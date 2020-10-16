Imports System.Globalization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid


Public Class Frm_CR_Approve
    Dim ff_Detail As Frm_CR_UserCreateDetail
    Dim dtGrid As DataTable
    Dim fc_Class As New clsCR_ApproveDeptHead
    Dim fc_Class_Other As New clsCR_ApproveDivHead
    Dim fc_Class_Accounting As New clsCR_Accounting
    Dim fc_ClassCRUD As New ClsCR_CreateUser
    Dim GService As GlobalService
    Dim IdTrans As String
    Dim Dept As String
    Dim DeptHeadID As String
    Dim Tanggal As Date
    Dim Active_Form As Integer = 0
    Dim division As Integer = 0
    Dim director As Integer = 0
    Dim _level As Integer = 0
    Dim SelectTab As String




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
        ElseIf Active_Form = 7 Then
            ff_Detail = New Frm_CR_UserCreateDetail(ls_Code, ls_Code2, Me, li_Row, Grid5, Active_Form)
        ElseIf Active_Form = 8 Then
            ff_Detail = New Frm_CR_UserCreateDetail(ls_Code, ls_Code2, Me, li_Row, Grid6, Active_Form)
        End If

        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()


    End Sub

    Private Sub Frm_CR_Approve_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        GService = New GlobalService
        _level = GService.GetLevel_str("CIRCULATION")

        Dim dtRoot As DataTable
        dtRoot = fc_Class.Get_Root_Approve(gh_Common.GroupID)

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
        Call LoadGrid_CRClose()
        Call Grid_Properties()

        If gh_Common.GroupID = "1FAC" Then
            'TabControl1.TabPages.Remove(TabPage1)
            'TabControl1.TabPages.Remove(TabPage2)
            'TabControl1.TabPages.Remove(TabPage3)
            TabControl1.TabPages.Remove(Purchase)
            'TabControl1.TabPages.Remove(TabPage5)
            'TabControl1.TabPages.Remove(TabPage6)
        ElseIf gh_Common.GroupID = "1PUR" Then
            'TabControl1.TabPages.Remove(TabPage1)
            'TabControl1.TabPages.Remove(TabPage2)
            TabControl1.TabPages.Remove(BOD)
            'TabControl1.TabPages.Remove(TabPage4)
            TabControl1.TabPages.Remove(Close)
            TabControl1.TabPages.Remove(Search)
        Else
            'TabControl1.TabPages.Remove(TabPage1)
            'TabControl1.TabPages.Remove(TabPage2)
            TabControl1.TabPages.Remove(BOD)
            TabControl1.TabPages.Remove(Purchase)
            TabControl1.TabPages.Remove(Close)
            TabControl1.TabPages.Remove(Search)
        End If

        Dim dtGrid As New DataTable
        Call Proc_EnableButtons(False, False, False, True, False, False, False, False, False, False, True, True)

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

            If TabControl1.SelectedTab.Name = "Approval" Then
                dtGrid = New DataTable
                With fSearch
                    .StartPosition = FormStartPosition.CenterScreen
                    .ShowDialog()
                    dtGrid = fc_Class.Get_Approve_Search(Dept, _level, division, director, If(IsDBNull(.TglDari), Format(Date.Today, gs_FormatSQLDate), .TglDari), If(IsDBNull(.TglSampai), Format(Date.Today, gs_FormatSQLDate), .TglSampai))
                    Grid.DataSource = dtGrid
                End With
            ElseIf TabControl1.SelectedTab.Name = "Opinion" Then
                dtGrid = New DataTable
                With fSearch
                    .StartPosition = FormStartPosition.CenterScreen
                    .ShowDialog()
                    dtGrid = fc_Class_Other.Get_Other_Dept_Search(Dept, If(IsDBNull(.TglDari), Format(Date.Today, gs_FormatSQLDate), .TglDari), If(IsDBNull(.TglSampai), Format(Date.Today, gs_FormatSQLDate), .TglSampai))
                    Grid2.DataSource = dtGrid
                End With
            ElseIf TabControl1.SelectedTab.Name = "Search" Then
                dtGrid = New DataTable
                With fSearch
                    .StartPosition = FormStartPosition.CenterScreen
                    .ShowDialog()
                    dtGrid = fc_Class_Accounting.Get_Search(If(IsDBNull(.TglDari), Format(Date.Today, gs_FormatSQLDate), .TglDari), If(IsDBNull(.TglSampai), Format(Date.Today, gs_FormatSQLDate), .TglSampai))
                    Grid6.DataSource = dtGrid
                End With
            ElseIf TabControl1.SelectedTab.Name = "Purchase" Then
                dtGrid = New DataTable
                With fSearch
                    .StartPosition = FormStartPosition.CenterScreen
                    .ShowDialog()
                    dtGrid = fc_Class_Accounting.Get_Purchase_Monitor_Proses_Search(If(IsDBNull(.TglDari), Format(Date.Today, gs_FormatSQLDate), .TglDari), If(IsDBNull(.TglSampai), Format(Date.Today, gs_FormatSQLDate), .TglSampai))
                    Grid4.DataSource = dtGrid
                End With

            End If



        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try

    End Sub

    Public Overrides Sub Proc_Refresh()
        bs_Filter = ""
        ' LoadGrid(_level, division, director)
        Call LoadGrid(_level, division, director)
        Call LoadGrid_Other(gh_Common.GroupID)
        Call LoadGrid_Accounting()
        Call LoadGrid_Purchase()
        Call LoadGrid_CRClose()
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

            Call Grid_Properties_ApproveBOD()
            If dt.Rows.Count > 0 Then
                Call Event_Approve()
            End If


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

    Public Sub LoadGrid_CRClose()
        Try
            Cursor.Current = Cursors.WaitCursor

            Dim dt As New DataTable
            dt = fc_Class_Accounting.Get_CRClose()
            Grid5.DataSource = dt

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
                .Columns("Approved").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric


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

    Private Sub Grid4_DoubleClick(sender As Object, e As EventArgs) Handles Grid4.DoubleClick

        Active_Form = 8
        Try
            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            IdTrans = String.Empty

            'fc_ClassCRUD = New ClsCR_CreateUser
            Dim selectedRows() As Integer = GridView4.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    IdTrans = GridView4.GetRowCellValue(rowHandle, "Circulation No")
                End If
            Next rowHandle

            If GridView4.GetSelectedRows.Length > 0 Then
                Call CallFrm(IdTrans,
                            Format(Tanggal, gs_FormatSQLDate),
                            GridView4.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Private Sub TabControl1_DrawItem(sender As Object, e As DrawItemEventArgs) Handles TabControl1.DrawItem
        Select Case e.Index
            Case 0
                e.Graphics.FillRectangle(New SolidBrush(Color.Red), e.Bounds)
            Case 1
                e.Graphics.FillRectangle(New SolidBrush(Color.Blue), e.Bounds)
                'Case 2
                '    e.Graphics.FillRectangle(New SolidBrush(Color.Magenta), e.Bounds)

        End Select

        Dim paddedBounds As Rectangle = e.Bounds
        paddedBounds.Inflate(-2, -2)
        e.Graphics.DrawString(TabControl1.TabPages(e.Index).Text, Me.Font, SystemBrushes.MenuText, paddedBounds)


    End Sub

    Private Sub Grid5_DoubleClick(sender As Object, e As EventArgs) Handles Grid5.DoubleClick
        Active_Form = 7
        Try
            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            IdTrans = String.Empty

            'fc_ClassCRUD = New ClsCR_CreateUser
            Dim selectedRows() As Integer = GridView5.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    IdTrans = GridView5.GetRowCellValue(rowHandle, "Circulation No")
                End If
            Next rowHandle

            If GridView5.GetSelectedRows.Length > 0 Then
                Call CallFrm(IdTrans,
                            Format(Tanggal, gs_FormatSQLDate),
                            GridView5.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Private Sub Grid_Properties_ApproveBOD()


        Try
            With GridView3

                '.BestFitColumns()

                .Columns("Circulation").Width = 200
                '.Columns("Circulation").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                '.Columns("Circulation").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Circulation").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
                .Columns("Circulation").OptionsColumn.AllowEdit = DevExpress.Utils.DefaultBoolean.False

                .Columns("Tgl").Width = 100
                .Columns("Tgl").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Tgl").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Tgl").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
                .Columns("Tgl").OptionsColumn.AllowEdit = DevExpress.Utils.DefaultBoolean.False

                .Columns("Dept").Width = 100
                .Columns("Dept").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Dept").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Dept").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
                .Columns("Dept").OptionsColumn.AllowEdit = DevExpress.Utils.DefaultBoolean.False


                .Columns("Status").Width = 100
                .Columns("Status").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Status").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("Status").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
                .Columns("Status").OptionsColumn.AllowEdit = DevExpress.Utils.DefaultBoolean.False



                .Columns("IDR").Width = 200
                .Columns("IDR").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("IDR").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
                .Columns("IDR").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
                .Columns("IDR").OptionsColumn.AllowEdit = DevExpress.Utils.DefaultBoolean.False
                .Columns("IDR").SummaryItem.SummaryType = DevExpress.Data.SummaryItemType.Sum
                .Columns("IDR").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
                .Columns("IDR").DisplayFormat.FormatString = "N2"
                .Columns("IDR").OptionsColumn.AllowEdit = DevExpress.Utils.DefaultBoolean.False



            End With
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Event_Approve()

        Dim Apv As RepositoryItemCheckEdit = New RepositoryItemCheckEdit()
        AddHandler Apv.CheckedChanged, AddressOf Approve_EditValueChanged

        With GridView3
            .Columns("Approve").ColumnEdit = Apv
        End With
        With Grid3.RepositoryItems
            .Add(Apv)
        End With

    End Sub
    Private Sub Approve_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Public Overrides Sub Proc_Approve()
        Active_Form = 5
        Dim _Check1 As Boolean = False
        For i As Integer = 0 To GridView3.RowCount - 1
            Dim _Check As Boolean = IIf(GridView3.GetRowCellValue(i, "Approve") Is DBNull.Value, False, Convert.ToBoolean(GridView3.GetRowCellValue(i, "Approve")))
            _Check1 = _Check1 Or _Check
        Next

        If _Check1 = False Then
            MessageBox.Show("Please Choose Circulation No",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
        Else
            Dim result As DialogResult = MessageBox.Show("Are You Want to Submit ?",
                                                    "CIRCULATION",
                                                    MessageBoxButtons.OKCancel,
                                                    MessageBoxIcon.Question,
                                                    MessageBoxDefaultButton.Button2)
            If result = System.Windows.Forms.DialogResult.OK Then


                For i As Integer = 0 To GridView3.RowCount - 1
                    Dim _Submit As Boolean = IIf(GridView3.GetRowCellValue(i, "Approve") Is DBNull.Value, False, Convert.ToBoolean(GridView3.GetRowCellValue(i, "Approve")))
                    If _Submit = True Then
                        fc_ClassCRUD.GetDataByID(GridView3.GetRowCellValue(i, "Circulation"))
                        If fc_ClassCRUD.H_Status = "Other Dept" Then

                            Try
                                fc_ClassCRUD = New ClsCR_CreateUser
                                With fc_ClassCRUD
                                    .H_UserSubmition = 1
                                    .H_Status = "Approve BOD"
                                    .H_Current_Level = Active_Form
                                    .TA_Username = gh_Common.Username
                                    .TA_MenuCode = "CIRCULATION"
                                    .TA_DeptID = gh_Common.GroupID
                                    .TA_NoTransaksi = GridView3.GetRowCellValue(i, "Circulation")
                                    .TA_LevelApprove = Active_Form
                                    .TA_StatusApprove = "Approve BOD"
                                    .TA_ApproveBy = gh_Common.Username
                                    .TA_ApproveDAte = Date.Now
                                    .TA_IsActive = 1
                                End With
                                fc_ClassCRUD.UpdateAprove_Requester(GridView3.GetRowCellValue(i, "Circulation"), Active_Form)
                                Call LoadGrid_Accounting()
                                Call LoadGrid_Purchase()
                                Call LoadGrid_CRClose()
                            Catch ex As Exception
                                'ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
                                'WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                            End Try

                        Else
                            XtraMessageBox.Show("Circulation Number : '" & fs_Code & "' has been Submitted  ?", "Confirmation", MessageBoxButtons.OK)
                        End If

                    End If
                Next
                'XtraMessageBox.Show("Data Saved", "Information", MessageBoxButtons.OK)
                'Call LoadGrid(gh_Common.GroupID)
            End If
        End If

    End Sub

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.SelectedIndexChanged
        SelectTab = TabControl1.SelectedTab.Name
    End Sub

    Private Sub Grid6_DoubleClick(sender As Object, e As EventArgs) Handles Grid6.DoubleClick
        Active_Form = 8
        Try
            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            IdTrans = String.Empty

            'fc_ClassCRUD = New ClsCR_CreateUser
            Dim selectedRows() As Integer = GridView6.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    IdTrans = GridView6.GetRowCellValue(rowHandle, "Circulation No")
                End If
            Next rowHandle

            If GridView6.GetSelectedRows.Length > 0 Then
                Call CallFrm(IdTrans,
                            Format(Tanggal, gs_FormatSQLDate),
                            GridView6.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub
End Class
