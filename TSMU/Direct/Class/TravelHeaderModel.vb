Imports System.Collections.ObjectModel

Public Class TravelHeaderModel
    Public Property TravelHeaderID As Integer
    Public Property DeptID As String
    Public Property Destination As String
    ' Public Property ID As Integer
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
            Dim query As String = "DELETE FROM TravelHeader" & vbCrLf &
            "WHERE Travelid = " & QVal(Me._id) & " "
            Dim li_Row = MainModul.ExecQuery_Solomon(query)

            Dim query1 As String = "DELETE FROM Travel_detail " & vbCrLf &
            "WHERE Travelid = " & QVal(Me._id) & " "
            Dim li_Row1 = MainModul.ExecQuery_Solomon(query1)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Property ObjDetails() As New Collection(Of TravelDetailModel)
    Public Function GetDataGrid() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
            "SELECT TravelHeaderID      ,TravelID      ,Nama      ,Destination      ,Term      ,Purpose      ,DeptID      ,PickUp      ,Visa      ,TotalAdvanceIDR,TotalAdvanceYEN,TotalAdvanceUSD,TotalAdvIDR,Tgl,TglBerangkat,TglTiba  FROM TravelHeader"
            dt = GetDataTable_Solomon(sql)
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
                DeptID = If(IsDBNull(dt.Rows(0).Item("DeptID")), "", Trim(dt.Rows(0).Item("DeptID").ToString()))
                Nama = If(IsDBNull(dt.Rows(0).Item("Nama")), "", Trim(dt.Rows(0).Item("Nama").ToString()))
                Destination = If(IsDBNull(dt.Rows(0).Item("Destination")), "", Trim(dt.Rows(0).Item("Destination").ToString()))
                Tgl = If(IsDBNull(dt.Rows(0).Item("Tgl")), DateTime.Today, Convert.ToDateTime(dt.Rows(0).Item("Tgl")))
                Depdate = If(IsDBNull(dt.Rows(0).Item("TglBerangkat")), DateTime.Today, Convert.ToDateTime(dt.Rows(0).Item("Tgl")))
                Arrdate = If(IsDBNull(dt.Rows(0).Item("TglTiba")), DateTime.Today, Convert.ToDateTime(dt.Rows(0).Item("Tgl")))
                Term = If(IsDBNull(dt.Rows(0).Item("Term")), "", Trim(dt.Rows(0).Item("Term").ToString()))
                TotalAdvanceIDR = If(IsDBNull(dt.Rows(0).Item("TotalAdvanceIDR")), 0, Convert.ToDouble(dt.Rows(0).Item("TotalAdvanceIDR")))
                TotalAdvanceUSD = If(IsDBNull(dt.Rows(0).Item("TotalAdvanceUSD")), 0, Convert.ToDouble(dt.Rows(0).Item("TotalAdvanceUSD")))
                TotalAdvanceYEN = If(IsDBNull(dt.Rows(0).Item("TotalAdvanceYEN")), 0, Convert.ToDouble(dt.Rows(0).Item("TotalAdvanceYEN")))
                TotalAdvIDR = If(IsDBNull(dt.Rows(0).Item("TotalAdvIDR")), 0, Convert.ToDouble(dt.Rows(0).Item("TotalAdvanceIDR")))
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
    Public Function GetTraveller() As DataTable
        Try
            Dim sql As String =
            "SELECT  [Nama]
      ,[DeptID]
      ,[VisaNo]
      ,[VisaExpDate]
      ,[PassNo]
      ,[PassExpDate]
  FROM [Traveller]"
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetAccount() As DataTable
        Try
            Dim sql As String = "SELECT 
 	                                RTRIM(Acct) [Account],
	                                RTRIM(Descr) Descritiption
                                FROM dbo.Account where substring(Acct,1,1)='5' or  substring(Acct,1,1)='6'"
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
            Dim ls_SP As String = " " & vbCrLf &
                                    "UPDATE TravelHeader " & vbCrLf &
                                    "      ,Nama = " & QVal(Nama) & ", " & vbCrLf &
                                    "      ,Destination = " & QVal(Destination) & ", " & vbCrLf &
                                    "      ,Term = " & QVal(Term) & ", " & vbCrLf &
                                    "      ,Purpose = " & QVal(Purpose) & ", " & vbCrLf &
                                    "      ,DeptID = " & QVal(DeptID) & ", " & vbCrLf &
                                    "      ,PickUp = " & QVal(PickUp) & ", " & vbCrLf &
                                    "      ,Visa = " & QVal(Visa) & ", " & vbCrLf &
                                    "      ,TotalAdvanceIDR = " & QVal(TotalAdvanceIDR) & ", " & vbCrLf &
                                    "      ,TotalAdvanceYEN = " & QVal(TotalAdvanceYEN) & ", " & vbCrLf &
                                    "      ,TotalAdvanceUSD = " & QVal(TotalAdvanceUSD) & ", " & vbCrLf &
                                    "      ,TotalAdvIDR = " & QVal(TotalAdvIDR) & ", " & vbCrLf &
                                    "      ,Tgl = " & QVal(Tgl) & ", " & vbCrLf &
                                    "      ,TglBerangkat = " & QVal(Depdate) & ", " & vbCrLf &
                                    "      ,TglTiba = " & QVal(Arrdate) & ", " & vbCrLf &
                                    "       UpdatedBy = " & QVal(gh_Common.Username) & ", " & vbCrLf &
                                    "       UpdatedDate = GETDATE() WHERE TravelID = '" & TravelID & "'"
            ExecQuery(ls_SP)
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

                        UpdateHeader(_TravelID)

                        Dim ObjTravelDetail As New TravelDetailModel
                        ObjTravelDetail.DeleteDetail(_TravelID)

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


End Class
Public Class TravelDetailModel
    Public Property TravelID As String
    Public Property AcctID As String
    Public Property SubAcct As String
    Public Property Description As String
    Public Property CuryID As String
    Public Property Amount As Double
    Public Property Rate As String
    Public Property AmountIDR As Double
    Public Property TravelDetailID As Integer


    Public Sub InsertDetails()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO TravelDetail (TravelID,SubAcct,AcctID,Description,Amount,CuryID,Rate,AmountIDR ) " & vbCrLf &
            "Values(" & QVal(TravelID) & ", " & vbCrLf &
            "       " & QVal(SubAcct) & ", " & vbCrLf &
            "       " & QVal(AcctID) & ", " & vbCrLf &
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
            Dim ls_SP As String = "DELETE FROM suspend_detail WHERE rtrim(TravelID)=" & QVal(_TravelID.TrimEnd) & ""
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
            Dim sql As String = "SELECT ID
      ,AcctID Account
      ,SubAcct SubAccount
      ,Description
      ,Amount
      ,CuryID
      ,Rate
      ,AmountIDR
  FROM TempTravel"

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
  FROM TempTravel where Description='TICKET' "

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
            Dim sql As String = "SELECT 
      AcctID Account
      ,SubAcct SubAccount
      ,Description
      ,Amount
      ,CuryID
      ,Rate
      ,AmountIDR
  FROM TravelDetail WHERE TravelID = " & QVal(TravelID) & ""

            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
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
