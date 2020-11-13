<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frm_CR_UserCreateDetail
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
        Me.RB_Budget = New System.Windows.Forms.RadioButton()
        Me.RB_NonBudget = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.T_RequirementDate = New DevExpress.XtraEditors.DateEdit()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.T_PO = New System.Windows.Forms.TextBox()
        Me.BBeritaAcara = New System.Windows.Forms.Button()
        Me.BMold = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.RBPO = New System.Windows.Forms.RadioButton()
        Me.RBNonPO = New System.Windows.Forms.RadioButton()
        Me.T_Spesification = New DevExpress.XtraEditors.TextEdit()
        Me.T_Reason = New DevExpress.XtraEditors.TextEdit()
        Me.BAddRows = New System.Windows.Forms.Button()
        Me.T_CRType = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.T_NameItem = New DevExpress.XtraEditors.TextEdit()
        Me.T_CRNo = New DevExpress.XtraEditors.TextEdit()
        Me.T_Dept = New DevExpress.XtraEditors.CheckedComboBoxEdit()
        Me.T_Parent = New DevExpress.XtraEditors.ButtonEdit()
        Me.T_ParentAmount = New DevExpress.XtraEditors.TextEdit()
        Me.TCustomer = New DevExpress.XtraEditors.ButtonEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem16 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.BehaviorManager1 = New DevExpress.Utils.Behaviors.BehaviorManager(Me.components)
        Me.Grid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NameOfGoods = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Spesification = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Model = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SalesType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.C_SalesType = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.C_Qty = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.Price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.C_Price = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.PTotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.C_Amount_Barang = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.Curr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CurrRepository = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.Rate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Account = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BAccount = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Remaining = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PTotalRP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TotalIdr = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Check_OK = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Check_Rev = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Check_Del = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.C_Amount = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.C_Check = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.T_Remark = New DevExpress.XtraEditors.TextEdit()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.T_Charged = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.T_ModelName = New DevExpress.XtraEditors.TextEdit()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.T_DS = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.T_CustomerName = New DevExpress.XtraEditors.TextEdit()
        Me.Grid3 = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CurrEdit = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemSpinEdit3 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.RepositoryItemSpinEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.Grid4 = New DevExpress.XtraGrid.GridControl()
        Me.GridView4 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.RepositoryItemSpinEdit4 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.RepositoryItemSpinEdit6 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.RepositoryItemSpinEdit5 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.C_Term = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Grid5 = New DevExpress.XtraGrid.GridControl()
        Me.GridView5 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Opinion = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemSpinEdit7 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.RepositoryItemSpinEdit8 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.RepositoryItemSpinEdit9 = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.RepositoryItemTextEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.BPrint = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        CType(Me.T_RequirementDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_RequirementDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.T_Spesification.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Reason.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_CRType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_NameItem.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_CRNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Dept.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Parent.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_ParentAmount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TCustomer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_SalesType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_Qty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_Price, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_Amount_Barang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrRepository, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotalIdr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Check_OK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Check_Rev, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Check_Del, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_Amount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_Check, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.T_Remark.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_Charged.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_ModelName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_DS.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_CustomerName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrEdit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_Term.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Grid5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Opinion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemSpinEdit9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RB_Budget
        '
        Me.RB_Budget.AutoSize = True
        Me.RB_Budget.Location = New System.Drawing.Point(6, 9)
        Me.RB_Budget.Name = "RB_Budget"
        Me.RB_Budget.Size = New System.Drawing.Size(59, 17)
        Me.RB_Budget.TabIndex = 2
        Me.RB_Budget.TabStop = True
        Me.RB_Budget.Text = "Budget"
        Me.RB_Budget.UseVisualStyleBackColor = True
        '
        'RB_NonBudget
        '
        Me.RB_NonBudget.AutoSize = True
        Me.RB_NonBudget.Location = New System.Drawing.Point(74, 9)
        Me.RB_NonBudget.Name = "RB_NonBudget"
        Me.RB_NonBudget.Size = New System.Drawing.Size(82, 17)
        Me.RB_NonBudget.TabIndex = 3
        Me.RB_NonBudget.TabStop = True
        Me.RB_NonBudget.Text = "Non Budget"
        Me.RB_NonBudget.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RB_Budget)
        Me.GroupBox1.Controls.Add(Me.RB_NonBudget)
        Me.GroupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox1.Location = New System.Drawing.Point(345, 84)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(189, 30)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'T_RequirementDate
        '
        Me.T_RequirementDate.EditValue = Nothing
        Me.T_RequirementDate.Location = New System.Drawing.Point(87, 36)
        Me.T_RequirementDate.Name = "T_RequirementDate"
        Me.T_RequirementDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.T_RequirementDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.T_RequirementDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.T_RequirementDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.T_RequirementDate.Properties.EditFormat.FormatString = "dd-MM-yyyy"
        Me.T_RequirementDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.T_RequirementDate.Properties.Mask.EditMask = "dd-MM-yyyy"
        Me.T_RequirementDate.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.T_RequirementDate.Size = New System.Drawing.Size(179, 20)
        Me.T_RequirementDate.StyleController = Me.LayoutControl1
        Me.T_RequirementDate.TabIndex = 6
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.T_PO)
        Me.LayoutControl1.Controls.Add(Me.BBeritaAcara)
        Me.LayoutControl1.Controls.Add(Me.BMold)
        Me.LayoutControl1.Controls.Add(Me.GroupBox3)
        Me.LayoutControl1.Controls.Add(Me.T_Spesification)
        Me.LayoutControl1.Controls.Add(Me.T_Reason)
        Me.LayoutControl1.Controls.Add(Me.BAddRows)
        Me.LayoutControl1.Controls.Add(Me.T_CRType)
        Me.LayoutControl1.Controls.Add(Me.T_NameItem)
        Me.LayoutControl1.Controls.Add(Me.T_RequirementDate)
        Me.LayoutControl1.Controls.Add(Me.T_CRNo)
        Me.LayoutControl1.Controls.Add(Me.GroupBox1)
        Me.LayoutControl1.Controls.Add(Me.T_Dept)
        Me.LayoutControl1.Controls.Add(Me.T_Parent)
        Me.LayoutControl1.Controls.Add(Me.T_ParentAmount)
        Me.LayoutControl1.Controls.Add(Me.TCustomer)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 27)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(0, 385, 472, 343)
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(1173, 126)
        Me.LayoutControl1.TabIndex = 98
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'T_PO
        '
        Me.T_PO.Enabled = False
        Me.T_PO.Location = New System.Drawing.Point(613, 12)
        Me.T_PO.Name = "T_PO"
        Me.T_PO.Size = New System.Drawing.Size(209, 20)
        Me.T_PO.TabIndex = 98
        '
        'BBeritaAcara
        '
        Me.BBeritaAcara.Enabled = False
        Me.BBeritaAcara.Location = New System.Drawing.Point(826, 84)
        Me.BBeritaAcara.Name = "BBeritaAcara"
        Me.BBeritaAcara.Size = New System.Drawing.Size(104, 30)
        Me.BBeritaAcara.TabIndex = 97
        Me.BBeritaAcara.Text = "Berita Acara"
        Me.BBeritaAcara.UseVisualStyleBackColor = True
        '
        'BMold
        '
        Me.BMold.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BMold.Location = New System.Drawing.Point(934, 84)
        Me.BMold.Name = "BMold"
        Me.BMold.Size = New System.Drawing.Size(107, 30)
        Me.BMold.TabIndex = 79
        Me.BMold.Text = "Mold"
        Me.BMold.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.RBPO)
        Me.GroupBox3.Controls.Add(Me.RBNonPO)
        Me.GroupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.GroupBox3.Location = New System.Drawing.Point(87, 84)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(179, 30)
        Me.GroupBox3.TabIndex = 93
        Me.GroupBox3.TabStop = False
        '
        'RBPO
        '
        Me.RBPO.AutoSize = True
        Me.RBPO.Location = New System.Drawing.Point(6, 9)
        Me.RBPO.Name = "RBPO"
        Me.RBPO.Size = New System.Drawing.Size(40, 17)
        Me.RBPO.TabIndex = 2
        Me.RBPO.TabStop = True
        Me.RBPO.Text = "PO"
        Me.RBPO.UseVisualStyleBackColor = True
        '
        'RBNonPO
        '
        Me.RBNonPO.AutoSize = True
        Me.RBNonPO.Location = New System.Drawing.Point(64, 9)
        Me.RBNonPO.Name = "RBNonPO"
        Me.RBNonPO.Size = New System.Drawing.Size(63, 17)
        Me.RBNonPO.TabIndex = 3
        Me.RBNonPO.TabStop = True
        Me.RBNonPO.Text = "Non PO"
        Me.RBNonPO.UseVisualStyleBackColor = True
        '
        'T_Spesification
        '
        Me.T_Spesification.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.T_Spesification.Location = New System.Drawing.Point(613, 60)
        Me.T_Spesification.Name = "T_Spesification"
        Me.T_Spesification.Size = New System.Drawing.Size(548, 20)
        Me.T_Spesification.StyleController = Me.LayoutControl1
        Me.T_Spesification.TabIndex = 94
        '
        'T_Reason
        '
        Me.T_Reason.Location = New System.Drawing.Point(345, 60)
        Me.T_Reason.Name = "T_Reason"
        Me.T_Reason.Size = New System.Drawing.Size(189, 20)
        Me.T_Reason.StyleController = Me.LayoutControl1
        Me.T_Reason.TabIndex = 95
        '
        'BAddRows
        '
        Me.BAddRows.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BAddRows.Location = New System.Drawing.Point(1045, 84)
        Me.BAddRows.Name = "BAddRows"
        Me.BAddRows.Size = New System.Drawing.Size(116, 30)
        Me.BAddRows.TabIndex = 78
        Me.BAddRows.Text = "Add Rows"
        Me.BAddRows.UseVisualStyleBackColor = True
        '
        'T_CRType
        '
        Me.T_CRType.EditValue = ""
        Me.T_CRType.Location = New System.Drawing.Point(87, 12)
        Me.T_CRType.Name = "T_CRType"
        Me.T_CRType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.T_CRType.Size = New System.Drawing.Size(179, 20)
        Me.T_CRType.StyleController = Me.LayoutControl1
        Me.T_CRType.TabIndex = 4
        '
        'T_NameItem
        '
        Me.T_NameItem.Location = New System.Drawing.Point(345, 36)
        Me.T_NameItem.Name = "T_NameItem"
        Me.T_NameItem.Size = New System.Drawing.Size(189, 20)
        Me.T_NameItem.StyleController = Me.LayoutControl1
        Me.T_NameItem.TabIndex = 89
        '
        'T_CRNo
        '
        Me.T_CRNo.Location = New System.Drawing.Point(345, 12)
        Me.T_CRNo.Name = "T_CRNo"
        Me.T_CRNo.Properties.MaxLength = 49
        Me.T_CRNo.Size = New System.Drawing.Size(189, 20)
        Me.T_CRNo.StyleController = Me.LayoutControl1
        Me.T_CRNo.TabIndex = 1
        '
        'T_Dept
        '
        Me.T_Dept.EditValue = ""
        Me.T_Dept.Location = New System.Drawing.Point(87, 60)
        Me.T_Dept.Name = "T_Dept"
        Me.T_Dept.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.T_Dept.Size = New System.Drawing.Size(179, 20)
        Me.T_Dept.StyleController = Me.LayoutControl1
        Me.T_Dept.TabIndex = 63
        '
        'T_Parent
        '
        Me.T_Parent.Location = New System.Drawing.Point(613, 36)
        Me.T_Parent.Name = "T_Parent"
        Me.T_Parent.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.T_Parent.Size = New System.Drawing.Size(209, 20)
        Me.T_Parent.StyleController = Me.LayoutControl1
        Me.T_Parent.TabIndex = 65
        '
        'T_ParentAmount
        '
        Me.T_ParentAmount.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.T_ParentAmount.EditValue = "0"
        Me.T_ParentAmount.Location = New System.Drawing.Point(901, 36)
        Me.T_ParentAmount.Name = "T_ParentAmount"
        Me.T_ParentAmount.Properties.DisplayFormat.FormatString = "{0:N0}"
        Me.T_ParentAmount.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.T_ParentAmount.Size = New System.Drawing.Size(260, 20)
        Me.T_ParentAmount.StyleController = Me.LayoutControl1
        Me.T_ParentAmount.TabIndex = 66
        '
        'TCustomer
        '
        Me.TCustomer.Location = New System.Drawing.Point(901, 12)
        Me.TCustomer.Name = "TCustomer"
        Me.TCustomer.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TCustomer.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.TCustomer.Size = New System.Drawing.Size(260, 20)
        Me.TCustomer.StyleController = Me.LayoutControl1
        Me.TCustomer.TabIndex = 99
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem3, Me.LayoutControlItem2, Me.LayoutControlItem10, Me.LayoutControlItem11, Me.LayoutControlItem8, Me.LayoutControlItem9, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem12, Me.LayoutControlItem13, Me.LayoutControlItem14, Me.LayoutControlItem15, Me.LayoutControlItem16, Me.EmptySpaceItem1})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(1173, 126)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.T_CRType
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(258, 24)
        Me.LayoutControlItem1.Text = "CR Type"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(72, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.T_CRNo
        Me.LayoutControlItem6.Location = New System.Drawing.Point(258, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(268, 24)
        Me.LayoutControlItem6.Text = "Circulation No"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(72, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.T_Dept
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(258, 24)
        Me.LayoutControlItem7.Text = "Comment"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(72, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.T_RequirementDate
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(258, 24)
        Me.LayoutControlItem3.Text = "Req Date"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(72, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.T_NameItem
        Me.LayoutControlItem2.Location = New System.Drawing.Point(258, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(268, 24)
        Me.LayoutControlItem2.Text = "Name Of Item"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(72, 13)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.GroupBox1
        Me.LayoutControlItem10.Location = New System.Drawing.Point(258, 72)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(268, 34)
        Me.LayoutControlItem10.Text = "Budget Type"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(72, 13)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.GroupBox3
        Me.LayoutControlItem11.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(258, 34)
        Me.LayoutControlItem11.Text = "Po Type"
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(72, 13)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.T_Parent
        Me.LayoutControlItem8.Location = New System.Drawing.Point(526, 24)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(288, 24)
        Me.LayoutControlItem8.Text = "Parent CR"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(72, 13)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.T_ParentAmount
        Me.LayoutControlItem9.Location = New System.Drawing.Point(814, 24)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(339, 24)
        Me.LayoutControlItem9.Text = "Parent Amount"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(72, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.T_Reason
        Me.LayoutControlItem4.Location = New System.Drawing.Point(258, 48)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(268, 24)
        Me.LayoutControlItem4.Text = "Reason"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(72, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.T_Spesification
        Me.LayoutControlItem5.Location = New System.Drawing.Point(526, 48)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(627, 24)
        Me.LayoutControlItem5.Text = "Spesification"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(72, 13)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.BMold
        Me.LayoutControlItem12.Location = New System.Drawing.Point(922, 72)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(111, 34)
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem12.TextVisible = False
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.BAddRows
        Me.LayoutControlItem13.Location = New System.Drawing.Point(1033, 72)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(120, 34)
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem13.TextVisible = False
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.BBeritaAcara
        Me.LayoutControlItem14.Location = New System.Drawing.Point(814, 72)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(108, 34)
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem14.TextVisible = False
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.T_PO
        Me.LayoutControlItem15.Location = New System.Drawing.Point(526, 0)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(288, 24)
        Me.LayoutControlItem15.Text = "PO Number"
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(72, 13)
        '
        'LayoutControlItem16
        '
        Me.LayoutControlItem16.Control = Me.TCustomer
        Me.LayoutControlItem16.Location = New System.Drawing.Point(814, 0)
        Me.LayoutControlItem16.Name = "LayoutControlItem16"
        Me.LayoutControlItem16.Size = New System.Drawing.Size(339, 24)
        Me.LayoutControlItem16.Text = "Customer"
        Me.LayoutControlItem16.TextSize = New System.Drawing.Size(72, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(526, 72)
        Me.EmptySpaceItem1.MaxSize = New System.Drawing.Size(0, 7)
        Me.EmptySpaceItem1.MinSize = New System.Drawing.Size(5, 5)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(288, 34)
        Me.EmptySpaceItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.Location = New System.Drawing.Point(7, 159)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Name = "Grid"
        Me.Grid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.C_Qty, Me.C_Price, Me.C_Amount, Me.C_Amount_Barang, Me.CurrRepository, Me.BAccount, Me.C_Check, Me.TotalIdr, Me.Check_OK, Me.Check_Rev, Me.Check_Del, Me.C_SalesType})
        Me.Grid.Size = New System.Drawing.Size(1159, 246)
        Me.Grid.TabIndex = 80
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.NameOfGoods, Me.Spesification, Me.Model, Me.SalesType, Me.GridColumn16, Me.Qty, Me.Price, Me.PTotal, Me.Curr, Me.Rate, Me.Account, Me.GridColumn14, Me.Remaining, Me.GridColumn1, Me.GridColumn2, Me.PTotalRP, Me.GridColumn5, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13})
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowFooter = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'NameOfGoods
        '
        Me.NameOfGoods.FieldName = "Name Of Goods"
        Me.NameOfGoods.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.NameOfGoods.Name = "NameOfGoods"
        Me.NameOfGoods.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.NameOfGoods.OptionsFilter.AllowAutoFilter = False
        Me.NameOfGoods.OptionsFilter.AllowFilter = False
        Me.NameOfGoods.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Count, "Name Of Goods", "{0:N0}")})
        Me.NameOfGoods.Visible = True
        Me.NameOfGoods.VisibleIndex = 0
        Me.NameOfGoods.Width = 139
        '
        'Spesification
        '
        Me.Spesification.FieldName = "Spesification"
        Me.Spesification.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
        Me.Spesification.Name = "Spesification"
        Me.Spesification.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.Spesification.OptionsFilter.AllowAutoFilter = False
        Me.Spesification.OptionsFilter.AllowFilter = False
        Me.Spesification.Visible = True
        Me.Spesification.VisibleIndex = 1
        Me.Spesification.Width = 157
        '
        'Model
        '
        Me.Model.AppearanceCell.Options.UseTextOptions = True
        Me.Model.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Model.AppearanceHeader.Options.UseTextOptions = True
        Me.Model.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Model.FieldName = "Model"
        Me.Model.Name = "Model"
        Me.Model.Visible = True
        Me.Model.VisibleIndex = 2
        '
        'SalesType
        '
        Me.SalesType.AppearanceCell.Options.UseTextOptions = True
        Me.SalesType.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SalesType.AppearanceHeader.Options.UseTextOptions = True
        Me.SalesType.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SalesType.ColumnEdit = Me.C_SalesType
        Me.SalesType.FieldName = "Sales Type"
        Me.SalesType.Name = "SalesType"
        Me.SalesType.Visible = True
        Me.SalesType.VisibleIndex = 3
        '
        'C_SalesType
        '
        Me.C_SalesType.AutoHeight = False
        Me.C_SalesType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.C_SalesType.Items.AddRange(New Object() {"Paid", "Tsc Charge"})
        Me.C_SalesType.Name = "C_SalesType"
        '
        'GridColumn16
        '
        Me.GridColumn16.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn16.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn16.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn16.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn16.FieldName = "Remark"
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 4
        Me.GridColumn16.Width = 214
        '
        'Qty
        '
        Me.Qty.AppearanceCell.Options.UseTextOptions = True
        Me.Qty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Qty.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.Qty.AppearanceHeader.Options.UseTextOptions = True
        Me.Qty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Qty.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.Qty.Caption = "Qty"
        Me.Qty.ColumnEdit = Me.C_Qty
        Me.Qty.FieldName = "Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.Qty.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.Qty.Visible = True
        Me.Qty.VisibleIndex = 8
        Me.Qty.Width = 37
        '
        'C_Qty
        '
        Me.C_Qty.Appearance.Options.UseTextOptions = True
        Me.C_Qty.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.C_Qty.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.C_Qty.AutoHeight = False
        Me.C_Qty.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.C_Qty.Name = "C_Qty"
        '
        'Price
        '
        Me.Price.AppearanceHeader.Options.UseTextOptions = True
        Me.Price.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Price.Caption = "Price"
        Me.Price.ColumnEdit = Me.C_Price
        Me.Price.DisplayFormat.FormatString = "{0:N2}"
        Me.Price.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Price.FieldName = "Price"
        Me.Price.Name = "Price"
        Me.Price.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.Price.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.Price.Visible = True
        Me.Price.VisibleIndex = 10
        Me.Price.Width = 108
        '
        'C_Price
        '
        Me.C_Price.Appearance.Options.UseTextOptions = True
        Me.C_Price.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.C_Price.AutoHeight = False
        Me.C_Price.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.C_Price.Name = "C_Price"
        '
        'PTotal
        '
        Me.PTotal.AppearanceHeader.Options.UseTextOptions = True
        Me.PTotal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.PTotal.ColumnEdit = Me.C_Amount_Barang
        Me.PTotal.DisplayFormat.FormatString = "{0:N2}"
        Me.PTotal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.PTotal.FieldName = "Total Amount Currency"
        Me.PTotal.Name = "PTotal"
        Me.PTotal.OptionsColumn.AllowEdit = False
        Me.PTotal.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.PTotal.Visible = True
        Me.PTotal.VisibleIndex = 12
        Me.PTotal.Width = 120
        '
        'C_Amount_Barang
        '
        Me.C_Amount_Barang.AutoHeight = False
        Me.C_Amount_Barang.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.C_Amount_Barang.Name = "C_Amount_Barang"
        '
        'Curr
        '
        Me.Curr.AppearanceCell.Options.UseTextOptions = True
        Me.Curr.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Curr.AppearanceHeader.Options.UseTextOptions = True
        Me.Curr.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Curr.ColumnEdit = Me.CurrRepository
        Me.Curr.FieldName = "Curr"
        Me.Curr.Name = "Curr"
        Me.Curr.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.Curr.Visible = True
        Me.Curr.VisibleIndex = 9
        Me.Curr.Width = 36
        '
        'CurrRepository
        '
        Me.CurrRepository.AutoHeight = False
        Me.CurrRepository.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CurrRepository.Name = "CurrRepository"
        '
        'Rate
        '
        Me.Rate.AppearanceHeader.Options.UseTextOptions = True
        Me.Rate.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Rate.DisplayFormat.FormatString = "{0:N2}"
        Me.Rate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Rate.FieldName = "Rate"
        Me.Rate.Name = "Rate"
        Me.Rate.OptionsColumn.AllowEdit = False
        Me.Rate.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.Rate.Visible = True
        Me.Rate.VisibleIndex = 11
        Me.Rate.Width = 58
        '
        'Account
        '
        Me.Account.AppearanceCell.Options.UseTextOptions = True
        Me.Account.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Account.AppearanceHeader.Options.UseTextOptions = True
        Me.Account.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Account.ColumnEdit = Me.BAccount
        Me.Account.FieldName = "Account"
        Me.Account.Name = "Account"
        Me.Account.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.Account.Visible = True
        Me.Account.VisibleIndex = 5
        Me.Account.Width = 79
        '
        'BAccount
        '
        Me.BAccount.AutoHeight = False
        Me.BAccount.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.BAccount.Name = "BAccount"
        '
        'GridColumn14
        '
        Me.GridColumn14.FieldName = "Account Name"
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.AllowEdit = False
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 6
        Me.GridColumn14.Width = 148
        '
        'Remaining
        '
        Me.Remaining.AppearanceHeader.Options.UseTextOptions = True
        Me.Remaining.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Remaining.DisplayFormat.FormatString = "{0:N2}"
        Me.Remaining.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Remaining.FieldName = "Remaining Budget"
        Me.Remaining.Name = "Remaining"
        Me.Remaining.OptionsColumn.AllowEdit = False
        Me.Remaining.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.Remaining.Visible = True
        Me.Remaining.VisibleIndex = 7
        Me.Remaining.Width = 103
        '
        'GridColumn1
        '
        Me.GridColumn1.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn1.DisplayFormat.FormatString = "{0:N2}"
        Me.GridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn1.FieldName = "Balance"
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn1.Width = 138
        '
        'GridColumn2
        '
        Me.GridColumn2.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn2.FieldName = "Category"
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        '
        'PTotalRP
        '
        Me.PTotalRP.AppearanceHeader.Options.UseTextOptions = True
        Me.PTotalRP.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.PTotalRP.ColumnEdit = Me.TotalIdr
        Me.PTotalRP.DisplayFormat.FormatString = "{0:N2}"
        Me.PTotalRP.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.PTotalRP.FieldName = "Total IDR"
        Me.PTotalRP.Name = "PTotalRP"
        Me.PTotalRP.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.PTotalRP.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total IDR", "{0:N2}")})
        Me.PTotalRP.Visible = True
        Me.PTotalRP.VisibleIndex = 13
        Me.PTotalRP.Width = 153
        '
        'TotalIdr
        '
        Me.TotalIdr.AutoHeight = False
        Me.TotalIdr.Name = "TotalIdr"
        '
        'GridColumn5
        '
        Me.GridColumn5.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn5.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn5.FieldName = "Note"
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 17
        Me.GridColumn5.Width = 325
        '
        'GridColumn10
        '
        Me.GridColumn10.FieldName = "Id"
        Me.GridColumn10.Name = "GridColumn10"
        '
        'GridColumn11
        '
        Me.GridColumn11.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn11.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn11.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn11.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn11.ColumnEdit = Me.Check_OK
        Me.GridColumn11.FieldName = "OK"
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.UnboundType = DevExpress.Data.UnboundColumnType.[Boolean]
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 14
        '
        'Check_OK
        '
        Me.Check_OK.AutoHeight = False
        Me.Check_OK.Name = "Check_OK"
        '
        'GridColumn12
        '
        Me.GridColumn12.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn12.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn12.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn12.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn12.ColumnEdit = Me.Check_Rev
        Me.GridColumn12.FieldName = "Rev"
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.UnboundType = DevExpress.Data.UnboundColumnType.[Boolean]
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 15
        '
        'Check_Rev
        '
        Me.Check_Rev.AutoHeight = False
        Me.Check_Rev.Name = "Check_Rev"
        '
        'GridColumn13
        '
        Me.GridColumn13.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn13.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn13.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn13.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn13.ColumnEdit = Me.Check_Del
        Me.GridColumn13.FieldName = "Del"
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.UnboundType = DevExpress.Data.UnboundColumnType.[Boolean]
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 16
        '
        'Check_Del
        '
        Me.Check_Del.AutoHeight = False
        Me.Check_Del.Name = "Check_Del"
        '
        'C_Amount
        '
        Me.C_Amount.Appearance.Options.UseTextOptions = True
        Me.C_Amount.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.C_Amount.AutoHeight = False
        Me.C_Amount.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.C_Amount.Name = "C_Amount"
        '
        'C_Check
        '
        Me.C_Check.AutoHeight = False
        Me.C_Check.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.C_Check.Items.AddRange(New Object() {"OK", "REVISE", "DELETE"})
        Me.C_Check.Name = "C_Check"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.T_Remark)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.T_Charged)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.T_ModelName)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.T_DS)
        Me.GroupBox2.Controls.Add(Me.T_CustomerName)
        Me.GroupBox2.Location = New System.Drawing.Point(596, 412)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(246, 129)
        Me.GroupBox2.TabIndex = 83
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Dies / Mold"
        Me.GroupBox2.Visible = False
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(13, 109)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(44, 13)
        Me.Label20.TabIndex = 44
        Me.Label20.Text = "Remark"
        '
        'T_Remark
        '
        Me.T_Remark.Location = New System.Drawing.Point(127, 106)
        Me.T_Remark.Name = "T_Remark"
        Me.T_Remark.Size = New System.Drawing.Size(113, 20)
        Me.T_Remark.TabIndex = 45
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(13, 87)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(106, 13)
        Me.Label19.TabIndex = 43
        Me.Label19.Text = "Charged of Customer"
        '
        'T_Charged
        '
        Me.T_Charged.Location = New System.Drawing.Point(127, 84)
        Me.T_Charged.Name = "T_Charged"
        Me.T_Charged.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.T_Charged.Properties.Items.AddRange(New Object() {"YES", "NO"})
        Me.T_Charged.Size = New System.Drawing.Size(113, 20)
        Me.T_Charged.TabIndex = 42
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(13, 66)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(67, 13)
        Me.Label18.TabIndex = 40
        Me.Label18.Text = "Model Name"
        '
        'T_ModelName
        '
        Me.T_ModelName.Location = New System.Drawing.Point(127, 62)
        Me.T_ModelName.Name = "T_ModelName"
        Me.T_ModelName.Size = New System.Drawing.Size(113, 20)
        Me.T_ModelName.TabIndex = 41
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(13, 41)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(82, 13)
        Me.Label17.TabIndex = 38
        Me.Label17.Text = "Customer Name"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(13, 18)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(60, 13)
        Me.Label16.TabIndex = 36
        Me.Label16.Text = "Sales Type"
        '
        'T_DS
        '
        Me.T_DS.Location = New System.Drawing.Point(127, 15)
        Me.T_DS.Name = "T_DS"
        Me.T_DS.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.T_DS.Properties.Items.AddRange(New Object() {"Depreciation", "Sales"})
        Me.T_DS.Size = New System.Drawing.Size(113, 20)
        Me.T_DS.TabIndex = 37
        '
        'T_CustomerName
        '
        Me.T_CustomerName.Location = New System.Drawing.Point(127, 38)
        Me.T_CustomerName.Name = "T_CustomerName"
        Me.T_CustomerName.Size = New System.Drawing.Size(113, 20)
        Me.T_CustomerName.TabIndex = 39
        '
        'Grid3
        '
        Me.Grid3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid3.Location = New System.Drawing.Point(773, 412)
        Me.Grid3.MainView = Me.GridView3
        Me.Grid3.Name = "Grid3"
        Me.Grid3.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit1, Me.RepositoryItemSpinEdit3, Me.RepositoryItemSpinEdit2, Me.RepositoryItemTextEdit1, Me.CurrEdit})
        Me.Grid3.Size = New System.Drawing.Size(393, 129)
        Me.Grid3.TabIndex = 85
        Me.Grid3.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn4, Me.GridColumn3})
        Me.GridView3.GridControl = Me.Grid3
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsView.ShowFooter = True
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'GridColumn4
        '
        Me.GridColumn4.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn4.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.GridColumn4.ColumnEdit = Me.RepositoryItemSpinEdit1
        Me.GridColumn4.DisplayFormat.FormatString = "{0:N2}"
        Me.GridColumn4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GridColumn4.FieldName = "Total"
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn4.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "%", "{0:N2}")})
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 1
        Me.GridColumn4.Width = 781
        '
        'RepositoryItemSpinEdit1
        '
        Me.RepositoryItemSpinEdit1.AutoHeight = False
        Me.RepositoryItemSpinEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSpinEdit1.Name = "RepositoryItemSpinEdit1"
        '
        'GridColumn3
        '
        Me.GridColumn3.ColumnEdit = Me.CurrEdit
        Me.GridColumn3.FieldName = "Curr"
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.[False]
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 0
        Me.GridColumn3.Width = 287
        '
        'CurrEdit
        '
        Me.CurrEdit.AutoHeight = False
        Me.CurrEdit.Name = "CurrEdit"
        '
        'RepositoryItemSpinEdit3
        '
        Me.RepositoryItemSpinEdit3.AutoHeight = False
        Me.RepositoryItemSpinEdit3.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSpinEdit3.Name = "RepositoryItemSpinEdit3"
        '
        'RepositoryItemSpinEdit2
        '
        Me.RepositoryItemSpinEdit2.AutoHeight = False
        Me.RepositoryItemSpinEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSpinEdit2.Name = "RepositoryItemSpinEdit2"
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'Grid4
        '
        Me.Grid4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Grid4.Location = New System.Drawing.Point(7, 412)
        Me.Grid4.MainView = Me.GridView4
        Me.Grid4.Name = "Grid4"
        Me.Grid4.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit4, Me.RepositoryItemSpinEdit6, Me.RepositoryItemSpinEdit5})
        Me.Grid4.Size = New System.Drawing.Size(760, 129)
        Me.Grid4.TabIndex = 80
        Me.Grid4.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView4})
        '
        'GridView4
        '
        Me.GridView4.GridControl = Me.Grid4
        Me.GridView4.Name = "GridView4"
        Me.GridView4.OptionsView.ShowFooter = True
        Me.GridView4.OptionsView.ShowGroupPanel = False
        '
        'RepositoryItemSpinEdit4
        '
        Me.RepositoryItemSpinEdit4.AutoHeight = False
        Me.RepositoryItemSpinEdit4.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSpinEdit4.Name = "RepositoryItemSpinEdit4"
        '
        'RepositoryItemSpinEdit6
        '
        Me.RepositoryItemSpinEdit6.AutoHeight = False
        Me.RepositoryItemSpinEdit6.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSpinEdit6.Name = "RepositoryItemSpinEdit6"
        '
        'RepositoryItemSpinEdit5
        '
        Me.RepositoryItemSpinEdit5.AutoHeight = False
        Me.RepositoryItemSpinEdit5.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSpinEdit5.Name = "RepositoryItemSpinEdit5"
        '
        'C_Term
        '
        Me.C_Term.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.C_Term.Enabled = False
        Me.C_Term.Location = New System.Drawing.Point(11, 518)
        Me.C_Term.Name = "C_Term"
        Me.C_Term.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.C_Term.Properties.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6"})
        Me.C_Term.Size = New System.Drawing.Size(50, 20)
        Me.C_Term.TabIndex = 86
        '
        'Grid5
        '
        Me.Grid5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Grid5.Location = New System.Drawing.Point(7, 412)
        Me.Grid5.MainView = Me.GridView5
        Me.Grid5.Name = "Grid5"
        Me.Grid5.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemSpinEdit7, Me.RepositoryItemSpinEdit8, Me.RepositoryItemSpinEdit9, Me.RepositoryItemTextEdit2, Me.Opinion})
        Me.Grid5.Size = New System.Drawing.Size(760, 129)
        Me.Grid5.TabIndex = 87
        Me.Grid5.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView5})
        '
        'GridView5
        '
        Me.GridView5.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn15, Me.GridColumn17})
        Me.GridView5.GridControl = Me.Grid5
        Me.GridView5.Name = "GridView5"
        Me.GridView5.OptionsView.ShowGroupPanel = False
        '
        'GridColumn6
        '
        Me.GridColumn6.FieldName = "Dept"
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 0
        Me.GridColumn6.Width = 244
        '
        'GridColumn7
        '
        Me.GridColumn7.FieldName = "Name"
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.Width = 106
        '
        'GridColumn8
        '
        Me.GridColumn8.FieldName = "Date"
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.Width = 86
        '
        'GridColumn9
        '
        Me.GridColumn9.ColumnEdit = Me.Opinion
        Me.GridColumn9.FieldName = "Opinion"
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.AllowEdit = False
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 1
        Me.GridColumn9.Width = 873
        '
        'Opinion
        '
        Me.Opinion.AutoHeight = False
        Me.Opinion.Name = "Opinion"
        '
        'GridColumn15
        '
        Me.GridColumn15.FieldName = "User_id"
        Me.GridColumn15.Name = "GridColumn15"
        '
        'GridColumn17
        '
        Me.GridColumn17.AppearanceCell.Options.UseTextOptions = True
        Me.GridColumn17.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn17.AppearanceHeader.Options.UseTextOptions = True
        Me.GridColumn17.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridColumn17.Caption = "Check"
        Me.GridColumn17.FieldName = "Check"
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.OptionsColumn.AllowEdit = False
        Me.GridColumn17.UnboundType = DevExpress.Data.UnboundColumnType.[Boolean]
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 2
        '
        'RepositoryItemSpinEdit7
        '
        Me.RepositoryItemSpinEdit7.AutoHeight = False
        Me.RepositoryItemSpinEdit7.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSpinEdit7.Name = "RepositoryItemSpinEdit7"
        '
        'RepositoryItemSpinEdit8
        '
        Me.RepositoryItemSpinEdit8.AutoHeight = False
        Me.RepositoryItemSpinEdit8.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSpinEdit8.Name = "RepositoryItemSpinEdit8"
        '
        'RepositoryItemSpinEdit9
        '
        Me.RepositoryItemSpinEdit9.AutoHeight = False
        Me.RepositoryItemSpinEdit9.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemSpinEdit9.Name = "RepositoryItemSpinEdit9"
        '
        'RepositoryItemTextEdit2
        '
        Me.RepositoryItemTextEdit2.AutoHeight = False
        Me.RepositoryItemTextEdit2.Name = "RepositoryItemTextEdit2"
        '
        'Timer1
        '
        Me.Timer1.Interval = 700
        '
        'BPrint
        '
        Me.BPrint.Location = New System.Drawing.Point(371, 3)
        Me.BPrint.Name = "BPrint"
        Me.BPrint.Size = New System.Drawing.Size(75, 23)
        Me.BPrint.TabIndex = 99
        Me.BPrint.Text = "Print"
        Me.BPrint.UseVisualStyleBackColor = True
        Me.BPrint.Visible = False
        '
        'Frm_CR_UserCreateDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.ClientSize = New System.Drawing.Size(1173, 550)
        Me.Controls.Add(Me.BPrint)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.Grid5)
        Me.Controls.Add(Me.C_Term)
        Me.Controls.Add(Me.Grid4)
        Me.Controls.Add(Me.Grid3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Grid)
        Me.Name = "Frm_CR_UserCreateDetail"
        Me.Controls.SetChildIndex(Me.Grid, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.Grid3, 0)
        Me.Controls.SetChildIndex(Me.Grid4, 0)
        Me.Controls.SetChildIndex(Me.C_Term, 0)
        Me.Controls.SetChildIndex(Me.Grid5, 0)
        Me.Controls.SetChildIndex(Me.LayoutControl1, 0)
        Me.Controls.SetChildIndex(Me.BPrint, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.T_RequirementDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_RequirementDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.T_Spesification.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Reason.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_CRType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_NameItem.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_CRNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Dept.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Parent.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_ParentAmount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TCustomer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_SalesType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_Qty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_Price, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_Amount_Barang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrRepository, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BAccount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotalIdr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Check_OK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Check_Rev, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Check_Del, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_Amount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_Check, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.T_Remark.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_Charged.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_ModelName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_DS.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_CustomerName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrEdit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_Term.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Grid5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Opinion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemSpinEdit9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents RB_Budget As RadioButton
    Friend WithEvents RB_NonBudget As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents T_RequirementDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents T_CRNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Amount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BehaviorManager1 As DevExpress.Utils.Behaviors.BehaviorManager
    Friend WithEvents T_Dept As DevExpress.XtraEditors.CheckedComboBoxEdit
    Friend WithEvents T_ParentAmount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_Parent As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents T_CRType As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents BAddRows As Button
    Friend WithEvents BMold As Button
    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents NameOfGoods As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Spesification As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents C_Qty As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents Price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents C_Price As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents PTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents C_Amount_Barang As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents Curr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CurrRepository As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents Rate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Account As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BAccount As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents Remaining As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PTotalRP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents C_Amount As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label20 As Label
    Friend WithEvents T_Remark As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label19 As Label
    Friend WithEvents T_Charged As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Label18 As Label
    Friend WithEvents T_ModelName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents T_DS As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents T_CustomerName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Grid3 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit3 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents RepositoryItemSpinEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents Grid4 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView4 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemSpinEdit4 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents RepositoryItemSpinEdit6 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents RepositoryItemSpinEdit5 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents C_Check As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents C_Term As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Grid5 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView5 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemSpinEdit7 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents RepositoryItemSpinEdit8 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents RepositoryItemSpinEdit9 As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents CurrEdit As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents T_NameItem As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents RBPO As RadioButton
    Friend WithEvents RBNonPO As RadioButton
    Friend WithEvents T_Spesification As DevExpress.XtraEditors.TextEdit
    Friend WithEvents T_Reason As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TotalIdr As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents BBeritaAcara As Button
    Friend WithEvents Opinion As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemTextEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Check_OK As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents Check_Rev As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents Check_Del As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents T_PO As TextBox
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Timer1 As Timer
    Friend WithEvents LayoutControlItem16 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TCustomer As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents Model As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SalesType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents C_SalesType As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents BPrint As Button
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
End Class
