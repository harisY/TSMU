Imports System.Globalization

Public Class Frm_CR_Approve
    Dim ff_Detail As Frm_CR_UserCreateDetail
    Dim dtGrid As DataTable
    Dim fc_Class As New clsCR_ApproveDeptHead
    Dim GService As GlobalService
    Dim IdTrans As String
    Dim Dept As String
    Dim DeptHeadID As String
    Dim Tanggal As Date
    Dim Active_Form As Integer = 0
    Dim division As Integer = 0
    Dim director As Integer = 0
    Dim _level As Integer = 0



    Private Sub LoadGrid(level As Int32, div_id As Integer, director_id As Integer)
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim dt As New DataTable

            dt = fc_Class.Get_Approve(gh_Common.GroupID.ToString, level, div_id, director_id)
            Grid.DataSource = dt
            Active_Form = level




            Call Proc_EnableButtons(False, False, False, True, True, False, False, False)
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
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

    Private Sub Frm_CR_Approve_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GService = New GlobalService
        _level = GService.GetLevel_str("CIRCULATION")

        Dim dtRoot As DataTable
        dtRoot = fc_Class.Get_Root_Approve(gh_Common.Username)

        If dtRoot.Rows.Count > 0 Then
            division = dtRoot.Rows(0).Item("div_Id")
            director = dtRoot.Rows(0).Item("director_Id")
        End If

        bb_SetDisplayChangeConfirmation = False
        Dept = gh_Common.GroupID

        LoadGrid(_level, division, director)

        Dim dtGrid As New DataTable
        Call Proc_EnableButtons(False, False, False, True, False, False, False, False, False, False, False, True)
    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick
        Try
            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            IdTrans = String.Empty
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    IdTrans = GridView1.GetRowCellValue(rowHandle, "Circulation No")
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


    Public Overrides Sub Proc_Search()

        Try

            Dim fSearch As New frmSearch()
            With fSearch
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()

                dtGrid = fc_Class.Get_Approve_Search(Dept, _level, division, director, If(IsDBNull(.TglDari), Format(Date.Today, gs_FormatSQLDate), .TglDari), If(IsDBNull(.TglSampai), Format(Date.Today, gs_FormatSQLDate), .TglSampai))
                Grid.DataSource = dtGrid


            End With
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try

    End Sub


End Class
