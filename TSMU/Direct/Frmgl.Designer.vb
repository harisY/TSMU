<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Frmgl
    Inherits TSMU.baseForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.XtraTabPage1 = New DevExpress.XtraTab.XtraTabPage()
        Me.Grid = New DevExpress.XtraGrid.GridControl()
        Me.GridView1 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.XtraTabPage2 = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.XtraTabPage1.SuspendLayout()
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabPage2.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XtraTabControl1.Location = New System.Drawing.Point(13, 31)
        Me.XtraTabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.XtraTabPage1
        Me.XtraTabControl1.Size = New System.Drawing.Size(1088, 719)
        Me.XtraTabControl1.TabIndex = 4
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.XtraTabPage1, Me.XtraTabPage2})
        '
        'XtraTabPage1
        '
        Me.XtraTabPage1.Controls.Add(Me.Grid)
        Me.XtraTabPage1.Margin = New System.Windows.Forms.Padding(4)
        Me.XtraTabPage1.Name = "XtraTabPage1"
        Me.XtraTabPage1.Size = New System.Drawing.Size(1081, 685)
        Me.XtraTabPage1.Text = "General Journal"
        '
        'Grid
        '
        Me.Grid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Grid.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.Location = New System.Drawing.Point(4, 4)
        Me.Grid.MainView = Me.GridView1
        Me.Grid.Margin = New System.Windows.Forms.Padding(4)
        Me.Grid.Name = "Grid"
        Me.Grid.Size = New System.Drawing.Size(1072, 673)
        Me.Grid.TabIndex = 2
        Me.Grid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView1})
        '
        'GridView1
        '
        Me.GridView1.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn21, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn10, Me.GridColumn19, Me.GridColumn3})
        Me.GridView1.DetailHeight = 458
        Me.GridView1.FixedLineWidth = 3
        Me.GridView1.GridControl = Me.Grid
        Me.GridView1.Name = "GridView1"
        Me.GridView1.OptionsBehavior.Editable = False
        Me.GridView1.OptionsView.ColumnAutoWidth = False
        Me.GridView1.OptionsView.ShowAutoFilterRow = True
        Me.GridView1.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "GJHeaderID"
        Me.GridColumn1.MinWidth = 27
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.FixedWidth = True
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 100
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Journal No."
        Me.GridColumn2.FieldName = "GJID"
        Me.GridColumn2.MinWidth = 27
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.OptionsColumn.FixedWidth = True
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 133
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Currency"
        Me.GridColumn4.FieldName = "Currency"
        Me.GridColumn4.MinWidth = 27
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.OptionsColumn.FixedWidth = True
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        Me.GridColumn4.Width = 100
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Department"
        Me.GridColumn5.FieldName = "DeptID"
        Me.GridColumn5.MinWidth = 27
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.OptionsColumn.FixedWidth = True
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 4
        Me.GridColumn5.Width = 100
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "PR No"
        Me.GridColumn6.FieldName = "PRNo"
        Me.GridColumn6.MinWidth = 27
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.OptionsColumn.FixedWidth = True
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 5
        Me.GridColumn6.Width = 133
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Remark"
        Me.GridColumn7.FieldName = "Remark"
        Me.GridColumn7.MinWidth = 27
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.OptionsColumn.FixedWidth = True
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 6
        Me.GridColumn7.Width = 267
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Date"
        Me.GridColumn8.FieldName = "Tgl"
        Me.GridColumn8.MinWidth = 27
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.OptionsColumn.FixedWidth = True
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 7
        Me.GridColumn8.Width = 107
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Amount Debit"
        Me.GridColumn10.FieldName = "Total"
        Me.GridColumn10.MinWidth = 27
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.AllowEdit = False
        Me.GridColumn10.OptionsColumn.FixedWidth = True
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 8
        Me.GridColumn10.Width = 133
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "Amount Credit"
        Me.GridColumn19.FieldName = "TotalCr"
        Me.GridColumn19.MinWidth = 25
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 9
        Me.GridColumn19.Width = 94
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Status"
        Me.GridColumn3.FieldName = "Status"
        Me.GridColumn3.MinWidth = 27
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.OptionsColumn.FixedWidth = True
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 10
        Me.GridColumn3.Width = 100
        '
        'XtraTabPage2
        '
        Me.XtraTabPage2.Controls.Add(Me.GridControl1)
        Me.XtraTabPage2.Margin = New System.Windows.Forms.Padding(4)
        Me.XtraTabPage2.Name = "XtraTabPage2"
        Me.XtraTabPage2.Size = New System.Drawing.Size(1081, 685)
        Me.XtraTabPage2.Text = "General Journal Approved"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.GridControl1.Location = New System.Drawing.Point(4, 5)
        Me.GridControl1.MainView = Me.GridView2
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1072, 673)
        Me.GridControl1.TabIndex = 3
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn9, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn20, Me.GridColumn18})
        Me.GridView2.DetailHeight = 458
        Me.GridView2.FixedLineWidth = 3
        Me.GridView2.GridControl = Me.GridControl1
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.Editable = False
        Me.GridView2.OptionsView.ColumnAutoWidth = False
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        Me.GridView2.OptionsView.ShowGroupPanel = False
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "ID"
        Me.GridColumn9.FieldName = "GJHeaderID"
        Me.GridColumn9.MinWidth = 27
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.FixedWidth = True
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 0
        Me.GridColumn9.Width = 100
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "GJ No."
        Me.GridColumn11.FieldName = "GJID"
        Me.GridColumn11.MinWidth = 27
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.FixedWidth = True
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 1
        Me.GridColumn11.Width = 133
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Currency"
        Me.GridColumn12.FieldName = "Currency"
        Me.GridColumn12.MinWidth = 27
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.FixedWidth = True
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 2
        Me.GridColumn12.Width = 100
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Department"
        Me.GridColumn13.FieldName = "DeptID"
        Me.GridColumn13.MinWidth = 27
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.FixedWidth = True
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 3
        Me.GridColumn13.Width = 100
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "PR No"
        Me.GridColumn14.FieldName = "PRNo"
        Me.GridColumn14.MinWidth = 27
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.FixedWidth = True
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 4
        Me.GridColumn14.Width = 133
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Remark"
        Me.GridColumn15.FieldName = "Remark"
        Me.GridColumn15.MinWidth = 27
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.FixedWidth = True
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 5
        Me.GridColumn15.Width = 267
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Date"
        Me.GridColumn16.FieldName = "Tgl"
        Me.GridColumn16.MinWidth = 27
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.OptionsColumn.FixedWidth = True
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 6
        Me.GridColumn16.Width = 107
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Amount Debit"
        Me.GridColumn17.FieldName = "Total"
        Me.GridColumn17.MinWidth = 27
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.OptionsColumn.FixedWidth = True
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 7
        Me.GridColumn17.Width = 133
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Amount Credit"
        Me.GridColumn20.FieldName = "TotalCr"
        Me.GridColumn20.MinWidth = 25
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 8
        Me.GridColumn20.Width = 94
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Status"
        Me.GridColumn18.FieldName = "Status"
        Me.GridColumn18.MinWidth = 27
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.OptionsColumn.AllowEdit = False
        Me.GridColumn18.OptionsColumn.FixedWidth = True
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 9
        Me.GridColumn18.Width = 100
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "Reff Journal No."
        Me.GridColumn21.FieldName = "GJID_Revers"
        Me.GridColumn21.MinWidth = 25
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 2
        Me.GridColumn21.Width = 94
        '
        'Frmgl
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.ClientSize = New System.Drawing.Size(1104, 760)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Name = "Frmgl"
        Me.Controls.SetChildIndex(Me.XtraTabControl1, 0)
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.XtraTabPage1.ResumeLayout(False)
        CType(Me.Grid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabPage2.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents XtraTabPage1 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents Grid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView1 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XtraTabPage2 As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
End Class
