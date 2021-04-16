Imports Excel = Microsoft.Office.Interop.Excel
Imports ExcelLibrary
Imports DevExpress.XtraGrid
Public Class Frm_Rpt_TarikSoA
    Dim pay_class As New Cls_report
    Dim pay_Config As DataTable = Nothing
    Private Sub Frm_Rpt_TarikSoA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call baseForm.Proc_EnableButtons(False, False, False, True, False, True, False, False)
        Init()
        ProgBar.Visible = False
        ''Progbar_sup.Visible = False
        ''Progbar_sup2.Visible = False
        ''txtperpost.EditValue = Format(DateTime.Today, "yyyy-MM")
    End Sub

    Sub LoadTxtBox()
        If TabControl1.SelectedTab Is TabPage1 Then
            If ProgBar.Visible = True Then
                MsgBox("Proses Loading Data masih berjalan!")
                Exit Sub
            End If
            'ElseIf TabControl1.SelectedTab Is TabPage3 Then
            '    If Progbar_sup.Visible = True Then
            '        MsgBox("Proses Loading Data masih berjalan!")
            '        Exit Sub
            '    End If
        End If
    End Sub

    Private Sub Proc_Refresh()
        Try
            Call LoadTxtBox()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub Proc_Excel()
        Try
            If TabControl1.SelectedTab Is TabPage1 Then
                If GridView4.RowCount > 0 Then
                    SaveToExcel(GridControl3)
                    MsgBox("Data Sudah Berhasil Di Export.")
                Else
                    MsgBox("Grid Kosong!")
                End If

                'ElseIf TabControl1.SelectedTab Is TabPage3 Then
                '    If GridView2.RowCount > 0 Then
                '        SaveToExcel(GridControl1)
                '        MsgBox("Data Sudah Berhasil Di Export.")
                '    Else
                '        MsgBox("Grid Kosong!")
                '    End If
                'ElseIf TabControl1.SelectedTab Is TabPage2 Then
                '    If GridView7.RowCount > 0 Then
                '        SaveToExcel(GridControl4)
                '        MsgBox("Data Sudah Berhasil Di Export.")
                '    Else
                '        MsgBox("Grid Kosong!")
                '    End If
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    'Private Sub Proc_PrintPreview()
    '    Try
    '        If TabControl1.TabIndex = 1 Then
    '            If GridView4.RowCount = 0 Then
    '                Throw New Exception("Tidak ada data yang di akan print.")
    '            End If

    '        Else
    '            Dim ds As DataSet = New DataSet
    '            Dim dt As DataTable = New DataTable
    '            Dim perpost As String = ""
    '            Invoke(Sub()
    '                       perpost = txt_perpost.Text
    '                   End Sub)

    '            ds = pay_class.Mizuho(Format(DateEdit1.EditValue, gs_FormatSQLDate), Format(DateEdit2.EditValue, gs_FormatSQLDate))
    '            dt = ds.Tables("mizuho")

    '            Dim Laporan As XtraReport4 = New XtraReport4
    '            With Laporan
    '                ''.param1 = date1
    '                ''.param2 = date2
    '                .DataSource = dt
    '            End With

    '            Using PrintTool As ReportPrintTool = New ReportPrintTool(Laporan)
    '                PrintTool.ShowPreviewDialog()
    '                PrintTool.ShowPreview(UserLookAndFeel.Default)
    '            End Using

    '        End If
    '        LoadData()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub


    Dim path As String
    Private Sub getPath()
        Try
            Dim folderBrowser As New FolderBrowserDialog
            folderBrowser.RootFolder = Environment.SpecialFolder.MyComputer
            If (folderBrowser.ShowDialog() = DialogResult.OK) Then
                path = folderBrowser.SelectedPath
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub SetGridViewSortState(ByVal dgv As DataGridView, ByVal sortMode As DataGridViewColumnSortMode)
        For Each col As DataGridViewColumn In dgv.Columns
            col.SortMode = sortMode
        Next
    End Sub

    'Private Sub cmbsupplier()
    '    Try
    '        Dim dtgrid As DataTable = New DataTable
    '        dtgrid = pay_class.cmbsupplier()
    '        cmb_supplier.DataSource = dtgrid
    '        cmb_supplier.ValueMember = "Name 
    '        cmb_supplier.DisplayMember = "Name"
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub Init()
        GridControl3.DataSource = Nothing
        'GridControl1.DataSource = Nothing
    End Sub

    Private Sub GetDataGrid()

        Dim dateprocess As DateTime
        Dim dateperpost As String = ""
        Dim dateupdate1 As DateTime
        Dim dateupdate2 As DateTime
        Dim dateupdate3 As DateTime
        Invoke(Sub()
                   dateprocess = DateEdit1.Text
                   dateupdate1 = DateEdit1.Text
                   dateperpost = txt_perpost.Text
                   dateupdate2 = DateEdit1.Text
                   dateupdate3 = DateEdit1.Text

               End Sub)
        Dim dt As New DataTable
        dt = pay_class.DataGridViewTarikSoA(dateprocess, dateperpost, dateupdate1, dateupdate2, dateupdate3)
        setDataSource(dt, GridControl3)
        Invoke(Sub()
                   ProgBar.Visible = False
               End Sub)
    End Sub



    'Private Sub GetDataGridSup()
    '    Dim datesup1 As String = ""
    '    Dim datesup2 As String = ""
    '    Dim suppliername As String = ""

    '    Invoke(Sub()
    '               datesup1 = DateEdit1.Text
    '               datesup2 = DateEdit2.Text
    '               suppliername = cmb_supplier.Text
    '           End Sub)
    '    Dim dt As New DataTable
    '    dt = pay_class.DataGridViewPaymentSup(datesup1, datesup2, suppliername)
    '    setDataSource(dt, GridControl1)
    '    Invoke(Sub()
    '               Progbar_sup.Visible = False
    '           End Sub)
    'End Sub

    Private Sub GetDataGridSup2()
        Dim perpost As String = ""

        Dim suppliername As String = ""

        Invoke(Sub()
                   perpost = txtperpost.Text
                   suppliername = cmb_supplier2.Text
               End Sub)
        Dim dt As New DataTable
        dt = pay_class.DataGridViewPaymentSup2(perpost, suppliername)
        setDataSource(dt, GridControl4)
        Invoke(Sub()
                   Progbar_sup2.Visible = False
               End Sub)
    End Sub
    Private Sub GetDataGridSup3()
        Dim perpost As String = ""

        Dim suppliername As String = ""

        Invoke(Sub()
                   perpost = txtperpost.Text
                   suppliername = cmb_supplier2.Text
               End Sub)
        Dim dt As New DataTable
        dt = pay_class.DataGridViewPaymentSup3(perpost, suppliername)
        setDataSource(dt, GridControl5)
        Invoke(Sub()
                   Progbar_sup2.Visible = False
               End Sub)
    End Sub
    Friend Delegate Sub SetDataSourceDelegate(table As DataTable, _Grid As GridControl)
    Private Sub setDataSource(table As DataTable, _Grid As GridControl)
        ' Invoke method if required:
        If Me.InvokeRequired Then
            Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table, _Grid)
        Else
            _Grid.DataSource = table
        End If
    End Sub

    Private Sub SaveToExcel(_Grid As GridControl)
        Dim save As New SaveFileDialog
        save.Filter = "Excel File|*.xls"
        save.Title = "Save an Excel File"
        If save.ShowDialog = DialogResult.OK Then
            _Grid.ExportToXls(save.FileName)
        End If
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

    Private Async Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Try
            'If ProgBar.Visible = True Then
            '    Throw New Exception("Process already running, Please wait !")
            'End If
            ProgBar.Visible = True
            ProgBar.Style = ProgressBarStyle.Marquee
            Await Task.Run(Sub() GetDataGrid())
        Catch ex As Exception
            ProgBar.Visible = False
            MsgBox("Data Telah Berhasil Ditarik, Silahkan Download Data Di Solomon")
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    'Private Async Sub btnLoad_sup_Click(sender As Object, e As EventArgs)
    '    Try
    '        If Progbar_sup.Visible = True Then
    '            Throw New Exception("Process already running, Please wait !")
    '        End If
    '        Progbar_sup.Visible = True
    '        Progbar_sup.Style = ProgressBarStyle.Marquee
    '        Await Task.Run(Sub() GetDataGridSup())
    '    Catch ex As Exception
    '        Progbar_sup.Visible = False
    '        MsgBox(ex.Message)
    '        WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
    '    End Try

    'End Sub

    'Private Sub cmb_supplier_DropDown(sender As Object, e As EventArgs)
    '    Try
    '        Dim dtgrid As DataTable = New DataTable
    '        dtgrid = pay_class.cmbsupplier()
    '        cmb_supplier.DataSource = dtgrid
    '        cmb_supplier.ValueMember = "Name"
    '        cmb_supplier.DisplayMember = "Name"
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub

    Private Sub tsBtn_excel_Click(sender As Object, e As EventArgs) Handles tsBtn_excel.Click
        Proc_Excel()
        ''proc_PrintPreview()
    End Sub

    Private Async Sub btnLoad_sup2_Click(sender As Object, e As EventArgs)
        Try
            If Progbar_sup2.Visible = True Then
                Throw New Exception("Process already running, Please wait !")
            End If
            Progbar_sup2.Visible = True
            Progbar_sup2.Style = ProgressBarStyle.Marquee
            Await Task.Run(Sub() GetDataGridSup2())
            Await Task.Run(Sub() GetDataGridSup3())
            ' GridView7.Columns(0).Visible = False
            GridCellFormat(GridView7)

        Catch ex As Exception
            Progbar_sup2.Visible = False
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub cmb_supplier2_DropDown(sender As Object, e As EventArgs)
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = pay_class.cmbsupplier()
            cmb_supplier2.DataSource = dtgrid
            cmb_supplier2.ValueMember = "Name"
            cmb_supplier2.DisplayMember = "Name"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    'Private Sub tsBtn_preview_Click(sender As Object, e As EventArgs) Handles tsBtn_preview.Click
    '    'Try
    '    '    Dim newform As New Frm_Rpt_APPaySolomon(txt_perpost.Text)
    '    '    newform.StartPosition = FormStartPosition.CenterScreen
    '    '    newform.Show()
    '    'Catch ex As Exception
    '    '    MsgBox(ex.Message)
    '    'End Try

    '    Try
    '        Dim newform As New Frm_Rpt_APSignature(DateEdit3.Text, DateEdit4.Text)
    '        newform.StartPosition = FormStartPosition.CenterScreen
    '        newform.Show()
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try


    'End Sub

    Private Sub proc_PrintPreview()
        Try
            Dim newform As New Frm_Rpt_APPaySolomon(txt_perpost.Text)
            newform.StartPosition = FormStartPosition.CenterScreen
            newform.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            GetDataGrid()
        Catch ex As Exception
            MsgBox("Data Telah Berhasil Ditarik, Silahkan Download Data Di Solomon")
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    'Private Async Sub ToolStripButton1_Click(sender As Object, e As EventArgs)
    '    Try
    '        If ProgBar2.Visible = True Then
    '            Throw New Exception("Process already running, Please wait !")
    '        End If
    '        ProgBar2.Visible = True
    '        ProgBar2.Style = ProgressBarStyle.Marquee
    '        Await Task.Run(Sub() GetDataGridAPSign())
    '    Catch ex As Exception
    '        ProgBar2.Visible = False
    '        MsgBox(ex.Message)
    '        WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
    '    End Try
    'End Sub
End Class