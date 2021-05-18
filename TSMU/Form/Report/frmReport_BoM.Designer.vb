<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmReport_BoM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReport_BoM))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbActive = New System.Windows.Forms.ComboBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Grid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ToolStrip2 = New System.Windows.Forms.ToolStrip()
        Me.btnLoad = New System.Windows.Forms.ToolStripButton()
        Me.ProgBar = New System.Windows.Forms.ToolStripProgressBar()
        Me.btnCari = New System.Windows.Forms.Button()
        Me._txtInvID = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbStatus = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbSite = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.cmbStatusM = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.GridMultiLevel = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.tsMultiLevel = New System.Windows.Forms.ToolStrip()
        Me.tsbMultiLevel = New System.Windows.Forms.ToolStripButton()
        Me.PBMultiLevel = New System.Windows.Forms.ToolStripProgressBar()
        Me._btnFind = New System.Windows.Forms.Button()
        Me._txtInvtID2 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.GridMaterial = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.tsMaterial = New System.Windows.Forms.ToolStrip()
        Me.tsbLoadMaterial = New System.Windows.Forms.ToolStripButton()
        Me.PBMaterial = New System.Windows.Forms.ToolStripProgressBar()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.GridHeaderBoM = New DevExpress.XtraGrid.GridControl()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ExportToExcelToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ToolStrip2.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.GridMultiLevel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsMultiLevel.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.GridMaterial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tsMaterial.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        CType(Me.GridHeaderBoM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(21, 45)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(5)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1339, 831)
        Me.TabControl1.TabIndex = 1
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.cmbActive)
        Me.TabPage1.Controls.Add(Me.Panel1)
        Me.TabPage1.Controls.Add(Me.btnCari)
        Me.TabPage1.Controls.Add(Me._txtInvID)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.cmbStatus)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.cmbSite)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 29)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(5)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(5)
        Me.TabPage1.Size = New System.Drawing.Size(1331, 798)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "View BoM Routing"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(379, 50)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 20)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Active"
        '
        'cmbActive
        '
        Me.cmbActive.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbActive.FormattingEnabled = True
        Me.cmbActive.Items.AddRange(New Object() {"ALL", "Subcon", "InHouse", "Discontinue"})
        Me.cmbActive.Location = New System.Drawing.Point(503, 47)
        Me.cmbActive.Margin = New System.Windows.Forms.Padding(5)
        Me.cmbActive.Name = "cmbActive"
        Me.cmbActive.Size = New System.Drawing.Size(199, 28)
        Me.cmbActive.TabIndex = 17
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.Controls.Add(Me.Grid)
        Me.Panel1.Controls.Add(Me.ToolStrip2)
        Me.Panel1.Location = New System.Drawing.Point(10, 99)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(5)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1305, 682)
        Me.Panel1.TabIndex = 16
        '
        'Grid
        '
        Me.Grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(5)
        Me.Grid.Location = New System.Drawing.Point(0, 39)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Margin = New System.Windows.Forms.Padding(5)
        Me.Grid.Name = "Grid"
        Me.Grid.Size = New System.Drawing.Size(1305, 643)
        Me.Grid.TabIndex = 3
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.DetailHeight = 539
        Me.GridView1.FixedLineWidth = 4
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsCustomization.AllowSort = False
        Me.GridView1.OptionsPrint.PrintHorzLines = False
        Me.GridView1.OptionsPrint.PrintVertLines = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'ToolStrip2
        '
        Me.ToolStrip2.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ToolStrip2.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnLoad, Me.ProgBar})
        Me.ToolStrip2.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip2.Name = "ToolStrip2"
        Me.ToolStrip2.Size = New System.Drawing.Size(1305, 39)
        Me.ToolStrip2.TabIndex = 0
        Me.ToolStrip2.Text = "ToolStrip2"
        '
        'btnLoad
        '
        Me.btnLoad.Image = CType(resources.GetObject("btnLoad.Image"), System.Drawing.Image)
        Me.btnLoad.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(117, 36)
        Me.btnLoad.Text = "Load Data"
        '
        'ProgBar
        '
        Me.ProgBar.Name = "ProgBar"
        Me.ProgBar.Size = New System.Drawing.Size(166, 36)
        '
        'btnCari
        '
        Me.btnCari.Image = CType(resources.GetObject("btnCari.Image"), System.Drawing.Image)
        Me.btnCari.Location = New System.Drawing.Point(891, 6)
        Me.btnCari.Margin = New System.Windows.Forms.Padding(5)
        Me.btnCari.Name = "btnCari"
        Me.btnCari.Size = New System.Drawing.Size(41, 32)
        Me.btnCari.TabIndex = 14
        Me.btnCari.UseVisualStyleBackColor = True
        '
        '_txtInvID
        '
        Me._txtInvID.Location = New System.Drawing.Point(503, 9)
        Me._txtInvID.Margin = New System.Windows.Forms.Padding(5)
        Me._txtInvID.Name = "_txtInvID"
        Me._txtInvID.Size = New System.Drawing.Size(378, 26)
        Me._txtInvID.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(379, 12)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(89, 20)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Invetory ID"
        '
        'cmbStatus
        '
        Me.cmbStatus.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbStatus.FormattingEnabled = True
        Me.cmbStatus.Items.AddRange(New Object() {"ALL", "Regular", "Project"})
        Me.cmbStatus.Location = New System.Drawing.Point(134, 47)
        Me.cmbStatus.Margin = New System.Windows.Forms.Padding(5)
        Me.cmbStatus.Name = "cmbStatus"
        Me.cmbStatus.Size = New System.Drawing.Size(199, 28)
        Me.cmbStatus.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 50)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(57, 20)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Status"
        '
        'cmbSite
        '
        Me.cmbSite.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbSite.FormattingEnabled = True
        Me.cmbSite.Items.AddRange(New Object() {"ALL", "TSC1", "TSC3"})
        Me.cmbSite.Location = New System.Drawing.Point(134, 9)
        Me.cmbSite.Margin = New System.Windows.Forms.Padding(5)
        Me.cmbSite.Name = "cmbSite"
        Me.cmbSite.Size = New System.Drawing.Size(199, 28)
        Me.cmbSite.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 12)
        Me.Label1.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 20)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Site"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.cmbStatusM)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Controls.Add(Me._btnFind)
        Me.TabPage2.Controls.Add(Me._txtInvtID2)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Location = New System.Drawing.Point(4, 29)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(5)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(5)
        Me.TabPage2.Size = New System.Drawing.Size(1331, 798)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Multi Level BoM"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'cmbStatusM
        '
        Me.cmbStatusM.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmbStatusM.FormattingEnabled = True
        Me.cmbStatusM.Items.AddRange(New Object() {"Regular", "Project"})
        Me.cmbStatusM.Location = New System.Drawing.Point(134, 45)
        Me.cmbStatusM.Margin = New System.Windows.Forms.Padding(5)
        Me.cmbStatusM.Name = "cmbStatusM"
        Me.cmbStatusM.Size = New System.Drawing.Size(199, 28)
        Me.cmbStatusM.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 45)
        Me.Label4.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 20)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Status"
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.Controls.Add(Me.GridMultiLevel)
        Me.Panel2.Controls.Add(Me.tsMultiLevel)
        Me.Panel2.Location = New System.Drawing.Point(10, 84)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(5)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1305, 699)
        Me.Panel2.TabIndex = 19
        '
        'GridMultiLevel
        '
        Me.GridMultiLevel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridMultiLevel.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(5)
        Me.GridMultiLevel.Location = New System.Drawing.Point(0, 39)
        Me.GridMultiLevel.MainView = Me.GridView2
        Me.GridMultiLevel.Margin = New System.Windows.Forms.Padding(5)
        Me.GridMultiLevel.Name = "GridMultiLevel"
        Me.GridMultiLevel.Size = New System.Drawing.Size(1305, 660)
        Me.GridMultiLevel.TabIndex = 4
        Me.GridMultiLevel.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.DetailHeight = 539
        Me.GridView2.FixedLineWidth = 4
        Me.GridView2.GridControl = Me.GridMultiLevel
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.Editable = False
        Me.GridView2.OptionsCustomization.AllowSort = False
        Me.GridView2.OptionsPrint.PrintHorzLines = False
        Me.GridView2.OptionsPrint.PrintVertLines = False
        Me.GridView2.OptionsView.ColumnAutoWidth = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'tsMultiLevel
        '
        Me.tsMultiLevel.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMultiLevel.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbMultiLevel, Me.PBMultiLevel})
        Me.tsMultiLevel.Location = New System.Drawing.Point(0, 0)
        Me.tsMultiLevel.Name = "tsMultiLevel"
        Me.tsMultiLevel.Size = New System.Drawing.Size(1305, 39)
        Me.tsMultiLevel.TabIndex = 0
        Me.tsMultiLevel.Text = "ToolStrip3"
        '
        'tsbMultiLevel
        '
        Me.tsbMultiLevel.Image = CType(resources.GetObject("tsbMultiLevel.Image"), System.Drawing.Image)
        Me.tsbMultiLevel.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbMultiLevel.Name = "tsbMultiLevel"
        Me.tsbMultiLevel.Size = New System.Drawing.Size(117, 36)
        Me.tsbMultiLevel.Text = "Load Data"
        '
        'PBMultiLevel
        '
        Me.PBMultiLevel.Name = "PBMultiLevel"
        Me.PBMultiLevel.Size = New System.Drawing.Size(166, 36)
        '
        '_btnFind
        '
        Me._btnFind.Image = CType(resources.GetObject("_btnFind.Image"), System.Drawing.Image)
        Me._btnFind.Location = New System.Drawing.Point(644, 9)
        Me._btnFind.Margin = New System.Windows.Forms.Padding(5)
        Me._btnFind.Name = "_btnFind"
        Me._btnFind.Size = New System.Drawing.Size(41, 32)
        Me._btnFind.TabIndex = 17
        Me._btnFind.UseVisualStyleBackColor = True
        '
        '_txtInvtID2
        '
        Me._txtInvtID2.Location = New System.Drawing.Point(134, 9)
        Me._txtInvtID2.Margin = New System.Windows.Forms.Padding(5)
        Me._txtInvtID2.Name = "_txtInvtID2"
        Me._txtInvtID2.Size = New System.Drawing.Size(508, 26)
        Me._txtInvtID2.TabIndex = 16
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 9)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 20)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "Invetory ID"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Panel3)
        Me.TabPage3.Location = New System.Drawing.Point(4, 29)
        Me.TabPage3.Margin = New System.Windows.Forms.Padding(5)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(5)
        Me.TabPage3.Size = New System.Drawing.Size(1331, 798)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Material Used By"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel3.Controls.Add(Me.GridMaterial)
        Me.Panel3.Controls.Add(Me.tsMaterial)
        Me.Panel3.Location = New System.Drawing.Point(10, 5)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(5)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1305, 776)
        Me.Panel3.TabIndex = 19
        '
        'GridMaterial
        '
        Me.GridMaterial.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridMaterial.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(5)
        Me.GridMaterial.Location = New System.Drawing.Point(0, 39)
        Me.GridMaterial.MainView = Me.GridView3
        Me.GridMaterial.Margin = New System.Windows.Forms.Padding(5)
        Me.GridMaterial.Name = "GridMaterial"
        Me.GridMaterial.Size = New System.Drawing.Size(1305, 737)
        Me.GridMaterial.TabIndex = 4
        Me.GridMaterial.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.DetailHeight = 539
        Me.GridView3.FixedLineWidth = 4
        Me.GridView3.GridControl = Me.GridMaterial
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsBehavior.Editable = False
        Me.GridView3.OptionsCustomization.AllowSort = False
        Me.GridView3.OptionsPrint.PrintHorzLines = False
        Me.GridView3.OptionsPrint.PrintVertLines = False
        Me.GridView3.OptionsView.ColumnAutoWidth = False
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'tsMaterial
        '
        Me.tsMaterial.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.tsMaterial.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbLoadMaterial, Me.PBMaterial})
        Me.tsMaterial.Location = New System.Drawing.Point(0, 0)
        Me.tsMaterial.Name = "tsMaterial"
        Me.tsMaterial.Size = New System.Drawing.Size(1305, 39)
        Me.tsMaterial.TabIndex = 0
        Me.tsMaterial.Text = "ToolStrip4"
        '
        'tsbLoadMaterial
        '
        Me.tsbLoadMaterial.Image = CType(resources.GetObject("tsbLoadMaterial.Image"), System.Drawing.Image)
        Me.tsbLoadMaterial.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbLoadMaterial.Name = "tsbLoadMaterial"
        Me.tsbLoadMaterial.Size = New System.Drawing.Size(117, 36)
        Me.tsbLoadMaterial.Text = "Load Data"
        '
        'PBMaterial
        '
        Me.PBMaterial.Name = "PBMaterial"
        Me.PBMaterial.Size = New System.Drawing.Size(166, 36)
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.GridHeaderBoM)
        Me.TabPage4.Location = New System.Drawing.Point(4, 29)
        Me.TabPage4.Margin = New System.Windows.Forms.Padding(5)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(5)
        Me.TabPage4.Size = New System.Drawing.Size(1331, 798)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Header BoM"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'GridHeaderBoM
        '
        Me.GridHeaderBoM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridHeaderBoM.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(5)
        Me.GridHeaderBoM.Location = New System.Drawing.Point(5, 5)
        Me.GridHeaderBoM.MainView = Me.GridView4
        Me.GridHeaderBoM.Margin = New System.Windows.Forms.Padding(5)
        Me.GridHeaderBoM.Name = "GridHeaderBoM"
        Me.GridHeaderBoM.Size = New System.Drawing.Size(1321, 788)
        Me.GridHeaderBoM.TabIndex = 3
        Me.GridHeaderBoM.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView4})
        '
        'GridView4
        '
        Me.GridView4.DetailHeight = 539
        Me.GridView4.FixedLineWidth = 4
        Me.GridView4.GridControl = Me.GridHeaderBoM
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsBehavior.Editable = False
        Me.GridView4.OptionsPrint.PrintHorzLines = False
        Me.GridView4.OptionsPrint.PrintVertLines = False
        Me.GridView4.OptionsView.ShowAutoFilterRow = True
        Me.GridView4.OptionsView.ShowGroupPanel = False
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExportToExcelToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(202, 34)
        '
        'ExportToExcelToolStripMenuItem
        '
        Me.ExportToExcelToolStripMenuItem.Name = "ExportToExcelToolStripMenuItem"
        Me.ExportToExcelToolStripMenuItem.Size = New System.Drawing.Size(201, 30)
        Me.ExportToExcelToolStripMenuItem.Text = "Export To Excel"
        '
        'frmReport_BoM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.ClientSize = New System.Drawing.Size(1380, 894)
        Me.Controls.Add(Me.TabControl1)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "frmReport_BoM"
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ToolStrip2.ResumeLayout(False)
        Me.ToolStrip2.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.GridMultiLevel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsMultiLevel.ResumeLayout(False)
        Me.tsMultiLevel.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.GridMaterial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tsMaterial.ResumeLayout(False)
        Me.tsMaterial.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        CType(Me.GridHeaderBoM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbSite As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ExportToExcelToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents btnCari As System.Windows.Forms.Button
    Friend WithEvents _txtInvID As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents _btnFind As System.Windows.Forms.Button
    Friend WithEvents _txtInvtID2 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As TabPage
    Friend WithEvents Panel1 As Panel
    Friend WithEvents ToolStrip2 As ToolStrip
    Friend WithEvents btnLoad As ToolStripButton
    Friend WithEvents ProgBar As ToolStripProgressBar
    Friend WithEvents Panel2 As Panel
    Friend WithEvents tsMultiLevel As ToolStrip
    Friend WithEvents tsbMultiLevel As ToolStripButton
    Friend WithEvents PBMultiLevel As ToolStripProgressBar
    Friend WithEvents Panel3 As Panel
    Friend WithEvents tsMaterial As ToolStrip
    Friend WithEvents tsbLoadMaterial As ToolStripButton
    Friend WithEvents PBMaterial As ToolStripProgressBar
    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridMultiLevel As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridMaterial As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TabPage4 As TabPage
    Friend WithEvents GridHeaderBoM As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents cmbStatusM As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents cmbActive As ComboBox
End Class
