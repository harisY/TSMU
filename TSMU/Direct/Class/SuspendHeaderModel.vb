Imports System.Collections.ObjectModel

Public Class SuspendHeaderModel
    Public Property cekno As String
    Public Property deptid As String
    Public Property id As Integer
    Public Property paid As String
    Public Property pay As Double
    Public Property prno As String
    Public Property remark As String
    Public Property status As String
    Public Property suspendid As String
    Public Property tgl As DateTime
    Public Property tot As Double
    Public Property ObjDetails() As New Collection(Of SuspendDetailModel)
    Public Function GetDataGrid() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
            "SELECT [id]
                ,[suspendid]
                ,[paid]
                ,[deptid]
                ,[prno]
                ,[cekno]
                ,[remark]
            FROM [suspend_header] Order by suspendid Desc"
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub GetSuspenById()
        Try
            Dim sql As String =
            "SELECT [id]
                ,[suspendid]
                ,[paid]
                ,[deptid]
                ,[prno]
                ,[cekno]
                ,[remark]
                ,[tgl]
                ,[status]
                ,[tot]
                ,[pay]
            FROM [suspend_header] where id=" & QVal(id) & ""
            Dim dt As New DataTable
            dt = GetDataTable_Solomon(sql)
            If dt.Rows.Count > 0 Then
                id = If(IsDBNull(dt.Rows(0).Item("id")), "", Trim(dt.Rows(0).Item("id").ToString()))
                suspendid = If(IsDBNull(dt.Rows(0).Item("suspendid")), "", Trim(dt.Rows(0).Item("suspendid").ToString()))
                paid = If(IsDBNull(dt.Rows(0).Item("paid")), "", Trim(dt.Rows(0).Item("paid").ToString()))
                deptid = If(IsDBNull(dt.Rows(0).Item("deptid")), "", Trim(dt.Rows(0).Item("deptid").ToString()))
                prno = If(IsDBNull(dt.Rows(0).Item("prno")), "", Trim(dt.Rows(0).Item("prno").ToString()))
                cekno = If(IsDBNull(dt.Rows(0).Item("cekno")), "", Trim(dt.Rows(0).Item("cekno").ToString()))
                remark = If(IsDBNull(dt.Rows(0).Item("remark")), "", Trim(dt.Rows(0).Item("remark").ToString()))
                tgl = If(IsDBNull(dt.Rows(0).Item("tgl")), DateTime.Today, Convert.ToDateTime(dt.Rows(0).Item("tgl")))
                status = If(IsDBNull(dt.Rows(0).Item("status")), "", Trim(dt.Rows(0).Item("status").ToString()))
                tot = If(IsDBNull(dt.Rows(0).Item("tot")), 0, Double.Parse(dt.Rows(0).Item("tot")))
                pay = If(IsDBNull(dt.Rows(0).Item("pay")), 0, Double.Parse(dt.Rows(0).Item("pay")))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub InsertHeader()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO suspend_header (cekno,deptid,paid,pay,prno,remark,status,suspendid,tgl,tot) " & vbCrLf &
            "Values(" & QVal(cekno) & ", " & vbCrLf &
            "       " & QVal(deptid) & ", " & vbCrLf &
            "       " & QVal(deptid) & ", " & vbCrLf &
            "       " & QVal(paid) & ", " & vbCrLf &
            "       " & QVal(pay) & ", " & vbCrLf &
            "       " & QVal(prno) & ", " & vbCrLf &
            "       " & QVal(remark) & ", " & vbCrLf &
            "       " & QVal(status) & ", " & vbCrLf &
            "       " & QVal(suspendid) & ", " & vbCrLf &
            "       " & QVal(tgl) & ", " & vbCrLf &
            "       " & QVal(tot) & ")"
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
                        MainModul.gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
Public Class SuspendDetailModel
    Public Property account As String
    Public Property acctid As String
    Public Property alamat As String
    Public Property descr As String
    Public Property id As Integer
    Public Property jenis As String
    Public Property jml As Double
    Public Property nama As String
    Public Property sub_account As String
    Public Property subacctid As String
    Public Property suspendid As String
    Public Property tempat As String
    Public Property tgl As String

    Public Sub InsertDetails()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO suspend_detail (account,acctid,descr,jenis,jml,nama,sub_account,subacctid,suspendid,tempat,tgl) " & vbCrLf &
            "Values(" & QVal(account) & ", " & vbCrLf &
            "       " & QVal(acctid) & ", " & vbCrLf &
            "       " & QVal(descr) & ", " & vbCrLf &
            "       " & QVal(jenis) & ", " & vbCrLf &
            "       " & QVal(jml) & ", " & vbCrLf &
            "       " & QVal(nama) & ", " & vbCrLf &
            "       " & QVal(sub_account) & ", " & vbCrLf &
            "       " & QVal(subacctid) & ", " & vbCrLf &
            "       " & QVal(suspendid) & ", " & vbCrLf &
            "       " & QVal(tempat) & ", " & vbCrLf &
            "       " & QVal(tgl) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class
