Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmSystem_PrintPreview1

    Dim _Report As ReportClass
    Dim _ReportCR As ReportDocument

    Property ViewReport() As ReportClass
        Get
            Return _Report
        End Get
        Set(ByVal value As ReportClass)
            _Report = value
        End Set
    End Property

    Property EnabledRefresh() As Boolean
        Get
            Return CRViewer.ShowRefreshButton
        End Get
        Set(ByVal value As Boolean)
            CRViewer.ShowRefreshButton = value
        End Set
    End Property

    Property ViewReportCR() As ReportDocument
        Get
            Return _ReportCR
        End Get
        Set(ByVal value As ReportDocument)
            _ReportCR = value
        End Set
    End Property


    Private Sub FrmPrintPreview_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If _Report IsNot Nothing Then
            CRViewer.ReportSource = _Report
        ElseIf _ReportCR IsNot Nothing Then
            CRViewer.ReportSource = _ReportCR
        End If

        CRViewer.Show()

    End Sub
End Class