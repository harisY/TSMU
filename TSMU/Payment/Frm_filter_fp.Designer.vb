<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Frm_filter_fp
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
        Me._txtcari = New System.Windows.Forms.TextBox()
        Me._cmbcari = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
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
        Me._gridshipper2.TabIndex = 10
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me._txtcari)
        Me.Panel1.Controls.Add(Me._cmbcari)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(526, 41)
        Me.Panel1.TabIndex = 9
        '
        '_txtcari
        '
        Me._txtcari.Location = New System.Drawing.Point(213, 12)
        Me._txtcari.Name = "_txtcari"
        Me._txtcari.Size = New System.Drawing.Size(292, 20)
        Me._txtcari.TabIndex = 10
        '
        '_cmbcari
        '
        Me._cmbcari.FormattingEnabled = True
        Me._cmbcari.Items.AddRange(New Object() {"FPNo", "Vend_Name", "No_Bukti_Potong"})
        Me._cmbcari.Location = New System.Drawing.Point(81, 12)
        Me._cmbcari.Name = "_cmbcari"
        Me._cmbcari.Size = New System.Drawing.Size(126, 21)
        Me._cmbcari.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(7, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Filter"
        '
        'Frm_filter_fp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 293)
        Me.Controls.Add(Me._gridshipper2)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "Frm_filter_fp"
        Me.Text = "Frm_filter_fp"
        CType(Me._gridshipper2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents _gridshipper2 As System.Windows.Forms.DataGridView
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents _txtcari As System.Windows.Forms.TextBox
    Friend WithEvents _cmbcari As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
End Class
