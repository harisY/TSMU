Imports DevExpress.LookAndFeel
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen

Public Class frmBarcodeGenerate
    Dim dtGrid As DataTable
    Dim Obj As New BarcodeGenerate
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
            dtGrid = Obj.GetAllDataGrid()
            Grid.DataSource = dtGrid
            With GridView1
                .BestFitColumns()
                .FixedLineWidth = 2
                .Columns(1).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                .Columns(2).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
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
        frmExcel = New FrmSystemExcelBarcode(table, 69)
        frmExcel.Text = "Import " & ls_Judul
        frmExcel.StartPosition = FormStartPosition.CenterScreen
        frmExcel.ShowDialog()

        Try
            Dim dv As DataView = New DataView(table)
            Dim dtFilter As New DataTable

            dtFilter = dv.ToTable

            If dtFilter.Rows.Count > 0 Then

                SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
                For i As Integer = 0 To dtFilter.Rows.Count - 1
                    Try
                        With Obj
                            If dtFilter.Rows(i)("KODE PART") Is DBNull.Value OrElse dtFilter.Rows(i)("KODE PART").ToString = "" Then
                                .KodePart = 0
                            Else
                                .KodePart = Integer.Parse(dtFilter.Rows(i)("KODE PART").ToString)
                            End If
                            If dtFilter.Rows(i)("CUST") Is DBNull.Value OrElse dtFilter.Rows(i)("CUST").ToString = "" Then
                                .CustomerID = ""
                            Else
                                .CustomerID = dtFilter.Rows(i)("CUST").ToString
                            End If
                            If dtFilter.Rows(i)("CUST LENGKAP") Is DBNull.Value OrElse dtFilter.Rows(i)("CUST LENGKAP").ToString = "" Then
                                .CustomerName = ""
                            Else
                                .CustomerName = dtFilter.Rows(i)("CUST LENGKAP").ToString
                            End If
                            If dtFilter.Rows(i)("INVENTORY ID") Is DBNull.Value OrElse dtFilter.Rows(i)("INVENTORY ID").ToString = "" Then
                                .InventoryID = ""
                            Else
                                .InventoryID = dtFilter.Rows(i)("INVENTORY ID").ToString
                            End If

                            If dtFilter.Rows(i)("SFG/FG") Is DBNull.Value OrElse dtFilter.Rows(i)("SFG/FG").ToString = "" Then
                                .SFGFG = ""
                            Else
                                .SFGFG = dtFilter.Rows(i)("SFG/FG").ToString
                            End If
                            If dtFilter.Rows(i)("PART NAME ALL") Is DBNull.Value OrElse dtFilter.Rows(i)("PART NAME ALL").ToString = "" Then
                                .PartNameFull = ""
                            Else
                                .PartNameFull = dtFilter.Rows(i)("PART NAME ALL").ToString
                            End If
                            If dtFilter.Rows(i)("PART NAME") Is DBNull.Value OrElse dtFilter.Rows(i)("PART NAME").ToString = "" Then
                                .PartName = ""
                            Else
                                .PartName = dtFilter.Rows(i)("PART NAME").ToString
                            End If
                            If dtFilter.Rows(i)("NO PART") Is DBNull.Value OrElse dtFilter.Rows(i)("NO PART").ToString = "" Then
                                .PartNo = ""
                            Else
                                .PartNo = dtFilter.Rows(i)("NO PART").ToString
                            End If

                            If dtFilter.Rows(i)("COLOUR") Is DBNull.Value OrElse dtFilter.Rows(i)("COLOUR").ToString = "" Then
                                .Colour = ""
                            Else
                                .Colour = dtFilter.Rows(i)("COLOUR").ToString
                            End If
                            If dtFilter.Rows(i)("JOB NO") Is DBNull.Value OrElse dtFilter.Rows(i)("JOB NO").ToString = "" Then
                                .JobNo = ""
                            Else
                                .JobNo = dtFilter.Rows(i)("JOB NO").ToString
                            End If
                            If dtFilter.Rows(i)("TARGET").ToString = "" OrElse dtFilter.Rows(i)("TARGET") Is DBNull.Value Then
                                .Target = ""
                            Else
                                .Target = dtFilter.Rows(i)("TARGET").ToString
                            End If

                            If dtFilter.Rows(i)("FAMILY").ToString = "" OrElse dtFilter.Rows(i)("FAMILY") Is DBNull.Value Then
                                .Family = ""
                            Else
                                .Family = dtFilter.Rows(i)("FAMILY").ToString
                            End If

                            If dtFilter.Rows(i)("CAV").ToString = "" OrElse dtFilter.Rows(i)("CAV") Is DBNull.Value Then
                                .Cav = ""
                            Else
                                .Cav = dtFilter.Rows(i)("CAV").ToString
                            End If
                            If dtFilter.Rows(i)("QTY LABEL").ToString = "" OrElse dtFilter.Rows(i)("QTY LABEL") Is DBNull.Value Then
                                .QtyLabel = 0
                            Else
                                .QtyLabel = Integer.Parse(dtFilter.Rows(i)("QTY LABEL").ToString)
                            End If
                            If dtFilter.Rows(i)("WARNA PASCARD").ToString = "" OrElse dtFilter.Rows(i)("WARNA PASCARD") Is DBNull.Value Then
                                .WarnaPasscard = ""
                            Else
                                .WarnaPasscard = dtFilter.Rows(i)("WARNA PASCARD").ToString
                            End If

                            If dtFilter.Rows(i)("JENIS STOCK MAT").ToString = "" OrElse dtFilter.Rows(i)("JENIS STOCK MAT") Is DBNull.Value Then
                                .JenisStok = ""
                            Else
                                .JenisStok = dtFilter.Rows(i)("JENIS STOCK MAT").ToString
                            End If
                            If dtFilter.Rows(i)("STATUS MILIK").ToString = "" OrElse dtFilter.Rows(i)("STATUS MILIK") Is DBNull.Value Then
                                .StatusMilik = ""
                            Else
                                .StatusMilik = dtFilter.Rows(i)("STATUS MILIK").ToString
                            End If

                            If dtFilter.Rows(i)("INVENTORY ID MAT").ToString = "" OrElse dtFilter.Rows(i)("INVENTORY ID MAT") Is DBNull.Value Then
                                .InventoryIdMat = ""
                            Else
                                .InventoryIdMat = dtFilter.Rows(i)("INVENTORY ID MAT").ToString
                            End If
                            If dtFilter.Rows(i)("MATERIAL").ToString = "" OrElse dtFilter.Rows(i)("MATERIAL") Is DBNull.Value Then
                                .Material = ""
                            Else
                                .Material = dtFilter.Rows(i)("MATERIAL").ToString
                            End If

                            .TglUpload = DateTime.Now
                            .UploadBy = gh_Common.Username
                            .InsertData()

                        End With

                    Catch ex As Exception
                        'MsgBox(ex.Message)
                        Console.WriteLine(ex.Message)
                        WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                        Continue For
                    End Try
                Next
                SplashScreenManager.CloseForm()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                LoadGrid()
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
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
End Class
