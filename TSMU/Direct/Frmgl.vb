Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Public Class Frmgl
    Dim ff_Detail As Frmgl_Detail
    Dim dtGrid As DataTable
    Dim dtGrid2 As DataTable
    Dim dtGrid3 As DataTable
    Dim ObjGJ As GJHeaderModel
    Dim ObjGJ2 As GJHeaderModel
    Dim _Service As GJHeaderModel
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        _Service = New GJHeaderModel

    End Sub
    Private Sub Frmgl_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Call LoadGrid2()
        Call LoadGrid3()
        Call LoadGrid4()
        Call Proc_EnableButtons(True, True, True, True, True, False, False, False, False, False, False, True)
    End Sub
    Private Sub LoadGrid()
        Try
            ObjGJ = New GJHeaderModel
            dtGrid = ObjGJ.GetDataGrid()
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
    Public Overrides Sub Proc_SaveData()
        Try
            ObjGJ2 = New GJHeaderModel
            If gh_Common.Level = 1 Then
                Exit Sub
            End If
            For i As Integer = 0 To GridView3.RowCount - 1
                If gh_Common.Level = 2 Then
                    If GridView3.GetRowCellValue(i, "Approved2") = True Then
                        With ObjGJ2
                            .cek2 = CBool(GridView3.GetRowCellValue(i, "Approved2"))
                            .GJID = CStr(GridView3.GetRowCellValue(i, "GJID"))
                            .UpdateCek(2)
                        End With

                    End If
                ElseIf gh_Common.Level = 3 Then
                    If GridView3.GetRowCellValue(i, "Approved3") = True Then
                        With ObjGJ2
                            .cek3 = CBool(GridView3.GetRowCellValue(i, "Approved3"))
                            .GJID = CStr(GridView3.GetRowCellValue(i, "GJID"))
                            .UpdateCek(3)
                        End With

                    End If
                End If

            Next
            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Call LoadGrid3()
            tsBtn_refresh.PerformClick()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            'ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
    Public Overrides Sub Proc_Search()
        Try
            Dim Status As List(Of String) = New List(Of String)({"ALL", "Open", "Posted"})

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
                    Case "Posted"
                        _Status = "Posted"
                End Select

                Dim dt As New DataTable
                _Service = New GJHeaderModel
                dt = _Service.GetDataByDate(If(IsDBNull(.TglDari), Format(Date.Today, gs_FormatSQLDate), .TglDari), If(IsDBNull(.TglSampai), Format(Date.Today, gs_FormatSQLDate), .TglSampai), _Status)
                Grid.DataSource = dt
            End With
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
    Private Sub LoadGrid2()
        Try
            ObjGJ = New GJHeaderModel
            dtGrid2 = ObjGJ.GetDataGrid2()

            GridControl1.DataSource = dtGrid2

            GridView2.BestFitColumns()

            With GridView2
                .Columns(0).Visible = False
            End With
            GridCellFormat(GridView2)
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub LoadGrid3()
        Try
            ObjGJ = New GJHeaderModel
            ObjGJ.Level = gh_Common.Level
            dtGrid3 = ObjGJ.GetDataGrid3()

            GridControl2.DataSource = dtGrid3

            GridView3.BestFitColumns()

            With GridView3
                .Columns(0).Visible = False
            End With
            GridCellFormat(GridView3)
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub LoadGrid4()
        Try
            ObjGJ = New GJHeaderModel
            ObjGJ.Level = gh_Common.Level
            dtGrid3 = ObjGJ.GetDataGrid4()

            GridControl3.DataSource = dtGrid3

            GridView4.BestFitColumns()

            With GridView4
                .Columns(0).Visible = False
            End With
            GridCellFormat(GridView4)
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

    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        ff_Detail = New Frmgl_Detail(ls_Code, ls_Code2, Me, li_Row, Grid)
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    Public Overrides Sub Proc_DeleteData()
        Dim ID As String = String.Empty
        Dim REFFID As String = String.Empty
        Try
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    ID = GridView1.GetRowCellValue(rowHandle, "GJID")
                    REFFID = GridView1.GetRowCellValue(rowHandle, "GJID_Revers")
                End If
            Next rowHandle
            ObjGJ.ID = ID
            ObjGJ.GJID = ID
            ObjGJ.GJID_Revers = REFFID
            ''          ObjGJ.Delete()
            ''ObjGJ.DeleteDataR(REFFID)
            ObjGJ.DeleteHeaderR(REFFID)
            ObjGJ.Deletegj()

            tsBtn_refresh.PerformClick()

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Dim ID As String
    Dim gjid As String
    Private Sub Frmgl_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        ID = GridView1.GetRowCellValue(rowHandle, "GJHeaderID")
                        gjid = GridView1.GetRowCellValue(rowHandle, "GJID")
                    End If
                Next rowHandle

                If GridView1.GetSelectedRows.Length > 0 Then
                    Call CallFrm(ID,
                             gjid,
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
                gjid = String.Empty
                Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        ID = GridView1.GetRowCellValue(rowHandle, "GJHeaderID")
                        gjid = GridView1.GetRowCellValue(rowHandle, "GJID")
                    End If
                Next rowHandle

                If GridView1.GetSelectedRows.Length > 0 Then
                    'Dim objGrid As DataGridView = sender
                    Call CallFrm(ID,
                         gjid,
                         GridView1.RowCount)
                End If
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub GridControl1_DoubleClick(sender As Object, e As EventArgs) Handles GridControl1.DoubleClick
        Try

            Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
            'Dim view As GridView = TryCast(sender, GridView)
            Dim view As BaseView = GridControl1.GetViewAt(ea.Location)
            If view Is Nothing Then
                Return
            End If
            Dim baseHI As BaseHitInfo = view.CalcHitInfo(ea.Location)
            Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
            If info.InRow OrElse info.InRowCell Then

                ID = String.Empty
                gjid = String.Empty
                Dim selectedRows() As Integer = GridView2.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        ID = GridView2.GetRowCellValue(rowHandle, "GJHeaderID")
                        gjid = GridView2.GetRowCellValue(rowHandle, "GJID")
                    End If
                Next rowHandle

                If GridView2.GetSelectedRows.Length > 0 Then
                    'Dim objGrid As DataGridView = sender
                    Call CallFrm(ID,
                         gjid,
                         GridView2.RowCount)
                End If
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub GridControl2_DoubleClick(sender As Object, e As EventArgs) Handles GridControl2.DoubleClick
        Try

            Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
            'Dim view As GridView = TryCast(sender, GridView)
            Dim view As BaseView = GridControl2.GetViewAt(ea.Location)
            If view Is Nothing Then
                Return
            End If
            Dim baseHI As BaseHitInfo = view.CalcHitInfo(ea.Location)
            Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
            If info.InRow OrElse info.InRowCell Then

                ID = String.Empty
                gjid = String.Empty
                Dim selectedRows() As Integer = GridView3.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        ID = GridView3.GetRowCellValue(rowHandle, "GJHeaderID")
                        gjid = GridView3.GetRowCellValue(rowHandle, "GJID")
                    End If
                Next rowHandle

                If GridView3.GetSelectedRows.Length > 0 Then
                    'Dim objGrid As DataGridView = sender
                    Call CallFrm(ID,
                         gjid,
                         GridView3.RowCount)
                End If
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub GridControl3_DoubleClick(sender As Object, e As EventArgs) Handles GridControl3.DoubleClick
        Try

            Dim ea As DXMouseEventArgs = TryCast(e, DXMouseEventArgs)
            'Dim view As GridView = TryCast(sender, GridView)
            Dim view As BaseView = GridControl3.GetViewAt(ea.Location)
            If view Is Nothing Then
                Return
            End If
            Dim baseHI As BaseHitInfo = view.CalcHitInfo(ea.Location)
            Dim info As GridHitInfo = view.CalcHitInfo(ea.Location)
            If info.InRow OrElse info.InRowCell Then

                ID = String.Empty
                gjid = String.Empty
                Dim selectedRows() As Integer = GridView4.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        ID = GridView4.GetRowCellValue(rowHandle, "GJHeaderID")
                        gjid = GridView4.GetRowCellValue(rowHandle, "GJID")
                    End If
                Next rowHandle

                If GridView4.GetSelectedRows.Length > 0 Then
                    'Dim objGrid As DataGridView = sender
                    Call CallFrm(ID,
                         gjid,
                         GridView4.RowCount)
                End If
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
End Class
