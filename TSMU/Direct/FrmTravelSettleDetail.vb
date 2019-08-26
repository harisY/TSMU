﻿Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports TSMU
Public Class FrmTravelSettleDetail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    ''   Dim fc_Class As New ClsTravel
    Dim ObjTravelHeader As New TravelHeaderModel
    Dim ObjTravelDetail As New TravelDetailModel
    Dim GridDtl As GridControl
    Dim f As FrmTravel_Detail2
    Dim dt As New DataTable
    Dim fs_Split As String = "'"
    Dim lg_Grid As DataGridView
    Dim boomId As String = String.Empty
    Dim dtGrid As New DataTable
    Dim DtScan As DataTable
    Dim DtScan2 As DataTable
    Dim DtScan3 As DataTable
    Dim DtScan4 As DataTable


    ''   Dim ObjTravel As New ClsTravel
    Dim ls_Judul As String = ""
    Dim dtSearch As New DataTable
    Dim ls_OldKode As String = ""
    Dim _TravelID As String = ""

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal strCode As String,
                   ByVal strCode2 As String,
                   ByRef lf_FormParent As Form,
                   ByVal li_GridRow As Integer,
                   ByRef _Grid As GridControl)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
            fs_Code2 = strCode2
            bi_GridParentRow = li_GridRow
        End If
        GridDtl = _Grid
        FrmParent = lf_FormParent
    End Sub
    Private Sub CreateTable()
        DtScan = New DataTable
        DtScan.Columns.AddRange(New DataColumn(6) {New DataColumn("Account", GetType(String)),
                                                            New DataColumn("SubAccount", GetType(String)),
                                                            New DataColumn("Description", GetType(String)),
                                                            New DataColumn("Amount", GetType(Double)),
                                                            New DataColumn("CuryID", GetType(String)),
                                                            New DataColumn("TSC Rare", GetType(String)),
                                                            New DataColumn("IDR Amount", GetType(Double))})
        Grid.DataSource = DtScan
        GridView2.OptionsView.ShowAutoFilterRow = False

    End Sub
    Private Sub FrmTravel_Detail2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False, True)
        '' Call Proc_EnableButtons(True, True, True, True, True, True, True, True, True, True)
        ''Call CreateTable()
        Call InitialSetForm()

        GridView2.AddNewRow()
        GridView2.OptionsNavigation.AutoFocusNewRow = True
        GridView2.FocusedColumn = GridView2.VisibleColumns(0)


    End Sub
    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                ObjTravelHeader.TravelHeaderID = fs_Code
                ObjTravelHeader.GetTravelById()
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "Travel " & fs_Code
            Else
                Me.Text = "Travel"
            End If
            Call LoadTxtBox()
            LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "frmTravel"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Public Sub LoadGridDetail()
        Try
            If fs_Code <> "" Then
                Dim dtGrid As New DataTable
                ObjTravelDetail.TravelID = TxtNoTravel.Text
                dtGrid = ObjTravelDetail.GetDataDetailByID2()
                Grid.DataSource = dtGrid
                If dtGrid.Rows.Count > 0 Then
                    GridCellFormat(GridView2)
                End If
            Else
                Dim dtGrid As New DataTable
                Dim dtGrid2 As New DataTable
                Dim dtGrid3 As New DataTable
                Dim dtGrid4 As New DataTable
                Dim dtGrid5 As New DataTable
                Dim dtGrid6 As New DataTable
                Dim dtGrid7 As New DataTable
                ObjTravelDetail.TravelID = ""
                dtGrid = ObjTravelDetail.GetDataDetailByIDTICKET()
                Grid.DataSource = dtGrid

                dtGrid2 = ObjTravelDetail.GetDataDetailByIDTRANSPORTATION()
                Grid2.DataSource = dtGrid2

                dtGrid3 = ObjTravelDetail.GetDataDetailByIDHOTEL()
                Grid3.DataSource = dtGrid3

                dtGrid4 = ObjTravelDetail.GetDataDetailByIDENTERTAINMENT()
                Grid4.DataSource = dtGrid4

                dtGrid5 = ObjTravelDetail.GetDataDetailByIDPOCKET()
                Grid5.DataSource = dtGrid5

                dtGrid6 = ObjTravelDetail.GetDataDetailByIDBTRIP()
                Grid6.DataSource = dtGrid6

                dtGrid7 = ObjTravelDetail.GetDataDetailByIDOTHERS()
                Grid7.DataSource = dtGrid7
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "" Then
                With ObjTravelHeader
                    TxtNoTravel.Text = .TravelID
                    TxtNama.Text = .Nama
                    'TxtCurrency.SelectedText = .Currency
                    TxtDep.Text = .DeptID
                    TxtDestination.Text = .Destination
                    txtPurpose.Text = .Purpose
                    TxtTerm.Text = .Term
                    txtPickUp.Text = .PickUp
                    txtVisa.Text = .Visa
                    TxtTgl.EditValue = .Tgl
                    TxtTotalAdvanceIDR.Text = .TotalAdvanceIDR
                    TxtTotalAdvanceYEN.Text = .TotalAdvanceYEN
                    TxtTotalAdvanceUSD.Text = .TotalAdvanceUSD
                    TxtTotIDR.Text = .TotalAdvIDR
                    TxtArrDate.EditValue = .Arrdate
                    TxtDepDate.EditValue = .Depdate
                End With
                GridView2.AddNewRow()
                GridView2.OptionsNavigation.AutoFocusNewRow = True
            Else
                TxtNama.Text = ""
                TxtNoTravel.Text = ""
                TxtDep.Text = ""
                TxtDestination.Text = ""
                txtVisa.Text = "Yes"
                txtPurpose.Text = ""
                txtPickUp.Text = ""
                TxtTgl.EditValue = DateTime.Today
                TxtTotalAdvanceIDR.Text = "0"
                TxtTotalAdvanceYEN.Text = "0"
                TxtTotalAdvanceUSD.Text = "0"
                TxtTotIDR.Text = "0"
                TxtArrDate.EditValue = DateTime.Today
                TxtDepDate.EditValue = DateTime.Today
                'TxtPrNo.Focus()
                GridView2.AddNewRow()
                GridView2.OptionsNavigation.AutoFocusNewRow = True

            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        Call LoadTxtBox()
        LoadGridDetail()
    End Sub
    Public Overrides Function ValidateSave() As Boolean
        Dim lb_Validated As Boolean = False
        Try

            If DxValidationProvider1.Validate Then
                lb_Validated = True
            Else
                Err.Raise(ErrNumber, , "Data yang anda input tidak valid, silahkan cek inputan anda !")
            End If

            If lb_Validated Then
                With ObjTravelHeader
                    .TravelID = .TravelAutoNo
                    _TravelID = .TravelAutoNo
                    .Nama = TxtNama.Text
                    .DeptID = TxtDep.Text
                    .Destination = TxtDestination.Text
                    .Purpose = txtPurpose.Text
                    TxtTerm.Text = .Term
                    .PickUp = txtPickUp.Text
                    .Visa = txtVisa.Text
                    .Tgl = TxtTgl.EditValue
                    .TotalAdvanceIDR = TxtTotalAdvanceIDR.Text
                    .TotalAdvanceYEN = TxtTotalAdvanceYEN.Text
                    .TotalAdvanceUSD = TxtTotalAdvanceUSD.Text
                    TxtTotIDR.Text = .TotalAdvIDR
                    .Arrdate = TxtArrDate.EditValue
                    .Depdate = TxtDepDate.EditValue

                    ''.Total = TxtTotal.Text
                    'If isUpdate = False Then
                    '    .ValidateInsert()
                    'Else
                    '    .ValidateUpdate()
                    'End If
                End With
            End If
        Catch ex As Exception
            lb_Validated = False
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
        Return lb_Validated
    End Function
    Private Sub GAccount_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles GAccount.ButtonClick, GAccountTran.ButtonClick
        Try
            ObjTravelHeader = New TravelHeaderModel
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            Dim editor As ButtonEdit = CType(sender, ButtonEdit)

            If editor.AccessibleName = GAccount.Name Then
                dtSearch = ObjTravelHeader.GetAccount
                ls_OldKode = IIf(GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Account") Is DBNull.Value, "", GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Account"))
                ls_Judul = "Account"
            ElseIf editor.AccessibleName = GAccountTran.Name Then
                dtSearch = ObjTravelHeader.GetAccount
                ls_OldKode = IIf(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "Account") Is DBNull.Value, "", GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "Account"))
                ls_Judul = "Account Tran"
            End If

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
                If editor.AccessibleName = GAccount.Name Then
                    GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "Account", Value1)
                ElseIf editor.AccessibleName = GAccountTran.Name Then
                    GridView3.SetRowCellValue(GridView3.FocusedRowHandle, "Account", Value1)
                End If

            End If
                lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub GAccount_EditValueChanged(sender As Object, e As EventArgs) Handles GAccount.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

    End Sub
    Public Sub CallForm(Optional ByVal ID As String = "", Optional ByVal Nama As String = "", Optional ByVal IsNew As Boolean = True)

        'f = New FrmTravel_Detail2(ID, Nama, IsNew, dt, Grid)
        'f.StartPosition = FormStartPosition.CenterScreen
        'f.MaximizeBox = False
        'f.ShowDialog()

    End Sub
    Public Overrides Sub Proc_Approve()
        ''CallForm()
    End Sub
    Public Overrides Sub Proc_SaveData()
        Try
            Dim IsEmpty As Boolean = False
            For i As Integer = 0 To GridView2.RowCount - 1
                GridView2.MoveFirst()
                If GridView2.GetRowCellValue(i, GridView2.Columns("Account")).ToString = "" OrElse
                   GridView2.GetRowCellValue(i, GridView2.Columns("SubAccount")).ToString = "" OrElse
                   GridView2.GetRowCellValue(i, GridView2.Columns("Amount")).ToString = "" Then
                    IsEmpty = True
                    GridView2.DeleteRow(i)
                End If
            Next
            'If IsEmpty Then
            '    Throw New Exception("Silahkan Hapus dulu baris yang kosong !")
            'End If

            If isUpdate = False Then
                ObjTravelHeader.ObjDetails.Clear()
                For i As Integer = 0 To GridView2.RowCount - 1
                    If GridView2.GetRowCellValue(i, "Account") <> "" Then
                        ObjTravelDetail = New TravelDetailModel
                        With ObjTravelDetail
                            .TravelID = _TravelID
                            .AcctID = GridView2.GetRowCellValue(i, "Account").ToString().TrimEnd
                            .Amount = Convert.ToDouble(GridView2.GetRowCellValue(i, "Amount"))
                            .Description = GridView2.GetRowCellValue(i, "Description").ToString()
                            .SubAcct = GridView2.GetRowCellValue(i, "SubAccount")
                            .CuryID = GridView2.GetRowCellValue(i, "CuryID")
                            .Rate = GridView2.GetRowCellValue(i, "Rate")
                            .AmountIDR = Convert.ToDouble(GridView2.GetRowCellValue(i, "AmountIDR"))
                        End With
                        ObjTravelHeader.ObjDetails.Add(ObjTravelDetail)
                    End If
                Next
                ObjTravelHeader.InsertData()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                ObjTravelHeader.ObjDetails.Clear()
                For i As Integer = 0 To GridView2.RowCount - 1
                    If GridView2.GetRowCellValue(i, "Account") <> "" Then
                        ObjTravelDetail = New TravelDetailModel
                        With ObjTravelDetail
                            .TravelID = TxtNama.Text
                            .AcctID = GridView2.GetRowCellValue(i, "Account").ToString().TrimEnd
                            .Amount = Convert.ToDouble(GridView2.GetRowCellValue(i, "Amount"))
                            .Description = GridView2.GetRowCellValue(i, "Description").ToString()
                            .SubAcct = GridView2.GetRowCellValue(i, "SubAccount")
                        End With
                        ObjTravelHeader.ObjDetails.Add(ObjTravelDetail)
                    End If
                Next
                ''ObjTravelHeader.UpdateData()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            End If
            GridDtl.DataSource = ObjTravelHeader.GetDataGrid()
            IsClosed = True
            Me.Hide()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Function GetTotIdr() As Decimal
        Dim _totalidr1 As Decimal = 0

        Try
            For i As Integer = 0 To GridView2.RowCount - 1
                If Not IsDBNull(GridView2.GetRowCellValue(i, "Amount")) Then
                    If GridView2.GetRowCellValue(i, "CuryID") = "IDR" Then
                        _totalidr1 = _totalidr1 + Convert.ToDecimal(GridView2.GetRowCellValue(i, "Amount"))
                    End If

                End If
            Next
            Return _totalidr1

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Private Function GetTotUSD() As Decimal
        Dim _totalusd1 As Decimal = 0
        Dim _totalusd2 As Decimal = 0
        Dim _totalusd3 As Decimal = 0
        Dim _totalusd4 As Decimal = 0
        Try
            For i As Integer = 0 To GridView2.RowCount - 1
                If Not IsDBNull(GridView2.GetRowCellValue(i, "Amount")) Then
                    If GridView2.GetRowCellValue(i, "CuryID") = "USD" Then
                        _totalusd1 = _totalusd1 + Convert.ToDecimal(GridView2.GetRowCellValue(i, "Amount"))
                    End If

                End If
            Next


            Return _totalusd1

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Private Function GetTotYEN() As Decimal
        Dim _totalYEN1 As Decimal = 0
        Dim _totalYEN2 As Decimal = 0
        Dim _totalYEN3 As Decimal = 0
        Dim _totalYEN4 As Decimal = 0
        Try
            For i As Integer = 0 To GridView2.RowCount - 1
                If Not IsDBNull(GridView2.GetRowCellValue(i, "Amount")) Then
                    If GridView2.GetRowCellValue(i, "CuryID") = "YEN" Then
                        _totalYEN1 = _totalYEN1 + Convert.ToDecimal(GridView2.GetRowCellValue(i, "Amount"))
                    End If

                End If
            Next


            Return _totalYEN1

        Catch ex As Exception
            Throw ex
        End Try

    End Function
    Private Sub GAmount_EditValueChanged(sender As Object, e As EventArgs)
        'Dim baseEdit = TryCast(sender, BaseEdit)
        'Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        'gridView.PostEditor()
        'gridView.UpdateCurrentRow()
    End Sub




    Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
        'Dim ignoreCancel As Boolean = False
        'TxtPrNo.DoValidate()
        'TxtDep.DoValidate()

        'If DxValidationProvider1.GetInvalidControls().Contains(TxtPrNo) _
        '    OrElse DxValidationProvider1.GetInvalidControls().Contains(TxtDep) Then
        '    ignoreCancel = True
        'Else
        '    ignoreCancel = True
        'End If

        'MyBase.OnFormClosing(e)''
        'e.Cancel = Not ignoreCancel
        ''Me.Close()
    End Sub
    'Private Sub GridView2_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView2.CellValueChanged
    '    Dim Total As Double = 0
    '    For i As Integer = 0 To GridView2.RowCount - 1
    '        If Not GridView2.GetRowCellValue(i, "Amount") Is DBNull.Value Then
    '            Total = Total + GridView2.GetRowCellValue(i, "Amount")
    '        End If
    '    Next
    '    ''TxtTotal.Text = Format(Total, gs_FormatBulat)
    'End Sub

    Private Sub FrmTravel_Detail2_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            GridView2.AddNewRow()
            GridView2.OptionsNavigation.AutoFocusNewRow = True
            GridView2.FocusedColumn = GridView2.VisibleColumns(0)

        End If
    End Sub

    Private Sub TxtDep_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtDep.ButtonClick
        Try
            ObjTravelHeader = New TravelHeaderModel
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = ObjTravelHeader.GetDept
            ls_OldKode = TxtDep.Text
            ls_Judul = "Departemen"


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
                TxtDep.Text = Value1
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub GridView2_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView2.CellValueChanged
        Dim _totalidr1 As Decimal = 0
        Dim _totalusd1 As Decimal = 0
        Dim _totalyen1 As Decimal = 0
        Dim _totalidr2 As Decimal = 0
        Try
            For i As Integer = 0 To GridView2.RowCount - 1
                If Not IsDBNull(GridView2.GetRowCellValue(i, "Amount")) Then
                    If GridView2.GetRowCellValue(i, "CuryID") = "IDR" Then
                        _totalidr1 = _totalidr1 + Convert.ToDecimal(GridView2.GetRowCellValue(i, "Amount"))
                        ' _totalidr2 = _totalidr2 + (Convert.ToDecimal(GridView2.GetRowCellValue(i, "Amount")) * Convert.ToDecimal(GridView2.GetRowCellValue(i, "Rate")))

                    End If
                    If GridView2.GetRowCellValue(i, "CuryID") = "USD" Then
                        _totalusd1 = _totalusd1 + Convert.ToDecimal(GridView2.GetRowCellValue(i, "Amount"))
                    End If
                    If GridView2.GetRowCellValue(i, "CuryID") = "YEN" Then
                        _totalyen1 = _totalyen1 + Convert.ToDecimal(GridView2.GetRowCellValue(i, "Amount"))
                    End If
                    _totalidr2 = _totalidr2 + Convert.ToDecimal(GridView2.GetRowCellValue(i, "AmountIDR"))
                End If
            Next
            ''Return _totalidr1

            TxtTotalAdvanceIDR.Text = Format(_totalidr1, gs_FormatBulat)
            TxtTotalAdvanceUSD.Text = Format(_totalusd1, gs_FormatBulat)
            TxtTotalAdvanceYEN.Text = Format(_totalyen1, gs_FormatBulat)
            TxtTotIDR.Text = Format(_totalidr2, gs_FormatBulat)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub jmltot_EditValueChanged(sender As Object, e As EventArgs) Handles jmltot.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Amount")
        Dim vrate As Single = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Rate")
        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "AmountIDR", jumlah * vrate)
    End Sub
    Private Sub Grate_EditValueChanged(sender As Object, e As EventArgs) Handles Grate.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double = 0

        ''Dim jumlah As Double = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Amount")

        jumlah = IIf(GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Amount") Is DBNull.Value, "0", GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Amount"))

        Dim vrate As Single = GridView2.GetRowCellValue(GridView2.FocusedRowHandle, "Rate")
        GridView2.SetRowCellValue(GridView2.FocusedRowHandle, "AmountIDR", jumlah * vrate)
    End Sub
    Private Sub IDRAmt_EditValueChanged(sender As Object, e As EventArgs) Handles IDRAmt.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub Grid_DoubleClick(sender As Object, e As EventArgs) Handles Grid.DoubleClick
        GridView2.AddNewRow()
        GridView2.OptionsNavigation.AutoFocusNewRow = True
        GridView2.FocusedColumn = GridView2.VisibleColumns(0)

    End Sub
End Class