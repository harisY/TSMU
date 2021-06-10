Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.LookAndFeel
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraReports.Parameters
Imports Excel = Microsoft.Office.Interop.Excel
Imports System.Reflection
Imports System.Runtime.InteropServices

Public Class FrmPPICConvertMuatDetail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim _Tag = New TagModel

    Dim clsGlobal As New GlobalService
    Dim srvPPIC As New PPICService
    Dim modelHeader As PPICConvertMuatHeaderModel
    Dim modelDetail As PPICConvertMuatDetailModel

    Dim GridDtl As GridControl
    Dim gridViewHeader As GridView

    Dim _rows As String
    Public Property NoUpload() As String
    Public Property CustID() As String
    Public Property DeliveryDueDate() As Date
    Public Property UploadDate() As Date
    Public Property FileName() As String
    Public Property Revised() As String
    Public Property dtDetail() As DataTable
    Public Property dtConvertMuat() As DataTable

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal strCode As String,
                   ByVal strCode2 As String,
                   ByVal strCode3 As String,
                   ByRef lf_FormParent As Form,
                   ByRef _Grid As GridControl,
                   ByRef _GridView As GridView,
                   ByRef rows As Integer)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
            fs_Code2 = strCode2
            UploadDate = strCode3
            _rows = rows
        End If
        GridDtl = _Grid
        gridViewHeader = _GridView
        FrmParent = lf_FormParent
        _Tag = New TagModel
        _Tag.PageIndex = lf_FormParent.Tag.PageIndex
        Tag = _Tag
    End Sub

    Private Sub FrmPPICConvertMuatDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CreateTable()
        Call InitialSetForm()
    End Sub

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "LIST PO DETAIL"
            Else
                Me.Text = "NEW LIST PO DETAIL"
            End If
            LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmPPICConvertMuat"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub LoadGridDetail()
        Try
            If isUpdate Then
                Call Proc_EnableButtons(False, False, False, True, True, False, False, True, False, False, False, False)
                NoUpload = fs_Code
                CustID = gridViewHeader.GetRowCellValue(_rows, "CustID")
                FileName = gridViewHeader.GetRowCellValue(_rows, "FileName")
                Revised = "Yes"
                btnKonversi.Enabled = False
                srvPPIC = New PPICService
                dtDetail = srvPPIC.GetDataConvertMuatDetail(fs_Code)
                dtConvertMuat = New DataTable
                dtConvertMuat = dtDetail.Copy()
                GridDetail.DataSource = dtConvertMuat
                txtTotalMobil.Text = fs_Code2

                If UploadDate = Date.Today Then
                    GridViewDetail.OptionsBehavior.Editable = True
                Else
                    GridViewDetail.OptionsBehavior.Editable = False
                End If
                HitungJumlahTruk()
            Else
                Proc_EnableButtons(False, False, False, False, False, False, False, False, False, False, False, False)
                txtTotalMobil.Text = 0
                dtConvertMuat = New DataTable
                dtConvertMuat = dtDetail.Copy()
                GridDetail.DataSource = dtConvertMuat
                GridViewDetail.OptionsBehavior.Editable = False
                btnKonversi.Enabled = True
            End If

            GridViewDetail.BestFitColumns()
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        LoadGridDetail()
    End Sub

    Public Overrides Sub Proc_Excel()
        Try
            If GridViewDetail.RowCount > 0 Then
                Dim save As New SaveFileDialog With {
                    .Filter = "Excel File|*.xls",
                    .Title = "Save an Excel File",
                    .FileName = FileName
                }
                If save.ShowDialog = DialogResult.OK Then
                    ExportToExcel(save)
                End If
            Else
                Throw New Exception("Data Is Not Found !")
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Public Overrides Function ValidateSave() As Boolean
        Dim lb_Validated As Boolean = False
        Try
            Dim success As Boolean = True

            If DxValidationProvider1.Validate Then
                lb_Validated = True
            Else
                Err.Raise(ErrNumber, , "Data yang anda input tidak valid, silahkan cek inputan anda !")
            End If

            If btnKonversi.Enabled = True Then
                Err.Raise(ErrNumber, , "Harap Konversi Muat Dulu!")
            End If

            If lb_Validated Then
                If Revised = "No" Then
                    clsGlobal = New GlobalService
                    NoUpload = clsGlobal.GetAutoNumber(FrmParent)
                End If
                modelHeader = New PPICConvertMuatHeaderModel
                With modelHeader
                    .NoUpload = NoUpload
                    .UploadDate = UploadDate
                    .CustID = CustID
                    .DeliveryDueDate = DeliveryDueDate
                    .FileName = FileName
                    .Revised = Revised
                    .TotalRecordExcel = GridViewDetail.RowCount
                    .TotalMobil = txtTotalMobil.Text
                End With
            End If
        Catch ex As Exception
            lb_Validated = False
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
        Return lb_Validated
    End Function

    Public Overrides Sub Proc_SaveData()
        Try
            modelHeader.ObjConvertDetails.Clear()
            For i As Integer = 0 To GridViewDetail.RowCount - 1
                If GridViewDetail.GetRowCellValue(i, "ItemNumber") IsNot DBNull.Value Then
                    modelDetail = New PPICConvertMuatDetailModel
                    With modelDetail
                        .NoUpload = NoUpload
                        .No = GridViewDetail.GetRowCellValue(i, "No")
                        .Seq = GridViewDetail.GetRowCellValue(i, "Seq")
                        .PartNo = GridViewDetail.GetRowCellValue(i, "PartNo")
                        .ItemNumber = GridViewDetail.GetRowCellValue(i, "ItemNumber")
                        .ItemName = GridViewDetail.GetRowCellValue(i, "ItemName")
                        .Lokasi = GridViewDetail.GetRowCellValue(i, "Lokasi")
                        .UserCode = GridViewDetail.GetRowCellValue(i, "UserCode")
                        .PF = GridViewDetail.GetRowCellValue(i, "PF")
                        .OrderNo = GridViewDetail.GetRowCellValue(i, "OrderNo")
                        .DeliveryDueDate = IIf(GridViewDetail.GetRowCellValue(i, "DeliveryDueDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(i, "DeliveryDueDate"))
                        .GroupHourly = GridViewDetail.GetRowCellValue(i, "GroupHourly")
                        .DeliveryTime = IIf(GridViewDetail.GetRowCellValue(i, "DeliveryTime") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(i, "DeliveryTime"))
                        .OrderQuantity = GridViewDetail.GetRowCellValue(i, "OrderQuantity")
                        .JenisPacking = GridViewDetail.GetRowCellValue(i, "JenisPacking")
                        .StandarQty = GridViewDetail.GetRowCellValue(i, "StandarQty")
                        .KapasitasMuat = GridViewDetail.GetRowCellValue(i, "KapasitasMuat")
                        .ButuhPacking = GridViewDetail.GetRowCellValue(i, "ButuhPacking")
                        .KebutuhanTruk = GridViewDetail.GetRowCellValue(i, "KebutuhanTruk")
                        .GroupTruk = GridViewDetail.GetRowCellValue(i, "GroupTruk")
                    End With
                    modelHeader.ObjConvertDetails.Add(modelDetail)
                End If
            Next
            If MsgBox("Are You Sure Save Data", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Please wait...")
                If Revised = "No" Then
                    srvPPIC.SaveConverMuat(FrmParent, modelHeader)
                Else
                    srvPPIC.EditConverMuat(FrmParent, modelHeader)
                End If

                SplashScreenManager.CloseForm()
                Dim _now As Date = Date.Today
                GridDtl.DataSource = srvPPIC.GetDataConvertMuatHeader(_now, _now)
                gridViewHeader.BestFitColumns()
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                Me.Hide()
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_Print()
        srvPPIC = New PPICService
        Dim lapBuktiMuatHeader As New DRPPICBuktiMuatHeader
        Dim lapBuktiMuat As New DRPPICBuktiMuat
        Dim dtBuktiMuatHeader As New DataTable
        Dim dtBuktiMuatTemp As New DataTable

        dtBuktiMuatHeader = srvPPIC.LoadReportBuktiMuatHeader(NoUpload)
        dtBuktiMuatTemp = srvPPIC.LoadReportBuktiMuat(NoUpload)

        lapBuktiMuatHeader.DataSource = dtBuktiMuatHeader

        Dim dtBuktiMuat As New DataTable
        dtBuktiMuat = dtBuktiMuatTemp.Clone()
        Dim newRow As DataRow
        Dim UserCode As String = String.Empty
        Dim NoMobil As String = String.Empty

        For Each rows As DataRow In dtBuktiMuatTemp.Rows
            If Not String.IsNullOrEmpty(UserCode) AndAlso UserCode <> rows("UserCode") AndAlso NoMobil = rows("NoMobil") Then
                newRow = dtBuktiMuat.NewRow
                newRow("GroupTruk") = rows("GroupTruk")
                newRow("NoMobil") = rows("NoMobil")
                dtBuktiMuat.Rows.Add(newRow)
            End If

            UserCode = rows("UserCode")
            NoMobil = rows("NoMobil")

            newRow = dtBuktiMuat.NewRow
            newRow("NoUpload") = rows("NoUpload")
            newRow("No") = rows("No")
            newRow("UploadDate") = rows("UploadDate")
            newRow("No") = rows("No")
            newRow("Seq") = rows("Seq")
            newRow("ItemNumber") = rows("ItemNumber")
            newRow("ItemName") = rows("ItemName")
            newRow("Tujuan") = rows("Tujuan")
            newRow("UserCode") = rows("UserCode")
            newRow("PF") = rows("PF")
            newRow("OrderNo") = rows("OrderNo")
            newRow("TglKirim") = rows("TglKirim")
            newRow("GroupHourly") = rows("GroupHourly")
            newRow("Hourly") = rows("Hourly")
            newRow("OrderQuantity") = rows("OrderQuantity")
            newRow("JenisPacking") = rows("JenisPacking")
            newRow("JmlPacking") = rows("JmlPacking")
            newRow("StandarQty") = rows("StandarQty")
            newRow("KapasitasMuat") = rows("KapasitasMuat")
            newRow("ButuhPacking") = rows("ButuhPacking")
            newRow("KebutuhanTruk") = rows("KebutuhanTruk")
            newRow("GroupTruk") = rows("GroupTruk")
            newRow("NoMobil") = rows("NoMobil")
            dtBuktiMuat.Rows.Add(newRow)
        Next

        Dim parameter1 As New Parameter()
        parameter1.Name = "Mobil"
        parameter1.Type = GetType(System.Int32)
        parameter1.MultiValue = True
        parameter1.Description = "Mobil: "
        parameter1.AllowNull = True

        Dim lookupSettings As New DynamicListLookUpSettings()
        lookupSettings.DataSource = dtBuktiMuatHeader
        lookupSettings.DisplayMember = "NoMobil"
        lookupSettings.ValueMember = "NoMobil"

        parameter1.LookUpSettings = lookupSettings
        parameter1.Visible = True
        lapBuktiMuatHeader.Parameters.Add(parameter1)

        lapBuktiMuatHeader.FilterString = "?Mobil Is Null or [NoMobil] In (?Mobil)"
        lapBuktiMuatHeader.RequestParameters = False

        Dim subReport As XRSubreport = CType(lapBuktiMuatHeader.FindControl("XrSubreport1", True), XRSubreport)
        subReport.ReportSource.DataSource = dtBuktiMuat

        Dim PrintTool As ReportPrintTool
        PrintTool = New ReportPrintTool(lapBuktiMuatHeader)
        TryCast(PrintTool.Report, XtraReport).Tag = PrintTool
        PrintTool.ShowPreview(UserLookAndFeel.Default)
    End Sub

    Private Sub btnKonversi_Click(sender As Object, e As EventArgs) Handles btnKonversi.Click
        HitungJumlahTruk()
        Call Proc_EnableButtons(False, True, False, True, True, False, False, False, False, False, False, False)
    End Sub

    Public Sub CreateTable()
        dtDetail = New DataTable
        dtDetail.Columns.AddRange(New DataColumn(18) {New DataColumn("No", GetType(Integer)),
                                                    New DataColumn("Seq", GetType(Integer)),
                                                    New DataColumn("PartNo", GetType(String)),
                                                    New DataColumn("ItemNumber", GetType(String)),
                                                    New DataColumn("ItemName", GetType(String)),
                                                    New DataColumn("Lokasi", GetType(String)),
                                                    New DataColumn("UserCode", GetType(String)),
                                                    New DataColumn("PF", GetType(String)),
                                                    New DataColumn("OrderNo", GetType(String)),
                                                    New DataColumn("DeliveryDueDate", GetType(Date)),
                                                    New DataColumn("GroupHourly", GetType(Integer)),
                                                    New DataColumn("DeliveryTime", GetType(DateTime)),
                                                    New DataColumn("OrderQuantity", GetType(Integer)),
                                                    New DataColumn("JenisPacking", GetType(String)),
                                                    New DataColumn("StandarQty", GetType(Integer)),
                                                    New DataColumn("KapasitasMuat", GetType(Integer)),
                                                    New DataColumn("ButuhPacking", GetType(Integer)),
                                                    New DataColumn("KebutuhanTruk", GetType(Double)),
                                                    New DataColumn("GroupTruk", GetType(Integer))})
    End Sub

    Private Sub GridViewDetail_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridViewDetail.RowStyle
        Dim foreColor As Color = Color.Red
        Dim backColor As Color = Color.DarkGray
        Dim view As GridView = TryCast(sender, GridView)
        If view.RowCount > 0 Then
            Dim ItemNumber As String = view.GetRowCellDisplayText(e.RowHandle, view.Columns("ItemNumber"))
            If ItemNumber = "" Then
                e.Appearance.ForeColor = foreColor
                e.Appearance.BackColor = backColor
                e.HighPriority = True
            End If
        End If
    End Sub

    Private Sub HitungJumlahTruk()
        btnKonversi.Enabled = False
        Dim TotalButuhTruk As Double = 0
        Dim GroupTruk As Integer = 1
        Dim GroupHourly As Integer = 0
        Dim Lokasi As String = String.Empty
        Dim Total As Double = 0

        Dim drTemp As DataRow()
        drTemp = dtConvertMuat.Select("ItemNumber <> ''")

        Dim dtTemp As DataTable = New DataTable()
        dtTemp = dtConvertMuat.Clone()

        Dim newRow As DataRow

        For Each rows As DataRow In drTemp
            Dim NewTruk As Boolean = False
            Dim OrderQuantity As Integer = rows("OrderQuantity")
            Dim StandarQty As Integer = rows("StandarQty")
            Dim ButuhPacking As Integer = Math.Ceiling(OrderQuantity / StandarQty)

            Dim KapasitasMuat As Integer = rows("KapasitasMuat")
            Dim ButuhTruk As Double = ButuhPacking / KapasitasMuat
            TotalButuhTruk += ButuhTruk

            If String.IsNullOrEmpty(Lokasi) Then
                Lokasi = rows("Lokasi")
                GroupHourly = rows("GroupHourly")
            ElseIf Lokasi <> rows("Lokasi") Then
                Lokasi = rows("Lokasi")
                GroupHourly = rows("GroupHourly")
                GroupTruk += 1
                NewTruk = True
                Total = TotalButuhTruk - ButuhTruk
                TotalButuhTruk = ButuhTruk
            Else
                If GroupHourly <> rows("GroupHourly") Then
                    GroupHourly = rows("GroupHourly")
                    GroupTruk += 1
                    NewTruk = True
                    Total = TotalButuhTruk - ButuhTruk
                    TotalButuhTruk = ButuhTruk
                ElseIf TotalButuhTruk > 1 Then
                    GroupTruk += 1
                    NewTruk = True
                    Total = TotalButuhTruk - ButuhTruk
                    TotalButuhTruk = ButuhTruk
                End If
            End If

            If NewTruk Then
                newRow = dtTemp.NewRow
                newRow("KebutuhanTruk") = Total
                dtTemp.Rows.Add(newRow)
            End If

            newRow = dtTemp.NewRow
            newRow("No") = rows("No")
            newRow("Seq") = rows("Seq")
            newRow("PartNo") = rows("PartNo")
            newRow("ItemNumber") = rows("ItemNumber")
            newRow("ItemName") = rows("ItemName")
            newRow("Lokasi") = rows("Lokasi")
            newRow("UserCode") = rows("UserCode")
            newRow("PF") = rows("PF")
            newRow("OrderNo") = rows("OrderNo")
            newRow("DeliveryDueDate") = rows("DeliveryDueDate")
            newRow("GroupHourly") = rows("GroupHourly")
            newRow("DeliveryTime") = rows("DeliveryTime")
            newRow("OrderQuantity") = rows("OrderQuantity")
            newRow("JenisPacking") = rows("JenisPacking")
            newRow("StandarQty") = rows("StandarQty")
            newRow("KapasitasMuat") = rows("KapasitasMuat")
            newRow("ButuhPacking") = ButuhPacking
            newRow("KebutuhanTruk") = ButuhTruk
            newRow("GroupTruk") = GroupTruk
            dtTemp.Rows.Add(newRow)
        Next
        newRow = dtTemp.NewRow
        newRow("KebutuhanTruk") = TotalButuhTruk
        dtTemp.Rows.Add(newRow)

        dtConvertMuat = dtTemp
        GridDetail.DataSource = dtConvertMuat
        GridViewDetail.BestFitColumns()
        txtTotalMobil.Text = GroupTruk
    End Sub

    Private Sub RepOrderQty_EditValueChanged(sender As Object, e As EventArgs) Handles RepOrderQty.EditValueChanged
        btnKonversi.Enabled = True
    End Sub

    Private Sub ExportToExcel(SaveDialog As SaveFileDialog)
        Dim xlapp As Excel.Application
        Dim xlworkbook As Excel.Workbook
        Dim xlworksheet As Excel.Worksheet
        Dim misvalue As Object = Reflection.Missing.Value

        xlapp = New Excel.Application
        xlworkbook = xlapp.Workbooks.Add(misvalue)
        xlworksheet = xlworkbook.Sheets("Sheet1")

        For j = 0 To dtConvertMuat.Columns.Count - 1
            xlworksheet.Cells(1, j + 1) = dtConvertMuat.Columns(j).ToString()
            xlworksheet.Cells(1, j + 1).Font.Bold = True
        Next

        For i = 1 To dtConvertMuat.Rows.Count - 1
            For j = 0 To dtConvertMuat.Columns.Count - 1
                xlworksheet.Cells(i + 1, j + 1) = dtConvertMuat.Rows(i).Item(j)
            Next
        Next
        xlworksheet.SaveAs(SaveDialog.FileName)
        xlworkbook.Close()
        xlapp.Quit()
    End Sub

End Class
