Imports System.Collections.ObjectModel
Public Class ClsSuspend
    Dim _Query As String
    Public Property ID() As String
    Public Property suspendID() As String
    Public Sub New()
        Me._Query = "select suspendID,Tgl,Dept,total_suspend,remark from suspend_header order by suspendID"
    End Sub
    Public Function GetAllDataTable(ByVal ls_Filter As String) As DataTable
        Try
            'Dim ls_SP As String = "select invtid as [Inventory ID], descr as suspendid,StkUnit as Unit,catalog as [Part No], packing as Packing, min_stok [Min Stok], " & _
            '                        "case kdgrup " & _
            '                            "when 'FG' then 'Finish Good' " & _
            '                            "else 'PURCHASE' end as [Group] " & _
            '                        "from inventory_lc order by Invtid"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(Me._Query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetAllData() As DataTable
        Try
            Dim ls_SP As String = "select suspendID,Tgl,Dept,total_suspend,remark from suspend_header order by suspendID"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Sub getDataByID(ByVal ID As String)
        Try
            Dim query As String = "select id,suspendID,Tgl,Dept,total_suspend,remark from suspend_header WHERE [ID] = " & QVal(ID) & ""
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
            Dim ls_SP As String = "SELECT TOP 1 ID,suspendID,Tgl,Dept,total_suspend,remark where [ID] = " & QVal(ID) & ""
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
#End Region
End Class
