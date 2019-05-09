Imports System.Drawing.Printing

Public Class Testing
    Public param1, param2, param3 As String

    Private Sub Testing_BeforePrint(sender As Object, e As PrintEventArgs) Handles Me.BeforePrint
        LblKodePart.Text = param1
        LblBulan.Text = param2
        'LblIso.Text = param3
    End Sub
End Class