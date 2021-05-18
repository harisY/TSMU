Imports System.Collections.ObjectModel
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Net
Imports System.Net.Mail
Public Class Cls_PO

    Public Property ID As String
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
            'Dim query As String = "[PO_D_GetPR]"
            'Dim dt As New DataTable
            'dt = GetDataTableByCommand_SP(query)
            'Return dt

            Dim query As String = "[PO_D_GetPR]"
            'Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            'pParam(0) = New SqlClient.SqlParameter("@VendorID", SqlDbType.VarChar)
            'pParam(0).Value = Vendor
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
            'pParam(1) = New SqlClient.SqlParameter("@Vendor", SqlDbType.VarChar)

            pParam(0).Value = PRNo
            'pParam(1).Value = Vendor
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt

        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function Get_CekHarga(InvtID As String, loc As Integer) As DataTable
        Try
            Dim query As String = "[PO_D_GetCekHarga]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@InvtID", SqlDbType.VarChar)
            pParam(1) = New SqlClient.SqlParameter("@loc", SqlDbType.Int)

            pParam(0).Value = InvtID
            pParam(1).Value = loc
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt

        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function Get_Delete(PONo As String) As DataTable
        Try
            Dim query As String = "[PO_D_Get_Delete]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@PONo", SqlDbType.VarChar)

            pParam(0).Value = PONo
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt

        Catch ex As Exception
            Throw
        End Try

    End Function


    Public Function Get_POHeader() As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[PO_D_Header]"
            'Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
            'pParam(0) = New SqlClient.SqlParameter("@deptID", SqlDbType.VarChar)
            'pParam(1) = New SqlClient.SqlParameter("@pDate1", SqlDbType.DateTime)
            'pParam(2) = New SqlClient.SqlParameter("@pDate2", SqlDbType.DateTime)


            'pParam(0).Value = Dept
            'pParam(1).Value = pDate1
            'pParam(2).Value = pDate2
            Dim dt As New DataTable
            'dt = GetDataTableByCommand_SP(query, pParam)
            dt = GetDataTableByCommand_SP(query)
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

    Public Function Get_MataUang() As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[PO_D_GetMataUang]"
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query)
            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function Get_Rate(CuryID As String, Efektif As Date) As DataTable
        Try

            Dim query As String = "[PO_D_GetRate]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@CuryID", SqlDbType.VarChar)
            pParam(1) = New SqlClient.SqlParameter("@Efektif", SqlDbType.Date)

            pParam(0).Value = CuryID
            pParam(1).Value = Efektif.AddMonths(-1)

            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt

        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function Get_AlterateID(Invetory As String, VendorID As String) As DataTable
        Try

            Dim query As String = "[PO_D_AlterateID]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@Invetory", SqlDbType.VarChar)
            pParam(1) = New SqlClient.SqlParameter("@VendorID ", SqlDbType.VarChar)

            pParam(0).Value = Invetory
            pParam(1).Value = VendorID

            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt

        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function Get_PODetail(PONumber As String) As DataTable
        Try

            Dim query As String = "[PO_D_GetPODetail]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@PONo", SqlDbType.VarChar)

            pParam(0).Value = PONumber

            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt

        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function Get_POHeader(PONumber As String) As DataTable
        Try

            Dim query As String = "[PO_D_GetPOHeader]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@PONo", SqlDbType.VarChar)

            pParam(0).Value = PONumber

            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt

        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function Get_POVendorName(VendID As String) As DataTable
        Try

            Dim query As String = "[PO_D_GetVendorName]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@VendID ", SqlDbType.VarChar)

            pParam(0).Value = VendID

            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(query, pParam)
            Return dt

        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function Get_Pajak() As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[PO_D_GetPajak]"
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
    Public Function Get_SiteDetail() As DataTable
        Try
            'Dim query As String = "[Generate_Report_Matome]"
            Dim query As String = "[PO_D_GetSiteDetail]"
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


    Public Function Get_TAX(Invetory As String) As DataTable
        Try

            Dim query As String = "[PO_D_GetTAX]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@Inventory", SqlDbType.VarChar)
            pParam(0).Value = Invetory
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
                        Insert_POHeader(H_PONbr,
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
                                        H_TaxID00,
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
                                        H_VendZip,
                                        H_VouchStage,
                                        H_Terms,
                                        H_User1,
                                        H_Status,
                                        H_PODate,
                                        H_User3,
                                        H_User4,
                                        H_POAmt,
                                        H_CuryPOAmt)


                        For i As Integer = 0 To Collection_Detail.Count - 1
                            With Collection_Detail(i)
                                .InsertDetailPO()
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


    Public Sub Update(PONumber As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        'InsertHistory(NPWO_)

                        Update_PoHeader(H_PONbr,
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
                                        H_TaxID00,
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
                                        H_VendZip,
                                        H_VouchStage,
                                        H_Terms,
                                        H_User1,
                                        H_Status,
                                        H_PODate,
                                        H_User3,
                                        H_User4,
                                        H_POAmt,
                                        H_CuryPOAmt)

                        Delete_Detail(PONumber)

                        For i As Integer = 0 To Collection_Detail.Count - 1
                            With Collection_Detail(i)
                                .InsertDetailPO()
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





    Public Sub Insert_POHeader(PONbr As String,
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
                               TaxID00 As String,
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
                               VendZip As String,
                               VouchStage As String,
                               Term As String,
                               user1 As String,
                               Status As String,
                               PODate As Date,
                               User3 As Double,
                               User4 As Double,
                               POAmt As Double,
                               CurPOAmt As Double)


        Dim ls_TA As String = "INSERT INTO [PurchOrd]
                                          (PONbr ,
                                           CpnyID ,
                                           Crtd_DateTime ,
                                           Crtd_Prog ,
                                           Crtd_User ,
                                           CurrentNbr ,
                                           CuryEffDate ,
                                           CuryFreight ,
                                           CuryMultDiv,
                                           CuryID ,
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
                                           TaxID00,
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
                                           VendZip ,
                                           VouchStage,
                                           Terms,
                                            User1,
                                            Status,
                                            PODate,
                                            User3,
                                            User4,
                                            POAmt)
                                         VALUES
                                               ('" & PONbr & "'
                                               ,'" & CpnyID & "'
                                               ,'" & Crtd_DateTime & "'
                                               ,'" & Crtd_Prog & "'
                                               ,'" & Crtd_User & "'
                                               ,'" & CurrentNbr & "'
                                               ,'" & CuryEffDate & "'
                                               ,'" & CuryFreight & "'
                                               ,'" & CuryMultDiv & "'
                                               ,'" & CuryID & "'
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
                                               ,'" & TaxID00 & "'
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
                                               ,'" & VendZip & "'
                                               ,'" & VouchStage & "'
                                               ,'" & Term & "'
                                               ,'" & user1 & "'
                                               ,'" & Status & "'
                                               ,'" & PODate & "'
                                               ,'" & User3 & "'
                                               ,'" & User4 & "'
                                               ,'" & POAmt & "')"
        MainModul.ExecQuery(ls_TA)


    End Sub


    Public Sub Update_PoHeader(PONbr As String,
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
                               TaxID00 As String,
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
                               VendZip As String,
                               VouchStage As String,
                               Term As String,
                               user1 As String,
                               Status As String,
                               PODate As Date,
                               User3 As Double,
                               User4 As Double,
                               POAmt As Double,
                               CurPOAmt As Double)

        'Dim result As Integer = 0
        Try
            '    If Parent = "" Then
            '        Parent = DBNull.Value.ToString
            '    End If


            '    If Customer_Name = "" Then
            '        Customer_Name = DBNull.Value.ToString
            '    End If


            '    If NameItem = "" Then
            '        NameItem = DBNull.Value.ToString
            '    End If

            '    If Spesification = "" Then
            '        Spesification = DBNull.Value.ToString
            '    End If

            Dim ls_SP As String = "UPDATE [PurchOrd]
                                       SET [CpnyID ] = '" & CpnyID & "'
                                            ,[Crtd_DateTime ] = '" & Crtd_DateTime & "'	
                                            ,[Crtd_Prog ] = '" & Crtd_Prog & "'	
                                            ,[Crtd_User ] = '" & Crtd_User & "'	
                                            ,[CurrentNbr ] = '" & CurrentNbr & "'	
                                            ,[CuryEffDate ] = '" & CuryEffDate & "'	
                                            ,[CuryFreight ] = '" & CuryFreight & "'	
                                            ,[CuryMultDiv] = '" & CuryMultDiv & "'	
                                            ,[CuryID ] = '" & CuryID & "'	
                                            ,[CuryPOAmt ] = '" & CuryPOAmt & "'	
                                            ,[CuryRate ] = '" & CuryRate & "'	
                                            ,[CuryRateType ] = '" & CuryRateType & "'	
                                            ,[CuryRcptTotAmt ] = '" & CuryRcptTotAmt & "'	
                                            ,[LineCntr ] = '" & LineCntr & "'	
                                            ,[LUpd_DateTime ] = '" & LUpd_DateTime & "'	
                                            ,[LUpd_Prog ] = '" & LUpd_Prog & "'	
                                            ,[LUpd_User ] = '" & LUpd_User & "'	
                                            ,[NoteID ] = '" & NoteID & "'	
                                            ,[PerClosed ] = '" & PerClosed & "'	
                                            ,[PerEnt ] = '" & PerEnt & "'	
                                            ,[POType ] = '" & POType & "'	
                                            ,[ProjectID ] = '" & ProjectID & "'	
                                            ,[RcptStage ] = '" & RcptStage & "'	
                                            ,[ShipAddr1 ] = '" & ShipAddr1 & "'	
                                            ,[ShipAddr2 ] = '" & ShipAddr2 & "'	
                                            ,[ShipAddrID ] = '" & ShipAddrID & "'	
                                            ,[ShipAttn ] = '" & ShipAttn & "'	
                                            ,[ShipCity ] = '" & ShipCity & "'	
                                            ,[ShipCountry ] = '" & ShipCountry & "'	
                                            ,[ShipCustID ] = '" & ShipCustID & "'	
                                            ,[ShipEmail ] = '" & ShipEmail & "'	
                                            ,[ShipFax ] = '" & ShipFax & "'	
                                            ,[ShipName ] = '" & ShipName & "'	
                                            ,[ShipPhone ] = '" & ShipPhone & "'	
                                            ,[ShipSiteID ] = '" & ShipSiteID & "'	
                                            ,[ShipState ] = '" & ShipState & "'	
                                            ,[Shipzip ] = '" & Shipzip & "'	
                                            ,[TaxID00] = '" & TaxID00 & "'	
                                            ,[VendAddr1 ] = '" & VendAddr1 & "'	
                                            ,[VendAddr2 ] = '" & VendAddr2 & "'	
                                            ,[VendAddrID ] = '" & VendAddrID & "'	
                                            ,[VendAttn ] = '" & VendAttn & "'	
                                            ,[VendCity ] = '" & VendCity & "'	
                                            ,[VendCountry ] = '" & VendCountry & "'	
                                            ,[VendEmail ] = '" & VendEmail & "'	
                                            ,[VendFax ] = '" & VendFax & "'	
                                            ,[VendID ] = '" & VendID & "'	
                                            ,[VendName ] = '" & VendName & "'	
                                            ,[VendPhone ] = '" & VendPhone & "'	
                                            ,[VendState ] = '" & VendState & "'	
                                            ,[VendZip ] = '" & VendZip & "'	
                                            ,[VouchStage] = '" & VouchStage & "'	
                                            ,[Terms] = '" & Term & "'	
                                            ,[User1] = '" & user1 & "'	
                                            ,[Status] = '" & Status & "'	
                                            ,[PODate] = '" & PODate & "'	
                                            ,[User3] = '" & User3 & "'	
                                            ,[User4] = '" & User4 & "'	
                                            ,[POAmt] = '" & POAmt & "'	
                                     WHERE [PONbr ] = '" & H_PONbr & "'"



            MainModul.ExecQuery(ls_SP)



        Catch ex As Exception
            Throw
        End Try

    End Sub


    Public Sub Delete_Detail(PONumber As String)
        Try
            Try


                Dim query As String = "Delete From [PurOrdDet] Where PONbr = '" & PONumber & "' "

                MainModul.ExecQueryByCommand(query)
            Catch ex As Exception
                Throw
            End Try

        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Sub ValidateInsert()
        'If Me.NoAbsen = "" Then
        '    Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
        'End If
        Try
            Dim ls_SP As String = "SELECT TOP 1 *                     
                                    FROM PurchOrd where PONbr = '" & H_PONbr & "'"
            Dim dtTable As New DataTable
            'dtTable = MainModul.GetDataTableByCommand(ls_SP)
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
                "[" & Me.H_PONbr & "]")

            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub



    Public Sub Delete(PONo As String)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        Dim query As String = "[PO_D_Delete]"
                        Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
                        pParam(0) = New SqlClient.SqlParameter("@PONo", SqlDbType.VarChar)

                        pParam(0).Value = PONo

                        MainModul.ExecQueryByCommand_SP(query, pParam)

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

End Class

Public Class Cls_PO_Detail

    Public Property D_AddlCostPct As Double
    Public Property D_AllocCntr As Short
    Public Property D_AlternateID As String
    Public Property D_AltIDType As String
    Public Property D_BlktLineID As Integer
    Public Property D_BlktLineRef As String
    Public Property D_Buyer As String
    Public Property D_CnvFact As Double
    Public Property D_CostReceived As Double
    Public Property D_CostReturned As Double
    Public Property D_CostVouched As Double
    Public Property D_CpnyID As String
    Public Property D_Crtd_DateTime As DateTime
    Public Property D_Crtd_Prog As String
    Public Property D_Crtd_User As String
    Public Property D_CuryCostReceived As Double
    Public Property D_CuryCostReturned As Double
    Public Property D_CuryCostVouched As Double
    Public Property D_CuryExtCost As Double
    Public Property D_CuryID As String
    Public Property D_CuryMultDiv As String
    Public Property D_CuryRate As Double
    Public Property D_CuryTaxAmt00 As Double
    Public Property D_CuryTaxAmt01 As Double
    Public Property D_CuryTaxAmt02 As Double
    Public Property D_CuryTaxAmt03 As Double
    Public Property D_CuryTxblAmt00 As Double
    Public Property D_CuryTxblAmt01 As Double
    Public Property D_CuryTxblAmt02 As Double
    Public Property D_CuryTxblAmt03 As Double
    Public Property D_CuryUnitCost As Double
    Public Property D_ExtCost As Double
    Public Property D_ExtWeight As Double
    Public Property D_FlatRateLineNbr As Short
    Public Property D_InclForecastUsageClc As Short
    Public Property D_InvtID As String
    Public Property D_IRIncLeadTime As Short
    Public Property D_KitUnExpld As Short
    Public Property D_Labor_Class_Cd As String
    Public Property D_LineID As Integer
    Public Property D_LineNbr As Short
    Public Property D_LineRef As String
    Public Property D_LUpd_DateTime As DateTime
    Public Property D_LUpd_Prog As String
    Public Property D_LUpd_User As String
    Public Property D_NoteID As Integer
    Public Property D_OpenLine As Short
    Public Property D_OrigPOLine As Short
    Public Property D_PC_Flag As String
    Public Property D_PC_ID As String
    Public Property D_PC_Status As String
    Public Property D_PONbr As String
    Public Property D_POType As String
    Public Property D_ProjectID As String
    Public Property D_PromDate As DateTime
    Public Property D_PurAcct As String
    Public Property D_PurchaseType As String
    Public Property D_PurchUnit As String
    Public Property D_PurSub As String
    Public Property D_QtyOrd As Double
    Public Property D_QtyRcvd As Double
    Public Property D_QtyReturned As Double
    Public Property D_QtyVouched As Double
    Public Property D_RcptPctAct As String
    Public Property D_RcptPctMax As Double
    Public Property D_RcptPctMin As Double
    Public Property D_RcptStage As String
    Public Property D_ReasonCd As String
    Public Property D_ReqdDate As DateTime
    Public Property D_ReqNbr As String
    Public Property D_S4Future01 As String
    Public Property D_S4Future02 As String
    Public Property D_S4Future03 As Double
    Public Property D_S4Future04 As Double
    Public Property D_S4Future05 As Double
    Public Property D_S4Future06 As Double
    Public Property D_S4Future07 As DateTime
    Public Property D_S4Future08 As DateTime
    Public Property D_S4Future09 As Integer
    Public Property D_S4Future10 As Integer
    Public Property D_S4Future11 As String
    Public Property D_S4Future12 As String
    Public Property D_ServiceCallID As String
    Public Property D_ShelfLife As Short
    Public Property D_ShipAddr1 As String
    Public Property D_ShipAddr2 As String
    Public Property D_ShipAddrID As String
    Public Property D_ShipCity As String
    Public Property D_ShipCountry As String
    Public Property D_ShipName As String
    Public Property D_ShipState As String
    Public Property D_ShipViaID As String
    Public Property D_ShipZip As String
    Public Property D_SiteID As String
    Public Property D_SOLineRef As String
    Public Property D_SOOrdNbr As String
    Public Property D_SOSchedRef As String
    Public Property D_StepNbr As Short
    Public Property D_SvcContractID As String
    Public Property D_SvcLineNbr As Short
    Public Property D_TaskID As String
    Public Property D_TaxAmt00 As Double
    Public Property D_TaxAmt01 As Double
    Public Property D_TaxAmt02 As Double
    Public Property D_TaxAmt03 As Double
    Public Property D_TaxCalced As String
    Public Property D_TaxCat As String
    Public Property D_TaxID00 As String
    Public Property D_TaxID01 As String
    Public Property D_TaxID02 As String
    Public Property D_TaxID03 As String
    Public Property D_TaxIdDflt As String
    Public Property D_TranDesc As String
    Public Property D_tstamp As DateTime
    Public Property D_TxblAmt00 As Double
    Public Property D_TxblAmt01 As Double
    Public Property D_TxblAmt02 As Double
    Public Property D_TxblAmt03 As Double
    Public Property D_UnitCost As Double
    Public Property D_UnitMultDiv As String
    Public Property D_UnitWeight As Double
    Public Property D_User1 As String
    Public Property D_User2 As String
    Public Property D_User3 As Double
    Public Property D_User4 As Double
    Public Property D_User5 As String
    Public Property D_User6 As String
    Public Property D_User7 As DateTime
    Public Property D_User8 As DateTime
    Public Property D_VouchStage As String
    Public Property D_WOBOMSeq As Short
    Public Property D_WOCostType As String
    Public Property D_WONbr As String
    Public Property D_WOStepNbr As Short



    Public Sub InsertDetailPO()

        Try

            Dim ls_TA As String = "INSERT INTO [PurOrdDet]
                                               ([AddlCostPct]
                                               ,[AllocCntr]
                                               ,[AlternateID]
                                               ,[AltIDType]
                                               ,[BlktLineID]
                                               ,[BlktLineRef]
                                               ,[Buyer]
                                               ,[CnvFact]
                                               ,[CostReceived]
                                               ,[CostReturned]
                                               ,[CostVouched]
                                               ,[CpnyID]
                                               ,[Crtd_DateTime]
                                               ,[Crtd_Prog]
                                               ,[Crtd_User]
                                               ,[CuryCostReceived]
                                               ,[CuryCostReturned]
                                               ,[CuryCostVouched]
                                               ,[CuryExtCost]
                                               ,[CuryID]
                                               ,[CuryMultDiv]
                                               ,[CuryRate]
                                               ,[CuryTaxAmt00]
                                               ,[CuryTaxAmt01]
                                               ,[CuryTaxAmt02]
                                               ,[CuryTaxAmt03]
                                               ,[CuryTxblAmt00]
                                               ,[CuryTxblAmt01]
                                               ,[CuryTxblAmt02]
                                               ,[CuryTxblAmt03]
                                               ,[CuryUnitCost]
                                               ,[ExtCost]
                                               ,[ExtWeight]
                                               ,[FlatRateLineNbr]
                                               ,[InclForecastUsageClc]
                                               ,[InvtID]
                                               ,[IRIncLeadTime]
                                               ,[KitUnExpld]
                                               ,[Labor_Class_Cd]
                                               ,[LineID]
                                               ,[LineNbr]
                                               ,[LineRef]
                                               ,[LUpd_DateTime]
                                               ,[LUpd_Prog]
                                               ,[LUpd_User]
                                               ,[NoteID]
                                               ,[OpenLine]
                                               ,[OrigPOLine]
                                               ,[PC_Flag]
                                               ,[PC_ID]
                                               ,[PC_Status]
                                               ,[PONbr]
                                               ,[POType]
                                               ,[ProjectID]
                                               ,[PromDate]
                                               ,[PurAcct]
                                               ,[PurchaseType]
                                               ,[PurchUnit]
                                               ,[PurSub]
                                               ,[QtyOrd]
                                               ,[QtyRcvd]
                                               ,[QtyReturned]
                                               ,[QtyVouched]
                                               ,[RcptPctAct]
                                               ,[RcptPctMax]
                                               ,[RcptPctMin]
                                               ,[RcptStage]
                                               ,[ReasonCd]
                                               ,[ReqdDate]
                                               ,[ReqNbr]
                                               ,[S4Future01]
                                               ,[S4Future02]
                                               ,[S4Future03]
                                               ,[S4Future04]
                                               ,[S4Future05]
                                               ,[S4Future06]
                                               ,[S4Future07]
                                               ,[S4Future08]
                                               ,[S4Future09]
                                               ,[S4Future10]
                                               ,[S4Future11]
                                               ,[S4Future12]
                                               ,[ServiceCallID]
                                               ,[ShelfLife]
                                               ,[ShipAddr1]
                                               ,[ShipAddr2]
                                               ,[ShipAddrID]
                                               ,[ShipCity]
                                               ,[ShipCountry]
                                               ,[ShipName]
                                               ,[ShipState]
                                               ,[ShipViaID]
                                               ,[ShipZip]
                                               ,[SiteID]
                                               ,[SOLineRef]
                                               ,[SOOrdNbr]
                                               ,[SOSchedRef]
                                               ,[StepNbr]
                                               ,[SvcContractID]
                                               ,[SvcLineNbr]
                                               ,[TaskID]
                                               ,[TaxAmt00]
                                               ,[TaxAmt01]
                                               ,[TaxAmt02]
                                               ,[TaxAmt03]
                                               ,[TaxCalced]
                                               ,[TaxCat]
                                               ,[TaxID00]
                                               ,[TaxID01]
                                               ,[TaxID02]
                                               ,[TaxID03]
                                               ,[TaxIdDflt]
                                               ,[TranDesc]
                                               ,[TxblAmt00]
                                               ,[TxblAmt01]
                                               ,[TxblAmt02]
                                               ,[TxblAmt03]
                                               ,[UnitCost]
                                               ,[UnitMultDiv]
                                               ,[UnitWeight]
                                               ,[User1]
                                               ,[User2]
                                               ,[User3]
                                               ,[User4]
                                               ,[User5]
                                               ,[User6]
                                               ,[User7]
                                               ,[User8]
                                               ,[VouchStage]
                                               ,[WOBOMSeq]
                                               ,[WOCostType]
                                               ,[WONbr]
                                               ,[WOStepNbr])
                                         VALUES
                                               ('" & D_AddlCostPct & "'
                                                ,'" & D_AllocCntr & "'
                                                ,'" & D_AlternateID & "'
                                                ,'" & D_AltIDType & "'
                                                ,'" & D_BlktLineID & "'
                                                ,'" & D_BlktLineRef & "'
                                                ,'" & D_Buyer & "'
                                                ,'" & D_CnvFact & "'
                                                ,'" & D_CostReceived & "'
                                                ,'" & D_CostReturned & "'
                                                ,'" & D_CostVouched & "'
                                                ,'" & D_CpnyID & "'
                                                ,'" & D_Crtd_DateTime & "'
                                                ,'" & D_Crtd_Prog & "'
                                                ,'" & D_Crtd_User & "'
                                                ,'" & D_CuryCostReceived & "'
                                                ,'" & D_CuryCostReturned & "'
                                                ,'" & D_CuryCostVouched & "'
                                                ,'" & D_CuryExtCost & "'
                                                ,'" & D_CuryID & "'
                                                ,'" & D_CuryMultDiv & "'
                                                ,'" & D_CuryRate & "'
                                                ,'" & D_CuryTaxAmt00 & "'
                                                ,'" & D_CuryTaxAmt01 & "'
                                                ,'" & D_CuryTaxAmt02 & "'
                                                ,'" & D_CuryTaxAmt03 & "'
                                                ,'" & D_CuryTxblAmt00 & "'
                                                ,'" & D_CuryTxblAmt01 & "'
                                                ,'" & D_CuryTxblAmt02 & "'
                                                ,'" & D_CuryTxblAmt03 & "'
                                                ,'" & D_CuryUnitCost & "'
                                                ,'" & D_ExtCost & "'
                                                ,'" & D_ExtWeight & "'
                                                ,'" & D_FlatRateLineNbr & "'
                                                ,'" & D_InclForecastUsageClc & "'
                                                ,'" & D_InvtID & "'
                                                ,'" & D_IRIncLeadTime & "'
                                                ,'" & D_KitUnExpld & "'
                                                ,'" & D_Labor_Class_Cd & "'
                                                ,'" & D_LineID & "'
                                                ,'" & D_LineNbr & "'
                                                ,'" & D_LineRef & "'
                                                ,'" & D_LUpd_DateTime & "'
                                                ,'" & D_LUpd_Prog & "'
                                                ,'" & D_LUpd_User & "'
                                                ,'" & D_NoteID & "'
                                                ,'" & D_OpenLine & "'
                                                ,'" & D_OrigPOLine & "'
                                                ,'" & D_PC_Flag & "'
                                                ,'" & D_PC_ID & "'
                                                ,'" & D_PC_Status & "'
                                                ,'" & D_PONbr & "'
                                                ,'" & D_POType & "'
                                                ,'" & D_ProjectID & "'
                                                ,'" & D_PromDate & "'
                                                ,'" & D_PurAcct & "'
                                                ,'" & D_PurchaseType & "'
                                                ,'" & D_PurchUnit & "'
                                                ,'" & D_PurSub & "'
                                                ,'" & D_QtyOrd & "'
                                                ,'" & D_QtyRcvd & "'
                                                ,'" & D_QtyReturned & "'
                                                ,'" & D_QtyVouched & "'
                                                ,'" & D_RcptPctAct & "'
                                                ,'" & D_RcptPctMax & "'
                                                ,'" & D_RcptPctMin & "'
                                                ,'" & D_RcptStage & "'
                                                ,'" & D_ReasonCd & "'
                                                ,'" & D_ReqdDate & "'
                                                ,'" & D_ReqNbr & "'
                                                ,'" & D_S4Future01 & "'
                                                ,'" & D_S4Future02 & "'
                                                ,'" & D_S4Future03 & "'
                                                ,'" & D_S4Future04 & "'
                                                ,'" & D_S4Future05 & "'
                                                ,'" & D_S4Future06 & "'
                                                ,'" & D_S4Future07 & "'
                                                ,'" & D_S4Future08 & "'
                                                ,'" & D_S4Future09 & "'
                                                ,'" & D_S4Future10 & "'
                                                ,'" & D_S4Future11 & "'
                                                ,'" & D_S4Future12 & "'
                                                ,'" & D_ServiceCallID & "'
                                                ,'" & D_ShelfLife & "'
                                                ,'" & D_ShipAddr1 & "'
                                                ,'" & D_ShipAddr2 & "'
                                                ,'" & D_ShipAddrID & "'
                                                ,'" & D_ShipCity & "'
                                                ,'" & D_ShipCountry & "'
                                                ,'" & D_ShipName & "'
                                                ,'" & D_ShipState & "'
                                                ,'" & D_ShipViaID & "'
                                                ,'" & D_ShipZip & "'
                                                ,'" & D_SiteID & "'
                                                ,'" & D_SOLineRef & "'
                                                ,'" & D_SOOrdNbr & "'
                                                ,'" & D_SOSchedRef & "'
                                                ,'" & D_StepNbr & "'
                                                ,'" & D_SvcContractID & "'
                                                ,'" & D_SvcLineNbr & "'
                                                ,'" & D_TaskID & "'
                                                ,'" & D_TaxAmt00 & "'
                                                ,'" & D_TaxAmt01 & "'
                                                ,'" & D_TaxAmt02 & "'
                                                ,'" & D_TaxAmt03 & "'
                                                ,'" & D_TaxCalced & "'
                                                ,'" & D_TaxCat & "'
                                                ,'" & D_TaxID00 & "'
                                                ,'" & D_TaxID01 & "'
                                                ,'" & D_TaxID02 & "'
                                                ,'" & D_TaxID03 & "'
                                                ,'" & D_TaxIdDflt & "'
                                                ,'" & D_TranDesc & "'
                                                ,'" & D_TxblAmt00 & "'
                                                ,'" & D_TxblAmt01 & "'
                                                ,'" & D_TxblAmt02 & "'
                                                ,'" & D_TxblAmt03 & "'
                                                ,'" & D_UnitCost & "'
                                                ,'" & D_UnitMultDiv & "'
                                                ,'" & D_UnitWeight & "'
                                                ,'" & D_User1 & "'
                                                ,'" & D_User2 & "'
                                                ,'" & D_User3 & "'
                                                ,'" & D_User4 & "'
                                                ,'" & D_User5 & "'
                                                ,'" & D_User6 & "'
                                                ,'" & D_User7 & "'
                                                ,'" & D_User8 & "'
                                                ,'" & D_VouchStage & "'
                                                ,'" & D_WOBOMSeq & "'
                                                ,'" & D_WOCostType & "'
                                                ,'" & D_WONbr & "'
                                                ,'" & D_WOStepNbr & "')"
            MainModul.ExecQuery(ls_TA)

            UpdatePR_Detail(D_User1)

        Catch ex As Exception
            Throw
        End Try

    End Sub

    Public Sub UpdatePR_Detail(PRNumber As String)


        Try

            Dim query As String = "[PO_D_UpdatePrDetail]"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@PRNo", SqlDbType.VarChar)

            pParam(0).Value = PRNumber

            MainModul.ExecQueryByCommand_SP(query, pParam)
        Catch ex As Exception
            Throw
        End Try

    End Sub




End Class
