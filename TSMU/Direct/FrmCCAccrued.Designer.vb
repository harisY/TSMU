﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCCAccrued
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
        Me.GridAccrued = New DevExpress.XtraGrid.GridControl()
        Me.GridViewAccrued = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GCreditCardNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CCreditCardNumber = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GAccountName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GBankName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GTanggalTransaksi = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GNoTransaksi = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSeq = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAccountID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GJenisTransaksi = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GCurryID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAmount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.AccrualEstimate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAmountIDR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CAmountIDR = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.btnProses = New DevExpress.XtraEditors.SimpleButton()
        Me.txtCCNumber = New DevExpress.XtraEditors.ButtonEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.TabPageProses = New DevExpress.XtraTab.XtraTabPage()
        Me.TableLayoutPanel2 = New System.Windows.Forms.TableLayoutPanel()
        Me.LayoutControl6 = New DevExpress.XtraLayout.LayoutControl()
        Me.GroupControl2 = New DevExpress.XtraEditors.GroupControl()
        Me.LayoutControlGroup5 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl7 = New DevExpress.XtraLayout.LayoutControl()
        Me.GroupControl1 = New DevExpress.XtraEditors.GroupControl()
        Me.GridSumAccrued = New DevExpress.XtraGrid.GridControl()
        Me.GridViewSumAccrued = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SumAmountOriUSD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SumAmountOriYEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SumAmountOriIDR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SumAccrualEstimateProses = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SumAmountIDR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControlGroup6 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TabPageCancel = New DevExpress.XtraTab.XtraTabPage()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LayoutControl3 = New DevExpress.XtraLayout.LayoutControl()
        Me.btnCancel = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControl4 = New DevExpress.XtraLayout.LayoutControl()
        Me.GroupControl6 = New DevExpress.XtraEditors.GroupControl()
        Me.GridAccruedAll = New DevExpress.XtraGrid.GridControl()
        Me.GridViewAccruedAll = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NoAccruedSetle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TanggalSettle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CCNumberMasterSettle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CreditCardNumberSettle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.AccountNameSettle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BankNameSettle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TanggalTransSette = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NoTransaksiSettle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.JenisTransaksiSettle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CurryIDSettle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Amount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.AccrualEstimateSettle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RateSettle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.AmountIDRSettle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.IDSettle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SeqSettle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DescriptionSettle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PaySettle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControlGroup3 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.GroupControl3 = New DevExpress.XtraEditors.GroupControl()
        Me.GridSumSettle = New DevExpress.XtraGrid.GridControl()
        Me.GridViewSumSettle = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.SumAmountOriUSDSettle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SumAmountOriYENSettle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SumAmountOriIDRSettle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SumAccrualEstimateSettle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SumAmountIDRSettle = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.TabPagePaid = New DevExpress.XtraTab.XtraTabPage()
        Me.TableLayoutPanel3 = New System.Windows.Forms.TableLayoutPanel()
        Me.LayoutControl5 = New DevExpress.XtraLayout.LayoutControl()
        Me.GroupControl4 = New DevExpress.XtraEditors.GroupControl()
        Me.GridAccruedPaid = New DevExpress.XtraGrid.GridControl()
        Me.GridViewAccruedPaid = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControlGroup4 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl8 = New DevExpress.XtraLayout.LayoutControl()
        Me.GroupControl5 = New DevExpress.XtraEditors.GroupControl()
        Me.GridSumPaid = New DevExpress.XtraGrid.GridControl()
        Me.GridViewSumPaid = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControlGroup7 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.CCCNumberMaster = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.CCCNumber = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.CCNumberMasterPaid = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.CCCNumberPaid = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        CType(Me.GridAccrued, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewAccrued, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CCreditCardNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CAmountIDR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtCCNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.TabPageProses.SuspendLayout()
        Me.TableLayoutPanel2.SuspendLayout()
        CType(Me.LayoutControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl6.SuspendLayout()
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl2.SuspendLayout()
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl7, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl7.SuspendLayout()
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl1.SuspendLayout()
        CType(Me.GridSumAccrued, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewSumAccrued, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageCancel.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl3.SuspendLayout()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl4.SuspendLayout()
        CType(Me.GroupControl6, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl6.SuspendLayout()
        CType(Me.GridAccruedAll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewAccruedAll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl3.SuspendLayout()
        CType(Me.GridSumSettle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewSumSettle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPagePaid.SuspendLayout()
        Me.TableLayoutPanel3.SuspendLayout()
        CType(Me.LayoutControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl5.SuspendLayout()
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl4.SuspendLayout()
        CType(Me.GridAccruedPaid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewAccruedPaid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl8.SuspendLayout()
        CType(Me.GroupControl5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupControl5.SuspendLayout()
        CType(Me.GridSumPaid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewSumPaid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CCCNumberMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CCCNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CCNumberMasterPaid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CCCNumberPaid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridAccrued
        '
        Me.GridAccrued.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridAccrued.Location = New System.Drawing.Point(2, 26)
        Me.GridAccrued.MainView = Me.GridViewAccrued
        Me.GridAccrued.Name = "GridAccrued"
        Me.GridAccrued.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CAmountIDR, Me.CCreditCardNumber})
        Me.GridAccrued.Size = New System.Drawing.Size(1012, 296)
        Me.GridAccrued.TabIndex = 1
        Me.GridAccrued.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewAccrued})
        '
        'GridViewAccrued
        '
        Me.GridViewAccrued.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GCreditCardNumber, Me.GAccountName, Me.GBankName, Me.GTanggalTransaksi, Me.GNoTransaksi, Me.GSeq, Me.GAccountID, Me.GJenisTransaksi, Me.GDescription, Me.GCurryID, Me.GAmount, Me.AccrualEstimate, Me.GRate, Me.GAmountIDR})
        Me.GridViewAccrued.GridControl = Me.GridAccrued
        Me.GridViewAccrued.Name = "GridViewAccrued"
        Me.GridViewAccrued.OptionsBehavior.Editable = False
        Me.GridViewAccrued.OptionsSelection.MultiSelect = True
        Me.GridViewAccrued.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.GridViewAccrued.OptionsView.ShowGroupPanel = False
        '
        'GCreditCardNumber
        '
        Me.GCreditCardNumber.Caption = "Credit Card Number"
        Me.GCreditCardNumber.ColumnEdit = Me.CCreditCardNumber
        Me.GCreditCardNumber.DisplayFormat.FormatString = "0000-0000-0000-9999"
        Me.GCreditCardNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.GCreditCardNumber.FieldName = "CreditCardNumber"
        Me.GCreditCardNumber.MinWidth = 25
        Me.GCreditCardNumber.Name = "GCreditCardNumber"
        Me.GCreditCardNumber.OptionsColumn.AllowEdit = False
        Me.GCreditCardNumber.OptionsColumn.FixedWidth = True
        Me.GCreditCardNumber.Visible = True
        Me.GCreditCardNumber.VisibleIndex = 1
        Me.GCreditCardNumber.Width = 180
        '
        'CCreditCardNumber
        '
        Me.CCreditCardNumber.AutoHeight = False
        Me.CCreditCardNumber.Mask.EditMask = "0000-0000-0000-9999"
        Me.CCreditCardNumber.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple
        Me.CCreditCardNumber.Mask.UseMaskAsDisplayFormat = True
        Me.CCreditCardNumber.Name = "CCreditCardNumber"
        '
        'GAccountName
        '
        Me.GAccountName.Caption = "Account Name"
        Me.GAccountName.FieldName = "AccountName"
        Me.GAccountName.MinWidth = 25
        Me.GAccountName.Name = "GAccountName"
        Me.GAccountName.OptionsColumn.AllowEdit = False
        Me.GAccountName.OptionsColumn.FixedWidth = True
        Me.GAccountName.Visible = True
        Me.GAccountName.VisibleIndex = 2
        Me.GAccountName.Width = 210
        '
        'GBankName
        '
        Me.GBankName.Caption = "Bank Name"
        Me.GBankName.FieldName = "BankName"
        Me.GBankName.MinWidth = 25
        Me.GBankName.Name = "GBankName"
        Me.GBankName.OptionsColumn.AllowEdit = False
        Me.GBankName.OptionsColumn.FixedWidth = True
        Me.GBankName.Visible = True
        Me.GBankName.VisibleIndex = 3
        Me.GBankName.Width = 130
        '
        'GTanggalTransaksi
        '
        Me.GTanggalTransaksi.Caption = "Tanggal Transaksi"
        Me.GTanggalTransaksi.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.GTanggalTransaksi.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GTanggalTransaksi.FieldName = "TanggalTransaksi"
        Me.GTanggalTransaksi.MinWidth = 25
        Me.GTanggalTransaksi.Name = "GTanggalTransaksi"
        Me.GTanggalTransaksi.OptionsColumn.AllowEdit = False
        Me.GTanggalTransaksi.OptionsColumn.FixedWidth = True
        Me.GTanggalTransaksi.Visible = True
        Me.GTanggalTransaksi.VisibleIndex = 4
        Me.GTanggalTransaksi.Width = 140
        '
        'GNoTransaksi
        '
        Me.GNoTransaksi.Caption = "No Transaksi"
        Me.GNoTransaksi.FieldName = "NoTransaksi"
        Me.GNoTransaksi.MinWidth = 25
        Me.GNoTransaksi.Name = "GNoTransaksi"
        Me.GNoTransaksi.OptionsColumn.AllowEdit = False
        Me.GNoTransaksi.OptionsColumn.FixedWidth = True
        Me.GNoTransaksi.Visible = True
        Me.GNoTransaksi.VisibleIndex = 5
        Me.GNoTransaksi.Width = 140
        '
        'GSeq
        '
        Me.GSeq.Caption = "Seq"
        Me.GSeq.FieldName = "Seq"
        Me.GSeq.MinWidth = 25
        Me.GSeq.Name = "GSeq"
        Me.GSeq.OptionsColumn.AllowEdit = False
        Me.GSeq.OptionsColumn.FixedWidth = True
        Me.GSeq.Width = 94
        '
        'GAccountID
        '
        Me.GAccountID.Caption = "Account"
        Me.GAccountID.FieldName = "Account"
        Me.GAccountID.MinWidth = 25
        Me.GAccountID.Name = "GAccountID"
        Me.GAccountID.OptionsColumn.FixedWidth = True
        Me.GAccountID.Visible = True
        Me.GAccountID.VisibleIndex = 6
        Me.GAccountID.Width = 80
        '
        'GJenisTransaksi
        '
        Me.GJenisTransaksi.Caption = "Jenis Transaksi"
        Me.GJenisTransaksi.FieldName = "JenisTransaksi"
        Me.GJenisTransaksi.MinWidth = 25
        Me.GJenisTransaksi.Name = "GJenisTransaksi"
        Me.GJenisTransaksi.OptionsColumn.AllowEdit = False
        Me.GJenisTransaksi.OptionsColumn.FixedWidth = True
        Me.GJenisTransaksi.Visible = True
        Me.GJenisTransaksi.VisibleIndex = 7
        Me.GJenisTransaksi.Width = 120
        '
        'GDescription
        '
        Me.GDescription.Caption = "Description"
        Me.GDescription.FieldName = "Description"
        Me.GDescription.MinWidth = 25
        Me.GDescription.Name = "GDescription"
        Me.GDescription.OptionsColumn.AllowEdit = False
        Me.GDescription.Visible = True
        Me.GDescription.VisibleIndex = 8
        Me.GDescription.Width = 25
        '
        'GCurryID
        '
        Me.GCurryID.Caption = "Curry ID"
        Me.GCurryID.FieldName = "CurryID"
        Me.GCurryID.MinWidth = 25
        Me.GCurryID.Name = "GCurryID"
        Me.GCurryID.OptionsColumn.AllowEdit = False
        Me.GCurryID.OptionsColumn.FixedWidth = True
        Me.GCurryID.Visible = True
        Me.GCurryID.VisibleIndex = 9
        Me.GCurryID.Width = 70
        '
        'GAmount
        '
        Me.GAmount.Caption = "Amount Original"
        Me.GAmount.DisplayFormat.FormatString = "n2"
        Me.GAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAmount.FieldName = "Amount"
        Me.GAmount.MinWidth = 25
        Me.GAmount.Name = "GAmount"
        Me.GAmount.OptionsColumn.AllowEdit = False
        Me.GAmount.OptionsColumn.FixedWidth = True
        Me.GAmount.Visible = True
        Me.GAmount.VisibleIndex = 10
        Me.GAmount.Width = 140
        '
        'AccrualEstimate
        '
        Me.AccrualEstimate.Caption = "Acrual Estimate"
        Me.AccrualEstimate.DisplayFormat.FormatString = "n2"
        Me.AccrualEstimate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.AccrualEstimate.FieldName = "AccrualEstimate"
        Me.AccrualEstimate.MinWidth = 25
        Me.AccrualEstimate.Name = "AccrualEstimate"
        Me.AccrualEstimate.OptionsColumn.AllowEdit = False
        Me.AccrualEstimate.OptionsColumn.FixedWidth = True
        Me.AccrualEstimate.Visible = True
        Me.AccrualEstimate.VisibleIndex = 11
        Me.AccrualEstimate.Width = 140
        '
        'GRate
        '
        Me.GRate.Caption = "Exchange Rate"
        Me.GRate.DisplayFormat.FormatString = "n2"
        Me.GRate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GRate.FieldName = "Rate"
        Me.GRate.MinWidth = 25
        Me.GRate.Name = "GRate"
        Me.GRate.OptionsColumn.AllowEdit = False
        Me.GRate.OptionsColumn.FixedWidth = True
        Me.GRate.Visible = True
        Me.GRate.VisibleIndex = 12
        Me.GRate.Width = 120
        '
        'GAmountIDR
        '
        Me.GAmountIDR.Caption = "Settlement"
        Me.GAmountIDR.ColumnEdit = Me.CAmountIDR
        Me.GAmountIDR.DisplayFormat.FormatString = "n2"
        Me.GAmountIDR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAmountIDR.FieldName = "AmountIDR"
        Me.GAmountIDR.MinWidth = 25
        Me.GAmountIDR.Name = "GAmountIDR"
        Me.GAmountIDR.OptionsColumn.FixedWidth = True
        Me.GAmountIDR.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AmountIDR", "{0:#,##0.#0}")})
        Me.GAmountIDR.Visible = True
        Me.GAmountIDR.VisibleIndex = 13
        Me.GAmountIDR.Width = 140
        '
        'CAmountIDR
        '
        Me.CAmountIDR.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.CAmountIDR.AutoHeight = False
        Me.CAmountIDR.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CAmountIDR.DisplayFormat.FormatString = "n2"
        Me.CAmountIDR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.CAmountIDR.EditFormat.FormatString = "n2"
        Me.CAmountIDR.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.CAmountIDR.Mask.EditMask = "n2"
        Me.CAmountIDR.Name = "CAmountIDR"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.btnProses)
        Me.LayoutControl1.Controls.Add(Me.txtCCNumber)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(3, 3)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(955, 0, 812, 500)
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(1040, 54)
        Me.LayoutControl1.TabIndex = 2
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'btnProses
        '
        Me.btnProses.Location = New System.Drawing.Point(12, 12)
        Me.btnProses.MaximumSize = New System.Drawing.Size(68, 0)
        Me.btnProses.Name = "btnProses"
        Me.btnProses.Size = New System.Drawing.Size(68, 27)
        Me.btnProses.StyleController = Me.LayoutControl1
        Me.btnProses.TabIndex = 4
        Me.btnProses.Text = "PROSES"
        '
        'txtCCNumber
        '
        Me.txtCCNumber.Location = New System.Drawing.Point(222, 12)
        Me.txtCCNumber.MaximumSize = New System.Drawing.Size(190, 0)
        Me.txtCCNumber.Name = "txtCCNumber"
        Me.txtCCNumber.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtCCNumber.Properties.DisplayFormat.FormatString = "0000-0000-0000-9999"
        Me.txtCCNumber.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.txtCCNumber.Properties.Mask.EditMask = "0000-0000-0000-9999"
        Me.txtCCNumber.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple
        Me.txtCCNumber.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtCCNumber.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txtCCNumber.Size = New System.Drawing.Size(190, 22)
        Me.txtCCNumber.StyleController = Me.LayoutControl1
        Me.txtCCNumber.TabIndex = 6
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.EmptySpaceItem2, Me.LayoutControlItem6})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(1040, 54)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.btnProses
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(72, 34)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(404, 0)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(616, 34)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.txtCCNumber
        Me.LayoutControlItem6.Location = New System.Drawing.Point(72, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2)
        Me.LayoutControlItem6.Size = New System.Drawing.Size(332, 34)
        Me.LayoutControlItem6.Text = "Credit Card Number"
        Me.LayoutControlItem6.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(125, 20)
        Me.LayoutControlItem6.TextToControlDistance = 5
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 27)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.TabPageProses
        Me.XtraTabControl1.Size = New System.Drawing.Size(1053, 578)
        Me.XtraTabControl1.TabIndex = 3
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.TabPageProses, Me.TabPageCancel, Me.TabPagePaid})
        '
        'TabPageProses
        '
        Me.TabPageProses.Controls.Add(Me.TableLayoutPanel2)
        Me.TabPageProses.Name = "TabPageProses"
        Me.TabPageProses.Size = New System.Drawing.Size(1046, 544)
        Me.TabPageProses.Text = "Proses"
        '
        'TableLayoutPanel2
        '
        Me.TableLayoutPanel2.ColumnCount = 1
        Me.TableLayoutPanel2.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.Controls.Add(Me.LayoutControl1, 0, 0)
        Me.TableLayoutPanel2.Controls.Add(Me.LayoutControl6, 0, 1)
        Me.TableLayoutPanel2.Controls.Add(Me.LayoutControl7, 0, 2)
        Me.TableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel2.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel2.Name = "TableLayoutPanel2"
        Me.TableLayoutPanel2.RowCount = 3
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel2.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.TableLayoutPanel2.Size = New System.Drawing.Size(1046, 544)
        Me.TableLayoutPanel2.TabIndex = 0
        '
        'LayoutControl6
        '
        Me.LayoutControl6.Controls.Add(Me.GroupControl2)
        Me.LayoutControl6.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl6.Location = New System.Drawing.Point(3, 63)
        Me.LayoutControl6.Name = "LayoutControl6"
        Me.LayoutControl6.Root = Me.LayoutControlGroup5
        Me.LayoutControl6.Size = New System.Drawing.Size(1040, 348)
        Me.LayoutControl6.TabIndex = 4
        Me.LayoutControl6.Text = "LayoutControl6"
        '
        'GroupControl2
        '
        Me.GroupControl2.Controls.Add(Me.GridAccrued)
        Me.GroupControl2.GroupStyle = DevExpress.Utils.GroupStyle.Card
        Me.GroupControl2.Location = New System.Drawing.Point(12, 12)
        Me.GroupControl2.Name = "GroupControl2"
        Me.GroupControl2.Size = New System.Drawing.Size(1016, 324)
        Me.GroupControl2.TabIndex = 4
        Me.GroupControl2.Text = "Detail"
        '
        'LayoutControlGroup5
        '
        Me.LayoutControlGroup5.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup5.GroupBordersVisible = False
        Me.LayoutControlGroup5.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem7})
        Me.LayoutControlGroup5.Name = "LayoutControlGroup5"
        Me.LayoutControlGroup5.Size = New System.Drawing.Size(1040, 348)
        Me.LayoutControlGroup5.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.GroupControl2
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(1020, 328)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControl7
        '
        Me.LayoutControl7.Controls.Add(Me.GroupControl1)
        Me.LayoutControl7.Dock = System.Windows.Forms.DockStyle.Left
        Me.LayoutControl7.Location = New System.Drawing.Point(3, 417)
        Me.LayoutControl7.Name = "LayoutControl7"
        Me.LayoutControl7.Root = Me.LayoutControlGroup6
        Me.LayoutControl7.Size = New System.Drawing.Size(900, 124)
        Me.LayoutControl7.TabIndex = 5
        Me.LayoutControl7.Text = "LayoutControl7"
        '
        'GroupControl1
        '
        Me.GroupControl1.Controls.Add(Me.GridSumAccrued)
        Me.GroupControl1.GroupStyle = DevExpress.Utils.GroupStyle.Card
        Me.GroupControl1.Location = New System.Drawing.Point(12, 12)
        Me.GroupControl1.Name = "GroupControl1"
        Me.GroupControl1.Size = New System.Drawing.Size(876, 100)
        Me.GroupControl1.TabIndex = 4
        Me.GroupControl1.Text = "Summary"
        '
        'GridSumAccrued
        '
        Me.GridSumAccrued.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridSumAccrued.Location = New System.Drawing.Point(2, 26)
        Me.GridSumAccrued.MainView = Me.GridViewSumAccrued
        Me.GridSumAccrued.Name = "GridSumAccrued"
        Me.GridSumAccrued.Size = New System.Drawing.Size(872, 72)
        Me.GridSumAccrued.TabIndex = 4
        Me.GridSumAccrued.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewSumAccrued})
        '
        'GridViewSumAccrued
        '
        Me.GridViewSumAccrued.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.SumAmountOriUSD, Me.SumAmountOriYEN, Me.SumAmountOriIDR, Me.SumAccrualEstimateProses, Me.SumAmountIDR})
        Me.GridViewSumAccrued.GridControl = Me.GridSumAccrued
        Me.GridViewSumAccrued.Name = "GridViewSumAccrued"
        Me.GridViewSumAccrued.OptionsBehavior.Editable = False
        Me.GridViewSumAccrued.OptionsView.ShowGroupPanel = False
        '
        'SumAmountOriUSD
        '
        Me.SumAmountOriUSD.Caption = "Original USD"
        Me.SumAmountOriUSD.DisplayFormat.FormatString = "n2"
        Me.SumAmountOriUSD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.SumAmountOriUSD.FieldName = "SumAmountOriUSD"
        Me.SumAmountOriUSD.MinWidth = 25
        Me.SumAmountOriUSD.Name = "SumAmountOriUSD"
        Me.SumAmountOriUSD.Visible = True
        Me.SumAmountOriUSD.VisibleIndex = 0
        Me.SumAmountOriUSD.Width = 94
        '
        'SumAmountOriYEN
        '
        Me.SumAmountOriYEN.Caption = "Original YEN"
        Me.SumAmountOriYEN.DisplayFormat.FormatString = "n2"
        Me.SumAmountOriYEN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.SumAmountOriYEN.FieldName = "SumAmountOriYEN"
        Me.SumAmountOriYEN.MinWidth = 25
        Me.SumAmountOriYEN.Name = "SumAmountOriYEN"
        Me.SumAmountOriYEN.Visible = True
        Me.SumAmountOriYEN.VisibleIndex = 1
        Me.SumAmountOriYEN.Width = 94
        '
        'SumAmountOriIDR
        '
        Me.SumAmountOriIDR.Caption = "Original IDR"
        Me.SumAmountOriIDR.DisplayFormat.FormatString = "n2"
        Me.SumAmountOriIDR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.SumAmountOriIDR.FieldName = "SumAmountOriIDR"
        Me.SumAmountOriIDR.MinWidth = 25
        Me.SumAmountOriIDR.Name = "SumAmountOriIDR"
        Me.SumAmountOriIDR.Visible = True
        Me.SumAmountOriIDR.VisibleIndex = 2
        Me.SumAmountOriIDR.Width = 94
        '
        'SumAccrualEstimateProses
        '
        Me.SumAccrualEstimateProses.Caption = "Accrual Estimate"
        Me.SumAccrualEstimateProses.DisplayFormat.FormatString = "n2"
        Me.SumAccrualEstimateProses.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.SumAccrualEstimateProses.FieldName = "SumAccrualEstimate"
        Me.SumAccrualEstimateProses.MinWidth = 25
        Me.SumAccrualEstimateProses.Name = "SumAccrualEstimateProses"
        Me.SumAccrualEstimateProses.Visible = True
        Me.SumAccrualEstimateProses.VisibleIndex = 3
        Me.SumAccrualEstimateProses.Width = 94
        '
        'SumAmountIDR
        '
        Me.SumAmountIDR.Caption = "Settlement"
        Me.SumAmountIDR.DisplayFormat.FormatString = "n2"
        Me.SumAmountIDR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.SumAmountIDR.FieldName = "SumAmountIDR"
        Me.SumAmountIDR.MinWidth = 25
        Me.SumAmountIDR.Name = "SumAmountIDR"
        Me.SumAmountIDR.Visible = True
        Me.SumAmountIDR.VisibleIndex = 4
        Me.SumAmountIDR.Width = 94
        '
        'LayoutControlGroup6
        '
        Me.LayoutControlGroup6.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup6.GroupBordersVisible = False
        Me.LayoutControlGroup6.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem8})
        Me.LayoutControlGroup6.Name = "LayoutControlGroup6"
        Me.LayoutControlGroup6.Size = New System.Drawing.Size(900, 124)
        Me.LayoutControlGroup6.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.GroupControl1
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(880, 104)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'TabPageCancel
        '
        Me.TabPageCancel.Controls.Add(Me.TableLayoutPanel1)
        Me.TabPageCancel.Name = "TabPageCancel"
        Me.TabPageCancel.Size = New System.Drawing.Size(1046, 544)
        Me.TabPageCancel.Text = "Settlement"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LayoutControl3, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LayoutControl4, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LayoutControl2, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1046, 544)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'LayoutControl3
        '
        Me.LayoutControl3.Controls.Add(Me.btnCancel)
        Me.LayoutControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl3.Location = New System.Drawing.Point(3, 3)
        Me.LayoutControl3.Name = "LayoutControl3"
        Me.LayoutControl3.Root = Me.LayoutControlGroup2
        Me.LayoutControl3.Size = New System.Drawing.Size(1040, 54)
        Me.LayoutControl3.TabIndex = 0
        Me.LayoutControl3.Text = "LayoutControl3"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(12, 12)
        Me.btnCancel.MaximumSize = New System.Drawing.Size(90, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(90, 27)
        Me.btnCancel.StyleController = Me.LayoutControl3
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "CANCEL"
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem1})
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1040, 54)
        Me.LayoutControlGroup2.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.btnCancel
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(94, 34)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(94, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(926, 34)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControl4
        '
        Me.LayoutControl4.Controls.Add(Me.GroupControl6)
        Me.LayoutControl4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl4.Location = New System.Drawing.Point(3, 63)
        Me.LayoutControl4.Name = "LayoutControl4"
        Me.LayoutControl4.Root = Me.LayoutControlGroup3
        Me.LayoutControl4.Size = New System.Drawing.Size(1040, 348)
        Me.LayoutControl4.TabIndex = 1
        Me.LayoutControl4.Text = "LayoutControl4"
        '
        'GroupControl6
        '
        Me.GroupControl6.Controls.Add(Me.GridAccruedAll)
        Me.GroupControl6.Location = New System.Drawing.Point(12, 12)
        Me.GroupControl6.Name = "GroupControl6"
        Me.GroupControl6.Size = New System.Drawing.Size(1016, 324)
        Me.GroupControl6.TabIndex = 4
        Me.GroupControl6.Text = "Detail"
        '
        'GridAccruedAll
        '
        Me.GridAccruedAll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridAccruedAll.Location = New System.Drawing.Point(2, 26)
        Me.GridAccruedAll.MainView = Me.GridViewAccruedAll
        Me.GridAccruedAll.Name = "GridAccruedAll"
        Me.GridAccruedAll.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CCCNumberMaster, Me.CCCNumber})
        Me.GridAccruedAll.Size = New System.Drawing.Size(1012, 296)
        Me.GridAccruedAll.TabIndex = 4
        Me.GridAccruedAll.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewAccruedAll})
        '
        'GridViewAccruedAll
        '
        Me.GridViewAccruedAll.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.NoAccruedSetle, Me.TanggalSettle, Me.CCNumberMasterSettle, Me.CreditCardNumberSettle, Me.AccountNameSettle, Me.BankNameSettle, Me.TanggalTransSette, Me.NoTransaksiSettle, Me.JenisTransaksiSettle, Me.CurryIDSettle, Me.Amount, Me.AccrualEstimateSettle, Me.RateSettle, Me.AmountIDRSettle, Me.IDSettle, Me.SeqSettle, Me.DescriptionSettle, Me.PaySettle})
        Me.GridViewAccruedAll.GridControl = Me.GridAccruedAll
        Me.GridViewAccruedAll.Name = "GridViewAccruedAll"
        Me.GridViewAccruedAll.OptionsBehavior.Editable = False
        Me.GridViewAccruedAll.OptionsSelection.MultiSelect = True
        Me.GridViewAccruedAll.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.GridViewAccruedAll.OptionsView.ColumnAutoWidth = False
        Me.GridViewAccruedAll.OptionsView.ShowGroupPanel = False
        '
        'NoAccruedSetle
        '
        Me.NoAccruedSetle.Caption = "No Accrued"
        Me.NoAccruedSetle.FieldName = "NoAccrued"
        Me.NoAccruedSetle.MinWidth = 25
        Me.NoAccruedSetle.Name = "NoAccruedSetle"
        Me.NoAccruedSetle.Visible = True
        Me.NoAccruedSetle.VisibleIndex = 1
        Me.NoAccruedSetle.Width = 94
        '
        'TanggalSettle
        '
        Me.TanggalSettle.Caption = "Tanggal"
        Me.TanggalSettle.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.TanggalSettle.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TanggalSettle.FieldName = "Tanggal"
        Me.TanggalSettle.MinWidth = 25
        Me.TanggalSettle.Name = "TanggalSettle"
        Me.TanggalSettle.Visible = True
        Me.TanggalSettle.VisibleIndex = 2
        Me.TanggalSettle.Width = 94
        '
        'CCNumberMasterSettle
        '
        Me.CCNumberMasterSettle.Caption = "CC Number Master"
        Me.CCNumberMasterSettle.ColumnEdit = Me.CCCNumberMaster
        Me.CCNumberMasterSettle.DisplayFormat.FormatString = "0000-0000-0000-9999"
        Me.CCNumberMasterSettle.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.CCNumberMasterSettle.FieldName = "CCNumberMaster"
        Me.CCNumberMasterSettle.MinWidth = 25
        Me.CCNumberMasterSettle.Name = "CCNumberMasterSettle"
        Me.CCNumberMasterSettle.Visible = True
        Me.CCNumberMasterSettle.VisibleIndex = 3
        Me.CCNumberMasterSettle.Width = 94
        '
        'CreditCardNumberSettle
        '
        Me.CreditCardNumberSettle.Caption = "CC Number"
        Me.CreditCardNumberSettle.ColumnEdit = Me.CCCNumber
        Me.CreditCardNumberSettle.DisplayFormat.FormatString = "0000-0000-0000-9999"
        Me.CreditCardNumberSettle.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.CreditCardNumberSettle.FieldName = "CreditCardNumber"
        Me.CreditCardNumberSettle.MinWidth = 25
        Me.CreditCardNumberSettle.Name = "CreditCardNumberSettle"
        Me.CreditCardNumberSettle.Visible = True
        Me.CreditCardNumberSettle.VisibleIndex = 4
        Me.CreditCardNumberSettle.Width = 94
        '
        'AccountNameSettle
        '
        Me.AccountNameSettle.Caption = "Account Name"
        Me.AccountNameSettle.FieldName = "AccountName"
        Me.AccountNameSettle.MinWidth = 25
        Me.AccountNameSettle.Name = "AccountNameSettle"
        Me.AccountNameSettle.Visible = True
        Me.AccountNameSettle.VisibleIndex = 5
        Me.AccountNameSettle.Width = 94
        '
        'BankNameSettle
        '
        Me.BankNameSettle.Caption = "Bank Name"
        Me.BankNameSettle.FieldName = "BankName"
        Me.BankNameSettle.MinWidth = 25
        Me.BankNameSettle.Name = "BankNameSettle"
        Me.BankNameSettle.Visible = True
        Me.BankNameSettle.VisibleIndex = 6
        Me.BankNameSettle.Width = 94
        '
        'TanggalTransSette
        '
        Me.TanggalTransSette.Caption = "Tanggal Transaksi"
        Me.TanggalTransSette.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.TanggalTransSette.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TanggalTransSette.FieldName = "TanggalTrans"
        Me.TanggalTransSette.MinWidth = 25
        Me.TanggalTransSette.Name = "TanggalTransSette"
        Me.TanggalTransSette.Visible = True
        Me.TanggalTransSette.VisibleIndex = 7
        Me.TanggalTransSette.Width = 94
        '
        'NoTransaksiSettle
        '
        Me.NoTransaksiSettle.Caption = "No Transaksi"
        Me.NoTransaksiSettle.FieldName = "NoTransaksi"
        Me.NoTransaksiSettle.MinWidth = 25
        Me.NoTransaksiSettle.Name = "NoTransaksiSettle"
        Me.NoTransaksiSettle.Visible = True
        Me.NoTransaksiSettle.VisibleIndex = 8
        Me.NoTransaksiSettle.Width = 94
        '
        'JenisTransaksiSettle
        '
        Me.JenisTransaksiSettle.Caption = "Jenis Transaksi"
        Me.JenisTransaksiSettle.FieldName = "JenisTransaksi"
        Me.JenisTransaksiSettle.MinWidth = 25
        Me.JenisTransaksiSettle.Name = "JenisTransaksiSettle"
        Me.JenisTransaksiSettle.Visible = True
        Me.JenisTransaksiSettle.VisibleIndex = 9
        Me.JenisTransaksiSettle.Width = 94
        '
        'CurryIDSettle
        '
        Me.CurryIDSettle.Caption = "Curry ID"
        Me.CurryIDSettle.FieldName = "CurryID"
        Me.CurryIDSettle.MinWidth = 25
        Me.CurryIDSettle.Name = "CurryIDSettle"
        Me.CurryIDSettle.Visible = True
        Me.CurryIDSettle.VisibleIndex = 10
        Me.CurryIDSettle.Width = 94
        '
        'Amount
        '
        Me.Amount.Caption = "Amount Original"
        Me.Amount.DisplayFormat.FormatString = "n2"
        Me.Amount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Amount.FieldName = "Amount"
        Me.Amount.MinWidth = 25
        Me.Amount.Name = "Amount"
        Me.Amount.Visible = True
        Me.Amount.VisibleIndex = 11
        Me.Amount.Width = 94
        '
        'AccrualEstimateSettle
        '
        Me.AccrualEstimateSettle.Caption = "Accrual Estimate"
        Me.AccrualEstimateSettle.DisplayFormat.FormatString = "n2"
        Me.AccrualEstimateSettle.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.AccrualEstimateSettle.FieldName = "AccrualEstimate"
        Me.AccrualEstimateSettle.MinWidth = 25
        Me.AccrualEstimateSettle.Name = "AccrualEstimateSettle"
        Me.AccrualEstimateSettle.Visible = True
        Me.AccrualEstimateSettle.VisibleIndex = 12
        Me.AccrualEstimateSettle.Width = 94
        '
        'RateSettle
        '
        Me.RateSettle.Caption = "Rate"
        Me.RateSettle.DisplayFormat.FormatString = "n2"
        Me.RateSettle.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RateSettle.FieldName = "Rate"
        Me.RateSettle.MinWidth = 25
        Me.RateSettle.Name = "RateSettle"
        Me.RateSettle.Visible = True
        Me.RateSettle.VisibleIndex = 13
        Me.RateSettle.Width = 94
        '
        'AmountIDRSettle
        '
        Me.AmountIDRSettle.Caption = "Settlement"
        Me.AmountIDRSettle.DisplayFormat.FormatString = "n2"
        Me.AmountIDRSettle.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.AmountIDRSettle.FieldName = "AmountIDR"
        Me.AmountIDRSettle.MinWidth = 25
        Me.AmountIDRSettle.Name = "AmountIDRSettle"
        Me.AmountIDRSettle.Visible = True
        Me.AmountIDRSettle.VisibleIndex = 14
        Me.AmountIDRSettle.Width = 94
        '
        'IDSettle
        '
        Me.IDSettle.Caption = "ID"
        Me.IDSettle.FieldName = "ID"
        Me.IDSettle.MinWidth = 25
        Me.IDSettle.Name = "IDSettle"
        Me.IDSettle.Width = 94
        '
        'SeqSettle
        '
        Me.SeqSettle.Caption = "Seq"
        Me.SeqSettle.FieldName = "Seq"
        Me.SeqSettle.MinWidth = 25
        Me.SeqSettle.Name = "SeqSettle"
        Me.SeqSettle.Width = 94
        '
        'DescriptionSettle
        '
        Me.DescriptionSettle.Caption = "Description"
        Me.DescriptionSettle.FieldName = "Description"
        Me.DescriptionSettle.MinWidth = 25
        Me.DescriptionSettle.Name = "DescriptionSettle"
        Me.DescriptionSettle.Width = 94
        '
        'PaySettle
        '
        Me.PaySettle.Caption = "Pay"
        Me.PaySettle.FieldName = "Pay"
        Me.PaySettle.MinWidth = 25
        Me.PaySettle.Name = "PaySettle"
        Me.PaySettle.Width = 94
        '
        'LayoutControlGroup3
        '
        Me.LayoutControlGroup3.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup3.GroupBordersVisible = False
        Me.LayoutControlGroup3.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem4})
        Me.LayoutControlGroup3.Name = "LayoutControlGroup3"
        Me.LayoutControlGroup3.Size = New System.Drawing.Size(1040, 348)
        Me.LayoutControlGroup3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.GroupControl6
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(1020, 328)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.GroupControl3)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Left
        Me.LayoutControl2.Location = New System.Drawing.Point(3, 417)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.Root = Me.LayoutControlGroup1
        Me.LayoutControl2.Size = New System.Drawing.Size(900, 124)
        Me.LayoutControl2.TabIndex = 2
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'GroupControl3
        '
        Me.GroupControl3.Controls.Add(Me.GridSumSettle)
        Me.GroupControl3.GroupStyle = DevExpress.Utils.GroupStyle.Card
        Me.GroupControl3.Location = New System.Drawing.Point(12, 12)
        Me.GroupControl3.Name = "GroupControl3"
        Me.GroupControl3.Size = New System.Drawing.Size(876, 100)
        Me.GroupControl3.TabIndex = 5
        Me.GroupControl3.Text = "Summary"
        '
        'GridSumSettle
        '
        Me.GridSumSettle.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridSumSettle.Location = New System.Drawing.Point(2, 26)
        Me.GridSumSettle.MainView = Me.GridViewSumSettle
        Me.GridSumSettle.Name = "GridSumSettle"
        Me.GridSumSettle.Size = New System.Drawing.Size(872, 72)
        Me.GridSumSettle.TabIndex = 4
        Me.GridSumSettle.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewSumSettle})
        '
        'GridViewSumSettle
        '
        Me.GridViewSumSettle.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.SumAmountOriUSDSettle, Me.SumAmountOriYENSettle, Me.SumAmountOriIDRSettle, Me.SumAccrualEstimateSettle, Me.SumAmountIDRSettle})
        Me.GridViewSumSettle.GridControl = Me.GridSumSettle
        Me.GridViewSumSettle.Name = "GridViewSumSettle"
        Me.GridViewSumSettle.OptionsBehavior.Editable = False
        Me.GridViewSumSettle.OptionsView.ShowGroupPanel = False
        '
        'SumAmountOriUSDSettle
        '
        Me.SumAmountOriUSDSettle.Caption = "Original USD"
        Me.SumAmountOriUSDSettle.DisplayFormat.FormatString = "n2"
        Me.SumAmountOriUSDSettle.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.SumAmountOriUSDSettle.FieldName = "SumAmountOriUSD"
        Me.SumAmountOriUSDSettle.MinWidth = 25
        Me.SumAmountOriUSDSettle.Name = "SumAmountOriUSDSettle"
        Me.SumAmountOriUSDSettle.Visible = True
        Me.SumAmountOriUSDSettle.VisibleIndex = 0
        Me.SumAmountOriUSDSettle.Width = 94
        '
        'SumAmountOriYENSettle
        '
        Me.SumAmountOriYENSettle.Caption = "Original YEN"
        Me.SumAmountOriYENSettle.DisplayFormat.FormatString = "n2"
        Me.SumAmountOriYENSettle.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.SumAmountOriYENSettle.FieldName = "SumAmountOriYEN"
        Me.SumAmountOriYENSettle.MinWidth = 25
        Me.SumAmountOriYENSettle.Name = "SumAmountOriYENSettle"
        Me.SumAmountOriYENSettle.Visible = True
        Me.SumAmountOriYENSettle.VisibleIndex = 1
        Me.SumAmountOriYENSettle.Width = 94
        '
        'SumAmountOriIDRSettle
        '
        Me.SumAmountOriIDRSettle.Caption = "Original IDR"
        Me.SumAmountOriIDRSettle.DisplayFormat.FormatString = "n2"
        Me.SumAmountOriIDRSettle.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.SumAmountOriIDRSettle.FieldName = "SumAmountOriIDR"
        Me.SumAmountOriIDRSettle.MinWidth = 25
        Me.SumAmountOriIDRSettle.Name = "SumAmountOriIDRSettle"
        Me.SumAmountOriIDRSettle.Visible = True
        Me.SumAmountOriIDRSettle.VisibleIndex = 2
        Me.SumAmountOriIDRSettle.Width = 94
        '
        'SumAccrualEstimateSettle
        '
        Me.SumAccrualEstimateSettle.Caption = "Accrual Estimate"
        Me.SumAccrualEstimateSettle.DisplayFormat.FormatString = "n2"
        Me.SumAccrualEstimateSettle.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.SumAccrualEstimateSettle.FieldName = "SumAccrualEstimate"
        Me.SumAccrualEstimateSettle.MinWidth = 25
        Me.SumAccrualEstimateSettle.Name = "SumAccrualEstimateSettle"
        Me.SumAccrualEstimateSettle.Visible = True
        Me.SumAccrualEstimateSettle.VisibleIndex = 3
        Me.SumAccrualEstimateSettle.Width = 94
        '
        'SumAmountIDRSettle
        '
        Me.SumAmountIDRSettle.Caption = "Settlement"
        Me.SumAmountIDRSettle.DisplayFormat.FormatString = "n2"
        Me.SumAmountIDRSettle.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.SumAmountIDRSettle.FieldName = "SumAmountIDR"
        Me.SumAmountIDRSettle.MinWidth = 25
        Me.SumAmountIDRSettle.Name = "SumAmountIDRSettle"
        Me.SumAmountIDRSettle.Visible = True
        Me.SumAmountIDRSettle.VisibleIndex = 4
        Me.SumAmountIDRSettle.Width = 94
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(900, 124)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.GroupControl3
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(880, 104)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'TabPagePaid
        '
        Me.TabPagePaid.Controls.Add(Me.TableLayoutPanel3)
        Me.TabPagePaid.Name = "TabPagePaid"
        Me.TabPagePaid.Size = New System.Drawing.Size(1046, 544)
        Me.TabPagePaid.Text = "Paid"
        '
        'TableLayoutPanel3
        '
        Me.TableLayoutPanel3.ColumnCount = 1
        Me.TableLayoutPanel3.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.Controls.Add(Me.LayoutControl5, 0, 0)
        Me.TableLayoutPanel3.Controls.Add(Me.LayoutControl8, 0, 1)
        Me.TableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel3.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel3.Name = "TableLayoutPanel3"
        Me.TableLayoutPanel3.RowCount = 2
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel3.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130.0!))
        Me.TableLayoutPanel3.Size = New System.Drawing.Size(1046, 544)
        Me.TableLayoutPanel3.TabIndex = 1
        '
        'LayoutControl5
        '
        Me.LayoutControl5.Controls.Add(Me.GroupControl4)
        Me.LayoutControl5.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl5.Location = New System.Drawing.Point(3, 3)
        Me.LayoutControl5.Name = "LayoutControl5"
        Me.LayoutControl5.Root = Me.LayoutControlGroup4
        Me.LayoutControl5.Size = New System.Drawing.Size(1040, 408)
        Me.LayoutControl5.TabIndex = 0
        Me.LayoutControl5.Text = "LayoutControl5"
        '
        'GroupControl4
        '
        Me.GroupControl4.Controls.Add(Me.GridAccruedPaid)
        Me.GroupControl4.Location = New System.Drawing.Point(12, 12)
        Me.GroupControl4.Name = "GroupControl4"
        Me.GroupControl4.Size = New System.Drawing.Size(1016, 384)
        Me.GroupControl4.TabIndex = 4
        Me.GroupControl4.Text = "Detail"
        '
        'GridAccruedPaid
        '
        Me.GridAccruedPaid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridAccruedPaid.Location = New System.Drawing.Point(2, 26)
        Me.GridAccruedPaid.MainView = Me.GridViewAccruedPaid
        Me.GridAccruedPaid.Name = "GridAccruedPaid"
        Me.GridAccruedPaid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CCNumberMasterPaid, Me.CCCNumberPaid})
        Me.GridAccruedPaid.Size = New System.Drawing.Size(1012, 356)
        Me.GridAccruedPaid.TabIndex = 5
        Me.GridAccruedPaid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewAccruedPaid})
        '
        'GridViewAccruedPaid
        '
        Me.GridViewAccruedPaid.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18})
        Me.GridViewAccruedPaid.GridControl = Me.GridAccruedPaid
        Me.GridViewAccruedPaid.Name = "GridViewAccruedPaid"
        Me.GridViewAccruedPaid.OptionsBehavior.Editable = False
        Me.GridViewAccruedPaid.OptionsView.ColumnAutoWidth = False
        Me.GridViewAccruedPaid.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "No Accrued"
        Me.GridColumn1.FieldName = "NoAccrued"
        Me.GridColumn1.MinWidth = 25
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 94
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Tanggal"
        Me.GridColumn2.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.GridColumn2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn2.FieldName = "Tanggal"
        Me.GridColumn2.MinWidth = 25
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 94
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "CC Number Master"
        Me.GridColumn3.ColumnEdit = Me.CCNumberMasterPaid
        Me.GridColumn3.DisplayFormat.FormatString = "0000-0000-0000-9999"
        Me.GridColumn3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.GridColumn3.FieldName = "CCNumberMaster"
        Me.GridColumn3.MinWidth = 25
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        Me.GridColumn3.Width = 94
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "CC Number"
        Me.GridColumn4.ColumnEdit = Me.CCCNumberPaid
        Me.GridColumn4.DisplayFormat.FormatString = "0000-0000-0000-9999"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.GridColumn4.FieldName = "CreditCardNumber"
        Me.GridColumn4.MinWidth = 25
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        Me.GridColumn4.Width = 94
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Account Name"
        Me.GridColumn5.FieldName = "AccountName"
        Me.GridColumn5.MinWidth = 25
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 4
        Me.GridColumn5.Width = 94
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Bank Name"
        Me.GridColumn6.FieldName = "BankName"
        Me.GridColumn6.MinWidth = 25
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 5
        Me.GridColumn6.Width = 94
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Tanggal Transaksi"
        Me.GridColumn7.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.GridColumn7.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.GridColumn7.FieldName = "TanggalTrans"
        Me.GridColumn7.MinWidth = 25
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 6
        Me.GridColumn7.Width = 94
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "No Transaksi"
        Me.GridColumn8.FieldName = "NoTransaksi"
        Me.GridColumn8.MinWidth = 25
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 7
        Me.GridColumn8.Width = 94
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Jenis Transaksi"
        Me.GridColumn9.FieldName = "JenisTransaksi"
        Me.GridColumn9.MinWidth = 25
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 8
        Me.GridColumn9.Width = 94
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Curry ID"
        Me.GridColumn10.FieldName = "CurryID"
        Me.GridColumn10.MinWidth = 25
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 9
        Me.GridColumn10.Width = 94
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "Amount Original"
        Me.GridColumn11.DisplayFormat.FormatString = "n2"
        Me.GridColumn11.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn11.FieldName = "Amount"
        Me.GridColumn11.MinWidth = 25
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 10
        Me.GridColumn11.Width = 94
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Accrual Estimate"
        Me.GridColumn12.DisplayFormat.FormatString = "n2"
        Me.GridColumn12.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn12.FieldName = "AccrualEstimate"
        Me.GridColumn12.MinWidth = 25
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 11
        Me.GridColumn12.Width = 94
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Rate"
        Me.GridColumn13.DisplayFormat.FormatString = "n2"
        Me.GridColumn13.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn13.FieldName = "Rate"
        Me.GridColumn13.MinWidth = 25
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 12
        Me.GridColumn13.Width = 94
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Settlement"
        Me.GridColumn14.DisplayFormat.FormatString = "n2"
        Me.GridColumn14.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn14.FieldName = "AmountIDR"
        Me.GridColumn14.MinWidth = 25
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 13
        Me.GridColumn14.Width = 94
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "ID"
        Me.GridColumn15.FieldName = "ID"
        Me.GridColumn15.MinWidth = 25
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.Width = 94
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Seq"
        Me.GridColumn16.FieldName = "Seq"
        Me.GridColumn16.MinWidth = 25
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Width = 94
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Description"
        Me.GridColumn17.FieldName = "Description"
        Me.GridColumn17.MinWidth = 25
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Width = 94
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Pay"
        Me.GridColumn18.FieldName = "Pay"
        Me.GridColumn18.MinWidth = 25
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.Width = 94
        '
        'LayoutControlGroup4
        '
        Me.LayoutControlGroup4.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup4.GroupBordersVisible = False
        Me.LayoutControlGroup4.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem5})
        Me.LayoutControlGroup4.Name = "LayoutControlGroup4"
        Me.LayoutControlGroup4.Size = New System.Drawing.Size(1040, 408)
        Me.LayoutControlGroup4.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.GroupControl4
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(1020, 388)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControl8
        '
        Me.LayoutControl8.Controls.Add(Me.GroupControl5)
        Me.LayoutControl8.Dock = System.Windows.Forms.DockStyle.Left
        Me.LayoutControl8.Location = New System.Drawing.Point(3, 417)
        Me.LayoutControl8.Name = "LayoutControl8"
        Me.LayoutControl8.Root = Me.LayoutControlGroup7
        Me.LayoutControl8.Size = New System.Drawing.Size(900, 124)
        Me.LayoutControl8.TabIndex = 1
        Me.LayoutControl8.Text = "LayoutControl8"
        '
        'GroupControl5
        '
        Me.GroupControl5.Controls.Add(Me.GridSumPaid)
        Me.GroupControl5.GroupStyle = DevExpress.Utils.GroupStyle.Card
        Me.GroupControl5.Location = New System.Drawing.Point(12, 12)
        Me.GroupControl5.Name = "GroupControl5"
        Me.GroupControl5.Size = New System.Drawing.Size(876, 100)
        Me.GroupControl5.TabIndex = 6
        Me.GroupControl5.Text = "Summary"
        '
        'GridSumPaid
        '
        Me.GridSumPaid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridSumPaid.Location = New System.Drawing.Point(2, 26)
        Me.GridSumPaid.MainView = Me.GridViewSumPaid
        Me.GridSumPaid.Name = "GridSumPaid"
        Me.GridSumPaid.Size = New System.Drawing.Size(872, 72)
        Me.GridSumPaid.TabIndex = 4
        Me.GridSumPaid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewSumPaid})
        '
        'GridViewSumPaid
        '
        Me.GridViewSumPaid.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn19, Me.GridColumn20, Me.GridColumn21, Me.GridColumn22, Me.GridColumn23})
        Me.GridViewSumPaid.GridControl = Me.GridSumPaid
        Me.GridViewSumPaid.Name = "GridViewSumPaid"
        Me.GridViewSumPaid.OptionsBehavior.Editable = False
        Me.GridViewSumPaid.OptionsView.ShowGroupPanel = False
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "Original USD"
        Me.GridColumn19.DisplayFormat.FormatString = "n2"
        Me.GridColumn19.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn19.FieldName = "SumAmountOriUSD"
        Me.GridColumn19.MinWidth = 25
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 0
        Me.GridColumn19.Width = 94
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Original YEN"
        Me.GridColumn20.DisplayFormat.FormatString = "n2"
        Me.GridColumn20.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn20.FieldName = "SumAmountOriYEN"
        Me.GridColumn20.MinWidth = 25
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 1
        Me.GridColumn20.Width = 94
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "Original IDR"
        Me.GridColumn21.DisplayFormat.FormatString = "n2"
        Me.GridColumn21.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn21.FieldName = "SumAmountOriIDR"
        Me.GridColumn21.MinWidth = 25
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 2
        Me.GridColumn21.Width = 94
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "Accrual Estimate"
        Me.GridColumn22.DisplayFormat.FormatString = "n2"
        Me.GridColumn22.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn22.FieldName = "SumAccrualEstimate"
        Me.GridColumn22.MinWidth = 25
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 3
        Me.GridColumn22.Width = 94
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "Settlement"
        Me.GridColumn23.DisplayFormat.FormatString = "n2"
        Me.GridColumn23.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn23.FieldName = "SumAmountIDR"
        Me.GridColumn23.MinWidth = 25
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 4
        Me.GridColumn23.Width = 94
        '
        'LayoutControlGroup7
        '
        Me.LayoutControlGroup7.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup7.GroupBordersVisible = False
        Me.LayoutControlGroup7.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem9})
        Me.LayoutControlGroup7.Name = "LayoutControlGroup7"
        Me.LayoutControlGroup7.Size = New System.Drawing.Size(900, 124)
        Me.LayoutControlGroup7.TextVisible = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.GroupControl5
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(880, 104)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'CCCNumberMaster
        '
        Me.CCCNumberMaster.AutoHeight = False
        Me.CCCNumberMaster.DisplayFormat.FormatString = "0000-0000-0000-9999"
        Me.CCCNumberMaster.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.CCCNumberMaster.Mask.EditMask = "0000-0000-0000-9999"
        Me.CCCNumberMaster.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple
        Me.CCCNumberMaster.Mask.UseMaskAsDisplayFormat = True
        Me.CCCNumberMaster.Name = "CCCNumberMaster"
        '
        'CCCNumber
        '
        Me.CCCNumber.AutoHeight = False
        Me.CCCNumber.DisplayFormat.FormatString = "0000-0000-0000-9999"
        Me.CCCNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.CCCNumber.Mask.EditMask = "0000-0000-0000-9999"
        Me.CCCNumber.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple
        Me.CCCNumber.Mask.UseMaskAsDisplayFormat = True
        Me.CCCNumber.Name = "CCCNumber"
        '
        'CCNumberMasterPaid
        '
        Me.CCNumberMasterPaid.AutoHeight = False
        Me.CCNumberMasterPaid.DisplayFormat.FormatString = "0000-0000-0000-9999"
        Me.CCNumberMasterPaid.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.CCNumberMasterPaid.Mask.EditMask = "0000-0000-0000-9999"
        Me.CCNumberMasterPaid.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple
        Me.CCNumberMasterPaid.Mask.UseMaskAsDisplayFormat = True
        Me.CCNumberMasterPaid.Name = "CCNumberMasterPaid"
        '
        'CCCNumberPaid
        '
        Me.CCCNumberPaid.AutoHeight = False
        Me.CCCNumberPaid.DisplayFormat.FormatString = "0000-0000-0000-9999"
        Me.CCCNumberPaid.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.CCCNumberPaid.Mask.EditMask = "0000-0000-0000-9999"
        Me.CCCNumberPaid.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple
        Me.CCCNumberPaid.Mask.UseMaskAsDisplayFormat = True
        Me.CCCNumberPaid.Name = "CCCNumberPaid"
        '
        'FrmCCAccrued
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.ClientSize = New System.Drawing.Size(1053, 605)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Name = "FrmCCAccrued"
        Me.Controls.SetChildIndex(Me.XtraTabControl1, 0)
        CType(Me.GridAccrued, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewAccrued, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CCreditCardNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CAmountIDR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtCCNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.TabPageProses.ResumeLayout(False)
        Me.TableLayoutPanel2.ResumeLayout(False)
        CType(Me.LayoutControl6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl6.ResumeLayout(False)
        CType(Me.GroupControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl2.ResumeLayout(False)
        CType(Me.LayoutControlGroup5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl7, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl7.ResumeLayout(False)
        CType(Me.GroupControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl1.ResumeLayout(False)
        CType(Me.GridSumAccrued, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewSumAccrued, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageCancel.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl3.ResumeLayout(False)
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl4.ResumeLayout(False)
        CType(Me.GroupControl6, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl6.ResumeLayout(False)
        CType(Me.GridAccruedAll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewAccruedAll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.GroupControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl3.ResumeLayout(False)
        CType(Me.GridSumSettle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewSumSettle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPagePaid.ResumeLayout(False)
        Me.TableLayoutPanel3.ResumeLayout(False)
        CType(Me.LayoutControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl5.ResumeLayout(False)
        CType(Me.GroupControl4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl4.ResumeLayout(False)
        CType(Me.GridAccruedPaid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewAccruedPaid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl8.ResumeLayout(False)
        CType(Me.GroupControl5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupControl5.ResumeLayout(False)
        CType(Me.GridSumPaid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewSumPaid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CCCNumberMaster, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CCCNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CCNumberMasterPaid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CCCNumberPaid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridAccrued As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewAccrued As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents TabPageProses As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TableLayoutPanel2 As TableLayoutPanel
    Friend WithEvents TabPageCancel As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents LayoutControl3 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControl4 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridAccruedAll As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewAccruedAll As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlGroup3 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents btnProses As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents btnCancel As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TabPagePaid As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents txtCCNumber As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LayoutControl5 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup4 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GTanggalTransaksi As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GNoTransaksi As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSeq As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GJenisTransaksi As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCurryID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAmount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAmountIDR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GCreditCardNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAccountName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBankName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CAmountIDR As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents CCreditCardNumber As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GAccountID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControl6 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridSumAccrued As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewSumAccrued As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SumAmountOriUSD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SumAmountOriYEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SumAmountOriIDR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SumAmountIDR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlGroup5 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GroupControl2 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl7 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GroupControl1 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControlGroup6 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GroupControl3 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridSumSettle As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewSumSettle As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents SumAmountOriUSDSettle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SumAmountOriYENSettle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SumAmountOriIDRSettle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SumAmountIDRSettle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents AccrualEstimate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SumAccrualEstimateProses As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SumAccrualEstimateSettle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents IDSettle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NoAccruedSetle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TanggalSettle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TanggalTransSette As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NoTransaksiSettle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SeqSettle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents JenisTransaksiSettle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DescriptionSettle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CurryIDSettle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Amount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents AccrualEstimateSettle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RateSettle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents AmountIDRSettle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CreditCardNumberSettle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents AccountNameSettle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BankNameSettle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PaySettle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CCNumberMasterSettle As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridAccruedPaid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewAccruedPaid As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TableLayoutPanel3 As TableLayoutPanel
    Friend WithEvents GroupControl4 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl8 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup7 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GroupControl6 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GroupControl5 As DevExpress.XtraEditors.GroupControl
    Friend WithEvents GridSumPaid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewSumPaid As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CCCNumberMaster As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents CCCNumber As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents CCNumberMasterPaid As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents CCCNumberPaid As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
End Class
