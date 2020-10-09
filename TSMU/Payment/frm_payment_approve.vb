﻿Imports System.Configuration
Imports System.Data.OleDb
Imports System.Globalization
Imports DevExpress.Utils
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Base.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports DevExpress.XtraGrid.Views.Grid

Public Class frm_payment_approve
    Dim dtGrid As DataTable
    Dim dtGrid2 As New DataTable
    Dim dtGrid3 As New DataTable
    Dim ObPayment As New Cls_Payment
    Dim table As DataTable
    Dim tableDetail As DataTable
    Dim ff_Detail As frm_payment_aprrove_details
    Dim ObjPaymentHeader As New payment_header_models
    Dim ObjPaymentDetail As New payment_detail_models

    Dim FApproveDetail As FrmApprovalDetail
    Dim FrmApproveEntertain As FrmApprovalEntertain
    Dim ObjSuspend As New SuspendApprovalHeaderModel
    Dim TotLevel1 As Double
    Dim TotLevel2 As Double
    Dim TotCheckDetail As Double
    Dim TotDirektur As Double
    Dim TotLevel1b As Double
    Dim TotLevel2b As Double
    Dim TotCheckDetailb As Double
    Dim TotDirekturb As Double
    Dim TotApproved As Double
    Dim TotApPaid As Double
    Dim TotBPaid As Double
    Private Sub frm_payment_approve_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Dim dtGrid As New DataTable
        dtGrid = Grid.DataSource
        Call LoadGrid("")
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False, False)
        If gh_Common.Level = 1 Then
            TabControl1.TabPages.Remove(TabPage2)
            TabControl1.TabPages.Remove(TabPage3)
        Else
            TabControl1.SelectedTab = TabPage1
            LoadGridSuspend()
            LoadGridApprovedReject()
        End If
    End Sub


    Private Sub LoadGrid(BankID As String)
        Try
            dtGrid = ObjPaymentHeader.GetDataGridApproveByBank(gh_Common.Level, BankID)
            Grid.DataSource = dtGrid

            If GridView1.RowCount > 0 Then
                With GridView1
                    .Columns(0).Visible = False
                    .BestFitColumns()
                    '.FixedLineWidth = 1
                    '.Columns(1).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                    '.OptionsView.ColumnAutoWidth = True
                End With
                GridCellFormat(GridView1)
                If gh_Common.Level = 1 Then
                    GridView1.OptionsBehavior.Editable = False
                ElseIf gh_Common.Level = 2 Then
                    GridView1.OptionsBehavior.Editable = True
                    For i As Integer = 0 To GridView1.Columns.Count - 1
                        If GridView1.Columns(i).VisibleIndex <> 7 Then
                            GridView1.Columns(i).OptionsColumn.AllowEdit = False
                        Else
                            GridView1.Columns(i).OptionsColumn.AllowEdit = True
                        End If
                    Next

                    'GridView1.Columns(15).OptionsColumn.AllowEdit = False
                    'GridView1.Columns(16).OptionsColumn.AllowEdit = True
                    'GridView1.Columns(17).OptionsColumn.AllowEdit = False
                    'GridView1.Columns(18).OptionsColumn.AllowEdit = False
                ElseIf gh_Common.Level = 3 Then
                    GridView1.OptionsBehavior.Editable = True
                    For i As Integer = 0 To GridView1.Columns.Count - 1
                        If GridView1.Columns(i).VisibleIndex <> 8 Then
                            GridView1.Columns(i).OptionsColumn.AllowEdit = False
                        Else
                            GridView1.Columns(i).OptionsColumn.AllowEdit = True
                        End If
                    Next
                ElseIf gh_Common.Level = 4 Then

                    GridView1.OptionsBehavior.Editable = True
                    For i As Integer = 0 To GridView1.Columns.Count - 1

                        'If GridView1.GetRowCellValue(i, GridView1.Columns("CheckDetail")) = False Then
                        '    GridView1.Columns(i).AppearanceCell.BackColor = Color.Honeydew
                        '    GridView1.Columns(i).AppearanceCell.ForeColor = Color.Black
                        '    'ElseIf GridView1.GetRowCellValue(i, GridView1.Columns("CheckDetail")) = True Then
                        '    '    GridView1.Columns(i).AppearanceCell.BackColor = Color.White
                        '    '    GridView1.Columns(i).AppearanceCell.ForeColor = Color.Black
                        'End If


                        If GridView1.Columns(i).VisibleIndex <> 9 Then
                            GridView1.Columns(i).OptionsColumn.AllowEdit = False
                            ''GridView1.Columns(i).AppearanceCell.BackColor = Color.Honeydew
                            ''GridView1.Columns(i).AppearanceCell.ForeColor = Color.Black
                        Else
                            GridView1.Columns(i).OptionsColumn.AllowEdit = True
                        End If

                    Next






                    'GridView1.OptionsBehavior.Editable = True
                    'GridView1.Columns(15).OptionsColumn.AllowEdit = False
                    'GridView1.Columns(16).OptionsColumn.AllowEdit = False
                    'GridView1.Columns(17).OptionsColumn.AllowEdit = False
                    'GridView1.Columns(18).OptionsColumn.AllowEdit = True
                Else
                    GridView1.OptionsBehavior.Editable = False
                End If

            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Try
            'If e.Column.FieldName = "Level1" Then
            '    If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Level1") = True Then
            '        GetTot()
            '    End If
            'End If
            'If e.Column.FieldName = "Level2" Then
            '    If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Level2") = True Then
            '        GetTot()
            '    End If
            'End If
            'If e.Column.FieldName = "CheckDetail" Then
            '    If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "CheckDetail") = True Then
            '        GetTot()
            '    End If
            'End If
            'If e.Column.FieldName = "Direktur" Then
            '    If GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Direktur") = True Then
            '        GetTot()
            '    End If
            'End If


            GetTot()
            _txtapapproved.Text = Format(TotApproved, "#,#.##")
            _txtapbpaid.Text = Format(TotApPaid, "#,#.##")
            _txtamountbpaid.Text = Format(TotBPaid, "#,#.##")
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GetTot()
        TotLevel1 = 0
        TotLevel2 = 0
        TotCheckDetail = 0
        TotDirektur = 0
        TotLevel1b = 0
        TotLevel2b = 0
        TotCheckDetailb = 0
        TotDirekturb = 0

        Dim cek As Boolean
        Try
            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "Level1") = True Then
                    TotLevel1 = TotLevel1 + CDbl(GridView1.GetRowCellValue(i, "PaidAmount"))

                End If
                If GridView1.GetRowCellValue(i, "Level2") = True Then
                    TotLevel2 = TotLevel2 + CDbl(GridView1.GetRowCellValue(i, "PaidAmount"))
                End If
                If GridView1.GetRowCellValue(i, "CheckDetail") = True Then
                    TotCheckDetail = TotCheckDetail + CDbl(GridView1.GetRowCellValue(i, "PaidAmount"))
                End If
                If GridView1.GetRowCellValue(i, "Direktur") = True Then
                    TotDirektur = TotDirektur + CDbl(GridView1.GetRowCellValue(i, "PaidAmount"))
                End If
                TotLevel1b = TotLevel1b + CDbl(GridView1.GetRowCellValue(i, "PaidAmount"))
                TotLevel2b = TotLevel2b + CDbl(GridView1.GetRowCellValue(i, "PaidAmount"))
                TotCheckDetailb = TotCheckDetailb + CDbl(GridView1.GetRowCellValue(i, "PaidAmount"))
                TotDirekturb = TotDirekturb + CDbl(GridView1.GetRowCellValue(i, "PaidAmount"))
            Next
            If gh_Common.Level = 1 Then

                TotApproved = TotLevel1
                TotApPaid = TotLevel1b
            ElseIf gh_Common.Level = 2 Then

                TotApproved = TotLevel2
                TotApPaid = TotLevel2b

            ElseIf gh_Common.Level = 3 Then

                TotApproved = TotCheckDetail
                TotApPaid = TotCheckDetailb
            Else


                'TotApproved = TotDirektur
                'TotApPaid = TotDirekturb


                TotApproved = TotDirektur
                'TotApPaid = TotDirekturb
                TotApPaid = TotLevel2
            End If
            If gh_Common.Level > 3 Then
                TotBPaid = TotLevel1
            Else
                TotBPaid = _txtsaldo.Text - TotApproved
            End If


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub LoadGridSuspend()
        Try
            dtGrid = ObjSuspend.GetDataGrid()
            GridSuspend.DataSource = dtGrid
            With GridView3
                .Columns(0).Visible = False
                .BestFitColumns()
                .FixedLineWidth = 2
            End With
            GridCellFormat(GridView3)
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub LoadGridApproved()
        Try
            ''DateEdit1.Text = ObjPaymentHeader.tglfrom + " 00:00:00"
            ''DateEdit2.Text = ObjPaymentHeader.tgluntil + " 00:00:00"
            dtGrid2 = ObjPaymentHeader.GetDataGridApproveDone(gh_Common.Level)
            GridApproved.DataSource = dtGrid2
            If GridView2.RowCount > 0 Then
                With GridView2
                    GridView2.Columns(0).Visible = False
                    GridView2.BestFitColumns()
                    GridView2.FixedLineWidth = 1
                    GridView2.Columns(0).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                    GridView2.OptionsView.ColumnAutoWidth = True
                End With
                GridCellFormat(GridView2)
                If gh_Common.Level = 1 Then
                    GridView2.OptionsBehavior.Editable = False
                ElseIf gh_Common.Level = 2 Then
                    GridView2.OptionsBehavior.Editable = True
                    For i As Integer = 0 To GridView2.Columns.Count - 1
                        If GridView2.Columns(i).VisibleIndex <> 16 Then
                            GridView2.Columns(i).OptionsColumn.AllowEdit = False
                        Else
                            GridView2.Columns(i).OptionsColumn.AllowEdit = True
                        End If
                    Next

                    'GridView2.Columns(15).OptionsColumn.AllowEdit = False
                    'GridView2.Columns(16).OptionsColumn.AllowEdit = True
                    'GridView2.Columns(17).OptionsColumn.AllowEdit = False
                    'GridView2.Columns(18).OptionsColumn.AllowEdit = False
                ElseIf gh_Common.Level = 3 Then
                    GridView2.OptionsBehavior.Editable = True
                    For i As Integer = 0 To GridView2.Columns.Count - 1
                        If GridView2.Columns(i).VisibleIndex <> 17 Then
                            GridView2.Columns(i).OptionsColumn.AllowEdit = False
                        Else
                            GridView2.Columns(i).OptionsColumn.AllowEdit = True
                        End If
                    Next
                ElseIf gh_Common.Level = 4 Then
                    GridView2.OptionsBehavior.Editable = True
                    For i As Integer = 0 To GridView2.Columns.Count - 1
                        If GridView2.Columns(i).VisibleIndex <> 18 Then
                            GridView2.Columns(i).OptionsColumn.AllowEdit = False
                        Else
                            GridView2.Columns(i).OptionsColumn.AllowEdit = True
                        End If
                    Next
                    'GridView2.OptionsBehavior.Editable = True
                    'GridView2.Columns(15).OptionsColumn.AllowEdit = False
                    'GridView2.Columns(16).OptionsColumn.AllowEdit = False
                    'GridView2.Columns(17).OptionsColumn.AllowEdit = False
                    'GridView2.Columns(18).OptionsColumn.AllowEdit = True
                Else
                    GridView2.OptionsBehavior.Editable = False
                End If
            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadGridApprovedReject()
        Try
            dtGrid3 = ObjPaymentHeader.GetDataGridReject1(gh_Common.Level)
            GridControl1.DataSource = dtGrid3
            If GridView4.RowCount > 0 Then
                With GridView4
                    .Columns(0).Visible = False
                    .BestFitColumns()
                    '.FixedLineWidth = 1
                    '.Columns(1).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
                    '.OptionsView.ColumnAutoWidth = True
                End With
                GridCellFormat(GridView4)
                If gh_Common.Level = 1 Then
                    GridView4.OptionsBehavior.Editable = False
                ElseIf gh_Common.Level = 2 Then
                    GridView4.OptionsBehavior.Editable = True
                    For i As Integer = 0 To GridView4.Columns.Count - 1
                        If GridView4.Columns(i).VisibleIndex <> 7 Then
                            GridView4.Columns(i).OptionsColumn.AllowEdit = False
                        Else
                            GridView4.Columns(i).OptionsColumn.AllowEdit = True
                        End If
                    Next
                    'GridView1.Columns(15).OptionsColumn.AllowEdit = False
                    'GridView1.Columns(16).OptionsColumn.AllowEdit = True
                    'GridView1.Columns(17).OptionsColumn.AllowEdit = False
                    'GridView1.Columns(18).OptionsColumn.AllowEdit = False
                ElseIf gh_Common.Level = 3 Then
                    GridView4.OptionsBehavior.Editable = True
                    For i As Integer = 0 To GridView4.Columns.Count - 1
                        If GridView4.Columns(i).VisibleIndex <> 8 Then
                            GridView4.Columns(i).OptionsColumn.AllowEdit = False
                        Else
                            GridView4.Columns(i).OptionsColumn.AllowEdit = True
                        End If
                    Next
                ElseIf gh_Common.Level = 4 Then
                    GridView4.OptionsBehavior.Editable = True
                    For i As Integer = 0 To GridView4.Columns.Count - 1
                        If GridView4.Columns(i).VisibleIndex <> 9 Then
                            GridView4.Columns(i).OptionsColumn.AllowEdit = False
                        Else
                            GridView4.Columns(i).OptionsColumn.AllowEdit = True
                        End If
                    Next
                    'GridView1.OptionsBehavior.Editable = True
                    'GridView1.Columns(15).OptionsColumn.AllowEdit = False
                    'GridView1.Columns(16).OptionsColumn.AllowEdit = False
                    'GridView1.Columns(17).OptionsColumn.AllowEdit = False
                    'GridView1.Columns(18).OptionsColumn.AllowEdit = True
                Else
                    GridView4.OptionsBehavior.Editable = False
                End If
            End If

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

        If gh_Common.Level <> 1 Then
            TabControl1.SelectedTab = TabPage1
            Call LoadGridApproved()
            LoadGridSuspend()
            LoadGridApprovedReject()
        End If
        Call LoadGrid("")

    End Sub
    Public Overrides Sub Proc_SaveData()
        Try
            If gh_Common.Level = 1 Then
                Exit Sub
            End If
            For i As Integer = 0 To GridView1.RowCount - 1
                If gh_Common.Level = 2 Then
                    If GridView1.GetRowCellValue(i, "Level2") = True Then
                        With ObjPaymentHeader
                            .cek2 = CBool(GridView1.GetRowCellValue(i, "Level2"))
                            .vrno = CStr(GridView1.GetRowCellValue(i, "VoucherNo"))
                            .UpdateCek(2)
                        End With

                    End If
                ElseIf gh_Common.Level = 3 Then
                    If GridView1.GetRowCellValue(i, "Level3") = True Then
                        With ObjPaymentHeader
                            .cek3 = CBool(GridView1.GetRowCellValue(i, "Level3"))
                            .vrno = CStr(GridView1.GetRowCellValue(i, "VoucherNo"))
                            .UpdateCek(3)
                        End With

                    End If
                ElseIf gh_Common.Level = 4 Then
                    If GridView1.GetRowCellValue(i, "Direktur") = True Then
                        With ObjPaymentHeader
                            .cek4 = CBool(GridView1.GetRowCellValue(i, "Direktur"))
                            .vrno = CStr(GridView1.GetRowCellValue(i, "VoucherNo"))
                            .UpdateCek(4)
                        End With

                    End If
                End If

            Next
            Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            tsBtn_refresh.PerformClick()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            'ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0, Optional ByVal IsNew As Boolean = True)
        If ff_Detail IsNot Nothing AndAlso ff_Detail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail.Close()
        End If
        ff_Detail = New frm_payment_aprrove_details(ls_Code, ls_Code2, Me, li_Row, Grid, IsNew)
        ff_Detail.MdiParent = frmMain
        ff_Detail.StartPosition = FormStartPosition.CenterScreen
        ff_Detail.Show()
    End Sub

    Private Sub CallFrmApprovalSuspend(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If FApproveDetail IsNot Nothing AndAlso FApproveDetail.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            FApproveDetail.Close()
        End If
        FApproveDetail = New FrmApprovalDetail(ls_Code, ls_Code2, Me, li_Row, Grid)
        FApproveDetail.MdiParent = frmMain
        FApproveDetail.StartPosition = FormStartPosition.CenterScreen
        FApproveDetail.Show()
    End Sub

    Private Sub CallFrmApprovalEntertain(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0)
        If FrmApproveEntertain IsNot Nothing AndAlso FrmApproveEntertain.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            FrmApproveEntertain.Close()
        End If
        FrmApproveEntertain = New FrmApprovalEntertain(ls_Code, ls_Code2, Me, li_Row, Grid)
        FrmApproveEntertain.MdiParent = frmMain
        FrmApproveEntertain.StartPosition = FormStartPosition.CenterScreen
        FrmApproveEntertain.Show()
    End Sub

    Public Overrides Sub Proc_DeleteData()
        Try
            'Dim fc_Class1 As New clsBoMTrans 
            'fc_Class1.BoMID = Trim(Grid.SelectedRows(0).Cells(0).Value)
            'fc_Class1.DeleteData()
            'Call ShowMessage(GetMessage(MessageEnum.HapusBerhasil), MessageTypeEnum.NormalMessage)
            'tsBtn_refresh.PerformClick()
            'Grid.RemoveItem(Grid.Row)
            'If Grid.Rows.Count > Grid.Rows.Fixed Then
            '    Call Proc_EnableButtons(True, False, True, True, True, True, False, False)
            'Else
            '    Call Proc_EnableButtons(True, False, False, True, True, True, False, False)
            'End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
    Dim NoVoucher, id As String
    Private editor As BaseEdit
    Private Sub frm_payment_approve_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try
            If TabControl1.SelectedIndex = 0 Then
                If e.KeyCode = Keys.F1 Then
                    NoVoucher = String.Empty
                    Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                    For Each rowHandle As Integer In selectedRows
                        If rowHandle >= 0 Then
                            id = GridView1.GetRowCellValue(rowHandle, "id")
                            NoVoucher = GridView1.GetRowCellValue(rowHandle, "vrno")
                        End If
                    Next rowHandle

                    If GridView1.GetSelectedRows.Length > 0 Then
                        'Dim objGrid As DataGridView = sender
                        Call CallFrm(id,
                                 NoVoucher,
                                 GridView1.RowCount, True)
                    End If
                End If
            Else
                If e.KeyCode = Keys.F1 Then
                    NoVoucher = String.Empty
                    Dim selectedRows() As Integer = GridView2.GetSelectedRows()
                    For Each rowHandle As Integer In selectedRows
                        If rowHandle >= 0 Then
                            id = GridView2.GetRowCellValue(rowHandle, "id")
                            NoVoucher = GridView2.GetRowCellValue(rowHandle, "vrno")
                        End If
                    Next rowHandle

                    If GridView2.GetSelectedRows.Length > 0 Then
                        'Dim objGrid As DataGridView = sender
                        Call CallFrm(id,
                                 NoVoucher,
                                 GridView2.RowCount, False)
                    End If
                End If
            End If


        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GridView1_DoubleClick(sender As Object, e As EventArgs) Handles GridView1.DoubleClick
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


                NoVoucher = String.Empty
                Dim selectedRows() As Integer = GridView1.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        id = GridView1.GetRowCellValue(rowHandle, "id")
                        NoVoucher = GridView1.GetRowCellValue(rowHandle, "vrno")
                    End If
                Next rowHandle

                If GridView1.GetSelectedRows.Length > 0 Then
                    'Dim objGrid As DataGridView = sender
                    Call CallFrm(id,
                             NoVoucher,
                             GridView1.RowCount, True)
                End If
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub


    Private Sub GridView4_DoubleClick(sender As Object, e As EventArgs) Handles GridView4.DoubleClick
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


                NoVoucher = String.Empty
                Dim selectedRows() As Integer = GridView4.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        id = GridView4.GetRowCellValue(rowHandle, "id")
                        NoVoucher = GridView4.GetRowCellValue(rowHandle, "vrno")
                    End If
                Next rowHandle

                If GridView4.GetSelectedRows.Length > 0 Then
                    'Dim objGrid As DataGridView = sender
                    Call CallFrm(id,
                             NoVoucher,
                             GridView4.RowCount, True)
                End If
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub


    Private Sub _txtBankId_ButtonClick(sender As Object, e As DevExpress.XtraEditors.Controls.ButtonPressedEventArgs) Handles _txtBankId.ButtonClick
        Try
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""
            Dim perpost As String = ""
            dtSearch = ObjPaymentDetail.GetBank
            ls_OldKode = _txtBankId.Text.Trim
            ls_Judul = "Bank"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()
            Dim Value1 As String = ""
            Dim Value2 As String = ""

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                Value1 = lF_SearchData.Values.Item(0).ToString.Trim
                Value2 = lF_SearchData.Values.Item(1).ToString.Trim
                _txtBankId.Text = Value2

                LoadGrid(Value1)

                Dim ObjCashBank As New cashbank_models
                Dim pppost As String
                pppost = Format(DateTime.Today, "yyyy-MM")

                Dim panjang As Integer = Microsoft.VisualBasic.Right(pppost, 2)
                panjang = Convert.ToInt32(panjang) + 1
                Dim bulanp As String = CStr(panjang)
                If panjang > 9 Then
                    ObjCashBank.Perpost = Microsoft.VisualBasic.Left(pppost, 5) + bulanp
                Else
                    ObjCashBank.Perpost = Microsoft.VisualBasic.Left(pppost, 6) + bulanp

                End If

                Dim saldo As Double
                ObjCashBank.account = Value1
                saldo = ObjCashBank.saldo2

                If saldo = 0 Then
                    _txtsaldo.Text = saldo
                Else
                    _txtsaldo.Text = Format(saldo, "#,#.##")
                End If
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GridView2_DoubleClick(sender As Object, e As EventArgs) Handles GridView2.DoubleClick
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


                NoVoucher = String.Empty
                Dim selectedRows() As Integer = GridView2.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        id = GridView2.GetRowCellValue(rowHandle, "id")
                        NoVoucher = GridView2.GetRowCellValue(rowHandle, "vrno")
                    End If
                Next rowHandle

                If GridView2.GetSelectedRows.Length > 0 Then
                    'Dim objGrid As DataGridView = sender
                    Call CallFrm(id,
                             NoVoucher,
                             GridView2.RowCount, False)
                End If
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Dim suspendid As String
    Private Sub GridView3_DoubleClick(sender As Object, e As EventArgs) Handles GridView3.DoubleClick
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

                id = String.Empty
                suspendid = String.Empty
                Dim selectedRows() As Integer = GridView3.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        id = GridView3.GetRowCellValue(rowHandle, "SuspendHeaderID")
                        suspendid = GridView3.GetRowCellValue(rowHandle, "SuspendID")
                    End If
                Next rowHandle

                If GridView3.GetSelectedRows.Length > 0 Then
                    'Dim objGrid As DataGridView = sender
                    If GridView1.GetRowCellValue(GridView3.FocusedRowHandle, "Tipe") = "S" Then
                        Call CallFrm(id,
                         suspendid,
                         GridView3.RowCount)
                    Else
                        Call CallFrmApprovalSuspend(id,
                         suspendid,
                         GridView3.RowCount)
                    End If
                End If


            End If

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub ChekLevel1_EditValueChanged(sender As Object, e As EventArgs) Handles ChekLevel1.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub ChekLevel2_EditValueChanged(sender As Object, e As EventArgs) Handles ChekLevel2.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub ChekLevel3_EditValueChanged(sender As Object, e As EventArgs) Handles ChekLevel3.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub



    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Call LoadGrid("")
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        LoadGridApproved()
    End Sub

    Friend Delegate Sub SetDataSourceDelegate(table As DataTable, _Grid As GridControl)
    Private Sub setDataSource(table As DataTable, _Grid As GridControl)
        ' Invoke method if required:
        If Me.InvokeRequired Then
            Me.Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table, _Grid)
        Else
            _Grid.DataSource = table
        End If
    End Sub

    Private Async Sub btnLoad_Click_1(sender As Object, e As EventArgs) Handles btnLoad.Click
        Try
            'If ProgBar.Visible = True Then
            '    Throw New Exception("Process already running, Please wait!")
            'End If
            ProgBar.Visible = True
            ProgBar.Style = ProgressBarStyle.Marquee
            Await Task.Run(Sub() GetDataApproved())
        Catch ex As Exception
            ProgBar.Visible = False
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GetDataApproved()
        Dim date1 As String = ""
        Dim date2 As String = ""
        'Dim date1 As DateTime
        'Dim date2 As DateTime
        Invoke(Sub()
                   date1 = DateEdit1.Text
                   date2 = DateEdit2.Text
               End Sub)
        Dim dt As New DataTable
        dt = ObjPaymentHeader.DataApproved(date1, date2)
        setDataSource(dt, GridApproved)
        Invoke(Sub()
                   ProgBar.Visible = False
               End Sub)
    End Sub

    Private Sub ChekDir_EditValueChanged(sender As Object, e As EventArgs) Handles ChekDir.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

End Class
