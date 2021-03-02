<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmVendorManagementDetail
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
        Me.Grid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Shift = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Keterangan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Subcount = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.KodeBarang = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.NamaBarang = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Problem = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Analisis = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CorrectionAction = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PreventiveAction = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Pic = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Target = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Gambar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LotNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Path = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GambarHapus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.RepositoryItemDateEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.TxtLotNo = New DevExpress.XtraEditors.TextEdit()
        Me.TxtQty = New DevExpress.XtraEditors.TextEdit()
        Me.BGambar = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.TxtPreventive = New DevExpress.XtraEditors.TextEdit()
        Me.TxtCorrection = New DevExpress.XtraEditors.TextEdit()
        Me.TxtAnalisis = New DevExpress.XtraEditors.TextEdit()
        Me.TxtProblem = New DevExpress.XtraEditors.TextEdit()
        Me.TxtType = New DevExpress.XtraEditors.TextEdit()
        Me.TxtInvtName = New DevExpress.XtraEditors.TextEdit()
        Me.TxtInvtID = New DevExpress.XtraEditors.TextEdit()
        Me.TxtPic = New DevExpress.XtraEditors.TextEdit()
        Me.TxtSubcount = New DevExpress.XtraEditors.TextEdit()
        Me.TxtKeterangan = New DevExpress.XtraEditors.TextEdit()
        Me.DtTanggalLaporan = New DevExpress.XtraEditors.DateEdit()
        Me.DtTarget = New DevExpress.XtraEditors.DateEdit()
        Me.CmbShift = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.TxtStatus = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem13 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem14 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem16 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem15 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem17 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem18 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.BAdd = New System.Windows.Forms.Button()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.TxtLotNo.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtQty.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPreventive.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtCorrection.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtAnalisis.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtProblem.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtInvtName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtInvtID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtPic.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtSubcount.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtKeterangan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtTanggalLaporan.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtTanggalLaporan.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtTarget.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtTarget.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CmbShift.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TxtStatus.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.Location = New System.Drawing.Point(12, 275)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Name = "Grid"
        Me.Grid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1, Me.RepositoryItemDateEdit1, Me.RepositoryItemDateEdit2})
        Me.Grid.Size = New System.Drawing.Size(756, 190)
        Me.Grid.TabIndex = 27
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Shift, Me.Keterangan, Me.Subcount, Me.KodeBarang, Me.NamaBarang, Me.Type, Me.Qty, Me.Problem, Me.Analisis, Me.CorrectionAction, Me.PreventiveAction, Me.Pic, Me.Target, Me.Gambar, Me.LotNo, Me.Path, Me.GambarHapus, Me.Status})
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'Shift
        '
        Me.Shift.AppearanceCell.Options.UseTextOptions = True
        Me.Shift.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Shift.AppearanceHeader.Options.UseTextOptions = True
        Me.Shift.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Shift.FieldName = "Shift"
        Me.Shift.Name = "Shift"
        Me.Shift.Visible = True
        Me.Shift.VisibleIndex = 0
        Me.Shift.Width = 42
        '
        'Keterangan
        '
        Me.Keterangan.AppearanceCell.Options.UseTextOptions = True
        Me.Keterangan.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Keterangan.AppearanceHeader.Options.UseTextOptions = True
        Me.Keterangan.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Keterangan.FieldName = "Keterangan"
        Me.Keterangan.Name = "Keterangan"
        Me.Keterangan.Visible = True
        Me.Keterangan.VisibleIndex = 1
        Me.Keterangan.Width = 100
        '
        'Subcount
        '
        Me.Subcount.AppearanceCell.Options.UseTextOptions = True
        Me.Subcount.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Subcount.AppearanceHeader.Options.UseTextOptions = True
        Me.Subcount.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Subcount.FieldName = "Subcount"
        Me.Subcount.Name = "Subcount"
        Me.Subcount.Visible = True
        Me.Subcount.VisibleIndex = 2
        Me.Subcount.Width = 124
        '
        'KodeBarang
        '
        Me.KodeBarang.FieldName = "Kode Barang"
        Me.KodeBarang.Name = "KodeBarang"
        Me.KodeBarang.Visible = True
        Me.KodeBarang.VisibleIndex = 3
        Me.KodeBarang.Width = 164
        '
        'NamaBarang
        '
        Me.NamaBarang.FieldName = "Nama Barang"
        Me.NamaBarang.Name = "NamaBarang"
        Me.NamaBarang.Visible = True
        Me.NamaBarang.VisibleIndex = 4
        Me.NamaBarang.Width = 172
        '
        'Type
        '
        Me.Type.AppearanceCell.Options.UseTextOptions = True
        Me.Type.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Type.AppearanceHeader.Options.UseTextOptions = True
        Me.Type.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Type.FieldName = "Type"
        Me.Type.Name = "Type"
        Me.Type.Visible = True
        Me.Type.VisibleIndex = 5
        Me.Type.Width = 132
        '
        'Qty
        '
        Me.Qty.AppearanceCell.Options.UseTextOptions = True
        Me.Qty.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Qty.AppearanceHeader.Options.UseTextOptions = True
        Me.Qty.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Qty.FieldName = "Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.Visible = True
        Me.Qty.VisibleIndex = 6
        Me.Qty.Width = 95
        '
        'Problem
        '
        Me.Problem.FieldName = "Problem"
        Me.Problem.Name = "Problem"
        Me.Problem.Visible = True
        Me.Problem.VisibleIndex = 8
        Me.Problem.Width = 90
        '
        'Analisis
        '
        Me.Analisis.FieldName = "Analisis"
        Me.Analisis.Name = "Analisis"
        Me.Analisis.Visible = True
        Me.Analisis.VisibleIndex = 9
        '
        'CorrectionAction
        '
        Me.CorrectionAction.FieldName = "Correction Action"
        Me.CorrectionAction.Name = "CorrectionAction"
        Me.CorrectionAction.Visible = True
        Me.CorrectionAction.VisibleIndex = 10
        Me.CorrectionAction.Width = 254
        '
        'PreventiveAction
        '
        Me.PreventiveAction.FieldName = "Preventive Action"
        Me.PreventiveAction.Name = "PreventiveAction"
        Me.PreventiveAction.Visible = True
        Me.PreventiveAction.VisibleIndex = 11
        Me.PreventiveAction.Width = 202
        '
        'Pic
        '
        Me.Pic.AppearanceCell.Options.UseTextOptions = True
        Me.Pic.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Pic.AppearanceHeader.Options.UseTextOptions = True
        Me.Pic.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Pic.FieldName = "Pic"
        Me.Pic.Name = "Pic"
        Me.Pic.Visible = True
        Me.Pic.VisibleIndex = 12
        Me.Pic.Width = 117
        '
        'Target
        '
        Me.Target.AppearanceCell.Options.UseTextOptions = True
        Me.Target.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Target.AppearanceHeader.Options.UseTextOptions = True
        Me.Target.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Target.FieldName = "Target"
        Me.Target.Name = "Target"
        Me.Target.Visible = True
        Me.Target.VisibleIndex = 13
        Me.Target.Width = 107
        '
        'Gambar
        '
        Me.Gambar.AppearanceCell.Options.UseTextOptions = True
        Me.Gambar.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Gambar.AppearanceHeader.Options.UseTextOptions = True
        Me.Gambar.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Gambar.FieldName = "Gambar"
        Me.Gambar.Name = "Gambar"
        Me.Gambar.Visible = True
        Me.Gambar.VisibleIndex = 14
        Me.Gambar.Width = 185
        '
        'LotNo
        '
        Me.LotNo.AppearanceCell.Options.UseTextOptions = True
        Me.LotNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LotNo.AppearanceHeader.Options.UseTextOptions = True
        Me.LotNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.LotNo.FieldName = "Lot No"
        Me.LotNo.Name = "LotNo"
        Me.LotNo.Visible = True
        Me.LotNo.VisibleIndex = 7
        Me.LotNo.Width = 87
        '
        'Path
        '
        Me.Path.AppearanceCell.Options.UseTextOptions = True
        Me.Path.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Path.AppearanceHeader.Options.UseTextOptions = True
        Me.Path.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Path.FieldName = "Path"
        Me.Path.Name = "Path"
        Me.Path.Width = 276
        '
        'GambarHapus
        '
        Me.GambarHapus.FieldName = "Gambar Hapus"
        Me.GambarHapus.Name = "GambarHapus"
        '
        'Status
        '
        Me.Status.FieldName = "Status"
        Me.Status.Name = "Status"
        Me.Status.Visible = True
        Me.Status.VisibleIndex = 15
        '
        'RepositoryItemTextEdit1
        '
        Me.RepositoryItemTextEdit1.AutoHeight = False
        Me.RepositoryItemTextEdit1.Name = "RepositoryItemTextEdit1"
        '
        'RepositoryItemDateEdit1
        '
        Me.RepositoryItemDateEdit1.AutoHeight = False
        Me.RepositoryItemDateEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit1.Name = "RepositoryItemDateEdit1"
        '
        'RepositoryItemDateEdit2
        '
        Me.RepositoryItemDateEdit2.AutoHeight = False
        Me.RepositoryItemDateEdit2.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit2.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepositoryItemDateEdit2.Name = "RepositoryItemDateEdit2"
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.TxtLotNo)
        Me.LayoutControl1.Controls.Add(Me.TxtQty)
        Me.LayoutControl1.Controls.Add(Me.BGambar)
        Me.LayoutControl1.Controls.Add(Me.PictureBox1)
        Me.LayoutControl1.Controls.Add(Me.TxtPreventive)
        Me.LayoutControl1.Controls.Add(Me.TxtCorrection)
        Me.LayoutControl1.Controls.Add(Me.TxtAnalisis)
        Me.LayoutControl1.Controls.Add(Me.TxtProblem)
        Me.LayoutControl1.Controls.Add(Me.TxtType)
        Me.LayoutControl1.Controls.Add(Me.TxtInvtName)
        Me.LayoutControl1.Controls.Add(Me.TxtInvtID)
        Me.LayoutControl1.Controls.Add(Me.TxtPic)
        Me.LayoutControl1.Controls.Add(Me.TxtSubcount)
        Me.LayoutControl1.Controls.Add(Me.TxtKeterangan)
        Me.LayoutControl1.Controls.Add(Me.DtTanggalLaporan)
        Me.LayoutControl1.Controls.Add(Me.DtTarget)
        Me.LayoutControl1.Controls.Add(Me.CmbShift)
        Me.LayoutControl1.Controls.Add(Me.TxtStatus)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Top
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 27)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(127, 346, 273, 400)
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(780, 214)
        Me.LayoutControl1.TabIndex = 28
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'TxtLotNo
        '
        Me.TxtLotNo.Location = New System.Drawing.Point(324, 36)
        Me.TxtLotNo.Name = "TxtLotNo"
        Me.TxtLotNo.Size = New System.Drawing.Size(271, 20)
        Me.TxtLotNo.StyleController = Me.LayoutControl1
        Me.TxtLotNo.TabIndex = 12
        '
        'TxtQty
        '
        Me.TxtQty.Location = New System.Drawing.Point(100, 156)
        Me.TxtQty.Name = "TxtQty"
        Me.TxtQty.Size = New System.Drawing.Size(132, 20)
        Me.TxtQty.StyleController = Me.LayoutControl1
        Me.TxtQty.TabIndex = 21
        '
        'BGambar
        '
        Me.BGambar.Location = New System.Drawing.Point(609, 170)
        Me.BGambar.Name = "BGambar"
        Me.BGambar.Size = New System.Drawing.Size(159, 32)
        Me.BGambar.TabIndex = 20
        Me.BGambar.Text = "Cari Gambar"
        Me.BGambar.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(609, 12)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(159, 154)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 19
        Me.PictureBox1.TabStop = False
        '
        'TxtPreventive
        '
        Me.TxtPreventive.Location = New System.Drawing.Point(324, 156)
        Me.TxtPreventive.Name = "TxtPreventive"
        Me.TxtPreventive.Size = New System.Drawing.Size(271, 20)
        Me.TxtPreventive.StyleController = Me.LayoutControl1
        Me.TxtPreventive.TabIndex = 17
        '
        'TxtCorrection
        '
        Me.TxtCorrection.Location = New System.Drawing.Point(324, 132)
        Me.TxtCorrection.Name = "TxtCorrection"
        Me.TxtCorrection.Size = New System.Drawing.Size(271, 20)
        Me.TxtCorrection.StyleController = Me.LayoutControl1
        Me.TxtCorrection.TabIndex = 16
        '
        'TxtAnalisis
        '
        Me.TxtAnalisis.Location = New System.Drawing.Point(324, 108)
        Me.TxtAnalisis.Name = "TxtAnalisis"
        Me.TxtAnalisis.Size = New System.Drawing.Size(271, 20)
        Me.TxtAnalisis.StyleController = Me.LayoutControl1
        Me.TxtAnalisis.TabIndex = 15
        '
        'TxtProblem
        '
        Me.TxtProblem.Location = New System.Drawing.Point(324, 84)
        Me.TxtProblem.Name = "TxtProblem"
        Me.TxtProblem.Size = New System.Drawing.Size(271, 20)
        Me.TxtProblem.StyleController = Me.LayoutControl1
        Me.TxtProblem.TabIndex = 14
        '
        'TxtType
        '
        Me.TxtType.Location = New System.Drawing.Point(100, 180)
        Me.TxtType.Name = "TxtType"
        Me.TxtType.Size = New System.Drawing.Size(132, 20)
        Me.TxtType.StyleController = Me.LayoutControl1
        Me.TxtType.TabIndex = 10
        '
        'TxtInvtName
        '
        Me.TxtInvtName.Location = New System.Drawing.Point(100, 132)
        Me.TxtInvtName.Name = "TxtInvtName"
        Me.TxtInvtName.Size = New System.Drawing.Size(132, 20)
        Me.TxtInvtName.StyleController = Me.LayoutControl1
        Me.TxtInvtName.TabIndex = 9
        '
        'TxtInvtID
        '
        Me.TxtInvtID.Location = New System.Drawing.Point(100, 108)
        Me.TxtInvtID.Name = "TxtInvtID"
        Me.TxtInvtID.Size = New System.Drawing.Size(132, 20)
        Me.TxtInvtID.StyleController = Me.LayoutControl1
        Me.TxtInvtID.TabIndex = 8
        '
        'TxtPic
        '
        Me.TxtPic.Location = New System.Drawing.Point(100, 84)
        Me.TxtPic.Name = "TxtPic"
        Me.TxtPic.Size = New System.Drawing.Size(132, 20)
        Me.TxtPic.StyleController = Me.LayoutControl1
        Me.TxtPic.TabIndex = 7
        '
        'TxtSubcount
        '
        Me.TxtSubcount.Location = New System.Drawing.Point(100, 60)
        Me.TxtSubcount.Name = "TxtSubcount"
        Me.TxtSubcount.Size = New System.Drawing.Size(132, 20)
        Me.TxtSubcount.StyleController = Me.LayoutControl1
        Me.TxtSubcount.TabIndex = 6
        '
        'TxtKeterangan
        '
        Me.TxtKeterangan.Location = New System.Drawing.Point(100, 36)
        Me.TxtKeterangan.Name = "TxtKeterangan"
        Me.TxtKeterangan.Size = New System.Drawing.Size(132, 20)
        Me.TxtKeterangan.StyleController = Me.LayoutControl1
        Me.TxtKeterangan.TabIndex = 5
        '
        'DtTanggalLaporan
        '
        Me.DtTanggalLaporan.EditValue = Nothing
        Me.DtTanggalLaporan.Location = New System.Drawing.Point(100, 12)
        Me.DtTanggalLaporan.Name = "DtTanggalLaporan"
        Me.DtTanggalLaporan.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DtTanggalLaporan.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DtTanggalLaporan.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.DtTanggalLaporan.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DtTanggalLaporan.Properties.EditFormat.FormatString = "dd-MM-yyyy"
        Me.DtTanggalLaporan.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DtTanggalLaporan.Properties.Mask.EditMask = ""
        Me.DtTanggalLaporan.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.DtTanggalLaporan.Size = New System.Drawing.Size(132, 20)
        Me.DtTanggalLaporan.StyleController = Me.LayoutControl1
        Me.DtTanggalLaporan.TabIndex = 4
        '
        'DtTarget
        '
        Me.DtTarget.EditValue = Nothing
        Me.DtTarget.Location = New System.Drawing.Point(324, 60)
        Me.DtTarget.Name = "DtTarget"
        Me.DtTarget.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DtTarget.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.DtTarget.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.DtTarget.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DtTarget.Properties.EditFormat.FormatString = "dd-MM-yyyy"
        Me.DtTarget.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.DtTarget.Properties.Mask.EditMask = ""
        Me.DtTarget.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None
        Me.DtTarget.Size = New System.Drawing.Size(271, 20)
        Me.DtTarget.StyleController = Me.LayoutControl1
        Me.DtTarget.TabIndex = 13
        '
        'CmbShift
        '
        Me.CmbShift.Location = New System.Drawing.Point(324, 12)
        Me.CmbShift.Name = "CmbShift"
        Me.CmbShift.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CmbShift.Properties.DropDownRows = 5
        Me.CmbShift.Properties.Items.AddRange(New Object() {"-", "1", "2", "3"})
        Me.CmbShift.Size = New System.Drawing.Size(271, 20)
        Me.CmbShift.StyleController = Me.LayoutControl1
        Me.CmbShift.TabIndex = 11
        '
        'TxtStatus
        '
        Me.TxtStatus.Location = New System.Drawing.Point(324, 180)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.TxtStatus.Properties.Items.AddRange(New Object() {"Open", "Close"})
        Me.TxtStatus.Size = New System.Drawing.Size(271, 20)
        Me.TxtStatus.StyleController = Me.LayoutControl1
        Me.TxtStatus.TabIndex = 22
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem5, Me.LayoutControlItem6, Me.LayoutControlItem7, Me.LayoutControlItem8, Me.LayoutControlItem10, Me.LayoutControlItem11, Me.LayoutControlItem12, Me.LayoutControlItem13, Me.LayoutControlItem14, Me.EmptySpaceItem1, Me.LayoutControlItem16, Me.LayoutControlItem15, Me.LayoutControlItem17, Me.LayoutControlItem18, Me.LayoutControlItem9})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(780, 214)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.DtTanggalLaporan
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(224, 24)
        Me.LayoutControlItem1.Text = "Tanggal"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(85, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.TxtKeterangan
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 24)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(224, 24)
        Me.LayoutControlItem2.Text = "Keterangan"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(85, 13)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.TxtSubcount
        Me.LayoutControlItem3.Location = New System.Drawing.Point(0, 48)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Size = New System.Drawing.Size(224, 24)
        Me.LayoutControlItem3.Text = "Subcount"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(85, 13)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.TxtPic
        Me.LayoutControlItem4.Location = New System.Drawing.Point(0, 72)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Size = New System.Drawing.Size(224, 24)
        Me.LayoutControlItem4.Text = "PIC"
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(85, 13)
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.TxtInvtID
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 96)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Size = New System.Drawing.Size(224, 24)
        Me.LayoutControlItem5.Text = "Kode Barang"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(85, 13)
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.TxtInvtName
        Me.LayoutControlItem6.Location = New System.Drawing.Point(0, 120)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(224, 24)
        Me.LayoutControlItem6.Text = "Nama Barang"
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(85, 13)
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.TxtType
        Me.LayoutControlItem7.Location = New System.Drawing.Point(0, 168)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Size = New System.Drawing.Size(224, 26)
        Me.LayoutControlItem7.Text = "Tipe"
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(85, 13)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.CmbShift
        Me.LayoutControlItem8.Location = New System.Drawing.Point(224, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Size = New System.Drawing.Size(363, 24)
        Me.LayoutControlItem8.Text = "Shift"
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(85, 13)
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.DtTarget
        Me.LayoutControlItem10.Location = New System.Drawing.Point(224, 48)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Size = New System.Drawing.Size(363, 24)
        Me.LayoutControlItem10.Text = "Target"
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(85, 13)
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.TxtProblem
        Me.LayoutControlItem11.Location = New System.Drawing.Point(224, 72)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Size = New System.Drawing.Size(363, 24)
        Me.LayoutControlItem11.Text = "Problem"
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(85, 13)
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.TxtAnalisis
        Me.LayoutControlItem12.Location = New System.Drawing.Point(224, 96)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Size = New System.Drawing.Size(363, 24)
        Me.LayoutControlItem12.Text = "Analis"
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(85, 13)
        '
        'LayoutControlItem13
        '
        Me.LayoutControlItem13.Control = Me.TxtCorrection
        Me.LayoutControlItem13.Location = New System.Drawing.Point(224, 120)
        Me.LayoutControlItem13.Name = "LayoutControlItem13"
        Me.LayoutControlItem13.Size = New System.Drawing.Size(363, 24)
        Me.LayoutControlItem13.Text = "Corrective Action"
        Me.LayoutControlItem13.TextSize = New System.Drawing.Size(85, 13)
        '
        'LayoutControlItem14
        '
        Me.LayoutControlItem14.Control = Me.TxtPreventive
        Me.LayoutControlItem14.Location = New System.Drawing.Point(224, 144)
        Me.LayoutControlItem14.Name = "LayoutControlItem14"
        Me.LayoutControlItem14.Size = New System.Drawing.Size(363, 24)
        Me.LayoutControlItem14.Text = "Preventive Action"
        Me.LayoutControlItem14.TextSize = New System.Drawing.Size(85, 13)
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(587, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(10, 194)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem16
        '
        Me.LayoutControlItem16.Control = Me.PictureBox1
        Me.LayoutControlItem16.Location = New System.Drawing.Point(597, 0)
        Me.LayoutControlItem16.Name = "LayoutControlItem16"
        Me.LayoutControlItem16.Size = New System.Drawing.Size(163, 158)
        Me.LayoutControlItem16.Text = "Gambar"
        Me.LayoutControlItem16.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem16.TextVisible = False
        '
        'LayoutControlItem15
        '
        Me.LayoutControlItem15.Control = Me.BGambar
        Me.LayoutControlItem15.Location = New System.Drawing.Point(597, 158)
        Me.LayoutControlItem15.Name = "LayoutControlItem15"
        Me.LayoutControlItem15.Size = New System.Drawing.Size(163, 36)
        Me.LayoutControlItem15.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem15.TextVisible = False
        '
        'LayoutControlItem17
        '
        Me.LayoutControlItem17.Control = Me.TxtQty
        Me.LayoutControlItem17.Location = New System.Drawing.Point(0, 144)
        Me.LayoutControlItem17.Name = "LayoutControlItem17"
        Me.LayoutControlItem17.Size = New System.Drawing.Size(224, 24)
        Me.LayoutControlItem17.Text = "Qty"
        Me.LayoutControlItem17.TextSize = New System.Drawing.Size(85, 13)
        '
        'LayoutControlItem18
        '
        Me.LayoutControlItem18.Control = Me.TxtStatus
        Me.LayoutControlItem18.CustomizationFormText = "Status"
        Me.LayoutControlItem18.Location = New System.Drawing.Point(224, 168)
        Me.LayoutControlItem18.Name = "LayoutControlItem18"
        Me.LayoutControlItem18.Size = New System.Drawing.Size(363, 26)
        Me.LayoutControlItem18.Text = "Status"
        Me.LayoutControlItem18.TextSize = New System.Drawing.Size(85, 13)
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.TxtLotNo
        Me.LayoutControlItem9.Location = New System.Drawing.Point(224, 24)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(363, 24)
        Me.LayoutControlItem9.Text = "Lot"
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(85, 13)
        '
        'BAdd
        '
        Me.BAdd.Location = New System.Drawing.Point(13, 246)
        Me.BAdd.Name = "BAdd"
        Me.BAdd.Size = New System.Drawing.Size(75, 23)
        Me.BAdd.TabIndex = 29
        Me.BAdd.Text = "Add"
        Me.BAdd.UseVisualStyleBackColor = True
        '
        'FrmVendorManagementDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(780, 460)
        Me.Controls.Add(Me.BAdd)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Controls.Add(Me.Grid)
        Me.Name = "FrmVendorManagementDetail"
        Me.Controls.SetChildIndex(Me.Grid, 0)
        Me.Controls.SetChildIndex(Me.LayoutControl1, 0)
        Me.Controls.SetChildIndex(Me.BAdd, 0)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.TxtLotNo.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtQty.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPreventive.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtCorrection.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtAnalisis.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtProblem.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtInvtName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtInvtID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtPic.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtSubcount.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtKeterangan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtTanggalLaporan.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtTanggalLaporan.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtTarget.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtTarget.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CmbShift.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TxtStatus.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem13, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem14, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem15, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem17, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem18, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Shift As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Keterangan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Subcount As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents KodeBarang As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents NamaBarang As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Problem As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Analisis As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CorrectionAction As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PreventiveAction As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Pic As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Target As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Gambar As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LotNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Path As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GambarHapus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents RepositoryItemDateEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents TxtKeterangan As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DtTanggalLaporan As DevExpress.XtraEditors.DateEdit
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TxtSubcount As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TxtLotNo As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtType As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtInvtName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtInvtID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtPic As DevExpress.XtraEditors.TextEdit
    Friend WithEvents DtTarget As DevExpress.XtraEditors.DateEdit
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TxtPreventive As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtCorrection As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtAnalisis As DevExpress.XtraEditors.TextEdit
    Friend WithEvents TxtProblem As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem13 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem14 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents BGambar As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LayoutControlItem16 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem15 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TxtQty As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem17 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents CmbShift As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents BAdd As Button
    Friend WithEvents Status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents LayoutControlItem18 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents TxtStatus As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
End Class
