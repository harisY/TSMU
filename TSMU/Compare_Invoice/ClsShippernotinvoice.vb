Imports System.Collections.ObjectModel
Public Class ClsShippernotinvoice
    Dim _Query As String
    Public Function GetCustomer() As DataTable
        Try
            Dim ls_SP As String =
                "Select CustId [Customer ID], Name from Customer"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetDataGrid() As DataTable
        Try
            Dim dt As New DataTable
            'Dim sql As String =
            '                " SELECT distinct  '1' as id,rtrim(vb_ShipperNonInvoice.ShipperID) as ShipperID, vb_ShipperNonInvoice.Descr, vb_ShipperNonInvoice.al1, vb_ShipperNonInvoice.al2, vb_ShipperNonInvoice.QtyShip, vb_ShipperNonInvoice.CurySlsPrice, vb_ShipperNonInvoice.Amount, vb_ShipperNonInvoice.CurySlsPrice as CurySlsPrice_Asli, vb_ShipperNonInvoice.CpnyID, vb_ShipperNonInvoice.Account, '0-0-00-0' as subAccount, vb_ShipperNonInvoice.UnitDesc, 0 as kosong, vb_ShipperNonInvoice.TaxCat, vb_ShipperNonInvoice.TaxID00, RTRIM(vb_ShipperNonInvoice.InvtID) AS InvtID, rtrim(vb_ShipperNonInvoice.CustOrdNbr) AS CustOrdNbr, vb_ShipperNonInvoice.TglSuratJalan, vb_ShipperNonInvoice.CustID, CAST(vb_ShipperNonInvoice.sNoteText AS VARCHAR(60)) AS sNoteText, RTRIM(vb_ShipperNonInvoice.AlternateID) AS AlternateID,poadm.PONo , SJChecking.NoTran 
            '                  FROM   vb_ShipperNonInvoice LEFT JOIN poadm ON poadm.DN=vb_ShipperNonInvoice.CustOrdNbr AND  poadm.AlternateID=vb_ShipperNonInvoice.AlternateID Left Join SJChecking on SJChecking.ShipperID=vb_ShipperNonInvoice.ShipperID
            '                  WHERE   NOT (vb_ShipperNonInvoice.ShipperID='304111240X' OR vb_ShipperNonInvoice.ShipperID='304111809X' OR vb_ShipperNonInvoice.ShipperID='304112235.X' OR vb_ShipperNonInvoice.ShipperID='401114729') AND YEAR(vb_ShipperNonInvoice.TglSuratJalan)>=2019"
            Dim sql As String = "Select distinct  '1' as id,rtrim(vb_ShipperNonInvoice.ShipperID) as ShipperID, vb_ShipperNonInvoice.Descr, vb_ShipperNonInvoice.al1, vb_ShipperNonInvoice.al2, vb_ShipperNonInvoice.QtyShip, vb_ShipperNonInvoice.CurySlsPrice, vb_ShipperNonInvoice.Amount, vb_ShipperNonInvoice.CurySlsPrice as CurySlsPrice_Asli, vb_ShipperNonInvoice.CpnyID, vb_ShipperNonInvoice.Account, '0-0-00-0' as subAccount, vb_ShipperNonInvoice.UnitDesc, 0 as kosong, vb_ShipperNonInvoice.TaxCat, vb_ShipperNonInvoice.TaxID00, RTRIM(vb_ShipperNonInvoice.InvtID) AS InvtID, rtrim(vb_ShipperNonInvoice.CustOrdNbr) AS CustOrdNbr, vb_ShipperNonInvoice.TglSuratJalan, vb_ShipperNonInvoice.CustID, CAST(vb_ShipperNonInvoice.sNoteText AS VARCHAR(60)) AS sNoteText, RTRIM(vb_ShipperNonInvoice.AlternateID) AS AlternateID,poadm.PONo , SJChecking.NoTran,   
                Case   
      WHEN poadm.PONo Is null THEN
	  Case 
          WHEN LEFT(RTRIM(vb_ShipperNonInvoice.CustOrdNbr),2)='DN'  THEN '' ELSE RIGHT(RTRIM(vb_ShipperNonInvoice.CustOrdNbr),10)
	  End
                    Else poadm.PONo
   End As PONbr INTO  #ShipNotInv
From vb_ShipperNonInvoice LEFT Join poadm On poadm.DN=vb_ShipperNonInvoice.CustOrdNbr And poadm.AlternateID=vb_ShipperNonInvoice.AlternateID Left Join SJChecking On SJChecking.ShipperID=vb_ShipperNonInvoice.ShipperID
Where Not (vb_ShipperNonInvoice.ShipperID ='304111240X' OR vb_ShipperNonInvoice.ShipperID='304111809X' OR vb_ShipperNonInvoice.ShipperID='304112235.X' OR vb_ShipperNonInvoice.ShipperID='401114729') AND YEAR(vb_ShipperNonInvoice.TglSuratJalan)>=2019 ;

Select ShipNotInv.id, ShipperID, ShipNotInv.Descr, al1, al2, QtyShip, CurySlsPrice, ShipNotInv.Amount, poadm.Price As CurySlsPrice_Asli, CpnyID, Account, subAccount, UnitDesc, kosong, TaxCat, TaxID00, InvtID, CustOrdNbr, TglSuratJalan, CustID, sNoteText, ShipNotInv.AlternateID , NoTran,ShipNotInv.PONo,PONbr  
FROM #ShipNotInv AS ShipNotInv  LEFT JOIN poadm ON poadm.DN=ShipNotInv.CustOrdNbr And  poadm.AlternateID=ShipNotInv.AlternateID;"


            dt = GetDataTable_Solomon(Sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function GetShipperNotInv(cust As String, tgl1 As String, tgl2 As String, lokasi As String) As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
                "Proses_ShipperNotInv"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(3) {}
            pParam(0) = New SqlClient.SqlParameter("@CustID", SqlDbType.VarChar)
            pParam(0).Value = cust
            pParam(1) = New SqlClient.SqlParameter("@tgl1", SqlDbType.VarChar)
            pParam(1).Value = tgl1
            pParam(2) = New SqlClient.SqlParameter("@tgl2", SqlDbType.VarChar)
            pParam(2).Value = tgl2
            pParam(3) = New SqlClient.SqlParameter("@lokasi", SqlDbType.VarChar)
            pParam(3).Value = lokasi

            dt = MainModul.GetDataTableByCommand_SP_Solomon(sql, pParam)
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
