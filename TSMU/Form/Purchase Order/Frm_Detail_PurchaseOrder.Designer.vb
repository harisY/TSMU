<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_Detail_PurchaseOrder
    Inherits TSMU.baseForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.T_Blanket = New DevExpress.XtraEditors.TextEdit()
        Me.T_DiscPersen = New DevExpress.XtraEditors.TextEdit()
        Me.T_StatusPO = New DevExpress.XtraEditors.TextEdit()
        Me.T_VendorName = New DevExpress.XtraEditors.TextEdit()
        Me.T_ProjectID = New DevExpress.XtraEditors.TextEdit()
        Me.T_PONumber = New DevExpress.XtraEditors.TextEdit()
        Me.T_POType = New DevExpress.XtraEditors.LookUpEdit()
        Me.T_PRNo = New DevExpress.XtraEditors.ButtonEdit()
        Me.T_VendorID = New DevExpress.XtraEditors.ButtonEdit()
        Me.T_Status = New DevExpress.XtraEditors.LookUpEdit()
        Me.T_Pajak = New DevExpress.XtraEditors.ButtonEdit()
        Me.T_DiscountAmount = New DevExpress.XtraEditors.TextEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.GridDetail = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.No = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XSeq = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PRNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PRLineNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.AlternateID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoAlternate = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.InventoryID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Description = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Quantity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Qty = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.OUM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UnitCost = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoUnitCost = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.ExtendedCost = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoExtendedCost = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.StatusPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UnitWeight = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoUnitWeight = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.SiteID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Reposite = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.ExtentedWeight = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoExtendedWeight = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.PurchaseFor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoPurchaseFor = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.UnitVolume = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoUnitVolume = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.ExtendedVolume = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoExtendedVolume = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.Required = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoRequired = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.Promised = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoPromised = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.Account = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SubAccount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RcptQtyMin = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoQtyMin = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.RcptQtyMax = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoQtyMax = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.ReceiptAction = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoAction = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.ReceiptStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoRcptStatus = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.VoucherStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoVoucherStatus = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.IncludeInLeadTimeCalc = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoIncl = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.Balance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PoQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PRQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepoCAction = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.T_ShippingComfirmto = New DevExpress.XtraEditors.TextEdit()
        Me.T_ShippingFOB = New DevExpress.XtraEditors.TextEdit()
        Me.T_ShippingShip = New DevExpress.XtraEditors.TextEdit()
        Me.T_ShippingEmail = New DevExpress.XtraEditors.TextEdit()
        Me.T_ShippingFax = New DevExpress.XtraEditors.TextEdit()
        Me.T_ShippingPhone = New DevExpress.XtraEditors.TextEdit()
        Me.T_ShippingCountry = New DevExpress.XtraEditors.TextEdit()
        Me.T_ShippingPostalCode = New DevExpress.XtraEditors.TextEdit()
        Me.T_ShippingState = New DevExpress.XtraEditors.TextEdit()
        Me.T_ShippingCity = New DevExpress.XtraEditors.TextEdit()
        Me.T_ShippingAddress2 = New DevExpress.XtraEditors.TextEdit()
        Me.T_ShippingAddress1 = New DevExpress.XtraEditors.TextEdit()
        Me.T_ShippingAttention = New DevExpress.XtraEditors.TextEdit()
        Me.T_ShippingName = New DevExpress.XtraEditors.TextEdit()
        Me.T_ShippingAddressType = New DevExpress.XtraEditors.LookUpEdit()
        Me.T_ShippingSiteId = New DevExpress.XtraEditors.ButtonEdit()
        Me.T_ShippingCustomerID = New DevExpress.XtraEditors.ButtonEdit()
        Me.T_ShippingVendorID = New DevExpress.XtraEditors.ButtonEdit()
        Me.T_ShippingOtherAddressID = New DevExpress.XtraEditors.ButtonEdit()
        Me.T_ShippingCustomerAddress = New DevExpress.XtraEditors.ButtonEdit()
        Me.T_ShippingVendorAddres = New DevExpress.XtraEditors.ButtonEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem20 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem21 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem22 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem23 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem24 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem25 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem26 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem27 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem28 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem29 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem30 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem31 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem32 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem33 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem17 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem18 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem16 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem19 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.LayoutControl3 = New DevExpress.XtraLayout.LayoutControl()
        Me.T_VI_Email = New DevExpress.XtraEditors.TextEdit()
        Me.T_VI_Fax = New DevExpress.XtraEditors.TextEdit()
        Me.T_VI_Phone = New DevExpress.XtraEditors.TextEdit()
        Me.T_VI_Country = New DevExpress.XtraEditors.TextEdit()
        Me.T_VI_Postal = New DevExpress.XtraEditors.TextEdit()
        Me.T_VI_State = New DevExpress.XtraEditors.TextEdit()
        Me.T_VI_City = New DevExpress.XtraEditors.TextEdit()
        Me.T_VI_Address2 = New DevExpress.XtraEditors.TextEdit()
        Me.T_VI_Address1 = New DevExpress.XtraEditors.TextEdit()
        Me.T_VI_Attention = New DevExpress.XtraEditors.TextEdit()
        Me.T_VI_Name = New DevExpress.XtraEditors.TextEdit()
        Me.T_VI_AddresID = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem34 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem6 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem35 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem36 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem37 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem38 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem39 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem40 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem41 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem42 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem43 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem44 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem45 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.LayoutControl4 = New DevExpress.XtraLayout.LayoutControl()
        Me.T_Other_Buyer = New DevExpress.XtraEditors.TextEdit()
        Me.T_Other_PeriodClosed = New DevExpress.XtraEditors.TextEdit()
        Me.T_Other_LastReceived = New DevExpress.XtraEditors.TextEdit()
        Me.T_Other_Blanked = New DevExpress.XtraEditors.TextEdit()
        Me.T_Other_PoDate = New DevExpress.XtraEditors.TextEdit()
        Me.T_Other_ReceiptStatus = New DevExpress.XtraEditors.LookUpEdit()
        Me.T_Other_Term = New DevExpress.XtraEditors.TextEdit()
        Me.T_Other_Certificated = New DevExpress.XtraEditors.LookUpEdit()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem46 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem7 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem47 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem48 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem49 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem50 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem51 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem52 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem53 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem8 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextEdit14 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit15 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit12 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit13 = New DevExpress.XtraEditors.TextEdit()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TextEdit7 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit8 = New DevExpress.XtraEditors.TextEdit()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.T_Rate_Reciprocal = New DevExpress.XtraEditors.TextEdit()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.T_Rate = New DevExpress.XtraEditors.TextEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.T_Rate_EfektifDate = New DevExpress.XtraEditors.TextEdit()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.T_Rate_Type = New DevExpress.XtraEditors.TextEdit()
        Me.T_Rate_BaseID = New DevExpress.XtraEditors.TextEdit()
        Me.T_Rate_Multiply = New DevExpress.XtraEditors.LookUpEdit()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.T_Curr_Symbol = New DevExpress.XtraEditors.TextEdit()
        Me.T_Curr_Description = New DevExpress.XtraEditors.TextEdit()
        Me.T_Curr_ID = New DevExpress.XtraEditors.ButtonEdit()
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.T_Note = New DevExpress.XtraEditors.MemoEdit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.T_Blanket.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_DiscPersen.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_StatusPO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_VendorName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_ProjectID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_PONumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_POType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_PRNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_VendorID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Status.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Pajak.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_DiscountAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoAlternate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Qty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoUnitCost, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoExtendedCost, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoUnitWeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Reposite, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoExtendedWeight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoPurchaseFor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoUnitVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoExtendedVolume, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoRequired, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoRequired.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoPromised, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoPromised.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoQtyMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoQtyMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoAction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoRcptStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoVoucherStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoIncl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoCAction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.T_ShippingComfirmto.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_ShippingFOB.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_ShippingShip.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_ShippingEmail.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_ShippingFax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_ShippingPhone.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_ShippingCountry.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_ShippingPostalCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_ShippingState.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_ShippingCity.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_ShippingAddress2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_ShippingAddress1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_ShippingAttention.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_ShippingName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_ShippingAddressType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_ShippingSiteId.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_ShippingCustomerID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_ShippingVendorID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_ShippingOtherAddressID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_ShippingCustomerAddress.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_ShippingVendorAddres.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem24, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem25, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem26, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem27, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem28, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem29, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem30, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem31, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem32, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl3.SuspendLayout()
        CType(Me.T_VI_Email.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_VI_Fax.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_VI_Phone.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_VI_Country.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_VI_Postal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_VI_State.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_VI_City.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_VI_Address2.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_VI_Address1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_VI_Attention.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_VI_Name.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_VI_AddresID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem34, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem36, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem37, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem39, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem40, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem41, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem42, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem43, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem44, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem45, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage4.SuspendLayout()
        CType(Me.LayoutControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl4.SuspendLayout()
        CType(Me.T_Other_Buyer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Other_PeriodClosed.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Other_LastReceived.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Other_Blanked.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Other_PoDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Other_ReceiptStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Other_Term.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Other_Certificated.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem46, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem47, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem48, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem49, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem50, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem51, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem52, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem53, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage5.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.TextEdit14.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit15.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit12.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit13.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit7.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit8.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.T_Rate_Reciprocal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Rate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Rate_EfektifDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Rate_Type.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Rate_BaseID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Rate_Multiply.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.T_Curr_Symbol.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Curr_Description.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Curr_ID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage6.SuspendLayout()
        CType(Me.T_Note.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.T_Blanket)
        Me.LayoutControl1.Controls.Add(Me.T_DiscPersen)
        Me.LayoutControl1.Controls.Add(Me.T_StatusPO)
        Me.LayoutControl1.Controls.Add(Me.T_VendorName)
        Me.LayoutControl1.Controls.Add(Me.T_ProjectID)
        Me.LayoutControl1.Controls.Add(Me.T_PONumber)
        Me.LayoutControl1.Controls.Add(Me.T_POType)
        Me.LayoutControl1.Controls.Add(Me.T_PRNo)
        Me.LayoutControl1.Controls.Add(Me.T_VendorID)
        Me.LayoutControl1.Controls.Add(Me.T_Status)
        Me.LayoutControl1.Controls.Add(Me.T_Pajak)
        Me.LayoutControl1.Controls.Add(Me.T_DiscountAmount)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 27)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1876, 81, 650, 400)
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(1277, 110)
        Me.LayoutControl1.TabIndex = 1
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'T_Blanket
        '
        Me.T_Blanket.Location = New System.Drawing.Point(1105, 36)
        Me.T_Blanket.Name = "T_Blanket"
        Me.T_Blanket.Size = New System.Drawing.Size(160, 20)
        Me.T_Blanket.StyleController = Me.LayoutControl1
        Me.T_Blanket.TabIndex = 8
        '
        'T_DiscPersen
        '
        Me.T_DiscPersen.Location = New System.Drawing.Point(1105, 60)
        Me.T_DiscPersen.Name = "T_DiscPersen"
        Me.T_DiscPersen.Size = New System.Drawing.Size(160, 20)
        Me.T_DiscPersen.StyleController = Me.LayoutControl1
        Me.T_DiscPersen.TabIndex = 12
        '
        'T_StatusPO
        '
        Me.T_StatusPO.Location = New System.Drawing.Point(404, 60)
        Me.T_StatusPO.Name = "T_StatusPO"
        Me.T_StatusPO.Size = New System.Drawing.Size(359, 20)
        Me.T_StatusPO.StyleController = Me.LayoutControl1
        Me.T_StatusPO.TabIndex = 10
        '
        'T_VendorName
        '
        Me.T_VendorName.Location = New System.Drawing.Point(404, 36)
        Me.T_VendorName.Name = "T_VendorName"
        Me.T_VendorName.Size = New System.Drawing.Size(359, 20)
        Me.T_VendorName.StyleController = Me.LayoutControl1
        Me.T_VendorName.TabIndex = 6
        '
        'T_ProjectID
        '
        Me.T_ProjectID.Location = New System.Drawing.Point(1105, 12)
        Me.T_ProjectID.Name = "T_ProjectID"
        Me.T_ProjectID.Size = New System.Drawing.Size(160, 20)
        Me.T_ProjectID.StyleController = Me.LayoutControl1
        Me.T_ProjectID.TabIndex = 4
        '
        'T_PONumber
        '
        Me.T_PONumber.Location = New System.Drawing.Point(110, 12)
        Me.T_PONumber.Name = "T_PONumber"
        Me.T_PONumber.Size = New System.Drawing.Size(192, 20)
        Me.T_PONumber.StyleController = Me.LayoutControl1
        Me.T_PONumber.TabIndex = 0
        '
        'T_POType
        '
        Me.T_POType.Location = New System.Drawing.Point(404, 12)
        Me.T_POType.Name = "T_POType"
        Me.T_POType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.T_POType.Properties.DropDownRows = 5
        Me.T_POType.Properties.NullText = ""
        Me.T_POType.Properties.PopupSizeable = False
        Me.T_POType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.T_POType.Size = New System.Drawing.Size(229, 20)
        Me.T_POType.StyleController = Me.LayoutControl1
        Me.T_POType.TabIndex = 2
        '
        'T_PRNo
        '
        Me.T_PRNo.Location = New System.Drawing.Point(735, 12)
        Me.T_PRNo.Name = "T_PRNo"
        Me.T_PRNo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.T_PRNo.Size = New System.Drawing.Size(268, 20)
        Me.T_PRNo.StyleController = Me.LayoutControl1
        Me.T_PRNo.TabIndex = 3
        '
        'T_VendorID
        '
        Me.T_VendorID.Location = New System.Drawing.Point(110, 36)
        Me.T_VendorID.Name = "T_VendorID"
        Me.T_VendorID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.T_VendorID.Size = New System.Drawing.Size(192, 20)
        Me.T_VendorID.StyleController = Me.LayoutControl1
        Me.T_VendorID.TabIndex = 5
        '
        'T_Status
        '
        Me.T_Status.Location = New System.Drawing.Point(865, 36)
        Me.T_Status.Name = "T_Status"
        Me.T_Status.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.T_Status.Properties.NullText = ""
        Me.T_Status.Size = New System.Drawing.Size(138, 20)
        Me.T_Status.StyleController = Me.LayoutControl1
        Me.T_Status.TabIndex = 7
        '
        'T_Pajak
        '
        Me.T_Pajak.Location = New System.Drawing.Point(110, 60)
        Me.T_Pajak.Name = "T_Pajak"
        Me.T_Pajak.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.T_Pajak.Size = New System.Drawing.Size(192, 20)
        Me.T_Pajak.StyleController = Me.LayoutControl1
        Me.T_Pajak.TabIndex = 9
        '
        'T_DiscountAmount
        '
        Me.T_DiscountAmount.Location = New System.Drawing.Point(865, 60)
        Me.T_DiscountAmount.Name = "T_DiscountAmount"
        Me.T_DiscountAmount.Size = New System.Drawing.Size(138, 20)
        Me.T_DiscountAmount.StyleController = Me.LayoutControl1
        Me.T_DiscountAmount.TabIndex = 11
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem5, Me.LayoutControlItem4, Me.LayoutControlItem6, Me.LayoutControlItem8, Me.LayoutControlItem7, Me.LayoutControlItem9, Me.LayoutControlItem10, Me.LayoutControlItem11, Me.LayoutControlItem12, Me.EmptySpaceItem1})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(1277, 110)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.T_PONumber
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(294, 24)
        Me.LayoutControlItem1.Text = "PO Number"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(95, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.T_POType
        Me.LayoutControlItem2.Location = New System.Drawing.Point(294, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(331, 24)
        Me.LayoutControlItem2.Text = "PO Type"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(95, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.T_PRNo
        Me.LayoutControlItem3.Location = New System.Drawing.Point(625, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(370, 24)
        Me.LayoutControlItem3.Text = "PR No"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(95, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.T_Status
        Me.LayoutControlItem5.Location = New System.Drawing.Point(755, 24)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(240, 24)
        Me.LayoutControlItem5.Text = "Status"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(95, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.T_VendorID
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(294, 24)
        Me.LayoutControlItem4.Text = "Vendor ID"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(95, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.T_ProjectID
        Me.LayoutControlItem6.Location = New System.Drawing.Point(995, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(262, 24)
        Me.LayoutControlItem6.Text = "Project ID"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(95, 13)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.T_VendorName
        Me.LayoutControlItem8.Location = New System.Drawing.Point(294, 24)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(461, 24)
        Me.LayoutControlItem8.Text = "Vendor"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(95, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.T_Pajak
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(294, 24)
        Me.LayoutControlItem7.Text = "Pajak"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(95, 13)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.T_StatusPO
        Me.LayoutControlItem9.Location = New System.Drawing.Point(294, 48)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(461, 24)
        Me.LayoutControlItem9.Text = "Status PO"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(95, 13)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.T_DiscountAmount
        Me.LayoutControlItem10.Location = New System.Drawing.Point(755, 48)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(240, 24)
        Me.LayoutControlItem10.Text = "Disc (amt)"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(95, 13)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.T_DiscPersen
        Me.LayoutControlItem11.Location = New System.Drawing.Point(995, 48)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(262, 24)
        Me.LayoutControlItem11.Text = "Disc (%)"
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(95, 13)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.T_Blanket
        Me.LayoutControlItem12.Location = New System.Drawing.Point(995, 24)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(262, 24)
        Me.LayoutControlItem12.Text = "Blanket /Std PO Nbr"
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(95, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 72)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(1257, 18)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'GridDetail
        '
        Me.GridDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetail.Location = New System.Drawing.Point(6, 6)
        Me.GridDetail.MainView = Me.GridView1
        Me.GridDetail.Name = "GridDetail"
        Me.GridDetail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1, Me.Qty, Me.RepoUnitCost, Me.RepoExtendedCost, Me.RepoUnitWeight, Me.RepoExtendedWeight, Me.RepoUnitVolume, Me.RepoExtendedVolume, Me.RepoQtyMin, Me.RepoQtyMax, Me.RepoRequired, Me.RepoPromised, Me.RepoAlternate, Me.RepoAction, Me.RepoCAction, Me.RepoRcptStatus, Me.RepoVoucherStatus, Me.Reposite, Me.RepoPurchaseFor, Me.RepoIncl})
        Me.GridDetail.Size = New System.Drawing.Size(1228, 391)
        Me.GridDetail.TabIndex = 2
        Me.GridDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.No, Me.XSeq, Me.PRNo, Me.PRLineNo, Me.AlternateID, Me.InventoryID, Me.Description, Me.Quantity, Me.OUM, Me.UnitCost, Me.ExtendedCost, Me.StatusPrice, Me.UnitWeight, Me.SiteID, Me.ExtentedWeight, Me.PurchaseFor, Me.UnitVolume, Me.ExtendedVolume, Me.Required, Me.Promised, Me.Account, Me.SubAccount, Me.RcptQtyMin, Me.RcptQtyMax, Me.ReceiptAction, Me.ReceiptStatus, Me.VoucherStatus, Me.IncludeInLeadTimeCalc, Me.Balance, Me.PoQty, Me.PRQty})
        Me.GridView1.GridControl = Me.GridDetail
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'No
        '
        Me.No.AppearanceCell.Options.UseTextOptions = True
        Me.No.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.No.AppearanceHeader.Options.UseTextOptions = True
        Me.No.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.No.FieldName = "No"
        Me.No.Name = "No"
        Me.No.OptionsColumn.AllowEdit = False
        Me.No.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "No", "{0}")})
        Me.No.Visible = True
        Me.No.VisibleIndex = 0
        Me.No.Width = 53
        '
        'XSeq
        '
        Me.XSeq.AppearanceCell.Options.UseTextOptions = True
        Me.XSeq.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.XSeq.AppearanceHeader.Options.UseTextOptions = True
        Me.XSeq.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.XSeq.FieldName = "XSeq"
        Me.XSeq.Name = "XSeq"
        Me.XSeq.OptionsColumn.AllowEdit = False
        Me.XSeq.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Max, "XSeq", "MAX={0}")})
        Me.XSeq.Visible = True
        Me.XSeq.VisibleIndex = 1
        '
        'PRNo
        '
        Me.PRNo.AppearanceHeader.Options.UseTextOptions = True
        Me.PRNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.PRNo.FieldName = "PR No"
        Me.PRNo.Name = "PRNo"
        Me.PRNo.OptionsColumn.AllowEdit = False
        Me.PRNo.Visible = True
        Me.PRNo.VisibleIndex = 2
        Me.PRNo.Width = 128
        '
        'PRLineNo
        '
        Me.PRLineNo.AppearanceCell.Options.UseTextOptions = True
        Me.PRLineNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.PRLineNo.AppearanceHeader.Options.UseTextOptions = True
        Me.PRLineNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.PRLineNo.FieldName = "PR Line No"
        Me.PRLineNo.Name = "PRLineNo"
        Me.PRLineNo.OptionsColumn.AllowEdit = False
        Me.PRLineNo.Visible = True
        Me.PRLineNo.VisibleIndex = 3
        Me.PRLineNo.Width = 77
        '
        'AlternateID
        '
        Me.AlternateID.AppearanceHeader.Options.UseTextOptions = True
        Me.AlternateID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.AlternateID.ColumnEdit = Me.RepoAlternate
        Me.AlternateID.FieldName = "Alternate ID"
        Me.AlternateID.Name = "AlternateID"
        Me.AlternateID.Visible = True
        Me.AlternateID.VisibleIndex = 4
        Me.AlternateID.Width = 124
        '
        'RepoAlternate
        '
        Me.RepoAlternate.AutoHeight = False
        Me.RepoAlternate.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.RepoAlternate.Name = "RepoAlternate"
        '
        'InventoryID
        '
        Me.InventoryID.AppearanceHeader.Options.UseTextOptions = True
        Me.InventoryID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.InventoryID.FieldName = "Inventory ID"
        Me.InventoryID.Name = "InventoryID"
        Me.InventoryID.OptionsColumn.AllowEdit = False
        Me.InventoryID.Visible = True
        Me.InventoryID.VisibleIndex = 5
        Me.InventoryID.Width = 123
        '
        'Description
        '
        Me.Description.AppearanceHeader.Options.UseTextOptions = True
        Me.Description.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Description.FieldName = "Description"
        Me.Description.Name = "Description"
        Me.Description.OptionsColumn.AllowEdit = False
        Me.Description.Visible = True
        Me.Description.VisibleIndex = 6
        Me.Description.Width = 109
        '
        'Quantity
        '
        Me.Quantity.AppearanceCell.Options.UseTextOptions = True
        Me.Quantity.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Quantity.AppearanceHeader.Options.UseTextOptions = True
        Me.Quantity.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Quantity.ColumnEdit = Me.Qty
        Me.Quantity.FieldName = "Quantity"
        Me.Quantity.Name = "Quantity"
        Me.Quantity.Visible = True
        Me.Quantity.VisibleIndex = 7
        Me.Quantity.Width = 62
        '
        'Qty
        '
        Me.Qty.AutoHeight = False
        Me.Qty.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Qty.Name = "Qty"
        '
        'OUM
        '
        Me.OUM.AppearanceCell.Options.UseTextOptions = True
        Me.OUM.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.OUM.AppearanceHeader.Options.UseTextOptions = True
        Me.OUM.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.OUM.FieldName = "OUM"
        Me.OUM.Name = "OUM"
        Me.OUM.OptionsColumn.AllowEdit = False
        Me.OUM.Visible = True
        Me.OUM.VisibleIndex = 8
        Me.OUM.Width = 123
        '
        'UnitCost
        '
        Me.UnitCost.AppearanceHeader.Options.UseTextOptions = True
        Me.UnitCost.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.UnitCost.ColumnEdit = Me.RepoUnitCost
        Me.UnitCost.DisplayFormat.FormatString = "n2"
        Me.UnitCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.UnitCost.FieldName = "Unit Cost"
        Me.UnitCost.Name = "UnitCost"
        Me.UnitCost.Visible = True
        Me.UnitCost.VisibleIndex = 9
        Me.UnitCost.Width = 126
        '
        'RepoUnitCost
        '
        Me.RepoUnitCost.AutoHeight = False
        Me.RepoUnitCost.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoUnitCost.Name = "RepoUnitCost"
        '
        'ExtendedCost
        '
        Me.ExtendedCost.AppearanceHeader.Options.UseTextOptions = True
        Me.ExtendedCost.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ExtendedCost.ColumnEdit = Me.RepoExtendedCost
        Me.ExtendedCost.DisplayFormat.FormatString = "n2"
        Me.ExtendedCost.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.ExtendedCost.FieldName = "Extended Cost"
        Me.ExtendedCost.Name = "ExtendedCost"
        Me.ExtendedCost.OptionsColumn.AllowEdit = False
        Me.ExtendedCost.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Extended Cost", "{0:n2}")})
        Me.ExtendedCost.Visible = True
        Me.ExtendedCost.VisibleIndex = 10
        Me.ExtendedCost.Width = 133
        '
        'RepoExtendedCost
        '
        Me.RepoExtendedCost.AutoHeight = False
        Me.RepoExtendedCost.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoExtendedCost.Name = "RepoExtendedCost"
        '
        'StatusPrice
        '
        Me.StatusPrice.AppearanceCell.Options.UseTextOptions = True
        Me.StatusPrice.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.StatusPrice.AppearanceHeader.Options.UseTextOptions = True
        Me.StatusPrice.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.StatusPrice.FieldName = "Status Price"
        Me.StatusPrice.Name = "StatusPrice"
        Me.StatusPrice.OptionsColumn.AllowEdit = False
        Me.StatusPrice.Width = 72
        '
        'UnitWeight
        '
        Me.UnitWeight.AppearanceCell.Options.UseTextOptions = True
        Me.UnitWeight.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.UnitWeight.AppearanceHeader.Options.UseTextOptions = True
        Me.UnitWeight.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.UnitWeight.ColumnEdit = Me.RepoUnitWeight
        Me.UnitWeight.FieldName = "Unit Weight"
        Me.UnitWeight.Name = "UnitWeight"
        Me.UnitWeight.OptionsColumn.AllowEdit = False
        Me.UnitWeight.Width = 71
        '
        'RepoUnitWeight
        '
        Me.RepoUnitWeight.AutoHeight = False
        Me.RepoUnitWeight.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoUnitWeight.Name = "RepoUnitWeight"
        '
        'SiteID
        '
        Me.SiteID.AppearanceCell.Options.UseTextOptions = True
        Me.SiteID.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SiteID.AppearanceHeader.Options.UseTextOptions = True
        Me.SiteID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SiteID.ColumnEdit = Me.Reposite
        Me.SiteID.FieldName = "Site ID"
        Me.SiteID.Name = "SiteID"
        Me.SiteID.Visible = True
        Me.SiteID.VisibleIndex = 11
        Me.SiteID.Width = 68
        '
        'Reposite
        '
        Me.Reposite.AutoHeight = False
        Me.Reposite.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.Reposite.Name = "Reposite"
        '
        'ExtentedWeight
        '
        Me.ExtentedWeight.AppearanceCell.Options.UseTextOptions = True
        Me.ExtentedWeight.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ExtentedWeight.AppearanceHeader.Options.UseTextOptions = True
        Me.ExtentedWeight.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ExtentedWeight.ColumnEdit = Me.RepoExtendedWeight
        Me.ExtentedWeight.FieldName = "Extented Weight"
        Me.ExtentedWeight.Name = "ExtentedWeight"
        Me.ExtentedWeight.OptionsColumn.AllowEdit = False
        Me.ExtentedWeight.Width = 104
        '
        'RepoExtendedWeight
        '
        Me.RepoExtendedWeight.AutoHeight = False
        Me.RepoExtendedWeight.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoExtendedWeight.Name = "RepoExtendedWeight"
        '
        'PurchaseFor
        '
        Me.PurchaseFor.AppearanceCell.Options.UseTextOptions = True
        Me.PurchaseFor.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.PurchaseFor.AppearanceHeader.Options.UseTextOptions = True
        Me.PurchaseFor.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.PurchaseFor.ColumnEdit = Me.RepoPurchaseFor
        Me.PurchaseFor.FieldName = "Purchase For"
        Me.PurchaseFor.Name = "PurchaseFor"
        Me.PurchaseFor.OptionsColumn.AllowEdit = False
        Me.PurchaseFor.Visible = True
        Me.PurchaseFor.VisibleIndex = 12
        Me.PurchaseFor.Width = 74
        '
        'RepoPurchaseFor
        '
        Me.RepoPurchaseFor.AutoHeight = False
        Me.RepoPurchaseFor.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoPurchaseFor.Name = "RepoPurchaseFor"
        '
        'UnitVolume
        '
        Me.UnitVolume.AppearanceCell.Options.UseTextOptions = True
        Me.UnitVolume.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.UnitVolume.AppearanceHeader.Options.UseTextOptions = True
        Me.UnitVolume.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.UnitVolume.ColumnEdit = Me.RepoUnitVolume
        Me.UnitVolume.FieldName = "Unit Volume"
        Me.UnitVolume.Name = "UnitVolume"
        Me.UnitVolume.OptionsColumn.AllowEdit = False
        Me.UnitVolume.Width = 81
        '
        'RepoUnitVolume
        '
        Me.RepoUnitVolume.AutoHeight = False
        Me.RepoUnitVolume.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoUnitVolume.Name = "RepoUnitVolume"
        '
        'ExtendedVolume
        '
        Me.ExtendedVolume.AppearanceHeader.Options.UseTextOptions = True
        Me.ExtendedVolume.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ExtendedVolume.ColumnEdit = Me.RepoExtendedVolume
        Me.ExtendedVolume.FieldName = "Extended Volume"
        Me.ExtendedVolume.Name = "ExtendedVolume"
        Me.ExtendedVolume.OptionsColumn.AllowEdit = False
        Me.ExtendedVolume.Width = 125
        '
        'RepoExtendedVolume
        '
        Me.RepoExtendedVolume.AutoHeight = False
        Me.RepoExtendedVolume.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoExtendedVolume.Name = "RepoExtendedVolume"
        '
        'Required
        '
        Me.Required.AppearanceCell.Options.UseTextOptions = True
        Me.Required.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Required.AppearanceHeader.Options.UseTextOptions = True
        Me.Required.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Required.ColumnEdit = Me.RepoRequired
        Me.Required.FieldName = "Required"
        Me.Required.Name = "Required"
        Me.Required.Visible = True
        Me.Required.VisibleIndex = 13
        Me.Required.Width = 81
        '
        'RepoRequired
        '
        Me.RepoRequired.AutoHeight = False
        Me.RepoRequired.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoRequired.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoRequired.Name = "RepoRequired"
        '
        'Promised
        '
        Me.Promised.AppearanceCell.Options.UseTextOptions = True
        Me.Promised.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Promised.AppearanceHeader.Options.UseTextOptions = True
        Me.Promised.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Promised.ColumnEdit = Me.RepoPromised
        Me.Promised.FieldName = "Promised"
        Me.Promised.Name = "Promised"
        Me.Promised.Visible = True
        Me.Promised.VisibleIndex = 14
        Me.Promised.Width = 77
        '
        'RepoPromised
        '
        Me.RepoPromised.AutoHeight = False
        Me.RepoPromised.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoPromised.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoPromised.Name = "RepoPromised"
        '
        'Account
        '
        Me.Account.AppearanceCell.Options.UseTextOptions = True
        Me.Account.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Account.AppearanceHeader.Options.UseTextOptions = True
        Me.Account.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Account.FieldName = "Account"
        Me.Account.Name = "Account"
        Me.Account.OptionsColumn.AllowEdit = False
        Me.Account.Visible = True
        Me.Account.VisibleIndex = 15
        Me.Account.Width = 76
        '
        'SubAccount
        '
        Me.SubAccount.AppearanceCell.Options.UseTextOptions = True
        Me.SubAccount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SubAccount.AppearanceHeader.Options.UseTextOptions = True
        Me.SubAccount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SubAccount.FieldName = "SubAccount"
        Me.SubAccount.Name = "SubAccount"
        Me.SubAccount.OptionsColumn.AllowEdit = False
        Me.SubAccount.Visible = True
        Me.SubAccount.VisibleIndex = 16
        Me.SubAccount.Width = 79
        '
        'RcptQtyMin
        '
        Me.RcptQtyMin.AppearanceCell.Options.UseTextOptions = True
        Me.RcptQtyMin.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RcptQtyMin.AppearanceHeader.Options.UseTextOptions = True
        Me.RcptQtyMin.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RcptQtyMin.ColumnEdit = Me.RepoQtyMin
        Me.RcptQtyMin.FieldName = "Rcpt Qty Min%"
        Me.RcptQtyMin.Name = "RcptQtyMin"
        Me.RcptQtyMin.Visible = True
        Me.RcptQtyMin.VisibleIndex = 17
        Me.RcptQtyMin.Width = 114
        '
        'RepoQtyMin
        '
        Me.RepoQtyMin.AutoHeight = False
        Me.RepoQtyMin.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoQtyMin.DisplayFormat.FormatString = "n2"
        Me.RepoQtyMin.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepoQtyMin.EditFormat.FormatString = "n2"
        Me.RepoQtyMin.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepoQtyMin.Name = "RepoQtyMin"
        '
        'RcptQtyMax
        '
        Me.RcptQtyMax.AppearanceCell.Options.UseTextOptions = True
        Me.RcptQtyMax.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RcptQtyMax.AppearanceHeader.Options.UseTextOptions = True
        Me.RcptQtyMax.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.RcptQtyMax.ColumnEdit = Me.RepoQtyMax
        Me.RcptQtyMax.FieldName = "Rcpt Qty Max%"
        Me.RcptQtyMax.Name = "RcptQtyMax"
        Me.RcptQtyMax.Visible = True
        Me.RcptQtyMax.VisibleIndex = 18
        Me.RcptQtyMax.Width = 89
        '
        'RepoQtyMax
        '
        Me.RepoQtyMax.AutoHeight = False
        Me.RepoQtyMax.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoQtyMax.DisplayFormat.FormatString = "n2"
        Me.RepoQtyMax.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepoQtyMax.EditFormat.FormatString = "n2"
        Me.RepoQtyMax.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepoQtyMax.Name = "RepoQtyMax"
        '
        'ReceiptAction
        '
        Me.ReceiptAction.AppearanceCell.Options.UseTextOptions = True
        Me.ReceiptAction.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ReceiptAction.AppearanceHeader.Options.UseTextOptions = True
        Me.ReceiptAction.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ReceiptAction.ColumnEdit = Me.RepoAction
        Me.ReceiptAction.FieldName = "Receipt Action"
        Me.ReceiptAction.Name = "ReceiptAction"
        Me.ReceiptAction.Visible = True
        Me.ReceiptAction.VisibleIndex = 19
        Me.ReceiptAction.Width = 82
        '
        'RepoAction
        '
        Me.RepoAction.AutoHeight = False
        Me.RepoAction.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoAction.Name = "RepoAction"
        '
        'ReceiptStatus
        '
        Me.ReceiptStatus.AppearanceCell.Options.UseTextOptions = True
        Me.ReceiptStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ReceiptStatus.AppearanceHeader.Options.UseTextOptions = True
        Me.ReceiptStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ReceiptStatus.ColumnEdit = Me.RepoRcptStatus
        Me.ReceiptStatus.FieldName = "Receipt Status"
        Me.ReceiptStatus.Name = "ReceiptStatus"
        Me.ReceiptStatus.Visible = True
        Me.ReceiptStatus.VisibleIndex = 20
        Me.ReceiptStatus.Width = 109
        '
        'RepoRcptStatus
        '
        Me.RepoRcptStatus.AutoHeight = False
        Me.RepoRcptStatus.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoRcptStatus.Name = "RepoRcptStatus"
        '
        'VoucherStatus
        '
        Me.VoucherStatus.AppearanceCell.Options.UseTextOptions = True
        Me.VoucherStatus.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.VoucherStatus.AppearanceHeader.Options.UseTextOptions = True
        Me.VoucherStatus.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.VoucherStatus.ColumnEdit = Me.RepoVoucherStatus
        Me.VoucherStatus.FieldName = "Voucher Status"
        Me.VoucherStatus.Name = "VoucherStatus"
        Me.VoucherStatus.OptionsColumn.AllowEdit = False
        Me.VoucherStatus.Visible = True
        Me.VoucherStatus.VisibleIndex = 21
        Me.VoucherStatus.Width = 108
        '
        'RepoVoucherStatus
        '
        Me.RepoVoucherStatus.AutoHeight = False
        Me.RepoVoucherStatus.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoVoucherStatus.Name = "RepoVoucherStatus"
        '
        'IncludeInLeadTimeCalc
        '
        Me.IncludeInLeadTimeCalc.AppearanceHeader.Options.UseTextOptions = True
        Me.IncludeInLeadTimeCalc.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.IncludeInLeadTimeCalc.ColumnEdit = Me.RepoIncl
        Me.IncludeInLeadTimeCalc.FieldName = "Lead Time"
        Me.IncludeInLeadTimeCalc.Name = "IncludeInLeadTimeCalc"
        Me.IncludeInLeadTimeCalc.Visible = True
        Me.IncludeInLeadTimeCalc.VisibleIndex = 22
        Me.IncludeInLeadTimeCalc.Width = 144
        '
        'RepoIncl
        '
        Me.RepoIncl.AutoHeight = False
        Me.RepoIncl.Name = "RepoIncl"
        '
        'Balance
        '
        Me.Balance.FieldName = "Balance"
        Me.Balance.Name = "Balance"
        Me.Balance.OptionsColumn.AllowEdit = False
        Me.Balance.Visible = True
        Me.Balance.VisibleIndex = 25
        '
        'PoQty
        '
        Me.PoQty.AppearanceCell.Options.UseTextOptions = True
        Me.PoQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.PoQty.AppearanceHeader.Options.UseTextOptions = True
        Me.PoQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.PoQty.FieldName = "PoQty"
        Me.PoQty.Name = "PoQty"
        Me.PoQty.OptionsColumn.AllowEdit = False
        Me.PoQty.Visible = True
        Me.PoQty.VisibleIndex = 24
        '
        'PRQty
        '
        Me.PRQty.AppearanceCell.Options.UseTextOptions = True
        Me.PRQty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.PRQty.AppearanceHeader.Options.UseTextOptions = True
        Me.PRQty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.PRQty.FieldName = "PRQty"
        Me.PRQty.Name = "PRQty"
        Me.PRQty.OptionsColumn.AllowEdit = False
        Me.PRQty.Visible = True
        Me.PRQty.VisibleIndex = 23
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'RepoCAction
        '
        Me.RepoCAction.AutoHeight = False
        Me.RepoCAction.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoCAction.Items.AddRange(New Object() {"A", "B"})
        Me.RepoCAction.Name = "RepoCAction"
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Location = New System.Drawing.Point(12, 143)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1258, 439)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GridDetail)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1250, 413)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Line Item"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.LayoutControl2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(1250, 413)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Shipping Information"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.T_ShippingComfirmto)
        Me.LayoutControl2.Controls.Add(Me.T_ShippingFOB)
        Me.LayoutControl2.Controls.Add(Me.T_ShippingShip)
        Me.LayoutControl2.Controls.Add(Me.T_ShippingEmail)
        Me.LayoutControl2.Controls.Add(Me.T_ShippingFax)
        Me.LayoutControl2.Controls.Add(Me.T_ShippingPhone)
        Me.LayoutControl2.Controls.Add(Me.T_ShippingCountry)
        Me.LayoutControl2.Controls.Add(Me.T_ShippingPostalCode)
        Me.LayoutControl2.Controls.Add(Me.T_ShippingState)
        Me.LayoutControl2.Controls.Add(Me.T_ShippingCity)
        Me.LayoutControl2.Controls.Add(Me.T_ShippingAddress2)
        Me.LayoutControl2.Controls.Add(Me.T_ShippingAddress1)
        Me.LayoutControl2.Controls.Add(Me.T_ShippingAttention)
        Me.LayoutControl2.Controls.Add(Me.T_ShippingName)
        Me.LayoutControl2.Controls.Add(Me.T_ShippingAddressType)
        Me.LayoutControl2.Controls.Add(Me.T_ShippingSiteId)
        Me.LayoutControl2.Controls.Add(Me.T_ShippingCustomerID)
        Me.LayoutControl2.Controls.Add(Me.T_ShippingVendorID)
        Me.LayoutControl2.Controls.Add(Me.T_ShippingOtherAddressID)
        Me.LayoutControl2.Controls.Add(Me.T_ShippingCustomerAddress)
        Me.LayoutControl2.Controls.Add(Me.T_ShippingVendorAddres)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Top
        Me.LayoutControl2.Location = New System.Drawing.Point(3, 3)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1874, 30, 650, 400)
        Me.LayoutControl2.Root = Me.LayoutControlGroup1
        Me.LayoutControl2.Size = New System.Drawing.Size(1244, 302)
        Me.LayoutControl2.TabIndex = 0
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'T_ShippingComfirmto
        '
        Me.T_ShippingComfirmto.Location = New System.Drawing.Point(657, 192)
        Me.T_ShippingComfirmto.Name = "T_ShippingComfirmto"
        Me.T_ShippingComfirmto.Size = New System.Drawing.Size(575, 20)
        Me.T_ShippingComfirmto.StyleController = Me.LayoutControl2
        Me.T_ShippingComfirmto.TabIndex = 19
        '
        'T_ShippingFOB
        '
        Me.T_ShippingFOB.Location = New System.Drawing.Point(657, 168)
        Me.T_ShippingFOB.Name = "T_ShippingFOB"
        Me.T_ShippingFOB.Size = New System.Drawing.Size(575, 20)
        Me.T_ShippingFOB.StyleController = Me.LayoutControl2
        Me.T_ShippingFOB.TabIndex = 17
        '
        'T_ShippingShip
        '
        Me.T_ShippingShip.Location = New System.Drawing.Point(657, 144)
        Me.T_ShippingShip.Name = "T_ShippingShip"
        Me.T_ShippingShip.Size = New System.Drawing.Size(575, 20)
        Me.T_ShippingShip.StyleController = Me.LayoutControl2
        Me.T_ShippingShip.TabIndex = 15
        '
        'T_ShippingEmail
        '
        Me.T_ShippingEmail.Location = New System.Drawing.Point(657, 120)
        Me.T_ShippingEmail.Name = "T_ShippingEmail"
        Me.T_ShippingEmail.Size = New System.Drawing.Size(575, 20)
        Me.T_ShippingEmail.StyleController = Me.LayoutControl2
        Me.T_ShippingEmail.TabIndex = 13
        '
        'T_ShippingFax
        '
        Me.T_ShippingFax.Location = New System.Drawing.Point(657, 96)
        Me.T_ShippingFax.Name = "T_ShippingFax"
        Me.T_ShippingFax.Size = New System.Drawing.Size(575, 20)
        Me.T_ShippingFax.StyleController = Me.LayoutControl2
        Me.T_ShippingFax.TabIndex = 11
        '
        'T_ShippingPhone
        '
        Me.T_ShippingPhone.Location = New System.Drawing.Point(657, 72)
        Me.T_ShippingPhone.Name = "T_ShippingPhone"
        Me.T_ShippingPhone.Size = New System.Drawing.Size(575, 20)
        Me.T_ShippingPhone.StyleController = Me.LayoutControl2
        Me.T_ShippingPhone.TabIndex = 9
        '
        'T_ShippingCountry
        '
        Me.T_ShippingCountry.Location = New System.Drawing.Point(105, 240)
        Me.T_ShippingCountry.Name = "T_ShippingCountry"
        Me.T_ShippingCountry.Size = New System.Drawing.Size(367, 20)
        Me.T_ShippingCountry.StyleController = Me.LayoutControl2
        Me.T_ShippingCountry.TabIndex = 21
        '
        'T_ShippingPostalCode
        '
        Me.T_ShippingPostalCode.Location = New System.Drawing.Point(105, 216)
        Me.T_ShippingPostalCode.Name = "T_ShippingPostalCode"
        Me.T_ShippingPostalCode.Size = New System.Drawing.Size(367, 20)
        Me.T_ShippingPostalCode.StyleController = Me.LayoutControl2
        Me.T_ShippingPostalCode.TabIndex = 20
        '
        'T_ShippingState
        '
        Me.T_ShippingState.Location = New System.Drawing.Point(105, 192)
        Me.T_ShippingState.Name = "T_ShippingState"
        Me.T_ShippingState.Size = New System.Drawing.Size(455, 20)
        Me.T_ShippingState.StyleController = Me.LayoutControl2
        Me.T_ShippingState.TabIndex = 18
        '
        'T_ShippingCity
        '
        Me.T_ShippingCity.Location = New System.Drawing.Point(105, 168)
        Me.T_ShippingCity.Name = "T_ShippingCity"
        Me.T_ShippingCity.Size = New System.Drawing.Size(455, 20)
        Me.T_ShippingCity.StyleController = Me.LayoutControl2
        Me.T_ShippingCity.TabIndex = 16
        '
        'T_ShippingAddress2
        '
        Me.T_ShippingAddress2.Location = New System.Drawing.Point(105, 144)
        Me.T_ShippingAddress2.Name = "T_ShippingAddress2"
        Me.T_ShippingAddress2.Size = New System.Drawing.Size(455, 20)
        Me.T_ShippingAddress2.StyleController = Me.LayoutControl2
        Me.T_ShippingAddress2.TabIndex = 14
        '
        'T_ShippingAddress1
        '
        Me.T_ShippingAddress1.Location = New System.Drawing.Point(105, 120)
        Me.T_ShippingAddress1.Name = "T_ShippingAddress1"
        Me.T_ShippingAddress1.Size = New System.Drawing.Size(455, 20)
        Me.T_ShippingAddress1.StyleController = Me.LayoutControl2
        Me.T_ShippingAddress1.TabIndex = 12
        '
        'T_ShippingAttention
        '
        Me.T_ShippingAttention.Location = New System.Drawing.Point(105, 96)
        Me.T_ShippingAttention.Name = "T_ShippingAttention"
        Me.T_ShippingAttention.Size = New System.Drawing.Size(455, 20)
        Me.T_ShippingAttention.StyleController = Me.LayoutControl2
        Me.T_ShippingAttention.TabIndex = 10
        '
        'T_ShippingName
        '
        Me.T_ShippingName.Location = New System.Drawing.Point(105, 72)
        Me.T_ShippingName.Name = "T_ShippingName"
        Me.T_ShippingName.Size = New System.Drawing.Size(455, 20)
        Me.T_ShippingName.StyleController = Me.LayoutControl2
        Me.T_ShippingName.TabIndex = 8
        '
        'T_ShippingAddressType
        '
        Me.T_ShippingAddressType.Location = New System.Drawing.Point(105, 12)
        Me.T_ShippingAddressType.Name = "T_ShippingAddressType"
        Me.T_ShippingAddressType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.T_ShippingAddressType.Properties.NullText = ""
        Me.T_ShippingAddressType.Size = New System.Drawing.Size(136, 20)
        Me.T_ShippingAddressType.StyleController = Me.LayoutControl2
        Me.T_ShippingAddressType.TabIndex = 0
        '
        'T_ShippingSiteId
        '
        Me.T_ShippingSiteId.Location = New System.Drawing.Point(338, 12)
        Me.T_ShippingSiteId.Name = "T_ShippingSiteId"
        Me.T_ShippingSiteId.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.T_ShippingSiteId.Size = New System.Drawing.Size(186, 20)
        Me.T_ShippingSiteId.StyleController = Me.LayoutControl2
        Me.T_ShippingSiteId.TabIndex = 2
        '
        'T_ShippingCustomerID
        '
        Me.T_ShippingCustomerID.Location = New System.Drawing.Point(621, 12)
        Me.T_ShippingCustomerID.Name = "T_ShippingCustomerID"
        Me.T_ShippingCustomerID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.T_ShippingCustomerID.Size = New System.Drawing.Size(134, 20)
        Me.T_ShippingCustomerID.StyleController = Me.LayoutControl2
        Me.T_ShippingCustomerID.TabIndex = 3
        '
        'T_ShippingVendorID
        '
        Me.T_ShippingVendorID.Location = New System.Drawing.Point(105, 36)
        Me.T_ShippingVendorID.Name = "T_ShippingVendorID"
        Me.T_ShippingVendorID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.T_ShippingVendorID.Size = New System.Drawing.Size(136, 20)
        Me.T_ShippingVendorID.StyleController = Me.LayoutControl2
        Me.T_ShippingVendorID.TabIndex = 5
        '
        'T_ShippingOtherAddressID
        '
        Me.T_ShippingOtherAddressID.Location = New System.Drawing.Point(852, 36)
        Me.T_ShippingOtherAddressID.Name = "T_ShippingOtherAddressID"
        Me.T_ShippingOtherAddressID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.T_ShippingOtherAddressID.Size = New System.Drawing.Size(380, 20)
        Me.T_ShippingOtherAddressID.StyleController = Me.LayoutControl2
        Me.T_ShippingOtherAddressID.TabIndex = 7
        '
        'T_ShippingCustomerAddress
        '
        Me.T_ShippingCustomerAddress.Location = New System.Drawing.Point(852, 12)
        Me.T_ShippingCustomerAddress.Name = "T_ShippingCustomerAddress"
        Me.T_ShippingCustomerAddress.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.T_ShippingCustomerAddress.Size = New System.Drawing.Size(380, 20)
        Me.T_ShippingCustomerAddress.StyleController = Me.LayoutControl2
        Me.T_ShippingCustomerAddress.TabIndex = 4
        '
        'T_ShippingVendorAddres
        '
        Me.T_ShippingVendorAddres.Location = New System.Drawing.Point(338, 36)
        Me.T_ShippingVendorAddres.Name = "T_ShippingVendorAddres"
        Me.T_ShippingVendorAddres.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.T_ShippingVendorAddres.Size = New System.Drawing.Size(417, 20)
        Me.T_ShippingVendorAddres.StyleController = Me.LayoutControl2
        Me.T_ShippingVendorAddres.TabIndex = 6
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem2, Me.LayoutControlItem13, Me.LayoutControlItem14, Me.LayoutControlItem15, Me.LayoutControlItem20, Me.LayoutControlItem21, Me.LayoutControlItem22, Me.LayoutControlItem23, Me.LayoutControlItem24, Me.LayoutControlItem25, Me.LayoutControlItem26, Me.LayoutControlItem27, Me.LayoutControlItem28, Me.LayoutControlItem29, Me.EmptySpaceItem3, Me.LayoutControlItem30, Me.LayoutControlItem31, Me.LayoutControlItem32, Me.LayoutControlItem33, Me.EmptySpaceItem4, Me.EmptySpaceItem5, Me.LayoutControlItem17, Me.LayoutControlItem18, Me.LayoutControlItem16, Me.LayoutControlItem19})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1244, 302)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 252)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(1224, 30)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.T_ShippingAddressType
        Me.LayoutControlItem13.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(233, 24)
        Me.LayoutControlItem13.Text = "Address Type"
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(90, 13)
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.T_ShippingSiteId
        Me.LayoutControlItem14.Location = New System.Drawing.Point(233, 0)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(283, 24)
        Me.LayoutControlItem14.Text = "Site ID"
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(90, 13)
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.T_ShippingCustomerID
        Me.LayoutControlItem15.Location = New System.Drawing.Point(516, 0)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(231, 24)
        Me.LayoutControlItem15.Text = "Customer ID"
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(90, 13)
        '
        'LayoutControlItem20
        '
        Me.LayoutControlItem20.Control = Me.T_ShippingName
        Me.LayoutControlItem20.Location = New System.Drawing.Point(0, 60)
        Me.LayoutControlItem20.Name = "LayoutControlItem20"
        Me.LayoutControlItem20.Size = New System.Drawing.Size(552, 24)
        Me.LayoutControlItem20.Text = "Name"
        Me.LayoutControlItem20.TextSize = New System.Drawing.Size(90, 13)
        '
        'LayoutControlItem21
        '
        Me.LayoutControlItem21.Control = Me.T_ShippingAttention
        Me.LayoutControlItem21.Location = New System.Drawing.Point(0, 84)
        Me.LayoutControlItem21.Name = "LayoutControlItem21"
        Me.LayoutControlItem21.Size = New System.Drawing.Size(552, 24)
        Me.LayoutControlItem21.Text = "Attention"
        Me.LayoutControlItem21.TextSize = New System.Drawing.Size(90, 13)
        '
        'LayoutControlItem22
        '
        Me.LayoutControlItem22.Control = Me.T_ShippingAddress1
        Me.LayoutControlItem22.Location = New System.Drawing.Point(0, 108)
        Me.LayoutControlItem22.Name = "LayoutControlItem22"
        Me.LayoutControlItem22.Size = New System.Drawing.Size(552, 24)
        Me.LayoutControlItem22.Text = "Address1"
        Me.LayoutControlItem22.TextSize = New System.Drawing.Size(90, 13)
        '
        'LayoutControlItem23
        '
        Me.LayoutControlItem23.Control = Me.T_ShippingAddress2
        Me.LayoutControlItem23.Location = New System.Drawing.Point(0, 132)
        Me.LayoutControlItem23.Name = "LayoutControlItem23"
        Me.LayoutControlItem23.Size = New System.Drawing.Size(552, 24)
        Me.LayoutControlItem23.Text = "Address2"
        Me.LayoutControlItem23.TextSize = New System.Drawing.Size(90, 13)
        '
        'LayoutControlItem24
        '
        Me.LayoutControlItem24.Control = Me.T_ShippingCity
        Me.LayoutControlItem24.Location = New System.Drawing.Point(0, 156)
        Me.LayoutControlItem24.Name = "LayoutControlItem24"
        Me.LayoutControlItem24.Size = New System.Drawing.Size(552, 24)
        Me.LayoutControlItem24.Text = "City"
        Me.LayoutControlItem24.TextSize = New System.Drawing.Size(90, 13)
        '
        'LayoutControlItem25
        '
        Me.LayoutControlItem25.Control = Me.T_ShippingState
        Me.LayoutControlItem25.Location = New System.Drawing.Point(0, 180)
        Me.LayoutControlItem25.Name = "LayoutControlItem25"
        Me.LayoutControlItem25.Size = New System.Drawing.Size(552, 24)
        Me.LayoutControlItem25.Text = "State / Prov"
        Me.LayoutControlItem25.TextSize = New System.Drawing.Size(90, 13)
        '
        'LayoutControlItem26
        '
        Me.LayoutControlItem26.Control = Me.T_ShippingPostalCode
        Me.LayoutControlItem26.Location = New System.Drawing.Point(0, 204)
        Me.LayoutControlItem26.Name = "LayoutControlItem26"
        Me.LayoutControlItem26.Size = New System.Drawing.Size(464, 24)
        Me.LayoutControlItem26.Text = "Postal Code"
        Me.LayoutControlItem26.TextSize = New System.Drawing.Size(90, 13)
        '
        'LayoutControlItem27
        '
        Me.LayoutControlItem27.Control = Me.T_ShippingCountry
        Me.LayoutControlItem27.Location = New System.Drawing.Point(0, 228)
        Me.LayoutControlItem27.Name = "LayoutControlItem27"
        Me.LayoutControlItem27.Size = New System.Drawing.Size(464, 24)
        Me.LayoutControlItem27.Text = "Country / Region"
        Me.LayoutControlItem27.TextSize = New System.Drawing.Size(90, 13)
        '
        'LayoutControlItem28
        '
        Me.LayoutControlItem28.Control = Me.T_ShippingPhone
        Me.LayoutControlItem28.Location = New System.Drawing.Point(552, 60)
        Me.LayoutControlItem28.Name = "LayoutControlItem28"
        Me.LayoutControlItem28.Size = New System.Drawing.Size(672, 24)
        Me.LayoutControlItem28.Text = "Phone"
        Me.LayoutControlItem28.TextSize = New System.Drawing.Size(90, 13)
        '
        'LayoutControlItem29
        '
        Me.LayoutControlItem29.Control = Me.T_ShippingFax
        Me.LayoutControlItem29.Location = New System.Drawing.Point(552, 84)
        Me.LayoutControlItem29.Name = "LayoutControlItem29"
        Me.LayoutControlItem29.Size = New System.Drawing.Size(672, 24)
        Me.LayoutControlItem29.Text = "Fax"
        Me.LayoutControlItem29.TextSize = New System.Drawing.Size(90, 13)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(0, 48)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(1224, 12)
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem30
        '
        Me.LayoutControlItem30.Control = Me.T_ShippingEmail
        Me.LayoutControlItem30.Location = New System.Drawing.Point(552, 108)
        Me.LayoutControlItem30.Name = "LayoutControlItem30"
        Me.LayoutControlItem30.Size = New System.Drawing.Size(672, 24)
        Me.LayoutControlItem30.Text = "E-Mail Address"
        Me.LayoutControlItem30.TextSize = New System.Drawing.Size(90, 13)
        '
        'LayoutControlItem31
        '
        Me.LayoutControlItem31.Control = Me.T_ShippingShip
        Me.LayoutControlItem31.Location = New System.Drawing.Point(552, 132)
        Me.LayoutControlItem31.Name = "LayoutControlItem31"
        Me.LayoutControlItem31.Size = New System.Drawing.Size(672, 24)
        Me.LayoutControlItem31.Text = "Ship VIA ID"
        Me.LayoutControlItem31.TextSize = New System.Drawing.Size(90, 13)
        '
        'LayoutControlItem32
        '
        Me.LayoutControlItem32.Control = Me.T_ShippingFOB
        Me.LayoutControlItem32.Location = New System.Drawing.Point(552, 156)
        Me.LayoutControlItem32.Name = "LayoutControlItem32"
        Me.LayoutControlItem32.Size = New System.Drawing.Size(672, 24)
        Me.LayoutControlItem32.Text = "FOB Point"
        Me.LayoutControlItem32.TextSize = New System.Drawing.Size(90, 13)
        '
        'LayoutControlItem33
        '
        Me.LayoutControlItem33.Control = Me.T_ShippingComfirmto
        Me.LayoutControlItem33.Location = New System.Drawing.Point(552, 180)
        Me.LayoutControlItem33.Name = "LayoutControlItem33"
        Me.LayoutControlItem33.Size = New System.Drawing.Size(672, 24)
        Me.LayoutControlItem33.Text = "Confirm To"
        Me.LayoutControlItem33.TextSize = New System.Drawing.Size(90, 13)
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(464, 204)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(760, 24)
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(464, 228)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(760, 24)
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem17
        '
        Me.LayoutControlItem17.Control = Me.T_ShippingVendorID
        Me.LayoutControlItem17.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem17.Name = "LayoutControlItem17"
        Me.LayoutControlItem17.Size = New System.Drawing.Size(233, 24)
        Me.LayoutControlItem17.Text = "Vendor ID"
        Me.LayoutControlItem17.TextSize = New System.Drawing.Size(90, 13)
        '
        'LayoutControlItem18
        '
        Me.LayoutControlItem18.Control = Me.T_ShippingCustomerAddress
        Me.LayoutControlItem18.Location = New System.Drawing.Point(747, 0)
        Me.LayoutControlItem18.Name = "LayoutControlItem18"
        Me.LayoutControlItem18.Size = New System.Drawing.Size(477, 24)
        Me.LayoutControlItem18.Text = "Customer Address"
        Me.LayoutControlItem18.TextSize = New System.Drawing.Size(90, 13)
        '
        'LayoutControlItem16
        '
        Me.LayoutControlItem16.Control = Me.T_ShippingVendorAddres
        Me.LayoutControlItem16.Location = New System.Drawing.Point(233, 24)
        Me.LayoutControlItem16.Name = "LayoutControlItem16"
        Me.LayoutControlItem16.Size = New System.Drawing.Size(514, 24)
        Me.LayoutControlItem16.Text = "Vendor Address ID"
        Me.LayoutControlItem16.TextSize = New System.Drawing.Size(90, 13)
        '
        'LayoutControlItem19
        '
        Me.LayoutControlItem19.Control = Me.T_ShippingOtherAddressID
        Me.LayoutControlItem19.Location = New System.Drawing.Point(747, 24)
        Me.LayoutControlItem19.Name = "LayoutControlItem19"
        Me.LayoutControlItem19.Size = New System.Drawing.Size(477, 24)
        Me.LayoutControlItem19.Text = "Other Address ID"
        Me.LayoutControlItem19.TextSize = New System.Drawing.Size(90, 13)
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.LayoutControl3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(1250, 413)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Vendor Information"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'LayoutControl3
        '
        Me.LayoutControl3.Controls.Add(Me.T_VI_Email)
        Me.LayoutControl3.Controls.Add(Me.T_VI_Fax)
        Me.LayoutControl3.Controls.Add(Me.T_VI_Phone)
        Me.LayoutControl3.Controls.Add(Me.T_VI_Country)
        Me.LayoutControl3.Controls.Add(Me.T_VI_Postal)
        Me.LayoutControl3.Controls.Add(Me.T_VI_State)
        Me.LayoutControl3.Controls.Add(Me.T_VI_City)
        Me.LayoutControl3.Controls.Add(Me.T_VI_Address2)
        Me.LayoutControl3.Controls.Add(Me.T_VI_Address1)
        Me.LayoutControl3.Controls.Add(Me.T_VI_Attention)
        Me.LayoutControl3.Controls.Add(Me.T_VI_Name)
        Me.LayoutControl3.Controls.Add(Me.T_VI_AddresID)
        Me.LayoutControl3.Dock = System.Windows.Forms.DockStyle.Top
        Me.LayoutControl3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl3.Name = "LayoutControl3"
        Me.LayoutControl3.Root = Me.LayoutControlGroup2
        Me.LayoutControl3.Size = New System.Drawing.Size(1250, 271)
        Me.LayoutControl3.TabIndex = 0
        Me.LayoutControl3.Text = "LayoutControl3"
        '
        'T_VI_Email
        '
        Me.T_VI_Email.Location = New System.Drawing.Point(712, 132)
        Me.T_VI_Email.Name = "T_VI_Email"
        Me.T_VI_Email.Size = New System.Drawing.Size(526, 20)
        Me.T_VI_Email.StyleController = Me.LayoutControl3
        Me.T_VI_Email.TabIndex = 12
        '
        'T_VI_Fax
        '
        Me.T_VI_Fax.Location = New System.Drawing.Point(712, 108)
        Me.T_VI_Fax.Name = "T_VI_Fax"
        Me.T_VI_Fax.Size = New System.Drawing.Size(526, 20)
        Me.T_VI_Fax.StyleController = Me.LayoutControl3
        Me.T_VI_Fax.TabIndex = 10
        '
        'T_VI_Phone
        '
        Me.T_VI_Phone.Location = New System.Drawing.Point(712, 84)
        Me.T_VI_Phone.Name = "T_VI_Phone"
        Me.T_VI_Phone.Size = New System.Drawing.Size(526, 20)
        Me.T_VI_Phone.StyleController = Me.LayoutControl3
        Me.T_VI_Phone.TabIndex = 8
        '
        'T_VI_Country
        '
        Me.T_VI_Country.Location = New System.Drawing.Point(712, 60)
        Me.T_VI_Country.Name = "T_VI_Country"
        Me.T_VI_Country.Size = New System.Drawing.Size(526, 20)
        Me.T_VI_Country.StyleController = Me.LayoutControl3
        Me.T_VI_Country.TabIndex = 6
        '
        'T_VI_Postal
        '
        Me.T_VI_Postal.Location = New System.Drawing.Point(712, 36)
        Me.T_VI_Postal.Name = "T_VI_Postal"
        Me.T_VI_Postal.Size = New System.Drawing.Size(526, 20)
        Me.T_VI_Postal.StyleController = Me.LayoutControl3
        Me.T_VI_Postal.TabIndex = 4
        '
        'T_VI_State
        '
        Me.T_VI_State.Location = New System.Drawing.Point(712, 12)
        Me.T_VI_State.Name = "T_VI_State"
        Me.T_VI_State.Size = New System.Drawing.Size(526, 20)
        Me.T_VI_State.StyleController = Me.LayoutControl3
        Me.T_VI_State.TabIndex = 2
        '
        'T_VI_City
        '
        Me.T_VI_City.Location = New System.Drawing.Point(97, 132)
        Me.T_VI_City.Name = "T_VI_City"
        Me.T_VI_City.Size = New System.Drawing.Size(526, 20)
        Me.T_VI_City.StyleController = Me.LayoutControl3
        Me.T_VI_City.TabIndex = 11
        '
        'T_VI_Address2
        '
        Me.T_VI_Address2.Location = New System.Drawing.Point(97, 108)
        Me.T_VI_Address2.Name = "T_VI_Address2"
        Me.T_VI_Address2.Size = New System.Drawing.Size(526, 20)
        Me.T_VI_Address2.StyleController = Me.LayoutControl3
        Me.T_VI_Address2.TabIndex = 9
        '
        'T_VI_Address1
        '
        Me.T_VI_Address1.Location = New System.Drawing.Point(97, 84)
        Me.T_VI_Address1.Name = "T_VI_Address1"
        Me.T_VI_Address1.Size = New System.Drawing.Size(526, 20)
        Me.T_VI_Address1.StyleController = Me.LayoutControl3
        Me.T_VI_Address1.TabIndex = 7
        '
        'T_VI_Attention
        '
        Me.T_VI_Attention.Location = New System.Drawing.Point(97, 60)
        Me.T_VI_Attention.Name = "T_VI_Attention"
        Me.T_VI_Attention.Size = New System.Drawing.Size(526, 20)
        Me.T_VI_Attention.StyleController = Me.LayoutControl3
        Me.T_VI_Attention.TabIndex = 5
        '
        'T_VI_Name
        '
        Me.T_VI_Name.Location = New System.Drawing.Point(97, 36)
        Me.T_VI_Name.Name = "T_VI_Name"
        Me.T_VI_Name.Size = New System.Drawing.Size(526, 20)
        Me.T_VI_Name.StyleController = Me.LayoutControl3
        Me.T_VI_Name.TabIndex = 3
        '
        'T_VI_AddresID
        '
        Me.T_VI_AddresID.Location = New System.Drawing.Point(97, 12)
        Me.T_VI_AddresID.Name = "T_VI_AddresID"
        Me.T_VI_AddresID.Size = New System.Drawing.Size(526, 20)
        Me.T_VI_AddresID.StyleController = Me.LayoutControl3
        Me.T_VI_AddresID.TabIndex = 0
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem34, Me.EmptySpaceItem6, Me.LayoutControlItem35, Me.LayoutControlItem36, Me.LayoutControlItem37, Me.LayoutControlItem38, Me.LayoutControlItem39, Me.LayoutControlItem40, Me.LayoutControlItem41, Me.LayoutControlItem42, Me.LayoutControlItem43, Me.LayoutControlItem44, Me.LayoutControlItem45})
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1250, 271)
        Me.LayoutControlGroup2.TextVisible = False
        '
        'LayoutControlItem34
        '
        Me.LayoutControlItem34.Control = Me.T_VI_AddresID
        Me.LayoutControlItem34.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem34.Name = "LayoutControlItem34"
        Me.LayoutControlItem34.Size = New System.Drawing.Size(615, 24)
        Me.LayoutControlItem34.Text = "Address ID"
        Me.LayoutControlItem34.TextSize = New System.Drawing.Size(82, 13)
        '
        'EmptySpaceItem6
        '
        Me.EmptySpaceItem6.AllowHotTrack = False
        Me.EmptySpaceItem6.Location = New System.Drawing.Point(0, 144)
        Me.EmptySpaceItem6.Name = "EmptySpaceItem6"
        Me.EmptySpaceItem6.Size = New System.Drawing.Size(1230, 107)
        Me.EmptySpaceItem6.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem35
        '
        Me.LayoutControlItem35.Control = Me.T_VI_Name
        Me.LayoutControlItem35.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem35.Name = "LayoutControlItem35"
        Me.LayoutControlItem35.Size = New System.Drawing.Size(615, 24)
        Me.LayoutControlItem35.Text = "Name"
        Me.LayoutControlItem35.TextSize = New System.Drawing.Size(82, 13)
        '
        'LayoutControlItem36
        '
        Me.LayoutControlItem36.Control = Me.T_VI_Attention
        Me.LayoutControlItem36.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem36.Name = "LayoutControlItem36"
        Me.LayoutControlItem36.Size = New System.Drawing.Size(615, 24)
        Me.LayoutControlItem36.Text = "Attention"
        Me.LayoutControlItem36.TextSize = New System.Drawing.Size(82, 13)
        '
        'LayoutControlItem37
        '
        Me.LayoutControlItem37.Control = Me.T_VI_Address1
        Me.LayoutControlItem37.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem37.Name = "LayoutControlItem37"
        Me.LayoutControlItem37.Size = New System.Drawing.Size(615, 24)
        Me.LayoutControlItem37.Text = "Address 1"
        Me.LayoutControlItem37.TextSize = New System.Drawing.Size(82, 13)
        '
        'LayoutControlItem38
        '
        Me.LayoutControlItem38.Control = Me.T_VI_Address2
        Me.LayoutControlItem38.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem38.Name = "LayoutControlItem38"
        Me.LayoutControlItem38.Size = New System.Drawing.Size(615, 24)
        Me.LayoutControlItem38.Text = "Address 2"
        Me.LayoutControlItem38.TextSize = New System.Drawing.Size(82, 13)
        '
        'LayoutControlItem39
        '
        Me.LayoutControlItem39.Control = Me.T_VI_City
        Me.LayoutControlItem39.Location = New System.Drawing.Point(0, 120)
        Me.LayoutControlItem39.Name = "LayoutControlItem39"
        Me.LayoutControlItem39.Size = New System.Drawing.Size(615, 24)
        Me.LayoutControlItem39.Text = "City"
        Me.LayoutControlItem39.TextSize = New System.Drawing.Size(82, 13)
        '
        'LayoutControlItem40
        '
        Me.LayoutControlItem40.Control = Me.T_VI_State
        Me.LayoutControlItem40.Location = New System.Drawing.Point(615, 0)
        Me.LayoutControlItem40.Name = "LayoutControlItem40"
        Me.LayoutControlItem40.Size = New System.Drawing.Size(615, 24)
        Me.LayoutControlItem40.Text = "State / Prov"
        Me.LayoutControlItem40.TextSize = New System.Drawing.Size(82, 13)
        '
        'LayoutControlItem41
        '
        Me.LayoutControlItem41.Control = Me.T_VI_Postal
        Me.LayoutControlItem41.Location = New System.Drawing.Point(615, 24)
        Me.LayoutControlItem41.Name = "LayoutControlItem41"
        Me.LayoutControlItem41.Size = New System.Drawing.Size(615, 24)
        Me.LayoutControlItem41.Text = "Postal Code"
        Me.LayoutControlItem41.TextSize = New System.Drawing.Size(82, 13)
        '
        'LayoutControlItem42
        '
        Me.LayoutControlItem42.Control = Me.T_VI_Country
        Me.LayoutControlItem42.Location = New System.Drawing.Point(615, 48)
        Me.LayoutControlItem42.Name = "LayoutControlItem42"
        Me.LayoutControlItem42.Size = New System.Drawing.Size(615, 24)
        Me.LayoutControlItem42.Text = "Country / Region"
        Me.LayoutControlItem42.TextSize = New System.Drawing.Size(82, 13)
        '
        'LayoutControlItem43
        '
        Me.LayoutControlItem43.Control = Me.T_VI_Phone
        Me.LayoutControlItem43.Location = New System.Drawing.Point(615, 72)
        Me.LayoutControlItem43.Name = "LayoutControlItem43"
        Me.LayoutControlItem43.Size = New System.Drawing.Size(615, 24)
        Me.LayoutControlItem43.Text = "Phone"
        Me.LayoutControlItem43.TextSize = New System.Drawing.Size(82, 13)
        '
        'LayoutControlItem44
        '
        Me.LayoutControlItem44.Control = Me.T_VI_Fax
        Me.LayoutControlItem44.Location = New System.Drawing.Point(615, 96)
        Me.LayoutControlItem44.Name = "LayoutControlItem44"
        Me.LayoutControlItem44.Size = New System.Drawing.Size(615, 24)
        Me.LayoutControlItem44.Text = "Fax"
        Me.LayoutControlItem44.TextSize = New System.Drawing.Size(82, 13)
        '
        'LayoutControlItem45
        '
        Me.LayoutControlItem45.Control = Me.T_VI_Email
        Me.LayoutControlItem45.Location = New System.Drawing.Point(615, 120)
        Me.LayoutControlItem45.Name = "LayoutControlItem45"
        Me.LayoutControlItem45.Size = New System.Drawing.Size(615, 24)
        Me.LayoutControlItem45.Text = "Email Address"
        Me.LayoutControlItem45.TextSize = New System.Drawing.Size(82, 13)
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.LayoutControl4)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(1250, 413)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Other Information"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'LayoutControl4
        '
        Me.LayoutControl4.Controls.Add(Me.T_Other_Buyer)
        Me.LayoutControl4.Controls.Add(Me.T_Other_PeriodClosed)
        Me.LayoutControl4.Controls.Add(Me.T_Other_LastReceived)
        Me.LayoutControl4.Controls.Add(Me.T_Other_Blanked)
        Me.LayoutControl4.Controls.Add(Me.T_Other_PoDate)
        Me.LayoutControl4.Controls.Add(Me.T_Other_ReceiptStatus)
        Me.LayoutControl4.Controls.Add(Me.T_Other_Term)
        Me.LayoutControl4.Controls.Add(Me.T_Other_Certificated)
        Me.LayoutControl4.Dock = System.Windows.Forms.DockStyle.Top
        Me.LayoutControl4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl4.Name = "LayoutControl4"
        Me.LayoutControl4.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(-8, 0, 699, 736)
        Me.LayoutControl4.Root = Me.LayoutControlGroup3
        Me.LayoutControl4.Size = New System.Drawing.Size(1250, 209)
        Me.LayoutControl4.TabIndex = 0
        Me.LayoutControl4.Text = "LayoutControl4"
        '
        'T_Other_Buyer
        '
        Me.T_Other_Buyer.Location = New System.Drawing.Point(146, 180)
        Me.T_Other_Buyer.Name = "T_Other_Buyer"
        Me.T_Other_Buyer.Size = New System.Drawing.Size(182, 20)
        Me.T_Other_Buyer.StyleController = Me.LayoutControl4
        Me.T_Other_Buyer.TabIndex = 8
        '
        'T_Other_PeriodClosed
        '
        Me.T_Other_PeriodClosed.Location = New System.Drawing.Point(146, 108)
        Me.T_Other_PeriodClosed.Name = "T_Other_PeriodClosed"
        Me.T_Other_PeriodClosed.Size = New System.Drawing.Size(182, 20)
        Me.T_Other_PeriodClosed.StyleController = Me.LayoutControl4
        Me.T_Other_PeriodClosed.TabIndex = 5
        '
        'T_Other_LastReceived
        '
        Me.T_Other_LastReceived.Location = New System.Drawing.Point(146, 84)
        Me.T_Other_LastReceived.Name = "T_Other_LastReceived"
        Me.T_Other_LastReceived.Size = New System.Drawing.Size(182, 20)
        Me.T_Other_LastReceived.StyleController = Me.LayoutControl4
        Me.T_Other_LastReceived.TabIndex = 4
        '
        'T_Other_Blanked
        '
        Me.T_Other_Blanked.Location = New System.Drawing.Point(146, 36)
        Me.T_Other_Blanked.Name = "T_Other_Blanked"
        Me.T_Other_Blanked.Size = New System.Drawing.Size(182, 20)
        Me.T_Other_Blanked.StyleController = Me.LayoutControl4
        Me.T_Other_Blanked.TabIndex = 2
        '
        'T_Other_PoDate
        '
        Me.T_Other_PoDate.Location = New System.Drawing.Point(146, 12)
        Me.T_Other_PoDate.Name = "T_Other_PoDate"
        Me.T_Other_PoDate.Size = New System.Drawing.Size(182, 20)
        Me.T_Other_PoDate.StyleController = Me.LayoutControl4
        Me.T_Other_PoDate.TabIndex = 0
        '
        'T_Other_ReceiptStatus
        '
        Me.T_Other_ReceiptStatus.Location = New System.Drawing.Point(146, 60)
        Me.T_Other_ReceiptStatus.Name = "T_Other_ReceiptStatus"
        Me.T_Other_ReceiptStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.T_Other_ReceiptStatus.Properties.NullText = ""
        Me.T_Other_ReceiptStatus.Size = New System.Drawing.Size(182, 20)
        Me.T_Other_ReceiptStatus.StyleController = Me.LayoutControl4
        Me.T_Other_ReceiptStatus.TabIndex = 3
        '
        'T_Other_Term
        '
        Me.T_Other_Term.EditValue = "30"
        Me.T_Other_Term.Location = New System.Drawing.Point(146, 156)
        Me.T_Other_Term.Name = "T_Other_Term"
        Me.T_Other_Term.Size = New System.Drawing.Size(182, 20)
        Me.T_Other_Term.StyleController = Me.LayoutControl4
        Me.T_Other_Term.TabIndex = 7
        '
        'T_Other_Certificated
        '
        Me.T_Other_Certificated.Location = New System.Drawing.Point(146, 132)
        Me.T_Other_Certificated.Name = "T_Other_Certificated"
        Me.T_Other_Certificated.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.T_Other_Certificated.Properties.NullText = ""
        Me.T_Other_Certificated.Size = New System.Drawing.Size(182, 20)
        Me.T_Other_Certificated.StyleController = Me.LayoutControl4
        Me.T_Other_Certificated.TabIndex = 6
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup3.GroupBordersVisible = False
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem46, Me.EmptySpaceItem7, Me.LayoutControlItem47, Me.LayoutControlItem48, Me.LayoutControlItem49, Me.LayoutControlItem50, Me.LayoutControlItem51, Me.LayoutControlItem52, Me.LayoutControlItem53, Me.EmptySpaceItem8})
        Me.LayoutControlGroup3.Name = "Root"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1233, 222)
        Me.LayoutControlGroup3.TextVisible = False
        '
        'LayoutControlItem46
        '
        Me.LayoutControlItem46.Control = Me.T_Other_PoDate
        Me.LayoutControlItem46.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem46.Name = "LayoutControlItem46"
        Me.LayoutControlItem46.Size = New System.Drawing.Size(320, 24)
        Me.LayoutControlItem46.Text = "PO Date"
        Me.LayoutControlItem46.TextSize = New System.Drawing.Size(131, 13)
        '
        'EmptySpaceItem7
        '
        Me.EmptySpaceItem7.AllowHotTrack = False
        Me.EmptySpaceItem7.Location = New System.Drawing.Point(0, 192)
        Me.EmptySpaceItem7.Name = "EmptySpaceItem7"
        Me.EmptySpaceItem7.Size = New System.Drawing.Size(320, 10)
        Me.EmptySpaceItem7.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem47
        '
        Me.LayoutControlItem47.Control = Me.T_Other_Blanked
        Me.LayoutControlItem47.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem47.Name = "LayoutControlItem47"
        Me.LayoutControlItem47.Size = New System.Drawing.Size(320, 24)
        Me.LayoutControlItem47.Text = "Blanked PO Expiration Date"
        Me.LayoutControlItem47.TextSize = New System.Drawing.Size(131, 13)
        '
        'LayoutControlItem48
        '
        Me.LayoutControlItem48.Control = Me.T_Other_ReceiptStatus
        Me.LayoutControlItem48.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem48.Name = "LayoutControlItem48"
        Me.LayoutControlItem48.Size = New System.Drawing.Size(320, 24)
        Me.LayoutControlItem48.Text = "Receipt Status"
        Me.LayoutControlItem48.TextSize = New System.Drawing.Size(131, 13)
        '
        'LayoutControlItem49
        '
        Me.LayoutControlItem49.Control = Me.T_Other_LastReceived
        Me.LayoutControlItem49.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem49.Name = "LayoutControlItem49"
        Me.LayoutControlItem49.Size = New System.Drawing.Size(320, 24)
        Me.LayoutControlItem49.Text = "Last Received"
        Me.LayoutControlItem49.TextSize = New System.Drawing.Size(131, 13)
        '
        'LayoutControlItem50
        '
        Me.LayoutControlItem50.Control = Me.T_Other_PeriodClosed
        Me.LayoutControlItem50.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem50.Name = "LayoutControlItem50"
        Me.LayoutControlItem50.Size = New System.Drawing.Size(320, 24)
        Me.LayoutControlItem50.Text = "Period Closed"
        Me.LayoutControlItem50.TextSize = New System.Drawing.Size(131, 13)
        '
        'LayoutControlItem51
        '
        Me.LayoutControlItem51.Control = Me.T_Other_Certificated
        Me.LayoutControlItem51.Location = New System.Drawing.Point(0, 120)
        Me.LayoutControlItem51.Name = "LayoutControlItem51"
        Me.LayoutControlItem51.Size = New System.Drawing.Size(320, 24)
        Me.LayoutControlItem51.Text = "Certificated Of Compliance"
        Me.LayoutControlItem51.TextSize = New System.Drawing.Size(131, 13)
        '
        'LayoutControlItem52
        '
        Me.LayoutControlItem52.Control = Me.T_Other_Term
        Me.LayoutControlItem52.Location = New System.Drawing.Point(0, 144)
        Me.LayoutControlItem52.Name = "LayoutControlItem52"
        Me.LayoutControlItem52.Size = New System.Drawing.Size(320, 24)
        Me.LayoutControlItem52.Text = "Term"
        Me.LayoutControlItem52.TextSize = New System.Drawing.Size(131, 13)
        '
        'LayoutControlItem53
        '
        Me.LayoutControlItem53.Control = Me.T_Other_Buyer
        Me.LayoutControlItem53.Location = New System.Drawing.Point(0, 168)
        Me.LayoutControlItem53.Name = "LayoutControlItem53"
        Me.LayoutControlItem53.Size = New System.Drawing.Size(320, 24)
        Me.LayoutControlItem53.Text = "Buyer"
        Me.LayoutControlItem53.TextSize = New System.Drawing.Size(131, 13)
        '
        'EmptySpaceItem8
        '
        Me.EmptySpaceItem8.AllowHotTrack = False
        Me.EmptySpaceItem8.Location = New System.Drawing.Point(320, 0)
        Me.EmptySpaceItem8.Name = "EmptySpaceItem8"
        Me.EmptySpaceItem8.Size = New System.Drawing.Size(893, 202)
        Me.EmptySpaceItem8.TextSize = New System.Drawing.Size(0, 0)
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.GroupBox3)
        Me.TabPage5.Controls.Add(Me.GroupBox2)
        Me.TabPage5.Controls.Add(Me.GroupBox1)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Size = New System.Drawing.Size(1250, 413)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "Currency"
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Controls.Add(Me.Label13)
        Me.GroupBox3.Controls.Add(Me.TextEdit14)
        Me.GroupBox3.Controls.Add(Me.TextEdit15)
        Me.GroupBox3.Controls.Add(Me.TextEdit12)
        Me.GroupBox3.Controls.Add(Me.TextEdit13)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.TextEdit7)
        Me.GroupBox3.Controls.Add(Me.TextEdit8)
        Me.GroupBox3.Location = New System.Drawing.Point(16, 237)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(550, 85)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Currency Unit Equivalents"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(159, 48)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(13, 13)
        Me.Label12.TabIndex = 18
        Me.Label12.Text = "="
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(159, 22)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(13, 13)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = "="
        '
        'TextEdit14
        '
        Me.TextEdit14.Location = New System.Drawing.Point(372, 45)
        Me.TextEdit14.Name = "TextEdit14"
        Me.TextEdit14.Size = New System.Drawing.Size(75, 20)
        Me.TextEdit14.TabIndex = 16
        '
        'TextEdit15
        '
        Me.TextEdit15.Location = New System.Drawing.Point(372, 19)
        Me.TextEdit15.Name = "TextEdit15"
        Me.TextEdit15.Size = New System.Drawing.Size(75, 20)
        Me.TextEdit15.TabIndex = 15
        '
        'TextEdit12
        '
        Me.TextEdit12.Location = New System.Drawing.Point(191, 45)
        Me.TextEdit12.Name = "TextEdit12"
        Me.TextEdit12.Size = New System.Drawing.Size(175, 20)
        Me.TextEdit12.TabIndex = 14
        '
        'TextEdit13
        '
        Me.TextEdit13.Location = New System.Drawing.Point(191, 19)
        Me.TextEdit13.Name = "TextEdit13"
        Me.TextEdit13.Size = New System.Drawing.Size(175, 20)
        Me.TextEdit13.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 48)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(34, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "1.000"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(34, 13)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "1.000"
        '
        'TextEdit7
        '
        Me.TextEdit7.Location = New System.Drawing.Point(85, 45)
        Me.TextEdit7.Name = "TextEdit7"
        Me.TextEdit7.Size = New System.Drawing.Size(64, 20)
        Me.TextEdit7.TabIndex = 10
        '
        'TextEdit8
        '
        Me.TextEdit8.Location = New System.Drawing.Point(85, 19)
        Me.TextEdit8.Name = "TextEdit8"
        Me.TextEdit8.Size = New System.Drawing.Size(64, 20)
        Me.TextEdit8.TabIndex = 9
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.T_Rate_Reciprocal)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.T_Rate)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.T_Rate_EfektifDate)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.T_Rate_Type)
        Me.GroupBox2.Controls.Add(Me.T_Rate_BaseID)
        Me.GroupBox2.Controls.Add(Me.T_Rate_Multiply)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 105)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(550, 126)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Currency Exchange Rate"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(204, 81)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(84, 13)
        Me.Label9.TabIndex = 16
        Me.Label9.Text = "Rate Reciprocal"
        '
        'T_Rate_Reciprocal
        '
        Me.T_Rate_Reciprocal.Location = New System.Drawing.Point(294, 78)
        Me.T_Rate_Reciprocal.Name = "T_Rate_Reciprocal"
        Me.T_Rate_Reciprocal.Properties.DisplayFormat.FormatString = "n6"
        Me.T_Rate_Reciprocal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.T_Rate_Reciprocal.Size = New System.Drawing.Size(153, 20)
        Me.T_Rate_Reciprocal.TabIndex = 15
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(204, 55)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(30, 13)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Rate"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(204, 29)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(42, 13)
        Me.Label11.TabIndex = 13
        Me.Label11.Text = "Multiply"
        '
        'T_Rate
        '
        Me.T_Rate.Location = New System.Drawing.Point(294, 52)
        Me.T_Rate.Name = "T_Rate"
        Me.T_Rate.Properties.DisplayFormat.FormatString = "n6"
        Me.T_Rate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.T_Rate.Size = New System.Drawing.Size(153, 20)
        Me.T_Rate.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 85)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(63, 13)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Efektif Date"
        '
        'T_Rate_EfektifDate
        '
        Me.T_Rate_EfektifDate.Location = New System.Drawing.Point(85, 82)
        Me.T_Rate_EfektifDate.Name = "T_Rate_EfektifDate"
        Me.T_Rate_EfektifDate.Properties.DisplayFormat.FormatString = "d"
        Me.T_Rate_EfektifDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.T_Rate_EfektifDate.Properties.EditFormat.FormatString = "d"
        Me.T_Rate_EfektifDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.T_Rate_EfektifDate.Size = New System.Drawing.Size(100, 20)
        Me.T_Rate_EfektifDate.TabIndex = 9
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Rate Type"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 33)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Base ID"
        '
        'T_Rate_Type
        '
        Me.T_Rate_Type.Location = New System.Drawing.Point(85, 56)
        Me.T_Rate_Type.Name = "T_Rate_Type"
        Me.T_Rate_Type.Size = New System.Drawing.Size(100, 20)
        Me.T_Rate_Type.TabIndex = 6
        '
        'T_Rate_BaseID
        '
        Me.T_Rate_BaseID.Location = New System.Drawing.Point(85, 30)
        Me.T_Rate_BaseID.Name = "T_Rate_BaseID"
        Me.T_Rate_BaseID.Size = New System.Drawing.Size(100, 20)
        Me.T_Rate_BaseID.TabIndex = 5
        '
        'T_Rate_Multiply
        '
        Me.T_Rate_Multiply.Location = New System.Drawing.Point(294, 26)
        Me.T_Rate_Multiply.Name = "T_Rate_Multiply"
        Me.T_Rate_Multiply.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.T_Rate_Multiply.Properties.NullText = ""
        Me.T_Rate_Multiply.Properties.PopupSizeable = False
        Me.T_Rate_Multiply.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.T_Rate_Multiply.Size = New System.Drawing.Size(153, 20)
        Me.T_Rate_Multiply.TabIndex = 11
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.T_Curr_Symbol)
        Me.GroupBox1.Controls.Add(Me.T_Curr_Description)
        Me.GroupBox1.Controls.Add(Me.T_Curr_ID)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 15)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(550, 84)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Transaction Currency"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(252, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(41, 13)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Symbol"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Description"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "ID"
        '
        'T_Curr_Symbol
        '
        Me.T_Curr_Symbol.Location = New System.Drawing.Point(294, 20)
        Me.T_Curr_Symbol.Name = "T_Curr_Symbol"
        Me.T_Curr_Symbol.Size = New System.Drawing.Size(153, 20)
        Me.T_Curr_Symbol.TabIndex = 2
        '
        'T_Curr_Description
        '
        Me.T_Curr_Description.Location = New System.Drawing.Point(85, 45)
        Me.T_Curr_Description.Name = "T_Curr_Description"
        Me.T_Curr_Description.Size = New System.Drawing.Size(362, 20)
        Me.T_Curr_Description.TabIndex = 1
        '
        'T_Curr_ID
        '
        Me.T_Curr_ID.Location = New System.Drawing.Point(85, 19)
        Me.T_Curr_ID.Name = "T_Curr_ID"
        Me.T_Curr_ID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.T_Curr_ID.Size = New System.Drawing.Size(100, 20)
        Me.T_Curr_ID.TabIndex = 0
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.T_Note)
        Me.TabPage6.Location = New System.Drawing.Point(4, 22)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage6.Size = New System.Drawing.Size(1250, 413)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "Note"
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'T_Note
        '
        Me.T_Note.Location = New System.Drawing.Point(17, 19)
        Me.T_Note.Name = "T_Note"
        Me.T_Note.Size = New System.Drawing.Size(441, 173)
        Me.T_Note.TabIndex = 0
        '
        'Frm_Detail_PurchaseOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1277, 594)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "Frm_Detail_PurchaseOrder"
        Me.Text = "PR FORM"
        Me.Controls.SetChildIndex(Me.LayoutControl1, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.T_Blanket.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_DiscPersen.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_StatusPO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_VendorName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_ProjectID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_PONumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_POType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_PRNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_VendorID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Status.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Pajak.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_DiscountAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoAlternate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Qty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoUnitCost, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoExtendedCost, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoUnitWeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Reposite, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoExtendedWeight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoPurchaseFor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoUnitVolume, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoExtendedVolume, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoRequired.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoRequired, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoPromised.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoPromised, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoQtyMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoQtyMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoAction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoRcptStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoVoucherStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoIncl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoCAction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.T_ShippingComfirmto.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_ShippingFOB.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_ShippingShip.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_ShippingEmail.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_ShippingFax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_ShippingPhone.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_ShippingCountry.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_ShippingPostalCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_ShippingState.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_ShippingCity.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_ShippingAddress2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_ShippingAddress1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_ShippingAttention.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_ShippingName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_ShippingAddressType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_ShippingSiteId.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_ShippingCustomerID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_ShippingVendorID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_ShippingOtherAddressID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_ShippingCustomerAddress.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_ShippingVendorAddres.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem22, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem23, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem24, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem25, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem26, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem27, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem28, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem29, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem30, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem31, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem32, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem19, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl3.ResumeLayout(False)
        CType(Me.T_VI_Email.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_VI_Fax.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_VI_Phone.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_VI_Country.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_VI_Postal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_VI_State.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_VI_City.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_VI_Address2.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_VI_Address1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_VI_Attention.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_VI_Name.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_VI_AddresID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem34, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem36, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem37, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem39, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem40, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem41, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem42, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem43, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem44, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem45, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.LayoutControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl4.ResumeLayout(False)
        CType(Me.T_Other_Buyer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Other_PeriodClosed.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Other_LastReceived.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Other_Blanked.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Other_PoDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Other_ReceiptStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Other_Term.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Other_Certificated.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem46, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem47, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem48, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem49, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem50, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem51, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem52, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem53, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage5.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.TextEdit14.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit15.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit12.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit13.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit7.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit8.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.T_Rate_Reciprocal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Rate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Rate_EfektifDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Rate_Type.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Rate_BaseID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Rate_Multiply.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.T_Curr_Symbol.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Curr_Description.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Curr_ID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage6.ResumeLayout(False)
        CType(Me.T_Note.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GridDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents T_PONumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents T_ProjectID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents T_POType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents T_PRNo As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents T_VendorName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_VendorID As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents T_Status As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents T_DiscPersen As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_StatusPO As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents T_Blanket As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents PRNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PRLineNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents AlternateID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents InventoryID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Description As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Quantity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents OUM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UnitCost As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ExtendedCost As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents StatusPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UnitWeight As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SiteID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ExtentedWeight As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PurchaseFor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UnitVolume As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ExtendedVolume As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Required As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Promised As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Account As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SubAccount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RcptQtyMin As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RcptQtyMax As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ReceiptAction As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ReceiptStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents VoucherStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IncludeInLeadTimeCalc As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents T_ShippingComfirmto As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_ShippingFOB As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_ShippingShip As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_ShippingEmail As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_ShippingFax As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_ShippingPhone As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_ShippingCountry As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_ShippingPostalCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_ShippingState As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_ShippingCity As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_ShippingAddress2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_ShippingAddress1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_ShippingAttention As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_ShippingName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem17 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem20 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem21 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem22 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem23 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem24 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem25 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem26 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem27 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem28 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem29 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem30 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem31 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem32 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem33 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem18 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem16 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem19 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl3 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents T_VI_Email As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_VI_Fax As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_VI_Phone As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_VI_Country As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_VI_Postal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_VI_State As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_VI_City As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_VI_Address2 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_VI_Address1 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_VI_Attention As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_VI_Name As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_VI_AddresID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem34 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem6 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem35 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem36 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem37 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem38 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem39 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem40 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem41 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem42 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem43 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem44 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem45 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl4 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents T_Other_Buyer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_Other_PeriodClosed As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_Other_LastReceived As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_Other_Blanked As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_Other_PoDate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem46 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem7 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem47 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem48 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem49 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem50 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem51 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem52 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem53 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents T_ShippingAddressType As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents T_ShippingSiteId As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents T_ShippingCustomerID As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents T_ShippingVendorID As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents T_ShippingOtherAddressID As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents T_ShippingCustomerAddress As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents T_ShippingVendorAddres As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Qty As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepoUnitCost As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents RepoExtendedCost As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents RepoUnitWeight As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents RepoExtendedWeight As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents RepoUnitVolume As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents RepoExtendedVolume As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents RepoQtyMin As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents RepoQtyMax As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents RepoRequired As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents RepoPromised As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents No As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XSeq As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoAlternate As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents T_Pajak As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents TabPage5 As TabPage
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents T_Curr_Symbol As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_Curr_Description As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit14 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit15 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit12 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit13 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents TextEdit7 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit8 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label9 As Label
    Friend WithEvents T_Rate_Reciprocal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents T_Rate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label6 As Label
    Friend WithEvents T_Rate_EfektifDate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents T_Rate_Type As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_Rate_BaseID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents T_Curr_ID As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents T_Other_ReceiptStatus As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents EmptySpaceItem8 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents T_Other_Term As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_Other_Certificated As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents TabPage6 As TabPage
    Friend WithEvents T_Rate_Multiply As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents RepoAction As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepoCAction As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents RepoRcptStatus As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepoVoucherStatus As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents Reposite As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents RepoPurchaseFor As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents Balance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PoQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PRQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents T_DiscountAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents RepoIncl As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents T_Note As DevExpress.XtraEditors.MemoEdit
End Class
