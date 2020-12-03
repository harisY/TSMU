﻿Imports System.Collections.ObjectModel

Public Class TravelSettleHeaderModel
    Dim clsGlobal As GlobalService
    Dim clsTravelEntertain As TravelEntertainModel
    Public Property TravelSettleID As String
    Public Property DateHeader As Date
    Public Property NoPR As String
    Public Property DeptID As String
    Public Property Nama As String
    Public Property Destination As String
    Public Property Purpose As String
    Public Property TravelType As String
    Public Property DepartureDate As Date
    Public Property ArrivalDate As Date
    Public Property Term As String
    Public Property PickUp As String
    Public Property Visa As String
    Public Property RateSalomonUSD As Double
    Public Property RateSalomonYEN As Double
    Public Property RateUSD As Double
    Public Property RateYEN As Double
    Public Property TotalAdvanceIDR As Double
    Public Property TotalAdvanceUSD As Double
    Public Property TotalAdvanceYEN As Double
    Public Property TotalReturnIDR As Double
    Public Property TotalReturnUSD As Double
    Public Property TotalReturnYEN As Double
    Public Property Status As String

    Public Property ObjSettleDetail() As New Collection(Of TravelSettleDetailModel)
    Public Property ObjSettleCost() As New Collection(Of TravelSettleCostModel)

    Dim strQuery As String

    Public Function TravelSettAutoNo() As String
        Try
            Dim query As String

            query = " DECLARE @bulan VARCHAR(4) " &
                    " DECLARE @tahun VARCHAR(4) " &
                    " DECLARE @seq VARCHAR(4) " &
                    " SET @bulan = LEFT(CONVERT(CHAR(20), GETDATE(), 101), 2) " &
                    " SET @tahun = DATEPART(YEAR, GETDATE()) " &
                    " SET @seq = ( SELECT RIGHT('0000' " &
                    "                             + CAST(RIGHT(RTRIM(MAX(TravelSettleID)), 4) + 1 AS VARCHAR), " &
                    "                             4) " &
                    "                 From dbo.TravelSettleHeader " &
                    "                 WHERE  SUBSTRING(TravelSettleID, 1, 7) = 'TS' + '-' + RIGHT(@tahun, 4) " &
                    "                     And SUBSTRING(TravelSettleID, 9, 2) = RIGHT(@bulan, 2) " &
                    "             ) " &
                    " SELECT 'TS' + '-' + RIGHT(@tahun, 4) + '-' + @bulan + '-' + COALESCE(@seq, " &
                    "                                                               '0001') "

            Dim dt As DataTable = New DataTable
            dt = GetDataTable(query)
            Return dt.Rows(0).Item(0).ToString

        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function GetDataGridRequest() As DataTable
        Try
            Dim dt As New DataTable
            strQuery = "SELECT  DISTINCT
                                ttd.NoVoucher ,
                                trh.NoRequest ,
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
                        FROM    dbo.TravelTicketDetail AS ttd
                                LEFT JOIN dbo.TravelRequestHeader AS trh ON trh.NoRequest = ttd.NoRequest
                                LEFT JOIN ( SELECT  NoRequest ,
                                                    MIN(DepartureDate) AS DepartureDate ,
                                                    MAX(ArrivalDate) AS ArrivalDate ,
                                                    CASE WHEN dbo.FormatDateTime(MIN(DepartureDate),
                                                                                 'MMyyyy') = dbo.FormatDateTime(MAX(ArrivalDate),
                                                                                      'MMyyyy')
                                                         THEN dbo.FormatDateTime(MIN(DepartureDate),
                                                                                 'dd') + ' - '
                                                              + dbo.FormatDateTime(MAX(ArrivalDate),
                                                                                   'dd MMMM yyyy')
                                                         ELSE dbo.FormatDateTime(MIN(DepartureDate),
                                                                                 'dd MMMM yyyy')
                                                              + ' - '
                                                              + dbo.FormatDateTime(MAX(ArrivalDate),
                                                                                   'dd MMMM yyyy')
                                                    END AS Term
                                            FROM    dbo.TravelRequestDetail
                                            GROUP BY NoRequest
                                          ) AS trd ON trd.NoRequest = trh.NoRequest
                                LEFT JOIN dbo.TravelRequestCost AS trc ON trc.NoRequest = trh.NoRequest
                        WHERE   Status = 'OPEN'
                                AND trc.CostType = 'C03' "
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetTravelSettHeader(dateFrom As Date, dateTo As Date) As DataTable
        Try
            Dim dt As New DataTable
            strQuery = "SELECT  TravelSettleID ,
                                Date ,
                                NoPR ,
                                DeptID ,
                                Nama ,
                                Destination ,
                                Purpose ,
                                Term ,
                                Pay
                        FROM    dbo.TravelSettleHeader
                        WHERE   ( [Date] >= " & QVal(dateFrom) & "
                                  AND [Date] <= " & QVal(dateTo) & "
                                )"
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CheckSettleAccrued(ByVal NoTransaksi As String) As Boolean
        Try
            Dim dt As New DataTable
            strQuery = "SELECT  CAST(COUNT(NoAccrued) AS BIT)
                        FROM    dbo.T_CCAccrued
                        WHERE   NoTransaksi = " & QVal(NoTransaksi) & ""
            dt = GetDataTable(strQuery)

            Dim validasi As Boolean
            validasi = dt.Rows(0).Item(0)

            Return validasi
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub GetTravelSettHeaderByID()
        Try
            strQuery = " SELECT  TravelSettleID ,
                                Date ,
                                NoPR ,
                                DeptID ,
                                Nama ,
                                Purpose ,
                                Destination ,
                                TravelType ,
                                DepartureDate ,
                                ArrivalDate ,
                                Term ,
                                PickUp ,
                                Visa ,
                                RateSalomonUSD ,
                                RateSalomonYEN ,
                                RateUSD ,
                                RateYEN ,
                                TotalAdvanceIDR ,
                                TotalAdvanceUSD ,
                                TotalAdvanceYEN ,
                                TotalReturnIDR ,
                                TotalReturnUSD ,
                                TotalReturnYEN
                        FROM    dbo.TravelSettleHeader
                        WHERE   TravelSettleID = " & QVal(TravelSettleID) & " "
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            If dt.Rows.Count > 0 Then
                DateHeader = If(IsDBNull(dt.Rows(0).Item("Date")), DateTime.Today, Convert.ToDateTime(dt.Rows(0).Item("Date")))
                NoPR = If(IsDBNull(dt.Rows(0).Item("NoPR")), "", Trim(dt.Rows(0).Item("NoPR").ToString()))
                DeptID = If(IsDBNull(dt.Rows(0).Item("DeptID")), "", Trim(dt.Rows(0).Item("DeptID").ToString()))
                Nama = If(IsDBNull(dt.Rows(0).Item("Nama")), "", Trim(dt.Rows(0).Item("Nama").ToString()))
                Purpose = If(IsDBNull(dt.Rows(0).Item("Purpose")), "", dt.Rows(0).Item("Purpose").ToString())
                Destination = If(IsDBNull(dt.Rows(0).Item("Destination")), "", Trim(dt.Rows(0).Item("Destination").ToString()))
                TravelType = If(IsDBNull(dt.Rows(0).Item("TravelType")), "", Trim(dt.Rows(0).Item("TravelType").ToString()))
                DepartureDate = If(IsDBNull(dt.Rows(0).Item("DepartureDate")), Nothing, Convert.ToDateTime(dt.Rows(0).Item("DepartureDate")))
                ArrivalDate = If(IsDBNull(dt.Rows(0).Item("ArrivalDate")), Nothing.Today, Convert.ToDateTime(dt.Rows(0).Item("ArrivalDate")))
                Term = If(IsDBNull(dt.Rows(0).Item("Term")), "", Trim(dt.Rows(0).Item("Term").ToString()))
                PickUp = If(IsDBNull(dt.Rows(0).Item("PickUp")), "", Trim(dt.Rows(0).Item("PickUp").ToString()))
                Visa = If(IsDBNull(dt.Rows(0).Item("Visa")), "", Trim(dt.Rows(0).Item("Visa").ToString()))
                RateSalomonUSD = If(IsDBNull(dt.Rows(0).Item("RateSalomonUSD")), 0, Convert.ToDouble(dt.Rows(0).Item("RateSalomonUSD")))
                RateSalomonYEN = If(IsDBNull(dt.Rows(0).Item("RateSalomonYEN")), 0, Convert.ToDouble(dt.Rows(0).Item("RateSalomonYEN")))
                RateUSD = If(IsDBNull(dt.Rows(0).Item("RateUSD")), 0, Convert.ToDouble(dt.Rows(0).Item("RateUSD")))
                RateYEN = If(IsDBNull(dt.Rows(0).Item("RateYEN")), 0, Convert.ToDouble(dt.Rows(0).Item("RateYEN")))
                TotalAdvanceIDR = If(IsDBNull(dt.Rows(0).Item("TotalAdvanceIDR")), 0, Convert.ToDouble(dt.Rows(0).Item("TotalAdvanceIDR")))
                TotalAdvanceUSD = If(IsDBNull(dt.Rows(0).Item("TotalAdvanceUSD")), 0, Convert.ToDouble(dt.Rows(0).Item("TotalAdvanceUSD")))
                TotalAdvanceYEN = If(IsDBNull(dt.Rows(0).Item("TotalAdvanceYEN")), 0, Convert.ToDouble(dt.Rows(0).Item("TotalAdvanceYEN")))
                TotalReturnIDR = If(IsDBNull(dt.Rows(0).Item("TotalAdvanceIDR")), 0, Convert.ToDouble(dt.Rows(0).Item("TotalReturnIDR")))
                TotalReturnUSD = If(IsDBNull(dt.Rows(0).Item("TotalAdvanceUSD")), 0, Convert.ToDouble(dt.Rows(0).Item("TotalReturnUSD")))
                TotalReturnYEN = If(IsDBNull(dt.Rows(0).Item("TotalAdvanceYEN")), 0, Convert.ToDouble(dt.Rows(0).Item("TotalReturnYEN")))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub InsertDataTravelSettle(frm As Form, dtHeader As DataTable, dtDetail As DataTable, dtRelasi As DataTable)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertSettleHeader()

                        For i As Integer = 0 To ObjSettleDetail.Count - 1
                            With ObjSettleDetail(i)
                                .InsertSettleDetail()
                                .UpdateRequest("CLOSE")
                            End With
                        Next

                        For i As Integer = 0 To ObjSettleCost.Count - 1
                            If ObjSettleCost(i).ID = 4 Then
                                Dim entertainID As String
                                clsTravelEntertain = New TravelEntertainModel
                                entertainID = clsTravelEntertain.InsertEntertainData(dtHeader, dtDetail, dtRelasi, ObjSettleCost(i).EntertainIDTemp)
                                ObjSettleCost(i).EntertainID = entertainID
                            End If
                            With ObjSettleCost(i)
                                .InsertSettleCost()
                            End With
                        Next

                        clsGlobal = New GlobalService
                        clsGlobal.UpdateAutoNumber(frm)

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

    Public Sub InsertSettleHeader()
        Try
            Dim dt As New DataTable

            Dim SP_Name As String = "Travel_Insert_TravelSettleHeader"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(23) {}
            pParam(0) = New SqlClient.SqlParameter("@TravelSettleID", SqlDbType.VarChar)
            pParam(0).Value = TravelSettleID
            pParam(1) = New SqlClient.SqlParameter("@DateHeader", SqlDbType.Date)
            pParam(1).Value = DateHeader
            pParam(2) = New SqlClient.SqlParameter("@NoPR", SqlDbType.VarChar)
            pParam(2).Value = NoPR
            pParam(3) = New SqlClient.SqlParameter("@DeptID", SqlDbType.VarChar)
            pParam(3).Value = DeptID
            pParam(4) = New SqlClient.SqlParameter("@Nama", SqlDbType.VarChar)
            pParam(4).Value = Nama
            pParam(5) = New SqlClient.SqlParameter("@Destination", SqlDbType.VarChar)
            pParam(5).Value = Destination
            pParam(6) = New SqlClient.SqlParameter("@Purpose", SqlDbType.VarChar)
            pParam(6).Value = Purpose
            pParam(7) = New SqlClient.SqlParameter("@TravelType", SqlDbType.VarChar)
            pParam(7).Value = TravelType
            pParam(8) = New SqlClient.SqlParameter("@DepartureDate", SqlDbType.Date)
            pParam(8).Value = DepartureDate
            pParam(9) = New SqlClient.SqlParameter("@ArrivalDate", SqlDbType.Date)
            pParam(9).Value = ArrivalDate
            pParam(10) = New SqlClient.SqlParameter("@Term", SqlDbType.VarChar)
            pParam(10).Value = Term
            pParam(11) = New SqlClient.SqlParameter("@PickUp", SqlDbType.VarChar)
            pParam(11).Value = PickUp
            pParam(12) = New SqlClient.SqlParameter("@Visa", SqlDbType.VarChar)
            pParam(12).Value = Visa
            pParam(13) = New SqlClient.SqlParameter("@RateSalomonUSD", SqlDbType.Float)
            pParam(13).Value = RateSalomonUSD
            pParam(14) = New SqlClient.SqlParameter("@RateSalomonYEN", SqlDbType.Float)
            pParam(14).Value = RateSalomonYEN
            pParam(15) = New SqlClient.SqlParameter("@RateUSD", SqlDbType.Float)
            pParam(15).Value = RateUSD
            pParam(16) = New SqlClient.SqlParameter("@RateYEN", SqlDbType.Float)
            pParam(16).Value = RateYEN
            pParam(17) = New SqlClient.SqlParameter("@TotalAdvanceIDR", SqlDbType.Float)
            pParam(17).Value = TotalAdvanceIDR
            pParam(18) = New SqlClient.SqlParameter("@TotalAdvanceUSD", SqlDbType.Float)
            pParam(18).Value = TotalAdvanceUSD
            pParam(19) = New SqlClient.SqlParameter("@TotalAdvanceYEN", SqlDbType.Float)
            pParam(19).Value = TotalAdvanceYEN
            pParam(20) = New SqlClient.SqlParameter("@TotalReturnIDR", SqlDbType.Float)
            pParam(20).Value = TotalReturnIDR
            pParam(21) = New SqlClient.SqlParameter("@TotalReturnUSD", SqlDbType.Float)
            pParam(21).Value = TotalReturnUSD
            pParam(22) = New SqlClient.SqlParameter("@TotalReturnYEN", SqlDbType.Float)
            pParam(22).Value = TotalReturnYEN
            pParam(23) = New SqlClient.SqlParameter("@Username", SqlDbType.VarChar)
            pParam(23).Value = gh_Common.Username

            ExecQueryByCommand_SP(SP_Name, pParam)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateDataTravelSettle(dtHeader As DataTable, dtDetail As DataTable, dtRelasi As DataTable, listDelete As List(Of String))
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        UpdateSettleHeader()

                        Dim cls_SettleDetail As New TravelSettleDetailModel
                        cls_SettleDetail.DeleteSettleDetail(TravelSettleID)
                        For i As Integer = 0 To ObjSettleDetail.Count - 1
                            With ObjSettleDetail(i)
                                .InsertSettleDetail()
                            End With
                        Next

                        Dim cls_SettleCost As New TravelSettleCostModel
                        cls_SettleCost.DeleteSettleCost(TravelSettleID)

                        For i As Integer = 0 To ObjSettleCost.Count - 1
                            If ObjSettleCost(i).ID = 4 Then
                                Dim entertainID As String
                                clsTravelEntertain = New TravelEntertainModel
                                entertainID = clsTravelEntertain.UpdateEntertainData(dtHeader, dtDetail, dtRelasi, ObjSettleCost(i).EntertainID, ObjSettleCost(i).EntertainIDTemp)
                                ObjSettleCost(i).EntertainID = entertainID
                            End If
                            With ObjSettleCost(i)
                                .InsertSettleCost()
                            End With
                        Next
                        For i As Integer = 0 To listDelete.Count - 1
                            If CheckSettleAccrued(listDelete(i)) Then
                                Err.Raise(ErrNumber, , "No Entertain " & listDelete(i) & " sudah dilakukan proses Accrued !")
                            Else
                                cls_SettleCost.EntertainID = listDelete(i)
                                cls_SettleCost.DeleteSettleEntertain()
                            End If
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

    Public Sub UpdateSettleHeader()
        Try
            strQuery = " UPDATE  dbo.TravelSettleHeader " & vbCrLf &
                        " SET     NoPR = " & QVal(NoPR) & " , " & vbCrLf &
                        "         RateUSD = " & QVal(RateUSD) & " , " & vbCrLf &
                        "         RateYEN = " & QVal(RateYEN) & " , " & vbCrLf &
                        "         TotalReturnUSD = " & QVal(TotalReturnUSD) & " , " & vbCrLf &
                        "         TotalReturnYEN = " & QVal(TotalReturnYEN) & " , " & vbCrLf &
                        "         TotalReturnIDR = " & QVal(TotalReturnIDR) & " , " & vbCrLf &
                        "         UpdatedBy = " & QVal(gh_Common.Username) & ", " & vbCrLf &
                        "         UpdatedDate = GETDATE() " & vbCrLf &
                        " WHERE   TravelSettleID = '" & TravelSettleID & "' "
            ExecQuery(strQuery)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteDataTravelSettle()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        DeleteSettleHeader()

                        Dim cls_SettleDetail As New TravelSettleDetailModel
                        cls_SettleDetail.DeleteSettleDetail(TravelSettleID)

                        For i As Integer = 0 To ObjSettleDetail.Count - 1
                            With ObjSettleDetail(i)
                                .UpdateRequest("OPEN")
                            End With
                        Next

                        Dim cls_SettleCost As New TravelSettleCostModel
                        cls_SettleCost.DeleteSettleCost(TravelSettleID)

                        For i As Integer = 0 To ObjSettleCost.Count - 1
                            With ObjSettleCost(i)
                                .DeleteSettleEntertain()
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

    Public Sub DeleteSettleHeader()
        Try
            strQuery = " DELETE  FROM dbo.TravelSettleHeader " & vbCrLf &
                       " WHERE   TravelSettleID = " & QVal(TravelSettleID) & " "
            ExecQuery(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub UpdateTravelSettleNoRefund()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        For i As Integer = 0 To ObjSettleDetail.Count - 1
                            With ObjSettleDetail(i)
                                .UpdateRequest("CLOSE")
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

    Public Sub UpdateTravelSettleYesRefund()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        For i As Integer = 0 To ObjSettleDetail.Count - 1
                            With ObjSettleDetail(i)
                                .UpdateRequest("CLOSE")
                                .UpdateTicketRefund()
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

            dt = MainModul.GetDataTableByCommand_SP(SP_Name, pParam)
            If dt.Rows.Count > 0 Then
                rate = Convert.ToDouble(dt.Rows(0).Item(1))
            End If

            Return rate
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

    Public Function GetCreditCard() As DataTable
        Try
            strQuery = "SELECT  CreditCardID ,
                                AccountName ,
                                BankName ,
                                CreditCardNumber
                        FROM    dbo.TravelCreditCard
                        ORDER BY AccountName ASC ,
                                BankName ASC"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetRequestAllowance(ByVal _noRequest As String) As DataTable
        Try
            strQuery = "SELECT  trh.NoRequest ,
                                trh.Nama ,
                                MIN(trd.DepartureDate) AS DepartureDate ,
                                MAX(trd.ArrivalDate) AS ArrivalDate ,
                                SUM(trd.Days) AS [Days] ,
                                SUM(trd.RateAllowanceUSD) AS TotRateAllowanceUSD ,
                                SUM(trd.RateAllowanceYEN) AS TotRateAllowanceYEN ,
                                SUM(trd.RateAllowanceIDR) AS TotRateAllowanceIDR ,
                                SUM(trc.AdvanceUSD) AS AdvanceUSD ,
                                SUM(trc.AdvanceUSD) AS SettlementUSD ,
                                SUM(trc.AdvanceYEN) AS AdvanceYEN ,
                                SUM(trc.AdvanceYEN) AS SettlementYEN ,
                                SUM(trc.AdvanceIDR) AS AdvanceIDR ,
                                SUM(trc.AdvanceIDR) AS SettlementIDR
                        FROM    dbo.TravelRequestHeader AS trh
                                INNER JOIN ( SELECT NoRequest ,
                                                    MIN(DepartureDate) AS DepartureDate ,
                                                    MAX(ArrivalDate) AS ArrivalDate ,
                                                    SUM(Day) AS [Days] ,
                                                    SUM(RateAllowanceUSD * Day) AS RateAllowanceUSD ,
                                                    SUM(RateAllowanceYEN * Day) AS RateAllowanceYEN ,
                                                    SUM(RateAllowanceIDR * Day) AS RateAllowanceIDR
                                             FROM   dbo.TravelRequestDetail
                                             GROUP BY NoRequest
                                           ) AS trd ON trd.NoRequest = trh.NoRequest
                                INNER JOIN dbo.TravelRequestCost AS trc ON trc.NoRequest = trh.NoRequest
                        WHERE   trc.CostType = 'C02'
                                AND trh.NoRequest IN ( " & _noRequest & " )
                        GROUP BY trh.NoRequest ,
                                trh.Nama"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetPocketAllowance(ByVal noRequest__ As String) As DataTable
        Try
            strQuery = "SELECT  trh.Golongan ,
                                tpa.Amount
                        FROM    dbo.TravelRequestHeader AS trh
                                LEFT JOIN dbo.TravelPocketAllowance AS tpa ON tpa.TravelType = trh.TravelType
                                                                              AND tpa.Golongan = trh.Golongan
                        WHERE   NoRequest = " & QVal(noRequest__) & ""
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region "Function for report"
    Public Function LoadReportSettleHeader() As DataTable
        Try
            Dim dt As New DataTable

            Dim SP_Name As String = "Travel_Rpt_GetTravelSettleHeader"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@TravelSettleID", SqlDbType.VarChar)
            pParam(0).Value = TravelSettleID

            dt = MainModul.GetDataTableByCommand_SP(SP_Name, pParam)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function LoadReportSettleDetail() As DataTable
        Try
            Dim dt As New DataTable

            Dim SP_Name As String = "Travel_Rpt_GetTravelSettleDetail"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@TravelSettleID", SqlDbType.VarChar)
            pParam(0).Value = TravelSettleID

            dt = MainModul.GetDataTableByCommand_SP(SP_Name, pParam)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function LoadReportSettleDetailSum() As DataTable
        Try
            Dim dt As New DataTable

            Dim SP_Name As String = "Travel_Rpt_GetTravelSettleDetailSum"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@TravelSettleID", SqlDbType.VarChar)
            pParam(0).Value = TravelSettleID

            dt = MainModul.GetDataTableByCommand_SP(SP_Name, pParam)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function LoadReportSettleExpense() As DataTable
        Try
            Dim dt As New DataTable

            Dim SP_Name As String = "Travel_Rpt_GetSumExpense"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@TravelSettleID", SqlDbType.VarChar)
            pParam(0).Value = TravelSettleID

            dt = MainModul.GetDataTableByCommand_SP(SP_Name, pParam)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function LoadReportSumExpense() As DataTable
        Try
            Dim dt As New DataTable
            strQuery = "DECLARE @tblSum TABLE
                            (
                                TravelSettleID CHAR(15) ,
                                ID CHAR(2) ,
                                CostType VARCHAR(20) ,
                                PaymentType VARCHAR(20) ,
                                USD FLOAT ,
                                YEN FLOAT ,
                                IDR FLOAT
                            );

                        INSERT  INTO @tblSum
                                EXEC dbo.Travel_Rpt_GetSumExpense @TravelSettleID = " & QVal(TravelSettleID) & ";
        
                        SELECT  TravelSettleID ,
                                'TOTAL EXPENSE MONEY ' + PaymentType AS SumDesc ,
                                SUM(USD) AS USD ,
                                SUM(YEN) AS YEN ,
                                SUM(IDR) AS IDR
                        FROM    @tblSum
                        WHERE   TravelSettleID IS NOT NULL
                        GROUP BY TravelSettleID ,
                                PaymentType"
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function LoadReportAllowanceAdvance() As DataTable
        Try
            Dim dt As New DataTable

            Dim SP_Name As String = "Travel_Rpt_GetAllowanceAdvance"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@TravelSettleID", SqlDbType.VarChar)
            pParam(0).Value = TravelSettleID

            dt = MainModul.GetDataTableByCommand_SP(SP_Name, pParam)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function LoadReportAllowanceSettle() As DataTable
        Try
            Dim dt As New DataTable

            Dim SP_Name As String = "Travel_Rpt_GetAllowanceSettle"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@TravelSettleID", SqlDbType.VarChar)
            pParam(0).Value = TravelSettleID

            dt = MainModul.GetDataTableByCommand_SP(SP_Name, pParam)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#End Region

End Class

Public Class TravelSettleDetailModel
    Public Property TravelSettleID As String
    Public Property NoRequest As String
    Public Property Nama As String
    Public Property DepartureDate As Date
    Public Property ArrivalDate As Date
    Public Property Days As Integer
    Public Property RateAllowanceUSD As Double
    Public Property TotRateAllowanceUSD As Double
    Public Property TotRateAllowanceYEN As Double
    Public Property TotRateAllowanceIDR As Double
    Public Property AllowanceUSD As Double
    Public Property AllowanceYEN As Double
    Public Property AllowanceIDR As Double
    Public Property NoVoucher As String

    Dim strQuery As String

    Public Function GetTravelSettDetailByID() As DataTable
        Try
            strQuery = " SELECT tsd.NoRequest ,
                                tsd.Nama ,
                                tsd.DepartureDate ,
                                tsd.ArrivalDate ,
                                tsd.Days ,
                                tsd.TotRateAllowanceUSD ,
                                tsd.TotRateAllowanceYEN ,
                                tsd.TotRateAllowanceIDR ,
                                trc.AdvanceUSD AS AdvanceUSD ,
                                tsd.AllowanceUSD AS SettlementUSD ,
                                trc.AdvanceYEN AS AdvanceYEN ,
                                tsd.AllowanceYEN AS SettlementYEN ,
                                trc.AdvanceIDR AS AdvanceIDR ,
                                tsd.AllowanceIDR AS SettlementIDR
                         FROM   dbo.TravelSettleDetail AS tsd
                                INNER JOIN dbo.TravelRequestCost AS trc ON trc.NoRequest = tsd.NoRequest
                         WHERE  trc.CostType = 'C02'
                                AND tsd.TravelSettleID = " & QVal(TravelSettleID) & ""
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub InsertSettleDetail()
        Try
            strQuery = "INSERT INTO dbo.TravelSettleDetail
                                ( TravelSettleID ,
                                  NoRequest ,
                                  Nama ,
                                  DepartureDate ,
                                  ArrivalDate ,
                                  Days ,
                                  TotRateAllowanceUSD ,
                                  TotRateAllowanceYEN ,
                                  TotRateAllowanceIDR ,
                                  AllowanceUSD ,
                                  AllowanceYEN ,
                                  AllowanceIDR
                                )
                        VALUES  ( " & QVal(TravelSettleID) & " , -- TravelSettleID - varchar(15)
                                  " & QVal(NoRequest) & " , -- NoRequest - varchar(15)
                                  " & QVal(Nama) & " , -- Nama - varchar(100)
                                  " & QVal(DepartureDate) & " , -- DepartureDate - date
                                  " & QVal(ArrivalDate) & " , -- ArrivalDate - date
                                  " & QVal(Days) & " , -- Days - int
                                  " & QVal(TotRateAllowanceUSD) & " , -- TotRateAllowanceUSD - float
                                  " & QVal(TotRateAllowanceYEN) & " , -- TotRateAllowanceYEN - float
                                  " & QVal(TotRateAllowanceIDR) & " , -- TotRateAllowanceIDR - float
                                  " & QVal(AllowanceUSD) & " , -- AllowanceUSD - float
                                  " & QVal(AllowanceYEN) & " , -- AllowanceYEN - float
                                  " & QVal(AllowanceIDR) & "  -- AllowanceIDR - float
                                )"
            ExecQuery(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub UpdateRequest(ByVal status As String)
        Try
            strQuery = "UPDATE  dbo.TravelRequestHeader
                        SET     Status = " & QVal(status) & "
                        WHERE   NoRequest = " & QVal(NoRequest) & ""
            ExecQuery(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub UpdateTicketRefund()
        Try
            strQuery = "UPDATE  dbo.TravelTicketDetail
                        SET     Refund = 1
                        WHERE   NoVoucher = " & QVal(NoVoucher) & "
                                AND NoRequest = " & QVal(NoRequest) & ""
            ExecQuery(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteSettleDetail(ByVal _TravelSettID As String)
        Try
            strQuery = " DELETE  FROM dbo.TravelSettleDetail " & vbCrLf &
                       " WHERE   TravelSettleID = " & QVal(_TravelSettID) & " "
            ExecQuery(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetTravelReqDetail() As DataTable
        Try
            Dim dt As New DataTable

            Dim SP_Name As String = "Travel_Get_TravelDetailAllowance"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
            pParam(0) = New SqlClient.SqlParameter("@NoRequest", SqlDbType.VarChar)
            pParam(0).Value = NoRequest
            pParam(1) = New SqlClient.SqlParameter("@DeptDate", SqlDbType.Date)
            pParam(1).Value = DepartureDate
            pParam(2) = New SqlClient.SqlParameter("@ArrDate", SqlDbType.Date)
            pParam(2).Value = ArrivalDate

            dt = MainModul.GetDataTableByCommand_SP(SP_Name, pParam)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class

Public Class TravelSettleCostModel
    Public Property TravelSettleID As String
    Public Property ID As Integer
    Public Property Seq As Integer
    Public Property AccountID As String
    Public Property DateCost As Date
    Public Property EntertainID As String
    Public Property EntertainIDTemp As String
    Public Property TFrom As String
    Public Property TTo As String
    Public Property Transport As String
    Public Property Description As String
    Public Property PaymentType As String
    Public Property CreditCardID As String
    Public Property CreditCardNumber As String
    Public Property AccountName As String
    Public Property CurryID As String
    Public Property Amount As Double
    Public Property AmountIDR As Double

    Dim strQuery As String

    Public Function GetTravelSettleCostByID() As DataTable
        Try
            Dim dt As New DataTable

            Dim SP_Name As String = "Travel_Get_TravelSettleCost"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@TravelSettleID", SqlDbType.VarChar)
            pParam(0).Value = TravelSettleID

            dt = MainModul.GetDataTableByCommand_SP(SP_Name, pParam)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetEntertainID() As List(Of String)
        Try
            Dim result As New List(Of String)
            Dim dt As New DataTable

            strQuery = "SELECT  '''' + EntertainID + '''' AS EntertainID
                        FROM    dbo.TravelSettleCost
                        WHERE   TravelSettleID = " & QVal(TravelSettleID) & "
                                AND ID = 4"

            dt = GetDataTable(strQuery)
            For Each row As DataRow In dt.Rows
                result.Add(row("EntertainID"))
            Next
            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetEntertainHeader() As DataTable
        Try
            Dim entertainID As List(Of String)
            entertainID = GetEntertainID()
            Dim nilai As String = "''"
            If entertainID.Count > 0 Then
                nilai = String.Join(",", entertainID.ToArray)
            End If

            Dim dt As New DataTable

            strQuery = "SELECT  Tgl ,
                                RTRIM(SettleID) AS SettleID ,
                                RTRIM(PRNo) AS PRNo ,
                                RTRIM(DeptID) AS DeptID ,
                                RTRIM(CuryID) AS CuryID ,
                                Total ,
                                RTRIM(PaymentType) AS PaymentType ,
                                RTRIM(CreditCardID) AS CreditCardID ,
                                RTRIM(CreditCardNumber) AS CreditCardNumber ,
                                RTRIM(AccountName) AS AccountName ,
                                RTRIM(Remark) AS Remark
                        FROM    dbo.settle_header
                        WHERE   SettleID IN ( " & nilai & " )"

            dt = GetDataTable_Solomon(strQuery)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetEntertainDetail() As DataTable
        Try
            Dim entertainID As List(Of String)
            entertainID = GetEntertainID()
            Dim nilai As String = "''"
            If entertainID.Count > 0 Then
                nilai = String.Join(",", entertainID.ToArray)
            End If

            Dim dt As New DataTable

            strQuery = "SELECT  RTRIM(SettleID) AS SettleID ,
                                Tgl ,
                                RTRIM(SubAcct) AS SubAccount ,
                                RTRIM(AcctID) AS Account ,
                                RTRIM([Description]) AS [Description] ,
                                RTRIM(Nama) AS Nama ,
                                RTRIM(Tempat) AS Tempat ,
                                RTRIM(Alamat) AS Alamat ,
                                RTRIM(Jenis) AS Jenis ,
                                SettleAmount AS Amount ,
                                HeaderSeq
                        FROM    dbo.settle_detail
                        WHERE   SettleID IN ( " & nilai & " )"

            dt = GetDataTable_Solomon(strQuery)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetEntertainRelasi() As DataTable
        Try
            Dim entertainID As List(Of String)
            entertainID = GetEntertainID()
            Dim nilai As String = "''"
            If entertainID.Count > 0 Then
                nilai = String.Join(",", entertainID.ToArray)
            End If

            Dim dt As New DataTable

            strQuery = "SELECT  RTRIM(SettleID) AS SettleID ,
                                RTRIM(Nama) AS Nama ,
                                RTRIM(Posisi) AS Posisi ,
                                RTRIM(Perusahaan) AS Perusahaan ,
                                RTRIM(JenisUsaha) AS JenisUsaha ,
                                RTRIM(Remark) AS Remark ,
                                HeaderSeq
                        FROM    dbo.SettleRelasi
                        WHERE   SettleID IN ( " & nilai & " )"

            dt = GetDataTable_Solomon(strQuery)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub InsertSettleCost()
        Try
            Dim dt As New DataTable

            Dim SP_Name As String = "Travel_Insert_TravelSettleCost"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(16) {}
            pParam(0) = New SqlClient.SqlParameter("@TravelSettleID", SqlDbType.VarChar)
            pParam(0).Value = TravelSettleID
            pParam(1) = New SqlClient.SqlParameter("@ID", SqlDbType.Int)
            pParam(1).Value = ID
            pParam(2) = New SqlClient.SqlParameter("@Seq", SqlDbType.Int)
            pParam(2).Value = Seq
            pParam(3) = New SqlClient.SqlParameter("@AccountID", SqlDbType.VarChar)
            pParam(3).Value = AccountID
            pParam(4) = New SqlClient.SqlParameter("@DateCost", SqlDbType.Date)
            pParam(4).Value = DateCost
            pParam(5) = New SqlClient.SqlParameter("@EntertainID", SqlDbType.VarChar)
            pParam(5).Value = EntertainID
            pParam(6) = New SqlClient.SqlParameter("@TFrom", SqlDbType.VarChar)
            pParam(6).Value = TFrom
            pParam(7) = New SqlClient.SqlParameter("@TTo", SqlDbType.VarChar)
            pParam(7).Value = TTo
            pParam(8) = New SqlClient.SqlParameter("@Transport", SqlDbType.VarChar)
            pParam(8).Value = Transport
            pParam(9) = New SqlClient.SqlParameter("@Description", SqlDbType.VarChar)
            pParam(9).Value = Description
            pParam(10) = New SqlClient.SqlParameter("@PaymentType", SqlDbType.VarChar)
            pParam(10).Value = PaymentType
            pParam(11) = New SqlClient.SqlParameter("@CreditCardID", SqlDbType.VarChar)
            pParam(11).Value = CreditCardID
            pParam(12) = New SqlClient.SqlParameter("@CreditCardNumber", SqlDbType.VarChar)
            pParam(12).Value = CreditCardNumber
            pParam(13) = New SqlClient.SqlParameter("@AccountName", SqlDbType.VarChar)
            pParam(13).Value = AccountName
            pParam(14) = New SqlClient.SqlParameter("@CurryID", SqlDbType.VarChar)
            pParam(14).Value = CurryID
            pParam(15) = New SqlClient.SqlParameter("@Amount", SqlDbType.Float)
            pParam(15).Value = Amount
            pParam(16) = New SqlClient.SqlParameter("@AmountIDR", SqlDbType.Float)
            pParam(16).Value = AmountIDR

            ExecQueryByCommand_SP(SP_Name, pParam)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteSettleCost(ByVal _TravelSettID As String)
        Try
            strQuery = " DELETE  FROM dbo.TravelSettleCost " & vbCrLf &
                       " WHERE   TravelSettleID = " & QVal(_TravelSettID) & " "
            ExecQuery(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteSettleEntertain()
        Try
            strQuery = "DELETE  FROM TSC16Application.dbo.settle_header
                        WHERE   SettleID = " & QVal(EntertainID) & ""
            ExecQuery_Solomon(strQuery)

            strQuery = "DELETE  FROM TSC16Application.dbo.settle_detail
                        WHERE   SettleID = " & QVal(EntertainID) & ""
            ExecQuery_Solomon(strQuery)

            strQuery = "DELETE  FROM TSC16Application.dbo.SettleRelasi
                        WHERE   SettleID = " & QVal(EntertainID) & ""
            ExecQuery_Solomon(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class


