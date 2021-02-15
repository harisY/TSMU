Imports System.Globalization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class Frm_CR_UserCreateHeader

    Dim ff_Detail As Frm_CR_UserCreateDetail
    Dim dtGrid As DataTable
    Dim fc_Class As New CR_UserCreateModel
    Dim fc_ClassCRUD As New ClsCR_CreateUser
    Dim fc_Class_PC As New clsCR_Accounting
    Dim fc_Class_ApproveDeptHead As New clsCR_ApproveDeptHead
    Dim IdTrans As String
    Dim Dept As String
    Dim Tanggal As Date
    Dim DeptSub As String = ""
    Dim Active_Form As Integer = 1
    Dim GService As New GlobalService
    Dim _level As Integer
    Dim Division As Integer
    Dim Director As Integer

    Dim pDate2 As Date
    Dim pDate1 As Date

    Private Sub Frm_CR_UserCreateHeader_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        If gh_Common.GroupID <> "1PUR" Then
            'TabControl1.TabPages.Remove(TabPage1)
            TabControl1.TabPages.Remove(TabPage2)
        End If

        If gh_Common.GroupID = "1PUR" Then
            Call LoadGrid_Purchase()
        End If

        bb_SetDisplayChangeConfirmation = False
        Dept = gh_Common.GroupID
        Call LoadGrid(Dept)


        'Call Sub_Dept(gh_Common.GroupID)
        Dim dtGrid As New DataTable
        Call Proc_EnableButtons(True, False, True, True, True, False, False, False, False, False, True, True)
    End Sub
    Private Sub Sub_Dept(Dept_Sub As String)
        Try

            Dim dt As New DataTable
            dt = fc_ClassCRUD.Get_Dept_Sub(Dept_Sub)
            If dt.Rows.Count <= 0 Then
                MessageBox.Show("Sub Tidak Ditemukan",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)

                Exit Sub
            Else
                DeptSub = (dt.Rows(0).Item("Sub"))
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Private Sub LoadGrid(Dept As String)
        Try
            Cursor.Current = Cursors.WaitCursor

            pDate2 = Date.Now.AddMonths(3)
            pDate1 = Date.Now.AddMonths(-3)

            Dim dt As New DataTable

            dt = fc_Class.Get_CRRequest(Dept, pDate1, pDate2)
            Grid.DataSource = dt
            Cursor.Current = Cursors.Default


            If gh_Common.GroupID = "1PUR" Then
                Call LoadGrid_Purchase()
            End If


        Catch ex As Exception
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    Private Sub LoadGrid_Purchase()
        Try
            Cursor.Current = Cursors.WaitCursor
            Dim dt As New DataTable
            dt = fc_Class_PC.Get_Cek_Purchase()
            GridPurchase.DataSource = dt
            Call Proc_EnableButtons(False, False, False, True, True, False, False, False)
            'Call Grid_Properties()

        Catch ex As Exception
            ' Cursor.Current = Cursors.Default
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_InputNewData()
        Active_Form = 1
        CallFrm()
    End Sub

    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        If Active_Form = 1 Then
            ff_Detail = New Frm_CR_UserCreateDetail(ls_Code, ls_Code2, Me, li_Row, Grid, Active_Form)
        ElseIf Active_Form = 6 Then
            ff_Detail = New Frm_CR_UserCreateDetail(ls_Code, ls_Code2, Me, li_Row, GridPurchase, Active_Form)
        End If
        ff_Detail.MdiParent = FrmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    Public Overrides Sub Proc_Refresh()
        bs_Filter = ""
        Call LoadGrid(gh_Common.GroupID)
    End Sub

    Public Overrides Sub Proc_Filter()
        FilterData.Text = "Filter Data Group"
        FilterData.ShowDialog()
        If Not FilterData.isCancel Then
            bs_Filter = FilterData.strWhereClauseWithoutWhere
            Call FilterGrid()
        End If
        FilterData.Hide()
    End Sub
    Private Sub FilterGrid()
        Try
            Dim dv As New DataView(dtGrid)
            dv.RowFilter = bs_Filter
            dtGrid = dv.ToTable
            Grid.DataSource = dtGrid
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_DeleteData()
        Dim IDTrans As String = ""

        Try
            'fc_Class.ObjDetails.Clear()
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            'ObjMaterialUsageDetail = New MaterialUsageDetailModel

            If GridView1.RowCount > 0 Then
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        'ObjMaterialUsageDetail.IDMaterialUsage = GridView1.GetRowCellValue(rowHandle, "IDMaterialUsage")
                        IDTrans = GridView1.GetRowCellValue(rowHandle, "Circulation No")
                    End If
                Next rowHandle

                Try

                    ' Dim Bulan As String = Format(((T_RemainingBudget.EditValue), "MM") - 1)
                    Dim dt As New DataTable
                    dt = fc_ClassCRUD.Get_Data_CR_Delete(IDTrans, gh_Common.GroupID)
                    If dt.Rows.Count <= 0 Then
                        MessageBox.Show("Circulation '" & IDTrans & "' Cannot Delete",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)

                        Exit Sub
                    Else

                        fc_ClassCRUD.Delete(IDTrans, gh_Common.GroupID)
                        Call LoadGrid(gh_Common.GroupID)
                        Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)
                    End If
                Catch ex As Exception
                    Throw
                End Try
            Else
                MessageBox.Show("No Data Found")
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub


    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick
        Try

            Active_Form = 1

            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            IdTrans = String.Empty

            'fc_ClassCRUD = New ClsCR_CreateUser
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

    Private Sub GridView1_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView1.RowStyle
        Dim View As GridView = sender
        If (e.RowHandle >= 0) Then
            Dim category As String = View.GetRowCellDisplayText(e.RowHandle, View.Columns("Status"))
            If category = "Revise" Then
                e.Appearance.BackColor = Color.Yellow
                'e.Appearance.BackColor2 = Color.Yellow
                e.HighPriority = True
            ElseIf category = "Create" Then
                e.Appearance.BackColor = Color.Green
                'e.Appearance.BackColor2 = Color.Yellow
                e.HighPriority = True
            End If
        End If
    End Sub

    Public Overrides Sub Proc_Search()

        Try
            Dim Status As List(Of String) = New List(Of String)({"ALL", "Create", "Submit", "Revise", "Approve Dept Head", "Approve Div Head", "Submit To NPD"})

            Dim fSearch As New frmSearch()
            With fSearch
                .StartPosition = FormStartPosition.CenterScreen
                .ShowDialog()

                dtGrid = fc_Class.Get_CRRequest(Dept, If(IsDBNull(.TglDari), Format(Date.Today, gs_FormatSQLDate), .TglDari), If(IsDBNull(.TglSampai), Format(Date.Today, gs_FormatSQLDate), .TglSampai))
                Grid.DataSource = dtGrid


                'dt = fc_Class.Get_CRRequest(Dept, pDate1, pDate2)
                'Grid.DataSource = dt


            End With
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try





    End Sub



    'Private Sub Grid_Properties()
    '    Try
    '        With GridPurchase

    '            .Columns("Circulation").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
    '            .Columns("Circulation").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
    '            .Columns("Circulation").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
    '            '.Columns("Term").DisplayFormat.FormatString = "c2"
    '            '.Columns("Date").Width = 20
    '            .Columns("Tgl").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
    '            .Columns("Tgl").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
    '            .Columns("Tgl").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
    '            '.Columns("%").Width = 2
    '            .Columns("Dept").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
    '            .Columns("Dept").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
    '            .Columns("Dept").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False

    '            .Columns("Status").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
    '            .Columns("Status").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
    '            .Columns("Status").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False

    '            .Columns("Approved").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
    '            .Columns("Approved").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
    '            .Columns("Approved").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False

    '            .Columns("IDR").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
    '            .Columns("IDR").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Default
    '            .Columns("IDR").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
    '            .Columns("IDR").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
    '            .Columns("IDR").DisplayFormat.FormatString = "{0:N2}"
    '            .Columns("IDR").Width = 100

    '            .Columns("USD").AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
    '            .Columns("USD").AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
    '            .Columns("USD").OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
    '            .Columns("USD").DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
    '            .Columns("USD").DisplayFormat.FormatString = "{0:N2}"
    '        End With
    '    Catch ex As Exception

    '    End Try
    'End Sub

    'Private Sub Grid2_DoubleClick(sender As Object, e As EventArgs)
    '    Active_Form = 6
    '    Try
    '        Dim provider As CultureInfo = CultureInfo.InvariantCulture
    '        IdTrans = String.Empty
    '        Dim selectedRows() As Integer = GridView2.GetSelectedRows()
    '        For Each rowHandle As Integer In selectedRows
    '            If rowHandle >= 0 Then
    '                IdTrans = GridView2.GetRowCellValue(rowHandle, "Circulation")
    '            End If
    '        Next rowHandle

    '        If GridView2.GetSelectedRows.Length > 0 Then
    '            Call CallFrm(IdTrans,
    '                        Format(Tanggal, gs_FormatSQLDate),
    '                        GridView2.RowCount)
    '        End If
    '    Catch ex As Exception
    '        Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
    '        WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
    '    End Try
    'End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        Try
            Dim R As Boolean
            Dim selectedRows() As Integer = GridView1.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    R = GridView1.GetRowCellValue(rowHandle, "Requester")
                End If
            Next rowHandle

            If R = False Then
                GridView1.Columns("Submit").OptionsColumn.AllowEdit = True
            Else
                GridView1.Columns("Submit").OptionsColumn.AllowEdit = False
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub


    Public Overrides Sub Proc_Approve()

        Dim Active_Form As Integer = 1
        GService = New GlobalService
        _level = GService.GetLevel_str("CIRCULATION")

        Dim dtRoot As DataTable
        dtRoot = fc_Class_ApproveDeptHead.Get_Root_Approve_ByDept(gh_Common.GroupID)

        If dtRoot.Rows.Count > 0 Then
            Division = dtRoot.Rows(0).Item("div_Id")
            Director = dtRoot.Rows(0).Item("director_Id")
        End If

        Dim _Check1 As Boolean = False
        For i As Integer = 0 To GridView1.RowCount - 1
            Dim _Check As Boolean = IIf(GridView1.GetRowCellValue(i, "Submit") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(i, "Submit")))
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


                For i As Integer = 0 To GridView1.RowCount - 1
                    Dim _Submit As Boolean = IIf(GridView1.GetRowCellValue(i, "Submit") Is DBNull.Value, False, Convert.ToBoolean(GridView1.GetRowCellValue(i, "Submit")))
                    If _Submit = True Then
                        fc_ClassCRUD.GetDataByID(GridView1.GetRowCellValue(i, "Circulation No"))
                        If fc_ClassCRUD.H_Status = "Create" Or fc_ClassCRUD.H_Status = "Revise" Then

                            Try
                                fc_ClassCRUD = New ClsCR_CreateUser
                                With fc_ClassCRUD
                                    .H_UserSubmition = 1
                                    .H_Status = "Submit"
                                    .H_Current_Level = Active_Form
                                    .TA_Username = gh_Common.Username
                                    .TA_MenuCode = "CIRCULATION"
                                    .TA_DeptID = gh_Common.GroupID
                                    .TA_NoTransaksi = GridView1.GetRowCellValue(i, "Circulation No")
                                    .TA_LevelApprove = Active_Form
                                    .TA_StatusApprove = "Submit"
                                    .TA_ApproveBy = gh_Common.Username
                                    .TA_ApproveDAte = Date.Now
                                    .TA_IsActive = 1
                                End With
                                fc_ClassCRUD.UpdateAprove_Requester(GridView1.GetRowCellValue(i, "Circulation No"), Active_Form)
                            Catch ex As Exception
                                'ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
                                'WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
                            End Try

                        Else
                            XtraMessageBox.Show("Circulation Number : '" & fs_Code & "' has been Submitted  ?", "Confirmation", MessageBoxButtons.OK)
                        End If

                    End If
                Next
                Timer1.Enabled = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                Call LoadGrid(gh_Common.GroupID)
            End If
        End If

    End Sub

    Private Sub C_Submit_CheckedChanged(sender As Object, e As EventArgs) Handles C_Submit.CheckedChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        SendKeys.Send("{ENTER}")
        Timer1.Enabled = False
    End Sub

    Private Sub GridPurchase_DoubleClick(sender As Object, e As EventArgs) Handles GridPurchase.DoubleClick
        Active_Form = 6
        Try
            Dim provider As CultureInfo = CultureInfo.InvariantCulture
            IdTrans = String.Empty
            Dim selectedRows() As Integer = GridViewPurchase.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    IdTrans = GridViewPurchase.GetRowCellValue(rowHandle, "Circulation No")
                End If
            Next rowHandle

            If GridViewPurchase.GetSelectedRows.Length > 0 Then
                Call CallFrm(IdTrans,
                            Format(Tanggal, gs_FormatSQLDate),
                            GridViewPurchase.RowCount)
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
End Class
