Imports DevExpress.XtraEditors.Controls

Public Class FrmPaymentDirect
    Private Sub TextEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles _account.EditValueChanged

    End Sub

    Private Sub TextEdit2_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles _account.ButtonClick
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            Dim ObjSuspend As New ClsSuspend
            If sender.Name = _account.Name Then
                dtSearch = ObjSuspend.GetAccount
                ls_OldKode = _account.Text.Trim
                ls_Judul = "Account"
            End If

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then

                If sender.Name = _account.Name AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                    Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                    Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                    '    Value3 = lF_SearchData.Values.Item(2).ToString.Trim
                    '   Value4 = lF_SearchData.Values.Item(3).ToString.Trim
                    _account.Text = Value1
                    _accountname.Text = Value2
                    '  _TxtToBank.Text = Value3
                    '  _TxtNoRek.Text = Value4

                End If
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
End Class
