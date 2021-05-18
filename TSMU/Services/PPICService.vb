Imports System.Data.SqlClient

Public Class PPICService
    Dim _globalService As GlobalService
    Dim strQuery As String = String.Empty

    Public Function GetDataBuildup() As DataTable
        Try
            strQuery = "SELECT  ID ,
                                JenisPacking ,
                                Panjang ,
                                Lebar ,
                                Tinggi ,
                                QtyPallet ,
                                StandarQty ,
                                KapasitasMuat ,
                                Persentase ,
                                Tipe ,
                                Keterangan ,
                                UsedForCustomer ,
                                CreateBy ,
                                CreateDate ,
                                UpdateBy ,
                                UpdateDate
                        FROM    dbo.M_PPICBuildup"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataBuildupByID(ByVal ID As Integer) As PPICBuildupModel
        Try
            strQuery = "SELECT  ID ,
                                JenisPacking ,
                                Panjang ,
                                Lebar ,
                                Tinggi ,
                                QtyPallet ,
                                StandarQty ,
                                KapasitasMuat ,
                                Persentase ,
                                Tipe ,
                                Keterangan ,
                                UsedForCustomer ,
                                CreateBy ,
                                CreateDate ,
                                UpdateBy ,
                                UpdateDate
                        FROM    dbo.M_PPICBuildup
                        WHERE   ID = " & ID & ""
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Dim modelHeader As New PPICBuildupModel
            If dt.Rows.Count > 0 Then
                With modelHeader
                    .ID = If(IsDBNull(dt.Rows(0).Item("ID")), 0, dt.Rows(0).Item("ID"))
                    .JenisPacking = If(IsDBNull(dt.Rows(0).Item("JenisPacking")), "", dt.Rows(0).Item("JenisPacking").ToString())
                    .Panjang = If(IsDBNull(dt.Rows(0).Item("Panjang")), 0, dt.Rows(0).Item("Panjang"))
                    .Lebar = If(IsDBNull(dt.Rows(0).Item("Lebar")), 0, dt.Rows(0).Item("Lebar"))
                    .Tinggi = If(IsDBNull(dt.Rows(0).Item("Tinggi")), 0, dt.Rows(0).Item("Tinggi"))
                    .QtyPallet = If(IsDBNull(dt.Rows(0).Item("QtyPallet")), 0, dt.Rows(0).Item("QtyPallet"))
                    .StandarQty = If(IsDBNull(dt.Rows(0).Item("StandarQty")), 0, dt.Rows(0).Item("StandarQty"))
                    .KapasitasMuat = If(IsDBNull(dt.Rows(0).Item("KapasitasMuat")), 0, dt.Rows(0).Item("KapasitasMuat"))
                    .Persentase = If(IsDBNull(dt.Rows(0).Item("Persentase")), 0, dt.Rows(0).Item("Persentase"))
                    .Tipe = If(IsDBNull(dt.Rows(0).Item("Tipe")), "", dt.Rows(0).Item("Tipe").ToString())
                    .Keterangan = If(IsDBNull(dt.Rows(0).Item("Keterangan")), "", dt.Rows(0).Item("Keterangan").ToString())
                    .UsedForCustomer = If(IsDBNull(dt.Rows(0).Item("UsedForCustomer")), "", dt.Rows(0).Item("UsedForCustomer").ToString())
                    .CreateBy = If(IsDBNull(dt.Rows(0).Item("CreateBy")), "", dt.Rows(0).Item("CreateBy").ToString())
                    .CreateDate = If(IsDBNull(dt.Rows(0).Item("CreateDate")), DateTime.Now, dt.Rows(0).Item("CreateDate"))
                    .UpdateBy = If(IsDBNull(dt.Rows(0).Item("UpdateBy")), "", dt.Rows(0).Item("UpdateBy").ToString())
                    .UpdateDate = If(IsDBNull(dt.Rows(0).Item("UpdateDate")), DateTime.Now, dt.Rows(0).Item("UpdateDate"))
                End With
            End If
            Return modelHeader
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub InsertDataBuildup(Data As PPICBuildupModel)
        Try
            strQuery = "INSERT dbo.M_PPICBuildup
                                ( JenisPacking ,
                                  Panjang ,
                                  Lebar ,
                                  Tinggi ,
                                  QtyPallet ,
                                  StandarQty ,
                                  KapasitasMuat ,
                                  Persentase ,
                                  Tipe ,
                                  Keterangan ,
                                  UsedForCustomer ,
                                  CreateBy ,
                                  CreateDate ,
                                  UpdateBy ,
                                  UpdateDate
                                )
                        VALUES  ( " & QVal(Data.JenisPacking) & " , -- JenisPacking - varchar(20)
                                  " & Data.Panjang & " , -- Panjang - float
                                  " & Data.Lebar & " , -- Lebar - float
                                  " & Data.Tinggi & " , -- Tinggi - float
                                  " & Data.QtyPallet & " , -- QtyPallet - int
                                  " & Data.StandarQty & " , -- StandarQty - int
                                  " & Data.KapasitasMuat & " , -- KapasitasMuat - int
                                  " & Data.Persentase & " , -- Persentase - float
                                  " & QVal(Data.Tipe) & " , -- Tipe - varchar(20)
                                  " & QVal(Data.Keterangan) & " , -- Keterangan - varchar(50)
                                  " & QVal(Data.UsedForCustomer) & " , -- UsedForCustomer - varchar(5)
                                  " & QVal(Data.CreateBy) & " , -- CreateBy - varchar(20)
                                  " & QVal(Data.CreateDate) & " , -- CreateDate - datetime
                                  " & QVal(Data.UpdateBy) & " , -- UpdateBy - varchar(20)
                                  " & QVal(Data.UpdateDate) & "  -- UpdateDate - datetime
                                )"
            MainModul.ExecQuery(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub UpdateDataBuildup(Data As PPICBuildupModel)
        Try
            strQuery = "UPDATE [New_BOM].[dbo].[M_PPICBuildup]
                           SET [Panjang] = " & Data.Panjang & "
                              ,[Lebar] = " & Data.Lebar & "
                              ,[Tinggi] = " & Data.Tinggi & "
                              ,[QtyPallet] = " & Data.QtyPallet & "
                              ,[StandarQty] = " & Data.StandarQty & "
                              ,[KapasitasMuat] = " & Data.KapasitasMuat & "
                              ,[Persentase] = " & Data.Persentase & "
                              ,[Tipe] = " & QVal(Data.Tipe) & "
                              ,[Keterangan] = " & QVal(Data.Keterangan) & "
                              ,[UsedForCustomer] = " & QVal(Data.UsedForCustomer) & "
                              ,[UpdateBy] = " & QVal(Data.UpdateBy) & "
                              ,[UpdateDate] = " & QVal(Data.UpdateDate) & "
                         WHERE ID = " & Data.ID & ""
            MainModul.ExecQuery(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteDataBuildup(ByVal ID As Integer)
        Try
            strQuery = "DELETE FROM dbo.M_PPICBuildup WHERE ID = " & ID & ""
            MainModul.ExecQuery(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub CheckDuplicateBuildup(Data As PPICBuildupModel)
        Try
            strQuery = "SELECT  *
                        FROM    dbo.M_PPICBuildup
                        WHERE   JenisPacking = " & QVal(Data.JenisPacking) & ""
            Dim dtTable As New DataTable
            dtTable = GetDataTable(strQuery)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
                "[" & Data.JenisPacking & "]")
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetDataKapOEM() As DataTable
        Try
            strQuery = "SELECT  ID ,
                                Model ,
                                Location ,
                                PartNo ,
                                PartName ,
                                InventoryID ,
                                JenisPacking ,
                                StandarQty ,
                                KapasitasMuat ,
                                CreateBy ,
                                CreateDate ,
                                UpdateBy ,
                                UpdateDate
                        FROM    dbo.M_PPICKapOEM"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataKapOEMByID(ByVal ID As Integer) As PPICKapOEMModel
        Try
            strQuery = "SELECT  ID ,
                                Model ,
                                Location ,
                                PartNo ,
                                PartName ,
                                InventoryID ,
                                JenisPacking ,
                                StandarQty ,
                                KapasitasMuat ,
                                CreateBy ,
                                CreateDate ,
                                UpdateBy ,
                                UpdateDate
                        FROM    dbo.M_PPICKapOEM
                        WHERE   ID = " & ID & ""
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Dim modelHeader As New PPICKapOEMModel
            If dt.Rows.Count > 0 Then
                With modelHeader
                    .ID = If(IsDBNull(dt.Rows(0).Item("ID")), 0, dt.Rows(0).Item("ID"))
                    .Model = If(IsDBNull(dt.Rows(0).Item("Model")), "", dt.Rows(0).Item("Model").ToString())
                    .Location = If(IsDBNull(dt.Rows(0).Item("Location")), "", dt.Rows(0).Item("Location").ToString())
                    .PartNo = If(IsDBNull(dt.Rows(0).Item("PartNo")), "", dt.Rows(0).Item("PartNo").ToString())
                    .PartName = If(IsDBNull(dt.Rows(0).Item("PartName")), "", dt.Rows(0).Item("PartName").ToString())
                    .InventoryID = If(IsDBNull(dt.Rows(0).Item("InventoryID")), "", dt.Rows(0).Item("InventoryID").ToString())
                    .JenisPacking = If(IsDBNull(dt.Rows(0).Item("JenisPacking")), "", dt.Rows(0).Item("JenisPacking").ToString())
                    .StandarQty = If(IsDBNull(dt.Rows(0).Item("StandarQty")), 0, dt.Rows(0).Item("StandarQty"))
                    .KapasitasMuat = If(IsDBNull(dt.Rows(0).Item("KapasitasMuat")), 0, dt.Rows(0).Item("KapasitasMuat"))
                    .CreateBy = If(IsDBNull(dt.Rows(0).Item("CreateBy")), "", dt.Rows(0).Item("CreateBy").ToString())
                    .CreateDate = If(IsDBNull(dt.Rows(0).Item("CreateDate")), DateTime.Now, dt.Rows(0).Item("CreateDate"))
                    .UpdateBy = If(IsDBNull(dt.Rows(0).Item("UpdateBy")), "", dt.Rows(0).Item("UpdateBy").ToString())
                    .UpdateDate = If(IsDBNull(dt.Rows(0).Item("UpdateDate")), DateTime.Now, dt.Rows(0).Item("UpdateDate"))
                End With
            End If
            Return modelHeader
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub InsertDataKapOEM(Data As PPICKapOEMModel)
        Try
            strQuery = "INSERT INTO dbo.M_PPICKapOEM
                                ( Model ,
                                  Location ,
                                  PartNo ,
                                  PartName ,
                                  InventoryID ,
                                  JenisPacking ,
                                  StandarQty ,
                                  KapasitasMuat ,
                                  CreateBy ,
                                  CreateDate ,
                                  UpdateBy ,
                                  UpdateDate
                                )
                        VALUES  ( " & QVal(Data.Model) & " , -- Model - varchar(5)
                                  " & QVal(Data.Location) & " , -- Location - varchar(20)
                                  " & QVal(Data.PartNo) & " , -- PartNo - varchar(20)
                                  " & QVal(Data.PartName) & " , -- PartName - varchar(50)
                                  " & QVal(Data.InventoryID) & " , -- InventoryID - varchar(20)
                                  " & QVal(Data.JenisPacking) & " , -- JenisPacking - varchar(20)
                                  " & Data.StandarQty & " , -- StandarQty - int
                                  " & Data.KapasitasMuat & " , -- KapasitasMuat - int
                                  " & QVal(Data.CreateBy) & " , -- CreateBy - varchar(20)
                                  " & QVal(Data.CreateDate) & " , -- CreateDate - datetime
                                  " & QVal(Data.UpdateBy) & " , -- UpdateBy - varchar(20)
                                  " & QVal(Data.UpdateDate) & "  -- UpdateDate - datetime
                                )"
            MainModul.ExecQuery(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub UpdateDataKapOEM(Data As PPICKapOEMModel)
        Try
            strQuery = "UPDATE [New_BOM].[dbo].[M_PPICKapOEM]
                           SET [Model] = " & QVal(Data.Model) & "
                              ,[Location] = " & QVal(Data.Location) & "
                              ,[PartName] = " & QVal(Data.PartName) & "
                              ,[JenisPacking] = " & QVal(Data.JenisPacking) & "
                              ,[StandarQty] = " & Data.StandarQty & "
                              ,[KapasitasMuat] = " & Data.KapasitasMuat & "
                              ,[UpdateBy] = " & QVal(Data.UpdateBy) & "
                              ,[UpdateDate] = " & QVal(Data.UpdateDate) & "
                         WHERE ID = " & Data.ID & ""
            MainModul.ExecQuery(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteDataKapOEM(ByVal ID As Integer)
        Try
            strQuery = "DELETE FROM dbo.M_PPICKapOEM WHERE ID = " & ID & ""
            MainModul.ExecQuery(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub CheckDuplicateKapOEM(Data As PPICKapOEMModel)
        Try
            strQuery = "SELECT  *
                        FROM    dbo.M_PPICKapOEM
                        WHERE   PartNo = " & QVal(Data.PartNo) & "
                                AND InventoryID = " & QVal(Data.InventoryID) & ""
            Dim dtTable As New DataTable
            dtTable = GetDataTable(strQuery)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
                "[" & Data.PartNo & "] & [" & Data.InventoryID & "]")
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetDataJenisPacking() As DataTable
        Try
            strQuery = "SELECT  JenisPacking ,
                                Keterangan ,
                                KapasitasMuat ,                                
                                UsedForCustomer
                        FROM    dbo.M_PPICBuildup"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataConvertMuatHeader(dateFrom As Date, dateTo As Date) As DataTable
        Try
            strQuery = "SELECT  NoUpload ,
                                UploadDate ,
                                CustID ,
                                FileName ,
                                Revised ,
                                TotalRecordExcel ,
                                TotalMobil ,
                                CreateBy ,
                                CreateDate
                        FROM    dbo.T_PPICConvertMuatHeader
                        WHERE   ( CAST(UploadDate AS DATE) >= " & QVal(dateFrom) & "
                                  AND CAST(UploadDate AS DATE) <= " & QVal(dateTo) & "
                                )"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub SaveConverMuat(frm As Form, Data As PPICConvertMuatHeaderModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertConvertHeader(Data)

                        For i As Integer = 0 To Data.ObjConvertDetails.Count - 1
                            InsertConvertDetail(Data.ObjConvertDetails(i))
                        Next

                        _globalService = New GlobalService
                        _globalService.UpdateAutoNumber(frm)

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

    Public Sub InsertConvertHeader(Data As PPICConvertMuatHeaderModel)
        Try
            strQuery = "INSERT  INTO dbo.T_PPICConvertMuatHeader
                                ( NoUpload ,
                                  UploadDate ,
                                  CustID ,
                                  FileName ,
                                  Revised ,
                                  TotalRecordExcel ,
                                  TotalMobil ,
                                  CreateBy ,
                                  CreateDate
                                )
                        VALUES  ( " & QVal(Data.NoUpload) & " , -- NoUpload - varchar(20)
                                  " & QVal(Data.UploadDate) & " , -- UploadDate - date
                                  " & QVal(Data.CustID) & " , -- CustID - varchar(10)
                                  " & QVal(Data.FileName) & " , -- FileName - varchar(50)
                                  " & QVal(Data.Revised) & " , -- Revised - varchar(10)
                                  " & Data.TotalRecordExcel & " , -- TotalRecordExcel - int
                                  " & Data.TotalMobil & " , -- TotalMobil - int
                                  " & QVal(gh_Common.Username) & " , -- CreateBy - varchar(50)
                                  GETDATE()  -- CreateDate - datetime
                                )"
            MainModul.ExecQuery(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertConvertDetail(Data As PPICConvertMuatDetailModel)
        Try
            strQuery = "INSERT  INTO dbo.T_PPICConvertMuatDetail
                                ( NoUpload ,
                                  Seq ,
                                  ItemNumber ,
                                  ItemName ,
                                  UserCode ,
                                  PF ,
                                  OrderNo ,
                                  DeliveryDueDate ,
                                  DeliveryTime ,
                                  OrderQuantity ,
                                  JenisPacking ,
                                  StandarQty ,
                                  KapasitasMuat ,
                                  ButuhPacking ,
                                  KebutuhanTruk ,
                                  GroupTruk
                                )
                        VALUES  ( " & QVal(Data.NoUpload) & " , -- NoUpload - varchar(20)
                                  " & Data.Seq & " , -- Seq - int
                                  " & QVal(Data.ItemNumber) & " , -- ItemNumber - varchar(20)
                                  " & QVal(Data.ItemName) & " , -- ItemName - varchar(50)
                                  " & QVal(Data.UserCode) & " , -- UserCode - varchar(20)
                                  " & QVal(Data.PF) & " , -- PF - varchar(20)
                                  " & Data.OrderNo & " , -- OrderNo - int
                                  " & QVal(Data.DeliveryDueDate) & " , -- DeliveryDueDate - date
                                  " & QVal(Data.DeliveryTime) & " , -- DeliveryTime - datetime
                                  " & Data.OrderQuantity & " , -- OrderQuantity - int
                                  " & QVal(Data.JenisPacking) & " , -- JenisPacking - varchar(20)
                                  " & Data.StandarQty & " , -- StandarQty - int
                                  " & Data.KapasitasMuat & " , -- KapasitasMuat - int
                                  " & Data.ButuhPacking & " , -- ButuhPacking - int
                                  " & Data.KebutuhanTruk & " , -- KebutuhanTruk - float
                                  " & Data.GroupTruk & " -- GroupTruk - int
                                )"
            MainModul.ExecQuery(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetDataConvertMuatDetail(NoUpload As String) As DataTable
        Try
            strQuery = "SELECT  ROW_NUMBER() OVER ( ORDER BY UserCode ASC, DeliveryTime ASC ) AS No ,
                                Seq ,
                                ItemNumber ,
                                ItemName ,
                                UserCode ,
                                PF ,
                                OrderNo ,
                                DeliveryDueDate ,
                                DeliveryTime ,
                                OrderQuantity ,
                                JenisPacking ,
                                StandarQty ,
                                KapasitasMuat ,
                                ButuhPacking ,
                                KebutuhanTruk ,
                                GroupTruk
                        FROM    dbo.T_PPICConvertMuatDetail
                        WHERE   NoUpload = " & QVal(NoUpload) & ""
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CheckInventoryID(CustID As String) As DataTable
        Try
            strQuery = "SELECT  DISTINCT
                                REPLACE(REPLACE(RTRIM(ixr.AlternateID), '-', ''), CHAR(160), '') AS AlternateID ,
                                RTRIM(inv.InvtID) AS InvtID
                        FROM    Inventory AS inv
                                INNER JOIN ItemXRef AS ixr ON ixr.InvtID = inv.InvtID
                        WHERE   ixr.AltIDType = 'C'
                                AND inv.TranStatusCode = 'AC'
                                AND ixr.EntityID = " & QVal(CustID) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CheckBuildup() As DataTable
        Try
            strQuery = "SELECT  REPLACE(PartNo, '-', '') AS PartNo ,
                                InventoryID ,
                                CAST(JenisPacking AS VARCHAR(20)) AS JenisPacking ,
                                StandarQty ,
                                KapasitasMuat
                        FROM    dbo.M_PPICKapOEM"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CheckDataExist(UploadDate As Date) As Integer
        Try
            strQuery = "SELECT  COUNT(NoUpload) AS IsRev
                        FROM    dbo.T_PPICConvertMuatHeader
                        WHERE   UploadDate = " & QVal(UploadDate) & ""
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt.Rows(0).Item("IsRev")
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub CopyDTToDB(dtUpload As DataTable)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Using sqlBulkCopy As New SqlBulkCopy(Conn1)
                    sqlBulkCopy.DestinationTableName = "dbo.T_PPICTempPO"

                    Conn1.Open()
                    sqlBulkCopy.WriteToServer(dtUpload)
                    Conn1.Close()
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetDataPPICTemp() As DataTable
        Try
            strQuery = "SELECT  ROW_NUMBER() OVER ( ORDER BY usr.[Group] ASC, usr.Seq ASC, temp.UserCode ASC, temp.DeliveryTime ASC ) AS [No] ,
                                temp.Seq ,
                                temp.ItemNumber ,
                                temp.ItemName ,
                                temp.UserCode ,
                                temp.PF ,
                                usr.[Group] ,
                                usr.Seq ,
                                temp.OrderNo ,
                                temp.DeliveryDueDate ,
                                temp.DeliveryTime ,
                                temp.OrderQuantity ,
                                temp.JenisPacking ,
                                temp.StandarQty ,
                                temp.KapasitasMuat ,
                                temp.ButuhPacking ,
                                temp.KebutuhanTruk ,
                                temp.GroupTruk
                        FROM    dbo.T_PPICTempPO AS temp
                                INNER JOIN dbo.M_PPICUser AS usr ON usr.UserCode = temp.UserCode
                                                                    AND COALESCE(usr.PF, '') = COALESCE(temp.PF,
                                                                                      '')"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub DeleteDataTemp()
        Try
            strQuery = "DELETE FROM dbo.M_PPICKapOEM"
            MainModul.ExecQuery(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
