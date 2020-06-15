Public Class FrmReportTravelSett
    Dim laporan As New CRTravelSettlement
    Dim report As New TravelSettleHeaderModel

    Sub loadreport()
        Dim dt As New DataTable
        Dim dtDetail As New DataTable
        Dim dtDetailSum As New DataTable
        Dim dtSett As New DataTable
        Dim dtExpense As New DataTable
        Dim FilteredRows As DataRow()
        report.TravelSettleID = txtTravelSettleID.Text

        dtSett = report.LoadReportSettleHeader()
        laporan.SetDataSource(dtSett)

        dtDetail = report.LoadReportSettleDetail()
        dtDetailSum = report.LoadReportSettleDetailSum()

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
        dt = report.LoadReportSumExpense()
        laporan.Subreports("CRTravelTotalExpenseSettRightSum.rpt").SetDataSource(dt)

        dtSett = report.LoadReportSettleAllowance()
        laporan.Subreports("CRTravelDetailAllowanceSett.rpt").SetDataSource(dtSett)
        laporan.Subreports("CRTravelDetailAllowanceSettRight.rpt").SetDataSource(dtSett)

        Dim USD As Double = 0
        Dim YEN As Double = 0
        Dim IDR As Double = 0
        USD = Convert.ToDouble(dtSett.Compute("SUM(USD)", String.Empty))
        YEN = Convert.ToDouble(dtSett.Compute("SUM(YEN)", String.Empty))
        IDR = Convert.ToDouble(dtSett.Compute("SUM(IDR)", String.Empty))

        FilteredRows = dt.[Select]("SumDesc like '%CASH%'")
        If FilteredRows.Count > 0 Then
            USD = USD + Convert.ToDouble(FilteredRows(0).Item("USD"))
            YEN = YEN + Convert.ToDouble(FilteredRows(0).Item("YEN"))
            IDR = IDR + Convert.ToDouble(FilteredRows(0).Item("IDR"))
        End If

        dt.Clear()
        dt.Rows.Add("", "", USD, YEN, IDR)

        If FilteredRows.Count > 0 Then
            laporan.Subreports("CRTravelTotalSuspenseSettRight.rpt").SetDataSource(dt)
        End If
        With CrystalReportViewer1
            .ReportSource = laporan
            .RefreshReport()
        End With
    End Sub

    Private Sub FrmReportTravelSett_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadreport()
    End Sub
End Class