Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class frm_fp_details
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim fc_Class As New clsBoM
    Dim GridDtl As GridControl

    Dim fs_Split As String = "'"

    Dim ObjFP As New Cls_FP
    Dim ModelFp As New Fp_Header
    Dim ObjPayment As New Cls_Payment
    Private Check As New RepositoryItemCheckEdit()

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
    End Sub

    Private Sub frm_fp_details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Call InitialSetForm()

    End Sub
    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                ModelFp.FPNo = fs_Code
                ModelFp.GetFakturPajakById()
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "FP " & fs_Code
            Else
                Me.Text = "FP New Data"
            End If
            LoadGridDetil()
            Call LoadTxtBox()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "frm_fp_new"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With ModelFp
                    _TxtNoTrans.Text = .FPNo
                    _LookUpSupplier.Text = .VendID
                    _TxtVendorName.Text = .Vend_Name
                    _TxtNPWP.Text = .npwp
                    _TxtJenisJasa.Text = .Jenis_Jasa
                    _DeDate.EditValue = .Tgl_fp
                    _TxtCurrency.Text = .CuryID
                    _TxtPPN.Text = Format(.Tot_Ppn, "##,0")
                    _TxtDppInvoice.Text = Format(.Tot_Dpp_Invoice, "##,0")
                    _TxtTotal.Text = Format(.Tot_Pph, "##,0")
                    _TxtPPH.Text = Format(.Tot_Pph, "##,0")
                    _LookUpSupplier.Properties.Buttons(0).Visible = False
                    _LookUpSupplier.Properties.ReadOnly = True
                End With
            Else
                ObjFP = New Cls_FP
                _TxtNoTrans.Text = ObjFP.autono()
                _LookUpSupplier.Text = ""
                _TxtVendorName.Text = ""
                _TxtNPWP.Text = ""
                _TxtJenisJasa.Text = ""
                _DeDate.EditValue = DateTime.Today
                _TxtCurrency.Text = ""
                _TxtPPN.Text = "0"
                _TxtDppInvoice.Text = "0"
                _TxtTotal.Text = "0"
                _TxtPPH.Text = "0"
                _LookUpSupplier.Properties.Buttons(0).Visible = True
                _LookUpSupplier.Properties.ReadOnly = False
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Overrides Sub Proc_Refresh()
        '_LookUpSupplier.EditValue = "N0329          "
        Call LoadTxtBox()
        LoadGridDetil()
    End Sub

    Private Sub loadGridByVendor()
        Try
            Dim dt As New DataTable
            If _LookUpSupplier.Text = "" Then
                    Exit Sub
                End If
            dt = ObjFP.GetDetailsGridFP(_LookUpSupplier.EditValue)
            If dt.Rows.Count > 0 Then
                _GridDetails.DataSource = dt
            Else
                _GridDetails.DataSource = dt
                XtraMessageBox.Show("Data tidak ditemukan !")
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Public Sub LoadGridDetil()
        Try
            Dim dtGrid As New DataTable
            ObjFP.Fp = fs_Code
            dtGrid = ModelFp.GetGridDetails
            _GridDetails.DataSource = dtGrid

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub RemoveEdit_ButtonClick(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs)
        XtraMessageBox.Show("Remove")
    End Sub

    Public Overrides Function ValidateSave() As Boolean
        Dim lb_Validated As Boolean = False
        Try


        Catch ex As Exception
            lb_Validated = False
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
        Return lb_Validated
    End Function
    Public Overrides Sub Proc_SaveData()
        Try

        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            'ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
    'Private Sub LoadSupplier()
    '    Try
    '        ObjPayment = New Cls_Payment
    '        Dim dtgrid As DataTable = New DataTable
    '        dtgrid = ObjPayment.supplier()
    '        _LookUpSupplier.Properties.DataSource = dtgrid
    '        _LookUpSupplier.Properties.ValueMember = "VendID"
    '        _LookUpSupplier.Properties.DisplayMember = "Name"
    '    Catch ex As Exception
    '        Throw ex
    '    End Try
    'End Sub

    Private Sub _LookUpSupplier_EditValueChanged(sender As Object, e As EventArgs) Handles _LookUpSupplier.EditValueChanged

    End Sub

    Private Sub _LookUpSupplier_Validated(sender As Object, e As EventArgs) Handles _LookUpSupplier.Validated

    End Sub

    Private Sub RepositoryItemButtonEdit1_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItemButtonEdit1.ButtonClick
        Try
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Check") = True Then

                With Frm_ScanFP

                    .StartPosition = FormStartPosition.CenterScreen
                    .ShowDialog()
                End With
            Else
                XtraMessageBox.Show("Data belum di checklist !")
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    'Dim PPH As String = String.Empty
    Dim TotPPH As Double
    Dim TotAmount As Double
    Dim TotDpp As Double
    Dim TotPPn As Double
    Private Sub GetTot()
        TotPPH = 0
        TotAmount = 0
        TotDpp = 0
        TotPPn = 0
        Try
            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "Check") = True Then
                    TotPPH = TotPPH + CDbl(GridView1.GetRowCellValue(i, "Pph"))
                    TotAmount = TotAmount + CDbl(GridView1.GetRowCellValue(i, "Amount"))
                    TotDpp = TotDpp + CDbl(GridView1.GetRowCellValue(i, "DPP"))
                    TotPPn = TotPPn + CDbl(GridView1.GetRowCellValue(i, "Ppn"))
                End If

            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub RepositoryItemButtonEdit2_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepositoryItemButtonEdit2.ButtonClick
        Dim FP As String = String.Empty
        Dim InvcNbr As String = String.Empty
        Dim DPP As String = String.Empty
        Try
            If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Check") = True Then
                Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        FP = GridView1.GetRowCellValue(rowHandle, "fp")
                        InvcNbr = GridView1.GetRowCellValue(rowHandle, "invcNbr")
                        DPP = GridView1.GetRowCellValue(rowHandle, "DPP")
                    End If
                Next rowHandle
                Dim f As frm_lookup_pph = New frm_lookup_pph(FP, _TxtNoTrans.Text, InvcNbr, DPP)
                With f
                    .StartPosition = FormStartPosition.CenterScreen
                    .ShowDialog()
                End With

                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Pph", f.PPHDetails)
                _TxtNoBuktiPot.Text = f.NoBuktiPotong

                GetTot()
                _TxtPPH.Text = Format(TotPPH, "#,#.##")
            Else
                XtraMessageBox.Show("Data belum di checklist !")
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub RepositoryItemCheckEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.EditValueChanged
        _GridDetails.FocusedView.PostEditor()
    End Sub
    Private Sub _LookUpSupplier_KeyDown(sender As Object, e As KeyEventArgs) Handles _LookUpSupplier.KeyDown, _TxtNPWP.KeyDown,
            _TxtJenisJasa.KeyDown, _TxtNoBuktiPot.KeyDown, _DeDate.KeyDown, _TxtCurrency.KeyDown, _TxtPPN.KeyDown, _TxtDppInvoice.KeyDown,
            _TxtTotal.KeyDown, _TxtPPH.KeyDown

        If e.KeyCode = Keys.Enter Then
            SendKeys.Send("{TAB}")
        End If

    End Sub

    Private Sub RepositoryItemButtonEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemButtonEdit2.EditValueChanged
        _GridDetails.FocusedView.PostEditor()
    End Sub
    Dim Amount As Double = 0
    Dim DPP As Double = 0
    Dim PPN As Double = 0
    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged

        Try
            If e.Column.FieldName = "Check" Then
                GetTot()

                If TotPPn = 0 Then
                    _TxtPPN.Text = "0"
                Else
                    _TxtPPN.Text = Format(TotPPn, "#,#.##")
                End If

                If TotDpp = 0 Then
                    _TxtDppInvoice.Text = "0"
                Else
                    _TxtDppInvoice.Text = Format(TotDpp, "#,#.##")
                End If

                If TotAmount = 0 Then
                    _TxtTotal.Text = "0"
                Else

                    _TxtTotal.Text = Format(TotAmount, "#,#.##")
                End If
                If TotPPH = 0 Then
                    _TxtPPH.Text = "0"
                Else

                    _TxtPPH.Text = Format(TotPPH, "#,#.##")
                End If
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub _LookUpSupplier_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles _LookUpSupplier.ButtonClick
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""


            If sender.Name = _LookUpSupplier.Name Then
                ObjFP = New Cls_FP()
                dtSearch = ObjFP.GetSupplierLookup
                ls_OldKode = _LookUpSupplier.Text.Trim
                ls_Judul = "Vendor"

            End If
            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim VendorID As String = ""
            Dim VendorName As String = ""
            Dim JenisJasa As String = ""
            Dim NPWP As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                VendorID = lF_SearchData.Values.Item(0).ToString.Trim
                VendorName = lF_SearchData.Values.Item(1).ToString.Trim
                JenisJasa = lF_SearchData.Values.Item(2).ToString.Trim
                NPWP = lF_SearchData.Values.Item(3).ToString.Trim
                _LookUpSupplier.Text = VendorID
                _TxtVendorName.Text = VendorName
                _TxtJenisJasa.Text = JenisJasa
                _TxtNPWP.Text = NPWP

                Dim dt As New DataTable
                If VendorID = "" Then
                    Exit Sub
                End If
                dt = ObjFP.GetDetailsGridFP(VendorID)
                If dt.Rows.Count > 0 Then
                    _GridDetails.DataSource = dt
                    _DeDate.Focus()
                Else
                    _GridDetails.DataSource = dt
                    XtraMessageBox.Show("Invoice " & "[" & VendorName & "]" & " Kosong !")
                End If
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
End Class
