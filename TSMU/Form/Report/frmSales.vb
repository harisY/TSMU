Imports DevExpress.XtraGrid.Views.Grid

Public Class frmSales
    Dim ObjSales As sales_model
    Private columnValues As New List(Of String)()
    Private Sub frmSales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, False, False, True, True, False, True, False)
        ProgBar.Visible = False
    End Sub
    Public Overrides Sub Proc_Excel()
        Try
            If GridView1.RowCount > 0 Then
                SaveToExcel(Grid, "Sales Aktual", "Sales Aktual " & _txtPerpost.Text, False)
            Else
                Throw New Exception("Tidak ada Data yg di export")
            End If
        Catch ex As Exception
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Async Sub btnLoad_Click(sender As Object, e As EventArgs) Handles btnLoad.Click
        Try
            If _txtPerpost.Text = "" Then
                _txtPerpost.Focus()
                Throw New Exception("Harap Isi Perpost !")
            End If
            If ProgBar.Visible = True Then
                Throw New Exception("Proses already running, Please wait !")
            End If
            ProgBar.Visible = True
            ProgBar.Style = ProgressBarStyle.Marquee
            Await Task.Run(Sub() GetDataGrid())
        Catch ex As Exception
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub
    Private Sub GetDataGrid()
        Try
            Dim perpost As String = ""
            Invoke(Sub()
                       perpost = _txtPerpost.Text
                   End Sub)
            ObjSales = New sales_model
            Dim dt As New DataTable
            dt = ObjSales.SalesLoadDataGrid(perpost)
            setDataSource(dt)

        Catch ex As Exception
            Throw ex
        End Try

    End Sub
    Friend Delegate Sub SetDataSourceDelegate(table As DataTable)
    Private Sub setDataSource(table As DataTable)
        Try
            ' Invoke method if required:
            If InvokeRequired Then
                Invoke(New SetDataSourceDelegate(AddressOf setDataSource), table)
            Else
                Grid.DataSource = table
                If GridView1.RowCount > 0 Then
                    GridCellFormat(GridView1)
                End If
                ProgBar.Visible = False
            End If
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

End Class
