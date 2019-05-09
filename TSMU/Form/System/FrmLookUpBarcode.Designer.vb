<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLookUpBarcode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmLookUpBarcode))
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.TxtKodePart = New DevExpress.XtraEditors.TextEdit()
        Me.CmbSite = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.CmbBulan = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.TxtFrom = New DevExpress.XtraEditors.SpinEdit()
        Me.TxtTo = New DevExpress.XtraEditors.SpinEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BtnPrint = New System.Windows.Forms.ToolStripButton()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.TxtKodePart.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbSite.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbBulan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFrom.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtTo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.TxtKodePart)
        Me.LayoutControl1.Controls.Add(Me.CmbSite)
        Me.LayoutControl1.Controls.Add(Me.CmbBulan)
        Me.LayoutControl1.Controls.Add(Me.TxtFrom)
        Me.LayoutControl1.Controls.Add(Me.TxtTo)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 25)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(296, 231)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'TxtKodePart
        '
        Me.TxtKodePart.Location = New System.Drawing.Point(66, 60)
        Me.TxtKodePart.Name = "TxtKodePart"
        Me.TxtKodePart.Size = New System.Drawing.Size(218, 20)
        Me.TxtKodePart.StyleController = Me.LayoutControl1
        Me.TxtKodePart.TabIndex = 6
        '
        'CmbSite
        '
        Me.CmbSite.Location = New System.Drawing.Point(66, 12)
        Me.CmbSite.Name = "CmbSite"
        Me.CmbSite.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CmbSite.Properties.Items.AddRange(New Object() {"TANGERANG", "CIKARANG"})
        Me.CmbSite.Size = New System.Drawing.Size(218, 20)
        Me.CmbSite.StyleController = Me.LayoutControl1
        Me.CmbSite.TabIndex = 4
        '
        'CmbBulan
        '
        Me.CmbBulan.Location = New System.Drawing.Point(66, 36)
        Me.CmbBulan.Name = "CmbBulan"
        Me.CmbBulan.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CmbBulan.Properties.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12"})
        Me.CmbBulan.Size = New System.Drawing.Size(218, 20)
        Me.CmbBulan.StyleController = Me.LayoutControl1
        Me.CmbBulan.TabIndex = 5
        '
        'TxtFrom
        '
        Me.TxtFrom.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TxtFrom.Location = New System.Drawing.Point(66, 84)
        Me.TxtFrom.Name = "TxtFrom"
        Me.TxtFrom.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtFrom.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.[Default]
        Me.TxtFrom.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.TxtFrom.Size = New System.Drawing.Size(81, 20)
        Me.TxtFrom.StyleController = Me.LayoutControl1
        Me.TxtFrom.TabIndex = 7
        '
        'TxtTo
        '
        Me.TxtTo.EditValue = New Decimal(New Integer() {0, 0, 0, 0})
        Me.TxtTo.Location = New System.Drawing.Point(206, 84)
        Me.TxtTo.Name = "TxtTo"
        Me.TxtTo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtTo.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.[Default]
        Me.TxtTo.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.TxtTo.Size = New System.Drawing.Size(78, 20)
        Me.TxtTo.StyleController = Me.LayoutControl1
        Me.TxtTo.TabIndex = 8
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(296, 231)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.CmbSite
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(276, 24)
        Me.LayoutControlItem1.Text = "Site"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(51, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 96)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(276, 115)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.CmbBulan
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(276, 24)
        Me.LayoutControlItem2.Text = "Bulan"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(51, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.TxtKodePart
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(276, 24)
        Me.LayoutControlItem3.Text = "Kode Part"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(51, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.TxtFrom
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(139, 24)
        Me.LayoutControlItem4.Text = "Page From"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(51, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.TxtTo
        Me.LayoutControlItem5.Location = New System.Drawing.Point(139, 72)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(137, 24)
        Me.LayoutControlItem5.Text = "To"
        Me.LayoutControlItem5.TextAlignMode = DevExpress.XtraLayout.TextAlignModeItem.CustomSize
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(50, 20)
        Me.LayoutControlItem5.TextToControlDistance = 5
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BtnPrint})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(296, 25)
        Me.ToolStrip1.TabIndex = 1
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BtnPrint
        '
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(52, 22)
        Me.BtnPrint.Text = "Print"
        '
        'FrmLookUpBarcode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(296, 256)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmLookUpBarcode"
        Me.Text = "Filter"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.TxtKodePart.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbSite.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbBulan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFrom.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtTo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BtnPrint As ToolStripButton
    Friend WithEvents TxtKodePart As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CmbSite As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CmbBulan As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents TxtFrom As DevExpress.XtraEditors.SpinEdit
    Friend WithEvents TxtTo As DevExpress.XtraEditors.SpinEdit
End Class
