Imports System.Collections.ObjectModel
Imports System.Data.SqlClient

Public Class QcOutgoingService
    Public Property ObjCollections() As New Collection(Of QcOutgoingModel)
    Public Function GetDataGrid() As DataTable
        Try
            Dim dt As New DataTable
            dt = GetDataTableByParam("qc_outgoing_fileSelect", CommandType.StoredProcedure, Nothing, GetConnString)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Sub InsertData(i As Integer)
        Try
            Dim Params As List(Of SqlParameter) = New List(Of SqlParameter)
            Params.Add(New SqlParameter() With {.ParameterName = "PartNo", .Value = ObjCollections(i).PartNo})
            Params.Add(New SqlParameter() With {.ParameterName = "InvtId", .Value = ObjCollections(i).InvtId})
            Params.Add(New SqlParameter() With {.ParameterName = "PathFile", .Value = ObjCollections(i).PathFile})
            Params.Add(New SqlParameter() With {.ParameterName = "PathFile1", .Value = ObjCollections(i).PathFile1})
            ExecQueryWithValue("qc_outgoing_fileInsert", CommandType.StoredProcedure, Params, GetConnString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub InsertTransactions()
        Using Conn As New SqlConnection(GetConnString())
            Conn.Open()
            Using Trans As SqlTransaction = Conn.BeginTransaction
                gh_Trans = New InstanceVariables.TransactionHelper
                gh_Trans.Command.Connection = Conn
                gh_Trans.Command.Transaction = Trans
                Try
                    For i As Integer = 0 To ObjCollections.Count - 1
                        InsertData(i)
                    Next

                    Trans.Commit()
                Catch ex As Exception
                    Trans.Rollback()
                    Throw ex
                Finally
                    gh_Trans = Nothing
                End Try
            End Using
        End Using
    End Sub

End Class
