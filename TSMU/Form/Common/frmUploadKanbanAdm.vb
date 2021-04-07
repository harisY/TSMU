Imports DevExpress.XtraGrid
Imports DevExpress.XtraSplashScreen

Public Class frmUploadKanbanAdm
    Dim dtGrid As DataTable
    Dim Obj As New KanbanAdmModel

    Private Sub frmUploadKanbanAdm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call Proc_EnableButtons(False, False, False, True, True, False, True, False, False, False, False)
    End Sub

    Private Sub LoadGrid()
        Try
            SplashScreenManager.ShowForm(GetType(FrmWait))
            dtGrid = Obj.GetAllDataGrid()
            Grid.DataSource = dtGrid

            If GridView1.RowCount > 0 Then
                With GridView1
                    .BestFitColumns()
                    .Columns(0).Visible = False
                    .FixedLineWidth = 2
                    .Columns(11).Fixed = Columns.FixedStyle.Left
                    .Columns(12).Fixed = Columns.FixedStyle.Left
                    .Columns(1).Fixed = Columns.FixedStyle.Left
                    .Columns(2).Fixed = Columns.FixedStyle.Left

                End With
                GridCellFormat(GridView1)
                SplashScreenManager.CloseForm()
            End If
        Catch ex As Exception
            SplashScreenManager.CloseForm()
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        LoadGrid()
    End Sub

    Public Overrides Sub Proc_Excel()
        Dim table As New DataTable
        Dim ls_Judul As String = "Barcode"
        Dim Bulan As String = ""
        Dim strTahun As String = ""
        Dim strCustomer As String = ""

        Dim frmExcel As FrmSystemExcelBarcode
        frmExcel = New FrmSystemExcelBarcode(table, 69)
        frmExcel.Text = "Import " & ls_Judul
        frmExcel.StartPosition = FormStartPosition.CenterScreen
        frmExcel.ShowDialog()

        Dim j As Integer
        Try
            Dim ObjColllection As KanbanAdmModel
            Dim dv As DataView = New DataView(table)
            Dim dtFilter As New DataTable

            dtFilter = dv.ToTable
            SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
            SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
            If dtFilter.Rows.Count > 0 Then
                Obj.ObjCollections.Clear()
                For i As Integer = 0 To dtFilter.Rows.Count - 1
                    ObjColllection = New KanbanAdmModel
                    With ObjColllection
                        .PlantCode = dtFilter.Rows(i)("Plant Code").ToString().AsString
                        .ShopCode = dtFilter.Rows(i)("Shop Code").ToString.AsString
                        .PartCategory = dtFilter.Rows(i)("Part Category").ToString.AsString
                        .Route = dtFilter.Rows(i)("Route").ToString.AsString
                        .LP = dtFilter.Rows(i)("LP").ToString.AsString
                        .Trip = dtFilter.Rows(i)("Trip").ToString.AsString
                        .VendorCode = dtFilter.Rows(i)("Vendor Code").ToString.AsString
                        .VendorAlias = dtFilter.Rows(i)("Vendor Alias").ToString.AsString
                        .VendorSite = dtFilter.Rows(i)("Vendor Site").ToString
                        .VendorSiteAlias = dtFilter.Rows(i)("Vendor Site Alias").ToString.AsString
                        .OrderNo = dtFilter.Rows(i)("Order No").ToString.AsString
                        .PONo = dtFilter.Rows(i)("PO Number").ToString.AsString
                        .CalcDate = dtFilter.Rows(i)("Calc# Date").ToString().AsDateTime
                        .OrderDate = dtFilter.Rows(i)("Order Date").ToString().AsDateTime
                        .OrderTime = dtFilter.Rows(i)("Order Time")
                        .DelDate = dtFilter.Rows(i)("Del# Date").ToString().AsDateTime
                        .DelTime = dtFilter.Rows(i)("Del# Time")
                        .DelCycle = dtFilter.Rows(i)("Del# Cycle").ToString().AsString
                        .DocNo = dtFilter.Rows(i)("Doc No").ToString().AsString
                        .RecStatus = dtFilter.Rows(i)("Rec Status").ToString().AsString
                        .DNType = dtFilter.Rows(i)("DN Type").ToString().AsString
                        .PartNo = dtFilter.Rows(i)("Part No").ToString().AsString
                        .PartName = dtFilter.Rows(i)("Part Name").ToString().AsString
                        .JobNo = dtFilter.Rows(i)("Job No").ToString().AsString
                        .Lane = dtFilter.Rows(i)("Lane").ToString().AsInt
                        .QtyKbn = dtFilter.Rows(i)("Qty/Kbn").ToString().AsInt
                        .OrderKbn = dtFilter.Rows(i)("Order(Kbn)").ToString().AsInt
                        .OrderPcs = dtFilter.Rows(i)("Order(Pcs)").ToString().AsInt
                        .QtyReceive = dtFilter.Rows(i)("Qty Receive").ToString().AsInt
                        .QtyBalance = dtFilter.Rows(i)("Qty Balance").ToString().AsInt
                        .CancelStatus = dtFilter.Rows(i)("Cancel Status").ToString().AsString
                        .Remark = dtFilter.Rows(i)("Remark").ToString().AsString
                        .UploadedDate = Date.Now
                        .UploadedBy = gh_Common.Username
                    End With
                    Obj.ObjCollections.Add(ObjColllection)
                Next
                Obj.InsertTransactions()

                SplashScreenManager.CloseForm()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                LoadGrid()
            End If
        Catch ex As Exception
            SplashScreenManager.CloseForm()
            Console.WriteLine($"Gagal Upload data - {j} {ex.Message}")
            ShowMessage($"Gagal Upload data - {ex.Message}", MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GridView1_MouseDown(sender As Object, e As MouseEventArgs) Handles GridView1.MouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            ContextMenuStrip1.Show(e.Location)
        End If
    End Sub

    'Public Overrides Sub Proc_PrintPreview()
    '    Try

    '        Dim ds As DataSet = New DataSet
    '        Dim dt As DataTable = New DataTable
    '        ds = SuratJalan.PrintPO(IIf(_BtnCust.Text = "", "ALL", _BtnCust.Text), Format(_TglSJFrom.EditValue, gs_FormatSQLDate), Format(_TglSJTo.EditValue, gs_FormatSQLDate), _TxtLokasi.Text, Format(_TxtTglKirimFrom.EditValue, gs_FormatSQLDate), Format(_TglKirimTo.EditValue, gs_FormatSQLDate))

    '        dt = ds.Tables("PrintPO")

    '        Dim Laporan As Testing = New Testing
    '        With Laporan
    '            .DataSource = dt
    '            '.DataMember = ds.Tables("PrintPO").TableName
    '        End With

    '        Using PrintTool As ReportPrintTool = New ReportPrintTool(Laporan)
    '            PrintTool.ShowPreviewDialog()
    '            PrintTool.ShowPreview(UserLookAndFeel.Default)
    '        End Using
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try
    'End Sub
    Private Sub SaveToExcel(_Grid As GridControl)
        Dim save As New SaveFileDialog
        save.Filter = "Excel File|*.xlsx"
        save.Title = "Save an Excel File"
        If save.ShowDialog = DialogResult.OK Then
            _Grid.ExportToXlsx(save.FileName)
        End If
    End Sub

    Private Sub CMSExport_Click(sender As Object, e As EventArgs) Handles CMSExport.Click
        If GridView1.RowCount > 0 Then
            SaveToExcel(Grid)
        Else
            MsgBox("Grid Kosong !")
        End If
    End Sub

    Private Sub frmUploadKanbanAdm_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LoadGrid()
    End Sub

End Class