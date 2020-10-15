Imports DevExpress.Data
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraSplashScreen

Public Class FrmMktExcelPrice
    Dim cls_UploadPrice As New ClsMktUploadPrice
    Dim proses As String = String.Empty
    Dim path As String = String.Empty
    Dim dtExcel As New DataTable
    Dim dtTemplate As New DataTable
    Dim dtColumn As DataTable
    Dim dtResult As New DataTable

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(ByRef dt As DataTable)
        ' This call is required by the Windows Form Designer.
        Me.New()
        ' Add any initialization after the InitializeComponent() call.
        dtExcel = dt
    End Sub

    Private Sub FrmMktExcelPrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListItemsTemplate()
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Try
            OpenFileDialog1.Filter = "Excel Files|*.xls;*.xlsx"
            Dim result As DialogResult = OpenFileDialog1.ShowDialog()
            If result = System.Windows.Forms.DialogResult.OK Then
                path = OpenFileDialog1.FileName
                Dim text As String = System.IO.File.ReadAllText(path)
                txtFileName.Text = path
            End If
        Catch ex As Exception When Not TypeOf ex Is MissingMethodException
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub btnSimulate_Click(sender As Object, e As EventArgs) Handles btnSimulate.Click
        Try
            If proses <> "" Then
                Throw New Exception("Proses masih berjalan !")
            End If
            If txtFileName.Text = "" Then
                txtFileName.Focus()
                Throw New Exception("File Excel yang akan di upload tidak ada !")
            End If
            Dim connString As String = String.Empty
            Dim extension As String = System.IO.Path.GetExtension(path)

            Select Case extension
                Case ".xls"
                    'Excel 97-03
                    connString = ConfigurationManager.ConnectionStrings("Excel03ConString").ConnectionString
                    Exit Select
                Case ".xlsx"
                    'Excel 07 or higher
                    connString = ConfigurationManager.ConnectionStrings("Excel07+ConString").ConnectionString
                    Exit Select
            End Select

            connString = String.Format(connString, path)
            Using excel_con As New OleDbConnection(connString)
                excel_con.Open()
                'Dim sheet1 As String = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing).Rows(0)("TABLE_NAME").ToString()
                Dim __rows As String = String.Empty
                For Each row As DataRow In dtTemplate.Select("TemplateID = '" & txtTemplate.EditValue & "'")
                    __rows = row("SheetName") + "$" + row("StartRow") + ":" + row("EndRow")
                Next
                Using oda As New OleDbDataAdapter((Convert.ToString("SELECT * FROM [") & __rows) + "]", excel_con)
                    Try
                        dtExcel = New DataTable
                        oda.Fill(dtExcel)
                    Catch ex As Exception
                        Throw New Exception("Pilih template yang sesuai !")
                    End Try
                End Using
                excel_con.Close()
            End Using
            SimulatePrice()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub ListItemsTemplate()
        cls_UploadPrice = New ClsMktUploadPrice
        dtTemplate = New DataTable
        dtTemplate = cls_UploadPrice.GetListTemplate()
        txtTemplate.Properties.DataSource = dtTemplate
        txtTemplate.Size = txtTemplate.CalcBestSize()
        txtTemplate.Properties.PopupFormMinSize = txtTemplate.Size
        txtTemplate.Properties.PopupWidth = txtTemplate.Size.Width
        txtTemplate.EditValue = "001"
    End Sub

    Private Sub SimulatePrice()
        cls_UploadPrice = New ClsMktUploadPrice
        CreateTable()
        Dim clmName As String = String.Empty
        If checkColumn() = False Then
            Dim rowColumn As DataRow() = dtColumn.Select("ColumnInTable = 'invtid'")
            clmName = rowColumn(0)("ColumnInExcel").ToString
            Dim clmNameTable As String = String.Empty
            Dim No As Integer
            Dim succes As Integer
            Dim _error As Integer
            clmNameTable = Replace(Replace(Replace(clmName, ".", "#"), "[", "("), "]", ")")
            SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
            For Each rows As DataRow In dtExcel.Rows
                If Not String.IsNullOrEmpty(IIf(rows(clmNameTable) Is DBNull.Value, "", rows(clmNameTable))) Then
                    Dim dt As New DataTable
                    dt = cls_UploadPrice.CheckInventoryID(rows(clmNameTable))
                    No += 1
                    If dt.Rows.Count = 0 Then
                        dtResult.Rows.Add(No, rows(clmNameTable), "", "Error ", "" & clmName & " Not Found !")
                        _error += 1
                    ElseIf dt.Rows.Count > 1 Then
                        dtResult.Rows.Add(No, rows(clmNameTable), "", "Error ", "InventoryID Lebih Dari 1 !")
                        _error += 1
                    Else
                        If String.IsNullOrEmpty(IIf(dt.Rows(0).Item("DiscPrice") Is DBNull.Value, "", dt.Rows(0).Item("DiscPrice"))) Then
                            dtResult.Rows.Add(No, rows(clmNameTable), dt.Rows(0).Item("InvtID"), "Error ", "Price Not Found !")
                            _error += 1
                        Else
                            dtResult.Rows.Add(No, rows(clmNameTable), dt.Rows(0).Item("InvtID"), "Success", "")
                            succes += 1
                        End If
                    End If
                End If
            Next
            SplashScreenManager.CloseForm()
            dtResult.Columns(1).Caption = clmName
            GridResult.DataSource = dtResult
            GridViewResult.BestFitColumns()
            GridViewResult.Columns(0).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            lblResult.Text = "Total Success : " & succes & " | Total Error : " & _error & ""
            If _error = 0 Then
                btnExport.Text = "Upload"
            Else
                btnExport.Text = "Save To Excel"
            End If
        Else
            GridResult.DataSource = Nothing
            GridResult.Refresh()
            lblResult.Text = "Total Success : 0 | Total Error : 0"
        End If
    End Sub

    Private Function checkColumn() As Boolean
        Dim isNotFound As Boolean = False
        Try
            Dim listColumn As New List(Of String)
            For Each clm As DataColumn In dtExcel.Columns
                listColumn.Add(Replace(Replace(Replace(clm.ColumnName.ToString(), "#", "."), "(", "["), ")", "]"))
            Next
            For Each row As DataRow In dtColumn.Rows
                If Not String.IsNullOrEmpty(row("ColumnInExcel")) Then
                    If Not listColumn.Contains(row("ColumnInExcel")) Then
                        isNotFound = True
                        Throw New Exception("Column (" & row("ColumnInExcel") & ") tidak ditemukan, Pilih template yang sesuai!")
                    End If
                End If
            Next
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
        Return isNotFound
    End Function

    Public Sub CreateTable()
        dtResult = New DataTable
        dtResult.Columns.AddRange(New DataColumn(4) {New DataColumn("No", GetType(Integer)),
                                                        New DataColumn("PartNo", GetType(String)),
                                                        New DataColumn("InventoryID", GetType(String)),
                                                        New DataColumn("Status", GetType(String)),
                                                        New DataColumn("Message", GetType(String))})
    End Sub

    Private Sub txtTemplate_EditValueChanged(sender As Object, e As EventArgs) Handles txtTemplate.EditValueChanged
        cls_UploadPrice = New ClsMktUploadPrice
        dtColumn = New DataTable
        dtColumn = cls_UploadPrice.GetMappingColumn(txtTemplate.EditValue)
        txtFileName.Text = ""
        GridResult.DataSource = Nothing
        GridResult.Refresh()
        lblResult.Text = "Total Success : 0 | Total Error : 0"
        btnExport.Text = "Save To Excel"
    End Sub

    Private Sub GridviewResult_CustomDrawCell(sender As Object, e As RowCellCustomDrawEventArgs) Handles GridViewResult.CustomDrawCell
        Dim view As GridView = sender
        If view Is Nothing Then
            Return
        End If
        If view.IsFilterRow(e.RowHandle) Then
            Return
        End If
        If e.Column.FieldName.ToLower = "Status" Then
            If Convert.ToString(e.CellValue).ToLower = "Success" Then
                e.Appearance.BackColor = Color.White
            Else
                e.Appearance.BackColor = Color.Red
            End If
        End If
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If GridViewResult.RowCount > 0 Then
            Dim path As String = "Result.xlsx"

            CType(GridResult.MainView, GridView).OptionsPrint.PrintHeader = True
            Dim advOptions As XlsxExportOptionsEx = New XlsxExportOptionsEx()
            advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False
            advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.False
            advOptions.SheetName = "Result Upload"

            GridResult.ExportToXlsx(path, advOptions)
            Process.Start(path)
        End If
    End Sub

End Class