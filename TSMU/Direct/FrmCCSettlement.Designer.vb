<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCCSettlement
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
        Me.GridAccruedAll = New DevExpress.XtraGrid.GridControl()
        Me.GridViewAccruedAll = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.GridAccruedAll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewAccruedAll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridAccruedAll
        '
        Me.GridAccruedAll.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GridAccruedAll.Location = New System.Drawing.Point(0, 27)
        Me.GridAccruedAll.MainView = Me.GridViewAccruedAll
        Me.GridAccruedAll.Name = "GridAccruedAll"
        Me.GridAccruedAll.Size = New System.Drawing.Size(1553, 554)
        Me.GridAccruedAll.TabIndex = 5
        Me.GridAccruedAll.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewAccruedAll})
        '
        'GridViewAccruedAll
        '
        Me.GridViewAccruedAll.GridControl = Me.GridAccruedAll
        Me.GridViewAccruedAll.Name = "GridViewAccruedAll"
        Me.GridViewAccruedAll.OptionsBehavior.Editable = False
        Me.GridViewAccruedAll.OptionsSelection.MultiSelect = True
        Me.GridViewAccruedAll.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.GridViewAccruedAll.OptionsView.ColumnAutoWidth = False
        Me.GridViewAccruedAll.OptionsView.ShowGroupPanel = False
        '
        'FrmCCSettlement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.ClientSize = New System.Drawing.Size(1553, 581)
        Me.Controls.Add(Me.GridAccruedAll)
        Me.Name = "FrmCCSettlement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Controls.SetChildIndex(Me.GridAccruedAll, 0)
        CType(Me.GridAccruedAll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewAccruedAll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridAccruedAll As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewAccruedAll As DevExpress.XtraGrid.Views.Grid.GridView
End Class
