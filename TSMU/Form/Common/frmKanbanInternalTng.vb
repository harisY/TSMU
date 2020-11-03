Imports DevExpress.LookAndFeel
Imports DevExpress.XtraEditors
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen

Public Class frmKanbanInternalTng
    Dim dtGrid As DataTable
    Dim Obj As New KanbanInternalTng

    Dim PrintTool As ReportPrintTool

    Dim ds As DataSet
    Dim dt As DataTable
    Dim dtTemp As DataTable
    Dim dtTemp1 As DataTable
    Private Sub frmKanbanInternalTng_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call Proc_EnableButtons(False, False, False, True, True, False, True, False, False, False, False)
    End Sub

    Private Sub LoadGrid()
        Try
            SplashScreenManager.ShowForm(GetType(FrmWait))
            dtGrid = New DataTable
            dtGrid = Obj.GetKanbans()
            Grid.DataSource = dtGrid
            With GridView1
                .BestFitColumns()
            End With
            If GridView1.RowCount > 0 Then
                GridCellFormat(GridView1)
            End If
            SplashScreenManager.CloseForm()
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
        Dim _Table As New DataTable
        Dim Filename As String = String.Empty
        Dim Dial As New OpenFileDialog
        Dial.Filter = "Excel Files|*.xls;*.xlsx"
        Dim result As DialogResult = Dial.ShowDialog()
        If result = System.Windows.Forms.DialogResult.OK Then
            _Table = ExcelToDatatable(Dial.FileName, "Sheet1")
        End If

        Try
            If _Table.Rows.Count > 0 Then
                SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
                Obj.KanbanCollection.Clear()
                For Each row As DataRow In _Table.Rows
                    Dim ObjCollection As New KanbanInternalTng

                    With ObjCollection
                        .Customer = If(String.IsNullOrEmpty(row("Cust").ToString()), "", row("Cust").ToString())
                        Dim _DeliveryDate As Date = Date.ParseExact(row("Delivery Date"), "dd.MM.yyyy", Globalization.DateTimeFormatInfo.InvariantInfo)
                        .DeliveryDate = If(String.IsNullOrEmpty(row("Delivery Date").ToString()), Date.Today, _DeliveryDate)
                        .InventoryId = If(row("Inventori ID") Is DBNull.Value, "", row("Inventori ID").ToString())
                        .ItemNo = If(row("Item No") Is DBNull.Value, "", row("Item No").ToString())
                        .NoPO = If(row("No PO") Is DBNull.Value, "", row("No PO").ToString())
                        .NoUrut = If(row("No Urut") Is DBNull.Value, 0, Convert.ToInt32(row("No Urut").ToString()))
                        Dim _OrderDate As Date = Date.ParseExact(row("Order Date"), "dd.MM.yyyy", Globalization.DateTimeFormatInfo.InvariantInfo)
                        .OrderDate = If(row("Order Date") Is DBNull.Value, Date.Today, _OrderDate)
                        .PalletizeMark = If(row("Palletize Mark") Is DBNull.Value, "", row("Palletize Mark").ToString())
                        .PartName = If(row("Part Name") Is DBNull.Value, "", Convert.ToString(row("Part Name")))
                        .PartNo = If(row("Part No") Is DBNull.Value, "", Convert.ToString(row("Part No")))
                        .PartNoLabel = If(row("Part No Label") Is DBNull.Value, "", row("Part No Label").ToString())
                        .PONumber = If(row("PO Number") Is DBNull.Value, "", row("PO Number").ToString())
                        .QtyOrder = If(row("Qty Order") Is DBNull.Value, 0, Convert.ToInt32(row("Qty Order")))
                        .RackLabel = If(row("Rack Label") Is DBNull.Value, "", row("Rack Label").ToString())
                        .RackPart = If(row("Rack Part") Is DBNull.Value, "", row("Rack Part").ToString())
                        .RH_LH = If(row("RH/LH") Is DBNull.Value, "", row("RH/LH").ToString())
                        .Type = If(row("Type") Is DBNull.Value, "", row("Type").ToString())
                        .VendorCode = If(row("Vendor Code") Is DBNull.Value, "", row("Vendor Code").ToString())
                        .UploadedBy = gh_Common.Username
                    End With
                    Obj.KanbanCollection.Add(ObjCollection)
                Next
                Obj.Insert()
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
            TempTable()

            For i As Integer = 0 To GridView1.RowCount - 1
                dtTemp.Rows.Add()
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(0) = Trim(GridView1.GetRowCellValue(i, "Id") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(1) = Trim(GridView1.GetRowCellValue(i, "NoUrut") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(2) = Trim(GridView1.GetRowCellValue(i, "Customer") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(3) = Trim(GridView1.GetRowCellValue(i, "PONumber") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(4) = Trim(GridView1.GetRowCellValue(i, "InventoryID") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(5) = Trim(GridView1.GetRowCellValue(i, "PartName") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(6) = Trim(GridView1.GetRowCellValue(i, "PartNo") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(7) = Trim(GridView1.GetRowCellValue(i, "Type") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(8) = Trim(GridView1.GetRowCellValue(i, "NoPO") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(9) = Trim(GridView1.GetRowCellValue(i, "OrderDate") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(10) = Trim(GridView1.GetRowCellValue(i, "DeliveryDate") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(11) = Trim(GridView1.GetRowCellValue(i, "QtyOrder") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(12) = Trim(GridView1.GetRowCellValue(i, "RH/LH") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(13) = Trim(GridView1.GetRowCellValue(i, "PalletizeMark") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(14) = Trim(GridView1.GetRowCellValue(i, "PartNoLabel") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(15) = Trim(GridView1.GetRowCellValue(i, "RackLabel") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(16) = Trim(GridView1.GetRowCellValue(i, "RackPart") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(17) = Trim(GridView1.GetRowCellValue(i, "ItemNo") & "")
                dtTemp.Rows(dtTemp.Rows.Count - 1).Item(18) = Trim(GridView1.GetRowCellValue(i, "Warna") & "")
            Next

            If dtTemp.Rows.Count = 0 Then
                Throw New Exception("Tidak ada data yang di print !")
            End If
            Dim groups = From j In dtTemp
                         Group By x = New With {
                                Key .Cust = j.Field(Of String)("Cust"),
                                Key .PONumber = j.Field(Of String)("PONumber"),
                                Key .InventoryId = j.Field(Of String)("InventoryId"),
                                Key .PartName = j.Field(Of String)("PartName"),
                                Key .PartNo = j.Field(Of String)("PartNo"),
                                Key .Type = j.Field(Of String)("Type"),
                                Key .NoPO = j.Field(Of String)("NoPO"),
                                Key .OrderDate = j.Field(Of String)("OrderDate"),
                                Key .DelDate = j.Field(Of String)("DelDate"),
                                Key .RH_LH = j.Field(Of String)("RH_LH"),
                                Key .PalletizeMark = j.Field(Of String)("PalletizeMark"),
                                Key .PartNoLabel = j.Field(Of String)("PartNoLabel"),
                                Key .RackLabel = j.Field(Of String)("RackLabel"),
                                Key .RackPart = j.Field(Of String)("RackPart"),
                                Key .Warna = j.Field(Of String)("Warna")} Into g = Group
                         Select New With {
                            x.Cust,
                            x.PONumber,
                            x.InventoryId,
                            x.PartName,
                             x.PartNo,
                             x.Type,
                             x.NoPO,
                             x.OrderDate,
                             x.DelDate,
                             .QtyOrder = g.Sum(Function(dr) dr.Field(Of Integer)("QtyOrder")),
                             x.RH_LH,
                             x.PalletizeMark,
                             x.PartNoLabel,
                             x.RackLabel,
                             x.RackPart,
                             x.Warna
                        }

            TempTable1()
            Dim ObjKanban As New KanbanInternalTng
            Dim urut As Integer = 1
            For Each item In groups
                Dim dr As DataRow = dtTemp1.NewRow()
                dr("NoUrut") = urut
                dr("Cust") = item.Cust
                dr("PONumber") = item.PONumber
                dr("InventoryID") = item.InventoryId
                dr("PartName") = item.PartName
                dr("PartNo") = item.PartNo
                dr("Type") = item.Type
                dr("NoPO") = item.NoPO
                dr("OrderDate") = item.OrderDate
                dr("DelDate") = item.DelDate
                dr("QtyOrder") = item.QtyOrder
                dr("RH_LH") = item.RH_LH
                dr("PalletizeMark") = item.PalletizeMark
                dr("PartNoLabel") = item.PartNoLabel
                dr("RackLabel") = item.RackLabel
                dr("RackPart") = item.RackPart
                dr("Warna") = item.Warna
                dr("QRCode") = item.InventoryId & item.PartNoLabel
                dtTemp1.Rows.Add(dr)
                urut = urut + 1
            Next

            Dim Laporan As New PrintKanbanInternalTes()
            With Laporan
                '.param1 = _param
                .DataSource = dtTemp1
                AddHandler .PrintingSystem.EndPrint, AddressOf PrintingSystem_EndPrint
            End With

            PrintTool = New ReportPrintTool(Laporan)
            TryCast(PrintTool.Report, XtraReport).Tag = PrintTool
            PrintTool.ShowPreview(UserLookAndFeel.Default)

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub PrintingSystem_EndPrint(sender As Object, e As EventArgs)
        Try
            For i As Integer = 0 To dtTemp.Rows.Count - 1
                Obj = New KanbanInternalTng
                Obj.UpdateKanban(dtTemp.Rows(i)("Id"))
                PrintTool.ClosePreview()
                tsBtn_refresh.PerformClick()
            Next
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub TempTable()
        dtTemp = New DataTable
        dtTemp.Columns.Add("Id", GetType(Integer))
        dtTemp.Columns.Add("NoUrut", GetType(Integer))
        dtTemp.Columns.Add("Cust", GetType(String))
        dtTemp.Columns.Add("PONumber", GetType(String))
        dtTemp.Columns.Add("InventoryID", GetType(String))
        dtTemp.Columns.Add("PartName", GetType(String))
        dtTemp.Columns.Add("PartNo", GetType(String))
        dtTemp.Columns.Add("Type", GetType(String))
        dtTemp.Columns.Add("NoPO", GetType(String))
        dtTemp.Columns.Add("OrderDate", GetType(String))
        dtTemp.Columns.Add("DelDate", GetType(String))
        dtTemp.Columns.Add("QtyOrder", GetType(Integer))
        dtTemp.Columns.Add("RH_LH", GetType(String))
        dtTemp.Columns.Add("PalletizeMark", GetType(String))
        dtTemp.Columns.Add("PartNoLabel", GetType(String))
        dtTemp.Columns.Add("RackLabel", GetType(String))
        dtTemp.Columns.Add("RackPart", GetType(String))
        dtTemp.Columns.Add("ItemNo", GetType(String))
        dtTemp.Columns.Add("Warna", GetType(String))
        dtTemp.Clear()
    End Sub

    Private Sub TempTable1()
        dtTemp1 = New DataTable
        dtTemp1.Columns.Add("Id", GetType(Integer))
        dtTemp1.Columns.Add("NoUrut", GetType(Integer))
        dtTemp1.Columns.Add("Cust", GetType(String))
        dtTemp1.Columns.Add("PONumber", GetType(String))
        dtTemp1.Columns.Add("InventoryID", GetType(String))
        dtTemp1.Columns.Add("PartName", GetType(String))
        dtTemp1.Columns.Add("PartNo", GetType(String))
        dtTemp1.Columns.Add("Type", GetType(String))
        dtTemp1.Columns.Add("NoPO", GetType(String))
        dtTemp1.Columns.Add("OrderDate", GetType(String))
        dtTemp1.Columns.Add("DelDate", GetType(String))
        dtTemp1.Columns.Add("QtyOrder", GetType(Integer))
        dtTemp1.Columns.Add("RH_LH", GetType(String))
        dtTemp1.Columns.Add("PalletizeMark", GetType(String))
        dtTemp1.Columns.Add("PartNoLabel", GetType(String))
        dtTemp1.Columns.Add("RackLabel", GetType(String))
        dtTemp1.Columns.Add("RackPart", GetType(String))
        dtTemp1.Columns.Add("ItemNo", GetType(String))
        dtTemp1.Columns.Add("Warna", GetType(String))
        dtTemp1.Columns.Add("QRCode", GetType(String))
        dtTemp1.Clear()
    End Sub

    Private Sub frmKanbanInternalTng_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LoadGrid()
    End Sub
End Class
