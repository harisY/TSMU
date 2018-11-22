Public Class Frm_PPN

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Frm_Scan.StartPosition = FormStartPosition.CenterScreen
        Frm_Scan.ShowDialog()
        Me.Close()
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Frm_Scan.StartPosition = FormStartPosition.CenterScreen
        Frm_Scan.ShowDialog()
        Me.Close()
    End Sub

    Private Sub txtppn_TextChanged(sender As Object, e As EventArgs) Handles txtppn.TextChanged
        ''txtppn.Text = Frm_Scan.txtscannilai.Text
    End Sub
End Class