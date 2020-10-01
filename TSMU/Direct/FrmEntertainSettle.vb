Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class FrmEntertainSettle
    Dim ff_Detail As FrmEntertainSettleDetail
    Dim ff_Detail1 As FrmEntertainSettleDetailDirect
    Dim ObjSettle As SettleHeader

    Dim dtGridSettle As New DataTable
    Dim dtGridPaid As New DataTable

    Private Sub FrmEntertainSettle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        bs_Filter = ""
        Call Proc_EnableButtons(True, False, True, True, True, False, False, False, False, False, False, True)
        Call LoadGridSettle()
    End Sub

    Private Sub LoadGridSettle()
        Try
            ObjSettle = New SettleHeader
            dtGridSettle = ObjSettle.GetDataGridEnt()
            GridSettle.DataSource = dtGridSettle
            With GridViewSettle
                .Columns(0).Visible = False
                .BestFitColumns()
            End With
            GridCellFormat(GridViewSettle)
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadGridPaid()
        Try
            ObjSettle = New SettleHeader
            dtGridPaid = ObjSettle.GetDataGridEntPaid()
            GridPaid.DataSource = dtGridPaid
            With GridViewPaid
                .Columns(0).Visible = False
                .BestFitColumns()
            End With
            GridCellFormat(GridViewPaid)
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_InputNewData()
        Dim result As DialogResult = XtraMessageBox.Show("Settle tanpa Advance ?", "Confirmation", MessageBoxButtons.YesNoCancel)
        If result = System.Windows.Forms.DialogResult.Yes Then
            CallFrmDirect()
        ElseIf result = System.Windows.Forms.DialogResult.No Then
            CallFrm()
        End If
    End Sub

    Private Sub CallFrmDirect(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail1 IsNot Nothing AndAlso ff_Detail1.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail1.Close()
        End If
        ff_Detail1 = New FrmEntertainSettleDetailDirect(ls_Code, ls_Code2, Me, li_Row, GridSettle)
        ff_Detail1.MdiParent = FrmMain
        ff_Detail1.StartPosition = FormStartPosition.CenterScreen
        ff_Detail1.Show()
    End Sub

    Public Overrides Sub Proc_Refresh()
        bs_Filter = ""
        If TabEntertainment.SelectedTabPage.Name = TabPageSettle.Name Then
            LoadGridSettle()
        Else
            LoadGridPaid()
        End If
    End Sub

    Public Overrides Sub Proc_Search()
        Try
            Dim fSearch As New frmSearch()
            With fSearch
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()
            End With
            If TabEntertainment.SelectedTabPage.Name = TabPageSettle.Name Then
                dtGridSettle = ObjSettle.GetDataGridEntSearch(fSearch.TglDari, fSearch.TglSampai)
                GridSettle.DataSource = dtGridSettle
                With GridViewSettle
                    .Columns(0).Visible = False
                    .BestFitColumns()
                End With
                GridCellFormat(GridViewSettle)
            Else
                dtGridPaid = ObjSettle.GetDataGridEntPaidSearch(fSearch.TglDari, fSearch.TglSampai)
                GridPaid.DataSource = dtGridPaid
                With GridViewPaid
                    .Columns(0).Visible = False
                    .BestFitColumns()
                End With
                GridCellFormat(GridViewPaid)
            End If


        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        ff_Detail = New FrmEntertainSettleDetail(ls_Code, ls_Code2, Me, li_Row, GridSettle)
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    Public Overrides Sub Proc_DeleteData()
        Try
            Dim ID As String = String.Empty
            Dim settleID As String = String.Empty
            Dim SuspendID As String = String.Empty
            Dim selectedRows() As Integer = GridViewSettle.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    ID = GridViewSettle.GetRowCellValue(rowHandle, "ID")
                    settleID = GridViewSettle.GetRowCellValue(rowHandle, "SettleID")
                    SuspendID = IIf(GridViewSettle.GetRowCellValue(rowHandle, "SuspendID") Is DBNull.Value, "", (GridViewSettle.GetRowCellValue(rowHandle, "SuspendID")))
                End If
            Next rowHandle

            If ObjSettle.CheckSettleAccrued(settleID) Then
                Err.Raise(ErrNumber, , "No Settlement " & settleID & " sudah dilakukan proses Accrued !")
            Else
                ObjSettle = New SettleHeader
                ObjSettle.ID = ID
                ObjSettle.SettleID = settleID
                ObjSettle.SuspendID = SuspendID
                If String.IsNullOrEmpty(SuspendID) Then
                    ObjSettle.DeleteData()
                Else
                    ObjSettle.DeleteDataWithSuspend()
                End If
                Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)
            End If
            tsBtn_refresh.PerformClick()

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GridSettle_DoubleClick(sender As Object, e As EventArgs) Handles GridSettle.DoubleClick
        Try
            Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
            'Dim view As GridView = TryCast(sender, GridView)
            Dim view As BaseView = GridSettle.GetViewAt(ea.Location)
            If view Is Nothing Then
                Return
            End If
            Dim baseHI As BaseHitInfo = view.CalcHitInfo(ea.Location)
            Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
            If info.InRow OrElse info.InRowCell Then

                Dim ID As String = String.Empty
                Dim SettleID As String = String.Empty
                Dim SuspendID As String = String.Empty
                Dim selectedRows() As Integer = GridViewSettle.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        ID = GridViewSettle.GetRowCellValue(rowHandle, "ID")
                        SettleID = GridViewSettle.GetRowCellValue(rowHandle, "SettleID")
                        SuspendID = IIf(GridViewSettle.GetRowCellValue(rowHandle, "SuspendID") Is DBNull.Value, "", (GridViewSettle.GetRowCellValue(rowHandle, "SuspendID")))
                    End If
                Next rowHandle

                If SuspendID = "" Then
                    Call CallFrmDirect(ID, SettleID,
                         GridViewSettle.RowCount)
                Else
                    Call CallFrm(ID,
                              SettleID,
                             GridViewSettle.RowCount)
                End If
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Private Sub GridPaid_DoubleClick(sender As Object, e As EventArgs) Handles GridPaid.DoubleClick
        Try
            Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
            'Dim view As GridView = TryCast(sender, GridView)
            Dim view As BaseView = GridPaid.GetViewAt(ea.Location)
            If view Is Nothing Then
                Return
            End If
            Dim baseHI As BaseHitInfo = view.CalcHitInfo(ea.Location)
            Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
            If info.InRow OrElse info.InRowCell Then

                Dim ID As String = String.Empty
                Dim SettleID As String = String.Empty
                Dim SuspendID As String = String.Empty
                Dim selectedRows() As Integer = GridViewPaid.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        ID = GridViewPaid.GetRowCellValue(rowHandle, "ID")
                        SettleID = GridViewPaid.GetRowCellValue(rowHandle, "SettleID")
                        SuspendID = IIf(GridViewPaid.GetRowCellValue(rowHandle, "SuspendID") Is DBNull.Value, "", (GridViewPaid.GetRowCellValue(rowHandle, "SuspendID")))
                    End If
                Next rowHandle

                If SuspendID = "" Then
                    Call CallFrmDirect(ID, SettleID,
                         GridViewSettle.RowCount)
                Else
                    Call CallFrm(ID,
                              SettleID,
                             GridViewSettle.RowCount)
                End If
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Private Sub TabEntertainment_SelectedPageChanged(sender As Object, e As DevExpress.XtraTab.TabPageChangedEventArgs) Handles TabEntertainment.SelectedPageChanged
        If TabEntertainment.SelectedTabPage.Name = TabPageSettle.Name Then
            Call Proc_EnableButtons(True, False, True, True, True, False, False, False, False, False, False, True)
            LoadGridSettle()
        Else
            Call Proc_EnableButtons(False, False, False, True, False, False, False, False, False, False, False, True)
            LoadGridPaid()
        End If
    End Sub

End Class
