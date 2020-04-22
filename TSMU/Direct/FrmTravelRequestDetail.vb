Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class FrmTravelRequestDetail
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""

    Dim NoRequest As String
    Dim GridDtl As GridControl
    Dim dtGrid As DataTable
    Dim ObjTravelRequest As New TravelRequestModel
    Dim ObjTravelRequestDetail As New TravelRequestDetailModel
    Dim ObjTravelRequestCost As New TravelRequestCostModel
    'Dim ObjTravelRequestAllowance As New TravelRequestAllowanceModel

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

    Private Sub FrmTravelRequestDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Call InitialSetForm()
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
                Me.Text = "Travel Request : " & fs_Code
            Else
                Me.Text = "New Travel Request"
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
            ListItemsNegara()

            If fs_Code <> "" Then
                Dim dtGrid As New DataTable
                ObjTravelRequestDetail.NoRequest = txtNoRequest.Text
                dtGrid = ObjTravelRequestDetail.GetDetailByID()
                GridDetail.DataSource = dtGrid
                GridCellFormat(GridViewDetail)

                dtGrid = ObjTravelRequestCost.GetCostByID()
                GridAdvance.DataSource = dtGrid
                GridCellFormat(GridViewAdvance)
            Else
                Dim dtGrid As New DataTable
                ObjTravelRequestDetail.NoRequest = ""
                dtGrid = ObjTravelRequestDetail.GetDetailByID()
                GridDetail.DataSource = dtGrid
                GridCellFormat(GridViewDetail)

                ObjTravelRequestCost.NoRequest = ""
                dtGrid = ObjTravelRequestCost.GetCostByID()
                GridAdvance.DataSource = dtGrid
                GridCellFormat(GridViewAdvance)
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadTxtBox()
        Try
            ListItemsGolongan()

            If fs_Code <> "" Then
                With ObjTravelRequest
                    txtNoRequest.Text = .NoRequest
                    txtNIK.Text = .NIK
                    txtNama.Text = .Nama
                    'dtTanggal.EditValue = .Tanggal
                    txtDepartement.Text = .DeptID
                    txtTravelType.Text = .TravelType
                    txtGolongan.Text = .Golongan
                    txtPurpose.Text = .Purpose
                End With
            Else
                txtNoRequest.Text = ""
                ''dtTanggal.EditValue = DateTime.Today
                txtDepartement.Text = gh_Common.GroupID
                txtNIK.Text = ""
                txtNama.Text = ""
                txtGolongan.Text = ""
                txtPurpose.Text = ""
                txtTravelType.Text = "LN"
                txtAdvanceIDR.Text = 0
                txtAdvanceUSD.Text = 0
                txtAdvanceYEN.Text = 0
                txtNIK.Focus()
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

            If txtNIK.Text = "" Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
            End If

            Dim i As Integer
            If String.IsNullOrEmpty(txtGolongan.Text) Then
                i = "0"
            Else
                i = Convert.ToInt16(txtGolongan.Text)
            End If

            If lb_Validated Then
                With ObjTravelRequest
                    NoRequest = .TravelRequestAutoNo
                    .NoRequest = NoRequest
                    .Nama = txtNama.Text.Trim.ToUpper
                    .Tanggal = Date.Today
                    .DeptID = txtDepartement.Text.Trim.ToUpper
                    .TravelType = txtTravelType.Text.Trim.ToUpper
                    .NIK = txtNIK.Text.Trim.ToUpper
                    .Golongan = i
                    .Purpose = txtPurpose.Text
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
            If isUpdate = False Then
                ObjTravelRequest.ObjDetails.Clear()
                For i As Integer = 0 To GridViewDetail.RowCount - 1
                    seq = seq + 1
                    ObjTravelRequestDetail = New TravelRequestDetailModel
                    With ObjTravelRequestDetail
                        .NoRequest = NoRequest
                        .Seq = seq
                        .Destination = GridViewDetail.GetRowCellValue(i, "Destination").ToString().TrimEnd
                        .Negara = GridViewDetail.GetRowCellValue(i, "Negara").ToString().TrimEnd
                        .DepartureDate = IIf(GridViewDetail.GetRowCellValue(i, "DepartureDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(i, "DepartureDate"))
                        .ArrivalDate = IIf(GridViewDetail.GetRowCellValue(i, "ArrivalDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(i, "ArrivalDate"))
                        .SafetyMoneyIDR = IIf(GridViewDetail.GetRowCellValue(i, "SafetyMoneyIDR") Is DBNull.Value, 0, GridViewDetail.GetRowCellValue(i, "SafetyMoneyIDR"))
                        .SafetyMoneyUSD = IIf(GridViewDetail.GetRowCellValue(i, "SafetyMoneyUSD") Is DBNull.Value, 0, GridViewDetail.GetRowCellValue(i, "SafetyMoneyUSD"))
                        .SafetyMoneyYEN = IIf(GridViewDetail.GetRowCellValue(i, "SafetyMoneyYEN") Is DBNull.Value, 0, GridViewDetail.GetRowCellValue(i, "SafetyMoneyYEN"))
                    End With
                    ObjTravelRequest.ObjDetails.Add(ObjTravelRequestDetail)
                Next

                'ObjTravelRequest.ObjAllowance.Clear()
                'For i As Integer = 0 To GridViewDetail.RowCount - 1
                '    ObjTravelRequestAllowance = New TravelRequestAllowanceModel
                '    With ObjTravelRequestAllowance
                '        .NoRequest = NoRequest
                '        .Term = GridViewDetail.GetRowCellValue(i, "Destination").ToString().TrimEnd
                '        .Days = Convert.ToInt16(GridViewDetail.GetRowCellValue(i, "Days"))
                '        .CuryID = GridViewDetail.GetRowCellValue(i, "CuryID").ToString().TrimEnd
                '        .Amount = Convert.ToDouble(GridViewDetail.GetRowCellValue(i, "Amount"))
                '        .TotalAmount = Convert.ToDouble(GridViewDetail.GetRowCellValue(i, "TotalAmount"))
                '    End With
                '    ObjTravelRequest.ObjDetails.Add(ObjTravelRequestDetail)
                'Next

                ObjTravelRequest.InsertData()
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)

            Else
                ObjTravelRequest.ObjDetails.Clear()
                For i As Integer = 0 To GridViewDetail.RowCount - 1
                    seq = seq + 1
                    ObjTravelRequestDetail = New TravelRequestDetailModel
                    With ObjTravelRequestDetail
                        .NoRequest = txtNoRequest.Text
                        .Seq = seq
                        .Destination = GridViewDetail.GetRowCellValue(i, "Destination").ToString().TrimEnd
                        .DepartureDate = IIf(GridViewDetail.GetRowCellValue(i, "DepartureDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(i, "DepartureDate"))
                        .ArrivalDate = IIf(GridViewDetail.GetRowCellValue(i, "ArrivalDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(i, "ArrivalDate"))
                        .SafetyMoneyIDR = IIf(GridViewDetail.GetRowCellValue(i, "SafetyMoneyIDR") Is DBNull.Value, 0, GridViewDetail.GetRowCellValue(i, "SafetyMoneyIDR"))
                        .SafetyMoneyUSD = IIf(GridViewDetail.GetRowCellValue(i, "SafetyMoneyUSD") Is DBNull.Value, 0, GridViewDetail.GetRowCellValue(i, "SafetyMoneyUSD"))
                        .SafetyMoneyYEN = IIf(GridViewDetail.GetRowCellValue(i, "SafetyMoneyYEN") Is DBNull.Value, 0, GridViewDetail.GetRowCellValue(i, "SafetyMoneyYEN"))
                    End With
                    ObjTravelRequest.ObjDetails.Add(ObjTravelRequestDetail)
                Next

                'ObjTravelRequest.ObjAllowance.Clear()
                'For i As Integer = 0 To GridViewDetail.RowCount - 1
                '    ObjTravelRequestAllowance = New TravelRequestAllowanceModel
                '    With ObjTravelRequestAllowance
                '        .NoRequest = txtNoRequest.Text
                '        .Term = GridViewDetail.GetRowCellValue(i, "Destination").ToString().TrimEnd
                '        .Days = Convert.ToInt16(GridViewDetail.GetRowCellValue(i, "Days"))
                '        .CuryID = GridViewDetail.GetRowCellValue(i, "CuryID").ToString().TrimEnd
                '        .Amount = Convert.ToDouble(GridViewDetail.GetRowCellValue(i, "Amount"))
                '        .TotalAmount = Convert.ToDouble(GridViewDetail.GetRowCellValue(i, "TotalAmount"))
                '    End With
                '    ObjTravelRequest.ObjDetails.Add(ObjTravelRequestDetail)
                'Next

                ObjTravelRequest.NoRequest = txtNoRequest.Text
                '    ObjTravelHeader.UpdateData()
                '    Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            End If
            GridDtl.DataSource = ObjTravelRequest.GetAllDataTable("")
            IsClosed = True
            Me.Hide()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        GridViewDetail.AddNewRow()
        'GridViewDetail.OptionsNavigation.AutoFocusNewRow = True
        GridViewDetail.RefreshData()
        HitungTotalAmount()
    End Sub

    Private Sub GridViewDetail_KeyDown(sender As Object, e As KeyEventArgs) Handles GridViewDetail.KeyDown
        If e.KeyData = Keys.Delete Then
            GridViewDetail.DeleteRow(GridViewDetail.FocusedRowHandle)
            GridViewDetail.RefreshData()
            HitungTotalAmount()
        End If
        If e.KeyData = Keys.Insert Then
            GridViewDetail.AddNewRow()
        End If
    End Sub

    Private Sub txtGolongan_EditValueChanged(sender As Object, e As EventArgs) Handles txtGolongan.EditValueChanged
        HitungTotalAmount()
    End Sub

    'Private Sub HitungAllowance()
    '    Dim dt = New DataTable
    '    'Dim curryid As String = ""
    '    Dim amountIDR As Double
    '    Dim amountUSD As Double
    '    Dim amountYEN As Double

    '    If txtTravelType.Text <> "" And txtGolongan.Text <> "" Then
    '        ObjTravelRequest.TravelType = txtTravelType.Text
    '        ObjTravelRequest.Golongan = txtGolongan.Text
    '        dt = ObjTravelRequest.GetPocketAllowance
    '        If dt.Rows.Count > 0 Then
    '            amountIDR = dt.Rows(0).Item(1).ToString()
    '            amountUSD = dt.Rows(0).Item(2).ToString()
    '        End If
    '    End If
    '    GridViewAdvance.SetRowCellValue(1, "AmountIDR", amountIDR)
    '    GridViewAdvance.SetRowCellValue(1, "AmountUSD", amountUSD)
    '    GridViewAdvance.SetRowCellValue(1, "AmountYEN", amountYEN)
    '    GridViewAdvance.RefreshData()
    '    'HitungTotalAmount()
    'End Sub

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
        GridViewDetail.RefreshData()
        HitungTotalAmount()
    End Sub

    Private Sub CDepartureDate_EditValueChanged(sender As Object, e As EventArgs) Handles CDepartureDate.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim departueDate As Date
        Dim arrivalDate As Date
        departueDate = GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "DepartureDate")
        arrivalDate = IIf(GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "ArrivalDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "ArrivalDate"))
        If arrivalDate = Nothing Or departueDate > arrivalDate Then
            GridViewDetail.SetRowCellValue(GridViewDetail.FocusedRowHandle, "ArrivalDate", departueDate)
        End If
        HitungTotalAmount()
    End Sub

    Private Sub HitungTotalAmount()
        Dim departueDate As Date
        Dim arrivalDate As Date
        'Dim term As String = String.Empty
        Dim days As Integer

        If txtTravelType.Text = "DN" Then
            GridViewDetail.SetRowCellValue(GridViewDetail.FocusedRowHandle, "Negara", "INDONESIA")
        End If

        For i As Integer = 0 To GridViewDetail.RowCount - 1
            Dim _date As Date
            _date = IIf(GridViewDetail.GetRowCellValue(i, "DepartureDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(i, "DepartureDate"))
            If _date <> Nothing And (departueDate > _date Or departueDate = Nothing) Then
                departueDate = GridViewDetail.GetRowCellValue(i, "DepartureDate")
                'term = departueDate.ToString("d MMMM yyyy").ToUpper + " - " + arrivalDate.ToString("d MMMM yyyy").ToUpper
                days = DateDiff(DateInterval.Day, departueDate, arrivalDate) + 1
            End If
            _date = IIf(GridViewDetail.GetRowCellValue(i, "ArrivalDate") Is DBNull.Value, Nothing, GridViewDetail.GetRowCellValue(i, "ArrivalDate"))
            If _date <> Nothing And (arrivalDate < _date Or arrivalDate = Nothing) Then
                arrivalDate = GridViewDetail.GetRowCellValue(i, "ArrivalDate")
                'term = departueDate.ToString("d MMMM yyyy").ToUpper + " - " + arrivalDate.ToString("d MMMM yyyy").ToUpper
                days = DateDiff(DateInterval.Day, departueDate, arrivalDate) + 1
            End If
        Next

        Dim dt = New DataTable
        Dim amountIDR As Double
        Dim amountUSD As Double
        Dim amountYEN As Double

        If txtTravelType.Text <> "" And txtGolongan.Text <> "" Then
            ObjTravelRequest.TravelType = txtTravelType.Text
            ObjTravelRequest.Golongan = txtGolongan.Text
            dt = ObjTravelRequest.GetPocketAllowance
            If dt.Rows.Count > 0 Then
                amountIDR = dt.Rows(0).Item(1).ToString()
                amountUSD = dt.Rows(0).Item(2).ToString()
            End If
        End If

        Dim firstTravel As Integer
        If firstTravel = 0 And departueDate <> Nothing Then
            firstTravel = ObjTravelRequest.GetFirstTravel(txtNIK.Text, departueDate.Year.ToString())
        Else
            firstTravel = 1
        End If

        dt = New DataTable
        dt.Columns.Add("Description", GetType(String))
        dt.Columns.Add("Days", GetType(Integer))
        dt.Columns.Add("AdvanceIDR", GetType(Double))
        dt.Columns.Add("AdvanceUSD", GetType(Double))
        dt.Columns.Add("AdvanceYEN", GetType(Double))

        Dim advanceIDR As Double = IIf(String.IsNullOrEmpty(txtAdvanceIDR.Text), 0, txtAdvanceIDR.Text)
        Dim advanceUSD As Double = IIf(String.IsNullOrEmpty(txtAdvanceUSD.Text), 0, txtAdvanceUSD.Text)
        Dim advanceYEN As Double = IIf(String.IsNullOrEmpty(txtAdvanceYEN.Text), 0, txtAdvanceYEN.Text)

        dt.Rows.Add("ADVANCE", days, advanceIDR, advanceUSD, advanceYEN)
        dt.Rows.Add("POCKET ALLOWANCE", days, amountIDR * days, amountUSD * days, amountYEN * days)
        If firstTravel <> 1 Then
            dt.Rows.Add("1YR TRAVEL " + "(" + departueDate.Year.ToString() + ")", days, 500000, 0, 0)
        End If
        GridAdvance.DataSource = dt

    End Sub

    Private Sub CArrivalDate_EditValueChanged(sender As Object, e As EventArgs) Handles CArrivalDate.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        HitungTotalAmount()
    End Sub

    Private Sub CNegara_EditValueChanged(sender As Object, e As EventArgs) Handles CNegara.EditValueChanged
        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim negara As String
        Dim visa As String
        negara = GridViewDetail.GetRowCellValue(GridViewDetail.FocusedRowHandle, "Negara")
        visa = ObjTravelRequestDetail.GetVisa(txtNIK.Text, negara)
        GridViewDetail.SetRowCellValue(GridViewDetail.FocusedRowHandle, "Visa", visa)
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

End Class
