﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHeaderPR
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
        Me.Grid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.PRNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Tanggal = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Dept = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Total = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Status = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.RepoStatus = New DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit()
        Me.C_Submit = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.RepoStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C_Submit, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.Location = New System.Drawing.Point(12, 30)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Name = "Grid"
        Me.Grid.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.C_Submit, Me.RepoStatus})
        Me.Grid.Size = New System.Drawing.Size(838, 336)
        Me.Grid.TabIndex = 11
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.PRNo, Me.Tanggal, Me.Dept, Me.Total, Me.Status})
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'PRNo
        '
        Me.PRNo.AppearanceHeader.Options.UseTextOptions = True
        Me.PRNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.PRNo.FieldName = "PR No"
        Me.PRNo.Name = "PRNo"
        Me.PRNo.OptionsColumn.AllowEdit = False
        Me.PRNo.Visible = True
        Me.PRNo.VisibleIndex = 0
        Me.PRNo.Width = 140
        '
        'Tanggal
        '
        Me.Tanggal.AppearanceCell.Options.UseTextOptions = True
        Me.Tanggal.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Tanggal.AppearanceHeader.Options.UseTextOptions = True
        Me.Tanggal.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Tanggal.DisplayFormat.FormatString = "dd/MM/yyyy"
        Me.Tanggal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.Tanggal.FieldName = "Tanggal"
        Me.Tanggal.Name = "Tanggal"
        Me.Tanggal.OptionsColumn.AllowEdit = False
        Me.Tanggal.Visible = True
        Me.Tanggal.VisibleIndex = 1
        Me.Tanggal.Width = 163
        '
        'Dept
        '
        Me.Dept.AppearanceCell.Options.UseTextOptions = True
        Me.Dept.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Dept.AppearanceHeader.Options.UseTextOptions = True
        Me.Dept.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Dept.FieldName = "Dept"
        Me.Dept.Name = "Dept"
        Me.Dept.OptionsColumn.AllowEdit = False
        Me.Dept.Visible = True
        Me.Dept.VisibleIndex = 2
        Me.Dept.Width = 134
        '
        'Total
        '
        Me.Total.AppearanceHeader.Options.UseTextOptions = True
        Me.Total.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Total.DisplayFormat.FormatString = "{0:N2}"
        Me.Total.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric
        Me.Total.FieldName = "Total"
        Me.Total.Name = "Total"
        Me.Total.OptionsColumn.AllowEdit = False
        Me.Total.Visible = True
        Me.Total.VisibleIndex = 3
        Me.Total.Width = 173
        '
        'Status
        '
        Me.Status.AppearanceCell.Options.UseTextOptions = True
        Me.Status.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Status.AppearanceHeader.Options.UseTextOptions = True
        Me.Status.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.Status.ColumnEdit = Me.RepoStatus
        Me.Status.FieldName = "Status"
        Me.Status.Name = "Status"
        Me.Status.OptionsColumn.AllowEdit = False
        Me.Status.Visible = True
        Me.Status.VisibleIndex = 4
        '
        'RepoStatus
        '
        Me.RepoStatus.AutoHeight = False
        Me.RepoStatus.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.RepoStatus.Name = "RepoStatus"
        '
        'C_Submit
        '
        Me.C_Submit.AutoHeight = False
        Me.C_Submit.Name = "C_Submit"
        '
        'FrmHeaderPR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.ClientSize = New System.Drawing.Size(862, 378)
        Me.Controls.Add(Me.Grid)
        Me.Name = "FrmHeaderPR"
        Me.Controls.SetChildIndex(Me.Grid, 0)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.RepoStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C_Submit, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents PRNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Tanggal As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Dept As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents C_Submit As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents Total As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Status As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents RepoStatus As DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit
End Class
