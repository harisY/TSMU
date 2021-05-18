Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.Utils

Public Class FrmPPICConvertMuatDetail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim _Tag = New TagModel

    Dim clsGlobal As New GlobalService
    Dim srvHR As New PPICService
    Dim modelHeader As PPICConvertMuatHeaderModel
    Dim modelDetail As PPICConvertMuatDetailModel

    Dim GridDtl As GridControl
    Dim gridViewHeader As GridView
    Dim dtDetail As DataTable

    Dim noUpload As String
    Public Property CustID() As String
    Public Property UploadDate() As Date
    Public Property FileName() As String
    Public Property Revised() As String

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal strCode As String,
                   ByVal strCode2 As String,
                   ByVal strCode3 As String,
                   ByRef lf_FormParent As Form,
                   ByRef _Grid As GridControl,
                   ByRef _GridView As GridView)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
            fs_Code2 = strCode2
            UploadDate = strCode3
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
                Call Proc_EnableButtons(False, False, False, True, True, False, False, False, False, False, False, False)
                btnKonversi.Enabled = False
                srvHR = New PPICService
                dtDetail = srvHR.GetDataConvertMuatDetail(fs_Code)
                GridDetail.DataSource = dtDetail
                With GridViewDetail
                    Dim colNo As GridColumn = .Columns("No")
                    colNo.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center

                    Dim colSeq As GridColumn = .Columns("Seq")
                    colSeq.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center

                    Dim colDeliveryTime As GridColumn = .Columns("DeliveryTime")
                    colDeliveryTime.Caption = "Delivery Time (To)"
                    colDeliveryTime.DisplayFormat.FormatType = FormatType.DateTime
                    colDeliveryTime.DisplayFormat.FormatString = "HH:mm"

                    .BestFitColumns()
                    If UploadDate = Date.Today Then
                        .OptionsBehavior.Editable = True
                    Else
                        .OptionsBehavior.Editable = False
                    End If
                End With
                txtTotalMobil.Text = fs_Code2

            Else
                txtTotalMobil.Text = 0
                GridDetail.DataSource = dtDetail
                GridViewDetail.BestFitColumns()
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Public Overrides Sub Proc_Excel()
        Try
            If GridViewDetail.RowCount > 0 Then
                Dim save As New SaveFileDialog With {
                    .Filter = "Excel File|*.xls",
                    .Title = "Save an Excel File"
                }
                If save.ShowDialog = DialogResult.OK Then
                    GridDetail.ExportToXls(save.FileName)
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
                clsGlobal = New GlobalService
                noUpload = clsGlobal.GetAutoNumber(FrmParent)
                srvHR = New PPICService
                modelHeader = New PPICConvertMuatHeaderModel
                With modelHeader
                    .NoUpload = noUpload
                    .UploadDate = UploadDate
                    .CustID = CustID
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
                modelDetail = New PPICConvertMuatDetailModel
                With modelDetail
                    .NoUpload = noUpload
                    .Seq = GridViewDetail.GetRowCellValue(i, "Seq")
                    .ItemNumber = GridViewDetail.GetRowCellValue(i, "ItemNumber")
                    .ItemName = GridViewDetail.GetRowCellValue(i, "ItemName")
                    .UserCode = GridViewDetail.GetRowCellValue(i, "UserCode")
                    .PF = GridViewDetail.GetRowCellValue(i, "PF")
                    .OrderNo = GridViewDetail.GetRowCellValue(i, "OrderNo")
                    .DeliveryDueDate = IIf(GridViewDetail.GetRowCellValue(i, "DeliveryDueDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(i, "DeliveryDueDate"))
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
            Next
            If MsgBox("Are You Sure Upload Data", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Please wait...")

                srvHR.SaveConverMuat(FrmParent, modelHeader)

                SplashScreenManager.CloseForm()
                Dim _now As Date = Date.Today
                GridDtl.DataSource = srvHR.GetDataConvertMuatHeader(_now, _now)
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

    Private Sub btnKonversi_Click(sender As Object, e As EventArgs) Handles btnKonversi.Click
        btnKonversi.Enabled = False
        Dim TotalButuhTruk As Double = 0
        Dim GroupTruk As Integer = 1
        For i As Integer = 0 To GridViewDetail.RowCount - 1
            Dim OrderQuantity As Integer = GridViewDetail.GetRowCellValue(i, "OrderQuantity")
            Dim StandarQty As Integer = GridViewDetail.GetRowCellValue(i, "StandarQty")
            Dim ButuhPacking As Integer = Math.Ceiling(OrderQuantity / StandarQty)

            GridViewDetail.SetRowCellValue(i, "ButuhPacking", ButuhPacking)

            Dim KapasitasMuat As Integer = GridViewDetail.GetRowCellValue(i, "KapasitasMuat")
            Dim ButuhTruk As Double = ButuhPacking / KapasitasMuat
            TotalButuhTruk += ButuhTruk

            GridViewDetail.SetRowCellValue(i, "KebutuhanTruk", ButuhTruk)

            If TotalButuhTruk > 1 Then
                GroupTruk += 1
                TotalButuhTruk = ButuhTruk
            End If

            GridViewDetail.SetRowCellValue(i, "GroupTruk", GroupTruk)
        Next
        txtTotalMobil.Text = GroupTruk
        Call Proc_EnableButtons(False, True, False, True, True, False, False, False, False, False, False, False)
    End Sub

    Public Sub CreateTable()
        dtDetail = New DataTable
        dtDetail.Columns.AddRange(New DataColumn(15) {New DataColumn("No", GetType(Integer)),
                                                    New DataColumn("Seq", GetType(Integer)),
                                                    New DataColumn("ItemNumber", GetType(String)),
                                                    New DataColumn("ItemName", GetType(String)),
                                                    New DataColumn("UserCode", GetType(String)),
                                                    New DataColumn("PF", GetType(String)),
                                                    New DataColumn("OrderNo", GetType(Integer)),
                                                    New DataColumn("DeliveryDueDate", GetType(Date)),
                                                    New DataColumn("DeliveryTime", GetType(DateTime)),
                                                    New DataColumn("OrderQuantity", GetType(Integer)),
                                                    New DataColumn("JenisPacking", GetType(String)),
                                                    New DataColumn("StandarQty", GetType(Integer)),
                                                    New DataColumn("KapasitasMuat", GetType(Integer)),
                                                    New DataColumn("ButuhPacking", GetType(Integer)),
                                                    New DataColumn("KebutuhanTruk", GetType(Double)),
                                                    New DataColumn("GroupTruk", GetType(Integer))})
    End Sub

End Class
