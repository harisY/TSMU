Public Class fp_pph_header_models
    Public Property Bulan As String
    Public Property CuryID As String
    Public Property FPNo As String
    Public Property id As Integer
    Public Property ket_dpp As String
    Public Property Ket_Pph As String
    Public Property Lokasi As String
    Public Property No_Bukti_Potong As String
    Public Property No_Faktur As String
    Public Property Pphid As String
    Public Property Tahun As String
    Public Property Tarif As Double
    Public Property Tot_Dpp_Invoice As Double
    Public Property Tot_Pph As Double

    Public Function GetFPByNo(ByVal NoFP As String) As DataTable
        Try
            Dim sql As String = "SELECT [id]
                    ,[FPNo]
                    ,[No_Bukti_Potong]
                    ,[Pphid]
                    ,[Ket_Pph]
                    ,[Tarif]
                    ,[Tahun]
                    ,[Bulan]
                    ,[Lokasi]
                    ,[CuryID]
                    ,[Tot_Dpp_Invoice]
                    ,[No_Faktur]
                    ,[Tot_Pph]
                    ,[ket_dpp]
                FROM [Fp_pph_header] WHERE RTRIM(FPNo) = " & QVal(NoFP) & ""

            Dim dt As New DataTable
            dt = MainModul.GetDataTable_Solomon(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub InsertHeader()
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "INSERT INTO Fp_pph_header (FPNo,No_Bukti_Potong,Pphid,Ket_Pph,Tarif,Tahun,Bulan,Lokasi,CuryID,Tot_Dpp_Invoice,No_Faktur,ket_dpp,Tot_Pph) " & vbCrLf &
                                    "Values(" & QVal(Me.FPNo) & ", " & vbCrLf &
                                    "       " & QVal(Me.No_Bukti_Potong) & ", " & vbCrLf &
                                    "       " & QVal(Me.Pphid) & ", " & vbCrLf &
                                    "       " & QVal(Me.Ket_Pph) & ", " & vbCrLf &
                                    "       " & QVal(Me.Tarif) & ", " & vbCrLf &
                                    "       " & QVal(Me.Tahun) & ", " & vbCrLf &
                                    "       " & QVal(Me.Bulan) & ", " & vbCrLf &
                                    "       " & QVal(Me.Lokasi) & ", " & vbCrLf &
                                    "       " & QVal(Me.CuryID) & ", " & vbCrLf &
                                    "       " & QVal(Me.Tot_Dpp_Invoice) & ", " & vbCrLf &
                                    "       " & QVal(Me.No_Faktur) & ", " & vbCrLf &
                                    "       " & QVal(Me.ket_dpp) & ", " & vbCrLf &
                                    "       " & QVal(Me.Tot_Pph) & ")"
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub DeleteHeader(ByVal FPNo As String)
        Try
            Dim ls_SP As String = "DELETE FROM Fp_pph_header WHERE rtrim(FPNo) =" & QVal(FPNo.TrimEnd) & ""
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
End Class
