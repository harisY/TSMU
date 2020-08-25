Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class FrmTravelRequest
    Dim ff_Detail As FrmTravelRequestDetail
    Dim dtGrid As DataTable
    Dim dtRequestAll As DataTable
    Dim fc_Class As New TravelRequestModel
    Dim _ServiceGlobal As GlobalService
    Dim grid__ As GridControl
    Dim TabPage As String
    Dim _level As Integer = 0

    Public Overrides Sub Proc_InputNewData()
        CallFrm()
    End Sub

    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        If ls_Code2 = "TabPageApproved" Then
            grid__ = GridApprovedReq
        ElseIf ls_Code2 = "TabPageProgress" Then
            grid__ = GridProgress
        ElseIf ls_Code2 = "TabPageRequestAll" Then
            grid__ = GridRequestAll
        Else
            grid__ = GridRequest
        End If
        ff_Detail = New FrmTravelRequestDetail(ls_Code, ls_Code2, Me, li_Row, grid__, _level)
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    Private Sub FrmTravelRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        levelApprove()
        TabPage = XtraTabControl1.SelectedTabPage.Name()
        aksesData()
        'LoadGridRequest()
    End Sub

    Private Sub levelApprove()
        Try
            _ServiceGlobal = New GlobalService
            _level = _ServiceGlobal.GetLevel(Me)
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub aksesData()
        If TabPage = "TabPageRequest" Then
            If _level = 1 Then
                Call Proc_EnableButtons(True, False, True, True, False, False, False, False, False, False, False, False)
            ElseIf _level > 1 Then
                Call Proc_EnableButtons(False, False, False, True, False, False, False, False, False, False, False, False)
            Else
                Call Proc_EnableButtons(False, False, False, False, False, False, False, False, False, False, False, False)
            End If
            LoadGridRequest()
        ElseIf TabPage = "TabPageProgress" Then
            Call Proc_EnableButtons(False, False, False, True, False, False, False, False, False, False, False, False)
            LoadGridProgressReq()
        Else
            Call Proc_EnableButtons(False, False, False, True, False, False, False, False, False, False, False, True)
            'LoadGridRequestAll()
        End If

    End Sub

    Private Sub LoadGridRequest()
        Try
            dtGrid = New DataTable
            dtGrid = fc_Class.GetTravelRequest(Me.Name, _level)
            GridRequest.DataSource = dtGrid
            GridCellFormat(GridViewRequest)
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadGridApprovedReq()
        Try
            dtGrid = fc_Class.GetTravelApproved()
            GridApprovedReq.DataSource = dtGrid
            GridCellFormat(GridViewApproved)
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadGridProgressReq()
        Try
            dtGrid = fc_Class.GetTravelProgress(_level)
            GridProgress.DataSource = dtGrid
            GridCellFormat(GridViewProgress)
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadGridRequestAll()
        Try
            'dtRequestAll = fc_Class.GetTravelRequestAll()
            'GridRequestAll.DataSource = dtGrid
            'GridCellFormat(GridViewRequestAll)
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_SaveData()
        Try
            Dim NoRequest As String
            Dim Status As String = String.Empty
            Dim Approved As String = String.Empty
            Dim Comment As String = String.Empty
            Dim dtApproved As New DataTable
            dtApproved.Columns.Add("NoRequest", GetType(String))
            dtApproved.Columns.Add("Status", GetType(String))
            dtApproved.Columns.Add("Approved", GetType(String))
            dtApproved.Columns.Add("Comment", GetType(String))
            For i As Integer = 0 To GridViewApproved.RowCount - 1
                NoRequest = IIf(GridViewApproved.GetRowCellValue(i, "NoRequest") Is DBNull.Value, "", GridViewApproved.GetRowCellValue(i, "NoRequest"))
                Status = IIf(GridViewApproved.GetRowCellValue(i, "Status") Is DBNull.Value, "", GridViewApproved.GetRowCellValue(i, "Status"))
                Approved = IIf(GridViewApproved.GetRowCellValue(i, "Approved") Is DBNull.Value, "", GridViewApproved.GetRowCellValue(i, "Approved"))
                Comment = IIf(GridViewApproved.GetRowCellValue(i, "Comment") Is DBNull.Value, "", GridViewApproved.GetRowCellValue(i, "Comment"))
                If Approved <> "" Then
                    If (Approved = "REVISED" Or Approved = "CANCEL") And Comment = "" Then
                        Err.Raise(ErrNumber, , "Revised atau Cancel Comment Harus Diisi !")
                    End If

                    If Approved = "REVISED" Then
                        Status = "CREATE"
                    ElseIf Approved = "CANCEL" Then
                        Status = "CLOSE"
                    End If
                    Dim row_ As DataRow = dtApproved.NewRow
                    row_("NoRequest") = NoRequest
                    row_("Status") = Status
                    row_("Approved") = Approved
                    row_("Comment") = Comment
                    dtApproved.Rows.Add(row_)
                End If
            Next
            If dtApproved.Rows.Count > 0 Then
                fc_Class.UpdateStatusApprovedMulti(dtApproved)
                MessageBox.Show("Data Updated.")
                LoadGridApprovedReq()
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Public Overrides Sub Proc_DeleteData()
        Dim ID As String = String.Empty
        Dim status As String = String.Empty
        Try
            Dim selectedRows() As Integer = GridViewRequest.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    ID = GridViewRequest.GetRowCellValue(rowHandle, "NoRequest")
                    status = GridViewRequest.GetRowCellValue(rowHandle, "Status")
                End If
            Next rowHandle

            If status = "OPEN" Then
                MessageBox.Show("No Request " & ID & " sudah dilakukan Invoice Ticket !", "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
            Else
                fc_Class.NoRequest = ID
                fc_Class.Delete()
                Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)
                tsBtn_refresh.PerformClick()
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        If TabPage = "TabPageRequest" Then
            LoadGridRequest()
        ElseIf TabPage = "TabPageApproved" Then
            LoadGridApprovedReq()
        ElseIf TabPage = "TabPageProgress" Then
            LoadGridProgressReq()
        Else
            'LoadGridRequestAll()
        End If
    End Sub

    Public Overrides Sub Proc_Search()
        Try
            Dim fSearch As New frmSearch
            With fSearch
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()

                Dim filterParam As String
                filterParam = "AND ( Date >= " & QVal(If(IsDBNull(.TglDari), Date.Today, .TglDari)) & " AND Date <= " & QVal(If(IsDBNull(.TglSampai), Date.Today, .TglSampai)) & " )"
                dtRequestAll = fc_Class.GetTravelRequestAll(filterParam)
                GridRequestAll.DataSource = dtRequestAll
                GridCellFormat(GridViewRequestAll)
            End With
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub GridRequest_DoubleClick(sender As Object, e As EventArgs) Handles GridRequest.DoubleClick
        Try
            Dim NoRequest = String.Empty
            Dim selectedRows() As Integer = GridViewRequest.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    NoRequest = GridViewRequest.GetRowCellValue(rowHandle, "NoRequest")
                End If
            Next rowHandle

            If GridViewRequest.GetSelectedRows.Length > 0 Then
                Call CallFrm(NoRequest,
                         TabPage,
                         GridViewRequest.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GridApprovedReq_DoubleClick(sender As Object, e As EventArgs) Handles GridApprovedReq.DoubleClick
        Try
            Dim NoRequest = String.Empty
            Dim selectedRows() As Integer = GridViewApproved.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    NoRequest = GridViewApproved.GetRowCellValue(rowHandle, "NoRequest")
                End If
            Next rowHandle

            If GridViewApproved.GetSelectedRows.Length > 0 Then
                Call CallFrm(NoRequest,
                         TabPage,
                         GridViewApproved.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GridGridProgress_DoubleClick(sender As Object, e As EventArgs) Handles GridProgress.DoubleClick
        Try
            Dim NoRequest = String.Empty
            Dim selectedRows() As Integer = GridViewProgress.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    NoRequest = GridViewProgress.GetRowCellValue(rowHandle, "NoRequest")
                End If
            Next rowHandle

            If GridViewProgress.GetSelectedRows.Length > 0 Then
                Call CallFrm(NoRequest,
                         TabPage,
                         GridViewProgress.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GridRequestAll_DoubleClick(sender As Object, e As EventArgs) Handles GridRequestAll.DoubleClick
        Try
            Dim NoRequest = String.Empty
            Dim selectedRows() As Integer = GridViewRequestAll.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    NoRequest = GridViewRequestAll.GetRowCellValue(rowHandle, "NoRequest")
                End If
            Next rowHandle

            If GridViewRequestAll.GetSelectedRows.Length > 0 Then
                Call CallFrm(NoRequest,
                         TabPage,
                         GridViewRequest.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        TabPage = XtraTabControl1.SelectedTabPage.Name()
        aksesData()
    End Sub

    Private Sub CApproved_EditValueChanged(sender As Object, e As EventArgs) Handles CApproved.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub CComment_EditValueChanged(sender As Object, e As EventArgs) Handles CComment.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If Not String.IsNullOrEmpty(txtValue.Text) Then
            Dim filterParam As String
            If txtValue.Text = "*" Then
                filterParam = ""
            Else
                filterParam = "AND " + Replace(txtColumnName.Text, " ", "") + " = " + QVal(txtValue.Text)
            End If
            dtRequestAll = fc_Class.GetTravelRequestAll(filterParam)
            GridRequestAll.DataSource = dtRequestAll
            GridCellFormat(GridViewRequestAll)
        Else
            GridRequestAll.DataSource = Nothing
        End If

    End Sub

End Class
