﻿Imports System.Collections.ObjectModel
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Net
Imports System.Net.Mail

Public Class Cls_PR


    Public Property AutoNumber As String
    Public Property H_Id As Int32
    Public Property H_ApprovalDate As Date
    Public Property H_ApprovalPIC As String
    Public Property H_ApprovalRemark As String
    Public Property H_LocId As String
    Public Property H_LUpd_DateTime As Date
    Public Property H_LUpd_Prog As String
    Public Property H_LUpd_User As String
    Public Property H_PRDate As Date
    Public Property H_PRNo As String
    Public Property H_Remark As String
    Public Property H_SecId As String
    Public Property H_SeqRev As Int32
    Public Property H_StatusFlag As String
    'Public Property H_tstamp As String
    Public Property H_CreateDate As Date
    Public Property H_CreateBy As String
    Public Property H_UpdateDate As Date
    Public Property H_UpdateBy As String
    Public Property H_Sirkulasi As String
    Public Property H_ForDept As String
    Public Property H_DeptCreate As String

    Public Property Collection_Detail() As New Collection(Of Cls_PR_Detail)


    Public Function Get_PR(Dept As String) As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[PR_D_GetPR]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@Dept", SqlDbType.VarChar)
            pParam(0).Value = Dept
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function Get_PR_Search(Dept As String, TglAwal As Date, TglAkhir As Date) As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[PR_D_GetPR_Search]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
            pParam(0) = New SqlClient.SqlParameter("@Dept", SqlDbType.VarChar)
            pParam(1) = New SqlClient.SqlParameter("@TglAwal", SqlDbType.Date)
            pParam(2) = New SqlClient.SqlParameter("@TglAkhir", SqlDbType.Date)

            pParam(0).Value = Dept
            pParam(1).Value = TglAwal
            pParam(2).Value = TglAkhir
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function



    Public Function GetSirkulasiSudahPR(Sirkulasi As String, PRNo As String) As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[PR_D_GetSirkulasiSudahPR]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@Sirkulasi", SqlDbType.VarChar)
            pParam(1) = New SqlClient.SqlParameter("@PRNO", SqlDbType.VarChar)

            pParam(0).Value = Sirkulasi
            pParam(1).Value = PRNo

            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function Get_UntuBagian() As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query = "SELECT DISTINCT DeptID,DeptName FROM M_Root_Approval
                         WHERE Active = 'TRUE'"


            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand(query)

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function


    Public Function GetSubAccount(Tahun As String,
                                  Dept As String,
                                  AcctID As String) As DataTable
        Try
            Dim query As String

            ' query = "SELECT Distinct Rtrim(LTrim(A.AcctID)) As AcctID
            ',Rtrim(LTrim(A.DeptID)) as DeptID
            ',Rtrim(LTrim(B.Sub)) as Sub
            'FROM [New_BOM].[dbo].rekap_budget_dept A inner Join [New_BOM].[dbo].M_Root_Approval B
            'on A.DeptID = B.DeptID
            'WHERE A.Tahun = '" & Tahun & "' 
            'and A.DeptID = '" & Dept & "' 
            'and A.AcctID = '" & AcctID & "'"

            query = "SELECT Distinct *
			        FROM AcctHist
			        WHERE FiscYr = '" & Tahun & "' 
			        and Sub = '" & Dept & "' 
			        and Acct = '" & AcctID & "'"

            Dim dt As New DataTable
            dt = GetDataTableByCommand(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetBudget(Tahun As String,
                                  Dept As String,
                                  AcctID As String) As DataTable
        Try
            Dim query As String

            query = "SELECT Rtrim(LTrim(rekap_budget_dept.AcctID)) as AcctID ,
                     Rtrim(LTrim(rekap_budget_dept.AcctName)) as AcctName,
                     Rtrim(LTrim(rekap_budget_dept.DeptID)) as DeptID,
                     Rtrim(LTrim(Tahun)),Rtrim(LTrim(Tahun)) As Tahun,
                     sum(jan_qty*jan_harga) as jan,
                     sum(feb_qty*feb_harga) as feb,
                     sum(mar_qty*mar_harga) as mar,
                     sum(apr_qty*apr_harga) as apr,
                     sum(mei_qty*mei_harga) as mei,
                     sum(jun_qty*jun_harga) as jun,
                     sum(jul_qty*jul_harga) as jul,
                     sum(agt_qty*agt_harga) as agu,
                     sum(sep_qty*sep_harga) as sep,
                     sum(okt_qty*okt_harga) as okt,
                     sum(nov_qty*nov_harga) as nov,
                     sum(des_qty*des_harga) as des
                     FROM rekap_budget_dept INNER JOIN tipeacct on tipeacct.acctid=rekap_budget_dept.acctid
                     WHERE tipeacct.tipe = 'D' 
                     and rekap_budget_dept.Tahun = '" & Tahun & "'
                     and rekap_budget_dept.DeptID = '" & Dept & "'
                     and rekap_budget_dept.AcctID = '" & AcctID & "'
                     GROUP BY rekap_budget_dept.DeptID,
                     rekap_budget_dept.AcctID,
                     rekap_budget_dept.AcctName,
                     Tahun"

            'query = "SELECT Rtrim(LTrim(Acct)) as AcctID ,
            '         --Rtrim(LTrim(rekap_budget_dept.AcctName)) as AcctName,
            '         Rtrim(LTrim(Sub)) as DeptID,
            '         --Rtrim(LTrim(SiteID)),
            '         Rtrim(LTrim(FiscYr)) As Tahun,
            '         sum(PtdBal00) as jan,
            '         sum(PtdBal01) as feb,
            '         sum(PtdBal02) as mar,
            '         sum(PtdBal03) as apr,
            '         sum(PtdBal04) as mei,
            '         sum(PtdBal05) as jun,
            '         sum(PtdBal06) as jul,
            '         sum(PtdBal07) as agu,
            '         sum(PtdBal08) as sep,
            '         sum(PtdBal09) as okt,
            '         sum(PtdBal10) as nov,
            '         sum(PtdBal11) as [des]
            '         FROM AcctHist 
            '         --INNER JOIN tipeacct on tipeacct.acctid=rekap_budget_dept.acctid
            '         WHERE 
            '         --tipeacct.tipe='D' 
            '         FiscYr = '" & Tahun & "'
            '         and Sub = '" & Dept & "'
            '         and Acct = '" & AcctID & "'
            '         GROUP BY 
            '         Acct,
            '         Sub,
            '         FiscYr"



            Dim dt As New DataTable
            'dt = GetDataTableByCommand(query)
            dt = GetDataTableByCommand(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetActualBudget(Tahun As String,
                                  Bulan As String,
                                  subAccount As String,
                                  Account As String,
                                  PRNo As String) As DataTable
        Try
            Dim query As String = "[PR_D_GetSisaBudget]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(4) {}
            pParam(0) = New SqlClient.SqlParameter("@Year", SqlDbType.VarChar)
            pParam(1) = New SqlClient.SqlParameter("@Month", SqlDbType.VarChar)
            pParam(2) = New SqlClient.SqlParameter("@Sub", SqlDbType.VarChar)
            pParam(3) = New SqlClient.SqlParameter("@Account", SqlDbType.VarChar)
            pParam(4) = New SqlClient.SqlParameter("@PR", SqlDbType.VarChar)

            pParam(0).Value = Tahun
            pParam(1).Value = Bulan
            pParam(2).Value = subAccount
            pParam(3).Value = Account
            pParam(4).Value = PRNo
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetBarang(Type As String, SubAccount As String, Sirkulasi As String) As DataTable
        Try
            Dim query As String
            If Type = "SE" Then
                query = "Select InvtID,Descr,Acct,UnitQty from XPRItem"
            ElseIf Type = "GN" Then
                'query = "Select Distinct a.InvtID,a.Descr,a.InvtAcct,a.StkUnit from Inventory a
                '            inner join New_BOM.dbo.CR_Description_Of_Cost b
                '            on a.InvtAcct = b.Account
                '            Where a.TranStatusCode = 'AC' 
                '            and User5 = 1
                '            and StkItem = 0
                '            and b.CirculationNo = '" & Sirkulasi & "'"

                query = "Select Distinct InvtID,Descr,InvtAcct,StkUnit from Inventory 
                            Where TranStatusCode = 'AC' 
                            and User5 = 1
                            and StkItem = 0"
            Else
                query = "Select InvtID,Descr,InvtAcct,StkUnit from Inventory
                            Where TranStatusCode = 'AC' 
                            and User5 = 1
                            and StkItem = 1"
            End If
            Dim dt As New DataTable
            dt = GetDataTableByCommand_sol(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub GetDataByID(ByVal ID As String)
        Try
            'Dim query As String = "[CR_Get_Request_ByID]"
            'Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            'pParam(0) = New SqlClient.SqlParameter("@Circulation", SqlDbType.VarChar)
            'pParam(0).Value = ID

            Dim query As String
            query = "Select * FROM XPRHdr
			        WHERE PRNo = '" & ID & "'"

            Dim dt As New DataTable
            dt = GetDataTableByCommand(query)

            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                With dt.Rows(0)

                    H_Sirkulasi = Trim(.Item("Sirkulasi") & "")
                    ' H_ApprovalDate = Convert.ToDateTime(.Item("ApprovalDate"))
                    'H_ApprovalPIC = Trim(.Item("ApprovalPIC") & "")
                    'H_ApprovalRemark = Trim(.Item("ApprovalRemark") & "")
                    H_LocId = Trim(.Item("LocId") & "")
                    H_LUpd_DateTime = .Item("LUpd_DateTime")
                    H_LUpd_Prog = Trim(.Item("LUpd_Prog") & "")
                    H_LUpd_User = Trim(.Item("LUpd_User") & "")
                    H_PRDate = .Item("PRDate")
                    H_PRNo = Trim(.Item("PRNo") & "")
                    H_Remark = Trim(.Item("Remark") & "")
                    H_SecId = Trim(.Item("SecId") & "")
                    H_SeqRev = .Item("SeqRev")
                    H_StatusFlag = Trim(.Item("StatusFlag") & "")
                    H_CreateBy = Trim(.Item("CreateBy") & "")
                    H_CreateDate = .Item("CreateDate")
                    H_ForDept = .Item("ForDept")
                    ' H_UpdateBy = Trim(.Item("UpdateBy") & "")
                    ' H_UpdateDate = .Item("UpdateDate")

                End With
            Else

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetDetail(PRNo As String) As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[PR_Get_Detail]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@PRNo", SqlDbType.VarChar)
            pParam(0).Value = PRNo
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function GetDataDelete(PRNo As String) As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[PR_D_Get_Delete]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@PRNo", SqlDbType.VarChar)
            pParam(0).Value = PRNo
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function GetSirkulasi(Tgl As Date, Dept As String) As DataTable
        Try

            Dim query As String = "[PR_Get_Sirkulasi]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@dept", SqlDbType.VarChar)
            pParam(1) = New SqlClient.SqlParameter("@tgl", SqlDbType.Date)

            pParam(0).Value = Dept
            pParam(1).Value = Tgl
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt

        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetPembelianUntuk(Expense As String) As DataTable
        Try
            Dim query As String = ""

            If Expense = "All" Then
                query = "SELECT Type as Name ,Alias AS Value From PR_PurchaseType"
            ElseIf Expense = "SE" Then
                query = "SELECT Type as Name ,Alias AS Value From PR_PurchaseType Where Alias = 'SE'"
            Else
                query = "SELECT Type as Name ,Alias AS Value From PR_PurchaseType Where Alias <> 'SE'"
            End If

            Dim dt As New DataTable
            dt = GetDataTableByCommand(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function


    Public Sub GetNoPRAuto(Dept_ As String)

        Try
            Dim Tahun, Bulan As String
            Tahun = Format(Now, "yy")
            Bulan = Format(Now, "MM")
            Dim Ulang As String = Dept_ & Bulan & Tahun

            Dim Dept As String = gh_Common.GroupID
            Dim Query As String = "SELECT  Top 1 * FROM XPRHdr
                                    where substring([PRNo], 1, 8) = '" & Ulang & "'                                  
                                    order by id desc"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(Query)

            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count <= 0 Then
                AutoNumber = Dept_ & Bulan & Tahun & "0001"
            Else
                AutoNumber = dtTable.Rows(0).Item("PRNo")
                AutoNumber = Microsoft.VisualBasic.Mid(AutoNumber, 1, 8)
                If AutoNumber <> Ulang Then
                    AutoNumber = Dept_ & Bulan & Tahun & "0001"
                Else
                    AutoNumber = dtTable.Rows(0).Item("PRNo")
                    AutoNumber = Val(Microsoft.VisualBasic.Mid(AutoNumber, 9, 4) + 1)
                    If Len(AutoNumber) = 1 Then
                        AutoNumber = Dept_ & Bulan & Tahun & "000" & AutoNumber & ""
                    ElseIf Len(AutoNumber) = 2 Then
                        AutoNumber = Dept_ & Bulan & Tahun & "00" & AutoNumber & ""
                    ElseIf Len(AutoNumber) = 3 Then
                        AutoNumber = Dept_ & Bulan & Tahun & "0" & AutoNumber & ""
                    Else
                        AutoNumber = Dept_ & Bulan & Tahun & AutoNumber & ""
                    End If
                End If

            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Function Get_Dept_Sub(Departemen As String) As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[CR_Get_Sub]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@deptID", SqlDbType.VarChar)

            pParam(0).Value = Departemen

            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function Get_LastPR(Account As String) As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query = "Select Top 1 A.PRNo ,A.PRDate from XPRHdr A
                        inner join XPRDtl B on A.PRNo = B.PRNo
                        where B.Acct ='" & Account & "' order by B.ID desc"


            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand(query)

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function


    Public Sub Insert()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        Insert_PRHeader(H_LocId,
                                        H_LUpd_DateTime,
                                        H_LUpd_Prog,
                                        H_LUpd_User,
                                        H_PRDate,
                                        H_PRNo,
                                        H_Remark,
                                        H_SecId,
                                        H_SeqRev,
                                        H_StatusFlag,
                                        H_CreateDate,
                                        H_CreateBy,
                                        H_Sirkulasi,
                                        H_ForDept,
                                        H_DeptCreate)

                        For i As Integer = 0 To Collection_Detail.Count - 1
                            With Collection_Detail(i)
                                .InsertCR_Description_Of_Cost()
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
    'Public Sub Delete_Detail(CirculationNo As String)
    '    Try
    '        Try


    '            Dim query As String = "[CR_Delete_CR_Request_Detail]"
    '            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
    '            pParam(0) = New SqlClient.SqlParameter("@CirculationNo", SqlDbType.VarChar)

    '            pParam(0).Value = CirculationNo

    '            'Dim dtTable As New DataTable
    '            'dtTable = MainModul.GetDataTableByCommand_SP(query, pParam)
    '            MainModul.ExecQueryByCommand_SP(query, pParam)
    '        Catch ex As Exception
    '            Throw
    '        End Try

    '    Catch ex As Exception
    '        Throw
    '    End Try
    'End Sub
    Public Sub Update(PRNo As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        'InsertHistory(NPWO_)

                        Update_PRHeader(H_LocId,
                                        H_LUpd_DateTime,
                                        H_LUpd_Prog,
                                        H_LUpd_User,
                                        H_PRDate,
                                        H_PRNo,
                                        H_Remark,
                                        H_SecId,
                                        H_SeqRev,
                                        H_StatusFlag,
                                        H_UpdateDate,
                                        H_UpdateBy,
                                        H_Sirkulasi,
                                        H_ForDept)

                        Delete_Detail(PRNo)


                        For i As Integer = 0 To Collection_Detail.Count - 1
                            With Collection_Detail(i)
                                .InsertCR_Description_Of_Cost()
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

    Public Sub Insert_PRHeader(LocId As String,
                               LUpd_DateTime As Date,
                               LUpd_Prog As String,
                               LUpd_User As String,
                               PRDate As Date,
                               PRNo As String,
                               Remark As String,
                               SecId As Integer,
                               SeqRev As String,
                               StatusFlag As String,
                               CreateDate As Date,
                               CreateBy As String,
                               Sirkulasi As String,
                               ForDept As String,
                               DeptCreate As String)


        Dim ls_TA As String = "INSERT INTO [XPRHdr]
                                               ([LocId]
                                               ,[LUpd_DateTime]
                                               ,[LUpd_Prog]
                                               ,[LUpd_User]
                                               ,[PRDate]
                                               ,[PRNo]
                                               ,[Remark]
                                               ,[SecId]
                                               ,[SeqRev]
                                               ,[StatusFlag]
                                               ,[CreateDate]
                                               ,[CreateBy]
                                               ,Sirkulasi
                                               ,ForDept
                                               ,DeptCreate)
                                         VALUES
                                               ('" & LocId & "'
                                               ,'" & LUpd_DateTime & "'
                                               ,'" & LUpd_Prog & "'
                                               ,'" & LUpd_User & "'
                                               ,'" & PRDate & "'
                                               ,'" & PRNo & "'
                                               ,'" & Remark & "'
                                               ,'" & SecId & "'
                                               ,'" & SeqRev & "'
                                               ,'" & StatusFlag & "'
                                              ,'" & CreateDate & "'
                                              ,'" & CreateBy & "'
                                              ,'" & Sirkulasi & "'
                                              ,'" & ForDept & "'
                                               ,'" & DeptCreate & "')"
        MainModul.ExecQuery(ls_TA)


    End Sub

    Public Sub Update_PRHeader(LocId As String,
                               LUpd_DateTime As Date,
                               LUpd_Prog As String,
                               LUpd_User As String,
                               PRDate As Date,
                               PRNo As String,
                               Remark As String,
                               SecId As Integer,
                               SeqRev As String,
                               StatusFlag As String,
                               UpdateDate As Date,
                               UpdateBy As String,
                               Sirkulasi As String,
                               ForDept As String)


        Dim ls_TA As String = "UPDATE [XPRHdr]
                               SET [Remark] ='" & Remark & "'
                                  ,[SeqRev] = '" & SeqRev & "'
                                  ,[UpdateDate] = '" & UpdateDate & "'
                                  ,[UpdateBy] = '" & UpdateBy & "'
                                  ,[Sirkulasi] = '" & Sirkulasi & "'
                                  ,[ForDept] = '" & ForDept & "'
                             WHERE [PRNo] = '" & PRNo & "'"

        MainModul.ExecQuery(ls_TA)

    End Sub

    Public Sub Delete_PR(PRNo As String)




        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        'InsertHistory(NPWO_)

                        Dim ls_TA As String = "UPDATE [XPRHdr]
                               SET [StatusFlag] ='D'
                                  ,[UpdateDate] = '" & Date.Now & "'
                                  ,[UpdateBy] = '" & gh_Common.Username & "'
                             WHERE [PRNo] = '" & PRNo & "'"

                        MainModul.ExecQuery(ls_TA)


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

    Public Sub Delete_Detail(PRNo As String)
        Try
            Try


                Dim query As String = "Delete From [XPRDtl] Where PRNo = '" & PRNo & "' "

                MainModul.ExecQueryByCommand(query)
            Catch ex As Exception
                Throw
            End Try

        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub CancelPR(PRNo As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        'InsertHistory(NPWO_)

                        Dim ls_TA As String = "UPDATE [XPRHdr]
                               SET [StatusFlag] ='D'
                                  ,[UpdateDate] = '" & Date.Now & "'
                                  ,[UpdateBy] = '" & gh_Common.Username & "'
                             WHERE [PRNo] = '" & PRNo & "'"

                        MainModul.ExecQuery(ls_TA)


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


    Public Function Get_HeaderOutstanding() As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query = "Select Distinct
				XPRHdr.ApprovalPIC as [ApprovalPIC],
				XPRHdr.ApprovalRemark as [Approval Remark],
				XPRHdr.LocId as [Loc ID],
				XPRHdr.LUpd_Prog as [LUpd Prog],
				XPRHdr.LUpd_User as [LUpd User],
				XPRHdr.PRNo as [PR No],
				XPRHdr.PRDate as [PR Date],
				XPRHdr.Remark as [Remark],
				XPRHdr.SecId as [Sec ID],
				XPRHdr.SeqRev as [Seq Rev],	
				XPRHdr.StatusFlag as  [Status Flag] from XPRHdr
                Left join approval1
                on XPRHdr.PRNo = approval1.PRNo
                Where kol1 ='0'
                or kol2 ='0'
                or kol3 ='0'"

            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand_sol(query)

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function Get_DetailOutstanding() As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query = "Select  ROW_NUMBER() OVER(ORDER BY XPRHdr.PRNo ASC) AS No,
				  XPRDtl.[Acct]
				  ,XPRDtl.[CurrCode]
				  ,XPRDtl.[DelDate]
				  ,XPRDtl.[InvtDescr]
				  ,XPRDtl.[InvtId]
				  ,XPRDtl.[InvtSpec]
				  ,XPRDtl.[LastPRDate]
				  ,XPRDtl.[LastPRNo]
				  ,XPRDtl.[LUpd_Datetime]
				  ,XPRDtl.[LUpd_Prog]
				  ,XPRDtl.[LUpd_User]
				  ,XPRDtl.[OverFlag]
				  ,XPRDtl.[PRNo]
				  ,XPRDtl.[PurchaseType]
				  ,XPRDtl.[Qty]
				  ,XPRDtl.[QtyPO]
				  ,XPRDtl.[QtyRcv]
				  ,XPRDtl.[Remark]
				  ,XPRDtl.[SeqNo]
				  ,XPRDtl.[StatusDate]
				  ,XPRDtl.[StatusFlag]
				  ,XPRDtl.[StatusPIC]
				  ,XPRDtl.[StatusRemark]
				  ,XPRDtl.[StkItem]
				  ,XPRDtl.[Sub]
				  ,XPRDtl.[UnitPrice]
				  ,XPRDtl.[UnitQty]
				  ,XPRDtl.[XQty]
				  ,XPRDtl.[XSeqNo]
				from XPRHdr inner join XPRDtl
				on XPRHdr.PRNo = XPRDtl.PRNo
                Left join approval1
                on XPRHdr.PRNo = approval1.PRNo
                Where kol1 ='0'
                or kol2 ='0'
                or kol3 ='0'"
            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand_sol(query)

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function Get_ApproveOutstanding() As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query = "Select  distinct 
                approval.user_id as [User],
				approval.tanggal as Tanggal,
				approval.PRNo as PRNo,
				approval.status as [Status],
				approval.lepelx as Level
				from approval
				inner Join approval1
				on approval.PRNo = approval1.PRNo
                Where kol1 ='0'
                or kol2 ='0'
                or kol3 ='0'"
            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand_sol(query)

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function


    Public Function Get_Approve1Outstanding() As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query = "Select Distinct approval1.*
				from approval1
				 inner Join approval
				 on approval.PRNo = approval1.PRNo
                Where kol1 ='0'
                or kol2 ='0'
                or kol3 ='0'"
            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand_sol(query)

            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function
End Class


Public Class Cls_PR_Detail

    Public Property D_Acct As String
    Public Property D_CurrCode As String
    Public Property D_DelDate As Date
    Public Property D_InvtDescr As String
    Public Property D_InvtId As String
    Public Property D_InvtSpec As String
    Public Property D_LastPRDate As Date
    Public Property D_LastPRNo As String
    Public Property D_LUpd_Datetime As Date
    Public Property D_LUpd_Prog As String
    Public Property D_LUpd_User As String
    Public Property D_OverFlag As String
    Public Property D_PRNo As String
    Public Property D_PurchaseType As String
    Public Property D_Qty As Double
    Public Property D_QtyPO As Double
    Public Property D_QtyRcv As Double
    Public Property D_Remark As String
    Public Property D_SeqNo As Int32
    Public Property D_StatusDate As Date
    Public Property D_StatusFlag As String
    Public Property D_StatusPIC As String
    Public Property D_StatusRemark As String
    Public Property D_StkItem As Int32
    Public Property D_Sub As String
    Public Property D_UnitPrice As String
    Public Property D_UnitQty As String
    Public Property D_XQty As Double
    Public Property D_XSeqNo As Int32
    Public Property D_Keterangan As String
    ' Public Property D_tstamp As String
    Public Property D_CirculationNo As String


    Public Sub InsertCR_Description_Of_Cost()

        Try

            Dim ls_TA As String = "INSERT INTO [XPRDtl]
                                              ([Acct]
                                               ,[CurrCode]
                                               ,[DelDate]
                                               ,[InvtDescr]
                                               ,[InvtId]
                                               ,[InvtSpec]
                                               ,[LastPRDate]
                                               ,[LastPRNo]
                                               ,[LUpd_Datetime]
                                               ,[LUpd_Prog]
                                               ,[LUpd_User]
                                               ,[OverFlag]
                                               ,[PRNo]
                                               ,[PurchaseType]
                                               ,[Qty]
                                               ,[QtyPO]
                                               ,[QtyRcv]
                                               ,[Remark]
                                               ,[SeqNo]
                                               ,[StatusDate]
                                               ,[StatusFlag]
                                               ,[StkItem]
                                               ,[Sub]
                                               ,[UnitPrice]
                                               ,[UnitQty]
                                               ,[XQty]
                                               ,[XSeqNo]
                                               ,[Keterangan])
                                         VALUES
                                               ('" & D_Acct & "'
                                               ,'" & D_CurrCode & "'
                                               ,'" & D_DelDate & "'
                                               ,'" & D_InvtDescr & "'
                                               ,'" & D_InvtId & "'
                                               ,'" & D_InvtSpec & "'
                                               ,'" & D_LastPRDate & "'
                                               ,'" & D_LastPRNo & "'
                                               ,'" & D_LUpd_Datetime & "'
                                               ,'" & D_LUpd_Prog & "'
                                               ,'" & D_LUpd_User & "'
                                              ,'" & D_OverFlag & "'
                                               ,'" & D_PRNo & "'
                                               ,'" & D_PurchaseType & "'
                                               ,'" & D_Qty & "'
                                               ,'" & D_QtyPO & "'
                                               ,'" & D_QtyRcv & "'
                                               ,'" & D_Remark & "'
                                               ,'" & D_SeqNo & "'
                                               ,'" & D_StatusDate & "'
                                               ,'" & D_StatusFlag & "'
                                               ,'" & D_StkItem & "'
                                              ,'" & D_Sub & "'
                                               ,'" & D_UnitPrice & "'
                                               ,'" & D_UnitQty & "'
                                               ,'" & D_XQty & "'
                                               ,'" & D_XSeqNo & "'
                                               ,'" & D_Keterangan & "')"
            MainModul.ExecQuery(ls_TA)

        Catch ex As Exception
            Throw
        End Try

    End Sub


    Public Sub Update_DOC_Approve(CirculationNo As String)

        Try

            Dim query As String = "[CR_Update_DOC_Approve]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}
            pParam(0) = New SqlClient.SqlParameter("@CirculationNo", SqlDbType.VarChar)
            pParam(1) = New SqlClient.SqlParameter("@Id", SqlDbType.Int)
            pParam(2) = New SqlClient.SqlParameter("@Check", SqlDbType.Int)
            pParam(3) = New SqlClient.SqlParameter("@Note", SqlDbType.VarChar)

            'pParam(0).Value = CirculationNo
            'pParam(1).Value = D_Id
            'pParam(2).Value = D_Check
            'pParam(3).Value = D_Note


            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand_SP(query, pParam)
        Catch ex As Exception
            Throw
        End Try

    End Sub

    Public Sub Update_DOC_Approve_MKTFAC(CirculationNo As String)

        Try
            'Dim ls_SP As String = "UPDATE [CR_Description_Of_Cost]
            '                           SET [Account] = '" & D_Account & "',
            '                               [SalesType] = '" & D_SalesType & "'
            '                         WHERE [CirculationNo] = '" & CirculationNo & "'"
            'MainModul.ExecQuery(ls_SP)

        Catch ex As Exception
            Throw
        End Try

    End Sub

End Class
