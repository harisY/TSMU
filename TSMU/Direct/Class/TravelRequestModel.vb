﻿Imports System.Collections.ObjectModel

Public Class TravelRequestModel
    Public Property NoRequest As String
    Public Property Tanggal As Date
    Public Property DeptID As String
    Public Property TravelType As String
    Public Property NIK As String
    Public Property Nama As String
    Public Property Golongan As Integer
    Public Property Purpose As String
    Public Property Status As String
    Public Property Approved As String
    Public Property Comment As String

    Public Property ObjRequestDetails() As New Collection(Of TravelRequestDetailModel)
    Public Property ObjRequestCost() As New Collection(Of TravelRequestCostModel)

    Dim strQuery As String
    Public Function TravelRequestAutoNo() As String
        Try
            strQuery = " DECLARE @bulan VARCHAR(4) " &
                    " DECLARE @tahun VARCHAR(4) " &
                    " DECLARE @seq VARCHAR(4) " &
                    " SET @bulan = LEFT(CONVERT(CHAR(20), GETDATE(), 101), 2) " &
                    " SET @tahun = DATEPART(YEAR, GETDATE()) " &
                    " SET @seq = ( SELECT RIGHT('0000' " &
                    "                           + CAST(RIGHT(RTRIM(MAX(NoRequest)), 4) + 1 AS VARCHAR), " &
                    "                           4) " &
                    "              From dbo.TravelRequestHeader " &
                    "              WHERE  SUBSTRING(NoRequest, 1, 7) = 'TR' + '-' + RIGHT(@tahun, 4) " &
                    "                     And SUBSTRING(NoRequest, 9, 2) = RIGHT(@bulan, 2) " &
                    "            ) " &
                    " SELECT 'TR' + '-' + RIGHT(@tahun, 4) + '-' + @bulan + '-' + COALESCE(@seq, " &
                    "                                                               '0001') "

            Dim dt As DataTable = New DataTable
            dt = GetDataTable_Solomon(strQuery)
            Return dt.Rows(0).Item(0).ToString

        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function GetTravelRequest() As DataTable
        Try
            Dim aksesView As List(Of String)
            aksesView = GetAksesView()
            aksesView.Add("" & QVal(gh_Common.GroupID) & "")
            Dim nilai = String.Join(",", aksesView.ToArray)

            strQuery = "SELECT  NoRequest ,
                                        NIK ,
                                        Nama ,
                                        Date ,
                                        DeptID ,
                                        TravelType ,
                                        Golongan ,
                                        Purpose ,
                                        Status ,
                                        Approved ,
                                        Comment
                                FROM    dbo.TravelRequestHeader
                                WHERE   Status IN ('PENDING', 'OPEN')
                                        AND DeptID IN (" & nilai & ") "
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetTravelApproved() As DataTable
        Try
            Dim aksesApproval As List(Of String)
            aksesApproval = GetAksesApproval()
            Dim nilai As String = "''"
            If aksesApproval.Count > 0 Then
                nilai = String.Join(",", aksesApproval.ToArray)
            End If
            strQuery = " SELECT NoRequest ,
                                NIK ,
                                Nama ,
                                Date ,
                                DeptID ,
                                TravelType ,
                                Golongan ,
                                Purpose ,
                                Approved ,
                                Comment
                         FROM   dbo.TravelRequestHeader
                         WHERE  Status = 'PENDING'
                                AND ( Approved = ''
                                      OR Approved IS NULL
                                    )
                                AND DeptID IN ( " & nilai & " ) "

            Dim dt As New DataTable
            dt = GetDataTable_Solomon(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetTravelRequestAll() As DataTable
        Try
            Dim aksesApproval As List(Of String)
            aksesApproval = GetAksesView()
            aksesApproval.Add("" & QVal(gh_Common.GroupID) & "")
            Dim nilai = String.Join(",", aksesApproval.ToArray)

            strQuery = "SELECT  NoRequest ,
                                NIK ,
                                Nama ,
                                Date ,
                                DeptID ,
                                TravelType ,
                                Golongan ,
                                Purpose ,
                                Status ,
                                Approved ,
                                Comment
                        FROM    dbo.TravelRequestHeader
                        WHERE   DeptID IN (" & nilai & ")"
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAksesView() As List(Of String)
        Try
            Dim result As New List(Of String)
            Dim dt As New DataTable

            strQuery = " SELECT '''' + RTRIM(taa.DeptID) + '''' DeptID
                         FROM   S_User usr
                                INNER JOIN Travel_Akses_Approval taa ON usr.Username = taa.Username
                         WHERE  IsView = 1
                                AND taa.Username = " & QVal(gh_Common.Username) & " "

            dt = GetDataTable(strQuery)
            For Each row As DataRow In dt.Rows
                result.Add(row("DeptID"))
            Next
            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAksesApproval() As List(Of String)
        Try
            Dim result As New List(Of String)
            Dim dt As New DataTable

            strQuery = " SELECT '''' + RTRIM(taa.DeptID) + '''' DeptID
                         FROM   S_User usr
                                INNER JOIN Travel_Akses_Approval taa ON usr.Username = taa.Username
                         WHERE  taa.IsApprove = 1
                                AND usr.Username = " & QVal(gh_Common.Username) & " "

            dt = GetDataTable(strQuery)
            For Each row As DataRow In dt.Rows
                result.Add(row("DeptID"))
            Next
            Return result
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetRequestHeaderByID(ByVal _NoReq As String) As DataTable
        Try
            strQuery = "SELECT  NoRequest ,
                                NIK ,
                                Nama ,
                                Date ,
                                DeptID ,
                                TravelType ,
                                Golongan ,
                                Purpose ,
                                Status ,
		                        Approved ,
		                        Comment                                        
                        FROM    dbo.TravelRequestHeader
                        WHERE   NoRequest = " & QVal(_NoReq) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(strQuery)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                With dt.Rows(0)
                    Me.NoRequest = Trim(.Item("NoRequest") & "")
                    Me.NIK = Trim(.Item("NIK") & "")
                    Me.Nama = Trim(.Item("Nama") & "")
                    Me.Tanggal = Trim(.Item("Date") & "")
                    Me.DeptID = Trim(.Item("DeptID") & "")
                    Me.TravelType = Trim(.Item("TravelType") & "")
                    Me.Golongan = Trim(.Item("Golongan") & "")
                    Me.Purpose = Trim(.Item("Purpose") & "")
                    Me.Status = Trim(.Item("Status") & "")
                    Me.Approved = Trim(.Item("Approved") & "")
                    Me.Comment = Trim(.Item("Comment") & "")
                End With
            End If
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetListGolongan() As DataTable
        Try
            strQuery = "SELECT DISTINCT
                                Golongan
                        FROM    dbo.TravelPocketAllowance"
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetListNegara(ByVal _travelType As String) As DataTable
        Try
            strQuery = "SELECT  NamaNegara
                        FROM    dbo.TravelNegara
                        WHERE   TravelType = " & QVal(_travelType) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

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

                        For i As Integer = 0 To ObjRequestDetails.Count - 1
                            With ObjRequestDetails(i)
                                .InsertDetails()
                            End With
                        Next

                        For i As Integer = 0 To ObjRequestCost.Count - 1
                            With ObjRequestCost(i)
                                .InsertCost()
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

    Public Sub InsertHeader()
        Try
            Dim dt As New DataTable

            Dim SP_Name As String = "Travel_Insert_TravelRequestHeader"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(9) {}
            pParam(0) = New SqlClient.SqlParameter("@NoRequest", SqlDbType.VarChar)
            pParam(0).Value = NoRequest
            pParam(1) = New SqlClient.SqlParameter("@NIK", SqlDbType.VarChar)
            pParam(1).Value = NIK
            pParam(2) = New SqlClient.SqlParameter("@Nama", SqlDbType.VarChar)
            pParam(2).Value = Nama
            pParam(3) = New SqlClient.SqlParameter("@Tanggal", SqlDbType.Date)
            pParam(3).Value = Date.Today
            pParam(4) = New SqlClient.SqlParameter("@DeptID", SqlDbType.VarChar)
            pParam(4).Value = DeptID
            pParam(5) = New SqlClient.SqlParameter("@TravelType", SqlDbType.VarChar)
            pParam(5).Value = TravelType
            pParam(6) = New SqlClient.SqlParameter("@Golongan", SqlDbType.Int)
            pParam(6).Value = Golongan
            pParam(7) = New SqlClient.SqlParameter("@Purpose", SqlDbType.VarChar)
            pParam(7).Value = Purpose
            pParam(8) = New SqlClient.SqlParameter("@Status", SqlDbType.VarChar)
            pParam(8).Value = Status
            pParam(9) = New SqlClient.SqlParameter("@Username", SqlDbType.VarChar)
            pParam(9).Value = gh_Common.Username

            ExecQueryByCommand_SP_Solomon(SP_Name, pParam)

        Catch ex As Exception
            Throw ex
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
                        UpdateHeader(NoRequest)

                        Dim ObjRequestDetail As New TravelRequestDetailModel
                        ObjRequestDetail.DeleteDetail(NoRequest)

                        For i As Integer = 0 To ObjRequestDetails.Count - 1
                            With ObjRequestDetails(i)
                                .InsertDetails()
                            End With
                        Next

                        Dim _ObjRequestCost As New TravelRequestCostModel
                        _ObjRequestCost.DeleteCost(NoRequest)

                        For i As Integer = 0 To ObjRequestCost.Count - 1
                            With ObjRequestCost(i)
                                .InsertCost()
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

    Public Sub UpdateHeader(ByVal _NoRequest As String)
        Try
            strQuery = " UPDATE  dbo.TravelRequestHeader " & vbCrLf &
                        " SET     NIK = " & QVal(NIK) & " , " & vbCrLf &
                        "         Nama = " & QVal(Nama) & " , " & vbCrLf &
                        "         TravelType = " & QVal(TravelType) & " , " & vbCrLf &
                        "         Golongan = " & QVal(Golongan) & " , " & vbCrLf &
                        "         Purpose = " & QVal(Purpose) & " , " & vbCrLf &
                        "         Status = " & QVal(Status) & " , " & vbCrLf &
                        "         Approved = " & QVal(Approved) & " , " & vbCrLf &
                        "         Comment = " & QVal(Comment) & " , " & vbCrLf &
                        "         UpdatedBy = " & QVal(gh_Common.Username) & " , " & vbCrLf &
                        "         UpdatedDate = GETDATE() " & vbCrLf &
                        " WHERE   NoRequest = " & QVal(_NoRequest) & ""
            ExecQuery_Solomon(strQuery)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateStatusHeader(ByVal _NoRequest As String)
        Try
            strQuery = " UPDATE  dbo.TravelRequestHeader " & vbCrLf &
                        " SET     Approved = " & QVal(Approved) & " , " & vbCrLf &
                        "         Comment = " & QVal(Comment) & " , " & vbCrLf &
                        "         UpdatedBy = " & QVal(gh_Common.Username) & " , " & vbCrLf &
                        "         UpdatedDate = GETDATE() " & vbCrLf &
                        " WHERE   NoRequest = " & QVal(_NoRequest) & " "
            ExecQuery_Solomon(strQuery)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

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
                        query = " DELETE  FROM dbo.TravelRequestHeader " & vbCrLf &
                                " WHERE   NoRequest = " & QVal(Me.NoRequest) & " "
                        MainModul.ExecQuery_Solomon(query)

                        query = " DELETE  FROM dbo.TravelRequestDetail " & vbCrLf &
                                " WHERE   NoRequest = " & QVal(Me.NoRequest) & " "
                        MainModul.ExecQuery_Solomon(query)

                        query = " DELETE  FROM dbo.TravelRequestCost " & vbCrLf &
                                " WHERE   NoRequest = " & QVal(Me.NoRequest) & " "
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

    Public Function GetPocketAllowance(ByVal TravelType__ As String, ByVal Golongan__ As Integer) As DataTable
        Try
            strQuery = " SELECT SUM(tbl.AllowanceUSD) AS AllowanceUSD ,
                                SUM(tbl.AllowanceYEN) AS AllowanceYEN ,
                                SUM(tbl.AllowanceIDR) AS AllowanceIDR ,
                                SUM(DISTINCT tbl.FirstTravel) AS FirstTravel
                         FROM   ( SELECT    CASE WHEN CuryID = 'IDR' THEN Amount
                                                 ELSE 0
                                            END AllowanceIDR ,
                                            CASE WHEN CuryID = 'USD' THEN Amount
                                                 ELSE 0
                                            END AllowanceUSD ,
                                            CASE WHEN CuryID = 'YEN' THEN Amount
                                                 ELSE 0
                                            END AllowanceYEN ,
                                            FirstTravel
                                  FROM      dbo.TravelPocketAllowance
                                  WHERE     TravelType = " & QVal(TravelType__) & "
                                            AND Golongan = " & QVal(Golongan__) & "
                                ) AS tbl "
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetFirstTravel(ByVal nik As String, ByVal traveltype As String, ByVal tahun As String) As Boolean
        Try
            strQuery = " IF " & QVal(traveltype) & " = 'DN'
                            BEGIN
                                SELECT  CAST(0 AS BIT) AS FirstTravel;
                            END
                         ELSE
                            BEGIN
                                SELECT  CASE WHEN EXISTS ( SELECT   trh.NoRequest
                                                           FROM     dbo.TravelRequestHeader AS trh
                                                                    INNER JOIN dbo.TravelRequestDetail trd ON trd.NoRequest = trh.NoRequest
                                                           WHERE    trh.NIK = " & QVal(nik) & "
                                                                    AND trh.TravelType = " & QVal(traveltype) & "
                                                           GROUP BY trh.NoRequest
                                                           HAVING   YEAR(MIN(trd.DepartureDate)) = " & QVal(tahun) & " )
                                             THEN CAST(0 AS BIT)
                                             ELSE CAST(1 AS BIT)
                                        END FirstTravel
                            END "
            Dim value As Boolean
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(strQuery)
            If dt.Rows.Count > 0 Then
                value = dt.Rows(0).Item(0)
            End If
            Return value
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetListTraveler() As DataTable
        Try
            strQuery = "SELECT  *
                        FROM    dbo.Traveler"
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class

Public Class TravelRequestDetailModel
    Public Property NoRequest As String
    Public Property Seq As Integer
    Public Property Negara As String
    Public Property NoPaspor As String
    Public Property Visa As String
    Public Property Destination As String
    Public Property DepartureDate As Date
    Public Property ArrivalDate As Date

    Dim strQuery As String

    Public Function GetDetailByID() As DataTable
        Try
            Dim sql As String = " SELECT  Destination ,
                                        Negara ,
                                        DepartureDate ,
                                        NoPaspor ,
                                        Visa ,
                                        ArrivalDate
                                FROM    dbo.TravelRequestDetail
                                WHERE   NoRequest = " & QVal(NoRequest) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetVisa(ByVal nik As String, negara As String, deptDate As Date, ArrivDate As Date) As String
        Try
            Dim hasil As String = String.Empty
            strQuery = "SELECT  NoVisa
                        FROM    dbo.TravelerVisa
                        WHERE   NIK = " & QVal(nik) & "
                                AND Negara = " & QVal(negara) & "
                                AND DateIssued <= " & QVal(deptDate) & "
                                AND DateExpired >= " & QVal(ArrivDate) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(strQuery)
            If dt.Rows.Count > 0 Then
                hasil = dt.Rows(0).Item(0).ToString()
            End If
            Return hasil
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetPaspor(ByVal nik As String, deptDate As Date, ArrivDate As Date) As DataTable
        Try
            strQuery = "SELECT  Ada.NIK ,
                                ISNULL(Expired.NoPaspor, '') AS NoPaspor ,
                                CASE WHEN Expired.NIK IS NULL THEN 'YES'
                                     ELSE 'NO'
                                END AS Expired
                        FROM    dbo.TravelerPaspor AS Ada
                                LEFT JOIN ( SELECT  NIK ,
                                                    NoPaspor
                                            FROM    dbo.TravelerPaspor
                                            WHERE   NIK = " & QVal(nik) & "
                                                    AND TanggalKeluar <= CAST(" & QVal(deptDate) & " AS DATE)
                                                    AND ExpiredDate >= CAST(" & QVal(ArrivDate) & " AS DATE)
                                          ) AS Expired ON Expired.NIK = Ada.NIK
                                                          AND Expired.NoPaspor = Ada.NoPaspor
                        WHERE   Ada.NIK = " & QVal(nik) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub InsertDetails()
        Try
            Dim ls_SP As String
            ls_SP = " INSERT INTO [dbo].[TravelRequestDetail] " & vbCrLf &
                    "            ([NoRequest] " & vbCrLf &
                    "            ,[Seq] " & vbCrLf &
                    "            ,[Destination] " & vbCrLf &
                    "            ,[Negara] " & vbCrLf &
                    "            ,[Visa] " & vbCrLf &
                    "            ,[DepartureDate] " & vbCrLf &
                    "            ,[ArrivalDate]) " & vbCrLf &
                    "      VALUES " & vbCrLf &
                    "            (" & QVal(NoRequest) & ", " & vbCrLf &
                    "            " & QVal(Seq) & ", " & vbCrLf &
                    "            " & QVal(Destination) & ", " & vbCrLf &
                    "            " & QVal(Negara) & ", " & vbCrLf &
                    "            " & QVal(Visa) & ", " & vbCrLf &
                    "            " & QVal(DepartureDate) & ", " & vbCrLf &
                    "            " & QVal(ArrivalDate) & ")"

            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteDetail(ByVal _NoRequest As String)
        Try
            Dim ls_SP As String = " DELETE  FROM dbo.TravelRequestDetail
                                    WHERE   NoRequest = " & QVal(_NoRequest.TrimEnd) & ""
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class

Public Class TravelRequestCostModel
    Public Property NoRequest As String
    Public Property Description As String
    Public Property CostType As String
    Public Property Days As Integer
    Public Property AdvanceIDR As String
    Public Property AdvanceUSD As Double
    Public Property AdvanceYEN As Double

    Public Function GetCostByID() As DataTable
        Try
            Dim sql As String = " SELECT  NoRequest ,
                                            CostType ,
                                            Description ,
                                            Days ,
                                            AdvanceIDR ,
                                            AdvanceUSD ,
                                            0 AS AdvanceIDRUSD ,
                                            AdvanceYEN ,
                                            0 AS AdvanceIDRYEN ,
                                            0 AS RateAdvanceIDR ,
                                            0 AS TotalAdvanceIDR
                                    FROM    dbo.TravelRequestCost
                                    WHERE   NoRequest = " & QVal(NoRequest) & " "
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub InsertCost()
        Try
            Dim ls_SP As String
            ls_SP = " INSERT  INTO dbo.TravelRequestCost " & vbCrLf &
                    "         ( NoRequest , " & vbCrLf &
                    "           CostType , " & vbCrLf &
                    "           Description , " & vbCrLf &
                    "           Days , " & vbCrLf &
                    "           AdvanceIDR , " & vbCrLf &
                    "           AdvanceUSD , " & vbCrLf &
                    "           AdvanceYEN " & vbCrLf &
                    "         ) " & vbCrLf &
                    " VALUES( " & QVal(NoRequest) & " ,  " & vbCrLf &
                    "           " & QVal(CostType) & " ,  " & vbCrLf &
                    "           " & QVal(Description) & " ,  " & vbCrLf &
                    "           " & QVal(Days) & " ,  " & vbCrLf &
                    "           " & QVal(AdvanceIDR) & " ,  " & vbCrLf &
                    "           " & QVal(AdvanceUSD) & " ,  " & vbCrLf &
                    "           " & QVal(AdvanceYEN) & "   " & vbCrLf &
                    "         ) "
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteCost(ByVal _NoRequest As String)
        Try
            Dim ls_SP As String = " DELETE  FROM dbo.TravelRequestCost
                                    WHERE   NoRequest = " & QVal(_NoRequest.TrimEnd) & ""
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class
