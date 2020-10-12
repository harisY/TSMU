Imports System.Globalization

Public Class Frm_CR_Approve
    Dim ff_Detail As Frm_CR_UserCreateDetail
    Dim dtGrid As DataTable
    Dim fc_Class As New clsCR_ApproveDeptHead
    Dim fc_Class_Other As New clsCR_ApproveDivHead
    Dim fc_Class_Accounting As New clsCR_Accounting
    Dim GService As GlobalService
    Dim IdTrans As String
    Dim Dept As String
    Dim DeptHeadID As String
    Dim Tanggal As Date
    Dim Active_Form As Integer = 0
    Dim division As Integer = 0
    Dim director As Integer = 0
    Dim _level As Integer = 0




    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)

        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        If Active_Form = 2 Or Active_Form = 3 Then
            ff_Detail = New Frm_CR_UserCreateDetail(ls_Code, ls_Code2, Me, li_Row, Grid, Active_Form)
        ElseIf Active_Form = 4 Then
            ff_Detail = New Frm_CR_UserCreateDetail(ls_Code, ls_Code2, Me, li_Row, Grid2, Active_Form)
        ElseIf Active_Form = 5 Then
            ff_Detail = New Frm_CR_UserCreateDetail(ls_Code, ls_Code2, Me, li_Row, Grid3, Active_Form)
        End If

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

        Call LoadGrid(_level, division, director)
        Call LoadGrid_Other(gh_Common.GroupID)
        Call LoadGrid_Accounting()
        Call LoadGrid_Purchase()
        Call Grid_Properties()

        If gh_Common.GroupID = "1FAC" Then
            'TabControl1.TabPages.Remove(TabPage1)
            'TabControl1.TabPages.Remove(TabPage2)
            'TabControl1.TabPages.Remove(TabPage3)
            TabControl1.TabPages.Remove(TabPage4)
        ElseIf gh_Common.GroupID = "1PUR" Then
            'TabControl1.TabPages.Remove(TabPage1)
            'TabControl1.TabPages.Remove(TabPage2)
            TabControl1.TabPages.Remove(TabPage3)
            'TabControl1.TabPages.Remove(TabPage4)
        Else
            'TabControl1.TabPages.Remove(TabPage1)
            'TabControl1.TabPages.Remove(TabPage2)
            TabControl1.TabPages.Remove(TabPage3)
            TabControl1.TabPages.Remove(TabPage4)
        End If

        Dim dtGrid As New DataTable
        Call Proc_EnableButtons(False, False, False, True, False, False, False, False, False, False, False, True)

    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick

        Active_Form = _level

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

    Public Overrides Sub Proc_Refresh()
        bs_Filter = ""
        LoadGrid(_level, division, director)
    End Sub

    Private Sub Grid2_DoubleClick(sender As Object, e As EventArgs) Handles Grid2.DoubleClick
        Active_Form = 4
        Try
            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            IdTrans = String.Empty

            'fc_ClassCRUD = New ClsCR_CreateUser
            Dim selectedRows() As Integer = GridView2.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    IdTrans = GridView2.GetRowCellValue(rowHandle, "Circulation No")
                End If
            Next rowHandle

            If GridView2.GetSelectedRows.Length > 0 Then
                Call CallFrm(IdTrans,
                            Format(Tanggal, gs_FormatSQLDate),
                            GridView2.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub


    Private Sub LoadGrid(level As Int32, div_id As Integer, director_id As Integer)
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim dt As New DataTable

            dt = fc_Class.Get_Approve(gh_Common.GroupID.ToString, level, div_id, director_id)
            Grid.DataSource = dt
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub LoadGrid_Other(_Dept As String)
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim dt As New DataTable
            dt = fc_Class_Other.Get_Other_Dept(_Dept)
            Grid2.DataSource = dt


            Call Proc_EnableButtons(False, False, False, True, True, False, False, False)
            Cursor.Current = Cursors.Default
        Catch ex As Exception
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Public Sub LoadGrid_Accounting()
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim dt As New DataTable
            dt = fc_Class_Accounting.Get_Approve_Accounting()
            Grid3.DataSource = dt
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub


    Public Sub LoadGrid_Purchase()
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim dt As New DataTable
            dt = fc_Class_Accounting.Get_Purchase_Monitor_Proses()
            Grid4.DataSource = dt

        Catch ex As Exception
            ' Cursor.Current = Cursors.Default
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub Grid3_DoubleClick(sender As Object, e As EventArgs) Handles Grid3.DoubleClick
        Active_Form = 5
        Try
            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            IdTrans = String.Empty

            'fc_ClassCRUD = New ClsCR_CreateUser
            Dim selectedRows() As Integer = GridView3.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    IdTrans = GridView3.GetRowCellValue(rowHandle, "Circulation")
                End If
            Next rowHandle

            If GridView3.GetSelectedRows.Length > 0 Then
                Call CallFrm(IdTrans,
                            Format(Tanggal, gs_FormatSQLDate),
                            GridView3.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub Grid_Properties()
        Try
            With GridView3

                '.Columns("Circulation").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                '.Columns("Circulation").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                '.Columns("Circulation").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
                '.Columns("Term").DisplayFormat.FormatString = "c2"
                '.Columns("Date").Width = 20
                .Columns("Tgl").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Tgl").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Tgl").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
                '.Columns("%").Width = 2
                .Columns("Dept").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Dept").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Dept").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False

                .Columns("Status").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Status").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Status").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False

                .Columns("Approved").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Approved").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Approved").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False

                .Columns("IDR").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("IDR").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default
                .Columns("IDR").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
                .Columns("IDR").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                .Columns("IDR").DisplayFormat.FormatString = "{0:N2}"
                .Columns("IDR").Width = 100

                .Columns("USD").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("USD").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("USD").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
                .Columns("USD").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                .Columns("USD").DisplayFormat.FormatString = "{0:N2}"
            End With
        Catch ex As Exception

        End Try
    End Sub


End Class
