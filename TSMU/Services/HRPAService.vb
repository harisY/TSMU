Public Class HRPAService
    Dim strQuery As String = String.Empty

    Public Function GetDataKaryawan() As DataTable
        Try
            strQuery = "DECLARE @Now AS DATE;

                        SET @Now = GETDATE();

                        SELECT  pdk.EmployeeID ,
                                pdk.NIK ,
                                pdp.NamaLengkap ,
                                pdp.NamaPanggilan ,
                                pdp.JenisKelamin ,
                                pdp.TglLahir ,
                                pp.PerpindahanDesc AS Perpindahan ,
                                pdk.StatusKaryawan ,
                                pdk.TipeKaryawan ,
                                pdk.TipePosisiKaryawan ,
                                pdk.Factory ,
                                oo.OrgDesc AS Organisasi ,
                                oj.OrgDesc AS Jabatan
                        FROM    dbo.M_HRPADataKaryawan AS pdk
                                INNER JOIN dbo.M_HRPADataPribadi AS pdp ON pdp.EmployeeID = pdk.EmployeeID
                                LEFT JOIN dbo.M_HROrgOrganisasi AS oo ON pdk.Organisasi = oo.OrgID
                                                                         AND oo.TglMulai <= @Now
                                                                         AND oo.TglSelesai >= @Now
                                LEFT JOIN dbo.M_HROrgJabatan AS oj ON pdk.Jabatan = oj.OrgID
                                                                      AND oj.TglMulai <= @Now
                                                                      AND oj.TglSelesai >= @Now
                                LEFT JOIN dbo.S_HRPAPerpindahan AS pp ON pdk.PerpindahanKaryawan = pp.Perpindahan
                        WHERE   ( pdk.TglMulai <= @Now
                                  AND pdk.TglSelesai >= @Now
                                )
                                AND pdp.TglMulai <= @Now
                                AND pdp.TglSelesai >= @Now"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataKaryawanByID(ByVal EmpID As String) As HRPAHeaderModel
        Try
            strQuery = "DECLARE @Now AS DATE;

                        SET @Now = GETDATE();

                        SELECT  pdk.EmployeeID ,
                                pdk.NIK ,
                                pdp.Gambar ,
                                pdp.NamaLengkap ,
                                pdp.NamaPanggilan ,
                                pdp.JenisKelamin ,
                                pdp.TglLahir ,
                                pdk.Factory ,
                                pdk.PerpindahanKaryawan ,
                                pdk.StatusKaryawan ,
                                pdk.TipeKaryawan ,
                                pdk.TipePosisiKaryawan ,
                                oo.OrgDesc AS Organisasi ,
                                oj.OrgDesc AS Jabatan
                        FROM    dbo.M_HRPADataKaryawan AS pdk
                                INNER JOIN dbo.M_HRPADataPribadi AS pdp ON pdp.EmployeeID = pdk.EmployeeID
                                LEFT JOIN dbo.M_HROrgOrganisasi AS oo ON pdk.Organisasi = oo.OrgID
                                                                         AND oo.TglMulai <= @Now
                                                                         AND oo.TglSelesai >= @Now
                                LEFT JOIN dbo.M_HROrgJabatan AS oj ON pdk.Jabatan = oj.OrgID
                                                                      AND oj.TglMulai <= @Now
                                                                      AND oj.TglSelesai >= @Now
                        WHERE   pdk.EmployeeID = " & QVal(EmpID) & "
                                AND ( pdk.TglMulai <= @Now
                                      AND pdk.TglSelesai >= @Now
                                    )
                                AND ( pdp.TglMulai <= @Now
                                      AND pdp.TglSelesai >= @Now
                                    );"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Dim modelHeader As New HRPAHeaderModel
            If dt.Rows.Count > 0 Then
                With modelHeader
                    .NIK = If(IsDBNull(dt.Rows(0).Item("NIK")), "", dt.Rows(0).Item("NIK").ToString())
                    .Gambar = If(IsDBNull(dt.Rows(0).Item("Gambar")), Nothing, dt.Rows(0).Item("Gambar"))
                    .NamaLengkap = If(IsDBNull(dt.Rows(0).Item("NamaLengkap")), "", dt.Rows(0).Item("NamaLengkap").ToString())
                    .JenisKelamin = If(IsDBNull(dt.Rows(0).Item("JenisKelamin")), "", dt.Rows(0).Item("JenisKelamin").ToString())
                    .TglLahir = If(IsDBNull(dt.Rows(0).Item("TglLahir")), Date.Today, dt.Rows(0).Item("TglLahir"))
                    .Factory = If(IsDBNull(dt.Rows(0).Item("Factory")), "", dt.Rows(0).Item("Factory").ToString())
                    .StatusKaryawan = If(IsDBNull(dt.Rows(0).Item("StatusKaryawan")), "", dt.Rows(0).Item("StatusKaryawan").ToString())
                    .TipeKaryawan = If(IsDBNull(dt.Rows(0).Item("TipeKaryawan")), "", dt.Rows(0).Item("TipeKaryawan").ToString())
                    .Organisasi = If(IsDBNull(dt.Rows(0).Item("Organisasi")), "", dt.Rows(0).Item("Organisasi").ToString())
                    .Jabatan = If(IsDBNull(dt.Rows(0).Item("Jabatan")), "", dt.Rows(0).Item("Jabatan").ToString())
                End With
            End If
            Return modelHeader
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataDataPribadi(ByVal EmpID As String) As DataTable
        Try
            strQuery = "SELECT  ID ,
                                TglMulai ,
                                TglSelesai ,
                                EmployeeID ,
                                PINFinger ,
                                NamaLengkap ,
                                NamaPanggilan ,
                                JenisKelamin ,
                                TempatLahir ,
                                TglLahir ,
                                Tamatan ,
                                Kewarganegaraan ,
                                Agama ,
                                GolonganDarah ,
                                StatusKawin ,
                                TglKawin ,
                                JumlahAnak ,
                                Reference ,
                                Gambar ,
                                Ket ,
                                TglBuat ,
                                UserBuat ,
                                TglUbah ,
                                UserUbah
                        FROM    dbo.M_HRPADataPribadi
                        WHERE   EmployeeID = " & QVal(EmpID) & ""
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataDataKaryawan(ByVal EmpID As String) As DataTable
        Try
            strQuery = "SELECT  pdk.ID ,
                                pdk.TglMulai ,
                                pdk.TglSelesai ,
                                pdk.EmployeeID ,
                                pdk.NIK ,
                                pdk.PerpindahanKaryawan ,
                                pp.PerpindahanDesc ,
                                pdk.AlasanPindah ,
                                ap.AlasanPindahDesc ,
                                pdk.Golongan AS Gol ,
                                --pg.GolDesc AS Golongan ,
                                pdk.StatusKaryawan ,
                                pdk.TipeKaryawan ,
                                pdk.TipePosisiKaryawan ,
                                pdk.Factory ,
                                pdk.Organisasi AS OrgID ,
                                oo.OrgDesc AS Organisasi ,
                                pdk.Jabatan AS JabID ,
                                oj.OrgDesc AS Jabatan ,
                                pdk.Job ,
                                pdk.TglEfektif ,
                                pdk.TglBerakhir ,
                                pdk.SK ,
                                pdk.Ket ,
                                pdk.TglBuat ,
                                pdk.UserBuat ,
                                pdk.TglUbah ,
                                pdk.UserUbah
                        FROM    dbo.M_HRPADataKaryawan AS pdk
                                LEFT JOIN dbo.M_HROrgOrganisasi AS oo ON oo.OrgID = pdk.Organisasi
                                LEFT JOIN dbo.M_HROrgJabatan AS oj ON pdk.Jabatan = oj.OrgID
                                --LEFT JOIN dbo.S_HRPAGolongan AS pg ON pdk.Golongan = pg.Gol
                                LEFT JOIN dbo.S_HRPAPerpindahan AS pp ON pdk.PerpindahanKaryawan = pp.Perpindahan
                                LEFT JOIN dbo.S_HRPAAlasanPindah AS ap ON ap.AlasanPindah = pdk.AlasanPindah
                        WHERE   EmployeeID = " & QVal(EmpID) & ""
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataDataAlamat(ByVal EmpID As String) As DataTable
        Try
            strQuery = "SELECT  ID ,
                                TglMulai ,
                                TglSelesai ,
                                EmployeeID ,
                                TipeAlamat ,
                                Seq ,
                                Alamat ,
                                RT ,
                                RW ,
                                Negara ,
                                Provinsi ,
                                KotaKab ,
                                Kecamatan ,
                                Kelurahan ,
                                KodePos ,
                                NoTelpon ,
                                Ket ,
                                TglBuat ,
                                UserBuat ,
                                TglUbah ,
                                UserUbah
                        FROM    dbo.M_HRPADataAlamat
                        WHERE   EmployeeID = " & QVal(EmpID) & ""
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataDataKeluarga(ByVal EmpID As String) As DataTable
        Try
            strQuery = "SELECT  ID ,
                                TglMulai ,
                                TglSelesai ,
                                EmployeeID ,
                                Hubungan ,
                                Seq ,
                                Nama ,
                                JenisKelamin ,
                                TempatLahir ,
                                TglLahir ,
                                TglKematian ,
                                Agama ,
                                Tamatan ,
                                Alamat ,
                                NoTelpon ,
                                Pekerjaan ,
                                Ket ,
                                TglBuat ,
                                UserBuat ,
                                TglUbah ,
                                UserUbah
                        FROM    dbo.M_HRPADataKeluarga
                        WHERE   EmployeeID = " & QVal(EmpID) & ""
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataDataPendidikan(ByVal EmpID As String) As DataTable
        Try
            strQuery = "SELECT  ID ,
                                TglMulai ,
                                TglSelesai ,
                                EmployeeID ,
                                Seq ,
                                TipePendidikan ,
                                TingkatPendidikan ,
                                NamaInstitut ,
                                Jurusan ,
                                Alamat ,
                                IPK ,
                                Nilai ,
                                NamaPelatihan ,
                                Ket ,
                                TglBuat ,
                                UserBuat ,
                                TglUbah ,
                                UserUbah
                        FROM    dbo.M_HRPADataPendidikan
                        WHERE   EmployeeID = " & QVal(EmpID) & ""
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataDataKomunikasi(ByVal EmpID As String) As DataTable
        Try
            strQuery = "SELECT  ID ,
                                TglMulai ,
                                TglSelesai ,
                                EmployeeID ,
                                Seq ,
                                TipeKomunikasi ,
                                Deskripsi ,
                                Ket ,
                                TglBuat ,
                                UserBuat ,
                                TglUbah ,
                                UserUbah
                        FROM    dbo.M_HRPADataKomunikasi
                        WHERE   EmployeeID = " & QVal(EmpID) & ""
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub SaveNewEmployee(DataPribadi As HRPADataPribadiModel, DataKaryawan As HRPADataKaryawanModel, OrgStruktur As HROrgStrukturModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertDataPribadi(DataPribadi)
                        InsertDataKaryawan(DataKaryawan)

                        InsertOrgStruktur(OrgStruktur)
                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub SaveNewDataPribadi(Data As HRPADataPribadiModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertDataPribadi(Data)
                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub SaveEditDataPribadi(Data As HRPADataPribadiModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        EditDataPribadi(Data)
                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertDataPribadi(Data As HRPADataPribadiModel)
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "HR_PAInsertDataPribadi"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(22) {}
            pParam(0) = New SqlClient.SqlParameter("@TglMulai", SqlDbType.Date)
            pParam(0).Value = Data.TglMulai
            pParam(1) = New SqlClient.SqlParameter("@TglSelesai", SqlDbType.Date)
            pParam(1).Value = Data.TglSelesai
            pParam(2) = New SqlClient.SqlParameter("@EmployeeID", SqlDbType.VarChar)
            pParam(2).Value = Data.EmpID
            pParam(3) = New SqlClient.SqlParameter("@PINFinger", SqlDbType.Char)
            pParam(3).Value = Data.PINFinger
            pParam(4) = New SqlClient.SqlParameter("@NamaLengkap", SqlDbType.VarChar)
            pParam(4).Value = Data.NamaLengkap
            pParam(5) = New SqlClient.SqlParameter("@NamaPanggilan", SqlDbType.VarChar)
            pParam(5).Value = Data.NamaPanggilan
            pParam(6) = New SqlClient.SqlParameter("@JenisKelamin", SqlDbType.VarChar)
            pParam(6).Value = Data.JenisKelamin
            pParam(7) = New SqlClient.SqlParameter("@TempatLahir", SqlDbType.VarChar)
            pParam(7).Value = Data.TempatLahir
            pParam(8) = New SqlClient.SqlParameter("@TglLahir", SqlDbType.Date)
            pParam(8).Value = Data.TglLahir
            pParam(9) = New SqlClient.SqlParameter("@Tamatan", SqlDbType.VarChar)
            pParam(9).Value = Data.Tamatan
            pParam(10) = New SqlClient.SqlParameter("@Kewarganegaraan", SqlDbType.VarChar)
            pParam(10).Value = Data.Kewarganegaraan
            pParam(11) = New SqlClient.SqlParameter("@Agama", SqlDbType.VarChar)
            pParam(11).Value = Data.Agama
            pParam(12) = New SqlClient.SqlParameter("@GolonganDarah", SqlDbType.VarChar)
            pParam(12).Value = Data.GolonganDarah
            pParam(13) = New SqlClient.SqlParameter("@StatusKawin", SqlDbType.VarChar)
            pParam(13).Value = Data.StatusKawin
            pParam(14) = New SqlClient.SqlParameter("@TglKawin", SqlDbType.Date)
            pParam(14).Value = Data.TglKawin
            pParam(15) = New SqlClient.SqlParameter("@JumlahAnak", SqlDbType.Int)
            pParam(15).Value = Data.JumlahAnak
            pParam(16) = New SqlClient.SqlParameter("@Gambar", SqlDbType.Image)
            pParam(16).Value = Data.Gambar
            pParam(17) = New SqlClient.SqlParameter("@Reference", SqlDbType.VarChar)
            pParam(17).Value = Data.Reference
            pParam(18) = New SqlClient.SqlParameter("@Ket", SqlDbType.VarChar)
            pParam(18).Value = Data.Ket
            pParam(19) = New SqlClient.SqlParameter("@TglBuat", SqlDbType.DateTime)
            pParam(19).Value = Data.TglBuat
            pParam(20) = New SqlClient.SqlParameter("@UserBuat", SqlDbType.VarChar)
            pParam(20).Value = Data.UserBuat
            pParam(21) = New SqlClient.SqlParameter("@TglUbah", SqlDbType.DateTime)
            pParam(21).Value = Data.TglUbah
            pParam(22) = New SqlClient.SqlParameter("@UserUbah", SqlDbType.VarChar)
            pParam(22).Value = Data.UserUbah

            ExecQueryByCommand_SP(SP_Name, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub EditDataPribadi(Data As HRPADataPribadiModel)
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "HR_PAEditDataPribadi"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(23) {}
            pParam(0) = New SqlClient.SqlParameter("@ID", SqlDbType.Int)
            pParam(0).Value = Data.ID
            pParam(1) = New SqlClient.SqlParameter("@TglMulai", SqlDbType.Date)
            pParam(1).Value = Data.TglMulai
            pParam(2) = New SqlClient.SqlParameter("@TglSelesai", SqlDbType.Date)
            pParam(2).Value = Data.TglSelesai
            pParam(3) = New SqlClient.SqlParameter("@EmployeeID", SqlDbType.VarChar)
            pParam(3).Value = Data.EmpID
            pParam(4) = New SqlClient.SqlParameter("@PINFinger", SqlDbType.Char)
            pParam(4).Value = Data.PINFinger
            pParam(5) = New SqlClient.SqlParameter("@NamaLengkap", SqlDbType.VarChar)
            pParam(5).Value = Data.NamaLengkap
            pParam(6) = New SqlClient.SqlParameter("@NamaPanggilan", SqlDbType.VarChar)
            pParam(6).Value = Data.NamaPanggilan
            pParam(7) = New SqlClient.SqlParameter("@JenisKelamin", SqlDbType.VarChar)
            pParam(7).Value = Data.JenisKelamin
            pParam(8) = New SqlClient.SqlParameter("@TempatLahir", SqlDbType.VarChar)
            pParam(8).Value = Data.TempatLahir
            pParam(9) = New SqlClient.SqlParameter("@TglLahir", SqlDbType.Date)
            pParam(9).Value = Data.TglLahir
            pParam(10) = New SqlClient.SqlParameter("@Tamatan", SqlDbType.VarChar)
            pParam(10).Value = Data.Tamatan
            pParam(11) = New SqlClient.SqlParameter("@Kewarganegaraan", SqlDbType.VarChar)
            pParam(11).Value = Data.Kewarganegaraan
            pParam(12) = New SqlClient.SqlParameter("@Agama", SqlDbType.VarChar)
            pParam(12).Value = Data.Agama
            pParam(13) = New SqlClient.SqlParameter("@GolonganDarah", SqlDbType.VarChar)
            pParam(13).Value = Data.GolonganDarah
            pParam(14) = New SqlClient.SqlParameter("@StatusKawin", SqlDbType.VarChar)
            pParam(14).Value = Data.StatusKawin
            pParam(15) = New SqlClient.SqlParameter("@TglKawin", SqlDbType.Date)
            pParam(15).Value = Data.TglKawin
            pParam(16) = New SqlClient.SqlParameter("@JumlahAnak", SqlDbType.Int)
            pParam(16).Value = Data.JumlahAnak
            pParam(17) = New SqlClient.SqlParameter("@Gambar", SqlDbType.Image)
            pParam(17).Value = Data.Gambar
            pParam(18) = New SqlClient.SqlParameter("@Reference", SqlDbType.VarChar)
            pParam(18).Value = Data.Reference
            pParam(19) = New SqlClient.SqlParameter("@Ket", SqlDbType.VarChar)
            pParam(19).Value = Data.Ket
            pParam(20) = New SqlClient.SqlParameter("@TglBuat", SqlDbType.DateTime)
            pParam(20).Value = Data.TglBuat
            pParam(21) = New SqlClient.SqlParameter("@UserBuat", SqlDbType.VarChar)
            pParam(21).Value = Data.UserBuat
            pParam(22) = New SqlClient.SqlParameter("@TglUbah", SqlDbType.DateTime)
            pParam(22).Value = Data.TglUbah
            pParam(23) = New SqlClient.SqlParameter("@UserUbah", SqlDbType.VarChar)
            pParam(23).Value = Data.UserUbah

            ExecQueryByCommand_SP(SP_Name, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub SaveNewDataKaryawan(Data As HRPADataKaryawanModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        InsertDataKaryawan(Data)
                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub SaveEditDataKaryawan(Data As HRPADataKaryawanModel)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        EditDataKaryawan(Data)
                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertDataKaryawan(Data As HRPADataKaryawanModel)
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "HR_PAInsertDataKaryawan"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(21) {}
            pParam(0) = New SqlClient.SqlParameter("@TglMulai", SqlDbType.Date)
            pParam(0).Value = Data.TglMulai
            pParam(1) = New SqlClient.SqlParameter("@TglSelesai", SqlDbType.Date)
            pParam(1).Value = Data.TglSelesai
            pParam(2) = New SqlClient.SqlParameter("@EmployeeID", SqlDbType.VarChar)
            pParam(2).Value = Data.EmpID
            pParam(3) = New SqlClient.SqlParameter("@NIK", SqlDbType.VarChar)
            pParam(3).Value = Data.NIK
            pParam(4) = New SqlClient.SqlParameter("@PerpindahanKaryawan", SqlDbType.VarChar)
            pParam(4).Value = Data.PerpindahanKaryawan
            pParam(5) = New SqlClient.SqlParameter("@AlasanPindah", SqlDbType.VarChar)
            pParam(5).Value = Data.AlasanPindah
            pParam(6) = New SqlClient.SqlParameter("@Golongan", SqlDbType.VarChar)
            pParam(6).Value = Data.Golongan
            pParam(7) = New SqlClient.SqlParameter("@StatusKaryawan", SqlDbType.VarChar)
            pParam(7).Value = Data.StatusKaryawan
            pParam(8) = New SqlClient.SqlParameter("@TipeKaryawan", SqlDbType.VarChar)
            pParam(8).Value = Data.TipeKaryawan
            pParam(9) = New SqlClient.SqlParameter("@TipePosisiKaryawan", SqlDbType.VarChar)
            pParam(9).Value = Data.TipePosisiKaryawan
            pParam(10) = New SqlClient.SqlParameter("@Factory", SqlDbType.VarChar)
            pParam(10).Value = Data.Factory
            pParam(11) = New SqlClient.SqlParameter("@Organisasi", SqlDbType.VarChar)
            pParam(11).Value = Data.Organisasi
            pParam(12) = New SqlClient.SqlParameter("@Jabatan", SqlDbType.VarChar)
            pParam(12).Value = Data.Jabatan
            pParam(13) = New SqlClient.SqlParameter("@Job", SqlDbType.VarChar)
            pParam(13).Value = Data.Job
            pParam(14) = New SqlClient.SqlParameter("@TglEfektif", SqlDbType.Date)
            pParam(14).Value = Data.TglEfektif
            pParam(15) = New SqlClient.SqlParameter("@TglBerakhir", SqlDbType.Date)
            pParam(15).Value = Data.TglBerakhir
            pParam(16) = New SqlClient.SqlParameter("@SK", SqlDbType.VarChar)
            pParam(16).Value = Data.SK
            pParam(17) = New SqlClient.SqlParameter("@Ket", SqlDbType.VarChar)
            pParam(17).Value = Data.Ket
            pParam(18) = New SqlClient.SqlParameter("@TglBuat", SqlDbType.DateTime)
            pParam(18).Value = Data.TglBuat
            pParam(19) = New SqlClient.SqlParameter("@UserBuat", SqlDbType.VarChar)
            pParam(19).Value = Data.UserBuat
            pParam(20) = New SqlClient.SqlParameter("@TglUbah", SqlDbType.DateTime)
            pParam(20).Value = Data.TglUbah
            pParam(21) = New SqlClient.SqlParameter("@UserUbah", SqlDbType.VarChar)
            pParam(21).Value = Data.UserUbah

            ExecQueryByCommand_SP(SP_Name, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub EditDataKaryawan(Data As HRPADataKaryawanModel)
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "HR_PAEditDataKaryawan"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(22) {}
            pParam(0) = New SqlClient.SqlParameter("@ID", SqlDbType.Int)
            pParam(0).Value = Data.ID
            pParam(1) = New SqlClient.SqlParameter("@TglMulai", SqlDbType.Date)
            pParam(1).Value = Data.TglMulai
            pParam(2) = New SqlClient.SqlParameter("@TglSelesai", SqlDbType.Date)
            pParam(2).Value = Data.TglSelesai
            pParam(3) = New SqlClient.SqlParameter("@EmployeeID", SqlDbType.VarChar)
            pParam(3).Value = Data.EmpID
            pParam(4) = New SqlClient.SqlParameter("@NIK", SqlDbType.VarChar)
            pParam(4).Value = Data.NIK
            pParam(5) = New SqlClient.SqlParameter("@PerpindahanKaryawan", SqlDbType.VarChar)
            pParam(5).Value = Data.PerpindahanKaryawan
            pParam(6) = New SqlClient.SqlParameter("@AlasanPindah", SqlDbType.VarChar)
            pParam(6).Value = Data.AlasanPindah
            pParam(7) = New SqlClient.SqlParameter("@Golongan", SqlDbType.VarChar)
            pParam(7).Value = Data.Golongan
            pParam(8) = New SqlClient.SqlParameter("@StatusKaryawan", SqlDbType.VarChar)
            pParam(8).Value = Data.StatusKaryawan
            pParam(9) = New SqlClient.SqlParameter("@TipeKaryawan", SqlDbType.VarChar)
            pParam(9).Value = Data.TipeKaryawan
            pParam(10) = New SqlClient.SqlParameter("@TipePosisiKaryawan", SqlDbType.VarChar)
            pParam(10).Value = Data.TipePosisiKaryawan
            pParam(11) = New SqlClient.SqlParameter("@Factory", SqlDbType.VarChar)
            pParam(11).Value = Data.Factory
            pParam(12) = New SqlClient.SqlParameter("@Organisasi", SqlDbType.VarChar)
            pParam(12).Value = Data.Organisasi
            pParam(13) = New SqlClient.SqlParameter("@Jabatan", SqlDbType.VarChar)
            pParam(13).Value = Data.Jabatan
            pParam(14) = New SqlClient.SqlParameter("@Job", SqlDbType.VarChar)
            pParam(14).Value = Data.Job
            pParam(15) = New SqlClient.SqlParameter("@TglEfektif", SqlDbType.Date)
            pParam(15).Value = Data.TglEfektif
            pParam(16) = New SqlClient.SqlParameter("@TglBerakhir", SqlDbType.Date)
            pParam(16).Value = Data.TglBerakhir
            pParam(17) = New SqlClient.SqlParameter("@SK", SqlDbType.VarChar)
            pParam(17).Value = Data.SK
            pParam(18) = New SqlClient.SqlParameter("@Ket", SqlDbType.VarChar)
            pParam(18).Value = Data.Ket
            pParam(19) = New SqlClient.SqlParameter("@TglBuat", SqlDbType.DateTime)
            pParam(19).Value = Data.TglBuat
            pParam(20) = New SqlClient.SqlParameter("@UserBuat", SqlDbType.VarChar)
            pParam(20).Value = Data.UserBuat
            pParam(21) = New SqlClient.SqlParameter("@TglUbah", SqlDbType.DateTime)
            pParam(21).Value = Data.TglUbah
            pParam(22) = New SqlClient.SqlParameter("@UserUbah", SqlDbType.VarChar)
            pParam(22).Value = Data.UserUbah

            ExecQueryByCommand_SP(SP_Name, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub InsertOrgStruktur(OrgStruktur As HROrgStrukturModel)
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "HR_OrgInsertStruktur"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(10) {}
            pParam(0) = New SqlClient.SqlParameter("@TglMulai", SqlDbType.Date)
            pParam(0).Value = OrgStruktur.TglMulai
            pParam(1) = New SqlClient.SqlParameter("@TglSelesai", SqlDbType.Date)
            pParam(1).Value = OrgStruktur.TglSelesai
            pParam(2) = New SqlClient.SqlParameter("@OrgID", SqlDbType.VarChar)
            pParam(2).Value = OrgStruktur.OrgID
            pParam(3) = New SqlClient.SqlParameter("@OrgClass", SqlDbType.VarChar)
            pParam(3).Value = OrgStruktur.OrgClass
            pParam(4) = New SqlClient.SqlParameter("@RelClass", SqlDbType.VarChar)
            pParam(4).Value = OrgStruktur.RelClass
            pParam(5) = New SqlClient.SqlParameter("@RelOrg", SqlDbType.VarChar)
            pParam(5).Value = OrgStruktur.RelOrg
            pParam(6) = New SqlClient.SqlParameter("@Ket", SqlDbType.VarChar)
            pParam(6).Value = OrgStruktur.Ket
            pParam(7) = New SqlClient.SqlParameter("@TglBuat", SqlDbType.DateTime)
            pParam(7).Value = OrgStruktur.TglBuat
            pParam(8) = New SqlClient.SqlParameter("@UserBuat", SqlDbType.VarChar)
            pParam(8).Value = OrgStruktur.UserBuat
            pParam(9) = New SqlClient.SqlParameter("@TglUbah", SqlDbType.DateTime)
            pParam(9).Value = OrgStruktur.TglUbah
            pParam(10) = New SqlClient.SqlParameter("@UserUbah", SqlDbType.VarChar)
            pParam(10).Value = OrgStruktur.UserUbah

            ExecQueryByCommand_SP(SP_Name, pParam)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Function GetStrukturOrg(TglMulai As Date) As DataTable
        Try
            Dim Sql As String = "HR_GetStrukturOrg"
            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@TglMulai", SqlDbType.Date)
            pParam(0).Value = TglMulai

            Dim dt As New DataTable

            dt = GetDataTableByCommand_SP(Sql, pParam)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetListPerpindahan() As DataTable
        Try
            strQuery = "SELECT  Perpindahan ,
                                PerpindahanDesc
                        FROM    dbo.S_HRPAPerpindahan"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetListAlasan(perpindahan As String) As DataTable
        Try
            strQuery = "SELECT  AlasanPindah ,
                                AlasanPindahDesc
                        FROM    dbo.S_HRPAAlasanPindah
                        WHERE   Perpindahan = " & QVal(perpindahan) & ""
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetListGolongan() As DataTable
        Try
            strQuery = "SELECT  Gol ,
                                GolDesc
                        FROM    dbo.S_HRPAGolongan"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetListOrganisasi() As DataTable
        Try
            strQuery = "SELECT  OrgID ,
                                OrgDesc
                        FROM    dbo.M_HROrgOrganisasi"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAutoNumberEmpID() As String
        Try
            strQuery = "DECLARE @seq VARCHAR(8);
                        SET @seq = ( SELECT RIGHT('00000000' + CAST(MAX(EmployeeID) + 1 AS VARCHAR), 8)
                                     FROM   dbo.M_HRPADataPribadi
                                   ); 
                        SELECT  COALESCE(@seq, '00000001');"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)

            Return dt.Rows(0).Item(0).ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetAutoNumberNIK() As String
        Try
            strQuery = "SELECT  RIGHT(Tahun, 2) + RIGHT('000000' + CAST(AvailableNo AS VARCHAR), 8)
                        FROM    dbo.S_Numbering
                        WHERE   MenuCode = 'FrmHRPANewEmployee'"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)

            Return dt.Rows(0).Item(0).ToString
        Catch ex As Exception
            Throw ex
        End Try
    End Function

#Region "Check apakah ada data yg jadi bagian periode ini (DATA PRIBADI)"
    Public Function CheckRangeDatePribadi(EmpID As String, TglMulai As Date, TglSelesai As Date) As Boolean
        Try
            strQuery = "SELECT  COUNT(EmployeeID)
                        FROM    dbo.M_HRPADataPribadi
                        WHERE   EmployeeID = " & QVal(EmpID) & "
                                AND ( TglMulai >= " & QVal(TglMulai) & "
                                      AND TglSelesai <= " & QVal(TglSelesai) & "
                                    )"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)

            Return dt.Rows(0).Item(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CheckRangeDateEditPribadi(ID As Integer, EmpID As String, TglMulai As Date, TglSelesai As Date) As Boolean
        Try
            strQuery = "SELECT  COUNT(EmployeeID)
                        FROM    dbo.M_HRPADataPribadi
                        WHERE   EmployeeID = " & QVal(EmpID) & "
                                AND ( TglMulai >= " & QVal(TglMulai) & "
                                      AND TglSelesai <= " & QVal(TglSelesai) & "
                                    )
                                AND ID <> " & ID & ""
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)

            Return dt.Rows(0).Item(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

#Region "Check apakah ada data yg jadi bagian periode ini (DATA KARIR)"
    Public Function CheckRangeDateKarir(EmpID As String, TglMulai As Date, TglSelesai As Date) As Boolean
        Try
            strQuery = "SELECT  COUNT(EmployeeID)
                        FROM    dbo.M_HRPADataKaryawan
                        WHERE   EmployeeID = " & QVal(EmpID) & "
                                AND ( TglMulai >= " & QVal(TglMulai) & "
                                      AND TglSelesai <= " & QVal(TglSelesai) & "
                                    )"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)

            Return dt.Rows(0).Item(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function CheckRangeDateEditKarir(ID As Integer, EmpID As String, TglMulai As Date, TglSelesai As Date) As Boolean
        Try
            strQuery = "SELECT  COUNT(EmployeeID)
                        FROM    dbo.M_HRPADataKaryawan
                        WHERE   EmployeeID = " & QVal(EmpID) & "
                                AND ( TglMulai >= " & QVal(TglMulai) & "
                                      AND TglSelesai <= " & QVal(TglSelesai) & "
                                    )
                                AND ID <> " & ID & ""
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)

            Return dt.Rows(0).Item(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function
#End Region

End Class
