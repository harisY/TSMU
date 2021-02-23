﻿Public Class TTI_Detail_Models
    Public Property cek1 As Boolean
    Public Property cek2 As Boolean
    Public Property cek3 As Boolean
    Public Property cek4 As Boolean
    Public Property cmdm As Double
    Public Property CuryID As String
    Public Property Dpp As Double
    Public Property id As Integer
    Public Property Jml_Invoice As Double
    Public Property ket As String
    Public Property No_Faktur As String
    Public Property NoBukti As String

    Public Property No_Invoice As String
    Public Property Pph As Double
    Public Property Ppn As Double
    Public Property releaser As String
    Public Property tax As String
    Public Property Tgl_Invoice As DateTime
    Public Property vrno As String
    Public Property NoPO As String
    Public Property Paid As Double
    Public Property tgl As Nullable(Of DateTime)

    Public Function GetPaymentByVoucherNo() As DataTable
        Try
            Dim sql As String = "SELECT RTRIM([No_Invoice]) InvcNbr
                      ,[Tgl_Invoice] InvcDate
                      ,RTRIM([No_Faktur]) fp
                      ,[CuryID] CuryId
                      ,[Jml_Invoice] Amount
                      ,[Dpp] DPP
                      ,[Ppn]
                      ,[Pph] PPH
                      ,[cek1] [Check]
                      ,[cek4] [CheckPPH]
                      ,[Paid]
                  FROM [TTI_detail] where RTRIM(vrno)=" & QVal(vrno.TrimEnd) & ""
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetPaymentByVoucherNoApprove() As DataTable
        Try
            Dim sql As String = "SELECT RTRIM([No_Invoice]) InvcNbr
                      ,[Tgl_Invoice] InvcDate
                      ,RTRIM([No_Faktur]) fp
                      ,[CuryID] CuryId
                      ,[Dpp] DPP
                      ,[Ppn]
                      ,Dpp+Ppn as Total
                      ,[Pph] PPH
                      ,(Dpp+Ppn)-Pph as Paid
                      ,[cek1] [Check]
                      ,[cek4] [CheckPPH]
                      ,[Paid]
                  FROM [TTI_detail] where RTRIM(vrno)=" & QVal(vrno.TrimEnd) & ""
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetCustomer2() As DataTable
        Try
            'Dim sql As String = "SELECT 
            '                      customer.CustID [Customer ID],
            '                        customer.name [Customer Name],vendor.vendid
            '                    FROM customer inner join vendor on vendor.vendid=customer.user5"

            Dim sql As String = "SELECT 
 	                                customer.CustID [Customer ID],
                                    customer.name [Customer Name]
                                FROM customer"
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetCustomer() As DataTable
        Try
            Dim sql As String = "SELECT 
 	                                CustID [Customer ID],
                                    name [Customer Name]
                                FROM dbo.customer"
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetBank() As DataTable
        Try
            Dim sql As String = "SELECT 
 	                                RTRIM(BankAcct) [Bank ID],
	                                RTRIM(CashAcctName) Name,
                                    CuryID
                                FROM dbo.cashacct"
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataGridCM_New(VendorID As String) As DataTable
        Try
            Dim sql As String = "SELECT Ardoc.docdate 
                                    ,Ardoc.CuryId
                                    ,Ardoc.batnbr 
                                    ,Ardoc.refnbr 
                                    ,Batch.CuryCrTot 
                                    , convert(bit,0) as [Check]
                                    , convert(bit,0) as [CheckPPH]
                                FROM Ardoc inner join 
                                    CashAcct  on Ardoc.BankAcct=CashAcct.BankAcct  inner join 
                                    Batch on Ardoc.BatNbr=Batch.BatNbr  inner join 
                                    customer  on Ardoc.custid=customer.custid inner join 
                                    vendor on customer.user5=vendor.vendid 
                                where Batch.user1='' 
                                    AND RTRIM(customer.custid)=" & QVal(VendorID.TrimEnd) & ""
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataGridCM_Edit(VendorID As String) As DataTable
        Try
            Dim sql As String = "SELECT Ardoc.docdate as tgl
                                    ,Ardoc.CuryId
                                    ,Ardoc.batnbr as Bacth
                                    ,Ardoc.refnbr as no_invoice
                                    ,Batch.CuryCrTot as total_cmdm 
                                FROM Ardoc inner join 
                                    CashAcct  on Ardoc.BankAcct=CashAcct.BankAcct  inner join 
                                    Batch on Ardoc.BatNbr=Batch.BatNbr  inner join 
                                    customer  on Ardoc.custid=customer.custid inner join 
                                    vendor on customer.user5=vendor.vendid 
                                where Batch.user1='' 
                                    AND vendor.name=" & QVal(VendorID) & ""
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetGridDetailPaymentByVendorID(VendorId) As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
                "PROSES_VOUCHER_ARNOTPAYYMENT1_TTI"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@CustID", SqlDbType.VarChar)
            pParam(0).Value = VendorId
            dt = MainModul.GetDataTableByCommand_SP_Solomon(sql, pParam)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetDetailPaymentByVendorID2(VendorId) As Double
        Try
            Dim auto As Double
            Dim dt As New DataTable
            Dim sql As String = "PROSES_VOUCHER_APNOTPAYYMENT1A_New"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@vendorID", SqlDbType.VarChar)
            pParam(0).Value = VendorId
            pParam(1) = New SqlClient.SqlParameter("@CuryId", SqlDbType.VarChar)
            pParam(1).Value = CuryID
            dt = MainModul.GetDataTableByCommand_SP_Solomon(sql, pParam)
            auto = dt.Rows(0).Item(0).ToString
            Return auto
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub InsertDetails()
        Try

            Dim ls_SP As String = " " & vbCrLf &
                                    "INSERT INTO TTI_detail (vrno,No_Invoice,Tgl_Invoice,Jml_Invoice,CuryID,Ppn,Dpp,Pph,No_Faktur,cek1,cek4,NoPO,Paid) " & vbCrLf &
                                    "Values(" & QVal(Me.vrno) & ", " & vbCrLf &
                                    "       " & QVal(Me.No_Invoice) & ", " & vbCrLf &
                                    "       " & QVal(Me.Tgl_Invoice) & ", " & vbCrLf &
                                    "       " & QVal(Me.Jml_Invoice) & ", " & vbCrLf &
                                    "       " & QVal(Me.CuryID) & ", " & vbCrLf &
                                    "       " & QVal(Me.Ppn) & ", " & vbCrLf &
                                    "       " & QVal(Me.Dpp) & ", " & vbCrLf &
                                    "       " & QVal(Me.Pph) & ", " & vbCrLf &
                                    "       " & QVal(Me.No_Faktur) & ", " & vbCrLf &
                                    "       " & QVal(Me.cek1) & ", " & vbCrLf &
                                    "       " & QVal(Me.cek4) & ", " & vbCrLf &
                                    "       " & QVal(Me.NoPO) & ", " & vbCrLf &
                                    "       " & QVal(Me.Paid) & ")"
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub InsertDetailsDir()
        Try

            Dim ls_SP As String = " " & vbCrLf &
                                    "INSERT INTO TTI_detail (cek4) " & vbCrLf &
                                    "Values(" & QVal(Me.cek4) & ")"
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateApDocUser7()
        Try

            '          Dim ls_SP As String = "UPDATE ardoc SET  user5=(case when user4=0 then 0 else User4-" & QVal(Paid) & " end),user5='1', user4=(case when user4=0 then 0 else User4-" & QVal(Paid) & " end)  WHERE refnbr = " & QVal(No_Invoice) & ""
            ''Dim ls_SP As String = "UPDATE apdoc SET user4=2 WHERE InvcNbr = " & QVal(No_Invoice) & ""
            Dim ls_SP As String = "update ARDoc set Ardoc.user7=" & QVal(Tgl) & " where Ardoc.refnbr = " & QVal(No_Invoice) & ""
            MainModul.ExecQuery_Solomon(ls_SP)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub Updateprosesbankreceipt()
        Try

            Dim ls_SP As String = "UPDATE bankreceipt set proses=1 WHERE nobukti = " & QVal(NoBukti) & ""
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub DeleteDetail(ByVal _vrno As String)
        Try
            Dim ls_SP As String = "DELETE FROM TTI_detail WHERE rtrim(vrno)=" & QVal(_vrno.TrimEnd) & ""
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub UpdateCheckDetailByVrnoInvcId()
        Try

            Dim ls_SP As String = "UPDATE TTI_detail SET Cek1=0 WHERE vrno= " & QVal(vrno) & " AND No_Invoice = " & QVal(No_Invoice) & ""
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Sub UpdateCheckDetailByVrnoInvcIdDir1()
        Try

            Dim ls_SP As String = "UPDATE TTI_detail SET Cek1=1,cek2=0,cek3=0,cek4=1 WHERE vrno= " & QVal(vrno) & " AND No_Invoice = " & QVal(No_Invoice) & ""
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub UpdateCheckDetailByVrnoInvcIdDir0()
        Try

            Dim ls_SP As String = "UPDATE TTI_detail SET Cek1=0,cek2=0,cek3=0,cek4=0 WHERE vrno= " & QVal(vrno) & " AND No_Invoice = " & QVal(No_Invoice) & ""
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

End Class
