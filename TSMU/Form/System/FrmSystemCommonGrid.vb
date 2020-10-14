Public Class FrmSystemCommonGrid
    Dim Dt As New DataTable
    Dim Perpost As String = String.Empty
    Dim _Tag As TagModel
    Public Sub New(_Dt As DataTable, _Perpost As String, lf_FormParent As Form)

        ' This call is required by the designer.
        InitializeComponent()
        Dt = _Dt
        Perpost = _Perpost
        ' Add any initialization after the InitializeComponent() call.
        _Tag = New TagModel
        _Tag.PageIndex = lf_FormParent.Tag.PageIndex
        Tag = _Tag
    End Sub
    Private Sub FrmSystemCommonGrid_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Proc_EnableButtons(False, False, False, False, True, False, False, False, False, False, False, False)
        LoadGrid()
    End Sub

    Private Sub LoadGrid()
        Try
            Grid.DataSource = Dt
            If GridView1.RowCount > 0 Then
                GridView1.BestFitColumns()
                GridCellFormat(GridView1)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Overrides Sub Proc_Excel()
        Try
            If GridView1.RowCount > 0 Then
                SaveToExcel(Grid, "Sales Aktual", "Sales Aktual " & Perpost & " Checking ", False)
            Else
                Throw New Exception("Tidak ada Data yg di export")
            End If
        Catch ex As Exception
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
End Class
