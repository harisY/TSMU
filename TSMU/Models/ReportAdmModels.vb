Public Class ReportAdmModels
    Public Function GetDataGrid(ByVal strStatus As String, tgl As String, tgl1 As String) As DataTable
        Try
            Dim query As String = String.Empty
            If gh_Common.Site.ToLower = "tng" Then
                query = "GetDataBarcode"
                'ElseIf gh_Common.Site = "all" Then
                '    query = "GetDataBarcode"
            Else
                query = "getBarcodeTSC_ADM"
            End If

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
            pParam(0) = New SqlClient.SqlParameter("@status", SqlDbType.VarChar)
            pParam(0).Value = strStatus
            pParam(1) = New SqlClient.SqlParameter("@tgl", SqlDbType.VarChar)
            pParam(1).Value = tgl
            pParam(2) = New SqlClient.SqlParameter("@tgl1", SqlDbType.VarChar)
            pParam(2).Value = tgl1

            'Dim pParam1() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
            'pParam1(0) = New SqlClient.SqlParameter("@status", SqlDbType.VarChar)
            'pParam1(0).Value = strStatus
            'pParam1(1) = New SqlClient.SqlParameter("@tgl", SqlDbType.VarChar)
            'pParam1(1).Value = tgl
            'pParam1(2) = New SqlClient.SqlParameter("@tgl1", SqlDbType.VarChar)
            'pParam1(2).Value = tgl1
            Dim dt As New DataTable
            If gh_Common.Site.ToLower = "tng" Then
                dt = GetDataTableByCommand_SP(query, pParam)
                'ElseIf gh_Common.Site.ToLower = "all" Then
                '    Dim dt1 As New DataTable

                '    dt = GetDataTableByCommand_SP(query, pParam)
                '    dt1 = GetDataTableByCommand_StorePCKR(query, pParam1)

                '    dt.Merge(dt1, False)
            Else
                dt = GetDataTableByCommand_StorePCKR(query, pParam)
            End If

            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function

    Public Function GetDataGridBarcodeGenerate() As DataTable
        Try
            Dim query As String = "GetReportBarcodeGenerate"
            Dim dt As New DataTable
            If gh_Common.Site.ToLower = "tng" Then
                dt = GetDataTableByCommand_SP(query)
            Else
                dt = GetDataTableByCommand_StorePCKR(query)
            End If

            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function
End Class


Public Class ReportBarcodePrintLog

    Public Function GetDataGrid(tgl As String, tgl1 As String) As DataTable
        Try
            Dim query As String = "SELECT
                [KodePart]
                ,[Bulan]
                ,[Site]
                ,[No]
                ,[PrintedBy]
                ,[PrintedDate]
            FROM [BarcodePrintLog] where convert(date,PrintedDate) >= " & QVal(tgl) & " AND convert(date,PrintedDate) <= " & QVal(tgl1) & ""
            Dim dt As New DataTable
            If gh_Common.Site.ToLower = "tng" Then
                dt = GetDataTable(query)
            Else
                dt = GetDataTableCKR(query)
            End If

            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function
End Class