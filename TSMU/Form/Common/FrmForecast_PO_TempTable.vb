Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class FrmForecast_PO_TempTable
    Dim _Dt As DataTable
    Dim columnValues As New List(Of String)()

    Public Sub New(ByVal Dt As DataTable)

        ' This call is required by the designer.
        InitializeComponent()
        _Dt = New DataTable
        _Dt = Dt
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    ReadOnly Property NewDt As DataTable
        Get
            Return DtTemp
        End Get
    End Property

    Private Sub FrmForecast_PO_TempTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Proc_EnableButtons(False, True, False, False, False, False, False, False, False, False, False, False)
            GridControl1.DataSource = _Dt
            If GridView1.RowCount > 0 Then
                GridView1.BestFitColumns()
                GridCellFormat(GridView1)
                Dim values = From myRow In _Dt.AsEnumerable()
                             Select myRow.Field(Of String)("PartNo")
                columnValues = values.ToList()
            End If
            For Each col As GridColumn In GridView1.Columns
                If col.Name.ToLower = "colcheck" OrElse col.Name.ToLower = "colinvtid" _
                    OrElse col.Name.ToLower = "colcustname" _
                    OrElse col.Name.ToLower = "coldescription" Then
                    col.OptionsColumn.AllowEdit = True
                Else
                    col.OptionsColumn.AllowEdit = False
                End If
            Next

            If GridView1.RowCount > 0 Then
                Dim TxtInvtId As RepositoryItemTextEdit = New RepositoryItemTextEdit()
                Dim TxtCustName As RepositoryItemTextEdit = New RepositoryItemTextEdit()
                Dim TxtDescr As RepositoryItemTextEdit = New RepositoryItemTextEdit()

                AddHandler TxtInvtId.EditValueChanged, AddressOf Gridview_EditValueChanged
                AddHandler TxtCustName.EditValueChanged, AddressOf Gridview_EditValueChanged
                AddHandler TxtDescr.EditValueChanged, AddressOf Gridview_EditValueChanged
                GridView1.Columns("CustName").ColumnEdit = TxtCustName
                GridView1.Columns("InvtID").ColumnEdit = TxtInvtId
                GridView1.Columns("Description").ColumnEdit = TxtDescr
                With GridControl1.RepositoryItems
                    .Add(TxtCustName)
                    .Add(TxtInvtId)
                    .Add(TxtDescr)
                End With
            End If
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
        'SetEditColumnGrid()
    End Sub

    Private Sub SetEditColumnGrid()
        Try
            Dim cmbSite As RepositoryItemComboBox = New RepositoryItemComboBox()
            Dim cmbFlag As RepositoryItemComboBox = New RepositoryItemComboBox()
            Dim cmbCheck As RepositoryItemCheckEdit = New RepositoryItemCheckEdit()

            'AddHandler cmbSite.EditValueChanged, AddressOf ComboBox_EditValueChanged
            'AddHandler cmbFlag.EditValueChanged, AddressOf ComboBox_EditValueChanged
            AddHandler cmbCheck.EditValueChanged, AddressOf Gridview_EditValueChanged

            cmbSite.Items.AddRange(New String() {"TNG-U", "TSC3-U"})
            cmbFlag.Items.AddRange(New String() {"N/A", "ADMSPD", "KAP TSC1", "KAP TSC3", "SAP TSC1", "SAP TSC3"})

            With GridView1
                '.Columns("Site").ColumnEdit = cmbSite
                '.Columns("Flag").ColumnEdit = cmbFlag
                .Columns("Check").ColumnEdit = cmbCheck
            End With
            With GridControl1.RepositoryItems
                '.Add(cmbSite)
                '.Add(cmbFlag)
                .Add(cmbCheck)
            End With
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Dim edit As DevExpress.XtraEditors.BaseEdit = Nothing

    Private Sub Gridview_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)

        Try
            GridView1.PostEditor()
            GridView1.UpdateCurrentRow()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try
    End Sub

    Public Overrides Sub Proc_SaveData()
        Try
            TempTable()
            For i As Integer = 0 To GridView1.RowCount - 1
                Console.WriteLine(GridView1.GetRowCellValue(i, "Check").ToString.ToLower)
                If GridView1.GetRowCellValue(i, "Check").ToString.ToLower = "true" Then
                    Dim dr As DataRow = DtTemp.NewRow()
                    dr("Tahun") = GridView1.GetRowCellValue(i, "Tahun")
                    dr("CustID") = GridView1.GetRowCellValue(i, "CustID")
                    dr("CustName") = GridView1.GetRowCellValue(i, "CustName")
                    dr("InvtID") = GridView1.GetRowCellValue(i, "InvtID")
                    dr("Description") = GridView1.GetRowCellValue(i, "Description")
                    dr("PartNo") = GridView1.GetRowCellValue(i, "PartNo")
                    dr("Model") = GridView1.GetRowCellValue(i, "Model")
                    dr("Oe") = GridView1.GetRowCellValue(i, "Oe")
                    dr("InSub") = GridView1.GetRowCellValue(i, "InSub")
                    dr("Site") = GridView1.GetRowCellValue(i, "Site")
                    dr("Flag") = GridView1.GetRowCellValue(i, "Flag")
                    dr("N") = GridView1.GetRowCellValue(i, "N")
                    dr("N1") = GridView1.GetRowCellValue(i, "N1")
                    dr("N2") = GridView1.GetRowCellValue(i, "N2")
                    dr("N3") = GridView1.GetRowCellValue(i, "N3")
                    DtTemp.Rows.Add(dr)
                End If
            Next
            Close()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Function IsShipToUSCanada(ByVal view As GridView, ByVal row As Integer) As Boolean
        Try
            Dim val As String = Convert.ToString(view.GetRowCellValue(row, "InvtID"))
            Return (val = "N/A")
        Catch
            Return False
        End Try
    End Function

    Private Sub GridView1_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView1.RowStyle
        If IsShipToUSCanada(GridView1, e.RowHandle) Then
            e.Appearance.BackColor = Color.LightGreen
        End If

        Dim val = (TryCast(sender, GridView)).GetRowCellValue(e.RowHandle, "PartNo")
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

    Dim DtTemp As DataTable

    Private Sub TempTable()
        DtTemp = New DataTable
        DtTemp.Columns.Add("Tahun", GetType(String))
        DtTemp.Columns.Add("CustID", GetType(String))
        DtTemp.Columns.Add("CustName", GetType(String))
        DtTemp.Columns.Add("InvtID", GetType(String))
        DtTemp.Columns.Add("Description", GetType(String))
        DtTemp.Columns.Add("PartNo", GetType(String))
        DtTemp.Columns.Add("Model", GetType(String))
        DtTemp.Columns.Add("Oe", GetType(String))
        DtTemp.Columns.Add("InSub", GetType(String))
        DtTemp.Columns.Add("Site", GetType(String))
        DtTemp.Columns.Add("Flag", GetType(String))
        DtTemp.Columns.Add("N", GetType(Integer))
        DtTemp.Columns.Add("N1", GetType(Integer))
        DtTemp.Columns.Add("N2", GetType(Integer))
        DtTemp.Columns.Add("N3", GetType(Integer))
        DtTemp.Clear()
    End Sub

End Class