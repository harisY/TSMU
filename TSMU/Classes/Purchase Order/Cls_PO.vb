Imports System.Collections.ObjectModel
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Net
Imports System.Net.Mail
Public Class Cls_PO


    'Public Property AutoNumber As String
    'Public Property H_Id As Int32
    'Public Property H_ApprovalDate As Date
    'Public Property H_ApprovalPIC As String
    'Public Property H_ApprovalRemark As String
    'Public Property H_LocId As String
    'Public Property H_LUpd_DateTime As Date
    'Public Property H_LUpd_Prog As String
    'Public Property H_LUpd_User As String
    'Public Property H_PRDate As Date
    'Public Property H_PRNo As String
    'Public Property H_Remark As String
    'Public Property H_SecId As String
    'Public Property H_SeqRev As Int32
    'Public Property H_StatusFlag As String
    ''Public Property H_tstamp As String
    'Public Property H_CreateDate As Date
    'Public Property H_CreateBy As String
    'Public Property H_UpdateDate As Date
    'Public Property H_UpdateBy As String
    'Public Property H_Sirkulasi As String

    Public Property H_AckDateTime As DateTime
    Public Property H_BatNbr As String
    Public Property H_BillShipAddr As Short
    Public Property H_BlktExprDate As DateTime
    Public Property H_BlktPONbr As String
    Public Property H_Buyer As String
    Public Property H_CertCompl As Short
    Public Property H_ConfirmTo As String
    Public Property H_CpnyID As String
    Public Property H_Crtd_DateTime As DateTime
    Public Property H_Crtd_Prog As String
    Public Property H_Crtd_User As String
    Public Property H_CurrentNbr As Short
    Public Property H_CuryEffDate As DateTime
    Public Property H_CuryFreight As Double
    Public Property H_CuryID As String
    Public Property H_CuryMultDiv As String
    Public Property H_CuryPOAmt As Double
    Public Property H_CuryPOItemTotal As Double
    Public Property H_CuryRate As Double
    Public Property H_CuryRateType As String
    Public Property H_CuryRcptTotAmt As Double
    Public Property H_CuryTaxTot00 As Double
    Public Property H_CuryTaxTot01 As Double
    Public Property H_CuryTaxTot02 As Double
    Public Property H_CuryTaxTot03 As Double
    Public Property H_CuryTxblTot00 As Double
    Public Property H_CuryTxblTot01 As Double
    Public Property H_CuryTxblTot02 As Double
    Public Property H_CuryTxblTot03 As Double
    Public Property H_EDI As Short
    Public Property H_FOB As String
    Public Property H_Freight As Double
    Public Property H_LastRcptDate As DateTime
    Public Property H_LineCntr As Integer
    Public Property H_LUpd_DateTime As DateTime
    Public Property H_LUpd_Prog As String
    Public Property H_LUpd_User As String
    Public Property H_NoteID As Integer
    Public Property H_OpenPO As Short
    Public Property H_PC_Status As String
    Public Property H_PerClosed As String
    Public Property H_PerEnt As String
    Public Property H_POAmt As Double
    Public Property H_PODate As DateTime
    Public Property H_POItemTotal As Double
    Public Property H_PONbr As String
    Public Property H_POType As String
    Public Property H_ProjectID As String
    Public Property H_PrtBatNbr As String
    Public Property H_PrtFlg As Short
    Public Property H_RcptStage As String
    Public Property H_RcptTotAmt As Double
    Public Property H_ReqNbr As String
    Public Property H_S4Future01 As String
    Public Property H_S4Future02 As String
    Public Property H_S4Future03 As Double
    Public Property H_S4Future04 As Double
    Public Property H_S4Future05 As Double
    Public Property H_S4Future06 As Double
    Public Property H_S4Future07 As DateTime
    Public Property H_S4Future08 As DateTime
    Public Property H_S4Future09 As Integer
    Public Property H_S4Future10 As Integer
    Public Property H_S4Future11 As String
    Public Property H_S4Future12 As String
    Public Property H_ServiceCallID As String
    Public Property H_ShipAddr1 As String
    Public Property H_ShipAddr2 As String
    Public Property H_ShipAddrID As String
    Public Property H_ShipAttn As String
    Public Property H_ShipCity As String
    Public Property H_ShipCountry As String
    Public Property H_ShipCustID As String
    Public Property H_ShipEmail As String
    Public Property H_ShipFax As String
    Public Property H_ShipName As String
    Public Property H_ShipPhone As String
    Public Property H_ShipSiteID As String
    Public Property H_ShipState As String
    Public Property H_ShiptoID As String
    Public Property H_ShiptoType As String
    Public Property H_ShipVendAddrID As String
    Public Property H_ShipVendID As String
    Public Property H_ShipVia As String
    Public Property H_ShipZip As String
    Public Property H_Status As String
    Public Property H_TaxCntr00 As Short
    Public Property H_TaxCntr01 As Short
    Public Property H_TaxCntr02 As Short
    Public Property H_TaxCntr03 As Short
    Public Property H_TaxID00 As String
    Public Property H_TaxID01 As String
    Public Property H_TaxID02 As String
    Public Property H_TaxID03 As String
    Public Property H_TaxTot00 As Double
    Public Property H_TaxTot01 As Double
    Public Property H_TaxTot02 As Double
    Public Property H_TaxTot03 As Double
    Public Property H_Terms As String
    Public Property H_tstamp As DateTime
    Public Property H_TxblTot00 As Double
    Public Property H_TxblTot01 As Double
    Public Property H_TxblTot02 As Double
    Public Property H_TxblTot03 As Double
    Public Property H_User1 As String
    Public Property H_User2 As String
    Public Property H_User3 As Double
    Public Property H_User4 As Double
    Public Property H_User5 As String
    Public Property H_User6 As String
    Public Property H_User7 As DateTime
    Public Property H_User8 As DateTime
    Public Property H_VendAddr1 As String
    Public Property H_VendAddr2 As String
    Public Property H_VendAddrID As String
    Public Property H_VendAttn As String
    Public Property H_VendCity As String
    Public Property H_VendCountry As String
    Public Property H_VendEmail As String
    Public Property H_VendFax As String
    Public Property H_VendID As String
    Public Property H_VendName As String
    Public Property H_VendPhone As String
    Public Property H_VendState As String
    Public Property H_VendZip As String
    Public Property H_VouchStage As String

    Public Property Collection_Detail() As New Collection(Of Cls_PO_Detail)







    Public Function Get_PO() As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[PO_D_GetPO]"
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function


    Public Function Get_PR() As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[PO_D_GetPR]"
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function Get_PRDetail(PRNo As String) As DataTable
        Try
            Dim query As String = "[PO_D_GetPRDetail]"
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

    Public Function Get_Vendor() As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[PO_D_GetVendor]"
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function Get_Site() As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[PO_D_GetSite]"
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function
    Public Function Get_OtherAddress() As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[PO_D_GetOtherAddress]"
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function Get_CustomerID() As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[PO_D_GetCustomerID]"
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function Get_CustomerAddress(CustId As String) As DataTable
        Try

            Dim query As String = "[PO_D_GetCustomerAddress]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@CustId", SqlDbType.VarChar)
            pParam(0).Value = CustId
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt

        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function Get_VendorAddress(VendorId As String) As DataTable
        Try

            Dim query As String = "[PO_D_GetVendorAddress]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@VendorId", SqlDbType.VarChar)
            pParam(0).Value = VendorId
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt

        Catch ex As Exception
            Throw
        End Try

    End Function


    Public Function Get_ShippingBySite(Site As String) As DataTable
        Try

            Dim query As String = "[PO_D_GetAddressBySite]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@Site", SqlDbType.VarChar)
            pParam(0).Value = Site
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt

        Catch ex As Exception
            Throw
        End Try

    End Function
    Public Function Get_ShippingByAddres(Addres As String) As DataTable
        Try

            Dim query As String = "[PO_D_GetAddressByAddrId]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@AddrId", SqlDbType.VarChar)
            pParam(0).Value = Addres
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
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
                        Insert_PRHeader(H_PONbr,
                                        H_CpnyID,
                                        H_Crtd_DateTime,
                                        H_Crtd_Prog,
                                        H_Crtd_User,
                                        H_CurrentNbr,
                                        H_CuryEffDate,
                                        H_CuryFreight,
                                        H_CuryID,
                                        H_CuryMultDiv,
                                        H_CuryPOAmt,
                                        H_CuryRate,
                                        H_CuryRateType,
                                        H_CuryRcptTotAmt,
                                        H_LineCntr,
                                        H_LUpd_DateTime,
                                        H_LUpd_Prog,
                                        H_LUpd_User,
                                        H_NoteID,
                                        H_PerClosed,
                                        H_PerEnt,
                                        H_POType,
                                        H_ProjectID,
                                        H_RcptStage,
                                        H_ShipAddr1,
                                        H_ShipAddr2,
                                        H_ShipAddrID,
                                        H_ShipAttn,
                                        H_ShipCity,
                                        H_ShipCountry,
                                        H_ShipCustID,
                                        H_ShipEmail,
                                        H_ShipFax,
                                        H_ShipName,
                                        H_ShipPhone,
                                        H_ShipSiteID,
                                        H_ShipState,
                                        H_ShipZip,
                                        H_VendAddr1,
                                        H_VendAddr2,
                                        H_VendAddrID,
                                        H_VendAttn,
                                        H_VendCity,
                                        H_VendCountry,
                                        H_VendEmail,
                                        H_VendFax,
                                        H_VendID,
                                        H_VendName,
                                        H_VendPhone,
                                        H_VendState,
                                        H_VendZip)
                        'For i As Integer = 0 To Collection_Detail.Count - 1
                        '    With Collection_Detail(i)
                        '        .InsertCR_Description_Of_Cost()
                        '    End With
                        'Next

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



    Public Sub Insert_PRHeader(PONbr As String,
                               CpnyID As String,
                               Crtd_DateTime As Date,
                               Crtd_Prog As String,
                               Crtd_User As String,
                               CurrentNbr As String,
                               CuryEffDate As Date,
                               CuryFreight As Integer,
                               CuryID As String,
                               CuryMultDiv As String,
                               CuryPOAmt As Double,
                               CuryRate As Double,
                               CuryRateType As String,
                               CuryRcptTotAmt As Double,
                               LineCntr As Double,
                               LUpd_DateTime As Date,
                               LUpd_Prog As String,
                               LUpd_User As String,
                               NoteID As Double,
                               PerClosed As String,
                               PerEnt As String,
                               POType As String,
                               ProjectID As String,
                               RcptStage As String,
                               ShipAddr1 As String,
                               ShipAddr2 As String,
                               ShipAddrID As String,
                               ShipAttn As String,
                               ShipCity As String,
                               ShipCountry As String,
                               ShipCustID As String,
                               ShipEmail As String,
                               ShipFax As String,
                               ShipName As String,
                               ShipPhone As String,
                               ShipSiteID As String,
                               ShipState As String,
                               Shipzip As String,
                               VendAddr1 As String,
                               VendAddr2 As String,
                               VendAddrID As String,
                               VendAttn As String,
                               VendCity As String,
                               VendCountry As String,
                               VendEmail As String,
                               VendFax As String,
                               VendID As String,
                               VendName As String,
                               VendPhone As String,
                               VendState As String,
                               VendZip As String)


        Dim ls_TA As String = "INSERT INTO [PurchOrd]
                                          (PONbr ,
                                           CpnyID ,
                                           Crtd_DateTime ,
                                           Crtd_Prog ,
                                           Crtd_User ,
                                           CurrentNbr ,
                                           CuryEffDate ,
                                           CuryFreight ,
                                           CuryID ,
                                           CuryMultDiv ,
                                           CuryPOAmt ,
                                           CuryRate ,
                                           CuryRateType ,
                                           CuryRcptTotAmt ,
                                           LineCntr ,
                                           LUpd_DateTime ,
                                           LUpd_Prog ,
                                           LUpd_User ,
                                           NoteID ,
                                           PerClosed ,
                                           PerEnt ,
                                           POType ,
                                           ProjectID ,
                                           RcptStage ,
                                           ShipAddr1 ,
                                           ShipAddr2 ,
                                           ShipAddrID ,
                                           ShipAttn ,
                                           ShipCity ,
                                           ShipCountry ,
                                           ShipCustID ,
                                           ShipEmail ,
                                           ShipFax ,
                                           ShipName ,
                                           ShipPhone ,
                                           ShipSiteID ,
                                           ShipState ,
                                           Shipzip ,
                                           VendAddr1 ,
                                           VendAddr2 ,
                                           VendAddrID ,
                                           VendAttn ,
                                           VendCity ,
                                           VendCountry ,
                                           VendEmail ,
                                           VendFax ,
                                           VendID ,
                                           VendName ,
                                           VendPhone ,
                                           VendState ,
                                           VendZip )
                                         VALUES
                                               ('" & PONbr & "'
                                               ,'" & CpnyID & "'
                                               ,'" & Crtd_DateTime & "'
                                               ,'" & Crtd_Prog & "'
                                               ,'" & Crtd_User & "'
                                               ,'" & CurrentNbr & "'
                                               ,'" & CuryEffDate & "'
                                               ,'" & CuryFreight & "'
                                               ,'" & CuryID & "'
                                               ,'" & CuryMultDiv & "'
                                               ,'" & CuryPOAmt & "'
                                               ,'" & CuryRate & "'
                                               ,'" & CuryRateType & "'
                                               ,'" & CuryRcptTotAmt & "'
                                               ,'" & LineCntr & "'
                                               ,'" & LUpd_DateTime & "'
                                               ,'" & LUpd_Prog & "'
                                               ,'" & LUpd_User & "'
                                               ,'" & NoteID & "'
                                               ,'" & PerClosed & "'
                                               ,'" & PerEnt & "'
                                               ,'" & POType & "'
                                               ,'" & ProjectID & "'
                                               ,'" & RcptStage & "'
                                               ,'" & ShipAddr1 & "'
                                               ,'" & ShipAddr2 & "'
                                               ,'" & ShipAddrID & "'
                                               ,'" & ShipAttn & "'
                                               ,'" & ShipCity & "'
                                               ,'" & ShipCountry & "'
                                               ,'" & ShipCustID & "'
                                               ,'" & ShipEmail & "'
                                               ,'" & ShipFax & "'
                                               ,'" & ShipName & "'
                                               ,'" & ShipPhone & "'
                                               ,'" & ShipSiteID & "'
                                               ,'" & ShipState & "'
                                               ,'" & Shipzip & "'
                                               ,'" & VendAddr1 & "'
                                               ,'" & VendAddr2 & "'
                                               ,'" & VendAddrID & "'
                                               ,'" & VendAttn & "'
                                               ,'" & VendCity & "'
                                               ,'" & VendCountry & "'
                                               ,'" & VendEmail & "'
                                               ,'" & VendFax & "'
                                               ,'" & VendID & "'
                                               ,'" & VendName & "'
                                               ,'" & VendPhone & "'
                                               ,'" & VendState & "'
                                               ,'" & VendZip & "')"
        MainModul.ExecQuery(ls_TA)


    End Sub


End Class

Public Class Cls_PO_Detail

End Class
