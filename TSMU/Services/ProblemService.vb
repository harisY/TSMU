Imports System.Data.SqlClient

Public Class ProblemService
    Public Function GetData() As DataTable
        Try
            Dim Dt As New DataTable
            Dt = GetDataTableByParam("m_problemSelect", CommandType.StoredProcedure, Nothing, GetConnString)
            Return Dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub SimpanData(Model As ProblemModel)
        Try
            Dim Params As List(Of SqlParameter) = New List(Of SqlParameter) From {
                 New SqlParameter() With {.ParameterName = "Proses", .Value = Model.Proses.AsString},
                 New SqlParameter() With {.ParameterName = "ProblemCode", .Value = Model.ProblemCode.AsString},
                 New SqlParameter() With {.ParameterName = "Name", .Value = Model.Name.AsString}
                }
            ExecQueryWithValue("m_problemInsert", CommandType.StoredProcedure, Params, GetConnString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateData(Model As ProblemModel)
        Try
            Dim Params As List(Of SqlParameter) = New List(Of SqlParameter) From {
                 New SqlParameter() With {.ParameterName = "Id", .Value = Model.Id.AsInt},
                 New SqlParameter() With {.ParameterName = "Proses", .Value = Model.Proses.AsString},
                 New SqlParameter() With {.ParameterName = "ProblemCode", .Value = Model.ProblemCode.AsString},
                 New SqlParameter() With {.ParameterName = "Name", .Value = Model.Name.AsString}
                }
            ExecQueryWithValue("m_problemUpdate", CommandType.StoredProcedure, Params, GetConnString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
