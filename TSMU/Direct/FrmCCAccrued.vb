Imports DevExpress.Data
Imports DevExpress.LookAndFeel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Imports TSMU

Public Class FrmCCAccrued
    Dim cls_Accrued As New ClsCCAccrued
    Dim clsReport As New ClsReportCCAccrued
    Dim clsGlobal As New GlobalService

    Dim dtGrid As New DataTable
    Dim dtGridAccrued As New DataTable
    Dim TabPage As String
    Dim dtSummaryProses As New DataTable
    Dim dtSummarySettle As New DataTable
    Dim dtSummaryPaid As New DataTable

    Private Sub FrmCCAccrued_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call Proc_EnableButtons(False, False, False, True, False, False, False, True, False, False, False, False)
        XtraTabControl1.SelectedTabPage = TabPageProses
        TabPage = XtraTabControl1.SelectedTabPage.Name
        LoadGridAccrued()
    End Sub

    Public Overrides Sub Proc_Refresh()
        TabPage = XtraTabControl1.SelectedTabPage.Name()
        If TabPage = "TabPageProses" Then
            Call Proc_EnableButtons(False, False, False, True, False, False, False, True, False, False, False, False)
            LoadGridAccrued()
        ElseIf TabPage = "TabPageCancel" Then
            Call Proc_EnableButtons(False, False, False, True, False, False, False, True, False, False, False, True)
            LoadGridAccruedSette()
        ElseIf TabPage = "TabPagePaid" Then
            'Tidak dipakai jadi 1 dengan settlement
            Call Proc_EnableButtons(False, False, False, True, False, False, False, False, False, False, False, True)
            LoadGridAccruedPaid()
        End If
    End Sub

    Public Overrides Sub Proc_Search()
        Try
            Dim Status As List(Of String) = New List(Of String)({"All", "Accrued", "Paid"})
            Dim _status As String = String.Empty

            Dim fSearch As New frmAdvanceSearch(Status)
            With fSearch
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()
                Select Case .Status.ToLower
                    Case "All"
                        _status = "0,1"
                    Case "Accrued"
                        _status = "0"
                    Case "Paid"
                        _status = "1"
                End Select
            End With

            Dim _now As Date = Date.Today
            Dim firstDay As Date = If(IsDBNull(fSearch.TglDari), New Date(_now.Year, _now.Month, 1), fSearch.TglDari)
            Dim lastDay As Date = If(IsDBNull(fSearch.TglSampai), _now.AddMonths(1).AddDays(-1), fSearch.TglSampai)

            LoadGridAccruedSetteWithFilter(firstDay, lastDay, _status)

        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Public Overrides Sub Proc_Print()
        Dim param As String
        Dim listNoTrans As New List(Of String)
        If TabPage = "TabPageProses" Then
            For i As Integer = 0 To GridViewAccrued.RowCount - 1
                Dim noTrans As String = GridViewAccrued.GetRowCellValue(i, "NoTransaksi")
                If Not listNoTrans.Contains(noTrans) Then
                    listNoTrans.Add(noTrans)
                End If
            Next
            param = String.Join(",", listNoTrans.ToArray)

            clsReport = New ClsReportCCAccrued
            Dim lapAccrued As New DRCCAccrued
            Dim dtAccrued As New DataTable

            dtAccrued = clsReport.LoadReportAccrued(txtPerpost.EditValue, param)

            lapAccrued.DataSource = dtAccrued
            Dim PrintTool As ReportPrintTool

            PrintTool = New ReportPrintTool(lapAccrued)
            TryCast(PrintTool.Report, XtraReport).Tag = PrintTool
            PrintTool.ShowPreview(UserLookAndFeel.Default)
        Else
            'Dim firstDay As Date = New Date(txtPerpostSett.EditValue.Year, txtPerpostSett.EditValue.Month, 1)
            'Dim nexMonth = firstDay.AddMonths(1)
            'Dim filter As String = "[PerpostDate] >= '" & firstDay.ToShortDateString & "' And [PerpostDate] <= '" & nexMonth.ToShortDateString & "'"
            'GridViewAccruedAll.Columns("PerpostDate").FilterInfo = New ColumnFilterInfo(filter)

            'For i As Integer = 0 To GridViewAccruedAll.RowCount - 1
            '    Dim noTrans As String = GridViewAccruedAll.GetRowCellValue(i, "NoTransaksi")
            '    If Not listNoTrans.Contains(noTrans) Then
            '        listNoTrans.Add(noTrans)
            '    End If
            'Next
            'GridViewAccruedAll.ClearColumnsFilter()
            'GridViewAccruedAll.SelectAll()

            param = String.Join(",", listNoTrans.ToArray)

            clsReport = New ClsReportCCAccrued
            Dim lapAccruedSettle As New DRCCAccruedAndSettle
            Dim dtAccruedSettle As New DataTable

            dtAccruedSettle = clsReport.LoadReportAccruedAndSettle(txtPerpostSett.EditValue, param)

            lapAccruedSettle.DataSource = dtAccruedSettle
            Dim PrintTool As ReportPrintTool

            PrintTool = New ReportPrintTool(lapAccruedSettle)
            TryCast(PrintTool.Report, XtraReport).Tag = PrintTool
            PrintTool.ShowPreview(UserLookAndFeel.Default)
        End If
    End Sub

    Private Sub CreateTable()
        dtSummaryProses = New DataTable
        dtSummaryProses.Columns.AddRange(New DataColumn(4) {New DataColumn("SumAmountOriUSD", GetType(Double)),
                                                            New DataColumn("SumAmountOriYEN", GetType(Double)),
                                                            New DataColumn("SumAmountOriIDR", GetType(Double)),
                                                            New DataColumn("SumAccrualEstimate", GetType(Double)),
                                                            New DataColumn("SumAmountIDR", GetType(Double))})
    End Sub

    Private Sub LoadGridAccrued()
        Try
            cls_Accrued = New ClsCCAccrued
            btnProses.Enabled = False
            txtCCNumber.EditValue = ""
            txtAccountName.Text = ""
            txtPerpost.EditValue = Date.Today
            cls_Accrued.CreditCardNumber = IIf(txtCCNumber.EditValue Is Nothing, "", txtCCNumber.EditValue)
            dtGridAccrued = cls_Accrued.GetDataCostCC()
            GridAccrued.DataSource = dtGridAccrued
            Dim colCCNumber As GridColumn = GridViewAccrued.Columns("CreditCardNumber")
            Dim colAccountName As GridColumn = GridViewAccrued.Columns("AccountName")
            Dim colBankName As GridColumn = GridViewAccrued.Columns("BankName")
            colCCNumber.Visible = True
            colAccountName.Visible = True
            colBankName.Visible = True
            colCCNumber.VisibleIndex = 1
            colAccountName.VisibleIndex = 2
            colBankName.VisibleIndex = 3
            GridViewAccrued.BestFitColumns()
            'GridViewAccrued.SelectAll()
            'GroupingGrid(GridViewAccrued)

            dtSummaryProses = New DataTable
            cls_Accrued = New ClsCCAccrued
            cls_Accrued.CreditCardNumber = IIf(txtCCNumber.EditValue Is Nothing, "", txtCCNumber.EditValue)
            dtSummaryProses = cls_Accrued.GetDataCostCCSum()
            GridSumAccrued.DataSource = dtSummaryProses
            GridViewSumAccrued.OptionsView.ShowFooter = True
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadGridAccruedWithFilter()
        Try
            cls_Accrued = New ClsCCAccrued
            btnProses.Enabled = True
            cls_Accrued.CreditCardNumber = IIf(txtCCNumber.EditValue Is Nothing, "", txtCCNumber.EditValue)
            dtGridAccrued = cls_Accrued.GetDataCostCCFilter()
            GridAccrued.DataSource = dtGridAccrued
            Dim colCCNumber As GridColumn = GridViewAccrued.Columns("CreditCardNumber")
            Dim colAccountName As GridColumn = GridViewAccrued.Columns("AccountName")
            Dim colBankName As GridColumn = GridViewAccrued.Columns("BankName")
            colBankName.Visible = False
            colAccountName.Visible = False
            colCCNumber.Visible = False
            GridViewAccrued.BestFitColumns()
            'GridViewAccrued.SelectAll()
            'GroupingGrid(GridViewAccrued)
            hitungSummaryProses()
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadGridAccruedSette()
        Try
            cls_Accrued = New ClsCCAccrued
            txtPerpostSett.EditValue = Date.Today
            dtGrid = cls_Accrued.GetDataCCSettle()
            GridAccruedAll.DataSource = dtGrid
            GridViewAccruedAll.BestFitColumns()
            GridViewAccruedAll.SelectAll()

            dtSummarySettle = New DataTable
            cls_Accrued = New ClsCCAccrued
            dtSummarySettle = cls_Accrued.GetDataCCSettleSum()
            GridSumSettle.DataSource = dtSummarySettle
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadGridAccruedSetteWithFilter(dateFrom As Date, dateTo As Date, status As String)
        Try
            cls_Accrued = New ClsCCAccrued
            dtGrid = cls_Accrued.GetDataCCSettleFilter(dateFrom, dateTo, status)
            GridAccruedAll.DataSource = dtGrid
            GridViewAccruedAll.BestFitColumns()
            GridViewAccruedAll.SelectAll()

            dtSummarySettle = New DataTable
            cls_Accrued = New ClsCCAccrued
            dtSummarySettle = cls_Accrued.GetDataCCSettleSumFilter(dateFrom, dateTo, status)
            GridSumSettle.DataSource = dtSummarySettle
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadGridAccruedPaid(Optional dateFrom As Date = Nothing, Optional dateTo As Date = Nothing)
        Try
            Dim firstDay As Date = dateFrom
            Dim lastDay As Date = dateTo

            If dateFrom = Nothing OrElse dateTo = Nothing Then
                Dim _now As Date = Date.Today
                firstDay = New Date(_now.Year, _now.Month, 1)
                lastDay = New Date(_now.Year, _now.Month, Date.DaysInMonth(_now.Year, _now.Month))
            End If

            cls_Accrued = New ClsCCAccrued
            dtGrid = cls_Accrued.GetDataCCPaid(firstDay, lastDay)
            GridAccruedPaid.DataSource = dtGrid
            GridViewAccruedPaid.BestFitColumns()

            dtSummaryPaid = New DataTable
            cls_Accrued = New ClsCCAccrued
            dtSummaryPaid = cls_Accrued.GetDataCCPaidSum(firstDay, lastDay)
            GridSumPaid.DataSource = dtSummaryPaid

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub hitungSummaryProses()
        dtSummaryProses.Clear()
        If GridViewAccrued.RowCount > 0 Then
            If GridViewAccrued.SelectedRowsCount > 0 Then
                Dim sumAmountOriUSD As Double = 0
                Dim sumAmountOriYEN As Double = 0
                Dim sumAmountOriIDR As Double = 0
                Dim sumAccrualEstimate As Double = 0
                Dim sumAmountIDR As Double = 0
                Dim curryID As String
                Dim amountOri As Double = 0

                For i As Integer = 0 To GridViewAccrued.SelectedRowsCount() - 1
                    Dim rowIndex As Integer = GridViewAccrued.GetSelectedRows()(i)
                    If rowIndex >= 0 Then
                        curryID = IIf(GridViewAccrued.GetRowCellValue(rowIndex, "CurryID") Is DBNull.Value, "", GridViewAccrued.GetRowCellValue(rowIndex, "CurryID"))
                        amountOri = IIf(GridViewAccrued.GetRowCellValue(rowIndex, "Amount") Is DBNull.Value, 0, GridViewAccrued.GetRowCellValue(rowIndex, "Amount"))
                        sumAccrualEstimate = sumAccrualEstimate + IIf(GridViewAccrued.GetRowCellValue(rowIndex, "AccrualEstimate") Is DBNull.Value, 0, GridViewAccrued.GetRowCellValue(rowIndex, "AccrualEstimate"))
                        sumAmountIDR = sumAmountIDR + IIf(GridViewAccrued.GetRowCellValue(rowIndex, "AmountIDR") Is DBNull.Value, 0, GridViewAccrued.GetRowCellValue(rowIndex, "AmountIDR"))
                        If curryID = "USD" Then
                            sumAmountOriUSD = sumAmountOriUSD + amountOri
                        ElseIf curryID = "JPY" Then
                            sumAmountOriYEN = sumAmountOriYEN + amountOri
                        ElseIf curryID = "IDR" Then
                            sumAmountOriIDR = sumAmountOriIDR + amountOri
                        End If
                    End If
                Next
                Dim newRow As DataRow
                newRow = dtSummaryProses.NewRow
                newRow("SumCCMaster") = txtCCNumber.EditValue
                newRow("SumAccountName") = txtAccountName.Text
                newRow("SumAmountOriUSD") = sumAmountOriUSD
                newRow("SumAmountOriYEN") = sumAmountOriYEN
                newRow("SumAmountOriIDR") = sumAmountOriIDR
                newRow("SumAccrualEstimate") = sumAccrualEstimate
                newRow("SumAmountIDR") = sumAmountIDR
                dtSummaryProses.Rows.Add(newRow)
                GridSumAccrued.DataSource = dtSummaryProses
            Else
                Dim newRow As DataRow
                newRow = dtSummaryProses.NewRow
                newRow("SumCCMaster") = txtCCNumber.EditValue
                newRow("SumAccountName") = txtAccountName.Text
                newRow("SumAmountOriUSD") = 0
                newRow("SumAmountOriYEN") = 0
                newRow("SumAmountOriIDR") = 0
                newRow("SumAccrualEstimate") = 0
                newRow("SumAmountIDR") = 0
                dtSummaryProses.Rows.Add(newRow)
                GridSumAccrued.DataSource = dtSummaryProses
            End If
        End If
        GridViewSumAccrued.OptionsView.ShowFooter = False
    End Sub

    Private Sub GroupingGrid(view As GridView)
        Dim colTanggalTrans As GridColumn = view.Columns("TanggalTransaksi")
        Dim colCCNumber As GridColumn = view.Columns("CreditCardNumber")
        Dim colAmountIDR As GridColumn = view.Columns("AmountIDR")
        Dim colAccountName As GridColumn = view.Columns("AccountName")
        Dim colBankName As GridColumn = view.Columns("BankName")
        Dim colType As GridColumn = view.Columns("Type")
        colType.GroupIndex = 0
        colType.SortIndex = 0
        colType.SortOrder = ColumnSortOrder.Ascending
        view.ExpandAllGroups()
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        tsBtn_refresh.PerformClick()
    End Sub

    Private Sub btnProses_Click(sender As Object, e As EventArgs) Handles btnProses.Click
        Try
            If GridViewAccrued.SelectedRowsCount > 0 Then
                Dim noAccrued As String
                clsGlobal = New GlobalService
                noAccrued = clsGlobal.GetAutoNumber(Me)
                Dim Rows As New ArrayList()
                For i As Integer = 0 To GridViewAccrued.SelectedRowsCount() - 1
                    Dim rowIndex As Integer = GridViewAccrued.GetSelectedRows()(i)
                    If rowIndex >= 0 Then
                        Rows.Add(GridViewAccrued.GetDataRow(rowIndex))
                        If GridViewAccrued.GetRowCellValue(rowIndex, "AmountIDR") = 0 Then
                            Throw New Exception("Amount Settlement tidak boleh 0!")
                        End If
                    End If
                Next
                cls_Accrued.InsertData(Me, txtPerpost.EditValue, noAccrued, txtCCNumber.EditValue, Rows)
                Dim perpostDate As Date = txtPerpost.EditValue
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                tsBtn_refresh.PerformClick()

                clsReport = New ClsReportCCAccrued
                Dim lapCCSettle As New DRCCSettlement
                Dim dtCCSettle As New DataTable

                dtCCSettle = clsReport.LoadReportCCSettle(perpostDate, noAccrued)

                lapCCSettle.DataSource = dtCCSettle
                Dim PrintTool As ReportPrintTool

                PrintTool = New ReportPrintTool(lapCCSettle)
                TryCast(PrintTool.Report, XtraReport).Tag = PrintTool
                PrintTool.ShowPreview(UserLookAndFeel.Default)


            Else
                MessageBox.Show("Tidak ada data yang dipilih", "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            If GridViewAccruedAll.SelectedRowsCount > 0 Then
                If MsgBox("Are You Sure Cancel Data", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                    Dim Rows As New ArrayList()
                    For i As Integer = 0 To GridViewAccruedAll.SelectedRowsCount() - 1
                        If (GridViewAccruedAll.GetSelectedRows()(i) >= 0) Then
                            Rows.Add(GridViewAccruedAll.GetDataRow(GridViewAccruedAll.GetSelectedRows()(i)))
                        End If
                        Dim Row As DataRow = CType(Rows(0), DataRow)
                        If Row("Pay") = 1 Then
                            MessageBox.Show("No Accrued " & Row("NoAccrued") & " sudah dilakukan pembayaran", "Warning",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Exclamation,
                                   MessageBoxDefaultButton.Button1)
                            Exit Sub
                        End If
                    Next
                    cls_Accrued.DeleteData(Rows)
                    Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)
                    tsBtn_refresh.PerformClick()
                End If
            Else
                MessageBox.Show("Tidak ada data yang dipilih", "Warning",
                       MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation,
                       MessageBoxDefaultButton.Button1)
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub txtCCNumber_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles txtCCNumber.ButtonClick
        Dim ls_Judul As String = ""
        Dim dtSearch As New DataTable

        cls_Accrued = New ClsCCAccrued
        dtSearch = cls_Accrued.GetCreditCard
        ls_Judul = "CREDIT CARD"

        Dim lF_SearchData As FrmSystem_LookupGrid
        lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
        lF_SearchData.Text = "Select Data " & ls_Judul
        lF_SearchData.StartPosition = FormStartPosition.CenterScreen
        lF_SearchData.ShowDialog()

        If lF_SearchData.Values IsNot Nothing Then
            txtCCNumber.EditValue = lF_SearchData.Values.Item(2).ToString.Trim
            txtAccountName.Text = lF_SearchData.Values.Item(0).ToString.Trim + " - " + lF_SearchData.Values.Item(1).ToString.Trim
            LoadGridAccruedWithFilter()
        End If

        lF_SearchData.Close()
    End Sub

    Private Sub CAmountIDR_EditValueChanged(sender As Object, e As EventArgs) Handles CAmountIDR.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim amount As Double
        Dim rate As Double
        Dim amountIDR As Double
        amount = GridViewAccrued.GetRowCellValue(GridViewAccrued.FocusedRowHandle, "Amount")
        amountIDR = GridViewAccrued.GetRowCellValue(GridViewAccrued.FocusedRowHandle, "AmountIDR")
        rate = amountIDR / amount

        GridViewAccrued.SetRowCellValue(GridViewAccrued.FocusedRowHandle, "Rate", rate)
        hitungSummaryProses()
    End Sub

    Private Sub GridViewAccrued_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles GridViewAccrued.SelectionChanged
        If txtCCNumber.EditValue <> "" Then
            Dim __isChecked As Boolean = GridViewAccrued.IsRowSelected(GridViewAccrued.FocusedRowHandle)
            If __isChecked = True Then
                For i As Integer = 0 To GridViewAccrued.RowCount - 1
                    If GridViewAccrued.GetRowCellValue(i, "NoTransaksi") = GridViewAccrued.GetRowCellValue(GridViewAccrued.FocusedRowHandle, "NoTransaksi") Then
                        GridViewAccrued.SelectRow(i)
                    End If
                Next
            Else
                For i As Integer = 0 To GridViewAccrued.RowCount - 1
                    If GridViewAccrued.GetRowCellValue(i, "NoTransaksi") = GridViewAccrued.GetRowCellValue(GridViewAccrued.FocusedRowHandle, "NoTransaksi") Then
                        GridViewAccrued.UnselectRow(i)
                    End If
                Next
            End If
            For i As Integer = 0 To GridViewAccrued.RowCount - 1
                Dim isChecked As Boolean = GridViewAccrued.IsRowSelected(i)
                If isChecked = False Then
                    GridViewAccrued.SetRowCellValue(i, "AmountIDR", 0)
                    If GridViewAccrued.GetRowCellValue(i, "CurryID") = "IDR" Then
                        GridViewAccrued.SetRowCellValue(i, "Rate", 1)
                    Else
                        GridViewAccrued.SetRowCellValue(i, "Rate", 0)
                    End If
                Else
                    If GridViewAccrued.GetRowCellValue(i, "CurryID") = "IDR" Then
                        GridViewAccrued.SetRowCellValue(i, "AmountIDR", GridViewAccrued.GetRowCellValue(i, "Amount"))
                    End If
                End If
            Next
            hitungSummaryProses()
        Else
            GridViewAccrued.ClearSelection()
            'Dim __isChecked As Boolean = GridViewAccrued.IsRowSelected(GridViewAccrued.FocusedRowHandle)
            'If __isChecked = True Then
            '    For i As Integer = 0 To GridViewAccrued.RowCount - 1
            '        If GridViewAccrued.GetRowCellValue(i, "NoTransaksi") = GridViewAccrued.GetRowCellValue(GridViewAccrued.FocusedRowHandle, "NoTransaksi") Then
            '            GridViewAccrued.SelectRow(i)
            '        End If
            '    Next
            'Else
            '    For i As Integer = 0 To GridViewAccrued.RowCount - 1
            '        If GridViewAccrued.GetRowCellValue(i, "NoTransaksi") = GridViewAccrued.GetRowCellValue(GridViewAccrued.FocusedRowHandle, "NoTransaksi") Then
            '            GridViewAccrued.UnselectRow(i)
            '        End If
            '    Next
            'End If
        End If
    End Sub

    Private Sub GridViewAccrued_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles GridViewAccrued.RowCellClick
        If GridViewAccrued.FocusedColumn.Name = "GAmountIDR" Then
            If txtCCNumber.EditValue = "" Then
                GridViewAccrued.OptionsBehavior.Editable = False
                GridViewAccrued.OptionsSelection.EnableAppearanceFocusedRow = False
            Else
                Dim isChecked As Boolean = GridViewAccrued.IsRowSelected(GridViewAccrued.FocusedRowHandle)
                Dim curryID As String = GridViewAccrued.GetRowCellValue(GridViewAccrued.FocusedRowHandle, "CurryID")
                If isChecked AndAlso curryID <> "IDR" Then
                    GridViewAccrued.OptionsBehavior.Editable = True
                Else
                    GridViewAccrued.OptionsBehavior.Editable = False
                End If
            End If
        End If
    End Sub

    Private Sub GridViewAccruedAll_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles GridViewAccruedAll.SelectionChanged
        Dim isChecked As Boolean = GridViewAccruedAll.IsRowSelected(GridViewAccruedAll.FocusedRowHandle)
        If isChecked = True Then
            For i As Integer = 0 To GridViewAccruedAll.RowCount - 1
                If GridViewAccruedAll.GetRowCellValue(i, "NoAccrued") = GridViewAccruedAll.GetRowCellValue(GridViewAccruedAll.FocusedRowHandle, "NoAccrued") Then
                    GridViewAccruedAll.SelectRow(i)
                End If
            Next
        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim param As String
        Dim listNoAccrued As New List(Of String)
        Dim firstDay As Date = New Date(txtPerpostSett.EditValue.Year, txtPerpostSett.EditValue.Month, 1)
        Dim nexMonth = firstDay.AddMonths(1)
        Dim filter As String = "[PerpostDate] >= '" & firstDay.ToShortDateString & "' And [PerpostDate] <= '" & nexMonth.ToShortDateString & "'"
        GridViewAccruedAll.Columns("PerpostDate").FilterInfo = New ColumnFilterInfo(filter)

        For i As Integer = 0 To GridViewAccruedAll.RowCount - 1
            Dim noAccrued As String = GridViewAccruedAll.GetRowCellValue(i, "NoAccrued")
            If Not listNoAccrued.Contains(noAccrued) Then
                listNoAccrued.Add(noAccrued)
            End If
        Next
        GridViewAccruedAll.ClearColumnsFilter()
        GridViewAccruedAll.SelectAll()

        param = String.Join(",", listNoAccrued.ToArray)

        clsReport = New ClsReportCCAccrued
        Dim lapCCSettle As New DRCCSettlement
        Dim dtCCSettle As New DataTable

        dtCCSettle = clsReport.LoadReportCCSettle(txtPerpostSett.EditValue, param)

        lapCCSettle.DataSource = dtCCSettle
        Dim PrintTool As ReportPrintTool

        PrintTool = New ReportPrintTool(lapCCSettle)
        TryCast(PrintTool.Report, XtraReport).Tag = PrintTool
        PrintTool.ShowPreview(UserLookAndFeel.Default)
    End Sub

End Class
