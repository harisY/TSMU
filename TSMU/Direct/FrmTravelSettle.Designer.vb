<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTravelSettle
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
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.TabPageSett = New DevExpress.XtraTab.XtraTabPage()
        Me.GridSettle = New DevExpress.XtraGrid.GridControl()
        Me.GridViewSettle = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.TravelSettleID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.DeptID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TravelerName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Destination = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Purpose = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Term = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TabPageReq = New DevExpress.XtraTab.XtraTabPage()
        Me.GridRequest = New DevExpress.XtraGrid.GridControl()
        Me.GridViewRequest = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TabPageSettPaid = New DevExpress.XtraTab.XtraTabPage()
        Me.GridControl1 = New DevExpress.XtraGrid.GridControl()
        Me.GridView2 = New DevExpress.XtraGrid.Views.Grid.GridView()
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
        Me.Pay = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.TabPageSett.SuspendLayout()
        CType(Me.GridSettle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewSettle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageReq.SuspendLayout()
        CType(Me.GridRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageSettPaid.SuspendLayout()
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XtraTabControl1.Location = New System.Drawing.Point(0, 37)
        Me.XtraTabControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.TabPageSett
        Me.XtraTabControl1.Size = New System.Drawing.Size(1371, 590)
        Me.XtraTabControl1.TabIndex = 3
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.TabPageReq, Me.TabPageSett, Me.TabPageSettPaid})
        '
        'TabPageSett
        '
        Me.TabPageSett.Controls.Add(Me.GridSettle)
        Me.TabPageSett.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPageSett.Name = "TabPageSett"
        Me.TabPageSett.Size = New System.Drawing.Size(1364, 556)
        Me.TabPageSett.Text = "Settlement"
        '
        'GridSettle
        '
        Me.GridSettle.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridSettle.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.GridSettle.Location = New System.Drawing.Point(4, 5)
        Me.GridSettle.MainView = Me.GridViewSettle
        Me.GridSettle.Margin = New System.Windows.Forms.Padding(4)
        Me.GridSettle.Name = "GridSettle"
        Me.GridSettle.Size = New System.Drawing.Size(1355, 544)
        Me.GridSettle.TabIndex = 3
        Me.GridSettle.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewSettle})
        '
        'GridViewSettle
        '
        Me.GridViewSettle.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.TravelSettleID, Me.DeptID, Me.TravelerName, Me.Destination, Me.Purpose, Me.Term, Me.Pay})
        Me.GridViewSettle.DetailHeight = 458
        Me.GridViewSettle.FixedLineWidth = 3
        Me.GridViewSettle.GridControl = Me.GridSettle
        Me.GridViewSettle.Name = "GridViewSettle"
        Me.GridViewSettle.OptionsBehavior.Editable = False
        Me.GridViewSettle.OptionsView.ShowAutoFilterRow = True
        Me.GridViewSettle.OptionsView.ShowGroupPanel = False
        '
        'TravelSettleID
        '
        Me.TravelSettleID.Caption = "Settlement ID"
        Me.TravelSettleID.FieldName = "TravelSettleID"
        Me.TravelSettleID.MinWidth = 27
        Me.TravelSettleID.Name = "TravelSettleID"
        Me.TravelSettleID.OptionsColumn.FixedWidth = True
        Me.TravelSettleID.Visible = True
        Me.TravelSettleID.VisibleIndex = 0
        Me.TravelSettleID.Width = 130
        '
        'DeptID
        '
        Me.DeptID.Caption = "Dept ID"
        Me.DeptID.FieldName = "DeptID"
        Me.DeptID.MinWidth = 27
        Me.DeptID.Name = "DeptID"
        Me.DeptID.OptionsColumn.FixedWidth = True
        Me.DeptID.Visible = True
        Me.DeptID.VisibleIndex = 1
        Me.DeptID.Width = 100
        '
        'TravelerName
        '
        Me.TravelerName.Caption = "Nama"
        Me.TravelerName.FieldName = "Nama"
        Me.TravelerName.MinWidth = 27
        Me.TravelerName.Name = "TravelerName"
        Me.TravelerName.OptionsColumn.FixedWidth = True
        Me.TravelerName.Visible = True
        Me.TravelerName.VisibleIndex = 2
        Me.TravelerName.Width = 260
        '
        'Destination
        '
        Me.Destination.Caption = "Destination"
        Me.Destination.FieldName = "Destination"
        Me.Destination.MinWidth = 27
        Me.Destination.Name = "Destination"
        Me.Destination.OptionsColumn.FixedWidth = True
        Me.Destination.Visible = True
        Me.Destination.VisibleIndex = 3
        Me.Destination.Width = 260
        '
        'Purpose
        '
        Me.Purpose.Caption = "Purpose"
        Me.Purpose.FieldName = "Purpose"
        Me.Purpose.MinWidth = 25
        Me.Purpose.Name = "Purpose"
        Me.Purpose.Visible = True
        Me.Purpose.VisibleIndex = 4
        Me.Purpose.Width = 94
        '
        'Term
        '
        Me.Term.Caption = "Term"
        Me.Term.FieldName = "Term"
        Me.Term.MinWidth = 25
        Me.Term.Name = "Term"
        Me.Term.OptionsColumn.FixedWidth = True
        Me.Term.Visible = True
        Me.Term.VisibleIndex = 5
        Me.Term.Width = 260
        '
        'TabPageReq
        '
        Me.TabPageReq.Controls.Add(Me.GridRequest)
        Me.TabPageReq.Name = "TabPageReq"
        Me.TabPageReq.Size = New System.Drawing.Size(1364, 556)
        Me.TabPageReq.Text = "Request"
        '
        'GridRequest
        '
        Me.GridRequest.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridRequest.Location = New System.Drawing.Point(3, 3)
        Me.GridRequest.MainView = Me.GridViewRequest
        Me.GridRequest.Name = "GridRequest"
        Me.GridRequest.Size = New System.Drawing.Size(1358, 551)
        Me.GridRequest.TabIndex = 0
        Me.GridRequest.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewRequest})
        '
        'GridViewRequest
        '
        Me.GridViewRequest.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn5, Me.GridColumn6, Me.GridColumn21, Me.GridColumn22, Me.GridColumn10, Me.GridColumn9, Me.GridColumn7, Me.GridColumn8})
        Me.GridViewRequest.GridControl = Me.GridRequest
        Me.GridViewRequest.Name = "GridViewRequest"
        Me.GridViewRequest.OptionsBehavior.Editable = False
        Me.GridViewRequest.OptionsSelection.MultiSelect = True
        Me.GridViewRequest.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect
        Me.GridViewRequest.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "No Request"
        Me.GridColumn1.FieldName = "NoRequest"
        Me.GridColumn1.MinWidth = 25
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.FixedWidth = True
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 1
        Me.GridColumn1.Width = 130
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "Nama"
        Me.GridColumn2.FieldName = "Nama"
        Me.GridColumn2.MinWidth = 25
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.FixedWidth = True
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 2
        Me.GridColumn2.Width = 200
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Dept ID"
        Me.GridColumn3.FieldName = "DeptID"
        Me.GridColumn3.MinWidth = 25
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.FixedWidth = True
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 3
        Me.GridColumn3.Width = 80
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Travel Type"
        Me.GridColumn5.FieldName = "TravelType"
        Me.GridColumn5.MinWidth = 25
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.FixedWidth = True
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 4
        Me.GridColumn5.Width = 100
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Purpose"
        Me.GridColumn6.FieldName = "Purpose"
        Me.GridColumn6.MinWidth = 25
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 5
        Me.GridColumn6.Width = 25
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "Departure Date"
        Me.GridColumn21.FieldName = "DepartureDate"
        Me.GridColumn21.MinWidth = 25
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.OptionsColumn.FixedWidth = True
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 6
        Me.GridColumn21.Width = 120
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "Arrival Date"
        Me.GridColumn22.FieldName = "ArrivalDate"
        Me.GridColumn22.MinWidth = 25
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.OptionsColumn.FixedWidth = True
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 7
        Me.GridColumn22.Width = 120
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "Term"
        Me.GridColumn10.FieldName = "Term"
        Me.GridColumn10.MinWidth = 25
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.FixedWidth = True
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 8
        Me.GridColumn10.Width = 260
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Advance IDR"
        Me.GridColumn9.FieldName = "AdvanceIDR"
        Me.GridColumn9.MinWidth = 25
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.FixedWidth = True
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 9
        Me.GridColumn9.Width = 130
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Advance USD"
        Me.GridColumn7.FieldName = "AdvanceUSD"
        Me.GridColumn7.MinWidth = 25
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.FixedWidth = True
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 10
        Me.GridColumn7.Width = 130
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Advance YEN"
        Me.GridColumn8.FieldName = "AdvanceYEN"
        Me.GridColumn8.MinWidth = 25
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.FixedWidth = True
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 11
        Me.GridColumn8.Width = 130
        '
        'TabPageSettPaid
        '
        Me.TabPageSettPaid.Controls.Add(Me.GridControl1)
        Me.TabPageSettPaid.Margin = New System.Windows.Forms.Padding(4)
        Me.TabPageSettPaid.Name = "TabPageSettPaid"
        Me.TabPageSettPaid.Size = New System.Drawing.Size(1364, 556)
        Me.TabPageSettPaid.Text = "Settlement Paid"
        '
        'GridControl1
        '
        Me.GridControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridControl1.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(4)
        Me.GridControl1.Location = New System.Drawing.Point(4, 4)
        Me.GridControl1.MainView = Me.GridView2
        Me.GridControl1.Margin = New System.Windows.Forms.Padding(4)
        Me.GridControl1.Name = "GridControl1"
        Me.GridControl1.Size = New System.Drawing.Size(1356, 549)
        Me.GridControl1.TabIndex = 3
        Me.GridControl1.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridView2})
        '
        'GridView2
        '
        Me.GridView2.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn19, Me.GridColumn20})
        Me.GridView2.DetailHeight = 458
        Me.GridView2.FixedLineWidth = 3
        Me.GridView2.GridControl = Me.GridControl1
        Me.GridView2.Name = "GridView2"
        Me.GridView2.OptionsBehavior.Editable = False
        Me.GridView2.OptionsView.ColumnAutoWidth = False
        Me.GridView2.OptionsView.ShowAutoFilterRow = True
        Me.GridView2.OptionsView.ShowGroupPanel = False
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
        Me.GridColumn17.Width = 67
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
        'Pay
        '
        Me.Pay.Caption = "Pay"
        Me.Pay.FieldName = "Pay"
        Me.Pay.MinWidth = 25
        Me.Pay.Name = "Pay"
        Me.Pay.Width = 94
        '
        'FrmTravelSettle
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.ClientSize = New System.Drawing.Size(1387, 631)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "FrmTravelSettle"
        Me.Controls.SetChildIndex(Me.XtraTabControl1, 0)
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.TabPageSett.ResumeLayout(False)
        CType(Me.GridSettle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewSettle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageReq.ResumeLayout(False)
        CType(Me.GridRequest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewRequest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageSettPaid.ResumeLayout(False)
        CType(Me.GridControl1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridView2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents TabPageSett As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents TabPageSettPaid As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridControl1 As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridView2 As DevExpress.XtraGrid.Views.Grid.GridView
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
    Friend WithEvents GridSettle As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewSettle As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents TravelSettleID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents DeptID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Destination As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TravelerName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TabPageReq As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridRequest As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewRequest As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Purpose As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Term As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Pay As DevExpress.XtraGrid.Columns.GridColumn
End Class
