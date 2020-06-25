Public Class FrmReportTravelSett
    Dim laporan As New CRTravelSettlement
    Dim report As New TravelSettleHeaderModel

    Sub loadreport()
        Dim dtHeader As New DataTable
        Dim dtDetail As New DataTable
        Dim dtDetailSum As New DataTable
        Dim dtAllowanceAdvance As New DataTable
        'Dim dtAllowanceSettle As New DataTable
        Dim dtExpense As New DataTable
        Dim dtExpenseSum As New DataTable
        Dim FilteredRows As DataRow()
        Dim FilteredRowsTicket As DataRow()
        report.TravelSettleID = txtTravelSettleID.Text

        Dim USD As Double = 0
        Dim YEN As Double = 0
        Dim IDR As Double = 0
        Dim ExpenseUSD As Double = 0
        Dim ExpenseYEN As Double = 0
        Dim ExpenseIDR As Double = 0
        Dim TicketUSD As Double = 0
        Dim TicketYEN As Double = 0
        Dim TicketIDR As Double = 0
        Dim AllowanceUSD As Double = 0
        Dim AllowanceYEN As Double = 0
        Dim AllowanceIDR As Double = 0

        dtDetail = report.LoadReportSettleDetail()
        dtDetailSum = report.LoadReportSettleDetailSum()
        FilteredRowsTicket = dtDetail.[Select]("ID = 1")
        If FilteredRowsTicket.Count > 0 Then
            laporan.Subreports("CRTravelDetailTicketSett.rpt").SetDataSource(FilteredRowsTicket.CopyToDataTable)
            laporan.Subreports("CRTravelDetailTicketSettRight.rpt").SetDataSource(FilteredRowsTicket.CopyToDataTable)
        End If

        FilteredRows = dtDetail.[Select]("ID = 2")
        If FilteredRows.Count > 0 Then
            laporan.Subreports("CRTravelDetailTransportSett.rpt").SetDataSource(FilteredRows.CopyToDataTable)
            laporan.Subreports("CRTravelDetailTransportSettRight.rpt").SetDataSource(FilteredRows.CopyToDataTable)
            FilteredRows = dtDetailSum.[Select]("ID = 2")
            laporan.Subreports("CRTravelDetailTransportSettRightSum.rpt").SetDataSource(FilteredRows.CopyToDataTable)
        End If

        FilteredRows = dtDetail.[Select]("ID = 3")
        If FilteredRows.Count > 0 Then
            laporan.Subreports("CRTravelDetailStayingSett.rpt").SetDataSource(FilteredRows.CopyToDataTable)
            laporan.Subreports("CRTravelDetailStayingSettRight.rpt").SetDataSource(FilteredRows.CopyToDataTable)
            FilteredRows = dtDetailSum.[Select]("ID = 3")
            laporan.Subreports("CRTravelDetailStayingSettRightSum.rpt").SetDataSource(FilteredRows.CopyToDataTable)
        End If

        FilteredRows = dtDetail.[Select]("ID = 4")
        If FilteredRows.Count > 0 Then
            laporan.Subreports("CRTravelDetailEntertainSett.rpt").SetDataSource(FilteredRows.CopyToDataTable)
            laporan.Subreports("CRTravelDetailEntertainSettRight.rpt").SetDataSource(FilteredRows.CopyToDataTable)
            FilteredRows = dtDetailSum.[Select]("ID = 4")
            laporan.Subreports("CRTravelDetailEntertainSettRightSum.rpt").SetDataSource(FilteredRows.CopyToDataTable)
        End If

        FilteredRows = dtDetail.[Select]("ID = 7")
        If FilteredRows.Count > 0 Then
            laporan.Subreports("CRTravelDetailSafetyMoneySett.rpt").SetDataSource(FilteredRows.CopyToDataTable)
            laporan.Subreports("CRTravelDetailSafetyMoneySettRight.rpt").SetDataSource(FilteredRows.CopyToDataTable)
            FilteredRows = dtDetailSum.[Select]("ID = 7")
            laporan.Subreports("CRTravelDetailSafetyMoneySettRightSum.rpt").SetDataSource(FilteredRows.CopyToDataTable)
        End If

        dtExpense = report.LoadReportSettleExpense()
        laporan.Subreports("CRTravelTotalExpenseSettRight.rpt").SetDataSource(dtExpense)
        dtExpenseSum = report.LoadReportSumExpense()
        laporan.Subreports("CRTravelTotalExpenseSettRightSum.rpt").SetDataSource(dtExpenseSum)

        dtAllowanceAdvance = report.LoadReportAllowanceAdvance()
        'dtAllowanceSettle = report.LoadReportAllowanceSettle()

        AllowanceUSD = Convert.ToDouble(dtAllowanceAdvance.Compute("SUM(USD)", String.Empty))
        AllowanceYEN = Convert.ToDouble(dtAllowanceAdvance.Compute("SUM(YEN)", String.Empty))
        AllowanceIDR = Convert.ToDouble(dtAllowanceAdvance.Compute("SUM(IDR)", String.Empty))

        dtAllowanceAdvance.Rows(0)("SumUSD") = AllowanceUSD
        dtAllowanceAdvance.Rows(0)("SumYEN") = AllowanceYEN
        dtAllowanceAdvance.Rows(0)("SumYEN") = AllowanceIDR

        laporan.Subreports("CRTravelDetailAllowanceSett.rpt").SetDataSource(dtAllowanceAdvance)
        laporan.Subreports("CRTravelDetailAllowanceSettRight.rpt").SetDataSource(dtAllowanceAdvance)

        FilteredRows = dtExpenseSum.[Select]("SumDesc like '%CASH%'")
        If FilteredRows.Count > 0 Then
            ExpenseUSD = Convert.ToDouble(FilteredRows(0).Item("USD"))
            ExpenseYEN = Convert.ToDouble(FilteredRows(0).Item("YEN"))
            ExpenseIDR = Convert.ToDouble(FilteredRows(0).Item("IDR"))
        End If

        For Each row As DataRow In FilteredRowsTicket.CopyToDataTable.Rows
            If row("CurryID") = "USD" Then
                TicketUSD = Convert.ToDouble(row("Amount"))
            ElseIf row("CurryID") = "YEN" Then
                TicketYEN = Convert.ToDouble(row("Amount"))
            Else
                TicketIDR = Convert.ToDouble(row("Amount"))
            End If
        Next
        ExpenseUSD = ExpenseUSD + TicketUSD + AllowanceUSD
        ExpenseYEN = ExpenseYEN + TicketYEN + AllowanceYEN
        ExpenseIDR = ExpenseIDR + TicketIDR + AllowanceIDR

        dtExpenseSum.Clear()
        dtExpenseSum.Rows.Add("", "", ExpenseUSD, ExpenseYEN, ExpenseIDR)

        If FilteredRows.Count > 0 Then
            laporan.Subreports("CRTravelTotalSuspenseSettRight.rpt").SetDataSource(dtExpenseSum)
        End If

        dtHeader = report.LoadReportSettleHeader()
        USD = dtHeader.Rows(0)("TotalAdvanceUSD") + TicketUSD + AllowanceUSD
        YEN = dtHeader.Rows(0)("TotalAdvanceYEN") + TicketYEN + AllowanceYEN
        IDR = dtHeader.Rows(0)("TotalAdvanceIDR") + TicketIDR + AllowanceIDR
        dtHeader.Rows(0)("Penanggung") = txtPersonInCharge.Text
        dtHeader.Rows(0)("TotalUSD") = USD
        dtHeader.Rows(0)("TotalYEN") = YEN
        dtHeader.Rows(0)("TotalIDR") = IDR
        dtHeader.Rows(0)("SettleUSD") = ExpenseUSD
        dtHeader.Rows(0)("SettleYEN") = ExpenseYEN
        dtHeader.Rows(0)("SettleIDR") = ExpenseIDR
        dtHeader.Rows(0)("BalanceUSD") = USD - ExpenseUSD
        dtHeader.Rows(0)("BalanceYEN") = YEN - ExpenseYEN
        dtHeader.Rows(0)("BalanceIDR") = IDR - ExpenseIDR
        dtHeader.Rows(0)("PaidActualUSD") = USD - ExpenseUSD - dtHeader.Rows(0)("TotalReturnUSD")
        dtHeader.Rows(0)("PaidActualYEN") = YEN - ExpenseYEN - dtHeader.Rows(0)("TotalReturnYEN")
        dtHeader.Rows(0)("PaidActualIDR") = IDR - ExpenseIDR - dtHeader.Rows(0)("TotalReturnIDR")
        Dim PaidIDRUSD As Double = Math.Round((USD - ExpenseUSD - dtHeader.Rows(0)("TotalReturnUSD")) * dtHeader.Rows(0)("RateUSD") / 100, 0) * 100
        Dim PaidIDRYEN As Double = Math.Round((YEN - ExpenseYEN - dtHeader.Rows(0)("TotalReturnYEN")) * dtHeader.Rows(0)("RateYEN") / 100, 0) * 100
        dtHeader.Rows(0)("PaidIDRUSD") = PaidIDRUSD
        dtHeader.Rows(0)("PaidIDRYEN") = PaidIDRYEN
        dtHeader.Rows(0)("SumPaidIDR") = Math.Abs(PaidIDRUSD + PaidIDRYEN + IDR - ExpenseIDR - dtHeader.Rows(0)("TotalReturnIDR"))
        laporan.SetDataSource(dtHeader)

        With CrystalReportViewer1
            .ReportSource = laporan
            .RefreshReport()
        End With
    End Sub

    Private Sub FrmReportTravelSett_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadreport()
    End Sub
End Class