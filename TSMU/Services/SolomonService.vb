Imports System.Data.SqlClient

Public Class SolomonService
    Public Function GetDataInventory(FromDate As Date, ToDate As Date) As DataTable
        Try
            Dim Query As String =
            "
            SELECT
	            Crtd_User CreatedBy,
	            Crtd_DateTime CreatedDate,
	            InvtID InventoryID,
	            Descr Description,
	            StkUnit StokUnit,
	            CASE valmthd
		            WHEN 'F' THEN 'FIFO'
		            WHEN 'L' THEN 'LIFO'
		            WHEN 'A' THEN 'Average Cost'
		            WHEN 'S' THEN 'Specific Identification'
		            WHEN 'T' THEN 'Standard Cost'
		            WHEN 'U' THEN 'User-Specified Cost'
		            ELSE ''
	            END AS Methode,
	            InvtAcct,
	            COGSAcct,
	            DfltSalesAcct,
	            ppvacct PpvAcc,
	            CASE TranStatusCode
		            WHEN 'AC' THEN 'Active'
		            WHEN 'NP' THEN 'No Purchase'
		            WHEN 'NU' THEN 'No Usage'
		            WHEN 'OH' THEN 'On Hold'
		            WHEN 'IN' THEN 'Inactive'
		            WHEN 'DE' THEN 'Delete'
		            ELSE ''
	            END AS Status
            FROM Inventory
            WHERE Crtd_User <> 'sysadmin' and Convert(Date,crtd_datetime) >=@FromDate
            AND Convert(Date,crtd_datetime) <= @ToDate      
            ORDER BY crtd_datetime
            "
            Dim Params As List(Of SqlParameter) = New List(Of SqlParameter) From {
                New SqlParameter() With {.ParameterName = "FromDate", .Value = FromDate},
                New SqlParameter() With {.ParameterName = "ToDate", .Value = ToDate}
                }
            Dim dt As New DataTable
            dt = GetDataTableByParam(Query, CommandType.Text, Params, GetConnStringSolomon)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
