Public Class FrmReportCirculation

    Dim Laporan As New RptCirculationHead
    Dim Rpt_OtherDept As New RptCirculation_OtherDept

    Dim Report As New ClsCR_CreateUser

    Public Circulation As String = ""



    Private Sub FrmReportCirculation_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call loadreport()

    End Sub


    Sub loadreport()

        'report.H_No_Npwo = "001"
        Dim ds As New DataSet
        Dim dsOtherDept As New DataSet

        ds = Report.RptCirculation(Circulation)
        Laporan.SetDataSource(ds)


        dsOtherDept = Report.RptCirculation_OtherDept(Circulation)
        ' Rpt_OtherDept.SetDataSource(dsOtherDept)

        Laporan.Subreports("RptCirculation_OtherDept.rpt").SetDataSource(dsOtherDept)

        dsOtherDept = Report.RptCirculation_OtherDept(Circulation)
        Rpt_OtherDept.SetDataSource(dsOtherDept)


        With CrystalReportViewer1
            .ReportSource = (Laporan)
            .RefreshReport()
            .Zoom(90)
        End With
    End Sub

End Class