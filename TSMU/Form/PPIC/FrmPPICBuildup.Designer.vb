<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPPICBuildup
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
        Me.GridBuildup = New DevExpress.XtraGrid.GridControl()
        Me.GridViewBuildup = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.GridBuildup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewBuildup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridBuildup
        '
        Me.GridBuildup.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridBuildup.Location = New System.Drawing.Point(0, 27)
        Me.GridBuildup.MainView = Me.GridViewBuildup
        Me.GridBuildup.Name = "GridBuildup"
        Me.GridBuildup.Size = New System.Drawing.Size(828, 554)
        Me.GridBuildup.TabIndex = 1
        Me.GridBuildup.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewBuildup})
        '
        'GridViewBuildup
        '
        Me.GridViewBuildup.GridControl = Me.GridBuildup
        Me.GridViewBuildup.Name = "GridViewBuildup"
        Me.GridViewBuildup.OptionsBehavior.Editable = False
        Me.GridViewBuildup.OptionsView.ColumnAutoWidth = False
        Me.GridViewBuildup.OptionsView.ShowGroupPanel = False
        '
        'FrmPPICBuildup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.ClientSize = New System.Drawing.Size(828, 581)
        Me.Controls.Add(Me.GridBuildup)
        Me.Name = "FrmPPICBuildup"
        Me.Controls.SetChildIndex(Me.GridBuildup, 0)
        CType(Me.GridBuildup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewBuildup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridBuildup As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewBuildup As DevExpress.XtraGrid.Views.Grid.GridView
End Class
