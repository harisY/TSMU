Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class FrmForecast_PO_TempTable
    Private _Dt As DataTable
    Private columnValues As New List(Of String)()
    Public Sub New(ByVal Dt As DataTable)

        ' This call is required by the designer.
        InitializeComponent()
        _Dt = New DataTable
        _Dt = Dt
        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Private Sub FrmForecast_PO_TempTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Proc_EnableButtons(False, True, False, False, False, False, False, False, False, False, False, False)
        GridControl1.DataSource = _Dt
        If GridView1.RowCount > 0 Then
            GridView1.BestFitColumns()
            GridCellFormat(GridView1)
            Dim values = From myRow In _Dt.AsEnumerable()
                         Select myRow.Field(Of String)("InvtID")
            columnValues = values.ToList()
        End If
        'For Each col As GridColumn In GridView1.Columns
        '    If col.Name.ToLower = "colsite" OrElse col.Name.ToLower = "colflag" Then
        '        col.OptionsColumn.AllowEdit = True
        '    Else
        '        col.OptionsColumn.AllowEdit = False
        '    End If
        'Next
        'SetEditColumnGrid()
    End Sub
    Private Sub SetEditColumnGrid()
        Try
            Dim cmbSite As RepositoryItemComboBox = New RepositoryItemComboBox()
            Dim cmbFlag As RepositoryItemComboBox = New RepositoryItemComboBox()

            AddHandler cmbSite.EditValueChanged, AddressOf ComboBox_EditValueChanged
            AddHandler cmbFlag.EditValueChanged, AddressOf ComboBox_EditValueChanged

            cmbSite.Items.AddRange(New String() {"TNG-U", "TSC3-U"})
            cmbFlag.Items.AddRange(New String() {"N/A", "ADMSPD", "KAP TSC1", "KAP TSC3", "SAP TSC1", "SAP TSC3"})

            With GridView1
                .Columns("Site").ColumnEdit = cmbSite
                .Columns("Flag").ColumnEdit = cmbFlag
            End With
            With GridControl1.RepositoryItems
                .Add(cmbSite)
                .Add(cmbFlag)
            End With

        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub ComboBox_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)

        Try
            GridView1.PostEditor()
            GridView1.UpdateCurrentRow()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub
    Public Overrides Sub Proc_SaveData()
        Try
            For i As Integer = 0 To GridView1.RowCount - 1

            Next
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub GridView1_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView1.RowStyle

        'Dim view As GridView = TryCast(sender, GridView)

        'If view.FocusedRowHandle >= 0 Then
        '    Dim valueToCompare As String = view.GetRowCellDisplayText(view.FocusedRowHandle, "InvtID")
        '    Dim rowValue As String = view.GetRowCellDisplayText(e.RowHandle, "InvtID")

        '    If valueToCompare = rowValue Then
        '        e.Appearance.BackColor = Color.Salmon
        '        e.HighPriority = True
        '    End If
        'End If
        Dim val = (TryCast(sender, GridView)).GetRowCellValue(e.RowHandle, "InvtID")
        If val Is Nothing Then
            Return
        End If
        Dim svalue As String = val.ToString()
        If columnValues.Where(Function(s) s.Equals(svalue)).ToList().Count > 1 Then
            e.Appearance.BackColor = Color.Salmon
        End If
    End Sub

    Private Sub GridView1_FocusedRowChanged(sender As Object, e As FocusedRowChangedEventArgs) Handles GridView1.FocusedRowChanged
        'Dim view As GridView = TryCast(sender, GridView)
        'view.LayoutChanged()
    End Sub

End Class
