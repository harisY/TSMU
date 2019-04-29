Public Class KanbanAdmModel
    Public Property CalcDate As DateTime
    Public Property CancelStatus As String
    Public Property DelCycle As String
    Public Property DelDate As DateTime
    Public Property DelTime As String
    Public Property DNType As String
    Public Property DocNo As String
    Public Property IdKanban As Integer
    Public Property JobNo As String
    Public Property Lane As Integer
    Public Property LP As String
    Public Property OrderDate As DateTime
    Public Property OrderKbn As Integer
    Public Property OrderNo As String
    Public Property OrderPcs As Integer
    Public Property OrderTime As String
    Public Property PartCategory As String
    Public Property PartName As String
    Public Property PartNo As String
    Public Property PlantCode As String
    Public Property PONo As String
    Public Property QtyBalance As Integer
    Public Property QtyKbn As Integer
    Public Property QtyReceive As Integer
    Public Property RecDate As DateTime
    Public Property RecStatus As String
    Public Property RecType As String
    Public Property Remark As String
    Public Property Route As String
    Public Property ShopCode As String
    Public Property Trip As String
    Public Property UploadedBy As String
    Public Property UploadedDate As DateTime
    Public Property VendorAlias As String
    Public Property VendorCode As String
    Public Property VendorSite As String
    Public Property VendorSiteAlias As String
    Public Function GetAllDataGrid() As DataTable
        Try
            Dim ls_SP As String =
            "SELECT [IdKanban] ID
                ,[PlantCode]
                ,[ShopCode]
                ,[PartCategory]
                ,[Route]
                ,[VendorCode]
                ,[VendorAlias]
                ,[VendorSite]
                ,[VendorSiteAlias]
                ,[OrderNo]
                ,[PONo]
                ,[CalcDate]
                ,[OrderDate]
                ,[OrderTime]
                ,[DelDate]
                ,[DelTime]
                ,[DelCycle]
                ,[DocNo]
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
            FROM [New_BOM].[dbo].[KanbanADM]"
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
            Query = "INSERT INTO [KanbanADM] ([PlantCode]
            ,[ShopCode],[PartCategory],[Route],LP,Trip,[VendorCode]
            ,[VendorAlias],[VendorSite],[VendorSiteAlias],[OrderNo]
            ,[PONo],[CalcDate],[OrderDate],[OrderTime]
            ,[DelDate],[DelTime],[DelCycle],[DocNo]
            ,[RecStatus],[DNType],[RecDate],[RecType]
            ,[PartNo],[PartName],[JobNo],[Lane]
            ,[QtyKbn],[OrderKbn],[OrderPcs],[QtyReceive]
            ,[QtyBalance],[CancelStatus],[Remark],[UploadedBy],[UploadedDate])
            Values(" & QVal(PlantCode) & "," & QVal(ShopCode) & "," & QVal(PartCategory) & "
                ," & QVal(Route) & "," & QVal(LP) & "," & QVal(Trip) & "," & QVal(VendorCode) & "," & QVal(VendorAlias) & "," & QVal(VendorSite) & "
                ," & QVal(VendorSiteAlias) & "," & QVal(OrderNo) & "," & QVal(PONo) & "," & QVal(CalcDate) & "
                ," & QVal(OrderDate) & "," & QVal(OrderTime) & "," & QVal(DelDate) & "," & QVal(DelTime) & "
                ," & QVal(DelCycle) & "," & QVal(DocNo.TrimEnd) & "," & QVal(RecStatus) & "," & QVal(DNType) & "," & QVal(RecDate) & "," & QVal(RecType) & "
                ," & QVal(PartNo) & "," & QVal(PartName) & "," & QVal(JobNo) & "," & QVal(Lane) & "," & QVal(QtyKbn) & "," & QVal(OrderKbn) & "
                ," & QVal(OrderPcs) & "," & QVal(QtyReceive) & "," & QVal(QtyBalance) & "
                ," & QVal(CancelStatus) & "," & QVal(Remark) & "," & QVal(UploadedBy) & "," & QVal(UploadedDate) & ")"
            ExecQuery(Query)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
