Imports System.Net.Mail

Public Class TestEmail

    Dim fc_Class As New ClsCR_CreateUser
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
#Region "send Email"


        Dim MyMailMessage As New MailMessage
        Dim A As ArrayList = New ArrayList
        Dim dtEmail As New DataTable
        Dim pesan As DialogResult = MessageBox.Show("Apakah Mau Coba Kirim Email", "Test", MessageBoxButtons.YesNo)

        If pesan = DialogResult.Yes Then
            'dtEmail = fc_Class.Email_test()
            MyMailMessage.Body = "Test Email Cikarang Tangerang"

            MyMailMessage.From = New MailAddress("circulation@tsmu.co.id", "CIRCULATION")

            MyMailMessage.To.Add("agung-mis@tsmu.co.id")
            MyMailMessage.CC.Add("log@tsmu.co.id")
            MyMailMessage.CC.Add("miftah-mis@tsmu.co.id")
            MyMailMessage.Subject = "Test Email"

            Dim SMTP As New SmtpClient("mail.tsmu.co.id")
            'SMTP.Port = 587
            SMTP.Port = 465
            SMTP.EnableSsl = False
            SMTP.Credentials = New System.Net.NetworkCredential("circulation@tsmu.co.id", "MREK2*Pv5{WV")
            'SMTP.Timeout = 10000
            'SMTP.Send(MyMailMessage)
            MessageBox.Show("Sukses",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Information,
                               MessageBoxDefaultButton.Button1)
        End If
#End Region
    End Sub

    Private Sub TestEmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
