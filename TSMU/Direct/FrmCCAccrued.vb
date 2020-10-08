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

    Dim accountName As String = String.Empty

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
            Call Proc_EnableButtons(False, False, False, True, False, False, False, True, False, False, False, False)
            LoadGridAccruedSette()
        ElseIf TabPage = "TabPagePaid" Then
            Call Proc_EnableButtons(False, False, False, True, False, False, False, False, False, False, False, True)
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

            LoadGridAccruedPaid(firstDay, lastDay)
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Public Overrides Sub Proc_Print()
        Dim param As String
        Dim listNoAccrued As New List(Of String)
        If GridViewAccruedAll.SelectedRowsCount > 0 Then
            For i As Integer = 0 To GridViewAccruedAll.SelectedRowsCount() - 1
                If (GridViewAccruedAll.GetSelectedRows()(i) >= 0) Then
                    Dim noAccrued As String = String.Empty
                    If noAccrued <> GridViewAccruedAll.GetRowCellValue(GridViewAccruedAll.GetSelectedRows()(i), "NoAccrued") Then
                        noAccrued = GridViewAccruedAll.GetRowCellValue(GridViewAccruedAll.GetSelectedRows()(i), "NoAccrued")
                        listNoAccrued.Add(noAccrued)
                    End If
                End If
            Next
        End If

        param = String.Join(",", listNoAccrued.ToArray)

        frmCCAccrued = New FrmReportCCAccrued
        frmCCAccrued.txtTabAccrued.Text = TabPage
        frmCCAccrued.param = param
        frmCCAccrued.StartPosition = FormStartPosition.CenterScreen
        frmCCAccrued.Show()
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
            cls_Accrued.CreditCardNumber = IIf(txtCCNumber.EditValue Is Nothing, "", txtCCNumber.EditValue)
            dtGridAccrued = cls_Accrued.GetDataCostCC()
            GridAccrued.DataSource = dtGridAccrued
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
            dtGridAccrued = cls_Accrued.GetDataCostCC()
            GridAccrued.DataSource = dtGridAccrued
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
            dtGrid = cls_Accrued.GetDataCCSettle()
            GridAccruedAll.DataSource = dtGrid
            GridViewAccruedAll.BestFitColumns()

            dtSummarySettle = New DataTable
            cls_Accrued = New ClsCCAccrued
            dtSummarySettle = cls_Accrued.GetDataCCSettleSum()
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
                newRow("SumAccountName") = accountName
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
                newRow("SumAccountName") = accountName
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
        'view.OptionsCustomization.AllowMergedGrouping = True
        'view.SortInfo.ClearAndAddRange({New GridMergedColumnSortInfo({colCCNumber, colAccountName, colBankName}, {}),
        '                                New GridColumnSortInfo(colCCNumber, ColumnSortOrder.Ascending)
        '                                }, 3)
        colType.GroupIndex = 0
        colType.SortIndex = 0
        colType.SortOrder = ColumnSortOrder.Ascending
        view.ExpandAllGroups()

        'Dim item As GridGroupSummaryItem = New GridGroupSummaryItem()
        'item.FieldName = colCCNumber.FieldName
        'item.SummaryType = SummaryItemType.Count
        'view.GroupSummary.Clear()
        'view.GroupSummary.Add(item)

        'Dim item1 As GridGroupSummaryItem = New GridGroupSummaryItem()
        'item1.FieldName = colAmountIDR.FieldName
        'item1.SummaryType = SummaryItemType.Sum
        'item1.DisplayFormat = "{0:#,##0.#0}"
        'item1.ShowInGroupColumnFooter = colAmountIDR
        'view.GroupSummary.Add(item1)
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
            accountName = lF_SearchData.Values.Item(1).ToString.Trim
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
            For i As Integer = 0 To GridViewAccrued.RowCount - 1
                Dim isChecked As Boolean = GridViewAccrued.IsRowSelected(i)
                If isChecked = False Then
                    GridViewAccrued.SetRowCellValue(i, "AmountIDR", 0)
                    If GridViewAccrued.GetRowCellValue(i, "CurryID") = "IDR" Then
                        GridViewAccrued.SetRowCellValue(i, "Rate", 1)
                    Else
                        GridViewAccrued.SetRowCellValue(i, "Rate", 0)
                    End If
                End If
            Next
            hitungSummaryProses()
        Else
            GridViewAccrued.ClearSelection()
        End If
    End Sub

    Private Sub GridViewAccrued_RowCellClick(sender As Object, e As RowCellClickEventArgs) Handles GridViewAccrued.RowCellClick
        If GridViewAccrued.FocusedColumn.Name = "GAmountIDR" Then
            If txtCCNumber.EditValue = "" Then
                GridViewAccrued.OptionsBehavior.Editable = False
                GridViewAccrued.OptionsSelection.EnableAppearanceFocusedRow = False
            Else
                Dim isChecked As Boolean = GridViewAccrued.IsRowSelected(GridViewAccrued.FocusedRowHandle)
                If isChecked Then
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

End Class
