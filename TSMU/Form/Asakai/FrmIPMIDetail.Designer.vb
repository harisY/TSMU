<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmIPMIDetail
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
        Me.TxtNoIpmi = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TxtPartNo = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TxtPartName = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TxtQty = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.TxtProblem = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TxtDibuat = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TxtMengetahui = New System.Windows.Forms.TextBox()
        Me.Grid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Perbaikan = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Target = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.PIC = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TxtAnalisa = New System.Windows.Forms.TextBox()
        Me.TxtPerbaikan = New System.Windows.Forms.TextBox()
        Me.TxtPIC = New System.Windows.Forms.TextBox()
        Me.Tambah = New System.Windows.Forms.Button()
        Me.DtTanggalLaporan = New System.Windows.Forms.DateTimePicker()
        Me.DtTarget = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GridPenyebab = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.Penyebab = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.AddPenyebab = New System.Windows.Forms.Button()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridPenyebab, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TxtNoIpmi
        '
        Me.TxtNoIpmi.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtNoIpmi.Location = New System.Drawing.Point(173, 74)
        Me.TxtNoIpmi.Name = "TxtNoIpmi"
        Me.TxtNoIpmi.Size = New System.Drawing.Size(388, 20)
        Me.TxtNoIpmi.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 74)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "NO IPMI"
        '
        'TxtPartNo
        '
        Me.TxtPartNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPartNo.Location = New System.Drawing.Point(173, 104)
        Me.TxtPartNo.Name = "TxtPartNo"
        Me.TxtPartNo.Size = New System.Drawing.Size(155, 20)
        Me.TxtPartNo.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(21, 107)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "PART NO/NAME"
        '
        'TxtPartName
        '
        Me.TxtPartName.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPartName.Location = New System.Drawing.Point(334, 104)
        Me.TxtPartName.Name = "TxtPartName"
        Me.TxtPartName.Size = New System.Drawing.Size(227, 20)
        Me.TxtPartName.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(21, 134)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(29, 13)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "QTY"
        '
        'TxtQty
        '
        Me.TxtQty.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtQty.Location = New System.Drawing.Point(173, 134)
        Me.TxtQty.Name = "TxtQty"
        Me.TxtQty.Size = New System.Drawing.Size(155, 20)
        Me.TxtQty.TabIndex = 7
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(21, 229)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "PROBLEM"
        '
        'TxtProblem
        '
        Me.TxtProblem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtProblem.Location = New System.Drawing.Point(173, 215)
        Me.TxtProblem.Multiline = True
        Me.TxtProblem.Name = "TxtProblem"
        Me.TxtProblem.Size = New System.Drawing.Size(388, 61)
        Me.TxtProblem.TabIndex = 9
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 160)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "DIBUAT"
        '
        'TxtDibuat
        '
        Me.TxtDibuat.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtDibuat.Location = New System.Drawing.Point(173, 160)
        Me.TxtDibuat.Name = "TxtDibuat"
        Me.TxtDibuat.Size = New System.Drawing.Size(155, 20)
        Me.TxtDibuat.TabIndex = 11
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(21, 192)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(79, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "MENGETAHUI"
        '
        'TxtMengetahui
        '
        Me.TxtMengetahui.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtMengetahui.Location = New System.Drawing.Point(173, 189)
        Me.TxtMengetahui.Name = "TxtMengetahui"
        Me.TxtMengetahui.Size = New System.Drawing.Size(155, 20)
        Me.TxtMengetahui.TabIndex = 13
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Grid.Location = New System.Drawing.Point(445, 320)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Name = "Grid"
        Me.Grid.Size = New System.Drawing.Size(827, 208)
        Me.Grid.TabIndex = 15
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Perbaikan, Me.Target, Me.PIC})
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'Perbaikan
        '
        Me.Perbaikan.FieldName = "Rencana Perbaikan"
        Me.Perbaikan.Name = "Perbaikan"
        Me.Perbaikan.Visible = True
        Me.Perbaikan.VisibleIndex = 0
        Me.Perbaikan.Width = 575
        '
        'Target
        '
        Me.Target.FieldName = "Target"
        Me.Target.Name = "Target"
        Me.Target.Visible = True
        Me.Target.VisibleIndex = 1
        Me.Target.Width = 177
        '
        'PIC
        '
        Me.PIC.FieldName = "PIC"
        Me.PIC.Name = "PIC"
        Me.PIC.Visible = True
        Me.PIC.VisibleIndex = 2
        Me.PIC.Width = 138
        '
        'TxtAnalisa
        '
        Me.TxtAnalisa.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtAnalisa.Location = New System.Drawing.Point(67, 290)
        Me.TxtAnalisa.Name = "TxtAnalisa"
        Me.TxtAnalisa.Size = New System.Drawing.Size(353, 20)
        Me.TxtAnalisa.TabIndex = 16
        '
        'TxtPerbaikan
        '
        Me.TxtPerbaikan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPerbaikan.Location = New System.Drawing.Point(501, 290)
        Me.TxtPerbaikan.Name = "TxtPerbaikan"
        Me.TxtPerbaikan.Size = New System.Drawing.Size(530, 20)
        Me.TxtPerbaikan.TabIndex = 17
        '
        'TxtPIC
        '
        Me.TxtPIC.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TxtPIC.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPIC.Location = New System.Drawing.Point(1218, 287)
        Me.TxtPIC.Name = "TxtPIC"
        Me.TxtPIC.Size = New System.Drawing.Size(54, 20)
        Me.TxtPIC.TabIndex = 19
        '
        'Tambah
        '
        Me.Tambah.Location = New System.Drawing.Point(445, 290)
        Me.Tambah.Name = "Tambah"
        Me.Tambah.Size = New System.Drawing.Size(50, 21)
        Me.Tambah.TabIndex = 20
        Me.Tambah.Text = "+"
        Me.Tambah.UseVisualStyleBackColor = True
        '
        'DtTanggalLaporan
        '
        Me.DtTanggalLaporan.CustomFormat = "dd-MM-yyyy"
        Me.DtTanggalLaporan.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtTanggalLaporan.Location = New System.Drawing.Point(173, 42)
        Me.DtTanggalLaporan.Name = "DtTanggalLaporan"
        Me.DtTanggalLaporan.Size = New System.Drawing.Size(116, 20)
        Me.DtTanggalLaporan.TabIndex = 68
        '
        'DtTarget
        '
        Me.DtTarget.CustomFormat = "dd-MM-yyyy"
        Me.DtTarget.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DtTarget.Location = New System.Drawing.Point(1049, 287)
        Me.DtTarget.Name = "DtTarget"
        Me.DtTarget.Size = New System.Drawing.Size(163, 20)
        Me.DtTarget.TabIndex = 69
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 13)
        Me.Label2.TabIndex = 70
        Me.Label2.Text = "TANGGAL"
        '
        'GridPenyebab
        '
        Me.GridPenyebab.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.GridPenyebab.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GridPenyebab.Location = New System.Drawing.Point(11, 320)
        Me.GridPenyebab.MainView = Me.GridView2
        Me.GridPenyebab.Name = "GridPenyebab"
        Me.GridPenyebab.Size = New System.Drawing.Size(409, 208)
        Me.GridPenyebab.TabIndex = 71
        Me.GridPenyebab.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.AutoFillColumn = Me.Penyebab
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.Penyebab})
        Me.GridView2.GridControl = Me.GridPenyebab
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsView.ColumnAutoWidth = False
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'Penyebab
        '
        Me.Penyebab.FieldName = "Penyebab 4M Analisa"
        Me.Penyebab.Name = "Penyebab"
        Me.Penyebab.Visible = True
        Me.Penyebab.VisibleIndex = 0
        Me.Penyebab.Width = 354
        '
        'AddPenyebab
        '
        Me.AddPenyebab.Location = New System.Drawing.Point(11, 290)
        Me.AddPenyebab.Name = "AddPenyebab"
        Me.AddPenyebab.Size = New System.Drawing.Size(50, 20)
        Me.AddPenyebab.TabIndex = 72
        Me.AddPenyebab.Text = "+"
        Me.AddPenyebab.UseVisualStyleBackColor = True
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox1.Location = New System.Drawing.Point(649, 74)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(234, 202)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 73
        Me.PictureBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(649, 42)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(234, 26)
        Me.Button1.TabIndex = 74
        Me.Button1.Text = "Cari Gambar"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'FrmIPMIDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(1273, 581)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.AddPenyebab)
        Me.Controls.Add(Me.GridPenyebab)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DtTarget)
        Me.Controls.Add(Me.DtTanggalLaporan)
        Me.Controls.Add(Me.Tambah)
        Me.Controls.Add(Me.TxtPIC)
        Me.Controls.Add(Me.TxtPerbaikan)
        Me.Controls.Add(Me.TxtAnalisa)
        Me.Controls.Add(Me.Grid)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.TxtMengetahui)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtDibuat)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TxtProblem)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.TxtQty)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtPartName)
        Me.Controls.Add(Me.TxtPartNo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TxtNoIpmi)
        Me.Name = "FrmIPMIDetail"
        Me.Controls.SetChildIndex(Me.TxtNoIpmi, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.TxtPartNo, 0)
        Me.Controls.SetChildIndex(Me.TxtPartName, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.TxtQty, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.TxtProblem, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.TxtDibuat, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.TxtMengetahui, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.Grid, 0)
        Me.Controls.SetChildIndex(Me.TxtAnalisa, 0)
        Me.Controls.SetChildIndex(Me.TxtPerbaikan, 0)
        Me.Controls.SetChildIndex(Me.TxtPIC, 0)
        Me.Controls.SetChildIndex(Me.Tambah, 0)
        Me.Controls.SetChildIndex(Me.DtTanggalLaporan, 0)
        Me.Controls.SetChildIndex(Me.DtTarget, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.GridPenyebab, 0)
        Me.Controls.SetChildIndex(Me.AddPenyebab, 0)
        Me.Controls.SetChildIndex(Me.PictureBox1, 0)
        Me.Controls.SetChildIndex(Me.Button1, 0)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridPenyebab, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TxtNoIpmi As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TxtPartNo As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents TxtPartName As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents TxtQty As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TxtProblem As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents TxtDibuat As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents TxtMengetahui As TextBox
    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Perbaikan As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Target As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents PIC As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TxtAnalisa As TextBox
    Friend WithEvents TxtPerbaikan As TextBox
    Friend WithEvents TxtPIC As TextBox
    Friend WithEvents Tambah As Button
    Friend WithEvents DtTanggalLaporan As DateTimePicker
    Friend WithEvents DtTarget As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents GridPenyebab As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents Penyebab As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents AddPenyebab As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Button1 As Button
End Class
