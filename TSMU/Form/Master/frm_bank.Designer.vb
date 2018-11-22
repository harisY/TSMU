<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm_bank
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frm_bank))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me._BankName = New System.Windows.Forms.ComboBox()
        Me._BankID = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me._TglPay = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me._gridshipper2 = New System.Windows.Forms.DataGridView()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout
        CType(Me._gridshipper2,System.ComponentModel.ISupportInitialize).BeginInit
        Me.SuspendLayout
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.Panel1.Controls.Add(Me._BankName)
        Me.Panel1.Controls.Add(Me._BankID)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me._TglPay)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Location = New System.Drawing.Point(308, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(455, 151)
        Me.Panel1.TabIndex = 0
        '
        '_BankName
        '
        Me._BankName.FormattingEnabled = true
        Me._BankName.Items.AddRange(New Object() {"MIZUHO"})
        Me._BankName.Location = New System.Drawing.Point(198, 36)
        Me._BankName.Name = "_BankName"
        Me._BankName.Size = New System.Drawing.Size(229, 21)
        Me._BankName.TabIndex = 96
        Me._BankName.Text = "MIZUHO IDR"
        '
        '_BankID
        '
        Me._BankID.Font = New System.Drawing.Font("Calibri", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me._BankID.FormattingEnabled = true
        Me._BankID.Location = New System.Drawing.Point(118, 36)
        Me._BankID.Name = "_BankID"
        Me._BankID.Size = New System.Drawing.Size(74, 22)
        Me._BankID.TabIndex = 95
        Me._BankID.Text = "11240"
        '
        'Label6
        '
        Me.Label6.AutoSize = true
        Me.Label6.Font = New System.Drawing.Font("Calibri", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label6.Location = New System.Drawing.Point(102, 39)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(10, 14)
        Me.Label6.TabIndex = 94
        Me.Label6.Text = ":"
        '
        'Label7
        '
        Me.Label7.AutoSize = true
        Me.Label7.Font = New System.Drawing.Font("Calibri", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label7.Location = New System.Drawing.Point(11, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 14)
        Me.Label7.TabIndex = 93
        Me.Label7.Text = "BANK"
        '
        '_TglPay
        '
        Me._TglPay.Font = New System.Drawing.Font("Calibri", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me._TglPay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me._TglPay.Location = New System.Drawing.Point(119, 64)
        Me._TglPay.Name = "_TglPay"
        Me._TglPay.Size = New System.Drawing.Size(207, 22)
        Me._TglPay.TabIndex = 92
        Me._TglPay.Value = New Date(2018, 4, 23, 0, 0, 0, 0)
        '
        'Label10
        '
        Me.Label10.AutoSize = true
        Me.Label10.Font = New System.Drawing.Font("Calibri", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label10.Location = New System.Drawing.Point(11, 70)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(83, 14)
        Me.Label10.TabIndex = 90
        Me.Label10.Text = "PAYMENT DATE"
        '
        'Label11
        '
        Me.Label11.AutoSize = true
        Me.Label11.Font = New System.Drawing.Font("Calibri", 9!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0,Byte))
        Me.Label11.Location = New System.Drawing.Point(102, 70)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(10, 14)
        Me.Label11.TabIndex = 91
        Me.Label11.Text = ":"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(382, 101)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(45, 23)
        Me.Button1.TabIndex = 6
        Me.Button1.Text = "OK"
        Me.Button1.UseVisualStyleBackColor = true
        '
        '_gridshipper2
        '
        Me._gridshipper2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridshipper2.Location = New System.Drawing.Point(12, 178)
        Me._gridshipper2.Name = "_gridshipper2"
        Me._gridshipper2.Size = New System.Drawing.Size(1001, 499)
        Me._gridshipper2.TabIndex = 1
        '
        'Button8
        '
        Me.Button8.BackgroundImage = CType(resources.GetObject("Button8.BackgroundImage"),System.Drawing.Image)
        Me.Button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button8.Location = New System.Drawing.Point(780, 103)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(70, 60)
        Me.Button8.TabIndex = 28
        Me.Button8.UseVisualStyleBackColor = true
        Me.Button8.Visible = False
        '
        'frm_bank
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6!, 13!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1027, 680)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me._gridshipper2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "frm_bank"
        Me.Text = "LIST PAYMENT TRANSFER"
        Me.Panel1.ResumeLayout(false)
        Me.Panel1.PerformLayout
        CType(Me._gridshipper2,System.ComponentModel.ISupportInitialize).EndInit
        Me.ResumeLayout(false)

End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents _gridshipper2 As System.Windows.Forms.DataGridView
    Friend WithEvents _BankName As System.Windows.Forms.ComboBox
    Friend WithEvents _BankID As System.Windows.Forms.ComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents _TglPay As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Button8 As System.Windows.Forms.Button
End Class
