<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportUploadGL
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
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.TxtPerpost = New System.Windows.Forms.TextBox()
        Me.TxtCuryID = New System.Windows.Forms.TextBox()
        Me.TxtTransaksi = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer1.Margin = New System.Windows.Forms.Padding(4)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(800, 450)
        Me.CrystalReportViewer1.TabIndex = 2
        Me.CrystalReportViewer1.ToolPanelWidth = 267
        '
        'TxtPerpost
        '
        Me.TxtPerpost.Location = New System.Drawing.Point(495, 13)
        Me.TxtPerpost.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtPerpost.Name = "TxtPerpost"
        Me.TxtPerpost.Size = New System.Drawing.Size(71, 22)
        Me.TxtPerpost.TabIndex = 3
        '
        'TxtCuryID
        '
        Me.TxtCuryID.Location = New System.Drawing.Point(574, 13)
        Me.TxtCuryID.Margin = New System.Windows.Forms.Padding(4)
        Me.TxtCuryID.Name = "TxtCuryID"
        Me.TxtCuryID.Size = New System.Drawing.Size(61, 22)
        Me.TxtCuryID.TabIndex = 4
        '
        'TxtTransaksi
        '
        Me.TxtTransaksi.Location = New System.Drawing.Point(654, 13)
        Me.TxtTransaksi.Name = "TxtTransaksi"
        Me.TxtTransaksi.Size = New System.Drawing.Size(100, 22)
        Me.TxtTransaksi.TabIndex = 5
        '
        'FrmReportUploadGL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TxtTransaksi)
        Me.Controls.Add(Me.TxtCuryID)
        Me.Controls.Add(Me.TxtPerpost)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "FrmReportUploadGL"
        Me.Text = "FrmReportUploadGL"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents TxtPerpost As TextBox
    Friend WithEvents TxtCuryID As TextBox
    Friend WithEvents TxtTransaksi As TextBox
End Class
