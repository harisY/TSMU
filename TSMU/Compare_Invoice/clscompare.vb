Imports System.Collections.ObjectModel
Public Class clscompare

    Dim _Query As String
    Private _txtFileLocation As String
    Public Property txtFileLocation() As String
        Get
            Return _txtFileLocation
        End Get
        Set(ByVal value As String)
            _txtFileLocation = value
        End Set
    End Property

    Private _cmbperpost As String
    Public Property cmbperpost() As String
        Get
            Return _cmbperpost
        End Get
        Set(ByVal value As String)
            _cmbperpost = value
        End Set
    End Property
    Public Property g0() As String
    Public Property g1() As String
    Public Property g2() As String
    Public Property g3() As String
    Public Property g4() As String
    Public Property g5() As String
    Public Property g6() As String
    Public Property g7() As String
    Public Property g8() As String
    Public Property g9() As String
    Public Property g10() As String
    Public Property g11() As String
    Public Property g12() As String
    Public Property g13() As String
    Public Property g14() As String
    Public Property g15() As String
    Public Property g16() As String
    Public Property g17() As String
    Public Property g18() As String
    Public Property g19() As String
    Public Property g20() As String
    Public Property g21() As String
    Public Property g22() As String
    Public Property g23() As String
    Public Property g24() As String
    Public Property g25() As String
    Public Property g26() As String
    Public Property g27() As String
    Public Property g28() As String
    Public Property g29() As String
    Public Property g30() As String
    Public Property g31() As String
    Public Property g32() As String
    Public Property g33() As String
    Public Property g34() As String
    Public Property cekbalance() As Boolean

    Public Property perpost() As String
    Public Property Account As String
    Public Property Amount As Double
    Public Property Amount_Cust As Double
    Public Property Amount_xx As Double
    Public Property AternateID1 As String
    Public Property AternateID2 As String
    Public Property Balance As Double
    Public Property CurySlsPrice As Double
    Public Property CurySlsPrice_Cust As Double
    Public Property CustOrdNbr As String
    Public Property Descr As String
    Public Property InvtID As String
    Public Property Receipt_Quantity As Double
    Public Property ShipperID As String
    Public Property SubAccount As String
    Public Property TaxCat As String
    Public Property TaxID00 As String
    Public Property TglSuratJalan As DateTime
    Public Property UnitDescr As String
    Public Property ordnbr As Integer
    Public Property PO As String
    Public Property periode As String
    Public Property nom As Integer
    Public Property ID As Integer
    Public Property JenisPO As String

    '  Public Property cmbperpost() As String
    Public Sub New()
        Me._Query = "select * from Temp_Copas_sol "
        ' MsgBox(cekbalance)

    End Sub
    Public Function GetAllDataTable(ByVal ls_Filter As String) As DataTable
        Try

            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(Me._Query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function loadreport2() As DataSet
        Dim query As String
        query = "SELECT RTRIM(AlternateID) as AlternateID
      ,RTRIM(InvtID) as InvtID
      ,RTRIM(Descr) as Descr
      ,RTRIM(PO) as PO
      , CONVERT(varchar, Promdate, 101) AS Promdate
      ,Quantity as Qty
      ,RTRIM(SiteID) as SiteID
      ,Nom as No
      ,RTRIM(CustID) as CustID
      ,RTRIM(Jam) as Jam
      ,RTRIM(Tujuan) as Tujuan
      ,RTRIM(SO) as SO FROM POYIM where JenisPO='" & JenisPO & "' AND Lokasi='" & txtFileLocation & "' AND PO<>'' "

        Dim ds As New dsLaporan
        ds = GetDsReport_Solomon(query, "SO")
        Return ds

    End Function
    Public Sub Updateordnbr()
        Try
            Dim ls_SP As String = String.Empty
            ls_SP = "UPDATE POYIM SET ordnbr =" & QVal(ordnbr) & " WHERE PO=" & QVal(PO.TrimEnd) & ""

            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Updatenom()
        Try
            Dim ls_SP As String = String.Empty
            ls_SP = "UPDATE POYIM SET Nom =" & QVal(nom) & " WHERE ID= " & QVal(ID) & ""

            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Updatesonbr()
        Try
            Dim ls_SP As String = String.Empty
            ls_SP = "update POYIM  Set SO=" & QVal(periode.TrimEnd) & "+'-'+right('0000'+cast(right(rtrim(ordnbr),4) as varchar),4)"

            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetAllData() As DataTable
        ' Try
        'Dim ls_SP As String = "select * from Temp_Copas_sol where balance=0"

        Dim ls_SP As String
        Try
            If cekbalance = True Then
                ls_SP = "select * from Temp_Copas_sol where balance=0 "
            Else
                ls_SP = "select * from Temp_Copas_sol where balance!=0  or balance is null "

            End If

            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetDataReturn() As DataTable
        ' Try
        'Dim ls_SP As String = "select * from Temp_Copas_sol where balance=0"
        'cmbperpost = frmCompare_Invoice1._cmbperpost.Text

        Try

            Dim ls_SP As String = "select Item_Number,Item_Name, sum(0-Receipt_Quantity_return) as Qty,Unit_Price,sum(0-Receipt_Quantity_return)*Unit_Price as Total from  YIM_Receipt where order_number=''  and item_number!='' and perpost='" & perpost & "' group by Item_Number,Item_Name,Unit_Price,Amount"

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
            Dim sql As String =
            "SELECT ID,RTRIM(AlternateID) as AlternateID
      ,RTRIM(InvtID) as InvtID
      ,RTRIM(Descr) as Descr
      ,RTRIM(PO) as PO
      , CONVERT(varchar, Promdate, 101) AS Promdate
      ,Quantity
      ,RTRIM(SiteID) as SiteID
      ,Nom
      ,RTRIM(CustID) as CustID
      ,RTRIM(Jam) as Jam
      ,RTRIM(Tujuan) as Tujuan
      ,RTRIM(SO) as SO
      ,Ordnbr
      ,RTRIM(JenisPO) JenisPO
      ,RTRIM(Lokasi) Lokasi FROM POYIM WHERE PO<>'' AND JenisPO='" & JenisPO & "' AND Lokasi='" & txtFileLocation & "' ORDER BY PO"
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataGrid3() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String =
            "SELECT ID,RTRIM(AlternateID) as AlternateID
      ,RTRIM(InvtID) as InvtID
      ,RTRIM(Descr) as Descr
      ,RTRIM(PO) as PO
      , CONVERT(varchar, Promdate, 101) AS Promdate
      ,Quantity
      ,RTRIM(SiteID) as SiteID
      ,Nom
      ,RTRIM(CustID) as CustID
      ,RTRIM(Jam) as Jam
      ,RTRIM(Tujuan) as Tujuan
      ,RTRIM(SO) as SO
      ,Ordnbr
      ,RTRIM(JenisPO) JenisPO
      ,RTRIM(Lokasi) Lokasi FROM POYIM WHERE PO<>'' ORDER BY PO"
            dt = GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataImport() As DataTable
        ' Try
        'Dim ls_SP As String = "select * from Temp_Copas_sol where balance=0"

        Try

            Dim ls_SP As String = "select distinct nama_file from YIM_Receipt where perpost='" & cmbperpost & "'"

            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub getDataByID(ByVal ID As String)
        Try
            Dim query As String = "select * from YIM_receipt where Nama_File = " & QVal(ID) & " order by Nama_File"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me._txtFileLocation = Trim(.Item("Nama_File") & "")
                End With
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub ValidateInsert()
        If Me._txtFileLocation = "" Then
            Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
        End If
        Try
            Dim ls_SP As String = "Select top 1 Nama_File from YIM_receipt where Nama_File = " & QVal(Me._txtFileLocation) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable_Solomon(ls_SP)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.InsertGagal) &
                "[" & Me._txtFileLocation & "]")
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
#Region "CRUD"
    Public Sub Insert()
        Try
            '   cmbperpost = "201811"
            ' cmbperpost = frmCompare_Invoice1._cmbperpost.Text
            Dim ls_SP As String = "INSERT INTO YIM_receipt (SEQ, Issue_Date, Payment_Term_from, Payment_Term_to, Company_Code, Company_Name, Section, Person_Charge, Data_Range_ID, Data_Range, Supplier_Code, Supplier_Name, Item_Number, S_code, U_code, PF, Item_Name, S_Name, U_Name, UM, Item_Class, Receipt_Date_return, Receipt_Quantity_return, Unit_Price, Amount, Currency, Slip_Type, Slip_Number, Order_Number, Input_Date, Due_Date, Order_Quantity, Ordered_by, Volume_Number, Output_Date,Nama_File,perpost) " &
                                "VALUES ('" & g0 & "','" & g1 & "','" & g2 & "','" & g3 & "','" & g4 & "','" & g5 & "','" & g6 & "','" & g7 & "','" & g8 & "','" & g9 & "','" & g10 & "','" & g11 & "','" & g12 & "','" & g13 & "','" & g14 & "','" & g15 & "','" & g16 & "','" & g17 & "','" & g18 & "','" & g19 & "','" & g20 & "','" & g21 & "','" & g22 & "','" & g23 & "','" & g24 & "','" & g25 & "','" & g26 & "','" & g27 & "','" & g28 & "','" & g29 & "','" & g30 & "','" & g31 & "','" & g32 & "','" & g33 & "','" & g34 & "','" & txtFileLocation & "'," & QVal(perpost) & ")"
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Insert2()
        Try
            '   cmbperpost = "201811"
            ' cmbperpost = frmCompare_Invoice1._cmbperpost.Text
            Dim ls_SP As String = "INSERT INTO POADM (DN	,Plant	,GRNo	,GRScanDate	,PONo	,VendID	,Vendor_Name	,AlternateID	,Descr	,Price	,Qty	,Amount	) " &
                                "VALUES ('" & g0 & "','" & g1 & "','" & g2 & "','" & g3 & "','" & g4 & "','" & g5 & "','" & g6 & "','" & g7 & "','" & g8 & "','" & g9 & "','" & g10 & "','" & g11 & "')"
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Insert2YIM()
        Try
            '   cmbperpost = "201811"
            ' cmbperpost = frmCompare_Invoice1._cmbperpost.Text
            '' g0 = Convert.ToString(g0)
            g0 = g0.Substring(0, 3) + "-" + g0.Substring(3, 5) + "-" + g0.Substring(8, 2) + "-" + g0.Substring(10, 2) + "-" + g0.Substring(12, 2)
            g2 = Trim(g2)
            '   g0 = g0.Substring(1, g0.Length > 3 ? 3 g0.Length) + "-" + g0.Substring(4, 5) + "-" + g0.Substring(9, 2) + "-" + g0.Substring(11, 2) + "-" + g0.Substring(13, 2)
            Dim ls_SP As String = "INSERT INTO POYIM (AlternateID,Descr,PO,Promdate,Quantity,Tujuan,Jam,JenisPO,Lokasi ) " &
                                "VALUES ('" & g0 & "','" & g1 & "','" & g2 & "','" & g3 & "','" & g4 & "','" & g8 & "','" & g6 & "','" & JenisPO & "','" & txtFileLocation & "')"
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Delete2YIM()
        Try
            Dim ls_SP As String = "DELETE FROM POYIM WHERE Lokasi='" & txtFileLocation & "' and JenisPO='" & JenisPO & "'"
            MainModul.ExecQuery_Solomon(ls_SP)


        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub Update2YIM()
        Try
            ''select '#'+right('0000'+cast(right(rtrim(PO),5) as varchar),5),* FROM POYIM  where  PO <>'' and  PO not like 'J%' and  PO not like 'K%'
            If JenisPO = "POD" Then
                Dim ls_SP21 As String = "UPDATE POYIM SET POYIM.InvtID=ItemxRef.InvtID,POYIM.CustID='YIM',POYIM.SiteID='TNG-U',POYIM.PO='#'+right('0000'+cast(right(rtrim(PO),5) as varchar),5) FROM POYIM Inner Join ItemxRef on POYIM.AlternateID=ItemxRef.AlternateID inner join inventory on inventory.InvtID=ItemxRef.InvtID where TranStatusCode='AC' and itemxref.AltIDType ='C' and SUBSTRING(ItemxRef.InvtID,16,2) IN ('SN','SI','SP') AND POYIM.JenisPO='POD'"
                MainModul.ExecQuery_Solomon(ls_SP21)
            Else
                Dim ls_SP2 As String = "UPDATE POYIM SET POYIM.InvtID=ItemxRef.InvtID,POYIM.CustID='YIM',POYIM.SiteID='TNG-U',POYIM.PO='#'+right('0000'+cast(right(rtrim(PO),5) as varchar),5) FROM POYIM Inner Join ItemxRef on POYIM.AlternateID=ItemxRef.AlternateID inner join inventory on inventory.InvtID=ItemxRef.InvtID where TranStatusCode='AC' and itemxref.AltIDType ='C'  and SUBSTRING(ItemxRef.InvtID,16,2) NOT IN ('SN','SI','SP','') AND POYIM.JenisPO='Regular' "
                MainModul.ExecQuery_Solomon(ls_SP2)
            End If
            'Dim ls_SP2 As String = "UPDATE POYIM SET POYIM.InvtID=ItemxRef.InvtID,POYIM.CustID='YIM',POYIM.SiteID='TNG-U' FROM POYIM Inner Join ItemxRef on POYIM.AlternateID=ItemxRef.AlternateID inner join inventory on inventory.InvtID=ItemxRef.InvtID where TranStatusCode='AC' and itemxref.AltIDType ='C'  "

            Dim ls_SP1 As String = "UPDATE POYIM SET PO='' FROM POYIM where PO='#0000'"
            MainModul.ExecQuery_Solomon(ls_SP1)

        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function autoperpost() As String
        Try
            Dim auto As String
            Dim query As String = "declare  @bulan varchar(4), @tahun varchar(4) " &
                 "set @bulan = LEFT(CONVERT(CHAR(20), GETDATE(), 101), 2) " &
                "set @tahun = datepart(year,getdate()) " &
                "select RIGHT(@tahun,4) + @bulan "

            Dim dt As DataTable = New DataTable
            dt = GetDataTableByCommand(query)
            auto = dt.Rows(0).Item(0).ToString
            Return auto

        Catch ex As Exception
            Throw

        End Try
    End Function
    Public Sub Delete()
        Try
            Dim ls_SP As String = "Delete from YIM_receipt where Nama_File =" & QVal(txtFileLocation) & ""
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception

            Throw
        End Try
    End Sub
#End Region
    Public Function proses_compare1(ByVal strperpost As String) As DataTable
        Try
            Dim query As String = "COMPARE_RECEIPT"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@perpost", SqlDbType.VarChar)
            pParam(0).Value = strperpost

            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP_Solomon(query, pParam)

            Return dt
        Catch ex As Exception
            Throw
        End Try

    End Function
End Class


