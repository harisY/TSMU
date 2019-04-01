Imports System.Collections.ObjectModel

Public Class TravelHeaderModel
    Public Property DeptID As String
    Public Property Destination As String
    Public Property ID As Integer
    Public Property Nama As String
    Public Property PickUp As String
    Public Property Purpose As String
    Public Property Term As String
    Public Property TotalAdvanceBudget As Double
    Public Property TravelID As String
    Public Property Visa As String
    Public Property Tgl As DateTime
    Public Property ObjDetails() As New Collection(Of TravelDetailModel)
    Public Function GetDataGrid() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
            "SELECT ID      ,TravelID      ,Nama      ,Destination      ,Term      ,Purpose      ,DeptID      ,PickUp      ,Visa      ,TotalAdvanceBudget,Tgl  FROM TravelHeader"
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function SuspendAutoNo() As String

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

    Public Sub GetSuspenById()
        Try
            Dim sql As String =
            "SELECT ID,TravelID      ,Nama      ,Destination      ,Term      ,Purpose      ,DeptID      ,PickUp      ,Visa      ,TotalAdvanceBudget,Tgl    FROM TravelHeader where ID=" & QVal(ID) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            If dt.Rows.Count > 0 Then
                ID = If(IsDBNull(dt.Rows(0).Item("ID")), "", Trim(dt.Rows(0).Item("ID").ToString()))
                TravelID = If(IsDBNull(dt.Rows(0).Item("TravelID")), "", Trim(dt.Rows(0).Item("TravelID").ToString()))
                DeptID = If(IsDBNull(dt.Rows(0).Item("DeptID")), "", Trim(dt.Rows(0).Item("DeptID").ToString()))
                Nama = If(IsDBNull(dt.Rows(0).Item("Nama")), "", Trim(dt.Rows(0).Item("Nama").ToString()))
                Destination = If(IsDBNull(dt.Rows(0).Item("Destination")), "", Trim(dt.Rows(0).Item("Destination").ToString()))
                Tgl = If(IsDBNull(dt.Rows(0).Item("Tgl")), DateTime.Today, Convert.ToDateTime(dt.Rows(0).Item("Tgl")))
                Term = If(IsDBNull(dt.Rows(0).Item("Term")), "", Trim(dt.Rows(0).Item("Term").ToString()))
                TotalAdvanceBudget = If(IsDBNull(dt.Rows(0).Item("TotalAdvanceBudget")), 0, Convert.ToDouble(dt.Rows(0).Item("TotalAdvanceBudget")))
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

    Public Function GetAccount() As DataTable
        Try
            Dim sql As String = "SELECT 
 	                                RTRIM(Acct) [Account],
	                                RTRIM(Descr) Descritiption
                                FROM dbo.Account"
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
            "INSERT INTO TravelHeader (TravelID      ,Nama      ,Destination      ,Term      ,Purpose      ,DeptID      ,PickUp      ,Visa      ,TotalAdvanceBudget, CreatedBy, CreatedDate,Tgl) " & vbCrLf &
            "Values(" & QVal(TravelID) & ", " & vbCrLf &
            "       " & QVal(Nama) & ", " & vbCrLf &
            "       " & QVal(Destination) & ", " & vbCrLf &
            "       " & QVal(Term) & ", " & vbCrLf &
            "       " & QVal(Purpose) & ", " & vbCrLf &
            "       " & QVal(DeptID) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(PickUp) & ", " & vbCrLf &
            "       " & QVal(Visa) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(TotalAdvanceBudget) & ", " & vbCrLf &
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
                                    "      ,TotalAdvanceBudget = " & QVal(TotalAdvanceBudget) & ", " & vbCrLf &
                                    "      ,Tgl = " & QVal(Tgl) & ", " & vbCrLf &
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

    Public Sub InsertDataRelasi()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        ''InsertHeader()

                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
                                .InsertRelasi()
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

                        Dim ObjSuspendDetail As New SuspendDetailModel
                        ObjSuspendDetail.DeleteDetail(_TravelID)

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

    Public Sub UpdateDataRelasi()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        UpdateHeader(TravelID)

                        Dim ObjSuspendDetail As New SuspendDetailModel
                        ObjSuspendDetail.DeleteDetail(TravelID)

                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
                                .InsertRelasi()
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
    Public Property AcctID As String
    Public Property Alamat As String
    Public Property Amount As Double
    Public Property DeptID As String
    Public Property Description As String
    Public Property Jenis As String
    Public Property Nama As String
    Public Property NoKwitansi As String
    Public Property SubAcct As String
    Public Property SuspendDetailID As Integer
    Public Property TravelID As String
    Public Property Tempat As String
    Public Property Tgl As Date
    Public Property Posisi As String
    Public Property Perusahaan As String
    Public Property JenisUSaha As String
    Public Property Remark As String

    Public Sub InsertDetails()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO suspend_detail (TravelID,SubAcct,AcctID,Description,Tgl,DeptID,Nama,Tempat,Alamat,Jenis,NoKwitansi,Amount ) " & vbCrLf &
            "Values(" & QVal(TravelID) & ", " & vbCrLf &
            "       " & QVal(SubAcct) & ", " & vbCrLf &
            "       " & QVal(AcctID) & ", " & vbCrLf &
            "       " & QVal(Description) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(DeptID) & ", " & vbCrLf &
            "       " & QVal(Nama) & ", " & vbCrLf &
            "       " & QVal(Tempat) & ", " & vbCrLf &
            "       " & QVal(Alamat) & ", " & vbCrLf &
            "       " & QVal(Jenis) & ", " & vbCrLf &
            "       " & QVal(NoKwitansi) & ", " & vbCrLf &
            "       " & QVal(Amount) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertRelasi()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO SuspendRelasi (TravelID,Nama,Posisi,Perusahaan,JenisUsaha,Remark ) " & vbCrLf &
            "Values(" & QVal(TravelID) & ", " & vbCrLf &
            "       " & QVal(Nama) & ", " & vbCrLf &
            "       " & QVal(Posisi) & ", " & vbCrLf &
            "       " & QVal(Perusahaan) & ", " & vbCrLf &
            "       " & QVal(JenisUSaha) & ", " & vbCrLf &
            "       " & QVal(Remark) & ")"
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
