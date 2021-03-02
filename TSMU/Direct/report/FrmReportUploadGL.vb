Imports DevExpress.XtraPrinting
Public Class FrmReportUploadGL
    Dim laporan As New CRUploadGL2
    Dim laporan2 As New CRUploadGJ
    Dim laporan3 As New CRUploadGJ_Tr
    Dim report As New GJHeaderModel
    Dim _Service As GJHeaderModel

    Private Sub FrmReportUploadGL_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If TxtTransaksi.Text = "Cash Transaction" Then
            loadreport()

        ElseIf TxtTransaksi.Text = "Cash Transfer" Then
            loadreport3()
        ElseIf TxtTransaksi.Text = "General Journal" Then
            loadreport2()

        End If



    End Sub
    Sub loadreport()

        _Service = New GJHeaderModel
        Dim ds As DataSet = New DataSet
        ds = _Service.PrintReport(TxtPerpost.Text, TxtCuryID.Text)
        laporan.SetDataSource(ds)
        With CrystalReportViewer1
            .ReportSource = laporan
            .RefreshReport()
        End With

    End Sub

    Sub loadreport2()

        _Service = New GJHeaderModel
        Dim ds As DataSet = New DataSet
        ds = _Service.PrintReport2(TxtPerpost.Text, TxtCuryID.Text)
        laporan2.SetDataSource(ds)
        With CrystalReportViewer1
            .ReportSource = laporan2
            .RefreshReport()
        End With

    End Sub
    Sub loadreport3()

        _Service = New GJHeaderModel
        Dim ds As DataSet = New DataSet
        ds = _Service.PrintReport3(TxtPerpost.Text, TxtCuryID.Text)
        laporan3.SetDataSource(ds)
        With CrystalReportViewer1
            .ReportSource = laporan3
            .RefreshReport()
        End With

    End Sub


End Class