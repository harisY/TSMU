<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPPICConvertMuatDetail
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
        Me.components = New System.ComponentModel.Container()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.GridDetail = New DevExpress.XtraGrid.GridControl()
        Me.GridViewDetail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColSeq = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColItemNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColItemName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColLokasi = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColUserCode = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPF = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColOrderNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDeliveryDueDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColGroupHourly = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColDeliveryTime = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColOrderQuantity = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepOrderQty = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.ColJenisPacking = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColStandarQty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColKapasitasMuat = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColButuhPacking = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColKebutuhanTruk = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColGroupTruk = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DxValidationProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.txtTotalMobil = New DevExpress.XtraEditors.TextEdit()
        Me.btnKonversi = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ColPartNo = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepOrderQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.txtTotalMobil.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.GridDetail)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(4, 64)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(1186, 637)
        Me.LayoutControl1.TabIndex = 1
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'GridDetail
        '
        Me.GridDetail.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(5)
        Me.GridDetail.Location = New System.Drawing.Point(2, 2)
        Me.GridDetail.MainView = Me.GridViewDetail
        Me.GridDetail.Margin = New System.Windows.Forms.Padding(4)
        Me.GridDetail.Name = "GridDetail"
        Me.GridDetail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepOrderQty})
        Me.GridDetail.Size = New System.Drawing.Size(1182, 633)
        Me.GridDetail.TabIndex = 4
        Me.GridDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewDetail})
        '
        'GridViewDetail
        '
        Me.GridViewDetail.ActiveFilterEnabled = False
        Me.GridViewDetail.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridViewDetail.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridViewDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColNo, Me.ColSeq, Me.ColPartNo, Me.ColItemNumber, Me.ColItemName, Me.ColLokasi, Me.ColUserCode, Me.ColPF, Me.ColOrderNo, Me.ColDeliveryDueDate, Me.ColGroupHourly, Me.ColDeliveryTime, Me.ColOrderQuantity, Me.ColJenisPacking, Me.ColStandarQty, Me.ColKapasitasMuat, Me.ColButuhPacking, Me.ColKebutuhanTruk, Me.ColGroupTruk})
        Me.GridViewDetail.DetailHeight = 412
        Me.GridViewDetail.GridControl = Me.GridDetail
        Me.GridViewDetail.Name = "GridViewDetail"
        Me.GridViewDetail.OptionsCustomization.AllowFilter = False
        Me.GridViewDetail.OptionsCustomization.AllowSort = False
        Me.GridViewDetail.OptionsView.ColumnAutoWidth = False
        Me.GridViewDetail.OptionsView.ShowGroupPanel = False
        '
        'ColNo
        '
        Me.ColNo.AppearanceCell.Options.UseTextOptions = True
        Me.ColNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColNo.Caption = "No"
        Me.ColNo.FieldName = "No"
        Me.ColNo.MinWidth = 30
        Me.ColNo.Name = "ColNo"
        Me.ColNo.OptionsColumn.AllowEdit = False
        Me.ColNo.Visible = True
        Me.ColNo.VisibleIndex = 0
        Me.ColNo.Width = 112
        '
        'ColSeq
        '
        Me.ColSeq.AppearanceCell.Options.UseTextOptions = True
        Me.ColSeq.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColSeq.Caption = "Seq"
        Me.ColSeq.FieldName = "Seq"
        Me.ColSeq.MinWidth = 30
        Me.ColSeq.Name = "ColSeq"
        Me.ColSeq.OptionsColumn.AllowEdit = False
        Me.ColSeq.Visible = True
        Me.ColSeq.VisibleIndex = 1
        Me.ColSeq.Width = 112
        '
        'ColItemNumber
        '
        Me.ColItemNumber.Caption = "Item Number"
        Me.ColItemNumber.FieldName = "ItemNumber"
        Me.ColItemNumber.MinWidth = 30
        Me.ColItemNumber.Name = "ColItemNumber"
        Me.ColItemNumber.OptionsColumn.AllowEdit = False
        Me.ColItemNumber.Visible = True
        Me.ColItemNumber.VisibleIndex = 3
        Me.ColItemNumber.Width = 112
        '
        'ColItemName
        '
        Me.ColItemName.Caption = "Item Name"
        Me.ColItemName.FieldName = "ItemName"
        Me.ColItemName.MinWidth = 30
        Me.ColItemName.Name = "ColItemName"
        Me.ColItemName.OptionsColumn.AllowEdit = False
        Me.ColItemName.Visible = True
        Me.ColItemName.VisibleIndex = 4
        Me.ColItemName.Width = 112
        '
        'ColLokasi
        '
        Me.ColLokasi.Caption = "Lokasi"
        Me.ColLokasi.FieldName = "Lokasi"
        Me.ColLokasi.MinWidth = 30
        Me.ColLokasi.Name = "ColLokasi"
        Me.ColLokasi.OptionsColumn.AllowEdit = False
        Me.ColLokasi.Visible = True
        Me.ColLokasi.VisibleIndex = 5
        Me.ColLokasi.Width = 112
        '
        'ColUserCode
        '
        Me.ColUserCode.Caption = "User Code"
        Me.ColUserCode.FieldName = "UserCode"
        Me.ColUserCode.MinWidth = 30
        Me.ColUserCode.Name = "ColUserCode"
        Me.ColUserCode.OptionsColumn.AllowEdit = False
        Me.ColUserCode.Visible = True
        Me.ColUserCode.VisibleIndex = 6
        Me.ColUserCode.Width = 112
        '
        'ColPF
        '
        Me.ColPF.Caption = "P/F"
        Me.ColPF.FieldName = "PF"
        Me.ColPF.MinWidth = 30
        Me.ColPF.Name = "ColPF"
        Me.ColPF.OptionsColumn.AllowEdit = False
        Me.ColPF.Width = 112
        '
        'ColOrderNo
        '
        Me.ColOrderNo.Caption = "Order No"
        Me.ColOrderNo.FieldName = "OrderNo"
        Me.ColOrderNo.MinWidth = 30
        Me.ColOrderNo.Name = "ColOrderNo"
        Me.ColOrderNo.OptionsColumn.AllowEdit = False
        Me.ColOrderNo.Visible = True
        Me.ColOrderNo.VisibleIndex = 7
        Me.ColOrderNo.Width = 112
        '
        'ColDeliveryDueDate
        '
        Me.ColDeliveryDueDate.Caption = "Delivery Due Date"
        Me.ColDeliveryDueDate.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.ColDeliveryDueDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColDeliveryDueDate.FieldName = "DeliveryDueDate"
        Me.ColDeliveryDueDate.MinWidth = 30
        Me.ColDeliveryDueDate.Name = "ColDeliveryDueDate"
        Me.ColDeliveryDueDate.OptionsColumn.AllowEdit = False
        Me.ColDeliveryDueDate.Visible = True
        Me.ColDeliveryDueDate.VisibleIndex = 8
        Me.ColDeliveryDueDate.Width = 112
        '
        'ColGroupHourly
        '
        Me.ColGroupHourly.Caption = "Group Hourly"
        Me.ColGroupHourly.FieldName = "GroupHourly"
        Me.ColGroupHourly.MinWidth = 30
        Me.ColGroupHourly.Name = "ColGroupHourly"
        Me.ColGroupHourly.OptionsColumn.AllowEdit = False
        Me.ColGroupHourly.Visible = True
        Me.ColGroupHourly.VisibleIndex = 9
        Me.ColGroupHourly.Width = 112
        '
        'ColDeliveryTime
        '
        Me.ColDeliveryTime.Caption = "Delivery Time (To)"
        Me.ColDeliveryTime.DisplayFormat.FormatString = "HH:mm"
        Me.ColDeliveryTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ColDeliveryTime.FieldName = "DeliveryTime"
        Me.ColDeliveryTime.MinWidth = 30
        Me.ColDeliveryTime.Name = "ColDeliveryTime"
        Me.ColDeliveryTime.OptionsColumn.AllowEdit = False
        Me.ColDeliveryTime.Visible = True
        Me.ColDeliveryTime.VisibleIndex = 10
        Me.ColDeliveryTime.Width = 112
        '
        'ColOrderQuantity
        '
        Me.ColOrderQuantity.Caption = "Order Qty"
        Me.ColOrderQuantity.ColumnEdit = Me.RepOrderQty
        Me.ColOrderQuantity.FieldName = "OrderQuantity"
        Me.ColOrderQuantity.MinWidth = 30
        Me.ColOrderQuantity.Name = "ColOrderQuantity"
        Me.ColOrderQuantity.Visible = True
        Me.ColOrderQuantity.VisibleIndex = 11
        Me.ColOrderQuantity.Width = 112
        '
        'RepOrderQty
        '
        Me.RepOrderQty.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.RepOrderQty.AutoHeight = False
        Me.RepOrderQty.DisplayFormat.FormatString = "n0"
        Me.RepOrderQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepOrderQty.EditFormat.FormatString = "n0"
        Me.RepOrderQty.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.RepOrderQty.Mask.EditMask = "n0"
        Me.RepOrderQty.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.RepOrderQty.Name = "RepOrderQty"
        '
        'ColJenisPacking
        '
        Me.ColJenisPacking.Caption = "Jenis Packing"
        Me.ColJenisPacking.FieldName = "JenisPacking"
        Me.ColJenisPacking.MinWidth = 30
        Me.ColJenisPacking.Name = "ColJenisPacking"
        Me.ColJenisPacking.OptionsColumn.AllowEdit = False
        Me.ColJenisPacking.Visible = True
        Me.ColJenisPacking.VisibleIndex = 12
        Me.ColJenisPacking.Width = 112
        '
        'ColStandarQty
        '
        Me.ColStandarQty.Caption = "Standar Qty"
        Me.ColStandarQty.FieldName = "StandarQty"
        Me.ColStandarQty.MinWidth = 30
        Me.ColStandarQty.Name = "ColStandarQty"
        Me.ColStandarQty.OptionsColumn.AllowEdit = False
        Me.ColStandarQty.Visible = True
        Me.ColStandarQty.VisibleIndex = 13
        Me.ColStandarQty.Width = 112
        '
        'ColKapasitasMuat
        '
        Me.ColKapasitasMuat.Caption = "Kapasitas Muat"
        Me.ColKapasitasMuat.FieldName = "KapasitasMuat"
        Me.ColKapasitasMuat.MinWidth = 30
        Me.ColKapasitasMuat.Name = "ColKapasitasMuat"
        Me.ColKapasitasMuat.OptionsColumn.AllowEdit = False
        Me.ColKapasitasMuat.Visible = True
        Me.ColKapasitasMuat.VisibleIndex = 14
        Me.ColKapasitasMuat.Width = 112
        '
        'ColButuhPacking
        '
        Me.ColButuhPacking.Caption = "Butuh Packing"
        Me.ColButuhPacking.FieldName = "ButuhPacking"
        Me.ColButuhPacking.MinWidth = 30
        Me.ColButuhPacking.Name = "ColButuhPacking"
        Me.ColButuhPacking.OptionsColumn.AllowEdit = False
        Me.ColButuhPacking.Visible = True
        Me.ColButuhPacking.VisibleIndex = 15
        Me.ColButuhPacking.Width = 112
        '
        'ColKebutuhanTruk
        '
        Me.ColKebutuhanTruk.Caption = "Kebutuhan Truk"
        Me.ColKebutuhanTruk.FieldName = "KebutuhanTruk"
        Me.ColKebutuhanTruk.MinWidth = 30
        Me.ColKebutuhanTruk.Name = "ColKebutuhanTruk"
        Me.ColKebutuhanTruk.OptionsColumn.AllowEdit = False
        Me.ColKebutuhanTruk.Visible = True
        Me.ColKebutuhanTruk.VisibleIndex = 16
        Me.ColKebutuhanTruk.Width = 112
        '
        'ColGroupTruk
        '
        Me.ColGroupTruk.AppearanceCell.Options.UseTextOptions = True
        Me.ColGroupTruk.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColGroupTruk.Caption = "Group Truk"
        Me.ColGroupTruk.FieldName = "GroupTruk"
        Me.ColGroupTruk.MinWidth = 30
        Me.ColGroupTruk.Name = "ColGroupTruk"
        Me.ColGroupTruk.OptionsColumn.AllowEdit = False
        Me.ColGroupTruk.Visible = True
        Me.ColGroupTruk.VisibleIndex = 17
        Me.ColGroupTruk.Width = 112
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.Root.Name = "Root"
        Me.Root.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.Root.Size = New System.Drawing.Size(1186, 637)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridDetail
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1186, 637)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LayoutControl1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LayoutControl2, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 27)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1194, 705)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.txtTotalMobil)
        Me.LayoutControl2.Controls.Add(Me.btnKonversi)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl2.Location = New System.Drawing.Point(3, 3)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.Padding = New System.Windows.Forms.Padding(12)
        Me.LayoutControl2.Root = Me.LayoutControlGroup1
        Me.LayoutControl2.Size = New System.Drawing.Size(1188, 54)
        Me.LayoutControl2.TabIndex = 2
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'txtTotalMobil
        '
        Me.txtTotalMobil.Enabled = False
        Me.txtTotalMobil.Location = New System.Drawing.Point(341, 10)
        Me.txtTotalMobil.MaximumSize = New System.Drawing.Size(100, 0)
        Me.txtTotalMobil.Name = "txtTotalMobil"
        Me.txtTotalMobil.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTotalMobil.Size = New System.Drawing.Size(100, 28)
        Me.txtTotalMobil.StyleController = Me.LayoutControl2
        Me.txtTotalMobil.TabIndex = 5
        '
        'btnKonversi
        '
        Me.btnKonversi.Location = New System.Drawing.Point(2, 10)
        Me.btnKonversi.MaximumSize = New System.Drawing.Size(150, 0)
        Me.btnKonversi.Name = "btnKonversi"
        Me.btnKonversi.Size = New System.Drawing.Size(150, 32)
        Me.btnKonversi.StyleController = Me.LayoutControl2
        Me.btnKonversi.TabIndex = 4
        Me.btnKonversi.Text = "Konversi Muat"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem3})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1188, 54)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.btnKonversi
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 2, 10, 2)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(154, 54)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtTotalMobil
        Me.LayoutControlItem3.Location = New System.Drawing.Point(154, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(20, 2, 10, 2)
        Me.LayoutControlItem3.Size = New System.Drawing.Size(1034, 54)
        Me.LayoutControlItem3.Text = "Total Kebutuhan Truk  "
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(164, 19)
        '
        'ColPartNo
        '
        Me.ColPartNo.Caption = "Part No"
        Me.ColPartNo.FieldName = "PartNo"
        Me.ColPartNo.MinWidth = 30
        Me.ColPartNo.Name = "ColPartNo"
        Me.ColPartNo.OptionsColumn.AllowEdit = False
        Me.ColPartNo.Visible = True
        Me.ColPartNo.VisibleIndex = 2
        Me.ColPartNo.Width = 112
        '
        'FrmPPICConvertMuatDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.ClientSize = New System.Drawing.Size(1194, 732)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.Name = "FrmPPICConvertMuatDetail"
        Me.Controls.SetChildIndex(Me.TableLayoutPanel1, 0)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepOrderQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.txtTotalMobil.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DxValidationProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents btnKonversi As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtTotalMobil As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColSeq As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColItemName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColItemNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColLokasi As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColUserCode As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPF As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColOrderNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDeliveryDueDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColGroupHourly As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColDeliveryTime As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColOrderQuantity As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColJenisPacking As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColStandarQty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColKapasitasMuat As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColButuhPacking As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColKebutuhanTruk As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColGroupTruk As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepOrderQty As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents ColPartNo As DevExpress.XtraGrid.Columns.GridColumn
End Class
