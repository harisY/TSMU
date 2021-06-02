﻿
Imports System.Collections.ObjectModel
Public Class KategoriAbsenModel_CKR

    Dim _Query As String
    Public Property IDAbsen() As String
    Public Property Description() As String
    Public Property Jumlah() As Integer

    Public Sub New()
        Me._Query = "SELECT IDAbsen,Description FROM KategoriAbsen"
    End Sub

    Public Function GetAllDataTable(ByVal ls_Filter As String) As DataTable
        Try
            'Dim ls_SP As String = "select invtid as [Inventory ID], descr as Description,StkUnit as Unit,catalog as [Part No], packing as Packing, min_stok [Min Stok], " & _
            '                        "case kdgrup " & _
            '                            "when 'FG' then 'Finish Good' " & _
            '                            "else 'PURCHASE' end as [Group] " & _
            '                        "from inventory_lc order by Invtid"
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(Me._Query)
            dtTable = MainModul.GetDataTableByCommand(Me._Query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetAllData() As DataTable
        Try
            Dim ls_SP As String = "SELECT
                                    '' IDAbsen
                                    ,'' [Description]
                                    FROM [KategoriAbsen] 
                                    UNION 
                                    SELECT 
                                    [IDAbsen]
                                    ,[Description]
                                    FROM [KategoriAbsen]"
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(ls_SP)
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function


    Public Sub getDataByID(ByVal ID As String)
        Try
            Dim query As String = "SELECT 
                                    [IDAbsen]
                                   ,[Description]
                                    FROM [KategoriAbsen] WHERE [IDAbsen] = " & QVal(ID) & ""
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(query)
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.IDAbsen = Trim(.Item("IDAbsen") & "")
                    Me.Description = Trim(.Item("Description") & "")
                End With
            Else
                IDAbsen = ""
                Description = ""
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub ValidateInsert()
        If Me.Description = "" OrElse Me.IDAbsen = "" Then
            Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
        End If
        Try
            Dim ls_SP As String = "SELECT TOP 1 [IDAbsen]
                                    ,[Description]                     
                                    FROM [KategoriAbsen] where [IDAbsen] = " & QVal(IDAbsen) & ""
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(ls_SP)
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
                "[" & Me.IDAbsen & "]")
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub


#Region "CRUD"
    Public Sub Insert()
        Try
            'Dim ls_SP As String = "INSERT INTO [departemen]
            '                               ([DeptID]
            '                               ,[Nama]
            '                               ,[Jumlah]
            '                               ,[Createdby]
            '                               ,[CreatedDate])
            '                         VALUES
            '                               (" & QVal(DeptID) & " 
            '                               ," & QVal(Nama) & "
            '                               ," & QVal(Jumlah) & "
            '                               ," & QVal(gh_Common.Username) & "
            '                               ,GETDATE())"

            Dim ls_SP As String = "INSERT INTO [KategoriAbsen]
                                           ([IDAbsen]
                                           ,[Description]
                                           ,[CreatedBy]
                                           ,[CreatedDate])
                                     VALUES
                                           (" & QVal(IDAbsen) & " 
                                           ," & QVal(Description) & "
                                           ," & QVal(gh_Common.Username) & "
                                           ,GETDATE())"

            'MainModul.ExecQuery(ls_SP)
            MainModul.ExecQuery(ls_SP)

        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Update(ByVal id As String)
        Try
            Dim ls_SP As String = "UPDATE [KategoriAbsen]
                                   SET [Description] = " & QVal(Description) & "
                                      ,[UpdatedBy] = " & QVal(gh_Common.Username) & "
                                      ,[UpdatedDate] = GETDATE()
                                   WHERE IDAbsen = " & QVal(id) & ""
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Delete(ByVal id As String)
        Try
            Dim ls_SP As String = "DELETE FROM [KategoriAbsen] WHERE IDAbsen =" & QVal(id) & ""
            'MainModul.ExecQuery(ls_SP)
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
#End Region


End Class
