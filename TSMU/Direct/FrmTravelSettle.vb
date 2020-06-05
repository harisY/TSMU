Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class FrmTravelSettle
    Dim ff_Detail As FrmTravelSettleDetail
    Dim ff_Detail1 As FrmSuspendSettleDetailDirect
    Dim cls_SettHeader As TravelSettleHeaderModel
    Dim cls_SettDetail As New TravelSettleDetailModel

    Dim dtGrid As DataTable
    Dim TabPage As String

    Private Sub FrmTravelSettle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call Proc_EnableButtons(True, False, True, True, True, False, False, False, False, False, False)
        XtraTabControl1.SelectedTabPage = TabPageReq
        TabPage = XtraTabControl1.SelectedTabPage.Name
        Call LoadGridRequest()
    End Sub

    Private Sub LoadGridRequest()
        Try
            cls_SettHeader = New TravelSettleHeaderModel
            dtGrid = cls_SettHeader.GetDataGridRequest()
            GridRequest.DataSource = dtGrid
            GridCellFormat(GridViewRequest)
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadGridSettle()
        Try
            cls_SettHeader = New TravelSettleHeaderModel
            dtGrid = cls_SettHeader.GetTravelSettHeader()
            GridSettle.DataSource = dtGrid
            GridCellFormat(GridViewSettle)
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadGrid2()
        'Try
        '    ObjSettle = New TravelHeaderModel
        'dtGrid2 = ObjSettle.GetDataGrid2()
        '    GridControl1.DataSource = dtGrid2
        '    With GridView2
        '        .Columns(0).Visible = False
        '        .BestFitColumns()
        '    End With
        '    GridCellFormat(GridView2)
        'Catch ex As Exception
        '    Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        '    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        'End Try
    End Sub

    Public Overrides Sub Proc_InputNewData()
        If TabPage = "TabPageReq" Then
            If GridViewRequest.SelectedRowsCount > 0 Then
                CallFrm()
            Else
                MessageBox.Show("Harap pilih dulu travelnya", "Warning",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Exclamation,
                                    MessageBoxDefaultButton.Button1)
            End If
        End If

    End Sub

    Public Overrides Sub Proc_Refresh()
        bs_Filter = ""
        If TabPage = "TabPageReq" Then
            LoadGridRequest()
        ElseIf TabPage = "TabPageSett" Then
            LoadGridSettle()
        Else
            LoadGrid2()
        End If
    End Sub

    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        ff_Detail = New FrmTravelSettleDetail(ls_Code, ls_Code2, Me, li_Row, GridViewRequest, GridRequest)
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    'Private Sub CallFrmDirect(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
    '    If ff_Detail1 IsNot Nothing AndAlso ff_Detail1.Visible Then
    '        If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
    '            Exit Sub
    '        End If
    '        ff_Detail1.Close()
    '    End If
    '    ff_Detail1 = New FrmSuspendSettleDetailDirect(ls_Code, ls_Code2, Me, li_Row, Grid)
    '    ff_Detail1.MdiParent = FrmMain
    '    ff_Detail1.StartPosition = FormStartPosition.CenterScreen
    '    ff_Detail1.Show()
    'End Sub

    Public Overrides Sub Proc_DeleteData()
        Try
            Dim TravelSettleID As String = String.Empty
            Dim selectedRows() As Integer = GridViewSettle.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    TravelSettleID = GridViewSettle.GetRowCellValue(rowHandle, "TravelSettleID").ToString()
                    cls_SettHeader.TravelSettleID = TravelSettleID
                End If
            Next rowHandle

            dtGrid = New DataTable
            cls_SettDetail.TravelSettleID = TravelSettleID
            dtGrid = cls_SettDetail.GetTravelSettDetailByID

            cls_SettHeader.ObjSettleDetail.Clear()
            If dtGrid.Rows.Count > 0 Then
                For i As Integer = 0 To dtGrid.Rows.Count - 1
                    cls_SettDetail = New TravelSettleDetailModel
                    With cls_SettDetail
                        .TravelSettleID = TravelSettleID
                        .NoRequest = dtGrid.Rows(i).Item(0)
                        .Nama = dtGrid.Rows(i).Item(1)
                    End With
                    cls_SettHeader.ObjSettleDetail.Add(cls_SettDetail)
                Next
            End If

            cls_SettHeader.DeleteDataTravelSettle()

            tsBtn_refresh.PerformClick()

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Dim ID As String
    Dim suspendid As String
    Dim suspend1 As String
    Private Sub FrmSuspendSettle_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                Dim selectedRows() As Integer = GridViewSettle.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        ID = GridViewSettle.GetRowCellValue(rowHandle, "ID")
                        suspendid = GridViewSettle.GetRowCellValue(rowHandle, "SettleID")
                    End If
                Next rowHandle

                If GridViewSettle.GetSelectedRows.Length > 0 Then
                    Call CallFrm(ID,
                         suspendid,
                         GridViewSettle.RowCount)
                End If

            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GridSettle_DoubleClick(sender As Object, e As EventArgs) Handles GridSettle.DoubleClick
        Try
            Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
            Dim view As BaseView = GridSettle.GetViewAt(ea.Location)
            If view Is Nothing Then
                Return
            End If
            Dim baseHI As BaseHitInfo = view.CalcHitInfo(ea.Location)
            Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
            If info.InRow OrElse info.InRowCell Then

                Dim TravelSettID As String = String.Empty
                Dim selectedRows() As Integer = GridViewSettle.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        TravelSettID = GridViewSettle.GetRowCellValue(rowHandle, "TravelSettleID")
                    End If
                Next rowHandle

                If GridViewSettle.GetSelectedRows.Length > 0 Then
                    'Dim objGrid As DataGridView = sender
                    Call CallFrm(TravelSettID,
                         GridViewSettle.RowCount)
                End If
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        TabPage = XtraTabControl1.SelectedTabPage.Name()
        If TabPage = "TabPageReq" Then
            Call Proc_EnableButtons(True, False, False, True, True, False, False, False)
            LoadGridRequest()
        ElseIf TabPage = "TabPageSett" Then
            Call Proc_EnableButtons(False, False, True, True, True, False, False, False)
            LoadGridSettle()
        Else
            Call Proc_EnableButtons(True, False, True, True, False, False, False, False)
            LoadGrid2()
        End If
    End Sub

End Class
