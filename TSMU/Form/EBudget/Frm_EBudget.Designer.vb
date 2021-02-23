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
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.BApprove = New System.Windows.Forms.Button()
        Me.C_Dept = New DevExpress.XtraEditors.LookUpEdit()
        Me.C_Site_Approve = New DevExpress.XtraEditors.LookUpEdit()
        Me.C_Account_Approve = New DevExpress.XtraEditors.LookUpEdit()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.CTahunApprove = New DevExpress.XtraEditors.LookUpEdit()
        Me.LookUpEdit1 = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.tpersen = New DevExpress.XtraEditors.TextEdit()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        CType(Me.TtahunCreate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        CType(Me.CSemester.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CTahunOpenBudget.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        CType(Me.C_Dept.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_Site_Approve.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_Account_Approve.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CTahunApprove.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.tpersen.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel4.SuspendLayout()
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
        Me.Panel1.Size = New System.Drawing.Size(434, 91)
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
        Me.Panel2.Size = New System.Drawing.Size(434, 129)
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
        Me.BClose.Location = New System.Drawing.Point(311, 49)
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
        Me.Label5.Location = New System.Drawing.Point(15, 54)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(54, 20)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Tahun"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(15, 20)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 20)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Status"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(17, 88)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(78, 20)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Semester"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(121, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(13, 20)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = ":"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(121, 54)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(13, 20)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = ":"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(121, 88)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(13, 20)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = ":"
        '
        'LStatus
        '
        Me.LStatus.AutoSize = True
        Me.LStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LStatus.Location = New System.Drawing.Point(155, 20)
        Me.LStatus.Name = "LStatus"
        Me.LStatus.Size = New System.Drawing.Size(14, 20)
        Me.LStatus.TabIndex = 15
        Me.LStatus.Text = "-"
        '
        'LTahun
        '
        Me.LTahun.AutoSize = True
        Me.LTahun.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LTahun.Location = New System.Drawing.Point(155, 54)
        Me.LTahun.Name = "LTahun"
        Me.LTahun.Size = New System.Drawing.Size(14, 20)
        Me.LTahun.TabIndex = 16
        Me.LTahun.Text = "-"
        '
        'LSemester
        '
        Me.LSemester.AutoSize = True
        Me.LSemester.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LSemester.Location = New System.Drawing.Point(155, 88)
        Me.LSemester.Name = "LSemester"
        Me.LSemester.Size = New System.Drawing.Size(14, 20)
        Me.LSemester.TabIndex = 17
        Me.LSemester.Text = "-"
        '
        'Panel3
        '
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Controls.Add(Me.BApprove)
        Me.Panel3.Controls.Add(Me.C_Dept)
        Me.Panel3.Controls.Add(Me.C_Site_Approve)
        Me.Panel3.Controls.Add(Me.C_Account_Approve)
        Me.Panel3.Controls.Add(Me.Label16)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.Label14)
        Me.Panel3.Controls.Add(Me.Label13)
        Me.Panel3.Controls.Add(Me.Label12)
        Me.Panel3.Controls.Add(Me.Label11)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.CTahunApprove)
        Me.Panel3.Controls.Add(Me.LookUpEdit1)
        Me.Panel3.Controls.Add(Me.tpersen)
        Me.Panel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel3.Location = New System.Drawing.Point(492, 39)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(463, 230)
        Me.Panel3.TabIndex = 18
        '
        'BApprove
        '
        Me.BApprove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BApprove.Location = New System.Drawing.Point(367, 187)
        Me.BApprove.Name = "BApprove"
        Me.BApprove.Size = New System.Drawing.Size(75, 26)
        Me.BApprove.TabIndex = 13
        Me.BApprove.Text = "Approve"
        Me.BApprove.UseVisualStyleBackColor = True
        '
        'C_Dept
        '
        Me.C_Dept.Location = New System.Drawing.Point(126, 158)
        Me.C_Dept.Name = "C_Dept"
        Me.C_Dept.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.C_Dept.Properties.DropDownRows = 20
        Me.C_Dept.Properties.NullText = ""
        Me.C_Dept.Properties.PopupSizeable = False
        Me.C_Dept.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.C_Dept.Size = New System.Drawing.Size(316, 20)
        Me.C_Dept.TabIndex = 11
        '
        'C_Site_Approve
        '
        Me.C_Site_Approve.Location = New System.Drawing.Point(126, 132)
        Me.C_Site_Approve.Name = "C_Site_Approve"
        Me.C_Site_Approve.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.C_Site_Approve.Properties.NullText = ""
        Me.C_Site_Approve.Properties.PopupSizeable = False
        Me.C_Site_Approve.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.C_Site_Approve.Size = New System.Drawing.Size(131, 20)
        Me.C_Site_Approve.TabIndex = 10
        '
        'C_Account_Approve
        '
        Me.C_Account_Approve.Location = New System.Drawing.Point(126, 106)
        Me.C_Account_Approve.Name = "C_Account_Approve"
        Me.C_Account_Approve.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.C_Account_Approve.Properties.DropDownRows = 20
        Me.C_Account_Approve.Properties.NullText = ""
        Me.C_Account_Approve.Properties.PopupSizeable = False
        Me.C_Account_Approve.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.C_Account_Approve.Size = New System.Drawing.Size(316, 20)
        Me.C_Account_Approve.TabIndex = 9
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(30, 179)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(51, 13)
        Me.Label16.TabIndex = 6
        Me.Label16.Text = "Percent"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(30, 155)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(79, 13)
        Me.Label15.TabIndex = 5
        Me.Label15.Text = "Departement"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(30, 132)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(29, 13)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "Site"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(30, 105)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(54, 13)
        Me.Label13.TabIndex = 3
        Me.Label13.Text = "Account"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(30, 81)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Semester"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(30, 57)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Tahun"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(178, 8)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(159, 17)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "APPROVAL BUDGET"
        '
        'CTahunApprove
        '
        Me.CTahunApprove.Location = New System.Drawing.Point(126, 54)
        Me.CTahunApprove.Name = "CTahunApprove"
        Me.CTahunApprove.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CTahunApprove.Properties.NullText = ""
        Me.CTahunApprove.Properties.PopupSizeable = False
        Me.CTahunApprove.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard
        Me.CTahunApprove.Size = New System.Drawing.Size(131, 20)
        Me.CTahunApprove.TabIndex = 7
        '
        'LookUpEdit1
        '
        Me.LookUpEdit1.Location = New System.Drawing.Point(126, 80)
        Me.LookUpEdit1.Name = "LookUpEdit1"
        Me.LookUpEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.LookUpEdit1.Properties.DropDownRows = 4
        Me.LookUpEdit1.Properties.Items.AddRange(New Object() {"1", "2"})
        Me.LookUpEdit1.Size = New System.Drawing.Size(131, 20)
        Me.LookUpEdit1.TabIndex = 8
        '
        'tpersen
        '
        Me.tpersen.Location = New System.Drawing.Point(126, 184)
        Me.tpersen.Name = "tpersen"
        Me.tpersen.Size = New System.Drawing.Size(131, 20)
        Me.tpersen.TabIndex = 12
        '
        'Panel4
        '
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.LSemester)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.LTahun)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.LStatus)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Location = New System.Drawing.Point(19, 275)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(434, 128)
        Me.Panel4.TabIndex = 19
        '
        'Frm_EBudget
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1261, 478)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Frm_EBudget"
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.Panel3, 0)
        Me.Controls.SetChildIndex(Me.Panel4, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.TtahunCreate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.CSemester.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CTahunOpenBudget.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.C_Dept.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_Site_Approve.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_Account_Approve.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CTahunApprove.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.tpersen.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
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
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents CTahunApprove As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents C_Dept As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents C_Site_Approve As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents C_Account_Approve As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LookUpEdit1 As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents BApprove As Button
    Friend WithEvents tpersen As DevExpress.XtraEditors.TextEdit
End Class
