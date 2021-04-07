Imports DevExpress.XtraGrid
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls

Public Class Frm_Detail_PurchaseOrder

    Dim fc_Class As New Cls_PO
    Dim GridDtl As GridControl
    Dim _Tag As TagModel
    Dim Active_Form As Integer = 0
    Dim PONumber As String = ""
    Dim DtGridBarang As DataTable
    Dim dtBarang As DataTable

    Dim isUpdate As Boolean = False
    Private Sub Frm_Detail_PurchaseOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CreateTableBarang()
        Call InitialSetForm()
        Call List_TipePO()
        Call List_Status()
        Call List_AddressType()

    End Sub

    Private Sub CreateTableBarang()
        DtGridBarang = New DataTable
        DtGridBarang.Columns.AddRange(New DataColumn(25) {New DataColumn("PR No", GetType(String)),
                                                            New DataColumn("PR Line No", GetType(String)),
                                                            New DataColumn("Alternate Manual", GetType(String)),
                                                            New DataColumn("Inventory ID", GetType(String)),
                                                            New DataColumn("Description", GetType(String)),
                                                            New DataColumn("Quantity", GetType(Double)),
                                                            New DataColumn("OUM", GetType(Double)),
                                                            New DataColumn("Unit Cost", GetType(Double)),
                                                            New DataColumn("Extended Cost", GetType(Double)),
                                                            New DataColumn("Status Price", GetType(String)),
                                                            New DataColumn("Unit Weight", GetType(String)),
                                                            New DataColumn("Site ID", GetType(Double)),
                                                            New DataColumn("Extended Weight", GetType(Double)),
                                                            New DataColumn("Purchase For", GetType(Double)),
                                                            New DataColumn("Unit Volume", GetType(Double)),
                                                            New DataColumn("Extended Volume", GetType(String)),
                                                            New DataColumn("Required", GetType(String)),
                                                            New DataColumn("Promised", GetType(Integer)),
                                                            New DataColumn("Account", GetType(String)),
                                                            New DataColumn("SubAccount", GetType(String)),
                                                            New DataColumn("Rcpt Qty Min%", GetType(String)),
                                                            New DataColumn("Rcpt Qty Max%", GetType(String)),
                                                            New DataColumn("Receipt Action", GetType(String)),
                                                            New DataColumn("Receipt Status", GetType(String)),
                                                            New DataColumn("Voucher Status", GetType(String)),
                                                            New DataColumn("Include In Lead Time Calc", GetType(String))})
    End Sub

    Private Sub List_AddressType()
        Dim cList As New ContactList()
        cList.Add(New Contact("P", "PO Setup Record"))
        cList.Add(New Contact("S", "Site"))
        cList.Add(New Contact("C", "Customer"))
        cList.Add(New Contact("V", "Vendor"))
        cList.Add(New Contact("O", "Other"))

        'bind the lookup editor to the list
        T_ShippingAddressType.Properties.DataSource = cList
        T_ShippingAddressType.Properties.DisplayMember = "Name"
        T_ShippingAddressType.Properties.ValueMember = "Id"
        ' Add columns.
        ' The ID column is populated 
        ' via the GetNotInListValue event (not listed in the example).
        T_ShippingAddressType.Properties.Columns.Add(New LookUpColumnInfo("Id", "ID", 20))
        T_ShippingAddressType.Properties.Columns.Add(New LookUpColumnInfo("Name", "Name", 80))
        'enable text editing
        T_ShippingAddressType.Properties.TextEditStyle = TextEditStyles.Standard
    End Sub

    Private Sub List_TipePO()
        Dim cList As New ContactList()
        cList.Add(New Contact("OR", "Reguler Order"))
        cList.Add(New Contact("DP", "Drop Ship"))
        cList.Add(New Contact("BL", "Blanket Order"))
        cList.Add(New Contact("St", "Standard Order"))

        'bind the lookup editor to the list
        T_POType.Properties.DataSource = cList
        T_POType.Properties.DisplayMember = "Name"
        T_POType.Properties.ValueMember = "Id"
        ' Add columns.
        ' The ID column is populated 
        ' via the GetNotInListValue event (not listed in the example).
        T_POType.Properties.Columns.Add(New LookUpColumnInfo("Id", "ID", 20))
        T_POType.Properties.Columns.Add(New LookUpColumnInfo("Name", "Name", 80))
        'enable text editing
        T_POType.Properties.TextEditStyle = TextEditStyles.Standard
    End Sub

    Private Sub List_Status()
        Dim StatusList As New StatusList()
        StatusList.Add(New Status("M", "Completed"))
        StatusList.Add(New Status("O", "Open Order"))
        StatusList.Add(New Status("P", "Purchase Order"))
        StatusList.Add(New Status("Q", "Quote Order"))
        StatusList.Add(New Status("X", "Cancelled"))
        'bind the lookup editor to the list
        T_Status.Properties.DataSource = StatusList
        T_Status.Properties.DisplayMember = "Name"
        T_Status.Properties.ValueMember = "Id"
        ' Add columns.
        ' The ID column is populated 
        ' via the GetNotInListValue event (not listed in the example).
        T_Status.Properties.Columns.Add(New LookUpColumnInfo("Id", "ID", 20))
        T_Status.Properties.Columns.Add(New LookUpColumnInfo("Name", "Name", 80))
        'enable text editing
        T_Status.Properties.TextEditStyle = TextEditStyles.Standard
    End Sub



    Public Class ContactList
        Inherits System.Collections.CollectionBase

        Default Public Property Item(ByVal index As Integer) As Contact
            Get
                Return DirectCast(List(index), Contact)
            End Get
            Set(ByVal value As Contact)
                List(index) = value
            End Set
        End Property

        Public Function Add(ByVal value As Contact) As Integer
            Return List.Add(value)
        End Function
        '...
    End Class

    Public Class StatusList
        Inherits System.Collections.CollectionBase

        Default Public Property Item(ByVal index As Integer) As Status
            Get
                Return DirectCast(List(index), Status)
            End Get
            Set(ByVal value As Status)
                List(index) = value
            End Set
        End Property

        Public Function Add(ByVal value As Status) As Integer
            Return List.Add(value)
        End Function
        '...
    End Class

    Public Class Contact
        'INSTANT VB NOTE: The variable name was renamed since Visual Basic does not allow variables and other class members to have the same name:
        Private name_Renamed As String
        'INSTANT VB NOTE: The variable id was renamed since Visual Basic does not allow variables and other class members to have the same name:
        Private id_Renamed As String

        Public Sub New(ByVal _id As String, ByVal _name As String)
            id_Renamed = _id
            name_Renamed = _name
        End Sub

        Public Property Name() As String
            Get
                Return name_Renamed
            End Get
            Set(ByVal value As String)
                name_Renamed = value
            End Set
        End Property

        Public Property Id() As String
            Get
                Return id_Renamed
            End Get
            Set(ByVal value As String)
                id_Renamed = value
            End Set
        End Property
    End Class

    Public Class Status
        'INSTANT VB NOTE: The variable name was renamed since Visual Basic does not allow variables and other class members to have the same name:
        Private name_Renamed As String
        'INSTANT VB NOTE: The variable id was renamed since Visual Basic does not allow variables and other class members to have the same name:
        Private id_Renamed As String

        Public Sub New(ByVal _id As String, ByVal _name As String)
            id_Renamed = _id
            name_Renamed = _name
        End Sub

        Public Property Name() As String
            Get
                Return name_Renamed
            End Get
            Set(ByVal value As String)
                name_Renamed = value
            End Set
        End Property

        Public Property Id() As String
            Get
                Return id_Renamed
            End Get
            Set(ByVal value As String)
                id_Renamed = value
            End Set
        End Property
    End Class



    Public Overrides Sub InitialSetForm()

        T_ShippingSiteId.Enabled = False
        T_ShippingCustomerID.Enabled = False
        T_ShippingCustomerAddress.Enabled = False
        T_ShippingVendorID.Enabled = False
        T_ShippingVendorAddres.Enabled = False
        T_ShippingOtherAddressID.Enabled = False

        If fs_Code <> "" Then
            Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
        Else
            T_POType.EditValue = "OR"
            T_Status.EditValue = "P"
            T_ShippingAddressType.EditValue = "P"
            Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
            Me.Text = "PURCHASE ORDER "
        End If

        bb_IsUpdate = isUpdate
        bs_MainFormName = FrmParent.Name.ToString()

    End Sub




    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal strCode As String,
                   ByVal strCode2 As String,
                   ByRef lf_FormParent As Form,
                   ByVal li_GridRow As Integer,
                   ByRef _Grid As GridControl,
                   ByRef _Active_Form As Integer)
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
        Active_Form = _Active_Form
        PONumber = strCode

    End Sub



    Private Sub T_NoPR_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles T_PRNo.ButtonClick
        Try
            fc_Class = New Cls_PO
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""
            dtBarang = New DataTable


            dtSearch = fc_Class.Get_PR()
            ls_Judul = "PR"
            ls_OldKode = T_PRNo.EditValue

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                T_PRNo.EditValue = lF_SearchData.Values.Item(0).ToString.Trim

                dtBarang = fc_Class.Get_PRDetail(lF_SearchData.Values.Item(0).ToString.Trim)


            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub T_NoPR_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T_PRNo.KeyPress

        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0) Or (tombol = 8)) Then
            e.Handled = True
        End If
        T_PRNo.SelectAll()

    End Sub

    Private Sub T_NoPR_Click(sender As Object, e As EventArgs) Handles T_PRNo.Click
        T_PRNo.SelectAll()
    End Sub

    Private Sub T_VendorID_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles T_VendorID.ButtonClick
        Try
            fc_Class = New Cls_PO
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = fc_Class.Get_Vendor()
            ls_Judul = "VENDOR"
            ls_OldKode = T_PRNo.EditValue

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
                T_VendorID.EditValue = lF_SearchData.Values.Item(0).ToString.Trim
                T_VendorName.EditValue = lF_SearchData.Values.Item(1).ToString.Trim


                T_VI_Name.EditValue = lF_SearchData.Values.Item("Name").ToString.Trim
                T_VI_Attention.EditValue = lF_SearchData.Values.Item("Attn").ToString.Trim
                T_VI_Address1.EditValue = lF_SearchData.Values.Item("Addr1").ToString.Trim
                T_VI_Address2.EditValue = lF_SearchData.Values.Item("Addr2").ToString.Trim
                T_VI_City.EditValue = lF_SearchData.Values.Item("City").ToString.Trim
                T_VI_State.EditValue = lF_SearchData.Values.Item("State").ToString.Trim
                T_VI_Postal.EditValue = lF_SearchData.Values.Item("Zip").ToString.Trim
                T_VI_Country.EditValue = lF_SearchData.Values.Item("Country").ToString.Trim
                T_VI_Phone.EditValue = lF_SearchData.Values.Item("Phone").ToString.Trim
                T_VI_Fax.EditValue = lF_SearchData.Values.Item("Fax").ToString.Trim
                T_VI_Email.EditValue = ""

            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub T_VendorID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T_VendorID.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If
        T_VendorID.SelectAll()
    End Sub

    Private Sub T_VendorID_Click(sender As Object, e As EventArgs) Handles T_VendorID.Click
        T_VendorID.SelectAll()
    End Sub

    Private Sub T_VendorName_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T_VendorName.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub T_ShippingAddressType_EditValueChanged(sender As Object, e As EventArgs) Handles T_ShippingAddressType.EditValueChanged

        If T_ShippingAddressType.EditValue = "P" Then

            fc_Class = New Cls_PO
            Dim dt As New DataTable
            dt = fc_Class.Get_ShippingByAddres("TSC1")

            If dt.Rows.Count > 0 Then

                T_ShippingName.EditValue = IIf(dt.Rows(0).Item("Name") Is DBNull.Value, "", dt.Rows(0).Item("Name"))
                T_ShippingAttention.EditValue = IIf(dt.Rows(0).Item("Attn") Is DBNull.Value, "", dt.Rows(0).Item("Attn"))
                T_ShippingAddress1.EditValue = IIf(dt.Rows(0).Item("Addr1") Is DBNull.Value, "", dt.Rows(0).Item("Addr1"))
                T_ShippingAddress2.EditValue = IIf(dt.Rows(0).Item("Addr2") Is DBNull.Value, "", dt.Rows(0).Item("Addr2"))
                T_ShippingCity.EditValue = IIf(dt.Rows(0).Item("City") Is DBNull.Value, "", dt.Rows(0).Item("City"))
                T_ShippingState.EditValue = IIf(dt.Rows(0).Item("State") Is DBNull.Value, "", dt.Rows(0).Item("State"))
                T_ShippingPostalCode.EditValue = IIf(dt.Rows(0).Item("Zip") Is DBNull.Value, "", dt.Rows(0).Item("Zip"))
                T_ShippingCountry.EditValue = IIf(dt.Rows(0).Item("Country") Is DBNull.Value, "", dt.Rows(0).Item("Country"))
                T_ShippingPhone.EditValue = IIf(dt.Rows(0).Item("Phone") Is DBNull.Value, "", dt.Rows(0).Item("Phone"))
                T_ShippingFax.EditValue = IIf(dt.Rows(0).Item("Fax") Is DBNull.Value, "", dt.Rows(0).Item("Fax"))
                T_ShippingEmail.EditValue = ""
                T_ShippingShip.EditValue = ""
                T_ShippingFOB.EditValue = ""
                T_ShippingComfirmto.EditValue = ""

            End If

            T_ShippingSiteId.Enabled = False
            T_ShippingCustomerID.Enabled = False
            T_ShippingCustomerAddress.Enabled = False
            T_ShippingVendorID.Enabled = False
            T_ShippingVendorAddres.Enabled = False
            T_ShippingOtherAddressID.Enabled = False


            T_ShippingSiteId.EditValue = ""
            T_ShippingCustomerID.EditValue = ""
            T_ShippingCustomerAddress.EditValue = ""
            T_ShippingVendorID.EditValue = ""
            T_ShippingVendorAddres.EditValue = ""
            T_ShippingOtherAddressID.EditValue = ""

        Else
            T_ShippingSiteId.EditValue = ""
            T_ShippingCustomerID.EditValue = ""
            T_ShippingCustomerAddress.EditValue = ""
            T_ShippingVendorID.EditValue = ""
            T_ShippingVendorAddres.EditValue = ""
            T_ShippingOtherAddressID.EditValue = ""


            T_ShippingName.EditValue = ""
            T_ShippingAttention.EditValue = ""
            T_ShippingAddress1.EditValue = ""
            T_ShippingAddress2.EditValue = ""
            T_ShippingCity.EditValue = ""
            T_ShippingState.EditValue = ""
            T_ShippingPostalCode.EditValue = ""
            T_ShippingCountry.EditValue = ""
            T_ShippingPhone.EditValue = ""
            T_ShippingFax.EditValue = ""
            T_ShippingEmail.EditValue = ""
            T_ShippingShip.EditValue = ""
            T_ShippingFOB.EditValue = ""
            T_ShippingComfirmto.EditValue = ""

            If T_ShippingAddressType.EditValue = "S" Then

                T_ShippingSiteId.Enabled = True
                T_ShippingCustomerID.Enabled = False
                T_ShippingCustomerAddress.Enabled = False
                T_ShippingVendorID.Enabled = False
                T_ShippingVendorAddres.Enabled = False
                T_ShippingOtherAddressID.Enabled = False

            ElseIf T_ShippingAddressType.EditValue = "C" Then

                T_ShippingSiteId.Enabled = False
                T_ShippingCustomerID.Enabled = True
                T_ShippingCustomerAddress.Enabled = False
                T_ShippingVendorID.Enabled = False
                T_ShippingVendorAddres.Enabled = False
                T_ShippingOtherAddressID.Enabled = False

            ElseIf T_ShippingAddressType.EditValue = "V" Then

                T_ShippingSiteId.Enabled = False
                T_ShippingCustomerID.Enabled = False
                T_ShippingCustomerAddress.Enabled = False
                T_ShippingVendorID.Enabled = True
                T_ShippingVendorAddres.Enabled = False
                T_ShippingOtherAddressID.Enabled = False

            ElseIf T_ShippingAddressType.EditValue = "O" Then

                T_ShippingSiteId.Enabled = False
                T_ShippingCustomerID.Enabled = False
                T_ShippingCustomerAddress.Enabled = False
                T_ShippingVendorID.Enabled = False
                T_ShippingVendorAddres.Enabled = False
                T_ShippingOtherAddressID.Enabled = True

            End If




        End If
    End Sub

    Private Sub T_ShippingAddressType_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T_ShippingAddressType.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub T_ShippingSiteId_MouseClick(sender As Object, e As MouseEventArgs) Handles T_ShippingSiteId.MouseClick



    End Sub

    Private Sub T_ShippingSiteId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T_ShippingSiteId.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub T_ShippingCustomerID_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles T_ShippingCustomerID.ButtonClick

        Try
            fc_Class = New Cls_PO
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = fc_Class.Get_CustomerID()
            ls_Judul = "CUSTOMER ID"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then

                T_ShippingCustomerID.EditValue = lF_SearchData.Values.Item(0).ToString.Trim
                T_ShippingCustomerAddress.Enabled = True
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try


    End Sub

    Private Sub T_ShippingCustomerID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T_ShippingCustomerID.KeyPress

        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If

    End Sub

    Private Sub T_ShippingCustomerAddress_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T_ShippingCustomerAddress.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If

    End Sub

    Private Sub T_ShippingCustomerAddress_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles T_ShippingCustomerAddress.ButtonClick

        Try
            fc_Class = New Cls_PO
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = fc_Class.Get_CustomerAddress(T_ShippingCustomerID.EditValue)
            ls_Judul = "CUSTOMER ADDRESS"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then

                T_ShippingCustomerAddress.EditValue = lF_SearchData.Values.Item(0).ToString.Trim

                T_ShippingName.EditValue = lF_SearchData.Values.Item("Name").ToString.Trim
                T_ShippingAttention.EditValue = lF_SearchData.Values.Item("Attn").ToString.Trim
                T_ShippingAddress1.EditValue = lF_SearchData.Values.Item("Addr1").ToString.Trim
                T_ShippingAddress2.EditValue = lF_SearchData.Values.Item("Addr2").ToString.Trim
                T_ShippingCity.EditValue = lF_SearchData.Values.Item("City").ToString.Trim
                T_ShippingState.EditValue = lF_SearchData.Values.Item("State").ToString.Trim
                T_ShippingPostalCode.EditValue = lF_SearchData.Values.Item("Zip").ToString.Trim
                T_ShippingCountry.EditValue = lF_SearchData.Values.Item("Country").ToString.Trim
                T_ShippingPhone.EditValue = lF_SearchData.Values.Item("Phone").ToString.Trim
                T_ShippingFax.EditValue = lF_SearchData.Values.Item("Fax").ToString.Trim
                T_ShippingEmail.EditValue = ""
                T_ShippingShip.EditValue = ""
                T_ShippingFOB.EditValue = ""
                T_ShippingComfirmto.EditValue = ""

            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try


    End Sub

    Private Sub T_ShippingVendorID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T_ShippingVendorID.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If

    End Sub

    Private Sub T_ShippingVendorAddres_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T_ShippingVendorAddres.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If

    End Sub

    Private Sub T_ShippingOtherAddressID_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T_ShippingOtherAddressID.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0)) Then
            e.Handled = True
        End If

    End Sub

    Private Sub T_ShippingVendorID_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles T_ShippingVendorID.ButtonClick

        Try
            fc_Class = New Cls_PO
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = fc_Class.Get_Vendor()
            ls_Judul = "VENDOR ID"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then

                T_ShippingVendorID.EditValue = lF_SearchData.Values.Item(0).ToString.Trim
                T_ShippingVendorAddres.Enabled = True
            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try


    End Sub

    Private Sub T_ShippingVendorAddres_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles T_ShippingVendorAddres.ButtonClick

        Try
            fc_Class = New Cls_PO
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = fc_Class.Get_VendorAddress(T_ShippingVendorID.EditValue)
            ls_Judul = "VENDOR ADDRESS"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then

                T_ShippingVendorAddres.EditValue = lF_SearchData.Values.Item(0).ToString.Trim

                T_ShippingName.EditValue = lF_SearchData.Values.Item("Name").ToString.Trim
                T_ShippingAttention.EditValue = lF_SearchData.Values.Item("Attn").ToString.Trim
                T_ShippingAddress1.EditValue = lF_SearchData.Values.Item("Addr1").ToString.Trim
                T_ShippingAddress2.EditValue = lF_SearchData.Values.Item("Addr2").ToString.Trim
                T_ShippingCity.EditValue = lF_SearchData.Values.Item("City").ToString.Trim
                T_ShippingState.EditValue = lF_SearchData.Values.Item("State").ToString.Trim
                T_ShippingPostalCode.EditValue = lF_SearchData.Values.Item("Zip").ToString.Trim
                T_ShippingCountry.EditValue = lF_SearchData.Values.Item("Country").ToString.Trim
                T_ShippingPhone.EditValue = lF_SearchData.Values.Item("Phone").ToString.Trim
                T_ShippingFax.EditValue = lF_SearchData.Values.Item("Fax").ToString.Trim
                T_ShippingEmail.EditValue = ""
                T_ShippingShip.EditValue = ""
                T_ShippingFOB.EditValue = ""
                T_ShippingComfirmto.EditValue = ""

            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try


    End Sub

    Private Sub T_ShippingSiteId_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles T_ShippingSiteId.ButtonClick
        Try
            fc_Class = New Cls_PO
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = fc_Class.Get_Site()
            ls_Judul = "SITE"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then

                T_ShippingSiteId.EditValue = lF_SearchData.Values.Item(0).ToString.Trim


                T_ShippingName.EditValue = lF_SearchData.Values.Item("Name").ToString.Trim
                T_ShippingAttention.EditValue = lF_SearchData.Values.Item("Attn").ToString.Trim
                T_ShippingAddress1.EditValue = lF_SearchData.Values.Item("Addr1").ToString.Trim
                T_ShippingAddress2.EditValue = lF_SearchData.Values.Item("Addr2").ToString.Trim
                T_ShippingCity.EditValue = lF_SearchData.Values.Item("City").ToString.Trim
                T_ShippingState.EditValue = lF_SearchData.Values.Item("State").ToString.Trim
                T_ShippingPostalCode.EditValue = lF_SearchData.Values.Item("Zip").ToString.Trim
                T_ShippingCountry.EditValue = lF_SearchData.Values.Item("Country").ToString.Trim
                T_ShippingPhone.EditValue = lF_SearchData.Values.Item("Phone").ToString.Trim
                T_ShippingFax.EditValue = lF_SearchData.Values.Item("Fax").ToString.Trim
                T_ShippingEmail.EditValue = ""
                T_ShippingShip.EditValue = ""
                T_ShippingFOB.EditValue = ""
                T_ShippingComfirmto.EditValue = ""


            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub T_ShippingOtherAddressID_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles T_ShippingOtherAddressID.ButtonClick

        Try
            fc_Class = New Cls_PO
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = fc_Class.Get_Site()
            ls_Judul = "OTHER ADDRESS"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then

                T_ShippingOtherAddressID.EditValue = lF_SearchData.Values.Item(0).ToString.Trim


                T_ShippingName.EditValue = lF_SearchData.Values.Item("Name").ToString.Trim
                T_ShippingAttention.EditValue = lF_SearchData.Values.Item("Attn").ToString.Trim
                T_ShippingAddress1.EditValue = lF_SearchData.Values.Item("Addr1").ToString.Trim
                T_ShippingAddress2.EditValue = lF_SearchData.Values.Item("Addr2").ToString.Trim
                T_ShippingCity.EditValue = lF_SearchData.Values.Item("City").ToString.Trim
                T_ShippingState.EditValue = lF_SearchData.Values.Item("State").ToString.Trim
                T_ShippingPostalCode.EditValue = lF_SearchData.Values.Item("Zip").ToString.Trim
                T_ShippingCountry.EditValue = lF_SearchData.Values.Item("Country").ToString.Trim
                T_ShippingPhone.EditValue = lF_SearchData.Values.Item("Phone").ToString.Trim
                T_ShippingFax.EditValue = lF_SearchData.Values.Item("Fax").ToString.Trim
                T_ShippingEmail.EditValue = ""
                T_ShippingShip.EditValue = ""
                T_ShippingFOB.EditValue = ""
                T_ShippingComfirmto.EditValue = ""


            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Private Sub TextEdit30_EditValueChanged(sender As Object, e As EventArgs) Handles T_VI_Country.EditValueChanged

    End Sub
End Class
