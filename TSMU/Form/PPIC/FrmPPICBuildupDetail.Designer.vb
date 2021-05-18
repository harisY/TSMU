<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPPICBuildupDetail
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
        Me.txtQtyPallet = New DevExpress.XtraEditors.TextEdit()
        Me.txtUsedForCustomer = New DevExpress.XtraEditors.TextEdit()
        Me.txtKeterangan = New DevExpress.XtraEditors.TextEdit()
        Me.txtPersentase = New DevExpress.XtraEditors.TextEdit()
        Me.txtKapasitasMuat = New DevExpress.XtraEditors.TextEdit()
        Me.txtTinggi = New DevExpress.XtraEditors.TextEdit()
        Me.txtLebar = New DevExpress.XtraEditors.TextEdit()
        Me.txtPanjang = New DevExpress.XtraEditors.TextEdit()
        Me.txtJenisPacking = New DevExpress.XtraEditors.TextEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleLabelItem1 = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleLabelItem3 = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.SimpleLabelItem2 = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.SimpleLabelItem4 = New DevExpress.XtraLayout.SimpleLabelItem()
        Me.DxValidationProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtQtyPallet.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUsedForCustomer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtKeterangan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPersentase.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtKapasitasMuat.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTinggi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtLebar.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPanjang.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtJenisPacking.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleLabelItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleLabelItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleLabelItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SimpleLabelItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.txtQtyPallet)
        Me.LayoutControl1.Controls.Add(Me.txtUsedForCustomer)
        Me.LayoutControl1.Controls.Add(Me.txtKeterangan)
        Me.LayoutControl1.Controls.Add(Me.txtPersentase)
        Me.LayoutControl1.Controls.Add(Me.txtKapasitasMuat)
        Me.LayoutControl1.Controls.Add(Me.txtTinggi)
        Me.LayoutControl1.Controls.Add(Me.txtLebar)
        Me.LayoutControl1.Controls.Add(Me.txtPanjang)
        Me.LayoutControl1.Controls.Add(Me.txtJenisPacking)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 27)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(860, 92, 975, 600)
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(778, 429)
        Me.LayoutControl1.TabIndex = 1
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'txtQtyPallet
        '
        Me.txtQtyPallet.Location = New System.Drawing.Point(151, 140)
        Me.txtQtyPallet.MaximumSize = New System.Drawing.Size(100, 0)
        Me.txtQtyPallet.Name = "txtQtyPallet"
        Me.txtQtyPallet.Properties.EditFormat.FormatString = "n0"
        Me.txtQtyPallet.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtQtyPallet.Properties.Mask.EditMask = "n0"
        Me.txtQtyPallet.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtQtyPallet.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtQtyPallet.Size = New System.Drawing.Size(100, 28)
        Me.txtQtyPallet.StyleController = Me.LayoutControl1
        Me.txtQtyPallet.TabIndex = 12
        '
        'txtUsedForCustomer
        '
        Me.txtUsedForCustomer.Location = New System.Drawing.Point(151, 268)
        Me.txtUsedForCustomer.MaximumSize = New System.Drawing.Size(100, 0)
        Me.txtUsedForCustomer.Name = "txtUsedForCustomer"
        Me.txtUsedForCustomer.Properties.MaxLength = 5
        Me.txtUsedForCustomer.Size = New System.Drawing.Size(100, 28)
        Me.txtUsedForCustomer.StyleController = Me.LayoutControl1
        Me.txtUsedForCustomer.TabIndex = 11
        '
        'txtKeterangan
        '
        Me.txtKeterangan.Location = New System.Drawing.Point(151, 236)
        Me.txtKeterangan.MaximumSize = New System.Drawing.Size(350, 0)
        Me.txtKeterangan.Name = "txtKeterangan"
        Me.txtKeterangan.Size = New System.Drawing.Size(350, 28)
        Me.txtKeterangan.StyleController = Me.LayoutControl1
        Me.txtKeterangan.TabIndex = 10
        '
        'txtPersentase
        '
        Me.txtPersentase.Location = New System.Drawing.Point(151, 204)
        Me.txtPersentase.MaximumSize = New System.Drawing.Size(100, 0)
        Me.txtPersentase.Name = "txtPersentase"
        Me.txtPersentase.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtPersentase.Properties.EditFormat.FormatString = "n2"
        Me.txtPersentase.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPersentase.Properties.Mask.EditMask = "n2"
        Me.txtPersentase.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtPersentase.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPersentase.Size = New System.Drawing.Size(100, 28)
        Me.txtPersentase.StyleController = Me.LayoutControl1
        Me.txtPersentase.TabIndex = 9
        '
        'txtKapasitasMuat
        '
        Me.txtKapasitasMuat.Location = New System.Drawing.Point(151, 172)
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
        'txtTinggi
        '
        Me.txtTinggi.Location = New System.Drawing.Point(151, 108)
        Me.txtTinggi.MaximumSize = New System.Drawing.Size(100, 0)
        Me.txtTinggi.Name = "txtTinggi"
        Me.txtTinggi.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtTinggi.Properties.EditFormat.FormatString = "n2"
        Me.txtTinggi.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtTinggi.Properties.Mask.EditMask = "n2"
        Me.txtTinggi.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtTinggi.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtTinggi.Size = New System.Drawing.Size(100, 28)
        Me.txtTinggi.StyleController = Me.LayoutControl1
        Me.txtTinggi.TabIndex = 7
        '
        'txtLebar
        '
        Me.txtLebar.Location = New System.Drawing.Point(151, 76)
        Me.txtLebar.MaximumSize = New System.Drawing.Size(100, 0)
        Me.txtLebar.Name = "txtLebar"
        Me.txtLebar.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtLebar.Properties.EditFormat.FormatString = "n2"
        Me.txtLebar.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtLebar.Properties.Mask.EditMask = "n2"
        Me.txtLebar.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtLebar.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtLebar.Size = New System.Drawing.Size(100, 28)
        Me.txtLebar.StyleController = Me.LayoutControl1
        Me.txtLebar.TabIndex = 6
        '
        'txtPanjang
        '
        Me.txtPanjang.Location = New System.Drawing.Point(151, 44)
        Me.txtPanjang.MaximumSize = New System.Drawing.Size(100, 0)
        Me.txtPanjang.Name = "txtPanjang"
        Me.txtPanjang.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtPanjang.Properties.EditFormat.FormatString = "n2"
        Me.txtPanjang.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtPanjang.Properties.Mask.EditMask = "n2"
        Me.txtPanjang.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtPanjang.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtPanjang.Size = New System.Drawing.Size(100, 28)
        Me.txtPanjang.StyleController = Me.LayoutControl1
        Me.txtPanjang.TabIndex = 5
        '
        'txtJenisPacking
        '
        Me.txtJenisPacking.Location = New System.Drawing.Point(151, 12)
        Me.txtJenisPacking.MaximumSize = New System.Drawing.Size(160, 0)
        Me.txtJenisPacking.Name = "txtJenisPacking"
        Me.txtJenisPacking.Properties.MaxLength = 20
        Me.txtJenisPacking.Size = New System.Drawing.Size(160, 28)
        Me.txtJenisPacking.StyleController = Me.LayoutControl1
        Me.txtJenisPacking.TabIndex = 4
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem1, Me.LayoutControlItem2, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.SimpleLabelItem1, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.SimpleLabelItem3, Me.SimpleLabelItem2, Me.LayoutControlItem9, Me.SimpleLabelItem4})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(778, 429)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtJenisPacking
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(758, 32)
        Me.LayoutControlItem1.Text = "Jenis Packing"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(136, 19)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 288)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(758, 121)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtPanjang
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 32)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(243, 32)
        Me.LayoutControlItem2.Text = "Panjang"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(136, 19)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.txtKapasitasMuat
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 160)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(758, 32)
        Me.LayoutControlItem5.Text = "Kapasitas Muat"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(136, 19)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.txtPersentase
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 192)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(243, 32)
        Me.LayoutControlItem6.Text = "Persentase"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(136, 19)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.txtKeterangan
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 224)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(758, 32)
        Me.LayoutControlItem7.Text = "Keterangan"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(136, 19)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.txtUsedForCustomer
        Me.LayoutControlItem8.CustomizationFormText = "UsedForCustomer"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 256)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(758, 32)
        Me.LayoutControlItem8.Text = "UsedForCustomer  "
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(136, 19)
        '
        'SimpleLabelItem1
        '
        Me.SimpleLabelItem1.AllowHotTrack = False
        Me.SimpleLabelItem1.Location = New System.Drawing.Point(243, 32)
        Me.SimpleLabelItem1.Name = "SimpleLabelItem1"
        Me.SimpleLabelItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2)
        Me.SimpleLabelItem1.Size = New System.Drawing.Size(515, 32)
        Me.SimpleLabelItem1.Text = "cm"
        Me.SimpleLabelItem1.TextSize = New System.Drawing.Size(136, 19)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtLebar
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 64)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(243, 32)
        Me.LayoutControlItem3.Text = "Lebar"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(136, 19)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtTinggi
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(243, 32)
        Me.LayoutControlItem4.Text = "Tinggi"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(136, 19)
        '
        'SimpleLabelItem3
        '
        Me.SimpleLabelItem3.AllowHotTrack = False
        Me.SimpleLabelItem3.Location = New System.Drawing.Point(243, 64)
        Me.SimpleLabelItem3.Name = "SimpleLabelItem3"
        Me.SimpleLabelItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2)
        Me.SimpleLabelItem3.Size = New System.Drawing.Size(515, 32)
        Me.SimpleLabelItem3.Text = "cm"
        Me.SimpleLabelItem3.TextSize = New System.Drawing.Size(136, 19)
        '
        'SimpleLabelItem2
        '
        Me.SimpleLabelItem2.AllowHotTrack = False
        Me.SimpleLabelItem2.Location = New System.Drawing.Point(243, 96)
        Me.SimpleLabelItem2.Name = "SimpleLabelItem2"
        Me.SimpleLabelItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2)
        Me.SimpleLabelItem2.Size = New System.Drawing.Size(515, 32)
        Me.SimpleLabelItem2.Text = "cm"
        Me.SimpleLabelItem2.TextSize = New System.Drawing.Size(136, 19)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.txtQtyPallet
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 128)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(758, 32)
        Me.LayoutControlItem9.Text = "Qty/Pallet"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(136, 19)
        '
        'SimpleLabelItem4
        '
        Me.SimpleLabelItem4.AllowHotTrack = False
        Me.SimpleLabelItem4.Location = New System.Drawing.Point(243, 192)
        Me.SimpleLabelItem4.Name = "SimpleLabelItem4"
        Me.SimpleLabelItem4.Padding = New DevExpress.XtraLayout.Utils.Padding(5, 2, 2, 2)
        Me.SimpleLabelItem4.Size = New System.Drawing.Size(515, 32)
        Me.SimpleLabelItem4.Text = "%"
        Me.SimpleLabelItem4.TextSize = New System.Drawing.Size(136, 19)
        '
        'FrmPPICBuildupDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.ClientSize = New System.Drawing.Size(778, 456)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "FrmPPICBuildupDetail"
        Me.Controls.SetChildIndex(Me.LayoutControl1, 0)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtQtyPallet.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUsedForCustomer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtKeterangan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPersentase.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtKapasitasMuat.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTinggi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtLebar.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPanjang.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtJenisPacking.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleLabelItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleLabelItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleLabelItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SimpleLabelItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents txtUsedForCustomer As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtKeterangan As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPersentase As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtKapasitasMuat As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtTinggi As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtLebar As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPanjang As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtJenisPacking As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleLabelItem3 As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents SimpleLabelItem1 As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents SimpleLabelItem2 As DevExpress.XtraLayout.SimpleLabelItem
    Friend WithEvents DxValidationProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents txtQtyPallet As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents SimpleLabelItem4 As DevExpress.XtraLayout.SimpleLabelItem
End Class
