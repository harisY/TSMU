Public Class KanbanAdmModel
    Public Property CancelStatus As String
    Public Property DNType As String
    Public Property IdKanban As Integer
    Public Property JobNo As String
    Public Property Lane As Integer
    Public Property OrderKbn As Integer
    Public Property OrderPcs As Integer
    Public Property PartName As String
    Public Property PartNo As String
    Public Property QtyBalance As Integer
    Public Property QtyKbn As Integer
    Public Property QtyReceive As Integer
    Public Property RecDate As DateTime
    Public Property RecStatus As String
    Public Property RecType As String
    Public Property Remark As String
    Public Property UploadedBy As String
    Public Property UploadedDate As DateTime
    Public Function GetAllDataGrid() As DataTable
        Try
            Dim ls_SP As String =
            "SELECT [IdKanban] ID
                ,[RecStatus]
                ,[DNType]
                ,[RecDate]
                ,[RecType]
                ,[PartNo]
                ,[PartName]
                ,[JobNo]
                ,[Lane]
                ,[QtyKbn]
                ,[OrderKbn]
                ,[OrderPcs]
                ,[QtyReceive]
                ,[QtyBalance]
                ,[CancelStatus]
                ,[Remark]
                ,[UploadedBy]
                ,[UploadedDate]
            FROM [KanbanADM]"
            Dim dtTable As New DataTable
            dtTable = GetDataTable(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Sub InsertData()
        Try
            Dim Query As String = String.Empty
            Query = "INSERT INTO [KanbanADM]
               ([RecStatus],[DNType],[RecDate],[RecType],[PartNo]
               ,[PartName],[JobNo],[Lane],[QtyKbn],[OrderKbn]
               ,[OrderPcs],[QtyReceive],[QtyBalance],[CancelStatus],[Remark]
               ,[UploadedBy],[UploadedDate])
            Values(" & QVal(RecStatus) & "," & QVal(DNType) & "," & QVal(RecDate) & "
                ," & QVal(RecType) & "," & QVal(PartNo) & "," & QVal(PartName) & "," & QVal(JobNo) & "
                ," & QVal(Lane) & "," & QVal(QtyKbn) & "," & QVal(OrderKbn) & "," & QVal(OrderPcs) & "
                ," & QVal(QtyReceive) & "," & QVal(QtyBalance) & "," & QVal(CancelStatus) & "," & QVal(Remark) & "
                ," & QVal(UploadedBy) & "," & QVal(UploadedDate) & ")"
            ExecQuery(Query)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
