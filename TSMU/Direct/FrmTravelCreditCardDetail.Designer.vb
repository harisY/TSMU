<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmTravelCreditCardDetail
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
        Me.txtCreditCardID = New DevExpress.XtraEditors.TextEdit()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtBankName = New DevExpress.XtraEditors.TextEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtAccountName = New DevExpress.XtraEditors.TextEdit()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtType = New DevExpress.XtraEditors.ComboBoxEdit()
        Me.dtExpDate = New DevExpress.XtraEditors.DateEdit()
        Me.DxValidationProvider1 = New DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider()
        Me.GridCreditCard = New DevExpress.XtraGrid.GridControl()
        Me.GridViewCreditCard = New DevExpress.XtraGrid.Views.Grid.GridView()
        Me.CreditCardID = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CreditCardNumber = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.CCreditCardNumber = New DevExpress.XtraEditors.Repository.RepositoryItemTextEdit()
        Me.AccountName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.BankName = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.Type = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.ExpiredDate = New DevExpress.XtraGrid.Columns.GridColumn()
        Me.txtCreditCardNumber = New DevExpress.XtraEditors.TextEdit()
        CType(Me.txtCreditCardID.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBankName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAccountName.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtType.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtExpDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtExpDate.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridCreditCard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.GridViewCreditCard, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CCreditCardNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCreditCardNumber.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtCreditCardID
        '
        Me.txtCreditCardID.Enabled = False
        Me.txtCreditCardID.Location = New System.Drawing.Point(139, 56)
        Me.txtCreditCardID.Name = "txtCreditCardID"
        Me.txtCreditCardID.Size = New System.Drawing.Size(66, 22)
        Me.txtCreditCardID.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 58)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 17)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Credit Card ID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(1771, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 17)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Expired Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(1510, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(40, 17)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Type"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(1168, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 17)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Bank Name"
        '
        'txtBankName
        '
        Me.txtBankName.Location = New System.Drawing.Point(1296, 56)
        Me.txtBankName.Name = "txtBankName"
        Me.txtBankName.Size = New System.Drawing.Size(171, 22)
        Me.txtBankName.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(633, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(100, 17)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Account Name"
        '
        'txtAccountName
        '
        Me.txtAccountName.Location = New System.Drawing.Point(773, 56)
        Me.txtAccountName.Name = "txtAccountName"
        Me.txtAccountName.Size = New System.Drawing.Size(355, 22)
        Me.txtAccountName.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(243, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(133, 17)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Credit Card Number"
        '
        'txtType
        '
        Me.txtType.Location = New System.Drawing.Point(1592, 56)
        Me.txtType.Name = "txtType"
        Me.txtType.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.txtType.Properties.Items.AddRange(New Object() {"VISA", "MASTERCARD"})
        Me.txtType.Size = New System.Drawing.Size(136, 22)
        Me.txtType.TabIndex = 5
        '
        'dtExpDate
        '
        Me.dtExpDate.EditValue = Nothing
        Me.dtExpDate.Location = New System.Drawing.Point(1896, 56)
        Me.dtExpDate.Name = "dtExpDate"
        Me.dtExpDate.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtExpDate.Properties.CalendarTimeProperties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() {New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
        Me.dtExpDate.Properties.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.dtExpDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtExpDate.Properties.EditFormat.FormatString = "dd-MM-yyyy"
        Me.dtExpDate.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.dtExpDate.Properties.Mask.EditMask = "dd-MM-yyyy"
        Me.dtExpDate.Size = New System.Drawing.Size(120, 22)
        Me.dtExpDate.TabIndex = 6
        '
        'GridCreditCard
        '
        Me.GridCreditCard.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GridCreditCard.Location = New System.Drawing.Point(15, 94)
        Me.GridCreditCard.MainView = Me.GridViewCreditCard
        Me.GridCreditCard.Name = "GridCreditCard"
        Me.GridCreditCard.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() {Me.CCreditCardNumber})
        Me.GridCreditCard.Size = New System.Drawing.Size(1505, 463)
        Me.GridCreditCard.TabIndex = 13
        Me.GridCreditCard.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.GridViewCreditCard})
        '
        'GridViewCreditCard
        '
        Me.GridViewCreditCard.Columns.AddRange(New DevExpress.XtraGrid.Columns.GridColumn() {Me.CreditCardID, Me.CreditCardNumber, Me.AccountName, Me.BankName, Me.Type, Me.ExpiredDate})
        Me.GridViewCreditCard.GridControl = Me.GridCreditCard
        Me.GridViewCreditCard.Name = "GridViewCreditCard"
        Me.GridViewCreditCard.OptionsBehavior.Editable = False
        Me.GridViewCreditCard.OptionsView.ColumnAutoWidth = False
        Me.GridViewCreditCard.OptionsView.ShowGroupPanel = False
        '
        'CreditCardID
        '
        Me.CreditCardID.Caption = "Credit Card ID"
        Me.CreditCardID.FieldName = "CreditCardID"
        Me.CreditCardID.MinWidth = 25
        Me.CreditCardID.Name = "CreditCardID"
        Me.CreditCardID.OptionsColumn.FixedWidth = True
        Me.CreditCardID.Visible = True
        Me.CreditCardID.VisibleIndex = 0
        Me.CreditCardID.Width = 120
        '
        'CreditCardNumber
        '
        Me.CreditCardNumber.Caption = "Credit Card Number"
        Me.CreditCardNumber.ColumnEdit = Me.CCreditCardNumber
        Me.CreditCardNumber.DisplayFormat.FormatString = "0000-0000-0000-9999"
        Me.CreditCardNumber.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom
        Me.CreditCardNumber.FieldName = "CreditCardNumber"
        Me.CreditCardNumber.MinWidth = 25
        Me.CreditCardNumber.Name = "CreditCardNumber"
        Me.CreditCardNumber.OptionsColumn.FixedWidth = True
        Me.CreditCardNumber.Visible = True
        Me.CreditCardNumber.VisibleIndex = 1
        Me.CreditCardNumber.Width = 180
        '
        'CCreditCardNumber
        '
        Me.CCreditCardNumber.AutoHeight = False
        Me.CCreditCardNumber.Mask.EditMask = "0000-0000-0000-9999"
        Me.CCreditCardNumber.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple
        Me.CCreditCardNumber.Mask.ShowPlaceHolders = False
        Me.CCreditCardNumber.Mask.UseMaskAsDisplayFormat = True
        Me.CCreditCardNumber.Name = "CCreditCardNumber"
        '
        'AccountName
        '
        Me.AccountName.Caption = "Account Name"
        Me.AccountName.FieldName = "AccountName"
        Me.AccountName.MinWidth = 25
        Me.AccountName.Name = "AccountName"
        Me.AccountName.OptionsColumn.FixedWidth = True
        Me.AccountName.Visible = True
        Me.AccountName.VisibleIndex = 2
        Me.AccountName.Width = 400
        '
        'BankName
        '
        Me.BankName.Caption = "Bank Name"
        Me.BankName.FieldName = "BankName"
        Me.BankName.MinWidth = 25
        Me.BankName.Name = "BankName"
        Me.BankName.OptionsColumn.FixedWidth = True
        Me.BankName.Visible = True
        Me.BankName.VisibleIndex = 3
        Me.BankName.Width = 250
        '
        'Type
        '
        Me.Type.Caption = "Type"
        Me.Type.FieldName = "Type"
        Me.Type.MinWidth = 25
        Me.Type.Name = "Type"
        Me.Type.OptionsColumn.FixedWidth = True
        Me.Type.Visible = True
        Me.Type.VisibleIndex = 4
        Me.Type.Width = 150
        '
        'ExpiredDate
        '
        Me.ExpiredDate.Caption = "Expired Date"
        Me.ExpiredDate.DisplayFormat.FormatString = "dd-MM-yyyy"
        Me.ExpiredDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime
        Me.ExpiredDate.FieldName = "ExpDate"
        Me.ExpiredDate.MinWidth = 25
        Me.ExpiredDate.Name = "ExpiredDate"
        Me.ExpiredDate.OptionsColumn.FixedWidth = True
        Me.ExpiredDate.Visible = True
        Me.ExpiredDate.VisibleIndex = 5
        Me.ExpiredDate.Width = 150
        '
        'txtCreditCardNumber
        '
        Me.txtCreditCardNumber.Location = New System.Drawing.Point(421, 56)
        Me.txtCreditCardNumber.Name = "txtCreditCardNumber"
        Me.txtCreditCardNumber.Properties.Mask.EditMask = "0000-0000-0000-9999"
        Me.txtCreditCardNumber.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Simple
        Me.txtCreditCardNumber.Properties.Mask.ShowPlaceHolders = False
        Me.txtCreditCardNumber.Properties.Mask.UseMaskAsDisplayFormat = True
        Me.txtCreditCardNumber.Size = New System.Drawing.Size(165, 22)
        Me.txtCreditCardNumber.TabIndex = 14
        '
        'FrmTravelCreditCardDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.ClientSize = New System.Drawing.Size(1924, 569)
        Me.Controls.Add(Me.txtCreditCardNumber)
        Me.Controls.Add(Me.GridCreditCard)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtAccountName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtBankName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtCreditCardID)
        Me.Controls.Add(Me.txtType)
        Me.Controls.Add(Me.dtExpDate)
        Me.Name = "FrmTravelCreditCardDetail"
        Me.Controls.SetChildIndex(Me.dtExpDate, 0)
        Me.Controls.SetChildIndex(Me.txtType, 0)
        Me.Controls.SetChildIndex(Me.txtCreditCardID, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtBankName, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txtAccountName, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.GridCreditCard, 0)
        Me.Controls.SetChildIndex(Me.txtCreditCardNumber, 0)
        CType(Me.txtCreditCardID.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBankName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAccountName.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtType.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtExpDate.Properties.CalendarTimeProperties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtExpDate.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DxValidationProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridCreditCard, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.GridViewCreditCard, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CCreditCardNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCreditCardNumber.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents txtCreditCardID As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents txtBankName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label5 As Label
    Friend WithEvents txtAccountName As DevExpress.XtraEditors.TextEdit
    Friend WithEvents Label6 As Label
    Friend WithEvents txtType As DevExpress.XtraEditors.ComboBoxEdit
    Friend WithEvents dtExpDate As DevExpress.XtraEditors.DateEdit
    Friend WithEvents DxValidationProvider1 As DevExpress.XtraEditors.DXErrorProvider.DXValidationProvider
    Friend WithEvents GridCreditCard As DevExpress.XtraGrid.GridControl
    Friend WithEvents GridViewCreditCard As DevExpress.XtraGrid.Views.Grid.GridView
    Friend WithEvents CreditCardID As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents CreditCardNumber As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents AccountName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents BankName As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents Type As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents ExpiredDate As DevExpress.XtraGrid.Columns.GridColumn
    Friend WithEvents txtCreditCardNumber As DevExpress.XtraEditors.TextEdit
    Friend WithEvents CCreditCardNumber As DevExpress.XtraEditors.Repository.RepositoryItemTextEdit
End Class
