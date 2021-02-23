<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmViewGL
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
        Me._TxtModule = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.lblnama = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me._TxtPerpost = New DevExpress.XtraEditors.ComboBoxEdit()
        Me._txtaccount = New DevExpress.XtraEditors.ButtonEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.Grid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me._TxtModule.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._TxtPerpost.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._txtaccount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me._TxtModule)
        Me.LayoutControl1.Controls.Add(Me.lblnama)
        Me.LayoutControl1.Controls.Add(Me.Button1)
        Me.LayoutControl1.Controls.Add(Me._TxtPerpost)
        Me.LayoutControl1.Controls.Add(Me._txtaccount)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 27)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1104, 51)
        Me.LayoutControl1.TabIndex = 22
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        '_TxtModule
        '
        Me._TxtModule.EditValue = "ALL"
        Me._TxtModule.Location = New System.Drawing.Point(428, 12)
        Me._TxtModule.Name = "_TxtModule"
        Me._TxtModule.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me._TxtModule.Properties.Items.AddRange(New Object() {"AP", "AR", "CA", "CM", "GL", "IN", "PO"})
        Me._TxtModule.Size = New System.Drawing.Size(118, 22)
        Me._TxtModule.StyleController = Me.LayoutControl1
        Me._TxtModule.TabIndex = 14
        '
        'lblnama
        '
        Me.lblnama.Location = New System.Drawing.Point(12, 12)
        Me.lblnama.Name = "lblnama"
        Me.lblnama.Size = New System.Drawing.Size(65, 27)
        Me.lblnama.TabIndex = 8
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(550, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(85, 27)
        Me.Button1.TabIndex = 7
        Me.Button1.Text = "View Data"
        Me.Button1.UseVisualStyleBackColor = True
        '
        '_TxtPerpost
        '
        Me._TxtPerpost.Location = New System.Drawing.Point(129, 12)
        Me._TxtPerpost.Margin = New System.Windows.Forms.Padding(4)
        Me._TxtPerpost.Name = "_TxtPerpost"
        Me._TxtPerpost.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me._TxtPerpost.Size = New System.Drawing.Size(103, 22)
        Me._TxtPerpost.StyleController = Me.LayoutControl1
        Me._TxtPerpost.TabIndex = 5
        '
        '_txtaccount
        '
        Me._txtaccount.EditValue = "ALL"
        Me._txtaccount.Location = New System.Drawing.Point(284, 12)
        Me._txtaccount.Name = "_txtaccount"
        Me._txtaccount.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me._txtaccount.Size = New System.Drawing.Size(92, 22)
        Me._txtaccount.StyleController = Me.LayoutControl1
        Me._txtaccount.TabIndex = 9
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.EmptySpaceItem1, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem1, Me.LayoutControlItem7})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1104, 51)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me._TxtPerpost
        Me.LayoutControlItem2.Location = New System.Drawing.Point(69, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(155, 31)
        Me.LayoutControlItem2.Text = "Perpost"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(45, 16)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(627, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(457, 31)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.Button1
        Me.LayoutControlItem5.Location = New System.Drawing.Point(538, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(89, 31)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.lblnama
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(69, 31)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me._txtaccount
        Me.LayoutControlItem1.Location = New System.Drawing.Point(224, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(144, 31)
        Me.LayoutControlItem1.Text = "Account"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(45, 16)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me._TxtModule
        Me.LayoutControlItem7.Location = New System.Drawing.Point(368, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(170, 31)
        Me.LayoutControlItem7.Text = "Module"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(45, 16)
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
        Me.Grid.Size = New System.Drawing.Size(1072, 645)
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
        'FrmViewGL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.ClientSize = New System.Drawing.Size(1104, 759)
        Me.Controls.Add(Me.Grid)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "FrmViewGL"
        Me.Controls.SetChildIndex(Me.LayoutControl1, 0)
        Me.Controls.SetChildIndex(Me.Grid, 0)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me._TxtModule.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._TxtPerpost.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._txtaccount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents _TxtModule As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents lblnama As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents _TxtPerpost As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents _txtaccount As DevExpress.XtraEditors.ButtonEdit
End Class
