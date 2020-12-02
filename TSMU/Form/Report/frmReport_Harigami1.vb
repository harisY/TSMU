Imports Excel = Microsoft.Office.Interop.Excel
Imports ExcelLibrary
Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraReports.UI
Imports DevExpress.LookAndFeel

Public Class frmReport_Harigami1
    Dim ObjHarigami As HarigamiModels
    Dim fdtl_Config As DataTable = Nothing

    Private Sub frmReport_Harigami1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, False, False, True, True, False, True, False, False, False, False, False)
        Init()
    End Sub
    Private Sub Init()
        Grid.DataSource = Nothing
        TxtDari.EditValue = Date.Today
        TxtSampai.EditValue = Date.Today
        TxtType.SelectedIndex = 0
    End Sub

    Public Overrides Sub Proc_Refresh()
        Try
            If TxtFileNo.Text <> "" OrElse TxtType.Text <> "" Then
                ObjHarigami = New HarigamiModels
                Dim dt As New DataTable
                dt = ObjHarigami.GenerateDataGrid(TxtFileNo.Text, TxtType.Text, TxtDari.EditValue, TxtSampai.EditValue)
                Grid.DataSource = dt
                If GridView1.RowCount > 0 Then
                    GridView1.BestFitColumns()
                    GridCellFormatDatewithTime(GridView1)
                End If
            Else
                Throw New Exception("Data tidak boleh kosonng, Cek inputan anda !")
            End If
            'Call GetDataGrid()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub SaveToExcel(_Grid As GridControl)
        Dim save As New SaveFileDialog
        save.Filter = "Excel File|*.xlsx"
        save.Title = "Save an Excel File"
        If save.ShowDialog = DialogResult.OK Then
            _Grid.ExportToXlsx(save.FileName)
        End If
    End Sub
    Public Overrides Sub Proc_Excel()
        Try
            If GridView1.RowCount > 0 Then
                SaveToExcel(Grid)
            Else
                MsgBox("Grid Kosong !")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Public Overrides Sub Proc_PrintPreview()
        Try
            TempTable()

            For i As Integer = 0 To GridView1.RowCount - 1
                Dim FileNo As String = If(IsDBNull(GridView1.GetRowCellValue(i, "FileNo")), "", GridView1.GetRowCellValue(i, "FileNo"))
                Dim PartNo As String = If(IsDBNull(GridView1.GetRowCellValue(i, "PartNo")), "", GridView1.GetRowCellValue(i, "PartNo"))
                Dim Type As String = If(IsDBNull(GridView1.GetRowCellValue(i, "Type")), "", GridView1.GetRowCellValue(i, "Type"))
                Dim Tanggal As DateTime = If(IsDBNull(GridView1.GetRowCellValue(i, "Tanggal")), Date.Parse("1900-01-01"), GridView1.GetRowCellValue(i, "Tanggal").ToString())
                Dim Counter As String = If(IsDBNull(GridView1.GetRowCellValue(i, "Counter")), "0", GridView1.GetRowCellValue(i, "Counter"))

                dtTemp.Rows.Add()
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(0) = i + 1
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(1) = Trim(FileNo)
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(2) = Trim(PartNo)
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(3) = Trim(Type)
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(4) = Tanggal
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(5) = Counter
            Next

            If dtTemp.Rows.Count > 0 Then
                Dim Laporan As New HarigamiReport()
                With Laporan
                    .DataSource = dtTemp
                End With
                Dim PrintTool As ReportPrintTool
                PrintTool = New ReportPrintTool(Laporan)
                TryCast(PrintTool.Report, XtraReport).Tag = PrintTool
                PrintTool.ShowPreview(UserLookAndFeel.Default)
            Else
                ShowMessage("Data kosong !", MessageTypeEnum.ErrorMessage)
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub TxtFileNo_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtFileNo.ButtonClick
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            ObjHarigami = New HarigamiModels
            If sender.Name = TxtFileNo.Name Then
                dtSearch = ObjHarigami.PopulateFileNo
                ls_OldKode = TxtFileNo.Text.Trim
                ls_Judul = "File No"
                'ElseIf sender.name = TxtPartNo.Name Then
                '    dtSearch = ObjHarigami.PopulateFileNo
                '    ls_OldKode = TxtPartNo.Text.Trim
                '    ls_Judul = "Part No"
            End If

            dtSearch.Rows.InsertAt(dtSearch.NewRow, 0)
            dtSearch.Rows(0).Item(0) = "ALL"
            dtSearch.Rows(0).Item(1) = "ALL"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim ls_Kode As String = ""
            Dim ls_Nama As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                'If sender.Name = TxtFileNo.Name AndAlso ls_Kode <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                '    TxtFileNo.Text = ls_Kode
                '    TxtFileNo.Focus()
                'End If
                'If sender.Name = TxtPartNo.Name AndAlso ls_Kode <> "" AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                '    TxtPartNo.Text = ls_Kode
                '    TxtPartNo.Focus()
                'End If
                ls_Kode = lF_SearchData.Values.Item(0).ToString.Trim
                ls_Nama = lF_SearchData.Values.Item(1).ToString.Trim
                TxtFileNo.Text = ls_Kode
                TxtPartNo.Text = ls_Nama
                TxtType.Focus()
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub TxtType_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtType.KeyPress
        e.Handled = True
    End Sub
    Dim dtTemp As DataTable
    Private Sub TempTable()
        dtTemp = New DataTable
        dtTemp.Columns.Add("No")
        dtTemp.Columns.Add("FileNo")
        dtTemp.Columns.Add("PartNo")
        dtTemp.Columns.Add("Type")
        dtTemp.Columns.Add("Tanggal", GetType(Date))
        dtTemp.Columns.Add("Counter")
        dtTemp.Clear()
    End Sub
End Class
