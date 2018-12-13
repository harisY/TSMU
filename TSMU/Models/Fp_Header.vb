Public Class Fp_Header
    Public Property Bulan As String
    Public Property CuryID As String
    Public Property FPNo As String
    Public Property Jenis_Jasa As String
    Public Property Ket_Pph As String
    Public Property Lokasi As String
    Public Property nama_vendor As String
    Public Property No_Bukti_Potong As String
    Public Property npwp As String
    Public Property Pphid As String
    Public Property Status As String
    Public Property Tahun As String
    Public Property Tarif As Double
    Public Property Tgl_fp As DateTime
    Public Property Tot_Dpp_Invoice As Double
    Public Property Tot_Pph As Double
    Public Property Tot_Ppn As Double
    Public Property Tot_Voucher As Double
    Public Property Vend_Name As String
    Public Property VendID As String

    Public Sub GetFakturPajakById()
        Try
            Dim sql = "SELECT [FPNo]
                      ,[Tgl_fp]
                      ,[VendID]
                      ,[Vend_Name]
                      ,[Jenis_Jasa]
                      ,[npwp]
                      ,[No_Bukti_Potong]
                      ,[Pphid]
                      ,[Ket_Pph]
                      ,[Tarif]
                      ,[Tahun]
                      ,[Bulan]
                      ,[Lokasi]
                      ,[CuryID]
                      ,[Tot_Dpp_Invoice]
                      ,[Tot_Ppn]
                      ,[Tot_Voucher]
                      ,[Tot_Pph]
                      ,[Status]
                      ,[nama_vendor]
                  FROM [Fp_Header] where FPNo=" & QVal(FPNo) & ""
            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            If dt.Rows.Count > 0 Then
                FPNo = Trim(dt.Rows(0).Item("FPNo"))
                Tgl_fp = Trim(dt.Rows(0).Item("Tgl_fp"))
                VendID = Trim(dt.Rows(0).Item("VendID"))
                Vend_Name = Trim(dt.Rows(0).Item("Vend_Name"))
                Jenis_Jasa = Trim(dt.Rows(0).Item("Jenis_Jasa"))
                npwp = Trim(dt.Rows(0).Item("npwp"))
                No_Bukti_Potong = Trim(dt.Rows(0).Item("No_Bukti_Potong"))
                Pphid = Trim(dt.Rows(0).Item("Pphid"))
                Ket_Pph = Trim(dt.Rows(0).Item("Ket_Pph"))
                Tarif = Trim(dt.Rows(0).Item("Tarif"))
                Tahun = Trim(dt.Rows(0).Item("Tahun"))
                Bulan = Trim(dt.Rows(0).Item("Bulan"))
                Lokasi = Trim(dt.Rows(0).Item("Lokasi"))
                CuryID = Trim(dt.Rows(0).Item("CuryID"))
                Tot_Dpp_Invoice = Trim(dt.Rows(0).Item("Tot_Dpp_Invoice"))
                Tot_Ppn = Trim(dt.Rows(0).Item("Tot_Ppn"))
                Tot_Voucher = Trim(dt.Rows(0).Item("Tot_Voucher"))
                Tot_Pph = Trim(dt.Rows(0).Item("Tot_Pph"))
                Status = Trim(dt.Rows(0).Item("Status"))
                nama_vendor = Trim(dt.Rows(0).Item("nama_vendor"))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetGridDetails() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String = "SELECT [No_Invoice] invcNbr
                    ,[Tgl_Invoice] invcDate
                    ,[CuryID] CuryId
                    ,[Jml_Invoice] Amount
                    ,[Dpp] DPP
                    ,[Ppn]
                    ,[Pph]
                    ,[link_barcode] Scan
                    ,convert(bit,1) [Check]
                FROM [Fp_Detail] WHERE FPNo = " & QVal(FPNo) & ""
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
