Imports System.Drawing.Printing
Imports System.IO
Imports DevExpress.XtraPrinting.Drawing

Public Class ReportDrr
    Dim _path As String = "\\10.10.3.6\d$\TESTING\DRR Sktech\"
    Private Sub ReportDrr_BeforePrint(sender As Object, e As PrintEventArgs) Handles Me.BeforePrint
        Dim Gambar1 As String = If(IsDBNull(GetCurrentColumnValue(Of String)("Gambar1")), String.Empty, GetCurrentColumnValue(Of String)("Gambar1").ToString)
        Dim Gambar2 As String = If(IsDBNull(GetCurrentColumnValue(Of String)("Gambar2")), String.Empty, GetCurrentColumnValue(Of String)("Gambar2").ToString)
        Dim Gambar3 As String = If(IsDBNull(GetCurrentColumnValue(Of String)("Gambar3")), String.Empty, GetCurrentColumnValue(Of String)("Gambar3").ToString)
        Dim Gambar4 As String = If(IsDBNull(GetCurrentColumnValue(Of String)("Gambar4")), String.Empty, GetCurrentColumnValue(Of String)("Gambar4").ToString)
        Dim Gambar5 As String = If(IsDBNull(GetCurrentColumnValue(Of String)("Gambar5")), String.Empty, GetCurrentColumnValue(Of String)("Gambar5").ToString)

        If Gambar1 <> "N/A" Then
            XrPictureBox2.ImageSource = New ImageSource(New Bitmap(Path.Combine(_path, ImageName(Gambar1))))
        End If
        If Gambar2 <> "N/A" Then
            XrPictureBox3.ImageSource = New ImageSource(New Bitmap(Path.Combine(_path, ImageName(Gambar2))))
        End If
        If Gambar3 <> "N/A" Then
            XrPictureBox4.ImageSource = New ImageSource(New Bitmap(Path.Combine(_path, ImageName(Gambar3))))
        End If
        If Gambar4 <> "N/A" Then
            XrPictureBox5.ImageSource = New ImageSource(New Bitmap(Path.Combine(_path, ImageName(Gambar4))))
        End If

    End Sub

    Public Function ImageName(Gambar As String) As String
        If String.IsNullOrEmpty(Gambar) Then
            Return ""
        End If
        Dim PathParts = Gambar.Split(","c)
        Dim FileName As String = PathParts(0)
        Return FileName
    End Function
End Class