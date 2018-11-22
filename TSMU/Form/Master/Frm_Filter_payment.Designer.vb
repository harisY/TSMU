<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_Filter_payment
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Frm_Filter_payment))
        Me._gridshipper2 = New System.Windows.Forms.DataGridView()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.dt2 = New System.Windows.Forms.DateTimePicker()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.dt1 = New System.Windows.Forms.DateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Button9 = New System.Windows.Forms.Button()
        Me._Vend_Name1 = New System.Windows.Forms.ComboBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.dt1a = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dt2a = New System.Windows.Forms.DateTimePicker()
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me._vrno = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.Button6 = New System.Windows.Forms.Button()
        Me._Vend_Name = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Button8 = New System.Windows.Forms.Button()
        CType(Me._gridshipper2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.SuspendLayout()
        '
        '_gridshipper2
        '
        Me._gridshipper2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridshipper2.Location = New System.Drawing.Point(12, 92)
        Me._gridshipper2.Name = "_gridshipper2"
        Me._gridshipper2.Size = New System.Drawing.Size(1096, 552)
        Me._gridshipper2.TabIndex = 15
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(1079, 12)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(29, 24)
        Me.Button3.TabIndex = 17
        Me.Button3.UseVisualStyleBackColor = True
        Me.Button3.Visible = False
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1030, 12)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(43, 38)
        Me.Button2.TabIndex = 16
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(857, 74)
        Me.TabControl1.TabIndex = 20
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Button1)
        Me.TabPage2.Controls.Add(Me.dt2)
        Me.TabPage2.Controls.Add(Me.Button4)
        Me.TabPage2.Controls.Add(Me.dt1)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(849, 48)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Filter By Tanggal"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.Location = New System.Drawing.Point(457, 12)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(35, 30)
        Me.Button1.TabIndex = 27
        Me.Button1.UseVisualStyleBackColor = True
        '
        'dt2
        '
        Me.dt2.CustomFormat = "dd/MM/yyyy"
        Me.dt2.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt2.Location = New System.Drawing.Point(263, 18)
        Me.dt2.Name = "dt2"
        Me.dt2.Size = New System.Drawing.Size(129, 20)
        Me.dt2.TabIndex = 24
        '
        'Button4
        '
        Me.Button4.BackColor = System.Drawing.SystemColors.Control
        Me.Button4.BackgroundImage = CType(resources.GetObject("Button4.BackgroundImage"), System.Drawing.Image)
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button4.Location = New System.Drawing.Point(415, 12)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(36, 30)
        Me.Button4.TabIndex = 25
        Me.Button4.UseVisualStyleBackColor = False
        '
        'dt1
        '
        Me.dt1.CustomFormat = "dd/MM/yyyy"
        Me.dt1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt1.Location = New System.Drawing.Point(88, 19)
        Me.dt1.Name = "dt1"
        Me.dt1.Size = New System.Drawing.Size(122, 20)
        Me.dt1.TabIndex = 23
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(5, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 13)
        Me.Label7.TabIndex = 21
        Me.Label7.Text = "Dari Tanggal"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(225, 23)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(23, 13)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "s/d"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Button9)
        Me.TabPage3.Controls.Add(Me._Vend_Name1)
        Me.TabPage3.Controls.Add(Me.Button5)
        Me.TabPage3.Controls.Add(Me.dt1a)
        Me.TabPage3.Controls.Add(Me.Label4)
        Me.TabPage3.Controls.Add(Me.Label6)
        Me.TabPage3.Controls.Add(Me.Label5)
        Me.TabPage3.Controls.Add(Me.dt2a)
        Me.TabPage3.Location = New System.Drawing.Point(4, 22)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(849, 48)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Filter By Tanggal & Supplier"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.BackgroundImage = CType(resources.GetObject("Button9.BackgroundImage"), System.Drawing.Image)
        Me.Button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button9.Location = New System.Drawing.Point(784, 12)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(36, 28)
        Me.Button9.TabIndex = 40
        Me.Button9.UseVisualStyleBackColor = True
        '
        '_Vend_Name1
        '
        Me._Vend_Name1.FormattingEnabled = True
        Me._Vend_Name1.Items.AddRange(New Object() {"ALL"})
        Me._Vend_Name1.Location = New System.Drawing.Point(454, 17)
        Me._Vend_Name1.Name = "_Vend_Name1"
        Me._Vend_Name1.Size = New System.Drawing.Size(270, 21)
        Me._Vend_Name1.TabIndex = 39
        Me._Vend_Name1.Text = "ALL"
        '
        'Button5
        '
        Me.Button5.BackColor = System.Drawing.SystemColors.Control
        Me.Button5.BackgroundImage = CType(resources.GetObject("Button5.BackgroundImage"), System.Drawing.Image)
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button5.Location = New System.Drawing.Point(744, 12)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(34, 28)
        Me.Button5.TabIndex = 37
        Me.Button5.UseVisualStyleBackColor = False
        '
        'dt1a
        '
        Me.dt1a.CustomFormat = "dd/MM/yyyy"
        Me.dt1a.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt1a.Location = New System.Drawing.Point(88, 17)
        Me.dt1a.Name = "dt1a"
        Me.dt1a.Size = New System.Drawing.Size(115, 20)
        Me.dt1a.TabIndex = 35
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(403, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 13)
        Me.Label4.TabIndex = 38
        Me.Label4.Text = "Supplier"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(218, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 13)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "s/d"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 23)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 13)
        Me.Label5.TabIndex = 33
        Me.Label5.Text = "Dari Tanggal"
        '
        'dt2a
        '
        Me.dt2a.CustomFormat = "dd/MM/yyyy"
        Me.dt2a.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dt2a.Location = New System.Drawing.Point(256, 16)
        Me.dt2a.Name = "dt2a"
        Me.dt2a.Size = New System.Drawing.Size(126, 20)
        Me.dt2a.TabIndex = 36
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me._vrno)
        Me.TabPage4.Controls.Add(Me.Label9)
        Me.TabPage4.Controls.Add(Me.Button7)
        Me.TabPage4.Location = New System.Drawing.Point(4, 22)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(849, 48)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        '_vrno
        '
        Me._vrno.Location = New System.Drawing.Point(137, 44)
        Me._vrno.Name = "_vrno"
        Me._vrno.Size = New System.Drawing.Size(260, 20)
        Me._vrno.TabIndex = 30
        Me._vrno.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(54, 47)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 13)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "No. Voucher"
        Me.Label9.Visible = False
        '
        'Button7
        '
        Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button7.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button7.Location = New System.Drawing.Point(515, 23)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(74, 60)
        Me.Button7.TabIndex = 28
        Me.Button7.UseVisualStyleBackColor = False
        Me.Button7.Visible = False
        '
        'TabPage5
        '
        Me.TabPage5.Controls.Add(Me.Button6)
        Me.TabPage5.Controls.Add(Me._Vend_Name)
        Me.TabPage5.Controls.Add(Me.Label10)
        Me.TabPage5.Location = New System.Drawing.Point(4, 22)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(849, 48)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button6.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button6.Location = New System.Drawing.Point(546, 25)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(74, 60)
        Me.Button6.TabIndex = 25
        Me.Button6.UseVisualStyleBackColor = False
        Me.Button6.Visible = False
        '
        '_Vend_Name
        '
        Me._Vend_Name.FormattingEnabled = True
        Me._Vend_Name.Location = New System.Drawing.Point(152, 49)
        Me._Vend_Name.Name = "_Vend_Name"
        Me._Vend_Name.Size = New System.Drawing.Size(270, 21)
        Me._Vend_Name.TabIndex = 24
        Me._Vend_Name.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(97, 52)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(45, 13)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "Supplier"
        Me.Label10.Visible = False
        '
        'Button8
        '
        Me.Button8.BackgroundImage = CType(resources.GetObject("Button8.BackgroundImage"), System.Drawing.Image)
        Me.Button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button8.Location = New System.Drawing.Point(1064, 44)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(44, 39)
        Me.Button8.TabIndex = 26
        Me.Button8.UseVisualStyleBackColor = True
        Me.Button8.Visible = False
        '
        'Frm_Filter_payment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1120, 650)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me._gridshipper2)
        Me.Name = "Frm_Filter_payment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Voucher List"
        CType(Me._gridshipper2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents _gridshipper2 As System.Windows.Forms.DataGridView
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents dt2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dt1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents _Vend_Name1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents dt2a As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dt1a As System.Windows.Forms.DateTimePicker
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents _vrno As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents _Vend_Name As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
End Class
