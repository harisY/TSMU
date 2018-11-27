Public Class Frm_Scan

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ''txtscannilai.Text = Frm_PPN.txtppn.Text
        utama._Tot_Pph.Text = txtscannilai.Text
        Frm_PPH.StartPosition = FormStartPosition.CenterScreen
        Frm_PPH.ShowDialog()
        Me.Close()
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs)

    End Sub

    Private Sub Frm_Scan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Ckredit.Checked = True Then
            CFPcash.Enabled = False
        ElseIf Ckredit.Checked = False Then
            CFPcash.Enabled = True
        End If
    End Sub

    
End Class