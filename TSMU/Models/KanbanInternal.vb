Imports System.Collections.ObjectModel

Public Class KanbanInternal

    Public Property ObjDetails() As New Collection(Of KanbanInternalDetails)

    Public Function GetAllDataGridCKR() As DataTable
        Try
            Dim ls_SP As String =
            "SELECT
                Id
                ,[NoUrut]
                ,[Customer]
                ,[PONumber]
                ,[InventoryId]
                ,[PartName]
                ,[PartNo]
                ,[Type]
                ,[NoPO]
                ,convert(varchar,[OrderDate],105) OrderDate
                ,convert(varchar,[DeliveryDate],105) DelDate
                ,[QtyOrder]
                ,[RH_LH]
                ,[PalletizeMark]
                ,[PartNoLabel]
                ,[RackLabel]
                ,[RackPart]
                ,[ItemNo]
                ,IsPrint
                ,Case Customer
                    when 'ADM' then '#00FFFF'
                    when 'TAM' then '#FFFF00'
                    when 'TMMIN' then '#FF69B4'
                else '#FFFFFF'
                END as Warna     
                ,[UploadedBy]
                ,[UploadedDate]
            FROM [KanbanInternal]"
            Dim dtTable As New DataTable

            dtTable = GetDataTableCKR(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Sub InsertData()
        Try

            Using Conn1 As New SqlClient.SqlConnection(GetConnStringDbCKR)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        'DeleteData()
                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
                                .InsertData()
                            End With
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
            Throw ex
        End Try
    End Sub
    Public Sub DeleteData()
        Try
            Dim sql As String = "Delete From [KanbanInternal]"
            ExecQueryCKR(sql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateData(Id As Integer)
        Try
            Dim sql As String = "Update [KanbanInternal] Set IsPrint = 1 where Id = " & QVal(Id) & ""
            ExecQueryCKR(sql)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function PrintQRCOdeCkr() As DataSet
        Dim ds As dsLaporan
        Try
            Dim sql As String =
            "SELECT
                Id
                ,[NoUrut]
                ,[Customer] Cust
                ,[PONumber]
                ,[InventoryId]
                ,[PartName]
                ,[PartNo]
                ,[Type]
                ,[NoPO]
                ,convert(date,[OrderDate]) OrderDate
                ,convert(date,[DeliveryDate]) DelDate
                ,[QtyOrder]
                ,[RH_LH]
                ,[PalletizeMark]
                ,[PartNoLabel]
                ,[RackLabel]
                ,[RackPart]
                ,[ItemNo]
                ,Case Customer
                    when 'ADM' then '#00FFFF'
                    when 'TAM' then '#FFFF00'
                    when 'TMMIN' then '#FF69B4'
                else '#FFFFFF'
                END as Warna               
            FROM [KanbanInternal] WHERE IsPrint = 0"
            ds = New dsLaporan
            ds = GetDsReportCKR(sql, "KanbanInternal")

        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function
End Class

Public Class KanbanInternalDetails
    Public Property Customer As String
    Public Property DeliveryDate As DateTime
    Public Property Id As Integer
    Public Property InventoryId As String
    Public Property ItemNo As String
    Public Property NoPO As String
    Public Property NoUrut As Integer
    Public Property OrderDate As DateTime
    Public Property PalletizeMark As String
    Public Property PartName As String
    Public Property PartNo As String
    Public Property PartNoLabel As String
    Public Property PONumber As String
    Public Property QtyOrder As Integer
    Public Property RackLabel As String
    Public Property RackPart As String
    Public Property RH_LH As String
    Public Property Type As String
    Public Property UploadedBy As String
    Public Property UploadedDate As DateTime
    Public Sub InsertData()
        Try
            Dim Query As String = String.Empty
            Query = "INSERT INTO [KanbanInternal]
                ([NoUrut],[Customer],[PONumber],[InventoryId],[PartName],[PartNo]
               ,[Type],[NoPO],[OrderDate],[DeliveryDate],[QtyOrder]
               ,[RH_LH],[PalletizeMark],[PartNoLabel],[RackLabel],[RackPart]
               ,[ItemNo],[UploadedBy],[UploadedDate])
            Values(" & QVal(NoUrut) & "," & QVal(Customer) & "," & QVal(PONumber) & "," & QVal(InventoryId) & "," & QVal(PartName) & "," & QVal(PartNo.ToUpper) & "
                ," & QVal(Type) & "," & QVal(NoPO) & "," & QVal(OrderDate) & "," & QVal(DeliveryDate) & "," & QVal(QtyOrder) & "
                ," & QVal(RH_LH) & "," & QVal(PalletizeMark) & "," & QVal(PartNoLabel) & "," & QVal(RackLabel) & "," & QVal(RackPart) & "
                ," & QVal(ItemNo) & "," & QVal(UploadedBy) & ",GETDATE())"
            ExecQueryCKR(Query)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
