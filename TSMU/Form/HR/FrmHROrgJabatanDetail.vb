Imports DevExpress.Data
Imports DevExpress.XtraTreeList

Public Class FrmHROrgJabatanDetail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim isLoad As Boolean = False
    Dim _Tag = New TagModel

    Dim JabID As String
    Dim ParentID As String
    Dim trListOrg As TreeList
    Dim dtTreeOrg As New DataTable
    Dim srvOrg As New HROrgService
    Dim modelJabatan As HROrgJabatanModel
    Dim modelOrgStruktur As HROrgStrukturModel

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal strCode As String,
                   ByVal strParentID As String,
                   ByVal TreeOrg As TreeList,
                   ByRef lf_FormParent As Form)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
        End If
        ParentID = strParentID
        trListOrg = TreeOrg
        FrmParent = lf_FormParent
        _Tag = New TagModel
        _Tag.PageIndex = lf_FormParent.Tag.PageIndex
        Tag = _Tag
    End Sub

    Private Sub FrmHROrgJabatanDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, False, False, False, False, False, False, False, False, False)
        Call InitialSetForm()
    End Sub

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                modelJabatan = New HROrgJabatanModel
                modelJabatan = srvOrg.GetJabatanByID(fs_Code)
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "JABATAN DETAIL"
            Else
                Me.Text = "NEW JABATAN"
            End If
            Call LoadTxtBox()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmHROrganisasi"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With modelJabatan
                    dtTglMulai.EditValue = .TglMulai
                    dtTglSelesai.EditValue = .TglSelesai
                    txtIDJabatan.Text = .OrgID
                    txtDeskripsi.Text = .OrgDesc
                    cbIsHead.Text = .IsHead
                    txtAlias.EditValue = .Alias_
                    txtKet.Text = .Ket
                    dtTglBuat.EditValue = .TglBuat
                    txtUserBuat.Text = .UserBuat
                    dtTglUbah.EditValue = .TglUbah
                    txtUserUbah.Text = .UserUbah
                End With
            Else
                dtTglMulai.EditValue = Date.Today
                dtTglSelesai.EditValue = Date.Parse("9999-12-31")
                cbIsHead.Text = "NO"
                dtTglBuat.EditValue = DateTime.Now
                txtUserBuat.Text = gh_Common.Username
                dtTglUbah.EditValue = DateTime.Now
                txtUserUbah.Text = gh_Common.Username
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Overrides Function ValidateSave() As Boolean
        Dim lb_Validated As Boolean = False
        Try
            Dim success As Boolean = True

            If DxValidationProvider1.Validate Then
                lb_Validated = True
            Else
                Err.Raise(ErrNumber, , "Data yang anda input tidak valid, silahkan cek inputan anda !")
            End If
            If dtTglMulai.EditValue > dtTglSelesai.EditValue Then
                Err.Raise(ErrNumber, , "Tanggal Mulai Tidak Boleh Lebih Besar Dari Tanggal Selesai !")
            ElseIf txtDeskripsi.Text = "" Then
                Err.Raise(ErrNumber, , "Deskripsi Tidak Boleh Kosong!")
            ElseIf srvOrg.CekPeriodParent(ParentID, dtTglMulai.EditValue, dtTglSelesai.EditValue) = False Then
                Err.Raise(ErrNumber, , "Period Tidak Boleh Lebih Besar Dari Period Parentnya!")
            ElseIf Not String.IsNullOrEmpty(fs_Code) AndAlso srvOrg.CekPeriodChild(fs_Code, dtTglMulai.EditValue, dtTglSelesai.EditValue) Then
                Err.Raise(ErrNumber, , "Period Tidak Boleh Lebih Kecil Dari Period Childnya!")
            End If

            If lb_Validated Then
                If isUpdate = False Then
                    JabID = srvOrg.GetAutoNumberJabID()
                    txtIDJabatan.Text = JabID
                End If

                Dim now As DateTime = DateTime.Now

                modelJabatan = New HROrgJabatanModel
                With modelJabatan
                    .TglMulai = dtTglMulai.EditValue
                    .TglSelesai = dtTglSelesai.EditValue
                    .OrgID = txtIDJabatan.Text
                    .OrgDesc = txtDeskripsi.Text
                    .IsHead = cbIsHead.Text
                    .Alias_ = txtAlias.Text
                    .Ket = txtKet.Text
                    If isUpdate = False Then
                        .TglBuat = now
                        .UserBuat = gh_Common.Username
                    Else
                        .TglBuat = dtTglBuat.EditValue
                        .UserBuat = txtUserBuat.Text
                    End If
                    .TglUbah = now
                    .UserUbah = gh_Common.Username
                End With

                modelOrgStruktur = New HROrgStrukturModel
                With modelOrgStruktur
                    .TglMulai = dtTglMulai.EditValue
                    .TglSelesai = dtTglSelesai.EditValue
                    .OrgID = ParentID
                    .OrgClass = "O"
                    .RelDir = "B"
                    .RelTipe = "01"
                    .Seq = 1
                    .RelClass = "P"
                    .RelOrg = txtIDJabatan.Text
                    .Ket = txtKet.Text
                    If isUpdate = False Then
                        .TglBuat = now
                        .UserBuat = gh_Common.Username
                    Else
                        .TglBuat = dtTglBuat.EditValue
                        .UserBuat = txtUserBuat.Text
                    End If
                    .TglUbah = now
                    .UserUbah = gh_Common.Username
                End With
            End If
        Catch ex As Exception
            lb_Validated = False
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
        Return lb_Validated
    End Function

    Public Overrides Sub Proc_SaveData()
        Try
            If isUpdate = False Then
                srvOrg.SaveNewOrgJabatan(modelJabatan, modelOrgStruktur)
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                srvOrg.SaveEditOrgJabatan(Date.Today, modelJabatan, modelOrgStruktur)
                Call ShowMessage(GetMessage(MessageEnum.UpdateBerhasil), MessageTypeEnum.NormalMessage)
            End If

            dtTreeOrg = srvOrg.GetStrukturOrg(Date.Today)
            trListOrg.DataSource = dtTreeOrg
            IsClosed = True
            Me.Hide()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

End Class
