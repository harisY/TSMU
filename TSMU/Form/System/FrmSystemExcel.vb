Imports System.Data.OleDb
Imports System.Data.SqlClient
Imports System.Configuration
Imports System.IO
Public Class FrmSystemExcel
    Dim fc_class As New clsSales_Budget
    Dim GridData As DataTable = Nothing
    Dim Gridfilter As DataTable = Nothing
    Dim a As Integer = 0
    Dim b As Integer = 0
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByRef dt As DataTable, ByVal x As Integer)
        ' This call is required by the Windows Form Designer.
        Me.New()
        ' Add any initialization after the InitializeComponent() call.
        GridData = dt
        a = x
    End Sub
    ReadOnly Property Tahun As String
        Get
            Return _cmbTahun.Text.Trim
        End Get
    End Property
    ReadOnly Property Customer As String
        Get
            Return _cmbCust.Text.Trim
        End Get
    End Property
    Private Sub FrmSystemExcel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        FillComboTahun()
        FillComboCustomer()
        lblStatus.Text = ""
    End Sub
    Private Sub FillComboTahun()
        Dim tahun() As String = {"", DateTime.Today.Year.ToString, (DateTime.Today.Year - 1).ToString, (DateTime.Today.Year - 2).ToString}
        _cmbTahun.Items.Clear()
        For Each var As String In tahun
            _cmbTahun.Items.Add(var)
        Next
    End Sub

    Private Sub FillComboCustomer()
        Dim dtTabel As New DataTable
        dtTabel = fc_class.getCusstID_Solomon
        Dim dr As DataRow = dtTabel.NewRow
        dr("CustId") = ""
        dtTabel.Rows.InsertAt(dr, 0)
        _cmbCust.Items.Clear()
        For i As Integer = 0 To dtTabel.Rows.Count - 1
            _cmbCust.Items.Add(dtTabel.Rows(i)("CustId"))
        Next
    End Sub
    Dim path As String
    Private Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Try
            OpenFileDialog1.Filter = "Excel Files|*.xls;*.xlsx"
            Dim result As DialogResult = OpenFileDialog1.ShowDialog()
            ' Test result.
            If result = Windows.Forms.DialogResult.OK Then
                path = OpenFileDialog1.FileName
                'path = System.IO.Path.GetFileName(OpenFileDialog1.FileName)
                'MsgBox(path)
                Dim text As String = System.IO.File.ReadAllText(path)
                _txtExcel.Text = path
                'Me.Text = text.Length.ToString
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub _btnExport_Click(sender As Object, e As EventArgs) Handles _btnExport.Click
        Try
            If lblStatus.Text <> "" Then
                Throw New Exception("Proses masih berjalan !")
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
                Dim sheet1 As String = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing).Rows(0)("TABLE_NAME").ToString()
                Using oda As New OleDbDataAdapter((Convert.ToString("SELECT * FROM [") & sheet1) + "]", excel_con)
                    oda.Fill(GridData)
                End Using
                excel_con.Close()
            End Using

            'Dim xlApp As Microsoft.Office.Interop.Excel.Application
            'Dim xlWorkbook As Microsoft.Office.Interop.Excel.Workbook
            'Dim xlWorkSheet As Microsoft.Office.Interop.Excel.Worksheet
            'Dim xlRange As Microsoft.Office.Interop.Excel.Range

            'Dim xlCol As Integer
            'Dim xlRow As Integer

            'Dim Data(0 To a) As String

            'With GridData
            '    .Clear()
            '    If _txtExcel.Text <> "" Then
            '        xlApp = New Microsoft.Office.Interop.Excel.Application
            '        xlWorkbook = xlApp.Workbooks.Open(_txtExcel.Text)
            '        xlWorkSheet = xlWorkbook.ActiveSheet()
            '        xlRange = xlWorkSheet.UsedRange

            '        If xlRange.Columns.Count > 0 Then
            '            If xlRange.Rows.Count > 0 Then
            '                'Cursor = Cursors.WaitCursor
            '                lblStatus.Text = "Please wait...!"
            '                For xlRow = 2 To xlRange.Rows.Count 'here the xlRow is start from 2 coz in exvel sheet mostly 1st row is the header row
            '                    For xlCol = 1 To xlRange.Columns.Count
            '                        Data(xlCol - 1) = xlRange.Cells(xlRow, xlCol).text
            '                    Next
            '                    .LoadDataRow(Data, True)
            '                    Application.DoEvents()
            '                Next
            '                'Cursor = Cursors.Default
            '                lblStatus.Text = ""
            '                xlWorkbook.Close()
            '                xlApp.Quit()
            '                'KillExcelProcess()
            '                releaseObject(xlWorkSheet)
            '                releaseObject(xlWorkbook)
            '                releaseObject(xlApp)
            '            End If
            '        End If
            '    Else
            '        MessageBox.Show("Please Select Excel File", "Information", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            '    End If
            'End With
            Me.Close()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
            MessageBox.Show("Exception Occured while releasing object " + ex.ToString())
        Finally
            GC.Collect()
        End Try
    End Sub
End Class