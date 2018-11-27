<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_FP
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_FP))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me._ket_pph = New System.Windows.Forms.ComboBox()
        Me._lokasi = New System.Windows.Forms.ComboBox()
        Me._tarif = New System.Windows.Forms.ComboBox()
        Me._pph = New System.Windows.Forms.ComboBox()
        Me._bulan = New System.Windows.Forms.TextBox()
        Me._tahun = New System.Windows.Forms.TextBox()
        Me._Ket_Dpp = New System.Windows.Forms.RichTextBox()
        Me._nilai_Pph = New System.Windows.Forms.TextBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me._nama_vendor = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me._No_Bukti_Potong = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me._Vend_Name = New System.Windows.Forms.ComboBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me._curyid = New System.Windows.Forms.ComboBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me._jenis_jasa = New System.Windows.Forms.TextBox()
        Me._Tot_Voucher = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me._Tot_Ppn = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me._Tot_Pph = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me._Tot_Dpp_Invoice = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me._Tgl_fp = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me._npwp = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me._VendID = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me._VoucNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me._ket_pph)
        Me.Panel1.Controls.Add(Me._lokasi)
        Me.Panel1.Controls.Add(Me._tarif)
        Me.Panel1.Controls.Add(Me._pph)
        Me.Panel1.Controls.Add(Me._bulan)
        Me.Panel1.Controls.Add(Me._tahun)
        Me.Panel1.Controls.Add(Me._Ket_Dpp)
        Me.Panel1.Controls.Add(Me._nilai_Pph)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me._nama_vendor)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me._No_Bukti_Potong)
        Me.Panel1.Controls.Add(Me.Label28)
        Me.Panel1.Controls.Add(Me.Label30)
        Me.Panel1.Controls.Add(Me._Vend_Name)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Controls.Add(Me._curyid)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me._jenis_jasa)
        Me.Panel1.Controls.Add(Me._Tot_Voucher)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me._Tot_Ppn)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me._Tot_Pph)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me._Tot_Dpp_Invoice)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me._Tgl_fp)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me._npwp)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me._VendID)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me._VoucNo)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(23, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1082, 202)
        Me.Panel1.TabIndex = 10
        '
        '_ket_pph
        '
        Me._ket_pph.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._ket_pph.FormattingEnabled = True
        Me._ket_pph.Location = New System.Drawing.Point(468, 113)
        Me._ket_pph.Name = "_ket_pph"
        Me._ket_pph.Size = New System.Drawing.Size(23, 21)
        Me._ket_pph.TabIndex = 170
        Me._ket_pph.Visible = False
        '
        '_lokasi
        '
        Me._lokasi.FormattingEnabled = True
        Me._lokasi.Items.AddRange(New Object() {"TSC-TNG", "TSC-CKR"})
        Me._lokasi.Location = New System.Drawing.Point(561, 113)
        Me._lokasi.Name = "_lokasi"
        Me._lokasi.Size = New System.Drawing.Size(33, 21)
        Me._lokasi.TabIndex = 169
        Me._lokasi.Visible = False
        '
        '_tarif
        '
        Me._tarif.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me._tarif.FormattingEnabled = True
        Me._tarif.Location = New System.Drawing.Point(498, 113)
        Me._tarif.Name = "_tarif"
        Me._tarif.Size = New System.Drawing.Size(30, 21)
        Me._tarif.TabIndex = 168
        Me._tarif.Text = "0"
        Me._tarif.Visible = False
        '
        '_pph
        '
        Me._pph.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me._pph.FormattingEnabled = True
        Me._pph.Location = New System.Drawing.Point(432, 113)
        Me._pph.Name = "_pph"
        Me._pph.Size = New System.Drawing.Size(30, 21)
        Me._pph.TabIndex = 167
        Me._pph.Visible = False
        '
        '_bulan
        '
        Me._bulan.Location = New System.Drawing.Point(600, 113)
        Me._bulan.Name = "_bulan"
        Me._bulan.Size = New System.Drawing.Size(52, 20)
        Me._bulan.TabIndex = 165
        Me._bulan.Visible = False
        '
        '_tahun
        '
        Me._tahun.Location = New System.Drawing.Point(534, 114)
        Me._tahun.Name = "_tahun"
        Me._tahun.Size = New System.Drawing.Size(21, 20)
        Me._tahun.TabIndex = 166
        Me._tahun.Visible = False
        '
        '_Ket_Dpp
        '
        Me._Ket_Dpp.Location = New System.Drawing.Point(431, 168)
        Me._Ket_Dpp.Name = "_Ket_Dpp"
        Me._Ket_Dpp.Size = New System.Drawing.Size(221, 29)
        Me._Ket_Dpp.TabIndex = 164
        Me._Ket_Dpp.Text = ""
        Me._Ket_Dpp.Visible = False
        '
        '_nilai_Pph

        Me._nilai_Pph.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._nilai_Pph.Location = New System.Drawing.Point(431, 140)
        Me._nilai_Pph.Name = "_nilai_Pph"
        Me._nilai_Pph.Size = New System.Drawing.Size(220, 22)
        Me._nilai_Pph.TabIndex = 163
        Me._nilai_Pph.Text = "0"
        Me._nilai_Pph.Visible = False
        '
        'Button4

        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(960, 13)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(50, 47)
        Me.Button4.TabIndex = 86
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button1
        '

        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Location = New System.Drawing.Point(536, 45)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(35, 38)
        Me.Button1.TabIndex = 85
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '

        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.Location = New System.Drawing.Point(356, 13)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(35, 38)
        Me.Button2.TabIndex = 84
        Me.Button2.UseVisualStyleBackColor = True
        '
        '_nama_vendor
        '
        Me._nama_vendor.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._nama_vendor.Location = New System.Drawing.Point(289, 85)
        Me._nama_vendor.Name = "_nama_vendor"
        Me._nama_vendor.Size = New System.Drawing.Size(241, 22)
        Me._nama_vendor.TabIndex = 83
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(657, 53)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(61, 14)
        Me.Label17.TabIndex = 77
        Me.Label17.Text = "CURRENCY"
        '
        '_No_Bukti_Potong
        '
        Me._No_Bukti_Potong.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me._No_Bukti_Potong.Location = New System.Drawing.Point(163, 141)
        Me._No_Bukti_Potong.Name = "_No_Bukti_Potong"
        Me._No_Bukti_Potong.Size = New System.Drawing.Size(188, 20)
        Me._No_Bukti_Potong.TabIndex = 71
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(147, 144)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(10, 13)
        Me.Label28.TabIndex = 70
        Me.Label28.Text = ":"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(35, 144)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(88, 13)
        Me.Label30.TabIndex = 69
        Me.Label30.Text = "No. Bukti Potong"
        '
        '_Vend_Name
        '
        Me._Vend_Name.FormattingEnabled = True
        Me._Vend_Name.Location = New System.Drawing.Point(243, 57)
        Me._Vend_Name.Name = "_Vend_Name"
        Me._Vend_Name.Size = New System.Drawing.Size(287, 21)
        Me._Vend_Name.TabIndex = 58
        Me._Vend_Name.Text = "3 M INDONESIA , PT"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(658, 139)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(38, 14)
        Me.Label25.TabIndex = 54
        Me.Label25.Text = "TOTAL"
        '
        'Button3
        '
        Me.Button3.BackgroundImage = CType(resources.GetObject("Button3.BackgroundImage"), System.Drawing.Image)
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(1016, 13)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(50, 47)
        Me.Button3.TabIndex = 52
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(761, 111)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(10, 14)
        Me.Label19.TabIndex = 26
        Me.Label19.Text = ":"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(568, 3)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(0, 14)
        Me.Label24.TabIndex = 42
        '
        '_curyid
        '
        Me._curyid.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._curyid.FormattingEnabled = True
        Me._curyid.Items.AddRange(New Object() {"IDR", "USD"})
        Me._curyid.Location = New System.Drawing.Point(776, 50)
        Me._curyid.Name = "_curyid"
        Me._curyid.Size = New System.Drawing.Size(55, 22)
        Me._curyid.TabIndex = 39
        Me._curyid.Text = "IDR"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(761, 141)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(10, 14)
        Me.Label21.TabIndex = 29
        Me.Label21.Text = ":"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(33, 113)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(62, 14)
        Me.Label22.TabIndex = 31
        Me.Label22.Text = "JENIS JASA"
        '
        '_jenis_jasa
        '
        Me._jenis_jasa.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._jenis_jasa.Location = New System.Drawing.Point(164, 113)
        Me._jenis_jasa.Name = "_jenis_jasa"
        Me._jenis_jasa.Size = New System.Drawing.Size(366, 22)
        Me._jenis_jasa.TabIndex = 32
        '
        '_Tot_Voucher
        '
        Me._Tot_Voucher.Enabled = False
        Me._Tot_Voucher.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Tot_Voucher.Location = New System.Drawing.Point(776, 133)
        Me._Tot_Voucher.Name = "_Tot_Voucher"
        Me._Tot_Voucher.Size = New System.Drawing.Size(180, 22)
        Me._Tot_Voucher.TabIndex = 30
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(148, 113)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(10, 14)
        Me.Label23.TabIndex = 33
        Me.Label23.Text = ":"
        '
        '_Tot_Ppn
        '
        Me._Tot_Ppn.Enabled = False
        Me._Tot_Ppn.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Tot_Ppn.Location = New System.Drawing.Point(776, 105)
        Me._Tot_Ppn.Name = "_Tot_Ppn"
        Me._Tot_Ppn.Size = New System.Drawing.Size(180, 22)
        Me._Tot_Ppn.TabIndex = 24
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(661, 167)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(27, 14)
        Me.Label16.TabIndex = 22
        Me.Label16.Text = "PPH"
        '
        '_Tot_Pph
        '
        Me._Tot_Pph.Enabled = False
        Me._Tot_Pph.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Tot_Pph.Location = New System.Drawing.Point(776, 161)
        Me._Tot_Pph.Name = "_Tot_Pph"
        Me._Tot_Pph.Size = New System.Drawing.Size(180, 22)
        Me._Tot_Pph.TabIndex = 21
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(658, 111)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(27, 14)
        Me.Label14.TabIndex = 19
        Me.Label14.Text = "PPN"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(761, 167)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(10, 14)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = ":"
        '
        '_Tot_Dpp_Invoice
        '
        Me._Tot_Dpp_Invoice.Enabled = False
        Me._Tot_Dpp_Invoice.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Tot_Dpp_Invoice.Location = New System.Drawing.Point(776, 77)
        Me._Tot_Dpp_Invoice.Name = "_Tot_Dpp_Invoice"
        Me._Tot_Dpp_Invoice.Size = New System.Drawing.Size(180, 22)
        Me._Tot_Dpp_Invoice.TabIndex = 18
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(658, 80)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 14)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "DPP INVOICE"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(761, 80)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(10, 14)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = ":"
        '
        '_Tgl_fp
        '
        Me._Tgl_fp.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Tgl_fp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me._Tgl_fp.Location = New System.Drawing.Point(776, 22)
        Me._Tgl_fp.Name = "_Tgl_fp"
        Me._Tgl_fp.Size = New System.Drawing.Size(112, 22)
        Me._Tgl_fp.TabIndex = 15
        Me._Tgl_fp.Value = New Date(2017, 8, 15, 0, 0, 0, 0)
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(657, 28)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(33, 14)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "DATE"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(760, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(10, 14)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = ":"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(33, 88)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(38, 14)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "NPWP"
        '
        '_npwp
        '
        Me._npwp.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._npwp.Location = New System.Drawing.Point(164, 85)
        Me._npwp.Name = "_npwp"
        Me._npwp.Size = New System.Drawing.Size(119, 22)
        Me._npwp.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(148, 90)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(10, 14)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = ":"
        '
        '_VendID
        '
        Me._VendID.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._VendID.FormattingEnabled = True
        Me._VendID.Location = New System.Drawing.Point(163, 57)
        Me._VendID.Name = "_VendID"
        Me._VendID.Size = New System.Drawing.Size(74, 22)
        Me._VendID.TabIndex = 6
        Me._VendID.Text = "P0001"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(33, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "NO. TRANSAKSI"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(147, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 14)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = ":"
        '
        '_VoucNo
        '
        Me._VoucNo.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me._VoucNo.Enabled = False
        Me._VoucNo.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._VoucNo.Location = New System.Drawing.Point(164, 28)
        Me._VoucNo.Name = "_VoucNo"
        Me._VoucNo.Size = New System.Drawing.Size(186, 22)
        Me._VoucNo.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(32, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 14)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "SUPPLIER"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(148, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 14)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = ":"
        '
        'Panel3
        '
        Me.Panel3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel3.Controls.Add(Me.DataGridView1)
        Me.Panel3.Controls.Add(Me.Label27)
        Me.Panel3.Location = New System.Drawing.Point(23, 220)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1082, 314)
        Me.Panel3.TabIndex = 51
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(16, 28)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1050, 270)
        Me.DataGridView1.TabIndex = 52
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(13, 9)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(204, 16)
        Me.Label27.TabIndex = 51
        Me.Label27.Text = "Invoice Yang Akan Dibayar :"
        '
        'Frm_FP
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1115, 583)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Frm_FP"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "VERIFIKASI PAJAK"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents _Vend_Name As System.Windows.Forms.ComboBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents _curyid As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents _jenis_jasa As System.Windows.Forms.TextBox
    Friend WithEvents _Tot_Voucher As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents _Tot_Ppn As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents _Tot_Pph As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents _Tot_Dpp_Invoice As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents _Tgl_fp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents _npwp As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents _VendID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents _VoucNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents _No_Bukti_Potong As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents _nama_vendor As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents _ket_pph As System.Windows.Forms.ComboBox
    Friend WithEvents _lokasi As System.Windows.Forms.ComboBox
    Friend WithEvents _tarif As System.Windows.Forms.ComboBox
    Friend WithEvents _pph As System.Windows.Forms.ComboBox
    Friend WithEvents _bulan As System.Windows.Forms.TextBox
    Friend WithEvents _tahun As System.Windows.Forms.TextBox
    Friend WithEvents _Ket_Dpp As System.Windows.Forms.RichTextBox
    Friend WithEvents _nilai_Pph As System.Windows.Forms.TextBox
End Class
