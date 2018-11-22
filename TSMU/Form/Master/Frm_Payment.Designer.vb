<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Payment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Payment))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Label29 = New System.Windows.Forms.Label()
        Me._debit_bank = New System.Windows.Forms.TextBox()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me._Biaya_Transfer = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me._tot_cndn = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me._Tot_Voucher = New System.Windows.Forms.TextBox()
        Me._Tot_Ppn = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me._Tot_Pph = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me._Tot_Dpp_Invoice = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Button4 = New System.Windows.Forms.Button()
        Me._tot_tmv = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me._BankName = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me._BankID = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label17 = New System.Windows.Forms.Label()
        Me._Vend_Name = New System.Windows.Forms.ComboBox()
        Me.cek = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Label24 = New System.Windows.Forms.Label()
        Me._curyid = New System.Windows.Forms.ComboBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me._jenis_jasa = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me._Tgl_fp = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me._VendID = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me._VocNo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label27 = New System.Windows.Forms.Label()
        'Me.CachedRptVerifyPajak1 = New TSMU.CachedRptVerifyPajak()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.Label29)
        Me.Panel1.Controls.Add(Me._debit_bank)
        Me.Panel1.Controls.Add(Me.Label30)
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me._Biaya_Transfer)
        Me.Panel1.Controls.Add(Me.Label28)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me._tot_cndn)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me._Tot_Voucher)
        Me.Panel1.Controls.Add(Me._Tot_Ppn)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me._Tot_Pph)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me._Tot_Dpp_Invoice)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Button4)
        Me.Panel1.Controls.Add(Me._tot_tmv)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me._BankName)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me._BankID)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me._Vend_Name)
        Me.Panel1.Controls.Add(Me.cek)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Controls.Add(Me._curyid)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me._jenis_jasa)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me._Tgl_fp)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me._VendID)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me._VocNo)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(12, 17)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1145, 171)
        Me.Panel1.TabIndex = 11
        '
        'Button1
        '
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Location = New System.Drawing.Point(1083, 2)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(49, 46)
        Me.Button1.TabIndex = 53
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label29.Location = New System.Drawing.Point(910, 144)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(69, 14)
        Me.Label29.TabIndex = 114
        Me.Label29.Text = "DEBIT BANK"
        '
        '_debit_bank
        '
        Me._debit_bank.Enabled = False
        Me._debit_bank.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._debit_bank.Location = New System.Drawing.Point(1015, 138)
        Me._debit_bank.Name = "_debit_bank"
        Me._debit_bank.Size = New System.Drawing.Size(117, 22)
        Me._debit_bank.TabIndex = 113
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label30.Location = New System.Drawing.Point(999, 144)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(10, 14)
        Me.Label30.TabIndex = 112
        Me.Label30.Text = ":"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(908, 118)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(92, 14)
        Me.Label26.TabIndex = 111
        Me.Label26.Text = "BIAYA TRANSFER"
        '
        '_Biaya_Transfer
        '
        Me._Biaya_Transfer.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Biaya_Transfer.Location = New System.Drawing.Point(1015, 110)
        Me._Biaya_Transfer.Name = "_Biaya_Transfer"
        Me._Biaya_Transfer.Size = New System.Drawing.Size(117, 22)
        Me._Biaya_Transfer.TabIndex = 110
        Me._Biaya_Transfer.Text = "2500"
        Me._Biaya_Transfer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(1002, 116)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(10, 14)
        Me.Label28.TabIndex = 109
        Me.Label28.Text = ":"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(910, 91)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(46, 14)
        Me.Label18.TabIndex = 108
        Me.Label18.Text = "CM/DM"
        '
        '_tot_cndn
        '
        Me._tot_cndn.Enabled = False
        Me._tot_cndn.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._tot_cndn.Location = New System.Drawing.Point(1015, 85)
        Me._tot_cndn.Name = "_tot_cndn"
        Me._tot_cndn.Size = New System.Drawing.Size(117, 22)
        Me._tot_cndn.TabIndex = 107
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(999, 91)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(10, 14)
        Me.Label20.TabIndex = 106
        Me.Label20.Text = ":"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(664, 144)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(38, 14)
        Me.Label25.TabIndex = 105
        Me.Label25.Text = "TOTAL"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(747, 114)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(10, 14)
        Me.Label19.TabIndex = 102
        Me.Label19.Text = ":"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(747, 141)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(10, 14)
        Me.Label21.TabIndex = 103
        Me.Label21.Text = ":"
        '
        '_Tot_Voucher
        '
        Me._Tot_Voucher.Enabled = False
        Me._Tot_Voucher.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Tot_Voucher.Location = New System.Drawing.Point(762, 138)
        Me._Tot_Voucher.Name = "_Tot_Voucher"
        Me._Tot_Voucher.Size = New System.Drawing.Size(135, 22)
        Me._Tot_Voucher.TabIndex = 104
        '
        '_Tot_Ppn
        '
        Me._Tot_Ppn.Enabled = False
        Me._Tot_Ppn.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Tot_Ppn.Location = New System.Drawing.Point(762, 108)
        Me._Tot_Ppn.Name = "_Tot_Ppn"
        Me._Tot_Ppn.Size = New System.Drawing.Size(135, 22)
        Me._Tot_Ppn.TabIndex = 101
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(910, 63)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(56, 14)
        Me.Label16.TabIndex = 100
        Me.Label16.Text = "PPH (TAX)"
        '
        '_Tot_Pph
        '
        Me._Tot_Pph.Enabled = False
        Me._Tot_Pph.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Tot_Pph.Location = New System.Drawing.Point(1015, 57)
        Me._Tot_Pph.Name = "_Tot_Pph"
        Me._Tot_Pph.Size = New System.Drawing.Size(117, 22)
        Me._Tot_Pph.TabIndex = 99
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(664, 114)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(56, 14)
        Me.Label14.TabIndex = 97
        Me.Label14.Text = "PPN (VAT)"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(999, 63)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(10, 14)
        Me.Label15.TabIndex = 98
        Me.Label15.Text = ":"
        '
        '_Tot_Dpp_Invoice
        '
        Me._Tot_Dpp_Invoice.Enabled = False
        Me._Tot_Dpp_Invoice.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Tot_Dpp_Invoice.Location = New System.Drawing.Point(762, 80)
        Me._Tot_Dpp_Invoice.Name = "_Tot_Dpp_Invoice"
        Me._Tot_Dpp_Invoice.Size = New System.Drawing.Size(135, 22)
        Me._Tot_Dpp_Invoice.TabIndex = 96
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(664, 83)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 14)
        Me.Label12.TabIndex = 94
        Me.Label12.Text = "DPP INVOICE"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(747, 83)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(10, 14)
        Me.Label13.TabIndex = 95
        Me.Label13.Text = ":"
        '
        'Button4
        '
        'Me.Button4.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources._1488269007_file_edit
        'Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(971, 1)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(50, 47)
        Me.Button4.TabIndex = 93
        Me.Button4.UseVisualStyleBackColor = True
        '
        '_tot_tmv
        '
        Me._tot_tmv.Enabled = False
        Me._tot_tmv.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._tot_tmv.Location = New System.Drawing.Point(762, 53)
        Me._tot_tmv.Name = "_tot_tmv"
        Me._tot_tmv.Size = New System.Drawing.Size(135, 22)
        Me._tot_tmv.TabIndex = 92
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(664, 53)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 14)
        Me.Label1.TabIndex = 90
        Me.Label1.Text = "TMV" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(746, 29)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(10, 14)
        Me.Label9.TabIndex = 90
        Me.Label9.Text = ":"
        '
        '_BankName
        '
        Me._BankName.FormattingEnabled = True
        Me._BankName.Items.AddRange(New Object() {"MIZUHO"})
        Me._BankName.Location = New System.Drawing.Point(263, 57)
        Me._BankName.Name = "_BankName"
        Me._BankName.Size = New System.Drawing.Size(287, 21)
        Me._BankName.TabIndex = 89
        Me._BankName.Text = "MIZUHO IDR"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(747, 56)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(10, 14)
        Me.Label8.TabIndex = 91
        Me.Label8.Text = ":"
        '
        '_BankID
        '
        Me._BankID.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._BankID.FormattingEnabled = True
        Me._BankID.Location = New System.Drawing.Point(183, 57)
        Me._BankID.Name = "_BankID"
        Me._BankID.Size = New System.Drawing.Size(74, 22)
        Me._BankID.TabIndex = 88
        Me._BankID.Text = "11240"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(167, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(10, 14)
        Me.Label6.TabIndex = 87
        Me.Label6.Text = ":"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(32, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 14)
        Me.Label7.TabIndex = 86
        Me.Label7.Text = "BANK"
        '
        'Button2
        '
        'Me.Button2.BackgroundImage = Global.WindowsApplication1.My.Resources.Resources._1488269045_file_search
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.Location = New System.Drawing.Point(376, 13)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(35, 38)
        Me.Button2.TabIndex = 84
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(662, 26)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(61, 14)
        Me.Label17.TabIndex = 77
        Me.Label17.Text = "CURRENCY"
        '
        '_Vend_Name
        '
        Me._Vend_Name.FormattingEnabled = True
        Me._Vend_Name.Location = New System.Drawing.Point(263, 113)
        Me._Vend_Name.Name = "_Vend_Name"
        Me._Vend_Name.Size = New System.Drawing.Size(287, 21)
        Me._Vend_Name.TabIndex = 58
        Me._Vend_Name.Text = "3 M INDONESIA , PT"
        '
        'cek
        '
        Me.cek.Location = New System.Drawing.Point(556, 113)
        Me.cek.Name = "cek"
        Me.cek.Size = New System.Drawing.Size(57, 23)
        Me.cek.TabIndex = 53
        Me.cek.Text = "Cek Inv."
        Me.cek.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.BackgroundImage = CType(resources.GetObject("Button3.BackgroundImage"), System.Drawing.Image)
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.Location = New System.Drawing.Point(1027, 1)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(50, 47)
        Me.Button3.TabIndex = 52
        Me.Button3.UseVisualStyleBackColor = True
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
        Me._curyid.Items.AddRange(New Object() {"IDR", "USD", "YEN"})
        Me._curyid.Location = New System.Drawing.Point(762, 25)
        Me._curyid.Name = "_curyid"
        Me._curyid.Size = New System.Drawing.Size(55, 22)
        Me._curyid.TabIndex = 39
        Me._curyid.Text = "IDR"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(33, 141)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(122, 14)
        Me.Label22.TabIndex = 31
        Me.Label22.Text = "DESKRIPSI TAMBAHAN"
        '
        '_jenis_jasa
        '
        Me._jenis_jasa.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._jenis_jasa.Location = New System.Drawing.Point(183, 141)
        Me._jenis_jasa.Name = "_jenis_jasa"
        Me._jenis_jasa.Size = New System.Drawing.Size(366, 22)
        Me._jenis_jasa.TabIndex = 32
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(167, 141)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(10, 14)
        Me.Label23.TabIndex = 33
        Me.Label23.Text = ":"
        '
        '_Tgl_fp
        '
        Me._Tgl_fp.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Tgl_fp.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me._Tgl_fp.Location = New System.Drawing.Point(184, 85)
        Me._Tgl_fp.Name = "_Tgl_fp"
        Me._Tgl_fp.Size = New System.Drawing.Size(186, 22)
        Me._Tgl_fp.TabIndex = 15
        Me._Tgl_fp.Value = New Date(2018, 1, 15, 0, 0, 0, 0)
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(32, 91)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 14)
        Me.Label10.TabIndex = 13
        Me.Label10.Text = "DATE PAYMENT"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(167, 91)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(10, 14)
        Me.Label11.TabIndex = 14
        Me.Label11.Text = ":"
        '
        '_VendID
        '
        Me._VendID.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._VendID.FormattingEnabled = True
        Me._VendID.Location = New System.Drawing.Point(183, 113)
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
        Me.Label2.Size = New System.Drawing.Size(89, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "E-VOUCHER NO."
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(167, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(10, 14)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = ":"
        '
        '_VocNo
        '
        Me._VocNo.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me._VocNo.Enabled = False
        Me._VocNo.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._VocNo.Location = New System.Drawing.Point(184, 28)
        Me._VocNo.Name = "_VocNo"
        Me._VocNo.Size = New System.Drawing.Size(186, 22)
        Me._VocNo.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(32, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 14)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "SUPPLIER"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(168, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 14)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = ":"
        '
        'Panel3
        '
        Me.Panel3.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel3.Controls.Add(Me.Label31)
        Me.Panel3.Controls.Add(Me.DataGridView2)
        Me.Panel3.Controls.Add(Me.DataGridView1)
        Me.Panel3.Controls.Add(Me.Label27)
        Me.Panel3.Location = New System.Drawing.Point(12, 194)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1145, 433)
        Me.Panel3.TabIndex = 52
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label31.Location = New System.Drawing.Point(13, 245)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(66, 16)
        Me.Label31.TabIndex = 54
        Me.Label31.Text = "CM/DM :"
        '
        'DataGridView2
        '
        Me.DataGridView2.AllowUserToAddRows = False
        Me.DataGridView2.AllowUserToDeleteRows = False
        Me.DataGridView2.AllowUserToOrderColumns = True
        Me.DataGridView2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(16, 264)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(1116, 138)
        Me.DataGridView2.TabIndex = 53
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(16, 28)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1116, 196)
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
        'Frm_Payment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1169, 639)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Frm_Payment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PAYMENT"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents _Vend_Name As System.Windows.Forms.ComboBox
    Friend WithEvents cek As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents _curyid As System.Windows.Forms.ComboBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents _jenis_jasa As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents _Tgl_fp As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents _VendID As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents _VocNo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents _BankName As System.Windows.Forms.ComboBox
    Friend WithEvents _BankID As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents _tot_tmv As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents _tot_cndn As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents _Tot_Voucher As System.Windows.Forms.TextBox
    Friend WithEvents _Tot_Ppn As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents _Tot_Pph As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents _Tot_Dpp_Invoice As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents DataGridView2 As System.Windows.Forms.DataGridView
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents _Biaya_Transfer As System.Windows.Forms.TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    'Friend WithEvents CachedRptVerifyPajak1 As WindowsApplication1.CachedRptVerifyPajak
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents _debit_bank As System.Windows.Forms.TextBox
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
