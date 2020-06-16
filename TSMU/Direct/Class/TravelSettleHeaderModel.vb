Imports System.Collections.ObjectModel

Public Class TravelSettleHeaderModel
    Public Property TravelSettleID As String
    Public Property DateHeader As Date
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
            dt = GetDataTable_Solomon(query)
            Return dt.Rows(0).Item(0).ToString

        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function GetDataGridRequest() As DataTable
        Try
            Dim dt As New DataTable
            strQuery = " SELECT  ttd.NoVoucher ,
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
            dt = GetDataTable_Solomon(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetTravelSettHeader() As DataTable
        Try
            Dim dt As New DataTable
            strQuery = " SELECT  TravelSettleID ,
                                Date ,
                                DeptID ,
                                Nama ,
                                Destination ,
                                Purpose ,
                                Term ,
                                Pay
                        FROM    dbo.TravelSettleHeader "
            dt = GetDataTable_Solomon(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub GetTravelSettHeaderByID()
        Try
            strQuery = " SELECT  TravelSettleID ,
                                Date ,
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
            dt = GetDataTable_Solomon(strQuery)
            If dt.Rows.Count > 0 Then
                DateHeader = If(IsDBNull(dt.Rows(0).Item("Date")), DateTime.Today, Convert.ToDateTime(dt.Rows(0).Item("Date")))
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

    Public Sub InsertDataTravelSettle()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
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
                            With ObjSettleCost(i)
                                .InsertSettleCost()
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

    Public Sub InsertSettleHeader()
        Try
            Dim dt As New DataTable

            Dim SP_Name As String = "Travel_Insert_TravelSettleHeader"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(20) {}
            pParam(0) = New SqlClient.SqlParameter("@TravelSettleID", SqlDbType.VarChar)
            pParam(0).Value = TravelSettleID
            pParam(1) = New SqlClient.SqlParameter("@DateHeader", SqlDbType.Date)
            pParam(1).Value = DateHeader
            pParam(2) = New SqlClient.SqlParameter("@DeptID", SqlDbType.VarChar)
            pParam(2).Value = DeptID
            pParam(3) = New SqlClient.SqlParameter("@Nama", SqlDbType.VarChar)
            pParam(3).Value = Nama
            pParam(4) = New SqlClient.SqlParameter("@Destination", SqlDbType.VarChar)
            pParam(4).Value = Destination
            pParam(5) = New SqlClient.SqlParameter("@Purpose", SqlDbType.VarChar)
            pParam(5).Value = Purpose
            pParam(6) = New SqlClient.SqlParameter("@TravelType", SqlDbType.VarChar)
            pParam(6).Value = TravelType
            pParam(7) = New SqlClient.SqlParameter("@DepartureDate", SqlDbType.Date)
            pParam(7).Value = DepartureDate
            pParam(8) = New SqlClient.SqlParameter("@ArrivalDate", SqlDbType.Date)
            pParam(8).Value = ArrivalDate
            pParam(9) = New SqlClient.SqlParameter("@Term", SqlDbType.VarChar)
            pParam(9).Value = Term
            pParam(10) = New SqlClient.SqlParameter("@PickUp", SqlDbType.VarChar)
            pParam(10).Value = PickUp
            pParam(11) = New SqlClient.SqlParameter("@Visa", SqlDbType.VarChar)
            pParam(11).Value = Visa
            pParam(12) = New SqlClient.SqlParameter("@RateUSD", SqlDbType.Float)
            pParam(12).Value = RateUSD
            pParam(13) = New SqlClient.SqlParameter("@RateYEN", SqlDbType.Float)
            pParam(13).Value = RateYEN
            pParam(14) = New SqlClient.SqlParameter("@TotalAdvanceIDR", SqlDbType.Float)
            pParam(14).Value = TotalAdvanceIDR
            pParam(15) = New SqlClient.SqlParameter("@TotalAdvanceUSD", SqlDbType.Float)
            pParam(15).Value = TotalAdvanceUSD
            pParam(16) = New SqlClient.SqlParameter("@TotalAdvanceYEN", SqlDbType.Float)
            pParam(16).Value = TotalAdvanceYEN
            pParam(17) = New SqlClient.SqlParameter("@TotalReturnIDR", SqlDbType.Float)
            pParam(17).Value = TotalReturnIDR
            pParam(18) = New SqlClient.SqlParameter("@TotalReturnUSD", SqlDbType.Float)
            pParam(18).Value = TotalReturnUSD
            pParam(19) = New SqlClient.SqlParameter("@TotalReturnYEN", SqlDbType.Float)
            pParam(19).Value = TotalReturnYEN
            pParam(20) = New SqlClient.SqlParameter("@Username", SqlDbType.VarChar)
            pParam(20).Value = gh_Common.Username

            ExecQueryByCommand_SP_Solomon(SP_Name, pParam)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateDataTravelSettle()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        UpdateSettleHeader()

                        Dim cls_SettleCost As New TravelSettleCostModel
                        cls_SettleCost.DeleteSettleCost(TravelSettleID)
                        For i As Integer = 0 To ObjSettleCost.Count - 1
                            With ObjSettleCost(i)
                                .InsertSettleCost()
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

    Public Sub UpdateSettleHeader()
        Try
            strQuery = " UPDATE  dbo.TravelSettleHeader " & vbCrLf &
                        " SET     RateUSD = " & QVal(RateUSD) & " , " & vbCrLf &
                        "         RateYEN = " & QVal(RateYEN) & " , " & vbCrLf &
                        "         TotalReturnUSD = " & QVal(TotalReturnUSD) & " , " & vbCrLf &
                        "         TotalReturnYEN = " & QVal(TotalReturnYEN) & " , " & vbCrLf &
                        "         TotalReturnIDR = " & QVal(TotalReturnIDR) & " , " & vbCrLf &
                        "         UpdatedBy = " & QVal(gh_Common.Username) & ", " & vbCrLf &
                        "         UpdatedDate = GETDATE() " & vbCrLf &
                        " WHERE   TravelSettleID = '" & TravelSettleID & "' "
            ExecQuery_Solomon(strQuery)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteDataTravelSettle()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
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
            ExecQuery_Solomon(strQuery)
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

            dt = MainModul.GetDataTableByCommand_SP_Solomon(SP_Name, pParam)
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
            strQuery = " SELECT  CreditCardID ,
                                CreditCardNumber ,
                                AccountName ,
                                BankName
                        FROM    dbo.TravelCreditCard "
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region "Function for report"
    Public Function LoadReportSettleHeader() As DataTable
        Try
            Dim dt As New DataTable
            strQuery = " SELECT  TravelSettleID ,
                                Date ,
                                DeptID ,
                                Nama ,
                                Purpose ,
                                Destination ,
                                Term ,
                                PickUp ,
                                Visa ,
                                RateUSD ,
                                RateYEN ,
                                CAST(TotalAdvanceIDR AS INTEGER) AS TotalAdvanceIDR ,
                                CAST(TotalAdvanceUSD AS INTEGER) AS TotalAdvanceUSD ,
                                CAST(TotalAdvanceYEN AS INTEGER) AS TotalAdvanceYEN
                        FROM    dbo.TravelSettleHeader
                        WHERE   TravelSettleID = " & QVal(TravelSettleID) & " "
            dt = GetDataTable_Solomon(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function LoadReportSettleTransport() As DataTable
        Try
            Dim dt As New DataTable
            strQuery = "SELECT  TravelSettleID ,
                                Seq ,
                                dbo.FormatDateTime(Date, 'dd-MMM') AS Date ,
                                TFrom ,
                                TTo ,
                                Transport ,
                                CASE WHEN CurryID = 'YEN' THEN 'JPY'
                                     ELSE CurryID
                                END AS CurryID ,
                                Amount ,
                                CASE WHEN PaymentType = 'CASH' THEN 'CH'
                                     ELSE 'CC'
                                END AS PaymentType
                        FROM    dbo.TravelSettleTransport
                        WHERE   TravelSettleID = " & QVal(TravelSettleID) & ""
            dt = GetDataTable_Solomon(strQuery)
            Return dt
            'Dim ds As New dsLaporan
            'ds = GetDsReport_Solomon(strQuery, "TravelSettTransport")
            'Return ds
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function LoadReportSumTransport() As DataTable
        Try
            Dim dt As New DataTable
            strQuery = "SELECT  TravelSettleID ,
                                'TOTAL' AS SumDesc ,
                                CASE WHEN CurryID = 'YEN' THEN 'JPY'
                                        ELSE CurryID
                                END AS CurryID ,
                                SUM(Amount) AS TotAmount
                        FROM    dbo.TravelSettleTransport
                        WHERE   TravelSettleID = " & QVal(TravelSettleID) & "
                        GROUP BY TravelSettleID ,
                                CurryID "
            dt = GetDataTable_Solomon(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function LoadReportSettleStaying() As DataTable
        Try
            Dim dt As New DataTable
            strQuery = "SELECT  TravelSettleID ,
                                Seq ,
                                dbo.FormatDateTime (Date, 'dd-MMM') AS Date ,
                                Description ,
                                CASE WHEN CurryID = 'YEN' THEN 'JPY'
                                     ELSE CurryID
                                END AS CurryID ,
                                Amount ,
                                CASE WHEN PaymentType = 'CASH' THEN 'CH'
                                     ELSE 'CC'
                                END AS PaymentType
                        FROM    dbo.TravelSettleStaying
                        WHERE   TravelSettleID = " & QVal(TravelSettleID) & ""
            dt = GetDataTable_Solomon(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function LoadReportSettleEntertain() As DataTable
        Try
            Dim dt As New DataTable
            strQuery = " SELECT  TravelSettleID ,
                                Seq ,
                                dbo.FormatDateTime(Date, 'dd-MMM') AS Date ,
                                Description ,
                                CASE WHEN CurryID = 'YEN' THEN 'JPY'
                                     ELSE CurryID
                                END AS CurryID ,
                                Amount ,
                                CASE WHEN PaymentType = 'CASH' THEN 'CH'
                                     ELSE 'CC'
                                END AS PaymentType
                        FROM    dbo.TravelSettleEntertainment
                        WHERE   TravelSettleID = " & QVal(TravelSettleID) & " "
            dt = GetDataTable_Solomon(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function LoadReportSettleOther() As DataTable
        Try
            Dim dt As New DataTable
            strQuery = " SELECT  TravelSettleID ,
                                Seq ,
                                dbo.FormatDateTime(Date, 'dd-MMM') AS Date ,
                                Description ,
                                CASE WHEN CurryID = 'YEN' THEN 'JPY'
                                     ELSE CurryID
                                END AS CurryID ,
                                Amount ,
                                CASE WHEN PaymentType = 'CASH' THEN 'CH'
                                     ELSE 'CC'
                                END AS PaymentType
                        FROM    dbo.TravelSettleOther
                        WHERE   TravelSettleID = " & QVal(TravelSettleID) & " "
            dt = GetDataTable_Solomon(strQuery)
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

            dt = MainModul.GetDataTableByCommand_SP_Solomon(SP_Name, pParam)

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

            dt = MainModul.GetDataTableByCommand_SP_Solomon(SP_Name, pParam)

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

            dt = MainModul.GetDataTableByCommand_SP_Solomon(SP_Name, pParam)

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
                                PaymentType VARCHAR(11) ,
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
            dt = GetDataTable_Solomon(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function LoadReportSettleAllowance() As DataTable
        Try
            Dim dt As New DataTable
            strQuery = " SELECT  tsd.TravelSettleID ,
                                CASE WHEN trc.AdvanceUSD <> 0
                                     THEN 'USD ' + CAST(trc.AdvanceUSD / trc.Days AS VARCHAR(100))
                                     ELSE ''
                                END + CASE WHEN trc.AdvanceYEN <> 0
                                           THEN ' | YEN '
                                                + CAST(trc.AdvanceYEN / trc.Days AS VARCHAR(100))
                                           ELSE ''
                                      END + CASE WHEN trc.AdvanceIDR <> 0
                                                 THEN ' | IDR '
                                                      + CAST(trc.AdvanceIDR / trc.Days AS VARCHAR(100))
                                                 ELSE ''
                                            END AS Rate ,
                                CAST(trc.Days AS VARCHAR(2)) + ' days' AS Days ,
                                CAST(COUNT(tsd.TravelSettleID) AS VARCHAR(2)) + ' persons' AS Persons ,
                                CAST(SUM(trc.AdvanceUSD) AS FLOAT) AS USD ,
                                CAST(SUM(trc.AdvanceYEN) AS FLOAT) AS YEN ,
                                CAST(SUM(trc.AdvanceIDR) AS FLOAT) AS IDR
                        FROM    dbo.TravelSettleDetail AS tsd
                                LEFT JOIN TravelRequestCost AS trc ON trc.NoRequest = tsd.NoRequest
                        WHERE   CostType = 'C02'
                                AND tsd.TravelSettleID = " & QVal(TravelSettleID) & "
                        GROUP BY tsd.TravelSettleID ,
                                trc.Days ,
                                trc.AdvanceUSD ,
                                trc.AdvanceYEN ,
                                trc.AdvanceIDR "
            dt = GetDataTable_Solomon(strQuery)
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

    Dim strQuery As String

    Public Function GetTravelSettDetailByID() As DataTable
        Try
            strQuery = " SELECT  NoRequest ,
                                Nama
                        FROM    dbo.TravelSettleDetail
                        WHERE   TravelSettleID = " & QVal(TravelSettleID) & " "
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub InsertSettleDetail()
        Try
            strQuery = " INSERT  INTO dbo.TravelSettleDetail
                                ( TravelSettleID, NoRequest, Nama )
                        VALUES  ( " & QVal(TravelSettleID) & ", -- TravelSettleID - varchar(15)
                                  " & QVal(NoRequest) & ", -- NoRequest - varchar(15)
                                  " & QVal(Nama) & "  -- Nama - varchar(100)
                                  ) "
            ExecQuery_Solomon(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub UpdateRequest(ByVal status As String)
        Try
            strQuery = " UPDATE  dbo.TravelRequestHeader
                        SET     Status = " & QVal(status) & "
                        WHERE   NoRequest = " & QVal(NoRequest) & " "
            ExecQuery_Solomon(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteSettleDetail(ByVal _TravelSettID As String)
        Try
            strQuery = " DELETE  FROM dbo.TravelSettleDetail " & vbCrLf &
                       " WHERE   TravelSettleID = " & QVal(_TravelSettID) & " "
            ExecQuery_Solomon(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class

Public Class TravelSettleCostModel
    Public Property TravelSettleID As String
    Public Property ID As Integer
    Public Property Seq As Integer
    Public Property AccountID As String
    Public Property DateCost As Date
    Public Property EntertainID As String
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

            dt = MainModul.GetDataTableByCommand_SP_Solomon(SP_Name, pParam)

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

            ExecQueryByCommand_SP_Solomon(SP_Name, pParam)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteSettleCost(ByVal _TravelSettID As String)
        Try
            Dim ls_SP As String
            ls_SP = " DELETE  FROM dbo.TravelSettleCost " & vbCrLf &
                    " WHERE   TravelSettleID = " & QVal(_TravelSettID) & " "
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class


