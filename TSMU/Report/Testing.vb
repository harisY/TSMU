Imports System.Drawing.Printing
Imports DevExpress.XtraReports.UI

Public Class Testing
    Public param1, param2, param3, param4 As String
    Dim Obj As New BarcodeGenerate
    Private Sub Testing_BeforePrint(sender As Object, e As PrintEventArgs) Handles Me.BeforePrint
        LblKodePart.Text = param1
        LblBulan.Text = param2
        LblSite.Text = param3
        LblTgl.Text = param4
    End Sub

    Private Sub Testing_AfterPrint(sender As Object, e As EventArgs) Handles Me.AfterPrint
        'Obj.InsertLog(param1, param2, param3)
    End Sub

    Private Sub XrLabel20_BeforePrint(sender As Object, e As PrintEventArgs) Handles XrLabel20.BeforePrint
        'If param3 = "TSC3" Then
        '    Dim label As XRLabel = TryCast(sender, XRLabel)
        '    Dim Warna As String = GetCurrentColumnValue(Of String)("Color")
        '    If Warna = "Black" Then
        '        label.ForeColor = Color.White
        '        label.BackColor = Color.Black
        '    Else
        '        label.ForeColor = Color.Black
        '        label.BackColor = Color.DarkGray
        '    End If
        'End If

    End Sub
End Class