Imports DevExpress.LookAndFeel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraReports.UI

Public Class FrmLookUpBarcode
    Dim Obj As New BarcodeGenerate

    Dim dtTemp As DataTable
    Private Sub TempTable()
        dtTemp = New DataTable
        dtTemp.Columns.Add("No")
        dtTemp.Columns.Add("InvtID")
        dtTemp.Columns.Add("Color")
        dtTemp.Columns.Add("PartNo")
        dtTemp.Columns.Add("KodePart")
        dtTemp.Columns.Add("JobNo")
        dtTemp.Columns.Add("PartName")
        dtTemp.Columns.Add("Bulan")
        dtTemp.Columns.Add("Status")
        dtTemp.Columns.Add("Qty")
        dtTemp.Columns.Add("Quality")
        dtTemp.Columns.Add("Outgoing")
        dtTemp.Columns.Add("DeliveryDate")
        dtTemp.Columns.Add("Color2")
        dtTemp.Columns.Add("QrCode")
        dtTemp.Columns.Add("Warna")
        dtTemp.Clear()
    End Sub

    Private Sub GenerateRow()
        Try
            Dim a As Integer
            Dim b As Integer
            a = TxtFrom.Text
            b = TxtTo.Text

            For i As Integer = a To b - 1
                dtTemp.Rows.Add()
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(0) = "Level 0"
                'dtTemp.Rows(dtTemp.Rows.Count - 1).Item(1) = Trim(dt.Rows(i).Item("level0") & "")
            Next
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click
        Try

            If TxtKodePart.Text = "" OrElse CmbBulan.Text = "" OrElse TxtFrom.Text = "" OrElse TxtTo.Text = "" Then
                Throw New Exception("Silahkan lengkapi data")
            ElseIf TxtFrom.Text = "0" OrElse TxtTo.Text = "0" Then
                TxtFrom.Focus()
                Throw New Exception("Page From/To tidak boleh '0'")
            ElseIf Val(TxtFrom.Text) > Val(TxtTo.Text) Then
                TxtFrom.Focus()
                Throw New Exception("Page From tidak boleh lebih besar dari To")
            End If
            Dim ds As DataSet = New DataSet
            Dim dt As DataTable = New DataTable
            ds = Obj.PrintQRCOde(TxtKodePart.Text)

            dt = ds.Tables("QRCode")

            Dim a As Integer
            Dim b As Integer
            a = TxtFrom.Text
            b = TxtTo.Text

            If dt.Rows.Count = 0 Then
                Throw New Exception("Kode Part tidak ditemukan, Silahkan input kode yang lain")
            End If
            TempTable()

            For i As Integer = a To b
                dtTemp.Rows.Add()
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(0) = i
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(1) = Trim(dt.Rows(0).Item("InvtID") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(2) = Trim(dt.Rows(0).Item("Color") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(3) = Trim(dt.Rows(0).Item("PartNo") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(4) = Trim(dt.Rows(0).Item("KodePart") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(5) = Trim(dt.Rows(0).Item("JobNo") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(6) = Trim(dt.Rows(0).Item("PartName") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(7) = CmbBulan.Text
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(8) = Trim(dt.Rows(0).Item("Status") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(9) = Trim(dt.Rows(0).Item("Qty") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(10) = Trim(dt.Rows(0).Item("Quality") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(1) = Trim(dt.Rows(0).Item("Outgoing") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(12) = Trim(dt.Rows(0).Item("DeliveryDate") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(13) = Trim(dt.Rows(0).Item("Color2") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(14) = Trim(dt.Rows(0).Item("JobNo") & "") & "-" & i & "-" & CmbBulan.Text
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(15) = Trim(dt.Rows(0).Item("Warna") & "")
            Next

            Dim Laporan As New Testing
            With Laporan
                .param1 = TxtKodePart.Text
                .param2 = CmbBulan.Text
                '.param3 = "No.Form TSC-1/QR/INJ/01/009, Tgl Terbit. 30/11/11, Rev. 2 Tgl Revisi : 26/03/18"
                .DataSource = dtTemp
                '.DataMember = ds.Tables("PrintPO").TableName
            End With

            Using PrintTool As ReportPrintTool = New ReportPrintTool(Laporan)
                PrintTool.ShowPreviewDialog()
                PrintTool.ShowPreview(UserLookAndFeel.Default)
            End Using
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub FrmLookUpBarcode_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CmbSite_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CmbSite.KeyPress
        e.Handled = True
    End Sub

    Private Sub CmbBulan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CmbBulan.KeyPress
        e.Handled = True
    End Sub
End Class