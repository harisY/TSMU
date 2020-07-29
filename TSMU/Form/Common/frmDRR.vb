﻿Imports System.Collections.ObjectModel
Imports System.IO
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraSplashScreen

Public Class frmDRR
    Dim ff_Detail As frmDRR_details
    Dim dtGrid As DataTable
    Dim _Service As DRRService
    Dim ObjHeader As DRRModel
    Dim ObjDetail As DRRDetail

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        _Service = New DRRService

    End Sub

    Private Sub frmDRR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False

        Call Proc_EnableButtons(True, False, True, True, True, False, False, False, False, False, False)

    End Sub
    Private Sub SaveToExcel(_Grid As GridControl)
        Dim save As New SaveFileDialog
        save.Filter = "Excel File|*.xlsx"
        save.Title = "Save an Excel File"
        If save.ShowDialog = DialogResult.OK Then
            _Grid.ExportToXlsx(save.FileName)
        End If
    End Sub
    Private Sub LoadGrid()
        Try

            SplashScreenManager.ShowForm(GetType(FrmWait))
            _Service = New DRRService
            dtGrid = New DataTable
            dtGrid = _Service.GetAll()
            Grid.DataSource = dtGrid
            With GridView1
                .BestFitColumns()
                .Columns(0).Visible = False
                .FixedLineWidth = 2
                .Columns(1).Fixed = Columns.FixedStyle.Left
                .Columns(2).Fixed = Columns.FixedStyle.Left
                .Columns(3).Fixed = Columns.FixedStyle.Left
            End With
            If GridView1.RowCount > 0 Then
                GridCellFormat(GridView1)
            End If
            SplashScreenManager.CloseForm()
        Catch ex As Exception
            SplashScreenManager.CloseForm()
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

    Private Sub CallFrm(Optional ByVal ls_Code As String = "0", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        ff_Detail = New frmDRR_details(ls_Code, ls_Code2, Me, li_Row, Grid)
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub
    Dim _path As String = "\\10.10.1.12\e$\DRR Sketch\"
    Public Overrides Sub Proc_DeleteData()
        Try
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    ID = GridView1.GetRowCellValue(rowHandle, "Id")
                End If
            Next rowHandle
            _Service = New DRRService

            'Hapus Gambar di Folder
            Dim ObjHeader As New DRRModel
            ObjHeader = _Service.GetById(ID)
            Dim images As New List(Of String)
            With ObjHeader
                images = New List(Of String)({ .Gambar1, .Gambar2, .Gambar3, .Gambar4, .Gambar5})
            End With
            For Each gambar In images
                Dim fileName = gambar.Split(","c)
                'Dim fileName = pathParts(pathParts.Count() - 1).Split("."c)
                'Dim _index = pathParts(pathParts.Count() - 1).Split(","c)
                If fileName(0).ToString = "" Then
                    Exit For
                End If
                Dim _File As String = String.Empty
                If Directory.Exists(_path) Then
                    _File = Path.Combine(_path, fileName(0))
                    If File.Exists(_File) Then
                        File.Delete(_File)
                    End If
                End If
            Next
            _Service.Delete(ID)

            Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)
            tsBtn_refresh.PerformClick()
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Dim NoNPP As String
    Dim ID As String
    Private Sub frmDRR_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If e.KeyCode = Keys.F1 Then
                NoNPP = String.Empty
                ID = "0"
                Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        ID = GridView1.GetRowCellValue(rowHandle, "Id")
                        NoNPP = GridView1.GetRowCellValue(rowHandle, "NoNPP")
                    End If
                Next rowHandle

                If GridView1.GetSelectedRows.Length > 0 Then
                    'Dim objGrid As DataGridView = sender
                    Call CallFrm(ID,
                             NoNPP,
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
                'Dim colCaption As String = If(info.Column Is Nothing, "N/A", info.Column.GetCaption())
                'MessageBox.Show(String.Format("DoubleClick on row: {0}, column: {1}.", info.RowHandle, colCaption))

                ID = "0"
                NoNPP = String.Empty
                For Each rowHandle As Integer In GridView1.GetSelectedRows()
                    If rowHandle >= 0 Then
                        ID = GridView1.GetRowCellValue(rowHandle, "Id")
                        NoNPP = GridView1.GetRowCellValue(rowHandle, "NoNPP")
                    End If
                Next rowHandle

                If GridView1.GetSelectedRows.Length > 0 Then
                    'Dim objGrid As DataGridView = sender
                    Call CallFrm(ID,
                             NoNPP,
                             GridView1.RowCount)
                End If
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub frmDRR_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Call LoadGrid()
    End Sub

End Class
