﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Detail_PurchaseOrder
    Inherits TSMU.baseForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.T_Blanket = New DevExpress.XtraEditors.TextEdit()
        Me.T_DiscPersen = New DevExpress.XtraEditors.TextEdit()
        Me.T_DiscountAmount = New DevExpress.XtraEditors.TextEdit()
        Me.T_StatusPO = New DevExpress.XtraEditors.TextEdit()
        Me.T_Pajak = New DevExpress.XtraEditors.TextEdit()
        Me.T_VendorName = New DevExpress.XtraEditors.TextEdit()
        Me.TProjectID = New DevExpress.XtraEditors.TextEdit()
        Me.T_PONumber = New DevExpress.XtraEditors.TextEdit()
        Me.T_POType = New DevExpress.XtraEditors.LookUpEdit()
        Me.T_PRNo = New DevExpress.XtraEditors.ButtonEdit()
        Me.T_VendorID = New DevExpress.XtraEditors.ButtonEdit()
        Me.T_Status = New DevExpress.XtraEditors.LookUpEdit()
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
        Me.PRNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PRLineNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.AlternateManual = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.InventoryID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Description = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Quantity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OUM = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UnitCost = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ExtendedCost = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.StatusPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UnitWeight = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SiteID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ExtentedWeight = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PurchaseFor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.UnitVolume = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ExtendedVolume = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Required = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Promised = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Account = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SubAccount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RcptQtyMin = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RcptQtyMax = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ReceiptAction = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ReceiptStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.VoucherStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.IncludeInLeadTimeCalc = New DevExpress.XtraGrid.Columns.GridColumn()
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
        Me.TextEdit41 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit40 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit39 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit38 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit37 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit36 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit35 = New DevExpress.XtraEditors.TextEdit()
        Me.TextEdit34 = New DevExpress.XtraEditors.TextEdit()
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
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.T_Blanket.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_DiscPersen.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_DiscountAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_StatusPO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Pajak.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_VendorName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TProjectID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_PONumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_POType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_PRNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_VendorID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Status.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.TextEdit41.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit40.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit39.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit38.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit37.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit36.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit35.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextEdit34.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.T_Blanket)
        Me.LayoutControl1.Controls.Add(Me.T_DiscPersen)
        Me.LayoutControl1.Controls.Add(Me.T_DiscountAmount)
        Me.LayoutControl1.Controls.Add(Me.T_StatusPO)
        Me.LayoutControl1.Controls.Add(Me.T_Pajak)
        Me.LayoutControl1.Controls.Add(Me.T_VendorName)
        Me.LayoutControl1.Controls.Add(Me.TProjectID)
        Me.LayoutControl1.Controls.Add(Me.T_PONumber)
        Me.LayoutControl1.Controls.Add(Me.T_POType)
        Me.LayoutControl1.Controls.Add(Me.T_PRNo)
        Me.LayoutControl1.Controls.Add(Me.T_VendorID)
        Me.LayoutControl1.Controls.Add(Me.T_Status)
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
        'T_DiscountAmount
        '
        Me.T_DiscountAmount.Location = New System.Drawing.Point(865, 60)
        Me.T_DiscountAmount.Name = "T_DiscountAmount"
        Me.T_DiscountAmount.Size = New System.Drawing.Size(138, 20)
        Me.T_DiscountAmount.StyleController = Me.LayoutControl1
        Me.T_DiscountAmount.TabIndex = 11
        '
        'T_StatusPO
        '
        Me.T_StatusPO.Location = New System.Drawing.Point(404, 60)
        Me.T_StatusPO.Name = "T_StatusPO"
        Me.T_StatusPO.Size = New System.Drawing.Size(359, 20)
        Me.T_StatusPO.StyleController = Me.LayoutControl1
        Me.T_StatusPO.TabIndex = 10
        '
        'T_Pajak
        '
        Me.T_Pajak.Location = New System.Drawing.Point(110, 60)
        Me.T_Pajak.Name = "T_Pajak"
        Me.T_Pajak.Size = New System.Drawing.Size(192, 20)
        Me.T_Pajak.StyleController = Me.LayoutControl1
        Me.T_Pajak.TabIndex = 9
        '
        'T_VendorName
        '
        Me.T_VendorName.Location = New System.Drawing.Point(404, 36)
        Me.T_VendorName.Name = "T_VendorName"
        Me.T_VendorName.Size = New System.Drawing.Size(359, 20)
        Me.T_VendorName.StyleController = Me.LayoutControl1
        Me.T_VendorName.TabIndex = 6
        '
        'TProjectID
        '
        Me.TProjectID.Location = New System.Drawing.Point(1105, 12)
        Me.TProjectID.Name = "TProjectID"
        Me.TProjectID.Size = New System.Drawing.Size(160, 20)
        Me.TProjectID.StyleController = Me.LayoutControl1
        Me.TProjectID.TabIndex = 4
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
        Me.LayoutControlItem6.Control = Me.TProjectID
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
        Me.GridDetail.Location = New System.Drawing.Point(6, 3)
        Me.GridDetail.MainView = Me.GridView1
        Me.GridDetail.Name = "GridDetail"
        Me.GridDetail.Size = New System.Drawing.Size(1238, 377)
        Me.GridDetail.TabIndex = 2
        Me.GridDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.PRNo, Me.PRLineNo, Me.AlternateManual, Me.InventoryID, Me.Description, Me.Quantity, Me.OUM, Me.UnitCost, Me.ExtendedCost, Me.StatusPrice, Me.UnitWeight, Me.SiteID, Me.ExtentedWeight, Me.PurchaseFor, Me.UnitVolume, Me.ExtendedVolume, Me.Required, Me.Promised, Me.Account, Me.SubAccount, Me.RcptQtyMin, Me.RcptQtyMax, Me.ReceiptAction, Me.ReceiptStatus, Me.VoucherStatus, Me.IncludeInLeadTimeCalc})
        Me.GridView1.GridControl = Me.GridDetail
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'PRNo
        '
        Me.PRNo.FieldName = "PR No"
        Me.PRNo.Name = "PRNo"
        Me.PRNo.Visible = True
        Me.PRNo.VisibleIndex = 0
        Me.PRNo.Width = 92
        '
        'PRLineNo
        '
        Me.PRLineNo.FieldName = "PR Line No"
        Me.PRLineNo.Name = "PRLineNo"
        Me.PRLineNo.Visible = True
        Me.PRLineNo.VisibleIndex = 1
        Me.PRLineNo.Width = 94
        '
        'AlternateManual
        '
        Me.AlternateManual.FieldName = "Alternate Manual"
        Me.AlternateManual.Name = "AlternateManual"
        Me.AlternateManual.Visible = True
        Me.AlternateManual.VisibleIndex = 2
        Me.AlternateManual.Width = 90
        '
        'InventoryID
        '
        Me.InventoryID.FieldName = "Inventory ID"
        Me.InventoryID.Name = "InventoryID"
        Me.InventoryID.Visible = True
        Me.InventoryID.VisibleIndex = 3
        '
        'Description
        '
        Me.Description.FieldName = "Description"
        Me.Description.Name = "Description"
        Me.Description.Visible = True
        Me.Description.VisibleIndex = 4
        Me.Description.Width = 80
        '
        'Quantity
        '
        Me.Quantity.FieldName = "Quantity"
        Me.Quantity.Name = "Quantity"
        Me.Quantity.Visible = True
        Me.Quantity.VisibleIndex = 5
        Me.Quantity.Width = 72
        '
        'OUM
        '
        Me.OUM.FieldName = "OUM"
        Me.OUM.Name = "OUM"
        Me.OUM.Visible = True
        Me.OUM.VisibleIndex = 6
        Me.OUM.Width = 90
        '
        'UnitCost
        '
        Me.UnitCost.FieldName = "Unit Cost"
        Me.UnitCost.Name = "UnitCost"
        Me.UnitCost.Visible = True
        Me.UnitCost.VisibleIndex = 7
        Me.UnitCost.Width = 70
        '
        'ExtendedCost
        '
        Me.ExtendedCost.FieldName = "Extended Cost"
        Me.ExtendedCost.Name = "ExtendedCost"
        Me.ExtendedCost.Visible = True
        Me.ExtendedCost.VisibleIndex = 8
        Me.ExtendedCost.Width = 109
        '
        'StatusPrice
        '
        Me.StatusPrice.FieldName = "Status Price"
        Me.StatusPrice.Name = "StatusPrice"
        Me.StatusPrice.Visible = True
        Me.StatusPrice.VisibleIndex = 9
        Me.StatusPrice.Width = 72
        '
        'UnitWeight
        '
        Me.UnitWeight.FieldName = "Unit Weight"
        Me.UnitWeight.Name = "UnitWeight"
        Me.UnitWeight.Visible = True
        Me.UnitWeight.VisibleIndex = 10
        Me.UnitWeight.Width = 71
        '
        'SiteID
        '
        Me.SiteID.FieldName = "Site ID"
        Me.SiteID.Name = "SiteID"
        Me.SiteID.Visible = True
        Me.SiteID.VisibleIndex = 11
        Me.SiteID.Width = 68
        '
        'ExtentedWeight
        '
        Me.ExtentedWeight.FieldName = "Extented Weight"
        Me.ExtentedWeight.Name = "ExtentedWeight"
        Me.ExtentedWeight.Visible = True
        Me.ExtentedWeight.VisibleIndex = 12
        Me.ExtentedWeight.Width = 104
        '
        'PurchaseFor
        '
        Me.PurchaseFor.FieldName = "Purchase For"
        Me.PurchaseFor.Name = "PurchaseFor"
        Me.PurchaseFor.Visible = True
        Me.PurchaseFor.VisibleIndex = 13
        Me.PurchaseFor.Width = 74
        '
        'UnitVolume
        '
        Me.UnitVolume.FieldName = "Unit Volume"
        Me.UnitVolume.Name = "UnitVolume"
        Me.UnitVolume.Visible = True
        Me.UnitVolume.VisibleIndex = 14
        Me.UnitVolume.Width = 81
        '
        'ExtendedVolume
        '
        Me.ExtendedVolume.FieldName = "Extended Volume"
        Me.ExtendedVolume.Name = "ExtendedVolume"
        Me.ExtendedVolume.Visible = True
        Me.ExtendedVolume.VisibleIndex = 15
        Me.ExtendedVolume.Width = 125
        '
        'Required
        '
        Me.Required.FieldName = "Required"
        Me.Required.Name = "Required"
        Me.Required.Visible = True
        Me.Required.VisibleIndex = 16
        Me.Required.Width = 81
        '
        'Promised
        '
        Me.Promised.FieldName = "Promised"
        Me.Promised.Name = "Promised"
        Me.Promised.Visible = True
        Me.Promised.VisibleIndex = 17
        Me.Promised.Width = 77
        '
        'Account
        '
        Me.Account.FieldName = "Account"
        Me.Account.Name = "Account"
        Me.Account.Visible = True
        Me.Account.VisibleIndex = 18
        Me.Account.Width = 76
        '
        'SubAccount
        '
        Me.SubAccount.FieldName = "SubAccount"
        Me.SubAccount.Name = "SubAccount"
        Me.SubAccount.Visible = True
        Me.SubAccount.VisibleIndex = 19
        Me.SubAccount.Width = 79
        '
        'RcptQtyMin
        '
        Me.RcptQtyMin.FieldName = "Rcpt Qty Min%"
        Me.RcptQtyMin.Name = "RcptQtyMin"
        Me.RcptQtyMin.Visible = True
        Me.RcptQtyMin.VisibleIndex = 20
        Me.RcptQtyMin.Width = 114
        '
        'RcptQtyMax
        '
        Me.RcptQtyMax.FieldName = "Rcpt Qty Max%"
        Me.RcptQtyMax.Name = "RcptQtyMax"
        Me.RcptQtyMax.Visible = True
        Me.RcptQtyMax.VisibleIndex = 21
        Me.RcptQtyMax.Width = 89
        '
        'ReceiptAction
        '
        Me.ReceiptAction.FieldName = "Receipt Action"
        Me.ReceiptAction.Name = "ReceiptAction"
        Me.ReceiptAction.Visible = True
        Me.ReceiptAction.VisibleIndex = 22
        Me.ReceiptAction.Width = 82
        '
        'ReceiptStatus
        '
        Me.ReceiptStatus.FieldName = "Receipt Status"
        Me.ReceiptStatus.Name = "ReceiptStatus"
        Me.ReceiptStatus.Visible = True
        Me.ReceiptStatus.VisibleIndex = 23
        Me.ReceiptStatus.Width = 109
        '
        'VoucherStatus
        '
        Me.VoucherStatus.FieldName = "Voucher Status"
        Me.VoucherStatus.Name = "VoucherStatus"
        Me.VoucherStatus.Visible = True
        Me.VoucherStatus.VisibleIndex = 24
        Me.VoucherStatus.Width = 108
        '
        'IncludeInLeadTimeCalc
        '
        Me.IncludeInLeadTimeCalc.FieldName = "Include In Lead Time Calc"
        Me.IncludeInLeadTimeCalc.Name = "IncludeInLeadTimeCalc"
        Me.IncludeInLeadTimeCalc.Visible = True
        Me.IncludeInLeadTimeCalc.VisibleIndex = 25
        Me.IncludeInLeadTimeCalc.Width = 144
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
        Me.TabControl1.Location = New System.Drawing.Point(12, 143)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1258, 412)
        Me.TabControl1.TabIndex = 3
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GridDetail)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(1250, 386)
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
        Me.TabPage2.Size = New System.Drawing.Size(1250, 386)
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
        Me.TabPage3.Size = New System.Drawing.Size(1250, 386)
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
        Me.TabPage4.Size = New System.Drawing.Size(1250, 386)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Other Information"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'LayoutControl4
        '
        Me.LayoutControl4.Controls.Add(Me.TextEdit41)
        Me.LayoutControl4.Controls.Add(Me.TextEdit40)
        Me.LayoutControl4.Controls.Add(Me.TextEdit39)
        Me.LayoutControl4.Controls.Add(Me.TextEdit38)
        Me.LayoutControl4.Controls.Add(Me.TextEdit37)
        Me.LayoutControl4.Controls.Add(Me.TextEdit36)
        Me.LayoutControl4.Controls.Add(Me.TextEdit35)
        Me.LayoutControl4.Controls.Add(Me.TextEdit34)
        Me.LayoutControl4.Dock = System.Windows.Forms.DockStyle.Top
        Me.LayoutControl4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl4.Name = "LayoutControl4"
        Me.LayoutControl4.Root = Me.LayoutControlGroup3
        Me.LayoutControl4.Size = New System.Drawing.Size(1250, 242)
        Me.LayoutControl4.TabIndex = 0
        Me.LayoutControl4.Text = "LayoutControl4"
        '
        'TextEdit41
        '
        Me.TextEdit41.Location = New System.Drawing.Point(146, 180)
        Me.TextEdit41.Name = "TextEdit41"
        Me.TextEdit41.Size = New System.Drawing.Size(1092, 20)
        Me.TextEdit41.StyleController = Me.LayoutControl4
        Me.TextEdit41.TabIndex = 8
        '
        'TextEdit40
        '
        Me.TextEdit40.Location = New System.Drawing.Point(146, 156)
        Me.TextEdit40.Name = "TextEdit40"
        Me.TextEdit40.Size = New System.Drawing.Size(1092, 20)
        Me.TextEdit40.StyleController = Me.LayoutControl4
        Me.TextEdit40.TabIndex = 7
        '
        'TextEdit39
        '
        Me.TextEdit39.Location = New System.Drawing.Point(146, 132)
        Me.TextEdit39.Name = "TextEdit39"
        Me.TextEdit39.Size = New System.Drawing.Size(1092, 20)
        Me.TextEdit39.StyleController = Me.LayoutControl4
        Me.TextEdit39.TabIndex = 6
        '
        'TextEdit38
        '
        Me.TextEdit38.Location = New System.Drawing.Point(146, 108)
        Me.TextEdit38.Name = "TextEdit38"
        Me.TextEdit38.Size = New System.Drawing.Size(1092, 20)
        Me.TextEdit38.StyleController = Me.LayoutControl4
        Me.TextEdit38.TabIndex = 5
        '
        'TextEdit37
        '
        Me.TextEdit37.Location = New System.Drawing.Point(146, 84)
        Me.TextEdit37.Name = "TextEdit37"
        Me.TextEdit37.Size = New System.Drawing.Size(1092, 20)
        Me.TextEdit37.StyleController = Me.LayoutControl4
        Me.TextEdit37.TabIndex = 4
        '
        'TextEdit36
        '
        Me.TextEdit36.Location = New System.Drawing.Point(146, 60)
        Me.TextEdit36.Name = "TextEdit36"
        Me.TextEdit36.Size = New System.Drawing.Size(1092, 20)
        Me.TextEdit36.StyleController = Me.LayoutControl4
        Me.TextEdit36.TabIndex = 3
        '
        'TextEdit35
        '
        Me.TextEdit35.Location = New System.Drawing.Point(146, 36)
        Me.TextEdit35.Name = "TextEdit35"
        Me.TextEdit35.Size = New System.Drawing.Size(1092, 20)
        Me.TextEdit35.StyleController = Me.LayoutControl4
        Me.TextEdit35.TabIndex = 2
        '
        'TextEdit34
        '
        Me.TextEdit34.Location = New System.Drawing.Point(146, 12)
        Me.TextEdit34.Name = "TextEdit34"
        Me.TextEdit34.Size = New System.Drawing.Size(1092, 20)
        Me.TextEdit34.StyleController = Me.LayoutControl4
        Me.TextEdit34.TabIndex = 0
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup3.GroupBordersVisible = False
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem46, Me.EmptySpaceItem7, Me.LayoutControlItem47, Me.LayoutControlItem48, Me.LayoutControlItem49, Me.LayoutControlItem50, Me.LayoutControlItem51, Me.LayoutControlItem52, Me.LayoutControlItem53})
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1250, 242)
        Me.LayoutControlGroup3.TextVisible = False
        '
        'LayoutControlItem46
        '
        Me.LayoutControlItem46.Control = Me.TextEdit34
        Me.LayoutControlItem46.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem46.Name = "LayoutControlItem46"
        Me.LayoutControlItem46.Size = New System.Drawing.Size(1230, 24)
        Me.LayoutControlItem46.Text = "PO Date"
        Me.LayoutControlItem46.TextSize = New System.Drawing.Size(131, 13)
        '
        'EmptySpaceItem7
        '
        Me.EmptySpaceItem7.AllowHotTrack = False
        Me.EmptySpaceItem7.Location = New System.Drawing.Point(0, 192)
        Me.EmptySpaceItem7.Name = "EmptySpaceItem7"
        Me.EmptySpaceItem7.Size = New System.Drawing.Size(1230, 30)
        Me.EmptySpaceItem7.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem47
        '
        Me.LayoutControlItem47.Control = Me.TextEdit35
        Me.LayoutControlItem47.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem47.Name = "LayoutControlItem47"
        Me.LayoutControlItem47.Size = New System.Drawing.Size(1230, 24)
        Me.LayoutControlItem47.Text = "Blanked PO Expiration Date"
        Me.LayoutControlItem47.TextSize = New System.Drawing.Size(131, 13)
        '
        'LayoutControlItem48
        '
        Me.LayoutControlItem48.Control = Me.TextEdit36
        Me.LayoutControlItem48.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem48.Name = "LayoutControlItem48"
        Me.LayoutControlItem48.Size = New System.Drawing.Size(1230, 24)
        Me.LayoutControlItem48.Text = "Receipt Status"
        Me.LayoutControlItem48.TextSize = New System.Drawing.Size(131, 13)
        '
        'LayoutControlItem49
        '
        Me.LayoutControlItem49.Control = Me.TextEdit37
        Me.LayoutControlItem49.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem49.Name = "LayoutControlItem49"
        Me.LayoutControlItem49.Size = New System.Drawing.Size(1230, 24)
        Me.LayoutControlItem49.Text = "Last Received"
        Me.LayoutControlItem49.TextSize = New System.Drawing.Size(131, 13)
        '
        'LayoutControlItem50
        '
        Me.LayoutControlItem50.Control = Me.TextEdit38
        Me.LayoutControlItem50.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem50.Name = "LayoutControlItem50"
        Me.LayoutControlItem50.Size = New System.Drawing.Size(1230, 24)
        Me.LayoutControlItem50.Text = "Period Closed"
        Me.LayoutControlItem50.TextSize = New System.Drawing.Size(131, 13)
        '
        'LayoutControlItem51
        '
        Me.LayoutControlItem51.Control = Me.TextEdit39
        Me.LayoutControlItem51.Location = New System.Drawing.Point(0, 120)
        Me.LayoutControlItem51.Name = "LayoutControlItem51"
        Me.LayoutControlItem51.Size = New System.Drawing.Size(1230, 24)
        Me.LayoutControlItem51.Text = "Certificated Of Compliance"
        Me.LayoutControlItem51.TextSize = New System.Drawing.Size(131, 13)
        '
        'LayoutControlItem52
        '
        Me.LayoutControlItem52.Control = Me.TextEdit40
        Me.LayoutControlItem52.Location = New System.Drawing.Point(0, 144)
        Me.LayoutControlItem52.Name = "LayoutControlItem52"
        Me.LayoutControlItem52.Size = New System.Drawing.Size(1230, 24)
        Me.LayoutControlItem52.Text = "Term"
        Me.LayoutControlItem52.TextSize = New System.Drawing.Size(131, 13)
        '
        'LayoutControlItem53
        '
        Me.LayoutControlItem53.Control = Me.TextEdit41
        Me.LayoutControlItem53.Location = New System.Drawing.Point(0, 168)
        Me.LayoutControlItem53.Name = "LayoutControlItem53"
        Me.LayoutControlItem53.Size = New System.Drawing.Size(1230, 24)
        Me.LayoutControlItem53.Text = "Buyer"
        Me.LayoutControlItem53.TextSize = New System.Drawing.Size(131, 13)
        '
        'Frm_Detail_PurchaseOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1277, 567)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "Frm_Detail_PurchaseOrder"
        Me.Controls.SetChildIndex(Me.LayoutControl1, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.T_Blanket.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_DiscPersen.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_DiscountAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_StatusPO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Pajak.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_VendorName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TProjectID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_PONumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_POType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_PRNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_VendorID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Status.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.TextEdit41.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit40.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit39.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit38.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit37.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit36.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit35.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextEdit34.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents TProjectID As DevExpress.XtraEditors.TextEdit
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
    Friend WithEvents T_DiscountAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_StatusPO As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_Pajak As DevExpress.XtraEditors.TextEdit
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
    Friend WithEvents AlternateManual As DevExpress.XtraGrid.Columns.GridColumn
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
    Friend WithEvents TextEdit41 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit40 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit39 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit38 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit37 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit36 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit35 As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TextEdit34 As DevExpress.XtraEditors.TextEdit
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
End Class