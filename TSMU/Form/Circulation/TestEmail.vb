
Imports EASendMail

Public Class TestEmail

    Dim fc_Class As New ClsCR_CreateUser
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
#Region "send Email"


        'Dim MyMailMessage As New MailMessage
        'Dim A As ArrayList = New ArrayList
        'Dim dtEmail As New DataTable
        'Dim pesan As DialogResult = MessageBox.Show("Apakah Mau Coba Kirim Email", "Test", MessageBoxButtons.YesNo)

        'If pesan = DialogResult.Yes Then
        '    'dtEmail = fc_Class.Email_test()
        '    MyMailMessage.Body = "Test Email Cikarang Tangerang"

        '    MyMailMessage.From = New MailAddress("circulation@tsmu.co.id", "CIRCULATION")

        '    MyMailMessage.To.Add("agung-mis@tsmu.co.id")
        '    MyMailMessage.CC.Add("log@tsmu.co.id")
        '    MyMailMessage.CC.Add("miftah-mis@tsmu.co.id")
        '    MyMailMessage.Subject = "Test Email"

        '    Dim SMTP As New SmtpClient("mail.tsmu.co.id")
        '    'SMTP.Port = 587
        '    SMTP.Port = 465
        '    SMTP.EnableSsl = False
        '    SMTP.Credentials = New System.Net.NetworkCredential("circulation@tsmu.co.id", "MREK2*Pv5{WV")
        '    'SMTP.Timeout = 10000
        '    'SMTP.Send(MyMailMessage)
        '    MessageBox.Show("Sukses",
        '                       "Warning",
        '                       MessageBoxButtons.OK,
        '                       MessageBoxIcon.Information,
        '                       MessageBoxDefaultButton.Button1)
        'End If

        Try

            Dim oMail As New SmtpMail("TryIt")
            ' Set sender email address, please change it to yours
            oMail.From = "circulation@tsmu.co.id"
            ' Set recipient email address, please change it to yours
            oMail.To = "miftah-mis@tsmu.co.id"
            oMail.Cc = "log@tsmu.co.id"

            ' Set email subject
            oMail.Subject = "test email from VB.NET project"
            ' Set email body
            oMail.TextBody = "this is a test email sent from VB.NET project, do not reply"

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


#End Region
    End Sub

    Private Sub TestEmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
