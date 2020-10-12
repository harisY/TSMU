Imports System.Collections.ObjectModel

Public Class TravelEntertainModel
    Public Property CuryID As String
    Public Property DeptID As String
    Public Property Remark As String
    Public Property SettleID As String
    Public Property Tgl As Date
    Public Property Total As Double
    Public Property PaymentType As String
    Public Property CreditCardID As String
    Public Property CreditCardNumber As String
    Public Property AccountName As String

    Dim strQuery As String

    Public Function EntertainAutoNo() As String

        Try
            strQuery = "DECLARE @bulan VARCHAR(4); 
                        DECLARE @tahun VARCHAR(4); 
                        DECLARE @seq_ VARCHAR(4);
                        SET @bulan = LEFT(CONVERT(CHAR(20), GETDATE(), 101), 2);
                        SET @tahun = DATEPART(YEAR, GETDATE());
                        SET @seq_ = ( SELECT RIGHT('0000'
                                                  + CAST(RIGHT(RTRIM(MAX(SettleID)), 4) + 1 AS VARCHAR),
                                                  4)
                                     FROM   TSC16Application.dbo.settle_header WITH ( NOLOCK )
                                     WHERE  SUBSTRING(SettleID, 1, 2) = 'ET'
                                            AND SUBSTRING(SettleID, 4, 4) = RIGHT(@tahun, 4)
                                            AND SUBSTRING(SettleID, 9, 2) = RIGHT(@bulan, 2)
                                   );
                        SELECT  'ET' + '-' + RIGHT(@tahun, 4) + '-' + @bulan + '-' + COALESCE(@seq_,
                                                                                      '0001');"

            Dim dt As DataTable = New DataTable
            dt = GetDataTable_Solomon(strQuery)
            Return dt.Rows(0).Item(0).ToString

        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function InsertEntertainData(dtHeader As DataTable, dtDetail As DataTable, dtRelasi As DataTable, entertainIDTemp As String) As String
        Try
            Dim entertainID As String = String.Empty

            entertainID = EntertainAutoNo()

            Dim RowsTOSave As DataRow()
            RowsTOSave = dtHeader.Select("SettleID = '" & entertainIDTemp & "'")
            For Each dr As DataRow In RowsTOSave
                SettleID = entertainID
                DeptID = dr("DeptID")
                Remark = dr("Remark")
                Tgl = dr("Tgl")
                CuryID = dr("CuryID")
                PaymentType = dr("PaymentType")
                CreditCardID = dr("CreditCardID")
                CreditCardNumber = dr("CreditCardNumber")
                AccountName = dr("AccountName")
                Total = dr("Total")
                InsertEntertainHeader()
            Next

            RowsTOSave = dtDetail.Select("SettleID = '" & entertainIDTemp & "'")
            For Each dr As DataRow In RowsTOSave
                Dim clsEntertainDetail As New TravelEntertainDetailModel
                With clsEntertainDetail
                    .SettleID = entertainID
                    .Tgl = dr("Tgl")
                    .SubAcct = dr("SubAccount")
                    .AcctID = dr("Account")
                    .Description = dr("Description")
                    .Nama = dr("Nama")
                    .Tempat = dr("Tempat")
                    .Alamat = dr("Alamat")
                    .Jenis = dr("Jenis")
                    .SettleAmount = dr("Amount")
                    .HeaderSeq = dr("HeaderSeq")
                    .InsertEntertainDetail()
                End With
            Next

            RowsTOSave = dtRelasi.Select("SettleID = '" & entertainIDTemp & "'")
            For Each dr As DataRow In RowsTOSave
                Dim clsEntertainRelasi As New TravelEntertainRelasiModel
                With clsEntertainRelasi
                    .SettleID = entertainID
                    .NamaRelasi = dr("Nama")
                    .Posisi = dr("Posisi")
                    .Relasi = dr("Perusahaan")
                    .JenisRelasi = dr("JenisUsaha")
                    .Nota = dr("Remark")
                    .HeaderSeq = dr("HeaderSeq")
                    .InsertEntertainRelasi()
                End With
            Next
            Return entertainID
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Function UpdateEntertainData(dtHeader As DataTable, dtDetail As DataTable, dtRelasi As DataTable, entertainID_ As String, entertainIDTemp As String) As String
        Try
            Dim entertainID As String = String.Empty
            Dim filterParam As String

            If entertainID_ <> "" Then
                filterParam = entertainID_
                entertainID = entertainID_
            Else
                filterParam = entertainIDTemp
                entertainID = EntertainAutoNo()
            End If

            Dim RowsTOSave As DataRow()
            RowsTOSave = dtHeader.Select("SettleID = '" & filterParam & "'")
            DeleteEntertainHeader(entertainID)
            For Each dr As DataRow In RowsTOSave
                SettleID = entertainID
                DeptID = dr("DeptID")
                Remark = dr("Remark")
                Tgl = dr("Tgl")
                CuryID = dr("CuryID")
                PaymentType = dr("PaymentType")
                CreditCardID = IIf(dr("CreditCardID") Is DBNull.Value, "", dr("CreditCardID"))
                CreditCardNumber = IIf(dr("CreditCardNumber") Is DBNull.Value, "", dr("CreditCardNumber"))
                AccountName = IIf(dr("AccountName") Is DBNull.Value, "", dr("AccountName"))
                Total = dr("Total")
                InsertEntertainHeader()
            Next

            RowsTOSave = dtDetail.Select("SettleID = '" & filterParam & "'")
            Dim clsEntertainDetail As New TravelEntertainDetailModel
            clsEntertainDetail.DeleteEntertainDetail(entertainID)
            For Each dr As DataRow In RowsTOSave
                clsEntertainDetail = New TravelEntertainDetailModel
                With clsEntertainDetail
                    .SettleID = entertainID
                    .Tgl = dr("Tgl")
                    .SubAcct = dr("SubAccount")
                    .AcctID = dr("Account")
                    .Description = dr("Description")
                    .Nama = dr("Nama")
                    .Tempat = dr("Tempat")
                    .Alamat = dr("Alamat")
                    .Jenis = dr("Jenis")
                    .SettleAmount = dr("Amount")
                    .HeaderSeq = dr("HeaderSeq")
                    .InsertEntertainDetail()
                End With
            Next

            RowsTOSave = dtRelasi.Select("SettleID = '" & filterParam & "'")
            Dim clsEntertainRelasi As New TravelEntertainRelasiModel
            clsEntertainRelasi.DeleteEntertainRelasi(entertainID)
            For Each dr As DataRow In RowsTOSave
                clsEntertainRelasi = New TravelEntertainRelasiModel
                With clsEntertainRelasi
                    .SettleID = entertainID
                    .NamaRelasi = dr("Nama")
                    .Posisi = dr("Posisi")
                    .Relasi = dr("Perusahaan")
                    .JenisRelasi = dr("JenisUsaha")
                    .Nota = dr("Remark")
                    .HeaderSeq = dr("HeaderSeq")
                    .InsertEntertainRelasi()
                End With
            Next
            Return entertainID
        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Sub InsertEntertainHeader()
        Try
            Dim ls_SP As String = String.Empty
            ls_SP = " INSERT INTO TSC16Application.dbo.settle_header (SettleID, DeptID, Remark, Tgl, CuryID, Status, PaymentType, CreditCardID, CreditCardNumber, AccountName, Total ) " & vbCrLf &
                    " Values(" & QVal(SettleID.TrimEnd) & ", " & vbCrLf &
                    "        " & QVal(DeptID.TrimEnd) & ", " & vbCrLf &
                    "        " & QVal(Remark.TrimEnd) & ", " & vbCrLf &
                    "        " & QVal(Tgl) & ", " & vbCrLf &
                    "        " & QVal(CuryID.TrimEnd) & ", " & vbCrLf &
                    "        'Close', " & vbCrLf &
                    "        " & QVal(PaymentType.TrimEnd) & ", " & vbCrLf &
                    "        " & QVal(CreditCardID.TrimEnd) & ", " & vbCrLf &
                    "        " & QVal(CreditCardNumber.TrimEnd) & ", " & vbCrLf &
                    "        " & QVal(AccountName.TrimEnd) & ", " & vbCrLf &
                    "        " & QVal(Total) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteEntertainHeader(settleID_ As String)
        Try
            strQuery = "DELETE  FROM TSC16Application.dbo.settle_header
                        WHERE   SettleID = " & QVal(settleID_) & ""
            ExecQuery_Solomon(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetListJenis() As DataTable
        Try
            Dim sql As String
            sql = " SELECT  *
                    FROM    dbo.S_JenisEntDetail "
            Dim dt As New DataTable
            dt = GetDataTable(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetListPosisi() As DataTable
        Try
            Dim sql As String
            sql = " SELECT  *
                    FROM    dbo.S_PosisiEntRelasi "
            Dim dt As New DataTable
            dt = GetDataTable(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetListJenisUsaha() As DataTable
        Try
            Dim sql As String
            sql = " SELECT  *
                    FROM    dbo.S_JenisUsahaEntRelasi "
            Dim dt As New DataTable
            dt = GetDataTable(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetListRemark() As DataTable
        Try
            Dim sql As String
            sql = " SELECT  *
                    FROM    dbo.S_RemarkEntRelasi "
            Dim dt As New DataTable
            dt = GetDataTable(sql)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class

Public Class TravelEntertainDetailModel
    Public Property AcctID As String
    Public Property Alamat As String
    Public Property SettleAmount As Long
    Public Property Description As String
    Public Property Jenis As String
    Public Property Nama As String
    Public Property SettleID As String
    Public Property SubAcct As String
    Public Property Tempat As String
    Public Property Tgl As DateTime
    Public Property HeaderSeq As Integer

    Dim strQuery As String

    Public Sub InsertEntertainDetail()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO TSC16Application.dbo.settle_detail
            (SettleID, Tgl, SubAcct, AcctID,  Description, Nama, Tempat, Alamat, Jenis, SettleAmount, HeaderSeq ) " & vbCrLf &
            "Values(" & QVal(SettleID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tgl) & ", " & vbCrLf &
            "       " & QVal(SubAcct.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(AcctID.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Description.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Nama.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Tempat.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Alamat.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(Jenis.TrimEnd) & ", " & vbCrLf &
            "       " & QVal(SettleAmount) & ", " & vbCrLf &
            "       " & QVal(HeaderSeq) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteEntertainDetail(SettleID_ As String)
        Try
            strQuery = "DELETE  FROM TSC16Application.dbo.settle_detail
                        WHERE   SettleID = " & QVal(SettleID_) & ""
            ExecQuery_Solomon(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class

Public Class TravelEntertainRelasiModel
    Public Property SettleID As String
    Public Property NamaRelasi As String
    Public Property Posisi As String
    Public Property Relasi As String
    Public Property JenisRelasi As String
    Public Property Nota As String
    Public Property HeaderSeq As Integer

    Dim strQuery As String

    Public Sub InsertEntertainRelasi()
        Try
            Dim ls_SP As String = " " & vbCrLf &
            "INSERT INTO TSC16Application.dbo.settlerelasi (SettleID, Nama, Posisi, Perusahaan, JenisUsaha, Remark, HeaderSeq ) " & vbCrLf &
            "Values(" & QVal(SettleID) & ", " & vbCrLf &
            "       " & QVal(NamaRelasi) & ", " & vbCrLf &
            "       " & QVal(Posisi) & ", " & vbCrLf &
            "       " & QVal(Relasi) & ", " & vbCrLf &
            "       " & QVal(JenisRelasi) & ", " & vbCrLf &
            "       " & QVal(Nota) & ", " & vbCrLf &
            "       " & QVal(HeaderSeq) & ")"
            ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteEntertainRelasi(SettleID_ As String)
        Try
            strQuery = "DELETE  FROM TSC16Application.dbo.SettleRelasi
                        WHERE   SettleID = " & QVal(SettleID_) & ""
            ExecQuery_Solomon(strQuery)
        Catch ex As Exception
            Throw
        End Try
    End Sub

End Class
