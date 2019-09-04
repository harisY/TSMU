Imports DevExpress.LookAndFeel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen

Public Class frmKanbanInternal
    Dim dtGrid As DataTable
    Dim Obj As New KanbanInternal
    Dim ObjDet As New KanbanInternalDetails

    Dim PrintTool As ReportPrintTool

    Dim ds As DataSet
    Dim dt As DataTable
    Dim dtTemp As DataTable
    Private Sub frmKanbanInternal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Dim dtGrid As New DataTable
        dtGrid = Grid.DataSource
        Call Proc_EnableButtons(False, False, False, True, True, False, True, False, False, False, False)
    End Sub

    Private Sub LoadGrid()
        Try
            dtGrid = New DataTable
            dtGrid = Obj.GetAllDataGridCKR()
            Grid.DataSource = dtGrid
            With GridView1
                .BestFitColumns()
            End With
            If GridView1.RowCount > 0 Then
                GridCellFormat(GridView1)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Public Overrides Sub Proc_Refresh()
        Call LoadGrid()
    End Sub
    Public Overrides Sub Proc_Excel()
        Dim table As New DataTable
        Dim ls_Judul As String = "Kanban Internal"
        Dim Bulan As String = ""
        Dim strTahun As String = ""
        Dim strCustomer As String = ""

        Dim frmExcel As FrmSystemExcelBarcode
        frmExcel = New FrmSystemExcelBarcode(table, 69)
        frmExcel.Text = "Import " & ls_Judul
        frmExcel.StartPosition = FormStartPosition.CenterScreen
        frmExcel.ShowDialog()

        Try

            Dim dv As DataView = New DataView(table)
            Dim dtFilter As New DataTable

            dtFilter = dv.ToTable
            'Exit Sub
            If dtFilter.Rows.Count > 0 Then
                SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
                Obj.ObjDetails.Clear()
                For Each row As DataRow In dtFilter.Rows
                    ObjDet = New KanbanInternalDetails
                    With ObjDet
                        .Customer = If(row("Cust") Is DBNull.Value, "", row("Cust").ToString())
                        .DeliveryDate = If(row("Delivery Date") Is DBNull.Value, DateTime.Today, Convert.ToDateTime(row("Delivery Date")))
                        .InventoryId = If(row("Inventori ID") Is DBNull.Value, "", row("Inventori ID").ToString())
                        .ItemNo = If(row("Item No") Is DBNull.Value, "", row("Item No").ToString())
                        .NoPO = If(row("No PO") Is DBNull.Value, "", row("No PO").ToString())
                        .NoUrut = If(row("No Urut") Is DBNull.Value, 0, Convert.ToInt32(row("No Urut").ToString()))
                        .OrderDate = If(row("Order Date") Is DBNull.Value, DateTime.Today, Convert.ToDateTime(row("Order Date")))
                        .PalletizeMark = If(row("Palletize Mark") Is DBNull.Value, "", row("Palletize Mark").ToString())
                        .PartName = If(row("Part Name") Is DBNull.Value, "", Convert.ToString(row("Part Name")))
                        .PartNo = If(row("Part No") Is DBNull.Value, "", Convert.ToString(row("Part No")))
                        .PartNoLabel = If(row("Part No Label") Is DBNull.Value, "", row("Part No Label").ToString())
                        .PONumber = If(row("Part No") Is DBNull.Value, "", row("Part No").ToString())
                        .QtyOrder = If(row("Qty Order") Is DBNull.Value, 0, Convert.ToInt32(row("Qty Order")))
                        .RackLabel = If(row("Rack Label") Is DBNull.Value, "", row("Rack Label").ToString())
                        .RackPart = If(row("Rack Part") Is DBNull.Value, "", row("Rack Part").ToString())
                        .RH_LH = If(row("RH/LH") Is DBNull.Value, "", row("RH/LH").ToString())
                        .Type = If(row("Type") Is DBNull.Value, "", row("Type").ToString())
                        .UploadedBy = gh_Common.Username
                    End With
                    Obj.ObjDetails.Add(ObjDet)
                Next
                Obj.InsertData()
                SplashScreenManager.CloseForm()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                LoadGrid()
            End If
        Catch ex As Exception
            SplashScreenManager.CloseForm()
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_PrintPreview()
        Try
            'Dim f As New FrmLookUpBarcode
            'f.StartPosition = FormStartPosition.CenterParent
            'f.ShowDialog()
            'Dim _param As ArrayList = New ArrayList()
            TempTable()

            For i As Integer = 0 To GridView1.RowCount - 1
                dtTemp.Rows.Add()
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(0) = Trim(GridView1.GetRowCellValue(i, "Id") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(1) = Trim(GridView1.GetRowCellValue(i, "NoUrut") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(2) = Trim(GridView1.GetRowCellValue(i, "Customer") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(3) = Trim(GridView1.GetRowCellValue(i, "PONumber") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(4) = Trim(GridView1.GetRowCellValue(i, "InventoryId") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(5) = Trim(GridView1.GetRowCellValue(i, "PartName") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(6) = Trim(GridView1.GetRowCellValue(i, "PartNo") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(7) = Trim(GridView1.GetRowCellValue(i, "Type") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(8) = Trim(GridView1.GetRowCellValue(i, "NoPO") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(9) = Trim(GridView1.GetRowCellValue(i, "OrderDate") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(10) = Trim(GridView1.GetRowCellValue(i, "DelDate") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(11) = Trim(GridView1.GetRowCellValue(i, "QtyOrder") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(12) = Trim(GridView1.GetRowCellValue(i, "RH_LH") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(13) = Trim(GridView1.GetRowCellValue(i, "PalletizeMark") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(14) = Trim(GridView1.GetRowCellValue(i, "PartNoLabel") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(15) = Trim(GridView1.GetRowCellValue(i, "RackLabel") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(16) = Trim(GridView1.GetRowCellValue(i, "RackPart") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(17) = Trim(GridView1.GetRowCellValue(i, "ItemNo") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(18) = Trim(GridView1.GetRowCellValue(i, "Warna") & "")
            Next

            'ds = New DataSet
            'ds = Obj.PrintQRCOdeCkr()

            'dt = New DataTable
            'dt = ds.Tables("KanbanInternal")

            If dtTemp.Rows.Count = 0 Then
                Throw New Exception("Tidak ada data yang di print !")
                'Else
                '    For i As Integer = 0 To dt.Rows.Count - 1
                '        _param.Add(dt.Rows(i)("Cust").ToString())
                '    Next
            End If

            Dim Laporan As New PrintKanbanInternalTes()
            With Laporan
                '.param1 = _param
                .DataSource = dtTemp
                AddHandler .PrintingSystem.EndPrint, AddressOf PrintingSystem_EndPrint
            End With

            PrintTool = New ReportPrintTool(Laporan)
            TryCast(PrintTool.Report, XtraReport).Tag = PrintTool
            'PrintTool.ShowPreviewDialog()
            PrintTool.ShowPreview(UserLookAndFeel.Default)

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub PrintingSystem_EndPrint(sender As Object, e As EventArgs)
        Try
            For i As Integer = 0 To dtTemp.Rows.Count - 1
                Obj = New KanbanInternal
                Obj.UpdateData(dtTemp.Rows(i)("Id"))
                PrintTool.ClosePreview()
                tsBtn_refresh.PerformClick()

            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub TempTable()
        dtTemp = New DataTable
        dtTemp.Columns.Add("Id")
        dtTemp.Columns.Add("NoUrut")
        dtTemp.Columns.Add("Cust")
        dtTemp.Columns.Add("PONumber")
        dtTemp.Columns.Add("InventoryId")
        dtTemp.Columns.Add("PartName")
        dtTemp.Columns.Add("PartNo")
        dtTemp.Columns.Add("Type")
        dtTemp.Columns.Add("NoPO")
        dtTemp.Columns.Add("OrderDate")
        dtTemp.Columns.Add("DelDate")
        dtTemp.Columns.Add("QtyOrder")
        dtTemp.Columns.Add("RH_LH")
        dtTemp.Columns.Add("PalletizeMark")
        dtTemp.Columns.Add("PartNoLabel")
        dtTemp.Columns.Add("RackLabel")
        dtTemp.Columns.Add("RackPart")
        dtTemp.Columns.Add("ItemNo")
        dtTemp.Columns.Add("Warna")
        dtTemp.Clear()
    End Sub
End Class
