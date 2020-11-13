<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmReportCCAccrued
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
        Me.txtTabAccrued = New System.Windows.Forms.TextBox()
        Me.txtPerpost = New DevExpress.XtraEditors.DateEdit()
        CType(Me.txtPerpost.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtPerpost.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(1005, 612)
        Me.CrystalReportViewer1.TabIndex = 0
        '
        'txtTabAccrued
        '
        Me.txtTabAccrued.Location = New System.Drawing.Point(485, 0)
        Me.txtTabAccrued.Name = "txtTabAccrued"
        Me.txtTabAccrued.Size = New System.Drawing.Size(100, 22)
        Me.txtTabAccrued.TabIndex = 1
        Me.txtTabAccrued.Visible = False
        '
        'txtPerpost
        '
        Me.txtPerpost.EditValue = Nothing
        Me.txtPerpost.Location = New System.Drawing.Point(611, 0)
        Me.txtPerpost.Name = "txtPerpost"
        Me.txtPerpost.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtPerpost.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtPerpost.Size = New System.Drawing.Size(125, 22)
        Me.txtPerpost.TabIndex = 2
        Me.txtPerpost.Visible = False
        '
        'FrmReportCCAccrued
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1005, 612)
        Me.Controls.Add(Me.txtPerpost)
        Me.Controls.Add(Me.txtTabAccrued)
        Me.Controls.Add(Me.CrystalReportViewer1)
        Me.Name = "FrmReportCCAccrued"
        Me.Text = "FrmReportCCAccrued"
        CType(Me.txtPerpost.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtPerpost.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents txtTabAccrued As TextBox
    Friend WithEvents txtPerpost As DevExpress.XtraEditors.DateEdit
End Class
