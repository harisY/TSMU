Public Class FrmHROrgJabatanDetail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim isLoad As Boolean = False
    Dim _Tag = New TagModel

    Dim ParentID As String
    Dim ObjHROrgService As New HROrgService
    Dim modelJabatan As HROrgJabatanModel

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal strCode As String,
                   ByVal strParentID As String,
                   ByRef lf_FormParent As Form)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
        End If
        ParentID = strParentID
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
                modelJabatan = ObjHROrgService.GetJabatanByID(fs_Code)
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
                dtTglBuat.EditValue = DateTime.Now
                txtUserBuat.Text = gh_Common.Username
                dtTglUbah.EditValue = DateTime.Now
                txtUserUbah.Text = gh_Common.Username
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class
