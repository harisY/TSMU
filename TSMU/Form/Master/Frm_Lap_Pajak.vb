Public Class Frm_Lap_Pajak


    Dim jsox1 As Cls_report = New Cls_report()
    Sub tampildata()
        Try


            Dim dtgrid As DataTable = New DataTable
            dtgrid = jsox1.FilterBydate()
            DataGridView1.DataSource = dtgrid
            DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect

        Catch ex As Exception

            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        tampildata()
    End Sub

    Private Sub Frm_Lap_Pajak_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class