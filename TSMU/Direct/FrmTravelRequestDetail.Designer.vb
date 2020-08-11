<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTravelRequestDetail
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
        Me.CDepartureDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.CArrivalDate = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtNoRequest = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.txtNIK = New DevExpress.XtraEditors.TextEdit()
        Me.txtAdvanceIDR = New DevExpress.XtraEditors.TextEdit()
        Me.txtAdvanceYEN = New DevExpress.XtraEditors.TextEdit()
        Me.txtAdvanceUSD = New DevExpress.XtraEditors.TextEdit()
        Me.txtTravelType = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txtApproved = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.txtNama = New DevExpress.XtraEditors.TextEdit()
        Me.txtDepartement = New DevExpress.XtraEditors.TextEdit()
        Me.txtGolongan = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtPurpose = New DevExpress.XtraEditors.TextEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem3 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem5 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem6 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.EmptySpaceItem4 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem16 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.GridDetail = New DevExpress.XtraGrid.GridControl()
        Me.GridViewDetail = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.DestinationGrid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NegaraGrid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CNegara = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.NoPasporGrid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NoVisaGrid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.VisaGrid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DepartureDateGrid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ArrivalDateGrid = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GDetailDay = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRateAllowanceUSD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRateAllowanceYEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DxValidationProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        Me.GridAdvance = New DevExpress.XtraGrid.GridControl()
        Me.GridViewAdvance = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GAdvanceCostType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAdvanceDescription = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAdvanceDays = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAdvanceAdvanceUSD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CAdvanceUSD = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.GAdvanceAdvanceIDRUSD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAdvanceAdvanceYEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CAdvanceYEN = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.GAdvanceAdvanceIDRYEN = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAdvanceAdvanceIDR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CAdvanceIDR = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.GAdvanceRateAdvanceIDR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GAdvanceTotalAdvanceIDR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.BehaviorManager1 = New DevExpress.Utils.Behaviors.BehaviorManager(Me.components)
        Me.LayoutControl3 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.CDepartureDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CDepartureDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CArrivalDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CArrivalDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoRequest.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtNIK.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAdvanceIDR.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAdvanceYEN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAdvanceUSD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTravelType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtApproved.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNama.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtDepartement.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGolongan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPurpose.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CNegara, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridAdvance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewAdvance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CAdvanceUSD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CAdvanceYEN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CAdvanceIDR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl3.SuspendLayout()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CDepartureDate
        '
        Me.CDepartureDate.AutoHeight = False
        Me.CDepartureDate.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CDepartureDate.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CDepartureDate.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.CDepartureDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.CDepartureDate.EditFormat.FormatString = "dd-MM-yyyy"
        Me.CDepartureDate.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.CDepartureDate.Mask.EditMask = "dd-MM-yyyy"
        Me.CDepartureDate.Name = "CDepartureDate"
        Me.CDepartureDate.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'CArrivalDate
        '
        Me.CArrivalDate.AutoHeight = False
        Me.CArrivalDate.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CArrivalDate.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CArrivalDate.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.CArrivalDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.CArrivalDate.EditFormat.FormatString = "dd-MM-yyyy"
        Me.CArrivalDate.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.CArrivalDate.Mask.EditMask = "dd-MM-yyyy"
        Me.CArrivalDate.Name = "CArrivalDate"
        Me.CArrivalDate.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Location = New System.Drawing.Point(1173, 38)
        Me.btnAdd.MaximumSize = New System.Drawing.Size(120, 0)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 45)
        Me.btnAdd.TabIndex = 10
        Me.btnAdd.Text = "Add Detail ++"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtNoRequest
        '
        Me.txtNoRequest.EditValue = ""
        Me.txtNoRequest.Enabled = False
        Me.txtNoRequest.Location = New System.Drawing.Point(91, 12)
        Me.txtNoRequest.MaximumSize = New System.Drawing.Size(140, 22)
        Me.txtNoRequest.Name = "txtNoRequest"
        Me.txtNoRequest.Size = New System.Drawing.Size(62, 22)
        Me.txtNoRequest.StyleController = Me.LayoutControl1
        Me.txtNoRequest.TabIndex = 0
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LayoutControl1.Controls.Add(Me.LabelControl1)
        Me.LayoutControl1.Controls.Add(Me.txtNIK)
        Me.LayoutControl1.Controls.Add(Me.txtAdvanceIDR)
        Me.LayoutControl1.Controls.Add(Me.txtAdvanceYEN)
        Me.LayoutControl1.Controls.Add(Me.txtAdvanceUSD)
        Me.LayoutControl1.Controls.Add(Me.btnAdd)
        Me.LayoutControl1.Controls.Add(Me.txtTravelType)
        Me.LayoutControl1.Controls.Add(Me.txtApproved)
        Me.LayoutControl1.Controls.Add(Me.txtNama)
        Me.LayoutControl1.Controls.Add(Me.txtNoRequest)
        Me.LayoutControl1.Controls.Add(Me.txtDepartement)
        Me.LayoutControl1.Controls.Add(Me.txtGolongan)
        Me.LayoutControl1.Controls.Add(Me.txtPurpose)
        Me.LayoutControl1.Location = New System.Drawing.Point(10, 40)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(362, 479, 812, 500)
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(1260, 95)
        Me.LayoutControl1.TabIndex = 35
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(1083, 48)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(78, 16)
        Me.LabelControl1.StyleController = Me.LayoutControl1
        Me.LabelControl1.TabIndex = 34
        Me.LabelControl1.Text = "LabelControl1"
        '
        'txtNIK
        '
        Me.txtNIK.EditValue = ""
        Me.txtNIK.Location = New System.Drawing.Point(397, 12)
        Me.txtNIK.MaximumSize = New System.Drawing.Size(120, 22)
        Me.txtNIK.Name = "txtNIK"
        Me.txtNIK.Properties.MaxLength = 9
        Me.txtNIK.Size = New System.Drawing.Size(62, 22)
        Me.txtNIK.StyleController = Me.LayoutControl1
        Me.txtNIK.TabIndex = 2
        ConditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule1.ErrorText = "This value is not valid"
        ConditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
        Me.DxValidationProvider1.SetValidationRule(Me.txtNIK, ConditionValidationRule1)
        '
        'txtAdvanceIDR
        '
        Me.txtAdvanceIDR.EditValue = "0"
        Me.txtAdvanceIDR.Location = New System.Drawing.Point(1009, 45)
        Me.txtAdvanceIDR.MaximumSize = New System.Drawing.Size(150, 0)
        Me.txtAdvanceIDR.Name = "txtAdvanceIDR"
        Me.txtAdvanceIDR.Properties.Mask.EditMask = "n2"
        Me.txtAdvanceIDR.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtAdvanceIDR.Properties.Name = "txtAdvanceIDR"
        Me.txtAdvanceIDR.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtAdvanceIDR.Size = New System.Drawing.Size(62, 22)
        Me.txtAdvanceIDR.StyleController = Me.LayoutControl1
        Me.txtAdvanceIDR.TabIndex = 7
        '
        'txtAdvanceYEN
        '
        Me.txtAdvanceYEN.EditValue = "0"
        Me.txtAdvanceYEN.Location = New System.Drawing.Point(856, 45)
        Me.txtAdvanceYEN.MaximumSize = New System.Drawing.Size(150, 0)
        Me.txtAdvanceYEN.Name = "txtAdvanceYEN"
        Me.txtAdvanceYEN.Properties.Mask.EditMask = "n2"
        Me.txtAdvanceYEN.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtAdvanceYEN.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtAdvanceYEN.Size = New System.Drawing.Size(62, 22)
        Me.txtAdvanceYEN.StyleController = Me.LayoutControl1
        Me.txtAdvanceYEN.TabIndex = 9
        '
        'txtAdvanceUSD
        '
        Me.txtAdvanceUSD.EditValue = "0"
        Me.txtAdvanceUSD.Location = New System.Drawing.Point(703, 45)
        Me.txtAdvanceUSD.MaximumSize = New System.Drawing.Size(150, 0)
        Me.txtAdvanceUSD.Name = "txtAdvanceUSD"
        Me.txtAdvanceUSD.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtAdvanceUSD.Properties.DisplayFormat.FormatString = "n2"
        Me.txtAdvanceUSD.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtAdvanceUSD.Properties.EditFormat.FormatString = "n2"
        Me.txtAdvanceUSD.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtAdvanceUSD.Properties.Mask.EditMask = "n2"
        Me.txtAdvanceUSD.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtAdvanceUSD.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtAdvanceUSD.Size = New System.Drawing.Size(62, 22)
        Me.txtAdvanceUSD.StyleController = Me.LayoutControl1
        Me.txtAdvanceUSD.TabIndex = 8
        '
        'txtTravelType
        '
        Me.txtTravelType.EditValue = ""
        Me.txtTravelType.Location = New System.Drawing.Point(550, 45)
        Me.txtTravelType.Name = "txtTravelType"
        Me.txtTravelType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtTravelType.Properties.Items.AddRange(New Object() {"DN", "LN"})
        Me.txtTravelType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txtTravelType.Size = New System.Drawing.Size(62, 22)
        Me.txtTravelType.StyleController = Me.LayoutControl1
        Me.txtTravelType.TabIndex = 6
        '
        'txtApproved
        '
        Me.txtApproved.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtApproved.Location = New System.Drawing.Point(1131, 12)
        Me.txtApproved.MaximumSize = New System.Drawing.Size(120, 22)
        Me.txtApproved.Name = "txtApproved"
        Me.txtApproved.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtApproved.Properties.Items.AddRange(New Object() {"APPROVED", "REVISED", "CANCEL"})
        Me.txtApproved.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txtApproved.Size = New System.Drawing.Size(117, 22)
        Me.txtApproved.StyleController = Me.LayoutControl1
        Me.txtApproved.TabIndex = 33
        '
        'txtNama
        '
        Me.txtNama.EditValue = ""
        Me.txtNama.Location = New System.Drawing.Point(91, 45)
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.txtNama.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtNama.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.txtNama.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtNama.Size = New System.Drawing.Size(368, 22)
        Me.txtNama.StyleController = Me.LayoutControl1
        Me.txtNama.TabIndex = 5
        ConditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule2.ErrorText = "This value is not valid"
        ConditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
        Me.DxValidationProvider1.SetValidationRule(Me.txtNama, ConditionValidationRule2)
        '
        'txtDepartement
        '
        Me.txtDepartement.EditValue = ""
        Me.txtDepartement.Enabled = False
        Me.txtDepartement.Location = New System.Drawing.Point(244, 12)
        Me.txtDepartement.MaximumSize = New System.Drawing.Size(70, 22)
        Me.txtDepartement.Name = "txtDepartement"
        Me.txtDepartement.Size = New System.Drawing.Size(62, 22)
        Me.txtDepartement.StyleController = Me.LayoutControl1
        Me.txtDepartement.TabIndex = 1
        '
        'txtGolongan
        '
        Me.txtGolongan.Location = New System.Drawing.Point(550, 12)
        Me.txtGolongan.MaximumSize = New System.Drawing.Size(100, 22)
        Me.txtGolongan.Name = "txtGolongan"
        Me.txtGolongan.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[True]
        Me.txtGolongan.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtGolongan.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Golongan", "Golongan", 30, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Description", "")})
        Me.txtGolongan.Properties.DisplayMember = "Description"
        Me.txtGolongan.Properties.NullText = ""
        Me.txtGolongan.Properties.PopupFormMinSize = New System.Drawing.Size(30, 0)
        Me.txtGolongan.Properties.PopupSizeable = False
        Me.txtGolongan.Properties.ShowFooter = False
        Me.txtGolongan.Properties.ShowHeader = False
        Me.txtGolongan.Properties.ValueMember = "Golongan"
        Me.txtGolongan.Size = New System.Drawing.Size(62, 22)
        Me.txtGolongan.StyleController = Me.LayoutControl1
        Me.txtGolongan.TabIndex = 3
        '
        'txtPurpose
        '
        Me.txtPurpose.Location = New System.Drawing.Point(703, 12)
        Me.txtPurpose.Name = "txtPurpose"
        Me.txtPurpose.Size = New System.Drawing.Size(337, 22)
        Me.txtPurpose.StyleController = Me.LayoutControl1
        Me.txtPurpose.TabIndex = 4
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.LayoutControlItem9, Me.LayoutControlItem10, Me.LayoutControlItem2, Me.LayoutControlItem11, Me.LayoutControlItem12, Me.LayoutControlItem1, Me.EmptySpaceItem2, Me.EmptySpaceItem3, Me.EmptySpaceItem5, Me.EmptySpaceItem6, Me.EmptySpaceItem4, Me.LayoutControlItem16})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(1260, 95)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.btnAdd
        Me.LayoutControlItem3.Location = New System.Drawing.Point(1161, 26)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(79, 49)
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem3.TextVisible = False
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.txtApproved
        Me.LayoutControlItem4.Location = New System.Drawing.Point(1032, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2)
        Me.LayoutControlItem4.Size = New System.Drawing.Size(208, 26)
        Me.LayoutControlItem4.Text = "Approved"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(76, 16)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.txtNoRequest
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(145, 26)
        Me.LayoutControlItem5.Text = "No Request"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(76, 16)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.txtDepartement
        Me.LayoutControlItem6.Location = New System.Drawing.Point(145, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2)
        Me.LayoutControlItem6.Size = New System.Drawing.Size(153, 26)
        Me.LayoutControlItem6.Text = "Dept"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(76, 16)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.txtGolongan
        Me.LayoutControlItem7.Location = New System.Drawing.Point(461, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 2, 2, 2)
        Me.LayoutControlItem7.Size = New System.Drawing.Size(143, 26)
        Me.LayoutControlItem7.Text = "Golongan"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(76, 16)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.txtPurpose
        Me.LayoutControlItem8.Location = New System.Drawing.Point(614, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 2, 2, 2)
        Me.LayoutControlItem8.Size = New System.Drawing.Size(418, 26)
        Me.LayoutControlItem8.Text = "Purpose"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(76, 16)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.txtNama
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 33)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(451, 42)
        Me.LayoutControlItem9.Text = "Nama"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(76, 16)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.txtTravelType
        Me.LayoutControlItem10.Location = New System.Drawing.Point(461, 33)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 2, 2, 2)
        Me.LayoutControlItem10.Size = New System.Drawing.Size(143, 42)
        Me.LayoutControlItem10.Text = "Travel Type"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(76, 16)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtAdvanceUSD
        Me.LayoutControlItem2.Location = New System.Drawing.Point(614, 33)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(0, 2, 2, 2)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(143, 42)
        Me.LayoutControlItem2.Text = "Advance USD"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(76, 16)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.txtAdvanceYEN
        Me.LayoutControlItem11.Location = New System.Drawing.Point(757, 33)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2)
        Me.LayoutControlItem11.Size = New System.Drawing.Size(153, 42)
        Me.LayoutControlItem11.Text = "Advance YEN"
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(76, 16)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.txtAdvanceIDR
        Me.LayoutControlItem12.Location = New System.Drawing.Point(910, 33)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2)
        Me.LayoutControlItem12.Size = New System.Drawing.Size(153, 42)
        Me.LayoutControlItem12.Text = "Advance IDR"
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(76, 16)
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtNIK
        Me.LayoutControlItem1.Location = New System.Drawing.Point(298, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 2, 2, 2)
        Me.LayoutControlItem1.Size = New System.Drawing.Size(153, 26)
        Me.LayoutControlItem1.Text = "NIK"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(76, 16)
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 26)
        Me.EmptySpaceItem2.MaxSize = New System.Drawing.Size(0, 7)
        Me.EmptySpaceItem2.MinSize = New System.Drawing.Size(10, 7)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(451, 7)
        Me.EmptySpaceItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem3
        '
        Me.EmptySpaceItem3.AllowHotTrack = False
        Me.EmptySpaceItem3.Location = New System.Drawing.Point(614, 26)
        Me.EmptySpaceItem3.MaxSize = New System.Drawing.Size(0, 7)
        Me.EmptySpaceItem3.MinSize = New System.Drawing.Size(10, 7)
        Me.EmptySpaceItem3.Name = "EmptySpaceItem3"
        Me.EmptySpaceItem3.Size = New System.Drawing.Size(449, 7)
        Me.EmptySpaceItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem3.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem5
        '
        Me.EmptySpaceItem5.AllowHotTrack = False
        Me.EmptySpaceItem5.Location = New System.Drawing.Point(461, 26)
        Me.EmptySpaceItem5.MaxSize = New System.Drawing.Size(0, 7)
        Me.EmptySpaceItem5.MinSize = New System.Drawing.Size(10, 7)
        Me.EmptySpaceItem5.Name = "EmptySpaceItem5"
        Me.EmptySpaceItem5.Size = New System.Drawing.Size(143, 7)
        Me.EmptySpaceItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem5.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem6
        '
        Me.EmptySpaceItem6.AllowHotTrack = False
        Me.EmptySpaceItem6.Location = New System.Drawing.Point(451, 0)
        Me.EmptySpaceItem6.MaxSize = New System.Drawing.Size(0, 10)
        Me.EmptySpaceItem6.MinSize = New System.Drawing.Size(10, 10)
        Me.EmptySpaceItem6.Name = "EmptySpaceItem6"
        Me.EmptySpaceItem6.Size = New System.Drawing.Size(10, 75)
        Me.EmptySpaceItem6.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem6.TextSize = New System.Drawing.Size(0, 0)
        '
        'EmptySpaceItem4
        '
        Me.EmptySpaceItem4.AllowHotTrack = False
        Me.EmptySpaceItem4.Location = New System.Drawing.Point(604, 0)
        Me.EmptySpaceItem4.MaxSize = New System.Drawing.Size(0, 10)
        Me.EmptySpaceItem4.MinSize = New System.Drawing.Size(10, 10)
        Me.EmptySpaceItem4.Name = "EmptySpaceItem4"
        Me.EmptySpaceItem4.Size = New System.Drawing.Size(10, 75)
        Me.EmptySpaceItem4.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.EmptySpaceItem4.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem16
        '
        Me.LayoutControlItem16.Control = Me.LabelControl1
        Me.LayoutControlItem16.Location = New System.Drawing.Point(1063, 26)
        Me.LayoutControlItem16.Name = "LayoutControlItem16"
        Me.LayoutControlItem16.Padding = New DevExpress.XtraLayout.Utils.Padding(10, 10, 12, 2)
        Me.LayoutControlItem16.Size = New System.Drawing.Size(98, 49)
        Me.LayoutControlItem16.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem16.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 26)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(1077, 94)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'GridDetail
        '
        Me.GridDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridDetail.Location = New System.Drawing.Point(12, 12)
        Me.GridDetail.MainView = Me.GridViewDetail
        Me.GridDetail.Name = "GridDetail"
        Me.GridDetail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CNegara})
        Me.GridDetail.Size = New System.Drawing.Size(1236, 225)
        Me.GridDetail.TabIndex = 2
        Me.GridDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewDetail})
        '
        'GridViewDetail
        '
        Me.GridViewDetail.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.DestinationGrid, Me.NegaraGrid, Me.NoPasporGrid, Me.NoVisaGrid, Me.VisaGrid, Me.DepartureDateGrid, Me.ArrivalDateGrid, Me.GDetailDay, Me.GRateAllowanceUSD, Me.GRateAllowanceYEN})
        Me.GridViewDetail.GridControl = Me.GridDetail
        Me.GridViewDetail.Name = "GridViewDetail"
        Me.GridViewDetail.OptionsCustomization.AllowFilter = False
        Me.GridViewDetail.OptionsCustomization.AllowSort = False
        Me.GridViewDetail.OptionsView.ShowGroupPanel = False
        '
        'DestinationGrid
        '
        Me.DestinationGrid.Caption = "Destination"
        Me.DestinationGrid.FieldName = "Destination"
        Me.DestinationGrid.MinWidth = 25
        Me.DestinationGrid.Name = "DestinationGrid"
        Me.DestinationGrid.Visible = True
        Me.DestinationGrid.VisibleIndex = 0
        Me.DestinationGrid.Width = 863
        '
        'NegaraGrid
        '
        Me.NegaraGrid.Caption = "Negara"
        Me.NegaraGrid.ColumnEdit = Me.CNegara
        Me.NegaraGrid.FieldName = "Negara"
        Me.NegaraGrid.MinWidth = 25
        Me.NegaraGrid.Name = "NegaraGrid"
        Me.NegaraGrid.OptionsColumn.FixedWidth = True
        Me.NegaraGrid.Visible = True
        Me.NegaraGrid.VisibleIndex = 1
        Me.NegaraGrid.Width = 150
        '
        'CNegara
        '
        Me.CNegara.AutoHeight = False
        Me.CNegara.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CNegara.Name = "CNegara"
        Me.CNegara.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'NoPasporGrid
        '
        Me.NoPasporGrid.Caption = "No Paspor"
        Me.NoPasporGrid.FieldName = "NoPaspor"
        Me.NoPasporGrid.MinWidth = 25
        Me.NoPasporGrid.Name = "NoPasporGrid"
        Me.NoPasporGrid.OptionsColumn.AllowEdit = False
        Me.NoPasporGrid.Visible = True
        Me.NoPasporGrid.VisibleIndex = 2
        Me.NoPasporGrid.Width = 94
        '
        'NoVisaGrid
        '
        Me.NoVisaGrid.Caption = "No Visa"
        Me.NoVisaGrid.FieldName = "NoVisa"
        Me.NoVisaGrid.MinWidth = 25
        Me.NoVisaGrid.Name = "NoVisaGrid"
        Me.NoVisaGrid.Width = 94
        '
        'VisaGrid
        '
        Me.VisaGrid.Caption = "Visa"
        Me.VisaGrid.FieldName = "Visa"
        Me.VisaGrid.MinWidth = 25
        Me.VisaGrid.Name = "VisaGrid"
        Me.VisaGrid.OptionsColumn.AllowEdit = False
        Me.VisaGrid.Visible = True
        Me.VisaGrid.VisibleIndex = 3
        Me.VisaGrid.Width = 94
        '
        'DepartureDateGrid
        '
        Me.DepartureDateGrid.Caption = "Departure Date"
        Me.DepartureDateGrid.ColumnEdit = Me.CDepartureDate
        Me.DepartureDateGrid.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.DepartureDateGrid.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DepartureDateGrid.FieldName = "DepartureDate"
        Me.DepartureDateGrid.MinWidth = 25
        Me.DepartureDateGrid.Name = "DepartureDateGrid"
        Me.DepartureDateGrid.OptionsColumn.FixedWidth = True
        Me.DepartureDateGrid.Visible = True
        Me.DepartureDateGrid.VisibleIndex = 4
        Me.DepartureDateGrid.Width = 150
        '
        'ArrivalDateGrid
        '
        Me.ArrivalDateGrid.Caption = "Arrival Date"
        Me.ArrivalDateGrid.ColumnEdit = Me.CArrivalDate
        Me.ArrivalDateGrid.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.ArrivalDateGrid.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ArrivalDateGrid.FieldName = "ArrivalDate"
        Me.ArrivalDateGrid.MinWidth = 25
        Me.ArrivalDateGrid.Name = "ArrivalDateGrid"
        Me.ArrivalDateGrid.OptionsColumn.FixedWidth = True
        Me.ArrivalDateGrid.Visible = True
        Me.ArrivalDateGrid.VisibleIndex = 5
        Me.ArrivalDateGrid.Width = 150
        '
        'GDetailDay
        '
        Me.GDetailDay.Caption = "Day"
        Me.GDetailDay.FieldName = "Day"
        Me.GDetailDay.MinWidth = 25
        Me.GDetailDay.Name = "GDetailDay"
        Me.GDetailDay.Width = 94
        '
        'GRateAllowanceUSD
        '
        Me.GRateAllowanceUSD.Caption = "RateAllowanceUSD"
        Me.GRateAllowanceUSD.FieldName = "RateAllowanceUSD"
        Me.GRateAllowanceUSD.MinWidth = 25
        Me.GRateAllowanceUSD.Name = "GRateAllowanceUSD"
        Me.GRateAllowanceUSD.Width = 94
        '
        'GRateAllowanceYEN
        '
        Me.GRateAllowanceYEN.Caption = "RateAllowanceYEN"
        Me.GRateAllowanceYEN.FieldName = "RateAllowanceYEN"
        Me.GRateAllowanceYEN.MinWidth = 25
        Me.GRateAllowanceYEN.Name = "GRateAllowanceYEN"
        Me.GRateAllowanceYEN.Width = 94
        '
        'DxValidationProvider1
        '
        Me.DxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.[Auto]
        '
        'GridAdvance
        '
        Me.GridAdvance.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridAdvance.Location = New System.Drawing.Point(6, 28)
        Me.GridAdvance.MainView = Me.GridViewAdvance
        Me.GridAdvance.Name = "GridAdvance"
        Me.GridAdvance.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CAdvanceIDR, Me.CAdvanceUSD, Me.CAdvanceYEN})
        Me.GridAdvance.Size = New System.Drawing.Size(1224, 152)
        Me.GridAdvance.TabIndex = 23
        Me.GridAdvance.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewAdvance})
        '
        'GridViewAdvance
        '
        Me.GridViewAdvance.ActiveFilterEnabled = False
        Me.GridViewAdvance.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GAdvanceCostType, Me.GAdvanceDescription, Me.GAdvanceDays, Me.GAdvanceAdvanceUSD, Me.GAdvanceAdvanceIDRUSD, Me.GAdvanceAdvanceYEN, Me.GAdvanceAdvanceIDRYEN, Me.GAdvanceAdvanceIDR, Me.GAdvanceRateAdvanceIDR, Me.GAdvanceTotalAdvanceIDR})
        Me.GridViewAdvance.GridControl = Me.GridAdvance
        Me.GridViewAdvance.Name = "GridViewAdvance"
        Me.GridViewAdvance.OptionsCustomization.AllowFilter = False
        Me.GridViewAdvance.OptionsCustomization.AllowSort = False
        Me.GridViewAdvance.OptionsView.ShowFooter = True
        Me.GridViewAdvance.OptionsView.ShowGroupPanel = False
        '
        'GAdvanceCostType
        '
        Me.GAdvanceCostType.Caption = "Cost Type"
        Me.GAdvanceCostType.FieldName = "CostType"
        Me.GAdvanceCostType.MinWidth = 25
        Me.GAdvanceCostType.Name = "GAdvanceCostType"
        Me.GAdvanceCostType.OptionsColumn.AllowEdit = False
        Me.GAdvanceCostType.Width = 94
        '
        'GAdvanceDescription
        '
        Me.GAdvanceDescription.Caption = "Description"
        Me.GAdvanceDescription.FieldName = "Description"
        Me.GAdvanceDescription.MinWidth = 25
        Me.GAdvanceDescription.Name = "GAdvanceDescription"
        Me.GAdvanceDescription.OptionsColumn.AllowEdit = False
        Me.GAdvanceDescription.Visible = True
        Me.GAdvanceDescription.VisibleIndex = 0
        Me.GAdvanceDescription.Width = 450
        '
        'GAdvanceDays
        '
        Me.GAdvanceDays.Caption = "Days"
        Me.GAdvanceDays.FieldName = "Days"
        Me.GAdvanceDays.MinWidth = 25
        Me.GAdvanceDays.Name = "GAdvanceDays"
        Me.GAdvanceDays.OptionsColumn.AllowEdit = False
        Me.GAdvanceDays.OptionsColumn.FixedWidth = True
        Me.GAdvanceDays.Visible = True
        Me.GAdvanceDays.VisibleIndex = 1
        Me.GAdvanceDays.Width = 100
        '
        'GAdvanceAdvanceUSD
        '
        Me.GAdvanceAdvanceUSD.Caption = "Advance USD"
        Me.GAdvanceAdvanceUSD.ColumnEdit = Me.CAdvanceUSD
        Me.GAdvanceAdvanceUSD.DisplayFormat.FormatString = "n2"
        Me.GAdvanceAdvanceUSD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAdvanceAdvanceUSD.FieldName = "AdvanceUSD"
        Me.GAdvanceAdvanceUSD.MinWidth = 25
        Me.GAdvanceAdvanceUSD.Name = "GAdvanceAdvanceUSD"
        Me.GAdvanceAdvanceUSD.OptionsColumn.AllowEdit = False
        Me.GAdvanceAdvanceUSD.OptionsColumn.FixedWidth = True
        Me.GAdvanceAdvanceUSD.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AdvanceUSD", "{0:#,##0.#0}")})
        Me.GAdvanceAdvanceUSD.Visible = True
        Me.GAdvanceAdvanceUSD.VisibleIndex = 2
        Me.GAdvanceAdvanceUSD.Width = 200
        '
        'CAdvanceUSD
        '
        Me.CAdvanceUSD.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.CAdvanceUSD.AutoHeight = False
        Me.CAdvanceUSD.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CAdvanceUSD.DisplayFormat.FormatString = "n2"
        Me.CAdvanceUSD.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.CAdvanceUSD.EditFormat.FormatString = "n2"
        Me.CAdvanceUSD.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.CAdvanceUSD.Mask.EditMask = "n2"
        Me.CAdvanceUSD.Name = "CAdvanceUSD"
        '
        'GAdvanceAdvanceIDRUSD
        '
        Me.GAdvanceAdvanceIDRUSD.Caption = "Advance IDR USD"
        Me.GAdvanceAdvanceIDRUSD.FieldName = "AdvanceIDRUSD"
        Me.GAdvanceAdvanceIDRUSD.MinWidth = 25
        Me.GAdvanceAdvanceIDRUSD.Name = "GAdvanceAdvanceIDRUSD"
        Me.GAdvanceAdvanceIDRUSD.Width = 94
        '
        'GAdvanceAdvanceYEN
        '
        Me.GAdvanceAdvanceYEN.Caption = "Advance YEN"
        Me.GAdvanceAdvanceYEN.ColumnEdit = Me.CAdvanceYEN
        Me.GAdvanceAdvanceYEN.DisplayFormat.FormatString = "n2"
        Me.GAdvanceAdvanceYEN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAdvanceAdvanceYEN.FieldName = "AdvanceYEN"
        Me.GAdvanceAdvanceYEN.MinWidth = 25
        Me.GAdvanceAdvanceYEN.Name = "GAdvanceAdvanceYEN"
        Me.GAdvanceAdvanceYEN.OptionsColumn.AllowEdit = False
        Me.GAdvanceAdvanceYEN.OptionsColumn.FixedWidth = True
        Me.GAdvanceAdvanceYEN.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AdvanceYEN", "{0:#,##0.#0}")})
        Me.GAdvanceAdvanceYEN.Visible = True
        Me.GAdvanceAdvanceYEN.VisibleIndex = 3
        Me.GAdvanceAdvanceYEN.Width = 200
        '
        'CAdvanceYEN
        '
        Me.CAdvanceYEN.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.CAdvanceYEN.AutoHeight = False
        Me.CAdvanceYEN.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CAdvanceYEN.DisplayFormat.FormatString = "n2"
        Me.CAdvanceYEN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.CAdvanceYEN.EditFormat.FormatString = "n2"
        Me.CAdvanceYEN.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.CAdvanceYEN.Mask.EditMask = "n2"
        Me.CAdvanceYEN.Name = "CAdvanceYEN"
        Me.CAdvanceYEN.NullText = "0000"
        Me.CAdvanceYEN.NullValuePrompt = "0000"
        '
        'GAdvanceAdvanceIDRYEN
        '
        Me.GAdvanceAdvanceIDRYEN.Caption = "Advance IDR YEN"
        Me.GAdvanceAdvanceIDRYEN.FieldName = "AdvanceIDRYEN"
        Me.GAdvanceAdvanceIDRYEN.MinWidth = 25
        Me.GAdvanceAdvanceIDRYEN.Name = "GAdvanceAdvanceIDRYEN"
        Me.GAdvanceAdvanceIDRYEN.Width = 94
        '
        'GAdvanceAdvanceIDR
        '
        Me.GAdvanceAdvanceIDR.Caption = "Advance IDR"
        Me.GAdvanceAdvanceIDR.ColumnEdit = Me.CAdvanceIDR
        Me.GAdvanceAdvanceIDR.DisplayFormat.FormatString = "n2"
        Me.GAdvanceAdvanceIDR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAdvanceAdvanceIDR.FieldName = "AdvanceIDR"
        Me.GAdvanceAdvanceIDR.MinWidth = 25
        Me.GAdvanceAdvanceIDR.Name = "GAdvanceAdvanceIDR"
        Me.GAdvanceAdvanceIDR.OptionsColumn.AllowEdit = False
        Me.GAdvanceAdvanceIDR.OptionsColumn.FixedWidth = True
        Me.GAdvanceAdvanceIDR.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "AdvanceIDR", "{0:#,##0.#0}")})
        Me.GAdvanceAdvanceIDR.Visible = True
        Me.GAdvanceAdvanceIDR.VisibleIndex = 4
        Me.GAdvanceAdvanceIDR.Width = 200
        '
        'CAdvanceIDR
        '
        Me.CAdvanceIDR.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.CAdvanceIDR.AutoHeight = False
        Me.CAdvanceIDR.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CAdvanceIDR.DisplayFormat.FormatString = "n2"
        Me.CAdvanceIDR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.CAdvanceIDR.EditFormat.FormatString = "n2"
        Me.CAdvanceIDR.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.CAdvanceIDR.Mask.EditMask = "n2"
        Me.CAdvanceIDR.Name = "CAdvanceIDR"
        '
        'GAdvanceRateAdvanceIDR
        '
        Me.GAdvanceRateAdvanceIDR.Caption = "Rate Advance IDR"
        Me.GAdvanceRateAdvanceIDR.DisplayFormat.FormatString = "n2"
        Me.GAdvanceRateAdvanceIDR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAdvanceRateAdvanceIDR.FieldName = "RateAdvanceIDR"
        Me.GAdvanceRateAdvanceIDR.MinWidth = 25
        Me.GAdvanceRateAdvanceIDR.Name = "GAdvanceRateAdvanceIDR"
        Me.GAdvanceRateAdvanceIDR.OptionsColumn.AllowEdit = False
        Me.GAdvanceRateAdvanceIDR.OptionsColumn.FixedWidth = True
        Me.GAdvanceRateAdvanceIDR.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "RateAdvanceIDR", "{0:#,##0.#0}")})
        Me.GAdvanceRateAdvanceIDR.Visible = True
        Me.GAdvanceRateAdvanceIDR.VisibleIndex = 5
        Me.GAdvanceRateAdvanceIDR.Width = 200
        '
        'GAdvanceTotalAdvanceIDR
        '
        Me.GAdvanceTotalAdvanceIDR.Caption = "Total Advance IDR"
        Me.GAdvanceTotalAdvanceIDR.DisplayFormat.FormatString = "n2"
        Me.GAdvanceTotalAdvanceIDR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GAdvanceTotalAdvanceIDR.FieldName = "TotalAdvanceIDR"
        Me.GAdvanceTotalAdvanceIDR.MinWidth = 25
        Me.GAdvanceTotalAdvanceIDR.Name = "GAdvanceTotalAdvanceIDR"
        Me.GAdvanceTotalAdvanceIDR.OptionsColumn.AllowEdit = False
        Me.GAdvanceTotalAdvanceIDR.OptionsColumn.FixedWidth = True
        Me.GAdvanceTotalAdvanceIDR.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TotalAdvanceIDR", "{0:#,##0.#0}")})
        Me.GAdvanceTotalAdvanceIDR.UnboundExpression = "[AdvanceIDRUSD] + [AdvanceIDRYEN] + [AdvanceIDR]"
        Me.GAdvanceTotalAdvanceIDR.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.GAdvanceTotalAdvanceIDR.Visible = True
        Me.GAdvanceTotalAdvanceIDR.VisibleIndex = 6
        Me.GAdvanceTotalAdvanceIDR.Width = 200
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.GridAdvance)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1236, 186)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Advance dan Pocket Allowance"
        '
        'LayoutControl3
        '
        Me.LayoutControl3.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LayoutControl3.Controls.Add(Me.GroupBox1)
        Me.LayoutControl3.Location = New System.Drawing.Point(10, 395)
        Me.LayoutControl3.Name = "LayoutControl3"
        Me.LayoutControl3.Root = Me.LayoutControlGroup2
        Me.LayoutControl3.Size = New System.Drawing.Size(1260, 210)
        Me.LayoutControl3.TabIndex = 36
        Me.LayoutControl3.Text = "LayoutControl3"
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem15})
        Me.LayoutControlGroup2.Name = "LayoutControlGroup2"
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1260, 210)
        Me.LayoutControlGroup2.TextVisible = False
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.GroupBox1
        Me.LayoutControlItem15.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(1240, 190)
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem15.TextVisible = False
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LayoutControl2.Controls.Add(Me.GridDetail)
        Me.LayoutControl2.Location = New System.Drawing.Point(10, 140)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.Root = Me.LayoutControlGroup1
        Me.LayoutControl2.Size = New System.Drawing.Size(1260, 249)
        Me.LayoutControl2.TabIndex = 37
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem14})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1260, 249)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.GridDetail
        Me.LayoutControlItem14.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(1240, 229)
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem14.TextVisible = False
        '
        'FrmTravelRequestDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.ClientSize = New System.Drawing.Size(1282, 617)
        Me.Controls.Add(Me.LayoutControl2)
        Me.Controls.Add(Me.LayoutControl3)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "FrmTravelRequestDetail"
        Me.Controls.SetChildIndex(Me.LayoutControl1, 0)
        Me.Controls.SetChildIndex(Me.LayoutControl3, 0)
        Me.Controls.SetChildIndex(Me.LayoutControl2, 0)
        CType(Me.CDepartureDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CDepartureDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CArrivalDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CArrivalDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoRequest.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtNIK.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAdvanceIDR.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAdvanceYEN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAdvanceUSD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTravelType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtApproved.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNama.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtDepartement.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGolongan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPurpose.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CNegara, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridAdvance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewAdvance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CAdvanceUSD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CAdvanceYEN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CAdvanceIDR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl3.ResumeLayout(False)
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAdd As Button
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents GridDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewDetail As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents txtNoRequest As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DepartureDateGrid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ArrivalDateGrid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DestinationGrid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtTravelType As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents DxValidationProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents NegaraGrid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtNama As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtPurpose As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GridAdvance As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewAdvance As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GAdvanceDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAdvanceAdvanceIDR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAdvanceAdvanceUSD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAdvanceAdvanceYEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtAdvanceIDR As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtAdvanceUSD As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtAdvanceYEN As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GAdvanceDays As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents VisaGrid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CNegara As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents CDepartureDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents CArrivalDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents GAdvanceCostType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NoPasporGrid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtDepartement As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CAdvanceUSD As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents CAdvanceYEN As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents CAdvanceIDR As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents NoVisaGrid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAdvanceTotalAdvanceIDR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAdvanceAdvanceIDRUSD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAdvanceAdvanceIDRYEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtNIK As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GAdvanceRateAdvanceIDR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtApproved As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents txtGolongan As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents GDetailDay As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRateAllowanceUSD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRateAllowanceYEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents BehaviorManager1 As DevExpress.Utils.Behaviors.BehaviorManager
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem3 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControl3 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem5 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem6 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents EmptySpaceItem4 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem16 As DevExpress.XtraLayout.LayoutControlItem
End Class
