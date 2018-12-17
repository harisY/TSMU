Public Class fp_header_models
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
                FPNo = Trim(dt.Rows(0).Item("FPNo").ToString())
                Tgl_fp = dt.Rows(0).Item("Tgl_fp")
                VendID = Trim(dt.Rows(0).Item("VendID").ToString())
                Vend_Name = Trim(dt.Rows(0).Item("Vend_Name").ToString())
                Jenis_Jasa = Trim(dt.Rows(0).Item("Jenis_Jasa").ToString())
                npwp = Trim(dt.Rows(0).Item("npwp").ToString())
                No_Bukti_Potong = Trim(dt.Rows(0).Item("No_Bukti_Potong").ToString())
                CuryID = dt.Rows(0).Item("CuryID")
                Tot_Dpp_Invoice = dt.Rows(0).Item("Tot_Dpp_Invoice")
                Tot_Ppn = dt.Rows(0).Item("Tot_Ppn")
                Tot_Voucher = dt.Rows(0).Item("Tot_Voucher")
                Tot_Pph = dt.Rows(0).Item("Tot_Pph")
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetGridDetails() As DataTable
        Try
            Dim dt As New DataTable
            Dim sql As String = "SELECT fp.[No_Invoice] invcNbr
                    ,fp.[Tgl_Invoice] invcDate
                    ,fp.[CuryID] CuryId
                    ,fp.[Jml_Invoice] Amount
                    ,fp.[Dpp] DPP
                    ,fp.[Ppn]
                    ,fp.No_Faktur fp
                    ,fp.No_Bukti_Potong NBP
                    ,fp.[Pph]
                    ,fp.[link_barcode] Scan
                    ,convert(bit,1) [Check]
                    ,ap.User4 [Status]
                FROM [Fp_Detail] fp inner JOIN 
                (select distinct InvcNbr, User4 from apdoc) ap on fp.No_Invoice = ap.InvcNbr WHERE fp.FPNo = " & QVal(FPNo) & ""
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function IsUser4Exist(InvcNbr As String) As Boolean
        Dim User4 As Boolean = False
        Try
            Dim dt As New DataTable
            Dim sql As String = "SELECT USER4 FROM dbo.APDoc
                WHERE InvcNbr = " & QVal(InvcNbr) & ""
            dt = MainModul.GetDataTable_Solomon(sql)
            User4 = Convert.ToBoolean(dt.Rows(0)(0))
        Catch ex As Exception
            Throw ex
        End Try
        Return User4
    End Function

    Public Sub InsertHeader()
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "INSERT INTO Fp_Header (FPNo,Tgl_fp,VendID,Vend_Name,Jenis_Jasa,npwp,CuryID,Tot_Dpp_Invoice,Tot_Ppn,Tot_Voucher,Tot_Pph,Status) " & vbCrLf &
                                    "Values(" & QVal(Me.FPNo) & ", " & vbCrLf &
                                    "       " & QVal(Me.Tgl_fp) & ", " & vbCrLf &
                                    "       " & QVal(Me.VendID) & ", " & vbCrLf &
                                    "       " & QVal(Me.Vend_Name) & ", " & vbCrLf &
                                    "       " & QVal(Me.Jenis_Jasa) & ", " & vbCrLf &
                                    "       " & QVal(Me.npwp) & ", " & vbCrLf &
                                    "       " & QVal(Me.CuryID) & ", " & vbCrLf &
                                    "       " & QVal(Me.Tot_Dpp_Invoice) & ", " & vbCrLf &
                                    "       " & QVal(Me.Tot_Ppn) & ", " & vbCrLf &
                                    "       " & QVal(Me.Tot_Voucher) & ", " & vbCrLf &
                                    "       " & QVal(Me.Tot_Pph) & ", " & vbCrLf &
                                    "       " & QVal(Me.Status) & ")"
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteHeader(ByVal FPNo As String)
        Try
            Dim ls_SP As String = "DELETE FROM Fp_Header WHERE rtrim(FPNo) =" & QVal(FPNo.TrimEnd) & ""
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub UpdateApDocUser3(ByVal FPNo As String)

        Try

            Dim Query = "UPDATE ApDoc set User3=0 where rtrim(InvcNbr) in(SELECT RTRIM(No_Invoice) FROM FP_Detail where FPNo= " & QVal(FPNo) & ")"
            mdlmain.ExecQueryByCommand(Query)
        Catch ex As Exception
            Throw ex

        End Try
    End Sub
End Class
