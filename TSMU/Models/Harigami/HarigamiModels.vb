Imports System.Collections.ObjectModel
Imports System.Data.SqlClient

Public Class HarigamiModels
    Public Property ObjDetails() As New Collection(Of HarigamiDetailsModels)
    Public Function GetAllDataGridCKR() As DataTable
        Try
            Dim Query As String =
            "SELECT
                Id, FileNo, InvtId , FilePath, Type 
            FROM [TbHarigamiMaster]"
            Dim dtTable As New DataTable

            If Left(gh_Common.Site.ToLower, 3) = "tng" Then
                dtTable = GetDataTableByParam(Query, CommandType.Text, Nothing, GetConnString)
            Else
                dtTable = GetDataTableByParam(Query, CommandType.Text, Nothing, GetConnStringDbCKR)
            End If
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetReportHarigami(Tgl1 As String, Tgl2 As String) As DataTable
        Try
            Dim Query As String = "SELECT
                h.Id,
	            h.FileNo,
                m.InvtId,
	            m.FilePath,
	            h.Type,
	            h.LastCounter,
	            d.CreatedDate,
	            d.Status,
	            d.Counter
            FROM TbHarigami h left join
            TbHarigamiDetails d on h.Id = d.Id left join
            TbHarigamiMaster m on h.FileNo = m.FileNo AND h.Type = m.Type
            WHERE Convert(Date,h.CreatedDate) >= @dari AND Convert(Date,h.CreatedDate) <= @sampai Order By h.Id"
            Dim Params As List(Of SqlParameter) = New List(Of SqlParameter)
            Params.Add(New SqlParameter() With {.ParameterName = "dari", .Value = Tgl1})
            Params.Add(New SqlParameter() With {.ParameterName = "sampai", .Value = Tgl2})

            Dim dtTable As New DataTable
            If Left(gh_Common.Site.ToLower, 3) = "tng" Then
                dtTable = GetDataTableByParam(Query, CommandType.Text, Params, GetConnString)
            Else
                dtTable = GetDataTableByParam(Query, CommandType.Text, Params, GetConnStringDbCKR)
            End If
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Sub DeleteData()
        Try

            Dim sql As String = "Delete From TbHarigamiMaster"
            If Left(gh_Common.Site.ToLower, 3) = "tng" Then
                ExecQueryWithValue(sql, CommandType.Text, Nothing, GetConnString)
            Else
                ExecQueryWithValue(sql, CommandType.Text, Nothing, GetConnStringDbCKR)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub InsertData()
        Try
            Using Conn1 As New SqlConnection(If(Left(gh_Common.Site.ToLower, 3) = "tng", GetConnString(), GetConnStringDbCKR()))
                Conn1.Open()
                Using Trans1 As SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        DeleteData()
                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
                                .InsertData()
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
            Throw ex
        End Try
    End Sub

    Public Sub UpdateData()
        Try
            Using Conn As New SqlConnection(If(Left(gh_Common.Site.ToLower, 3) = "tng", GetConnString(), GetConnStringDbCKR()))
                Conn.Open()
                Using Trans As SqlTransaction = Conn.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn
                    gh_Trans.Command.Transaction = Trans

                    Try
                        For i As Integer = 0 To ObjDetails.Count - 1
                            With ObjDetails(i)
                                .UpdateData()
                            End With
                        Next

                        Trans.Commit()
                    Catch ex As Exception
                        Trans.Rollback()
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

#Region "REPORT"
    Public Function PopulateFileNo() As DataTable
        Try
            Dim dtTable As New DataTable
            Dim Query As String = "SELECT LTRIM(RTRIM(FileNo)) FileNo,
                                        CASE 
		                                WHEN PartNo IS NULL
			                                THEN 'N/A'
		                                ELSE PartNo
		                                END AS PartNo
                                   FROM TbHarigami
                                   "
            If Left(gh_Common.Site.ToLower, 3) = "tng" Then
                dtTable = GetDataTableByParam(Query, CommandType.Text, Nothing, GetConnString)
            Else
                dtTable = GetDataTableByParam(Query, CommandType.Text, Nothing, GetConnStringDbCKR)
            End If
            Return dtTable
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GenerateDataGrid(FileNo As String, Type As String, Dari As Date, Sampai As Date) As DataTable
        Try
            Dim dtTable As New DataTable
            Dim Params As List(Of SqlParameter) = New List(Of SqlParameter)
            Params.Add(New SqlParameter() With {.ParameterName = "FileNo", .Value = FileNo})
            Params.Add(New SqlParameter() With {.ParameterName = "Type", .Value = Type})
            Params.Add(New SqlParameter() With {.ParameterName = "Tgl", .Value = Dari})
            Params.Add(New SqlParameter() With {.ParameterName = "Tgl1", .Value = Sampai})
            If Left(gh_Common.Site.ToLower, 3) = "tng" Then
                dtTable = GetDataTableByParam("Harigami_Report", CommandType.StoredProcedure, Params, GetConnString)
            Else
                dtTable = GetDataTableByParam("Harigami_Report", CommandType.StoredProcedure, Params, GetConnStringDbCKR)
            End If
            Return dtTable
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function PopulatePartNo() As DataTable
        Try
            Dim dtTable As New DataTable
            Dim Query As String = "SELECT DISTINCT LTRIM(RTRIM(PartNo)) PartNo
                                   FROM TbHarigami
                                   "
            If Left(gh_Common.Site.ToLower, 3) = "tng" Then
                dtTable = GetDataTableByParam(Query, CommandType.Text, Nothing, GetConnString)
            Else
                dtTable = GetDataTableByParam(Query, CommandType.Text, Nothing, GetConnStringDbCKR)
            End If
            Return dtTable
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region
End Class
Public Class HarigamiDetailsModels
    Public Property Id() As Integer
    Public Property FileNo() As String
    Public Property FilePath() As String
    Public Property Type() As String
    Public Property InvtId() As String


    Public Sub InsertData()
        Try
            Dim Query As String = String.Empty
            Query = "INSERT INTO [TbHarigamiMaster]([FileNo],[FilePath],[Type],InvtId,[CreatedDate])
                    Values(@FileNo, @FilePath, @Type, @InvtId, GETDATE())"
            Dim Params As List(Of SqlParameter) = New List(Of SqlParameter)
            Params.Add(New SqlParameter() With {.ParameterName = "FileNo", .Value = FileNo})
            Params.Add(New SqlParameter() With {.ParameterName = "FilePath", .Value = FilePath})
            Params.Add(New SqlParameter() With {.ParameterName = "Type", .Value = Type})
            Params.Add(New SqlParameter() With {.ParameterName = "InvtId", .Value = InvtId})
            If Left(gh_Common.Site.ToLower, 3) = "tng" Then
                ExecQueryWithValue(Query, CommandType.Text, Params, GetConnString)
            Else
                ExecQueryWithValue(Query, CommandType.Text, Params, GetConnStringDbCKR)
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateData()
        Try
            Dim Query As String = String.Empty
            Query = "Update [TbHarigamiMaster]
                    Set [FileNo] = @FileNo 
                        ,[FilePath] = @FilePath 
                        ,[InvtId] = @InvtId 
                        ,[Type]) = @Type where Id = @Id"
            Dim Params As List(Of SqlParameter) = New List(Of SqlParameter)
            Params.Add(New SqlParameter() With {.ParameterName = "FileNo", .Value = FileNo})
            Params.Add(New SqlParameter() With {.ParameterName = "FilePath", .Value = FilePath})
            Params.Add(New SqlParameter() With {.ParameterName = "Type", .Value = Type})
            Params.Add(New SqlParameter() With {.ParameterName = "InvtId", .Value = InvtId})
            Params.Add(New SqlParameter() With {.ParameterName = "Id", .Value = Id})
            If Left(gh_Common.Site.ToLower, 3) = "tng" Then
                ExecQueryWithValue(Query, CommandType.Text, Params, GetConnString)
            Else
                ExecQueryWithValue(Query, CommandType.Text, Params, GetConnStringDbCKR)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
