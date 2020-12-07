<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReport_Harigami1
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
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExportToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.Grid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.TxtType = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.TxtDari = New DevExpress.XtraEditors.DateEdit()
        Me.TxtSampai = New DevExpress.XtraEditors.DateEdit()
        Me.TxtFileNo = New DevExpress.XtraEditors.ButtonEdit()
        Me.TxtPartNo = New DevExpress.XtraEditors.TextEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.TxtType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDari.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDari.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSampai.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSampai.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtFileNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPartNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportToExcelToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(180, 28)
        '
        'ExportToExcelToolStripMenuItem
        '
        Me.ExportToExcelToolStripMenuItem.Name = "ExportToExcelToolStripMenuItem"
        Me.ExportToExcelToolStripMenuItem.Size = New System.Drawing.Size(179, 24)
        Me.ExportToExcelToolStripMenuItem.Text = "Export To Excel"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.Grid, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LayoutControl1, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 27)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8.45839!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 91.54161!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1104, 733)
        Me.TableLayoutPanel1.TabIndex = 2
        '
        'Grid
        '
        Me.Grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.Location = New System.Drawing.Point(4, 66)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.Name = "Grid"
        Me.Grid.Size = New System.Drawing.Size(1096, 663)
        Me.Grid.TabIndex = 4
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.DetailHeight = 458
        Me.GridView1.FixedLineWidth = 3
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsPrint.PrintHorzLines = False
        Me.GridView1.OptionsPrint.PrintVertLines = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.TxtType)
        Me.LayoutControl1.Controls.Add(Me.TxtDari)
        Me.LayoutControl1.Controls.Add(Me.TxtSampai)
        Me.LayoutControl1.Controls.Add(Me.TxtFileNo)
        Me.LayoutControl1.Controls.Add(Me.TxtPartNo)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(3, 3)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(1098, 56)
        Me.LayoutControl1.TabIndex = 5
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'TxtType
        '
        Me.TxtType.Location = New System.Drawing.Point(593, 12)
        Me.TxtType.Name = "TxtType"
        Me.TxtType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtType.Properties.Items.AddRange(New Object() {"ALL", "SPIS", "SPPS"})
        Me.TxtType.Size = New System.Drawing.Size(131, 22)
        Me.TxtType.StyleController = Me.LayoutControl1
        Me.TxtType.TabIndex = 5
        '
        'TxtDari
        '
        Me.TxtDari.EditValue = Nothing
        Me.TxtDari.Location = New System.Drawing.Point(774, 12)
        Me.TxtDari.Name = "TxtDari"
        Me.TxtDari.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtDari.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtDari.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.TxtDari.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TxtDari.Properties.EditFormat.FormatString = "dd-MM-yyyy"
        Me.TxtDari.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TxtDari.Properties.Mask.EditMask = ""
        Me.TxtDari.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.TxtDari.Size = New System.Drawing.Size(131, 22)
        Me.TxtDari.StyleController = Me.LayoutControl1
        Me.TxtDari.TabIndex = 6
        '
        'TxtSampai
        '
        Me.TxtSampai.EditValue = Nothing
        Me.TxtSampai.Location = New System.Drawing.Point(955, 12)
        Me.TxtSampai.Name = "TxtSampai"
        Me.TxtSampai.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtSampai.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtSampai.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.TxtSampai.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TxtSampai.Properties.EditFormat.FormatString = "dd-MM-yyyy"
        Me.TxtSampai.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TxtSampai.Properties.Mask.EditMask = ""
        Me.TxtSampai.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.TxtSampai.Size = New System.Drawing.Size(131, 22)
        Me.TxtSampai.StyleController = Me.LayoutControl1
        Me.TxtSampai.TabIndex = 8
        '
        'TxtFileNo
        '
        Me.TxtFileNo.Location = New System.Drawing.Point(58, 12)
        Me.TxtFileNo.Name = "TxtFileNo"
        Me.TxtFileNo.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtFileNo.Size = New System.Drawing.Size(206, 22)
        Me.TxtFileNo.StyleController = Me.LayoutControl1
        Me.TxtFileNo.TabIndex = 4
        '
        'TxtPartNo
        '
        Me.TxtPartNo.Location = New System.Drawing.Point(314, 12)
        Me.TxtPartNo.Name = "TxtPartNo"
        Me.TxtPartNo.Properties.ReadOnly = True
        Me.TxtPartNo.Size = New System.Drawing.Size(229, 22)
        Me.TxtPartNo.StyleController = Me.LayoutControl1
        Me.TxtPartNo.TabIndex = 7
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(1098, 56)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.TxtFileNo
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(256, 26)
        Me.LayoutControlItem1.Text = "File No"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(43, 16)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 26)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(1078, 10)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.TxtType
        Me.LayoutControlItem2.Location = New System.Drawing.Point(535, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(181, 26)
        Me.LayoutControlItem2.Text = "Type"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(43, 16)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.TxtDari
        Me.LayoutControlItem3.Location = New System.Drawing.Point(716, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(181, 26)
        Me.LayoutControlItem3.Text = "Dari"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(43, 16)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.TxtPartNo
        Me.LayoutControlItem4.Location = New System.Drawing.Point(256, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(279, 26)
        Me.LayoutControlItem4.Text = "Part No"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(43, 16)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.TxtSampai
        Me.LayoutControlItem5.Location = New System.Drawing.Point(897, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(181, 26)
        Me.LayoutControlItem5.Text = "Sampai"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(43, 16)
        '
        'frmReport_Harigami1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.ClientSize = New System.Drawing.Size(1104, 760)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmReport_Harigami1"
        Me.Controls.SetChildIndex(Me.TableLayoutPanel1, 0)
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.TxtType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDari.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDari.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSampai.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSampai.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtFileNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPartNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExportToExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtTglScan As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtTgl1 As DateTimePicker
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents TxtType As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents TxtDari As DevExpress.XtraEditors.DateEdit
    Friend WithEvents TxtSampai As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TxtFileNo As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents TxtPartNo As DevExpress.XtraEditors.TextEdit
End Class
