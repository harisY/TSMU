<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_filter_barcode_fp
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
        Me._gridshipper2 = New System.Windows.Forms.DataGridView()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me._tahunpajak = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me._masapajak = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        CType(Me._gridshipper2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        '_gridshipper2
        '
        Me._gridshipper2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me._gridshipper2.Location = New System.Drawing.Point(12, 59)
        Me._gridshipper2.Name = "_gridshipper2"
        Me._gridshipper2.Size = New System.Drawing.Size(678, 222)
        Me._gridshipper2.TabIndex = 12
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me._tahunpajak)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me._masapajak)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(417, 41)
        Me.Panel1.TabIndex = 11
        '
        '_tahunpajak
        '
        Me._tahunpajak.Location = New System.Drawing.Point(270, 10)
        Me._tahunpajak.Name = "_tahunpajak"
        Me._tahunpajak.Size = New System.Drawing.Size(55, 20)
        Me._tahunpajak.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(201, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 13)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Tahun Pajak"
        '
        '_masapajak
        '
        Me._masapajak.Location = New System.Drawing.Point(76, 9)
        Me._masapajak.Name = "_masapajak"
        Me._masapajak.Size = New System.Drawing.Size(55, 20)
        Me._masapajak.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(63, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Masa Pajak"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(447, 22)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "Search"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Frm_filter_barcode_fp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 293)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me._gridshipper2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Frm_filter_barcode_fp"
        Me.Text = "Frm_filter_barcode_fp"
        CType(Me._gridshipper2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents _gridshipper2 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents _masapajak As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents _tahunpajak As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
