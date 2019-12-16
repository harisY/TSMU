Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Public Class frm_AR_details
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim ObjPaymentHeader As New AR_Header_Models
    Dim ObjPaymentDetail As New ar_detail_models
    Dim GridDtl As GridControl

    Dim fs_Split As String = "'"
    Dim TotAmount As Double
    Dim ObjFP As New Cls_FP
    Dim ObjPayment As New Cls_Payment
    Dim ObjCM As New Cls_cmdm
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal strCode As String,
                   ByVal strCode2 As String,
                   ByVal strCode3 As String,
                   ByVal strCode4 As String,
                   ByVal strCode5 As String,
                   ByVal strCode6 As Double,
                   ByRef lf_FormParent As Form,
                   ByVal li_GridRow As Integer,
                   ByRef _Grid As GridControl)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
            fs_Code2 = strCode2
            fs_Code3 = strCode3
            'fs_Code4 = strCode4
            'fs_Code5 = strCode5
            'fs_Code6 = strCode6
            bi_GridParentRow = li_GridRow
        End If
        GridDtl = _Grid
        FrmParent = lf_FormParent
    End Sub
    Private Sub frm_payment_details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Call InitialSetForm()
    End Sub
    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Try
            If e.Column.FieldName = "Check" Then
                If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Check") = True Then
                    GetTot()
                Else
                    GetTot()

                End If
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub RepositoryItemCheckEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.EditValueChanged
        GridInvoice.FocusedView.PostEditor()
    End Sub
    Private Sub _TxtPerpost_EditValueChanged(sender As Object, e As EventArgs) Handles _TxtPerpost.EditValueChanged
        Try
            If fs_Code <> "" Then
            Else
                ObjPaymentHeader.PerPost = _TxtPerpost.Text
                _txtVoucher.Text = ObjPaymentHeader.VoucherNo
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub

    Private Sub _TxtPerpost_LostFocus(sender As Object, e As EventArgs) Handles _TxtPerpost.LostFocus
        Try
            If fs_Code <> "" Then
            Else
                ObjPaymentHeader.PerPost = _TxtPerpost.Text
                _txtVoucher.Text = ObjPaymentHeader.VoucherNo
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Overrides Function ValidateSave() As Boolean
        Dim lb_Validated As Boolean = True
        'Try
        '    If DxValidationProvider1.Validate Then
        '        lb_Validated = True
        '    Else
        '        Err.Raise(ErrNumber, , "Data yang anda input tidak valid, silahkan cek inputan anda !")
        '    End If
        '    If lb_Validated Then
        With ObjPaymentHeader
            .BankID = _TxtBankID.Text
            .BankName = _TxtBankName.Text

            .Biaya_Transfer = _TxtBiaya.Text
            .cek1 = "1"
            .cek2 = "0"
            .cek3 = "0"
            .cek4 = "0"
            .CM_DM = _TxtCM.Text
            .CuryID = _TxtCurrency.Text
            .Descr = ""
            .PPh = _TxtPPH.Text
            .prosespay = "0"
            .tgl = _TxtTgl.Text

            .uploaded = "0"
            .CustID = _TxtVendorID.Text
            .vrno = _txtVoucher.Text
            .CustomerName = _TxtVendorName.Text
            .Total_DPP_PPN = _TxtTotalAmount.Text
            .TotReceive = _TxtDebit.Text
        End With
        '    End If
        'Catch ex As Exception
        '    lb_Validated = False
        '    ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        '    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        'End Try
        Return lb_Validated
    End Function
    Public Overrides Sub Proc_SaveData()
        Try
            ObjPaymentHeader.ObjPaymentDetails.Clear()
            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "Check") = True Then
                    Dim ObjDetails As New ar_detail_models
                    With ObjDetails
                        .vrno = _txtVoucher.Text.TrimEnd
                        .No_Invoice = GridView1.GetRowCellValue(i, "InvcNbr").ToString().TrimEnd
                        .Tgl_Invoice = DateTime.Parse(GridView1.GetRowCellValue(i, "InvcDate").ToString())
                        .Jml_Invoice = GridView1.GetRowCellValue(i, "Amount")
                        .CuryID = GridView1.GetRowCellValue(i, "CuryId")
                        .Ppn = GridView1.GetRowCellValue(i, "Ppn")
                        .Dpp = GridView1.GetRowCellValue(i, "DPP")
                        .Pph = GridView1.GetRowCellValue(i, "PPH")
                        .No_Faktur = GridView1.GetRowCellValue(i, "fp").ToString().TrimEnd
                        .cek1 = True
                    End With
                    ObjPaymentHeader.ObjPaymentDetails.Add(ObjDetails)
                End If
            Next
            If isUpdate = True Then
                ObjPaymentHeader.InsertData()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                ObjPaymentHeader.UpdateData()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            End If
            GridDtl.DataSource = ObjPaymentHeader.GetDataGrid()
            ''IsClosed = True
            ''Me.Hide()

            LoadGridDetail()

            '_TxtVendorName.Text = ""
            '_TxtVendorID.Text = ""
            '_TxtBankID.Text = "11240"
            '_TxtBankName.Text = "MIZUHO IDR"
            '_TxtBiaya.EditValue = "2500"
            '_TxtPerpost.EditValue = Format(DateTime.Today, "yyyy-MM")
            '_TxtCM.Text = "0"
            '_TxtCurrency.Text = "IDR"
            '_TxtDebit.Text = "0"

            '_TxtPPH.Text = "0"

            _TxtPerpost.Focus()





        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            'ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
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
    Private Sub GetTot()

        TotAmount = 0

        ''GrandTotal = 0
        Dim cek As Boolean
        Try
            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "Check") = True Then
                    TotAmount = TotAmount + CDbl(GridView1.GetRowCellValue(i, "Amount"))
                End If

            Next


            If TotAmount = 0 Then
                _TxtTotalAmount.Text = "0"
            Else
                _TxtTotalAmount.Text = Format(TotAmount - _TxtBiaya.Text, gs_FormatBulat)
            End If

            '       Dim debit As Double = TotAmount - TotPPH - _TxtCM.Text - _txtCMDMmanual.Text - _TxtBiaya.Text
            '       _TxtDebit.Text = Format(debit, gs_FormatBulat)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                ObjPaymentHeader.NoBukti = fs_Code
                ObjPaymentHeader.GetReceiptByVoucherNo()
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "Payment " & fs_Code
            Else
                Me.Text = "Payment New Data"
            End If
            Call LoadTxtBox()
            ''  LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "frm_AR_details"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With ObjPaymentHeader
                    _TxtPerpost.Text = .PerPost
                    ObjPaymentHeader.PerPost = _TxtPerpost.Text
                    _txtVoucher.Text = ObjPaymentHeader.VoucherNo
                    _TxtTgl.Text = .tgl
                    _TxtBankID.Text = .AcctID_tujuan
                    _TxtBankName.Text = .Descr_tujuan
                    _TxtVendorName.Text = .Customer
                    _TxtVendorID.Text = .CustID
                    _TxtDebit.EditValue = Format(.Jumlah, "##,0")

                End With
            Else

                _TxtTgl.EditValue = DateTime.Today
                _TxtBankID.Text = ""
                _TxtBankName.Text = ""
                _TxtVendorName.Text = ""
                _TxtVendorID.Text = ""
                _TxtDebit.EditValue = "0"
                _TxtPerpost.EditValue = Format(DateTime.Today, "yyyy-MM")

            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Private Sub _TxtVendorID_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles _TxtVendorID.ButtonClick,
                                                                                                _TxtBankID.ButtonClick
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""
            ObjPaymentDetail.CuryID = _TxtCurrency.Text
            If sender.Name = _TxtVendorID.Name Then
                dtSearch = ObjPaymentDetail.GetCustomer
                ls_OldKode = _TxtVendorID.Text.Trim
                ls_Judul = "Customer"
            ElseIf sender.Name = _TxtBankID.Name Then
                dtSearch = ObjPaymentDetail.GetBank
                ls_OldKode = _TxtBankID.Text.Trim
                ls_Judul = "Bank"
            Else
                dtSearch = ObjPaymentDetail.GetDataGridCM_New(_TxtVendorID.Text)
                ls_OldKode = _TxtCM.Text.Trim
                ls_Judul = "CM/DM"
            End If

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""
            Dim Value3 As String = ""
            Dim Value4 As String = ""
            Dim Value5 As String = ""
            Dim Value6 As String = ""
            ''Dim value7 As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then

                If sender.Name = _TxtVendorID.Name AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                    Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                    Value2 = lF_SearchData.Values.Item(1).ToString.Trim

                    _TxtVendorID.Text = Value1
                    _TxtVendorName.Text = Value2

                    Dim dtGrid As New DataTable
                    ''dtGrid = ObjPaymentDetail.GetGridDetailPaymentByVendorID(Value1.TrimEnd)

                    dtGrid = ObjPaymentDetail.GetGridDetailPaymentByVendorID(Value1.TrimEnd)
                    If dtGrid.Rows.Count > 0 Then
                        GridInvoice.DataSource = dtGrid
                        GridCellFormat(GridView1)
                    End If
                ElseIf sender.Name = _TxtBankID.Name AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                    Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                    Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                    Value3 = lF_SearchData.Values.Item(2).ToString.Trim
                    _TxtBankID.Text = Value1
                    _TxtBankName.Text = Value2
                    _TxtCurrency.Text = Value3
                End If
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub _TxtVendorID_EditValueChanged(sender As Object, e As EventArgs) Handles _TxtVendorID.EditValueChanged
        Dim dtGrid As New DataTable
        ''dtGrid = ObjPaymentDetail.GetGridDetailPaymentByVendorID(Value1.TrimEnd)

        dtGrid = ObjPaymentDetail.GetGridDetailPaymentByVendorID(_TxtVendorID.Text.TrimEnd)
        If dtGrid.Rows.Count > 0 Then
            GridInvoice.DataSource = dtGrid
            GridCellFormat(GridView1)
        End If
    End Sub

    Private Sub _TxtBiaya_EditValueChanged(sender As Object, e As EventArgs) Handles _TxtBiaya.EditValueChanged
        If TotAmount = 0 Then
            _TxtTotalAmount.Text = _TxtBiaya.Text
        Else
            _TxtTotalAmount.Text = Format(TotAmount + _TxtBiaya.Text, gs_FormatBulat)
        End If
    End Sub
End Class
