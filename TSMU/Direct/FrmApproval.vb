Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class FrmApproval
    Dim ff_Detail As FrmApprovalDetail
    Dim ApprovalEntertain As FrmApprovalEntertain
    Dim dtGrid As DataTable
    Dim ObjSuspend As New SuspendApprovalHeaderModel

    Private Sub FrmApproval_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False, False)
        XtraTabControl1.SelectedTabPage = XtraTabPage1
    End Sub
    Private Sub LoadGrid()
        Try
            dtGrid = ObjSuspend.GetDataGrid()
            Grid.DataSource = dtGrid
            With GridView1
                .Columns(0).Visible = False
                .BestFitColumns()
            End With
            GridCellFormat(GridView1)

            Dim dt As New DataTable
            dt = ObjSuspend.GetDataGrid2()
            Grid2.DataSource = dt
            With GridView2
                .Columns(0).Visible = False
                .BestFitColumns()
            End With
            GridCellFormat(GridView2)
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadGrid2()
        Try
            ''ObjSuspend = New SuspendHeaderModel
            dtGrid = ObjSuspend.GetDataGrid()
            Grid.DataSource = dtGrid
            GridView1.BestFitColumns()

            With GridView1
                .Columns(0).Visible = False
            End With
            GridCellFormat(GridView1)
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Public Overrides Sub Proc_InputNewData()
        CallFrm()
    End Sub
    Public Overrides Sub Proc_Refresh()
        bs_Filter = ""
        Call LoadGrid()
    End Sub

    Public Overrides Sub Proc_SaveData()
        Try
            Dim query As String
            'Dim checked As Boolean
            Dim suspendid As String
            Dim status As String
            Dim a As Boolean
            Dim ObjSuspend As New SuspendApprovalHeaderModel
            Dim level As Integer = ObjSuspend.GetUsernameLevel
            For i As Integer = 0 To GridView1.RowCount - 1
                suspendid = GridView1.GetRowCellValue(i, "SuspendID")
                a = GridView1.GetRowCellValue(i, "ceklist")
                status = GridView1.GetRowCellValue(i, "Status")
                If a = True Then
                    'a = False
                    'suspendid = GridView1.GetRowCellValue(i, "SuspendID")
                    'status = GridView1.GetRowCellValue(i, "Status")
                    'query = "update suspend_header set ceklist='1',Status='Approved',State=1 where SuspendID='" & suspendid & "' "
                    'ExecQueryByCommandSolomon(query)
                    ObjSuspend.ApproveData(suspendid, level)
                Else
                    'a = True
                    'query = "update suspend_header set ceklist='" & a & "',Status='Approved',State=1 where SuspendID='" & suspendid & "' "
                    'query = "update suspend_header set ceklist='False',Status='Open',State=0 where SuspendID='" & suspendid & "' "
                    'MainModul.ExecQueryByCommandSolomon(query)
                End If
            Next
        Catch ex As Exception
            Throw
        End Try
        MessageBox.Show("Data Updated.")
        ''GridView1.Columns.Clear()
        ''GridView1.RefreshData()
        LoadGrid2()
    End Sub

    Private Sub CallFrmEntertain(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ApprovalEntertain IsNot Nothing AndAlso ApprovalEntertain.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ApprovalEntertain.Close()
        End If
        ApprovalEntertain = New FrmApprovalEntertain(ls_Code, ls_Code2, Me, li_Row, Grid)
        ApprovalEntertain.MdiParent = MenuUtamaForm
        ApprovalEntertain.StartPosition = FormStartPosition.CenterScreen
        ApprovalEntertain.Show()
    End Sub
    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        ff_Detail = New FrmApprovalDetail(ls_Code, ls_Code2, Me, li_Row, Grid)
        ff_Detail.MdiParent = MenuUtamaForm
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    Dim ID As String
    Dim suspendid As String
    Private Sub FrmApproval_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                If XtraTabControl1.SelectedTabPage Is XtraTabPage1 Then
                    Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                    For Each rowHandle As Integer In selectedRows
                        If rowHandle >= 0 Then
                            ID = GridView1.GetRowCellValue(rowHandle, "SuspendHeaderID")
                            suspendid = GridView1.GetRowCellValue(rowHandle, "SuspendID")
                        End If
                    Next rowHandle

                    If GridView1.GetSelectedRows.Length > 0 Then
                        If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Tipe") = "S" Then
                            Call CallFrm(ID,
                             suspendid,
                             GridView1.RowCount)
                        Else
                            Call CallFrmEntertain(ID,
                             suspendid,
                             GridView1.RowCount)
                        End If
                    End If
                Else
                    Dim selectedRows1() As Integer = GridView2.GetSelectedRows()
                    For Each rowHandle As Integer In selectedRows1
                        If rowHandle >= 0 Then
                            ID = GridView2.GetRowCellValue(rowHandle, "SuspendHeaderID")
                            suspendid = GridView2.GetRowCellValue(rowHandle, "SuspendID")
                        End If
                    Next rowHandle

                    If GridView2.GetSelectedRows.Length > 0 Then
                        If GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Tipe") = "S" Then
                            Call CallFrm(ID,
                             suspendid,
                             GridView2.RowCount)
                        Else
                            Call CallFrmEntertain(ID,
                                 suspendid,
                                 GridView2.RowCount)
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick, Grid2.DoubleClick
        Try
            If XtraTabControl1.SelectedTabPage Is XtraTabPage1 Then
                Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
                'Dim view As GridView = TryCast(sender, GridView)
                Dim view As BaseView = Grid.GetViewAt(ea.Location)
                If view Is Nothing Then
                    Return
                End If
                Dim baseHI As BaseHitInfo = view.CalcHitInfo(ea.Location)
                Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
                If info.InRow OrElse info.InRowCell Then

                    ID = String.Empty
                    suspendid = String.Empty
                    Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                    For Each rowHandle As Integer In selectedRows
                        If rowHandle >= 0 Then
                            ID = GridView1.GetRowCellValue(rowHandle, "SuspendHeaderID")
                            suspendid = GridView1.GetRowCellValue(rowHandle, "SuspendID")
                        End If
                    Next rowHandle

                    If GridView1.GetSelectedRows.Length > 0 Then
                        'Dim objGrid As DataGridView = sender
                        If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Tipe") = "S" Then
                            Call CallFrm(ID,
                             suspendid,
                             GridView1.RowCount)
                        Else
                            Call CallFrmEntertain(ID,
                             suspendid,
                             GridView1.RowCount)
                        End If
                    End If


                End If
            Else
                Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
                'Dim view As GridView = TryCast(sender, GridView)
                Dim view As BaseView = Grid2.GetViewAt(ea.Location)
                If view Is Nothing Then
                    Return
                End If
                Dim baseHI As BaseHitInfo = view.CalcHitInfo(ea.Location)
                Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
                If info.InRow OrElse info.InRowCell Then

                    ID = String.Empty
                    suspendid = String.Empty
                    Dim selectedRows() As Integer = GridView2.GetSelectedRows()
                    For Each rowHandle As Integer In selectedRows
                        If rowHandle >= 0 Then
                            ID = GridView2.GetRowCellValue(rowHandle, "SuspendHeaderID")
                            suspendid = GridView2.GetRowCellValue(rowHandle, "SuspendID")
                        End If
                    Next rowHandle

                    If GridView2.GetSelectedRows.Length > 0 Then
                        'Dim objGrid As DataGridView = sender
                        If GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Tipe") = "S" Then
                            Call CallFrm(ID,
                             suspendid,
                             GridView2.RowCount)
                        Else
                            Call CallFrmEntertain(ID,
                             suspendid,
                             GridView2.RowCount)
                        End If
                    End If


                End If
            End If


        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub SimpleButton1_Click(sender As Object, e As EventArgs) Handles SimpleButton1.Click
        Try
            Dim query As String
            Dim checked As Boolean
            Dim suspendid As String
            Dim a As Boolean
            For i As Integer = 0 To GridView1.RowCount - 1
                suspendid = GridView1.GetRowCellValue(i, "SuspendID")
                checked = GridView1.GetRowCellValue(i, "Check")
                a = GridView1.GetRowCellValue(i, "Check")
                If a = True Then
                    a = False
                    checked = GridView1.GetRowCellValue(i, "Check")
                    suspendid = GridView1.GetRowCellValue(i, "SuspendID")
                    query = "update suspend_header set ceklist='" & checked & "' where suspendid='" & suspendid & "' "
                    MainModul.ExecQueryByCommandSolomon(query)
                Else
                    a = True
                End If
            Next
        Catch ex As Exception
            Throw
        End Try
        MessageBox.Show("Data Updated.")
        GridView1.Columns.Clear()
        GridView1.RefreshData()
        LoadGrid()
    End Sub

    Private Sub RepositoryItemCheckEdit2_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit2.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub
End Class
