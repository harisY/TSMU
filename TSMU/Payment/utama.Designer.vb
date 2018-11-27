<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class utama
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(utama))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me._VoucNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me._BankName = New System.Windows.Forms.ComboBox()
        Me._Vend_Name = New System.Windows.Forms.ComboBox()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me._Nilai_Transfer = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.cek = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ComboBox7 = New System.Windows.Forms.ComboBox()
        Me.ComboBox4 = New System.Windows.Forms.ComboBox()
        Me.ComboBox6 = New System.Windows.Forms.ComboBox()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ComboBox5 = New System.Windows.Forms.ComboBox()
        Me._Biaya_transfer = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me._No_Bukti_Potong = New System.Windows.Forms.TextBox()
        Me._Tot_Voucher = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me._Tot_Ppn = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me._Tot_Pph = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me._Tot_Dpp_Invoice = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me._Tgl_Vouch = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me._CheckNo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me._BankID = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me._VendID = New System.Windows.Forms.ComboBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Calibri", 21.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(131, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(332, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "BANK PAYMENT VOUCHER"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(33, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 14)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "VOUCHER NO."
        '
        '_VoucNo
        '
        Me._VoucNo.Enabled = False
        Me._VoucNo.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._VoucNo.Location = New System.Drawing.Point(164, 28)
        Me._VoucNo.Name = "_VoucNo"
        Me._VoucNo.Size = New System.Drawing.Size(186, 22)
        Me._VoucNo.TabIndex = 2
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
        'Panel1
        '
        Me.Panel1.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.Panel1.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel1.Controls.Add(Me._BankName)
        Me.Panel1.Controls.Add(Me._Vend_Name)
        Me.Panel1.Controls.Add(Me.Label26)
        Me.Panel1.Controls.Add(Me.ComboBox1)
        Me.Panel1.Controls.Add(Me._Nilai_Transfer)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.cek)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.ComboBox7)
        Me.Panel1.Controls.Add(Me.ComboBox4)
        Me.Panel1.Controls.Add(Me.ComboBox6)
        Me.Panel1.Controls.Add(Me.ComboBox3)
        Me.Panel1.Controls.Add(Me.Label19)
        Me.Panel1.Controls.Add(Me.Label24)
        Me.Panel1.Controls.Add(Me.Label18)
        Me.Panel1.Controls.Add(Me.ComboBox5)
        Me.Panel1.Controls.Add(Me._Biaya_transfer)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.Label22)
        Me.Panel1.Controls.Add(Me.Label20)
        Me.Panel1.Controls.Add(Me._No_Bukti_Potong)
        Me.Panel1.Controls.Add(Me._Tot_Voucher)
        Me.Panel1.Controls.Add(Me.Label23)
        Me.Panel1.Controls.Add(Me._Tot_Ppn)
        Me.Panel1.Controls.Add(Me.Label16)
        Me.Panel1.Controls.Add(Me.Label17)
        Me.Panel1.Controls.Add(Me._Tot_Pph)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me._Tot_Dpp_Invoice)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me._Tgl_Vouch)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me._CheckNo)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me._BankID)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me._VendID)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me._VoucNo)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Location = New System.Drawing.Point(137, 67)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1189, 227)
        Me.Panel1.TabIndex = 7
        '
        '_BankName
        '
        Me._BankName.FormattingEnabled = True
        Me._BankName.Location = New System.Drawing.Point(243, 85)
        Me._BankName.Name = "_BankName"
        Me._BankName.Size = New System.Drawing.Size(287, 21)
        Me._BankName.TabIndex = 59
        '
        '_Vend_Name
        '
        Me._Vend_Name.FormattingEnabled = True
        Me._Vend_Name.Location = New System.Drawing.Point(243, 57)
        Me._Vend_Name.Name = "_Vend_Name"
        Me._Vend_Name.Size = New System.Drawing.Size(287, 21)
        Me._Vend_Name.TabIndex = 58
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.Location = New System.Drawing.Point(760, 196)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(10, 14)
        Me.Label26.TabIndex = 57
        Me.Label26.Text = ":"
        '
        'ComboBox1
        '
        Me.ComboBox1.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"IDR", "USD"})
        Me.ComboBox1.Location = New System.Drawing.Point(776, 193)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(55, 22)
        Me.ComboBox1.TabIndex = 56
        Me.ComboBox1.Text = "IDR"
        '
        '_Nilai_Transfer
        '
        Me._Nilai_Transfer.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Nilai_Transfer.Location = New System.Drawing.Point(837, 193)
        Me._Nilai_Transfer.Name = "_Nilai_Transfer"
        Me._Nilai_Transfer.Size = New System.Drawing.Size(180, 22)
        Me._Nilai_Transfer.TabIndex = 55
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(657, 111)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(38, 14)
        Me.Label25.TabIndex = 54
        Me.Label25.Text = "TOTAL"
        '
        'cek
        '
        Me.cek.Location = New System.Drawing.Point(536, 57)
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
        Me.Button3.Location = New System.Drawing.Point(1033, 168)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(50, 47)
        Me.Button3.TabIndex = 52
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ComboBox7
        '
        Me.ComboBox7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox7.FormattingEnabled = True
        Me.ComboBox7.Items.AddRange(New Object() {"IDR", "USD"})
        Me.ComboBox7.Location = New System.Drawing.Point(776, 108)
        Me.ComboBox7.Name = "ComboBox7"
        Me.ComboBox7.Size = New System.Drawing.Size(55, 22)
        Me.ComboBox7.TabIndex = 46
        Me.ComboBox7.Text = "IDR"
        '
        'ComboBox4
        '
        Me.ComboBox4.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox4.FormattingEnabled = True
        Me.ComboBox4.Items.AddRange(New Object() {"IDR", "USD"})
        Me.ComboBox4.Location = New System.Drawing.Point(776, 164)
        Me.ComboBox4.Name = "ComboBox4"
        Me.ComboBox4.Size = New System.Drawing.Size(55, 22)
        Me.ComboBox4.TabIndex = 44
        Me.ComboBox4.Text = "IDR"
        '
        'ComboBox6
        '
        Me.ComboBox6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox6.FormattingEnabled = True
        Me.ComboBox6.Items.AddRange(New Object() {"IDR", "USD"})
        Me.ComboBox6.Location = New System.Drawing.Point(776, 80)
        Me.ComboBox6.Name = "ComboBox6"
        Me.ComboBox6.Size = New System.Drawing.Size(55, 22)
        Me.ComboBox6.TabIndex = 45
        Me.ComboBox6.Text = "IDR"
        '
        'ComboBox3
        '
        Me.ComboBox3.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Items.AddRange(New Object() {"IDR", "USD"})
        Me.ComboBox3.Location = New System.Drawing.Point(776, 136)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(55, 22)
        Me.ComboBox3.TabIndex = 43
        Me.ComboBox3.Text = "IDR"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(760, 83)
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
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(660, 167)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(92, 14)
        Me.Label18.TabIndex = 25
        Me.Label18.Text = "BIAYA TRANSFER"
        '
        'ComboBox5
        '
        Me.ComboBox5.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox5.FormattingEnabled = True
        Me.ComboBox5.Items.AddRange(New Object() {"IDR", "USD"})
        Me.ComboBox5.Location = New System.Drawing.Point(776, 52)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(55, 22)
        Me.ComboBox5.TabIndex = 39
        Me.ComboBox5.Text = "IDR"
        '
        '_Biaya_transfer
        '
        Me._Biaya_transfer.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Biaya_transfer.Location = New System.Drawing.Point(837, 164)
        Me._Biaya_transfer.Name = "_Biaya_transfer"
        Me._Biaya_transfer.Size = New System.Drawing.Size(180, 22)
        Me._Biaya_transfer.TabIndex = 27
        Me._Biaya_transfer.Text = "2500"
        Me._Biaya_transfer.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(760, 113)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(10, 14)
        Me.Label21.TabIndex = 29
        Me.Label21.Text = ":"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(32, 146)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(107, 14)
        Me.Label22.TabIndex = 31
        Me.Label22.Text = "NO. BUKTI POTONG"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(660, 196)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(91, 14)
        Me.Label20.TabIndex = 28
        Me.Label20.Text = "NILAI TRANSFER"
        '
        '_No_Bukti_Potong
        '
        Me._No_Bukti_Potong.Enabled = False
        Me._No_Bukti_Potong.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._No_Bukti_Potong.Location = New System.Drawing.Point(163, 146)
        Me._No_Bukti_Potong.Name = "_No_Bukti_Potong"
        Me._No_Bukti_Potong.Size = New System.Drawing.Size(187, 22)
        Me._No_Bukti_Potong.TabIndex = 32
        '
        '_Tot_Voucher
        '
        Me._Tot_Voucher.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Tot_Voucher.Location = New System.Drawing.Point(837, 108)
        Me._Tot_Voucher.Name = "_Tot_Voucher"
        Me._Tot_Voucher.Size = New System.Drawing.Size(180, 22)
        Me._Tot_Voucher.TabIndex = 30
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(147, 146)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(10, 14)
        Me.Label23.TabIndex = 33
        Me.Label23.Text = ":"
        '
        '_Tot_Ppn
        '
        Me._Tot_Ppn.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Tot_Ppn.Location = New System.Drawing.Point(837, 80)
        Me._Tot_Ppn.Name = "_Tot_Ppn"
        Me._Tot_Ppn.Size = New System.Drawing.Size(180, 22)
        Me._Tot_Ppn.TabIndex = 24
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(660, 139)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(27, 14)
        Me.Label16.TabIndex = 22
        Me.Label16.Text = "PPH"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(760, 167)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(10, 14)
        Me.Label17.TabIndex = 23
        Me.Label17.Text = ":"
        '
        '_Tot_Pph
        '
        Me._Tot_Pph.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Tot_Pph.Location = New System.Drawing.Point(837, 136)
        Me._Tot_Pph.Name = "_Tot_Pph"
        Me._Tot_Pph.Size = New System.Drawing.Size(180, 22)
        Me._Tot_Pph.TabIndex = 21
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(657, 83)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(27, 14)
        Me.Label14.TabIndex = 19
        Me.Label14.Text = "PPN"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(760, 139)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(10, 14)
        Me.Label15.TabIndex = 20
        Me.Label15.Text = ":"
        '
        '_Tot_Dpp_Invoice
        '
        Me._Tot_Dpp_Invoice.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Tot_Dpp_Invoice.Location = New System.Drawing.Point(837, 52)
        Me._Tot_Dpp_Invoice.Name = "_Tot_Dpp_Invoice"
        Me._Tot_Dpp_Invoice.Size = New System.Drawing.Size(180, 22)
        Me._Tot_Dpp_Invoice.TabIndex = 18
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(657, 52)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(73, 14)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "DPP INVOICE"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(760, 52)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(10, 14)
        Me.Label13.TabIndex = 17
        Me.Label13.Text = ":"
        '
        '_Tgl_Vouch
        '
        Me._Tgl_Vouch.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._Tgl_Vouch.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me._Tgl_Vouch.Location = New System.Drawing.Point(776, 22)
        Me._Tgl_Vouch.Name = "_Tgl_Vouch"
        Me._Tgl_Vouch.Size = New System.Drawing.Size(112, 22)
        Me._Tgl_Vouch.TabIndex = 15
        Me._Tgl_Vouch.Value = New Date(2017, 8, 15, 0, 0, 0, 0)
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
        Me.Label8.Location = New System.Drawing.Point(32, 116)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(107, 14)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "CHECK / GIRO / TRF"
        '
        '_CheckNo
        '
        Me._CheckNo.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._CheckNo.Location = New System.Drawing.Point(163, 113)
        Me._CheckNo.Name = "_CheckNo"
        Me._CheckNo.Size = New System.Drawing.Size(187, 22)
        Me._CheckNo.TabIndex = 11
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(147, 118)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(10, 14)
        Me.Label9.TabIndex = 12
        Me.Label9.Text = ":"
        '
        '_BankID
        '
        Me._BankID.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._BankID.FormattingEnabled = True
        Me._BankID.Location = New System.Drawing.Point(163, 85)
        Me._BankID.Name = "_BankID"
        Me._BankID.Size = New System.Drawing.Size(74, 22)
        Me._BankID.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(147, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(10, 14)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = ":"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(32, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 14)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "BANK"
        '
        '_VendID
        '
        Me._VendID.Font = New System.Drawing.Font("Calibri", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._VendID.FormattingEnabled = True
        Me._VendID.Location = New System.Drawing.Point(163, 57)
        Me._VendID.Name = "_VendID"
        Me._VendID.Size = New System.Drawing.Size(74, 22)
        Me._VendID.TabIndex = 6
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel2.Controls.Add(Me.Panel3)
        Me.Panel2.Location = New System.Drawing.Point(137, 300)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1189, 350)
        Me.Panel2.TabIndex = 8
        '
        'Panel3
        '
        Me.Panel3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom), System.Windows.Forms.AnchorStyles)
        Me.Panel3.BackColor = System.Drawing.SystemColors.ControlLight
        Me.Panel3.Controls.Add(Me.DataGridView1)
        Me.Panel3.Controls.Add(Me.Label27)
        Me.Panel3.Location = New System.Drawing.Point(15, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(1147, 303)
        Me.Panel3.TabIndex = 50
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(13, 40)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1115, 260)
        Me.DataGridView1.TabIndex = 52
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label27.Location = New System.Drawing.Point(10, 12)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(204, 16)
        Me.Label27.TabIndex = 51
        Me.Label27.Text = "Invoice Yang Akan Dibayar :"
        '
        'utama
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1338, 733)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "utama"
        Me.Text = "Bank Payment Voucher"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents _VoucNo As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents _VendID As System.Windows.Forms.ComboBox
    Friend WithEvents _BankID As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents _CheckNo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents _Tgl_Vouch As System.Windows.Forms.DateTimePicker
    Friend WithEvents _Tot_Dpp_Invoice As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents _Tot_Voucher As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents _Biaya_transfer As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents _Tot_Ppn As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents _Tot_Pph As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents _No_Bukti_Potong As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents ComboBox5 As System.Windows.Forms.ComboBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents ComboBox7 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox6 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox4 As System.Windows.Forms.ComboBox
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents cek As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents _Nilai_Transfer As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents _BankName As System.Windows.Forms.ComboBox
    Friend WithEvents _Vend_Name As System.Windows.Forms.ComboBox

End Class
