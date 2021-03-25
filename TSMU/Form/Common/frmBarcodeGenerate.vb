Imports DevExpress.XtraSplashScreen

Public Class frmBarcodeGenerate
    Dim dtGrid As DataTable
    Dim Obj As New BarcodeGenerate
    Dim ObjDet As New BarcodeDet

    Private Sub frmBarcodeGenerate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Dim dtGrid As New DataTable
        dtGrid = Grid.DataSource
        Call Proc_EnableButtons(False, False, False, True, True, False, True, False, False, False, False)
    End Sub

    Private Sub LoadGrid()
        Try
            'Grid.ReadOnly = True
            'Grid.AllowSorting = AllowSortingEnum.SingleColumn
            If gh_Common.Site.ToLower = "tng" Then
                dtGrid = Obj.GetAllDataGrid()
            Else
                dtGrid = Obj.GetAllDataGridCKR()
            End If

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
        Dim ls_Judul As String = "Barcode"
        Dim Bulan As String = ""
        Dim strTahun As String = ""
        Dim strCustomer As String = ""

        Dim frmExcel As FrmSystemExcelBarcode
        frmExcel = New FrmSystemExcelBarcode(table, 69) With {
            .Text = "Import " & ls_Judul,
            .StartPosition = FormStartPosition.CenterScreen
        }
        frmExcel.ShowDialog()

        Try
            'Dim dv As DataView = New DataView(table)
            'Dim dtFilter As New DataTable

            'table = dv.ToTable
            'Exit Sub
            If table.Rows.Count > 0 Then

                SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Please wait...")

                Obj.ObjDetails.Clear()
                For Each row As DataRow In table.Rows
                    ObjDet = New BarcodeDet
                    With ObjDet
                        .KodePart = row("KODE PART").ToString().AsString()
                        .CustomerID = row("CUST").ToString().AsString()
                        .CustomerName = row("CUST LENGKAP").ToString().AsString()
                        .InventoryID = row("INVENTORY ID").ToString().AsString()
                        .SFGFG = row("SFG/FG").ToString().AsString()
                        .PartName = row("PART NAME").ToString().AsString()
                        .PartNo = row("NO PART").ToString().AsString()
                        .Colour = row("COLOUR").ToString().AsString()
                        .JobNo = row("JOB NO").ToString().AsString()
                        .QtyLabel = row("QTY LABEL").ToString().AsInt()
                        .WarnaPasscard = row("WARNA PASCARD").ToString().AsString()
                        .LokalExport = row("LOKAL / EXPORT").ToString().AsString()
                        .KodeWarna = row("KODE WARNA").ToString().AsString()
                        .Varian = row("VARIAN").ToString().AsString()
                        .TglUpload = Date.Now
                        .UploadBy = gh_Common.Username
                        .Site = gh_Common.Site
                    End With
                    Obj.ObjDetails.Add(ObjDet)
                Next
                Obj.InsertData()
                SplashScreenManager.CloseForm()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                LoadGrid()
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            SplashScreenManager.CloseForm()
        End Try
    End Sub

    Public Overrides Sub Proc_PrintPreview()
        Try
            Dim f As New FrmLookUpBarcode
            f.StartPosition = FormStartPosition.CenterParent
            f.ShowDialog()
            'If GridView1.RowCount = 0 Then
            '    Throw New Exception("Tidak ada data yang di akan print.")
            'End If

            'Dim ds As DataSet = New DataSet
            'Dim dt As DataTable = New DataTable
            'ds = Obj.PrintQRCOde()

            'dt = ds.Tables("QRCode")

            'Dim Laporan As Testing = New Testing
            'With Laporan
            '    '.param1 = No
            '    '.param2 = No
            '    .DataSource = dt
            '    '.DataMember = ds.Tables("PrintPO").TableName
            'End With

            'Using PrintTool As ReportPrintTool = New ReportPrintTool(Laporan)
            '    PrintTool.ShowPreviewDialog()
            '    PrintTool.ShowPreview(UserLookAndFeel.Default)
            'End Using
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If GridView1.RowCount > 0 Then
            SaveToExcel(Grid)
        Else
            MsgBox("Data Kosong !")
        End If
    End Sub

    Private Sub Grid_MouseDown(sender As Object, e As MouseEventArgs) Handles Grid.MouseDown
        If e.Button = System.Windows.Forms.MouseButtons.Right Then
            ContextMenuStrip1.Show(e.Location)
        End If
    End Sub

End Class