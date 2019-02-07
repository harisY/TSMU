Public Class frmCalculate
    Private Sub frmCalculate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillComboBulan()
    End Sub

    Private Sub FillComboBulan()
        Dim tahun() As String = {"", "Januari", "Februari", "Maret", "April", "Mei", "Juni", "Juli", "Agustus", "September", "November", "Desember"}
        CmbBulan1.Properties.Items.Clear()
        For Each var As String In tahun
            CmbBulan1.Properties.Items.Add(var)
        Next

        CmbBulan2.Properties.Items.Clear()
        For Each var As String In tahun
            CmbBulan2.Properties.Items.Add(var)
        Next
    End Sub
    Private Sub FillComboTahun()
        Dim tahun() As String = {"", DateTime.Today.Year.ToString, (DateTime.Today.Year - 1).ToString, (DateTime.Today.Year - 2).ToString}
        CmbTahun.Properties.Items.Clear()
        For Each var As String In tahun
            CmbTahun.Properties.Items.Add(var)
        Next
    End Sub
End Class
