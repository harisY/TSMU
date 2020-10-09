﻿Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class FrmSuspendSettle
    Dim ff_Detail As FrmSuspendSettleDetail
    Dim ff_Detail1 As FrmSuspendSettleDetailDirect
    Dim dtGrid As DataTable
    Dim dtGrid2 As DataTable
    Dim ObjSettle As SettleHeader
    Dim _Service As SettleHeader

    Private Sub FrmSuspendSettle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Call LoadGrid2()
        Call Proc_EnableButtons(True, False, True, True, True, False, False, False, False, False, False, True)
    End Sub
    Public Overrides Sub Proc_Search()
        Try
            Dim Status As List(Of String) = New List(Of String)({"ALL", "Open", "Approved", "Close"})

            Dim fSearch As New frmAdvanceSearch(Status)
            With fSearch
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()
                Dim _Status As String = String.Empty
                Select Case .Status.ToLower
                    Case "all"
                        _Status = "ALL"
                    Case "Open"
                        _Status = "Open"
                    Case "Approved"
                        _Status = "Approved"
                    Case "Close"
                        _Status = "Close"
                End Select
                Dim dt As New DataTable
                _Service = New SettleHeader
                dt = _Service.GetDataByDate(If(IsDBNull(.TglDari), Format(Date.Today, gs_FormatSQLDate), .TglDari), If(IsDBNull(.TglSampai), Format(Date.Today, gs_FormatSQLDate), .TglSampai), _Status)
                Grid.DataSource = dt
            End With
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        _Service = New SettleHeader

    End Sub
    Private Sub LoadGrid()
        Try
            ObjSettle = New SettleHeader
            dtGrid = ObjSettle.GetDataGrid()
            Grid.DataSource = dtGrid
            With GridView1
                .Columns(0).Visible = False
                .BestFitColumns()
            End With
            GridCellFormat(GridView1)
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub LoadGrid2()
        Try
            ObjSettle = New SettleHeader
            dtGrid2 = ObjSettle.GetDataGrid2()
            GridControl1.DataSource = dtGrid2
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

    Public Overrides Sub Proc_InputNewData()
        Dim result As DialogResult = XtraMessageBox.Show("Settle tanpa Advance ?", "Confirmation", MessageBoxButtons.YesNoCancel)
        If result = System.Windows.Forms.DialogResult.Yes Then
            CallFrmDirect()
        ElseIf result = System.Windows.Forms.DialogResult.No Then
            CallFrm()
        End If
    End Sub
    Public Overrides Sub Proc_Refresh()
        bs_Filter = ""
        Call LoadGrid()
    End Sub

    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        ff_Detail = New FrmSuspendSettleDetail(ls_Code, ls_Code2, Me, li_Row, Grid)
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub
    Private Sub CallFrmDirect(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail1 IsNot Nothing AndAlso ff_Detail1.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail1.Close()
        End If
        ff_Detail1 = New FrmSuspendSettleDetailDirect(ls_Code, ls_Code2, Me, li_Row, Grid)
        ff_Detail1.MdiParent = FrmMain
        ff_Detail1.StartPosition = FormStartPosition.CenterScreen
        ff_Detail1.Show()
    End Sub

    Public Overrides Sub Proc_DeleteData()
        'Dim ID As String = String.Empty

        'Try
        '    Dim selectedRows() As Integer = GridView1.GetSelectedRows()
        '    For Each rowHandle As Integer In selectedRows
        '        If rowHandle >= 0 Then
        '            ID = GridView1.GetRowCellValue(rowHandle, "ID")
        '        End If
        '    Next rowHandle

        '    ' fc_Class.Delete(ID)

        '    tsBtn_refresh.PerformClick()

        'Catch ex As Exception
        '    Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        '    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        'End Try
        Try
            Dim ID As String = String.Empty
            Dim settleID As String = String.Empty
            Dim SuspendID As String = String.Empty
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    ID = GridView1.GetRowCellValue(rowHandle, "ID")
                    settleID = GridView1.GetRowCellValue(rowHandle, "SettleID")
                    SuspendID = IIf(GridView1.GetRowCellValue(rowHandle, "SuspendID") Is DBNull.Value, "", (GridView1.GetRowCellValue(rowHandle, "SuspendID")))
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
    Dim ID As String
    Dim suspendid As String
    Dim suspend1 As String
    Private Sub FrmSuspendSettle_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        ID = GridView1.GetRowCellValue(rowHandle, "ID")
                        suspendid = GridView1.GetRowCellValue(rowHandle, "SettleID")
                    End If
                Next rowHandle

                If GridView1.GetSelectedRows.Length > 0 Then
                    Call CallFrm(ID,
                         suspendid,
                         GridView1.RowCount)
                End If

            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick
        Try

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
                suspend1 = String.Empty
                Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        ID = GridView1.GetRowCellValue(rowHandle, "ID")
                        suspendid = GridView1.GetRowCellValue(rowHandle, "SettleID")
                        suspend1 = IIf(GridView1.GetRowCellValue(rowHandle, "SuspendID") Is DBNull.Value, "", (GridView1.GetRowCellValue(rowHandle, "SuspendID")))
                    End If
                Next rowHandle

                If suspend1 = "" Then
                    'Dim objGrid As DataGridView = sender
                    Call CallFrmDirect(ID, suspendid,
                         GridView1.RowCount)
                Else
                    'Dim objGrid As DataGridView = sender
                    Call CallFrm(ID,
                             suspendid,
                             GridView1.RowCount)
                End If
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub Grid_Click(sender As Object, e As EventArgs) Handles Grid.Click

    End Sub
End Class
