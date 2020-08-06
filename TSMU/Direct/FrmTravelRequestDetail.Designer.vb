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
        Me.txtTravelType = New DevExpress.XtraEditors.ComboBoxEdit()
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
        Me.DxValidationProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        Me.txtNIK = New DevExpress.XtraEditors.TextEdit()
        Me.txtNama = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl1 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl2 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl3 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl4 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl5 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl6 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl8 = New DevExpress.XtraEditors.LabelControl()
        Me.txtPurpose = New DevExpress.XtraEditors.TextEdit()
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
        Me.txtAdvanceIDR = New DevExpress.XtraEditors.TextEdit()
        Me.txtAdvanceUSD = New DevExpress.XtraEditors.TextEdit()
        Me.LabelControl7 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl9 = New DevExpress.XtraEditors.LabelControl()
        Me.LabelControl10 = New DevExpress.XtraEditors.LabelControl()
        Me.txtAdvanceYEN = New DevExpress.XtraEditors.TextEdit()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDepartement = New DevExpress.XtraEditors.TextEdit()
        Me.txtApproved = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.LabelControl11 = New DevExpress.XtraEditors.LabelControl()
        Me.txtGolongan = New DevExpress.XtraEditors.LookUpEdit()
        Me.GRateAllowanceUSD = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GRateAllowanceYEN = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.CDepartureDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CDepartureDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CArrivalDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CArrivalDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNoRequest.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTravelType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CNegara, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNIK.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNama.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPurpose.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridAdvance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewAdvance, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CAdvanceUSD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CAdvanceYEN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CAdvanceIDR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAdvanceIDR.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAdvanceUSD.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAdvanceYEN.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.txtDepartement.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtApproved.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGolongan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.btnAdd.Location = New System.Drawing.Point(1403, 86)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(124, 37)
        Me.btnAdd.TabIndex = 10
        Me.btnAdd.Text = "Add Detail ++"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtNoRequest
        '
        Me.txtNoRequest.EditValue = ""
        Me.txtNoRequest.Enabled = False
        Me.txtNoRequest.Location = New System.Drawing.Point(120, 48)
        Me.txtNoRequest.Name = "txtNoRequest"
        Me.txtNoRequest.Size = New System.Drawing.Size(130, 22)
        Me.txtNoRequest.TabIndex = 0
        '
        'txtTravelType
        '
        Me.txtTravelType.EditValue = ""
        Me.txtTravelType.Location = New System.Drawing.Point(693, 88)
        Me.txtTravelType.Name = "txtTravelType"
        Me.txtTravelType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtTravelType.Properties.Items.AddRange(New Object() {"DN", "LN"})
        Me.txtTravelType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txtTravelType.Size = New System.Drawing.Size(104, 22)
        Me.txtTravelType.TabIndex = 6
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
        Me.GridDetail.Location = New System.Drawing.Point(25, 134)
        Me.GridDetail.MainView = Me.GridViewDetail
        Me.GridDetail.Name = "GridDetail"
        Me.GridDetail.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CNegara})
        Me.GridDetail.Size = New System.Drawing.Size(1502, 520)
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
        'DxValidationProvider1
        '
        Me.DxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.[Auto]
        '
        'txtNIK
        '
        Me.txtNIK.EditValue = ""
        Me.txtNIK.Location = New System.Drawing.Point(477, 48)
        Me.txtNIK.Name = "txtNIK"
        Me.txtNIK.Properties.MaxLength = 9
        Me.txtNIK.Size = New System.Drawing.Size(100, 22)
        Me.txtNIK.TabIndex = 2
        ConditionValidationRule1.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule1.ErrorText = "This value is not valid"
        ConditionValidationRule1.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
        Me.DxValidationProvider1.SetValidationRule(Me.txtNIK, ConditionValidationRule1)
        '
        'txtNama
        '
        Me.txtNama.EditValue = ""
        Me.txtNama.Location = New System.Drawing.Point(120, 88)
        Me.txtNama.Name = "txtNama"
        Me.txtNama.Properties.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.txtNama.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtNama.Properties.EditFormat.FormatString = "dd/MM/yyyy"
        Me.txtNama.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.txtNama.Size = New System.Drawing.Size(457, 22)
        Me.txtNama.TabIndex = 5
        ConditionValidationRule2.ConditionOperator = DevExpress.XtraEditors.DXErrorProvider.ConditionOperator.IsNotBlank
        ConditionValidationRule2.ErrorText = "This value is not valid"
        ConditionValidationRule2.ErrorType = DevExpress.XtraEditors.DXErrorProvider.ErrorType.Warning
        Me.DxValidationProvider1.SetValidationRule(Me.txtNama, ConditionValidationRule2)
        '
        'LabelControl1
        '
        Me.LabelControl1.Location = New System.Drawing.Point(25, 51)
        Me.LabelControl1.Name = "LabelControl1"
        Me.LabelControl1.Size = New System.Drawing.Size(65, 16)
        Me.LabelControl1.TabIndex = 14
        Me.LabelControl1.Text = "No Request"
        '
        'LabelControl2
        '
        Me.LabelControl2.Location = New System.Drawing.Point(272, 51)
        Me.LabelControl2.Name = "LabelControl2"
        Me.LabelControl2.Size = New System.Drawing.Size(26, 16)
        Me.LabelControl2.TabIndex = 15
        Me.LabelControl2.Text = "Dept"
        '
        'LabelControl3
        '
        Me.LabelControl3.Location = New System.Drawing.Point(430, 51)
        Me.LabelControl3.Name = "LabelControl3"
        Me.LabelControl3.Size = New System.Drawing.Size(19, 16)
        Me.LabelControl3.TabIndex = 16
        Me.LabelControl3.Text = "NIK"
        '
        'LabelControl4
        '
        Me.LabelControl4.Location = New System.Drawing.Point(25, 91)
        Me.LabelControl4.Name = "LabelControl4"
        Me.LabelControl4.Size = New System.Drawing.Size(33, 16)
        Me.LabelControl4.TabIndex = 17
        Me.LabelControl4.Text = "Nama"
        '
        'LabelControl5
        '
        Me.LabelControl5.Location = New System.Drawing.Point(605, 51)
        Me.LabelControl5.Name = "LabelControl5"
        Me.LabelControl5.Size = New System.Drawing.Size(53, 16)
        Me.LabelControl5.TabIndex = 18
        Me.LabelControl5.Text = "Golongan"
        '
        'LabelControl6
        '
        Me.LabelControl6.Location = New System.Drawing.Point(828, 51)
        Me.LabelControl6.Name = "LabelControl6"
        Me.LabelControl6.Size = New System.Drawing.Size(41, 16)
        Me.LabelControl6.TabIndex = 19
        Me.LabelControl6.Text = "Pupose"
        '
        'LabelControl8
        '
        Me.LabelControl8.Location = New System.Drawing.Point(605, 91)
        Me.LabelControl8.Name = "LabelControl8"
        Me.LabelControl8.Size = New System.Drawing.Size(68, 16)
        Me.LabelControl8.TabIndex = 21
        Me.LabelControl8.Text = "Travel Type"
        '
        'txtPurpose
        '
        Me.txtPurpose.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtPurpose.Location = New System.Drawing.Point(900, 48)
        Me.txtPurpose.Name = "txtPurpose"
        Me.txtPurpose.Size = New System.Drawing.Size(395, 22)
        Me.txtPurpose.TabIndex = 4
        '
        'GridAdvance
        '
        Me.GridAdvance.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridAdvance.Location = New System.Drawing.Point(6, 22)
        Me.GridAdvance.MainView = Me.GridViewAdvance
        Me.GridAdvance.Name = "GridAdvance"
        Me.GridAdvance.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CAdvanceIDR, Me.CAdvanceUSD, Me.CAdvanceYEN})
        Me.GridAdvance.Size = New System.Drawing.Size(1490, 156)
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
        'txtAdvanceIDR
        '
        Me.txtAdvanceIDR.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtAdvanceIDR.EditValue = "0"
        Me.txtAdvanceIDR.Location = New System.Drawing.Point(532, 19)
        Me.txtAdvanceIDR.MaximumSize = New System.Drawing.Size(160, 0)
        Me.txtAdvanceIDR.Name = "txtAdvanceIDR"
        Me.txtAdvanceIDR.Properties.Mask.EditMask = "n2"
        Me.txtAdvanceIDR.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtAdvanceIDR.Properties.Name = "txtAdvanceIDR"
        Me.txtAdvanceIDR.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtAdvanceIDR.Size = New System.Drawing.Size(6, 22)
        Me.txtAdvanceIDR.TabIndex = 7
        '
        'txtAdvanceUSD
        '
        Me.txtAdvanceUSD.EditValue = "0"
        Me.txtAdvanceUSD.Location = New System.Drawing.Point(72, 19)
        Me.txtAdvanceUSD.Name = "txtAdvanceUSD"
        Me.txtAdvanceUSD.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.[False]
        Me.txtAdvanceUSD.Properties.DisplayFormat.FormatString = "n2"
        Me.txtAdvanceUSD.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtAdvanceUSD.Properties.EditFormat.FormatString = "n2"
        Me.txtAdvanceUSD.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.txtAdvanceUSD.Properties.Mask.EditMask = "n2"
        Me.txtAdvanceUSD.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtAdvanceUSD.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtAdvanceUSD.Size = New System.Drawing.Size(160, 22)
        Me.txtAdvanceUSD.TabIndex = 8
        '
        'LabelControl7
        '
        Me.LabelControl7.Location = New System.Drawing.Point(21, 22)
        Me.LabelControl7.Name = "LabelControl7"
        Me.LabelControl7.Size = New System.Drawing.Size(24, 16)
        Me.LabelControl7.TabIndex = 28
        Me.LabelControl7.Text = "USD"
        '
        'LabelControl9
        '
        Me.LabelControl9.Location = New System.Drawing.Point(256, 22)
        Me.LabelControl9.Name = "LabelControl9"
        Me.LabelControl9.Size = New System.Drawing.Size(22, 16)
        Me.LabelControl9.TabIndex = 29
        Me.LabelControl9.Text = "YEN"
        '
        'LabelControl10
        '
        Me.LabelControl10.Location = New System.Drawing.Point(491, 22)
        Me.LabelControl10.Name = "LabelControl10"
        Me.LabelControl10.Size = New System.Drawing.Size(21, 16)
        Me.LabelControl10.TabIndex = 30
        Me.LabelControl10.Text = "IDR"
        '
        'txtAdvanceYEN
        '
        Me.txtAdvanceYEN.EditValue = "0"
        Me.txtAdvanceYEN.Location = New System.Drawing.Point(305, 19)
        Me.txtAdvanceYEN.Name = "txtAdvanceYEN"
        Me.txtAdvanceYEN.Properties.Mask.EditMask = "n2"
        Me.txtAdvanceYEN.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtAdvanceYEN.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.txtAdvanceYEN.Size = New System.Drawing.Size(160, 22)
        Me.txtAdvanceYEN.TabIndex = 9
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.GridAdvance)
        Me.GroupBox1.Location = New System.Drawing.Point(25, 660)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1502, 184)
        Me.GroupBox1.TabIndex = 31
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Advance dan Pocket Allowance"
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.LabelControl9)
        Me.GroupBox2.Controls.Add(Me.LabelControl7)
        Me.GroupBox2.Controls.Add(Me.LabelControl10)
        Me.GroupBox2.Controls.Add(Me.txtAdvanceYEN)
        Me.GroupBox2.Controls.Add(Me.txtAdvanceIDR)
        Me.GroupBox2.Controls.Add(Me.txtAdvanceUSD)
        Me.GroupBox2.Font = New System.Drawing.Font("Tahoma", 7.6!)
        Me.GroupBox2.Location = New System.Drawing.Point(828, 75)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(554, 53)
        Me.GroupBox2.TabIndex = 32
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Advance"
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.Location = New System.Drawing.Point(265, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label1.Size = New System.Drawing.Size(270, 16)
        Me.Label1.TabIndex = 31
        Me.Label1.Text = "l"
        '
        'txtDepartement
        '
        Me.txtDepartement.EditValue = ""
        Me.txtDepartement.Enabled = False
        Me.txtDepartement.Location = New System.Drawing.Point(325, 48)
        Me.txtDepartement.Name = "txtDepartement"
        Me.txtDepartement.Size = New System.Drawing.Size(70, 22)
        Me.txtDepartement.TabIndex = 1
        '
        'txtApproved
        '
        Me.txtApproved.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtApproved.Location = New System.Drawing.Point(1403, 48)
        Me.txtApproved.Name = "txtApproved"
        Me.txtApproved.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtApproved.Properties.Items.AddRange(New Object() {"APPROVED", "REVISED", "CANCEL"})
        Me.txtApproved.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txtApproved.Size = New System.Drawing.Size(124, 22)
        Me.txtApproved.TabIndex = 33
        '
        'LabelControl11
        '
        Me.LabelControl11.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.LabelControl11.Location = New System.Drawing.Point(1312, 51)
        Me.LabelControl11.Name = "LabelControl11"
        Me.LabelControl11.Size = New System.Drawing.Size(54, 16)
        Me.LabelControl11.TabIndex = 34
        Me.LabelControl11.Text = "Approved"
        '
        'txtGolongan
        '
        Me.txtGolongan.Location = New System.Drawing.Point(693, 48)
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
        Me.txtGolongan.Size = New System.Drawing.Size(104, 22)
        Me.txtGolongan.TabIndex = 3
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
        'FrmTravelRequestDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.ClientSize = New System.Drawing.Size(1552, 875)
        Me.Controls.Add(Me.LabelControl11)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.LabelControl8)
        Me.Controls.Add(Me.LabelControl6)
        Me.Controls.Add(Me.LabelControl5)
        Me.Controls.Add(Me.LabelControl4)
        Me.Controls.Add(Me.LabelControl3)
        Me.Controls.Add(Me.LabelControl2)
        Me.Controls.Add(Me.LabelControl1)
        Me.Controls.Add(Me.GridDetail)
        Me.Controls.Add(Me.txtNoRequest)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtPurpose)
        Me.Controls.Add(Me.txtTravelType)
        Me.Controls.Add(Me.txtNama)
        Me.Controls.Add(Me.txtDepartement)
        Me.Controls.Add(Me.txtNIK)
        Me.Controls.Add(Me.txtApproved)
        Me.Controls.Add(Me.txtGolongan)
        Me.Name = "FrmTravelRequestDetail"
        Me.Controls.SetChildIndex(Me.txtGolongan, 0)
        Me.Controls.SetChildIndex(Me.txtApproved, 0)
        Me.Controls.SetChildIndex(Me.txtNIK, 0)
        Me.Controls.SetChildIndex(Me.txtDepartement, 0)
        Me.Controls.SetChildIndex(Me.txtNama, 0)
        Me.Controls.SetChildIndex(Me.txtTravelType, 0)
        Me.Controls.SetChildIndex(Me.txtPurpose, 0)
        Me.Controls.SetChildIndex(Me.btnAdd, 0)
        Me.Controls.SetChildIndex(Me.txtNoRequest, 0)
        Me.Controls.SetChildIndex(Me.GridDetail, 0)
        Me.Controls.SetChildIndex(Me.LabelControl1, 0)
        Me.Controls.SetChildIndex(Me.LabelControl2, 0)
        Me.Controls.SetChildIndex(Me.LabelControl3, 0)
        Me.Controls.SetChildIndex(Me.LabelControl4, 0)
        Me.Controls.SetChildIndex(Me.LabelControl5, 0)
        Me.Controls.SetChildIndex(Me.LabelControl6, 0)
        Me.Controls.SetChildIndex(Me.LabelControl8, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.LabelControl11, 0)
        CType(Me.CDepartureDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CDepartureDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CArrivalDate.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CArrivalDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNoRequest.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTravelType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CNegara, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNIK.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNama.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPurpose.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridAdvance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewAdvance, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CAdvanceUSD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CAdvanceYEN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CAdvanceIDR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAdvanceIDR.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAdvanceUSD.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAdvanceYEN.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.txtDepartement.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtApproved.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGolongan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents LabelControl1 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl2 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl3 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl4 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl5 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtNama As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl6 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl8 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtPurpose As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GridAdvance As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewAdvance As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GAdvanceDescription As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAdvanceAdvanceIDR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAdvanceAdvanceUSD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GAdvanceAdvanceYEN As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtAdvanceIDR As DevExpress.XtraEditors.TextEdit
    Friend WithEvents txtAdvanceUSD As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LabelControl7 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl9 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LabelControl10 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtAdvanceYEN As DevExpress.XtraEditors.TextEdit
    Friend WithEvents GAdvanceDays As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents VisaGrid As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents CNegara As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents CDepartureDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents CArrivalDate As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents Label1 As Label
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
    Friend WithEvents LabelControl11 As DevExpress.XtraEditors.LabelControl
    Friend WithEvents txtGolongan As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents GDetailDay As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRateAllowanceUSD As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GRateAllowanceYEN As DevExpress.XtraGrid.Columns.GridColumn
End Class
