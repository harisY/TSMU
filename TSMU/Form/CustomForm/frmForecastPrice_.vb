Imports DevExpress.XtraEditors.Repository

Public Class frmForecastPrice_
    Dim ObjCommon As CommonModel
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub frmForecastPrice__Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MdiParent = MenuUtamaForm
        WindowState = FormWindowState.Maximized
        'TODO: This line of code loads data into the 'DataSet1.tForecastPrice' table. You can move, or remove it, as needed.
        Me.TForecastPriceTableAdapter.Fill(Me.DataSet1.tForecastPrice)
        With GridView1
            .BestFitColumns()
            .Columns(0).Visible = False
            .FixedLineWidth = 2
            .Columns(1).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            .Columns(2).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            .Columns(3).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            .Columns(4).Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left
            '.OptionsView.ShowFooter = True
            '.OptionsBehavior.Editable = False
        End With
        SetEditColumnGrid()
    End Sub

    Private Sub TForecastPriceBindingNavigatorSaveItem_Click(sender As Object, e As EventArgs) Handles TForecastPriceBindingNavigatorSaveItem.Click
        Me.Validate()
        Me.TForecastPriceBindingSource.EndEdit()
        Me.TableAdapterManager.UpdateAll(Me.DataSet1)
    End Sub
    Private Sub SetEditColumnGrid()
        Try
            Dim cmbCustID As RepositoryItemComboBox = New RepositoryItemComboBox()
            Dim cmbInvtID As RepositoryItemComboBox = New RepositoryItemComboBox()
            Dim cmbSite As RepositoryItemComboBox = New RepositoryItemComboBox()
            Dim cmbOE As RepositoryItemComboBox = New RepositoryItemComboBox()
            Dim cmbFlag As RepositoryItemComboBox = New RepositoryItemComboBox()
            Dim cmbInhouse As RepositoryItemComboBox = New RepositoryItemComboBox()

            AddHandler cmbCustID.EditValueChanged, AddressOf ComboBox_EditValueChanged
            AddHandler cmbInvtID.EditValueChanged, AddressOf ComboBox_EditValueChanged
            AddHandler cmbSite.EditValueChanged, AddressOf ComboBox_EditValueChanged
            AddHandler cmbOE.EditValueChanged, AddressOf ComboBox_EditValueChanged
            AddHandler cmbFlag.EditValueChanged, AddressOf ComboBox_EditValueChanged
            AddHandler cmbInhouse.EditValueChanged, AddressOf ComboBox_EditValueChanged

            ObjCommon = New CommonModel
            Dim dt As New DataTable
            dt = ObjCommon.GeCustID
            cmbCustID.Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                cmbCustID.Items.Add(dt.Rows(i).Item("CustId").ToString())
            Next
            'GridView1.Columns("CustID").ColumnEdit = cmbCustID
            'TForecastPriceGridControl.RepositoryItems.Add(cmbCustID)

            dt = New DataTable
            dt = ObjCommon.GetInvtID
            cmbInvtID.Items.Clear()
            For i As Integer = 0 To dt.Rows.Count - 1
                cmbInvtID.Items.Add(dt.Rows(i).Item("InvtID").ToString())
            Next
            cmbOE.Items.AddRange(New String() {"OE", "PE"})
            cmbSite.Items.AddRange(New String() {"TNG-U", "TSC3-U"})
            cmbFlag.Items.AddRange(New String() {"KAP TSC1", "KAP TSC3", "SAP TSC1", "SAP TSC3"})
            cmbInhouse.Items.AddRange(New String() {"Inhouse", "Subcon"})

            With GridView1
                .Columns("CustID").ColumnEdit = cmbCustID
                .Columns("InvtID").ColumnEdit = cmbInvtID
                .Columns("Oe/Pe").ColumnEdit = cmbOE
                .Columns("IN/SUB").ColumnEdit = cmbInhouse
                .Columns("Site").ColumnEdit = cmbSite
                .Columns("Flag").ColumnEdit = cmbFlag
            End With
            With TForecastPriceGridControl.RepositoryItems
                .Add(cmbCustID)
                .Add(cmbInvtID)
                .Add(cmbOE)
                .Add(cmbInhouse)
                .Add(cmbSite)
                .Add(cmbFlag)
            End With

            'AddHandler GridView1.CustomColumnDisplayText, AddressOf GridView1_CustomColumnDisplayText
            'AddHandler GridView1.ShowingEditor, AddressOf GridView1_ShowingEditor
            'AddHandler GridView1.RowCellStyle, AddressOf GridView1_RowCellStyle
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub ComboBox_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        GridView1.PostEditor()
    End Sub
End Class