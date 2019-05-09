Public Class BarcodeGenerate
    Public Property BarcodeID As Integer
    Public Property Cav As String
    Public Property Colour As String
    Public Property Concatenate As String
    Public Property CustomerID As String
    Public Property CustomerName As String
    Public Property Family As String
    Public Property InventoryIdMat As String
    Public Property InventoryID As String
    Public Property JenisStok As String
    Public Property JobNo As String
    Public Property KodePart As Integer
    Public Property LokalExport As String
    Public Property Material As String
    Public Property PartCode As String
    Public Property PartName As String
    Public Property PartNameFull As String
    Public Property PartNo As String
    Public Property QtyLabel As Integer
    Public Property SFGFG As String
    Public Property StatusMilik As String
    Public Property Target As String
    Public Property TglUpload As DateTime
    Public Property UploadBy As String
    Public Property WarnaPasscard As String


    Public Function GetAllDataGrid() As DataTable
        Try
            Dim ls_SP As String =
            "SELECT [BarcodeID]
                ,[TglUpload]
                ,[KodePart]
                ,[CustomerID]
                ,[CustomerName]
                ,[InvetoryID]
                ,[SFG/FG]
                ,[PartName]
                ,[PartCode]
                ,[PartNo]
                ,[Colour]
                ,[JobNo]
                ,[Target]
                ,[Family]
                ,[Cav]
                ,[QtyLabel]
                ,[WarnaPasscard]
                ,[LokalExport]
                ,[Concatenate]
                ,[JenisStok]
                ,[StatusMilik]
                ,[InventoryIdMat]
                ,[Material]
            FROM [BarcodeGenerate]"
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
            Query = "INSERT INTO [BarcodeGenerate]([TglUpload]
               ,[KodePart],[CustomerID],[CustomerName],[InvetoryID]
               ,[SFG/FG],[PartName],[PartNo],[Colour]
               ,[JobNo],[Target],[Family],[Cav],[QtyLabel]
               ,[WarnaPasscard],[LokalExport],[Concatenate]
               ,[JenisStok],[StatusMilik],[InventoryIdMat],[Material],[UploadBy])
            Values(" & QVal(TglUpload) & "," & QVal(KodePart) & "," & QVal(CustomerID) & "
                    ," & QVal(CustomerName) & "," & QVal(InventoryID) & "," & QVal(SFGFG) & "," & QVal(PartName) & "
                    ," & QVal(PartNo) & "," & QVal(Colour) & "," & QVal(JobNo) & "," & QVal(Target) & "
                    ," & QVal(Family) & "," & QVal(Cav) & "," & QVal(QtyLabel) & "," & QVal(WarnaPasscard) & "
                    ," & QVal(LokalExport) & "," & QVal(Concatenate) & "," & QVal(JenisStok) & "
                    ," & QVal(StatusMilik) & "," & QVal(InventoryIdMat) & "," & QVal(Material) & "," & QVal(UploadBy) & ")"
            ExecQuery(Query)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function PrintQRCOde(KodePart As String) As DataSet
        Dim ds As dsLaporan
        Try
            Dim sql As String =
                "SELECT [BarcodeID]
                ,[TglUpload]
                ,[KodePart]
                ,[CustomerID]
                ,[CustomerName]
                ,[InvetoryID] InvtID
                ,[SFG/FG] Status
                ,[PartName]
                ,[PartCode]
                ,[PartNo]
                ,[Colour] Color
                ,[JobNo]
                ,[Target]
                ,[Family]
                ,[Cav]
                ,[QtyLabel] Qty
                ,[WarnaPasscard] Color2
                ,[LokalExport]
                ,[Concatenate]
                ,[JenisStok]
                ,[StatusMilik]
                ,[InventoryIdMat]
                ,[Material]
                ,0 as No
                ,WarnaPasscard Warna
            FROM [BarcodeGenerate] WHERE KodePart = " & QVal(KodePart) & ""
            ds = New dsLaporan
            ds = GetDsReport(sql, "QRCode")
        Catch ex As Exception
            Throw ex
        End Try
        Return ds
    End Function
End Class
