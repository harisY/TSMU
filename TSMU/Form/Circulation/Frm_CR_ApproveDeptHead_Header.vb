﻿Imports System.Globalization

Public Class Frm_CR_ApproveDeptHead_Header
    Dim ff_Detail As Frm_CR_UserCreateDetail
    Dim dtGrid As DataTable
    Dim fc_Class As New clsCR_ApproveDeptHead
    Dim IdTrans As String
    Dim Dept As String
    Dim DeptHeadID As String
    Dim Tanggal As Date
    Dim Active_Form As Integer = 2

    Private Sub Frm_CR_ApproveDeptHead_Header_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Dept = gh_Common.GroupID
        DeptHeadID = gh_Common.Username
        LoadGrid(DeptHeadID)
        Dim dtGrid As New DataTable
        Call Proc_EnableButtons(False, True, True, True, True, False, False, False, False, False, False)

    End Sub

    Private Sub LoadGrid(_DeptHeadID As String)
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim dt As New DataTable
            dt = fc_Class.Get_ApproveDeptHead(_DeptHeadID)
            Grid.DataSource = dt
            Call Proc_EnableButtons(False, False, False, True, True, False, False, False)
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick


        Try
            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            IdTrans = String.Empty

            'fc_ClassCRUD = New ClsCR_CreateUser
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    IdTrans = GridView1.GetRowCellValue(rowHandle, "Circulation No")
                    'Tanggal = Convert.ToDateTime(GridView1.GetRowCellValue(rowHandle, "Tanggal"))
                    ' Dim oDate As DateTime = DateTime.ParseExact(GridView1.GetRowCellValue(rowHandle, "Tanggal"), "dd-MM-yyyy", provider)
                    'Tanggal = Convert.ToDateTime(GridView1.GetRowCellValue(rowHandle, "Tanggal"))
                    'Tanggal = oDate
                End If
            Next rowHandle

            If GridView1.GetSelectedRows.Length > 0 Then
                Call CallFrm(IdTrans,
                            Format(Tanggal, gs_FormatSQLDate),
                            GridView1.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try



    End Sub


    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)

        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        ff_Detail = New Frm_CR_UserCreateDetail(ls_Code, ls_Code2, Me, li_Row, Grid, Active_Form)
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()


    End Sub
End Class
