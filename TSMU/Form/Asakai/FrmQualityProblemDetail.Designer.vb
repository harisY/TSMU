<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmQualityProblemDetail
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
        Me.Grid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Shift = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Customer = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.InvtId = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.InvtName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Qty = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Problem = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Analisis = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CorrectionAction = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PreventiveAction = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Pic = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Target = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Gambar = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepositoryItemTextEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.RepositoryItemDateEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.RepositoryItemDateEdit2 = New DevExpress.XtraEditors.Repository.RepositoryItemDateEdit()
        Me.BAdd = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TxtPic = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TxtStatus = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtQty = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtType = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtInvtName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtInvtID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.DtTanggalLaporan = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtCustomer = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CmbShift = New System.Windows.Forms.ComboBox()
        Me.TxtProblem = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtAnalisis = New System.Windows.Forms.TextBox()
        Me.DtTarget = New System.Windows.Forms.DateTimePicker()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.TxtPreventive = New System.Windows.Forms.TextBox()
        Me.TxtCorrection = New System.Windows.Forms.TextBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.BGambar = New System.Windows.Forms.Button()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.Location = New System.Drawing.Point(12, 208)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Name = "Grid"
        Me.Grid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.RepositoryItemTextEdit1, Me.RepositoryItemDateEdit1, Me.RepositoryItemDateEdit2})
        Me.Grid.Size = New System.Drawing.Size(1306, 361)
        Me.Grid.TabIndex = 26
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Shift, Me.Status, Me.Customer, Me.InvtId, Me.InvtName, Me.Type, Me.Qty, Me.Problem, Me.Analisis, Me.CorrectionAction, Me.PreventiveAction, Me.Pic, Me.Target, Me.Gambar})
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        '
        'Shift
        '
        Me.Shift.FieldName = "Shift"
        Me.Shift.Name = "Shift"
        Me.Shift.Visible = True
        Me.Shift.VisibleIndex = 0
        '
        'Status
        '
        Me.Status.FieldName = "Status"
        Me.Status.Name = "Status"
        Me.Status.Visible = True
        Me.Status.VisibleIndex = 1
        '
        'Customer
        '
        Me.Customer.FieldName = "Customer"
        Me.Customer.Name = "Customer"
        Me.Customer.Visible = True
        Me.Customer.VisibleIndex = 2
        '
        'InvtId
        '
        Me.InvtId.FieldName = "InvtId"
        Me.InvtId.Name = "InvtId"
        Me.InvtId.Visible = True
        Me.InvtId.VisibleIndex = 3
        '
        'InvtName
        '
        Me.InvtName.FieldName = "InvtName"
        Me.InvtName.Name = "InvtName"
        Me.InvtName.Visible = True
        Me.InvtName.VisibleIndex = 4
        '
        'Type
        '
        Me.Type.FieldName = "Type"
        Me.Type.Name = "Type"
        Me.Type.Visible = True
        Me.Type.VisibleIndex = 5
        '
        'Qty
        '
        Me.Qty.FieldName = "Qty"
        Me.Qty.Name = "Qty"
        Me.Qty.Visible = True
        Me.Qty.VisibleIndex = 6
        '
        'Problem
        '
        Me.Problem.FieldName = "Problem"
        Me.Problem.Name = "Problem"
        Me.Problem.Visible = True
        Me.Problem.VisibleIndex = 7
        '
        'Analisis
        '
        Me.Analisis.FieldName = "Analisis"
        Me.Analisis.Name = "Analisis"
        Me.Analisis.Visible = True
        Me.Analisis.VisibleIndex = 8
        '
        'CorrectionAction
        '
        Me.CorrectionAction.FieldName = "Correction Action"
        Me.CorrectionAction.Name = "CorrectionAction"
        Me.CorrectionAction.Visible = True
        Me.CorrectionAction.VisibleIndex = 9
        '
        'PreventiveAction
        '
        Me.PreventiveAction.FieldName = "Preventive Action"
        Me.PreventiveAction.Name = "PreventiveAction"
        Me.PreventiveAction.Visible = True
        Me.PreventiveAction.VisibleIndex = 10
        '
        'Pic
        '
        Me.Pic.FieldName = "Pic"
        Me.Pic.Name = "Pic"
        Me.Pic.Visible = True
        Me.Pic.VisibleIndex = 11
        '
        'Target
        '
        Me.Target.FieldName = "Target"
        Me.Target.Name = "Target"
        Me.Target.Visible = True
        Me.Target.VisibleIndex = 12
        '
        'Gambar
        '
        Me.Gambar.FieldName = "Gambar"
        Me.Gambar.Name = "Gambar"
        Me.Gambar.Visible = True
        Me.Gambar.VisibleIndex = 13
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
        'BAdd
        '
        Me.BAdd.Location = New System.Drawing.Point(12, 179)
        Me.BAdd.Name = "BAdd"
        Me.BAdd.Size = New System.Drawing.Size(84, 23)
        Me.BAdd.TabIndex = 87
        Me.BAdd.Text = "Add"
        Me.BAdd.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(257, 143)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 13)
        Me.Label11.TabIndex = 84
        Me.Label11.Text = "Target"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(257, 117)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(24, 13)
        Me.Label12.TabIndex = 82
        Me.Label12.Text = "PIC"
        '
        'TxtPic
        '
        Me.TxtPic.Location = New System.Drawing.Point(316, 117)
        Me.TxtPic.Name = "TxtPic"
        Me.TxtPic.Size = New System.Drawing.Size(154, 20)
        Me.TxtPic.TabIndex = 81
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(9, 64)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(37, 13)
        Me.Label13.TabIndex = 80
        Me.Label13.Text = "Status"
        '
        'TxtStatus
        '
        Me.TxtStatus.Location = New System.Drawing.Point(76, 64)
        Me.TxtStatus.Name = "TxtStatus"
        Me.TxtStatus.Size = New System.Drawing.Size(154, 20)
        Me.TxtStatus.TabIndex = 77
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(257, 90)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(23, 13)
        Me.Label6.TabIndex = 76
        Me.Label6.Text = "Qty"
        '
        'TxtQty
        '
        Me.TxtQty.Location = New System.Drawing.Point(316, 90)
        Me.TxtQty.Name = "TxtQty"
        Me.TxtQty.Size = New System.Drawing.Size(154, 20)
        Me.TxtQty.TabIndex = 75
        Me.TxtQty.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(257, 64)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 13)
        Me.Label5.TabIndex = 74
        Me.Label5.Text = "Type"
        '
        'TxtType
        '
        Me.TxtType.Location = New System.Drawing.Point(316, 64)
        Me.TxtType.Name = "TxtType"
        Me.TxtType.Size = New System.Drawing.Size(154, 20)
        Me.TxtType.TabIndex = 73
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 143)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 13)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = "Invt Name"
        '
        'TxtInvtName
        '
        Me.TxtInvtName.Location = New System.Drawing.Point(76, 143)
        Me.TxtInvtName.Name = "TxtInvtName"
        Me.TxtInvtName.Size = New System.Drawing.Size(154, 20)
        Me.TxtInvtName.TabIndex = 71
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Invt Id"
        '
        'TxtInvtID
        '
        Me.TxtInvtID.Location = New System.Drawing.Point(76, 117)
        Me.TxtInvtID.Name = "TxtInvtID"
        Me.TxtInvtID.Size = New System.Drawing.Size(154, 20)
        Me.TxtInvtID.TabIndex = 69
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 90)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(51, 13)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Customer"
        '
        'DtTanggalLaporan
        '
        Me.DtTanggalLaporan.CustomFormat = "dd-MM-yyyy"
        Me.DtTanggalLaporan.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtTanggalLaporan.Location = New System.Drawing.Point(76, 39)
        Me.DtTanggalLaporan.Name = "DtTanggalLaporan"
        Me.DtTanggalLaporan.Size = New System.Drawing.Size(154, 20)
        Me.DtTanggalLaporan.TabIndex = 67
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 13)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "Tanggal "
        '
        'TxtCustomer
        '
        Me.TxtCustomer.Location = New System.Drawing.Point(76, 90)
        Me.TxtCustomer.Name = "TxtCustomer"
        Me.TxtCustomer.Size = New System.Drawing.Size(154, 20)
        Me.TxtCustomer.TabIndex = 65
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(257, 39)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 13)
        Me.Label8.TabIndex = 88
        Me.Label8.Text = "Shift"
        '
        'CmbShift
        '
        Me.CmbShift.FormattingEnabled = True
        Me.CmbShift.Items.AddRange(New Object() {"1", "2", "3"})
        Me.CmbShift.Location = New System.Drawing.Point(316, 37)
        Me.CmbShift.Name = "CmbShift"
        Me.CmbShift.Size = New System.Drawing.Size(154, 21)
        Me.CmbShift.TabIndex = 89
        '
        'TxtProblem
        '
        Me.TxtProblem.Location = New System.Drawing.Point(549, 36)
        Me.TxtProblem.Multiline = True
        Me.TxtProblem.Name = "TxtProblem"
        Me.TxtProblem.Size = New System.Drawing.Size(192, 60)
        Me.TxtProblem.TabIndex = 90
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(489, 54)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(45, 13)
        Me.Label7.TabIndex = 94
        Me.Label7.Text = "Problem"
        '
        'TxtAnalisis
        '
        Me.TxtAnalisis.Location = New System.Drawing.Point(549, 106)
        Me.TxtAnalisis.Multiline = True
        Me.TxtAnalisis.Name = "TxtAnalisis"
        Me.TxtAnalisis.Size = New System.Drawing.Size(192, 60)
        Me.TxtAnalisis.TabIndex = 93
        '
        'DtTarget
        '
        Me.DtTarget.CustomFormat = "dd-MM-yyyy"
        Me.DtTarget.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtTarget.Location = New System.Drawing.Point(316, 143)
        Me.DtTarget.Name = "DtTarget"
        Me.DtTarget.Size = New System.Drawing.Size(154, 20)
        Me.DtTarget.TabIndex = 95
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(492, 127)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(42, 13)
        Me.Label10.TabIndex = 96
        Me.Label10.Text = "Analisis"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(773, 127)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 13)
        Me.Label9.TabIndex = 100
        Me.Label9.Text = "Preventive Action"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(771, 54)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(88, 13)
        Me.Label14.TabIndex = 99
        Me.Label14.Text = "Correction Action"
        '
        'TxtPreventive
        '
        Me.TxtPreventive.Location = New System.Drawing.Point(886, 106)
        Me.TxtPreventive.Multiline = True
        Me.TxtPreventive.Name = "TxtPreventive"
        Me.TxtPreventive.Size = New System.Drawing.Size(192, 60)
        Me.TxtPreventive.TabIndex = 98
        '
        'TxtCorrection
        '
        Me.TxtCorrection.Location = New System.Drawing.Point(886, 36)
        Me.TxtCorrection.Multiline = True
        Me.TxtCorrection.Name = "TxtCorrection"
        Me.TxtCorrection.Size = New System.Drawing.Size(192, 60)
        Me.TxtCorrection.TabIndex = 97
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(1112, 36)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(148, 94)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 101
        Me.PictureBox1.TabStop = False
        '
        'BGambar
        '
        Me.BGambar.Location = New System.Drawing.Point(1149, 140)
        Me.BGambar.Name = "BGambar"
        Me.BGambar.Size = New System.Drawing.Size(75, 23)
        Me.BGambar.TabIndex = 102
        Me.BGambar.Text = "Cari Gambar"
        Me.BGambar.UseVisualStyleBackColor = True
        '
        'FrmQualityProblemDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1330, 581)
        Me.Controls.Add(Me.BGambar)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.TxtPreventive)
        Me.Controls.Add(Me.TxtCorrection)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.DtTarget)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtAnalisis)
        Me.Controls.Add(Me.TxtProblem)
        Me.Controls.Add(Me.CmbShift)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.BAdd)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.TxtPic)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.TxtStatus)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtQty)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtType)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtInvtName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtInvtID)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DtTanggalLaporan)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtCustomer)
        Me.Controls.Add(Me.Grid)
        Me.Name = "FrmQualityProblemDetail"
        Me.Controls.SetChildIndex(Me.Grid, 0)
        Me.Controls.SetChildIndex(Me.TxtCustomer, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.DtTanggalLaporan, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.TxtInvtID, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.TxtInvtName, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.TxtType, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.TxtQty, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.TxtStatus, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.TxtPic, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.BAdd, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.CmbShift, 0)
        Me.Controls.SetChildIndex(Me.TxtProblem, 0)
        Me.Controls.SetChildIndex(Me.TxtAnalisis, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.DtTarget, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.TxtCorrection, 0)
        Me.Controls.SetChildIndex(Me.TxtPreventive, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.BGambar, 0)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemTextEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit2.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepositoryItemDateEdit2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents RepositoryItemTextEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents RepositoryItemDateEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents RepositoryItemDateEdit2 As DevExpress.XtraEditors.Repository.RepositoryItemDateEdit
    Friend WithEvents BAdd As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents TxtPic As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents TxtStatus As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtQty As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtType As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtInvtName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtInvtID As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents DtTanggalLaporan As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtCustomer As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents CmbShift As ComboBox
    Friend WithEvents TxtProblem As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtAnalisis As TextBox
    Friend WithEvents DtTarget As DateTimePicker
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents TxtPreventive As TextBox
    Friend WithEvents TxtCorrection As TextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Shift As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Customer As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents InvtId As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents InvtName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Qty As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Problem As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Analisis As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CorrectionAction As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PreventiveAction As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Pic As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Target As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Gambar As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BGambar As Button
End Class
