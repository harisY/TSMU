Imports DevExpress.XtraSplashScreen
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class FrmMktUploadPriceDetail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim _Tag = New TagModel

    Dim clsGlobal As New GlobalService
    Dim clsUploadPrice As New ClsMktUploadPrice
    Dim clsUploadPriceDetail As New ClsMktUploadPriceDetail

    Dim GridDtl As GridControl
    Dim gridViewPrice As GridView
    Dim dtDetail As DataTable

    Dim noUpload As String
    Public Property CustID() As String
    Public Property Template() As String
    Public Property FileName() As String
    Public Property Revised() As String
    Public Property TotRecordExcel() As String

    Public Sub New()
        InitializeComponent()
    End Sub

    Public Sub New(ByVal strCode As String,
                   ByVal strCode2 As String,
                   ByRef lf_FormParent As Form,
                   ByRef _Grid As GridControl,
                   ByRef _GridView As GridView)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
            fs_Code2 = strCode2
        End If
        GridDtl = _Grid
        gridViewPrice = _GridView
        FrmParent = lf_FormParent
        _Tag = New TagModel
        _Tag.PageIndex = lf_FormParent.Tag.PageIndex
        Tag = _Tag
    End Sub

    Private Sub FrmMktUploadPriceDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False, False)
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
                Me.Text = "PRICE DETAIL"
            Else
                Me.Text = "NEW PRICE DETAIL"
            End If
            LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmMktUploadPrice"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub LoadGridDetail()
        Try
            If isUpdate Then
                Call Proc_EnableButtons(False, False, False, False, True, False, False, False, False, False, False, False)
                clsUploadPrice = New ClsMktUploadPrice
                dtDetail = New DataTable
                dtDetail = clsUploadPrice.GetDataUploadDetail(fs_Code)
                GridDetail.DataSource = dtDetail
                With GridViewDetail
                    .BestFitColumns()
                    .Columns("No").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("OldPrice").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    .Columns("OldPrice").DisplayFormat.FormatString = "n2"
                    .Columns("NewPriceR").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    .Columns("NewPriceR").DisplayFormat.FormatString = "n2"
                    .Columns("NewPriceS").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    .Columns("NewPriceS").DisplayFormat.FormatString = "n2"
                    .Columns("EffectiveDate").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    .Columns("EffectiveDate").DisplayFormat.FormatString = "dd-MM-yyyy"
                End With
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

            If lb_Validated Then
                clsGlobal = New GlobalService
                noUpload = clsGlobal.GetAutoNumber(FrmParent)
                clsUploadPrice = New ClsMktUploadPrice
                With clsUploadPrice
                    .NoUpload = noUpload
                    .CustID = custID
                    .Template = Template
                    .FileName = FileName
                    .Revised = Revised
                    .TotalRecordExcel = TotRecordExcel
                    .TotalRecord = GridViewDetail.RowCount
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
            clsUploadPrice.ObjPriceDetails.Clear()
            For i As Integer = 0 To GridViewDetail.RowCount - 1
                clsUploadPriceDetail = New ClsMktUploadPriceDetail
                With clsUploadPriceDetail
                    .NoUpload = noUpload
                    .CustID = custID
                    .PartNo = GridViewDetail.GetRowCellValue(i, "PartNo")
                    .InvtID = GridViewDetail.GetRowCellValue(i, "InvtID")
                    .Desc = GridViewDetail.GetRowCellValue(i, "PartName")
                    .OldPrice = GridViewDetail.GetRowCellValue(i, "OldPrice")
                    .NewPriceR = GridViewDetail.GetRowCellValue(i, "NewPriceR")
                    .NewPriceS = GridViewDetail.GetRowCellValue(i, "NewPriceS")
                    .StartDate = GridViewDetail.GetRowCellValue(i, "EffectiveDate")
                End With
                clsUploadPrice.ObjPriceDetails.Add(clsUploadPriceDetail)
            Next
            If MsgBox("Are You Sure Upload Data", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                SplashScreenManager.ShowForm(Me, GetType(FrmWait), True, True, False)
                SplashScreenManager.Default.SetWaitFormCaption("Please wait...")

                clsUploadPrice.SaveUpload(FrmParent)

                SplashScreenManager.CloseForm()
                Dim _now As Date = Date.Today
                Dim firstDay As Date = New Date(_now.Year, _now.Month, 1)
                Dim lastDay As Date = New Date(_now.Year, _now.Month, Date.DaysInMonth(_now.Year, _now.Month))
                GridDtl.DataSource = clsUploadPrice.GetDataUploadHeader(firstDay, lastDay)
                gridViewPrice.BestFitColumns()
                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                Me.Hide()
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

End Class
