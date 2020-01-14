Imports System.Collections.ObjectModel
Public Class NonProduksiModel

    Public Property H_IDTransaksi() As String
    Public Property H_Tanggal() As String
    Public Property H_Dept() As String
    Public Property D_IDTransaksi() As String
    Public Property D_Informasi() As String
    Public Property D_Duedate() As Date
    Public Property D_PIC() As String
    Public Property IDTrans As String
    Dim _Query As String

    Public Property ObjDetailNonProduksi() As New Collection(Of NonProduksiDetailModel)


    Public Sub New()
        Me._Query = "SELECT [IDTransaksi] as IDTransaksi
                   ,[Tanggal] as Tanggal
                   ,[Dept] as Dept
              FROM AsakaiOtherDept"
    End Sub

    Public Function GetAllDataTable(ByVal ls_Filter As String) As DataTable
        Try
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand_sol(Me._Query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetDataLoad() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
            "SELECT [IDTransaksi] as IDTransaksi
                   ,[Tanggal] as Tanggal
                   ,[Dept] as Dept
              FROM AsakaiOtherDept"
            'dt = GetDataTableByCommand(sql)
            dt = GetDataTableByCommand_sol(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub DeleteHeader(ByVal ID As String)
        Try

            Dim ls_SP As String = "DELETE FROM AsakaiOtherDept WHERE rtrim(IDTransaksi)=" & QVal(ID) & ""
            'MainModul.ExecQuery(ls_SP)
            MainModul.ExecQuery_Solomon(ls_SP)

            Dim ls_SPD As String = "DELETE FROM AsakaiOtherDeptDetail WHERE rtrim(IDTransaksi)=" & QVal(ID) & ""
            'MainModul.ExecQuery(ls_SP)
            MainModul.ExecQuery_Solomon(ls_SPD)

        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub GetData(ID As String)
        Try
            Dim query As String = "SELECT AsakaiOtherDeptDetail.[IDTransaksi] as IDTransaksi
                                  ,AsakaiOtherDeptDetail.[Informasi] as Informasi
                                  ,AsakaiOtherDeptDetail.[Duedate] as DueDate
                                  ,AsakaiOtherDeptDetail.[PIC] as PIC
                                  ,AsakaiOtherDept.[Tanggal]  as Tanggal
                                  ,AsakaiOtherDept.[Dept] as Dept
                              FROM AsakaiOtherDeptDetail inner join AsakaiOtherDept
                                    on AsakaiOtherDeptDetail.IDTransaksi = AsakaiOtherDept.IDTransaksi 
                                    WHERE AsakaiOtherDeptDetail.[IDTransaksi] = " & QVal(ID) & ""
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(query)
            dtTable = MainModul.GetDataTableByCommand_sol(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.H_Tanggal = Trim(.Item("Tanggal") & "")
                    Me.D_Duedate = Trim(.Item("DueDate") & "")
                End With
            End If
        Catch ex As Exception
            Throw
        End Try

    End Sub

    Public Function GetDataDetailNonProduksi(ID As String) As DataTable
        Try
            Dim query As String = "SELECT [Informasi] as INFORMASI
                                  ,[Duedate] as DUEDATE
                                  ,[PIC] as PIC
                              FROM AsakaiOtherDeptDetail inner join AsakaiOtherDept
                                    on AsakaiOtherDeptDetail.IDTransaksi = AsakaiOtherDept.IDTransaksi 
                                    WHERE AsakaiOtherDeptDetail.[IDTransaksi] = " & QVal(ID) & ""
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(query)
            dtTable = MainModul.GetDataTableByCommand_sol(query)

            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub GetIDTransAuto()
        Try
            Dim Tahun As String
            Tahun = Format(Now, "yy")

            Dim ls_SP As String = "SELECT [IDTransaksi] FROM [AsakaiOtherDept] order by IDTransaksi desc" 'where IDTrans= " & QVal(IDTrans) & " or TanggalSampai = '" & TanggalDari & "' "
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand_sol(ls_SP)
            Dim Ulang As String = Tahun
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count <= 0 Then
                IDTrans = "NP" & Tahun & "0001"
            Else
                IDTrans = dtTable.Rows(0).Item("IDTransaksi")
                IDTrans = Microsoft.VisualBasic.Mid(IDTrans, 3, 2)
                If IDTrans <> Ulang Then
                    IDTrans = "NP" & Tahun & "0001"
                Else
                    IDTrans = dtTable.Rows(0).Item("IDTransaksi")
                    IDTrans = Val(Microsoft.VisualBasic.Mid(IDTrans, 5, 4)) + 1
                    If Len(IDTrans) = 1 Then
                        IDTrans = "NP" & Tahun & "000" & IDTrans & ""
                    ElseIf Len(IDTrans) = 2 Then
                        IDTrans = "NP" & Tahun & "00" & IDTrans & ""
                    ElseIf Len(IDTrans) = 3 Then
                        IDTrans = "NP" & Tahun & "0" & IDTrans & ""
                    Else
                        IDTrans = "NP" & Tahun & IDTrans & ""
                    End If

                End If

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertData(IdTransaksi As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        InsertHeader(IdTransaksi)
                        For i As Integer = 0 To ObjDetailNonProduksi.Count - 1
                            With ObjDetailNonProduksi(i)
                                .InsertDetail(IdTransaksi)
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

    Public Sub InsertHeader(idTransaksi As String)
        Dim result As Integer = 0
        Try


            Dim ls_SP As String = "INSERT INTO AsakaiOtherDept
                                           ([IDTransaksi]
                                           ,[Tanggal]
                                           ,[Dept]
                                           ,[CreatedBy]
                                           ,[CreatedDate])
                                     VALUES 
                                            (" & QVal(H_IDTransaksi) & " 
                                             ," & QVal(H_Tanggal) & "
                                             ," & QVal(gh_Common.GroupID) & "
                                             ," & QVal(gh_Common.Username) & "
                                             ,GETDATE())"

            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand_sol(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub ValidateInsert()
        Try
            Dim ls_SP As String = "SELECT TOP 1 [IDTransaksi]                  
                                    FROM [AsakaiOtherDept] where IDTransaksi = '" & H_IDTransaksi & "' "
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(ls_SP)
            dtTable = MainModul.GetDataTableByCommand_sol(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
                "[" & (Me.H_IDTransaksi) & "]")
            Else

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub UpdateData(IdTransaksi As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        UpdateHeader(IdTransaksi)
                        DeleteDetail(IdTransaksi)

                        For i As Integer = 0 To ObjDetailNonProduksi.Count - 1
                            With ObjDetailNonProduksi(i)
                                .InsertDetail(IdTransaksi)
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
    Public Sub UpdateHeader(ByVal _IDTrans As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "UPDATE AsakaiOtherDept" & vbCrLf &
                                    "SET Tanggal = " & QVal(H_Tanggal) & ", " & vbCrLf &
                                    "Dept = " & QVal(gh_Common.GroupID) & ", " & vbCrLf &
                                    "UpdatedBy = " & QVal(gh_Common.Username) & ", " & vbCrLf &
                                    "UpdatedDate = GETDATE() WHERE IDTransaksi = '" & _IDTrans & "'"
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteDetail(ByVal ID As String)
        Try
            'DeleteDetail
            Dim ls_DeleteDetail As String = "DELETE FROM AsakaiOtherDeptDetail WHERE rtrim(IDTransaksi)=" & QVal(ID) & ""
            MainModul.ExecQuery_Solomon(ls_DeleteDetail)

        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class

Public Class NonProduksiDetailModel

    Public Property D_IDTransaksi() As String
    Public Property D_Informasi() As String
    Public Property D_Duedate() As Date
    Public Property D_PIC() As String

    Public Sub InsertDetail(IDTrans)
        Try

            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO [AsakaiOtherDeptDetail]
                   ([IDTransaksi]
                   ,[Informasi]
                   ,[Duedate]
                   ,[PIC]) " & vbCrLf &
            "Values(" & QVal(D_IDTransaksi) & ", " & vbCrLf &
            "       " & QVal(D_Informasi) & ", " & vbCrLf &
            "       " & QVal(D_Duedate) & ", " & vbCrLf &
            "       " & QVal(D_PIC) & ")"
            'ExecQuery(ls_SP)
            ExecQuery_Solomon(ls_SP)

        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class
