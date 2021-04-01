<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHRAdministrasiKaryawan
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
        Me.GridKaryawan = New DevExpress.XtraGrid.GridControl()
        Me.GridViewKaryawan = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.colEmpID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNIK = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNamaLengkap = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colNamaPanggilan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJenisKelamin = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTglLahir = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colPerpindahan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colStatusKaryawan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTipeKaryawan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colTipePosisiKaryawan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colFactory = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colOrganisasi = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.colJabatan = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.GridKaryawan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewKaryawan, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.GridKaryawan)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 27)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(1035, 657)
        Me.LayoutControl1.TabIndex = 1
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'GridKaryawan
        '
        Me.GridKaryawan.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.GridKaryawan.Location = New System.Drawing.Point(14, 14)
        Me.GridKaryawan.MainView = Me.GridViewKaryawan
        Me.GridKaryawan.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.GridKaryawan.Name = "GridKaryawan"
        Me.GridKaryawan.Size = New System.Drawing.Size(1007, 629)
        Me.GridKaryawan.TabIndex = 4
        Me.GridKaryawan.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewKaryawan})
        '
        'GridViewKaryawan
        '
        Me.GridViewKaryawan.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.colEmpID, Me.colNIK, Me.colNamaLengkap, Me.colNamaPanggilan, Me.colJenisKelamin, Me.colTglLahir, Me.colPerpindahan, Me.colStatusKaryawan, Me.colTipeKaryawan, Me.colTipePosisiKaryawan, Me.colFactory, Me.colOrganisasi, Me.colJabatan})
        Me.GridViewKaryawan.DetailHeight = 412
        Me.GridViewKaryawan.GridControl = Me.GridKaryawan
        Me.GridViewKaryawan.Name = "GridViewKaryawan"
        Me.GridViewKaryawan.OptionsBehavior.Editable = False
        Me.GridViewKaryawan.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full
        Me.GridViewKaryawan.OptionsView.ColumnAutoWidth = False
        Me.GridViewKaryawan.OptionsView.ShowAutoFilterRow = True
        Me.GridViewKaryawan.OptionsView.ShowGroupPanel = False
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.Root.Name = "Root"
        Me.Root.Size = New System.Drawing.Size(1035, 657)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridKaryawan
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1011, 633)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'colEmpID
        '
        Me.colEmpID.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.colEmpID.AppearanceHeader.Options.UseFont = True
        Me.colEmpID.Caption = "Employee ID"
        Me.colEmpID.FieldName = "EmployeeID"
        Me.colEmpID.MinWidth = 30
        Me.colEmpID.Name = "colEmpID"
        Me.colEmpID.Width = 141
        '
        'colNIK
        '
        Me.colNIK.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.colNIK.AppearanceHeader.Options.UseFont = True
        Me.colNIK.Caption = "NIK"
        Me.colNIK.FieldName = "NIK"
        Me.colNIK.MinWidth = 30
        Me.colNIK.Name = "colNIK"
        Me.colNIK.Visible = True
        Me.colNIK.VisibleIndex = 0
        Me.colNIK.Width = 141
        '
        'colNamaLengkap
        '
        Me.colNamaLengkap.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.colNamaLengkap.AppearanceHeader.Options.UseFont = True
        Me.colNamaLengkap.Caption = "Nama Lengkap"
        Me.colNamaLengkap.FieldName = "NamaLengkap"
        Me.colNamaLengkap.MinWidth = 30
        Me.colNamaLengkap.Name = "colNamaLengkap"
        Me.colNamaLengkap.Visible = True
        Me.colNamaLengkap.VisibleIndex = 1
        Me.colNamaLengkap.Width = 141
        '
        'colNamaPanggilan
        '
        Me.colNamaPanggilan.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.colNamaPanggilan.AppearanceHeader.Options.UseFont = True
        Me.colNamaPanggilan.Caption = "Nama Panggilan"
        Me.colNamaPanggilan.FieldName = "NamaPanggilan"
        Me.colNamaPanggilan.MinWidth = 30
        Me.colNamaPanggilan.Name = "colNamaPanggilan"
        Me.colNamaPanggilan.Visible = True
        Me.colNamaPanggilan.VisibleIndex = 2
        Me.colNamaPanggilan.Width = 141
        '
        'colJenisKelamin
        '
        Me.colJenisKelamin.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.colJenisKelamin.AppearanceHeader.Options.UseFont = True
        Me.colJenisKelamin.Caption = "JK"
        Me.colJenisKelamin.FieldName = "JenisKelamin"
        Me.colJenisKelamin.MinWidth = 30
        Me.colJenisKelamin.Name = "colJenisKelamin"
        Me.colJenisKelamin.Visible = True
        Me.colJenisKelamin.VisibleIndex = 3
        Me.colJenisKelamin.Width = 141
        '
        'colTglLahir
        '
        Me.colTglLahir.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.colTglLahir.AppearanceHeader.Options.UseFont = True
        Me.colTglLahir.Caption = "Tgl Lahir"
        Me.colTglLahir.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.colTglLahir.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.colTglLahir.FieldName = "TglLahir"
        Me.colTglLahir.MinWidth = 30
        Me.colTglLahir.Name = "colTglLahir"
        Me.colTglLahir.Visible = True
        Me.colTglLahir.VisibleIndex = 4
        Me.colTglLahir.Width = 141
        '
        'colPerpindahan
        '
        Me.colPerpindahan.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.colPerpindahan.AppearanceHeader.Options.UseFont = True
        Me.colPerpindahan.Caption = "Perpindahan"
        Me.colPerpindahan.FieldName = "Perpindahan"
        Me.colPerpindahan.MinWidth = 30
        Me.colPerpindahan.Name = "colPerpindahan"
        Me.colPerpindahan.Visible = True
        Me.colPerpindahan.VisibleIndex = 5
        Me.colPerpindahan.Width = 141
        '
        'colStatusKaryawan
        '
        Me.colStatusKaryawan.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.colStatusKaryawan.AppearanceHeader.Options.UseFont = True
        Me.colStatusKaryawan.Caption = "Status"
        Me.colStatusKaryawan.FieldName = "StatusKaryawan"
        Me.colStatusKaryawan.MinWidth = 30
        Me.colStatusKaryawan.Name = "colStatusKaryawan"
        Me.colStatusKaryawan.Visible = True
        Me.colStatusKaryawan.VisibleIndex = 6
        Me.colStatusKaryawan.Width = 141
        '
        'colTipeKaryawan
        '
        Me.colTipeKaryawan.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.colTipeKaryawan.AppearanceHeader.Options.UseFont = True
        Me.colTipeKaryawan.Caption = "Tipe Karyawan"
        Me.colTipeKaryawan.FieldName = "TipeKaryawan"
        Me.colTipeKaryawan.MinWidth = 30
        Me.colTipeKaryawan.Name = "colTipeKaryawan"
        Me.colTipeKaryawan.Visible = True
        Me.colTipeKaryawan.VisibleIndex = 7
        Me.colTipeKaryawan.Width = 141
        '
        'colTipePosisiKaryawan
        '
        Me.colTipePosisiKaryawan.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.colTipePosisiKaryawan.AppearanceHeader.Options.UseFont = True
        Me.colTipePosisiKaryawan.Caption = "Tipe Posisi"
        Me.colTipePosisiKaryawan.FieldName = "TipePosisiKaryawan"
        Me.colTipePosisiKaryawan.MinWidth = 30
        Me.colTipePosisiKaryawan.Name = "colTipePosisiKaryawan"
        Me.colTipePosisiKaryawan.Visible = True
        Me.colTipePosisiKaryawan.VisibleIndex = 8
        Me.colTipePosisiKaryawan.Width = 141
        '
        'colFactory
        '
        Me.colFactory.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.colFactory.AppearanceHeader.Options.UseFont = True
        Me.colFactory.Caption = "Factory"
        Me.colFactory.FieldName = "Factory"
        Me.colFactory.MinWidth = 30
        Me.colFactory.Name = "colFactory"
        Me.colFactory.Visible = True
        Me.colFactory.VisibleIndex = 9
        Me.colFactory.Width = 141
        '
        'colOrganisasi
        '
        Me.colOrganisasi.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.colOrganisasi.AppearanceHeader.Options.UseFont = True
        Me.colOrganisasi.Caption = "Organisasi"
        Me.colOrganisasi.FieldName = "Organisasi"
        Me.colOrganisasi.MinWidth = 30
        Me.colOrganisasi.Name = "colOrganisasi"
        Me.colOrganisasi.Visible = True
        Me.colOrganisasi.VisibleIndex = 10
        Me.colOrganisasi.Width = 141
        '
        'colJabatan
        '
        Me.colJabatan.AppearanceHeader.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Bold)
        Me.colJabatan.AppearanceHeader.Options.UseFont = True
        Me.colJabatan.Caption = "Jabatan"
        Me.colJabatan.FieldName = "Jabatan"
        Me.colJabatan.MinWidth = 30
        Me.colJabatan.Name = "colJabatan"
        Me.colJabatan.Visible = True
        Me.colJabatan.VisibleIndex = 11
        Me.colJabatan.Width = 141
        '
        'FrmHRAdministrasiKaryawan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.ClientSize = New System.Drawing.Size(1035, 684)
        Me.Controls.Add(Me.LayoutControl1)
        Me.Margin = New System.Windows.Forms.Padding(2, 4, 2, 4)
        Me.Name = "FrmHRAdministrasiKaryawan"
        Me.Controls.SetChildIndex(Me.LayoutControl1, 0)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.GridKaryawan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewKaryawan, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents GridKaryawan As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewKaryawan As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents colEmpID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNIK As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNamaLengkap As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colNamaPanggilan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJenisKelamin As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTglLahir As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colPerpindahan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colStatusKaryawan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTipeKaryawan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colTipePosisiKaryawan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colFactory As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colOrganisasi As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents colJabatan As DevExpress.XtraGrid.Columns.GridColumn
End Class
