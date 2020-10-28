Public Class Frm_Rpt_APSignature

    Dim laporan As New Rpt_APSignature
    Dim report As New SettleHeader
    Dim _date3 As DateTime
    Dim _date4 As DateTime


    Private Sub Frm_Rpt_APSignature_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadreport()
    End Sub

    Public Sub New(ByVal date3 As Date, ByVal date4 As Date)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        _date3 = date3
        _date4 = date4
    End Sub

    Sub loadreport()
        'report.SettleID = TxtNosettle.Text
        'Dim ds As New DataSet
        'ds = report.loadreport2
        ''ds = report.reportsj
        ''laporan.PrintToPrinter(1, False, 0, 0)

        'laporan.SetDataSource(ds)
        'With CrystalReportViewer1
        '    .ReportSource = laporan
        '    .RefreshReport()
        'End With

        Try
            'If _Date1 = "" And _Date2 = "" Then
            '    Throw New Exception("Tanggal Tidak Boleh Kosong")
            'End If
            report.Date3 = _date3
            report.Date4 = _date4
            ''perpost = Frm_Rpt_APPaymentSolomon.txt_perpost.Text
            Dim ds As New DataSet
            ds = report.DataGridViewAPPaymentSign
            'ds = report.reportsj
            'laporan.PrintToPrinter(1, False, 0, 0)

            ''Dim dsSub As New DataSet
            ''dsSub = report.SubReport

            laporan.SetDataSource(ds.Tables("ReportPaymentSignature"))
            ''laporan.Subreports(0).SetDataSource(dsSub.Tables("SettleRelasi"))

            With CrystalReportViewer1
                .ReportSource = laporan
                .RefreshReport()
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try


    End Sub



End Class