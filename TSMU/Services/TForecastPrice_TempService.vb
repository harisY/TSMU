Imports System.Data.SqlClient

Public Class TForecastPrice_TempService
    Dim Model As TForecastPrice_TempModel
    Public Function GetDataGrid() As DataTable
        Try
            Dim dt As New DataTable
            dt = GetDataTableByParam("tForecastPrice_Temp1Select", CommandType.StoredProcedure, Nothing, GetConnString)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetDataById(Id As Integer) As TForecastPrice_TempModel
        Try
            Model = New TForecastPrice_TempModel
            Dim parameters As List(Of SqlParameter) = New List(Of SqlParameter)()
            parameters.Add(New SqlParameter() With {.ParameterName = "Id", .Value = Id})
            Dim dt As New DataTable
            dt = GetDataTableByParam("tForecastPrice_Temp1SelectById", CommandType.StoredProcedure, parameters, GetConnString)
            If dt.Rows.Count > 0 Then
                With Model
                    .Id = dt.Rows(0)("Id").ToString().AsInt()
                    .Tahun = dt.Rows(0)("Tahun").ToString().AsString()
                    .Bulan = dt.Rows(0)("Bulan").ToString().AsString()
                    .CustID = dt.Rows(0)("CustID").ToString().AsString()
                    .InvtID = dt.Rows(0)("InvtID").ToString().AsString()
                    .PartNo = dt.Rows(0)("PartNo").ToString().AsString()
                    .PartName = dt.Rows(0)("PartName").ToString().AsString()
                    .Site = dt.Rows(0)("Site").ToString().AsString()
                    .Harga = dt.Rows(0)("Harga").ToString().AsDouble()
                End With
            End If
            Return Model
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub InsertData(Model As TForecastPrice_TempModel)
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
    Public Sub UpdatetData(Model As TForecastPrice_TempModel)
        Try
            Dim parameters As List(Of SqlParameter) = New List(Of SqlParameter)()
            parameters.Add(New SqlParameter() With {.ParameterName = "Id", .Value = Model.Id})
            parameters.Add(New SqlParameter() With {.ParameterName = "Tahun", .Value = Model.Tahun})
            parameters.Add(New SqlParameter() With {.ParameterName = "Bulan", .Value = Model.Bulan})
            parameters.Add(New SqlParameter() With {.ParameterName = "CustID", .Value = Model.CustID})
            parameters.Add(New SqlParameter() With {.ParameterName = "InvtID", .Value = Model.InvtID})
            parameters.Add(New SqlParameter() With {.ParameterName = "PartNo", .Value = Model.PartNo})
            parameters.Add(New SqlParameter() With {.ParameterName = "PartName", .Value = Model.PartName})
            parameters.Add(New SqlParameter() With {.ParameterName = "Site", .Value = Model.Site})
            parameters.Add(New SqlParameter() With {.ParameterName = "Harga", .Value = Model.Harga})
            ExecQueryWithValue("tForecastPrice_Temp1Update", CommandType.StoredProcedure, parameters, GetConnString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub DeleteData(Id As Integer)
        Try
            Dim parameters As List(Of SqlParameter) = New List(Of SqlParameter)()
            parameters.Add(New SqlParameter() With {.ParameterName = "Id", .Value = Id})
            ExecQueryWithValue("tForecastPrice_Temp1Delete", CommandType.StoredProcedure, parameters, GetConnString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
