Imports DevExpress.XtraSplashScreen

Public Class frmSales_Budget
    Dim ff_Detail As frmSales_Budget_detail
    Dim dtGrid As DataTable
    Dim fc_Class As New clsSales_Budget
    Private Sub frmSales_Budget_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Dim dtGrid As New DataTable
        dtGrid = Grid.DataSource
        FilterData = New FrmSystem_FilterData(dtGrid)
        Call Proc_EnableButtons(True, False, True, True, True, False, False, False)
    End Sub
    Private Sub LoadGrid()
        Try
            'Grid.ReadOnly = True
            'Grid.AllowSorting = AllowSortingEnum.SingleColumn
            dtGrid = fc_Class.GetAllDataGrid(bs_Filter)
            Grid.DataSource = dtGrid
            With GridView1
                .BestFitColumns()
                .Columns(0).Visible = False
                .FixedLineWidth = 2
                .Columns(1).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                .Columns(2).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                .Columns(3).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                .Columns(4).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
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
        CallFrm()
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

        'table.Columns.Add("tahun")
        'table.Columns.Add("custid")
        'table.Columns.Add("customer")
        'table.Columns.Add("invtid")
        'table.Columns.Add("descr")
        'table.Columns.Add("partno")
        'table.Columns.Add("model")
        'table.Columns.Add("oe_re")
        'table.Columns.Add("in_sub")
        'table.Columns.Add("site")
        'table.Columns.Add("jan_qty")
        'table.Columns.Add("feb_qty")
        'table.Columns.Add("mar_qty")
        'table.Columns.Add("apr_qty")
        'table.Columns.Add("mei_qty")
        'table.Columns.Add("jun_qty")
        'table.Columns.Add("jul_qty")
        'table.Columns.Add("agt_qty")
        'table.Columns.Add("sep_qty")
        'table.Columns.Add("okt_qty")
        'table.Columns.Add("nov_qty")
        'table.Columns.Add("des_qty")
        'table.Columns.Add("jan_harga")
        'table.Columns.Add("feb_harga")
        'table.Columns.Add("mar_harga")
        'table.Columns.Add("apr_harga")
        'table.Columns.Add("mei_harga")
        'table.Columns.Add("jun_harga")
        'table.Columns.Add("jul_harga")
        'table.Columns.Add("agt_harga")
        'table.Columns.Add("sep_harga")
        'table.Columns.Add("okt_harga")
        'table.Columns.Add("nov_harga")
        'table.Columns.Add("des_harga")
        'table.Columns.Add("revisi")

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
                fc_Class.DeleteByTahun()
                SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
                For i As Integer = 0 To dtFilter.Rows.Count - 1
                    Try
                        With fc_Class

                            If dtFilter.Rows(i)("tahun") Is DBNull.Value OrElse dtFilter.Rows(i)("tahun").ToString = "" Then
                                .Tahun = ""
                            Else
                                .Tahun = dtFilter.Rows(i)("tahun").ToString
                            End If
                            If dtFilter.Rows(i)("Customer ID") Is DBNull.Value OrElse dtFilter.Rows(i)("Customer ID").ToString = "" Then
                                .CustomerId = ""
                            Else
                                .CustomerId = dtFilter.Rows(i)("Customer ID").ToString
                            End If
                            If dtFilter.Rows(i)("Customer") Is DBNull.Value OrElse dtFilter.Rows(i)("Customer").ToString = "" Then
                                .Customer = ""
                            Else
                                .Customer = dtFilter.Rows(i)("Customer").ToString
                            End If
                            'If dtFilter.Rows(i)("customer") Is DBNull.Value OrElse dtFilter.Rows(i)("customer").ToString = "" Then
                            '    .Customer = ""
                            'Else
                            '    .Customer = dtFilter.Rows(i)("customer").ToString
                            'End If
                            If dtFilter.Rows(i)("Part No") Is DBNull.Value OrElse dtFilter.Rows(i)("Part No").ToString = "" Then
                                .PartNo = ""
                            Else
                                .PartNo = dtFilter.Rows(i)("Part No").ToString
                            End If
                            If dtFilter.Rows(i)("Inventory ID") Is DBNull.Value OrElse dtFilter.Rows(i)("Inventory ID").ToString = "" Then
                                .InvtId = ""
                            Else
                                .InvtId = dtFilter.Rows(i)("Inventory ID").ToString
                            End If
                            If dtFilter.Rows(i)("Description") Is DBNull.Value OrElse dtFilter.Rows(i)("Description").ToString = "" Then
                                .Descr = ""
                            Else
                                .Descr = dtFilter.Rows(i)("Description").ToString
                            End If
                            If dtFilter.Rows(i)("Model") Is DBNull.Value OrElse dtFilter.Rows(i)("Model").ToString = "" Then
                                .Model = ""
                            Else
                                .Model = dtFilter.Rows(i)("Model").ToString
                            End If
                            If dtFilter.Rows(i)("OE/RE") Is DBNull.Value OrElse dtFilter.Rows(i)("OE/RE").ToString = "" Then
                                .Oe_Re = ""
                            Else
                                .Oe_Re = dtFilter.Rows(i)("OE/RE").ToString
                            End If
                            If dtFilter.Rows(i)("IN/SUB") Is DBNull.Value OrElse dtFilter.Rows(i)("IN/SUB").ToString = "" Then
                                .In_Sub = ""
                            Else
                                .In_Sub = dtFilter.Rows(i)("IN/SUB").ToString
                            End If
                            If dtFilter.Rows(i)("Site") Is DBNull.Value OrElse dtFilter.Rows(i)("Site").ToString = "" Then
                                .Site = ""
                            Else
                                .Site = dtFilter.Rows(i)("Site").ToString

                            End If
                            '==================== Quantity ================================
                            If dtFilter.Rows(i)("Jan Qty") Is DBNull.Value OrElse dtFilter.Rows(i)("Jan Qty").ToString = "" Then
                                .Jan_Qty = 0
                            Else
                                .Jan_Qty = Single.Parse(dtFilter.Rows(i)("Jan Qty").ToString)
                            End If
                            If dtFilter.Rows(i)("Feb Qty") Is DBNull.Value OrElse dtFilter.Rows(i)("Feb Qty").ToString = "" Then
                                .Feb_Qty = 0
                            Else
                                .Feb_Qty = Single.Parse(dtFilter.Rows(i)("Feb Qty").ToString)
                            End If
                            If dtFilter.Rows(i)("Mar Qty") Is DBNull.Value OrElse dtFilter.Rows(i)("Mar Qty").ToString = "" Then
                                .Mar_Qty = 0
                            Else
                                .Mar_Qty = Single.Parse(dtFilter.Rows(i)("Mar Qty").ToString)
                            End If
                            If dtFilter.Rows(i)("Apr Qty") Is DBNull.Value OrElse dtFilter.Rows(i)("Apr Qty").ToString = "" Then
                                .April_Qty = 0
                            Else
                                .April_Qty = Single.Parse(dtFilter.Rows(i)("Apr Qty").ToString)
                            End If
                            If dtFilter.Rows(i)("Mei Qty") Is DBNull.Value OrElse dtFilter.Rows(i)("Mei Qty").ToString = "" Then
                                .Mei_Qty = 0
                            Else
                                .Mei_Qty = Single.Parse(dtFilter.Rows(i)("Mei Qty").ToString)
                            End If
                            If dtFilter.Rows(i)("Jun Qty") Is DBNull.Value OrElse dtFilter.Rows(i)("Jun Qty").ToString = "" Then
                                .Jun_Qty = 0
                            Else
                                .Jun_Qty = Single.Parse(dtFilter.Rows(i)("Jun Qty").ToString)
                            End If
                            If dtFilter.Rows(i)("Jul Qty") Is DBNull.Value OrElse dtFilter.Rows(i)("Jul Qty").ToString = "" Then
                                .Jul_Qty = 0
                            Else
                                .Jul_Qty = Single.Parse(dtFilter.Rows(i)("Jul Qty").ToString)
                            End If
                            If dtFilter.Rows(i)("Agt Qty") Is DBNull.Value OrElse dtFilter.Rows(i)("Agt Qty").ToString = "" Then
                                .Agt_Qty = 0
                            Else
                                .Agt_Qty = Single.Parse(dtFilter.Rows(i)("Agt Qty").ToString)
                            End If
                            If dtFilter.Rows(i)("Sep Qty") Is DBNull.Value OrElse dtFilter.Rows(i)("Sep Qty").ToString = "" Then
                                .Sep_Qty = 0
                            Else
                                .Sep_Qty = Single.Parse(dtFilter.Rows(i)("Sep Qty").ToString)
                            End If
                            If dtFilter.Rows(i)("Okt Qty") Is DBNull.Value OrElse dtFilter.Rows(i)("Okt Qty").ToString = "" Then
                                .Okt_Qty = 0
                            Else
                                .Okt_Qty = Single.Parse(dtFilter.Rows(i)("Okt Qty").ToString)
                            End If
                            If dtFilter.Rows(i)("Nov Qty") Is DBNull.Value OrElse dtFilter.Rows(i)("Nov Qty").ToString = "" Then
                                .Nov_Qty = 0
                            Else
                                .Nov_Qty = Single.Parse(dtFilter.Rows(i)("Nov Qty").ToString)
                            End If
                            If dtFilter.Rows(i)("Des Qty") Is DBNull.Value OrElse dtFilter.Rows(i)("Des Qty").ToString = "" Then
                                .Des_Qty = 0
                            Else
                                .Des_Qty = Single.Parse(dtFilter.Rows(i)("Des Qty").ToString)
                            End If
                            '==================== HARGA ================================
                            If dtFilter.Rows(i)("Jan Price") Is DBNull.Value OrElse dtFilter.Rows(i)("Jan Price").ToString = "" Then
                                .Jan_Harga = 0
                            Else
                                .Jan_Harga = Single.Parse(dtFilter.Rows(i)("Jan Price").ToString)
                            End If
                            If dtFilter.Rows(i)("Feb Price") Is DBNull.Value OrElse dtFilter.Rows(i)("Feb Price").ToString = "" Then
                                .Feb_Harga = 0
                            Else
                                .Feb_Harga = Single.Parse(dtFilter.Rows(i)("Feb Price").ToString)
                            End If
                            If dtFilter.Rows(i)("Mar Price") Is DBNull.Value OrElse dtFilter.Rows(i)("Mar Price").ToString = "" Then
                                .Mar_Harga = 0
                            Else
                                .Mar_Harga = Single.Parse(dtFilter.Rows(i)("Mar Price").ToString)
                            End If
                            If dtFilter.Rows(i)("Apr Price") Is DBNull.Value OrElse dtFilter.Rows(i)("Apr Price").ToString = "" Then
                                .Apr_Harga = 0
                            Else
                                .Apr_Harga = Single.Parse(dtFilter.Rows(i)("Apr Price").ToString)
                            End If
                            If dtFilter.Rows(i)("Mei Price") Is DBNull.Value OrElse dtFilter.Rows(i)("Mei Price").ToString = "" Then
                                .Mei_Harga = 0
                            Else
                                .Mei_Harga = Single.Parse(dtFilter.Rows(i)("Mei Price").ToString)
                            End If
                            If dtFilter.Rows(i)("Jun Price") Is DBNull.Value OrElse dtFilter.Rows(i)("Jun Price").ToString = "" Then
                                .Jun_Harga = 0
                            Else
                                .Jun_Harga = Single.Parse(dtFilter.Rows(i)("Jun Price").ToString)
                            End If
                            If dtFilter.Rows(i)("Jul Price") Is DBNull.Value OrElse dtFilter.Rows(i)("Jul Price").ToString = "" Then
                                .Jul_Harga = 0
                            Else
                                .Jul_Harga = Single.Parse(dtFilter.Rows(i)("Jul Price").ToString)
                            End If
                            If dtFilter.Rows(i)("Agt Price") Is DBNull.Value OrElse dtFilter.Rows(i)("Agt Price").ToString = "" Then
                                .Agt_Harga = 0
                            Else
                                .Agt_Harga = Single.Parse(dtFilter.Rows(i)("Agt Price").ToString)
                            End If
                            If dtFilter.Rows(i)("Sep Price") Is DBNull.Value OrElse dtFilter.Rows(i)("Sep Price").ToString = "" Then
                                .Sep_Harga = 0
                            Else
                                .Sep_Harga = Single.Parse(dtFilter.Rows(i)("Sep Price").ToString)
                            End If
                            If dtFilter.Rows(i)("Okt Price") Is DBNull.Value OrElse dtFilter.Rows(i)("Okt Price").ToString = "" Then
                                .Okt_Harga = 0
                            Else
                                .Okt_Harga = Single.Parse(dtFilter.Rows(i)("Okt Price").ToString)
                            End If
                            If dtFilter.Rows(i)("Nov Price") Is DBNull.Value OrElse dtFilter.Rows(i)("Nov Price").ToString = "" Then
                                .Nov_Harga = 0
                            Else
                                .Nov_Harga = Single.Parse(dtFilter.Rows(i)("Nov Price").ToString)
                            End If
                            If dtFilter.Rows(i)("Des Price") Is DBNull.Value OrElse dtFilter.Rows(i)("Des Price").ToString = "" Then
                                .Des_Harga = 0
                            Else
                                .Des_Harga = Single.Parse(dtFilter.Rows(i)("Des Price").ToString)
                            End If
                            'If dtFilter.Rows(i)("revisi") Is DBNull.Value OrElse dtFilter.Rows(i)("revisi").ToString = "" Then
                            '    .Revisi = 0
                            'Else
                            '    .Revisi = dtFilter.Rows(i)("revisi")
                            'End If

                            '.DeleteByTahun()
                            .Insert()

                        End With

                    Catch ex As Exception
                        WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                        WriteSalesToErrorLog("Budget", "Log", dtFilter, i, "Inventory ID", gh_Common.Username)
                        Continue For
                    End Try
                Next
                SplashScreenManager.CloseForm()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                'Cursor = Cursors.Default
                LoadGrid()
            End If
        Catch ex As Exception
            Console.WriteLine(ex.Message)
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
        ff_Detail.MdiParent = MenuUtamaForm
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

                If GridView1.GetSelectedRows.Length > 0 Then
                    'Dim objGrid As DataGridView = sender
                    Call CallFrm(ID,
                             invtID,
                             GridView1.RowCount)
                End If
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

            If GridView1.GetSelectedRows.Length > 0 Then
                'Dim objGrid As DataGridView = sender
                Call CallFrm(ID,
                         invtID,
                         GridView1.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
End Class
