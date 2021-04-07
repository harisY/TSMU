<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmDetailPR
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
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.TJumlahProses = New DevExpress.XtraEditors.TextEdit()
        Me.T_SirkulasiJumlah = New DevExpress.XtraEditors.TextEdit()
        Me.BTambahBaris = New System.Windows.Forms.Button()
        Me.TRevisi = New DevExpress.XtraEditors.TextEdit()
        Me.TKeterangan = New DevExpress.XtraEditors.TextEdit()
        Me.TBagian = New DevExpress.XtraEditors.TextEdit()
        Me.TNoPR = New DevExpress.XtraEditors.TextEdit()
        Me.TTanggal = New DevExpress.XtraEditors.TextEdit()
        Me.TSirkulasi = New DevExpress.XtraEditors.ButtonEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.C_Submit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Tanggal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Dept = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.C_Qty = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.C_Price = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.C_Amount = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.C_Amount_Barang = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.CurrRepository = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.BAccount = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.C_Check = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.TotalIdr = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.Check_OK = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.Check_Rev = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.Check_Del = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.C_SalesType = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.NameOfGoods = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Spesification = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Model = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SalesType = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Price = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PTotal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Curr = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Rate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Account = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Remaining = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PTotalRP = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridPR = New DevExpress.XtraGrid.GridControl()
        Me.GridView3 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.XSeq = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.No = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BNo = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.PembelianUntuk = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CPembelianUntuk = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.KodeBarang = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BBarang = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        Me.NamaBarang = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Spesifikasi = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Accountt = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.SubAccount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Jumlah = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CJumlah = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.Harga = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Charga = New DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit()
        Me.Total = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Satuan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Digunakan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.WaktuTempo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DTempo = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.GBudget = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GSudahDipakai = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Keterangan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BSubAccount = New DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.TJumlahProses.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.T_SirkulasiJumlah.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TRevisi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TKeterangan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TBagian.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TNoPR.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TTanggal.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TSirkulasi.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_Submit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_Qty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_Price, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_Amount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_Amount_Barang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrRepository, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_Check, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotalIdr, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Check_OK, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Check_Rev, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Check_Del, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_SalesType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridPR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CPembelianUntuk, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BBarang, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CJumlah, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Charga, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTempo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DTempo.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BSubAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.TJumlahProses)
        Me.LayoutControl1.Controls.Add(Me.T_SirkulasiJumlah)
        Me.LayoutControl1.Controls.Add(Me.BTambahBaris)
        Me.LayoutControl1.Controls.Add(Me.TRevisi)
        Me.LayoutControl1.Controls.Add(Me.TKeterangan)
        Me.LayoutControl1.Controls.Add(Me.TBagian)
        Me.LayoutControl1.Controls.Add(Me.TNoPR)
        Me.LayoutControl1.Controls.Add(Me.TTanggal)
        Me.LayoutControl1.Controls.Add(Me.TSirkulasi)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 27)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(0, 419, 650, 299)
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(1156, 79)
        Me.LayoutControl1.TabIndex = 1
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'TJumlahProses
        '
        Me.TJumlahProses.Enabled = False
        Me.TJumlahProses.Location = New System.Drawing.Point(990, 12)
        Me.TJumlahProses.Name = "TJumlahProses"
        Me.TJumlahProses.Properties.DisplayFormat.FormatString = "n0"
        Me.TJumlahProses.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TJumlahProses.Properties.EditFormat.FormatString = "n0"
        Me.TJumlahProses.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.TJumlahProses.Size = New System.Drawing.Size(154, 20)
        Me.TJumlahProses.StyleController = Me.LayoutControl1
        Me.TJumlahProses.TabIndex = 12
        '
        'T_SirkulasiJumlah
        '
        Me.T_SirkulasiJumlah.EditValue = "0"
        Me.T_SirkulasiJumlah.Enabled = False
        Me.T_SirkulasiJumlah.Location = New System.Drawing.Point(751, 12)
        Me.T_SirkulasiJumlah.Name = "T_SirkulasiJumlah"
        Me.T_SirkulasiJumlah.Properties.DisplayFormat.FormatString = "n"
        Me.T_SirkulasiJumlah.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.T_SirkulasiJumlah.Properties.EditFormat.FormatString = "n0"
        Me.T_SirkulasiJumlah.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.T_SirkulasiJumlah.Properties.Mask.EditMask = "n"
        Me.T_SirkulasiJumlah.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric
        Me.T_SirkulasiJumlah.Size = New System.Drawing.Size(158, 20)
        Me.T_SirkulasiJumlah.StyleController = Me.LayoutControl1
        Me.T_SirkulasiJumlah.TabIndex = 11
        '
        'BTambahBaris
        '
        Me.BTambahBaris.Location = New System.Drawing.Point(1054, 36)
        Me.BTambahBaris.MaximumSize = New System.Drawing.Size(90, 20)
        Me.BTambahBaris.MinimumSize = New System.Drawing.Size(90, 20)
        Me.BTambahBaris.Name = "BTambahBaris"
        Me.BTambahBaris.Size = New System.Drawing.Size(90, 20)
        Me.BTambahBaris.TabIndex = 9
        Me.BTambahBaris.Text = "Tambah Baris"
        Me.BTambahBaris.UseVisualStyleBackColor = True
        '
        'TRevisi
        '
        Me.TRevisi.Location = New System.Drawing.Point(339, 12)
        Me.TRevisi.Name = "TRevisi"
        Me.TRevisi.Size = New System.Drawing.Size(45, 20)
        Me.TRevisi.StyleController = Me.LayoutControl1
        Me.TRevisi.TabIndex = 8
        Me.TRevisi.Visible = False
        '
        'TKeterangan
        '
        Me.TKeterangan.Location = New System.Drawing.Point(567, 36)
        Me.TKeterangan.Name = "TKeterangan"
        Me.TKeterangan.Size = New System.Drawing.Size(483, 20)
        Me.TKeterangan.StyleController = Me.LayoutControl1
        Me.TKeterangan.TabIndex = 7
        '
        'TBagian
        '
        Me.TBagian.Enabled = False
        Me.TBagian.Location = New System.Drawing.Point(89, 36)
        Me.TBagian.Name = "TBagian"
        Me.TBagian.Size = New System.Drawing.Size(169, 20)
        Me.TBagian.StyleController = Me.LayoutControl1
        Me.TBagian.TabIndex = 5
        '
        'TNoPR
        '
        Me.TNoPR.Enabled = False
        Me.TNoPR.Location = New System.Drawing.Point(89, 12)
        Me.TNoPR.Name = "TNoPR"
        Me.TNoPR.Size = New System.Drawing.Size(169, 20)
        Me.TNoPR.StyleController = Me.LayoutControl1
        Me.TNoPR.TabIndex = 4
        '
        'TTanggal
        '
        Me.TTanggal.Enabled = False
        Me.TTanggal.Location = New System.Drawing.Point(339, 36)
        Me.TTanggal.Name = "TTanggal"
        Me.TTanggal.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.TTanggal.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TTanggal.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.TTanggal.Size = New System.Drawing.Size(147, 20)
        Me.TTanggal.StyleController = Me.LayoutControl1
        Me.TTanggal.TabIndex = 6
        '
        'TSirkulasi
        '
        Me.TSirkulasi.Location = New System.Drawing.Point(465, 12)
        Me.TSirkulasi.Name = "TSirkulasi"
        Me.TSirkulasi.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.TSirkulasi.Size = New System.Drawing.Size(205, 20)
        Me.TSirkulasi.StyleController = Me.LayoutControl1
        Me.TSirkulasi.TabIndex = 10
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.EmptySpaceItem1, Me.LayoutControlItem2, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.LayoutControlItem3, Me.LayoutControlItem9, Me.LayoutControlItem4, Me.LayoutControlItem6, Me.LayoutControlItem5})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(1156, 79)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.TNoPR
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.MaxSize = New System.Drawing.Size(250, 24)
        Me.LayoutControlItem1.MinSize = New System.Drawing.Size(250, 24)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(250, 24)
        Me.LayoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem1.Text = "No PR"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(74, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(0, 49)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(1136, 10)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.TBagian
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem2.MaxSize = New System.Drawing.Size(250, 24)
        Me.LayoutControlItem2.MinSize = New System.Drawing.Size(250, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(250, 25)
        Me.LayoutControlItem2.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem2.Text = "Bagian"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(74, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.TSirkulasi
        Me.LayoutControlItem7.Location = New System.Drawing.Point(376, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(286, 24)
        Me.LayoutControlItem7.Text = "No Sirkulasi"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(74, 13)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.T_SirkulasiJumlah
        Me.LayoutControlItem8.Location = New System.Drawing.Point(662, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(239, 24)
        Me.LayoutControlItem8.Text = "Jumlah Sirkulasi"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(74, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.TTanggal
        Me.LayoutControlItem3.Location = New System.Drawing.Point(250, 24)
        Me.LayoutControlItem3.MinSize = New System.Drawing.Size(50, 25)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(228, 25)
        Me.LayoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem3.Text = "Tanggal"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(74, 13)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.TJumlahProses
        Me.LayoutControlItem9.Location = New System.Drawing.Point(901, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(235, 24)
        Me.LayoutControlItem9.Text = "Jumlah Proses"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(74, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.TKeterangan
        Me.LayoutControlItem4.Location = New System.Drawing.Point(478, 24)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(564, 25)
        Me.LayoutControlItem4.Text = "Keterangan"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(74, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.BTambahBaris
        Me.LayoutControlItem6.Location = New System.Drawing.Point(1042, 24)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(94, 25)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.TRevisi
        Me.LayoutControlItem5.Enabled = False
        Me.LayoutControlItem5.Location = New System.Drawing.Point(250, 0)
        Me.LayoutControlItem5.MaxSize = New System.Drawing.Size(150, 24)
        Me.LayoutControlItem5.MinSize = New System.Drawing.Size(100, 24)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(126, 24)
        Me.LayoutControlItem5.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom
        Me.LayoutControlItem5.Text = "Revisi"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(74, 13)
        '
        'C_Submit
        '
        Me.C_Submit.AutoHeight = False
        Me.C_Submit.Name = "C_Submit"
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Tanggal, Me.Dept})
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'Tanggal
        '
        Me.Tanggal.AppearanceCell.Options.UseTextOptions = True
        Me.Tanggal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Tanggal.AppearanceHeader.Options.UseTextOptions = True
        Me.Tanggal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Tanggal.FieldName = "Tanggal"
        Me.Tanggal.Name = "Tanggal"
        Me.Tanggal.OptionsColumn.AllowEdit = False
        Me.Tanggal.Visible = True
        Me.Tanggal.VisibleIndex = 1
        Me.Tanggal.Width = 109
        '
        'Dept
        '
        Me.Dept.AppearanceCell.Options.UseTextOptions = True
        Me.Dept.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Dept.AppearanceHeader.Options.UseTextOptions = True
        Me.Dept.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Dept.FieldName = "Dept"
        Me.Dept.Name = "Dept"
        Me.Dept.OptionsColumn.AllowEdit = False
        Me.Dept.Visible = True
        Me.Dept.VisibleIndex = 2
        Me.Dept.Width = 91
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
        'C_Price
        '
        Me.C_Price.Appearance.Options.UseTextOptions = True
        Me.C_Price.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.C_Price.AutoHeight = False
        Me.C_Price.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.C_Price.Name = "C_Price"
        '
        'C_Amount
        '
        Me.C_Amount.Appearance.Options.UseTextOptions = True
        Me.C_Amount.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.C_Amount.AutoHeight = False
        Me.C_Amount.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.C_Amount.Name = "C_Amount"
        '
        'C_Amount_Barang
        '
        Me.C_Amount_Barang.AutoHeight = False
        Me.C_Amount_Barang.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.C_Amount_Barang.Name = "C_Amount_Barang"
        '
        'CurrRepository
        '
        Me.CurrRepository.AutoHeight = False
        Me.CurrRepository.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CurrRepository.Name = "CurrRepository"
        '
        'BAccount
        '
        Me.BAccount.AutoHeight = False
        Me.BAccount.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.BAccount.Name = "BAccount"
        '
        'C_Check
        '
        Me.C_Check.AutoHeight = False
        Me.C_Check.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.C_Check.Items.AddRange(New Object() {"OK", "REVISE", "DELETE"})
        Me.C_Check.Name = "C_Check"
        '
        'TotalIdr
        '
        Me.TotalIdr.AutoHeight = False
        Me.TotalIdr.Name = "TotalIdr"
        '
        'Check_OK
        '
        Me.Check_OK.AutoHeight = False
        Me.Check_OK.Name = "Check_OK"
        '
        'Check_Rev
        '
        Me.Check_Rev.AutoHeight = False
        Me.Check_Rev.Name = "Check_Rev"
        '
        'Check_Del
        '
        Me.Check_Del.AutoHeight = False
        Me.Check_Del.Name = "Check_Del"
        '
        'C_SalesType
        '
        Me.C_SalesType.AutoHeight = False
        Me.C_SalesType.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.C_SalesType.Items.AddRange(New Object() {"SALES", "DEPRECIATION", "TSC EXPENSE", "CHARGE TO MOLD MAKER"})
        Me.C_SalesType.Name = "C_SalesType"
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.NameOfGoods, Me.Spesification, Me.Model, Me.SalesType, Me.GridColumn16, Me.Qty, Me.Price, Me.PTotal, Me.Curr, Me.Rate, Me.Account, Me.GridColumn14, Me.Remaining, Me.GridColumn1, Me.GridColumn2, Me.PTotalRP, Me.GridColumn5, Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13})
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsView.ColumnAutoWidth = False
        Me.GridView2.OptionsView.ShowFooter = True
        Me.GridView2.OptionsView.ShowGroupPanel = False
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
        Me.Qty.VisibleIndex = 7
        Me.Qty.Width = 37
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
        Me.Price.VisibleIndex = 9
        Me.Price.Width = 108
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
        Me.PTotal.VisibleIndex = 11
        Me.PTotal.Width = 120
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
        Me.Curr.VisibleIndex = 8
        Me.Curr.Width = 36
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
        Me.Rate.VisibleIndex = 10
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
        Me.PTotalRP.VisibleIndex = 12
        Me.PTotalRP.Width = 153
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
        Me.GridColumn5.VisibleIndex = 16
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
        Me.GridColumn11.VisibleIndex = 13
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
        Me.GridColumn12.VisibleIndex = 14
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
        Me.GridColumn13.VisibleIndex = 15
        '
        'GridPR
        '
        Me.GridPR.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPR.Location = New System.Drawing.Point(12, 108)
        Me.GridPR.MainView = Me.GridView3
        Me.GridPR.Name = "GridPR"
        Me.GridPR.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CPembelianUntuk, Me.BBarang, Me.CJumlah, Me.Charga, Me.DTempo, Me.BSubAccount, Me.BNo})
        Me.GridPR.Size = New System.Drawing.Size(1132, 332)
        Me.GridPR.TabIndex = 2
        Me.GridPR.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView3})
        '
        'GridView3
        '
        Me.GridView3.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.XSeq, Me.No, Me.PembelianUntuk, Me.KodeBarang, Me.NamaBarang, Me.Spesifikasi, Me.Accountt, Me.SubAccount, Me.Jumlah, Me.Harga, Me.Total, Me.Satuan, Me.Digunakan, Me.WaktuTempo, Me.GBudget, Me.GSudahDipakai, Me.Keterangan})
        Me.GridView3.GridControl = Me.GridPR
        Me.GridView3.IndicatorWidth = 30
        Me.GridView3.Name = "GridView3"
        Me.GridView3.OptionsView.ColumnAutoWidth = False
        Me.GridView3.OptionsView.ShowFooter = True
        Me.GridView3.OptionsView.ShowGroupPanel = False
        '
        'XSeq
        '
        Me.XSeq.AppearanceCell.Options.UseTextOptions = True
        Me.XSeq.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.XSeq.AppearanceHeader.Options.UseTextOptions = True
        Me.XSeq.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.XSeq.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.XSeq.FieldName = "XSeq"
        Me.XSeq.Name = "XSeq"
        Me.XSeq.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Max, "XSeq", "0")})
        Me.XSeq.UnboundType = DevExpress.Data.UnboundColumnType.[Integer]
        '
        'No
        '
        Me.No.AppearanceCell.Options.UseTextOptions = True
        Me.No.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.No.AppearanceHeader.Options.UseTextOptions = True
        Me.No.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.No.ColumnEdit = Me.BNo
        Me.No.FieldName = "No"
        Me.No.Name = "No"
        Me.No.Visible = True
        Me.No.VisibleIndex = 0
        Me.No.Width = 45
        '
        'BNo
        '
        Me.BNo.AutoHeight = False
        Me.BNo.Name = "BNo"
        '
        'PembelianUntuk
        '
        Me.PembelianUntuk.AppearanceHeader.Options.UseTextOptions = True
        Me.PembelianUntuk.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.PembelianUntuk.ColumnEdit = Me.CPembelianUntuk
        Me.PembelianUntuk.FieldName = "Pembelian Untuk"
        Me.PembelianUntuk.Name = "PembelianUntuk"
        Me.PembelianUntuk.Visible = True
        Me.PembelianUntuk.VisibleIndex = 1
        Me.PembelianUntuk.Width = 137
        '
        'CPembelianUntuk
        '
        Me.CPembelianUntuk.AutoHeight = False
        Me.CPembelianUntuk.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CPembelianUntuk.Name = "CPembelianUntuk"
        '
        'KodeBarang
        '
        Me.KodeBarang.AppearanceHeader.Options.UseTextOptions = True
        Me.KodeBarang.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.KodeBarang.ColumnEdit = Me.BBarang
        Me.KodeBarang.FieldName = "Kode Barang"
        Me.KodeBarang.Name = "KodeBarang"
        Me.KodeBarang.Visible = True
        Me.KodeBarang.VisibleIndex = 2
        Me.KodeBarang.Width = 126
        '
        'BBarang
        '
        Me.BBarang.AutoHeight = False
        Me.BBarang.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.BBarang.Name = "BBarang"
        '
        'NamaBarang
        '
        Me.NamaBarang.AppearanceHeader.Options.UseTextOptions = True
        Me.NamaBarang.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.NamaBarang.FieldName = "Nama Barang"
        Me.NamaBarang.Name = "NamaBarang"
        Me.NamaBarang.OptionsColumn.AllowEdit = False
        Me.NamaBarang.Visible = True
        Me.NamaBarang.VisibleIndex = 3
        Me.NamaBarang.Width = 186
        '
        'Spesifikasi
        '
        Me.Spesifikasi.AppearanceHeader.Options.UseTextOptions = True
        Me.Spesifikasi.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Spesifikasi.FieldName = "Spesifikasi"
        Me.Spesifikasi.Name = "Spesifikasi"
        Me.Spesifikasi.Visible = True
        Me.Spesifikasi.VisibleIndex = 4
        Me.Spesifikasi.Width = 196
        '
        'Accountt
        '
        Me.Accountt.AppearanceCell.Options.UseTextOptions = True
        Me.Accountt.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Accountt.AppearanceHeader.Options.UseTextOptions = True
        Me.Accountt.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Accountt.FieldName = "Account"
        Me.Accountt.Name = "Accountt"
        Me.Accountt.OptionsColumn.AllowEdit = False
        Me.Accountt.Visible = True
        Me.Accountt.VisibleIndex = 5
        Me.Accountt.Width = 73
        '
        'SubAccount
        '
        Me.SubAccount.AppearanceCell.Options.UseTextOptions = True
        Me.SubAccount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SubAccount.AppearanceHeader.Options.UseTextOptions = True
        Me.SubAccount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.SubAccount.FieldName = "Sub Account"
        Me.SubAccount.Name = "SubAccount"
        Me.SubAccount.OptionsColumn.AllowEdit = False
        Me.SubAccount.Visible = True
        Me.SubAccount.VisibleIndex = 7
        Me.SubAccount.Width = 80
        '
        'Jumlah
        '
        Me.Jumlah.AppearanceCell.Options.UseTextOptions = True
        Me.Jumlah.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Jumlah.AppearanceHeader.Options.UseTextOptions = True
        Me.Jumlah.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Jumlah.Caption = "Jumlah"
        Me.Jumlah.ColumnEdit = Me.CJumlah
        Me.Jumlah.FieldName = "Jumlah"
        Me.Jumlah.Name = "Jumlah"
        Me.Jumlah.UnboundType = DevExpress.Data.UnboundColumnType.[Decimal]
        Me.Jumlah.Visible = True
        Me.Jumlah.VisibleIndex = 8
        Me.Jumlah.Width = 71
        '
        'CJumlah
        '
        Me.CJumlah.AutoHeight = False
        Me.CJumlah.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CJumlah.Name = "CJumlah"
        '
        'Harga
        '
        Me.Harga.AppearanceHeader.Options.UseTextOptions = True
        Me.Harga.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Harga.ColumnEdit = Me.Charga
        Me.Harga.DisplayFormat.FormatString = "{0:N0}"
        Me.Harga.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Harga.FieldName = "Harga"
        Me.Harga.Name = "Harga"
        Me.Harga.Visible = True
        Me.Harga.VisibleIndex = 9
        Me.Harga.Width = 170
        '
        'Charga
        '
        Me.Charga.AutoHeight = False
        Me.Charga.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.Charga.Name = "Charga"
        '
        'Total
        '
        Me.Total.DisplayFormat.FormatString = "{0:N0}"
        Me.Total.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Total.FieldName = "Total"
        Me.Total.Name = "Total"
        Me.Total.OptionsColumn.AllowEdit = False
        Me.Total.Summary.AddRange(New DevExpress.XtraGrid.GridSummaryItem() {New DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Total", "SUM={0:N0}")})
        Me.Total.Visible = True
        Me.Total.VisibleIndex = 10
        '
        'Satuan
        '
        Me.Satuan.AppearanceCell.Options.UseTextOptions = True
        Me.Satuan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Satuan.AppearanceHeader.Options.UseTextOptions = True
        Me.Satuan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Satuan.FieldName = "Satuan"
        Me.Satuan.Name = "Satuan"
        Me.Satuan.OptionsColumn.AllowEdit = False
        Me.Satuan.Visible = True
        Me.Satuan.VisibleIndex = 11
        Me.Satuan.Width = 81
        '
        'Digunakan
        '
        Me.Digunakan.AppearanceHeader.Options.UseTextOptions = True
        Me.Digunakan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Digunakan.FieldName = "Digunakan Untuk"
        Me.Digunakan.Name = "Digunakan"
        Me.Digunakan.Visible = True
        Me.Digunakan.VisibleIndex = 12
        Me.Digunakan.Width = 158
        '
        'WaktuTempo
        '
        Me.WaktuTempo.AppearanceHeader.Options.UseTextOptions = True
        Me.WaktuTempo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.WaktuTempo.ColumnEdit = Me.DTempo
        Me.WaktuTempo.FieldName = "Waktu Tempo"
        Me.WaktuTempo.Name = "WaktuTempo"
        Me.WaktuTempo.Visible = True
        Me.WaktuTempo.VisibleIndex = 6
        Me.WaktuTempo.Width = 98
        '
        'DTempo
        '
        Me.DTempo.AutoHeight = False
        Me.DTempo.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DTempo.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DTempo.Name = "DTempo"
        '
        'GBudget
        '
        Me.GBudget.DisplayFormat.FormatString = "{0:N0}"
        Me.GBudget.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GBudget.FieldName = "Budget"
        Me.GBudget.Name = "GBudget"
        '
        'GSudahDipakai
        '
        Me.GSudahDipakai.DisplayFormat.FormatString = "{0:N0}"
        Me.GSudahDipakai.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.GSudahDipakai.FieldName = "Sudah Dipakai"
        Me.GSudahDipakai.Name = "GSudahDipakai"
        '
        'Keterangan
        '
        Me.Keterangan.FieldName = "Keterangan"
        Me.Keterangan.Name = "Keterangan"
        Me.Keterangan.OptionsColumn.AllowEdit = False
        Me.Keterangan.Visible = True
        Me.Keterangan.VisibleIndex = 13
        '
        'BSubAccount
        '
        Me.BSubAccount.AutoHeight = False
        Me.BSubAccount.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.BSubAccount.Name = "BSubAccount"
        '
        'FrmDetailPR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1156, 452)
        Me.Controls.Add(Me.GridPR)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Name = "FrmDetailPR"
        Me.Controls.SetChildIndex(Me.LayoutControl1, 0)
        Me.Controls.SetChildIndex(Me.GridPR, 0)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.TJumlahProses.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.T_SirkulasiJumlah.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TRevisi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TKeterangan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TBagian.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TNoPR.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TTanggal.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TSirkulasi.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_Submit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_Qty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_Price, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_Amount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_Amount_Barang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrRepository, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BAccount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_Check, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotalIdr, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Check_OK, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Check_Rev, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Check_Del, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_SalesType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridPR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CPembelianUntuk, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BBarang, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CJumlah, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Charga, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTempo.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DTempo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BSubAccount, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents TRevisi As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TKeterangan As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TBagian As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TNoPR As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents BTambahBaris As Button
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents C_Submit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Tanggal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Dept As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents C_Qty As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents C_Price As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents C_Amount As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents C_Amount_Barang As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents CurrRepository As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents BAccount As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents C_Check As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents TotalIdr As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents Check_OK As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents Check_Rev As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents Check_Del As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents C_SalesType As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents NameOfGoods As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Spesification As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Model As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SalesType As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Price As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PTotal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Curr As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Rate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Account As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Remaining As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PTotalRP As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridPR As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView3 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PembelianUntuk As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents KodeBarang As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NamaBarang As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Spesifikasi As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Accountt As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents SubAccount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Jumlah As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Harga As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Satuan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TTanggal As DevExpress.XtraEditors.TextEdit
    Friend WithEvents No As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CPembelianUntuk As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
    Friend WithEvents BBarang As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents CJumlah As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents Charga As DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit
    Friend WithEvents DTempo As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents Digunakan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents WaktuTempo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BSubAccount As DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit
    Friend WithEvents BNo As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TSirkulasi As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents XSeq As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Total As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GBudget As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GSudahDipakai As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Keterangan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents T_SirkulasiJumlah As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TJumlahProses As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
End Class
