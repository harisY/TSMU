Imports System.Data.SqlClient

Public Class ProblemService
    Dim Model As ProblemModel
    Public Function GetData() As DataTable
        Try
            Dim Dt As New DataTable
            Dt = GetDataTableByParam("m_problemSelect", CommandType.StoredProcedure, Nothing, GetConnString)
            Return Dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetDataById(Id As Integer) As ProblemModel
        Try
            Model = New ProblemModel
            Dim Params As List(Of SqlParameter) = New List(Of SqlParameter) From {
                New SqlParameter() With {.ParameterName = "Id", .Value = Id}
            }
            Dim dt As New DataTable
            dt = GetDataTableByParam("m_problemSelectById", CommandType.StoredProcedure, Params, GetConnString)
            If dt.Rows.Count > 0 Then
                With Model
                    .Id = dt.Rows(0)("Id").ToString().AsInt()
                    .ProblemCode = dt.Rows(0)("ProblemCode").ToString().AsString()
                    .Name = dt.Rows(0)("Name").ToString().AsString()
                    .Proses = dt.Rows(0)("Proses").ToString().AsString()
                End With
            Else
                With Model
                    .Id = 0
                    .ProblemCode = ""
                    .Name = ""
                    .Proses = ""
                End With
            End If
            Return Model
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function CheckData(Model As ProblemModel) As Boolean
        Dim Hasil As Boolean
        Try
            Dim Params As List(Of SqlParameter) = New List(Of SqlParameter) From {
                 New SqlParameter() With {.ParameterName = "Proses", .Value = Model.Proses.AsString},
                 New SqlParameter() With {.ParameterName = "ProblemCode", .Value = Model.ProblemCode.AsString}
                }
            Dim Dt As New DataTable
            Dt = GetDataTableByParam("m_problemSelectExist", CommandType.StoredProcedure, Params, GetConnString)
            If Dt.Rows.Count > 0 Then
                Hasil = True
            End If
            Return Hasil
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
    Public Sub DeleteData(Id As Integer)
        Try
            Dim Params As List(Of SqlParameter) = New List(Of SqlParameter) From {
                 New SqlParameter() With {.ParameterName = "Id", .Value = Id.AsInt}
                }
            ExecQueryWithValue("m_problemUpdate", CommandType.StoredProcedure, Params, GetConnString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
