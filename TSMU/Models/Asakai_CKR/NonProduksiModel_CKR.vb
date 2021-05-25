Imports System.Collections.ObjectModel
Public Class NonProduksiModel_CKR

    Public Property H_IDTransaksi() As String
    Public Property H_Tanggal() As String
    Public Property H_Dept() As String
    Public Property D_IDTransaksi() As String
    Public Property D_Informasi() As String
    Public Property D_Gambar() As String
    Public Property D_PIC() As String
    Public Property IDTrans As String
    Dim _Query As String

    Public Property ObjDetailNonProduksi() As New Collection(Of NonProduksiDetailModel_CKR)


    Public Sub New()
        Me._Query = "SELECT [IDTransaksi] as IDTransaksi
                   ,[Tanggal] as Tanggal
                   ,[Dept] as Dept
              FROM AsakaiOtherDept "
    End Sub

    Public Function GetAllDataTable(ByVal ls_Filter As String) As DataTable
        Try
            Dim dtTable As New DataTable
            dtTable = GetDataTableByCommand(Me._Query)
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
                   ,Convert (Varchar,Tanggal,105) as Tanggal
                   ,[Dept] as Dept
              FROM AsakaiOtherDept Where Dept = '" & gh_Common.GroupID & "'"
            'dt = GetDataTableByCommand(sql)
            'dt = GetDataTableByCommand(sql)
            dt = GetDataTableByParam(sql, CommandType.Text, Nothing, GetConnStringDbCKR)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataLoad_CKR() As DataTable
        Try
            'Dim dt As New DataTable
            'Dim sql As String =
            '"SELECT [IDTransaksi] as IDTransaksi
            '       ,Convert (Varchar,Tanggal,105) as Tanggal
            '       ,[Dept] as Dept
            '  FROM AsakaiOtherDept Where Dept = '" & gh_Common.GroupID & "'"
            ''dt = GetDataTableByCommand(sql)
            'dt = GetDataTableByCommand_SP_Tsc(sql)

            Dim query As String = "[Asakai_Nonproduksi_GetDataHeader_CKR]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@deptID", SqlDbType.VarChar)

            pParam(0).Value = gh_Common.GroupID


            Dim dt As New DataTable
            dt = GetDataTableByCommand_StorePCKR(query, pParam)
            Return dt


            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub DeleteHeader(ByVal ID As String)
        Try

            Dim ls_SP As String = "DELETE FROM AsakaiOtherDept WHERE rtrim(IDTransaksi)=" & QVal(ID) & ""
            'MainModul.ExecQuery(ls_SP)
            ExecQueryWithValue(ls_SP, CommandType.Text, Nothing, GetConnStringDbCKR)

            Dim ls_SPD As String = "DELETE FROM AsakaiOtherDeptDetail WHERE rtrim(IDTransaksi)=" & QVal(ID) & ""
            ExecQueryWithValue(ls_SPD, CommandType.Text, Nothing, GetConnStringDbCKR)

        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub GetData(ID As String)
        Try
            Dim query As String = "SELECT AsakaiOtherDeptDetail.[IDTransaksi] as IDTransaksi
                                  ,AsakaiOtherDeptDetail.[Informasi] as Informasi
                                  ,AsakaiOtherDeptDetail.[Gambar] as GAMBAR
                                  ,AsakaiOtherDeptDetail.[PIC] as PIC
                                  ,AsakaiOtherDept.[Tanggal]  as Tanggal
                                  ,AsakaiOtherDept.[Dept] as Dept
                              FROM AsakaiOtherDeptDetail inner join AsakaiOtherDept
                                    on AsakaiOtherDeptDetail.IDTransaksi = AsakaiOtherDept.IDTransaksi 
                                    WHERE AsakaiOtherDeptDetail.[IDTransaksi] = " & QVal(ID) & ""
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(query)
            'dtTable = MainModul.GetDataTableByCommand(query)
            dtTable = GetDataTableByParam(query, CommandType.Text, Nothing, GetConnStringDbCKR)

            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.H_Tanggal = Trim(.Item("Tanggal") & "")
                    Me.D_Gambar = Trim(.Item("GAMBAR") & "")
                End With
            End If
        Catch ex As Exception
            Throw
        End Try

    End Sub

    Public Sub GetData_CKR(ID As String)
        Try
            Dim query As String = "SELECT AsakaiOtherDeptDetail.[IDTransaksi] as IDTransaksi
                                  ,AsakaiOtherDeptDetail.[Informasi] as Informasi
                                  ,AsakaiOtherDeptDetail.[Gambar] as GAMBAR
                                  ,AsakaiOtherDeptDetail.[PIC] as PIC
                                  ,AsakaiOtherDept.[Tanggal]  as Tanggal
                                  ,AsakaiOtherDept.[Dept] as Dept
                              FROM AsakaiOtherDeptDetail inner join AsakaiOtherDept
                                    on AsakaiOtherDeptDetail.IDTransaksi = AsakaiOtherDept.IDTransaksi 
                                    WHERE AsakaiOtherDeptDetail.[IDTransaksi] = " & QVal(ID) & ""
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(query)
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.H_Tanggal = Trim(.Item("Tanggal") & "")
                    Me.D_Gambar = Trim(.Item("GAMBAR") & "")
                End With
            End If
        Catch ex As Exception
            Throw
        End Try

    End Sub

    Public Function GetDataDetailNonProduksi(ID As String) As DataTable
        Try
            Dim query As String = "SELECT [Informasi] as INFORMASI
                                  ,[Gambar] as [File]
                                  ,[PIC] as PIC
                              FROM AsakaiOtherDeptDetail inner join AsakaiOtherDept
                                    on AsakaiOtherDeptDetail.IDTransaksi = AsakaiOtherDept.IDTransaksi 
                                    WHERE AsakaiOtherDeptDetail.[IDTransaksi] = " & QVal(ID) & ""
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(query)
            'dtTable = MainModul.GetDataTableByCommand(query)
            dtTable = GetDataTableByParam(query, CommandType.Text, Nothing, GetConnStringDbCKR)


            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetDataDetailNonProduksi_CKR(ID As String) As DataTable
        Try
            Dim query As String = "SELECT [Informasi] as INFORMASI
                                  ,[Gambar] as [File]
                                  ,[PIC] as PIC
                              FROM AsakaiOtherDeptDetail inner join AsakaiOtherDept
                                    on AsakaiOtherDeptDetail.IDTransaksi = AsakaiOtherDept.IDTransaksi 
                                    WHERE AsakaiOtherDeptDetail.[IDTransaksi] = " & QVal(ID) & ""
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(query)
            dtTable = GetDataTableByParam(query, CommandType.Text, Nothing, GetConnStringDbCKR)

            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub GetIDTransAuto()
        Try
            Dim Tahun, Bulan As String
            Tahun = Format(Now, "yy")
            Bulan = Format(Now, "MM")

            Dim ls_SP As String = "SELECT [IDTransaksi] FROM [AsakaiOtherDept] order by IDTransaksi desc" 'where IDTrans= " & QVal(IDTrans) & " or TanggalSampai = '" & TanggalDari & "' "
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(ls_SP)
            dtTable = GetDataTableByParam(ls_SP, CommandType.Text, Nothing, GetConnStringDbCKR)
            Dim Ulang As String = Tahun & Bulan
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count <= 0 Then
                IDTrans = "NP" & Tahun & Bulan & "0001"
            Else
                IDTrans = dtTable.Rows(0).Item("IDTransaksi")
                IDTrans = Microsoft.VisualBasic.Mid(IDTrans, 3, 4)
                If IDTrans <> Ulang Then
                    IDTrans = "NP" & Tahun & Bulan & "0001"
                Else
                    IDTrans = dtTable.Rows(0).Item("IDTransaksi")
                    IDTrans = Val(Microsoft.VisualBasic.Mid(IDTrans, 7, 4)) + 1
                    If Len(IDTrans) = 1 Then
                        IDTrans = "NP" & Tahun & Bulan & "000" & IDTrans & ""
                    ElseIf Len(IDTrans) = 2 Then
                        IDTrans = "NP" & Tahun & Bulan & "00" & IDTrans & ""
                    ElseIf Len(IDTrans) = 3 Then
                        IDTrans = "NP" & Tahun & Bulan & "0" & IDTrans & ""
                    Else
                        IDTrans = "NP" & Tahun & Bulan & IDTrans & ""
                    End If

                End If

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertData(IdTransaksi As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringDbCKR)
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

            ExecQueryWithValue(ls_SP, CommandType.Text, Nothing, GetConnStringDbCKR)
            ' Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(ls_SP)
            'dtTable = GetDataTableByParam(Query, CommandType.Text, Params, GetConnStringDbCKR)
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
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
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
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringDbCKR)
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
            'MainModul.ExecQuery(ls_SP)
            ExecQueryWithValue(ls_SP, CommandType.Text, Nothing, GetConnStringDbCKR)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteDetail(ByVal ID As String)
        Try
            'DeleteDetail
            Dim ls_DeleteDetail As String = "DELETE FROM AsakaiOtherDeptDetail WHERE rtrim(IDTransaksi)=" & QVal(ID) & ""
            'MainModul.ExecQuery(ls_DeleteDetail)
            ExecQueryWithValue(ls_DeleteDetail, CommandType.Text, Nothing, GetConnStringDbCKR)

        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class

Public Class NonProduksiDetailModel_CKR

    Public Property D_IDTransaksi() As String
    Public Property D_Informasi() As String
    Public Property D_Gambar() As String
    Public Property D_PIC() As String

    Public Sub InsertDetail(IDTrans)
        Try

            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO [AsakaiOtherDeptDetail]
                   ([IDTransaksi]
                   ,[Informasi]
                   ,[Gambar]
                   ,[PIC]) " & vbCrLf &
            "Values(" & QVal(D_IDTransaksi) & ", " & vbCrLf &
            "       " & QVal(D_Informasi) & ", " & vbCrLf &
            "       " & QVal(D_Gambar) & ", " & vbCrLf &
            "       " & QVal(D_PIC) & ")"
            'ExecQuery(ls_SP)
            'ExecQuery(ls_SP)
            ExecQueryWithValue(ls_SP, CommandType.Text, Nothing, GetConnStringDbCKR)
        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class
