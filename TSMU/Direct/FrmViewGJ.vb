Imports Excel = Microsoft.Office.Interop.Excel
Imports ExcelLibrary
Imports DevExpress.XtraGrid
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors.Controls
Imports System.Globalization
Imports System.Windows.Forms.ImageList
Imports DevExpress.LookAndFeel
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI
Public Class FrmViewGJ
    Dim dtGrid As DataTable
    Dim _Service As GJHeaderModel
    Dim Objgl As GJHeaderModel

    Dim TotAmount As Double
    Private Sub FrmViewGJ_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub ListItemsPerpost()
        Objgl = New GJHeaderModel
        Dim dt = New DataTable

        dt = Objgl.GetListPerpost()
        Dim itemsCollection As ComboBoxItemCollection = _TxtPerpost.Properties.Items
        itemsCollection.BeginUpdate()
        itemsCollection.Clear()
        Try
            For Each r As DataRow In dt.Rows
                itemsCollection.Add(r.Item(0))
            Next
        Finally
            itemsCollection.EndUpdate()
        End Try
    End Sub

    Private Sub LoadDataxx()
        Try
            If _TxtPerpost.Text = "" Then

                Throw New Exception("Silahkan pilih perpost!")
            End If
            Cursor = Cursors.WaitCursor
            Objgl = New GJHeaderModel
            Dim dtSearch2 As New DataTable
            '' dtSearch2 = ObjSuspend2.GetCustomer2
            dtSearch2 = Objgl.GetGJPerpost(IIf(_TxtCuryID.Text = "", "ALL", _TxtCuryID.Text), _TxtPerpost.Text)
            Grid.DataSource = dtSearch2
            GridCellFormat(GridView1)
            GridView1.BestFitColumns()

            With GridView1
                .Columns(0).Visible = False
            End With
            GridCellFormat(GridView1)


            GridView1.Columns("Perpost").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("NoBukti").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("AcctID").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("Keterangan").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("CuryID").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath
            GridView1.Columns("Transaksi").AppearanceCell.TextOptions.Trimming = Trimming.EllipsisPath

            Cursor = Cursors.Default

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadDataxx()
    End Sub
    Private Sub tsBtn_excel_Click(sender As Object, e As EventArgs) Handles tsBtn_excel.Click
        Proc_Excel()
    End Sub
    Private Sub Proc_Excel()
        Try

            If GridView1.RowCount > 0 Then
                    SaveToExcel(Grid)
                    MsgBox("Data Sudah Berhasil Di Export.")
                Else
                    MsgBox("Grid Kosong!")
                End If

        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub SaveToExcel(_Grid As GridControl)
        Dim save As New SaveFileDialog
        save.Filter = "Excel File|*.xls"
        save.Title = "Save an Excel File"
        If save.ShowDialog = DialogResult.OK Then
            _Grid.ExportToXls(save.FileName)
        End If
    End Sub
    Private Sub _TxtPerpost_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _TxtPerpost.SelectedIndexChanged

    End Sub

    Private Sub _TxtPerpost_Click(sender As Object, e As EventArgs) Handles _TxtPerpost.Click
        ListItemsPerpost()
    End Sub
End Class
