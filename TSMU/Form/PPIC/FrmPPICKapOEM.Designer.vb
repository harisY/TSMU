<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPPICKapOEM
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
        Me.GridKapOEM = New DevExpress.XtraGrid.GridControl()
        Me.GridViewKapOEM = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.GridKapOEM, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewKapOEM, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridKapOEM
        '
        Me.GridKapOEM.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridKapOEM.Location = New System.Drawing.Point(0, 27)
        Me.GridKapOEM.MainView = Me.GridViewKapOEM
        Me.GridKapOEM.Name = "GridKapOEM"
        Me.GridKapOEM.Size = New System.Drawing.Size(828, 554)
        Me.GridKapOEM.TabIndex = 1
        Me.GridKapOEM.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewKapOEM})
        '
        'GridViewKapOEM
        '
        Me.GridViewKapOEM.GridControl = Me.GridKapOEM
        Me.GridViewKapOEM.Name = "GridViewKapOEM"
        Me.GridViewKapOEM.OptionsBehavior.Editable = False
        Me.GridViewKapOEM.OptionsView.ColumnAutoWidth = False
        Me.GridViewKapOEM.OptionsView.ShowGroupPanel = False
        '
        'FrmPPICKapOEM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.ClientSize = New System.Drawing.Size(828, 581)
        Me.Controls.Add(Me.GridKapOEM)
        Me.Name = "FrmPPICKapOEM"
        Me.Controls.SetChildIndex(Me.GridKapOEM, 0)
        CType(Me.GridKapOEM, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewKapOEM, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridKapOEM As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewKapOEM As DevExpress.XtraGrid.Views.Grid.GridView
End Class
