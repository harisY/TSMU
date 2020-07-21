<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTravelerDetail
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
        Me.btnAddPaspor = New System.Windows.Forms.Button()
        Me.GridPaspor = New DevExpress.XtraGrid.GridControl()
        Me.GridViewPaspor = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NoPaspor = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Nama = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.KodeNegara = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CKodeNegara = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.TanggalLahir = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CTanggalLahirPaspor = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.JenisKelamin = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CJenisKelamin = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.TanggalKeluar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TanggalKeluarPaspor = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.ExpiredDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CExpiredDatePaspor = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.TempatKeluar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CTempatKeluar = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.txtGolongan = New DevExpress.XtraEditors.TextEdit()
        Me.GridVisa = New DevExpress.XtraGrid.GridControl()
        Me.GridViewVisa = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NoVisa = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CNoVisa = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.VisaNegara = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CNegara = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.Entries = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CEntries = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.DateIssued = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CDateIssued = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.DateExpired = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CDateExpired = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.btnAddVisa = New System.Windows.Forms.Button()
        Me.TxtDeptID = New DevExpress.XtraEditors.ButtonEdit()
        Me.TxtNama = New DevExpress.XtraEditors.TextEdit()
        Me.TxtNIK = New DevExpress.XtraEditors.TextEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem2 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.DxValidationProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider(Me.components)
        Me.BehaviorManager1 = New DevExpress.Utils.Behaviors.BehaviorManager(Me.components)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridPaspor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewPaspor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CKodeNegara, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CTanggalLahirPaspor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CTanggalLahirPaspor.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CJenisKelamin, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TanggalKeluarPaspor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TanggalKeluarPaspor.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CExpiredDatePaspor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CExpiredDatePaspor.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CTempatKeluar, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtGolongan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridVisa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewVisa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CNoVisa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CNegara, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CEntries, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CDateIssued, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CDateIssued.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CDateExpired, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CDateExpired.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtDeptID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNama.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtNIK.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.btnAddPaspor)
        Me.LayoutControl1.Controls.Add(Me.GridPaspor)
        Me.LayoutControl1.Controls.Add(Me.txtGolongan)
        Me.LayoutControl1.Controls.Add(Me.GridVisa)
        Me.LayoutControl1.Controls.Add(Me.btnAddVisa)
        Me.LayoutControl1.Controls.Add(Me.TxtDeptID)
        Me.LayoutControl1.Controls.Add(Me.TxtNama)
        Me.LayoutControl1.Controls.Add(Me.TxtNIK)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 27)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1108, 0, 812, 500)
        Me.LayoutControl1.Root = Me.LayoutControlGroup1
        Me.LayoutControl1.Size = New System.Drawing.Size(1068, 614)
        Me.LayoutControl1.TabIndex = 2
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'btnAddPaspor
        '
        Me.btnAddPaspor.Location = New System.Drawing.Point(860, 12)
        Me.btnAddPaspor.Name = "btnAddPaspor"
        Me.btnAddPaspor.Size = New System.Drawing.Size(101, 25)
        Me.btnAddPaspor.TabIndex = 8
        Me.btnAddPaspor.Text = "Add Paspor"
        Me.btnAddPaspor.UseVisualStyleBackColor = True
        '
        'GridPaspor
        '
        Me.GridPaspor.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPaspor.Location = New System.Drawing.Point(12, 62)
        Me.GridPaspor.MainView = Me.GridViewPaspor
        Me.GridPaspor.Name = "GridPaspor"
        Me.GridPaspor.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CJenisKelamin, Me.CKodeNegara, Me.CTanggalLahirPaspor, Me.TanggalKeluarPaspor, Me.CExpiredDatePaspor, Me.CTempatKeluar})
        Me.GridPaspor.Size = New System.Drawing.Size(1044, 246)
        Me.GridPaspor.TabIndex = 7
        Me.GridPaspor.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewPaspor})
        '
        'GridViewPaspor
        '
        Me.GridViewPaspor.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.NoPaspor, Me.Nama, Me.KodeNegara, Me.TanggalLahir, Me.JenisKelamin, Me.TanggalKeluar, Me.ExpiredDate, Me.TempatKeluar})
        Me.GridViewPaspor.GridControl = Me.GridPaspor
        Me.GridViewPaspor.Name = "GridViewPaspor"
        Me.GridViewPaspor.OptionsView.ShowGroupPanel = False
        '
        'NoPaspor
        '
        Me.NoPaspor.Caption = "No Paspor"
        Me.NoPaspor.FieldName = "NoPaspor"
        Me.NoPaspor.MinWidth = 25
        Me.NoPaspor.Name = "NoPaspor"
        Me.NoPaspor.OptionsColumn.FixedWidth = True
        Me.NoPaspor.Visible = True
        Me.NoPaspor.VisibleIndex = 0
        Me.NoPaspor.Width = 150
        '
        'Nama
        '
        Me.Nama.Caption = "Nama"
        Me.Nama.FieldName = "Nama"
        Me.Nama.MinWidth = 25
        Me.Nama.Name = "Nama"
        Me.Nama.Visible = True
        Me.Nama.VisibleIndex = 1
        Me.Nama.Width = 94
        '
        'KodeNegara
        '
        Me.KodeNegara.Caption = "Kode Negara"
        Me.KodeNegara.ColumnEdit = Me.CKodeNegara
        Me.KodeNegara.FieldName = "KodeNegara"
        Me.KodeNegara.MinWidth = 25
        Me.KodeNegara.Name = "KodeNegara"
        Me.KodeNegara.OptionsColumn.FixedWidth = True
        Me.KodeNegara.Visible = True
        Me.KodeNegara.VisibleIndex = 2
        Me.KodeNegara.Width = 120
        '
        'CKodeNegara
        '
        Me.CKodeNegara.AutoHeight = False
        Me.CKodeNegara.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CKodeNegara.Name = "CKodeNegara"
        Me.CKodeNegara.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'TanggalLahir
        '
        Me.TanggalLahir.Caption = "Tanggal Lahir"
        Me.TanggalLahir.ColumnEdit = Me.CTanggalLahirPaspor
        Me.TanggalLahir.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.TanggalLahir.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TanggalLahir.FieldName = "TanggalLahir"
        Me.TanggalLahir.MinWidth = 25
        Me.TanggalLahir.Name = "TanggalLahir"
        Me.TanggalLahir.OptionsColumn.FixedWidth = True
        Me.TanggalLahir.Visible = True
        Me.TanggalLahir.VisibleIndex = 3
        Me.TanggalLahir.Width = 150
        '
        'CTanggalLahirPaspor
        '
        Me.CTanggalLahirPaspor.AutoHeight = False
        Me.CTanggalLahirPaspor.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CTanggalLahirPaspor.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CTanggalLahirPaspor.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.CTanggalLahirPaspor.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.CTanggalLahirPaspor.EditFormat.FormatString = "dd-MM-yyyy"
        Me.CTanggalLahirPaspor.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.CTanggalLahirPaspor.Mask.EditMask = "dd-MM-yyyy"
        Me.CTanggalLahirPaspor.Name = "CTanggalLahirPaspor"
        '
        'JenisKelamin
        '
        Me.JenisKelamin.Caption = "Jenis Kelamin"
        Me.JenisKelamin.ColumnEdit = Me.CJenisKelamin
        Me.JenisKelamin.FieldName = "JenisKelamin"
        Me.JenisKelamin.MinWidth = 25
        Me.JenisKelamin.Name = "JenisKelamin"
        Me.JenisKelamin.OptionsColumn.FixedWidth = True
        Me.JenisKelamin.Visible = True
        Me.JenisKelamin.VisibleIndex = 4
        Me.JenisKelamin.Width = 120
        '
        'CJenisKelamin
        '
        Me.CJenisKelamin.AutoHeight = False
        Me.CJenisKelamin.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CJenisKelamin.Items.AddRange(New Object() {"L", "P"})
        Me.CJenisKelamin.Name = "CJenisKelamin"
        Me.CJenisKelamin.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'TanggalKeluar
        '
        Me.TanggalKeluar.Caption = "Tanggal Keluar"
        Me.TanggalKeluar.ColumnEdit = Me.TanggalKeluarPaspor
        Me.TanggalKeluar.FieldName = "TanggalKeluar"
        Me.TanggalKeluar.MinWidth = 25
        Me.TanggalKeluar.Name = "TanggalKeluar"
        Me.TanggalKeluar.OptionsColumn.FixedWidth = True
        Me.TanggalKeluar.Visible = True
        Me.TanggalKeluar.VisibleIndex = 5
        Me.TanggalKeluar.Width = 150
        '
        'TanggalKeluarPaspor
        '
        Me.TanggalKeluarPaspor.AutoHeight = False
        Me.TanggalKeluarPaspor.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TanggalKeluarPaspor.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TanggalKeluarPaspor.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.TanggalKeluarPaspor.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TanggalKeluarPaspor.EditFormat.FormatString = "dd-MM-yyyy"
        Me.TanggalKeluarPaspor.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TanggalKeluarPaspor.Mask.EditMask = "dd-MM-yyyy"
        Me.TanggalKeluarPaspor.Name = "TanggalKeluarPaspor"
        '
        'ExpiredDate
        '
        Me.ExpiredDate.Caption = "Expired Date"
        Me.ExpiredDate.ColumnEdit = Me.CExpiredDatePaspor
        Me.ExpiredDate.FieldName = "ExpiredDate"
        Me.ExpiredDate.MinWidth = 25
        Me.ExpiredDate.Name = "ExpiredDate"
        Me.ExpiredDate.OptionsColumn.FixedWidth = True
        Me.ExpiredDate.Visible = True
        Me.ExpiredDate.VisibleIndex = 6
        Me.ExpiredDate.Width = 150
        '
        'CExpiredDatePaspor
        '
        Me.CExpiredDatePaspor.AutoHeight = False
        Me.CExpiredDatePaspor.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CExpiredDatePaspor.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CExpiredDatePaspor.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.CExpiredDatePaspor.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.CExpiredDatePaspor.EditFormat.FormatString = "dd-MM-yyyy"
        Me.CExpiredDatePaspor.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.CExpiredDatePaspor.Mask.EditMask = "dd-MM-yyyy"
        Me.CExpiredDatePaspor.Name = "CExpiredDatePaspor"
        '
        'TempatKeluar
        '
        Me.TempatKeluar.Caption = "Tempat Keluar"
        Me.TempatKeluar.ColumnEdit = Me.CTempatKeluar
        Me.TempatKeluar.FieldName = "TempatKeluar"
        Me.TempatKeluar.MinWidth = 25
        Me.TempatKeluar.Name = "TempatKeluar"
        Me.TempatKeluar.Visible = True
        Me.TempatKeluar.VisibleIndex = 7
        Me.TempatKeluar.Width = 94
        '
        'CTempatKeluar
        '
        Me.CTempatKeluar.AutoHeight = False
        Me.CTempatKeluar.Name = "CTempatKeluar"
        '
        'txtGolongan
        '
        Me.txtGolongan.Location = New System.Drawing.Point(794, 12)
        Me.txtGolongan.Name = "txtGolongan"
        Me.txtGolongan.Properties.Mask.EditMask = "f0"
        Me.txtGolongan.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.txtGolongan.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.txtGolongan.Size = New System.Drawing.Size(62, 22)
        Me.txtGolongan.StyleController = Me.LayoutControl1
        Me.txtGolongan.TabIndex = 6
        '
        'GridVisa
        '
        Me.GridVisa.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridVisa.Location = New System.Drawing.Point(12, 325)
        Me.GridVisa.MainView = Me.GridViewVisa
        Me.GridVisa.Name = "GridVisa"
        Me.GridVisa.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CDateExpired, Me.CDateIssued, Me.CEntries, Me.CNoVisa, Me.CNegara})
        Me.GridVisa.Size = New System.Drawing.Size(1044, 277)
        Me.GridVisa.TabIndex = 4
        Me.GridVisa.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewVisa})
        '
        'GridViewVisa
        '
        Me.GridViewVisa.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.NoVisa, Me.VisaNegara, Me.Entries, Me.DateIssued, Me.DateExpired})
        Me.GridViewVisa.GridControl = Me.GridVisa
        Me.GridViewVisa.Name = "GridViewVisa"
        Me.GridViewVisa.OptionsView.ShowGroupPanel = False
        '
        'NoVisa
        '
        Me.NoVisa.Caption = "No Visa"
        Me.NoVisa.ColumnEdit = Me.CNoVisa
        Me.NoVisa.FieldName = "NoVisa"
        Me.NoVisa.MinWidth = 25
        Me.NoVisa.Name = "NoVisa"
        Me.NoVisa.Visible = True
        Me.NoVisa.VisibleIndex = 0
        Me.NoVisa.Width = 232
        '
        'CNoVisa
        '
        Me.CNoVisa.AutoHeight = False
        Me.CNoVisa.Name = "CNoVisa"
        '
        'VisaNegara
        '
        Me.VisaNegara.Caption = "Negara"
        Me.VisaNegara.ColumnEdit = Me.CNegara
        Me.VisaNegara.FieldName = "Negara"
        Me.VisaNegara.MinWidth = 25
        Me.VisaNegara.Name = "VisaNegara"
        Me.VisaNegara.Visible = True
        Me.VisaNegara.VisibleIndex = 1
        Me.VisaNegara.Width = 94
        '
        'CNegara
        '
        Me.CNegara.AutoHeight = False
        Me.CNegara.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CNegara.Name = "CNegara"
        Me.CNegara.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'Entries
        '
        Me.Entries.Caption = "Entries"
        Me.Entries.ColumnEdit = Me.CEntries
        Me.Entries.FieldName = "Entries"
        Me.Entries.MinWidth = 25
        Me.Entries.Name = "Entries"
        Me.Entries.OptionsColumn.FixedWidth = True
        Me.Entries.Visible = True
        Me.Entries.VisibleIndex = 2
        Me.Entries.Width = 120
        '
        'CEntries
        '
        Me.CEntries.AutoHeight = False
        Me.CEntries.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CEntries.Items.AddRange(New Object() {"S", "M"})
        Me.CEntries.Name = "CEntries"
        Me.CEntries.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        '
        'DateIssued
        '
        Me.DateIssued.Caption = "Date Issued"
        Me.DateIssued.ColumnEdit = Me.CDateIssued
        Me.DateIssued.FieldName = "DateIssued"
        Me.DateIssued.MinWidth = 25
        Me.DateIssued.Name = "DateIssued"
        Me.DateIssued.Visible = True
        Me.DateIssued.VisibleIndex = 3
        Me.DateIssued.Width = 219
        '
        'CDateIssued
        '
        Me.CDateIssued.AutoHeight = False
        Me.CDateIssued.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CDateIssued.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CDateIssued.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.CDateIssued.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.CDateIssued.EditFormat.FormatString = "dd-MM-yyyy"
        Me.CDateIssued.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.CDateIssued.Mask.EditMask = "dd-MM-yyyy"
        Me.CDateIssued.Name = "CDateIssued"
        '
        'DateExpired
        '
        Me.DateExpired.Caption = "Date Expired"
        Me.DateExpired.ColumnEdit = Me.CDateExpired
        Me.DateExpired.FieldName = "DateExpired"
        Me.DateExpired.MinWidth = 25
        Me.DateExpired.Name = "DateExpired"
        Me.DateExpired.Visible = True
        Me.DateExpired.VisibleIndex = 4
        Me.DateExpired.Width = 221
        '
        'CDateExpired
        '
        Me.CDateExpired.AutoHeight = False
        Me.CDateExpired.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CDateExpired.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CDateExpired.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.CDateExpired.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.CDateExpired.EditFormat.FormatString = "dd-MM-yyyy"
        Me.CDateExpired.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.CDateExpired.Mask.EditMask = "dd-MM-yyyy"
        Me.CDateExpired.Name = "CDateExpired"
        '
        'btnAddVisa
        '
        Me.btnAddVisa.Location = New System.Drawing.Point(965, 12)
        Me.btnAddVisa.Name = "btnAddVisa"
        Me.btnAddVisa.Size = New System.Drawing.Size(91, 25)
        Me.btnAddVisa.TabIndex = 2
        Me.btnAddVisa.Text = "Add Visa"
        Me.btnAddVisa.UseVisualStyleBackColor = True
        '
        'TxtDeptID
        '
        Me.TxtDeptID.Location = New System.Drawing.Point(640, 12)
        Me.TxtDeptID.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtDeptID.Name = "TxtDeptID"
        Me.TxtDeptID.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TxtDeptID.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.TxtDeptID.Size = New System.Drawing.Size(62, 22)
        Me.TxtDeptID.StyleController = Me.LayoutControl1
        Me.TxtDeptID.TabIndex = 5
        '
        'TxtNama
        '
        Me.TxtNama.Location = New System.Drawing.Point(254, 12)
        Me.TxtNama.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNama.Name = "TxtNama"
        Me.TxtNama.Size = New System.Drawing.Size(294, 22)
        Me.TxtNama.StyleController = Me.LayoutControl1
        Me.TxtNama.TabIndex = 3
        '
        'TxtNIK
        '
        Me.TxtNIK.Location = New System.Drawing.Point(100, 12)
        Me.TxtNIK.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtNIK.Name = "TxtNIK"
        Me.TxtNIK.Properties.MaxLength = 9
        Me.TxtNIK.Size = New System.Drawing.Size(62, 22)
        Me.TxtNIK.StyleController = Me.LayoutControl1
        Me.TxtNIK.TabIndex = 0
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.EmptySpaceItem1, Me.LayoutControlItem7, Me.EmptySpaceItem2, Me.LayoutControlItem8})
        Me.LayoutControlGroup1.Name = "Root"
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1068, 614)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.TxtNIK
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(154, 29)
        Me.LayoutControlItem1.Text = "NIK"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(85, 16)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.TxtNama
        Me.LayoutControlItem2.Location = New System.Drawing.Point(154, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(386, 29)
        Me.LayoutControlItem2.Text = "Traveler Name"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(85, 16)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.TxtDeptID
        Me.LayoutControlItem3.Location = New System.Drawing.Point(540, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(154, 29)
        Me.LayoutControlItem3.Text = "Dept ID"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(85, 16)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.btnAddVisa
        Me.LayoutControlItem4.Location = New System.Drawing.Point(953, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(95, 29)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.GridVisa
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 313)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(1048, 281)
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem5.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.txtGolongan
        Me.LayoutControlItem6.Location = New System.Drawing.Point(694, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(154, 29)
        Me.LayoutControlItem6.Text = "Golongan"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(85, 16)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 300)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(1048, 13)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.GridPaspor
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 50)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(1048, 250)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'EmptySpaceItem2
        '
        Me.EmptySpaceItem2.AllowHotTrack = False
        Me.EmptySpaceItem2.Location = New System.Drawing.Point(0, 29)
        Me.EmptySpaceItem2.Name = "EmptySpaceItem2"
        Me.EmptySpaceItem2.Size = New System.Drawing.Size(1048, 21)
        Me.EmptySpaceItem2.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.btnAddPaspor
        Me.LayoutControlItem8.Location = New System.Drawing.Point(848, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(105, 29)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'DxValidationProvider1
        '
        Me.DxValidationProvider1.ValidationMode = DevExpress.XtraEditors.DXErrorProvider.ValidationMode.[Auto]
        '
        'FrmTravelerDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.ClientSize = New System.Drawing.Size(1068, 637)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmTravelerDetail"
        Me.Controls.SetChildIndex(Me.LayoutControl1, 0)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridPaspor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewPaspor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CKodeNegara, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CTanggalLahirPaspor.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CTanggalLahirPaspor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CJenisKelamin, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TanggalKeluarPaspor.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TanggalKeluarPaspor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CExpiredDatePaspor.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CExpiredDatePaspor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CTempatKeluar, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtGolongan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridVisa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewVisa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CNoVisa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CNegara, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CEntries, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CDateIssued.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CDateIssued, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CDateExpired.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CDateExpired, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtDeptID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNama.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtNIK.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BehaviorManager1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents TxtNIK As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents TxtNama As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DxValidationProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents TxtDeptID As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents btnAddVisa As Button
    Friend WithEvents GridVisa As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewVisa As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents NoVisa As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Entries As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DateIssued As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DateExpired As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CDateExpired As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CEntries As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents CDateIssued As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents txtGolongan As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents CNoVisa As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents GridPaspor As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewPaspor As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents NoPaspor As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Nama As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents KodeNegara As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TanggalLahir As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents JenisKelamin As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TanggalKeluar As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ExpiredDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TempatKeluar As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem2 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents VisaNegara As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents btnAddPaspor As Button
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CJenisKelamin As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents CKodeNegara As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents CNegara As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents BehaviorManager1 As DevExpress.Utils.Behaviors.BehaviorManager
    Friend WithEvents CTanggalLahirPaspor As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents TanggalKeluarPaspor As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents CExpiredDatePaspor As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents CTempatKeluar As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
End Class
