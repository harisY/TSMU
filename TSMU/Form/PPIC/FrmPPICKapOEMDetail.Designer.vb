<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPPICKapOEMDetail
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
        Me.components = New System.ComponentModel.Container()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.txtStandarQty = New DevExpress.XtraEditors.TextEdit()
        Me.txtInventoryID = New DevExpress.XtraEditors.TextEdit()
        Me.txtPartName = New DevExpress.XtraEditors.TextEdit()
        Me.txtKapasitasMuat = New DevExpress.XtraEditors.TextEdit()
        Me.txtModel = New DevExpress.XtraEditors.TextEdit()
        Me.txtLocation = New DevExpress.XtraEditors.TextEdit()
        Me.txtJenisPacking = New DevExpress.XtraEditors.ButtonEdit()
        Me.txtPartNo = New DevExpress.XtraEditors.ButtonEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DxValidationProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtStandarQty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtInventoryID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPartName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtKapasitasMuat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtModel.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLocation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJenisPacking.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPartNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.txtStandarQty)
        Me.LayoutControl1.Controls.Add(Me.txtInventoryID)
        Me.LayoutControl1.Controls.Add(Me.txtPartName)
        Me.LayoutControl1.Controls.Add(Me.txtKapasitasMuat)
        Me.LayoutControl1.Controls.Add(Me.txtModel)
        Me.LayoutControl1.Controls.Add(Me.txtLocation)
        Me.LayoutControl1.Controls.Add(Me.txtJenisPacking)
        Me.LayoutControl1.Controls.Add(Me.txtPartNo)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 27)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(794, 156, 975, 600)
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(778, 429)
        Me.LayoutControl1.TabIndex = 1
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'txtStandarQty
        '
        Me.txtStandarQty.Location = New System.Drawing.Point(129, 204)
        Me.txtStandarQty.MaximumSize = New System.Drawing.Size(100, 0)
        Me.txtStandarQty.Name = "txtStandarQty"
        Me.txtStandarQty.Properties.EditFormat.FormatString = "n0"
        Me.txtStandarQty.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtStandarQty.Properties.Mask.EditMask = "n0"
        Me.txtStandarQty.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtStandarQty.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtStandarQty.Size = New System.Drawing.Size(100, 28)
        Me.txtStandarQty.StyleController = Me.LayoutControl1
        Me.txtStandarQty.TabIndex = 12
        '
        'txtInventoryID
        '
        Me.txtInventoryID.Location = New System.Drawing.Point(129, 140)
        Me.txtInventoryID.MaximumSize = New System.Drawing.Size(200, 0)
        Me.txtInventoryID.Name = "txtInventoryID"
        Me.txtInventoryID.Properties.MaxLength = 5
        Me.txtInventoryID.Size = New System.Drawing.Size(200, 28)
        Me.txtInventoryID.StyleController = Me.LayoutControl1
        Me.txtInventoryID.TabIndex = 11
        '
        'txtPartName
        '
        Me.txtPartName.Location = New System.Drawing.Point(129, 108)
        Me.txtPartName.MaximumSize = New System.Drawing.Size(400, 0)
        Me.txtPartName.Name = "txtPartName"
        Me.txtPartName.Size = New System.Drawing.Size(400, 28)
        Me.txtPartName.StyleController = Me.LayoutControl1
        Me.txtPartName.TabIndex = 10
        '
        'txtKapasitasMuat
        '
        Me.txtKapasitasMuat.Enabled = False
        Me.txtKapasitasMuat.Location = New System.Drawing.Point(129, 236)
        Me.txtKapasitasMuat.MaximumSize = New System.Drawing.Size(100, 0)
        Me.txtKapasitasMuat.Name = "txtKapasitasMuat"
        Me.txtKapasitasMuat.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtKapasitasMuat.Properties.EditFormat.FormatString = "n0"
        Me.txtKapasitasMuat.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtKapasitasMuat.Properties.Mask.EditMask = "n0"
        Me.txtKapasitasMuat.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtKapasitasMuat.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtKapasitasMuat.Size = New System.Drawing.Size(100, 28)
        Me.txtKapasitasMuat.StyleController = Me.LayoutControl1
        Me.txtKapasitasMuat.TabIndex = 8
        '
        'txtModel
        '
        Me.txtModel.Enabled = False
        Me.txtModel.Location = New System.Drawing.Point(129, 12)
        Me.txtModel.MaximumSize = New System.Drawing.Size(100, 0)
        Me.txtModel.Name = "txtModel"
        Me.txtModel.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtModel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtModel.Size = New System.Drawing.Size(100, 28)
        Me.txtModel.StyleController = Me.LayoutControl1
        Me.txtModel.TabIndex = 7
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(129, 44)
        Me.txtLocation.MaximumSize = New System.Drawing.Size(100, 0)
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtLocation.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLocation.Size = New System.Drawing.Size(100, 28)
        Me.txtLocation.StyleController = Me.LayoutControl1
        Me.txtLocation.TabIndex = 5
        '
        'txtJenisPacking
        '
        Me.txtJenisPacking.Location = New System.Drawing.Point(129, 172)
        Me.txtJenisPacking.MaximumSize = New System.Drawing.Size(200, 0)
        Me.txtJenisPacking.Name = "txtJenisPacking"
        Me.txtJenisPacking.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtJenisPacking.Properties.MaxLength = 20
        Me.txtJenisPacking.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txtJenisPacking.Size = New System.Drawing.Size(200, 28)
        Me.txtJenisPacking.StyleController = Me.LayoutControl1
        Me.txtJenisPacking.TabIndex = 4
        '
        'txtPartNo
        '
        Me.txtPartNo.Location = New System.Drawing.Point(129, 76)
        Me.txtPartNo.MaximumSize = New System.Drawing.Size(250, 0)
        Me.txtPartNo.Name = "txtPartNo"
        Me.txtPartNo.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtPartNo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtPartNo.Properties.Name = "txtPartNo"
        Me.txtPartNo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txtPartNo.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtPartNo.Size = New System.Drawing.Size(250, 28)
        Me.txtPartNo.StyleController = Me.LayoutControl1
        Me.txtPartNo.TabIndex = 6
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem2, Me.LayoutControlItem5, Me.LayoutControlItem3, Me.LayoutControlItem9, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.LayoutControlItem1, Me.LayoutControlItem4})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(778, 429)
        Me.Root.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 256)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(758, 153)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtLocation
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 32)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(758, 32)
        Me.LayoutControlItem2.Text = "Location"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(114, 19)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.txtKapasitasMuat
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 224)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(758, 32)
        Me.LayoutControlItem5.Text = "Kapasitas Muat  "
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(114, 19)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtPartNo
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 64)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(758, 32)
        Me.LayoutControlItem3.Text = "Part No"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(114, 19)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.txtStandarQty
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 192)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(758, 32)
        Me.LayoutControlItem9.Text = "Standar Qty"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(114, 19)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.txtPartName
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(758, 32)
        Me.LayoutControlItem7.Text = "Part Name"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(114, 19)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.txtInventoryID
        Me.LayoutControlItem8.CustomizationFormText = "UsedForCustomer"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 128)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(758, 32)
        Me.LayoutControlItem8.Text = "Inventory ID"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(114, 19)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtJenisPacking
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 160)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(758, 32)
        Me.LayoutControlItem1.Text = "Jenis Packing"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(114, 19)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtModel
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(758, 32)
        Me.LayoutControlItem4.Text = "Model"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(114, 19)
        '
        'FrmPPICKapOEMDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.ClientSize = New System.Drawing.Size(778, 456)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "FrmPPICKapOEMDetail"
        Me.Controls.SetChildIndex(Me.LayoutControl1, 0)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtStandarQty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtInventoryID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPartName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtKapasitasMuat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtModel.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLocation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJenisPacking.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPartNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents txtInventoryID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPartName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtKapasitasMuat As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtModel As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtLocation As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DxValidationProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents txtStandarQty As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtJenisPacking As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents txtPartNo As DevExpress.XtraEditors.ButtonEdit
End Class
