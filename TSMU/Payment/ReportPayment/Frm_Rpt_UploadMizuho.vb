Imports System.Globalization
Imports System.Windows.Forms.ImageList
Imports DevExpress.LookAndFeel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraReports.UI
Public Class Frm_Rpt_UploadMizuho

    Dim pay_class As New Cls_report
    Dim pay_Config As DataTable = Nothing
    Private Sub Frm_Rpt_UploadMizuho_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call baseForm.Proc_EnableButtons(False, False, False, True, True, False, False, False)
        Init()
        ProgBar.Visible = False
        ''_totalchk.Text = totalsupllier()
    End Sub

    Private Sub totalsupllier()
        Try
            Dim tgl1 As String
            Dim tgl2 As String
            Dim query As String
            tgl1 = DateEdit1.Text
            tgl2 = DateEdit2.Text
            query = "SELECT COUNT(*) FROM payment_header1 where tgl>='" & tgl1 & "' and tgl>='" & tgl2 & "' "
            MainModul.ExecQueryByCommandSolomon(query)
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Private Sub Init()
        GridControl3.DataSource = Nothing
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

    Private Sub tsBtn_excel_Click(sender As Object, e As EventArgs) Handles tsBtn_excel.Click
        Proc_Excel()
    End Sub

    Private Sub SaveToExcel(_Grid As GridControl)
        Dim save As New SaveFileDialog
        save.Filter = "CSV File|*.csv"
        save.Title = "Save a CSV File"
        If save.ShowDialog = DialogResult.OK Then
            _Grid.ExportToCsv(save.FileName)
        End If
    End Sub
    Private Sub Proc_Excel()
        Try
            If TabControl1.SelectedTab Is TabPage1 Then
                If GridView4.RowCount > 0 Then
                    SaveToExcel(GridControl3)
                    MsgBox("Data Berhasil di Export!")
                Else
                    MsgBox("Grid Kosong!")
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Async Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Try
            If ProgBar.Visible = True Then
                Throw New Exception("Process already running, Please wait!")
            End If
            ProgBar.Visible = True
            ProgBar.Style = ProgressBarStyle.Marquee
            Await Task.Run(Sub() GetDataGridReportUploadtoSolomon())
        Catch ex As Exception
            ProgBar.Visible = False
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    'Private Async Sub reportuploadtomizuho()
    '    Try
    '        If ProgBar.Visible = True Then
    '            Throw New Exception("Process already running, Please wait!")
    '        End If
    '        ProgBar.Visible = True
    '        ProgBar.Style = ProgressBarStyle.Marquee
    '        Await Task.Run(Sub() ReportMizuho())
    '    Catch ex As Exception
    '        ProgBar.Visible = False
    '        MsgBox(ex.Message)
    '        WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
    '    End Try
    'End Sub

    Private Sub GetDataGridREportUploadToSolomon()
        Dim date1 As String = ""
        Dim date2 As String = ""
        'Dim date1 As DateTime
        'Dim date2 As DateTime
        Invoke(Sub()
                   date1 = DateEdit1.Text
                   date2 = DateEdit2.Text
               End Sub)
        Dim dt As New DataTable
        dt = pay_class.DataGridViewUploadMizuho(date1, date2)
        setDataSource(dt, GridControl3)
        Invoke(Sub()
                   ProgBar.Visible = False
               End Sub)
    End Sub

    'Private Sub ReportMizuho()
    '    Dim date1 As String = ""
    '    Dim date2 As String = ""
    '    'Dim date1 As DateTime
    '    'Dim date2 As DateTime
    '    Invoke(Sub()
    '               date1 = DateEdit1.Text
    '               date2 = DateEdit2.Text
    '           End Sub)
    '    Dim dt As New DataTable
    '    dt = pay_class.DataGridViewUploadMizuho(date1, date2)
    '    dt = ds.Tables("PrintPO")
    '    setDataSource(dt, "XtraReport1")
    '    Invoke(Sub()
    '               ProgBar.Visible = False
    '           End Sub)
    'End Sub

    Friend Delegate Sub SetDataSourceDelegate(table As DataTable, _Grid As GridControl)
    Private Sub setDataSource(table As DataTable, _Grid As GridControl)
        ' Invoke method if required:
        If Me.InvokeRequired Then
            Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table, _Grid)
        Else
            _Grid.DataSource = table
        End If
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub tsBtn_preview_Click(sender As Object, e As EventArgs) Handles tsBtn_preview.Click
        Proc_PrintPreview()
    End Sub


    Private Sub Proc_PrintPreview()


        Try
            If TabControl1.TabIndex = 1 Then
                If GridView4.RowCount = 0 Then
                    Throw New Exception("Tidak ada data yang di akan print.")
                End If
            Else
                'Else
                'Dim IsNoTranEmpty As Boolean = False
                'Dim ValidateNotran As Boolean = True
                'For i As Integer = 0 To GridView4.RowCount - 1
                '    IsNoTranEmpty = pay_class.CheckNoTran(GridView4.GetRowCellValue(i, GridView4.Columns("No Surat Jalan")))
                '    If IsNoTranEmpty Then
                '        ValidateNotran = False
                '        Exit For
                '    End If
                'Next

                'For i As Integer = 0 To GridView4.RowCount - 1
                '    SuratJalan.ShipperID = GridView2.GetRowCellValue(i, GridView2.Columns("No Surat Jalan"))
                '    SuratJalan.UpdateNoTran()
                'Next

                Dim ds As DataSet = New DataSet
                Dim dt As DataTable = New DataTable
                Dim date1 As String = ""
                Dim date2 As String = ""
                Invoke(Sub()
                           date1 = DateEdit1.Text
                           date2 = DateEdit2.Text
                       End Sub)

                '' ds = pay_class.DXReportUploadToMizuho(IIf(DateEdit1.Text >='" & uploaded & "', "ALL", _BtnCust.Text))


                'For i As Integer = 0 To GridView4.RowCount - 1
                '    pay_class.DXReportUploadToMizuho()
                'Next

                ds = pay_class.Mizuho(Format(DateEdit1.EditValue, gs_FormatSQLDate), Format(DateEdit2.EditValue, gs_FormatSQLDate))
                dt = ds.Tables("mizuho")

                Dim Laporan As XtraReport4 = New XtraReport4
                With Laporan
                    ''.param1 = date1
                    ''.param2 = date2
                    .DataSource = dt
                End With

                Using PrintTool As ReportPrintTool = New ReportPrintTool(Laporan)
                    PrintTool.ShowPreviewDialog()
                    PrintTool.ShowPreview(UserLookAndFeel.Default)
                End Using

            End If
            LoadData()
            ''reportuploadtomizuho()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub LoadData()
        Try
            If DateEdit1.Text = "" OrElse DateEdit2.Text = "" Then
                If DateEdit1.Text = "" Then
                    DateEdit1.Focus()
                ElseIf DateEdit2.Text = "" Then
                    DateEdit2.Focus()
                End If
                Throw New Exception("Silahkan pilih tanggal !")
            End If

            Cursor = Cursors.WaitCursor
            Dim dt As New DataTable
            'dt = SuratJalan.GetdataGridEdit(IIf(_txtCust.Text = "", "ALL", _txtCust.Text), _dtTgl1.Value.ToString("MM-dd-yyyy"), _dtTgl2.Value.ToString("MM-dd-yyyy"), Site2)
            ''dt = pay_class.DataGridViewUploadMizuho(IIf(Format(DateEdit1.EditValue, gs_FormatSQLDate), Format(DateEdit2.EditValue, gs_FormatSQLDate)))
            GridControl3.DataSource = dt
            'btnFilter.Enabled = True
            Cursor = Cursors.Default
            '_Grid.Columns(2).ValueType = calenderCol
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    'Sub GetExcelSheetNames(ByVal FileName As String)
    '    Dim sConn As String
    '    sConn = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" &
    '            FileName & ";Extended Properties=""Excel 12.0 Xml;HDR=YES"";"

    '    Dim conn As New OleDbConnection(sConn)

    '    conn.Open()

    '    Dim dtSheets As DataTable =
    '    conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)
    '    Dim drSheet As DataRow

    '    ListBox1.Items.Clear()
    '    For Each drSheet In dtSheets.Rows
    '        ListBox1.Items.Add(drSheet("TABLE_NAME").ToString())
    '    Next

    '    LoadExcel2Grid(FileName, ListBox1.Items(0).ToString)

    '    conn.Close()

    'End Sub

    Private Sub _btnBrowse_Click(sender As Object, e As EventArgs) Handles _btnBrowse.Click
        'With OpenFileDialog1
        '    .FileName = String.Empty
        '    .InitialDirectory = "C:\"
        '    .Title = "Open Excel File"
        '    .Filter = "Excel 97-2003|*.xls|Excel 2007|*.xlsx"
        'End With
        'Dim result As DialogResult = OpenFileDialog1.ShowDialog()
        'If result = Windows.Forms.DialogResult.OK Then
        '    Try
        '        TextBox1.Text = OpenFileDialog1.FileName
        '        GetExcelSheetNames(TextBox1.Text)
        '    Catch ex As Exception
        '        MsgBox("Error : " & ex.Message)
        '    End Try
        'End If

        Using fold As New OpenFileDialog
            fold.Filter = "document files (*.xls)|*.xlsx|richtextformat files (*.rtf)|*.rtf|All files (*.*)|*.*"
            fold.Title = "Select file"
            If fold.ShowDialog() = Windows.Forms.DialogResult.OK Then
                'fold.FilterIndex = 2
                fold.RestoreDirectory = True
                MessageBox.Show("You selected " & fold.FileName)
                TextBox1.Text = fold.FileName
            End If
            'Dim result As DialogResult
            'If result = Windows.Forms.DialogResult.OK Then
            '    Try

            '        ''GetExcelSheetNames(TextBox1.Text)
            '    Catch ex As Exception
            '        MsgBox("Error : " & ex.Message)
            '    End Try
            ''End If

        End Using

    End Sub

End Class