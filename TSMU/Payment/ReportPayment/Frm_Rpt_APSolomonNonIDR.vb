Public Class Frm_Rpt_APSolomonNonIDR

    Dim laporan As New Rpt_UploadNonIDR
    Dim report As New SettleHeader
    Dim entertain As New Object
    Dim _Date3 As Date
    Dim _Date4 As Date
    Dim _Date5 As Date

    Private Sub Frm_Rpt_APSolomonNonIDR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadreport()
    End Sub

    Public Sub New(ByVal Date3 As Date, ByVal Date4 As Date, ByVal Date5 As Date)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        _Date3 = Date3
        _Date4 = Date4
        _Date5 = Date5
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
            report.Date3 = _Date3
            report.Date4 = _Date4
            report.Date5 = _Date5

            Dim ds As New DataSet
            ds = report.loadreportAPSolomonNonIDR
            'ds = report.reportsj
            'laporan.PrintToPrinter(1, False, 0, 0)

            ''Dim dsSub As New DataSet
            ''dsSub = report.SubReport

            laporan.SetDataSource(ds.Tables("datauploadNonIDR"))
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