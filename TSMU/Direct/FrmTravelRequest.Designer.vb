<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTravelRequest
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
        Me.GridApprovedReq = New DevExpress.XtraGrid.GridControl()
        Me.GridViewApproved = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn1 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn2 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn3 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn4 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn5 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn6 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn7 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn8 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn19 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CApproved = New DevExpress.XtraEditors.Repository.RepositoryItemComboBox()
        Me.GridColumn20 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CComment = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.XtraTabControl1 = New DevExpress.XtraTab.XtraTabControl()
        Me.TabPageRequest = New DevExpress.XtraTab.XtraTabPage()
        Me.GridRequest = New DevExpress.XtraGrid.GridControl()
        Me.GridViewRequest = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn10 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn11 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn12 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn13 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn14 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn15 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn16 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn17 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn18 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn9 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn21 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.TabPageApproved = New DevExpress.XtraTab.XtraTabPage()
        Me.TabPageRequestAll = New DevExpress.XtraTab.XtraTabPage()
        Me.GridRequestAll = New DevExpress.XtraGrid.GridControl()
        Me.GridViewRequestAll = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.GridColumn22 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn23 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn24 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn25 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn26 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn27 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn28 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn29 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn30 = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.GridColumn31 = New DevExpress.XtraGrid.Columns.GridColumn()
        CType(Me.GridApprovedReq, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewApproved, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CApproved, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CComment, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.XtraTabControl1.SuspendLayout()
        Me.TabPageRequest.SuspendLayout()
        CType(Me.GridRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewRequest, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPageApproved.SuspendLayout()
        Me.TabPageRequestAll.SuspendLayout()
        CType(Me.GridRequestAll, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewRequestAll, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GridApprovedReq
        '
        Me.GridApprovedReq.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridApprovedReq.Location = New System.Drawing.Point(3, 3)
        Me.GridApprovedReq.MainView = Me.GridViewApproved
        Me.GridApprovedReq.Name = "GridApprovedReq"
        Me.GridApprovedReq.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CApproved, Me.CComment})
        Me.GridApprovedReq.Size = New System.Drawing.Size(1487, 480)
        Me.GridApprovedReq.TabIndex = 1
        Me.GridApprovedReq.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewApproved})
        '
        'GridViewApproved
        '
        Me.GridViewApproved.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn1, Me.GridColumn2, Me.GridColumn3, Me.GridColumn4, Me.GridColumn5, Me.GridColumn6, Me.GridColumn7, Me.GridColumn8, Me.GridColumn19, Me.GridColumn20})
        Me.GridViewApproved.GridControl = Me.GridApprovedReq
        Me.GridViewApproved.Name = "GridViewApproved"
        Me.GridViewApproved.OptionsView.ShowGroupPanel = False
        '
        'GridColumn1
        '
        Me.GridColumn1.Caption = "No Request"
        Me.GridColumn1.FieldName = "NoRequest"
        Me.GridColumn1.MinWidth = 25
        Me.GridColumn1.Name = "GridColumn1"
        Me.GridColumn1.OptionsColumn.AllowEdit = False
        Me.GridColumn1.OptionsColumn.FixedWidth = True
        Me.GridColumn1.Visible = True
        Me.GridColumn1.VisibleIndex = 0
        Me.GridColumn1.Width = 130
        '
        'GridColumn2
        '
        Me.GridColumn2.Caption = "NIK"
        Me.GridColumn2.FieldName = "NIK"
        Me.GridColumn2.MinWidth = 25
        Me.GridColumn2.Name = "GridColumn2"
        Me.GridColumn2.OptionsColumn.AllowEdit = False
        Me.GridColumn2.OptionsColumn.FixedWidth = True
        Me.GridColumn2.Visible = True
        Me.GridColumn2.VisibleIndex = 1
        Me.GridColumn2.Width = 100
        '
        'GridColumn3
        '
        Me.GridColumn3.Caption = "Nama"
        Me.GridColumn3.FieldName = "Nama"
        Me.GridColumn3.MinWidth = 25
        Me.GridColumn3.Name = "GridColumn3"
        Me.GridColumn3.OptionsColumn.AllowEdit = False
        Me.GridColumn3.OptionsColumn.FixedWidth = True
        Me.GridColumn3.Visible = True
        Me.GridColumn3.VisibleIndex = 2
        Me.GridColumn3.Width = 200
        '
        'GridColumn4
        '
        Me.GridColumn4.Caption = "Tanggal"
        Me.GridColumn4.FieldName = "Date"
        Me.GridColumn4.MinWidth = 25
        Me.GridColumn4.Name = "GridColumn4"
        Me.GridColumn4.OptionsColumn.AllowEdit = False
        Me.GridColumn4.OptionsColumn.FixedWidth = True
        Me.GridColumn4.Visible = True
        Me.GridColumn4.VisibleIndex = 3
        Me.GridColumn4.Width = 110
        '
        'GridColumn5
        '
        Me.GridColumn5.Caption = "Dept ID"
        Me.GridColumn5.FieldName = "DeptID"
        Me.GridColumn5.MinWidth = 25
        Me.GridColumn5.Name = "GridColumn5"
        Me.GridColumn5.OptionsColumn.AllowEdit = False
        Me.GridColumn5.OptionsColumn.FixedWidth = True
        Me.GridColumn5.Visible = True
        Me.GridColumn5.VisibleIndex = 4
        Me.GridColumn5.Width = 70
        '
        'GridColumn6
        '
        Me.GridColumn6.Caption = "Travel Type"
        Me.GridColumn6.FieldName = "TravelType"
        Me.GridColumn6.MinWidth = 25
        Me.GridColumn6.Name = "GridColumn6"
        Me.GridColumn6.OptionsColumn.AllowEdit = False
        Me.GridColumn6.OptionsColumn.FixedWidth = True
        Me.GridColumn6.Visible = True
        Me.GridColumn6.VisibleIndex = 5
        Me.GridColumn6.Width = 90
        '
        'GridColumn7
        '
        Me.GridColumn7.Caption = "Golongan"
        Me.GridColumn7.FieldName = "Golongan"
        Me.GridColumn7.MinWidth = 25
        Me.GridColumn7.Name = "GridColumn7"
        Me.GridColumn7.OptionsColumn.AllowEdit = False
        Me.GridColumn7.OptionsColumn.FixedWidth = True
        Me.GridColumn7.Visible = True
        Me.GridColumn7.VisibleIndex = 6
        Me.GridColumn7.Width = 80
        '
        'GridColumn8
        '
        Me.GridColumn8.Caption = "Purpose"
        Me.GridColumn8.FieldName = "Purpose"
        Me.GridColumn8.MinWidth = 25
        Me.GridColumn8.Name = "GridColumn8"
        Me.GridColumn8.OptionsColumn.AllowEdit = False
        Me.GridColumn8.Visible = True
        Me.GridColumn8.VisibleIndex = 7
        Me.GridColumn8.Width = 500
        '
        'GridColumn19
        '
        Me.GridColumn19.Caption = "Approved"
        Me.GridColumn19.ColumnEdit = Me.CApproved
        Me.GridColumn19.FieldName = "Approved"
        Me.GridColumn19.MinWidth = 25
        Me.GridColumn19.Name = "GridColumn19"
        Me.GridColumn19.OptionsColumn.FixedWidth = True
        Me.GridColumn19.Visible = True
        Me.GridColumn19.VisibleIndex = 8
        Me.GridColumn19.Width = 120
        '
        'CApproved
        '
        Me.CApproved.AutoHeight = False
        Me.CApproved.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.CApproved.Items.AddRange(New Object() {"APPROVED", "REVISED", "REJECT"})
        Me.CApproved.Name = "CApproved"
        '
        'GridColumn20
        '
        Me.GridColumn20.Caption = "Comment"
        Me.GridColumn20.ColumnEdit = Me.CComment
        Me.GridColumn20.FieldName = "Comment"
        Me.GridColumn20.MinWidth = 25
        Me.GridColumn20.Name = "GridColumn20"
        Me.GridColumn20.Visible = True
        Me.GridColumn20.VisibleIndex = 9
        Me.GridColumn20.Width = 500
        '
        'CComment
        '
        Me.CComment.AutoHeight = False
        Me.CComment.Name = "CComment"
        '
        'XtraTabControl1
        '
        Me.XtraTabControl1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.XtraTabControl1.Location = New System.Drawing.Point(12, 39)
        Me.XtraTabControl1.Name = "XtraTabControl1"
        Me.XtraTabControl1.SelectedTabPage = Me.TabPageRequest
        Me.XtraTabControl1.Size = New System.Drawing.Size(1500, 520)
        Me.XtraTabControl1.TabIndex = 2
        Me.XtraTabControl1.TabPages.AddRange(New DevExpress.XtraTab.XtraTabPage() {Me.TabPageRequest, Me.TabPageApproved, Me.TabPageRequestAll})
        '
        'TabPageRequest
        '
        Me.TabPageRequest.Controls.Add(Me.GridRequest)
        Me.TabPageRequest.Name = "TabPageRequest"
        Me.TabPageRequest.Size = New System.Drawing.Size(1493, 486)
        Me.TabPageRequest.Text = "Request"
        '
        'GridRequest
        '
        Me.GridRequest.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridRequest.Location = New System.Drawing.Point(3, 3)
        Me.GridRequest.MainView = Me.GridViewRequest
        Me.GridRequest.Name = "GridRequest"
        Me.GridRequest.Size = New System.Drawing.Size(1487, 480)
        Me.GridRequest.TabIndex = 2
        Me.GridRequest.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewRequest})
        '
        'GridViewRequest
        '
        Me.GridViewRequest.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn10, Me.GridColumn11, Me.GridColumn12, Me.GridColumn13, Me.GridColumn14, Me.GridColumn15, Me.GridColumn16, Me.GridColumn17, Me.GridColumn18, Me.GridColumn9, Me.GridColumn21})
        Me.GridViewRequest.GridControl = Me.GridRequest
        Me.GridViewRequest.Name = "GridViewRequest"
        Me.GridViewRequest.OptionsBehavior.Editable = False
        Me.GridViewRequest.OptionsView.ShowGroupPanel = False
        '
        'GridColumn10
        '
        Me.GridColumn10.Caption = "No Request"
        Me.GridColumn10.FieldName = "NoRequest"
        Me.GridColumn10.MinWidth = 25
        Me.GridColumn10.Name = "GridColumn10"
        Me.GridColumn10.OptionsColumn.FixedWidth = True
        Me.GridColumn10.Visible = True
        Me.GridColumn10.VisibleIndex = 0
        Me.GridColumn10.Width = 130
        '
        'GridColumn11
        '
        Me.GridColumn11.Caption = "NIK"
        Me.GridColumn11.FieldName = "NIK"
        Me.GridColumn11.MinWidth = 25
        Me.GridColumn11.Name = "GridColumn11"
        Me.GridColumn11.OptionsColumn.FixedWidth = True
        Me.GridColumn11.Visible = True
        Me.GridColumn11.VisibleIndex = 1
        Me.GridColumn11.Width = 100
        '
        'GridColumn12
        '
        Me.GridColumn12.Caption = "Nama"
        Me.GridColumn12.FieldName = "Nama"
        Me.GridColumn12.MinWidth = 25
        Me.GridColumn12.Name = "GridColumn12"
        Me.GridColumn12.OptionsColumn.FixedWidth = True
        Me.GridColumn12.Visible = True
        Me.GridColumn12.VisibleIndex = 2
        Me.GridColumn12.Width = 200
        '
        'GridColumn13
        '
        Me.GridColumn13.Caption = "Tanggal"
        Me.GridColumn13.FieldName = "Date"
        Me.GridColumn13.MinWidth = 25
        Me.GridColumn13.Name = "GridColumn13"
        Me.GridColumn13.OptionsColumn.FixedWidth = True
        Me.GridColumn13.Visible = True
        Me.GridColumn13.VisibleIndex = 3
        Me.GridColumn13.Width = 110
        '
        'GridColumn14
        '
        Me.GridColumn14.Caption = "Dept ID"
        Me.GridColumn14.FieldName = "DeptID"
        Me.GridColumn14.MinWidth = 25
        Me.GridColumn14.Name = "GridColumn14"
        Me.GridColumn14.OptionsColumn.FixedWidth = True
        Me.GridColumn14.Visible = True
        Me.GridColumn14.VisibleIndex = 4
        Me.GridColumn14.Width = 70
        '
        'GridColumn15
        '
        Me.GridColumn15.Caption = "Travel Type"
        Me.GridColumn15.FieldName = "TravelType"
        Me.GridColumn15.MinWidth = 25
        Me.GridColumn15.Name = "GridColumn15"
        Me.GridColumn15.OptionsColumn.FixedWidth = True
        Me.GridColumn15.Visible = True
        Me.GridColumn15.VisibleIndex = 5
        Me.GridColumn15.Width = 90
        '
        'GridColumn16
        '
        Me.GridColumn16.Caption = "Golongan"
        Me.GridColumn16.FieldName = "Golongan"
        Me.GridColumn16.MinWidth = 25
        Me.GridColumn16.Name = "GridColumn16"
        Me.GridColumn16.OptionsColumn.FixedWidth = True
        Me.GridColumn16.Visible = True
        Me.GridColumn16.VisibleIndex = 6
        Me.GridColumn16.Width = 80
        '
        'GridColumn17
        '
        Me.GridColumn17.Caption = "Purpose"
        Me.GridColumn17.FieldName = "Purpose"
        Me.GridColumn17.MinWidth = 25
        Me.GridColumn17.Name = "GridColumn17"
        Me.GridColumn17.Visible = True
        Me.GridColumn17.VisibleIndex = 7
        Me.GridColumn17.Width = 94
        '
        'GridColumn18
        '
        Me.GridColumn18.Caption = "Status"
        Me.GridColumn18.FieldName = "Status"
        Me.GridColumn18.MinWidth = 25
        Me.GridColumn18.Name = "GridColumn18"
        Me.GridColumn18.OptionsColumn.FixedWidth = True
        Me.GridColumn18.Visible = True
        Me.GridColumn18.VisibleIndex = 8
        Me.GridColumn18.Width = 80
        '
        'GridColumn9
        '
        Me.GridColumn9.Caption = "Approved"
        Me.GridColumn9.FieldName = "Approved"
        Me.GridColumn9.MinWidth = 25
        Me.GridColumn9.Name = "GridColumn9"
        Me.GridColumn9.OptionsColumn.FixedWidth = True
        Me.GridColumn9.Visible = True
        Me.GridColumn9.VisibleIndex = 9
        Me.GridColumn9.Width = 90
        '
        'GridColumn21
        '
        Me.GridColumn21.Caption = "Comment"
        Me.GridColumn21.FieldName = "Comment"
        Me.GridColumn21.MinWidth = 25
        Me.GridColumn21.Name = "GridColumn21"
        Me.GridColumn21.Visible = True
        Me.GridColumn21.VisibleIndex = 10
        Me.GridColumn21.Width = 94
        '
        'TabPageApproved
        '
        Me.TabPageApproved.Controls.Add(Me.GridApprovedReq)
        Me.TabPageApproved.Name = "TabPageApproved"
        Me.TabPageApproved.Size = New System.Drawing.Size(1493, 486)
        Me.TabPageApproved.Text = "Approved"
        '
        'TabPageRequestAll
        '
        Me.TabPageRequestAll.Controls.Add(Me.GridRequestAll)
        Me.TabPageRequestAll.Name = "TabPageRequestAll"
        Me.TabPageRequestAll.Size = New System.Drawing.Size(1493, 486)
        Me.TabPageRequestAll.Text = "Search"
        '
        'GridRequestAll
        '
        Me.GridRequestAll.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridRequestAll.Location = New System.Drawing.Point(3, 3)
        Me.GridRequestAll.MainView = Me.GridViewRequestAll
        Me.GridRequestAll.Name = "GridRequestAll"
        Me.GridRequestAll.Size = New System.Drawing.Size(1487, 480)
        Me.GridRequestAll.TabIndex = 3
        Me.GridRequestAll.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewRequestAll})
        '
        'GridViewRequestAll
        '
        Me.GridViewRequestAll.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.GridColumn22, Me.GridColumn23, Me.GridColumn24, Me.GridColumn25, Me.GridColumn26, Me.GridColumn27, Me.GridColumn28, Me.GridColumn29, Me.GridColumn30, Me.GridColumn31})
        Me.GridViewRequestAll.GridControl = Me.GridRequestAll
        Me.GridViewRequestAll.Name = "GridViewRequestAll"
        Me.GridViewRequestAll.OptionsBehavior.Editable = False
        Me.GridViewRequestAll.OptionsView.ShowGroupPanel = False
        '
        'GridColumn22
        '
        Me.GridColumn22.Caption = "No Request"
        Me.GridColumn22.FieldName = "NoRequest"
        Me.GridColumn22.MinWidth = 25
        Me.GridColumn22.Name = "GridColumn22"
        Me.GridColumn22.OptionsColumn.FixedWidth = True
        Me.GridColumn22.Visible = True
        Me.GridColumn22.VisibleIndex = 0
        Me.GridColumn22.Width = 130
        '
        'GridColumn23
        '
        Me.GridColumn23.Caption = "NIK"
        Me.GridColumn23.FieldName = "NIK"
        Me.GridColumn23.MinWidth = 25
        Me.GridColumn23.Name = "GridColumn23"
        Me.GridColumn23.OptionsColumn.FixedWidth = True
        Me.GridColumn23.Visible = True
        Me.GridColumn23.VisibleIndex = 1
        Me.GridColumn23.Width = 100
        '
        'GridColumn24
        '
        Me.GridColumn24.Caption = "Nama"
        Me.GridColumn24.FieldName = "Nama"
        Me.GridColumn24.MinWidth = 25
        Me.GridColumn24.Name = "GridColumn24"
        Me.GridColumn24.OptionsColumn.FixedWidth = True
        Me.GridColumn24.Visible = True
        Me.GridColumn24.VisibleIndex = 2
        Me.GridColumn24.Width = 200
        '
        'GridColumn25
        '
        Me.GridColumn25.Caption = "Tanggal"
        Me.GridColumn25.FieldName = "Date"
        Me.GridColumn25.MinWidth = 25
        Me.GridColumn25.Name = "GridColumn25"
        Me.GridColumn25.OptionsColumn.FixedWidth = True
        Me.GridColumn25.Visible = True
        Me.GridColumn25.VisibleIndex = 3
        Me.GridColumn25.Width = 110
        '
        'GridColumn26
        '
        Me.GridColumn26.Caption = "Dept ID"
        Me.GridColumn26.FieldName = "DeptID"
        Me.GridColumn26.MinWidth = 25
        Me.GridColumn26.Name = "GridColumn26"
        Me.GridColumn26.OptionsColumn.FixedWidth = True
        Me.GridColumn26.Visible = True
        Me.GridColumn26.VisibleIndex = 4
        Me.GridColumn26.Width = 70
        '
        'GridColumn27
        '
        Me.GridColumn27.Caption = "Travel Type"
        Me.GridColumn27.FieldName = "TravelType"
        Me.GridColumn27.MinWidth = 25
        Me.GridColumn27.Name = "GridColumn27"
        Me.GridColumn27.OptionsColumn.FixedWidth = True
        Me.GridColumn27.Visible = True
        Me.GridColumn27.VisibleIndex = 5
        Me.GridColumn27.Width = 90
        '
        'GridColumn28
        '
        Me.GridColumn28.Caption = "Golongan"
        Me.GridColumn28.FieldName = "Golongan"
        Me.GridColumn28.MinWidth = 25
        Me.GridColumn28.Name = "GridColumn28"
        Me.GridColumn28.OptionsColumn.FixedWidth = True
        Me.GridColumn28.Visible = True
        Me.GridColumn28.VisibleIndex = 6
        Me.GridColumn28.Width = 80
        '
        'GridColumn29
        '
        Me.GridColumn29.Caption = "Purpose"
        Me.GridColumn29.FieldName = "Purpose"
        Me.GridColumn29.MinWidth = 25
        Me.GridColumn29.Name = "GridColumn29"
        Me.GridColumn29.Visible = True
        Me.GridColumn29.VisibleIndex = 7
        Me.GridColumn29.Width = 94
        '
        'GridColumn30
        '
        Me.GridColumn30.Caption = "Status"
        Me.GridColumn30.FieldName = "Status"
        Me.GridColumn30.MinWidth = 25
        Me.GridColumn30.Name = "GridColumn30"
        Me.GridColumn30.OptionsColumn.FixedWidth = True
        Me.GridColumn30.Visible = True
        Me.GridColumn30.VisibleIndex = 8
        Me.GridColumn30.Width = 80
        '
        'GridColumn31
        '
        Me.GridColumn31.Caption = "Approved"
        Me.GridColumn31.FieldName = "Approved"
        Me.GridColumn31.MinWidth = 25
        Me.GridColumn31.Name = "GridColumn31"
        Me.GridColumn31.OptionsColumn.FixedWidth = True
        Me.GridColumn31.Visible = True
        Me.GridColumn31.VisibleIndex = 9
        Me.GridColumn31.Width = 90
        '
        'FrmTravelRequest
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.ClientSize = New System.Drawing.Size(1524, 564)
        Me.Controls.Add(Me.XtraTabControl1)
        Me.Name = "FrmTravelRequest"
        Me.Controls.SetChildIndex(Me.XtraTabControl1, 0)
        CType(Me.GridApprovedReq, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewApproved, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CApproved, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CComment, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.XtraTabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.XtraTabControl1.ResumeLayout(False)
        Me.TabPageRequest.ResumeLayout(False)
        CType(Me.GridRequest, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewRequest, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPageApproved.ResumeLayout(False)
        Me.TabPageRequestAll.ResumeLayout(False)
        CType(Me.GridRequestAll, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewRequestAll, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GridApprovedReq As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewApproved As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn1 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn2 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn3 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn4 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn5 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn6 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn7 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn8 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn19 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn20 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents XtraTabControl1 As DevExpress.XtraTab.XtraTabControl
    Friend WithEvents TabPageRequest As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridRequest As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewRequest As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn10 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn11 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn12 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn13 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn14 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn15 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn16 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn17 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn18 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents TabPageApproved As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents CApproved As DevExpress.XtraEditors.Repository.RepositoryItemComboBox
    Friend WithEvents GridColumn9 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn21 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CComment As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
    Friend WithEvents TabPageRequestAll As DevExpress.XtraTab.XtraTabPage
    Friend WithEvents GridRequestAll As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewRequestAll As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents GridColumn22 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn23 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn24 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn25 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn26 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn27 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn28 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn29 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn30 As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents GridColumn31 As DevExpress.XtraGrid.Columns.GridColumn
End Class
