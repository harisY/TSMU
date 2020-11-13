Imports DevExpress.Data
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmForecast_PO_Log
    Private _dt As DataTable
    Dim _judul As String
    Dim _tipe As Integer
    Dim ObjForecast As New forecast_price_models
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal dt As DataTable, Judul As String, Tipe As Integer)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _dt = New DataTable
        _dt = dt
        _judul = Judul
        _tipe = Tipe
    End Sub
    Private Sub frmForecast_PO_Log_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, False, False, False, True, False, False, False, False, False, False, False)
        GetDataGrid()
        GroupControl1.Text = _judul
    End Sub

    Private Sub GetDataGrid()
        Grid.DataSource = _dt
        If GridView1.RowCount > 0 Then
            If _tipe = 0 Then
                GridView1.Columns(0).Visible = False
            End If
            GridView1.BestFitColumns()
            GridCellFormat(GridView1)
        End If
    End Sub

    Public Overrides Sub Proc_Excel()
        If GridView1.RowCount > 0 Then
            SaveToExcel(Grid)
        End If
    End Sub

    Private Sub BtnLookUpInvtID_Click(sender As Object, e As EventArgs) Handles BtnLookUpInvtID.Click

    End Sub

    Private Sub GridView1_RowStyle(sender As Object, e As RowStyleEventArgs) Handles GridView1.RowStyle
        Dim view As GridView = TryCast(sender, GridView)
        If view.FocusedRowHandle >= 0 Then
            If _tipe = 0 Then
                Dim Solomonon As String = view.GetRowCellDisplayText(e.RowHandle, "AlternateID Solomon")
                Dim Upload As String = view.GetRowCellDisplayText(e.RowHandle, "AlternateID Upload")

                If Solomonon <> Upload Then
                    e.Appearance.BackColor = Color.LightSalmon
                    e.HighPriority = True
                    'End If
                End If
            End If
        End If
    End Sub
End Class