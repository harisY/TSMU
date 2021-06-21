<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPPICLayoutGedungDetail
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
        Me.txtLokasi = New DevExpress.XtraEditors.TextEdit()
        Me.txtPF = New DevExpress.XtraEditors.TextEdit()
        Me.txtSeq = New DevExpress.XtraEditors.TextEdit()
        Me.txtUserCode = New DevExpress.XtraEditors.TextEdit()
        Me.txtGroup = New DevExpress.XtraEditors.TextEdit()
        Me.txtGedung = New DevExpress.XtraEditors.TextEdit()
        Me.txtSeqUser = New DevExpress.XtraEditors.TextEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DxValidationProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtLokasi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPF.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSeq.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtUserCode.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGroup.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGedung.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtSeqUser.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.LayoutControl1.Controls.Add(Me.txtLokasi)
        Me.LayoutControl1.Controls.Add(Me.txtPF)
        Me.LayoutControl1.Controls.Add(Me.txtSeq)
        Me.LayoutControl1.Controls.Add(Me.txtUserCode)
        Me.LayoutControl1.Controls.Add(Me.txtGroup)
        Me.LayoutControl1.Controls.Add(Me.txtGedung)
        Me.LayoutControl1.Controls.Add(Me.txtSeqUser)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 27)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(794, 156, 975, 600)
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(778, 429)
        Me.LayoutControl1.TabIndex = 1
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'txtLokasi
        '
        Me.txtLokasi.Location = New System.Drawing.Point(103, 204)
        Me.txtLokasi.MaximumSize = New System.Drawing.Size(100, 0)
        Me.txtLokasi.Name = "txtLokasi"
        Me.txtLokasi.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtLokasi.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtLokasi.Size = New System.Drawing.Size(100, 28)
        Me.txtLokasi.StyleController = Me.LayoutControl1
        Me.txtLokasi.TabIndex = 12
        '
        'txtPF
        '
        Me.txtPF.Location = New System.Drawing.Point(103, 140)
        Me.txtPF.MaximumSize = New System.Drawing.Size(100, 0)
        Me.txtPF.Name = "txtPF"
        Me.txtPF.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtPF.Properties.MaxLength = 5
        Me.txtPF.Size = New System.Drawing.Size(100, 28)
        Me.txtPF.StyleController = Me.LayoutControl1
        Me.txtPF.TabIndex = 11
        '
        'txtSeq
        '
        Me.txtSeq.Location = New System.Drawing.Point(103, 108)
        Me.txtSeq.MaximumSize = New System.Drawing.Size(100, 0)
        Me.txtSeq.Name = "txtSeq"
        Me.txtSeq.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtSeq.Properties.DisplayFormat.FormatString = "n0"
        Me.txtSeq.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtSeq.Properties.EditFormat.FormatString = "n0"
        Me.txtSeq.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtSeq.Properties.Mask.EditMask = "n0"
        Me.txtSeq.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtSeq.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtSeq.Size = New System.Drawing.Size(100, 28)
        Me.txtSeq.StyleController = Me.LayoutControl1
        Me.txtSeq.TabIndex = 10
        '
        'txtUserCode
        '
        Me.txtUserCode.Location = New System.Drawing.Point(103, 12)
        Me.txtUserCode.MaximumSize = New System.Drawing.Size(100, 0)
        Me.txtUserCode.Name = "txtUserCode"
        Me.txtUserCode.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtUserCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtUserCode.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtUserCode.Size = New System.Drawing.Size(100, 28)
        Me.txtUserCode.StyleController = Me.LayoutControl1
        Me.txtUserCode.TabIndex = 7
        '
        'txtGroup
        '
        Me.txtGroup.Location = New System.Drawing.Point(103, 44)
        Me.txtGroup.MaximumSize = New System.Drawing.Size(100, 0)
        Me.txtGroup.Name = "txtGroup"
        Me.txtGroup.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtGroup.Properties.DisplayFormat.FormatString = "n0"
        Me.txtGroup.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtGroup.Properties.EditFormat.FormatString = "n0"
        Me.txtGroup.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtGroup.Properties.Mask.EditMask = "n0"
        Me.txtGroup.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtGroup.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtGroup.Size = New System.Drawing.Size(100, 28)
        Me.txtGroup.StyleController = Me.LayoutControl1
        Me.txtGroup.TabIndex = 5
        '
        'txtGedung
        '
        Me.txtGedung.Location = New System.Drawing.Point(103, 172)
        Me.txtGedung.MaximumSize = New System.Drawing.Size(100, 0)
        Me.txtGedung.Name = "txtGedung"
        Me.txtGedung.Properties.MaxLength = 20
        Me.txtGedung.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtGedung.Size = New System.Drawing.Size(100, 28)
        Me.txtGedung.StyleController = Me.LayoutControl1
        Me.txtGedung.TabIndex = 4
        '
        'txtSeqUser
        '
        Me.txtSeqUser.Location = New System.Drawing.Point(103, 76)
        Me.txtSeqUser.MaximumSize = New System.Drawing.Size(100, 0)
        Me.txtSeqUser.Name = "txtSeqUser"
        Me.txtSeqUser.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtSeqUser.Properties.DisplayFormat.FormatString = "n0"
        Me.txtSeqUser.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtSeqUser.Properties.EditFormat.FormatString = "n0"
        Me.txtSeqUser.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtSeqUser.Properties.Mask.EditMask = "n0"
        Me.txtSeqUser.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtSeqUser.Properties.Name = "txtPartNo"
        Me.txtSeqUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtSeqUser.Size = New System.Drawing.Size(100, 28)
        Me.txtSeqUser.StyleController = Me.LayoutControl1
        Me.txtSeqUser.TabIndex = 6
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem9, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.LayoutControlItem1, Me.LayoutControlItem4})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(778, 429)
        Me.Root.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 224)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(758, 185)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtGroup
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 32)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(758, 32)
        Me.LayoutControlItem2.Text = "Group"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(88, 19)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtSeqUser
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 64)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(758, 32)
        Me.LayoutControlItem3.Text = "Seq User"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(88, 19)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.txtLokasi
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 192)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(758, 32)
        Me.LayoutControlItem9.Text = "Lokasi"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(88, 19)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.txtSeq
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(758, 32)
        Me.LayoutControlItem7.Text = "Seq"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(88, 19)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.txtPF
        Me.LayoutControlItem8.CustomizationFormText = "UsedForCustomer"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(0, 128)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(758, 32)
        Me.LayoutControlItem8.Text = "P/F"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(88, 19)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtGedung
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 160)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(758, 32)
        Me.LayoutControlItem1.Text = "Gedung"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(88, 19)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtUserCode
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(758, 32)
        Me.LayoutControlItem4.Text = "User Code   "
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(88, 19)
        '
        'FrmPPICLayoutGedungDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.ClientSize = New System.Drawing.Size(778, 456)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "FrmPPICLayoutGedungDetail"
        Me.Controls.SetChildIndex(Me.LayoutControl1, 0)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtLokasi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPF.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSeq.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtUserCode.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGroup.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGedung.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtSeqUser.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents txtPF As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSeq As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtUserCode As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtGroup As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents DxValidationProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents txtLokasi As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtGedung As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtSeqUser As DevExpress.XtraEditors.TextEdit
End Class
