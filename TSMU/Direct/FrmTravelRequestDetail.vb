Imports DevExpress.XtraEditors
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
    Dim rowC01 As DataRow
    Dim rowC02 As DataRow
    Dim rowC03 As DataRow
    Dim firstTravel As Boolean = False
    Dim amountFirstTravel As Double
    Dim descFirstTravel As String

    Dim departureDate_ As Date
    Dim arrivalDate_ As Date
    Dim days As Integer
    Dim dtGrid As DataTable
    Dim GridDtl As GridControl
    Dim rateAllowance As Double
    Dim amountIDRUSD As Double
    Dim amountIDRYEN As Double
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
        Call InitialSetForm()
        If FrmParent.Name = "FrmTravelTicket" Then
            Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False, False)
        Else
            If fs_Code2 = "TabPageRequestAll" Then
                Call Proc_EnableButtons(False, False, False, False, False, False, False, False, False, False)
                ViewForm()
            ElseIf fs_Code2 = "TabPageApproved" Then
                Call Proc_EnableButtons(False, False, False, False, False, False, False, False, False, False, True)
                ViewForm()
            ElseIf fs_Code2 = "TabPageProgress" Then
                Call Proc_EnableButtons(False, False, False, False, False, False, False, False, False, False, True)
                ViewForm()
            Else
                If isUpdate And String.IsNullOrEmpty(ObjTravelRequest.Approved) Then
                    Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False, True)
                Else
                    Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False, False)
                End If
            End If
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

    Private Sub LoadGridDetail()
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
                Dim dt As New DataTable
                dt = ObjTravelRequestCost.GetCostByID()

                For Each row__ As DataRow In dt.Rows
                    row__("AdvanceIDRUSD") = row__("AdvanceUSD") * rateUSD
                    row__("AdvanceIDRYEN") = row__("AdvanceYEN") * rateYEN
                    row__("TotalAdvanceIDR") = row__("AdvanceIDRUSD") + row__("AdvanceIDRYEN") + row__("AdvanceIDR")
                    If row__("CostType").Contains("C01") Then
                        rowC01 = row__
                    ElseIf row__("CostType").Contains("C02") Then
                        rowC02 = row__
                        rateAllowance = row__("RateAdvanceIDR")
                    ElseIf row__("CostType").Contains("C03") Then
                        rowC03 = row__
                        txtAdvanceIDR.Text = row__("AdvanceIDR")
                        txtAdvanceUSD.Text = row__("AdvanceUSD")
                        txtAdvanceYEN.Text = row__("AdvanceYEN")
                    End If
                Next
                GridAdvance.DataSource = dt
                GetTravelDate()
                isLoad = False
            Else
                dtGrid = New DataTable
                ObjTravelRequestDetail.NoRequest = ""
                dtGrid = ObjTravelRequestDetail.GetDetailByID()
                GridDetail.DataSource = dtGrid
                GridAdvance.DataSource = dtCost
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try
            ListItemsGolongan()
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
                    txtApproved.Text = .Approved
                End With
                rateUSD = ObjTravelRequest.GetRate("USD", ObjTravelRequest.Tanggal)
                rateYEN = ObjTravelRequest.GetRate("JPY", ObjTravelRequest.Tanggal)
            Else
                txtNoRequest.Text = ""
                txtDepartement.Text = gh_Common.GroupID
                txtNIK.Text = ""
                txtNama.Text = ""
                txtGolongan.EditValue = Nothing
                txtPurpose.Text = ""
                txtApproved.Text = ""
                txtTravelType.Text = "LN"
                rateUSD = ObjTravelRequest.GetRate("USD", DateTime.Today)
                rateYEN = ObjTravelRequest.GetRate("JPY", DateTime.Today)

            End If
            ketRateUSD = "1USD : " + Format(rateUSD, gs_FormatDecimal)
            ketRateYEN = "1YEN : " + Format(rateYEN, gs_FormatDecimal)
            Label1.Text = "" & ketRateUSD & "   |   " & ketRateYEN & ""
            If fs_Code2 = "TabPageApproved" Or fs_Code2 = "TabPageProgress" Then
                txtApproved.Enabled = True
            Else
                txtApproved.Enabled = False
            End If
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
                If ObjTravelRequest.StatusTicket = "INVOICE" Then
                    Err.Raise(ErrNumber, , "No Request " & fs_Code & " sudah dilakukan Invoice ticket !")
                ElseIf ObjTravelRequest.StatusTicket = "ISSUE" Then
                    Err.Raise(ErrNumber, , "No Request " & fs_Code & " sudah dilakukan Pesan ticket !")
                ElseIf ObjTravelRequest.Pay = 1 Then
                    Err.Raise(ErrNumber, , "No Request " & fs_Code & " sudah dilakukan advance expense !")
                End If
            End If

            If txtNIK.Text = "" Or txtGolongan.Text = "" Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
            ElseIf Len(txtNIK.Text) <> 9 Then
                Err.Raise(ErrNumber, , "NIK harus 9 digit !")
            ElseIf GridViewAdvance.RowCount = 0 Then
                Err.Raise(ErrNumber, , "Data detail tidak boleh kosong !")
            End If

            If lb_Validated Then
                Dim status As String = "CREATE"
                Dim approved As String = String.Empty
                If isUpdate = False Then
                    txtNoRequest.Text = ObjTravelRequest.TravelRequestAutoNo
                Else
                    If FrmParent.Name = "FrmTravelTicket" Then
                        approved = ObjTravelRequest.Approved
                        status = ObjTravelRequest.Status
                    End If
                End If

                With ObjTravelRequest
                    .NoRequest = txtNoRequest.Text
                    .Nama = txtNama.Text.Trim.ToUpper
                    .DeptID = txtDepartement.Text.Trim.ToUpper
                    .TravelType = txtTravelType.Text.Trim.ToUpper
                    .NIK = txtNIK.Text.Trim.ToUpper
                    .Golongan = txtGolongan.Text
                    .Purpose = txtPurpose.Text
                    .Status = status
                    .Approved = approved
                    .Comment = ""
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
                    .Destination = IIf(GridViewDetail.GetRowCellValue(i, "Destination") Is DBNull.Value, "", GridViewDetail.GetRowCellValue(i, "Destination").ToString().ToUpper)
                    If String.IsNullOrEmpty(GridViewDetail.GetRowCellValue(i, "Negara")) Then
                        Err.Raise(ErrNumber, , "Negara tidak boleh kosong !")
                    End If
                    .Negara = GridViewDetail.GetRowCellValue(i, "Negara").ToString()
                    .NoPaspor = GridViewDetail.GetRowCellValue(i, "NoPaspor").ToString()
                    .Visa = GridViewDetail.GetRowCellValue(i, "Visa").ToString()
                    If GridViewDetail.GetRowCellValue(i, "DepartureDate") Is DBNull.Value Then
                        Err.Raise(ErrNumber, , "Departure Date tidak boleh kosong !")
                    End If
                    .DepartureDate = IIf(GridViewDetail.GetRowCellValue(i, "DepartureDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(i, "DepartureDate"))
                    If GridViewDetail.GetRowCellValue(i, "ArrivalDate") Is DBNull.Value Then
                        Err.Raise(ErrNumber, , "Arrival Date Date tidak boleh kosong !")
                    End If
                    .ArrivalDate = IIf(GridViewDetail.GetRowCellValue(i, "ArrivalDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(i, "ArrivalDate"))
                End With
                ObjTravelRequest.ObjRequestDetails.Add(ObjTravelRequestDetail)
            Next

            ObjTravelRequest.ObjRequestCost.Clear()
            For i As Integer = 0 To GridViewAdvance.RowCount - 1
                ObjTravelRequestCost = New TravelRequestCostModel
                With ObjTravelRequestCost
                    .NoRequest = txtNoRequest.Text
                    Dim costType As String = GridViewAdvance.GetRowCellValue(i, "CostType").ToString().TrimEnd.ToUpper
                    .CostType = costType
                    .Description = GridViewAdvance.GetRowCellValue(i, "Description").ToString().TrimEnd
                    .Days = Convert.ToInt16(GridViewAdvance.GetRowCellValue(i, "Days"))
                    .AdvanceIDR = Convert.ToDouble(GridViewAdvance.GetRowCellValue(i, "AdvanceIDR"))
                    .AdvanceUSD = Convert.ToDouble(GridViewAdvance.GetRowCellValue(i, "AdvanceUSD"))
                    If Convert.ToDouble(GridViewAdvance.GetRowCellValue(i, "AdvanceUSD")) Mod 5 <> 0 Then
                        Err.Raise(ErrNumber, , "Amount USD Harus Kelipatan 5 !")
                    End If
                    .AdvanceYEN = Convert.ToDouble(GridViewAdvance.GetRowCellValue(i, "AdvanceYEN"))
                    If Convert.ToDouble(GridViewAdvance.GetRowCellValue(i, "AdvanceYEN")) Mod 1000 <> 0 Then
                        Err.Raise(ErrNumber, , "Amount YEN Harus Kelipatan 1.000 !")
                    End If
                    .RateAdvanceIDR = Convert.ToDouble(GridViewAdvance.GetRowCellValue(i, "RateAdvanceIDR"))
                    If costType = "C02" And GridViewAdvance.GetRowCellValue(i, "TotalAdvanceIDR") > GridViewAdvance.GetRowCellValue(i, "RateAdvanceIDR") Then
                        Err.Raise(ErrNumber, , "Total Amount Melebihi Rate Pocket Allowance !")
                    End If
                End With
                ObjTravelRequest.ObjRequestCost.Add(ObjTravelRequestCost)
            Next

            If isUpdate = False Then
                ObjTravelRequest.InsertData()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                ObjTravelRequest.NoRequest = txtNoRequest.Text
                ObjTravelRequest.UpdateData()
                Call ShowMessage("Data Updated", MessageTypeEnum.NormalMessage)
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

    Public Overrides Sub Proc_Approve()
        Try
            Dim status As String = "PENDING"
            Dim comment As String = String.Empty
            Dim message As String = "Data Approved"
            If fs_Code2 = "TabPageRequest" Then
                ObjTravelRequest.Status = status
                ObjTravelRequest.Approved = ""
                ObjTravelRequest.Comment = comment
                ObjTravelRequest.UpdateStatusPending(fs_Code)
                GridDtl.DataSource = ObjTravelRequest.GetTravelRequest()
            ElseIf fs_Code2 = "TabPageApproved" Then
                If txtApproved.Text = "" Then
                    Err.Raise(ErrNumber, , "Approved tidak boleh kosong !")
                ElseIf txtApproved.Text = "REVISED" Then
                    status = "CREATE"
                    comment = inputComment()
                    message = "Data Revised"
                ElseIf txtApproved.Text = "CANCEL" Then
                    status = "CLOSE"
                    comment = inputComment()
                    message = "Data Cancel"
                End If
                ObjTravelRequest.Status = status
                ObjTravelRequest.Approved = txtApproved.Text
                ObjTravelRequest.Comment = comment
                ObjTravelRequest.UpdateStatusApprove(fs_Code)
                GridDtl.DataSource = ObjTravelRequest.GetTravelApproved()
            ElseIf fs_Code2 = "TabPageProgress" Then
                If ObjTravelRequest.StatusTicket = "ISSUE" Then
                    Err.Raise(ErrNumber, , "No Request " & fs_Code & " sudah dilakukan Pesan ticket !")
                ElseIf ObjTravelRequest.StatusTicket = "INVOICE" Then
                    Err.Raise(ErrNumber, , "No Request " & fs_Code & " sudah dilakukan Invoice ticket !")
                Else
                    If txtApproved.Text = "REVISED" Then
                        status = "CREATE"
                        comment = inputComment()
                        message = "Data Revised"
                    ElseIf txtApproved.Text = "CANCEL" Then
                        status = "CLOSE"
                        comment = inputComment()
                        message = "Data Cancel"
                    End If
                    ObjTravelRequest.Status = status
                    ObjTravelRequest.Approved = txtApproved.Text
                    ObjTravelRequest.Comment = comment
                    ObjTravelRequest.UpdateStatusApprove(fs_Code)
                    GridDtl.DataSource = ObjTravelRequest.GetTravelProgress()
                End If
            End If
            MessageBox.Show(message)
            IsClosed = True
            Me.Hide()
        Catch ex As Exception
            If Not String.IsNullOrEmpty(ex.Message) Then
                ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
                WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            End If
        End Try
    End Sub

    Private Function inputComment() As String
        Dim comment As String = String.Empty
        comment = InputBox("Silahkan Masukkan Comment !", "Comment", "")
        If comment.Length = 0 Then
            Throw New Exception("")
        End If
        Return comment
    End Function

    Public Overrides Sub Proc_Refresh()
        'InitialSetForm()
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
        If Len(txtNIK.Text) = 9 And departureDate_ <> Nothing Then
            CheckFirstTravel()
            HitungTotalAmount()
            Dim rowIndex As Integer
            For rowIndex = 0 To GridViewDetail.RowCount - 1
                CheckVisa(rowIndex)
                CheckPaspor(rowIndex)
            Next
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
        txtAdvanceIDR.Text = Format(Convert.ToDecimal(txtAdvanceIDR.Text), gs_FormatDecimal)
        If GridViewDetail.RowCount > 0 And Convert.ToDecimal(txtAdvanceIDR.Text) >= 0 And isLoad = False Then
            GridViewAdvance.SetRowCellValue(GridViewAdvance.RowCount - 1, "AdvanceIDR", txtAdvanceIDR.Text)
            hitungAmountAdvance()
        End If
    End Sub

    Private Sub txtAdvanceUSD_EditValueChanged(sender As Object, e As EventArgs) Handles txtAdvanceUSD.EditValueChanged
        txtAdvanceUSD.Text = Format(Convert.ToDecimal(txtAdvanceUSD.Text), gs_FormatDecimal)
        If GridViewDetail.RowCount > 0 And Convert.ToDecimal(txtAdvanceUSD.Text) >= 0 And isLoad = False Then
            GridViewAdvance.SetRowCellValue(GridViewAdvance.RowCount - 1, "AdvanceUSD", txtAdvanceUSD.Text)
            GridViewAdvance.SetRowCellValue(GridViewAdvance.RowCount - 1, "AdvanceIDRUSD", txtAdvanceUSD.Text * rateUSD)
            hitungAmountAdvance()
        End If
    End Sub

    Private Sub txtAdvanceYEN_EditValueChanged(sender As Object, e As EventArgs) Handles txtAdvanceYEN.EditValueChanged
        txtAdvanceYEN.Text = Format(Convert.ToDecimal(txtAdvanceYEN.Text), gs_FormatDecimal)
        If GridViewDetail.RowCount > 0 And Convert.ToDecimal(txtAdvanceYEN.Text) >= 0 And isLoad = False Then
            GridViewAdvance.SetRowCellValue(GridViewAdvance.RowCount - 1, "AdvanceYEN", txtAdvanceYEN.Text)
            GridViewAdvance.SetRowCellValue(GridViewAdvance.RowCount - 1, "AdvanceIDRYEN", txtAdvanceYEN.Text * rateYEN)
            hitungAmountAdvance()
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
        AddNewRow(GridViewDetail)
    End Sub

    Private Sub AddNewRow(ByVal view As GridView)
        view.AddNewRow()
        view.OptionsNavigation.AutoFocusNewRow = True
        Dim negara As String = String.Empty
        If txtTravelType.Text = "DN" Then
            negara = "INDONESIA"
        End If
        view.SetRowCellValue(view.FocusedRowHandle, "Destination", "")
        view.SetRowCellValue(view.FocusedRowHandle, "Negara", negara)
        view.SetRowCellValue(view.FocusedRowHandle, "NoPaspor", "")
        view.SetRowCellValue(view.FocusedRowHandle, "Visa", "")
        view.SetRowCellValue(view.FocusedRowHandle, "DepartureDate", Nothing)
        view.SetRowCellValue(view.FocusedRowHandle, "ArrivalDate", Nothing)

        If GridViewAdvance.RowCount = 0 Then
            GetTravelDate()
            CheckFirstTravel()
            HitungTotalAmount()
        End If
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
        Dim rowIndex As Integer = GridViewDetail.FocusedRowHandle
        GetTravelDate()
        CheckFirstTravel()
        HitungTotalAmount()
        CheckVisa(rowIndex)
        CheckPaspor(rowIndex)
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
        Dim rowIndex As Integer = GridViewDetail.FocusedRowHandle
        GetTravelDate()
        CheckFirstTravel()
        HitungTotalAmount()
        CheckPaspor(rowIndex)
    End Sub

    Private Sub CNegara_EditValueChanged(sender As Object, e As EventArgs) Handles CNegara.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()
        Dim rowIndex As Integer = GridViewDetail.FocusedRowHandle
        CheckVisa(rowIndex)
    End Sub

    Private Sub ListItemsGolongan()
        Dim dtGolongan = New DataTable
        dtGolongan = ObjTravelRequest.GetListGolongan()
        txtGolongan.Properties.DataSource = dtGolongan
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
        dtCost.Columns.Add("AdvanceIDRUSD", GetType(Double))
        dtCost.Columns.Add("AdvanceYEN", GetType(Double))
        dtCost.Columns.Add("AdvanceIDRYEN", GetType(Double))
        dtCost.Columns.Add("RateAdvanceIDR", GetType(Double))
        dtCost.Columns.Add("TotalAdvanceIDR", GetType(Double))
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
            If rowC01 IsNot Nothing Then
                If ObjTravelRequest.NIK = txtNIK.Text And txtTravelType.Text = "LN" Then
                    firstTravel = True
                    amountFirstTravel = rowC01("AdvanceIDR")
                    descFirstTravel = rowC01("Description")
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
            amountUSD = dt.Rows(0).Item("AllowanceUSD")
            amountYEN = dt.Rows(0).Item("AllowanceYEN")
            amountIDR = dt.Rows(0).Item("AllowanceIDR")
        End If

        Dim advanceIDR As Double = IIf(String.IsNullOrEmpty(txtAdvanceIDR.Text), 0, txtAdvanceIDR.Text)
        Dim advanceUSD As Double = IIf(String.IsNullOrEmpty(txtAdvanceUSD.Text), 0, txtAdvanceUSD.Text)
        Dim advanceYEN As Double = IIf(String.IsNullOrEmpty(txtAdvanceYEN.Text), 0, txtAdvanceYEN.Text)

        dtCost.Clear()
        If GridViewDetail.RowCount > 0 Then
            amountIDR = amountIDR * days
            amountUSD = amountUSD * days
            amountYEN = amountYEN * days

            amountIDRUSD = amountUSD * rateUSD
            amountIDRYEN = amountYEN * rateYEN
            rateAllowance = amountIDR + amountIDRUSD + amountIDRYEN

            If firstTravel Then
                dtCost.Rows.Add(txtNoRequest.Text, "C01", descFirstTravel, days, amountFirstTravel, 0, 0, 0, 0, amountFirstTravel, amountFirstTravel)
            End If
            dtCost.Rows.Add(txtNoRequest.Text, "C02", "POCKET ALLOWANCE", days, amountIDR, amountUSD, amountIDRUSD, amountYEN, amountIDRYEN, rateAllowance, rateAllowance)
            dtCost.Rows.Add(txtNoRequest.Text, "C03", "ADVANCE", days, advanceIDR, advanceUSD, advanceUSD * rateUSD, advanceYEN, advanceYEN * rateYEN, advanceIDR + (advanceUSD * rateUSD) + (advanceYEN * rateYEN), advanceIDR + (advanceUSD * rateUSD) + (advanceYEN * rateYEN))
        End If
        GridAdvance.DataSource = dtCost

    End Sub

    Private Sub CheckVisa(ByVal rowIndex As Integer)
        Dim negara As String
        Dim visa As String = String.Empty
        Dim deptDate As Date
        Dim ArrivDate As Date

        negara = IIf(GridViewDetail.GetRowCellValue(rowIndex, "Negara") Is DBNull.Value, "", GridViewDetail.GetRowCellValue(rowIndex, "Negara"))
        deptDate = IIf(GridViewDetail.GetRowCellValue(rowIndex, "DepartureDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(rowIndex, "DepartureDate"))
        ArrivDate = IIf(GridViewDetail.GetRowCellValue(rowIndex, "ArrivalDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(rowIndex, "ArrivalDate"))
        If (deptDate <> Nothing Or ArrivDate <> Nothing) And txtTravelType.Text = "LN" Then
            visa = ObjTravelRequestDetail.GetVisa(txtNIK.Text, negara, deptDate, ArrivDate)
        End If
        GridViewDetail.SetRowCellValue(rowIndex, "Visa", visa)
    End Sub

    Private Sub CheckPaspor(ByVal rowIndex As Integer)
        Dim dtPaspor As New DataTable
        Dim paspor As String = String.Empty
        Dim noPaspor As String = String.Empty
        Dim deptDate As Date
        Dim ArrivDate As Date

        deptDate = IIf(GridViewDetail.GetRowCellValue(rowIndex, "DepartureDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(rowIndex, "DepartureDate"))
        ArrivDate = IIf(GridViewDetail.GetRowCellValue(rowIndex, "ArrivalDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(rowIndex, "ArrivalDate"))
        If (departureDate_ <> Nothing Or arrivalDate_ <> Nothing And txtTravelType.Text = "LN") Then
            dtPaspor = ObjTravelRequestDetail.GetPaspor(txtNIK.Text, deptDate, ArrivDate)
        End If

        If dtPaspor.Rows.Count > 0 Then
            'paspor = dtPaspor.Rows(0).Item("Expired")
            noPaspor = dtPaspor.Rows(0).Item("NoPaspor")
        End If
        'GridViewDetail.SetRowCellValue(rowIndex, "Paspor", paspor)
        GridViewDetail.SetRowCellValue(rowIndex, "NoPaspor", noPaspor)

    End Sub

    Private Sub ViewForm()
        GridViewDetail.OptionsBehavior.Editable = False
        GridViewAdvance.OptionsBehavior.Editable = False
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
            If fs_Code2 = "TabPageRequest" Or fs_Code = "" Then
                Dim CostType = String.Empty
                Dim selectedRows() As Integer = GridViewAdvance.GetSelectedRows()
                For Each rowHandle As Integer In selectedRows
                    If rowHandle >= 0 Then
                        CostType = GridViewAdvance.GetRowCellValue(rowHandle, "CostType")
                    End If
                Next rowHandle
                GridViewAdvance.OptionsBehavior.Editable = True
                If CostType = "C02" And txtTravelType.Text = "LN" Then
                    GridViewAdvance.Columns("AdvanceUSD").OptionsColumn.AllowEdit = True
                    GridViewAdvance.Columns("AdvanceYEN").OptionsColumn.AllowEdit = True
                    GridViewAdvance.Columns("AdvanceIDR").OptionsColumn.AllowEdit = True
                ElseIf CostType = "C02" And txtTravelType.Text = "DN" Then
                    GridViewAdvance.Columns("AdvanceUSD").OptionsColumn.AllowEdit = False
                    GridViewAdvance.Columns("AdvanceYEN").OptionsColumn.AllowEdit = False
                    GridViewAdvance.Columns("AdvanceIDR").OptionsColumn.AllowEdit = True
                Else
                    GridViewAdvance.OptionsBehavior.Editable = False
                End If
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub CAdvanceIDR_EditValueChanged(sender As Object, e As EventArgs) Handles CAdvanceIDR.EditValueChanged
        Dim amountIDRBefore As Double
        Dim amountIDRAfter As Double
        Dim amountUSD As Double = 0
        Dim amountYEN As Double = 0
        Dim totalAmountIDR As Double
        amountIDRBefore = GridViewAdvance.GetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceIDR")
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        amountIDRAfter = GridViewAdvance.GetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceIDR")
        amountUSD = GridViewAdvance.GetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceUSD")
        amountIDRUSD = GridViewAdvance.GetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceIDRUSD")
        amountYEN = GridViewAdvance.GetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceYEN")
        amountIDRYEN = GridViewAdvance.GetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceIDRYEN")
        Dim amountIDRUSD__ As Double
        Dim amountUSD__ As Double
        Dim totalAmountIDR__ As Double
        amountIDRUSD__ = amountIDRUSD - amountIDRAfter - amountIDRBefore
        If amountIDRUSD__ < 0 Then
            amountIDRUSD__ = 0
        End If
        amountUSD__ = amountIDRUSD__ / rateUSD
        totalAmountIDR = amountIDRUSD + amountIDRYEN + amountIDRBefore
        totalAmountIDR__ = amountIDRUSD__ + amountIDRYEN + amountIDRAfter
        If rateAllowance < totalAmountIDR__ Then
            MessageBox.Show("Total Amount Melebihi Rate Pocket Allowance !",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
            GridViewAdvance.SetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceIDR", amountIDRBefore)
        Else
            GridViewAdvance.SetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceUSD", amountUSD__)
            GridViewAdvance.SetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceIDRUSD", amountIDRUSD__)
            GridViewAdvance.SetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceIDR", amountIDRAfter)
            GridViewAdvance.SetRowCellValue(GridViewAdvance.FocusedRowHandle, "TotalAdvanceIDR", totalAmountIDR__)
        End If

    End Sub

    Private Sub CAdvanceUSD_EditValueChanged(sender As Object, e As EventArgs) Handles CAdvanceUSD.EditValueChanged
        Dim amountUSDBefore As Double
        Dim amountUSDAfter As Double
        Dim amountIDRUSD__ As Double
        Dim amountIDR__ As Double
        Dim totalAmountIDR As Double
        amountUSDBefore = GridViewAdvance.GetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceUSD")

        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        amountUSDAfter = GridViewAdvance.GetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceUSD")
        amountIDRUSD = GridViewAdvance.GetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceIDRUSD")
        amountIDRYEN = GridViewAdvance.GetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceIDRYEN")

        amountIDRUSD__ = amountUSDAfter * rateUSD
        totalAmountIDR = amountIDRUSD__ + amountIDRYEN
        amountIDR__ = rateAllowance - totalAmountIDR
        If rateAllowance < totalAmountIDR Then
            MessageBox.Show("Total Amount Melebihi Rate Pocket Allowance !",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)
            GridViewAdvance.SetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceUSD", amountUSDBefore)
        Else
            GridViewAdvance.SetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceIDRUSD", amountIDRUSD__)
            GridViewAdvance.SetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceIDR", amountIDR__)
            GridViewAdvance.SetRowCellValue(GridViewAdvance.FocusedRowHandle, "TotalAdvanceIDR", totalAmountIDR + amountIDR__)
        End If
    End Sub

    Private Sub CAdvanceYEN_EditValueChanged(sender As Object, e As EventArgs) Handles CAdvanceYEN.EditValueChanged
        Dim amountYENBefore As Double = 0
        Dim amountYENAfter As Double = 0
        Dim amountUSD As Double = 0
        Dim amountIDR As Double = 0
        Dim totalAmountIDR As Double = 0
        Dim totalAmountIDR__ As Double = 0
        amountYENBefore = GridViewAdvance.GetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceYEN")

        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        amountUSD = GridViewAdvance.GetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceUSD")
        amountIDRUSD = GridViewAdvance.GetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceIDRUSD")
        amountYENAfter = GridViewAdvance.GetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceYEN")
        amountIDRYEN = GridViewAdvance.GetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceIDRYEN")
        amountIDR = GridViewAdvance.GetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceIDR")
        totalAmountIDR = GridViewAdvance.GetRowCellValue(GridViewAdvance.FocusedRowHandle, "TotalAdvanceIDR")

        Dim amountIDRYEN__ As Double = amountYENAfter * rateYEN
        ''Mengurangi IDR oleh YEN
        Dim amountIDR__ As Double = amountIDR - amountIDRYEN__ + amountIDRYEN

        ''Mengurangi USD oleh YEN
        Dim amountIDRUSD__ As Double
        If amountIDR__ >= 0 Then
            amountIDRUSD__ = amountIDRUSD
            totalAmountIDR__ = amountIDRUSD__ + amountIDRYEN__
        Else
            amountIDRUSD__ = amountIDRUSD + amountIDR__
            If amountIDRUSD__ >= 0 Then
                amountUSD = amountIDRUSD__ / rateUSD
                Dim sisa As Double = amountUSD Mod 5
                amountUSD = amountUSD - sisa
                amountIDRUSD__ = amountUSD * rateUSD
                amountIDR__ = sisa * rateUSD
                totalAmountIDR__ = amountIDRUSD__ + amountIDRYEN__
            Else
                amountIDR__ = rateAllowance - amountIDRYEN__
                totalAmountIDR__ = amountIDRYEN__
                amountIDRUSD__ = amountIDRUSD
            End If
        End If

        If rateAllowance < totalAmountIDR__ Then
            MessageBox.Show("Total Amount Melebihi Rate Pocket Allowance !",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)

            GridViewAdvance.SetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceYEN", amountYENBefore)
            GridViewAdvance.SetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceUSD", amountUSD)
            GridViewAdvance.SetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceIDRUSD", amountIDRUSD)
            GridViewAdvance.SetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceIDRYEN", amountIDRYEN)
            GridViewAdvance.SetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceIDR", amountIDR)
            GridViewAdvance.SetRowCellValue(GridViewAdvance.FocusedRowHandle, "TotalAdvanceIDR", totalAmountIDR)
        Else
            GridViewAdvance.SetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceIDRUSD", amountIDRUSD__)
            GridViewAdvance.SetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceUSD", amountUSD)
            GridViewAdvance.SetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceIDRYEN", amountIDRYEN__)
            GridViewAdvance.SetRowCellValue(GridViewAdvance.FocusedRowHandle, "AdvanceIDR", amountIDR__)
            GridViewAdvance.SetRowCellValue(GridViewAdvance.FocusedRowHandle, "TotalAdvanceIDR", totalAmountIDR__ + amountIDR__)
        End If

    End Sub

    Private Sub sendMail()
        Try
            Dim smtpServer As New SmtpClient
            Dim eMail As New MailMessage()
            smtpServer.UseDefaultCredentials = False
            smtpServer.Credentials = New Net.NetworkCredential("miftah-mis@tsmu.co.id", "W[QIWbV~$ZZQ")
            smtpServer.Port = 25
            smtpServer.EnableSsl = True
            smtpServer.Host = "mail.tsmu.co.id"

            eMail = New MailMessage()
            eMail.From = New MailAddress("hamidi-mis@tsmu.co.id")
            eMail.To.Add("miftah-mis@tsmu.co.id")
            eMail.CC.Add("log@tsmu.co.id")
            eMail.Subject = "Request Passport & Visa"
            eMail.IsBodyHtml = True
            eMail.Body = "<p>Dear PGA,</p> <p>&nbsp;</p> <p>Sehubungan dengan adanya perjalanan travel a/n<strong> NAMA</strong>,</p> <p>mohon bantuannya untuk dibuatkan Visa atas nama yang bersangkutan.</p> <p><em><br />Email dikirim oleh sistem, tidak perlu dibalas.</em></p> <p>&nbsp;</p> <p>Terima kasih</p>"
            smtpServer.Send(eMail)

        Catch error_t As Exception
            MsgBox(error_t.ToString)
        End Try
    End Sub

    Private Sub hitungAmountAllowance()
        Dim amountIDRUSD As Double = GridViewAdvance.GetRowCellValue(GridViewAdvance.RowCount Mod 2, "AdvanceIDRUSD")
        Dim amountIDRYEN As Double = GridViewAdvance.GetRowCellValue(GridViewAdvance.RowCount Mod 2, "AdvanceIDRYEN")
        Dim amountIDR As Double = GridViewAdvance.GetRowCellValue(GridViewAdvance.RowCount Mod 2, "AdvanceIDR")
        GridViewAdvance.SetRowCellValue(GridViewAdvance.RowCount Mod 2, "TotalAdvanceIDR", amountIDRUSD + amountIDRYEN + amountIDR)
    End Sub

    Private Sub hitungAmountAdvance()
        Dim amountIDRUSD As Double = GridViewAdvance.GetRowCellValue(GridViewAdvance.RowCount - 1, "AdvanceIDRUSD")
        Dim amountIDRYEN As Double = GridViewAdvance.GetRowCellValue(GridViewAdvance.RowCount - 1, "AdvanceIDRYEN")
        Dim amountIDR As Double = GridViewAdvance.GetRowCellValue(GridViewAdvance.RowCount - 1, "AdvanceIDR")
        GridViewAdvance.SetRowCellValue(GridViewAdvance.RowCount - 1, "TotalAdvanceIDR", amountIDRUSD + amountIDRYEN + amountIDR)
        GridViewAdvance.SetRowCellValue(GridViewAdvance.RowCount - 1, "RateAdvanceIDR", amountIDRUSD + amountIDRYEN + amountIDR)
    End Sub

End Class
