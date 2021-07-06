<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPPICLayoutGedung
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
        Me.GridLayoutGedung = New DevExpress.XtraGrid.GridControl()
        Me.GridViewLayoutGedung = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.GridLayoutGedung, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewLayoutGedung, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridLayoutGedung
        '
        Me.GridLayoutGedung.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridLayoutGedung.Location = New System.Drawing.Point(0, 27)
        Me.GridLayoutGedung.MainView = Me.GridViewLayoutGedung
        Me.GridLayoutGedung.Name = "GridLayoutGedung"
        Me.GridLayoutGedung.Size = New System.Drawing.Size(931, 554)
        Me.GridLayoutGedung.TabIndex = 1
        Me.GridLayoutGedung.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewLayoutGedung})
        '
        'GridViewLayoutGedung
        '
        Me.GridViewLayoutGedung.GridControl = Me.GridLayoutGedung
        Me.GridViewLayoutGedung.Name = "GridViewLayoutGedung"
        Me.GridViewLayoutGedung.OptionsBehavior.Editable = False
        Me.GridViewLayoutGedung.OptionsView.ColumnAutoWidth = False
        Me.GridViewLayoutGedung.OptionsView.ShowGroupPanel = False
        '
        'FrmPPICLayoutGedung
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(10.0!, 20.0!)
        Me.ClientSize = New System.Drawing.Size(931, 581)
        Me.Controls.Add(Me.GridLayoutGedung)
        Me.Name = "FrmPPICLayoutGedung"
        Me.Controls.SetChildIndex(Me.GridLayoutGedung, 0)
        CType(Me.GridLayoutGedung, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewLayoutGedung, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridLayoutGedung As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewLayoutGedung As DevExpress.XtraGrid.Views.Grid.GridView
End Class
