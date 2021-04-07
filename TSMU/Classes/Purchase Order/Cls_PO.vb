Imports System.Collections.ObjectModel
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.Net
Imports System.Net.Mail
Public Class Cls_PO


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



End Class
