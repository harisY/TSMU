Public Class FrmReportTravelSett
    Dim laporan As New CRTravelSettlement
    Dim report As New TravelSettleHeaderModel

    Sub loadreport()
        Dim dt As New DataTable
        Dim dtSett As New DataTable
        Dim dtExpense As New DataTable
        report.TravelSettleID = txtTravelSettleID.Text

        dtSett = report.LoadReportSettleHeader()
        laporan.SetDataSource(dtSett)

        'Dim FilteredRows As DataRow()
        'dt = report.LoadReportTravelDetail
        'dtSett = reportSett.LoadReportTravelSettDetail
        'FilteredRows = dt.Select("ID = 1")
        'laporan.Subreports("CRTravelDetailTicketSett.rpt").SetDataSource(FilteredRows.CopyToDataTable)
        'FilteredRows = dtSett.Select("ID = 1")
        'laporan.Subreports("CRTravelDetailTicketSettRight.rpt").SetDataSource(FilteredRows.CopyToDataTable)

        'Dim dsSub1 = New DataSet
        'Dim dsSub2 = New DataSet
        'dsSub1 = report.LoadReportSettleTransport()
        'dsSub2 = report.SumTransport
        dtSett = report.LoadReportSettleTransport()
        laporan.Subreports("CRTravelDetailTransportSett.rpt").SetDataSource(dtSett)
        laporan.Subreports("CRTravelDetailTransportSettRight.rpt").SetDataSource(dtSett)
        dtSett = report.LoadReportSumTransport()
        laporan.Subreports("CRTravelDetailTransportSettRightSum.rpt").SetDataSource(dtSett)

        dtSett = report.LoadReportSettleStaying()
        laporan.Subreports("CRTravelDetailStayingSett.rpt").SetDataSource(dtSett)
        laporan.Subreports("CRTravelDetailStayingSettRight.rpt").SetDataSource(dtSett)

        'laporan.Subreports("CRTravelDetailStayingSettRightSum.rpt").SetDataSource(dtSett)

        dtSett = report.LoadReportSettleEntertain()
        laporan.Subreports("CRTravelDetailEntertainSett.rpt").SetDataSource(dtSett)
        laporan.Subreports("CRTravelDetailEntertainSettRight.rpt").SetDataSource(dtSett)

        dtSett = report.LoadReportSettleOther()
        laporan.Subreports("CRTravelDetailSafetyMoneySett.rpt").SetDataSource(dtSett)
        laporan.Subreports("CRTravelDetailSafetyMoneySettRight.rpt").SetDataSource(dtSett)

        dtExpense = report.LoadReportSettleExpense
        laporan.Subreports("CRTravelTotalExpenseSettRight.rpt").SetDataSource(dtExpense)

        dtSett = report.LoadReportSettleAllowance()
        laporan.Subreports("CRTravelDetailAllowanceSett.rpt").SetDataSource(dtSett)
        laporan.Subreports("CRTravelDetailAllowanceSettRight.rpt").SetDataSource(dtSett)

        ''FilteredRows = dtSett.Select("ID = 5")
        'laporan.Subreports("CRTravelTotalSuspenseSettRight.rpt").SetDataSource(dtSett)

        With CrystalReportViewer1
            .ReportSource = laporan
            .RefreshReport()
        End With
    End Sub

    Private Sub FrmReportTravelSett_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadreport()
    End Sub
End Class