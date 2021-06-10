Imports System.Net.Mail
Imports EASendMail

Public Class TestEmail

    Dim fc_Class As New ClsCR_CreateUser
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
#Region "send Email"


        Dim MyMailMessage As New MailMessage
        Dim A As ArrayList = New ArrayList
        Dim dtEmail As New DataTable


        Dim pesan As DialogResult = MessageBox.Show("Apakah Mau Coba Kirim Email", "Test", MessageBoxButtons.YesNo)

        If pesan = DialogResult.Yes Then
            Try

                Dim oMail As New SmtpMail("TryIt")
                ' Set sender email address, please change it to yours
                oMail.From = "circulation@tsmu.co.id"
                ' Set recipient email address, please change it to yours
                oMail.To = "agung-mis@tsmu.co.id"
                oMail.Cc = "log@tsmu.co.id"
                oMail.Cc = "miftah-mis@tsmu.co.id"

                ' Set email subject
                oMail.Subject = "Email Test"
                ' Set email body
                oMail.TextBody = "Test Email Cikarang Tangerang"

                ' Your SMTP server address
                Dim oServer As New SmtpServer("mail.tsmu.co.id")

                ' User and password for ESMTP authentication
                oServer.User = "circulation@tsmu.co.id"
                oServer.Password = "MREK2*Pv5{WV"

                ' Set SSL 465 port
                oServer.Port = 465

                ' Set direct SSL connection, you can also use ConnectSSLAuto
                oServer.ConnectType = SmtpConnectType.ConnectDirectSSL

                Console.WriteLine("start to send email ...")

                Dim oSmtp As New EASendMail.SmtpClient()
                oSmtp.SendMail(oServer, oMail)

                Console.WriteLine("email was sent successfully!")
            Catch ep As Exception
                Console.WriteLine("failed to send email with the following error:")
                Console.WriteLine(ep.Message)
            End Try
        End If
#End Region
    End Sub

    Private Sub TestEmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
