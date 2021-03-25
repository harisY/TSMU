Imports DevExpress.Data
Imports DevExpress.XtraTreeList

Public Class FrmHROrgOrganisasiDetail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim isLoad As Boolean = False
    Dim _Tag = New TagModel

    Dim OrgID As String
    Dim ParentID As String
    Dim OrgLevel As String
    Dim trListOrg As TreeList
    Dim dtTreeOrg As New DataTable
    Dim srvOrg As New HROrgService
    Dim modelOrganisasi As HROrgOrganisasiModel
    Dim modelOrgStruktur As HROrgStrukturModel

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal strCode As String,
                   ByVal strParentID As String,
                   ByVal strOrgLevel As String,
                   ByVal TreeOrg As TreeList,
                   ByRef lf_FormParent As Form)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
        End If
        ParentID = strParentID
        OrgLevel = strOrgLevel
        trListOrg = TreeOrg
        FrmParent = lf_FormParent
        _Tag = New TagModel
        _Tag.PageIndex = lf_FormParent.Tag.PageIndex
        Tag = _Tag
    End Sub

    Private Sub FrmHROrgOrganisasiDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, False, False, False, False, False, False, False, False, False)
        Call InitialSetForm()
    End Sub

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                modelOrganisasi = New HROrgOrganisasiModel
                modelOrganisasi = srvOrg.GetOrganisasiByID(fs_Code)
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "ORGANISASI DETAIL"
            Else
                Me.Text = "NEW ORGANISASI"
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
                ListItemsOrgLevelEdit()
                With modelOrganisasi
                    dtTglMulai.EditValue = .TglMulai
                    dtTglSelesai.EditValue = .TglSelesai
                    txtOrgID.Text = .OrgID
                    txtDeskripsi.Text = .OrgDesc
                    txtLevel.EditValue = .OrgLevel
                    txtAlias.EditValue = .Alias_
                    txtKet.Text = .Ket
                    dtTglBuat.EditValue = .TglBuat
                    txtUserBuat.Text = .UserBuat
                    dtTglUbah.EditValue = .TglUbah
                    txtUserUbah.Text = .UserUbah
                End With
            Else
                ListItemsOrgLevelNew()
                dtTglMulai.EditValue = Date.Today
                dtTglSelesai.EditValue = Date.Parse("9999-12-31")
                dtTglBuat.EditValue = DateTime.Now
                txtUserBuat.Text = gh_Common.Username
                dtTglUbah.EditValue = DateTime.Now
                txtUserUbah.Text = gh_Common.Username
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub ListItemsOrgLevelNew()
        Dim dtOrgLevel = New DataTable
        dtOrgLevel = srvOrg.GetListOrgLevel()
        Dim Rows As DataRow() = dtOrgLevel.[Select]("OrgLevel > '" & OrgLevel & "'")
        txtLevel.Properties.DataSource = Rows.CopyToDataTable()
    End Sub

    Private Sub ListItemsOrgLevelEdit()
        Dim dtOrgLevel = New DataTable
        dtOrgLevel = srvOrg.GetListOrgLevel()
        Dim Rows As DataRow() = dtOrgLevel.[Select]("OrgLevel >= '" & OrgLevel & "'")
        txtLevel.Properties.DataSource = Rows.CopyToDataTable()
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
            ElseIf txtLevel.EditValue = "" Then
                Err.Raise(ErrNumber, , "Level Tidak Boleh Kosong!")
            End If

            If lb_Validated Then
                If isUpdate = False Then
                    OrgID = srvOrg.GetAutoNumberOrgID()
                    txtOrgID.Text = OrgID
                End If

                Dim now As DateTime = DateTime.Now

                modelOrganisasi = New HROrgOrganisasiModel
                With modelOrganisasi
                    .TglMulai = dtTglMulai.EditValue
                    .TglSelesai = dtTglSelesai.EditValue
                    .OrgID = txtOrgID.Text
                    .OrgDesc = txtDeskripsi.Text
                    .OrgLevel = txtLevel.EditValue
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
                    .RelClass = "O"
                    .RelOrg = txtOrgID.Text
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
                srvOrg.SaveNewOrgOrganisasi(modelOrganisasi, modelOrgStruktur)
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                'ObjSettleHeader.UpdateData(TxtNoSettlement.Text)
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
