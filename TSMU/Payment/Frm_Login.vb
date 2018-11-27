Imports System.Data
Imports System.Data.SqlClient

Public Class Frm_Login

    Dim login1 As Cls_login = New Cls_login()
    Dim perintah As Integer = 0

    Private Function IsControlEmpty() As Boolean
        Try
            If _user_id.Text = "" Then
                Throw New Exception("Username Harus Di isi!")
                _user_id.Focus()
            ElseIf _user_name.Text = "" Then
                Throw New Exception("Password Harus Di isi!")
                _user_name.Focus()
            End If
            Return False
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.OkOnly)
            Return True
        End Try
    End Function

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        login()
    End Sub

    Sub usergetobject()
        login1.user_id = _user_id.Text
        login1.user_name = _user_name.Text

    End Sub

    Sub login()
        Try
            Dim IsEmpty As Boolean = IsControlEmpty()

            If IsEmpty = False Then
                usergetobject()
                Dim dt As DataTable = New DataTable
                dt = login1.getalldata
                If dt.Rows.Count > 0 Then
                    user1 = _user_id.Text

                    If Trim(dept1) = "3PGA" Then
                        Form_MENU.Show()
                    Else
                        Form_MENU.Show()
                    End If

                    Me.Hide()
                Else
                    MsgBox("User atau Password Anda Salah")
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TextBox1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _user_id.KeyPress
        If e.KeyChar = Chr(13) Then _user_name.Focus()
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _user_name.KeyPress
        Try
            If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Enter) Then
                login()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        _user_id.Clear()
        _user_name.Clear()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If MessageBox.Show("Apakah Anda Yakin Ingin Menutup Aplikasi..?", "INFORMATION", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            End
        End If
    End Sub

    Private Sub Frm_Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class