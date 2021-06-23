Imports System.Collections.ObjectModel

Public Class ClsMktUploadPrice
    Dim _globalService As GlobalService
    Public Property NoUpload As String
    Public Property CustID As String
    Public Property Template As String
    Public Property FileName As String
    Public Property Revised As String
    Public Property TotalRecord As Integer
    Public Property TotalRecordExcel As Integer
    Public Property UserName As String
    Public Property UploadDate As DateTime
    Public Property ObjPriceDetails() As New Collection(Of ClsMktUploadPriceDetail)

    Dim strQuery As String

    Public Function GetListTemplate(custID As String) As DataTable
        Try
            Dim sql As String
            sql = " SELECT  *
                    FROM    dbo.S_MktTemplateUploadPrice
                    WHERE   CustID = " & QVal(custID) & "
                            OR CustID = 'ALL'
                    ORDER BY TemplateID ASC; "
            Dim dt As New DataTable
            dt = GetDataTable(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetColumnExcel(ByVal templateID As String) As DataTable
        Try
            Dim sql As String
            sql = " SELECT  pvt.TemplateID ,
                            pvt.invtid AS InvtID ,
                            pvt.partnoR AS PartNoR ,
                            pvt.partnoS AS PartNoS ,
                            pvt.[desc] AS [Desc] ,
                            pvt.discpriceP AS PriceP ,
                            pvt.discpriceS AS PriceS ,
                            pvt.startdate AS StartDate
                    FROM    ( SELECT    TemplateID ,
                                        ColumnInTable ,
                                        ColumnInExcel
                              FROM      dbo.S_MktMappingUploadPrice
                              WHERE     TemplateID = " & QVal(templateID) & "
                            ) AS tbl PIVOT ( MAX(ColumnInExcel) FOR ColumnInTable IN ( [invtid],
                                                                                  [partnoR],
                                                                                  [partnoS],
                                                                                  [desc],
                                                                                  [discpriceP],
                                                                                  [discpriceS],
                                                                                  [startdate] ) ) AS pvt "
            Dim dt As New DataTable
            dt = GetDataTable(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub SaveUpload(frm As Form)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertHeader()

                        For i As Integer = 0 To ObjPriceDetails.Count - 1
                            With ObjPriceDetails(i)
                                .InsertDetail()
                                .UpdatePrice()
                            End With
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

    Public Sub InsertHeader()
        Try
            strQuery = "INSERT INTO	dbo.T_MktUploadPriceHeader
                                ( NoUpload ,
                                  CustID ,
                                  Template ,
                                  FileName ,
                                  Revised ,
                                  TotalRecordExcel ,
                                  TotalRecord ,
                                  UserName ,
                                  UploadDate
                                )
                        VALUES  ( " & QVal(NoUpload) & " , -- NoUpload - varchar(20)
                                  " & QVal(CustID) & " , -- CustID - varchar(10)
                                  " & QVal(Template) & " , -- Template - varchar(50)
                                  " & QVal(FileName) & " , -- FileName - varchar(50)
                                  " & QVal(Revised) & " , -- Revised - varchar(10)
                                  " & TotalRecordExcel & " , -- TotalRecordExcel - int
                                  " & TotalRecord & " , -- TotalRecord - int
                                  " & QVal(gh_Common.Username) & " , -- UserName - varchar(50)
                                  GETDATE()  -- UploadDate - datetime
                                )"
            ExecQuery(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function CheckInventoryID(CustID As String) As DataTable
        Try
            Dim sql As String
            sql = " SELECT  DISTINCT
                            REPLACE(REPLACE(RTRIM(ixr.AlternateID), '-', ''), CHAR(160), '') AS AlternateID ,
                            RTRIM(inv.InvtID) AS InvtID ,
                            LEFT(RIGHT(RTRIM(inv.InvtID), 2), 1) AS PartType ,
                            price.StartDate ,
                            price.DiscPrice
                    FROM    Inventory AS inv
                            INNER JOIN ItemXRef AS ixr ON ixr.InvtID = inv.InvtID
                            LEFT JOIN ( SELECT  sp.InvtID ,
                                                spd.StartDate ,
                                                spd.DiscPrice
                                        FROM    dbo.SlsPrc AS sp
                                                INNER JOIN dbo.SlsPrcDet AS spd ON sp.SlsPrcID = spd.SlsPrcID
                                        WHERE   sp.CustID = " & QVal(CustID) & "
                                      ) AS price ON price.InvtID = ixr.InvtID
                    WHERE   ixr.AltIDType = 'C'
                            AND inv.TranStatusCode = 'AC'
                            AND ixr.EntityID = " & QVal(CustID) & " "
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataCustomer() As DataTable
        Try
            strQuery = "SELECT  CustId ,
                                Name,
                                Addr1
                        FROM    Customer"
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataUploadHeader(dateFrom As Date, dateTo As Date) As DataTable
        Try
            strQuery = "SELECT  NoUpload ,
                                CustID ,
                                Template ,
                                FileName ,
                                Revised ,
                                TotalRecordExcel AS RecordExcel ,
                                TotalRecord AS RecordUpload,
                                UserName ,
                                UploadDate
                        FROM    dbo.T_MktUploadPriceHeader
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

    Public Function GetDataUploadDetail(_noUpload As String) As DataTable
        Try
            strQuery = "SELECT  ROW_NUMBER() OVER ( ORDER BY PartNo ASC ) AS [No] ,
                                PartNo ,
                                InvtID ,
                                PartName ,
                                OldPrice ,
                                NewPriceR ,
                                NewPriceS ,
                                StartDate AS EffectiveDate
                        FROM    dbo.T_MktUploadPriceDetail
                        WHERE   NoUpload = " & QVal(_noUpload) & ""
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CheckFileName(__fileName As String) As Integer
        Try
            Dim sql As String
            sql = " SELECT  COUNT(NoUpload) AS IsRev
                    FROM    dbo.T_MktUploadPriceHeader
                    WHERE   FileName = " & QVal(__fileName) & " "
            Dim dt As New DataTable
            dt = GetDataTable(sql)
            Return dt.Rows(0).Item("IsRev")
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetTotalTrans(__partNo As String, __invtID As String) As Integer
        Try
            Dim sql As String
            sql = " SELECT  COUNT(AlternateID) AS Total
                    FROM    dbo.SOLine
                    WHERE   REPLACE(AlternateID, '-', '') = " & QVal(__partNo) & "
                            AND InvtID = " & QVal(__invtID) & " "
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt.Rows(0).Item("Total")
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class

Public Class ClsMktUploadPriceDetail
    Public Property NoUpload As String
    Public Property CustID As String
    Public Property PartNo As String
    Public Property InvtID As String
    Public Property Desc As String
    Public Property OldPrice As Double
    Public Property NewPriceR As Double
    Public Property NewPriceS As Double
    Public Property StartDate As Date

    Dim strQuery As String

    Public Sub InsertDetail()
        Try
            strQuery = "INSERT INTO dbo.T_MktUploadPriceDetail
                                ( NoUpload ,
                                  CustID ,
                                  PartNo ,
                                  InvtID ,
                                  PartName ,
                                  OldPrice ,
                                  NewPriceR ,
                                  NewPriceS ,
                                  StartDate
                                )
                        VALUES  ( " & QVal(NoUpload) & " , -- NoUpload - varchar(20)
                                  " & QVal(CustID) & " , -- CustID - varchar(10)
                                  " & QVal(PartNo) & " , -- PartNo - varchar(50)
                                  " & QVal(InvtID) & " , -- InvtID - varchar(50)
                                  " & QVal(Desc) & " , -- PartName - varchar(50)
                                  " & OldPrice & " , -- OldPrice - float
                                  " & NewPriceR & " , -- NewPriceR - float
                                  " & NewPriceS & " , -- NewPriceS - float
                                  " & QVal(StartDate) & " -- StartDate - date
                                )"
            ExecQuery(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub UpdatePrice()
        Try
            strQuery = "UPDATE  TSC16Application.dbo.SlsPrcDet
                        SET     DiscPrice = " & NewPriceR + NewPriceS & " ,
                                StartDate = " & QVal(StartDate) & "
                        FROM    TSC16Application.dbo.SlsPrc AS sp
                                INNER JOIN TSC16Application.dbo.SlsPrcDet AS spd ON spd.SlsPrcID = sp.SlsPrcID
                        WHERE   CustID = " & QVal(CustID) & "
                                AND InvtID = " & QVal(InvtID) & ""
            ExecQuery(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class
