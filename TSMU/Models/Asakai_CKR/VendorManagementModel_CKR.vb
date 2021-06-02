﻿Imports System.Collections.ObjectModel
Public Class VendorManagementModel_CKR
    Dim _Query As String
    Public tahun As String
    Public bulan As String
    Public tanggal As String



    Public Property H_IDTransaksi As String
    Public Property H_Tanggal As DateTime
    Public Property IDTrans As String


    Public Property ObjDetailVMProblem() As New Collection(Of VMProblemDetailModel_CKR)


    Public Sub New()

        Me._Query = "SELECT  ROW_NUMBER() OVER(ORDER BY (SELECT 1)) AS [No],AsakaiVMProblemHeader.IDTransaksi as [No Transaksi],Convert(varchar,AsakaiVMProblemHeader.Tanggal,105) as Tanggal
                    from AsakaiVMProblemHeader inner join AsakaiVMProblemDetail
                    on AsakaiVMProblemHeader.IDTransaksi = AsakaiVMProblemDetail.IDTransaksi
                    GROUP by  AsakaiVMProblemHeader.IDTransaksi
								,AsakaiVMProblemHeader.tanggal
					Order by AsakaiVMProblemHeader.tanggal Desc"

    End Sub

    Public Sub Delete(ByVal ID As String)
        Try
            'Delete Header
            Dim ls_DeleteHeader As String = "DELETE FROM AsakaiVMProblemHeader WHERE rtrim(IDTransaksi)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteHeader)


            'DeleteDetail
            Dim ls_DeleteDetail As String = "DELETE FROM AsakaiVMProblemDetail WHERE rtrim(IDTransaksi)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteDetail)

        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Function GetAllDataTable(ByVal ls_Filter As String) As DataTable
        Try


            'Dim query As String = "[CR_Get_Approve]"
            Dim dt As New DataTable
            dt = GetDataTableByCommand(Me._Query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function


    Public Function GetDataDetailVMProblem(ID As String) As DataTable
        Try
            Dim query As String = "SELECT [IDTransaksi]
                                 ,[Tanggal]
                                 ,[Shift]
                                 ,[keterangan] as [Keterangan]
                                 ,[subcount] as [Subcount]
                                 ,[InvtId] as [Kode Barang]
                                 ,[InvtName] as [Nama Barang]
                                 ,[Type]
                                 ,[Qty]
                                 ,[Foto] as Gambar
                                 ,[Foto2] as Gambar2
                                 ,[Problem]
                                 ,[Analisis]
                                 ,[Lot Produksi] as [Lot No]
                                 ,[CORRECTIVE ACTION] as [Correction Action]
                                 ,[PREVENTIVE ACTION] as [Preventive Action]
                                 ,[Pic]
                                 ,[Target]  
                                 ,[Foto] as [Gambar Hapus]
                                 ,[Status] 
                                From [AsakaiVMProblemDetail] where IDTransaksi  = '" & ID & "'"
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(query)
            dtTable = MainModul.GetDataTableByCommand(query)

            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function



    Public Sub getDataByID(ByVal ID As String)
        Try
            Dim query As String = "SELECT [IDTransaksi]
                                  ,[Tanggal]
                                  ,[CreatedBy]
                                  ,[CreatedDate]
                                  ,[UpdatedBy]
                                  ,[UpdatedDate]
                              FROM [AsakaiVMProblemHeader] where IDTransaksi = '" & ID & "'"
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(query)
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me.H_IDTransaksi = Trim(.Item(0) & "")
                    Me.H_Tanggal = Trim(.Item(1) & "")

                End With
            Else

            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub GetIDTransAuto()
        Try
            Dim Tahun As String
            Tahun = Format(Now, "yy")

            Dim ls_SP As String = "SELECT [IDTransaksi] FROM [AsakaiVMProblemHeader] order by ID desc" 'where IDTrans= " & QVal(IDTrans) & " or TanggalSampai = '" & TanggalDari & "' "
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Dim Ulang As String = Tahun
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count <= 0 Then
                IDTrans = "VM" & Tahun & "0001"
            Else
                IDTrans = dtTable.Rows(0).Item("IDTransaksi")
                IDTrans = Microsoft.VisualBasic.Mid(IDTrans, 3, 2)
                If IDTrans <> Ulang Then
                    IDTrans = "VM" & Tahun & "0001"
                Else
                    IDTrans = dtTable.Rows(0).Item("IDTransaksi")
                    IDTrans = Val(Microsoft.VisualBasic.Mid(IDTrans, 5, 4)) + 1
                    If Len(IDTrans) = 1 Then
                        IDTrans = "VM" & Tahun & "000" & IDTrans & ""
                    ElseIf Len(IDTrans) = 2 Then
                        IDTrans = "VM" & Tahun & "00" & IDTrans & ""
                    ElseIf Len(IDTrans) = 3 Then
                        IDTrans = "VM" & Tahun & "0" & IDTrans & ""
                    Else
                        IDTrans = "VM" & Tahun & IDTrans & ""
                    End If

                End If

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertVMProblem(IdTransaksi As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        InsertHeader(IdTransaksi)
                        For i As Integer = 0 To ObjDetailVMProblem.Count - 1
                            With ObjDetailVMProblem(i)
                                .InsertVMProblemDetail(IdTransaksi)
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


            Dim ls_SP As String = "INSERT INTO AsakaiVMProblemHeader
                                           ([IDTransaksi]
                                           ,[Tanggal]
                                           ,[CreatedBy]
                                           ,[CreatedDate])
                                     VALUES 
                                            (" & QVal(idTransaksi) & " 
                                            ," & QVal(H_Tanggal) & "
                                            ," & QVal(gh_Common.Username) & "
                                            ,GETDATE())"

            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub UpdateData(IdTransaksi As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        UpdateHeader(IdTransaksi)
                        DeleteDetail(IdTransaksi)

                        For i As Integer = 0 To ObjDetailVMProblem.Count - 1
                            With ObjDetailVMProblem(i)
                                .InsertVMProblemDetail(IdTransaksi)
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
                                    "UPDATE AsakaiVMProblemHeader" & vbCrLf &
                                    "SET Tanggal = " & QVal(H_Tanggal) & ", " & vbCrLf &
                                    "    UpdatedBy = " & QVal(gh_Common.Username) & ", " & vbCrLf &
                                    "    UpdatedDate = GETDATE() WHERE IDTransaksi = '" & _IDTrans & "'"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteDetail(ByVal ID As String)
        Try
            'DeleteDetail
            Dim ls_DeleteDetail As String = "DELETE FROM AsakaiVMProblemDetail WHERE rtrim(IDTransaksi)=" & QVal(ID) & ""
            MainModul.ExecQuery(ls_DeleteDetail)

        Catch ex As Exception
            Throw
        End Try
    End Sub



End Class


Public Class VMProblemDetailModel_CKR


    Public Property D_IDTransaksi As String
    Public Property D_Tanggal As DateTime
    Public Property D_Shift As String
    Public Property D_Keterangan As String
    Public Property D_Subcount As String
    Public Property D_InvtId As String
    Public Property D_InvtName As String
    Public Property D_Type As String
    Public Property D_Qty As Integer
    Public Property D_Gambar As String
    Public Property D_Gambar2 As String
    Public Property D_Problem As String
    Public Property D_Lot As String
    Public Property D_Analisis As String
    Public Property D_CORRECTIVE_ACTION As String
    Public Property D_PREVENTIVE_ACTION As String
    Public Property D_Pic As String

    Public Property D_Target As DateTime

    Public Property D_Status As String

    Public Property D_Path As String




    Public Sub InsertVMProblemDetail(IDTrans)
        Try

            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO [AsakaiVMProblemDetail]
                   ([IDTransaksi]
                   ,[Tanggal]
                   ,[Shift]
                   ,[keterangan]
                   ,[subcount]
                   ,[InvtId]
                   ,[InvtName]
                   ,[Type]
                   ,[Qty]
                   ,[Foto]
                   ,[Problem]
                   ,[Lot Produksi]
                   ,[Analisis]
                   ,[CORRECTIVE ACTION]
                   ,[PREVENTIVE ACTION]
                   ,[Pic]
                   ,[Target]
                   ,[status]
                   ,[Foto2]) " & vbCrLf &
            "Values(" & QVal(IDTrans) & ", " & vbCrLf &
            "       " & QVal(D_Tanggal) & ", " & vbCrLf &
            "       " & QVal(D_Shift) & ", " & vbCrLf &
            "       " & QVal(D_Keterangan) & ", " & vbCrLf &
            "       " & QVal(D_Subcount) & ", " & vbCrLf &
            "       " & QVal(D_InvtId) & ", " & vbCrLf &
            "       " & QVal(D_InvtName) & ", " & vbCrLf &
            "       " & QVal(D_Type) & ", " & vbCrLf &
            "       " & QVal(D_Qty) & ", " & vbCrLf &
            "       " & QVal(D_Gambar) & ", " & vbCrLf &
            "       " & QVal(D_Problem) & ", " & vbCrLf &
            "       " & QVal(D_Lot) & ", " & vbCrLf &
            "       " & QVal(D_Analisis) & ", " & vbCrLf &
            "       " & QVal(D_CORRECTIVE_ACTION) & ", " & vbCrLf &
            "       " & QVal(D_PREVENTIVE_ACTION) & ", " & vbCrLf &
            "       " & QVal(D_Pic) & ", " & vbCrLf &
            "       " & QVal(D_Target) & ", " & vbCrLf &
            "       " & QVal(D_Status) & ", " & vbCrLf &
            "       " & QVal(D_Gambar2) & ")"

            'ExecQuery(ls_SP)
            ExecQuery(ls_SP)

        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class

