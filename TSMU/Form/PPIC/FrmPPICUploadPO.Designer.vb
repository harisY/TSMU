<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmPPICUploadPO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPPICUploadPO))
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.btnCheck = New DevExpress.XtraEditors.SimpleButton()
        Me.btnBrowse = New DevExpress.XtraEditors.SimpleButton()
        Me.txtFileName = New DevExpress.XtraEditors.TextEdit()
        Me.txtCustomer = New DevExpress.XtraEditors.ButtonEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem3 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem4 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem6 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem5 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl2 = New DevExpress.XtraLayout.LayoutControl()
        Me.GridResult = New DevExpress.XtraGrid.GridControl()
        Me.GridViewResult = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.CCheck = New DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit()
        Me.LayoutControlGroup1 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControl3 = New DevExpress.XtraLayout.LayoutControl()
        Me.lblWarning = New DevExpress.XtraEditors.LabelControl()
        Me.lblError = New DevExpress.XtraEditors.LabelControl()
        Me.lblSuccess = New DevExpress.XtraEditors.LabelControl()
        Me.btnExport = New DevExpress.XtraEditors.SimpleButton()
        Me.LayoutControlGroup2 = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem7 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem9 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem10 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem11 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.EmptySpaceItem1 = New DevExpress.XtraLayout.EmptySpaceItem()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.TableLayoutPanel1.SuspendLayout()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.txtFileName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCustomer.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1638, 910)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.btnCheck)
        Me.LayoutControl1.Controls.Add(Me.btnBrowse)
        Me.LayoutControl1.Controls.Add(Me.txtFileName)
        Me.LayoutControl1.Controls.Add(Me.txtCustomer)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(3, 4)
        Me.LayoutControl1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(1632, 54)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'btnCheck
        '
        Me.btnCheck.Location = New System.Drawing.Point(1518, 14)
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
        Me.btnBrowse.Location = New System.Drawing.Point(1404, 14)
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
        Me.txtFileName.Location = New System.Drawing.Point(534, 14)
        Me.txtFileName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtFileName.Name = "txtFileName"
        Me.txtFileName.Size = New System.Drawing.Size(857, 28)
        Me.txtFileName.StyleController = Me.LayoutControl1
        Me.txtFileName.TabIndex = 5
        '
        'txtCustomer
        '
        Me.txtCustomer.Location = New System.Drawing.Point(94, 14)
        Me.txtCustomer.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtCustomer.Name = "txtCustomer"
        Me.txtCustomer.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton()})
        Me.txtCustomer.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor
        Me.txtCustomer.Size = New System.Drawing.Size(346, 28)
        Me.txtCustomer.StyleController = Me.LayoutControl1
        Me.txtCustomer.TabIndex = 9
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem3, Me.LayoutControlItem4, Me.LayoutControlItem6, Me.LayoutControlItem5})
        Me.Root.Name = "Root"
        Me.Root.Padding = New DevExpress.XtraLayout.Utils.Padding(11, 11, 12, 0)
        Me.Root.Size = New System.Drawing.Size(1632, 54)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem3
        '
        Me.LayoutControlItem3.Control = Me.txtFileName
        Me.LayoutControlItem3.Location = New System.Drawing.Point(440, 0)
        Me.LayoutControlItem3.Name = "LayoutControlItem3"
        Me.LayoutControlItem3.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 11, 2, 2)
        Me.LayoutControlItem3.Size = New System.Drawing.Size(951, 42)
        Me.LayoutControlItem3.Text = "File Name"
        Me.LayoutControlItem3.TextSize = New System.Drawing.Size(78, 19)
        '
        'LayoutControlItem4
        '
        Me.LayoutControlItem4.Control = Me.btnBrowse
        Me.LayoutControlItem4.Location = New System.Drawing.Point(1391, 0)
        Me.LayoutControlItem4.Name = "LayoutControlItem4"
        Me.LayoutControlItem4.Padding = New DevExpress.XtraLayout.Utils.Padding(2, 11, 2, 2)
        Me.LayoutControlItem4.Size = New System.Drawing.Size(114, 42)
        Me.LayoutControlItem4.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem4.TextVisible = False
        '
        'LayoutControlItem6
        '
        Me.LayoutControlItem6.Control = Me.btnCheck
        Me.LayoutControlItem6.Location = New System.Drawing.Point(1505, 0)
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
        Me.LayoutControlItem5.Size = New System.Drawing.Size(440, 42)
        Me.LayoutControlItem5.Text = "Customer  "
        Me.LayoutControlItem5.TextSize = New System.Drawing.Size(78, 19)
        '
        'LayoutControl2
        '
        Me.LayoutControl2.Controls.Add(Me.GridResult)
        Me.LayoutControl2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl2.Location = New System.Drawing.Point(3, 66)
        Me.LayoutControl2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.LayoutControl2.Name = "LayoutControl2"
        Me.LayoutControl2.Root = Me.LayoutControlGroup1
        Me.LayoutControl2.Size = New System.Drawing.Size(1632, 784)
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
        Me.GridResult.Size = New System.Drawing.Size(1606, 776)
        Me.GridResult.TabIndex = 4
        Me.GridResult.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewResult})
        '
        'GridViewResult
        '
        Me.GridViewResult.Appearance.HeaderPanel.Options.UseTextOptions = True
        Me.GridViewResult.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center
        Me.GridViewResult.Appearance.HeaderPanel.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center
        Me.GridViewResult.Appearance.HeaderPanel.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap
        Me.GridViewResult.DetailHeight = 437
        Me.GridViewResult.GridControl = Me.GridResult
        Me.GridViewResult.Name = "GridViewResult"
        Me.GridViewResult.OptionsBehavior.Editable = False
        Me.GridViewResult.OptionsView.ColumnAutoWidth = False
        Me.GridViewResult.OptionsView.ShowGroupPanel = False
        '
        'CCheck
        '
        Me.CCheck.AutoHeight = False
        Me.CCheck.Name = "CCheck"
        '
        'LayoutControlGroup1
        '
        Me.LayoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup1.GroupBordersVisible = False
        Me.LayoutControlGroup1.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1})
        Me.LayoutControlGroup1.Name = "LayoutControlGroup1"
        Me.LayoutControlGroup1.Padding = New DevExpress.XtraLayout.Utils.Padding(11, 11, 2, 2)
        Me.LayoutControlGroup1.Size = New System.Drawing.Size(1632, 784)
        Me.LayoutControlGroup1.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.GridResult
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(1610, 780)
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem1.TextVisible = False
        '
        'LayoutControl3
        '
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
        Me.LayoutControl3.Size = New System.Drawing.Size(1632, 48)
        Me.LayoutControl3.TabIndex = 2
        Me.LayoutControl3.Text = "LayoutControl3"
        '
        'lblWarning
        '
        Me.lblWarning.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
        Me.lblWarning.ImageOptions.Image = CType(resources.GetObject("lblWarning.ImageOptions.Image"), System.Drawing.Image)
        Me.lblWarning.Location = New System.Drawing.Point(101, 4)
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
        Me.lblError.Location = New System.Drawing.Point(194, 4)
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
        Me.btnExport.Location = New System.Drawing.Point(1507, 4)
        Me.btnExport.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnExport.MaximumSize = New System.Drawing.Size(112, 0)
        Me.btnExport.MinimumSize = New System.Drawing.Size(101, 0)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnExport.Size = New System.Drawing.Size(112, 32)
        Me.btnExport.StyleController = Me.LayoutControl3
        Me.btnExport.TabIndex = 4
        Me.btnExport.Text = "Save To Excel"
        '
        'LayoutControlGroup2
        '
        Me.LayoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.LayoutControlGroup2.GroupBordersVisible = False
        Me.LayoutControlGroup2.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem7, Me.LayoutControlItem9, Me.LayoutControlItem10, Me.LayoutControlItem11, Me.EmptySpaceItem1})
        Me.LayoutControlGroup2.Name = "Root"
        Me.LayoutControlGroup2.Padding = New DevExpress.XtraLayout.Utils.Padding(11, 11, 2, 2)
        Me.LayoutControlGroup2.Size = New System.Drawing.Size(1632, 48)
        Me.LayoutControlGroup2.TextVisible = False
        '
        'LayoutControlItem7
        '
        Me.LayoutControlItem7.Control = Me.btnExport
        Me.LayoutControlItem7.Location = New System.Drawing.Point(1485, 0)
        Me.LayoutControlItem7.Name = "LayoutControlItem7"
        Me.LayoutControlItem7.Padding = New DevExpress.XtraLayout.Utils.Padding(11, 2, 2, 2)
        Me.LayoutControlItem7.Size = New System.Drawing.Size(125, 44)
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
        Me.LayoutControlItem10.Location = New System.Drawing.Point(172, 0)
        Me.LayoutControlItem10.Name = "LayoutControlItem10"
        Me.LayoutControlItem10.Padding = New DevExpress.XtraLayout.Utils.Padding(11, 2, 2, 2)
        Me.LayoutControlItem10.Size = New System.Drawing.Size(70, 44)
        Me.LayoutControlItem10.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem10.TextVisible = False
        '
        'LayoutControlItem11
        '
        Me.LayoutControlItem11.Control = Me.lblWarning
        Me.LayoutControlItem11.Location = New System.Drawing.Point(79, 0)
        Me.LayoutControlItem11.Name = "LayoutControlItem11"
        Me.LayoutControlItem11.Padding = New DevExpress.XtraLayout.Utils.Padding(11, 2, 2, 2)
        Me.LayoutControlItem11.Size = New System.Drawing.Size(93, 44)
        Me.LayoutControlItem11.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem11.TextVisible = False
        '
        'EmptySpaceItem1
        '
        Me.EmptySpaceItem1.AllowHotTrack = False
        Me.EmptySpaceItem1.Location = New System.Drawing.Point(242, 0)
        Me.EmptySpaceItem1.Name = "EmptySpaceItem1"
        Me.EmptySpaceItem1.Size = New System.Drawing.Size(1243, 44)
        Me.EmptySpaceItem1.TextSize = New System.Drawing.Size(0, 0)
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'FrmPPICUploadPO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1638, 910)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmPPICUploadPO"
        Me.Text = "Upload List PO"
        Me.TableLayoutPanel1.ResumeLayout(False)
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.txtFileName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCustomer.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.EmptySpaceItem1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents btnBrowse As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents txtFileName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
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
    Friend WithEvents LayoutControl3 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents btnExport As DevExpress.XtraEditors.SimpleButton
    Friend WithEvents LayoutControlGroup2 As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents LayoutControlItem7 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem5 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents txtCustomer As DevExpress.XtraEditors.ButtonEdit
    Friend WithEvents CCheck As DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit
    Friend WithEvents lblWarning As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblError As DevExpress.XtraEditors.LabelControl
    Friend WithEvents lblSuccess As DevExpress.XtraEditors.LabelControl
    Friend WithEvents LayoutControlItem9 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem10 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem11 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents EmptySpaceItem1 As DevExpress.XtraLayout.EmptySpaceItem
End Class
