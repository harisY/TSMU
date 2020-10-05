Imports DevExpress.Data
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports TSMU

Public Class FrmCCAccrued
    Dim cls_Accrued As New ClsCCAccrued
    Dim clsGlobal As New GlobalService
    Dim frmCCAccrued As New FrmReportCCAccrued

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
        CreateTable()
        'LoadGridAccrued()
    End Sub

    Public Overrides Sub Proc_Refresh()
        TabPage = XtraTabControl1.SelectedTabPage.Name()
        If TabPage = "TabPageProses" Then
            LoadGridAccrued()
        ElseIf TabPage = "TabPageCancel" Then
            LoadGridAccruedAll()
        ElseIf TabPage = "TabPagePaid" Then
            LoadGridAccruedPaid()
        End If
    End Sub

    Public Overrides Sub Proc_Search()
        Try
            Dim fSearch As New frmSearch()
            With fSearch
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()
            End With

            Dim _now As Date = Date.Today
            Dim firstDay As Date = If(IsDBNull(fSearch.TglDari), New Date(_now.Year, _now.Month, 1), fSearch.TglDari)
            Dim lastDay As Date = If(IsDBNull(fSearch.TglSampai), _now.AddMonths(1).AddDays(-1), fSearch.TglSampai)

            cls_Accrued = New ClsCCAccrued
            dtGrid = cls_Accrued.GetDataAccruedPaid(firstDay, lastDay)
            GridAccruedPaid.DataSource = dtGrid
            GridViewAccruedPaid.BestFitColumns()
            hitungSummaryPaid()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Public Overrides Sub Proc_Print()
        FrmCCAccrued = New FrmReportCCAccrued
        FrmCCAccrued.txtTabAccrued.Text = TabPage
        FrmCCAccrued.StartPosition = FormStartPosition.CenterScreen
        FrmCCAccrued.Show()
    End Sub

    Private Sub CreateTable()
        dtSummaryProses = New DataTable
        dtSummaryProses.Columns.AddRange(New DataColumn(4) {New DataColumn("SumAmountOriUSD", GetType(Double)),
                                                            New DataColumn("SumAmountOriYEN", GetType(Double)),
                                                            New DataColumn("SumAmountOriIDR", GetType(Double)),
                                                            New DataColumn("SumAccrualEstimate", GetType(Double)),
                                                            New DataColumn("SumAmountIDR", GetType(Double))})
        dtSummarySettle = New DataTable
        dtSummarySettle.Columns.AddRange(New DataColumn(4) {New DataColumn("SumAmountOriUSD", GetType(Double)),
                                                            New DataColumn("SumAmountOriYEN", GetType(Double)),
                                                            New DataColumn("SumAmountOriIDR", GetType(Double)),
                                                            New DataColumn("SumAccrualEstimate", GetType(Double)),
                                                            New DataColumn("SumAmountIDR", GetType(Double))})

        dtSummaryPaid = New DataTable
        dtSummaryPaid.Columns.AddRange(New DataColumn(4) {New DataColumn("SumAmountOriUSD", GetType(Double)),
                                                            New DataColumn("SumAmountOriYEN", GetType(Double)),
                                                            New DataColumn("SumAmountOriIDR", GetType(Double)),
                                                            New DataColumn("SumAccrualEstimate", GetType(Double)),
                                                            New DataColumn("SumAmountIDR", GetType(Double))})
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
                        sumAmountIDR = sumAmountIDR + IIf(GridViewAccrued.GetRowCellValue(rowIndex, "AmountIDR") Is DBNull.Value, 0, GridViewAccrued.GetRowCellValue(rowIndex, "AmountIDR"))
                        sumAccrualEstimate = sumAmountIDR + IIf(GridViewAccrued.GetRowCellValue(i, "AccrualEstimate") Is DBNull.Value, 0, GridViewAccrued.GetRowCellValue(i, "AccrualEstimate"))
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
                newRow("SumAmountOriUSD") = 0
                newRow("SumAmountOriYEN") = 0
                newRow("SumAmountOriIDR") = 0
                newRow("SumAccrualEstimate") = 0
                newRow("SumAmountIDR") = 0
                dtSummaryProses.Rows.Add(newRow)
                GridSumAccrued.DataSource = dtSummaryProses
            End If
        End If
    End Sub

    Private Sub hitungSummarySettle()
        dtSummarySettle.Clear()
        If GridViewAccruedAll.RowCount > 0 Then
            Dim sumAmountOriUSD As Double = 0
            Dim sumAmountOriYEN As Double = 0
            Dim sumAmountOriIDR As Double = 0
            Dim sumAmountIDR As Double = 0
            Dim sumAccrualEstimate As Double = 0
            Dim curryID As String
            Dim amountOri As Double = 0

            For i As Integer = 0 To GridViewAccruedAll.RowCount - 1
                curryID = IIf(GridViewAccruedAll.GetRowCellValue(i, "CurryID") Is DBNull.Value, "", GridViewAccruedAll.GetRowCellValue(i, "CurryID"))
                amountOri = IIf(GridViewAccruedAll.GetRowCellValue(i, "Amount") Is DBNull.Value, 0, GridViewAccruedAll.GetRowCellValue(i, "Amount"))
                sumAmountIDR = sumAmountIDR + IIf(GridViewAccruedAll.GetRowCellValue(i, "AmountIDR") Is DBNull.Value, 0, GridViewAccruedAll.GetRowCellValue(i, "AmountIDR"))
                sumAccrualEstimate = sumAmountIDR + IIf(GridViewAccruedAll.GetRowCellValue(i, "AccrualEstimate") Is DBNull.Value, 0, GridViewAccruedAll.GetRowCellValue(i, "AccrualEstimate"))
                If curryID = "USD" Then
                    sumAmountOriUSD = sumAmountOriUSD + amountOri
                ElseIf curryID = "JPY" Then
                    sumAmountOriYEN = sumAmountOriYEN + amountOri
                ElseIf curryID = "IDR" Then
                    sumAmountOriIDR = sumAmountOriIDR + amountOri
                End If
            Next
            Dim newRow As DataRow
            newRow = dtSummarySettle.NewRow
            newRow("SumAmountOriUSD") = sumAmountOriUSD
            newRow("SumAmountOriYEN") = sumAmountOriYEN
            newRow("SumAmountOriIDR") = sumAmountOriIDR
            newRow("SumAccrualEstimate") = sumAccrualEstimate
            newRow("SumAmountIDR") = sumAmountIDR
            dtSummarySettle.Rows.Add(newRow)
            GridSumSettle.DataSource = dtSummarySettle
        End If
    End Sub

    Private Sub hitungSummaryPaid()
        dtSummaryPaid.Clear()
        If GridViewAccruedPaid.RowCount > 0 Then
            Dim sumAmountOriUSD As Double = 0
            Dim sumAmountOriYEN As Double = 0
            Dim sumAmountOriIDR As Double = 0
            Dim sumAmountIDR As Double = 0
            Dim sumAccrualEstimate As Double = 0
            Dim curryID As String
            Dim amountOri As Double = 0

            For i As Integer = 0 To GridViewAccruedPaid.RowCount - 1
                curryID = IIf(GridViewAccruedPaid.GetRowCellValue(i, "CurryID") Is DBNull.Value, "", GridViewAccruedPaid.GetRowCellValue(i, "CurryID"))
                amountOri = IIf(GridViewAccruedPaid.GetRowCellValue(i, "Amount") Is DBNull.Value, 0, GridViewAccruedPaid.GetRowCellValue(i, "Amount"))
                sumAmountIDR = sumAmountIDR + IIf(GridViewAccruedPaid.GetRowCellValue(i, "AmountIDR") Is DBNull.Value, 0, GridViewAccruedPaid.GetRowCellValue(i, "AmountIDR"))
                sumAccrualEstimate = sumAmountIDR + IIf(GridViewAccruedPaid.GetRowCellValue(i, "AccrualEstimate") Is DBNull.Value, 0, GridViewAccruedPaid.GetRowCellValue(i, "AccrualEstimate"))
                If curryID = "USD" Then
                    sumAmountOriUSD = sumAmountOriUSD + amountOri
                ElseIf curryID = "JPY" Then
                    sumAmountOriYEN = sumAmountOriYEN + amountOri
                ElseIf curryID = "IDR" Then
                    sumAmountOriIDR = sumAmountOriIDR + amountOri
                End If
            Next
            Dim newRow As DataRow
            newRow = dtSummaryPaid.NewRow
            newRow("SumAmountOriUSD") = sumAmountOriUSD
            newRow("SumAmountOriYEN") = sumAmountOriYEN
            newRow("SumAmountOriIDR") = sumAmountOriIDR
            newRow("SumAccrualEstimate") = sumAccrualEstimate
            newRow("SumAmountIDR") = sumAmountIDR
            dtSummaryPaid.Rows.Add(newRow)
            GridSumPaid.DataSource = dtSummaryPaid
        End If
    End Sub

    Private Sub GroupingGrid(view As GridView)
        Dim colTanggalTrans As GridColumn = view.Columns("TanggalTransaksi")
        Dim colCCNumber As GridColumn = view.Columns("CreditCardNumber")
        Dim colAmountIDR As GridColumn = view.Columns("AmountIDR")
        Dim colAccountName As GridColumn = view.Columns("AccountName")
        Dim colBankName As GridColumn = view.Columns("BankName")
        view.OptionsCustomization.AllowMergedGrouping = True
        view.SortInfo.ClearAndAddRange({New GridMergedColumnSortInfo({colCCNumber, colAccountName, colBankName}, {}),
                                        New GridColumnSortInfo(colCCNumber, ColumnSortOrder.Ascending)
                                        }, 3)
        view.ExpandAllGroups()

        Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
        item.FieldName = colCCNumber.FieldName
        item.SummaryType = SummaryItemType.Count
        view.GroupSummary.Clear()
        view.GroupSummary.Add(item)

        Dim item1 As GridGroupSummaryItem = New GridGroupSummaryItem()
        item1.FieldName = colAmountIDR.FieldName
        item1.SummaryType = SummaryItemType.Sum
        item1.DisplayFormat = "{0:#,##0.#0}"
        item1.ShowInGroupColumnFooter = colAmountIDR
        view.GroupSummary.Add(item1)
    End Sub

    Private Sub LoadGridAccrued()
        Try
            cls_Accrued = New ClsCCAccrued
            cls_Accrued.CreditCardNumber = IIf(txtCCNumber.EditValue Is Nothing, "", txtCCNumber.EditValue)
            dtGridAccrued = cls_Accrued.GetDataCostCC()
            GridAccrued.DataSource = dtGridAccrued
            hitungSummaryProses()
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadGridAccruedAll()
        Try
            cls_Accrued = New ClsCCAccrued
            dtGrid = cls_Accrued.GetDataAccruedSettle()
            GridAccruedAll.DataSource = dtGrid
            GridViewAccruedAll.BestFitColumns()
            'GridCellFormat(GridViewAccruedAll)
            hitungSummarySettle()
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadGridAccruedPaid()
        Try
            Dim _now As Date = Date.Today
            Dim firstDay As Date = New Date(_now.Year, _now.Month, 1)
            Dim lastDay As Date = _now.AddMonths(1).AddDays(-1)

            cls_Accrued = New ClsCCAccrued
            dtGrid = cls_Accrued.GetDataAccruedPaid(firstDay, lastDay)
            GridAccruedPaid.DataSource = dtGrid
            GridViewAccruedPaid.BestFitColumns()
            'GridCellFormat(GridViewAccruedPaid)
            hitungSummaryPaid()
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        TabPage = XtraTabControl1.SelectedTabPage.Name()
        If TabPage = "TabPageProses" Then
            Call Proc_EnableButtons(False, False, False, True, False, False, False, True, False, False, False, False)
            LoadGridAccrued()
        ElseIf TabPage = "TabPageCancel" Then
            Call Proc_EnableButtons(False, False, False, True, False, False, False, True, False, False, False, False)
            LoadGridAccruedAll()
        ElseIf TabPage = "TabPagePaid" Then
            Call Proc_EnableButtons(False, False, False, True, False, False, False, False, False, False, False, True)
            LoadGridAccruedPaid()
        End If
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
                        If GridViewAccrued.GetRowCellValue(rowIndex, "CurryID") <> "IDR" AndAlso GridViewAccrued.GetRowCellValue(rowIndex, "AmountIDR") = 0 Then
                            Throw New Exception("Amount IDR tidak boleh 0!")
                        End If
                    End If
                Next
                cls_Accrued.InsertData(Me, noAccrued, txtCCNumber.EditValue, Rows)
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                tsBtn_refresh.PerformClick()
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
                Dim Rows As New ArrayList()
                For i As Integer = 0 To GridViewAccruedAll.SelectedRowsCount() - 1
                    If (GridViewAccruedAll.GetSelectedRows()(i) >= 0) Then
                        Rows.Add(GridViewAccruedAll.GetDataRow(GridViewAccruedAll.GetSelectedRows()(i)))
                    End If
                    Dim Row As DataRow = CType(Rows(0), DataRow)
                    If Row("Pay") = 1 Then
                        MessageBox.Show("Data sudah dilakukan pembayaran", "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
                        Exit Sub
                    End If
                Next
                cls_Accrued.DeleteData(Rows)
                Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)
                tsBtn_refresh.PerformClick()
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
            txtCCNumber.EditValue = lF_SearchData.Values.Item(0).ToString.Trim
        End If

        lF_SearchData.Close()
        LoadGridAccrued()
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

    Private Sub GridViewAccrued_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles GridViewAccrued.FocusedRowChanged
        Try
            Dim curryID = String.Empty
            Dim selectedRows As Integer = GridViewAccrued.FocusedRowHandle
            curryID = GridViewAccrued.GetRowCellValue(selectedRows, "CurryID")
            If curryID = "IDR" Then
                GridViewAccrued.OptionsBehavior.Editable = False
            Else
                GridViewAccrued.OptionsBehavior.Editable = True
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GridViewAccrued_SelectionChanged(sender As Object, e As SelectionChangedEventArgs) Handles GridViewAccrued.SelectionChanged
        hitungSummaryProses()
    End Sub

End Class
