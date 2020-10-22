Imports DevExpress.XtraSplashScreen

Public Class FrmMktUploadPrice
    Private Sub FrmMktUploadPrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call Proc_EnableButtons(False, False, False, False, True, False, False, False, False, False, False)
    End Sub

    Public Overrides Sub Proc_Excel()
        Dim table As New DataTable

        Dim frmExcelPrice As FrmMktExcelPrice
        frmExcelPrice = New FrmMktExcelPrice()
        frmExcelPrice.StartPosition = FormStartPosition.CenterScreen
        frmExcelPrice.ShowDialog()

        Dim dtResult As New DataTable
        dtResult = frmExcelPrice._dtResult

        If frmExcelPrice._isUpload AndAlso dtResult.Rows.Count > 0 Then
            Call Proc_EnableButtons(False, True, False, False, True, False, False, False, False, False, False)
            GridPrice.DataSource = dtResult
            With GridViewPrice
                .BestFitColumns()
                .Columns(0).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns(4).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                .Columns(4).DisplayFormat.FormatString = "n2"
                .Columns(5).DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                .Columns(5).DisplayFormat.FormatString = "n2"
                .Columns(6).DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns(6).DisplayFormat.FormatString = "dd-MM-yyyy"
            End With
        End If
    End Sub

End Class
