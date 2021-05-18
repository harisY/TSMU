<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_GetPRDetail
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.BAdd = New System.Windows.Forms.Button()
        Me.Grid = New DevExpress.XtraGrid.GridControl()
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
        Me.Balance = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PoQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PRQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Check = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoCheck = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepoQtyMin = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.RepoQtyMax = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.RepoAction = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.RepoCAction = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.RepoRcptStatus = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.RepoVoucherStatus = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.RepoIncl = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.RepoCheck, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoQtyMin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoQtyMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoAction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoCAction, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoRcptStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoVoucherStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoIncl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BAdd
        '
        Me.BAdd.Location = New System.Drawing.Point(12, 7)
        Me.BAdd.Name = "BAdd"
        Me.BAdd.Size = New System.Drawing.Size(64, 23)
        Me.BAdd.TabIndex = 9
        Me.BAdd.Text = "Add"
        Me.BAdd.UseVisualStyleBackColor = True
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.Location = New System.Drawing.Point(12, 36)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Name = "Grid"
        Me.Grid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1, Me.Qty, Me.RepoUnitCost, Me.RepoExtendedCost, Me.RepoUnitWeight, Me.RepoExtendedWeight, Me.RepoUnitVolume, Me.RepoExtendedVolume, Me.RepoQtyMin, Me.RepoQtyMax, Me.RepoRequired, Me.RepoPromised, Me.RepoAlternate, Me.RepoAction, Me.RepoCAction, Me.RepoRcptStatus, Me.RepoVoucherStatus, Me.Reposite, Me.RepoPurchaseFor, Me.RepoIncl, Me.RepoCheck})
        Me.Grid.Size = New System.Drawing.Size(803, 310)
        Me.Grid.TabIndex = 10
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.No, Me.XSeq, Me.PRNo, Me.PRLineNo, Me.AlternateID, Me.InventoryID, Me.Description, Me.Quantity, Me.OUM, Me.UnitCost, Me.ExtendedCost, Me.StatusPrice, Me.UnitWeight, Me.SiteID, Me.ExtentedWeight, Me.PurchaseFor, Me.UnitVolume, Me.ExtendedVolume, Me.Required, Me.Promised, Me.Account, Me.SubAccount, Me.Balance, Me.PoQty, Me.PRQty, Me.Check})
        Me.GridView1.GridControl = Me.Grid
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
        Me.No.VisibleIndex = 1
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
        Me.PRLineNo.Width = 134
        '
        'AlternateID
        '
        Me.AlternateID.AppearanceHeader.Options.UseTextOptions = True
        Me.AlternateID.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.AlternateID.ColumnEdit = Me.RepoAlternate
        Me.AlternateID.FieldName = "Alternate ID"
        Me.AlternateID.Name = "AlternateID"
        Me.AlternateID.Visible = True
        Me.AlternateID.VisibleIndex = 3
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
        Me.InventoryID.VisibleIndex = 4
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
        Me.Description.VisibleIndex = 5
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
        Me.Quantity.VisibleIndex = 6
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
        Me.OUM.VisibleIndex = 7
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
        Me.UnitCost.VisibleIndex = 8
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
        Me.ExtendedCost.VisibleIndex = 9
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
        Me.SiteID.VisibleIndex = 10
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
        Me.PurchaseFor.VisibleIndex = 11
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
        Me.Required.VisibleIndex = 12
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
        Me.Promised.VisibleIndex = 13
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
        Me.Account.VisibleIndex = 14
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
        Me.SubAccount.VisibleIndex = 15
        Me.SubAccount.Width = 79
        '
        'Balance
        '
        Me.Balance.FieldName = "Balance"
        Me.Balance.Name = "Balance"
        Me.Balance.OptionsColumn.AllowEdit = False
        Me.Balance.Visible = True
        Me.Balance.VisibleIndex = 18
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
        Me.PoQty.VisibleIndex = 17
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
        Me.PRQty.VisibleIndex = 16
        '
        'Check
        '
        Me.Check.ColumnEdit = Me.RepoCheck
        Me.Check.FieldName = "Check"
        Me.Check.Name = "Check"
        Me.Check.UnboundType = DevExpress.Data.UnboundColumnType.[Boolean]
        Me.Check.Visible = True
        Me.Check.VisibleIndex = 0
        Me.Check.Width = 40
        '
        'RepoCheck
        '
        Me.RepoCheck.AutoHeight = False
        Me.RepoCheck.Name = "RepoCheck"
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
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
        'RepoAction
        '
        Me.RepoAction.AutoHeight = False
        Me.RepoAction.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoAction.Name = "RepoAction"
        '
        'RepoCAction
        '
        Me.RepoCAction.AutoHeight = False
        Me.RepoCAction.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoCAction.Items.AddRange(New Object() {"A", "B"})
        Me.RepoCAction.Name = "RepoCAction"
        '
        'RepoRcptStatus
        '
        Me.RepoRcptStatus.AutoHeight = False
        Me.RepoRcptStatus.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoRcptStatus.Name = "RepoRcptStatus"
        '
        'RepoVoucherStatus
        '
        Me.RepoVoucherStatus.AutoHeight = False
        Me.RepoVoucherStatus.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoVoucherStatus.Name = "RepoVoucherStatus"
        '
        'RepoIncl
        '
        Me.RepoIncl.AutoHeight = False
        Me.RepoIncl.Name = "RepoIncl"
        '
        'Frm_GetPRDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(827, 358)
        Me.Controls.Add(Me.Grid)
        Me.Controls.Add(Me.BAdd)
        Me.Name = "Frm_GetPRDetail"
        Me.Text = "Detail PR"
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.RepoCheck, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoQtyMin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoQtyMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoAction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoCAction, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoRcptStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoVoucherStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoIncl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BAdd As Button
    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents No As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XSeq As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PRNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PRLineNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents AlternateID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoAlternate As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents InventoryID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Description As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Quantity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Qty As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents OUM As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UnitCost As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoUnitCost As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents ExtendedCost As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoExtendedCost As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents StatusPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents UnitWeight As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoUnitWeight As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents SiteID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Reposite As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents ExtentedWeight As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoExtendedWeight As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents PurchaseFor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoPurchaseFor As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents UnitVolume As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoUnitVolume As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents ExtendedVolume As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoExtendedVolume As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents Required As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoRequired As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents Promised As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoPromised As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents Account As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SubAccount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoQtyMin As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents RepoQtyMax As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents RepoAction As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepoRcptStatus As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepoVoucherStatus As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents RepoIncl As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents Balance As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PoQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PRQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepoCAction As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents Check As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoCheck As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
End Class
