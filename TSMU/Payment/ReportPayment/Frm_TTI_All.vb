Imports DevExpress.XtraGrid
Public Class Frm_TTI_All
    Dim ObjPaymentDetail As New TTI_Detail_Models
    Dim GridDtl As GridControl
    Dim dtGrid As DataTable
    Dim CustID As String
    Private Sub Frm_TTI_All_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            CustID = "-"
            dtGrid = ObjPaymentDetail.GetGridDetailPaymentByVendorID2(CustID)
            Grid.DataSource = dtGrid
            With GridView1
                .Columns(0).Visible = False
                .BestFitColumns()

            End With
            GridCellFormat(GridView1)

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
End Class