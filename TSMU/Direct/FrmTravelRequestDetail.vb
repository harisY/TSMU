﻿Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports System.Net.Mail

Public Class FrmTravelRequestDetail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim isLoad As Boolean = False
    Dim _Tag As TagModel

    Dim dtCost As New DataTable
    Dim row_ As DataRow
    Dim firstTravel As Boolean = False
    Dim amountFirstTravel As Double
    Dim descFirstTravel As String

    Dim departureDate_ As Date
    Dim arrivalDate_ As Date
    Dim days As Integer
    Dim dtGrid As DataTable
    Dim GridDtl As GridControl
    Dim rateUSD As Double
    Dim rateYEN As Double

    Dim ObjTravelRequest As New TravelRequestModel
    Dim ObjTravelRequestDetail As New TravelRequestDetailModel
    Dim ObjTravelRequestCost As New TravelRequestCostModel
    Dim fc_Class As New TravelTicketModel

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
        _Tag = New TagModel
        _Tag.PageIndex = lf_FormParent.Tag.PageIndex
        Tag = _Tag
    End Sub

    Private Sub FrmTravelRequestDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Call InitialSetForm()
        If fs_Code2 = "TabPageRequestAll" Then
            ViewForm()
        End If
    End Sub

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "" Then
                ObjTravelRequest.GetRequestHeaderByID(fs_Code)
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Me.Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Me.Text = "REQUEST DETAIL"
            Else
                Me.Text = "NEW REQUEST"
            End If
            Call LoadTxtBox()
            LoadGridDetail()
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = "FrmTravelRequest"
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Sub LoadGridDetail()
        Try
            CreateDataTable()
            ListItemsNegara()

            If fs_Code <> "" Then
                isLoad = True
                dtGrid = New DataTable
                ObjTravelRequestDetail.NoRequest = txtNoRequest.Text
                dtGrid = ObjTravelRequestDetail.GetDetailByID()
                GridDetail.DataSource = dtGrid

                ObjTravelRequestCost.NoRequest = txtNoRequest.Text
                dtGrid = ObjTravelRequestCost.GetCostByID()
                GridAdvance.DataSource = dtGrid

                Dim FilteredRows As DataRow()
                FilteredRows = dtGrid.Select("CostType = 'C01'")
                If FilteredRows.Count > 0 Then
                    row_ = FilteredRows(0)
                End If


                FilteredRows = dtGrid.Select("CostType = 'C03'")
                If FilteredRows.Count > 0 Then
                    txtAdvanceIDR.Text = Format(FilteredRows(0).Item("AdvanceIDR"), gs_FormatDecimal)
                    txtAdvanceUSD.Text = Format(FilteredRows(0).Item("AdvanceUSD"), gs_FormatDecimal)
                    txtAdvanceYEN.Text = Format(FilteredRows(0).Item("AdvanceYEN"), gs_FormatDecimal)
                End If
                GetTravelDate()
                isLoad = False
            Else
                dtGrid = New DataTable
                ObjTravelRequestDetail.NoRequest = ""
                dtGrid = ObjTravelRequestDetail.GetDetailByID()
                GridDetail.DataSource = dtGrid

                ObjTravelRequestCost.NoRequest = ""
                dtGrid = ObjTravelRequestCost.GetCostByID()
                GridAdvance.DataSource = dtGrid

            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try
            ListItemsGolongan()
            Dim objTravelHeader = New TravelHeaderModel
            Dim ketRateUSD As String
            Dim ketRateYEN As String

            If fs_Code <> "" Then
                With ObjTravelRequest
                    txtNoRequest.Text = .NoRequest
                    txtNIK.Text = .NIK
                    txtNama.Text = .Nama
                    txtDepartement.Text = .DeptID
                    txtTravelType.Text = .TravelType
                    txtGolongan.Text = .Golongan
                    txtPurpose.Text = .Purpose
                End With
                ketRateUSD = Format(objTravelHeader.GetRate("USD", ObjTravelRequest.Tanggal), gs_FormatDecimal)
                ketRateYEN = Format(objTravelHeader.GetRate("JPY", ObjTravelRequest.Tanggal), gs_FormatDecimal)
            Else
                txtNoRequest.Text = ""
                txtDepartement.Text = gh_Common.GroupID
                txtNIK.Text = ""
                txtNama.Text = ""
                txtGolongan.Text = ""
                txtPurpose.Text = ""
                txtTravelType.Text = "LN"
                txtAdvanceIDR.Text = Format(0, gs_FormatDecimal)
                txtAdvanceUSD.Text = Format(0, gs_FormatDecimal)
                txtAdvanceYEN.Text = Format(0, gs_FormatDecimal)
                txtNIK.Focus()
                rateUSD = objTravelHeader.GetRate("USD", DateTime.Today)
                rateYEN = objTravelHeader.GetRate("JPY", DateTime.Today)
                ketRateUSD = Format(rateUSD, gs_FormatDecimal)
                ketRateYEN = Format(rateYEN, gs_FormatDecimal)
            End If
            Label1.Text = "1USD : " & ketRateUSD & "   |   1YEN : " & ketRateYEN & ""

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Overrides Function ValidateSave() As Boolean
        Dim lb_Validated As Boolean = False
        Try
            Dim success As Boolean = True

            If DxValidationProvider1.Validate Then
                lb_Validated = True
            Else
                Err.Raise(ErrNumber, , "Data yang anda input tidak valid, silahkan cek inputan anda !")
            End If

            If isUpdate Then
                If ObjTravelRequest.Status = "Open" Then
                    Err.Raise(ErrNumber, , "No Request " & fs_Code & " sudah dilakukan proses ticket !")
                End If
            End If

            If txtNIK.Text = "" Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
            End If

            Dim i As Integer
            If String.IsNullOrEmpty(txtGolongan.Text) Then
                i = 0
            Else
                i = Convert.ToInt16(txtGolongan.Text)
            End If

            If lb_Validated Then
                Dim status As String = String.Empty
                If isUpdate = False Then
                    txtNoRequest.Text = ObjTravelRequest.TravelRequestAutoNo
                Else
                    If FrmParent.Name = "FrmTravelTicket" Then
                        status = "APPROVED"
                    End If
                End If

                With ObjTravelRequest
                    .NoRequest = txtNoRequest.Text
                    .Nama = txtNama.Text.Trim.ToUpper
                    .DeptID = txtDepartement.Text.Trim.ToUpper
                    .TravelType = txtTravelType.Text.Trim.ToUpper
                    .NIK = txtNIK.Text.Trim.ToUpper
                    .Golongan = i
                    .Purpose = txtPurpose.Text
                    .Status = "PENDING"
                    .Approved = status
                End With

            End If
        Catch ex As Exception
            lb_Validated = False
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
        Return lb_Validated
    End Function

    Public Overrides Sub Proc_SaveData()
        Try
            Dim seq As Integer = 0
            ObjTravelRequest.ObjRequestDetails.Clear()
            For i As Integer = 0 To GridViewDetail.RowCount - 1
                seq = seq + 1
                ObjTravelRequestDetail = New TravelRequestDetailModel
                With ObjTravelRequestDetail
                    .NoRequest = txtNoRequest.Text
                    .Seq = seq
                    .Destination = GridViewDetail.GetRowCellValue(i, "Destination").ToString().TrimEnd.ToUpper
                    .Negara = GridViewDetail.GetRowCellValue(i, "Negara").ToString().TrimEnd
                    .Visa = GridViewDetail.GetRowCellValue(i, "Visa").ToString().TrimEnd
                    .DepartureDate = IIf(GridViewDetail.GetRowCellValue(i, "DepartureDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(i, "DepartureDate"))
                    .ArrivalDate = IIf(GridViewDetail.GetRowCellValue(i, "ArrivalDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(i, "ArrivalDate"))
                End With
                ObjTravelRequest.ObjRequestDetails.Add(ObjTravelRequestDetail)
            Next

            ObjTravelRequest.ObjRequestCost.Clear()
            For i As Integer = 0 To GridViewAdvance.RowCount - 1
                ObjTravelRequestCost = New TravelRequestCostModel
                With ObjTravelRequestCost
                    .NoRequest = txtNoRequest.Text
                    .CostType = GridViewAdvance.GetRowCellValue(i, "CostType").ToString().TrimEnd.ToUpper
                    .Description = GridViewAdvance.GetRowCellValue(i, "Description").ToString().TrimEnd
                    .Days = Convert.ToInt16(GridViewAdvance.GetRowCellValue(i, "Days"))
                    .AdvanceIDR = Convert.ToDouble(GridViewAdvance.GetRowCellValue(i, "AdvanceIDR"))
                    .AdvanceUSD = Convert.ToDouble(GridViewAdvance.GetRowCellValue(i, "AdvanceUSD"))
                    .AdvanceYEN = Convert.ToDouble(GridViewAdvance.GetRowCellValue(i, "AdvanceYEN"))
                End With
                ObjTravelRequest.ObjRequestCost.Add(ObjTravelRequestCost)
            Next

            If isUpdate = False Then
                ObjTravelRequest.InsertData()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                ObjTravelRequest.NoRequest = txtNoRequest.Text
                ObjTravelRequest.UpdateData()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            End If

            If FrmParent.Name = "FrmTravelTicket" Then
                GridDtl.DataSource = fc_Class.GetTravelRequest()
            Else
                GridDtl.DataSource = ObjTravelRequest.GetTravelRequest()
            End If
            IsClosed = True
            Me.Hide()

        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub GridViewDetail_KeyDown(sender As Object, e As KeyEventArgs) Handles GridViewDetail.KeyDown
        If e.KeyData = Keys.Delete Then
            GridViewDetail.DeleteRow(GridViewDetail.FocusedRowHandle)
            GridViewDetail.RefreshData()
            GetTravelDate()
            CheckFirstTravel()
            HitungTotalAmount()
        End If
        If e.KeyData = Keys.Insert Then
            GridViewDetail.AddNewRow()
        End If
    End Sub

    Private Sub txtNIK_EditValueChanged(sender As Object, e As EventArgs) Handles txtNIK.EditValueChanged
        If Not String.IsNullOrEmpty(txtNIK.Text) And departureDate_ <> Nothing Then
            CheckFirstTravel()
            HitungTotalAmount()
        End If
    End Sub

    Private Sub txtNIK_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNIK.KeyPress
        Dim tombol As Integer

        tombol = Asc(e.KeyChar)

        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8) Or (tombol = 13)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtGolongan_EditValueChanged(sender As Object, e As EventArgs) Handles txtGolongan.EditValueChanged
        If GridViewDetail.RowCount > 0 Then
            CheckFirstTravel()
            HitungTotalAmount()
        End If
    End Sub

    Private Sub txtTravelType_EditValueChanged(sender As Object, e As EventArgs) Handles txtTravelType.EditValueChanged
        If txtTravelType.Text <> "" Then
            ListItemsNegara()
        End If

        Dim negara As String = "INDONESIA"
        If txtTravelType.Text = "LN" Then
            negara = ""
        End If

        For i As Integer = 0 To GridViewDetail.RowCount - 1
            GridViewDetail.SetRowCellValue(i, "Negara", negara)
        Next
        GridViewDetail.SetRowCellValue(GridViewDetail.FocusedRowHandle, "Negara", negara)
        If GridViewDetail.RowCount > 0 Then
            CheckFirstTravel()
            HitungTotalAmount()
        End If
    End Sub

    Private Sub txtAdvanceIDR_EditValueChanged(sender As Object, e As EventArgs) Handles txtAdvanceIDR.EditValueChanged
        If String.IsNullOrEmpty(txtAdvanceIDR.Text) Then
            txtAdvanceIDR.Text = 0
        End If
        txtAdvanceIDR.Text = Format(Convert.ToDecimal(txtAdvanceIDR.Text), gs_FormatDecimal)
        If GridViewDetail.RowCount > 0 And Convert.ToDecimal(txtAdvanceIDR.Text) >= 0 And isLoad = False Then
            CheckFirstTravel()
            HitungTotalAmount()
        End If
    End Sub

    Private Sub txtAdvanceUSD_EditValueChanged(sender As Object, e As EventArgs) Handles txtAdvanceUSD.EditValueChanged
        If String.IsNullOrEmpty(txtAdvanceUSD.Text) Then
            txtAdvanceUSD.Text = 0
        End If
        txtAdvanceUSD.Text = Format(Convert.ToDecimal(txtAdvanceUSD.Text), gs_FormatDecimal)
        If GridViewDetail.RowCount > 0 And Convert.ToDecimal(txtAdvanceUSD.Text) >= 0 And isLoad = False Then
            CheckFirstTravel()
            HitungTotalAmount()
        End If
    End Sub

    Private Sub txtAdvanceYEN_EditValueChanged(sender As Object, e As EventArgs) Handles txtAdvanceYEN.EditValueChanged
        If String.IsNullOrEmpty(txtAdvanceYEN.Text) Then
            txtAdvanceYEN.Text = 0
        End If
        txtAdvanceYEN.Text = Format(Convert.ToDecimal(txtAdvanceYEN.Text), gs_FormatDecimal)
        If GridViewDetail.RowCount > 0 And Convert.ToDecimal(txtAdvanceYEN.Text) >= 0 And isLoad = False Then
            CheckFirstTravel()
            HitungTotalAmount()
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        If txtNIK.Text = "" Or txtGolongan.Text = "" Then
            MessageBox.Show("Harap lengkapi data header dulu",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
            Exit Sub
        ElseIf Len(txtNIK.Text) < 9 Then
            MessageBox.Show("NIK kurang dari 9 digit",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
            Exit Sub
        End If
        'If txtTravelType.Text = "LN" AndAlso GridViewDetail.RowCount = 0 Then
        '    Dim frmOption As New FrmTravelOption()
        '    frmOption.Text = "Pilih Currency Allowance"
        '    frmOption.StartPosition = FormStartPosition.CenterScreen
        '    frmOption.ShowDialog()
        '    curryIDAllowance = IIf(frmOption.Values = Nothing, "USD", frmOption.Values)
        'End If

        GridViewDetail.AddNewRow()
        GridViewDetail.OptionsNavigation.AutoFocusNewRow = True
        GridViewDetail.RefreshData()

    End Sub

    Private Sub CDepartureDate_EditValueChanged(sender As Object, e As EventArgs) Handles CDepartureDate.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim departureDate As Date = IIf(GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "DepartureDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "DepartureDate"))
        Dim arrivalDate As Date = IIf(GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "ArrivalDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "ArrivalDate"))
        If ArrivalDate = Nothing Or DepartureDate > ArrivalDate Then
            GridViewDetail.SetRowCellValue(GridViewDetail.FocusedRowHandle, "ArrivalDate", DepartureDate)
        End If
        GetTravelDate()
        CheckFirstTravel()
        HitungTotalAmount()
        CheckVisa()
        CheckPaspor()
    End Sub

    Private Sub CArrivalDate_EditValueChanged(sender As Object, e As EventArgs) Handles CArrivalDate.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim departureDate As Date = IIf(GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "DepartureDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "DepartureDate"))
        Dim arrivalDate As Date = IIf(GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "ArrivalDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "ArrivalDate"))
        If departureDate > arrivalDate Then
            MessageBox.Show("Arrival Date tidak boleh lebih kecil dari Departure Date", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button1)
            GridViewDetail.SetRowCellValue(GridViewDetail.FocusedRowHandle, "ArrivalDate", departureDate)
        ElseIf departureDate = Nothing Then
            GridViewDetail.SetRowCellValue(GridViewDetail.FocusedRowHandle, "DepartureDate", arrivalDate)
        End If


        GetTravelDate()
        CheckFirstTravel()
        HitungTotalAmount()
        CheckPaspor()
    End Sub

    Private Sub CNegara_EditValueChanged(sender As Object, e As EventArgs) Handles CNegara.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
        CheckVisa()
        CheckPaspor()
    End Sub

    Private Sub ListItemsGolongan()
        Dim dt = New DataTable
        dt = ObjTravelRequest.GetListGolongan()
        Dim itemsCollection As ComboBoxItemCollection = txtGolongan.Properties.Items
        itemsCollection.BeginUpdate()
        itemsCollection.Clear()
        Try
            For Each r As DataRow In dt.Rows
                itemsCollection.Add(r.Item(0))
            Next
        Finally
            itemsCollection.EndUpdate()
        End Try
    End Sub

    Private Sub ListItemsNegara()
        Dim dt = New DataTable
        dt = ObjTravelRequest.GetListNegara(txtTravelType.Text)
        Dim itemsCollection As ComboBoxItemCollection = CNegara.Items
        itemsCollection.BeginUpdate()
        itemsCollection.Clear()
        Try
            For Each r As DataRow In dt.Rows
                itemsCollection.Add(r.Item(0))
            Next
        Finally
            itemsCollection.EndUpdate()
        End Try
    End Sub

    Private Sub CreateDataTable()
        dtCost.Columns.Add("NoRequest", GetType(String))
        dtCost.Columns.Add("CostType", GetType(String))
        dtCost.Columns.Add("Description", GetType(String))
        dtCost.Columns.Add("Days", GetType(Integer))
        dtCost.Columns.Add("AdvanceIDR", GetType(Double))
        dtCost.Columns.Add("AdvanceUSD", GetType(Double))
        dtCost.Columns.Add("AdvanceYEN", GetType(Double))
    End Sub

    Private Sub GetTravelDate()
        departureDate_ = Nothing
        arrivalDate_ = Nothing
        days = 0
        For i As Integer = 0 To GridViewDetail.RowCount - 1
            Dim _date As Date
            _date = IIf(GridViewDetail.GetRowCellValue(i, "DepartureDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(i, "DepartureDate"))
            If _date <> Nothing And (departureDate_ > _date Or departureDate_ = Nothing) Then
                departureDate_ = _date
            End If
            _date = IIf(GridViewDetail.GetRowCellValue(i, "ArrivalDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(i, "ArrivalDate"))
            If _date <> Nothing And (arrivalDate_ < _date Or arrivalDate_ = Nothing) Then
                arrivalDate_ = _date
            End If
        Next
        If departureDate_ <> Nothing AndAlso arrivalDate_ <> Nothing Then
            days = DateDiff(DateInterval.Day, departureDate_, arrivalDate_) + 1
        End If
    End Sub

    Private Sub CheckFirstTravel()
        firstTravel = False
        If String.IsNullOrEmpty(txtNoRequest.Text) Then
            If departureDate_ <> Nothing Then
                firstTravel = ObjTravelRequest.GetFirstTravel(txtNIK.Text, txtTravelType.Text, departureDate_.Year.ToString())
            End If

            If firstTravel Then
                Dim dt As DataTable = ObjTravelRequest.GetPocketAllowance(txtTravelType.Text, IIf(String.IsNullOrEmpty(txtGolongan.Text), 0, txtGolongan.Text))
                If dt.Rows.Count > 0 Then
                    amountFirstTravel = dt.Rows(0).Item("FirstTravel")
                End If
                descFirstTravel = "1YR TAVEL (" + departureDate_.Year.ToString() + ")"
            End If
        Else
            If row_ IsNot Nothing Then
                If ObjTravelRequest.NIK = txtNIK.Text And txtTravelType.Text = "LN" Then
                    firstTravel = True
                    amountFirstTravel = row_("AdvanceIDR")
                    descFirstTravel = row_("Description")
                Else
                    If departureDate_ <> Nothing Then
                        firstTravel = ObjTravelRequest.GetFirstTravel(txtNIK.Text, txtTravelType.Text, departureDate_.Year.ToString())
                    End If

                    If firstTravel Then
                        Dim dt As DataTable = ObjTravelRequest.GetPocketAllowance(txtTravelType.Text, IIf(String.IsNullOrEmpty(txtGolongan.Text), 0, txtGolongan.Text))
                        If dt.Rows.Count > 0 Then
                            amountFirstTravel = dt.Rows(0).Item("FirstTravel")
                        End If
                        descFirstTravel = "1YR TAVEL (" + departureDate_.Year.ToString() + ")"
                    End If
                End If
            Else

            End If
        End If
    End Sub

    Private Sub HitungTotalAmount()

        If txtTravelType.Text = "DN" Then
            GridViewDetail.SetRowCellValue(GridViewDetail.FocusedRowHandle, "Negara", "INDONESIA")
        End If

        Dim dt = New DataTable
        Dim amountIDR As Double
        Dim amountUSD As Double
        Dim amountYEN As Double

        dt = ObjTravelRequest.GetPocketAllowance(txtTravelType.Text, txtGolongan.Text)

        If dt.Rows.Count > 0 Then
            'If curryIDAllowance = "YEN" Then
            '    amountYEN = dt.Rows(0).Item("AllowanceYEN")
            '    If amountYEN = 0 Then
            '        amountYEN = dt.Rows(0).Item("AllowanceUSD") * rateUSD / rateYEN
            '    End If
            'ElseIf curryIDAllowance = "USD" Then
            '    amountUSD = dt.Rows(0).Item("AllowanceUSD")
            'Else
            '    amountIDR = dt.Rows(0).Item("AllowanceIDR")
            'End If
            amountUSD = dt.Rows(0).Item("AllowanceUSD")
            amountYEN = dt.Rows(0).Item("AllowanceYEN")
            amountIDR = dt.Rows(0).Item("AllowanceIDR")
        End If

        Dim advanceIDR As Double = IIf(String.IsNullOrEmpty(txtAdvanceIDR.Text), 0, txtAdvanceIDR.Text)
        Dim advanceUSD As Double = IIf(String.IsNullOrEmpty(txtAdvanceUSD.Text), 0, txtAdvanceUSD.Text)
        Dim advanceYEN As Double = IIf(String.IsNullOrEmpty(txtAdvanceYEN.Text), 0, txtAdvanceYEN.Text)

        dtCost.Clear()
        If GridViewDetail.RowCount > 0 AndAlso departureDate_ <> Nothing Then
            If firstTravel Then
                dtCost.Rows.Add(txtNoRequest.Text, "C01", descFirstTravel, days, amountFirstTravel, 0, 0)
            End If
            dtCost.Rows.Add(txtNoRequest.Text, "C02", "POCKET ALLOWANCE", days, amountIDR * days, amountUSD * days, amountYEN * days)
            dtCost.Rows.Add(txtNoRequest.Text, "C03", "ADVANCE", days, advanceIDR, advanceUSD, advanceYEN)
        End If
        GridAdvance.DataSource = dtCost

    End Sub

    Private Sub CheckVisa()
        Dim negara As String
        Dim visa As String = String.Empty
        Dim deptDate As Date
        Dim ArrivDate As Date

        negara = IIf(GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "Negara") Is DBNull.Value, "", GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "Negara"))
        deptDate = IIf(GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "DepartureDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "DepartureDate"))
        ArrivDate = IIf(GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "ArrivalDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "ArrivalDate"))
        If (deptDate <> Nothing Or ArrivDate <> Nothing) and txtTravelType.Text = "LN" Then
            visa = ObjTravelRequestDetail.GetVisa(txtNIK.Text, negara, deptDate, ArrivDate)
        End If
        GridViewDetail.SetRowCellValue(GridViewDetail.FocusedRowHandle, "Visa", visa)
    End Sub

    Private Sub CheckPaspor()
        Dim dtPaspor As New DataTable
        Dim NoPaspor As String = String.Empty
        Dim deptDate As Date
        Dim ArrivDate As Date

        deptDate = IIf(GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "DepartureDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "DepartureDate"))
        ArrivDate = IIf(GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "ArrivalDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "ArrivalDate"))
        If (deptDate <> Nothing Or ArrivDate <> Nothing And txtTravelType.Text = "LN") Then
            dtPaspor = ObjTravelRequestDetail.GetPaspor(txtNIK.Text, deptDate, ArrivDate)
        End If
        GridViewDetail.SetRowCellValue(GridViewDetail.FocusedRowHandle, "NoPaspor", NoPaspor)
    End Sub

    Private Sub ViewForm()
        Call Proc_EnableButtons(False, False, False, False, False, False, False, False, False, False)
        GridViewDetail.OptionsBehavior.Editable = False
        txtNoRequest.Enabled = False
        txtDepartement.Enabled = False
        txtNIK.Enabled = False
        txtNama.Enabled = False
        txtGolongan.Enabled = False
        txtPurpose.Enabled = False
        txtTravelType.Enabled = False
        txtAdvanceIDR.Enabled = False
        txtAdvanceUSD.Enabled = False
        txtAdvanceYEN.Enabled = False
        btnAdd.Enabled = False
    End Sub

    Private Sub GridViewAdvance_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles GridViewAdvance.FocusedRowChanged
        Try
            Dim CostType = String.Empty
            Dim selectedRows() As Integer = GridViewAdvance.GetSelectedRows()
            For Each rowHandle As Integer In selectedRows
                If rowHandle >= 0 Then
                    CostType = GridViewAdvance.GetRowCellValue(rowHandle, "CostType")
                End If
            Next rowHandle

            If CostType = "C02" Then
                GridViewAdvance.Columns("AdvanceUSD").OptionsColumn.AllowEdit = True
                GridViewAdvance.Columns("AdvanceYEN").OptionsColumn.AllowEdit = True
                GridViewAdvance.Columns("AdvanceIDR").OptionsColumn.AllowEdit = True
            Else
                GridViewAdvance.Columns("AdvanceUSD").OptionsColumn.AllowEdit = False
                GridViewAdvance.Columns("AdvanceYEN").OptionsColumn.AllowEdit = False
                GridViewAdvance.Columns("AdvanceIDR").OptionsColumn.AllowEdit = False
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub CAdvanceIDR_EditValueChanged(sender As Object, e As EventArgs) Handles CAdvanceIDR.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub CAdvanceUSD_EditValueChanged(sender As Object, e As EventArgs) Handles CAdvanceUSD.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub CAdvanceYEN_EditValueChanged(sender As Object, e As EventArgs) Handles CAdvanceYEN.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
    End Sub

    Private Sub sendMail()
        Try
            Dim smtpServer As New SmtpClient
            Dim eMail As New MailMessage()
            smtpServer.UseDefaultCredentials = False
            smtpServer.Credentials = New Net.NetworkCredential("username@gmail.com", "password")
            smtpServer.Port = 25
            smtpServer.EnableSsl = True
            smtpServer.Host = "smtp.gmail.com"

            eMail = New MailMessage()
            eMail.From = New MailAddress("")
            eMail.To.Add("")
            eMail.Subject = "Email Sending"
            eMail.IsBodyHtml = False
            eMail.Body = ""
            smtpServer.Send(eMail)
            MsgBox("Mail Sent")

        Catch error_t As Exception
            MsgBox(error_t.ToString)
        End Try
    End Sub

End Class
