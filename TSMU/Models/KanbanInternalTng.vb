Imports System.Collections.ObjectModel
Imports System.Data.SqlClient

Public Class KanbanInternalTng
    Public Property Customer() As String
    Public Property DeliveryDate() As DateTime
    Public Property IdKanban() As Integer
    Public Property InventoryID() As String
    Public Property IsPrint() As Boolean
    Public Property ItemNo() As String
    Public Property NoPO() As String
    Public Property NoUrut() As Integer
    Public Property OrderDate() As DateTime
    Public Property PalletizeMark() As String
    Public Property PartName() As String
    Public Property PartNo() As String
    Public Property PartNoLabel() As String
    Public Property PONumber() As String
    Public Property QtyOrder() As Integer
    Public Property RackLabel() As String
    Public Property RackPart() As String
    Public Property RH_LH() As String
    Public Property Type() As String
    Public Property UploadedBy() As String
    Public Property UploadedDate() As DateTime
    Public Property VendorCode() As String
    Public Property Item() As String
    Public Property KanbanCollection As New Collection(Of KanbanInternalTng)

    Public Function GetKanbans() As DataTable
        Try
            Dim dt As New DataTable
            dt = GetDataTableByParam("M_KanbanInternal_GetAll", CommandType.StoredProcedure, Nothing, GetConnString)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetKanbansDelivery(Status As Integer) As DataTable
        Try

            Dim dt As New DataTable
            Dim p As List(Of SqlParameter) = New List(Of SqlParameter)()
            p.Add(New SqlParameter() With {.ParameterName = "Status", .Value = Status})
            'dt = GetDataTableByCommand_HotReload("KanbanInternalTng_GetDataMonitoring", Nothing, 0, AddressOf Dep_onchange)
            dt = GetDataTableByParam("KanbanInternalTng_GetDataMonitoring", CommandType.StoredProcedure, p, GetConnString)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Private Sub Dep_onchange(ByVal sender As Object, ByVal e As SqlNotificationEventArgs)
        ' this event is run asynchronously so you will need to invoke to run on the UI thread(if required)
        'If Me.InvokeRequired Then
        '    dtTable = BeginInvoke(New MethodInvoker(AddressOf GetAllData))
        'Else
        'If e.Type = SqlNotificationType.Change Then
        '    GetKanbansDelivery()
        'End If

        'End If
        ' this will remove the event handler since the dependency is only for a single notification
        'Dim dep As SqlDependency = DirectCast(sender, SqlDependency)
        'RemoveHandler dep.OnChange, AddressOf dep_onchange
    End Sub

    Public Sub Add(i As Integer)
        Try
            Dim P As List(Of SqlParameter) = New List(Of SqlParameter)()
            P.Add(New SqlParameter() With {.ParameterName = "Customer", .Value = KanbanCollection(i).Customer})
            P.Add(New SqlParameter() With {.ParameterName = "DeliveryDate", .Value = KanbanCollection(i).DeliveryDate})
            P.Add(New SqlParameter() With {.ParameterName = "InventoryID", .Value = KanbanCollection(i).InventoryID})
            P.Add(New SqlParameter() With {.ParameterName = "ItemNo", .Value = KanbanCollection(i).InventoryID})
            P.Add(New SqlParameter() With {.ParameterName = "NoPO", .Value = KanbanCollection(i).NoPO})
            P.Add(New SqlParameter() With {.ParameterName = "NoUrut", .Value = KanbanCollection(i).NoUrut})
            P.Add(New SqlParameter() With {.ParameterName = "OrderDate", .Value = KanbanCollection(i).OrderDate})
            P.Add(New SqlParameter() With {.ParameterName = "PalletizeMark", .Value = If(String.IsNullOrEmpty(KanbanCollection(i).PalletizeMark), "", KanbanCollection(i).PalletizeMark)})
            P.Add(New SqlParameter() With {.ParameterName = "PartName", .Value = KanbanCollection(i).PartName})
            P.Add(New SqlParameter() With {.ParameterName = "PartNo", .Value = KanbanCollection(i).PartNo})
            P.Add(New SqlParameter() With {.ParameterName = "PartNoLabel", .Value = KanbanCollection(i).PartNoLabel})
            P.Add(New SqlParameter() With {.ParameterName = "PONumber", .Value = KanbanCollection(i).PONumber})
            P.Add(New SqlParameter() With {.ParameterName = "QtyOrder", .Value = KanbanCollection(i).QtyOrder})
            P.Add(New SqlParameter() With {.ParameterName = "RackLabel", .Value = KanbanCollection(i).RackLabel})
            P.Add(New SqlParameter() With {.ParameterName = "RackPart", .Value = KanbanCollection(i).RackPart})
            P.Add(New SqlParameter() With {.ParameterName = "RH_LH", .Value = KanbanCollection(i).RH_LH})
            P.Add(New SqlParameter() With {.ParameterName = "Type", .Value = KanbanCollection(i).Type})
            P.Add(New SqlParameter() With {.ParameterName = "UploadedBy", .Value = gh_Common.Username})
            P.Add(New SqlParameter() With {.ParameterName = "VendorCode", .Value = KanbanCollection(i).VendorCode})
            P.Add(New SqlParameter() With {.ParameterName = "Item", .Value = KanbanCollection(i).Item})
            ExecQueryWithValue("M_KanbanInternal_Insert", CommandType.StoredProcedure, P, GetConnString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateKanban(Id As Integer)
        Try
            Dim sql As String = "Update [M_KanbanInternal] Set IsPrint = 1 where Id = @Id"
            Dim P As List(Of SqlParameter) = New List(Of SqlParameter)()
            P.Add(New SqlParameter() With {.ParameterName = "Id", .Value = Id})
            ExecQueryWithValue(sql, CommandType.Text, P, GetConnString)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#Region "Transaction"
    Public Sub Insert()
        Try
            Using Conn1 As New SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        For i As Integer = 0 To KanbanCollection.Count - 1
                            Add(i)
                        Next

                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region
End Class
