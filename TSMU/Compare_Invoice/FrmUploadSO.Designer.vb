<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUploadSO
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
        Me.TxtJenisPO = New DevExpress.XtraEditors.TextEdit()
        Me._txtFileLocation = New DevExpress.XtraEditors.TextEdit()
        CType(Me.TxtJenisPO.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me._txtFileLocation.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CrystalReportViewer1.Cursor = System.Windows.Forms.Cursors.Default
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(800, 450)
        Me.CrystalReportViewer1.TabIndex = 0
        '
        'TxtJenisPO
        '
        Me.TxtJenisPO.Location = New System.Drawing.Point(548, 24)
        Me.TxtJenisPO.Name = "TxtJenisPO"
        Me.TxtJenisPO.Size = New System.Drawing.Size(125, 22)
        Me.TxtJenisPO.TabIndex = 1
        '
        '_txtFileLocation
        '
        Me._txtFileLocation.Location = New System.Drawing.Point(716, 27)
        Me._txtFileLocation.Name = "_txtFileLocation"
        Me._txtFileLocation.Size = New System.Drawing.Size(125, 22)
        Me._txtFileLocation.TabIndex = 2
        '
        'FrmUploadSO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me._txtFileLocation)
        Me.Controls.Add(Me.TxtJenisPO)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "FrmUploadSO"
        Me.Text = "FrmUploadSO"
        Me.WindowState = System.Windows.Forms.FormWindowState.Minimized
        CType(Me.TxtJenisPO.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me._txtFileLocation.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents TxtJenisPO As DevExpress.XtraEditors.TextEdit
    Friend WithEvents _txtFileLocation As DevExpress.XtraEditors.TextEdit
End Class
