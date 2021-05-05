﻿Imports DevExpress.Utils
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class FrmPPICConvertMuat
    Dim ff_Detail As FrmPPICConvertMuatDetail
    Dim srvPPIC As New PPICService()

    Dim dtResult As New DataTable
    Dim dtUpload As DataTable

    Private Sub FrmPPICConvertMuat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call Proc_EnableButtons(True, False, False, True, False, False, False, False, False, False, False, True)
        LoadGridConvertMuat()
    End Sub

    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal ls_Code3 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        ff_Detail = New FrmPPICConvertMuatDetail(ls_Code, ls_Code2, ls_Code3, Me, GridConvertMuat, GridViewConvertMuat)
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()

        If ls_Code = "" Then
            Dim frmUploadPO As FrmPPICUploadPO
            frmUploadPO = New FrmPPICUploadPO()
            frmUploadPO.StartPosition = FormStartPosition.CenterScreen
            frmUploadPO.ShowDialog()

            With frmUploadPO
                dtUpload = New DataTable
                dtUpload = ._dtResult
                ff_Detail.UploadDate = .UploadDate
                ff_Detail.CustID = .CustID
                ff_Detail.FileName = .FileName
                ff_Detail.Revised = .Revised
            End With

            If frmUploadPO._isUpload AndAlso dtUpload.Rows.Count > 0 Then
                ff_Detail.Proc_EnableButtons(False, False, False, False, False, False, False, False, False, False, False, False)
                ff_Detail.GridDetail.DataSource = dtUpload
                With ff_Detail.GridViewDetail
                    Dim colNo As GridColumn = .Columns("No")
                    colNo.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center

                    Dim colSeq As GridColumn = .Columns("Seq")
                    colSeq.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center

                    Dim colDeliveryTime As GridColumn = .Columns("DeliveryTime")
                    colDeliveryTime.Caption = "Delivery Time (To)"
                    colDeliveryTime.DisplayFormat.FormatType = FormatType.DateTime
                    colDeliveryTime.DisplayFormat.FormatString = "HH:mm"

                    .OptionsBehavior.Editable = False
                    .BestFitColumns()
                End With
            Else
                ff_Detail.Close()
            End If
        End If
    End Sub

    Public Overrides Sub Proc_InputNewData()
        CallFrm()
    End Sub

    Public Overrides Sub Proc_Refresh()
        LoadGridConvertMuat()
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

            LoadGridConvertMuat(firstDay, lastDay)
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub LoadGridConvertMuat(Optional dateFrom As Date = Nothing, Optional dateTo As Date = Nothing)
        Try
            Dim firstDay As Date = dateFrom
            Dim lastDay As Date = dateTo

            If dateFrom = Nothing OrElse dateTo = Nothing Then
                Dim _now As Date = Date.Today
                firstDay = _now
                lastDay = _now
            End If

            dtResult = New DataTable
            dtResult = srvPPIC.GetDataConvertMuatHeader(firstDay, lastDay)
            GridConvertMuat.DataSource = dtResult
            With GridViewConvertMuat
                .BestFitColumns()
                .Columns("UploadDate").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("UploadDate").DisplayFormat.FormatString = "dd-MM-yyyy"
                .Columns("CreateDate").DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
                .Columns("CreateDate").DisplayFormat.FormatString = "dd/MM/yyyy HH:mm : ss"
            End With
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GridConvertMuat_DoubleClick(sender As Object, e As EventArgs) Handles GridConvertMuat.DoubleClick
        Try
            Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
            Dim view As BaseView = GridConvertMuat.GetViewAt(ea.Location)
            If view Is Nothing Then
                Return
            End If
            Dim baseHI As BaseHitInfo = view.CalcHitInfo(ea.Location)
            Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
            If info.InRow OrElse info.InRowCell Then
                Dim noUpload As String = String.Empty
                Dim TotalMobil As Integer = 0
                Dim UploadDate As Date
                Dim selectedRows() As Integer = GridViewConvertMuat.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        noUpload = GridViewConvertMuat.GetRowCellValue(rowHandle, "NoUpload")
                        TotalMobil = GridViewConvertMuat.GetRowCellValue(rowHandle, "TotalMobil")
                        UploadDate = GridViewConvertMuat.GetRowCellValue(rowHandle, "UploadDate")
                    End If
                Next rowHandle

                If GridViewConvertMuat.GetSelectedRows.Length > 0 Then
                    Call CallFrm(noUpload, TotalMobil, UploadDate)
                End If
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

End Class
