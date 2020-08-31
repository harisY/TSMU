﻿Imports System.Collections.ObjectModel

Public Class TravelHeaderModel
    Public Property TravelHeaderID As Integer
    Public Property DeptID As String
    Public Property Destination As String
    Public Property NIK As String
    Public Property NamaDetail As String
    Public Property Nama As String
    Public Property PickUp As String
    Public Property Purpose As String
    Public Property Term As String
    Public Property TotalAdvanceYEN As Double
    Public Property TotalAdvanceIDR As Double
    Public Property TotalAdvanceUSD As Double
    Public Property TotalAdvIDR As Double
    Public Property TravelID As String
    Public Property Visa As String
    Public Property Tgl As DateTime
    Public Property Depdate As DateTime
    Public Property Arrdate As DateTime
    Public Property Status As String
    Public Property _id As String

    Public Property ID() As String
        Get
            Return _ID
        End Get
        Set(ByVal value As String)
            _ID = value
        End Set
    End Property

    Public Sub Delete()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1
                    Dim query As String
                    Try
                        query = " DELETE  FROM dbo.TravelHeader " & vbCrLf &
                                " WHERE   TravelID = " & QVal(Me._id) & " "
                        MainModul.ExecQuery_Solomon(query)

                        query = " DELETE  FROM dbo.TravelDetail " & vbCrLf &
                                " WHERE   TravelID = " & QVal(Me._id) & " "
                        MainModul.ExecQuery_Solomon(query)

                        query = " DELETE  FROM dbo.TravelToTravelerDetail " & vbCrLf &
                                " WHERE   TravelID = " & QVal(Me._id) & " "
                        MainModul.ExecQuery_Solomon(query)

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

    Public Property ObjDetails() As New Collection(Of TravelDetailModel)

    Public Function GetDataGrid() As DataTable
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "Travel_Get_TravelHeader"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
            pParam(0) = New SqlClient.SqlParameter("@TravelHeaderID", SqlDbType.Int)
            pParam(0).Value = 0
            pParam(1) = New SqlClient.SqlParameter("@TravelID", SqlDbType.VarChar)
            pParam(1).Value = ""
            pParam(2) = New SqlClient.SqlParameter("@Status", SqlDbType.VarChar)
            pParam(2).Value = IIf(Status = Nothing, "", Status)
            dt = MainModul.GetDataTableByCommand_SP(SP_Name, pParam)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDept2() As List(Of String)
        Try
            Dim result As New List(Of String)

            Dim dt As New DataTable
            Dim sql As String =
            "select '''' + RTRIM(a.DeptID) + '''' DeptID from S_User u inner join
	            akses_approval a on u.Username = a.Username
            WHERE a.Username = " & QVal(gh_Common.Username) & ""
            dt = GetDataTable(sql)
            For Each row As DataRow In dt.Rows
                result.Add(row("DeptID"))
            Next
            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataGrid2() As DataTable
        Try
            Dim dept As String()
            dept = GetDept2.ToArray
            Dim nilai = String.Join(",", GetDept2.ToArray)

            Dim dt As New DataTable
            Dim sql As String =
            "SELECT TravelHeaderID      ,TravelID      ,Nama      ,Destination      ,Term      ,Purpose      ,DeptID      ,PickUp      ,Visa      ,TotalAdvanceIDR,TotalAdvanceYEN,TotalAdvanceUSD,TotalAdvIDR,Tgl,TglBerangkat,TglTiba  
            FROM TravelHeader WHERE deptid in(" & nilai & ")  and status<>'Open' Order by TravelID"
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataGridRequest() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String
            sql = " SELECT  trh.NoRequest ,
                            trh.Nama ,
                            trh.DeptID ,
                            trh.TravelType ,
                            trh.Purpose ,
                            trd.DepartureDate ,
                            trd.ArrivalDate ,
                            trd.Term ,
                            trc.AdvanceIDR ,
                            trc.AdvanceUSD ,
                            trc.AdvanceYEN
                    FROM    dbo.TravelRequestHeader AS trh
                            LEFT JOIN ( SELECT  NoRequest ,
                                                MIN(DepartureDate) AS DepartureDate ,
                                                MAX(ArrivalDate) AS ArrivalDate ,
                                                CASE WHEN FORMAT(MIN(DepartureDate), 'MMyyyy') = FORMAT(MAX(ArrivalDate),
                                                                                  'MMyyyy')
                                                     THEN FORMAT(MIN(DepartureDate), 'dd') + ' - '
                                                          + FORMAT(MAX(ArrivalDate),
                                                                   'dd MMMM yyyy')
                                                     ELSE FORMAT(MIN(DepartureDate),
                                                                 'dd MMMM yyyy') + ' - '
                                                          + FORMAT(MAX(ArrivalDate),
                                                                   'dd MMMM yyyy')
                                                END AS Term
                                        FROM    dbo.TravelRequestDetail
                                        GROUP BY NoRequest
                                      ) AS trd ON trd.NoRequest = trh.NoRequest
                            LEFT JOIN dbo.TravelRequestCost AS trc ON trc.NoRequest = trh.NoRequest
                    WHERE   Status = 'OPEN'
                            AND trc.CostType = 'C03' "
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function TravelAutoNo() As String

        Try
            Dim query As String

            query = "declare  @bulan varchar(4), @tahun varchar(4),@seq varchar(4) " &
                 "set @bulan = LEFT(CONVERT(CHAR(20), GETDATE(), 101), 2) " &
                "set @tahun = datepart(year,getdate()) " &
                "set @seq= (select right('0000'+cast(right(rtrim(max(TravelID)),4)+1 as varchar),4) " &
                "from TravelHeader " &
                "where SUBSTRING(TravelID,1,7) = 'TR' + '-' + RIGHT(@tahun,4) AND SUBSTRING(TravelID,9,2) = RIGHT(@bulan,2)) " &
                "select 'TR' + '-' + RIGHT(@tahun,4) + '-' + @bulan + '-' + coalesce(@seq, '0001')"

            Dim dt As DataTable = New DataTable
            dt = GetDataTable_Solomon(query)
            Return dt.Rows(0).Item(0).ToString

        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Sub GetTravelById()
        Try
            Dim sql As String =
            "SELECT TravelHeaderID,TravelID      ,Nama      ,Destination      ,Term      ,Purpose      ,DeptID      ,PickUp      ,Visa      ,TotalAdvanceIDR,TotalAdvanceYEN,TotalAdvanceUSD,TotalAdvIDR,Tgl,TglBerangkat,TglTiba    FROM TravelHeader where TravelHeaderID=" & QVal(TravelHeaderID) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            If dt.Rows.Count > 0 Then
                '  ID = If(IsDBNull(dt.Rows(0).Item("TravelHeaderID")), "", Trim(dt.Rows(0).Item("TravelHeaderID").ToString()))
                TravelID = If(IsDBNull(dt.Rows(0).Item("TravelID")), "", Trim(dt.Rows(0).Item("TravelID").ToString()))
                'DeptID = If(IsDBNull(dt.Rows(0).Item("DeptID")), "", Trim(dt.Rows(0).Item("DeptID").ToString()))
                'Nama = If(IsDBNull(dt.Rows(0).Item("Nama")), "", Trim(dt.Rows(0).Item("Nama").ToString()))
                Destination = If(IsDBNull(dt.Rows(0).Item("Destination")), "", Trim(dt.Rows(0).Item("Destination").ToString()))
                Tgl = If(IsDBNull(dt.Rows(0).Item("Tgl")), DateTime.Today, Convert.ToDateTime(dt.Rows(0).Item("Tgl")))
                Depdate = If(IsDBNull(dt.Rows(0).Item("TglBerangkat")), DateTime.Today, Convert.ToDateTime(dt.Rows(0).Item("TglBerangkat")))
                Arrdate = If(IsDBNull(dt.Rows(0).Item("TglTiba")), DateTime.Today, Convert.ToDateTime(dt.Rows(0).Item("TglTiba")))
                Term = If(IsDBNull(dt.Rows(0).Item("Term")), "", Trim(dt.Rows(0).Item("Term").ToString()))
                TotalAdvanceIDR = If(IsDBNull(dt.Rows(0).Item("TotalAdvanceIDR")), 0, Convert.ToDouble(dt.Rows(0).Item("TotalAdvanceIDR")))
                TotalAdvanceUSD = If(IsDBNull(dt.Rows(0).Item("TotalAdvanceUSD")), 0, Convert.ToDouble(dt.Rows(0).Item("TotalAdvanceUSD")))
                TotalAdvanceYEN = If(IsDBNull(dt.Rows(0).Item("TotalAdvanceYEN")), 0, Convert.ToDouble(dt.Rows(0).Item("TotalAdvanceYEN")))
                TotalAdvIDR = If(IsDBNull(dt.Rows(0).Item("TotalAdvIDR")), 0, Convert.ToDouble(dt.Rows(0).Item("TotalAdvIDR")))
                Purpose = If(IsDBNull(dt.Rows(0).Item("Purpose")), "", Convert.ToString(dt.Rows(0).Item("Purpose")))
                Visa = If(IsDBNull(dt.Rows(0).Item("Visa")), "", Trim(dt.Rows(0).Item("Visa").ToString()))
                PickUp = If(IsDBNull(dt.Rows(0).Item("PickUp")), "", Trim(dt.Rows(0).Item("PickUp").ToString()))

            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub GetTravelByTravelID()
        Try
            Dim sql As String
            sql = " SELECT  TravelID ,
                            Nama ,
                            Destination ,
                            Term ,
                            Purpose ,
                            DeptID ,
                            PickUp ,
                            Visa ,
                            TotalAdvanceIDR ,
                            TotalAdvanceYEN ,
                            TotalAdvanceUSD ,
                            TotalAdvIDR ,
                            Tgl ,
                            TglBerangkat ,
                            TglTiba
                    FROM    TravelHeader
                    WHERE   TravelID = " & QVal(TravelID) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            If dt.Rows.Count > 0 Then
                TravelID = If(IsDBNull(dt.Rows(0).Item("TravelID")), "", Trim(dt.Rows(0).Item("TravelID").ToString()))
                DeptID = If(IsDBNull(dt.Rows(0).Item("DeptID")), "", Trim(dt.Rows(0).Item("DeptID").ToString()))
                Nama = If(IsDBNull(dt.Rows(0).Item("Nama")), "", Trim(dt.Rows(0).Item("Nama").ToString()))
                Destination = If(IsDBNull(dt.Rows(0).Item("Destination")), "", Trim(dt.Rows(0).Item("Destination").ToString()))
                Tgl = If(IsDBNull(dt.Rows(0).Item("Tgl")), DateTime.Today, Convert.ToDateTime(dt.Rows(0).Item("Tgl")))
                Depdate = If(IsDBNull(dt.Rows(0).Item("TglBerangkat")), DateTime.Today, Convert.ToDateTime(dt.Rows(0).Item("TglBerangkat")))
                Arrdate = If(IsDBNull(dt.Rows(0).Item("TglTiba")), DateTime.Today, Convert.ToDateTime(dt.Rows(0).Item("TglTiba")))
                Term = If(IsDBNull(dt.Rows(0).Item("Term")), "", Trim(dt.Rows(0).Item("Term").ToString()))
                TotalAdvanceIDR = If(IsDBNull(dt.Rows(0).Item("TotalAdvanceIDR")), 0, Convert.ToDouble(dt.Rows(0).Item("TotalAdvanceIDR")))
                TotalAdvanceUSD = If(IsDBNull(dt.Rows(0).Item("TotalAdvanceUSD")), 0, Convert.ToDouble(dt.Rows(0).Item("TotalAdvanceUSD")))
                TotalAdvanceYEN = If(IsDBNull(dt.Rows(0).Item("TotalAdvanceYEN")), 0, Convert.ToDouble(dt.Rows(0).Item("TotalAdvanceYEN")))
                TotalAdvIDR = If(IsDBNull(dt.Rows(0).Item("TotalAdvIDR")), 0, Convert.ToDouble(dt.Rows(0).Item("TotalAdvIDR")))
                Purpose = If(IsDBNull(dt.Rows(0).Item("Purpose")), "", Convert.ToString(dt.Rows(0).Item("Purpose")))
                Visa = If(IsDBNull(dt.Rows(0).Item("Visa")), "", Trim(dt.Rows(0).Item("Visa").ToString()))
                PickUp = If(IsDBNull(dt.Rows(0).Item("PickUp")), "", Trim(dt.Rows(0).Item("PickUp").ToString()))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetDept() As DataTable
        Try
            Dim sql As String =
            "SELECT [IdDept]
                  ,[NamaDept]
              FROM [mDept]"
            Dim dt As New DataTable
            dt = GetDataTable(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAdvanceTravel() As DataTable
        Try
            Dim sql As String
            sql = " SELECT TravelID , " &
                    "         Nama , " &
                    "         Destination , " &
                    "         Tgl , " &
                    "         TglBerangkat , " &
                    "         TglTiba, " &
                    "         TotalAdvIDR " &
                    "  FROM   dbo.TravelHeader " &
                    "  WHERE  Status = 'Approved' "
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetTraveler() As DataTable
        Try
            Dim sql As String
            sql = " SELECT  NIK ,
                            [Nama] ,
                            [DeptID] ,                            
                            [Golongan]
                    FROM    [dbo].[Traveler] "
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAccount() As DataTable
        Try
            Dim sql As String = "   SELECT  RTRIM(Acct) [Account] ,
                                            RTRIM(Descr) Descritiption
                                    FROM    dbo.Account
                                    WHERE   SUBSTRING(Acct, 1, 1) = '5'
                                            OR SUBSTRING(Acct, 1, 1) = '6'  "
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetSubAccount() As DataTable
        Try
            Dim sql As String = "SELECT 
 	                                RTRIM(Consolsub) [SubAccount],
	                                RTRIM(Descr) Descritiption
                                FROM dbo.SubAcct"
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub InsertHeader()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO TravelHeader (TravelID      ,Nama      ,Destination      ,Term      ,Purpose      ,DeptID      ,PickUp      ,Visa      ,TotalAdvanceIDR,TotalAdvanceYEN,TotalAdvanceUSD,TotalAdvIDR,Tgl,TglBerangkat,TglTiba, CreatedBy, CreatedDate) " & vbCrLf &
            "Values(" & QVal(TravelID) & ", " & vbCrLf &
            "       " & QVal(Nama) & ", " & vbCrLf &
            "       " & QVal(Destination) & ", " & vbCrLf &
            "       " & QVal(Term) & ", " & vbCrLf &
            "       " & QVal(Purpose) & ", " & vbCrLf &
            "       " & QVal(DeptID) & ", " & vbCrLf &
            "       " & QVal(PickUp) & ", " & vbCrLf &
            "       " & QVal(Visa) & ", " & vbCrLf &
            "       " & QVal(TotalAdvanceIDR) & ", " & vbCrLf &
            "       " & QVal(TotalAdvanceYEN) & ", " & vbCrLf &
            "       " & QVal(TotalAdvanceUSD) & ", " & vbCrLf &
            "       " & QVal(TotalAdvIDR) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(Depdate) & ", " & vbCrLf &
             "       " & QVal(Arrdate) & ", " & vbCrLf &
            "       " & QVal(gh_Common.Username) & ", " & vbCrLf &
            "       GETDATE())"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub UpdateHeader(ByVal _TravelID As String)
        Try
            Dim ls_SP As String = " UPDATE  TravelHeader " & vbCrLf &
                                    " SET   Nama = " & QVal(Nama) & ", " & vbCrLf &
                                    "       Destination = " & QVal(Destination) & ", " & vbCrLf &
                                    "       Term = " & QVal(Term) & ", " & vbCrLf &
                                    "       Purpose = " & QVal(Purpose) & ", " & vbCrLf &
                                    "       DeptID = " & QVal(DeptID) & ", " & vbCrLf &
                                    "       PickUp = " & QVal(PickUp) & ", " & vbCrLf &
                                    "       Visa = " & QVal(Visa) & ", " & vbCrLf &
                                    "       TotalAdvanceIDR =  " & QVal(TotalAdvanceIDR) & ", " & vbCrLf &
                                    "       TotalAdvanceYEN = " & QVal(TotalAdvanceYEN) & ", " & vbCrLf &
                                    "       TotalAdvanceUSD = " & QVal(TotalAdvanceUSD) & ", " & vbCrLf &
                                    "       Tgl = " & QVal(Tgl) & ", " & vbCrLf &
                                    "       TglBerangkat = " & QVal(Depdate) & ", " & vbCrLf &
                                    "       TglTiba = " & QVal(Arrdate) & ", " & vbCrLf &
                                    "       TotalAdvIDR = " & QVal(TotalAdvIDR) & ", " & vbCrLf &
                                    "       UpdatedBy = " & QVal(gh_Common.Username) & ", " & vbCrLf &
                                    "       UpdatedDate = GETDATE() " & vbCrLf &
                                    " WHERE TravelID = '" & TravelID & "'"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub InsertData()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertHeader()

                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
                                .InsertDetails()
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
            Throw
        End Try
    End Sub

    Public Sub UpdateData()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        UpdateHeader(TravelID)

                        Dim ObjTravelDetail As New TravelDetailModel
                        ObjTravelDetail.DeleteDetail(TravelID)

                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
                                .InsertDetails()
                            End With
                        Next

                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        MainModul.gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetRate(ByVal CuryID As String, Optional ByVal EffDate As Date = Nothing) As Double
        Try
            Dim dt As New DataTable
            Dim rate As Double = 1
            Dim now As Date = DateTime.Today
            Dim _EffDate As Date = IIf(EffDate = Nothing, now, EffDate)

            Dim SP_Name As String = "RateToRupiah"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@EffDate", SqlDbType.VarChar)
            pParam(0).Value = _EffDate
            pParam(1) = New SqlClient.SqlParameter("@CuryID", SqlDbType.VarChar)
            pParam(1).Value = CuryID

            dt = MainModul.GetDataTableByCommand_SP_Solomon(SP_Name, pParam)
            If dt.Rows.Count > 0 Then
                rate = Convert.ToDouble(dt.Rows(0).Item(1))
            End If

            Return rate
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function LoadReportTravel() As DataTable
        Try
            Dim dt As New DataTable

            Dim SP_Name As String = "Travel_Rpt_GetHeader"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@TravelID", SqlDbType.VarChar)
            pParam(0).Value = TravelID

            dt = MainModul.GetDataTableByCommand_SP_Solomon(SP_Name, pParam)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function LoadReportTravelDetail() As DataTable
        Try
            Dim dt As New DataTable

            Dim SP_Name As String = "Travel_Rpt_GetDetail"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@TravelID", SqlDbType.VarChar)
            pParam(0).Value = TravelID

            dt = MainModul.GetDataTableByCommand_SP_Solomon(SP_Name, pParam)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function DSReportTravelDetail() As DataSet
        Dim query As String
        query = " SELECT tv_detail.TravelSettleID , " &
                "         tv_detail.TravelID , " &
                "         tv_detail.AcctID AS Account , " &
                "         tv_detail.ID , " &
                "         tv_detail.Description AS DescriptionSett , " &
                "         tv_detail.CuryIDSett, " &
                "         tv_detail.RateSett , " &
                "         tv_detail.AmountSett, " &
                "         tv_detail.AmountIDRSett AS AmountIDRSett , " &
                "         ISNULL(pivot_table.IDR, 0) AS TotAmountIDR , " &
                "         ISNULL(pivot_table.USD, 0) AS TotAmountUSD , " &
                "         ISNULL(pivot_table.YEN, 0) AS TotAmountYEN " &
                " From dbo.TravelSettleDetail AS tv_detail " &
                "         Left Join( SELECT  TravelSettleID , " &
                "                             TravelID , " &
                "                             CASE WHEN ID IN ( 4, 6) THEN 7 " &
                "                                  ELSE ID " &
                "                             End ID , " &
                "                             CuryIDSett , " &
                "                             AmountSett " &
                "                     FROM    dbo.TravelSettleDetail " &
                "                   ) AS t PIVOT ( SUM(AmountSett) FOR CuryIDSett IN ( [IDR], " &
                "                                                               [USD], [YEN] ) ) AS pivot_table ON pivot_table.TravelID = tv_detail.TravelID " &
                "                                                               AND pivot_table.ID = tv_detail.ID " &
                "  WHERE  tv_detail.TravelID = " & QVal(TravelID) & ""

        Dim ds As New dsLaporan
        ds = GetDsReport_Solomon(query, "TravelDetailSett")
        Return ds

    End Function

    Public Sub UpdateHeaderApprove(ByVal TravelID As String)
        Try
            Dim ls_SP As String = " UPDATE  TravelHeader " & vbCrLf &
                                    " SET   Status = " & QVal(Status) & ", " & vbCrLf &
                                    "       UpdatedBy = " & QVal(gh_Common.Username) & ", " & vbCrLf &
                                    "       UpdatedDate = GETDATE() " & vbCrLf &
                                    " WHERE TravelID = '" & TravelID & "'"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class

Public Class TravelDetailModel
    Public Property TravelID As String
    Public Property AcctID As String
    Public Property SubAcct As String
    Public Property ID As Integer
    Public Property Seq As Integer
    Public Property Description As String
    Public Property CuryID As String
    Public Property Amount As Double
    Public Property Rate As String
    Public Property AmountIDR As Double
    Public Property TravelDetailID As Integer

    Public Sub InsertDetails()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO TravelDetail (TravelID,SubAcct,AcctID,ID,Description,Amount,CuryID,Rate,AmountIDR ) " & vbCrLf &
            "Values(" & QVal(TravelID) & ", " & vbCrLf &
            "       " & QVal(SubAcct) & ", " & vbCrLf &
            "       " & QVal(AcctID) & ", " & vbCrLf &
            "       " & QVal(ID) & ", " & vbCrLf &
            "       " & QVal(Description) & ", " & vbCrLf &
            "       " & QVal(Amount) & ", " & vbCrLf &
            "       " & QVal(CuryID) & ", " & vbCrLf &
            "       " & QVal(Rate) & ", " & vbCrLf &
            "       " & QVal(AmountIDR) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteDetail(_TravelID)
        Try
            Dim ls_SP As String = " DELETE  FROM TravelDetail
                                    WHERE   RTRIM(TravelID) = " & QVal(_TravelID.TrimEnd) & ""
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetSubAccountbyid() As DataTable
        Try
            Dim sql As String = "SELECT 
 	                                RTRIM(Consolsub) [SubAccount],
	                                RTRIM(Descr) Descritiption
                                FROM dbo.SubAcct WHERE Consolsub = " & QVal(SubAcct) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataDetailByID() As DataTable
        Try
            Dim sql As String = " SELECT  '' AS Date ,
                                            ID ,
                                            AcctID Account ,
                                            SubAcct SubAccount ,
                                            Description ,
                                            '' AS EntertainID ,
                                            Amount ,
                                            CuryID ,
                                            Rate ,
                                            AmountIDR ,
                                            'CASH' AS PaymentType ,
                                            '' AS NoRekening ,
                                            'IDR' AS CuryIDSett ,
                                            CONVERT(FLOAT, 1) AS RateSett ,
                                            CONVERT(FLOAT, 0) AS AmountSett ,
                                            CONVERT(FLOAT, 0) AS AmountIDRSett
                                    FROM    TempTravel "
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataDetailByIDTICKET() As DataTable
        Try
            Dim sql As String = "SELECT ID, CONVERT(varchar, getdate(), 105) as Tgl
      ,AcctID Account
      ,SubAcct SubAccount
      ,Description
      ,Amount
      ,CuryID
      ,Rate
      ,AmountIDR
  FROM TempTravel --where Description='TICKET' "

            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetDataDetailByIDTRANSPORTATION() As DataTable
        Try
            Dim sql As String = "SELECT ID, CONVERT(varchar, getdate(), 105) as Tgl
      ,AcctID Account
      ,SubAcct SubAccount
      ,Description
      ,Amount
      ,CuryID
      ,Rate
      ,AmountIDR
  FROM TempTravel where Description='TRANSPORTATION' "

            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetDataDetailByIDHOTEL() As DataTable
        Try
            Dim sql As String = "SELECT ID, CONVERT(varchar, getdate(), 105) as Tgl
      ,AcctID Account
      ,SubAcct SubAccount
      ,Description
      ,Amount
      ,CuryID
      ,Rate
      ,AmountIDR
  FROM TempTravel where Description='HOTEL' "

            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetDataDetailByIDENTERTAINMENT() As DataTable
        Try
            Dim sql As String = "SELECT ID, CONVERT(varchar, getdate(), 105) as Tgl
      ,AcctID Account
      ,SubAcct SubAccount
      ,Description
      ,Amount
      ,CuryID
      ,Rate
      ,AmountIDR
  FROM TempTravel where Description='ENTERTAINMENT' "

            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataDetailByIDOTHERS() As DataTable
        Try
            Dim sql As String = "SELECT ID, CONVERT(varchar, getdate(), 105) as Tgl
      ,AcctID Account
      ,SubAcct SubAccount
      ,Description
      ,Amount
      ,CuryID
      ,Rate
      ,AmountIDR
  FROM TempTravel where Description='OTHERS' "

            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetDataDetailByIDPOCKET() As DataTable
        Try
            Dim sql As String = "SELECT ID, CONVERT(varchar, getdate(), 105) as Tgl
      ,AcctID Account
      ,SubAcct SubAccount
      ,Description
      ,Amount
      ,CuryID
      ,Rate
      ,AmountIDR
  FROM TempTravel where Description='POCKET ALLOWANCE' "

            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetDataDetailByIDBTRIP() As DataTable
        Try
            Dim sql As String = "SELECT ID, CONVERT(varchar, getdate(), 105) as Tgl
      ,AcctID Account
      ,SubAcct SubAccount
      ,Description
      ,Amount
      ,CuryID
      ,Rate
      ,AmountIDR
  FROM TempTravel where Description='PREPARATION B-TRIP' "

            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataDetailByID2() As DataTable
        Try
            Dim dt As New DataTable

            Dim SP_Name As String = "Travel_Get_TravelDetail"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@TravelID", SqlDbType.VarChar)
            pParam(0).Value = TravelID

            dt = MainModul.GetDataTableByCommand_SP_Solomon(SP_Name, pParam)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataDetailStayingByID() As DataTable
        Try
            Dim sql As String = "SELECT 
                                   [Date]
                                  ,[Description]
                                  ,[CuryID]
                                  ,[Amount]
                                FROM TravelStaying WHERE TravelID = " & QVal(TravelID) & ""

            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetDataDetailSafetyByID() As DataTable
        Try
            Dim sql As String = "SELECT 
                                   [Date]
                                  ,[Description]
                                  ,[CuryID]
                                  ,[Amount]
                                FROM TravelSafetyMoney WHERE TravelID = " & QVal(TravelID) & ""

            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetDataDetailPocketByID() As DataTable
        Try
            Dim sql As String = "SELECT 
                                   [Date]
                                  ,[Description]
                                  ,[CuryID]
                                  ,[Amount]
                                FROM TravelPocket WHERE TravelID = " & QVal(TravelID) & ""

            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetDataDetailByIDEnt() As DataTable
        Try
            Dim sql As String = "SELECT 
 	                                RTRIM([SubAcct]) SubAccount,
                                    RTRIM([AcctID]) Account,
	                                RTRIM(Description) Description,
                                    Tgl,
                                    RTRIM(DeptID) DeptID,
                                    RTRIM(Nama) Nama,
                                    RTRIM(Tempat) Tempat,
                                    RTRIM(Alamat) Alamat,
                                    RTRIM(Jenis) Jenis,
                                    RTRIM(NoKwitansi) NoKwitansi,
                                    [Amount] Amount
                                FROM suspend_detail WHERE TravelID = " & QVal(TravelID) & ""

            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataDetailByID1Ent(_TravelID As String) As DataTable
        Try
            Dim sql As String = "SELECT GETDATE() as Tgl,
 	                                RTRIM([SubAcct]) SubAccount,
                                    RTRIM([AcctID]) Account,
	                                RTRIM(Description) Description,
                                    RTRIM([Amount]) Amount,
                                    0 ActualAmount 
                                FROM suspend_detail WHERE TravelID = " & QVal(_TravelID) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataDetailByIDtrial() As DataTable
        Try
            Dim sql As String = "SELECT 
 	                                RTRIM([SubAcct]) SubAccount,
                                    RTRIM([AcctID]) Account,
	                                RTRIM(Description) Description,
                                    [Amount] Amount
                                FROM suspend_detail WHERE TravelID = " & QVal(TravelID) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class

'Public Class TravelRequestModel
'    Public Property NoRequest As String
'    Public Property Tanggal As Date
'    Public Property DeptID As String
'    Public Property TravelType As String
'    Public Property NIK As String
'    Public Property Nama As String
'    Public Property Golongan As Integer
'    Public Property Purpose As String
'    Public Property Status As String
'    Public Property Approved As String
'    Public Property Comment As String

'    Public Property ObjRequestDetails() As New Collection(Of TravelRequestDetailModel)
'    Public Property ObjRequestCost() As New Collection(Of TravelRequestCostModel)

'    Public Function TravelRequestAutoNo() As String
'        Try
'            Dim query As String

'            query = " DECLARE @bulan VARCHAR(4) " &
'                    " DECLARE @tahun VARCHAR(4) " &
'                    " DECLARE @seq VARCHAR(4) " &
'                    " SET @bulan = LEFT(CONVERT(CHAR(20), GETDATE(), 101), 2) " &
'                    " SET @tahun = DATEPART(YEAR, GETDATE()) " &
'                    " SET @seq = ( SELECT RIGHT('0000' " &
'                    "                           + CAST(RIGHT(RTRIM(MAX(NoRequest)), 4) + 1 AS VARCHAR), " &
'                    "                           4) " &
'                    "              From dbo.TravelRequestHeader " &
'                    "              WHERE  SUBSTRING(NoRequest, 1, 7) = 'TR' + '-' + RIGHT(@tahun, 4) " &
'                    "                     And SUBSTRING(NoRequest, 9, 2) = RIGHT(@bulan, 2) " &
'                    "            ) " &
'                    " SELECT 'TR' + '-' + RIGHT(@tahun, 4) + '-' + @bulan + '-' + COALESCE(@seq, " &
'                    "                                                               '0001') "

'            Dim dt As DataTable = New DataTable
'            dt = GetDataTable_Solomon(query)
'            Return dt.Rows(0).Item(0).ToString

'        Catch ex As Exception
'            Throw

'        End Try
'    End Function

'    Public Function GetTravelRequest() As DataTable
'        Try
'            Dim aksesApproval As List(Of String)
'            aksesApproval = GetDept()
'            aksesApproval.Add("" & QVal(gh_Common.GroupID) & "")
'            Dim nilai = String.Join(",", aksesApproval.ToArray)

'            Dim sql As String = "SELECT  NoRequest ,
'                                        NIK ,
'                                        Nama ,
'                                        Date ,
'                                        DeptID ,
'                                        TravelType ,
'                                        Golongan ,
'                                        Purpose ,
'                                        Status ,
'                                        Approved ,
'                                        Comment
'                                FROM    dbo.TravelRequestHeader
'                                WHERE   Status IN ('PENDING', 'OPEN')
'                                        AND DeptID IN (" & nilai & ") "
'            Dim dt As New DataTable
'            dt = GetDataTable_Solomon(sql)
'            Return dt
'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Function

'    Public Function GetTravelApproved() As DataTable
'        Try
'            Dim dt As New DataTable
'            Dim nilai = String.Join(",", GetDept.ToArray)

'            Dim level As Integer = GetUsernameLevel()

'            If level = 3 Then
'                Dim sql As String
'                sql = " SELECT  NoRequest ,
'                                NIK ,
'                                Nama ,
'                                Date ,
'                                DeptID ,
'                                TravelType ,
'                                Golongan ,
'                                Purpose ,
'                                Approved ,
'                                Comment
'                        FROM    dbo.TravelRequestHeader
'                        WHERE   Status = 'PENDING'
'                                AND ( Approved = ''
'                                  OR Approved IS NULL
'                                )
'                                AND DeptID IN (" & nilai & ") "

'                dt = GetDataTable_Solomon(sql)
'            End If

'            Return dt
'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Function

'    Public Function GetTravelRequestAll() As DataTable
'        Try
'            Dim aksesApproval As List(Of String)
'            aksesApproval = GetDept()
'            aksesApproval.Add("" & QVal(gh_Common.GroupID) & "")
'            Dim nilai = String.Join(",", aksesApproval.ToArray)

'            Dim sql As String = "SELECT  NoRequest ,
'                                        NIK ,
'                                        Nama ,
'                                        Date ,
'                                        DeptID ,
'                                        TravelType ,
'                                        Golongan ,
'                                        Purpose ,
'                                        Status ,
'                                        Approved ,
'                                        Comment
'                                FROM    dbo.TravelRequestHeader
'                                WHERE   DeptID IN (" & nilai & ") "
'            Dim dt As New DataTable
'            dt = GetDataTable_Solomon(sql)
'            Return dt
'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Function

'    Public Function GetDept() As List(Of String)
'        Try
'            Dim result As New List(Of String)

'            Dim dt As New DataTable
'            Dim sql As String
'            sql = " SELECT  '''' + RTRIM(a.DeptID) + '''' DeptID
'                    FROM    S_User u
'                            INNER JOIN akses_approval a ON u.Username = a.Username
'                    WHERE   a.Username = " & QVal(gh_Common.Username) & " "
'            dt = GetDataTable(sql)
'            For Each row As DataRow In dt.Rows
'                result.Add(row("DeptID"))
'            Next
'            Return result
'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Function

'    Public Function GetUsernameLevel() As Integer
'        Dim result As Integer = 0
'        Try
'            Dim dt As New DataTable
'            Dim sql As String =
'            "SELECT top 1 Kol
'            FROM akses_approval where Username = " & QVal(gh_Common.Username) & ""
'            dt = GetDataTable(sql)
'            result = Convert.ToInt32(dt.Rows(0)(0))
'            Return result
'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Function

'    Public Function GetRequestHeaderByID(ByVal _NoReq As String) As DataTable
'        Try
'            Dim sql As String = "SELECT  NoRequest ,
'                                        NIK ,
'                                        Nama ,
'                                        Date ,
'                                        DeptID ,
'                                        TravelType ,
'                                        Golongan ,
'                                        Purpose ,
'                                        Status ,
'		                                Approved ,
'		                                Comment                                        
'                                FROM    dbo.TravelRequestHeader
'                                WHERE   NoRequest = " & QVal(_NoReq) & ""
'            Dim dt As New DataTable
'            dt = GetDataTable_Solomon(sql)
'            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
'                With dt.Rows(0)
'                    Me.NoRequest = Trim(.Item("NoRequest") & "")
'                    Me.NIK = Trim(.Item("NIK") & "")
'                    Me.Nama = Trim(.Item("Nama") & "")
'                    Me.Tanggal = Trim(.Item("Date") & "")
'                    Me.DeptID = Trim(.Item("DeptID") & "")
'                    Me.TravelType = Trim(.Item("TravelType") & "")
'                    Me.Golongan = Trim(.Item("Golongan") & "")
'                    Me.Purpose = Trim(.Item("Purpose") & "")
'                    Me.Status = Trim(.Item("Status") & "")
'                    Me.Approved = Trim(.Item("Approved") & "")
'                    Me.Comment = Trim(.Item("Comment") & "")
'                End With
'            End If
'            Return dt
'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Function

'    Public Function GetListGolongan() As DataTable
'        Try
'            Dim sql As String = "SELECT DISTINCT
'                                        Golongan
'                                FROM    dbo.TravelPocketAllowance"
'            Dim dt As New DataTable
'            dt = GetDataTable_Solomon(sql)
'            Return dt
'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Function

'    Public Function GetListNegara(ByVal _travelType As String) As DataTable
'        Try
'            Dim sql As String = "SELECT  NamaNegara
'                                 FROM    dbo.TravelNegara                                 
'                                 WHERE   TravelType = " & QVal(_travelType) & ""
'            Dim dt As New DataTable
'            dt = GetDataTable_Solomon(sql)
'            Return dt
'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Function

'    Public Sub InsertData()
'        Try
'            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
'                Conn1.Open()
'                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
'                    gh_Trans = New InstanceVariables.TransactionHelper
'                    gh_Trans.Command.Connection = Conn1
'                    gh_Trans.Command.Transaction = Trans1

'                    Try
'                        InsertHeader()

'                        For i As Integer = 0 To ObjRequestDetails.Count - 1
'                            With ObjRequestDetails(i)
'                                .InsertDetails()
'                            End With
'                        Next

'                        For i As Integer = 0 To ObjRequestCost.Count - 1
'                            With ObjRequestCost(i)
'                                .InsertCost()
'                            End With
'                        Next

'                        Trans1.Commit()
'                    Catch ex As Exception
'                        Trans1.Rollback()
'                        Throw
'                    Finally
'                        gh_Trans = Nothing
'                    End Try
'                End Using
'            End Using
'        Catch ex As Exception
'            Throw
'        End Try
'    End Sub

'    Public Sub InsertHeader()
'        Try
'            Dim dt As New DataTable

'            Dim SP_Name As String = "Travel_Insert_TravelRequestHeader"

'            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(9) {}
'            pParam(0) = New SqlClient.SqlParameter("@NoRequest", SqlDbType.VarChar)
'            pParam(0).Value = NoRequest
'            pParam(1) = New SqlClient.SqlParameter("@NIK", SqlDbType.VarChar)
'            pParam(1).Value = NIK
'            pParam(2) = New SqlClient.SqlParameter("@Nama", SqlDbType.VarChar)
'            pParam(2).Value = Nama
'            pParam(3) = New SqlClient.SqlParameter("@Tanggal", SqlDbType.Date)
'            pParam(3).Value = Date.Today
'            pParam(4) = New SqlClient.SqlParameter("@DeptID", SqlDbType.VarChar)
'            pParam(4).Value = DeptID
'            pParam(5) = New SqlClient.SqlParameter("@TravelType", SqlDbType.VarChar)
'            pParam(5).Value = TravelType
'            pParam(6) = New SqlClient.SqlParameter("@Golongan", SqlDbType.Int)
'            pParam(6).Value = Golongan
'            pParam(7) = New SqlClient.SqlParameter("@Purpose", SqlDbType.VarChar)
'            pParam(7).Value = Purpose
'            pParam(8) = New SqlClient.SqlParameter("@Status", SqlDbType.VarChar)
'            pParam(8).Value = Status
'            pParam(9) = New SqlClient.SqlParameter("@Username", SqlDbType.VarChar)
'            pParam(9).Value = gh_Common.Username

'            MainModul.GetDataTableByCommand_SP_Solomon(SP_Name, pParam)

'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Sub

'    Public Sub UpdateData()
'        Try
'            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
'                Conn1.Open()
'                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
'                    gh_Trans = New InstanceVariables.TransactionHelper
'                    gh_Trans.Command.Connection = Conn1
'                    gh_Trans.Command.Transaction = Trans1

'                    Try
'                        UpdateHeader(NoRequest)

'                        Dim ObjRequestDetail As New TravelRequestDetailModel
'                        ObjRequestDetail.DeleteDetail(NoRequest)

'                        For i As Integer = 0 To ObjRequestDetails.Count - 1
'                            With ObjRequestDetails(i)
'                                .InsertDetails()
'                            End With
'                        Next

'                        Dim _ObjRequestCost As New TravelRequestCostModel
'                        _ObjRequestCost.DeleteCost(NoRequest)

'                        For i As Integer = 0 To ObjRequestCost.Count - 1
'                            With ObjRequestCost(i)
'                                .InsertCost()
'                            End With
'                        Next

'                        Trans1.Commit()
'                    Catch ex As Exception
'                        Trans1.Rollback()
'                        Throw
'                    Finally
'                        gh_Trans = Nothing
'                    End Try
'                End Using
'            End Using
'        Catch ex As Exception
'            Throw
'        End Try
'    End Sub

'    Public Sub UpdateHeader(ByVal _NoRequest As String)
'        Try
'            Dim query As String
'            query = " UPDATE  dbo.TravelRequestHeader " & vbCrLf &
'                    " SET     NIK = " & QVal(NIK) & " , " & vbCrLf &
'                    "         Nama = " & QVal(Nama) & " , " & vbCrLf &
'                    "         TravelType = " & QVal(TravelType) & " , " & vbCrLf &
'                    "         Golongan = " & QVal(Golongan) & " , " & vbCrLf &
'                    "         Purpose = " & QVal(Purpose) & " , " & vbCrLf &
'                    "         Status = " & QVal(Status) & " , " & vbCrLf &
'                    "         Approved = " & QVal(Approved) & " , " & vbCrLf &
'                    "         Comment = " & QVal(Comment) & " , " & vbCrLf &
'                    "         UpdatedBy = " & QVal(gh_Common.Username) & " , " & vbCrLf &
'                    "         UpdatedDate = GETDATE() " & vbCrLf &
'                    " WHERE   NoRequest = " & QVal(_NoRequest) & " "
'            ExecQuery_Solomon(query)
'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Sub

'    Public Sub UpdateStatusHeader(ByVal _NoRequest As String)
'        Try
'            Dim query As String
'            query = " UPDATE  dbo.TravelRequestHeader " & vbCrLf &
'                    " SET     Approved = " & QVal(Approved) & " , " & vbCrLf &
'                    "         Comment = " & QVal(Comment) & " , " & vbCrLf &
'                    "         UpdatedBy = " & QVal(gh_Common.Username) & " , " & vbCrLf &
'                    "         UpdatedDate = GETDATE() " & vbCrLf &
'                    " WHERE   NoRequest = " & QVal(_NoRequest) & " "
'            ExecQuery_Solomon(query)
'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Sub

'    Public Sub Delete()
'        Try
'            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
'                Conn1.Open()
'                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
'                    gh_Trans = New InstanceVariables.TransactionHelper
'                    gh_Trans.Command.Connection = Conn1
'                    gh_Trans.Command.Transaction = Trans1
'                    Dim query As String
'                    Try
'                        query = " DELETE  FROM dbo.TravelRequestHeader " & vbCrLf &
'                                " WHERE   NoRequest = " & QVal(Me.NoRequest) & " "
'                        MainModul.ExecQuery_Solomon(query)

'                        query = " DELETE  FROM dbo.TravelRequestDetail " & vbCrLf &
'                                " WHERE   NoRequest = " & QVal(Me.NoRequest) & " "
'                        MainModul.ExecQuery_Solomon(query)

'                        query = " DELETE  FROM dbo.TravelRequestCost " & vbCrLf &
'                                " WHERE   NoRequest = " & QVal(Me.NoRequest) & " "
'                        MainModul.ExecQuery_Solomon(query)

'                        Trans1.Commit()
'                    Catch ex As Exception
'                        Trans1.Rollback()
'                        Throw
'                    Finally
'                        gh_Trans = Nothing
'                    End Try
'                End Using
'            End Using
'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Sub

'    Public Function GetPocketAllowance(ByVal TravelType__ As String, ByVal Golongan__ As Integer) As DataTable
'        Try
'            Dim sql As String = " SELECT  CuryID ,
'                                        CASE WHEN CuryID = 'IDR' THEN Amount
'                                                ELSE 0
'                                        END AdvanceIDR ,
'                                        CASE WHEN CuryID = 'USD' THEN Amount
'                                                ELSE 0
'                                        END AdvanceUSD ,
'                                        CASE WHEN CuryID = 'YEN' THEN Amount
'                                                ELSE 0
'                                        END AdvanceUSD ,
'                                        FirstTravel
'                                FROM    dbo.TravelPocketAllowance
'                                WHERE   TravelType = " & QVal(TravelType__) & "
'                                        AND Golongan = " & QVal(Golongan__) & ""
'            Dim dt As New DataTable
'            dt = GetDataTable_Solomon(sql)
'            Return dt
'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Function

'    Public Function GetFirstTravel(ByVal nik As String, ByVal traveltype As String, ByVal tahun As String) As Boolean
'        Try
'            Dim sql As String
'            sql = " IF " & QVal(traveltype) & " = 'DN'
'                        BEGIN
'                            SELECT  CAST(0 AS BIT) AS FirstTravel;
'                        END
'                     ELSE
'                        BEGIN
'                            SELECT  CASE WHEN EXISTS ( SELECT   trh.NoRequest
'                                                       FROM     dbo.TravelRequestHeader AS trh
'                                                                INNER JOIN dbo.TravelRequestDetail trd ON trd.NoRequest = trh.NoRequest
'                                                       WHERE    trh.NIK = " & QVal(nik) & "
'                                                                AND trh.TravelType = " & QVal(traveltype) & "
'                                                       GROUP BY trh.NoRequest
'                                                       HAVING   YEAR(MIN(trd.DepartureDate)) = " & QVal(tahun) & " )
'                                         THEN CAST(0 AS BIT)
'                                         ELSE CAST(1 AS BIT)
'                                    END FirstTravel
'                        END "
'            Dim value As Boolean
'            Dim dt As New DataTable
'            dt = GetDataTable_Solomon(sql)
'            If dt.Rows.Count > 0 Then
'                value = dt.Rows(0).Item(0)
'            End If
'            Return value
'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Function

'End Class

'Public Class TravelRequestDetailModel
'    Public Property NoRequest As String
'    Public Property Seq As Integer
'    Public Property Negara As String
'    Public Property NoPaspor As String
'    Public Property Visa As String
'    Public Property Destination As String
'    Public Property DepartureDate As Date
'    Public Property ArrivalDate As Date

'    Public Function GetDetailByID() As DataTable
'        Try
'            Dim sql As String = " SELECT  Destination ,
'                                        Negara ,
'                                        DepartureDate ,
'                                        NoPaspor ,
'                                        Visa ,
'                                        ArrivalDate
'                                FROM    dbo.TravelRequestDetail
'                                WHERE   NoRequest = " & QVal(NoRequest) & ""
'            Dim dt As New DataTable
'            dt = GetDataTable_Solomon(sql)
'            Return dt
'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Function

'    Public Function GetVisa(ByVal nik As String, negara As String, deptDate As Date, ArrivDate As Date) As String
'        Try
'            Dim hasil As String = String.Empty
'            Dim sql As String = "SELECT  CASE WHEN COUNT(NIK) > 0 THEN 'YES'
'                                                ELSE 'NO'
'                                        END Visa
'                                FROM    dbo.TravelerVisa
'                                WHERE   NIK = " & QVal(nik) & "
'                                        AND Negara = " & QVal(negara) & ""

'            Dim dt As New DataTable
'            dt = GetDataTable_Solomon(sql)
'            If dt.Rows.Count > 0 Then
'                hasil = dt.Rows(0).Item(0).ToString()
'            End If
'            Return hasil
'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Function

'    Public Function GetPaspor(ByVal nik As String, deptDate As Date, ArrivDate As Date) As String
'        Try
'            Dim hasil As String = String.Empty
'            Dim sql As String = " SELECT  NoPaspor
'                                  FROM    dbo.TravelerPaspor
'                                  WHERE   NIK = " & QVal(nik) & "
'                                          AND ExpiredDate >= CAST(" & QVal(ArrivDate) & " AS DATE) "

'            Dim dt As New DataTable
'            dt = GetDataTable_Solomon(sql)
'            If dt.Rows.Count > 0 Then
'                hasil = dt.Rows(0).Item(0).ToString()
'            End If
'            Return hasil
'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Function

'    Public Sub InsertDetails()
'        Try
'            Dim ls_SP As String
'            ls_SP = " INSERT INTO [dbo].[TravelRequestDetail] " & vbCrLf &
'                    "            ([NoRequest] " & vbCrLf &
'                    "            ,[Seq] " & vbCrLf &
'                    "            ,[Destination] " & vbCrLf &
'                    "            ,[Negara] " & vbCrLf &
'                    "            ,[Visa] " & vbCrLf &
'                    "            ,[DepartureDate] " & vbCrLf &
'                    "            ,[ArrivalDate]) " & vbCrLf &
'                    "      VALUES " & vbCrLf &
'                    "            (" & QVal(NoRequest) & ", " & vbCrLf &
'                    "            " & QVal(Seq) & ", " & vbCrLf &
'                    "            " & QVal(Destination) & ", " & vbCrLf &
'                    "            " & QVal(Negara) & ", " & vbCrLf &
'                    "            " & QVal(Visa) & ", " & vbCrLf &
'                    "            " & QVal(DepartureDate) & ", " & vbCrLf &
'                    "            " & QVal(ArrivalDate) & ")"

'            ExecQuery_Solomon(ls_SP)
'        Catch ex As Exception
'            Throw
'        End Try
'    End Sub

'    Public Sub DeleteDetail(ByVal _NoRequest As String)
'        Try
'            Dim ls_SP As String = " DELETE  FROM dbo.TravelRequestDetail
'                                    WHERE   NoRequest = " & QVal(_NoRequest.TrimEnd) & ""
'            ExecQuery_Solomon(ls_SP)
'        Catch ex As Exception
'            Throw
'        End Try
'    End Sub

'End Class

'Public Class TravelRequestCostModel
'    Public Property NoRequest As String
'    Public Property Description As String
'    Public Property CostType As String
'    Public Property Days As Integer
'    Public Property AdvanceIDR As String
'    Public Property AdvanceUSD As Double
'    Public Property AdvanceYEN As Double

'    Public Function GetCostByID() As DataTable
'        Try
'            Dim sql As String = " SELECT  NoRequest ,
'                                            CostType ,
'                                            Description ,
'                                            Days ,
'                                            AdvanceIDR ,
'                                            AdvanceUSD ,
'                                            AdvanceYEN
'                                    FROM    dbo.TravelRequestCost
'                                    WHERE   NoRequest = " & QVal(NoRequest) & " "
'            Dim dt As New DataTable
'            dt = GetDataTable_Solomon(sql)
'            Return dt
'        Catch ex As Exception
'            Throw ex
'        End Try
'    End Function

'    Public Sub InsertCost()
'        Try
'            Dim ls_SP As String
'            ls_SP = " INSERT  INTO dbo.TravelRequestCost " & vbCrLf &
'                    "         ( NoRequest , " & vbCrLf &
'                    "           CostType , " & vbCrLf &
'                    "           Description , " & vbCrLf &
'                    "           Days , " & vbCrLf &
'                    "           AdvanceIDR , " & vbCrLf &
'                    "           AdvanceUSD , " & vbCrLf &
'                    "           AdvanceYEN " & vbCrLf &
'                    "         ) " & vbCrLf &
'                    " VALUES( " & QVal(NoRequest) & " ,  " & vbCrLf &
'                    "           " & QVal(CostType) & " ,  " & vbCrLf &
'                    "           " & QVal(Description) & " ,  " & vbCrLf &
'                    "           " & QVal(Days) & " ,  " & vbCrLf &
'                    "           " & QVal(AdvanceIDR) & " ,  " & vbCrLf &
'                    "           " & QVal(AdvanceUSD) & " ,  " & vbCrLf &
'                    "           " & QVal(AdvanceYEN) & "   " & vbCrLf &
'                    "         ) "
'            ExecQuery_Solomon(ls_SP)
'        Catch ex As Exception
'            Throw
'        End Try
'    End Sub

'    Public Sub DeleteCost(ByVal _NoRequest As String)
'        Try
'            Dim ls_SP As String = " DELETE  FROM dbo.TravelRequestCost
'                                    WHERE   NoRequest = " & QVal(_NoRequest.TrimEnd) & ""
'            ExecQuery_Solomon(ls_SP)
'        Catch ex As Exception
'            Throw
'        End Try
'    End Sub

'End Class