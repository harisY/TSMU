Imports System.Collections.ObjectModel
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

    Public Function GetSubAccount(Tahun As String,
                                  Dept As String,
                                  AcctID As String) As DataTable
        Try
            Dim query As String

            query = "SELECT Distinct Rtrim(LTrim(A.AcctID)) As AcctID
			        ,Rtrim(LTrim(A.DeptID)) as DeptID
			        ,Rtrim(LTrim(B.Sub)) as Sub
			        FROM [New_BOM].[dbo].rekap_budget_dept A inner Join [New_BOM].[dbo].M_Root_Approval B
			        on A.DeptID = B.DeptID
			        WHERE A.Tahun = '" & Tahun & "' 
			        and A.DeptID = '" & Dept & "' 
			        and A.AcctID = '" & AcctID & "'"

            Dim dt As New DataTable
            dt = GetDataTableByCommand(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetBarang(Type As String, SubAccount As String) As DataTable
        Try
            Dim query As String
            If Type = "SE" Then
                query = "Select InvtID,Descr,Acct,UnitQty from XPRItem"
            ElseIf Type = "GN" Then
                query = "Select InvtID,Descr,InvtAcct,StkUnit from Inventory
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

    Public Function GetPembelianUntuk() As DataTable
        Try
            Dim query As String = "SELECT Type as Name ,Alias AS Value From PR_PurchaseType"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
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
                AutoNumber = Dept_ & Bulan & Tahun & "001"
            Else
                AutoNumber = dtTable.Rows(0).Item("PRNo")
                AutoNumber = Microsoft.VisualBasic.Mid(AutoNumber, 1, 8)
                If AutoNumber <> Ulang Then
                    AutoNumber = Dept_ & Bulan & Tahun & "001"
                Else
                    AutoNumber = dtTable.Rows(0).Item("PRNo")
                    AutoNumber = Val(Microsoft.VisualBasic.Mid(AutoNumber, 9, 3) + 1)
                    If Len(AutoNumber) = 1 Then
                        AutoNumber = Dept_ & Bulan & Tahun & "00" & AutoNumber & ""
                    ElseIf Len(AutoNumber) = 2 Then
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
                                        H_Sirkulasi)

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
                                        H_Sirkulasi)

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
                               Sirkulasi As String)


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
                                               ,Sirkulasi)
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
                                               ,'" & Sirkulasi & "')"
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
                               Sirkulasi As String)


        Dim ls_TA As String = "UPDATE [XPRHdr]
                               SET [Remark] ='" & Remark & "'
                                  ,[SeqRev] = '" & SeqRev & "'
                                  ,[UpdateDate] = '" & UpdateDate & "'
                                  ,[UpdateBy] = '" & UpdateBy & "'
                                  ,[Sirkulasi] = '" & Sirkulasi & "'
                             WHERE [PRNo] = '" & PRNo & "'"

        MainModul.ExecQuery(ls_TA)

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
                                               ,[XSeqNo])
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
                                               ,'" & D_XSeqNo & "')"
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
