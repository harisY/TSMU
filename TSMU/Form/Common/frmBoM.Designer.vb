﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBoM
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
        Me.components = New System.ComponentModel.Container()
        Me.menuContext = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.ViewRoutingBoMToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportBomToUpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.Grid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.menuContext.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'menuContext
        '
        Me.menuContext.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.menuContext.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ViewRoutingBoMToolStripMenuItem, Me.ImportBomToUpdateToolStripMenuItem})
        Me.menuContext.Name = "menuContext"
        Me.menuContext.Size = New System.Drawing.Size(202, 52)
        '
        'ViewRoutingBoMToolStripMenuItem
        '
        Me.ViewRoutingBoMToolStripMenuItem.Name = "ViewRoutingBoMToolStripMenuItem"
        Me.ViewRoutingBoMToolStripMenuItem.Size = New System.Drawing.Size(201, 24)
        Me.ViewRoutingBoMToolStripMenuItem.Text = "View Routing BoM"
        Me.ViewRoutingBoMToolStripMenuItem.Visible = False
        '
        'ImportBomToUpdateToolStripMenuItem
        '
        Me.ImportBomToUpdateToolStripMenuItem.Name = "ImportBomToUpdateToolStripMenuItem"
        Me.ImportBomToUpdateToolStripMenuItem.Size = New System.Drawing.Size(201, 24)
        Me.ImportBomToUpdateToolStripMenuItem.Text = "Delete BoM"
        '
        'Grid
        '
        Me.Grid.ContextMenuStrip = Me.menuContext
        Me.Grid.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Grid.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.Location = New System.Drawing.Point(0, 27)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.Name = "Grid"
        Me.Grid.Size = New System.Drawing.Size(1104, 733)
        Me.Grid.TabIndex = 2
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.DetailHeight = 458
        Me.GridView1.FixedLineWidth = 3
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        '
        'frmBoM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.ClientSize = New System.Drawing.Size(1104, 760)
        Me.Controls.Add(Me.Grid)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "frmBoM"
        Me.Text = "Form BoM"
        Me.Controls.SetChildIndex(Me.Grid, 0)
        Me.menuContext.ResumeLayout(False)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents menuContext As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents ViewRoutingBoMToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents ImportBomToUpdateToolStripMenuItem As ToolStripMenuItem
End Class
