Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class FrmForecast_PO_TempTableYIM
    Dim _Dt As DataTable
    'Dim columnValues As New List(Of String)()

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

    Private Sub FrmForecast_PO_TempTableYIM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Proc_EnableButtons(False, True, False, False, True, False, False, False, False, False, False, False)
            GridControl1.DataSource = _Dt
            With GridView1
                .Columns("PartType").Visible = False
                .BestFitColumns()
            End With
            For Each col As GridColumn In GridView1.Columns
                If col.Name.ToLower = "colcheck" Then
                    col.OptionsColumn.AllowEdit = True
                Else
                    col.OptionsColumn.AllowEdit = False
                End If
            Next
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Public Overrides Sub Proc_SaveData()
        Try
            TempTable()
            For i As Integer = 0 To GridView1.RowCount - 1
                If GridView1.GetRowCellValue(i, "Check").ToString.ToLower = "true" Then
                    Dim dr As DataRow = DtTemp.NewRow()
                    dr("Tahun") = GridView1.GetRowCellValue(i, "Tahun")
                    dr("CustID") = GridView1.GetRowCellValue(i, "CustID")
                    dr("CustName") = GridView1.GetRowCellValue(i, "CustName")
                    If GridView1.GetRowCellValue(i, "InvtID") Is DBNull.Value OrElse GridView1.GetRowCellValue(i, "InvtID") = "" Then
                        Throw New Exception("Inventory ID Tidak Boleh Kosong !")
                    Else
                        dr("InvtID") = GridView1.GetRowCellValue(i, "InvtID")
                    End If
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

    Public Overrides Sub Proc_Excel()
        If GridView1.RowCount > 0 Then
            SaveToExcel(GridControl1)
        Else
            MsgBox("Grid Kosong !")
        End If
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

        Dim val = (TryCast(sender, GridView)).GetRowCellValue(e.RowHandle, "Message")
        If val Is Nothing Then
            Return
        End If
        Dim svalue As String = val.ToString()
        If svalue.Contains("Ditemukan") Then
            e.Appearance.BackColor = Color.Red
        ElseIf svalue.Contains("Lebih") Then
            e.Appearance.BackColor = Color.Yellow
        End If
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