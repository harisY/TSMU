﻿Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class FrmEntertainSettle
    Dim ff_Detail As FrmEntertainSettleDetail
    Dim dtGrid As DataTable
    Dim ObjSettle As SettleHeader
    Dim ff_Detail1 As FrmEntertainSettleDetailDirect

    Private Sub FrmEntertainSettle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call LoadGrid()
        Call LoadGrid2()
        bb_SetDisplayChangeConfirmation = False
        bs_Filter = ""
        Call Proc_EnableButtons(True, False, True, True, True, False, False, False, False, False, False)
    End Sub
    Private Sub LoadGrid()
        Try
            ObjSettle = New SettleHeader
            dtGrid = ObjSettle.GetDataGridEnt()
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
            dtGrid = ObjSettle.GetDataGridEntPaid()
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

    Public Overrides Sub Proc_InputNewData()
        ''CallFrm()

        Dim result As DialogResult = XtraMessageBox.Show("Settle tanpa Advance ?", "Confirmation", MessageBoxButtons.YesNoCancel)
        If result = System.Windows.Forms.DialogResult.Yes Then
            CallFrmDirect()
        Else
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
        ff_Detail1 = New FrmEntertainSettleDetailDirect(ls_Code, ls_Code2, Me, li_Row, Grid)
        ff_Detail1.MdiParent = FrmMain
        ff_Detail1.StartPosition = FormStartPosition.CenterScreen
        ff_Detail1.Show()
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
        ff_Detail = New FrmEntertainSettleDetail(ls_Code, ls_Code2, Me, li_Row, Grid)
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    Public Overrides Sub Proc_DeleteData()
        Dim ID As String = String.Empty

        Try
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    ID = GridView1.GetRowCellValue(rowHandle, "ID")
                End If
            Next rowHandle

            ' fc_Class.Delete(ID)

            tsBtn_refresh.PerformClick()

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Dim ID As String
    ''Dim suspendid As String
    Private Sub FrmEntertainSettle_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

    Dim SuspendID As String
    Dim SettleID As String
    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick
        ''Try

        '    Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
        '        'Dim view As GridView = TryCast(sender, GridView)
        '        Dim view As BaseView = Grid.GetViewAt(ea.Location)
        '        If view Is Nothing Then
        '            Return
        '        End If
        '        Dim baseHI As BaseHitInfo = view.CalcHitInfo(ea.Location)
        '    Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)

        '    If info.InRow OrElse info.InRowCell Then
        '        ID = String.Empty
        '        suspendid = String.Empty
        '        Dim selectedRows() As Integer = GridView1.GetSelectedRows()
        '        For Each rowHandle As Integer In selectedRows
        '            If rowHandle >= 0 Then
        '                ID = GridView1.GetRowCellValue(rowHandle, "ID")
        '                suspendid = GridView1.GetRowCellValue(rowHandle, "SuspendID")
        '            End If
        '        Next rowHandle

        '        If suspendid = "" Then
        '            ''Dim objGrid As DataGridView = sender
        '            Call CallFrmDirect(ID,
        '                 suspendid,
        '             GridView1.RowCount)
        '        Else
        '            ''Dim objGrid As DataGridView = sender
        '            Call CallFrm(ID,
        '                 suspendid,
        '             GridView1.RowCount)

        '        End If

        '    End If

        'Catch ex As Exception
        '    Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        '    WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        'End Try

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
                SettleID = String.Empty
                SuspendID = String.Empty
                Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        ID = GridView1.GetRowCellValue(rowHandle, "ID")
                        SettleID = GridView1.GetRowCellValue(rowHandle, "SettleID")
                        ''SuspendID = GridView1.GetRowCellValue(rowHandle, "SuspendID")
                        SuspendID = IIf(GridView1.GetRowCellValue(rowHandle, "SuspendID") Is DBNull.Value, "", (GridView1.GetRowCellValue(rowHandle, "SuspendID")))
                    End If
                Next rowHandle

                If SuspendID = "" Then
                    'Dim objGrid As DataGridView = sender
                    Call CallFrmDirect(ID, SettleID,
                         GridView1.RowCount)
                Else
                    'Dim objGrid As DataGridView = sender
                    Call CallFrm(ID,
                              SuspendID,
                             GridView1.RowCount)
                End If
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

End Class
