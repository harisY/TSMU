Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Public Class frm_payment_aprrove_details
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim ObjPaymentHeader As New payment_header_models
    Dim ObjPaymentDetail As New payment_detail_models
    Dim GridDtl As GridControl

    Dim fs_Split As String = "'"

    Dim ObjFP As New Cls_FP
    Dim ObjPayment As New Cls_Payment
    Dim ObjCM As New Cls_cmdm
    Dim IsNew As Boolean
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal strCode As String,
                   ByVal strCode2 As String,
                   ByRef lf_FormParent As Form,
                   ByVal li_GridRow As Integer,
                   ByRef _Grid As GridControl, ByVal _IsNew As Boolean)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
            fs_Code2 = strCode2
            bi_GridParentRow = li_GridRow
            IsNew = _IsNew
        End If
        GridDtl = _Grid
        FrmParent = lf_FormParent
    End Sub
    Private Sub frm_payment_aprrove_details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If IsNew Then
            Call Proc_EnableButtons(False, True, False, True, False, False, False, False, True, True, True)
        Else
            Call Proc_EnableButtons(False, False, False, True, False, False, False, False, True, True, False)
        End If
        Call InitialSetForm()
    End Sub

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                ObjPaymentHeader.id = fs_Code
                ObjPaymentHeader.GetPaymentByVoucherNo()
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "Approval " & fs_Code
            Else
                Me.Text = "Approval New Data"
            End If
            Call LoadTxtBox()
            LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "frm_payment_approve"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With ObjPaymentHeader
                    _TxtPerpost.Text = .id
                    _txtVoucher.Text = .vrno
                    _TxtVendorName.Text = .VendorName
                    _TxtVendorID.Text = .VendID
                    _TxtTotal.Text = Format(.Tot_DPP + .Tot_PPN, "##,0")
                    _TxtAttentionTo.Text = .penerima
                    _TxtBankID.Text = .BankID
                    _TxtBankName.Text = .BankName
                    _TxtBiaya.EditValue = Format(.Biaya_Transfer, "##,0")
                    _TxtToBank.Text = .bankrek
                    _TxtCM.Text = .CM_DM
                    _TxtCurrency.Text = .CuryID
                    _TxtDebit.Text = Format((.Total_DPP_PPN + .PPh) - .PPh - .Biaya_Transfer - .CM_DM, "##,0")
                    _TxtNoRek.Text = .norek
                    _TxtDpp.Text = Format(.Tot_DPP, "##,0")
                    _TxtTgl.Text = Format(.tgl, "dd-MM-yyyy")
                    _TxtTMV.Text = ""
                    _TxtPPH.Text = Format(.PPh, "##,0")
                    _TxtPPN.Text = Format(.Tot_PPN, "##,0")

                End With
            Else
                _txtVoucher.Text = ""
                _TxtVendorName.Text = ""
                _TxtVendorID.Text = ""
                _TxtTotal.Text = "0"
                _TxtAttentionTo.Text = ""
                _TxtBankID.Text = ""
                _TxtBankName.Text = ""
                _TxtBiaya.EditValue = "2,500"
                _TxtToBank.Text = ""
                _TxtCM.Text = "0"
                _TxtCurrency.Text = ""
                _TxtDebit.Text = "0"
                _TxtNoRek.Text = ""
                _TxtDpp.Text = "0"
                _TxtTgl.EditValue = DateTime.Today
                _TxtTMV.Text = "0"
                _TxtPerpost.EditValue = Format(DateTime.Today, "yyyy-12")
                _TxtPPH.Text = "0"
                _TxtPPN.Text = "0"
                _TxtPerpost.Focus()
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Overrides Sub Proc_Refresh()
        LoadGridDetail()
        Call LoadTxtBox()
    End Sub

    Public Sub LoadGridDetailNew()
        Try
            Dim dtGrid As New DataTable
            dtGrid = ObjPayment.getalldataap2()

            If dtGrid.Rows.Count > 0 Then
                GridInvoice.DataSource = dtGrid
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub LoadGridDetail()
        Try
            Dim dtGrid As New DataTable
            ObjPaymentDetail.vrno = _txtVoucher.Text
            dtGrid = ObjPaymentDetail.GetPaymentByVoucherNo()
            GridInvoice.DataSource = dtGrid
            If dtGrid.Rows.Count > 0 Then
                GridCellFormat(GridView1)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Public Overrides Sub Proc_SaveData()
        'Try

        '    If isUpdate = False Then
        '        ObjPaymentHeader.InsertData()
        '        Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
        '    Else
        '    End If
        '    GridDtl.DataSource = ObjPaymentHeader.GetDataGrid()

        'Catch ex As Exception
        '    MsgBox(ex.Message)
        '    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        '    'ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        'End Try
    End Sub

    Public Overrides Sub Proc_Approve()
        Try
            Dim result As DialogResult = XtraMessageBox.Show("Approve Voucher " & "'" & _txtVoucher.Text & "'" & " ?", "Confirmation", MessageBoxButtons.YesNo)
            If result = System.Windows.Forms.DialogResult.Yes Then
                If gh_Common.Level = 2 Then
                    ObjPaymentHeader.UpdateCek(2)
                ElseIf gh_Common.Level = 3 Then
                    ObjPaymentHeader.UpdateCek(3)
                ElseIf gh_Common.Level = 4 Then
                    ObjPaymentHeader.UpdateCek(4)
                End If
            Else
                If gh_Common.Level = 2 Then
                    ObjPaymentHeader.UpdateUnCek(2)
                    ObjPaymentHeader.ObjPaymentDetails.Clear()
                    For i As Integer = 0 To GridView1.RowCount - 1
                        If GridView1.GetRowCellValue(i, "Check") = False Then
                            With ObjPaymentDetail
                                .vrno = _txtVoucher.Text.TrimEnd
                                .No_Invoice = GridView1.GetRowCellValue(i, "InvcNbr").ToString().TrimEnd
                                .UpdateCheckDetailByVrnoInvcId()
                            End With
                        End If
                    Next
                End If
            End If
            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            tsBtn_next.PerformClick()

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub RepositoryItemCheckEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.EditValueChanged
        GridInvoice.FocusedView.PostEditor()
    End Sub

End Class
