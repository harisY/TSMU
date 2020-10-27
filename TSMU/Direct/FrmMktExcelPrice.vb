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
    Dim dtUploadTemp As New DataTable
    Dim dtUpload As New DataTable
    Dim listColumn As New List(Of String)
    Dim isUpload As Boolean = False

    Dim clmPartNoExcel As String = String.Empty
    Dim clmPriceExcel As String = String.Empty
    Dim clmDateExcel As String = String.Empty
    Dim clmDescExcel As String = String.Empty
    Dim custID As String

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    ReadOnly Property _isUpload() As Boolean
        Get
            Return isUpload
        End Get
    End Property

    ReadOnly Property _dtResult() As DataTable
        Get
            Return dtUpload
        End Get
    End Property

    Private Sub FrmMktExcelPrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateTable()
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
                dtResult.Clear()
                GridResult.DataSource = dtResult
                GridViewResult.BestFitColumns()
                GridViewResult.Columns(1).Caption = clmPartNoExcel
                lblResult.Text = "Total Success : 0 | Total Error : 0"
            End If
        Catch ex As Exception When Not TypeOf ex Is MissingMethodException
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
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
            CheckPrice()
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

    Private Sub CheckPrice()
        dtResult.Clear()
        dtUploadTemp.Clear()
        cls_UploadPrice = New ClsMktUploadPrice
        If checkColumn() = False Then
            Dim No As Integer
            Dim succes As Integer
            Dim _error As Integer
            SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
            Dim dt As New DataTable
            dt = cls_UploadPrice.CheckInventoryID(custID)
            For Each rows As DataRow In dtExcel.Rows
                If Not String.IsNullOrEmpty(IIf(rows(clmPartNoExcel) Is DBNull.Value, "", rows(clmPartNoExcel))) Then
                    Dim rowInvtID As DataRow()
                    No += 1
                    Dim status As String = "Error"
                    Dim message As String = String.Empty
                    Dim invtID As String = String.Empty
                    rowInvtID = dt.Select("AlternateID = " & QVal(Replace(rows(clmPartNoExcel), "-", "")) & " ")
                    If rowInvtID.Count = 0 Then
                        message = "" & clmPartNoExcel & " Not Found !"
                        _error += 1
                    ElseIf rowInvtID.Count > 1 Then
                        message = "InventoryID More Than 1 !"
                        _error += 1
                    Else
                        If String.IsNullOrEmpty(IIf(rowInvtID(0)("DiscPrice") Is DBNull.Value, "", rowInvtID(0)("DiscPrice").ToString)) Then
                            message = "Price Not Found !"
                            _error += 1
                        Else
                            invtID = rowInvtID(0)("InvtID").ToString
                            status = "Success"
                            Dim _newRow As DataRow
                            _newRow = dtUploadTemp.NewRow
                            _newRow("No") = No
                            _newRow("AlternateID") = rows(clmPartNoExcel)
                            _newRow("InventoryID") = invtID
                            _newRow("Desc") = rows(clmDescExcel)
                            _newRow("OldPrice") = rowInvtID(0)("DiscPrice")
                            _newRow("NewPrice") = rows(clmPriceExcel)
                            _newRow("EffectiveDate") = Date.Today 'IIf(clmDateExcel Is Nothing, Date.Today, rows(clmDateExcel))
                            dtUploadTemp.Rows.Add(_newRow)
                            succes += 1
                        End If
                    End If
                    Dim newRow As DataRow
                    newRow = dtResult.NewRow
                    newRow("No") = No
                    newRow("PartNo") = rows(clmPartNoExcel)
                    newRow("InventoryID") = invtID
                    newRow("Desc") = rows(clmDescExcel)
                    newRow("Status") = status
                    newRow("Message") = message
                    dtResult.Rows.Add(newRow)
                End If
            Next
            SplashScreenManager.CloseForm()
            GridViewResult.BestFitColumns()
            GridViewResult.Columns("PartNo").Caption = clmPartNoExcel
            GridViewResult.Columns("Desc").Caption = clmDescExcel
            GridViewResult.Columns(0).AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
            lblResult.Text = "Total Success : " & succes & " | Total Error : " & _error & ""
            If _error = 0 Then
                btnExport.Text = "Upload"
            Else
                btnExport.Text = "Save To Excel"
            End If
        Else
            dtResult.Clear()
            GridResult.DataSource = dtResult
            GridResult.Refresh()
            lblResult.Text = "Total Success : 0 | Total Error : 0"
        End If
    End Sub

    Private Function checkColumn() As Boolean
        Dim isNotFound As Boolean = False
        Try
            For i As Integer = 0 To listColumn.Count - 1
                If listColumn(i) IsNot Nothing AndAlso Not dtExcel.Columns.Contains(listColumn(i)) Then
                    isNotFound = True
                    Throw New Exception("Column (" & listColumn(i) & ") tidak ditemukan, Pilih template yang sesuai!")
                End If
            Next
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
        Return isNotFound
    End Function

    Public Sub CreateTable()
        dtResult = New DataTable
        dtResult.Columns.AddRange(New DataColumn(5) {New DataColumn("No", GetType(Integer)),
                                                        New DataColumn("PartNo", GetType(String)),
                                                        New DataColumn("InventoryID", GetType(String)),
                                                        New DataColumn("Desc", GetType(String)),
                                                        New DataColumn("Status", GetType(String)),
                                                        New DataColumn("Message", GetType(String))})

        dtUploadTemp = New DataTable
        dtUploadTemp.Columns.AddRange(New DataColumn(6) {New DataColumn("No", GetType(Integer)),
                                                        New DataColumn("AlternateID", GetType(String)),
                                                        New DataColumn("InventoryID", GetType(String)),
                                                        New DataColumn("Desc", GetType(String)),
                                                        New DataColumn("OldPrice", GetType(Double)),
                                                        New DataColumn("NewPrice", GetType(Double)),
                                                        New DataColumn("EffectiveDate", GetType(Date))})
    End Sub

    Private Sub txtTemplate_EditValueChanged(sender As Object, e As EventArgs) Handles txtTemplate.EditValueChanged
        cls_UploadPrice = New ClsMktUploadPrice
        dtColumn = New DataTable
        dtColumn = cls_UploadPrice.GetColumnExcel(txtTemplate.EditValue)
        txtFileName.Text = ""

        For Each _rows As DataRow In dtColumn.Rows
            clmPartNoExcel = Replace(Replace(Replace(_rows("PartNo").ToString, ".", "#"), "[", "("), "]", ")")
            clmPriceExcel = Replace(Replace(Replace(_rows("Price").ToString, ".", "#"), "[", "("), "]", ")")
            clmDateExcel = Replace(Replace(Replace(_rows("StartDate").ToString, ".", "#"), "[", "("), "]", ")")
            clmDescExcel = Replace(Replace(Replace(_rows("Desc").ToString, ".", "#"), "[", "("), "]", ")")
        Next
        listColumn = New List(Of String)({clmPartNoExcel, clmDescExcel, clmPriceExcel, clmDateExcel})

        dtResult.Clear()
        GridResult.DataSource = dtResult
        GridViewResult.Columns("PartNo").Caption = clmPartNoExcel
        GridViewResult.Columns("Desc").Caption = clmDescExcel
        GridViewResult.BestFitColumns()
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
            If btnExport.Text = "Save To Excel" Then
                Dim path As String = "Result.xlsx"

                CType(GridResult.MainView, GridView).OptionsPrint.PrintHeader = True
                Dim advOptions As XlsxExportOptionsEx = New XlsxExportOptionsEx()
                advOptions.AllowGrouping = DevExpress.Utils.DefaultBoolean.False
                advOptions.ShowTotalSummaries = DevExpress.Utils.DefaultBoolean.False
                advOptions.SheetName = "Result Upload"

                GridResult.ExportToXlsx(path, advOptions)
                Process.Start(path)
            Else
                If MsgBox("Are You Sure Upload Data", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                    dtUpload = dtUploadTemp
                    isUpload = True
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub txtCustomer_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles txtCustomer.ButtonClick
        Dim ls_Judul As String = ""
        Dim dtSearch As New DataTable

        dtSearch = cls_UploadPrice.GetDataCustomer
        ls_Judul = "CUSTOMER"

        Dim lF_SearchData As FrmSystem_LookupGrid
        lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
        lF_SearchData.HiddenCols = 0
        lF_SearchData.Text = "Select Data " & ls_Judul
        lF_SearchData.StartPosition = FormStartPosition.CenterScreen
        lF_SearchData.ShowDialog()

        If lF_SearchData.Values IsNot Nothing Then
            custID = lF_SearchData.Values.Item(0).ToString.Trim
            txtCustomer.Text = lF_SearchData.Values.Item(1).ToString.Trim
        End If
        lF_SearchData.Close()
    End Sub

End Class