Public Class Frm_ViewPdf
    Dim FilePdf As String

    Public Sub New(ByVal _FilePDF As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.



        FilePdf = _FilePDF

    End Sub


    Private Sub Frm_ViewPdf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Me.PdfViewer1.LoadDocument("\\srv12\Asakai\Foto\NP_uunm1sjj.rjq.pdf")
        'Me.PdfViewer1.LoadDocument("D:\@KERJA\Project\Foto\" + FilePdf)
        Me.PdfViewer1.LoadDocument("\\srv12\Asakai\Foto\Circulation\" + FilePdf)

    End Sub
End Class