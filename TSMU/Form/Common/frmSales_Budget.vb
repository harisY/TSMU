Imports DevExpress.XtraSplashScreen

Public Class frmSales_Budget
    Dim ff_Detail As frmSales_Budget_detail
    Dim dtGrid As DataTable
    Dim fc_Class As New clsSales_Budget
    Dim ObjBudget As New BudgetModel
    Dim ObjBudget1 As New BudgetModel
    Dim Service As BudgetSerivce
    Private Sub frmSales_Budget_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        'Dim dtGrid As New DataTable
        'dtGrid = Grid.DataSource
        'FilterData = New FrmSystem_FilterData(dtGrid)
        Call Proc_EnableButtons(False, False, True, True, True, False, False, False, False, False, False, False)
    End Sub
    Private Sub LoadGrid()
        Try
            Service = New BudgetSerivce
            Grid.DataSource = Service.GetAll()
            With GridView1
                .BestFitColumns()
                .Columns(0).Visible = False
                .FixedLineWidth = 2
                .Columns(1).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                .Columns(2).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                .Columns(3).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                .Columns(4).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                GridCellFormat(GridView1)
            End With
            'If Grid.Rows.Count > 0 Then
            '    Call Proc_EnableButtons(False, False, False, True, True, True, False, False)
            'Else
            '    Call Proc_EnableButtons(False, False, False, True, True, True, False, False)
            'End If
            'Grid.AutoSize = True
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Public Overrides Sub Proc_InputNewData()
        'CallFrm()
    End Sub
    Public Overrides Sub Proc_Refresh()
        bs_Filter = ""
        Call LoadGrid()
    End Sub
    Public Overrides Sub Proc_Excel()
        Dim table As New DataTable
        Dim ls_Judul As String = "Budget"
        Dim strTtahun As String = ""
        Dim strCustomer As String = ""
        Dim frmExcel As FrmSystemExcel
        frmExcel = New FrmSystemExcel(table, 34)
        frmExcel.Text = "Upload " & ls_Judul
        frmExcel.StartPosition = FormStartPosition.CenterScreen
        frmExcel.ShowDialog()

        strTtahun = frmExcel.Tahun
        Try
            'Cursor = Cursors.WaitCursor
            Dim dv As DataView = New DataView(table)
            Dim dtFilter As New DataTable

            If strTtahun <> "" Then
                dv.RowFilter = "tahun = '" & strTtahun & "'"
                dtFilter = dv.ToTable
            Else
                dtFilter = dv.ToTable
            End If
            If dtFilter.Rows.Count > 0 Then
                'fc_Class.DeleteByTahun()
                SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
                ObjBudget1.ObjCollection.Clear()
                For Each row As DataRow In dtFilter.Rows
                    Try
                        ObjBudget = New BudgetModel
                        With ObjBudget

                            .Tahun = If(row("Tahun") Is DBNull.Value, "", row("Tahun").ToString())
                            .Bulan = If(row("Bulan") Is DBNull.Value, "", row("Bulan").ToString())
                            .CustId = If(row("Customer ID") Is DBNull.Value, "", row("Customer ID").ToString())
                            .Customer = If(row("Customer") Is DBNull.Value, "", row("Customer").ToString())
                            .InventoryId = If(row("Inventory ID") Is DBNull.Value, "", row("Inventory ID").ToString())
                            .Description = If(row("Description") Is DBNull.Value, "", row("Description").ToString())
                            .PartNo = If(row("Part No") Is DBNull.Value, "", row("Part No").ToString())
                            .Model = If(row("Model") Is DBNull.Value, "", row("Model").ToString())
                            .OE = If(row("OE/RE") Is DBNull.Value, "", row("OE/RE").ToString())
                            .INSub = If(row("IN/SUB") Is DBNull.Value, "", row("IN/SUB").ToString())
                            .Site = If(row("Site") Is DBNull.Value, "", row("Site").ToString())
                            .Qty = If(row("Qty") Is DBNull.Value, "0", Convert.ToInt32(row("Qty")))
                            .Price = If(row("Price") Is DBNull.Value, "0", Convert.ToDecimal(row("Price")))
                        End With
                        ObjBudget1.ObjCollection.Add(ObjBudget)

                    Catch ex As Exception
                        WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                        WriteSalesToErrorLog("Budget", "Log", dtFilter, 0, "Inventory ID", gh_Common.Username)
                        Continue For
                    End Try
                Next
                Service.Insert(ObjBudget1)
                LoadGrid()
                SplashScreenManager.CloseForm()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                'Cursor = Cursors.Default
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            SplashScreenManager.CloseForm()
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub
    Public Overrides Sub Proc_Filter()
        FilterData.Text = "Filter Data Budget"
        FilterData.ShowDialog()
        If Not FilterData.isCancel Then
            bs_Filter = FilterData.strWhereClauseWithoutWhere
            Call FilterGrid()
        End If
        FilterData.Hide()
    End Sub

    Private Sub FilterGrid()
        Try
            'Grid.all = False
            'Grid.AllowSorting = AllowSortingEnum.SingleColumn
            Dim dv As New DataView(dtGrid)
            dv.RowFilter = bs_Filter
            dtGrid = dv.ToTable
            Grid.DataSource = dtGrid
            'If Grid.Rows.Count > 0 Then
            '    Call Proc_EnableButtons(False, False, False, True, True, True, False, False)
            'Else
            '    Call Proc_EnableButtons(False, False, False, True, True, True, False, False)
            'End If
            'Grid.AutoSize = True
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        ff_Detail = New frmSales_Budget_detail(ls_Code, ls_Code2, Me, li_Row, Grid)
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    Public Overrides Sub Proc_DeleteData()
        Dim ID As Integer = 0
        Try
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    ID = GridView1.GetRowCellValue(rowHandle, "id")
                End If
            Next rowHandle
            fc_Class.ID = ID
            fc_Class.Delete()
            Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)
            tsBtn_refresh.PerformClick()
            'Grid.RemoveItem(Grid.Row)
            'If Grid.Rows.Count > Grid.Rows.Fixed Then
            '    Call Proc_EnableButtons(True, False, True, True, True, True, False, False)
            'Else
            '    Call Proc_EnableButtons(True, False, False, True, True, True, False, False)
            'End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub frmSales_Budget_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Dim invtID = String.Empty
        Dim ID As Integer = 0
        Try
            If e.KeyCode = Keys.F1 Then
                Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        invtID = GridView1.GetRowCellValue(rowHandle, "Inventory ID")
                        ID = GridView1.GetRowCellValue(rowHandle, "id")
                    End If
                Next rowHandle

                'If GridView1.GetSelectedRows.Length > 0 Then
                '    'Dim objGrid As DataGridView = sender
                '    Call CallFrm(ID,
                '             invtID,
                '             GridView1.RowCount)
                'End If
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick
        Dim invtID = String.Empty
        Dim ID As Integer = 0
        Try
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    invtID = GridView1.GetRowCellValue(rowHandle, "Inventory ID")
                    ID = GridView1.GetRowCellValue(rowHandle, "id")
                End If
            Next rowHandle

            'If GridView1.GetSelectedRows.Length > 0 Then
            '    'Dim objGrid As DataGridView = sender
            '    Call CallFrm(ID,
            '             invtID,
            '             GridView1.RowCount)
            'End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        Try
            If GridView1.RowCount > 0 Then
                SaveToExcel(Grid,, "Budget", False)
            Else
                MsgBox("Grid Kosong !")
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
End Class
