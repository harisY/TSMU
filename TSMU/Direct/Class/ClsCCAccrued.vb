Imports System.Collections.ObjectModel

Public Class ClsCCAccrued
    Dim clsGlobal As GlobalService
    Public Property ID As Integer
    Public Property NoAccrued As String
    Public Property Tanggal As Date
    Public Property TanggalTrans As Date
    Public Property NoTransaksi As String
    Public Property Seq As Integer
    Public Property JenisTransaksi As String
    Public Property Description As String
    Public Property CurryID As String
    Public Property Amount As Double
    Public Property AccrualEstimate As Double
    Public Property Rate As Double
    Public Property AmountIDR As Double
    Public Property CCNumberMaster As String
    Public Property CreditCardNumber As String
    Public Property AccountName As String
    Public Property BankName As String
    Public Property Pay As Integer

    Public Property ObjCCAccrued() As New Collection(Of ClsCCAccrued)

    Dim strQuery As String

    Public Function GetDataCostCC() As DataTable
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "Accrued_Get_CostCC"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@CreditCardNumber", SqlDbType.VarChar)
            pParam(0).Value = CreditCardNumber

            dt = GetDataTableByCommand_SP(SP_Name, pParam)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataCostCCSum() As DataTable
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "Accrued_Get_CostCCSum"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@CreditCardNumber", SqlDbType.VarChar)
            pParam(0).Value = CreditCardNumber

            dt = GetDataTableByCommand_SP(SP_Name, pParam)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataCCSettle() As DataTable
        Try
            Dim dt As New DataTable
            strQuery = "SELECT  ID ,
                                NoAccrued ,
                                Tanggal ,
                                TanggalTrans ,
                                NoTransaksi ,
                                Seq ,
                                JenisTransaksi ,
                                Description ,
                                CurryID ,
                                Amount ,
                                ISNULL(dbo.ConvertToIDR(TanggalTrans, CurryID), 1) * Amount AS AccrualEstimate ,
                                Rate ,
                                AmountIDR ,
                                tcc.Type ,
                                tc.CCNumberMaster ,
                                tc.CreditCardNumber ,
                                tcc.AccountName ,
                                tcc.BankName ,
                                Pay
                        FROM    dbo.T_CCAccrued AS tc
                                LEFT JOIN dbo.TravelCreditCard AS tcc ON tcc.CreditCardNumber = tc.CreditCardNumber
                        WHERE   Pay = 0
                        ORDER BY tcc.Type ASC ,
                                tc.CreditCardNumber ASC ,
                                tc.TanggalTrans ASC"
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataCCSettleSum() As DataTable
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "Accrued_Get_CCSettleSum"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter() {}

            dt = GetDataTableByCommand_SP(SP_Name, pParam)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataCCPaid(dateFrom As Date, dateTo As Date) As DataTable
        Try
            Dim dt As New DataTable
            strQuery = "SELECT  ID ,
                                NoAccrued ,
                                Tanggal ,
                                TanggalTrans ,
                                NoTransaksi ,
                                Seq ,
                                JenisTransaksi ,
                                Description ,
                                CurryID ,
                                Amount ,
                                ISNULL(dbo.ConvertToIDR(TanggalTrans, CurryID), 1) * Amount AS AccrualEstimate ,
                                Rate ,
                                AmountIDR ,
                                tcc.Type ,
                                tc.CCNumberMaster ,
                                tc.CreditCardNumber ,
                                tc.AccountName ,
                                tc.BankName ,
                                Pay
                        FROM    dbo.T_CCAccrued AS tc
                                LEFT JOIN dbo.TravelCreditCard AS tcc ON tcc.CreditCardNumber = tc.CreditCardNumber
                        WHERE   Pay = 1
                                AND ( TanggalTrans >= " & QVal(dateFrom) & "
                                      AND TanggalTrans <= " & QVal(dateTo) & "
                                    )
                        ORDER BY tcc.Type ASC ,
                                tc.CreditCardNumber ASC ,
                                tc.TanggalTrans ASC"
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function GetDataCCPaidSum(dateFrom As Date, dateTo As Date) As DataTable
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "Accrued_Get_CCPaidSum"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(1) {}
            pParam(0) = New SqlClient.SqlParameter("@DateFrom", SqlDbType.VarChar)
            pParam(0).Value = dateFrom
            pParam(1) = New SqlClient.SqlParameter("@DateTo", SqlDbType.VarChar)
            pParam(1).Value = dateTo

            dt = GetDataTableByCommand_SP(SP_Name, pParam)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Sub InsertData(frm As Form, noAccrued_ As String, _ccNumberMaster As String, rows As ArrayList)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        For i = 0 To rows.Count - 1
                            Dim Row As DataRow = CType(rows(i), DataRow)
                            NoAccrued = noAccrued_
                            Tanggal = Date.Today
                            TanggalTrans = Row("TanggalTransaksi")
                            NoTransaksi = Row("NoTransaksi")
                            Seq = Row("Seq")
                            JenisTransaksi = Row("JenisTransaksi")
                            Description = Row("Description")
                            CurryID = Row("CurryID")
                            Amount = Row("Amount")
                            AccrualEstimate = Row("AccrualEstimate")
                            Rate = Row("Rate")
                            AmountIDR = Row("AmountIDR")
                            CCNumberMaster = _ccNumberMaster
                            CreditCardNumber = IIf(Row("CreditCardNumber") Is DBNull.Value, "", Row("CreditCardNumber"))
                            AccountName = IIf(Row("AccountName") Is DBNull.Value, "", Row("AccountName"))
                            BankName = IIf(Row("BankName") Is DBNull.Value, "", Row("BankName"))
                            InsertDataAccrued()
                        Next

                        clsGlobal = New GlobalService
                        clsGlobal.UpdateAutoNumber(frm)

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

    Public Sub DeleteData(rows As ArrayList)
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        For i = 0 To rows.Count - 1
                            Dim Row As DataRow = CType(rows(i), DataRow)
                            NoAccrued = Row("NoAccrued")
                            NoTransaksi = Row("NoTransaksi")
                            Seq = Row("Seq")
                            DeleteDataAccrued()
                        Next

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

    Public Sub InsertDataAccrued()
        Try
            Dim dt As New DataTable

            Dim SP_Name As String = "Accrued_Insert_CCAccrued"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(16) {}
            pParam(0) = New SqlClient.SqlParameter("@NoAccrued", SqlDbType.VarChar)
            pParam(0).Value = NoAccrued
            pParam(1) = New SqlClient.SqlParameter("@Tanggal", SqlDbType.Date)
            pParam(1).Value = Tanggal
            pParam(2) = New SqlClient.SqlParameter("@TanggalTrans", SqlDbType.Date)
            pParam(2).Value = TanggalTrans
            pParam(3) = New SqlClient.SqlParameter("@NoTransaksi", SqlDbType.VarChar)
            pParam(3).Value = NoTransaksi
            pParam(4) = New SqlClient.SqlParameter("@Seq", SqlDbType.VarChar)
            pParam(4).Value = Seq
            pParam(5) = New SqlClient.SqlParameter("@JenisTransaksi", SqlDbType.VarChar)
            pParam(5).Value = JenisTransaksi
            pParam(6) = New SqlClient.SqlParameter("@Description", SqlDbType.VarChar)
            pParam(6).Value = Description
            pParam(7) = New SqlClient.SqlParameter("@CurryID", SqlDbType.VarChar)
            pParam(7).Value = CurryID
            pParam(8) = New SqlClient.SqlParameter("@Amount", SqlDbType.Float)
            pParam(8).Value = Amount
            pParam(9) = New SqlClient.SqlParameter("@AccrualEstimate", SqlDbType.Float)
            pParam(9).Value = AccrualEstimate
            pParam(10) = New SqlClient.SqlParameter("@Rate", SqlDbType.Float)
            pParam(10).Value = Rate
            pParam(11) = New SqlClient.SqlParameter("@AmountIDR", SqlDbType.Float)
            pParam(11).Value = AmountIDR
            pParam(12) = New SqlClient.SqlParameter("@CCNumberMaster", SqlDbType.VarChar)
            pParam(12).Value = CCNumberMaster
            pParam(13) = New SqlClient.SqlParameter("@CreditCardNumber", SqlDbType.VarChar)
            pParam(13).Value = CreditCardNumber
            pParam(14) = New SqlClient.SqlParameter("@AccountName", SqlDbType.VarChar)
            pParam(14).Value = AccountName
            pParam(15) = New SqlClient.SqlParameter("@BankName", SqlDbType.VarChar)
            pParam(15).Value = BankName
            pParam(16) = New SqlClient.SqlParameter("@Username", SqlDbType.VarChar)
            pParam(16).Value = gh_Common.Username

            ExecQueryByCommand_SP(SP_Name, pParam)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteDataAccrued()
        Try
            Dim dt As New DataTable

            Dim SP_Name As String = "Accrued_Delete_CCAccrued"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(2) {}
            pParam(0) = New SqlClient.SqlParameter("@NoAccrued", SqlDbType.VarChar)
            pParam(0).Value = NoAccrued
            pParam(1) = New SqlClient.SqlParameter("@NoTransaksi", SqlDbType.VarChar)
            pParam(1).Value = NoTransaksi
            pParam(2) = New SqlClient.SqlParameter("@Seq", SqlDbType.VarChar)
            pParam(2).Value = Seq

            ExecQueryByCommand_SP(SP_Name, pParam)

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Function GetCreditCard() As DataTable
        Try
            strQuery = "SELECT  CreditCardNumber ,
                                AccountName ,
                                BankName
                        FROM    dbo.TravelCreditCard
                        WHERE   Type = 'M'"
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class

Public Class ClsReportCCAccrued
    Public Function LoadReportAccrued() As DataTable
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "Accrued_Rpt_GetAccrued"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@Date", SqlDbType.VarChar)
            pParam(0).Value = Today.Date

            dt = GetDataTableByCommand_SP(SP_Name, pParam)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function LoadReportAccruedAndSettle() As DataTable
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "Accrued_Rpt_GetAccruedAndSettle"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@Date", SqlDbType.VarChar)
            pParam(0).Value = Today.Date

            dt = GetDataTableByCommand_SP(SP_Name, pParam)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function LoadReportCCSettle(_param As String) As DataTable
        Try
            Dim dt As New DataTable
            Dim SP_Name As String = "Accrued_Rpt_GetCCSettlement"

            Dim pParam() As SqlClient.SqlParameter = New SqlClient.SqlParameter(0) {}
            pParam(0) = New SqlClient.SqlParameter("@Param", SqlDbType.VarChar)
            pParam(0).Value = _param

            dt = GetDataTableByCommand_SP(SP_Name, pParam)

            Return dt
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
