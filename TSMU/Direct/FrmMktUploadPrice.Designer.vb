<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMktUploadPrice
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
        Me.GridPrice = New DevExpress.XtraGrid.GridControl()
        Me.GridViewPrice = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.GridPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridPrice
        '
        Me.GridPrice.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPrice.Location = New System.Drawing.Point(12, 42)
        Me.GridPrice.MainView = Me.GridViewPrice
        Me.GridPrice.Name = "GridPrice"
        Me.GridPrice.Size = New System.Drawing.Size(984, 527)
        Me.GridPrice.TabIndex = 1
        Me.GridPrice.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewPrice})
        '
        'GridViewPrice
        '
        Me.GridViewPrice.GridControl = Me.GridPrice
        Me.GridViewPrice.Name = "GridViewPrice"
        Me.GridViewPrice.OptionsView.ShowGroupPanel = False
        '
        'FrmMktUploadPrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.ClientSize = New System.Drawing.Size(1008, 581)
        Me.Controls.Add(Me.GridPrice)
        Me.Name = "FrmMktUploadPrice"
        Me.Controls.SetChildIndex(Me.GridPrice, 0)
        CType(Me.GridPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewPrice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridPrice As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewPrice As DevExpress.XtraGrid.Views.Grid.GridView
End Class
