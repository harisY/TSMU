Public Class Frm_Rpt_APPaySolomon

    Dim laporan As New Rpt_PaymentSolomon
    Dim report As New SettleHeader
    Dim _perpost As String


    Private Sub Frm_Rpt_APSolomon_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadreport()
    End Sub

    Public Sub New(ByVal perpost As String)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        _perpost = perpost

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
            report.perpost = _perpost
            ''perpost = Frm_Rpt_APPaymentSolomon.txt_perpost.Text
            Dim ds As New DataSet
            ds = report.GetDataReportPaymentSolomon
            'ds = report.reportsj
            'laporan.PrintToPrinter(1, False, 0, 0)

            ''Dim dsSub As New DataSet
            ''dsSub = report.SubReport

            laporan.SetDataSource(ds.Tables("PaymentSolomon"))
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