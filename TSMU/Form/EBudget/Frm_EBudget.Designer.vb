<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_EBudget
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BCreate = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TtahunCreate = New DevExpress.XtraEditors.TextEdit()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.CSemester = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.BClose = New System.Windows.Forms.Button()
        Me.BOpen = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CTahunOpenBudget = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.LStatus = New System.Windows.Forms.Label()
        Me.LTahun = New System.Windows.Forms.Label()
        Me.LSemester = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.TtahunCreate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.CSemester.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CTahunOpenBudget.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(162, 20)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Create Budget Tahun"
        '
        'BCreate
        '
        Me.BCreate.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BCreate.Location = New System.Drawing.Point(311, 25)
        Me.BCreate.Name = "BCreate"
        Me.BCreate.Size = New System.Drawing.Size(75, 28)
        Me.BCreate.TabIndex = 3
        Me.BCreate.Text = "Create"
        Me.BCreate.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(6, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(153, 20)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Open Budget Tahun"
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TtahunCreate)
        Me.Panel1.Controls.Add(Me.BCreate)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(19, 39)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(421, 80)
        Me.Panel1.TabIndex = 6
        '
        'TtahunCreate
        '
        Me.TtahunCreate.Location = New System.Drawing.Point(185, 27)
        Me.TtahunCreate.Name = "TtahunCreate"
        Me.TtahunCreate.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.TtahunCreate.Properties.Appearance.Options.UseFont = True
        Me.TtahunCreate.Size = New System.Drawing.Size(120, 26)
        Me.TtahunCreate.TabIndex = 4
        '
        'Panel2
        '
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel2.Controls.Add(Me.CSemester)
        Me.Panel2.Controls.Add(Me.BClose)
        Me.Panel2.Controls.Add(Me.BOpen)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.CTahunOpenBudget)
        Me.Panel2.Location = New System.Drawing.Point(19, 140)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(421, 99)
        Me.Panel2.TabIndex = 7
        '
        'CSemester
        '
        Me.CSemester.Location = New System.Drawing.Point(185, 49)
        Me.CSemester.Name = "CSemester"
        Me.CSemester.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CSemester.Properties.Appearance.Options.UseFont = True
        Me.CSemester.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CSemester.Properties.DropDownRows = 3
        Me.CSemester.Properties.Items.AddRange(New Object() {"1", "2"})
        Me.CSemester.Size = New System.Drawing.Size(120, 26)
        Me.CSemester.TabIndex = 12
        '
        'BClose
        '
        Me.BClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BClose.Location = New System.Drawing.Point(311, 54)
        Me.BClose.Name = "BClose"
        Me.BClose.Size = New System.Drawing.Size(75, 28)
        Me.BClose.TabIndex = 10
        Me.BClose.Text = "Close"
        Me.BClose.UseVisualStyleBackColor = True
        '
        'BOpen
        '
        Me.BOpen.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BOpen.Location = New System.Drawing.Point(311, 17)
        Me.BOpen.Name = "BOpen"
        Me.BOpen.Size = New System.Drawing.Size(75, 28)
        Me.BOpen.TabIndex = 9
        Me.BOpen.Text = "Open"
        Me.BOpen.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 20)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Semester"
        '
        'CTahunOpenBudget
        '
        Me.CTahunOpenBudget.Location = New System.Drawing.Point(185, 17)
        Me.CTahunOpenBudget.Name = "CTahunOpenBudget"
        Me.CTahunOpenBudget.Properties.Appearance.Font = New System.Drawing.Font("Tahoma", 12.0!)
        Me.CTahunOpenBudget.Properties.Appearance.Options.UseFont = True
        Me.CTahunOpenBudget.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CTahunOpenBudget.Size = New System.Drawing.Size(120, 26)
        Me.CTahunOpenBudget.TabIndex = 11
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(26, 296)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 20)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Tahun"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(26, 262)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 20)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Status"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(28, 330)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 20)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Semester"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(132, 262)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(13, 20)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = ":"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(132, 296)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(13, 20)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = ":"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(132, 330)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(13, 20)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = ":"
        '
        'LStatus
        '
        Me.LStatus.AutoSize = True
        Me.LStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LStatus.Location = New System.Drawing.Point(166, 262)
        Me.LStatus.Name = "LStatus"
        Me.LStatus.Size = New System.Drawing.Size(14, 20)
        Me.LStatus.TabIndex = 15
        Me.LStatus.Text = "-"
        '
        'LTahun
        '
        Me.LTahun.AutoSize = True
        Me.LTahun.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTahun.Location = New System.Drawing.Point(166, 296)
        Me.LTahun.Name = "LTahun"
        Me.LTahun.Size = New System.Drawing.Size(14, 20)
        Me.LTahun.TabIndex = 16
        Me.LTahun.Text = "-"
        '
        'LSemester
        '
        Me.LSemester.AutoSize = True
        Me.LSemester.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LSemester.Location = New System.Drawing.Point(166, 330)
        Me.LSemester.Name = "LSemester"
        Me.LSemester.Size = New System.Drawing.Size(14, 20)
        Me.LSemester.TabIndex = 17
        Me.LSemester.Text = "-"
        '
        'Frm_EBudget
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(659, 405)
        Me.Controls.Add(Me.LSemester)
        Me.Controls.Add(Me.LTahun)
        Me.Controls.Add(Me.LStatus)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Frm_EBudget"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.LStatus, 0)
        Me.Controls.SetChildIndex(Me.LTahun, 0)
        Me.Controls.SetChildIndex(Me.LSemester, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.TtahunCreate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.CSemester.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CTahunOpenBudget.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents BCreate As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents BClose As Button
    Friend WithEvents BOpen As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents CTahunOpenBudget As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents TtahunCreate As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CSemester As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents LStatus As Label
    Friend WithEvents LTahun As Label
    Friend WithEvents LSemester As Label
End Class
