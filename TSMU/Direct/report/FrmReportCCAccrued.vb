Public Class FrmReportCCAccrued
    Dim lapAccrued As New CRCCAccrued
    Dim lapAccruedAndSettle As New CRCCAccruedAndSettle
    Dim report As New ClsReportCCAccrued

    Private Sub FrmReportCCAccrued_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If txtTabAccrued.Text = "TabPageProses" Then
            LoadreportAccrued()
        Else
            LoadreportAccruedAndSettle()
        End If
    End Sub

    Sub LoadreportAccrued()
        Dim dtAccrued As New DataTable

        dtAccrued = report.LoadReportAccrued()
        lapAccrued.SetDataSource(dtAccrued)

        With CrystalReportViewer1
            .ReportSource = lapAccrued
            .RefreshReport()
        End With
    End Sub

    Sub LoadreportAccruedAndSettle()
        Dim dtAccrued As New DataTable

        dtAccrued = report.LoadReportAccruedAndSettle()
        lapAccruedAndSettle.SetDataSource(dtAccrued)

        With CrystalReportViewer1
            .ReportSource = lapAccruedAndSettle
            .RefreshReport()
        End With
    End Sub

End Class