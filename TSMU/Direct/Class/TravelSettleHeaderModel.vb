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
    Public Property Status As String

    Public Property ObjSettleDetail() As New Collection(Of TravelSettleDetailModel)
    Public Property ObjSettleTransport() As New Collection(Of TravelSettleTransportModel)
    Public Property ObjSettleStaying() As New Collection(Of TravelSettleStayingModel)
    Public Property ObjSettleEntertain() As New Collection(Of TravelSettleEntertainModel)
    Public Property ObjSettleOther() As New Collection(Of TravelSettleOtherModel)

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
            strQuery = " SELECT  trh.NoRequest ,
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
                                TotalAdvanceYEN
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

                        For i As Integer = 0 To ObjSettleTransport.Count - 1
                            With ObjSettleTransport(i)
                                .InsertSettleTransport()
                            End With
                        Next

                        For i As Integer = 0 To ObjSettleStaying.Count - 1
                            With ObjSettleStaying(i)
                                .InsertSettleStaying()
                            End With
                        Next

                        For i As Integer = 0 To ObjSettleEntertain.Count - 1
                            With ObjSettleEntertain(i)
                                .InsertSettleEntertain()
                            End With
                        Next

                        For i As Integer = 0 To ObjSettleOther.Count - 1
                            With ObjSettleOther(i)
                                .InsertSettleOther()
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

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(16) {}
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
            pParam(6) = New SqlClient.SqlParameter("@DepartureDate", SqlDbType.Date)
            pParam(6).Value = DepartureDate
            pParam(7) = New SqlClient.SqlParameter("@ArrivalDate", SqlDbType.Date)
            pParam(7).Value = ArrivalDate
            pParam(8) = New SqlClient.SqlParameter("@Term", SqlDbType.VarChar)
            pParam(8).Value = Term
            pParam(9) = New SqlClient.SqlParameter("@PickUp", SqlDbType.VarChar)
            pParam(9).Value = PickUp
            pParam(10) = New SqlClient.SqlParameter("@Visa", SqlDbType.VarChar)
            pParam(10).Value = Visa
            pParam(11) = New SqlClient.SqlParameter("@RateUSD", SqlDbType.Float)
            pParam(11).Value = RateUSD
            pParam(12) = New SqlClient.SqlParameter("@RateYEN", SqlDbType.Float)
            pParam(12).Value = RateYEN
            pParam(13) = New SqlClient.SqlParameter("@TotalAdvanceIDR", SqlDbType.Float)
            pParam(13).Value = TotalAdvanceIDR
            pParam(14) = New SqlClient.SqlParameter("@TotalAdvanceUSD", SqlDbType.Float)
            pParam(14).Value = TotalAdvanceUSD
            pParam(15) = New SqlClient.SqlParameter("@TotalAdvanceYEN", SqlDbType.Float)
            pParam(15).Value = TotalAdvanceYEN
            pParam(16) = New SqlClient.SqlParameter("@Username", SqlDbType.VarChar)
            pParam(16).Value = gh_Common.Username

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

                        Dim cls_SettleTransport As New TravelSettleTransportModel
                        cls_SettleTransport.DeleteSettleTransport(TravelSettleID)
                        For i As Integer = 0 To ObjSettleTransport.Count - 1
                            With ObjSettleTransport(i)
                                .InsertSettleTransport()
                            End With
                        Next

                        Dim cls_SettleStaying As New TravelSettleStayingModel
                        cls_SettleStaying.DeleteSettleStaying(TravelSettleID)
                        For i As Integer = 0 To ObjSettleStaying.Count - 1
                            With ObjSettleStaying(i)
                                .InsertSettleStaying()
                            End With
                        Next

                        Dim cls_SettleEntertain As New TravelSettleEntertainModel
                        cls_SettleEntertain.DeleteSettleEntertain(TravelSettleID)
                        For i As Integer = 0 To ObjSettleEntertain.Count - 1
                            With ObjSettleEntertain(i)
                                .InsertSettleEntertain()
                            End With
                        Next

                        Dim cls_SettleOther As New TravelSettleOtherModel
                        cls_SettleOther.DeleteSettleOther(TravelSettleID)
                        For i As Integer = 0 To ObjSettleOther.Count - 1
                            With ObjSettleOther(i)
                                .InsertSettleOther()
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

                        Dim cls_SettleTransport As New TravelSettleTransportModel
                        cls_SettleTransport.DeleteSettleTransport(TravelSettleID)

                        Dim cls_SettleStaying As New TravelSettleStayingModel
                        cls_SettleStaying.DeleteSettleStaying(TravelSettleID)

                        Dim cls_SettleEntertain As New TravelSettleEntertainModel
                        cls_SettleEntertain.DeleteSettleEntertain(TravelSettleID)

                        Dim cls_SettleOther As New TravelSettleOtherModel
                        cls_SettleOther.DeleteSettleOther(TravelSettleID)

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
                                TotalAdvanceIDR ,
                                TotalAdvanceUSD ,
                                TotalAdvanceYEN
                        FROM    dbo.TravelSettleHeader
                        WHERE   TravelSettleID = " & QVal(TravelSettleID) & " "
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

Public Class TravelSettleTransportModel
    Public Property TravelSettleID As String
    Public Property ID As Integer
    Public Property Seq As Integer
    Public Property AccountID As String
    Public Property DateTransport As Date
    Public Property TFrom As String
    Public Property TTo As String
    Public Property Transport As String
    Public Property PaymentType As String
    Public Property CreditCardID As String
    Public Property CreditCardNumber As String
    Public Property AccountName As String
    Public Property CurryID As String
    Public Property Amount As Double
    Public Property AmountIDR As Double

    Dim strQuery As String

    Public Function GetTravelSettTransportByID() As DataTable
        Try
            strQuery = " SELECT  TravelSettleID ,
                                ID ,
                                AccountID ,
                                '' AS SubAccount ,
                                Date ,
                                TFrom ,
                                TTo ,
                                Transport ,
                                CASE WHEN PaymentType = 'CREDIT CARD'
                                     THEN 'CC-' + ISNULL(CreditCardNumber, '')
                                     ELSE PaymentType
                                END PaymentType ,
                                CreditCardID ,
                                CreditCardNumber ,
                                AccountName ,
                                CurryID ,
                                Amount ,
                                AmountIDR
                        FROM    dbo.TravelSettleTransport
                        WHERE   TravelSettleID = " & QVal(TravelSettleID) & " "
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub InsertSettleTransport()
        Try
            strQuery = " INSERT  INTO dbo.TravelSettleTransport
                                ( TravelSettleID ,
                                  ID ,
                                  Seq ,
                                  AccountID ,
                                  Date ,
                                  TFrom ,
                                  TTo ,
                                  Transport ,
                                  PaymentType ,
                                  CreditCardID ,
                                  CreditCardNumber ,
                                  AccountName ,
                                  CurryID ,
                                  Amount ,
                                  AmountIDR
                                )
                        VALUES  ( " & QVal(TravelSettleID) & " , -- TravelSettleID - char(15)
                                  " & QVal(ID) & " , -- ID - int
                                  " & QVal(Seq) & " , -- Seq - int
                                  " & QVal(AccountID) & " , -- AccountID - varchar(10)
                                  " & QVal(DateTransport) & " , -- Date - date
                                  " & QVal(TFrom) & " , -- TFrom - varchar(50)
                                  " & QVal(TTo) & " , -- TTo - varchar(50)
                                  " & QVal(Transport) & " , -- Transport - varchar(50)
                                  " & QVal(PaymentType) & " , -- PaymentType - varchar(11)
                                  " & QVal(CreditCardID) & " , -- CreditCardID - char(5)
                                  " & QVal(CreditCardNumber) & " , -- CreditCardNumber - varchar(20)
                                  " & QVal(AccountName) & " , -- AccountName - varchar(50)
                                  " & QVal(CurryID) & " , -- CurryID - char(3)
                                  " & QVal(Amount) & " , -- Amount - float
                                  " & QVal(AmountIDR) & "  -- AmountIDR - float
                                ) "
            ExecQuery_Solomon(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteSettleTransport(ByVal _TravelSettID As String)
        Try
            Dim ls_SP As String
            ls_SP = " DELETE  FROM dbo.TravelSettleTransport " & vbCrLf &
                    " WHERE   TravelSettleID = " & QVal(_TravelSettID) & " "
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub



End Class

Public Class TravelSettleStayingModel
    Public Property TravelSettleID As String
    Public Property ID As Integer
    Public Property Seq As Integer
    Public Property AccountID As String
    Public Property DateStaying As Date
    Public Property Description As String
    Public Property PaymentType As String
    Public Property CreditCardID As String
    Public Property CreditCardNumber As String
    Public Property AccountName As String
    Public Property CurryID As String
    Public Property Amount As Double
    Public Property AmountIDR As Double

    Dim strQuery As String

    Public Function GetTravelSettHotelByID() As DataTable
        Try
            strQuery = " SELECT  TravelSettleID ,
                                ID ,
                                AccountID ,
                                '' AS SubAccount ,
                                Date ,
                                Description ,
                                CASE WHEN PaymentType = 'CREDIT CARD'
                                     THEN 'CC-' + ISNULL(CreditCardNumber, '')
                                     ELSE PaymentType
                                END PaymentType ,
                                CreditCardID ,
                                CreditCardNumber ,
                                AccountName ,
                                CurryID ,
                                Amount ,
                                AmountIDR
                        FROM    dbo.TravelSettleStaying
                        WHERE   TravelSettleID = " & QVal(TravelSettleID) & " "
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub InsertSettleStaying()
        Try
            strQuery = " INSERT  INTO dbo.TravelSettleStaying
                                ( TravelSettleID ,
                                  ID ,
                                  Seq ,
                                  AccountID ,
                                  Date ,
                                  Description ,
                                  PaymentType ,
                                  CreditCardID ,
                                  CreditCardNumber ,
                                  AccountName ,
                                  CurryID ,
                                  Amount ,
                                  AmountIDR
                                )
                        VALUES  ( " & QVal(TravelSettleID) & " , -- TravelSettleID - char(15)
                                  " & QVal(ID) & " , -- ID - int
                                  " & QVal(Seq) & " , -- Seq - int
                                  " & QVal(AccountID) & " , -- AccountID - varchar(10)
                                  " & QVal(DateStaying) & " , -- Date - date
                                  " & QVal(Description) & " , -- Transport - varchar(50)
                                  " & QVal(PaymentType) & " , -- PaymentType - varchar(11)
                                  " & QVal(CreditCardID) & " , -- CreditCardID - char(5)
                                  " & QVal(CreditCardNumber) & " , -- CreditCardNumber - varchar(20)
                                  " & QVal(AccountName) & " , -- AccountName - varchar(50)
                                  " & QVal(CurryID) & " , -- CurryID - char(3)
                                  " & QVal(Amount) & " , -- Amount - float
                                  " & QVal(AmountIDR) & "  -- AmountIDR - float
                                ) "
            ExecQuery_Solomon(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteSettleStaying(ByVal _TravelSettID As String)
        Try
            Dim ls_SP As String
            ls_SP = " DELETE  FROM dbo.TravelSettleStaying " & vbCrLf &
                    " WHERE   TravelSettleID = " & QVal(_TravelSettID) & " "
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class

Public Class TravelSettleEntertainModel
    Public Property TravelSettleID As String
    Public Property ID As Integer
    Public Property Seq As Integer
    Public Property AccountID As String
    Public Property DateEntertain As Date
    Public Property EntertainID As String
    Public Property Description As String
    Public Property PaymentType As String
    Public Property CreditCardID As String
    Public Property CreditCardNumber As String
    Public Property AccountName As String
    Public Property CurryID As String
    Public Property Amount As Double
    Public Property AmountIDR As Double

    Dim strQuery As String

    Public Function GetTravelSettEntertainByID() As DataTable
        Try
            strQuery = " SELECT  TravelSettleID ,
                                ID ,
                                AccountID ,
                                '' AS SubAccount ,
                                Date ,
                                EntertainID ,
                                Description ,
                                CASE WHEN PaymentType = 'CREDIT CARD'
                                     THEN 'CC-' + ISNULL(CreditCardNumber, '')
                                     ELSE PaymentType
                                END PaymentType ,
                                CreditCardID ,
                                CreditCardNumber ,
                                AccountName ,
                                CurryID ,
                                Amount ,
                                AmountIDR
                        FROM    dbo.TravelSettleEntertainment
                        WHERE   TravelSettleID = " & QVal(TravelSettleID) & " "
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub InsertSettleEntertain()
        Try
            strQuery = " INSERT  INTO dbo.TravelSettleEntertainment
                                ( TravelSettleID ,
                                  ID ,
                                  Seq ,
                                  AccountID ,
                                  Date ,
                                  EntertainID ,
                                  Description ,
                                  PaymentType ,
                                  CreditCardID ,
                                  CreditCardNumber ,
                                  AccountName ,
                                  CurryID ,
                                  Amount ,
                                  AmountIDR
                                )
                        VALUES  ( " & QVal(TravelSettleID) & " , -- TravelSettleID - char(15)
                                  " & QVal(ID) & " , -- ID - int
                                  " & QVal(Seq) & " , -- Seq - int
                                  " & QVal(AccountID) & " , -- AccountID - varchar(10)
                                  " & QVal(DateEntertain) & " , -- Date - date
                                  " & QVal(EntertainID) & " , -- EntertainID - varchar(15)
                                  " & QVal(Description) & " , -- Description - varchar(50)
                                  " & QVal(PaymentType) & " , -- PaymentType - varchar(11)
                                  " & QVal(CreditCardID) & " , -- CreditCardID - char(5)
                                  " & QVal(CreditCardNumber) & " , -- CreditCardNumber - varchar(20)
                                  " & QVal(AccountName) & " , -- AccountName - varchar(50)
                                  " & QVal(CurryID) & " , -- CurryID - char(3)
                                  " & QVal(Amount) & " , -- Amount - float
                                  " & QVal(AmountIDR) & "  -- AmountIDR - float
                                ) "
            ExecQuery_Solomon(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteSettleEntertain(ByVal _TravelSettID As String)
        Try
            Dim ls_SP As String
            ls_SP = " DELETE  FROM dbo.TravelSettleEntertainment " & vbCrLf &
                    " WHERE   TravelSettleID = " & QVal(_TravelSettID) & " "
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class

Public Class TravelSettleOtherModel
    Public Property TravelSettleID As String
    Public Property ID As Integer
    Public Property Seq As Integer
    Public Property AccountID As String
    Public Property DateOther As Date
    Public Property Description As String
    Public Property PaymentType As String
    Public Property CreditCardID As String
    Public Property CreditCardNumber As String
    Public Property AccountName As String
    Public Property CurryID As String
    Public Property Amount As Double
    Public Property AmountIDR As Double

    Dim strQuery As String

    Public Function GetTravelSettOtherByID() As DataTable
        Try
            strQuery = " SELECT  TravelSettleID ,
                                ID ,
                                AccountID ,
                                '' AS SubAccount ,
                                Date ,
                                Description ,
                                CASE WHEN PaymentType = 'CREDIT CARD'
                                     THEN 'CC-' + ISNULL(CreditCardNumber, '')
                                     ELSE PaymentType
                                END PaymentType ,
                                CreditCardID ,
                                CreditCardNumber ,
                                AccountName ,
                                CurryID ,
                                Amount ,
                                AmountIDR
                        FROM    dbo.TravelSettleOther
                        WHERE   TravelSettleID = " & QVal(TravelSettleID) & " "
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub InsertSettleOther()
        Try
            strQuery = " INSERT  INTO dbo.TravelSettleOther
                                ( TravelSettleID ,
                                  ID ,
                                  Seq ,
                                  AccountID ,
                                  Date ,
                                  Description ,
                                  PaymentType ,
                                  CreditCardID ,
                                  CreditCardNumber ,
                                  AccountName ,
                                  CurryID ,
                                  Amount ,
                                  AmountIDR
                                )
                        VALUES  ( " & QVal(TravelSettleID) & " , -- TravelSettleID - char(15)
                                  " & QVal(ID) & " , -- ID - int
                                  " & QVal(Seq) & " , -- Seq - int
                                  " & QVal(AccountID) & " , -- AccountID - varchar(10)
                                  " & QVal(DateOther) & " , -- Date - date
                                  " & QVal(Description) & " , -- Description - varchar(50)
                                  " & QVal(PaymentType) & " , -- PaymentType - varchar(11)
                                  " & QVal(CreditCardID) & " , -- CreditCardID - char(5)
                                  " & QVal(CreditCardNumber) & " , -- CreditCardNumber - varchar(20)
                                  " & QVal(AccountName) & " , -- AccountName - varchar(50)
                                  " & QVal(CurryID) & " , -- CurryID - char(3)
                                  " & QVal(Amount) & " , -- Amount - float
                                  " & QVal(AmountIDR) & "  -- AmountIDR - float
                                ) "
            ExecQuery_Solomon(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteSettleOther(ByVal _TravelSettID As String)
        Try
            Dim ls_SP As String
            ls_SP = " DELETE  FROM dbo.TravelSettleOther " & vbCrLf &
                    " WHERE   TravelSettleID = " & QVal(_TravelSettID) & " "
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class


