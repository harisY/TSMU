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
            dtEmail = fc_Class.Email_test()
            MyMailMessage.Body = "Test Email Cikarang Tangerang"

            MyMailMessage.From = New MailAddress("circulation@tsmu.co.id", "CIRCULATION")

            For i As Integer = 0 To dtEmail.Rows.Count - 1
                If dtEmail.Rows.Count > 0 Then
                    Dim cekEmail As String = ""
                    cekEmail = IIf(dtEmail.Rows(i).Item(0) Is DBNull.Value, "", dtEmail.Rows(i).Item(0))

                    If cekEmail = "" Then
                        MyMailMessage.To.Add("miftah-mis@tsmu.co.id")
                    Else
                        MyMailMessage.To.Add(dtEmail.Rows(i).Item(0))
                    End If

                Else
                    MyMailMessage.To.Add("miftah-mis@tsmu.co.id")
                End If

            Next

            MyMailMessage.CC.Add("log@tsmu.co.id")
            MyMailMessage.CC.Add("miftah-mis@tsmu.co.id")
            MyMailMessage.Subject = "Test Email"

            Dim SMTP As New SmtpClient("mail.tsmu.co.id")
            SMTP.Port = 587
            SMTP.EnableSsl = False
            SMTP.Credentials = New System.Net.NetworkCredential("circulation@tsmu.co.id", "MREK2*Pv5{WV")
            SMTP.Send(MyMailMessage)
        End If
#End Region
    End Sub

    Private Sub TestEmail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
