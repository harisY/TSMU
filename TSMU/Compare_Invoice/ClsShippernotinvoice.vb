Imports System.Collections.ObjectModel
Public Class ClsShippernotinvoice
    Dim _Query As String

    Public Function GetDataGrid() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
                            " SELECT distinct  '1' as id,vb_ShipperNonInvoice.ShipperID, vb_ShipperNonInvoice.Descr, vb_ShipperNonInvoice.al1, vb_ShipperNonInvoice.al2, vb_ShipperNonInvoice.QtyShip, vb_ShipperNonInvoice.CurySlsPrice, vb_ShipperNonInvoice.Amount, vb_ShipperNonInvoice.CurySlsPrice as CurySlsPrice_Asli, vb_ShipperNonInvoice.CpnyID, vb_ShipperNonInvoice.Account, '0-0-00-0' as subAccount, vb_ShipperNonInvoice.UnitDesc, 0 as kosong, vb_ShipperNonInvoice.TaxCat, vb_ShipperNonInvoice.TaxID00, vb_ShipperNonInvoice.InvtID, vb_ShipperNonInvoice.CustOrdNbr, vb_ShipperNonInvoice.TglSuratJalan, vb_ShipperNonInvoice.CustID, CAST(vb_ShipperNonInvoice.sNoteText AS VARCHAR(60)) AS sNoteText, vb_ShipperNonInvoice.AlternateID,poadm.PONo , SJChecking.NoTran 
                              FROM   vb_ShipperNonInvoice LEFT JOIN poadm ON poadm.DN=vb_ShipperNonInvoice.CustOrdNbr AND  poadm.AlternateID=vb_ShipperNonInvoice.AlternateID Left Join SJChecking on SJChecking.ShipperID=vb_ShipperNonInvoice.ShipperID
                              WHERE   NOT (vb_ShipperNonInvoice.ShipperID='304111240X' OR vb_ShipperNonInvoice.ShipperID='304111809X' OR vb_ShipperNonInvoice.ShipperID='304112235.X' OR vb_ShipperNonInvoice.ShipperID='401114729')"
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataByDate(Dari As String, Sampai As String) As DataTable
        Try
            Dim Sql As String = "ShipperNotInv_GetDataByDateY"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@Dari", SqlDbType.VarChar)
            pParam(0).Value = Dari
            pParam(1) = New SqlClient.SqlParameter("@Sampai", SqlDbType.VarChar)
            pParam(1).Value = Sampai

            Dim dt As New DataTable
            dt = MainModul.GetDataTableByCommand_SP_Solomon(Sql, pParam)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
