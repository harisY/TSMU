Imports System.Data.SqlClient

Public Class TForecastPrice_TempService

    Public Sub InsertTemptData(Model As TForecastPrice_TempModel)
        Try
            Dim parameters As List(Of SqlParameter) = New List(Of SqlParameter)()
            parameters.Add(New SqlParameter() With {.ParameterName = "Tahun", .Value = Model.Tahun})
            parameters.Add(New SqlParameter() With {.ParameterName = "Bulan", .Value = Model.Bulan})
            parameters.Add(New SqlParameter() With {.ParameterName = "CustID", .Value = Model.CustID})
            parameters.Add(New SqlParameter() With {.ParameterName = "InvtID", .Value = Model.InvtID})
            parameters.Add(New SqlParameter() With {.ParameterName = "PartNo", .Value = Model.PartNo})
            parameters.Add(New SqlParameter() With {.ParameterName = "PartName", .Value = Model.PartName})
            parameters.Add(New SqlParameter() With {.ParameterName = "Site", .Value = Model.Site})
            parameters.Add(New SqlParameter() With {.ParameterName = "Harga", .Value = Model.Harga})
            ExecQueryWithValue("tForecastPrice_Temp1Insert", CommandType.StoredProcedure, parameters, GetConnString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
