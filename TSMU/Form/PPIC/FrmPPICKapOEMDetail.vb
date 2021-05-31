Imports DevExpress.XtraGrid

Public Class FrmPPICKapOEMDetail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim _Tag = New TagModel

    Dim srvHR As New PPICService
    Dim modelHeader As PPICKapOEMModel
    Dim dtGridDetail As DataTable
    Dim GridDtl As GridControl
    Dim dataRow As DataRow

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Public Sub New(ByVal strCode As String,
                   ByVal strCode2 As String,
                   ByRef lf_FormParent As Form,
                   ByVal li_GridRow As Integer,
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

    Private Sub FrmPPICKapOEMDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False, False)
        Call InitialSetForm()
    End Sub

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                modelHeader = srvHR.GetDataKapOEMByID(fs_Code)
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "STANDAR PACKING DETAIL"
            Else
                Me.Text = "NEW STANDAR PACKING"
            End If
            Call LoadTxtBox()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmPPICKapOEM"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With modelHeader
                    txtModel.Text = .Model
                    txtLocation.Text = .Location
                    txtPartNo.Text = .PartNo
                    txtPartName.Text = .PartName
                    txtInventoryID.Text = .InventoryID
                    txtJenisPacking.Text = .JenisPacking
                    txtStandarQty.EditValue = .StandarQty
                    txtKapasitasMuat.EditValue = .KapasitasMuat
                    txtPartNo.Enabled = False
                    txtInventoryID.Enabled = False
                End With
            Else
                txtModel.Text = ""
                txtLocation.Text = ""
                txtPartNo.Text = ""
                txtPartName.Text = ""
                txtInventoryID.Text = ""
                txtJenisPacking.Text = ""
                txtStandarQty.EditValue = 0
                txtKapasitasMuat.EditValue = 0
                txtModel.Focus()
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        Call LoadTxtBox()
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

            If txtJenisPacking.EditValue = Nothing Then
                Err.Raise(ErrNumber, , "Jenis Packing Tidak Boleh Kosong!")
            End If

            If lb_Validated Then
                Dim Now As DateTime = DateTime.Now
                modelHeader = New PPICKapOEMModel
                With modelHeader
                    .ID = fs_Code
                    .Model = txtModel.EditValue
                    .Location = txtLocation.EditValue
                    .PartNo = txtPartNo.EditValue
                    .PartName = txtPartName.Text
                    .InventoryID = txtInventoryID.Text
                    .JenisPacking = txtJenisPacking.Text
                    .StandarQty = txtStandarQty.EditValue
                    .KapasitasMuat = txtKapasitasMuat.EditValue
                    .CreateBy = gh_Common.Username
                    .CreateDate = Now
                    .UpdateBy = gh_Common.Username
                    .UpdateDate = Now
                    If isUpdate = False Then
                        srvHR.CheckDuplicateKapOEM(modelHeader)
                    End If
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
                srvHR.InsertDataKapOEM(modelHeader)
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                srvHR.UpdateDataKapOEM(modelHeader)
                Call ShowMessage(GetMessage(MessageEnum.UpdateBerhasil), MessageTypeEnum.NormalMessage)
            End If

            GridDtl.DataSource = srvHR.GetDataKapOEM()
            IsClosed = True
            Me.Hide()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
        Dim ignoreCancel As Boolean = False
        txtJenisPacking.DoValidate()

        If DxValidationProvider1.GetInvalidControls().Contains(txtJenisPacking) Then
            ignoreCancel = True
        Else
            ignoreCancel = True
        End If

        MyBase.OnFormClosing(e)
        e.Cancel = Not ignoreCancel
    End Sub

    Private Sub txtJenisPacking_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtJenisPacking.ButtonClick
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = srvHR.GetDataJenisPacking
            ls_OldKode = txtJenisPacking.Text
            ls_Judul = "Buildup"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                Value2 = lF_SearchData.Values.Item(2).ToString.Trim
                txtJenisPacking.Text = Value1
                txtKapasitasMuat.EditValue = Value2
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub txtPartNo_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtPartNo.ButtonClick
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = srvHR.GetDataPart
            ls_OldKode = txtJenisPacking.Text
            ls_Judul = "Part No"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""
            Dim Value3 As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                Value3 = lF_SearchData.Values.Item(2).ToString.Trim
                txtPartNo.Text = Value1
                txtPartName.EditValue = Value2
                txtInventoryID.EditValue = Value3
                txtModel.Text = Microsoft.VisualBasic.Left(Value1, 3)
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

End Class
