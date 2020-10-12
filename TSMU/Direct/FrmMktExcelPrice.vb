Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO

Public Class FrmMktExcelPrice
    Dim cls_UploadPrice As New ClsMktUploadPrice
    Dim proses As String = String.Empty
    Dim path As String = String.Empty
    Dim dtExcel As New DataTable
    Dim dtTemplate As New DataTable
    Dim dtColumn As DataTable
    Dim a As Integer = 0

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Public Sub New(ByRef dt As DataTable, ByVal x As Integer)
        ' This call is required by the Windows Form Designer.
        Me.New()
        ' Add any initialization after the InitializeComponent() call.
        dtExcel = dt
        a = x
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
                'Dim sheet As String = String.Empty
                'sheet = QVal(Replace(sheet1, "'", "") + __rows)
                Using oda As New OleDbDataAdapter((Convert.ToString("SELECT * FROM [") & __rows) + "]", excel_con)
                    oda.Fill(dtExcel)
                End Using
                excel_con.Close()
            End Using
            SimulatePrice()
            'GridResult.DataSource = dtExcel
            'GridViewResult.BestFitColumns()
            'Me.Close()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub FrmMktExcelPrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListItemsTemplate()
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
        checkColumn()
    End Sub

    Private Sub UploadPrice()

    End Sub

    Private Sub checkColumn()
        Try
            Dim listColumn As New List(Of String)
            For Each clm As DataColumn In dtExcel.Columns
                listColumn.Add(Replace(Replace(Replace(clm.ColumnName.ToString(), "#", "."), "(", "["), ")", "]"))
            Next
            For Each row As DataRow In dtColumn.Rows
                If Not listColumn.Contains(row("ColumnInExcel")) Then
                    Throw New Exception("Column (" & row("ColumnInExcel") & ") tidak ditemukan, Pilih template yang sesuai!")
                End If
            Next
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try

    End Sub

    Private Sub txtTemplate_EditValueChanged(sender As Object, e As EventArgs) Handles txtTemplate.EditValueChanged
        cls_UploadPrice = New ClsMktUploadPrice
        dtColumn = New DataTable
        dtColumn = cls_UploadPrice.GetMappingColumn(txtTemplate.EditValue)
        txtFileName.Text = ""
    End Sub

End Class