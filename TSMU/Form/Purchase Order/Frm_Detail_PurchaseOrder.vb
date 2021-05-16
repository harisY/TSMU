Imports DevExpress.XtraBars.ToastNotifications
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid
Imports Microsoft.Office.Interop
Imports System.Globalization
'Imports AddinExpress.Outlook.SecurityManager
Imports System.IO
Imports System.Net.Mail
Imports System.Text
Imports DevExpress.LookAndFeel
Imports DevExpress.XtraPrinting
Imports DevExpress.XtraReports.UI
Imports DevExpress.XtraSplashScreen

Public Class Frm_Detail_PurchaseOrder

    Dim fc_Class As New Cls_PO
    Dim fc_Class_Detail As New Cls_PO_Detail
    Dim GridDtl As GridControl
    Dim _Tag As TagModel
    Dim Active_Form As Integer = 0
    Dim PONumber As String = ""
    Dim DtGridBarang As DataTable
    Dim dtBarang As DataTable
    Public IsClosed As Boolean = False
    Dim frmInput As Frm_GetPRDetail

    'Dim Curr_Description As String
    'Dim Curr_Symbol As String


    Dim isUpdate As Boolean = False
    Private Sub Frm_Detail_PurchaseOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Dim a As String = Format(Date.Now, "yyyy").ToString & Format(Date.Now, "MM").ToString

        Call CreateTableBarang()
        Call List_TipePO()
        Call List_Status()
        Call List_AddressType()
        Call List_ReceiptStatus()
        Call List_Certificated()
        Call List_CurryMultiply()
        Call List_RcptAction()
        Call List_GridReceiptStatus()
        Call List_GridVoucherStatus()
        Call List_GridPurchaseFor()

        Call InitialSetForm()

        For i As Integer = 0 To GridView1.RowCount - 1

            'GridView3.GetRowCellValue(i, GridView3.Columns("No")) = i.ToString()

            GridView1.SetRowCellValue(i, "No", i + 1)

        Next

    End Sub

    Private Sub CreateTableBarang()

        DtGridBarang = New DataTable
        DtGridBarang.Columns.AddRange(New DataColumn(30) {New DataColumn("PR No", GetType(String)),
                                                            New DataColumn("PR Line No", GetType(String)),
                                                            New DataColumn("Alternate ID", GetType(String)),
                                                            New DataColumn("No", GetType(Double)),
                                                            New DataColumn("XSeq", GetType(Double)),
                                                            New DataColumn("Inventory ID", GetType(String)),
                                                            New DataColumn("Description", GetType(String)),
                                                            New DataColumn("Quantity", GetType(Double)),
                                                            New DataColumn("OUM", GetType(String)),
                                                            New DataColumn("Unit Cost", GetType(Double)),
                                                            New DataColumn("Extended Cost", GetType(Double)),
                                                            New DataColumn("Status Price", GetType(String)),
                                                            New DataColumn("Unit Weight", GetType(Double)),
                                                            New DataColumn("Site ID", GetType(String)),
                                                            New DataColumn("Extended Weight", GetType(Double)),
                                                            New DataColumn("Purchase For", GetType(String)),
                                                            New DataColumn("Unit Volume", GetType(Double)),
                                                            New DataColumn("Extended Volume", GetType(String)),
                                                            New DataColumn("Required", GetType(Date)),
                                                            New DataColumn("Promised", GetType(Date)),
                                                            New DataColumn("Account", GetType(String)),
                                                            New DataColumn("SubAccount", GetType(String)),
                                                            New DataColumn("Rcpt Qty Min%", GetType(Double)),
                                                            New DataColumn("Rcpt Qty Max%", GetType(Double)),
                                                            New DataColumn("Receipt Action", GetType(String)),
                                                            New DataColumn("Balance", GetType(Double)),
                                                            New DataColumn("PoQty", GetType(Double)),
                                                            New DataColumn("PRQty", GetType(Double)),
                                                            New DataColumn("Receipt Status", GetType(String)),
                                                            New DataColumn("Voucher Status", GetType(String)),
                                                            New DataColumn("Lead Time", GetType(Boolean))})
        GridDetail.DataSource = DtGridBarang
        GridView1.OptionsView.ShowAutoFilterRow = False
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

    Private Sub List_RcptAction()
        Dim cList As New ContactList()
        cList.Add(New Contact("E", "Error & Reject Qty"))
        cList.Add(New Contact("W", "Warn & Accept Qty"))
        cList.Add(New Contact("N", "Accept Qty No Warn"))

        RepoAction.DataSource = cList
        RepoAction.DisplayMember = "Name"
        RepoAction.ValueMember = "Id"
        ' Add columns.
        ' The ID column is populated 
        ' via the GetNotInListValue event (not listed in the example).
        RepoAction.Columns.Add(New LookUpColumnInfo("Id", "ID", 20))
        RepoAction.Columns.Add(New LookUpColumnInfo("Name", "Name", 80))
        'enable text editing
        RepoAction.TextEditStyle = TextEditStyles.Standard
    End Sub

    Private Sub List_GridReceiptStatus()

        Dim cList As New ContactList()
        cList.Add(New Contact("N", "Not Received"))
        cList.Add(New Contact("P", "Partially Received"))
        cList.Add(New Contact("F", "Fully Received"))
        cList.Add(New Contact("X", "No Receipts Expected"))

        RepoRcptStatus.DataSource = cList
        RepoRcptStatus.DisplayMember = "Name"
        RepoRcptStatus.ValueMember = "Id"
        ' Add columns.
        ' The ID column is populated 
        ' via the GetNotInListValue event (not listed in the example).
        RepoRcptStatus.Columns.Add(New LookUpColumnInfo("Id", "ID", 20))
        RepoRcptStatus.Columns.Add(New LookUpColumnInfo("Name", "Name", 80))
        'enable text editing
        RepoRcptStatus.TextEditStyle = TextEditStyles.Standard
    End Sub

    Private Sub List_GridPurchaseFor()

        Dim cList As New ContactList()
        cList.Add(New Contact("DL", "Description Line"))
        cList.Add(New Contact("FR", "Freight Charges"))
        cList.Add(New Contact("GI", "Goods for Inventory"))
        cList.Add(New Contact("GS", "Goods for Sales Order"))
        cList.Add(New Contact("MI", "Misc Charges"))
        cList.Add(New Contact("GN", "Non-Inventory Goods"))
        cList.Add(New Contact("SE", "Services for Expense"))



        RepoPurchaseFor.DataSource = cList
        RepoPurchaseFor.DisplayMember = "Name"
        RepoPurchaseFor.ValueMember = "Id"
        ' Add columns.
        ' The ID column is populated 
        ' via the GetNotInListValue event (not listed in the example).
        RepoPurchaseFor.Columns.Add(New LookUpColumnInfo("Id", "ID", 20))
        RepoPurchaseFor.Columns.Add(New LookUpColumnInfo("Name", "Name", 80))
        'enable text editing
        RepoPurchaseFor.TextEditStyle = TextEditStyles.Standard
    End Sub


    Private Sub List_GridVoucherStatus()

        Dim cList As New ContactList()
        cList.Add(New Contact("N", "Not Received"))
        cList.Add(New Contact("P", "Partially Received"))
        cList.Add(New Contact("F", "Fully Received"))
        cList.Add(New Contact("X", "No Receipts Expected"))

        RepoVoucherStatus.DataSource = cList
        RepoVoucherStatus.DisplayMember = "Name"
        RepoVoucherStatus.ValueMember = "Id"
        ' Add columns.
        ' The ID column is populated 
        ' via the GetNotInListValue event (not listed in the example).
        RepoVoucherStatus.Columns.Add(New LookUpColumnInfo("Id", "ID", 20))
        RepoVoucherStatus.Columns.Add(New LookUpColumnInfo("Name", "Name", 80))
        'enable text editing
        RepoVoucherStatus.TextEditStyle = TextEditStyles.Standard
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

    Private Sub List_ReceiptStatus()
        Dim StatusList As New StatusList()
        StatusList.Add(New Status("N", "Not Received"))
        StatusList.Add(New Status("P", "Partially Received"))
        StatusList.Add(New Status("F", "Fully Received"))
        StatusList.Add(New Status("X", "No Receipts Expected"))
        'bind the lookup editor to the list
        T_Other_ReceiptStatus.Properties.DataSource = StatusList
        T_Other_ReceiptStatus.Properties.DisplayMember = "Name"
        T_Other_ReceiptStatus.Properties.ValueMember = "Id"
        ' Add columns.
        ' The ID column is populated 
        ' via the GetNotInListValue event (not listed in the example).
        T_Other_ReceiptStatus.Properties.Columns.Add(New LookUpColumnInfo("Id", "ID", 20))
        T_Other_ReceiptStatus.Properties.Columns.Add(New LookUpColumnInfo("Name", "Name", 80))
        'enable text editing
        T_Status.Properties.TextEditStyle = TextEditStyles.Standard
    End Sub

    Private Sub List_Certificated()
        Dim StatusList As New StatusList()
        StatusList.Add(New Status("1", "Required"))
        StatusList.Add(New Status("0", "Not Required"))
        'bind the lookup editor to the list
        T_Other_Certificated.Properties.DataSource = StatusList
        T_Other_Certificated.Properties.DisplayMember = "Name"
        T_Other_Certificated.Properties.ValueMember = "Id"
        ' Add columns.
        ' The ID column is populated 
        ' via the GetNotInListValue event (not listed in the example).
        T_Other_Certificated.Properties.Columns.Add(New LookUpColumnInfo("Id", "ID", 20))
        T_Other_Certificated.Properties.Columns.Add(New LookUpColumnInfo("Name", "Name", 80))
        'enable text editing
        T_Other_Certificated.Properties.TextEditStyle = TextEditStyles.Standard
    End Sub

    Private Sub List_CurryMultiply()
        Dim StatusList As New StatusList()
        StatusList.Add(New Status("D", "Divide"))
        StatusList.Add(New Status("M", "Multiply"))
        'bind the lookup editor to the list
        T_Rate_Multiply.Properties.DataSource = StatusList
        T_Rate_Multiply.Properties.DisplayMember = "Name"
        T_Rate_Multiply.Properties.ValueMember = "Id"
        ' Add columns.
        ' The ID column is populated 
        ' via the GetNotInListValue event (not listed in the example).
        T_Rate_Multiply.Properties.Columns.Add(New LookUpColumnInfo("Id", "ID", 20))
        T_Rate_Multiply.Properties.Columns.Add(New LookUpColumnInfo("Name", "Name", 80))
        'enable text editing
        T_Rate_Multiply.Properties.TextEditStyle = TextEditStyles.Standard
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
            isUpdate = True
            Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)
            Call LoadText(fs_Code)
            Call LoadPoDetail(fs_Code)
            T_PONumber.Enabled = False
            T_VendorID.Enabled = False
        Else
            T_POType.EditValue = "OR"
            T_Status.EditValue = "P"
            T_ShippingAddressType.EditValue = "P"
            Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False)

            T_Curr_ID.EditValue = "IDR"
            T_Other_PoDate.EditValue = Date.Now
            T_Other_ReceiptStatus.EditValue = "N"
            T_Other_Certificated.EditValue = "0"
            T_Rate_Multiply.EditValue = "M"

        End If
        Me.Text = "PO DETAIL"
        bb_IsUpdate = isUpdate
        bs_MainFormName = FrmParent.Name.ToString()

    End Sub

    Private Sub LoadPoDetail(PONumber As String)

        Try
            If fs_Code <> "" Then
                Cursor.Current = Cursors.WaitCursor

                'Dim dt As New DataTable
                DtGridBarang = New DataTable
                DtGridBarang = fc_Class.Get_PODetail(PONumber)
                GridDetail.DataSource = DtGridBarang
                Cursor.Current = Cursors.Default

            Else
                'Code
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try


    End Sub

    Private Sub LoadText(PONumber As String)

        Try
            If fs_Code <> "" Then
                Cursor.Current = Cursors.WaitCursor

                Dim dtTExt As New DataTable
                dtTExt = fc_Class.Get_POHeader(PONumber)
                Cursor.Current = Cursors.Default
                If dtTExt.Rows.Count > 0 Then
                    T_VendorID.EditValue = dtTExt.Rows(0).Item("VendID")
                    T_PONumber.EditValue = dtTExt.Rows(0).Item("PONbr")
                    T_POType.EditValue = dtTExt.Rows(0).Item("POType")
                    T_PRNo.EditValue = dtTExt.Rows(0).Item("User1")

                    Dim dtVendorName As New DataTable
                    dtVendorName = fc_Class.Get_POVendorName(dtTExt.Rows(0).Item("VendID"))
                    If dtVendorName.Rows.Count > 0 Then
                        T_VendorName.EditValue = dtVendorName.Rows(0).Item("Name")
                    End If
                    T_Pajak.EditValue = dtTExt.Rows(0).Item("TaxID00")
                    T_ProjectID.EditValue = dtTExt.Rows(0).Item("ProjectID")
                    T_Status.EditValue = dtTExt.Rows(0).Item("Status")
                    T_DiscountAmount.EditValue = dtTExt.Rows(0).Item("User4")
                    T_DiscPersen.EditValue = dtTExt.Rows(0).Item("User3")

                    T_ShippingName.EditValue = dtTExt.Rows(0).Item("ShipName")
                    T_ShippingAttention.EditValue = dtTExt.Rows(0).Item("ShipAttn")
                    T_ShippingAddress1.EditValue = dtTExt.Rows(0).Item("ShipAddr1")
                    T_ShippingAddress2.EditValue = dtTExt.Rows(0).Item("ShipAddr2")
                    T_ShippingCity.EditValue = dtTExt.Rows(0).Item("ShipCity")
                    T_ShippingState.EditValue = dtTExt.Rows(0).Item("ShipState")
                    T_ShippingPostalCode.EditValue = dtTExt.Rows(0).Item("ShipZip")
                    T_ShippingCountry.EditValue = dtTExt.Rows(0).Item("ShipCountry")
                    T_ShippingPhone.EditValue = dtTExt.Rows(0).Item("ShipPhone")
                    T_ShippingFax.EditValue = dtTExt.Rows(0).Item("ShipFax")
                    T_ShippingEmail.EditValue = dtTExt.Rows(0).Item("ShipEmail")
                    T_ShippingShip.EditValue = ""
                    T_ShippingFOB.EditValue = dtTExt.Rows(0).Item("FOB")
                    T_ShippingComfirmto.EditValue = ""

                    T_VI_AddresID.EditValue = dtTExt.Rows(0).Item("VendAddrID")
                    T_VI_Name.EditValue = dtTExt.Rows(0).Item("VendName")
                    T_VI_Attention.EditValue = dtTExt.Rows(0).Item("VendAttn")
                    T_VI_Address1.EditValue = dtTExt.Rows(0).Item("VendAddr1")
                    T_VI_Address2.EditValue = dtTExt.Rows(0).Item("VendAddr2")
                    T_VI_City.EditValue = dtTExt.Rows(0).Item("VendCity")
                    T_VI_State.EditValue = dtTExt.Rows(0).Item("VendState")
                    T_VI_Country.EditValue = dtTExt.Rows(0).Item("VendCountry")
                    T_VI_Phone.EditValue = dtTExt.Rows(0).Item("VendPhone")
                    T_VI_Fax.EditValue = dtTExt.Rows(0).Item("VendFax")
                    T_VI_Email.EditValue = dtTExt.Rows(0).Item("VendEmail")

                    T_Other_PoDate.EditValue = dtTExt.Rows(0).Item("PODate")
                    T_Other_Blanked.EditValue = dtTExt.Rows(0).Item("LastRcptDate")
                    T_Other_ReceiptStatus.EditValue = dtTExt.Rows(0).Item("RcptStage")
                    'T_Other_LastReceived.EditValue = dtTExt.Rows(0).Item("")
                    T_Other_PeriodClosed.EditValue = dtTExt.Rows(0).Item("PerClosed")
                    'T_Other_Certificated.EditValue = dtTExt.Rows(0).Item("")
                    T_Other_Term.EditValue = dtTExt.Rows(0).Item("Terms")
                    T_Other_Buyer.EditValue = dtTExt.Rows(0).Item("Buyer")

                    Dim a As String = Trim(dtTExt.Rows(0).Item("CuryID"))
                    T_Curr_ID.EditValue = a
                    T_Rate_Multiply.EditValue = Trim(dtTExt.Rows(0).Item("CuryMultDiv"))


                End If
                'Call TotalSumary()
            Else
                'Code
            End If

        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try


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

            GridView1.PostEditor()
            GridView1.UpdateCurrentRow()

            Dim a As Integer = 1
            Dim b As Integer = 0


            fc_Class = New Cls_PO
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            Dim PR As String = ""
            Dim Invt As String = ""
            Dim Seq As String = ""
            'Dim dtcekharga As DataTable
            Dim harga As Double
            harga = 0

            Dim Cek As Boolean = False

            dtBarang = New DataTable


            dtSearch = fc_Class.Get_PR()
            ls_Judul = "PR"
            ls_OldKode = ""


            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()

            CallForm(lF_SearchData.Values.Item(0).ToString.Trim)
            T_PRNo.EditValue = lF_SearchData.Values.Item(0).ToString.Trim

            'If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then
            '    T_PRNo.EditValue = lF_SearchData.Values.Item(0).ToString.Trim

            '    dtBarang = fc_Class.Get_PRDetail(lF_SearchData.Values.Item(0).ToString.Trim)

            '    If dtBarang.Rows.Count > 0 Then
            '        For i As Integer = 0 To dtBarang.Rows.Count - 1
            '            Cek = False
            '            PR = Trim(dtBarang.Rows(i).Item("PRNo"))
            '            Invt = Trim(dtBarang.Rows(i).Item("InvtId"))
            '            Seq = Trim(dtBarang.Rows(i).Item("XSeqNo"))


            '            dtcekharga = New DataTable
            '            dtcekharga = fc_Class.Get_CekHarga(Invt, 1)

            '            If dtcekharga.Rows(0).Item("Tipe") = "F" Then

            '                If dtcekharga.Rows(0).Item("LastCost") > 0 Then
            '                    harga = dtcekharga.Rows(0).Item("LastCost")
            '                Else
            '                    harga = dtBarang.Rows(i).Item("UnitPrice")
            '                End If

            '            Else
            '                dtcekharga = New DataTable
            '                dtcekharga = fc_Class.Get_CekHarga(Invt, 2)

            '                If dtcekharga.Rows.Count > 0 Then
            '                    If dtcekharga.Rows(0).Item("UnitCost") > 0 Then
            '                        harga = dtcekharga.Rows(0).Item("UnitCost")
            '                    Else
            '                        harga = dtBarang.Rows(i).Item("UnitPrice")
            '                    End If
            '                Else
            '                    harga = dtBarang.Rows(i).Item("UnitPrice")
            '                End If
            '            End If


            '            If GridView1.RowCount = 0 Then

            '                a = a + GridView1.RowCount
            '                b = GridView1.Columns("XSeq").SummaryItem.SummaryValue
            '                b = b + 1

            '                GridView1.AddNewRow()
            '                GridView1.Focus()
            '                'GridView1.OptionsNavigation.AutoFocusNewRow = True
            '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, No, a)
            '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, XSeq, b)
            '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, PRNo, dtBarang.Rows(i).Item("PRNo"))
            '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, InventoryID, dtBarang.Rows(i).Item("InvtId"))
            '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Description, dtBarang.Rows(i).Item("InvtDescr"))
            '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, PRLineNo, dtBarang.Rows(i).Item("XSeqNo"))
            '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Quantity, dtBarang.Rows(i).Item("Qty") - dtBarang.Rows(i).Item("PoQty"))
            '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Balance, dtBarang.Rows(i).Item("Qty") - dtBarang.Rows(i).Item("PoQty"))
            '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, PoQty, dtBarang.Rows(i).Item("PoQty"))
            '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, UnitCost, harga)
            '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, OUM, dtBarang.Rows(i).Item("UnitQty"))
            '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, PRQty, dtBarang.Rows(i).Item("Qty"))
            '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ExtendedCost, (dtBarang.Rows(i).Item("Qty") - dtBarang.Rows(i).Item("PoQty")) * harga)
            '                'GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ExtendedCost, dtBarang.Rows(i).Item("Qty") * harga)                           'GridView1.SetRowCellValue(GridView1.FocusedRowHandle, StatusPrice, )
            '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, UnitWeight, 0)
            '                'GridView1.SetRowCellValue(GridView1.FocusedRowHandle, SiteID, dtBarang.Rows(i).Item("XSeqNo"))
            '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ExtentedWeight, 0)
            '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, PurchaseFor, dtBarang.Rows(i).Item("PurchaseType"))
            '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, UnitVolume, 0)
            '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Required, dtBarang.Rows(i).Item("DelDate"))
            '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Promised, dtBarang.Rows(i).Item("DelDate"))
            '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Account, dtBarang.Rows(i).Item("Acct"))
            '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, SubAccount, dtBarang.Rows(i).Item("Sub"))
            '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, RcptQtyMax, 100)
            '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, RcptQtyMin, 0)
            '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ReceiptAction, "E")
            '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ReceiptStatus, "N")
            '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, VoucherStatus, "N")
            '                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, IncludeInLeadTimeCalc, 0)

            '            Else


            '                'dtcekharga = New DataTable
            '                'dtcekharga = fc_Class.Get_CekHarga(Invt, 1)
            '                'harga = dtBarang.Rows(0).Item("UnitPrice")

            '                'If dtcekharga.Rows(0).Item("Tipe") = "F" Then
            '                '    harga = dtcekharga.Rows(0).Item("LastCost")
            '                'Else
            '                '    dtcekharga = New DataTable
            '                '    dtcekharga = fc_Class.Get_CekHarga(Invt, 2)
            '                '    If dtcekharga.Rows.Count > 0 Then
            '                '        harga = dtcekharga.Rows(0).Item("UnitCost")
            '                '    Else
            '                '        harga = 0
            '                '    End If
            '                'End If


            '                Dim GvPR As String = ""
            '                Dim GvInvt As String = ""
            '                Dim GvSeq As String = ""

            '                For j As Integer = 0 To GridView1.RowCount - 1



            '                    GridView1.PostEditor()
            '                    GridView1.UpdateCurrentRow()

            '                    GvPR = Trim(GridView1.GetRowCellValue(b, GridView1.Columns("PR No")))
            '                    GvInvt = Trim(Convert.ToString(GridView1.GetRowCellValue(j, GridView1.Columns("Inventory ID")).ToString()))
            '                    GvSeq = Trim(Convert.ToString(GridView1.GetRowCellValue(j, GridView1.Columns("PR Line No")).ToString))

            '                    If (PR = GvPR) And (Invt = GvInvt) And (Seq = GvSeq) Then
            '                        Cek = Cek Or True
            '                    End If

            '                Next

            '                If Cek = False Then
            '                    a = 1
            '                    a = a + GridView1.RowCount
            '                    b = GridView1.Columns("XSeq").SummaryItem.SummaryValue
            '                    b = b + 1

            '                    GridView1.AddNewRow()
            '                    GridView1.Focus()
            '                    'GridView1.OptionsNavigation.AutoFocusNewRow = True
            '                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, No, a)
            '                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, XSeq, b)

            '                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, PRNo, dtBarang.Rows(i).Item("PRNo"))
            '                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, InventoryID, dtBarang.Rows(i).Item("InvtId"))
            '                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Description, dtBarang.Rows(i).Item("InvtDescr"))
            '                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, PRLineNo, dtBarang.Rows(i).Item("XSeqNo"))
            '                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Quantity, dtBarang.Rows(i).Item("Qty") - dtBarang.Rows(i).Item("PoQty"))
            '                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Balance, dtBarang.Rows(i).Item("Qty") - dtBarang.Rows(i).Item("PoQty"))
            '                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, PoQty, dtBarang.Rows(i).Item("PoQty"))
            '                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, OUM, dtBarang.Rows(i).Item("UnitQty"))
            '                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, PRQty, dtBarang.Rows(i).Item("Qty"))

            '                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, UnitCost, harga)

            '                    'GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ExtendedCost, dtBarang.Rows(i).Item("Qty") * harga)
            '                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ExtendedCost, (dtBarang.Rows(i).Item("Qty") - dtBarang.Rows(i).Item("PoQty")) * harga)
            '                    'GridView1.SetRowCellValue(GridView1.FocusedRowHandle, StatusPrice, )
            '                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, UnitWeight, 0)
            '                    'GridView1.SetRowCellValue(GridView1.FocusedRowHandle, SiteID, dtBarang.Rows(i).Item("XSeqNo"))
            '                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ExtentedWeight, 0)
            '                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, PurchaseFor, dtBarang.Rows(i).Item("PurchaseType"))
            '                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, UnitVolume, 0)
            '                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Required, dtBarang.Rows(i).Item("DelDate"))
            '                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Promised, dtBarang.Rows(i).Item("DelDate"))
            '                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, Account, dtBarang.Rows(i).Item("Acct"))
            '                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, SubAccount, dtBarang.Rows(i).Item("Sub"))
            '                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, RcptQtyMax, 100)
            '                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, RcptQtyMin, 0)
            '                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ReceiptAction, "E")
            '                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, ReceiptStatus, "N")
            '                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, VoucherStatus, "N")
            '                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, IncludeInLeadTimeCalc, 0)

            '                End If




            '            End If





            '        Next


            '        'Dim cells() As GridCell = GridView1.GetSelectedCells()
            '        'Dim values As New List(Of Decimal)()
            '        'For i As Integer = 0 To GridView1.RowCount - 2
            '        '    Dim value As Decimal = Convert.ToDecimal(GridView1.GetRowCellValue(cells(i).RowHandle, cells(i).Column))
            '        '    values.Add(value)
            '        'Next i
            '        'values.Sort()

            '        'Dim highestValue = GridView1.Rows.OfType(Of DataGridViewRow).Max(Function(row) Convert.ToInt32(row.Cells("sal").Value))

            '    End If


            'End If
            'lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Sub CallForm(Optional ByVal ID As String = "",
                        Optional ByVal IsNew As Boolean = True)

        frmInput = New Frm_GetPRDetail(ID, DtGridBarang, GridDetail, IsNew)
        frmInput.StartPosition = FormStartPosition.CenterScreen
        frmInput.MaximizeBox = False
        frmInput.ShowDialog()


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

    Private Sub T_PRNo_EditValueChanged(sender As Object, e As EventArgs) Handles T_PRNo.EditValueChanged

    End Sub

    Private Sub GridDetail_KeyDown(sender As Object, e As KeyEventArgs) Handles GridDetail.KeyDown

        If e.KeyData = Keys.Delete Then
            GridView1.DeleteRow(GridView1.FocusedRowHandle)
            GridView1.UpdateCurrentRow()
            GridView1.RefreshData()
        End If

        For i As Integer = 0 To GridView1.RowCount - 1

            'GridView3.GetRowCellValue(i, GridView3.Columns("No")) = i.ToString()

            GridView1.SetRowCellValue(i, No, i + 1)

        Next

        GridView1.PostEditor()
        GridView1.UpdateCurrentRow()
        GridDetail.Refresh()

    End Sub

    Public Overrides Sub Proc_SaveData()

        Try
            getdataview1()
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub
    Public Overrides Function ValidateSave() As Boolean

        Dim lb_Validated As Boolean = False
        Try
            If T_PONumber.EditValue = "" Then
                MessageBox.Show("Please Check PO Number",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf T_VendorID.EditValue = "" Then
                MessageBox.Show("Please Check Vendor ID",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf T_Pajak.EditValue = "" Then
                MessageBox.Show("Please Check Pajak",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf T_POType.EditValue = "" Then
                MessageBox.Show("Please Check PO Type",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf T_PRNo.EditValue = "" Then
                MessageBox.Show("Please Check PR No",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf T_PRNo.EditValue = "" Then
                MessageBox.Show("Please Check PR No",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            ElseIf T_Status.EditValue = "" Then
                MessageBox.Show("Please Check PR No",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
                'ElseIf T_DiscountAmount.EditValue = "" Then
                '    MessageBox.Show("Please Check Disc (Amt)",
                '                   "Warning",
                '                   MessageBoxButtons.OK,
                '                   MessageBoxIcon.Exclamation,
                '                   MessageBoxDefaultButton.Button1)
                'ElseIf T_DiscPersen.EditValue = "" Then
                '    MessageBox.Show("Please Check Disc (%)",
                '                   "Warning",
                '                   MessageBoxButtons.OK,
                '                   MessageBoxIcon.Exclamation,
                '                   MessageBoxDefaultButton.Button1)


            Else
                lb_Validated = True
            End If

            If lb_Validated Then

                If isUpdate = False Then
                    fc_Class.H_PONbr = T_PONumber.EditValue
                    fc_Class.ValidateInsert()
                Else
                    '.ValidateUpdate()
                End If

            End If
        Catch ex As Exception
            lb_Validated = False
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
        Return lb_Validated
    End Function


    Private Sub getdataview1()

        Dim IsEmpty As Boolean = False

        If GridView1.RowCount = 0 Then

            MessageBox.Show("Check Item PO ", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
            Exit Sub

        Else

            For i As Integer = 0 To GridView1.RowCount - 1
                GridView1.MoveFirst()
                GridView1.PostEditor()
                GridView1.UpdateCurrentRow()

                Dim AlternateManual As String = IIf(GridView1.GetRowCellValue(i, GridView1.Columns("Alternate ID")) Is DBNull.Value, "", GridView1.GetRowCellValue(i, GridView1.Columns("Alternate ID")))
                Dim Quantity As String = IIf(GridView1.GetRowCellValue(i, GridView1.Columns("Quantity")) Is DBNull.Value, "", GridView1.GetRowCellValue(i, GridView1.Columns("Quantity")))
                Dim UnitCost As String = IIf(GridView1.GetRowCellValue(i, GridView1.Columns("Unit Cost")) Is DBNull.Value, "", GridView1.GetRowCellValue(i, GridView1.Columns("Unit Cost")))
                Dim SiteID As String = IIf(GridView1.GetRowCellValue(i, GridView1.Columns("Site ID")) Is DBNull.Value, "", GridView1.GetRowCellValue(i, GridView1.Columns("Site ID")))
                Dim Required As String = IIf(GridView1.GetRowCellValue(i, GridView1.Columns("Required")) Is DBNull.Value, "", GridView1.GetRowCellValue(i, GridView1.Columns("Required")))
                Dim Promised As String = IIf(GridView1.GetRowCellValue(i, GridView1.Columns("Promised")) Is DBNull.Value, "", GridView1.GetRowCellValue(i, GridView1.Columns("Promised")))
                Dim RcptQtyMin As String = IIf(GridView1.GetRowCellValue(i, GridView1.Columns("Rcpt Qty Min%")) Is DBNull.Value, "", GridView1.GetRowCellValue(i, GridView1.Columns("Rcpt Qty Min%")))
                Dim RcptQtyMax As String = IIf(GridView1.GetRowCellValue(i, GridView1.Columns("Rcpt Qty Max%")) Is DBNull.Value, "", GridView1.GetRowCellValue(i, GridView1.Columns("Rcpt Qty Max%")))
                Dim ReceiptAction As String = IIf(GridView1.GetRowCellValue(i, GridView1.Columns("Receipt Action")) Is DBNull.Value, "", GridView1.GetRowCellValue(i, GridView1.Columns("Receipt Action")))
                Dim ReceiptStatus As String = IIf(GridView1.GetRowCellValue(i, GridView1.Columns("Receipt Status")) Is DBNull.Value, "", GridView1.GetRowCellValue(i, GridView1.Columns("Receipt Status")))


                If AlternateManual = "" Then
                    IsEmpty = True
                    MessageBox.Show("Cek Kolom AlternateManual Untuk Baris Ke " & i + 1 & " ", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                    Exit Sub
                ElseIf Quantity = "" Then
                    IsEmpty = True
                    MessageBox.Show("Cek Kolom Quantity Untuk Baris Ke " & i + 1 & " ", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                    Exit Sub

                ElseIf UnitCost = "" Then
                    IsEmpty = True
                    MessageBox.Show("Cek Kolom UnitCost Untuk Baris Ke " & i + 1 & " ", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                    Exit Sub
                ElseIf SiteID = "" Then
                    IsEmpty = True
                    MessageBox.Show("Cek Kolom Site ID Untuk Baris Ke " & i + 1 & " ", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                    Exit Sub
                ElseIf Required = "" Then
                    IsEmpty = True
                    MessageBox.Show("Cek Kolom Required Untuk Baris Ke " & i + 1 & " ", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                    Exit Sub

                ElseIf Promised = "" Then
                    IsEmpty = True
                    MessageBox.Show("Cek Kolom Promised Untuk Baris Ke " & i + 1 & " ", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                    Exit Sub

                ElseIf RcptQtyMin = "" Then
                    IsEmpty = True
                    MessageBox.Show("Cek Kolom RcptQtyMin Untuk Baris Ke " & i + 1 & " ", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                    Exit Sub

                ElseIf RcptQtyMax = "" Then
                    IsEmpty = True
                    MessageBox.Show("Cek Kolom RcptQtyMax Untuk Baris Ke " & i + 1 & " ", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                    Exit Sub

                ElseIf ReceiptAction = "" Then
                    IsEmpty = True
                    MessageBox.Show("Cek Kolom ReceiptAction Untuk Baris Ke " & i + 1 & " ", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                    Exit Sub

                ElseIf ReceiptStatus = "" Then
                    IsEmpty = True
                    MessageBox.Show("Cek Kolom ReceiptStatus Untuk Baris Ke " & i + 1 & " ", "Warning",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation,
                            MessageBoxDefaultButton.Button1)
                    Exit Sub

                End If
            Next

        End If


        With fc_Class

            fc_Class.H_PONbr = T_PONumber.EditValue
            fc_Class.H_CpnyID = "TSMU"
            fc_Class.H_Crtd_DateTime = Date.Now
            fc_Class.H_Crtd_Prog = "04250"
            fc_Class.H_Crtd_User = gh_Common.Username
            fc_Class.H_CurrentNbr = 0
            fc_Class.H_CuryEffDate = Date.Now
            fc_Class.H_CuryFreight = 0
            fc_Class.H_CuryID = T_Curr_ID.EditValue
            fc_Class.H_CuryMultDiv = T_Rate_Multiply.EditValue
            fc_Class.H_CuryPOAmt = 0
            fc_Class.H_CuryRate = T_Rate.EditValue
            fc_Class.H_CuryRateType = T_Rate_Type.EditValue
            fc_Class.H_CuryRcptTotAmt = 0
            fc_Class.H_LineCntr = 0
            fc_Class.H_LUpd_DateTime = Date.Now
            fc_Class.H_LUpd_Prog = "04250"
            fc_Class.H_LUpd_User = gh_Common.Username
            fc_Class.H_NoteID = 0
            fc_Class.H_PerClosed = "0"
            fc_Class.H_PerEnt = Format(Date.Now, "yyyy").ToString & Format(Date.Now, "MM").ToString
            fc_Class.H_POType = T_POType.EditValue
            fc_Class.H_ProjectID = T_ProjectID.EditValue
            fc_Class.H_RcptStage = "N"
            fc_Class.H_VouchStage = "N"
            fc_Class.H_Terms = T_Other_Term.EditValue
            fc_Class.H_User1 = T_PRNo.EditValue
            fc_Class.H_Status = T_Status.EditValue
            fc_Class.H_POAmt = GridView1.Columns("Extended Cost").SummaryItem.SummaryValue
            fc_Class.H_CuryPOAmt = GridView1.Columns("Extended Cost").SummaryItem.SummaryValue * T_Rate.EditValue



            fc_Class.H_ShipAddr1 = T_ShippingAddress1.EditValue
            fc_Class.H_ShipAddr2 = T_ShippingAddress2.EditValue
            Dim ShippingID As String = ""
            ShippingID = T_ShippingSiteId.EditValue

            If ShippingID = "" Then
                fc_Class.H_ShipAddrID = "TSC1"

            Else
                fc_Class.H_ShipAddrID = ShippingID.Substring(0, 3)
            End If

            fc_Class.H_ShipAttn = T_ShippingAttention.EditValue
            fc_Class.H_ShipCity = T_ShippingCity.EditValue
            fc_Class.H_ShipCountry = T_ShippingCountry.EditValue
            fc_Class.H_ShipCustID = T_ShippingCustomerID.EditValue
            fc_Class.H_ShipEmail = T_ShippingEmail.EditValue
            fc_Class.H_ShipFax = T_ShippingFax.EditValue
            fc_Class.H_ShipName = T_ShippingName.EditValue
            fc_Class.H_ShipPhone = T_ShippingPhone.EditValue
            fc_Class.H_ShipSiteID = T_ShippingSiteId.EditValue
            fc_Class.H_ShipState = T_ShippingState.EditValue
            fc_Class.H_ShipZip = T_ShippingPostalCode.EditValue
            fc_Class.H_TaxID00 = T_Pajak.EditValue


            fc_Class.H_VendAddr1 = T_VI_Address1.EditValue
            fc_Class.H_VendAddr2 = T_VI_Address2.EditValue
            fc_Class.H_VendAddrID = T_VI_AddresID.EditValue
            fc_Class.H_VendAttn = T_VI_Attention.EditValue
            fc_Class.H_VendCity = T_VI_City.EditValue
            fc_Class.H_VendCountry = T_VI_Country.EditValue
            fc_Class.H_VendEmail = T_VI_Email.EditValue
            fc_Class.H_VendFax = T_VI_Fax.EditValue
            fc_Class.H_VendID = T_VendorID.EditValue
            fc_Class.H_VendName = T_VendorName.EditValue
            fc_Class.H_VendPhone = T_VI_Phone.EditValue
            fc_Class.H_VendState = T_VI_State.EditValue
            fc_Class.H_VendZip = T_VI_Postal.EditValue
            fc_Class.H_PODate = T_Other_PoDate.EditValue
            fc_Class.H_User4 = IIf(T_DiscountAmount.EditValue Is Nothing, 0, T_DiscountAmount.EditValue)
            fc_Class.H_User3 = IIf(T_DiscPersen.EditValue Is Nothing, 0, T_DiscPersen.EditValue)
            fc_Class.H_User2 = "Circulation"

        End With

        'Insert To Detail
        Dim DtTax As DataTable
        Dim LineReff As String

        fc_Class.Collection_Detail.Clear()
        For i As Integer = 0 To GridView1.RowCount - 1

            'Call Get_LastPR(GridView1.GetRowCellValue(i, "Account"))

            fc_Class_Detail = New Cls_PO_Detail
            With fc_Class_Detail


                .D_AddlCostPct = 0
                .D_AllocCntr = 0
                .D_AlternateID = IIf(GridView1.GetRowCellValue(i, "Alternate ID") Is DBNull.Value, "", GridView1.GetRowCellValue(i, "Alternate ID"))
                .D_AltIDType = ""
                .D_BlktLineID = 0
                .D_BlktLineRef = ""
                .D_Buyer = ""
                .D_CnvFact = 1
                .D_CostReceived = 0
                .D_CostReturned = 0
                .D_CostVouched = 0
                .D_CpnyID = "TSMU"
                .D_Crtd_DateTime = Date.Now
                .D_Crtd_Prog = "04250"
                .D_Crtd_User = gh_Common.Username
                .D_CuryCostReceived = 0
                .D_CuryCostReturned = 0
                .D_CuryCostVouched = 0
                .D_CuryExtCost = T_Rate.EditValue * GridView1.GetRowCellValue(i, "Quantity") * GridView1.GetRowCellValue(i, "Unit Cost")
                .D_CuryID = T_Curr_ID.EditValue
                .D_CuryMultDiv = T_Rate_Multiply.EditValue
                .D_CuryRate = T_Rate.EditValue
                .D_CuryTaxAmt00 = 0
                .D_CuryTaxAmt01 = 0
                .D_CuryTaxAmt02 = 0
                .D_CuryTaxAmt03 = 0
                .D_CuryTxblAmt00 = 0
                .D_CuryTxblAmt01 = 0
                .D_CuryTxblAmt02 = 0
                .D_CuryTxblAmt03 = 0
                .D_CuryUnitCost = GridView1.GetRowCellValue(i, "Unit Cost")
                .D_ExtCost = GridView1.GetRowCellValue(i, "Quantity") * GridView1.GetRowCellValue(i, "Unit Cost")
                .D_ExtWeight = 0
                .D_FlatRateLineNbr = 0
                .D_InclForecastUsageClc = 0
                .D_InvtID = GridView1.GetRowCellValue(i, "Inventory ID")
                .D_IRIncLeadTime = Convert.ToInt16(GridView1.GetRowCellValue(i, "Lead Time"))
                .D_KitUnExpld = 0
                .D_Labor_Class_Cd = ""
                .D_LineID = GridView1.GetRowCellValue(i, "XSeq")
                .D_LineNbr = 0

                LineReff = GridView1.GetRowCellValue(i, "XSeq")

                If Len(LineReff) = 1 Then
                    .D_LineRef = "0000" & GridView1.GetRowCellValue(i, "XSeq")
                ElseIf Len(LineReff) = 2 Then
                    .D_LineRef = "000" & GridView1.GetRowCellValue(i, "XSeq")
                ElseIf Len(LineReff) = 3 Then
                    .D_LineRef = "00" & GridView1.GetRowCellValue(i, "XSeq")
                ElseIf Len(LineReff) = 4 Then
                    .D_LineRef = "0" & GridView1.GetRowCellValue(i, "XSeq")
                Else
                    .D_LineRef = GridView1.GetRowCellValue(i, "XSeq")
                End If


                .D_LUpd_DateTime = Date.Now
                .D_LUpd_Prog = "03400"
                .D_LUpd_User = gh_Common.Username
                .D_NoteID = 0
                .D_OpenLine = 1
                .D_OrigPOLine = 1
                .D_PC_Flag = "Y"
                .D_PC_ID = ""
                .D_PC_Status = "0"
                .D_PONbr = T_PONumber.EditValue
                .D_POType = T_POType.EditValue
                .D_ProjectID = T_ProjectID.EditValue
                .D_PromDate = GridView1.GetRowCellValue(i, "Promised")
                .D_PurAcct = GridView1.GetRowCellValue(i, "Account")
                .D_PurchaseType = GridView1.GetRowCellValue(i, "Purchase For")
                .D_PurchUnit = GridView1.GetRowCellValue(i, "OUM")
                .D_PurSub = GridView1.GetRowCellValue(i, "SubAccount")
                .D_QtyOrd = GridView1.GetRowCellValue(i, "Quantity")
                .D_QtyRcvd = 0
                .D_QtyReturned = 0
                .D_QtyVouched = 0
                .D_RcptPctAct = GridView1.GetRowCellValue(i, "Receipt Action")
                .D_RcptPctMax = GridView1.GetRowCellValue(i, "Rcpt Qty Max%")
                .D_RcptPctMin = GridView1.GetRowCellValue(i, "Rcpt Qty Min%")
                .D_RcptStage = GridView1.GetRowCellValue(i, "Receipt Status")
                .D_ReasonCd = ""
                .D_ReqdDate = GridView1.GetRowCellValue(i, "Required")
                .D_ReqNbr = ""  'Harus Ditanyain
                .D_S4Future01 = ""
                .D_S4Future02 = ""
                .D_S4Future03 = 0
                .D_S4Future04 = 0
                .D_S4Future05 = 0
                .D_S4Future06 = 0
                .D_S4Future07 = "01-01-1990"
                .D_S4Future08 = "01-01-1990"
                .D_S4Future09 = 0
                .D_S4Future10 = 0
                .D_S4Future11 = ""
                .D_S4Future12 = ""
                .D_ServiceCallID = ""
                .D_ShelfLife = 0
                .D_ShipAddr1 = ""
                .D_ShipAddr2 = ""
                .D_ShipAddrID = ""
                .D_ShipCity = ""
                .D_ShipCountry = ""
                .D_ShipName = ""
                .D_ShipState = ""
                .D_ShipViaID = ""
                .D_ShipZip = ""
                .D_SiteID = GridView1.GetRowCellValue(i, "Site ID")
                .D_SOLineRef = ""
                .D_SOOrdNbr = ""
                .D_SOSchedRef = ""
                .D_StepNbr = 0
                .D_SvcContractID = ""
                .D_SvcLineNbr = 0
                .D_TaskID = 0
                .D_TaxAmt00 = 0
                .D_TaxAmt01 = 0
                .D_TaxAmt02 = 0
                .D_TaxAmt03 = 0
                .D_TaxCalced = 0


                DtTax = New DataTable
                DtTax = fc_Class.Get_TAX(GridView1.GetRowCellValue(i, "Inventory ID"))

                If DtTax.Rows.Count > 0 Then
                    .D_TaxCat = DtTax.Rows(0).Item("TaxCat")
                Else
                    .D_TaxCat = ""
                End If

                .D_TaxCat = ""  ' Harus Ditanyain ditentukan berdasarkan apa?
                .D_TaxID00 = T_Pajak.EditValue
                .D_TaxID01 = ""
                .D_TaxID02 = ""
                .D_TaxID03 = ""
                .D_TaxIdDflt = ""
                .D_TranDesc = GridView1.GetRowCellValue(i, "Description")
                '.D_tstamp
                .D_TxblAmt00 = 0
                .D_TxblAmt01 = 0
                .D_TxblAmt02 = 0
                .D_TxblAmt03 = 0
                .D_UnitCost = GridView1.GetRowCellValue(i, "Unit Cost") * T_Rate.EditValue
                .D_UnitMultDiv = T_Rate_Multiply.EditValue
                .D_UnitWeight = 0
                .D_User1 = GridView1.GetRowCellValue(i, "PR No")
                .D_User2 = GridView1.GetRowCellValue(i, "Alternate ID")
                .D_User3 = GridView1.GetRowCellValue(i, "Unit Cost")
                .D_User4 = GridView1.GetRowCellValue(i, "PRQty")
                .D_User5 = GridView1.GetRowCellValue(i, "PR Line No") 'XSet
                .D_User6 = GridView1.GetRowCellValue(i, "XSeq")
                .D_User7 = "01-01-1990"
                .D_User8 = "01-01-1990"
                .D_VouchStage = GridView1.GetRowCellValue(i, "Voucher Status")
                .D_WOBOMSeq = 0
                .D_WOCostType = ""
                .D_WONbr = ""
                .D_WOStepNbr = 0


            End With
            fc_Class.Collection_Detail.Add(fc_Class_Detail)

        Next



        If isUpdate = False Then

            fc_Class.Insert()

        Else

            fc_Class.Update(fs_Code)

        End If

        GridDtl.DataSource = fc_Class.Get_POHeader()
        IsClosed = True
        Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
        Me.Hide()

    End Sub

    Private Sub T_Pajak_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles T_Pajak.ButtonClick

        Try
            fc_Class = New Cls_PO
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = fc_Class.Get_Pajak()
            ls_Judul = "PAJAK"
            ls_OldKode = ""

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then

                T_Pajak.EditValue = lF_SearchData.Values.Item(0).ToString.Trim


            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Private Sub T_Pajak_KeyPress(sender As Object, e As KeyPressEventArgs) Handles T_Pajak.KeyPress

        Dim tombol As Integer
        tombol = Asc(e.KeyChar)

        If Not ((tombol = 0) Or (tombol = 8)) Then
            e.Handled = True
        End If
        T_Pajak.SelectAll()

    End Sub

    Private Sub T_Pajak_Click(sender As Object, e As EventArgs) Handles T_Pajak.Click
        T_Pajak.SelectAll()
    End Sub

    Private Sub T_Curr_ID_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles T_Curr_ID.ButtonClick
        Try
            fc_Class = New Cls_PO
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = fc_Class.Get_MataUang()
            ls_Judul = "CURRENCY"
            ls_OldKode = ""

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then

                T_Curr_Description.EditValue = lF_SearchData.Values.Item(1).ToString.Trim
                T_Curr_Symbol.EditValue = lF_SearchData.Values.Item(2).ToString.Trim
                TabPage5.Text = "Currency " & lF_SearchData.Values.Item(2).ToString.Trim
                T_Curr_ID.EditValue = lF_SearchData.Values.Item(0).ToString.Trim



            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Private Sub T_Curr_ID_EditValueChanged(sender As Object, e As EventArgs) Handles T_Curr_ID.EditValueChanged


        If T_Curr_ID.EditValue = "IDR" Then
            T_Rate_BaseID.EditValue = "IDR"
            T_Rate_Type.EditValue = "BIMID"
            T_Rate_EfektifDate.EditValue = Date.Now
            T_Rate_Multiply.EditValue = "Multiply"
            T_Rate.EditValue = 1
            T_Rate_Reciprocal.EditValue = 1

            T_Curr_Symbol.EditValue = "Rp"
            TabPage5.Text = "Currency Rp"
            T_Curr_Description.EditValue = "INDONESIAN RUPIAH"

        Else
            fc_Class = New Cls_PO
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""
            dtSearch = fc_Class.Get_Rate(T_Curr_ID.EditValue, Date.Now)

            If dtSearch.Rows.Count > 0 Then
                T_Rate_BaseID.EditValue = dtSearch.Rows(0).Item("FromCuryId")
                T_Rate_Type.EditValue = dtSearch.Rows(0).Item("RateType")
                T_Rate_EfektifDate.EditValue = dtSearch.Rows(0).Item("EffDate")
                T_Rate_Multiply.EditValue = dtSearch.Rows(0).Item("MultDiv")
                T_Rate.EditValue = dtSearch.Rows(0).Item("Rate")
                T_Rate_Reciprocal.EditValue = dtSearch.Rows(0).Item("RateReciprocal")
            Else
                MessageBox.Show("Rate Not Set",
                                "Warning",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Exclamation,
                                MessageBoxDefaultButton.Button1)

                T_Curr_ID.EditValue = "IDR"
                T_Rate_BaseID.EditValue = "IDR"
                T_Rate_Type.EditValue = "BIMID"
                T_Rate_EfektifDate.EditValue = Date.Now
                T_Rate_Multiply.EditValue = "Multiply"
                T_Rate.EditValue = 1
                T_Rate_Reciprocal.EditValue = 1

                T_Curr_Symbol.EditValue = "Rp"
                T_Curr_Description.EditValue = "INDONESIAN RUPIAH"
            End If


        End If


    End Sub



    Private Sub RepoAlternate_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles RepoAlternate.ButtonClick

        Try

            If T_VendorID.EditValue = "" Then

                MessageBox.Show("Please Select Vendor ID",
                               "Warning",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation,
                               MessageBoxDefaultButton.Button1)
            Else
                fc_Class = New Cls_PO
                Dim ls_Judul As String = ""
                Dim dtSearch As New DataTable
                Dim ls_OldKode As String = ""

                dtSearch = fc_Class.Get_AlterateID(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Inventory ID"), T_VendorID.EditValue)
                ls_Judul = "ALTERNATE ID"
                ls_OldKode = ""

                Dim lF_SearchData As FrmSystem_LookupGrid
                lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
                lF_SearchData.Text = "Select Data " & ls_Judul
                lF_SearchData.StartPosition = FormStartPosition.CenterScreen
                lF_SearchData.ShowDialog()

                If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then

                    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Alternate ID", lF_SearchData.Values.Item(1).ToString.Trim)


                End If
                lF_SearchData.Close()
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try

    End Sub

    Private Sub Reposite_ButtonClick(sender As Object, e As ButtonPressedEventArgs) Handles Reposite.ButtonClick

        Try
            fc_Class = New Cls_PO
            Dim ls_Judul As String = ""
            Dim dtSearch As New DataTable
            Dim ls_OldKode As String = ""

            dtSearch = fc_Class.Get_SiteDetail()
            ls_Judul = "SITE"

            Dim lF_SearchData As FrmSystem_LookupGrid
            lF_SearchData = New FrmSystem_LookupGrid(dtSearch)
            lF_SearchData.Text = "Select Data " & ls_Judul
            lF_SearchData.StartPosition = FormStartPosition.CenterScreen
            lF_SearchData.ShowDialog()

            If lF_SearchData.Values IsNot Nothing AndAlso lF_SearchData.Values.Item(0).ToString.Trim <> ls_OldKode Then

                GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Site ID", lF_SearchData.Values.Item(0).ToString.Trim)

                'T_ShippingSiteId.EditValue = lF_SearchData.Values.Item(0).ToString.Trim
                'T_ShippingName.EditValue = lF_SearchData.Values.Item("Name").ToString.Trim
                'T_ShippingAttention.EditValue = lF_SearchData.Values.Item("Attn").ToString.Trim
                'T_ShippingAddress1.EditValue = lF_SearchData.Values.Item("Addr1").ToString.Trim
                'T_ShippingAddress2.EditValue = lF_SearchData.Values.Item("Addr2").ToString.Trim
                'T_ShippingCity.EditValue = lF_SearchData.Values.Item("City").ToString.Trim
                'T_ShippingState.EditValue = lF_SearchData.Values.Item("State").ToString.Trim
                'T_ShippingPostalCode.EditValue = lF_SearchData.Values.Item("Zip").ToString.Trim
                'T_ShippingCountry.EditValue = lF_SearchData.Values.Item("Country").ToString.Trim
                'T_ShippingPhone.EditValue = lF_SearchData.Values.Item("Phone").ToString.Trim
                'T_ShippingFax.EditValue = lF_SearchData.Values.Item("Fax").ToString.Trim
                'T_ShippingEmail.EditValue = ""
                'T_ShippingShip.EditValue = ""
                'T_ShippingFOB.EditValue = ""
                'T_ShippingComfirmto.EditValue = ""


            End If
            lF_SearchData.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try


    End Sub

    Private Sub Qty_EditValueChanged(sender As Object, e As EventArgs) Handles Qty.EditValueChanged

        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim a As Double = 0
        Dim b As Double = 0
        Dim GV_Qty As Double = 0

        Dim GV_PRNo As String = ""
        Dim GV_PRLine As String = ""
        Dim GV_PRInvtID As String = ""

        Dim Cek_PRNo As String = ""
        Dim Cek_PRLine As String = ""
        Dim Cek_PRInvtID As String = ""

        Dim GV_index As Integer

        Dim selectedRows() As Integer = GridView1.GetSelectedRows()
        For Each rowHandle As Integer In selectedRows
            If rowHandle >= 0 Then
                a = GridView1.GetRowCellValue(rowHandle, "Quantity")
                b = GridView1.GetRowCellValue(rowHandle, "Balance")

                GV_PRNo = GridView1.GetRowCellValue(rowHandle, "PR No")
                GV_PRLine = GridView1.GetRowCellValue(rowHandle, "PR Line No")
                GV_PRInvtID = GridView1.GetRowCellValue(rowHandle, "Inventory ID")
                GV_index = rowHandle

            End If

        Next rowHandle



        For j As Integer = 0 To GridView1.RowCount - 1

            Cek_PRNo = ""
            Cek_PRLine = ""
            Cek_PRInvtID = ""

            If j <> GV_index Then
                Cek_PRNo = GridView1.GetRowCellValue(j, GridView1.Columns("PR No"))
                Cek_PRLine = GridView1.GetRowCellValue(j, GridView1.Columns("PR Line No"))
                Cek_PRInvtID = GridView1.GetRowCellValue(j, GridView1.Columns("Inventory ID"))

                If Cek_PRNo = GV_PRNo And Cek_PRLine = GV_PRLine And Cek_PRInvtID = GV_PRInvtID Then
                    GV_Qty = GV_Qty + GridView1.GetRowCellValue(j, GridView1.Columns("Quantity"))
                End If

            End If

        Next



        If a > (b - GV_Qty) Then
            GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Quantity", b - GV_Qty)
        End If


        Dim Qty As Double = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Quantity") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Quantity"))
        Dim Price As Double = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Unit Cost") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Unit Cost"))


        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Extended Cost", Qty * Price)


        'For j As Integer = 0 To DtTabale.Rows.Count - 1
        '    DT_PRNo = DtTabale.Rows(j).Item("PR No")
        '    DT_PRLine = DtTabale.Rows(j).Item("PR Line No")
        '    DT_PRInvtID = DtTabale.Rows(j).Item("Inventory ID")

        '    If DT_PRNo = GV_PRNo And DT_PRLine = GV_PRLine And DT_PRInvtID = GV_PRInvtID Then
        '        DT_QtyPO = DT_QtyPO + DtTabale.Rows(j).Item("Quantity")
        '    End If
        'Next

    End Sub

    Private Sub RepoUnitCost_EditValueChanged(sender As Object, e As EventArgs) Handles RepoUnitCost.EditValueChanged

        Dim baseEdit = TryCast(sender, BaseEdit)
        Dim gridView = (TryCast((TryCast(baseEdit.Parent, GridControl)).MainView, GridView))
        gridView.PostEditor()
        gridView.UpdateCurrentRow()

        Dim a As Double = 0
        Dim b As Double = 0

        'Dim selectedRows() As Integer = GridView1.GetSelectedRows()
        'For Each rowHandle As Integer In selectedRows
        '    If rowHandle >= 0 Then
        '        a = GridView1.GetRowCellValue(rowHandle, "Quantity")
        '        b = GridView1.GetRowCellValue(rowHandle, "Balance")
        '    End If

        'Next rowHandle
        'If a > b Then
        '    GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Quantity", b)
        'End If


        Dim Qty As Double = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Quantity") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Quantity"))
        Dim Price As Double = IIf(GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Unit Cost") Is DBNull.Value, 0, GridView1.GetRowCellValue(GridView1.FocusedRowHandle, "Unit Cost"))


        GridView1.SetRowCellValue(GridView1.FocusedRowHandle, "Extended Cost", Qty * Price)


    End Sub

    Private Sub T_VendorID_EditValueChanged(sender As Object, e As EventArgs) Handles T_VendorID.EditValueChanged

        ''GridView1.SelectAll()
        ''GridView1.DeleteSelectedRows()

        'If GridView1.RowCount > 0 Then
        '    GridView1.MoveFirst()
        '    GridView1.PostEditor()
        '    GridView1.UpdateCurrentRow()
        '    For i As Integer = 0 To GridView1.RowCount - 1
        '        GridView1.DeleteRow(0)
        '    Next
        'End If



        If GridView1.RowCount > 0 Then
            GridView1.MoveFirst()
            GridView1.PostEditor()
            GridView1.UpdateCurrentRow()
            For i As Integer = 0 To GridView1.RowCount - 1
                GridView1.SetRowCellValue(i, "Alternate ID", "")
            Next
        End If

        'T_PRNo.EditValue = ""

    End Sub

    Private Sub RepoAlternate_KeyPress(sender As Object, e As KeyPressEventArgs) Handles RepoAlternate.KeyPress

        Dim tombol As Integer
        tombol = Asc(e.KeyChar)
        If Not (tombol = 0) Then
            e.Handled = True
        End If

    End Sub

    Private Sub Reposite_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Reposite.KeyPress
        Dim tombol As Integer
        tombol = Asc(e.KeyChar)
        If Not (tombol = 0) Then
            e.Handled = True
        End If
    End Sub

    Private Sub RepoIncl_EditValueChanged(sender As Object, e As EventArgs) Handles RepoIncl.EditValueChanged
        GridView1.PostEditor()
        GridView1.UpdateCurrentRow()
    End Sub

    Private Sub GridView1_RowCountChanged(sender As Object, e As EventArgs) Handles GridView1.RowCountChanged

        For i As Integer = 0 To GridView1.RowCount - 1

            'GridView3.GetRowCellValue(i, GridView3.Columns("No")) = i.ToString()

            GridView1.SetRowCellValue(i, No, i + 1)

        Next

    End Sub
End Class
