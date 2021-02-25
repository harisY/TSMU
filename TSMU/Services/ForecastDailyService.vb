Imports System.Collections.ObjectModel
Imports System.Data.SqlClient

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

    Public Sub Insert()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        'If CustID.ToLower <> "adm" Then
                        '    DeleleByCustomerTahun()
                        'End If
                        For i As Integer = 0 To ObjForecastCollection.Count - 1
                            With ObjForecastCollection(i)
                                AddData(i)
                            End With
                        Next

                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw ex
                    Finally
                        gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub AddData(ByVal Index As Integer)
        Try

            Dim Params As List(Of SqlParameter) = New List(Of SqlParameter) From {
                New SqlParameter() With {.ParameterName = "Tahun", .Value = ObjForecastCollection.Item(Index).Tahun},
                New SqlParameter() With {.ParameterName = "Bulan", .Value = ObjForecastCollection.Item(Index).Bulan},
                New SqlParameter() With {.ParameterName = "PartNo", .Value = ObjForecastCollection.Item(Index).PartNo},
                New SqlParameter() With {.ParameterName = "PartName", .Value = ObjForecastCollection.Item(Index).PartName},
                New SqlParameter() With {.ParameterName = "UniqueNo", .Value = ObjForecastCollection.Item(Index).UniqueNo},
                New SqlParameter() With {.ParameterName = "QtyKanban", .Value = ObjForecastCollection.Item(Index).QtyKanban},
                New SqlParameter() With {.ParameterName = "Tgl", .Value = ObjForecastCollection.Item(Index).Tgl},
                New SqlParameter() With {.ParameterName = "Qty", .Value = ObjForecastCollection.Item(Index).Qty}
            }
            ExecQueryWithValue("tForecastDailyInsert", CommandType.StoredProcedure, Params, GetConnString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class