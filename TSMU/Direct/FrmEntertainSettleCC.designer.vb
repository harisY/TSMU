<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmEntertainSettleCC
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
        Me.GridSettle = New DevExpress.XtraGrid.GridControl()
        Me.GridViewSettle = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TabEntertainment = New DevExpress.XtraTab.XtraTabControl()
        Me.TabPageSettle = New DevExpress.XtraTab.XtraTabPage()
        Me.TabPagePaid = New DevExpress.XtraTab.XtraTabPage()
        Me.GridPaid = New DevExpress.XtraGrid.GridControl()
        Me.GridViewPaid = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GridSettle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewSettle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TabEntertainment, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabEntertainment.SuspendLayout()
        Me.TabPageSettle.SuspendLayout()
        Me.TabPagePaid.SuspendLayout()
        CType(Me.GridPaid, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewPaid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridSettle
        '
        Me.GridSettle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridSettle.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.GridSettle.Location = New System.Drawing.Point(4, 4)
        Me.GridSettle.MainView = Me.GridViewSettle
        Me.GridSettle.Margin = New System.Windows.Forms.Padding(4)
        Me.GridSettle.Name = "GridSettle"
        Me.GridSettle.Size = New System.Drawing.Size(1168, 673)
        Me.GridSettle.TabIndex = 2
        Me.GridSettle.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewSettle})
        '
        'GridViewSettle
        '
        Me.GridViewSettle.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridViewSettle.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridViewSettle.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn9, Me.GridColumn10})
        Me.GridViewSettle.DetailHeight = 458
        Me.GridViewSettle.FixedLineWidth = 3
        Me.GridViewSettle.GridControl = Me.GridSettle
        Me.GridViewSettle.Name = "GridViewSettle"
        Me.GridViewSettle.OptionsBehavior.Editable = False
        Me.GridViewSettle.OptionsView.ColumnAutoWidth = False
        Me.GridViewSettle.OptionsView.ShowAutoFilterRow = True
        Me.GridViewSettle.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "ID"
        Me.GridColumn1.FieldName = "ID"
        Me.GridColumn1.MinWidth = 27
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.FixedWidth = True
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 100
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Settle ID"
        Me.GridColumn2.FieldName = "SettleID"
        Me.GridColumn2.MinWidth = 27
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.FixedWidth = True
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 133
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Suspend ID"
        Me.GridColumn3.FieldName = "SuspendID"
        Me.GridColumn3.MinWidth = 27
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.FixedWidth = True
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        Me.GridColumn3.Width = 133
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Department"
        Me.GridColumn4.FieldName = "DeptID"
        Me.GridColumn4.MinWidth = 27
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.FixedWidth = True
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        Me.GridColumn4.Width = 100
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Remark"
        Me.GridColumn5.FieldName = "Remark"
        Me.GridColumn5.MinWidth = 27
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.FixedWidth = True
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 4
        Me.GridColumn5.Width = 599
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Date"
        Me.GridColumn6.FieldName = "Tgl"
        Me.GridColumn6.MinWidth = 27
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.FixedWidth = True
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 5
        Me.GridColumn6.Width = 107
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Currency"
        Me.GridColumn7.FieldName = "CuryID"
        Me.GridColumn7.MinWidth = 27
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.FixedWidth = True
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 6
        Me.GridColumn7.Width = 80
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Amount"
        Me.GridColumn8.FieldName = "Total"
        Me.GridColumn8.MinWidth = 27
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.FixedWidth = True
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 7
        Me.GridColumn8.Width = 133
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Suspend Amount"
        Me.GridColumn9.FieldName = "SuspendAmount"
        Me.GridColumn9.MinWidth = 27
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 8
        Me.GridColumn9.Width = 100
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Settle Amount"
        Me.GridColumn10.FieldName = "SettleAmount"
        Me.GridColumn10.MinWidth = 27
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 9
        Me.GridColumn10.Width = 100
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'TabEntertainment
        '
        Me.TabEntertainment.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TabEntertainment.Location = New System.Drawing.Point(16, 37)
        Me.TabEntertainment.Margin = New System.Windows.Forms.Padding(4)
        Me.TabEntertainment.Name = "TabEntertainment"
        Me.TabEntertainment.SelectedTabPage = Me.TabPageSettle
        Me.TabEntertainment.Size = New System.Drawing.Size(1184, 718)
        Me.TabEntertainment.TabIndex = 3
        Me.TabEntertainment.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.TabPageSettle, Me.TabPagePaid})
        '
        'TabPageSettle
        '
        Me.TabPageSettle.Controls.Add(Me.GridSettle)
        Me.TabPageSettle.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPageSettle.Name = "TabPageSettle"
        Me.TabPageSettle.Size = New System.Drawing.Size(1177, 684)
        Me.TabPageSettle.Text = "Settlement"
        '
        'TabPagePaid
        '
        Me.TabPagePaid.Controls.Add(Me.GridPaid)
        Me.TabPagePaid.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPagePaid.Name = "TabPagePaid"
        Me.TabPagePaid.Size = New System.Drawing.Size(1177, 684)
        Me.TabPagePaid.Text = "Settlement Paid"
        '
        'GridPaid
        '
        Me.GridPaid.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridPaid.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.GridPaid.Location = New System.Drawing.Point(4, 4)
        Me.GridPaid.MainView = Me.GridViewPaid
        Me.GridPaid.Margin = New System.Windows.Forms.Padding(4)
        Me.GridPaid.Name = "GridPaid"
        Me.GridPaid.Size = New System.Drawing.Size(1168, 673)
        Me.GridPaid.TabIndex = 3
        Me.GridPaid.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewPaid})
        '
        'GridViewPaid
        '
        Me.GridViewPaid.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridViewPaid.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridViewPaid.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20})
        Me.GridViewPaid.DetailHeight = 458
        Me.GridViewPaid.FixedLineWidth = 3
        Me.GridViewPaid.GridControl = Me.GridPaid
        Me.GridViewPaid.Name = "GridViewPaid"
        Me.GridViewPaid.OptionsBehavior.Editable = False
        Me.GridViewPaid.OptionsView.ColumnAutoWidth = False
        Me.GridViewPaid.OptionsView.ShowAutoFilterRow = True
        Me.GridViewPaid.OptionsView.ShowGroupPanel = False
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "ID"
        Me.GridColumn11.FieldName = "ID"
        Me.GridColumn11.MinWidth = 27
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.FixedWidth = True
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 0
        Me.GridColumn11.Width = 100
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Settle ID"
        Me.GridColumn12.FieldName = "SettleID"
        Me.GridColumn12.MinWidth = 27
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.FixedWidth = True
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 1
        Me.GridColumn12.Width = 133
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Suspend ID"
        Me.GridColumn13.FieldName = "SuspendID"
        Me.GridColumn13.MinWidth = 27
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.FixedWidth = True
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 2
        Me.GridColumn13.Width = 133
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Department"
        Me.GridColumn14.FieldName = "DeptID"
        Me.GridColumn14.MinWidth = 27
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.FixedWidth = True
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 3
        Me.GridColumn14.Width = 100
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Remark"
        Me.GridColumn15.FieldName = "Remark"
        Me.GridColumn15.MinWidth = 27
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.FixedWidth = True
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 4
        Me.GridColumn15.Width = 589
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Date"
        Me.GridColumn16.FieldName = "Tgl"
        Me.GridColumn16.MinWidth = 27
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.OptionsColumn.FixedWidth = True
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 5
        Me.GridColumn16.Width = 107
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Currency"
        Me.GridColumn17.FieldName = "CuryID"
        Me.GridColumn17.MinWidth = 27
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.OptionsColumn.FixedWidth = True
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 6
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Amount"
        Me.GridColumn18.FieldName = "Total"
        Me.GridColumn18.MinWidth = 27
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.OptionsColumn.FixedWidth = True
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 7
        Me.GridColumn18.Width = 133
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "Suspend Amount"
        Me.GridColumn19.FieldName = "SuspendAmount"
        Me.GridColumn19.MinWidth = 27
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 8
        Me.GridColumn19.Width = 100
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Settle Amount"
        Me.GridColumn20.FieldName = "SettleAmount"
        Me.GridColumn20.MinWidth = 27
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 9
        Me.GridColumn20.Width = 100
        '
        'FrmEntertainSettleCC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.ClientSize = New System.Drawing.Size(1200, 760)
        Me.Controls.Add(Me.TabEntertainment)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmEntertainSettleCC"
        Me.Text = "Settlement Entertaint"
        Me.Controls.SetChildIndex(Me.TabEntertainment, 0)
        CType(Me.GridSettle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewSettle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TabEntertainment, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabEntertainment.ResumeLayout(False)
        Me.TabPageSettle.ResumeLayout(False)
        Me.TabPagePaid.ResumeLayout(False)
        CType(Me.GridPaid, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewPaid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridSettle As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewSettle As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TabEntertainment As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents TabPageSettle As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TabPagePaid As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridPaid As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewPaid As DevExpress.XtraGrid.Views.Grid.GridView
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
End Class
