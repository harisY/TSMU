Public Class FrmRekapClaim

    Dim dtGrid As DataTable
    Dim fc_Class As New ClaimCustomerModel
    Dim IdTrans As String
    Dim TanggalAwal As Date
    Dim TanggalAhir As Date


    Private Sub LoadGrid(TanggalAwal As Date, TanggalAhir As Date)
        Try
            dtGrid = fc_Class.GetRekapClaim(TanggalAwal, TanggalAhir)
            Grid.DataSource = dtGrid
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BCari_Click(sender As Object, e As EventArgs) Handles BCari.Click

        TanggalAwal = Convert.ToDateTime(DateAwal.Value)
        TanggalAhir = Convert.ToDateTime(DateAhir.Value)
        Call LoadGrid(TanggalAwal, TanggalAhir)

    End Sub
End Class