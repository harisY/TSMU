Public Class Form_MENU

    Private Sub VerifyFakturPajakToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Frm_FP.StartPosition = FormStartPosition.CenterScreen
        Frm_FP.ShowDialog()
    End Sub

    Private Sub ToolStripDropDownButton4_Click(sender As Object, e As EventArgs)
        End
    End Sub

    Private Sub VerifyFakturPajakToolStripMenuItem_Click_1(sender As Object, e As EventArgs)
        Frm_FP.StartPosition = FormStartPosition.CenterScreen
        Frm_FP.ShowDialog()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        If MessageBox.Show("Apakah Anda Yakin Ingin Menutup Aplikasi ?", "INFORMASI", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            End
        End If
    End Sub

    Private Sub ReportPPNToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Frm_Lap_Pajak.StartPosition = FormStartPosition.CenterScreen
        Frm_Lap_Pajak.ShowDialog()
    End Sub

    Private Sub PaymentToolStripMenuItem_Click(sender As Object, e As EventArgs)
        ''     Frm_Payment.StartPosition = FormStartPosition.CenterScreen
        ''   Frm_Payment.ShowDialog()
        Frm_Filter_payment.StartPosition = FormStartPosition.CenterScreen
        Frm_Filter_payment.ShowDialog()
    End Sub

    Private Sub ToolStripDropDownButton3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub ReportPaymentToolStripMenuItem_Click(sender As Object, e As EventArgs)
        'Frm_RptPayment.StartPosition = FormStartPosition.CenterScreen
        'Frm_RptPayment.ShowDialog()
    End Sub

    Private Sub PaymentToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PaymentToolStripMenuItem1.Click
        Frm_Filter_payment.StartPosition = FormStartPosition.CenterScreen
        Frm_Filter_payment.ShowDialog()
    End Sub

    Private Sub ReportPaymentToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ReportPaymentToolStripMenuItem1.Click
        'Frm_RptPayment.StartPosition = FormStartPosition.CenterScreen
        'Frm_RptPayment.ShowDialog()
    End Sub

   

    Private Sub TaxToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TaxToolStripMenuItem.Click
        Frm_FP.StartPosition = FormStartPosition.CenterScreen
        Frm_FP.ShowDialog()
    End Sub

    Private Sub PPHToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PPHToolStripMenuItem.Click

    End Sub

  
    Private Sub ReportListPaymentWithDetailToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReportListPaymentWithDetailToolStripMenuItem.Click
        frm_bank.StartPosition = FormStartPosition.CenterScreen
        frm_bank.ShowDialog()
    End Sub

   
   
    Private Sub ReportListPaymentToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ReportListPaymentToolStripMenuItem1.Click
        'Frm_RptBank.StartPosition = FormStartPosition.CenterScreen
        'Frm_RptBank.ShowDialog()
    End Sub

    Private Sub UploadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadToolStripMenuItem.Click
        'Frm_RptUpload.StartPosition = FormStartPosition.CenterScreen
        'Frm_RptUpload.ShowDialog()
    End Sub

    Private Sub ChooseDataUploadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ChooseDataUploadToolStripMenuItem.Click
        FormRptUpload1.StartPosition = FormStartPosition.CenterScreen
        FormRptUpload1.ShowDialog()
    End Sub
End Class