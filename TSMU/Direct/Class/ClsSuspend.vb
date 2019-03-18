Imports System.Collections.ObjectModel
Public Class ClsSuspend
    Dim _Query As String
    Public Property ID() As String
    Public Property subaccount() As String
    Public Property SuspendID() As String
    Public Property AcctID As String
    Public Property SubAcct As String
    Public Property Description As String
    Public Property Nama As String
    Public Property Tempat As String
    Public Property Alamat As String
    Public Property DeptID As String
    Public Property Jenis As String
    Public Property NoKwitansi As String
    Public Property Amount As String
    Public Property Posisi As String
    Public Property Perusahaan As String
    Public Property JenisUsaha As String
    Public Property Remark As String
    Public Property Tgl As String
    Public Property Currency As String
    Public Property PRNo As String
    Public Property Total As String


    Public Sub New()
        Me._Query = "select suspendID,Tgl,deptid,total,remark from suspend_header order by suspendID"
    End Sub
    Public Function GetAllDataTable(ByVal ls_Filter As String) As DataTable
        Try
            'Dim ls_SP As String = "select invtid as [Inventory ID], descr as suspendid,StkUnit as Unit,catalog as [Part No], packing as Packing, min_stok [Min Stok], " & _
            '                        "case kdgrup " & _
            '                            "when 'FG' then 'Finish Good' " & _
            '                            "else 'PURCHASE' end as [Group] " & _
            '                        "from inventory_lc order by Invtid"
            Dim dtTable As New DataTable
            dtTable = GetDataTable_Solomon(Me._Query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetAllDataTable1(ByVal ls_Filter As String) As DataTable
        Try
            'Dim ls_SP As String = "select invtid as [Inventory ID], descr as suspendid,StkUnit as Unit,catalog as [Part No], packing as Packing, min_stok [Min Stok], " & _
            '                        "case kdgrup " & _
            '                            "when 'FG' then 'Finish Good' " & _
            '                            "else 'PURCHASE' end as [Group] " & _
            '                        "from inventory_lc order by Invtid"
            Dim dtTable As New DataTable
            dtTable = GetDataTable_Solomon(Me._Query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetAllData() As DataTable
        Try
            Dim ls_SP As String = "select suspendID,Tgl,Dept,total,remark from suspend_header order by suspendID"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetAccount() As DataTable
        Try
            Dim sql As String = "SELECT 
 	                                RTRIM(Acct) [Account],
	                                RTRIM(Descr) Descritiption
                                FROM dbo.Account"
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
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
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetSubAccountbyid() As DataTable
        Try
            Dim sql As String = "SELECT 
 	                                RTRIM(Consolsub) [SubAccount],
	                                RTRIM(Descr) Descritiption
                                FROM dbo.SubAcct WHERE Consolsub = " & QVal(subaccount) & ""
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub getDataByID(ByVal ID As String)
        Try
            Dim query As String = "select id,suspendID,Tgl,Dept,total,remark from suspend_header WHERE [ID] = " & QVal(ID) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.ID = Trim(.Item("ID") & "")
                    Me.suspendID = Trim(.Item("suspendID") & "")
                End With
            Else
                ID = ""
                suspendID = ""
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub ValidateInsert()
        If Me.suspendID = "" OrElse Me.ID = "" Then
            Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
        End If
        Try
            Dim ls_SP As String = "SELECT TOP 1 ID,suspendID,Tgl,Dept,total,remark where [ID] = " & QVal(ID) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
                "[" & Me.ID & "]")
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

#Region "CRUD"
    Public Sub Insert()
        Try
            Dim ls_SP As String = "INSERT INTO [m_work_center]
                                           ([ID]
                                           ,[suspendid]
                                           ,[Created Date]
                                           ,[Created By])
                                     VALUES
                                           (" & QVal(ID) & " 
                                           ," & QVal(suspendID) & "
                                           ,GETDATE()
                                           ," & QVal(gh_Common.Username) & ")"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Update(ByVal id As String)
        Try
            Dim ls_SP As String = "UPDATE [m_work_center]
                                   SET [suspendid] = " & QVal(suspendID) & "
                                      ,[Updated Date] = GETDATE()
                                      ,[Updated By] = " & QVal(gh_Common.Username) & "
                                    WHERE ID = " & QVal(id) & ""
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Delete(ByVal id As String)
        Try
            Dim ls_SP As String = "DELETE FROM [suspend_header] WHERE ID =" & QVal(suspendID) & ""
            MainModul.ExecQuery(ls_SP)
            Dim ls_SP2 As String = "DELETE FROM [suspend_detail] WHERE ID =" & QVal(suspendID) & ""
            MainModul.ExecQuery(ls_SP2)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertDetails()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO suspend_detail (SubAcct as SubAccount,AcctID as Account,Description,DeptID,Nama,Tempat,Alamat,Jenis,NoKwitansi,Amount) " & vbCrLf &
            "Values(" & QVal(SubAcct) & ", " & vbCrLf &
            "       " & QVal(AcctID) & ", " & vbCrLf &
            "       " & QVal(Description) & ", " & vbCrLf &
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
            "INSERT INTO SuspendRelasi (Nama,Posisi,Perusahaan,JenisUsaha,Remark) " & vbCrLf &
            "Values(" & QVal(Nama) & ", " & vbCrLf &
            "       " & QVal(Posisi) & ", " & vbCrLf &
            "       " & QVal(Perusahaan) & ", " & vbCrLf &
            "       " & QVal(JenisUsaha) & ", " & vbCrLf &
            "       " & QVal(Remark) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub InsertData()
        Try
            Using Conn1 As New SqlClient.SqlConnection(MainModul.GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    MainModul.gh_Trans = New InstanceVariables.TransactionHelper
                    MainModul.gh_Trans.Command.Connection = Conn1
                    MainModul.gh_Trans.Command.Transaction = Trans1
                    Try
                        InsertDetails()
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
            Throw
        End Try
    End Sub

    Public Sub InsertData2()
        Try
            Using Conn1 As New SqlClient.SqlConnection(MainModul.GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    MainModul.gh_Trans = New InstanceVariables.TransactionHelper
                    MainModul.gh_Trans.Command.Connection = Conn1
                    MainModul.gh_Trans.Command.Transaction = Trans1
                    Try
                        InsertRelasi()
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
            Throw
        End Try
    End Sub

    Public Sub InsertSuspendHeader()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO Suspend_Header (SuspendID,Currency,PRNo,Remark,Tgl,Total) " & vbCrLf &
            "Values(" & QVal(SuspendID) & ", " & vbCrLf &
            "       " & QVal(Currency) & ", " & vbCrLf &
            "       " & QVal(PRNo) & ", " & vbCrLf &
            "       " & QVal(Remark) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(Total) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub


#End Region
End Class
