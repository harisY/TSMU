Imports System.Data.SqlClient

Public Class ReportService
    Public Function GenerateDataGridOutgoing(Dari As Date, Sampai As Date) As DataTable
        Try
            Dim dtTable As New DataTable
            Dim Params As List(Of SqlParameter) = New List(Of SqlParameter)
            Params.Add(New SqlParameter() With {.ParameterName = "dateFrom", .Value = Dari})
            Params.Add(New SqlParameter() With {.ParameterName = "dateTo", .Value = Sampai})
            dtTable = GetDataTableByParam("qc_outgoing_transactions_report", CommandType.StoredProcedure, Params, GetConnString)
            Return dtTable
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
