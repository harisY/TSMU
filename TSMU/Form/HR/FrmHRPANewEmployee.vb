Imports DevExpress.XtraGrid

Public Class FrmHRPANewEmployee
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim isLoad As Boolean = False
    Dim _Tag = New TagModel

    Dim GridDtl As GridControl
    Dim modelDataPribadi As HRPADataPribadiModel
    Dim modelDataKaryawan As HRPADataKaryawanModel
    Dim srvHR As New HRPAService

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal strCode As String,
                   ByVal strCode2 As String,
                   ByVal li_GridRow As Integer,
                   ByRef lf_FormParent As Form,
                   ByRef _Grid As GridControl)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
            fs_Code2 = strCode2
            bi_GridParentRow = li_GridRow
        End If
        GridDtl = _Grid
        FrmParent = lf_FormParent
        _Tag = New TagModel
        _Tag.PageIndex = lf_FormParent.Tag.PageIndex
        Tag = _Tag
    End Sub

    Private Sub FrmHRAdministrasiKaryawanDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, False, False, False, False, False, False, False, False, False)
        Call InitialSetForm()
    End Sub

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "KARYAWAN DETAIL"
            Else
                Me.Text = "NEW KARYAWAN"
            End If
            Call LoadTxtBox()
            'LoadGridDataPribadi()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmHRAdministrasiKaryawan"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        ListItemsPerpindahan()
        ListItemsGolongan()
        ListItemsOrganisasi()
        Dim dtTreeOrg As New DataTable
        dtTreeOrg = srvHR.GetStrukturOrg()
        txtJabatan.Properties.DataSource = dtTreeOrg
        dtHTglMulai.EditValue = Date.Today
        dtTglMulai.EditValue = Date.Today
        dtTglSelesai.EditValue = Date.Parse("9999-12-31")
        dtDKTglMulai.EditValue = Date.Today
        dtDKTglSelesai.EditValue = Date.Parse("9999-12-31")
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

            'If txtNIK.Text = "" OrElse txtNama.Text = "" OrElse txtGolongan.Text = "" Then
            '    Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
            'ElseIf Len(txtNIK.Text) <> 9 Then
            '    Err.Raise(ErrNumber, , "NIK harus 9 digit !")
            'ElseIf GridViewAdvance.RowCount = 0 Then
            '    Err.Raise(ErrNumber, , "Data detail tidak boleh kosong !")
            'End If

            If lb_Validated Then
                'Dim status As String = "CREATE"
                'Dim approved As String = "CREATE"
                'If isUpdate = False Then
                '    clsGlobal = New GlobalService
                '    noRequest = clsGlobal.GetAutoNumber(FrmParent)
                '    getDataDetail()
                '    txtNoRequest.Text = noRequest
                'Else
                '    noRequest = txtNoRequest.Text
                '    getDataDetail()
                '    If FrmParent.Name = "FrmTravelTicket" Then
                '        approved = ObjTravelRequest.Approved
                '        status = ObjTravelRequest.Status
                '    End If
                'End If
                'With ObjTravelRequest
                '    .NoRequest = txtNoRequest.Text
                '    .Nama = txtNama.Text.Trim.ToUpper
                '    .DeptID = txtDepartement.Text.Trim.ToUpper
                '    .TravelType = txtTravelType.Text.Trim.ToUpper
                '    .NIK = txtNIK.Text.Trim.ToUpper
                '    .Golongan = txtGolongan.EditValue
                '    .Purpose = txtPurpose.Text.Trim.ToUpper
                '    .Status = status
                '    .Approved = approved
                '    .Comment = ""
                'End With
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
            'If isUpdate = False Then
            '    ObjTravelRequest.InsertData(FrmParent)
            '    Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            'Else
            '    ObjTravelRequest.NoRequest = txtNoRequest.Text
            '    ObjTravelRequest.UpdateData()
            '    Call ShowMessage(GetMessage(MessageEnum.UpdateBerhasil), MessageTypeEnum.NormalMessage)
            'End If

            IsClosed = True
            Me.Hide()

        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub txtAction_SelectedIndexChanged(sender As Object, e As EventArgs) Handles txtAction.SelectedIndexChanged
        If txtAction.Text = "FROM APPLICANT" Then
            txtApplicantID.Enabled = True
        Else
            txtApplicantID.Enabled = False
        End If
    End Sub

    Private Sub dtHTglMulai_EditValueChanged(sender As Object, e As EventArgs) Handles dtHTglMulai.EditValueChanged
        dtTglMulai.EditValue = dtHTglMulai.EditValue
        dtDKTglMulai.EditValue = dtHTglMulai.EditValue
    End Sub

    Private Sub ListItemsPerpindahan()
        Dim dtPerpindahan = New DataTable
        dtPerpindahan = srvHR.GetListPerpindahan()
        cbPerpindahan.Properties.DataSource = dtPerpindahan
    End Sub

    Private Sub ListItemsAlasan(perpindahan As String)
        Dim dtAlasan = New DataTable
        dtAlasan = srvHR.GetListAlasan(perpindahan)
        cbAlasan.Properties.DataSource = dtAlasan
    End Sub

    Private Sub ListItemsGolongan()
        Dim dtGolongan = New DataTable
        dtGolongan = srvHR.GetListGolongan()
        cbGolongan.Properties.DataSource = dtGolongan
    End Sub

    Private Sub ListItemsOrganisasi()
        Dim dtOrganisasi = New DataTable
        dtOrganisasi = srvHR.GetListOrganisasi()
        cbOrganisasi.Properties.DataSource = dtOrganisasi
    End Sub

End Class
