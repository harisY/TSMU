<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmMktExcelPrice
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMktExcelPrice))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.btnCheck = New DevExpress.XtraEditors.SimpleButton()
        Me.btnBrowse = New DevExpress.XtraEditors.SimpleButton()
        Me.txtFileName = New DevExpress.XtraEditors.TextEdit()
        Me.txtTemplate = New DevExpress.XtraEditors.LookUpEdit()
        Me.txtCustomer = New DevExpress.XtraEditors.ButtonEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.GridResult = New DevExpress.XtraGrid.GridControl()
        Me.GridViewResult = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.ColCheck = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CCheck = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.ColNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColNoExcel = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPartNo = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColInvtID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColPartName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColOldPrice = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColNewPriceR = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColNewPriceS = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColEffectiveDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColStatus = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColMessage = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ColMaxTotTrans = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl3 = New DevExpress.XtraLayout.LayoutControl()
        Me.lblTotSelect = New DevExpress.XtraEditors.LabelControl()
        Me.lblInfo = New DevExpress.XtraEditors.LabelControl()
        Me.lblWarning = New DevExpress.XtraEditors.LabelControl()
        Me.lblError = New DevExpress.XtraEditors.LabelControl()
        Me.lblSuccess = New DevExpress.XtraEditors.LabelControl()
        Me.btnExport = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem12 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.LayoutControlItem8 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtFileName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtTemplate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCustomer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl2.SuspendLayout()
        CType(Me.GridResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewResult, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CCheck, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl3.SuspendLayout()
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.LayoutControl1, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.LayoutControl2, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.LayoutControl3, 0, 2)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 3
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 62.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 56.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1671, 910)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.btnCheck)
        Me.LayoutControl1.Controls.Add(Me.btnBrowse)
        Me.LayoutControl1.Controls.Add(Me.txtFileName)
        Me.LayoutControl1.Controls.Add(Me.txtTemplate)
        Me.LayoutControl1.Controls.Add(Me.txtCustomer)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(3, 4)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(1665, 54)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'btnCheck
        '
        Me.btnCheck.Location = New System.Drawing.Point(1551, 14)
        Me.btnCheck.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCheck.MaximumSize = New System.Drawing.Size(101, 0)
        Me.btnCheck.MinimumSize = New System.Drawing.Size(101, 0)
        Me.btnCheck.Name = "btnCheck"
        Me.btnCheck.Size = New System.Drawing.Size(101, 32)
        Me.btnCheck.StyleController = Me.LayoutControl1
        Me.btnCheck.TabIndex = 8
        Me.btnCheck.Text = "Check"
        '
        'btnBrowse
        '
        Me.btnBrowse.Location = New System.Drawing.Point(1437, 14)
        Me.btnBrowse.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnBrowse.MaximumSize = New System.Drawing.Size(101, 0)
        Me.btnBrowse.MinimumSize = New System.Drawing.Size(101, 0)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(101, 32)
        Me.btnBrowse.StyleController = Me.LayoutControl1
        Me.btnBrowse.TabIndex = 6
        Me.btnBrowse.Text = "Browse"
        '
        'txtFileName
        '
        Me.txtFileName.Location = New System.Drawing.Point(781, 14)
        Me.txtFileName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(643, 28)
        Me.txtFileName.StyleController = Me.LayoutControl1
        Me.txtFileName.TabIndex = 5
        '
        'txtTemplate
        '
        Me.txtTemplate.Location = New System.Drawing.Point(499, 14)
        Me.txtTemplate.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtTemplate.Name = "txtTemplate"
        Me.txtTemplate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtTemplate.Properties.Columns.AddRange(New DevExpress.XtraEditors.Controls.LookUpColumnInfo() {New DevExpress.XtraEditors.Controls.LookUpColumnInfo("TemplateID", "Template ID", 30, DevExpress.Utils.FormatType.None, "", False, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default]), New DevExpress.XtraEditors.Controls.LookUpColumnInfo("Desc", "", 10, DevExpress.Utils.FormatType.None, "", True, DevExpress.Utils.HorzAlignment.[Default], DevExpress.Data.ColumnSortOrder.None, DevExpress.Utils.DefaultBoolean.[Default])})
        Me.txtTemplate.Properties.DisplayMember = "Desc"
        Me.txtTemplate.Properties.NullText = ""
        Me.txtTemplate.Properties.ShowFooter = False
        Me.txtTemplate.Properties.ShowHeader = False
        Me.txtTemplate.Properties.ValueMember = "TemplateID"
        Me.txtTemplate.Size = New System.Drawing.Size(196, 28)
        Me.txtTemplate.StyleController = Me.LayoutControl1
        Me.txtTemplate.TabIndex = 4
        '
        'txtCustomer
        '
        Me.txtCustomer.Location = New System.Drawing.Point(86, 14)
        Me.txtCustomer.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtCustomer.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txtCustomer.Size = New System.Drawing.Size(327, 28)
        Me.txtCustomer.StyleController = Me.LayoutControl1
        Me.txtCustomer.TabIndex = 9
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem2, Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem6, Me.LayoutControlItem5})
        Me.Root.Name = "Root"
        Me.Root.Padding = New DevExpress.XtraLayout.Utils.Padding(11, 11, 12, 0)
        Me.Root.Size = New System.Drawing.Size(1665, 54)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.txtTemplate
        Me.LayoutControlItem2.Location = New System.Drawing.Point(413, 0)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 11, 2, 2)
        Me.LayoutControlItem2.Size = New System.Drawing.Size(282, 42)
        Me.LayoutControlItem2.Text = "Template"
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(70, 19)
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtFileName
        Me.LayoutControlItem3.Location = New System.Drawing.Point(695, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 11, 2, 2)
        Me.LayoutControlItem3.Size = New System.Drawing.Size(729, 42)
        Me.LayoutControlItem3.Text = "File Name"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(70, 19)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.btnBrowse
        Me.LayoutControlItem4.Location = New System.Drawing.Point(1424, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 11, 2, 2)
        Me.LayoutControlItem4.Size = New System.Drawing.Size(114, 42)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.btnCheck
        Me.LayoutControlItem6.Location = New System.Drawing.Point(1538, 0)
        Me.LayoutControlItem6.Name = "LayoutControlItem6"
        Me.LayoutControlItem6.Size = New System.Drawing.Size(105, 42)
        Me.LayoutControlItem6.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem6.TextVisible = False
        '
        'LayoutControlItem5
        '
        Me.LayoutControlItem5.Control = Me.txtCustomer
        Me.LayoutControlItem5.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem5.Name = "LayoutControlItem5"
        Me.LayoutControlItem5.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 11, 2, 2)
        Me.LayoutControlItem5.Size = New System.Drawing.Size(413, 42)
        Me.LayoutControlItem5.Text = "Customer"
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(70, 19)
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.GridResult)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl2.Location = New System.Drawing.Point(3, 66)
        Me.LayoutControl2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.Root = Me.LayoutControlGroup1
        Me.LayoutControl2.Size = New System.Drawing.Size(1665, 784)
        Me.LayoutControl2.TabIndex = 1
        Me.LayoutControl2.Text = "LayoutControl2"
        '
        'GridResult
        '
        Me.GridResult.EmbeddedNavigator.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GridResult.Location = New System.Drawing.Point(13, 4)
        Me.GridResult.MainView = Me.GridViewResult
        Me.GridResult.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GridResult.Name = "GridResult"
        Me.GridResult.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CCheck})
        Me.GridResult.Size = New System.Drawing.Size(1639, 776)
        Me.GridResult.TabIndex = 4
        Me.GridResult.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewResult})
        '
        'GridViewResult
        '
        Me.GridViewResult.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridViewResult.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridViewResult.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.ColCheck, Me.ColNo, Me.ColNoExcel, Me.ColPartNo, Me.ColInvtID, Me.ColPartName, Me.ColOldPrice, Me.ColNewPriceR, Me.ColNewPriceS, Me.ColEffectiveDate, Me.ColStatus, Me.ColMessage, Me.ColMaxTotTrans})
        Me.GridViewResult.DetailHeight = 437
        Me.GridViewResult.GridControl = Me.GridResult
        Me.GridViewResult.Name = "GridViewResult"
        Me.GridViewResult.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full
        Me.GridViewResult.OptionsView.ColumnAutoWidth = False
        Me.GridViewResult.OptionsView.ShowGroupPanel = False
        '
        'ColCheck
        '
        Me.ColCheck.Caption = "Check"
        Me.ColCheck.ColumnEdit = Me.CCheck
        Me.ColCheck.FieldName = "Check"
        Me.ColCheck.MinWidth = 28
        Me.ColCheck.Name = "ColCheck"
        Me.ColCheck.Visible = True
        Me.ColCheck.VisibleIndex = 0
        Me.ColCheck.Width = 106
        '
        'CCheck
        '
        Me.CCheck.AutoHeight = False
        Me.CCheck.Name = "CCheck"
        '
        'ColNo
        '
        Me.ColNo.AppearanceCell.Options.UseTextOptions = True
        Me.ColNo.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColNo.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ColNo.AppearanceHeader.Options.UseTextOptions = True
        Me.ColNo.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColNo.Caption = "No"
        Me.ColNo.FieldName = "No"
        Me.ColNo.MinWidth = 28
        Me.ColNo.Name = "ColNo"
        Me.ColNo.OptionsColumn.AllowEdit = False
        Me.ColNo.Visible = True
        Me.ColNo.VisibleIndex = 1
        Me.ColNo.Width = 106
        '
        'ColNoExcel
        '
        Me.ColNoExcel.AppearanceCell.Options.UseTextOptions = True
        Me.ColNoExcel.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColNoExcel.AppearanceCell.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.ColNoExcel.AppearanceHeader.Options.UseTextOptions = True
        Me.ColNoExcel.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.ColNoExcel.Caption = "No Excel"
        Me.ColNoExcel.FieldName = "NoExcel"
        Me.ColNoExcel.MinWidth = 28
        Me.ColNoExcel.Name = "ColNoExcel"
        Me.ColNoExcel.OptionsColumn.AllowEdit = False
        Me.ColNoExcel.Visible = True
        Me.ColNoExcel.VisibleIndex = 2
        Me.ColNoExcel.Width = 106
        '
        'ColPartNo
        '
        Me.ColPartNo.Caption = "Part No"
        Me.ColPartNo.FieldName = "PartNo"
        Me.ColPartNo.MinWidth = 28
        Me.ColPartNo.Name = "ColPartNo"
        Me.ColPartNo.OptionsColumn.AllowEdit = False
        Me.ColPartNo.Visible = True
        Me.ColPartNo.VisibleIndex = 3
        Me.ColPartNo.Width = 106
        '
        'ColInvtID
        '
        Me.ColInvtID.Caption = "Invt ID"
        Me.ColInvtID.FieldName = "InvtID"
        Me.ColInvtID.MinWidth = 28
        Me.ColInvtID.Name = "ColInvtID"
        Me.ColInvtID.OptionsColumn.AllowEdit = False
        Me.ColInvtID.Visible = True
        Me.ColInvtID.VisibleIndex = 4
        Me.ColInvtID.Width = 106
        '
        'ColPartName
        '
        Me.ColPartName.Caption = "Part Name"
        Me.ColPartName.FieldName = "PartName"
        Me.ColPartName.MinWidth = 28
        Me.ColPartName.Name = "ColPartName"
        Me.ColPartName.OptionsColumn.AllowEdit = False
        Me.ColPartName.Visible = True
        Me.ColPartName.VisibleIndex = 5
        Me.ColPartName.Width = 106
        '
        'ColOldPrice
        '
        Me.ColOldPrice.Caption = "Old Price"
        Me.ColOldPrice.FieldName = "OldPrice"
        Me.ColOldPrice.MinWidth = 28
        Me.ColOldPrice.Name = "ColOldPrice"
        Me.ColOldPrice.OptionsColumn.AllowEdit = False
        Me.ColOldPrice.Visible = True
        Me.ColOldPrice.VisibleIndex = 6
        Me.ColOldPrice.Width = 106
        '
        'ColNewPriceR
        '
        Me.ColNewPriceR.Caption = "New Price R"
        Me.ColNewPriceR.FieldName = "NewPriceR"
        Me.ColNewPriceR.MinWidth = 28
        Me.ColNewPriceR.Name = "ColNewPriceR"
        Me.ColNewPriceR.OptionsColumn.AllowEdit = False
        Me.ColNewPriceR.Visible = True
        Me.ColNewPriceR.VisibleIndex = 7
        Me.ColNewPriceR.Width = 106
        '
        'ColNewPriceS
        '
        Me.ColNewPriceS.Caption = "New Price S"
        Me.ColNewPriceS.FieldName = "NewPriceS"
        Me.ColNewPriceS.MinWidth = 28
        Me.ColNewPriceS.Name = "ColNewPriceS"
        Me.ColNewPriceS.OptionsColumn.AllowEdit = False
        Me.ColNewPriceS.Visible = True
        Me.ColNewPriceS.VisibleIndex = 8
        Me.ColNewPriceS.Width = 106
        '
        'ColEffectiveDate
        '
        Me.ColEffectiveDate.Caption = "Effective Date"
        Me.ColEffectiveDate.FieldName = "EffectiveDate"
        Me.ColEffectiveDate.MinWidth = 28
        Me.ColEffectiveDate.Name = "ColEffectiveDate"
        Me.ColEffectiveDate.OptionsColumn.AllowEdit = False
        Me.ColEffectiveDate.Visible = True
        Me.ColEffectiveDate.VisibleIndex = 9
        Me.ColEffectiveDate.Width = 106
        '
        'ColStatus
        '
        Me.ColStatus.Caption = "Status"
        Me.ColStatus.FieldName = "Status"
        Me.ColStatus.MinWidth = 28
        Me.ColStatus.Name = "ColStatus"
        Me.ColStatus.OptionsColumn.AllowEdit = False
        Me.ColStatus.Visible = True
        Me.ColStatus.VisibleIndex = 10
        Me.ColStatus.Width = 106
        '
        'ColMessage
        '
        Me.ColMessage.Caption = "Message"
        Me.ColMessage.FieldName = "Message"
        Me.ColMessage.MinWidth = 28
        Me.ColMessage.Name = "ColMessage"
        Me.ColMessage.OptionsColumn.AllowEdit = False
        Me.ColMessage.Visible = True
        Me.ColMessage.VisibleIndex = 11
        Me.ColMessage.Width = 106
        '
        'ColMaxTotTrans
        '
        Me.ColMaxTotTrans.Caption = "Total Trans"
        Me.ColMaxTotTrans.FieldName = "MaxTotTrans"
        Me.ColMaxTotTrans.MinWidth = 28
        Me.ColMaxTotTrans.Name = "ColMaxTotTrans"
        Me.ColMaxTotTrans.OptionsColumn.AllowEdit = False
        Me.ColMaxTotTrans.Width = 106
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(11, 11, 2, 2)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1665, 784)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridResult
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1643, 780)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControl3
        '
        Me.LayoutControl3.Controls.Add(Me.lblTotSelect)
        Me.LayoutControl3.Controls.Add(Me.lblInfo)
        Me.LayoutControl3.Controls.Add(Me.lblWarning)
        Me.LayoutControl3.Controls.Add(Me.lblError)
        Me.LayoutControl3.Controls.Add(Me.lblSuccess)
        Me.LayoutControl3.Controls.Add(Me.btnExport)
        Me.LayoutControl3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl3.Location = New System.Drawing.Point(3, 858)
        Me.LayoutControl3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl3.Name = "LayoutControl3"
        Me.LayoutControl3.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = New System.Drawing.Rectangle(1108, 345, 812, 500)
        Me.LayoutControl3.Root = Me.LayoutControlGroup2
        Me.LayoutControl3.Size = New System.Drawing.Size(1665, 48)
        Me.LayoutControl3.TabIndex = 2
        Me.LayoutControl3.Text = "LayoutControl3"
        '
        'lblTotSelect
        '
        Me.lblTotSelect.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        Me.lblTotSelect.ImageOptions.Image = CType(resources.GetObject("lblTotSelect.ImageOptions.Image"), System.Drawing.Image)
        Me.lblTotSelect.Location = New System.Drawing.Point(327, 4)
        Me.lblTotSelect.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblTotSelect.Name = "lblTotSelect"
        Me.lblTotSelect.Size = New System.Drawing.Size(79, 20)
        Me.lblTotSelect.StyleController = Me.LayoutControl3
        Me.lblTotSelect.TabIndex = 10
        Me.lblTotSelect.Text = "Selected"
        '
        'lblInfo
        '
        Me.lblInfo.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        Me.lblInfo.ImageOptions.Image = CType(resources.GetObject("lblInfo.ImageOptions.Image"), System.Drawing.Image)
        Me.lblInfo.Location = New System.Drawing.Point(101, 4)
        Me.lblInfo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblInfo.Name = "lblInfo"
        Me.lblInfo.Size = New System.Drawing.Size(50, 20)
        Me.lblInfo.StyleController = Me.LayoutControl3
        Me.lblInfo.TabIndex = 9
        Me.lblInfo.Text = "Info"
        '
        'lblWarning
        '
        Me.lblWarning.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        Me.lblWarning.ImageOptions.Image = CType(resources.GetObject("lblWarning.ImageOptions.Image"), System.Drawing.Image)
        Me.lblWarning.Location = New System.Drawing.Point(164, 4)
        Me.lblWarning.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblWarning.Name = "lblWarning"
        Me.lblWarning.Size = New System.Drawing.Size(80, 20)
        Me.lblWarning.StyleController = Me.LayoutControl3
        Me.lblWarning.TabIndex = 8
        Me.lblWarning.Text = "Warning"
        '
        'lblError
        '
        Me.lblError.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        Me.lblError.ImageOptions.Image = CType(resources.GetObject("lblError.ImageOptions.Image"), System.Drawing.Image)
        Me.lblError.Location = New System.Drawing.Point(257, 4)
        Me.lblError.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(57, 20)
        Me.lblError.StyleController = Me.LayoutControl3
        Me.lblError.TabIndex = 7
        Me.lblError.Text = "Error"
        '
        'lblSuccess
        '
        Me.lblSuccess.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        Me.lblSuccess.ImageOptions.Image = CType(resources.GetObject("lblSuccess.ImageOptions.Image"), System.Drawing.Image)
        Me.lblSuccess.Location = New System.Drawing.Point(13, 4)
        Me.lblSuccess.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.lblSuccess.Name = "lblSuccess"
        Me.lblSuccess.Size = New System.Drawing.Size(75, 20)
        Me.lblSuccess.StyleController = Me.LayoutControl3
        Me.lblSuccess.TabIndex = 6
        Me.lblSuccess.Text = "Success"
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(1532, 4)
        Me.btnExport.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnExport.MaximumSize = New System.Drawing.Size(120, 0)
        Me.btnExport.MinimumSize = New System.Drawing.Size(120, 0)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnExport.Size = New System.Drawing.Size(120, 32)
        Me.btnExport.StyleController = Me.LayoutControl3
        Me.btnExport.TabIndex = 4
        Me.btnExport.Text = "Save To Excel"
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem7, Me.LayoutControlItem9, Me.LayoutControlItem10, Me.LayoutControlItem11, Me.LayoutControlItem12, Me.EmptySpaceItem1, Me.LayoutControlItem8})
        Me.LayoutControlGroup2.Name = "Root"
        Me.LayoutControlGroup2.Padding = New DevExpress.XtraLayout.Utils.Padding(11, 11, 2, 2)
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1665, 48)
        Me.LayoutControlGroup2.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.btnExport
        Me.LayoutControlItem7.Location = New System.Drawing.Point(1510, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Padding = New DevExpress.XtraLayout.Utils.Padding(11, 2, 2, 2)
        Me.LayoutControlItem7.Size = New System.Drawing.Size(133, 44)
        Me.LayoutControlItem7.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem7.TextVisible = False
        '
        'LayoutControlItem9
        '
        Me.LayoutControlItem9.Control = Me.lblSuccess
        Me.LayoutControlItem9.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem9.Name = "LayoutControlItem9"
        Me.LayoutControlItem9.Size = New System.Drawing.Size(79, 44)
        Me.LayoutControlItem9.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem9.TextVisible = False
        '
        'LayoutControlItem10
        '
        Me.LayoutControlItem10.Control = Me.lblError
        Me.LayoutControlItem10.Location = New System.Drawing.Point(235, 0)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Padding = New DevExpress.XtraLayout.Utils.Padding(11, 2, 2, 2)
        Me.LayoutControlItem10.Size = New System.Drawing.Size(70, 44)
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.lblWarning
        Me.LayoutControlItem11.Location = New System.Drawing.Point(142, 0)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Padding = New DevExpress.XtraLayout.Utils.Padding(11, 2, 2, 2)
        Me.LayoutControlItem11.Size = New System.Drawing.Size(93, 44)
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'LayoutControlItem12
        '
        Me.LayoutControlItem12.Control = Me.lblInfo
        Me.LayoutControlItem12.Location = New System.Drawing.Point(79, 0)
        Me.LayoutControlItem12.Name = "LayoutControlItem12"
        Me.LayoutControlItem12.Padding = New DevExpress.XtraLayout.Utils.Padding(11, 2, 2, 2)
        Me.LayoutControlItem12.Size = New System.Drawing.Size(63, 44)
        Me.LayoutControlItem12.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem12.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(397, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(1113, 44)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'LayoutControlItem8
        '
        Me.LayoutControlItem8.Control = Me.lblTotSelect
        Me.LayoutControlItem8.Location = New System.Drawing.Point(305, 0)
        Me.LayoutControlItem8.Name = "LayoutControlItem8"
        Me.LayoutControlItem8.Padding = New DevExpress.XtraLayout.Utils.Padding(11, 2, 2, 2)
        Me.LayoutControlItem8.Size = New System.Drawing.Size(92, 44)
        Me.LayoutControlItem8.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem8.TextVisible = False
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'FrmMktExcelPrice
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1671, 910)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmMktExcelPrice"
        Me.Text = "Upload Price"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtFileName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtTemplate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCustomer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl2.ResumeLayout(False)
        CType(Me.GridResult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewResult, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CCheck, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlGroup1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControl3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl3.ResumeLayout(False)
        CType(Me.LayoutControlGroup2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem10, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem11, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem12, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem8, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents btnBrowse As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtFileName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem3 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem4 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControl2 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents GridResult As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewResult As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents LayoutControlGroup1 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents btnCheck As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlItem6 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents txtTemplate As DevExpress.XtraEditors.LookUpEdit
    Friend WithEvents LayoutControl3 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents btnExport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtCustomer As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents ColCheck As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CCheck As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents ColNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNoExcel As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPartNo As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColInvtID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColPartName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColOldPrice As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNewPriceR As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColNewPriceS As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColEffectiveDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColStatus As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ColMessage As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents lblInfo As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblWarning As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblError As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblSuccess As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem12 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
    Friend WithEvents lblTotSelect As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem8 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents ColMaxTotTrans As DevExpress.XtraGrid.Columns.GridColumn
End Class
