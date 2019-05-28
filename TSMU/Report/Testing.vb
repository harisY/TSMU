Imports System.Drawing.Printing

Public Class Testing
    Public param1, param2, param3 As String
    Dim Obj As New BarcodeGenerate
    Private Sub Testing_BeforePrint(sender As Object, e As PrintEventArgs) Handles Me.BeforePrint
        LblKodePart.Text = param1
        LblBulan.Text = param2
        LblSite.Text = param3
    End Sub

    Private Sub Testing_AfterPrint(sender As Object, e As EventArgs) Handles Me.AfterPrint
        'Obj.InsertLog(param1, param2, param3)
    End Sub
End Class