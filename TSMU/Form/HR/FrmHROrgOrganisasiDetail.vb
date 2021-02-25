Public Class FrmHROrgOrganisasiDetail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim isLoad As Boolean = False
    Dim _Tag = New TagModel

    Dim ParentID As String
    Dim OrgLevel As String
    Dim ObjHROrgService As New HROrgService
    Dim modelOrganisasi As HROrgOrganisasiModel

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal strCode As String,
                   ByVal strParentID As String,
                   ByVal strOrgLevel As String,
                   ByRef lf_FormParent As Form)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
        End If
        ParentID = strParentID
        OrgLevel = strOrgLevel
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
                modelOrganisasi = ObjHROrgService.GetOrganisasiByID(fs_Code)
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
        dtOrgLevel = ObjHROrgService.GetListOrgLevel()
        Dim Rows As DataRow() = dtOrgLevel.[Select]("OrgLevel > '" & OrgLevel & "'")
        txtLevel.Properties.DataSource = Rows.CopyToDataTable()
    End Sub

    Private Sub ListItemsOrgLevelEdit()
        Dim dtOrgLevel = New DataTable
        dtOrgLevel = ObjHROrgService.GetListOrgLevel()
        Dim Rows As DataRow() = dtOrgLevel.[Select]("OrgLevel >= '" & OrgLevel & "'")
        txtLevel.Properties.DataSource = Rows.CopyToDataTable()
    End Sub

End Class
