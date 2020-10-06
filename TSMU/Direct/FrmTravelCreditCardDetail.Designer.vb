<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTravelCreditCardDetail
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
        Dim ConditionValidationRule1 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Dim ConditionValidationRule2 As DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule = New DevExpress.XtraEditors.DXErrorProvider.ConditionValidationRule()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.txtCreditCardNumber = New DevExpress.XtraEditors.TextEdit()
        Me.txtAccountName = New DevExpress.XtraEditors.TextEdit()
        Me.dtExpDate = New DevExpress.XtraEditors.DateEdit()
        Me.txtProvider = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txtBankName = New DevExpress.XtraEditors.TextEdit()
        Me.txtCCMaster = New DevExpress.XtraEditors.TextEdit()
        Me.txtType = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DxValidationProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        Me.GridCreditCard = New DevExpress.XtraGrid.GridControl()
        Me.GridViewCreditCard = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.CreditCardID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CreditCardNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CCreditCardNumber = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.AccountName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BankName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Provider = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ExpiredDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CCNumberMaster = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CCCNumberMaster = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtCreditCardNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAccountName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtExpDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtExpDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtProvider.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBankName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCCMaster.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridCreditCard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewCreditCard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CCreditCardNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CCCNumberMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.txtCreditCardNumber)
        Me.LayoutControl1.Controls.Add(Me.txtAccountName)
        Me.LayoutControl1.Controls.Add(Me.dtExpDate)
        Me.LayoutControl1.Controls.Add(Me.txtProvider)
        Me.LayoutControl1.Controls.Add(Me.txtBankName)
        Me.LayoutControl1.Controls.Add(Me.txtCCMaster)
        Me.LayoutControl1.Controls.Add(Me.txtType)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(3, 3)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(1283, 54)
        Me.LayoutControl1.TabIndex = 15
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'txtCreditCardNumber
        '
        Me.txtCreditCardNumber.Location = New System.Drawing.Point(442, 12)
        Me.txtCreditCardNumber.Name = "txtCreditCardNumber"
        Me.txtCreditCardNumber.Properties.DisplayFormat.FormatString = "0000-0000-0000-9999"
        Me.txtCreditCardNumber.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.txtCreditCardNumber.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.txtCreditCardNumber.Properties.Mask.EditMask = "0000-0000-0000-9999"
        Me.txtCreditCardNumber.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple
        Me.txtCreditCardNumber.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtCreditCardNumber.Size = New System.Drawing.Size(103, 22)
        Me.txtCreditCardNumber.StyleController = Me.LayoutControl1
        Me.txtCreditCardNumber.TabIndex = 14
        ConditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule1.ErrorText = "This value is not valid"
        ConditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
        Me.DxValidationProvider1.SetValidationRule(Me.txtCreditCardNumber, ConditionValidationRule1)
        '
        'txtAccountName
        '
        Me.txtAccountName.Location = New System.Drawing.Point(642, 12)
        Me.txtAccountName.Name = "txtAccountName"
        Me.txtAccountName.Size = New System.Drawing.Size(82, 22)
        Me.txtAccountName.StyleController = Me.LayoutControl1
        Me.txtAccountName.TabIndex = 3
        ConditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule2.ErrorText = "This value is not valid"
        ConditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
        Me.DxValidationProvider1.SetValidationRule(Me.txtAccountName, ConditionValidationRule2)
        '
        'dtExpDate
        '
        Me.dtExpDate.EditValue = Nothing
        Me.dtExpDate.Location = New System.Drawing.Point(1181, 12)
        Me.dtExpDate.MaximumSize = New System.Drawing.Size(130, 22)
        Me.dtExpDate.Name = "dtExpDate"
        Me.dtExpDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtExpDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtExpDate.Properties.DisplayFormat.FormatString = "MM-yyyy"
        Me.dtExpDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtExpDate.Properties.EditFormat.FormatString = "dd-MM-yyyy"
        Me.dtExpDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtExpDate.Properties.Mask.EditMask = "MM-yyyy"
        Me.dtExpDate.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.dtExpDate.Size = New System.Drawing.Size(90, 22)
        Me.dtExpDate.StyleController = Me.LayoutControl1
        Me.dtExpDate.TabIndex = 6
        '
        'txtProvider
        '
        Me.txtProvider.Location = New System.Drawing.Point(1000, 12)
        Me.txtProvider.MaximumSize = New System.Drawing.Size(150, 22)
        Me.txtProvider.Name = "txtProvider"
        Me.txtProvider.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtProvider.Properties.Items.AddRange(New Object() {"VISA", "MASTERCARD"})
        Me.txtProvider.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txtProvider.Size = New System.Drawing.Size(84, 22)
        Me.txtProvider.StyleController = Me.LayoutControl1
        Me.txtProvider.TabIndex = 5
        '
        'txtBankName
        '
        Me.txtBankName.Location = New System.Drawing.Point(821, 12)
        Me.txtBankName.Name = "txtBankName"
        Me.txtBankName.Size = New System.Drawing.Size(82, 22)
        Me.txtBankName.StyleController = Me.LayoutControl1
        Me.txtBankName.TabIndex = 4
        '
        'txtCCMaster
        '
        Me.txtCCMaster.Enabled = False
        Me.txtCCMaster.Location = New System.Drawing.Point(256, 12)
        Me.txtCCMaster.Name = "txtCCMaster"
        Me.txtCCMaster.Properties.DisplayFormat.FormatString = "0000-0000-0000-9999"
        Me.txtCCMaster.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.txtCCMaster.Properties.Mask.EditMask = "0000-0000-0000-9999"
        Me.txtCCMaster.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple
        Me.txtCCMaster.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtCCMaster.Size = New System.Drawing.Size(89, 22)
        Me.txtCCMaster.StyleController = Me.LayoutControl1
        Me.txtCCMaster.TabIndex = 14
        '
        'txtType
        '
        Me.txtType.Location = New System.Drawing.Point(97, 12)
        Me.txtType.MaximumSize = New System.Drawing.Size(60, 0)
        Me.txtType.Name = "txtType"
        Me.txtType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtType.Properties.Items.AddRange(New Object() {"M", "S"})
        Me.txtType.Size = New System.Drawing.Size(60, 22)
        Me.txtType.StyleController = Me.LayoutControl1
        Me.txtType.TabIndex = 15
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem8, Me.LayoutControlItem7})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(1283, 54)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.dtExpDate
        Me.LayoutControlItem2.Location = New System.Drawing.Point(1084, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(179, 34)
        Me.LayoutControlItem2.Text = "Expired Date"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(82, 16)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtProvider
        Me.LayoutControlItem3.Location = New System.Drawing.Point(903, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2)
        Me.LayoutControlItem3.Size = New System.Drawing.Size(181, 34)
        Me.LayoutControlItem3.Text = "Provider"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(82, 16)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtBankName
        Me.LayoutControlItem4.Location = New System.Drawing.Point(724, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2)
        Me.LayoutControlItem4.Size = New System.Drawing.Size(179, 34)
        Me.LayoutControlItem4.Text = "Bank Name"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(82, 16)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.txtAccountName
        Me.LayoutControlItem5.Location = New System.Drawing.Point(545, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2)
        Me.LayoutControlItem5.Size = New System.Drawing.Size(179, 34)
        Me.LayoutControlItem5.Text = "Account Name"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(82, 16)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.txtCreditCardNumber
        Me.LayoutControlItem6.Location = New System.Drawing.Point(345, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2)
        Me.LayoutControlItem6.Size = New System.Drawing.Size(200, 34)
        Me.LayoutControlItem6.Text = "CC Number"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(82, 16)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.txtCCMaster
        Me.LayoutControlItem8.CustomizationFormText = "Credit Card Number"
        Me.LayoutControlItem8.Location = New System.Drawing.Point(159, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2)
        Me.LayoutControlItem8.Size = New System.Drawing.Size(186, 34)
        Me.LayoutControlItem8.Text = "CC Master"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(82, 16)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.txtType
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 10, 2, 2)
        Me.LayoutControlItem7.Size = New System.Drawing.Size(159, 34)
        Me.LayoutControlItem7.Text = "Type"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(82, 16)
        '
        'GridCreditCard
        '
        Me.GridCreditCard.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridCreditCard.Location = New System.Drawing.Point(12, 12)
        Me.GridCreditCard.MainView = Me.GridViewCreditCard
        Me.GridCreditCard.Name = "GridCreditCard"
        Me.GridCreditCard.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CCreditCardNumber, Me.CCCNumberMaster})
        Me.GridCreditCard.Size = New System.Drawing.Size(1259, 482)
        Me.GridCreditCard.TabIndex = 13
        Me.GridCreditCard.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewCreditCard})
        '
        'GridViewCreditCard
        '
        Me.GridViewCreditCard.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.CreditCardID, Me.CreditCardNumber, Me.AccountName, Me.BankName, Me.Provider, Me.ExpiredDate, Me.Type, Me.CCNumberMaster})
        Me.GridViewCreditCard.GridControl = Me.GridCreditCard
        Me.GridViewCreditCard.Name = "GridViewCreditCard"
        Me.GridViewCreditCard.OptionsBehavior.Editable = False
        Me.GridViewCreditCard.OptionsView.ColumnAutoWidth = False
        Me.GridViewCreditCard.OptionsView.ShowGroupPanel = False
        '
        'CreditCardID
        '
        Me.CreditCardID.Caption = "Credit Card ID"
        Me.CreditCardID.FieldName = "CreditCardID"
        Me.CreditCardID.MinWidth = 25
        Me.CreditCardID.Name = "CreditCardID"
        Me.CreditCardID.OptionsColumn.FixedWidth = True
        Me.CreditCardID.Width = 120
        '
        'CreditCardNumber
        '
        Me.CreditCardNumber.Caption = "Credit Card Number"
        Me.CreditCardNumber.ColumnEdit = Me.CCreditCardNumber
        Me.CreditCardNumber.DisplayFormat.FormatString = "0000-0000-0000-9999"
        Me.CreditCardNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.CreditCardNumber.FieldName = "CreditCardNumber"
        Me.CreditCardNumber.MinWidth = 25
        Me.CreditCardNumber.Name = "CreditCardNumber"
        Me.CreditCardNumber.OptionsColumn.FixedWidth = True
        Me.CreditCardNumber.Visible = True
        Me.CreditCardNumber.VisibleIndex = 0
        Me.CreditCardNumber.Width = 180
        '
        'CCreditCardNumber
        '
        Me.CCreditCardNumber.AutoHeight = False
        Me.CCreditCardNumber.Mask.EditMask = "0000-0000-0000-9999"
        Me.CCreditCardNumber.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple
        Me.CCreditCardNumber.Mask.ShowPlaceHolders = False
        Me.CCreditCardNumber.Mask.UseMaskAsDisplayFormat = True
        Me.CCreditCardNumber.Name = "CCreditCardNumber"
        '
        'AccountName
        '
        Me.AccountName.Caption = "Account Name"
        Me.AccountName.FieldName = "AccountName"
        Me.AccountName.MinWidth = 25
        Me.AccountName.Name = "AccountName"
        Me.AccountName.OptionsColumn.FixedWidth = True
        Me.AccountName.Visible = True
        Me.AccountName.VisibleIndex = 1
        Me.AccountName.Width = 400
        '
        'BankName
        '
        Me.BankName.Caption = "Bank Name"
        Me.BankName.FieldName = "BankName"
        Me.BankName.MinWidth = 25
        Me.BankName.Name = "BankName"
        Me.BankName.OptionsColumn.FixedWidth = True
        Me.BankName.Visible = True
        Me.BankName.VisibleIndex = 2
        Me.BankName.Width = 250
        '
        'Provider
        '
        Me.Provider.Caption = "Provider"
        Me.Provider.FieldName = "Provider"
        Me.Provider.MinWidth = 25
        Me.Provider.Name = "Provider"
        Me.Provider.OptionsColumn.FixedWidth = True
        Me.Provider.Visible = True
        Me.Provider.VisibleIndex = 3
        Me.Provider.Width = 150
        '
        'ExpiredDate
        '
        Me.ExpiredDate.Caption = "Expired Date"
        Me.ExpiredDate.DisplayFormat.FormatString = "MM-yyyy"
        Me.ExpiredDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ExpiredDate.FieldName = "ExpDate"
        Me.ExpiredDate.MinWidth = 25
        Me.ExpiredDate.Name = "ExpiredDate"
        Me.ExpiredDate.OptionsColumn.FixedWidth = True
        Me.ExpiredDate.Visible = True
        Me.ExpiredDate.VisibleIndex = 4
        Me.ExpiredDate.Width = 150
        '
        'Type
        '
        Me.Type.Caption = "Type"
        Me.Type.FieldName = "Type"
        Me.Type.MinWidth = 25
        Me.Type.Name = "Type"
        Me.Type.OptionsColumn.FixedWidth = True
        Me.Type.Visible = True
        Me.Type.VisibleIndex = 5
        Me.Type.Width = 50
        '
        'CCNumberMaster
        '
        Me.CCNumberMaster.Caption = "CC Master"
        Me.CCNumberMaster.ColumnEdit = Me.CCCNumberMaster
        Me.CCNumberMaster.DisplayFormat.FormatString = "0000-0000-0000-9999"
        Me.CCNumberMaster.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.CCNumberMaster.FieldName = "CCNumberMaster"
        Me.CCNumberMaster.MinWidth = 25
        Me.CCNumberMaster.Name = "CCNumberMaster"
        Me.CCNumberMaster.OptionsColumn.FixedWidth = True
        Me.CCNumberMaster.Visible = True
        Me.CCNumberMaster.VisibleIndex = 6
        Me.CCNumberMaster.Width = 180
        '
        'CCCNumberMaster
        '
        Me.CCCNumberMaster.AutoHeight = False
        Me.CCCNumberMaster.Mask.EditMask = "0000-0000-0000-9999"
        Me.CCCNumberMaster.Mask.UseMaskAsDisplayFormat = True
        Me.CCCNumberMaster.Name = "CCCNumberMaster"
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LayoutControl1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LayoutControl2, 0, 1)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 27)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1289, 572)
        Me.TableLayoutPanel1.TabIndex = 16
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.GridCreditCard)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl2.Location = New System.Drawing.Point(3, 63)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.Root = Me.LayoutControlGroup1
        Me.LayoutControl2.Size = New System.Drawing.Size(1283, 506)
        Me.LayoutControl2.TabIndex = 16
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1283, 506)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridCreditCard
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1263, 486)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'FrmTravelCreditCardDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.ClientSize = New System.Drawing.Size(1289, 599)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Name = "FrmTravelCreditCardDetail"
        Me.Controls.SetChildIndex(Me.TableLayoutPanel1, 0)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtCreditCardNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAccountName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtExpDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtExpDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtProvider.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBankName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCCMaster.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridCreditCard, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewCreditCard, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CCreditCardNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CCCNumberMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBankName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtAccountName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtProvider As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents dtExpDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DxValidationProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents GridCreditCard As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewCreditCard As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CreditCardID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CreditCardNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents AccountName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BankName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Provider As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ExpiredDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtCreditCardNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CCreditCardNumber As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtCCMaster As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtType As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CCNumberMaster As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CCCNumberMaster As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
End Class
