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
                ,[Scanned]
                ,isnull([OrderKbn],0)-isnull([Scanned],0) as OutStanding
                ,[OrderPcs]
                ,[QtyReceive]
                ,[QtyBalance]
                ,[CancelStatus]
                ,[Remark]
                ,[UploadedBy]
                ,[UploadedDate] 
            FROM [KanbanADM]"
            Dim dtTable As New DataTable
            If gh_Common.Site.ToLower = "tng" Then
                dtTable = GetDataTable(ls_SP)
            Else
                dtTable = GetDataTableCKR(ls_SP)
            End If

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
            If gh_Common.Site.ToLower = "tng" Then
                ExecQuery(Query)
            Else
                ExecQueryCKR(Query)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetKanban() As DataTable
        Try
            Dim sql As String = "SELECT 
			                        CONVERT(varchar,[OrderDate],101) Tanggal,
			                        [DelCycle] Cycle,
			                        sum([OrderKbn]) Kanban,
                                    Shopcode
		                        FROM [KanbanADM]
		                        GROUP BY 
			                        CONVERT(varchar,[OrderDate],101),
			                        [DelCycle], Shopcode
		                        ORDER BY 
			                        CONVERT(varchar,[OrderDate],101),
			                        [DelCycle]"
            Dim dt As New DataTable
            dt = GetDataTable(sql)

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetKanbanCKR() As DataTable
        Try
            Dim sql As String = "SELECT 
	                                CONVERT(varchar,[OrderDate],101) Tanggal,
	                                [DelCycle] Cycle, case when (Remark is null OR Remark<>'3A') then '3B' else '3A' END Remark,
	                                sum([OrderKbn]) Kanban
                                FROM [KanbanADM]
                                GROUP BY 
	                                CONVERT(varchar,[OrderDate],101),
	                                [DelCycle],Remark
                                ORDER BY 
	                                CONVERT(varchar,[OrderDate],101),
	                                [DelCycle]"
            Dim dt As New DataTable
            dt = GetDataTableCKR(sql)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub SaveKanbanSum(Tgl As String, Cycle As Integer, Kanban As Integer, ShopCode As String)
        Try
            Dim sql As String = "INSERT INTO [KanbanSum]
                                       ([Tanggal]
                                       ,[Cycle]
                                       ,[Kanban]
                                        ,[Open]
                                        ,ShopCode)
                                 VALUES
                                       (" & QVal(Tgl) & "
                                       ," & QVal(Cycle) & "
                                       ," & QVal(Kanban) & "," & QVal(ShopCode) & ")"
            ExecQuery(sql)

        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub SaveKanbanSumCKR(Tgl As String, Cycle As Integer, Kanban As Integer, Remark As String)
        Try
            Dim sql As String = "INSERT INTO [KanbanSum]
                                       ([Tanggal]
                                       ,[Cycle]
                                       ,[Kanban]
                                        ,[Open], Remark)
                                 VALUES
                                       (" & QVal(Tgl) & "
                                       ," & QVal(Cycle) & "
                                       ," & QVal(Kanban) & "," & QVal(Kanban) & ", " & QVal(Remark) & ")"

            ExecQueryCKR(sql)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub UpdateKanbanSum(Tgl As String, Cycle As Integer, Kanban As Integer)
        Try
            Dim sql As String = "Update [KanbanSum]
                                 Set Kanban = Kanban + " & QVal(Kanban) & "
                                 Where Tanggal =" & QVal(Tgl) & " AND Cycle = " & QVal(Cycle) & ""
            If gh_Common.Site.ToLower = "tng" Then
                ExecQuery(sql)
            Else
                ExecQueryCKR(sql)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function IsKanbanExist(Tgl As String, Cycle As Integer) As Boolean
        Dim hasil As Boolean = False
        Try
            Dim sql As String = "SELECT * 
                                FROM KanbanSum 
                                WHERE Tanggal = " & QVal(Tgl) & "
                                    AND Cycle=" & QVal(Cycle) & ""
            Dim dt As New DataTable
            dt = GetDataTable(sql)

            If dt.Rows.Count > 0 Then
                hasil = True
            End If
            Return hasil
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function IsKanbanExistCkr(Tgl As String, Cycle As Integer, Remark As String) As Boolean
        Dim hasil As Boolean = False
        Try
            Dim sql As String = "SELECT * 
                                FROM KanbanSum 
                                WHERE Tanggal = " & QVal(Tgl) & "
                                    AND Cycle=" & QVal(Cycle) & " AND Remark=" & QVal(Remark) & ""
            Dim dt As New DataTable

            dt = GetDataTableCKR(sql)
            If dt.Rows.Count > 0 Then
                hasil = True
            End If
            Return hasil
        Catch ex As Exception
            Throw
        End Try
    End Function
End Class
