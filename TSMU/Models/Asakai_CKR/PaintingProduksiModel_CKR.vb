Imports System.Collections.ObjectModel
Public Class PaintingProduksiModel_CKR

    Public Property ObjDetailScrap() As New Collection(Of PaintingProduksiDetailScrapModel)
    Public Property ObjDetailProblemQty() As New Collection(Of PaintingProduksiDetailScrapModel)
    Public Property ObjDetailProblemAnalisa() As New Collection(Of PaintingProduksiDetailScrapModel)


    Public Property Dummy As Integer = 0
    Public Property A_PLAN As Double
    Public Property A_NG As Double
    Public Property A_Ok_Line As Double
    Public Property A_OK_Part_Persen As Double
    Public Property A_Ok_Polesh As Double
    Public Property A_Ok_Total As Double
    Public Property A_Straight As Double
    Public Property A_Target_Str As Double
    Public Property A_Total_Produksi As Double
    Public Property B_ACTUAL As Double
    Public Property B_NG As Double
    Public Property B_Ok_Line As Double
    Public Property B_OK_Part_Persen As Double
    Public Property B_Ok_Polesh As Double
    Public Property B_Ok_Total As Double
    Public Property B_Straight As Double
    Public Property B_Target_Str As Double
    Public Property B_Total_Produksi As Double
    Public Property C_Persen_ACTUAL As Double
    Public Property D_TOTAL_PROD_ACTUAL As Double
    Public Property E_OK_LINE As Double
    Public Property F_NG As Double
    Public Property G_TARGET_STRAIGHT_PASS As Double
    Public Property H_STRAIGT_PASS As Double
    Public Property I_OK_POLESH As Double
    Public Property IdTransaksi As String
    Public Property J_OK_PART_LINE_OK_POLESH As Double
    Public Property K_OK_PART_Persen As Double
    Public Property L_Big_Part As Double
    Public Property M_Big_Ok As Double
    Public Property N_Big_NG As Double
    Public Property O_Big_STRAIGHT_PASSS As Double
    Public Property P_SMAAL_PART As Double
    Public Property Q_Small_OK As Double
    Public Property R_Small_NG As Double
    Public Property S_Small_STRAIGHT_PASSS As Double
    Public Property Tanggal As DateTime


#Region "Scrap"
    Public Property Scrap_QTY_CRUSHING As Integer
    Public Property Scrap_QTY_PROD As Integer
    Public Property Scrap_Persen_CRUSHING As Double
    Public Property Scrap_TARGET As Double

#End Region



    Dim _Query As String
    Public Property IDTrans As String


    Public Sub New()
        Me._Query = "SELECT IdTransaksi,CONVERT(varchar,Tanggal,105) as Tanggal  FROM AsakaiPaintingStraightPass order by IdTransaksi Desc "
    End Sub

    Public Function GetAllDataTable(ByVal ls_Filter As String) As DataTable
        Try
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(Me._Query)
            dtTable = GetDataTableByParam(Me._Query, CommandType.Text, Nothing, GetConnStringDbCKR)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub GetIDTransAuto()
        Dim fc_ClassDetail As New InjectionDetailModel
        Try

            Dim Tahun, Bulan As String
            Tahun = Format(Now, "yy")
            Bulan = Format(Now, "MM")

            Dim ls_SP As String = "SELECT top 1 [IdTransaksi]                   
                                    FROM [AsakaiPaintingStraightPass]
                                    where substring([IdTransaksi], 3, 2) = '" & Tahun & "'
                                    and substring([IdTransaksi], 5, 2) = '" & Bulan & "'
                                    and Dept = '" & gh_Common.GroupID & "'
                                    order by substring([IdTransaksi], 7, 4) desc"
            Dim dtTable As New DataTable
            dtTable = GetDataTableByParam(ls_SP, CommandType.Text, Nothing, GetConnStringDbCKR)
            'dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Dim Ulang As String = Tahun & Bulan

            If gh_Common.GroupID = "32PP" Then
                If dtTable IsNot Nothing AndAlso dtTable.Rows.Count <= 0 Then
                    IDTrans = "PA" & Tahun & Bulan & "0001"
                Else
                    IDTrans = dtTable.Rows(0).Item("IdTransaksi")
                    IDTrans = Microsoft.VisualBasic.Mid(IDTrans, 3, 4)
                    If IDTrans <> Ulang Then
                        IDTrans = "PA" & Tahun & Bulan & "0001"
                    Else
                        IDTrans = dtTable.Rows(0).Item("IdTransaksi")
                        IDTrans = Val(Microsoft.VisualBasic.Mid(IDTrans, 7, 4)) + 1
                        If Len(IDTrans) = 1 Then
                            IDTrans = "PA" & Tahun & Bulan & "000" & IDTrans & ""
                        ElseIf Len(IDTrans) = 2 Then
                            IDTrans = "PA" & Tahun & Bulan & "00" & IDTrans & ""
                        ElseIf Len(IDTrans) = 3 Then
                            IDTrans = "PA" & Tahun & Bulan & "0" & IDTrans & ""
                        Else
                            IDTrans = "PA" & Tahun & Bulan & IDTrans & ""
                        End If
                    End If

                End If
            Else
                If dtTable IsNot Nothing AndAlso dtTable.Rows.Count <= 0 Then
                    IDTrans = "PB" & Tahun & Bulan & "0001"
                Else
                    IDTrans = dtTable.Rows(0).Item("IdTransaksi")
                    IDTrans = Microsoft.VisualBasic.Mid(IDTrans, 3, 4)
                    If IDTrans <> Ulang Then
                        IDTrans = "PB" & Tahun & Bulan & "0001"
                    Else
                        IDTrans = dtTable.Rows(0).Item("IdTransaksi")
                        IDTrans = Val(Microsoft.VisualBasic.Mid(IDTrans, 7, 4)) + 1
                        If Len(IDTrans) = 1 Then
                            IDTrans = "PB" & Tahun & Bulan & "000" & IDTrans & ""
                        ElseIf Len(IDTrans) = 2 Then
                            IDTrans = "PB" & Tahun & Bulan & "00" & IDTrans & ""
                        ElseIf Len(IDTrans) = 3 Then
                            IDTrans = "PB" & Tahun & Bulan & "0" & IDTrans & ""
                        Else
                            IDTrans = "PB" & Tahun & Bulan & IDTrans & ""
                        End If
                    End If

                End If
            End If

            fc_ClassDetail.D_IdTransaksi = IDTrans

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub getDataByID(ByVal ID As String)
        Try
            Dim query As String = "SELECT AsakaiPemakaianMaterialKomponen.IDTrans    
                                    ,AsakaiPemakaianMaterialKomponen.TanggalDari
                                    ,AsakaiPemakaianMaterialKomponen.TanggalSampai
                                    ,AsakaiPemakaianMaterialKomponen.Keterangan
                                    ,AsakaiPemakaianMaterial.[1.AktualRP]
                                    ,AsakaiPemakaianMaterial.[2.Sales]
                                    ,AsakaiPemakaianMaterial.[3.% Sales]
                                    ,AsakaiPemakaianMaterial.[4.AktualProduksi]
                                    ,AsakaiPemakaianMaterial.[5. % Inj ]
                                    ,AsakaiPemakaianMaterial.[6.Target]
                                    ,AsakaiPemakaianKomponen.[1.AktualRP]
                                    ,AsakaiPemakaianKomponen.[2.Sales]
                                    ,AsakaiPemakaianKomponen.[3.% Sales]
                                    ,AsakaiPemakaianKomponen.[4.AktualProduksi]
                                    ,AsakaiPemakaianKomponen.[5. % Inj ]
                                    ,AsakaiPemakaianKomponen.[6.Target]
                                    ,AsakaiPemakaianMaterialKomponen.KolomQty
                                    ,AsakaiPemakaianMaterialKomponen.KolomHarga
                                    FROM AsakaiPemakaianMaterialKomponen inner join AsakaiPemakaianMaterial on AsakaiPemakaianMaterialKomponen.IDTrans = AsakaiPemakaianMaterial.IDTrans
                                    inner join AsakaiPemakaianKomponen on AsakaiPemakaianMaterialKomponen.IDTrans = AsakaiPemakaianKomponen.IDTrans WHERE AsakaiPemakaianMaterialKomponen.IDTrans = " & QVal(ID) & ""
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(query)
            dtTable = GetDataTableByParam(query, CommandType.Text, Nothing, GetConnStringDbCKR)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    'Me.IDTrans = Trim(.Item(0) & "")
                    'Me.TanggalDari = Trim(.Item(1) & "")
                    'Me.TanggalSampai = Trim(.Item(2) & "")
                    'Me.Keterangan = Trim(.Item(3) & "")
                    'Me.MaterialAktualRP = Trim(.Item(4) & "")
                    'Me.Sales = Trim(.Item(5) & "")
                    'Me.MaterialPercent1 = Trim(.Item(6) & "")
                    'Me.AktualProduksi = Trim(.Item(7) & "")
                    'Me.MaterialPercent2 = Trim(.Item(8) & "")
                    'Me.MaterialTarget = Trim(.Item(9) & "")
                    'Me.KomponenAktualRP = Trim(.Item(10) & "")
                    'Me.KomponenPercent1 = Trim(.Item(12) & "")
                    'Me.KomponenPercent2 = Trim(.Item(14) & "")
                    'Me.KomponenTarget = Trim(.Item(15) & "")
                    'Me.KolomQty = Trim(.Item(16) & "")
                    'Me.KolomHarga = Trim(.Item(17) & "")
                End With
            Else

            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub Insert()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringDbCKR)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        InsertStraightPass()
                        InsertScrap()

                        For i As Integer = 0 To ObjDetailScrap.Count - 1
                            With ObjDetailScrap(i)
                                .InsertPaintingDetailsScrap(IDTrans, Tanggal)
                            End With
                        Next

                        For j As Integer = 0 To ObjDetailProblemQty.Count - 1
                            With ObjDetailProblemQty(j)
                                .InsertPaintingProblemQty(IDTrans, Tanggal)
                            End With
                        Next

                        For k As Integer = 0 To ObjDetailProblemAnalisa.Count - 1
                            With ObjDetailProblemAnalisa(k)
                                .InsertPaintingProblemAnalisa(IDTrans, Tanggal)
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
    Public Sub InsertStraightPass()
        Dim result As Integer = 0
        Try
            Dim ls_SP As String = "INSERT INTO [AsakaiPaintingStraightPass]
                                           ([IdTransaksi]
                                           ,[Tanggal]
                                           ,[A. PLAN]
                                           ,[B. ACTUAL]
                                           ,[C. % ACTUAL]
                                           ,[D. TOTAL PROD ACTUAL]
                                           ,[E. OK LINE]
                                           ,[F. NG]
                                           ,[G. TARGET STRAIGHT PASS]
                                           ,[H. STRAIGT PASS]
                                           ,[I. OK POLESH]
                                           ,[J. OK PART LINE + OK POLESH]
                                           ,[K. OK PART %]
                                           ,[L. Big Part]
                                           ,[M. Big Ok]
                                           ,[N. Big NG]
                                           ,[O. Big STRAIGHT PASSS]
                                           ,[P. SMAAL PART]
                                           ,[Q. Small OK]
                                           ,[R. Small NG]
                                           ,[S. Small STRAIGHT PASSS]
                                           ,[A Total Produksi]
                                           ,[A Ok Line]
                                           ,[A NG]
                                           ,[A Target Str]
                                           ,[A Straight]
                                           ,[A Ok Polesh]
                                           ,[A Ok Total]
                                           ,[A OK Part %]
                                           ,[B Total Produksi]
                                           ,[B Ok Line]
                                           ,[B NG]
                                           ,[B Target Str]
                                           ,[B Straight]
                                           ,[B Ok Polesh]
                                           ,[B Ok Total]
                                           ,[B OK Part %]
                                           ,[CreatedBy]
                                           ,[CreatedDate]
                                           ,[Dept])
                                     VALUES 
                                            (" & QVal(IDTrans) & " 
                                            ," & QVal(Me.Tanggal) & "
                                            ," & QVal(Me.A_PLAN) & "
                                            ," & QVal(Me.B_ACTUAL) & "
                                            ," & QVal(Me.C_Persen_ACTUAL) & "
                                            ," & QVal(Me.D_TOTAL_PROD_ACTUAL) & "
                                            ," & QVal(Me.E_OK_LINE) & "
                                            ," & QVal(Me.F_NG) & "
                                            ," & QVal(Me.G_TARGET_STRAIGHT_PASS) & "
                                            ," & QVal(Me.H_STRAIGT_PASS) & "
                                             ," & QVal(Me.Dummy) & "
                                          ," & QVal(Me.J_OK_PART_LINE_OK_POLESH) & "
                                            ," & QVal(Me.K_OK_PART_Persen) & "
                                            ," & QVal(Me.Dummy) & "
                                            ," & QVal(Me.Dummy) & "
                                            ," & QVal(Me.Dummy) & "
                                            ," & QVal(Me.Dummy) & "
                                            ," & QVal(Me.Dummy) & "
                                            ," & QVal(Me.Dummy) & "
                                            ," & QVal(Me.Dummy) & "
                                            ," & QVal(Me.Dummy) & "
                                            ," & QVal(Me.Dummy) & "
                                            ," & QVal(Me.Dummy) & "
                                            ," & QVal(Me.Dummy) & "
                                            ," & QVal(Me.Dummy) & "
                                            ," & QVal(Me.Dummy) & "
                                            ," & QVal(Me.Dummy) & "
                                            ," & QVal(Me.Dummy) & "
                                            ," & QVal(Me.Dummy) & "
                                            ," & QVal(Me.Dummy) & "
                                            ," & QVal(Me.Dummy) & "
                                            ," & QVal(Me.Dummy) & "
                                            ," & QVal(Me.Dummy) & "
                                            ," & QVal(Me.Dummy) & "
                                            ," & QVal(Me.Dummy) & "
                                            ," & QVal(Me.Dummy) & "
                                            ," & QVal(Me.Dummy) & "
                                            ," & QVal(gh_Common.Username) & "
                                            ,GETDATE()
                                            ," & QVal(gh_Common.GroupID) & ")"

            ExecQueryWithValue(ls_SP, CommandType.Text, Nothing, GetConnStringDbCKR)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub InsertScrap()
        Dim result As Integer = 0
        Try
            Dim ls_SP As String = "INSERT INTO [AsakaiPaintingScrap]
                                           ([IdTransaksi]
                                           ,[Tanggal]
                                           ,[1. QTY CRUSHING]
                                           ,[2. QTY PROD]
                                           ,[3. % CRUSHING]
                                           ,[4. TARGET]
                                           ,[CreatedBy]
                                           ,[CreatedDate]
                                           ,[Dept])
                                     VALUES 
                                            (" & QVal(IDTrans) & " 
                                            ," & QVal(Me.Tanggal) & "
                                            ," & QVal(Me.Scrap_QTY_CRUSHING) & "
                                            ," & QVal(Me.Scrap_QTY_PROD) & "
                                            ," & QVal(Me.Scrap_Persen_CRUSHING) & "
                                            ," & QVal(Me.Scrap_TARGET) & "
                                            ," & QVal(gh_Common.Username) & "
                                            ,GETDATE() 
                                            ," & QVal(gh_Common.GroupID) & ")"
            ExecQueryWithValue(ls_SP, CommandType.Text, Nothing, GetConnStringDbCKR)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    'Public Sub Delete(ByVal ID As String)
    '    Try
    '        'Delete Header
    '        Dim ls_DeleteHeader As String = "DELETE FROM AsakaiPaintingStraightPass WHERE rtrim(IdTransaksi)=" & QVal(ID) & ""
    '        'MainModul.ExecQuery(ls_DeleteHeader)
    '        ExecQueryWithValue(ls_DeleteHeader, CommandType.Text, Nothing, GetConnStringDbCKR)

    '        Dim ls_DeleteScrap As String = "DELETE FROM AsakaiPaintingScrap WHERE rtrim(IdTransaksi)=" & QVal(ID) & ""
    '        'MainModul.ExecQuery(ls_DeleteScrap)
    '        ExecQueryWithValue(ls_DeleteScrap, CommandType.Text, Nothing, GetConnStringDbCKR)

    '        Dim ls_DeleteScrapDetail As String = "DELETE FROM AsakaiPaintingDetailPartScrap WHERE rtrim(IdTransaksi)=" & QVal(ID) & ""
    '        'MainModul.ExecQuery(ls_DeleteScrapDetail)
    '        ExecQueryWithValue(ls_DeleteScrap + ls_DeleteScrapDetail, CommandType.Text, Nothing, GetConnStringDbCKR)

    '        Dim ls_DeleteProblemQty As String = "DELETE FROM AsakaiPaintingProblemQty WHERE rtrim(IdTransaksi)=" & QVal(ID) & ""
    '        'MainModul.ExecQuery(ls_DeleteProblemQty)
    '        ExecQueryWithValue(ls_DeleteProblemQty, CommandType.Text, Nothing, GetConnStringDbCKR)

    '        Dim ls_DeleteProblemAnalisa As String = "DELETE FROM AsakaiPaintingProblemAnalisa WHERE rtrim(IdTransaksi)=" & QVal(ID) & ""
    '        'MainModul.ExecQuery(ls_DeleteProblemAnalisa)
    '        ExecQueryWithValue(ls_DeleteProblemAnalisa, CommandType.Text, Nothing, GetConnStringDbCKR)


    '        'DeleteDetail
    '    Catch ex As Exception
    '        Throw
    '    End Try
    'End Sub

    Public Sub Delete(ByVal ID As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnStringDbCKR)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        Dim ls_DeleteHeader As String = "DELETE FROM AsakaiPaintingStraightPass WHERE rtrim(IdTransaksi)=" & QVal(ID) & ""
                        'MainModul.ExecQuery(ls_DeleteHeader)
                        ExecQueryWithValue(ls_DeleteHeader, CommandType.Text, Nothing, GetConnStringDbCKR)

                        Dim ls_DeleteScrap As String = "DELETE FROM AsakaiPaintingScrap WHERE rtrim(IdTransaksi)=" & QVal(ID) & ""
                        'MainModul.ExecQuery(ls_DeleteScrap)
                        ExecQueryWithValue(ls_DeleteScrap, CommandType.Text, Nothing, GetConnStringDbCKR)

                        Dim ls_DeleteScrapDetail As String = "DELETE FROM AsakaiPaintingDetailPartScrap WHERE rtrim(IdTransaksi)=" & QVal(ID) & ""
                        'MainModul.ExecQuery(ls_DeleteScrapDetail)
                        ExecQueryWithValue(ls_DeleteScrap + ls_DeleteScrapDetail, CommandType.Text, Nothing, GetConnStringDbCKR)

                        Dim ls_DeleteProblemQty As String = "DELETE FROM AsakaiPaintingProblemQty WHERE rtrim(IdTransaksi)=" & QVal(ID) & ""
                        'MainModul.ExecQuery(ls_DeleteProblemQty)
                        ExecQueryWithValue(ls_DeleteProblemQty, CommandType.Text, Nothing, GetConnStringDbCKR)

                        Dim ls_DeleteProblemAnalisa As String = "DELETE FROM AsakaiPaintingProblemAnalisa WHERE rtrim(IdTransaksi)=" & QVal(ID) & ""
                        'MainModul.ExecQuery(ls_DeleteProblemAnalisa)
                        ExecQueryWithValue(ls_DeleteProblemAnalisa, CommandType.Text, Nothing, GetConnStringDbCKR)


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

    Public Sub ValidateInsert()
        Try
            Dim ls_SP As String = "SELECT TOP 1 [IdTransaksi],Tanggal                   
                                    FROM [AsakaiPaintingStraightPass] 
                                    where Tanggal = '" & Tanggal & "'
                                    and Dept = '" & gh_Common.GroupID & "'"
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(ls_SP)
            'dtTable = MainModul.GetDataTableByCommand(ls_SP)
            dtTable = GetDataTableByParam(ls_SP, CommandType.Text, Nothing, GetConnStringDbCKR)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
                "[" & Me.Tanggal & " ")

            Else

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub


End Class


Public Class PaintingProduksiDetailScrapModel_CKR

    Public Property IdTransaksi As String
    Public Property InvtID As String
    Public Property InvtName As String
    Public Property Qty As Integer

#Region "Problem Qty"

    Public Property PQ_STRIGHPASS As Double
    Public Property PQ_BINTIK_CAT As Integer
    Public Property PQ_BINTIK_HANGER As Integer
    Public Property PQ_HAJIKI As Integer
    Public Property PQ_IdTransaksi As String
    Public Property PQ_InvtID As String
    Public Property PQ_InvtName As String
    Public Property PQ_Warna As String
    Public Property PQ_KEBA As Integer
    Public Property PQ_KOTORAN_LUAR As Integer
    Public Property PQ_LAIN2 As Integer
    Public Property PQ_LELEH As Integer
    Public Property PQ_NG As Integer
    Public Property PQ_NG_INJECT As Integer
    Public Property PQ_OK As Integer
    Public Property PQ_OP_KASAR_BELANG As Integer
    Public Property PQ_SCRATCH As Integer
    Public Property PQ_SHIFT As String
    Public Property PQ_Tanggal As Date
    Public Property PQ_TOTAL_PROD As Integer
#End Region

#Region "Problem Analisa"
    Public Property PA_ANALISA_PROBLEM_4M As String
    Public Property PA_IdTransaksi As String
    Public Property PA_InvtID As String
    Public Property PA_InvtName As String
    Public Property PA_Perbaikan_Permanent As String
    Public Property PA_Perbaikan_Sementara As String
    Public Property PA_PIC As String
    Public Property PA_Status As String
    Public Property PA_Tanggal As DateTime
    Public Property PA_Target As DateTime
#End Region







    Public Sub InsertPaintingDetailsScrap(IDTrans As String, Tanggal As Date)
        Try

            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO [AsakaiPaintingDetailPartScrap]
                        ([IdTransaksi]
                       ,[Tanggal]
                       ,[InvtID]
                       ,[InvtName]
                       ,[Qty]) " & vbCrLf &
            "Values(" & QVal(IDTrans) & ", " & vbCrLf &
            "       " & QVal(Tanggal) & ", " & vbCrLf &
            "       " & QVal(InvtID) & ", " & vbCrLf &
            "       " & QVal(InvtName) & ", " & vbCrLf &
            "       " & QVal(Qty) & ")"
            'ExecQuery(ls_SP)
            ExecQuery(ls_SP)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertPaintingProblemQty(IDTrans As String, Tanggal As Date)
        Try

            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO [AsakaiPaintingProblemQty]
                           ([IdTransaksi]
                           ,[Tanggal]
                           ,[SHIFT]
                           ,[InvtID]
                           ,[InvtName]
                           ,[Warna]
                           ,[OK]
                           ,[NG]
                           ,[TOTAL PROD]
                           ,[% STRIGHPASS]
                           ,[BINTIK CAT]
                           ,[BINTIK HANGER]
                           ,[KOTORAN LUAR]
                           ,[KEBA]
                           ,[SCRATCH]
                           ,[HAJIKI]
                           ,[NG INJECT]
                           ,[LELEH]
                           ,[OP KASAR BELANG]
                           ,[LAIN2]) " & vbCrLf &
            "Values(" & QVal(IDTrans) & ", " & vbCrLf &
            "       " & QVal(Tanggal) & ", " & vbCrLf &
            "       " & QVal(PQ_SHIFT) & ", " & vbCrLf &
            "       " & QVal(PQ_InvtID) & ", " & vbCrLf &
            "       " & QVal(PQ_InvtName) & ", " & vbCrLf &
            "       " & QVal(PQ_Warna) & ", " & vbCrLf &
            "       " & QVal(PQ_OK) & ", " & vbCrLf &
            "       " & QVal(PQ_NG) & ", " & vbCrLf &
            "       " & QVal(PQ_TOTAL_PROD) & ", " & vbCrLf &
            "       " & Math.Round((QVal(PQ_STRIGHPASS) * 100), 2) & ", " & vbCrLf &
            "       " & QVal(PQ_BINTIK_CAT) & ", " & vbCrLf &
            "       " & QVal(PQ_BINTIK_HANGER) & ", " & vbCrLf &
            "       " & QVal(PQ_KOTORAN_LUAR) & ", " & vbCrLf &
            "       " & QVal(PQ_KEBA) & ", " & vbCrLf &
            "       " & QVal(PQ_SCRATCH) & ", " & vbCrLf &
            "       " & QVal(PQ_HAJIKI) & ", " & vbCrLf &
            "       " & QVal(PQ_NG_INJECT) & ", " & vbCrLf &
            "       " & QVal(PQ_LELEH) & ", " & vbCrLf &
            "       " & QVal(PQ_OP_KASAR_BELANG) & ", " & vbCrLf &
            "       " & QVal(PQ_LAIN2) & ")"
            'ExecQuery(ls_SP)
            ExecQuery(ls_SP)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertPaintingProblemAnalisa(IDTrans As String, Tanggal As Date)
        Try

            Dim ls_SP As String = " " & vbCrLf &
                    "INSERT INTO [AsakaiPaintingProblemAnalisa]
                   ([IdTransaksi]
                   ,[Tanggal]
                   ,[InvtID]
                   ,[InvtName]
                   ,[ANALISA PROBLEM 4M]
                   ,[Perbaikan Sementara]
                   ,[Perbaikan Permanent]
                   ,[PIC]
                   ,[Target]
                   ,[Status]) " & vbCrLf &
                    "Values(" & QVal(IDTrans) & ", " & vbCrLf &
            "       " & QVal(Tanggal) & ", " & vbCrLf &
            "       " & QVal(PA_InvtID) & ", " & vbCrLf &
            "       " & QVal(PA_InvtName) & ", " & vbCrLf &
            "       " & QVal(PA_ANALISA_PROBLEM_4M) & ", " & vbCrLf &
            "       " & QVal(PA_Perbaikan_Sementara) & ", " & vbCrLf &
            "       " & QVal(PA_Perbaikan_Permanent) & ", " & vbCrLf &
            "       " & QVal(PA_PIC) & ", " & vbCrLf &
            "       " & QVal(PA_Target) & ", " & vbCrLf &
            "       " & QVal(PA_Status) & ")"
            'ExecQuery(ls_SP)
            ExecQuery(ls_SP)

        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class


