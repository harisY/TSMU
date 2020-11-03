Imports DevExpress.XtraSplashScreen
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class FrmMktUploadPrice
    Dim ff_Detail As FrmMktUploadPriceDetail
    Dim clsGlobal As New GlobalService
    Dim clsUploadPrice As New ClsMktUploadPrice
    Dim clsUploadPriceDetail As New ClsMktUploadPriceDetail

    Dim dtResult As New DataTable
    Dim dtUpload As DataTable

    Private Sub FrmMktUploadPrice_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call Proc_EnableButtons(False, False, False, True, True, False, False, False, False, False, False, True)
        LoadGridPrice()
    End Sub

    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        ff_Detail = New FrmMktUploadPriceDetail(ls_Code, ls_Code2, Me, GridPrice, GridViewPrice)
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()

        If ls_Code = "" Then
            Dim frmExcelPrice As FrmMktExcelPrice
            frmExcelPrice = New FrmMktExcelPrice()
            frmExcelPrice.StartPosition = FormStartPosition.CenterScreen
            frmExcelPrice.ShowDialog()

            With frmExcelPrice
                dtUpload = New DataTable
                dtUpload = ._dtResult
                ff_Detail.CustID = .CustID
                ff_Detail.Template = .Template
                ff_Detail.FileName = .FileName
            End With

            If frmExcelPrice._isUpload AndAlso dtUpload.Rows.Count > 0 Then
                ff_Detail.Proc_EnableButtons(False, True, False, False, True, False, False, False, False, False, False, False)
                ff_Detail.GridDetail.DataSource = dtUpload
                With ff_Detail.GridViewDetail
                    .BestFitColumns()
                    .Columns("No").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                    .Columns("OldPrice").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    .Columns("OldPrice").DisplayFormat.FormatString = "n2"
                    .Columns("NewPrice").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                    .Columns("NewPrice").DisplayFormat.FormatString = "n2"
                    .Columns("EffectiveDate").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                    .Columns("EffectiveDate").DisplayFormat.FormatString = "dd-MM-yyyy"
                End With
            Else
                ff_Detail.Close()
            End If
        End If
    End Sub

    Public Overrides Sub Proc_Excel()
        CallFrm()
    End Sub

    Public Overrides Sub Proc_Refresh()
        LoadGridPrice()
    End Sub

    Public Overrides Sub Proc_Search()
        Try
            Dim fSearch As New frmSearch()
            With fSearch
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()
            End With

            Dim _now As Date = Date.Today
            Dim firstDay As Date = If(IsDBNull(fSearch.TglDari), New Date(_now.Year, _now.Month, 1), fSearch.TglDari)
            Dim lastDay As Date = If(IsDBNull(fSearch.TglSampai), _now.AddMonths(1).AddDays(-1), fSearch.TglSampai)

            LoadGridPrice(firstDay, lastDay)
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub LoadGridPrice(Optional dateFrom As Date = Nothing, Optional dateTo As Date = Nothing)
        Try
            Dim firstDay As Date = dateFrom
            Dim lastDay As Date = dateTo

            If dateFrom = Nothing OrElse dateTo = Nothing Then
                Dim _now As Date = Date.Today
                firstDay = New Date(_now.Year, _now.Month, 1)
                lastDay = New Date(_now.Year, _now.Month, Date.DaysInMonth(_now.Year, _now.Month))
            End If

            clsUploadPrice = New ClsMktUploadPrice
            dtResult = New DataTable
            dtResult = clsUploadPrice.GetDataUploadHeader(firstDay, lastDay)
            GridPrice.DataSource = dtResult
            With GridViewPrice
                .BestFitColumns()
                .Columns("UploadDate").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("UploadDate").DisplayFormat.FormatString = "dd-MM-yyyy"
            End With
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GridPrice_DoubleClick(sender As Object, e As EventArgs) Handles GridPrice.DoubleClick
        Try
            Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
            Dim view As BaseView = GridPrice.GetViewAt(ea.Location)
            If view Is Nothing Then
                Return
            End If
            Dim baseHI As BaseHitInfo = view.CalcHitInfo(ea.Location)
            Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
            If info.InRow OrElse info.InRowCell Then
                Dim noUpload As String = String.Empty
                Dim selectedRows() As Integer = GridViewPrice.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        noUpload = GridViewPrice.GetRowCellValue(rowHandle, "NoUpload")
                    End If
                Next rowHandle

                If GridViewPrice.GetSelectedRows.Length > 0 Then
                    Call CallFrm(noUpload, "")
                End If
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

End Class
