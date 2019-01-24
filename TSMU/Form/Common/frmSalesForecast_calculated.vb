Imports System.Data.SqlClient
Public Class frmSalesForecast_calculated
    'Dim ff_Detail As frmBoM_Budget_Calculate_detail
    Dim dtGrid As DataTable
    Dim fc_Class As New clsSalesForecastCalculate

    Private Sub frmSalesForecast_calculated_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call LoadGrid()
        Call Proc_EnableButtons(False, False, False, True, False, False, False, False, False, False, False)
    End Sub
    Private Sub LoadGrid()
        Try
            Dim ds As New DataSet()
            Dim Header As String = fc_Class.getHeader()
            Dim Detail As String = fc_Class.getDetails()
            Dim daHeader As SqlDataAdapter
            Dim daDetail As New SqlDataAdapter

            Using conn As New SqlConnection
                conn.ConnectionString = GetConnString()
                conn.Open()
                daHeader = New SqlDataAdapter(Header, conn)
                daDetail = New SqlDataAdapter(Detail, conn)
                daHeader.Fill(ds, "Header")
                daDetail.Fill(ds, "Details")
            End Using


            Dim keyColumn As DataColumn = ds.Tables("Header").Columns("ID")
            Dim foreignKeyColumn As DataColumn = ds.Tables("Details").Columns("Id")
            ds.Relations.Add("IDs", keyColumn, foreignKeyColumn)

            Grid.DataSource = ds.Tables("Header")
            Grid.ForceInitialize()

            If GridView1.RowCount > 0 Then
                FormatGridView(GridView1)
            End If


        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Public Overrides Sub Proc_Refresh()
        bs_Filter = ""
        Call LoadGrid()
    End Sub

End Class
