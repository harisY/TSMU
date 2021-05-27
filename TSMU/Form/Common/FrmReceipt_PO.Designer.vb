<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReceipt_PO
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
        Me._TxtSiteID = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblnama = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me._TxtSampai = New DevExpress.XtraEditors.DateEdit()
        Me._TxtVendorID = New DevExpress.XtraEditors.ButtonEdit()
        Me._TxtVendorName = New DevExpress.XtraEditors.TextEdit()
        Me._TxtDari = New DevExpress.XtraEditors.DateEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Grid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me._TxtSiteID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._TxtSampai.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._TxtSampai.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._TxtVendorID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._TxtVendorName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._TxtDari.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._TxtDari.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me._TxtSiteID)
        Me.LayoutControl1.Controls.Add(Me.lblnama)
        Me.LayoutControl1.Controls.Add(Me.Button1)
        Me.LayoutControl1.Controls.Add(Me._TxtSampai)
        Me.LayoutControl1.Controls.Add(Me._TxtVendorID)
        Me.LayoutControl1.Controls.Add(Me._TxtVendorName)
        Me.LayoutControl1.Controls.Add(Me._TxtDari)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 27)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1104, 51)
        Me.LayoutControl1.TabIndex = 22
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        '_TxtSiteID
        '
        Me._TxtSiteID.EditValue = "ALL"
        Me._TxtSiteID.Location = New System.Drawing.Point(730, 12)
        Me._TxtSiteID.Name = "_TxtSiteID"
        Me._TxtSiteID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me._TxtSiteID.Properties.Items.AddRange(New Object() {"ALL", "TNG-U", "TSC3-U", "TNG-S", "TNG-SUBCON", "TSC3-S", "TSC3-SUBCO"})
        Me._TxtSiteID.Size = New System.Drawing.Size(64, 22)
        Me._TxtSiteID.StyleController = Me.LayoutControl1
        Me._TxtSiteID.TabIndex = 9
        '
        'lblnama
        '
        Me.lblnama.Location = New System.Drawing.Point(12, 12)
        Me.lblnama.Name = "lblnama"
        Me.lblnama.Size = New System.Drawing.Size(26, 27)
        Me.lblnama.TabIndex = 8
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(798, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(119, 27)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "View Data"
        Me.Button1.UseVisualStyleBackColor = True
        '
        '_TxtSampai
        '
        Me._TxtSampai.EditValue = Nothing
        Me._TxtSampai.Location = New System.Drawing.Point(267, 12)
        Me._TxtSampai.Name = "_TxtSampai"
        Me._TxtSampai.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me._TxtSampai.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me._TxtSampai.Size = New System.Drawing.Size(89, 22)
        Me._TxtSampai.StyleController = Me.LayoutControl1
        Me._TxtSampai.TabIndex = 11
        '
        '_TxtVendorID
        '
        Me._TxtVendorID.Location = New System.Drawing.Point(423, 12)
        Me._TxtVendorID.Name = "_TxtVendorID"
        Me._TxtVendorID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me._TxtVendorID.Size = New System.Drawing.Size(68, 22)
        Me._TxtVendorID.StyleController = Me.LayoutControl1
        Me._TxtVendorID.TabIndex = 12
        '
        '_TxtVendorName
        '
        Me._TxtVendorName.Location = New System.Drawing.Point(495, 12)
        Me._TxtVendorName.Name = "_TxtVendorName"
        Me._TxtVendorName.Properties.ReadOnly = True
        Me._TxtVendorName.Size = New System.Drawing.Size(168, 22)
        Me._TxtVendorName.StyleController = Me.LayoutControl1
        Me._TxtVendorName.TabIndex = 13
        '
        '_TxtDari
        '
        Me._TxtDari.EditValue = Nothing
        Me._TxtDari.Location = New System.Drawing.Point(105, 12)
        Me._TxtDari.Name = "_TxtDari"
        Me._TxtDari.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me._TxtDari.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me._TxtDari.Size = New System.Drawing.Size(95, 22)
        Me._TxtDari.StyleController = Me.LayoutControl1
        Me._TxtDari.TabIndex = 11
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.EmptySpaceItem1, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem4, Me.LayoutControlItem1, Me.LayoutControlItem7, Me.LayoutControlItem3, Me.LayoutControlItem8})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1104, 51)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(909, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(175, 31)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.Button1
        Me.LayoutControlItem5.Location = New System.Drawing.Point(786, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(123, 31)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.lblnama
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(30, 31)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me._TxtSampai
        Me.LayoutControlItem4.Location = New System.Drawing.Point(192, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(156, 31)
        Me.LayoutControlItem4.Text = "To "
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(60, 16)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me._TxtSiteID
        Me.LayoutControlItem1.Location = New System.Drawing.Point(655, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(131, 31)
        Me.LayoutControlItem1.Text = "SiteID"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(60, 16)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me._TxtVendorID
        Me.LayoutControlItem7.Location = New System.Drawing.Point(348, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(135, 31)
        Me.LayoutControlItem7.Text = "Vendor"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(60, 16)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me._TxtVendorName
        Me.LayoutControlItem3.Location = New System.Drawing.Point(483, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(172, 31)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me._TxtDari
        Me.LayoutControlItem8.CustomizationFormText = "To "
        Me.LayoutControlItem8.Location = New System.Drawing.Point(30, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(162, 31)
        Me.LayoutControlItem8.Text = "From Date"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(60, 16)
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.Location = New System.Drawing.Point(13, 73)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.Name = "Grid"
        Me.Grid.Size = New System.Drawing.Size(1060, 645)
        Me.Grid.TabIndex = 23
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.DetailHeight = 458
        Me.GridView1.FixedLineWidth = 3
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsClipboard.ClipboardMode = DevExpress.Export.ClipboardMode.Formatted
        Me.GridView1.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridView1.OptionsSelection.MultiSelect = True
        Me.GridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CellSelect
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'FrmReceipt_PO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.ClientSize = New System.Drawing.Size(1104, 759)
        Me.Controls.Add(Me.Grid)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "FrmReceipt_PO"
        Me.Controls.SetChildIndex(Me.LayoutControl1, 0)
        Me.Controls.SetChildIndex(Me.Grid, 0)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me._TxtSiteID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._TxtSampai.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._TxtSampai.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._TxtVendorID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._TxtVendorName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._TxtDari.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._TxtDari.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents _TxtSiteID As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblnama As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents _TxtSampai As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents _TxtVendorID As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents _TxtVendorName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents _TxtDari As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
End Class
