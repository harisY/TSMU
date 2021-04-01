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



End Class
