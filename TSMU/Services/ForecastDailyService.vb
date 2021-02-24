Imports System.Collections.ObjectModel

Public Class ForecastDailyService

    Public Property ObjForecastCollection() As New Collection(Of ForecastDailyModel)
    Public Function GetDataGrid() As DataTable
        Try
            Dim dt As New DataTable
            dt = GetDataTableByParam("tForecastDaily_GetDataGrid", CommandType.StoredProcedure, Nothing, GetConnString)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
