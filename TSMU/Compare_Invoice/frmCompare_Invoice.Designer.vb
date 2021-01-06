<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCompare_Invoice
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
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me._cekbalance = New System.Windows.Forms.CheckBox()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DataGridView2 = New System.Windows.Forms.DataGridView()
        Me._cmbperpost = New System.Windows.Forms.ComboBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtFileLocation = New System.Windows.Forms.TextBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.OpenFileDialog2 = New System.Windows.Forms.OpenFileDialog()
        Me.Button6 = New System.Windows.Forms.Button()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(1451, 25)
        Me.Button5.Margin = New System.Windows.Forms.Padding(4)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(100, 30)
        Me.Button5.TabIndex = 33
        Me.Button5.Text = "Nota Return"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(1304, 25)
        Me.Button2.Margin = New System.Windows.Forms.Padding(4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(100, 30)
        Me.Button2.TabIndex = 32
        Me.Button2.Text = "View"
        Me.Button2.UseVisualStyleBackColor = True
        '
        '_cekbalance
        '
        Me._cekbalance.AutoSize = True
        Me._cekbalance.Checked = True
        Me._cekbalance.CheckState = System.Windows.Forms.CheckState.Checked
        Me._cekbalance.Location = New System.Drawing.Point(1157, 33)
        Me._cekbalance.Margin = New System.Windows.Forms.Padding(4)
        Me._cekbalance.Name = "_cekbalance"
        Me._cekbalance.Size = New System.Drawing.Size(81, 21)
        Me._cekbalance.TabIndex = 31
        Me._cekbalance.Text = "Balance"
        Me._cekbalance.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(476, 65)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.Size = New System.Drawing.Size(1316, 766)
        Me.DataGridView1.TabIndex = 30
        '
        'DataGridView2
        '
        Me.DataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView2.Location = New System.Drawing.Point(29, 64)
        Me.DataGridView2.Margin = New System.Windows.Forms.Padding(4)
        Me.DataGridView2.Name = "DataGridView2"
        Me.DataGridView2.Size = New System.Drawing.Size(439, 766)
        Me.DataGridView2.TabIndex = 29
        '
        '_cmbperpost
        '
        Me._cmbperpost.FormattingEnabled = True
        Me._cmbperpost.Location = New System.Drawing.Point(1021, 30)
        Me._cmbperpost.Margin = New System.Windows.Forms.Padding(4)
        Me._cmbperpost.Name = "_cmbperpost"
        Me._cmbperpost.Size = New System.Drawing.Size(95, 25)
        Me._cmbperpost.TabIndex = 28
        Me._cmbperpost.Text = "201811"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(893, 30)
        Me.Button1.Margin = New System.Windows.Forms.Padding(4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 30)
        Me.Button1.TabIndex = 27
        Me.Button1.Text = "Proses"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtFileLocation
        '
        Me.txtFileLocation.Location = New System.Drawing.Point(29, 30)
        Me.txtFileLocation.Margin = New System.Windows.Forms.Padding(4)
        Me.txtFileLocation.Name = "txtFileLocation"
        Me.txtFileLocation.Size = New System.Drawing.Size(639, 23)
        Me.txtFileLocation.TabIndex = 25
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(677, 30)
        Me.Button3.Margin = New System.Windows.Forms.Padding(4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(100, 30)
        Me.Button3.TabIndex = 24
        Me.Button3.Text = "Choose File"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(785, 30)
        Me.Button4.Margin = New System.Windows.Forms.Padding(4)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(100, 30)
        Me.Button4.TabIndex = 26
        Me.Button4.Text = "Save"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'OpenFileDialog2
        '
        Me.OpenFileDialog2.FileName = "OpenFileDialog2"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(1559, 27)
        Me.Button6.Margin = New System.Windows.Forms.Padding(4)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(100, 30)
        Me.Button6.TabIndex = 37
        Me.Button6.Text = "Choose File"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'frmCompare_Invoice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.ClientSize = New System.Drawing.Size(1823, 857)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me._cekbalance)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.DataGridView2)
        Me.Controls.Add(Me._cmbperpost)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtFileLocation)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button4)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmCompare_Invoice"
        Me.Controls.SetChildIndex(Me.Button4, 0)
        Me.Controls.SetChildIndex(Me.Button3, 0)
        Me.Controls.SetChildIndex(Me.txtFileLocation, 0)
        Me.Controls.SetChildIndex(Me.Button1, 0)
        Me.Controls.SetChildIndex(Me._cmbperpost, 0)
        Me.Controls.SetChildIndex(Me.DataGridView2, 0)
        Me.Controls.SetChildIndex(Me.DataGridView1, 0)
        Me.Controls.SetChildIndex(Me._cekbalance, 0)
        Me.Controls.SetChildIndex(Me.Button2, 0)
        Me.Controls.SetChildIndex(Me.Button5, 0)
        Me.Controls.SetChildIndex(Me.Button6, 0)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents Button5 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents _cekbalance As CheckBox
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DataGridView2 As DataGridView
    Friend WithEvents _cmbperpost As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents txtFileLocation As TextBox
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents OpenFileDialog2 As OpenFileDialog
    Friend WithEvents Button6 As Button
End Class
