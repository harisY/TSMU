Imports DevExpress.XtraEditors
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

    Dim _totalidr1 As Decimal = 0
    Dim _totalusd1 As Decimal = 0
    Dim _totalyen1 As Decimal = 0
    Dim _totalidr2 As Decimal = 0

    Dim _totalidr12a As Decimal = 0
    Dim _totalusd12 As Decimal = 0
    Dim _totalyen12 As Decimal = 0
    Dim _totalidr22 As Decimal = 0

    Dim _totalidr13 As Decimal = 0
    Dim _totalusd13 As Decimal = 0
    Dim _totalyen13 As Decimal = 0
    Dim _totalidr23 As Decimal = 0

    Dim _totalidr14 As Decimal = 0
    Dim _totalusd14 As Decimal = 0
    Dim _totalyen14 As Decimal = 0
    Dim _totalidr24 As Decimal = 0

    Dim _totalidr15 As Decimal = 0
    Dim _totalusd15 As Decimal = 0
    Dim _totalyen15 As Decimal = 0
    Dim _totalidr25 As Decimal = 0

    Dim _totalidr16 As Decimal = 0
    Dim _totalusd16 As Decimal = 0
    Dim _totalyen16 As Decimal = 0
    Dim _totalidr26 As Decimal = 0

    Dim _totalidr17 As Decimal = 0
    Dim _totalusd17 As Decimal = 0
    Dim _totalyen17 As Decimal = 0
    Dim _totalidr27 As Decimal = 0

    Dim ff_Detail7 As FrmEntertainSettleDetailDirect
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
    Private Sub CallFrm(Optional ByVal ls_Code As String = "", Optional ByVal ls_Code2 As String = "", Optional ByVal li_Row As Integer = 0, Optional ByVal IsNew As Boolean = True)
        If ff_Detail7 IsNot Nothing AndAlso ff_Detail7.Visible Then
            If MsgBox(gs_ConfirmDetailOpen, MsgBoxStyle.OkCancel, "Confirmation") = MsgBoxResult.Cancel Then
                Exit Sub
            End If
            ff_Detail7.Close()
        End If
        ff_Detail7 = New FrmEntertainSettleDetailDirect(ls_Code, ls_Code2, Me, li_Row, Grid4)
        ff_Detail7.MdiParent = MenuUtamaForm
        ff_Detail7.StartPosition = FormStartPosition.CenterScreen
        ff_Detail7.Show()
    End Sub

    Private Sub EntertainID_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles EntertainID.ButtonClick
        Dim id As String = String.Empty
        Dim id2 As String = String.Empty

        Dim selectedRows() As Integer = GridView5.GetSelectedRows()
        For Each rowHandle As Integer In selectedRows
            If rowHandle >= 0 Then
                id = GridView5.GetRowCellValue(rowHandle, "SettleID")
                id2 = GridView5.GetRowCellValue(rowHandle, "ID")
            End If
        Next rowHandle

        Call CallFrm(id2, id,
                         GridView5.RowCount)
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
    Private Sub GAccount_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles GAccount.ButtonClick, GAccountTran.ButtonClick, GAccountHotel.ButtonClick, GAccountEnter.ButtonClick, GAccount5.ButtonClick, GAccount6.ButtonClick, GAccount7.ButtonClick
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
            ElseIf editor.AccessibleName = GAccountHotel.Name Then
                dtSearch = ObjTravelHeader.GetAccount
                ls_OldKode = IIf(GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "Account") Is DBNull.Value, "", GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "Account"))
                ls_Judul = "Account"
            ElseIf editor.AccessibleName = GAccountEnter.Name Then
                dtSearch = ObjTravelHeader.GetAccount
                ls_OldKode = IIf(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "Account") Is DBNull.Value, "", GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "Account"))
                ls_Judul = "Account"
            ElseIf editor.AccessibleName = GAccount5.Name Then
                dtSearch = ObjTravelHeader.GetAccount
                ls_OldKode = IIf(GridView6.GetRowCellValue(GridView6.FocusedRowHandle, "Account") Is DBNull.Value, "", GridView6.GetRowCellValue(GridView6.FocusedRowHandle, "Account"))
                ls_Judul = "Account"
            ElseIf editor.AccessibleName = GAccount6.Name Then
                dtSearch = ObjTravelHeader.GetAccount
                ls_OldKode = IIf(GridView7.GetRowCellValue(GridView7.FocusedRowHandle, "Account") Is DBNull.Value, "", GridView7.GetRowCellValue(GridView7.FocusedRowHandle, "Account"))
                ls_Judul = "Account"
            ElseIf editor.AccessibleName = GAccount7.Name Then
                dtSearch = ObjTravelHeader.GetAccount
                ls_OldKode = IIf(GridView8.GetRowCellValue(GridView8.FocusedRowHandle, "Account") Is DBNull.Value, "", GridView8.GetRowCellValue(GridView8.FocusedRowHandle, "Account"))
                ls_Judul = "Account"
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
                ElseIf editor.AccessibleName = GAccountHotel.Name Then
                    GridView4.SetRowCellValue(GridView4.FocusedRowHandle, "Account", Value1)
                ElseIf editor.AccessibleName = GAccountEnter.Name Then
                    GridView5.SetRowCellValue(GridView5.FocusedRowHandle, "Account", Value1)
                ElseIf editor.AccessibleName = GAccount5.Name Then
                    GridView6.SetRowCellValue(GridView6.FocusedRowHandle, "Account", Value1)
                ElseIf editor.AccessibleName = GAccount6.Name Then
                    GridView7.SetRowCellValue(GridView7.FocusedRowHandle, "Account", Value1)
                ElseIf editor.AccessibleName = GAccount7.Name Then
                    GridView8.SetRowCellValue(GridView8.FocusedRowHandle, "Account", Value1)
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


            TxtTotTicketIDR.Text = _totalidr1
            TxtTotTicketYEN.Text = _totalyen1
            TxtTotTicketUSD.Text = _totalusd1
            TxtTotTicketIDRAmt.Text = _totalidr2

            TxtTotalAdvanceIDR.Text = Format(Val(TxtTotTransIDR.Text) + Val(TxtTotTicketIDR.Text) + Val(TxtTotEnterIDR.Text) + Val(TxtTotHotelIDR.Text) + Val(TxtTotPocketIDR.Text) + Val(TxtTotTripIDR.Text) + Val(TxtTotOtherIDR.Text), gs_FormatBulat)
            TxtTotalAdvanceUSD.Text = Format(Val(TxtTotTransUSD.Text) + Val(TxtTotTicketUSD.Text) + Val(TxtTotEnterUSD.Text) + Val(TxtTotHotelUSD.Text) + Val(TxtTotPocketUSD.Text) + Val(TxtTotTripUSD.Text) + Val(TxtTotOtherUSD.Text), gs_FormatBulat)
            TxtTotalAdvanceYEN.Text = Format(Val(TxtTotTransYEN.Text) + Val(TxtTotTicketYEN.Text) + Val(TxtTotEnterYEN.Text) + Val(TxtTotHotelYEN.Text) + Val(TxtTotPocketYEN.Text) + Val(TxtTotTripYEN.Text) + Val(TxtTotOtherYEN.Text), gs_FormatBulat)
            TxtTotIDR.Text = Format(Val(TxtTotTransIDRAmt.Text) + Val(TxtTotTicketIDRAmt.Text) + Val(TxtTotEnterIDRAmt.Text) + Val(TxtTotHotelIDRAmt.Text) + Val(TxtTotPocketIDRAmt.Text) + Val(TxtTotTripIDRAmt.Text) + Val(TxtTotOtherIDRAmt.Text), gs_FormatBulat)


        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub GridView3_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView3.CellValueChanged
        Dim _totalidr12a As Decimal = 0
        Dim _totalusd12 As Decimal = 0
        Dim _totalyen12 As Decimal = 0
        Dim _totalidr22 As Decimal = 0

        Try
            For b As Integer = 0 To GridView3.RowCount - 1
                If Not IsDBNull(GridView3.GetRowCellValue(b, "Amount")) Then
                    If GridView3.GetRowCellValue(b, "CuryID") = "IDR" Then
                        _totalidr12a = _totalidr12a + Convert.ToDecimal(GridView3.GetRowCellValue(b, "Amount"))

                    End If
                    If GridView3.GetRowCellValue(b, "CuryID") = "USD" Then
                        _totalusd12 = _totalusd12 + Convert.ToDecimal(GridView3.GetRowCellValue(b, "Amount"))
                    End If
                    If GridView3.GetRowCellValue(b, "CuryID") = "YEN" Then
                        _totalyen12 = _totalyen12 + Convert.ToDecimal(GridView3.GetRowCellValue(b, "Amount"))
                    End If
                    _totalidr22 = _totalidr22 + Convert.ToDecimal(GridView3.GetRowCellValue(b, "AmountIDR"))
                End If
            Next
            ''Return _totalidr1
            TxtTotTransIDR.Text = _totalidr12a
            TxtTotTransYEN.Text = _totalyen12
            TxtTotTransUSD.Text = _totalusd12
            TxtTotTransIDRAmt.Text = _totalidr22

            TxtTotalAdvanceIDR.Text = Format(Val(TxtTotTransIDR.Text) + Val(TxtTotTicketIDR.Text) + Val(TxtTotEnterIDR.Text) + Val(TxtTotHotelIDR.Text) + Val(TxtTotPocketIDR.Text) + Val(TxtTotTripIDR.Text) + Val(TxtTotOtherIDR.Text), gs_FormatBulat)
            TxtTotalAdvanceUSD.Text = Format(Val(TxtTotTransUSD.Text) + Val(TxtTotTicketUSD.Text) + Val(TxtTotEnterUSD.Text) + Val(TxtTotHotelUSD.Text) + Val(TxtTotPocketUSD.Text) + Val(TxtTotTripUSD.Text) + Val(TxtTotOtherUSD.Text), gs_FormatBulat)
            TxtTotalAdvanceYEN.Text = Format(Val(TxtTotTransYEN.Text) + Val(TxtTotTicketYEN.Text) + Val(TxtTotEnterYEN.Text) + Val(TxtTotHotelYEN.Text) + Val(TxtTotPocketYEN.Text) + Val(TxtTotTripYEN.Text) + Val(TxtTotOtherYEN.Text), gs_FormatBulat)
            TxtTotIDR.Text = Format(Val(TxtTotTransIDRAmt.Text) + Val(TxtTotTicketIDRAmt.Text) + Val(TxtTotEnterIDRAmt.Text) + Val(TxtTotHotelIDRAmt.Text) + Val(TxtTotPocketIDRAmt.Text) + Val(TxtTotTripIDRAmt.Text) + Val(TxtTotOtherIDRAmt.Text), gs_FormatBulat)

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

    Private Sub jmltot2_EditValueChanged(sender As Object, e As EventArgs) Handles jmltot2.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double = GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "Amount")
        Dim vrate As Single = GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "Rate")
        GridView3.SetRowCellValue(GridView3.FocusedRowHandle, "AmountIDR", jumlah * vrate)
    End Sub
    Private Sub Grate2_EditValueChanged(sender As Object, e As EventArgs) Handles Grate2.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double = 0

        ''Dim jumlah As Double = GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "Amount")

        jumlah = IIf(GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "Amount") Is DBNull.Value, "0", GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "Amount"))

        Dim vrate As Single = GridView3.GetRowCellValue(GridView3.FocusedRowHandle, "Rate")
        GridView3.SetRowCellValue(GridView3.FocusedRowHandle, "AmountIDR", jumlah * vrate)
    End Sub

    Private Sub IDRAmt2_EditValueChanged(sender As Object, e As EventArgs) Handles IDRAmt2.EditValueChanged
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
    Private Sub Grid2_DoubleClick(sender As Object, e As EventArgs) Handles Grid2.DoubleClick
        GridView3.AddNewRow()
        GridView3.OptionsNavigation.AutoFocusNewRow = True
        GridView3.FocusedColumn = GridView3.VisibleColumns(0)

    End Sub


    Private Sub GridView4_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView4.CellValueChanged
        Dim _totalidr13a As Decimal = 0
        Dim _totalusd13 As Decimal = 0
        Dim _totalyen13 As Decimal = 0
        Dim _totalidr23 As Decimal = 0

        Try
            For b As Integer = 0 To GridView4.RowCount - 1
                If Not IsDBNull(GridView4.GetRowCellValue(b, "Amount")) Then
                    If GridView4.GetRowCellValue(b, "CuryID") = "IDR" Then
                        _totalidr13a = _totalidr13a + Convert.ToDecimal(GridView4.GetRowCellValue(b, "Amount"))

                    End If
                    If GridView4.GetRowCellValue(b, "CuryID") = "USD" Then
                        _totalusd13 = _totalusd13 + Convert.ToDecimal(GridView4.GetRowCellValue(b, "Amount"))
                    End If
                    If GridView4.GetRowCellValue(b, "CuryID") = "YEN" Then
                        _totalyen13 = _totalyen13 + Convert.ToDecimal(GridView4.GetRowCellValue(b, "Amount"))
                    End If
                    _totalidr23 = _totalidr23 + Convert.ToDecimal(GridView4.GetRowCellValue(b, "AmountIDR"))
                End If
            Next
            ''Return _totalidr1
            TxtTotHotelIDR.Text = _totalidr13a
            TxtTotHotelYEN.Text = _totalyen13
            TxtTotHotelUSD.Text = _totalusd13
            TxtTotHotelIDRAmt.Text = _totalidr23

            TxtTotalAdvanceIDR.Text = Format(Val(TxtTotTransIDR.Text) + Val(TxtTotTicketIDR.Text) + Val(TxtTotEnterIDR.Text) + Val(TxtTotHotelIDR.Text) + Val(TxtTotPocketIDR.Text) + Val(TxtTotTripIDR.Text) + Val(TxtTotOtherIDR.Text), gs_FormatBulat)
            TxtTotalAdvanceUSD.Text = Format(Val(TxtTotTransUSD.Text) + Val(TxtTotTicketUSD.Text) + Val(TxtTotEnterUSD.Text) + Val(TxtTotHotelUSD.Text) + Val(TxtTotPocketUSD.Text) + Val(TxtTotTripUSD.Text) + Val(TxtTotOtherUSD.Text), gs_FormatBulat)
            TxtTotalAdvanceYEN.Text = Format(Val(TxtTotTransYEN.Text) + Val(TxtTotTicketYEN.Text) + Val(TxtTotEnterYEN.Text) + Val(TxtTotHotelYEN.Text) + Val(TxtTotPocketYEN.Text) + Val(TxtTotTripYEN.Text) + Val(TxtTotOtherYEN.Text), gs_FormatBulat)
            TxtTotIDR.Text = Format(Val(TxtTotTransIDRAmt.Text) + Val(TxtTotTicketIDRAmt.Text) + Val(TxtTotEnterIDRAmt.Text) + Val(TxtTotHotelIDRAmt.Text) + Val(TxtTotPocketIDRAmt.Text) + Val(TxtTotTripIDRAmt.Text) + Val(TxtTotOtherIDRAmt.Text), gs_FormatBulat)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub jmltot3_EditValueChanged(sender As Object, e As EventArgs) Handles jmltot3.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double = GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "Amount")
        Dim vrate As Single = GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "Rate")
        GridView4.SetRowCellValue(GridView4.FocusedRowHandle, "AmountIDR", jumlah * vrate)
    End Sub
    Private Sub Grate3_EditValueChanged(sender As Object, e As EventArgs) Handles Grate3.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double = 0

        ''Dim jumlah As Double = GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "Amount")

        jumlah = IIf(GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "Amount") Is DBNull.Value, "0", GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "Amount"))

        Dim vrate As Single = GridView4.GetRowCellValue(GridView4.FocusedRowHandle, "Rate")
        GridView4.SetRowCellValue(GridView4.FocusedRowHandle, "AmountIDR", jumlah * vrate)
    End Sub

    Private Sub IDRAmt3_EditValueChanged(sender As Object, e As EventArgs) Handles IDRAmt3.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub Grid3_DoubleClick(sender As Object, e As EventArgs) Handles Grid3.DoubleClick
        GridView4.AddNewRow()
        GridView4.OptionsNavigation.AutoFocusNewRow = True
        GridView4.FocusedColumn = GridView4.VisibleColumns(0)

    End Sub

    Private Sub GridView5_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView5.CellValueChanged
        Dim _totalidr14a As Decimal = 0
        Dim _totalusd14 As Decimal = 0
        Dim _totalyen14 As Decimal = 0
        Dim _totalidr24 As Decimal = 0

        Try
            For b As Integer = 0 To GridView5.RowCount - 1
                If Not IsDBNull(GridView5.GetRowCellValue(b, "Amount")) Then
                    If GridView5.GetRowCellValue(b, "CuryID") = "IDR" Then
                        _totalidr14a = _totalidr14a + Convert.ToDecimal(GridView5.GetRowCellValue(b, "Amount"))

                    End If
                    If GridView5.GetRowCellValue(b, "CuryID") = "USD" Then
                        _totalusd14 = _totalusd14 + Convert.ToDecimal(GridView5.GetRowCellValue(b, "Amount"))
                    End If
                    If GridView5.GetRowCellValue(b, "CuryID") = "YEN" Then
                        _totalyen14 = _totalyen14 + Convert.ToDecimal(GridView5.GetRowCellValue(b, "Amount"))
                    End If
                    _totalidr24 = _totalidr24 + Convert.ToDecimal(GridView5.GetRowCellValue(b, "AmountIDR"))
                End If
            Next
            ''Return _totalidr1
            TxtTotEnterIDR.Text = _totalidr14a
            TxtTotEnterYEN.Text = _totalyen14
            TxtTotEnterUSD.Text = _totalusd14
            TxtTotEnterIDRAmt.Text = _totalidr24

            TxtTotalAdvanceIDR.Text = Format(Val(TxtTotTransIDR.Text) + Val(TxtTotTicketIDR.Text) + Val(TxtTotEnterIDR.Text) + Val(TxtTotHotelIDR.Text) + Val(TxtTotPocketIDR.Text) + Val(TxtTotTripIDR.Text) + Val(TxtTotOtherIDR.Text), gs_FormatBulat)
            TxtTotalAdvanceUSD.Text = Format(Val(TxtTotTransUSD.Text) + Val(TxtTotTicketUSD.Text) + Val(TxtTotEnterUSD.Text) + Val(TxtTotHotelUSD.Text) + Val(TxtTotPocketUSD.Text) + Val(TxtTotTripUSD.Text) + Val(TxtTotOtherUSD.Text), gs_FormatBulat)
            TxtTotalAdvanceYEN.Text = Format(Val(TxtTotTransYEN.Text) + Val(TxtTotTicketYEN.Text) + Val(TxtTotEnterYEN.Text) + Val(TxtTotHotelYEN.Text) + Val(TxtTotPocketYEN.Text) + Val(TxtTotTripYEN.Text) + Val(TxtTotOtherYEN.Text), gs_FormatBulat)
            TxtTotIDR.Text = Format(Val(TxtTotTransIDRAmt.Text) + Val(TxtTotTicketIDRAmt.Text) + Val(TxtTotEnterIDRAmt.Text) + Val(TxtTotHotelIDRAmt.Text) + Val(TxtTotPocketIDRAmt.Text) + Val(TxtTotTripIDRAmt.Text) + Val(TxtTotOtherIDRAmt.Text), gs_FormatBulat)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub jmltot4_EditValueChanged(sender As Object, e As EventArgs) Handles jmltot4.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double = GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "Amount")
        Dim vrate As Single = GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "Rate")
        GridView5.SetRowCellValue(GridView5.FocusedRowHandle, "AmountIDR", jumlah * vrate)
    End Sub
    Private Sub Grate5_EditValueChanged(sender As Object, e As EventArgs) Handles Grate5.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double = 0

        jumlah = IIf(GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "Amount") Is DBNull.Value, "0", GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "Amount"))

        Dim vrate As Single = GridView5.GetRowCellValue(GridView5.FocusedRowHandle, "Rate")
        GridView5.SetRowCellValue(GridView5.FocusedRowHandle, "AmountIDR", jumlah * vrate)
    End Sub

    Private Sub IDRAmt4_EditValueChanged(sender As Object, e As EventArgs) Handles IDRAmt4.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub Grid4_DoubleClick(sender As Object, e As EventArgs) Handles Grid4.DoubleClick
        GridView5.AddNewRow()
        GridView5.OptionsNavigation.AutoFocusNewRow = True
        GridView5.FocusedColumn = GridView5.VisibleColumns(0)

    End Sub
    Private Sub GridView6_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView6.CellValueChanged
        Dim _totalidr15a As Decimal = 0
        Dim _totalusd15 As Decimal = 0
        Dim _totalyen15 As Decimal = 0
        Dim _totalidr25 As Decimal = 0

        Try
            For b As Integer = 0 To GridView6.RowCount - 1
                If Not IsDBNull(GridView6.GetRowCellValue(b, "Amount")) Then
                    If GridView6.GetRowCellValue(b, "CuryID") = "IDR" Then
                        _totalidr15a = _totalidr15a + Convert.ToDecimal(GridView6.GetRowCellValue(b, "Amount"))

                    End If
                    If GridView6.GetRowCellValue(b, "CuryID") = "USD" Then
                        _totalusd15 = _totalusd15 + Convert.ToDecimal(GridView6.GetRowCellValue(b, "Amount"))
                    End If
                    If GridView6.GetRowCellValue(b, "CuryID") = "YEN" Then
                        _totalyen15 = _totalyen15 + Convert.ToDecimal(GridView6.GetRowCellValue(b, "Amount"))
                    End If
                    _totalidr25 = _totalidr25 + Convert.ToDecimal(GridView6.GetRowCellValue(b, "AmountIDR"))
                End If
            Next
            ''Return _totalidr1
            TxtTotPocketIDR.Text = _totalidr15a
            TxtTotPocketYEN.Text = _totalyen15
            TxtTotPocketUSD.Text = _totalusd15
            TxtTotPocketIDRAmt.Text = _totalidr25

            TxtTotalAdvanceIDR.Text = Format(Val(TxtTotTransIDR.Text) + Val(TxtTotTicketIDR.Text) + Val(TxtTotEnterIDR.Text) + Val(TxtTotHotelIDR.Text) + Val(TxtTotPocketIDR.Text) + Val(TxtTotTripIDR.Text) + Val(TxtTotOtherIDR.Text), gs_FormatBulat)
            TxtTotalAdvanceUSD.Text = Format(Val(TxtTotTransUSD.Text) + Val(TxtTotTicketUSD.Text) + Val(TxtTotEnterUSD.Text) + Val(TxtTotHotelUSD.Text) + Val(TxtTotPocketUSD.Text) + Val(TxtTotTripUSD.Text) + Val(TxtTotOtherUSD.Text), gs_FormatBulat)
            TxtTotalAdvanceYEN.Text = Format(Val(TxtTotTransYEN.Text) + Val(TxtTotTicketYEN.Text) + Val(TxtTotEnterYEN.Text) + Val(TxtTotHotelYEN.Text) + Val(TxtTotPocketYEN.Text) + Val(TxtTotTripYEN.Text) + Val(TxtTotOtherYEN.Text), gs_FormatBulat)
            TxtTotIDR.Text = Format(Val(TxtTotTransIDRAmt.Text) + Val(TxtTotTicketIDRAmt.Text) + Val(TxtTotEnterIDRAmt.Text) + Val(TxtTotHotelIDRAmt.Text) + Val(TxtTotPocketIDRAmt.Text) + Val(TxtTotTripIDRAmt.Text) + Val(TxtTotOtherIDRAmt.Text), gs_FormatBulat)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub jmltot5_EditValueChanged(sender As Object, e As EventArgs) Handles jmltot5.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double = GridView6.GetRowCellValue(GridView6.FocusedRowHandle, "Amount")
        Dim vrate As Single = GridView6.GetRowCellValue(GridView6.FocusedRowHandle, "Rate")
        GridView6.SetRowCellValue(GridView6.FocusedRowHandle, "AmountIDR", jumlah * vrate)
    End Sub
    Private Sub Grate4_EditValueChanged(sender As Object, e As EventArgs) Handles Grate4.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double = 0

        jumlah = IIf(GridView6.GetRowCellValue(GridView6.FocusedRowHandle, "Amount") Is DBNull.Value, "0", GridView6.GetRowCellValue(GridView6.FocusedRowHandle, "Amount"))

        Dim vrate As Single = GridView6.GetRowCellValue(GridView6.FocusedRowHandle, "Rate")
        GridView6.SetRowCellValue(GridView6.FocusedRowHandle, "AmountIDR", jumlah * vrate)
    End Sub

    Private Sub IDRAmt5_EditValueChanged(sender As Object, e As EventArgs) Handles IDRAmt5.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub Grid5_DoubleClick(sender As Object, e As EventArgs) Handles Grid5.DoubleClick
        GridView6.AddNewRow()
        GridView6.OptionsNavigation.AutoFocusNewRow = True
        GridView6.FocusedColumn = GridView6.VisibleColumns(0)

    End Sub
    Private Sub GridView7_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView7.CellValueChanged
        Dim _totalidr16a As Decimal = 0
        Dim _totalusd16 As Decimal = 0
        Dim _totalyen16 As Decimal = 0
        Dim _totalidr26 As Decimal = 0

        Try
            For b As Integer = 0 To GridView7.RowCount - 1
                If Not IsDBNull(GridView7.GetRowCellValue(b, "Amount")) Then
                    If GridView7.GetRowCellValue(b, "CuryID") = "IDR" Then
                        _totalidr16a = _totalidr16a + Convert.ToDecimal(GridView7.GetRowCellValue(b, "Amount"))

                    End If
                    If GridView7.GetRowCellValue(b, "CuryID") = "USD" Then
                        _totalusd16 = _totalusd16 + Convert.ToDecimal(GridView7.GetRowCellValue(b, "Amount"))
                    End If
                    If GridView7.GetRowCellValue(b, "CuryID") = "YEN" Then
                        _totalyen16 = _totalyen16 + Convert.ToDecimal(GridView7.GetRowCellValue(b, "Amount"))
                    End If
                    _totalidr26 = _totalidr26 + Convert.ToDecimal(GridView7.GetRowCellValue(b, "AmountIDR"))
                End If
            Next
            ''Return _totalidr1
            TxtTotTripIDR.Text = _totalidr16a
            TxtTotTripYEN.Text = _totalyen16
            TxtTotTripUSD.Text = _totalusd16
            TxtTotTripIDRAmt.Text = _totalidr26

            TxtTotalAdvanceIDR.Text = Format(Val(TxtTotTransIDR.Text) + Val(TxtTotTicketIDR.Text) + Val(TxtTotEnterIDR.Text) + Val(TxtTotHotelIDR.Text) + Val(TxtTotPocketIDR.Text) + Val(TxtTotTripIDR.Text) + Val(TxtTotOtherIDR.Text), gs_FormatBulat)
            TxtTotalAdvanceUSD.Text = Format(Val(TxtTotTransUSD.Text) + Val(TxtTotTicketUSD.Text) + Val(TxtTotEnterUSD.Text) + Val(TxtTotHotelUSD.Text) + Val(TxtTotPocketUSD.Text) + Val(TxtTotTripUSD.Text) + Val(TxtTotOtherUSD.Text), gs_FormatBulat)
            TxtTotalAdvanceYEN.Text = Format(Val(TxtTotTransYEN.Text) + Val(TxtTotTicketYEN.Text) + Val(TxtTotEnterYEN.Text) + Val(TxtTotHotelYEN.Text) + Val(TxtTotPocketYEN.Text) + Val(TxtTotTripYEN.Text) + Val(TxtTotOtherYEN.Text), gs_FormatBulat)
            TxtTotIDR.Text = Format(Val(TxtTotTransIDRAmt.Text) + Val(TxtTotTicketIDRAmt.Text) + Val(TxtTotEnterIDRAmt.Text) + Val(TxtTotHotelIDRAmt.Text) + Val(TxtTotPocketIDRAmt.Text) + Val(TxtTotTripIDRAmt.Text) + Val(TxtTotOtherIDRAmt.Text), gs_FormatBulat)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub jmltot6_EditValueChanged(sender As Object, e As EventArgs) Handles jmltot6.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double = GridView7.GetRowCellValue(GridView7.FocusedRowHandle, "Amount")
        Dim vrate As Single = GridView7.GetRowCellValue(GridView7.FocusedRowHandle, "Rate")
        GridView7.SetRowCellValue(GridView7.FocusedRowHandle, "AmountIDR", jumlah * vrate)
    End Sub
    Private Sub Grate6_EditValueChanged(sender As Object, e As EventArgs) Handles Grate6.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double = 0

        jumlah = IIf(GridView7.GetRowCellValue(GridView7.FocusedRowHandle, "Amount") Is DBNull.Value, "0", GridView7.GetRowCellValue(GridView7.FocusedRowHandle, "Amount"))

        Dim vrate As Single = GridView7.GetRowCellValue(GridView7.FocusedRowHandle, "Rate")
        GridView7.SetRowCellValue(GridView7.FocusedRowHandle, "AmountIDR", jumlah * vrate)
    End Sub

    Private Sub IDRAmt6_EditValueChanged(sender As Object, e As EventArgs) Handles IDRAmt6.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub Grid6_DoubleClick(sender As Object, e As EventArgs) Handles Grid6.DoubleClick
        GridView7.AddNewRow()
        GridView7.OptionsNavigation.AutoFocusNewRow = True
        GridView7.FocusedColumn = GridView7.VisibleColumns(0)

    End Sub

    Private Sub GridView8_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView8.CellValueChanged
        Dim _totalidr17a As Decimal = 0
        Dim _totalusd17 As Decimal = 0
        Dim _totalyen17 As Decimal = 0
        Dim _totalidr26 As Decimal = 0

        Try
            For b As Integer = 0 To GridView8.RowCount - 1
                If Not IsDBNull(GridView8.GetRowCellValue(b, "Amount")) Then
                    If GridView8.GetRowCellValue(b, "CuryID") = "IDR" Then
                        _totalidr17a = _totalidr17a + Convert.ToDecimal(GridView8.GetRowCellValue(b, "Amount"))

                    End If
                    If GridView8.GetRowCellValue(b, "CuryID") = "USD" Then
                        _totalusd17 = _totalusd17 + Convert.ToDecimal(GridView8.GetRowCellValue(b, "Amount"))
                    End If
                    If GridView8.GetRowCellValue(b, "CuryID") = "YEN" Then
                        _totalyen17 = _totalyen17 + Convert.ToDecimal(GridView8.GetRowCellValue(b, "Amount"))
                    End If
                    _totalidr26 = _totalidr26 + Convert.ToDecimal(GridView8.GetRowCellValue(b, "AmountIDR"))
                End If
            Next
            ''Return _totalidr1
            TxtTotOtherIDR.Text = _totalidr17a
            TxtTotOtherYEN.Text = _totalyen17
            TxtTotOtherUSD.Text = _totalusd17
            TxtTotOtherIDRAmt.Text = _totalidr26

            TxtTotalAdvanceIDR.Text = Format(Val(TxtTotTransIDR.Text) + Val(TxtTotTicketIDR.Text) + Val(TxtTotEnterIDR.Text) + Val(TxtTotHotelIDR.Text) + Val(TxtTotPocketIDR.Text) + Val(TxtTotTripIDR.Text) + Val(TxtTotOtherIDR.Text), gs_FormatBulat)
            TxtTotalAdvanceUSD.Text = Format(Val(TxtTotTransUSD.Text) + Val(TxtTotTicketUSD.Text) + Val(TxtTotEnterUSD.Text) + Val(TxtTotHotelUSD.Text) + Val(TxtTotPocketUSD.Text) + Val(TxtTotTripUSD.Text) + Val(TxtTotOtherUSD.Text), gs_FormatBulat)
            TxtTotalAdvanceYEN.Text = Format(Val(TxtTotTransYEN.Text) + Val(TxtTotTicketYEN.Text) + Val(TxtTotEnterYEN.Text) + Val(TxtTotHotelYEN.Text) + Val(TxtTotPocketYEN.Text) + Val(TxtTotTripYEN.Text) + Val(TxtTotOtherYEN.Text), gs_FormatBulat)
            TxtTotIDR.Text = Format(Val(TxtTotTransIDRAmt.Text) + Val(TxtTotTicketIDRAmt.Text) + Val(TxtTotEnterIDRAmt.Text) + Val(TxtTotHotelIDRAmt.Text) + Val(TxtTotPocketIDRAmt.Text) + Val(TxtTotTripIDRAmt.Text) + Val(TxtTotOtherIDRAmt.Text), gs_FormatBulat)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub jmltot7_EditValueChanged(sender As Object, e As EventArgs) Handles jmltot7.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double = GridView8.GetRowCellValue(GridView8.FocusedRowHandle, "Amount")
        Dim vrate As Single = GridView8.GetRowCellValue(GridView8.FocusedRowHandle, "Rate")
        GridView8.SetRowCellValue(GridView8.FocusedRowHandle, "AmountIDR", jumlah * vrate)
    End Sub
    Private Sub Grate7_EditValueChanged(sender As Object, e As EventArgs) Handles Grate7.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim jumlah As Double = 0

        jumlah = IIf(GridView8.GetRowCellValue(GridView8.FocusedRowHandle, "Amount") Is DBNull.Value, "0", GridView8.GetRowCellValue(GridView8.FocusedRowHandle, "Amount"))

        Dim vrate As Single = GridView8.GetRowCellValue(GridView8.FocusedRowHandle, "Rate")
        GridView8.SetRowCellValue(GridView8.FocusedRowHandle, "AmountIDR", jumlah * vrate)
    End Sub

    Private Sub IDRAmt7_EditValueChanged(sender As Object, e As EventArgs) Handles IDRAmt7.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub Grid7_DoubleClick(sender As Object, e As EventArgs) Handles Grid7.DoubleClick
        GridView8.AddNewRow()
        GridView8.OptionsNavigation.AutoFocusNewRow = True
        GridView8.FocusedColumn = GridView8.VisibleColumns(0)

    End Sub

    Private Sub TxtNama_EditValueChanged(sender As Object, e As EventArgs) Handles TxtNama.EditValueChanged

    End Sub

    Private Sub TxtNama_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles TxtNama.ButtonClick

        Try
            ObjTravelHeader = New TravelHeaderModel
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = ObjTravelHeader.GetTraveller
            ls_OldKode = TxtNama.Text
            ls_Judul = "Traveller"

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
                TxtNama.Text = Value1
                TxtDep.Text = Value2
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub


End Class
