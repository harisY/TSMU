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

    Dim TabPage As String

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
        ff_Detail = New FrmTravelRequestDetail(ls_Code, ls_Code2, Me, li_Row, GridRequest)
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    Private Sub FrmTravelRequest_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call Proc_EnableButtons(True, False, True, True, True, False, False, False)
        XtraTabControl1.SelectedTabPage = TabPageRequest
        TabPage = XtraTabControl1.SelectedTabPage.Name
        LoadGridRequest()
    End Sub

    Private Sub LoadGridRequest()
        Try
            dtGrid = fc_Class.GetTravelRequest()
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

    Private Sub LoadGridRequestAll()
        Try
            dtRequestAll = fc_Class.GetTravelRequestAll()
            'GridRequestAll.DataSource = dtGrid
            'GridCellFormat(GridViewRequestAll)
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_SaveData()

        Dim flag As Boolean = False
        Try
            Dim Approved As String = String.Empty
            Dim Comment As String = String.Empty
            Dim NoRequest As String
            fc_Class = New TravelRequestModel
            For i As Integer = 0 To GridViewApproved.RowCount - 1
                Approved = IIf(GridViewApproved.GetRowCellValue(i, "Approved") Is DBNull.Value, "", GridViewApproved.GetRowCellValue(i, "Approved"))
                Comment = IIf(GridViewApproved.GetRowCellValue(i, "Comment") Is DBNull.Value, "", GridViewApproved.GetRowCellValue(i, "Comment"))
                NoRequest = IIf(GridViewApproved.GetRowCellValue(i, "NoRequest") Is DBNull.Value, "", GridViewApproved.GetRowCellValue(i, "NoRequest"))
                If Approved <> "" Then
                    fc_Class.Approved = Approved
                    fc_Class.Comment = Comment
                    fc_Class.UpdateStatusHeader(NoRequest)
                    flag = True
                End If
            Next
        Catch ex As Exception
            Throw
        End Try
        If flag Then
            MessageBox.Show("Data Updated.")
            LoadGridApprovedReq()
        End If

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
                MessageBox.Show("No Request " & ID & " sudah di Approve oleh atasan !", "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
            Else
                fc_Class.NoRequest = ID
                fc_Class.Delete()

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
        Else
            LoadGridRequestAll()
        End If
    End Sub

    Private Sub GridRequest_DoubleClick(sender As Object, e As EventArgs) Handles GridRequest.DoubleClick
        Try
            Dim NoRequest = String.Empty
            Dim NIK = String.Empty
            Dim selectedRows() As Integer = GridViewRequest.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    NoRequest = GridViewRequest.GetRowCellValue(rowHandle, "NoRequest")
                    NIK = GridViewRequest.GetRowCellValue(rowHandle, "NIK")
                End If
            Next rowHandle

            If GridViewRequest.GetSelectedRows.Length > 0 Then
                Call CallFrm(NoRequest,
                         NIK,
                         GridViewRequest.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub XtraTabControl1_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles XtraTabControl1.SelectedPageChanged
        TabPage = XtraTabControl1.SelectedTabPage.Name()
        If TabPage = "TabPageRequest" Then
            Call Proc_EnableButtons(True, False, True, True, True, False, False, False)
            LoadGridRequest()
        ElseIf TabPage = "TabPageApproved" Then
            Call Proc_EnableButtons(False, True, False, True, False, False, False, False)
            LoadGridApprovedReq()
        Else
            Call Proc_EnableButtons(False, False, False, True, False, False, False, False)
            LoadGridRequestAll()
        End If
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
        Dim filterParam As String
        Dim filteredRows As DataRow()

        filterParam = Replace(txtColumnName.Text, " ", "") + " = " + QVal(txtValue.Text)
        If Not String.IsNullOrEmpty(txtColumnName.Text) Then
            filteredRows = dtRequestAll.[Select](filterParam)
            If filteredRows.Count > 0 Then
                GridRequestAll.DataSource = filteredRows.CopyToDataTable
                GridCellFormat(GridViewRequestAll)
            Else
                GridRequestAll.DataSource = Nothing
            End If
        Else
            GridRequestAll.DataSource = Nothing
        End If

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

End Class
