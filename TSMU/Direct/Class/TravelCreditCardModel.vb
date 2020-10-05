﻿Public Class TravelCreditCardModel
    Public Property CreditCardID As String
    Public Property CreditCardNumber As String
    Public Property AccountName As String
    Public Property BankName As String
    Public Property Provider As String
    Public Property ExpDate As Date
    Public Property Type As String
    Public Property CCNumberMaster As String

    Dim strQuery As String

    Public Function TravelAutoCreditCardID() As String
        Try
            strQuery = " DECLARE @seq VARCHAR(4) " &
                        " SET @seq = ( SELECT RIGHT('000' " &
                        "                           + CAST(RIGHT(RTRIM(MAX(CreditCardID)), 3) + 1 AS VARCHAR), " &
                        "                           3) " &
                        "              From dbo.TravelCreditCard " &
                        "            ) " &
                        " SELECT  'CC' + COALESCE(@seq, '001') "
            Dim dt As DataTable = New DataTable
            dt = GetDataTable(strQuery)
            Return dt.Rows(0).Item(0).ToString

        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function GetAllDataTable(ByVal ls_Filter As String) As DataTable
        Try
            strQuery = "SELECT  CreditCardID ,
                                CreditCardNumber ,
                                AccountName ,
                                BankName ,
                                Provider ,
                                ExpDate ,
                                [Type] ,
                                CCNumberMaster
                        FROM    dbo.TravelCreditCard"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable(strQuery)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub GetCreditCardByID()
        Try
            strQuery = " SELECT  CreditCardID ,
                                CreditCardNumber ,
                                AccountName ,
                                BankName ,
                                Provider ,
                                ExpDate ,
                                [Type] ,
                                CCNumberMaster
                        FROM    dbo.TravelCreditCard
                        WHERE CreditCardID = " & QVal(CreditCardID) & " "
            Dim dt As New DataTable
            dt = GetDataTable(strQuery)
            If dt.Rows.Count > 0 Then
                CreditCardID = If(IsDBNull(dt.Rows(0).Item("CreditCardID")), "", Trim(dt.Rows(0).Item("CreditCardID").ToString()))
                CreditCardNumber = If(IsDBNull(dt.Rows(0).Item("CreditCardNumber")), "", Trim(dt.Rows(0).Item("CreditCardNumber").ToString()))
                AccountName = If(IsDBNull(dt.Rows(0).Item("AccountName")), "", Trim(dt.Rows(0).Item("AccountName").ToString()))
                BankName = If(IsDBNull(dt.Rows(0).Item("BankName")), "", Trim(dt.Rows(0).Item("BankName").ToString()))
                Provider = If(IsDBNull(dt.Rows(0).Item("Provider")), "", Trim(dt.Rows(0).Item("Provider").ToString()))
                ExpDate = If(IsDBNull(dt.Rows(0).Item("ExpDate")), "", Convert.ToDateTime(dt.Rows(0).Item("ExpDate")))
                Type = If(IsDBNull(dt.Rows(0).Item("Type")), "", Trim(dt.Rows(0).Item("Type").ToString()))
                CCNumberMaster = If(IsDBNull(dt.Rows(0).Item("CCNumberMaster")), "", Trim(dt.Rows(0).Item("CCNumberMaster").ToString()))
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Sub DeleteData()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1
                    Try
                        strQuery = " DELETE  FROM dbo.TravelCreditCard
                                     WHERE   CreditCardID = " & QVal(CreditCardID) & " "
                        ExecQuery(strQuery)

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
            Throw ex
        End Try
    End Sub

    Public Sub InsertData()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        strQuery = " INSERT INTO dbo.TravelCreditCard " & vbCrLf &
                                    "         ( CreditCardID , " & vbCrLf &
                                    "           CreditCardNumber , " & vbCrLf &
                                    "           AccountName , " & vbCrLf &
                                    "           BankName , " & vbCrLf &
                                    "           Provider , " & vbCrLf &
                                    "           ExpDate , " & vbCrLf &
                                    "           Type , " & vbCrLf &
                                    "           CCNumberMaster , " & vbCrLf &
                                    "           CreatedBy , " & vbCrLf &
                                    "           CreatedDate , " & vbCrLf &
                                    "           UpdatedBy , " & vbCrLf &
                                    "           UpdatedDate " & vbCrLf &
                                    "         ) " & vbCrLf &
                                    " VALUES  ( " & QVal(CreditCardID) & " , " & vbCrLf &
                                    "           " & QVal(CreditCardNumber) & " , " & vbCrLf &
                                    "           " & QVal(AccountName) & " , " & vbCrLf &
                                    "           " & QVal(BankName) & " , " & vbCrLf &
                                    "           " & QVal(Provider) & " , " & vbCrLf &
                                    "           " & QVal(ExpDate) & " , " & vbCrLf &
                                    "           " & QVal(Type) & " , " & vbCrLf &
                                    "           " & QVal(CCNumberMaster) & " , " & vbCrLf &
                                    "           " & QVal(gh_Common.Username) & " , " & vbCrLf &
                                    "           GETDATE() , " & vbCrLf &
                                    "           " & QVal(gh_Common.Username) & " , " & vbCrLf &
                                    "           GETDATE()   " & vbCrLf &
                                    "         ) "
                        ExecQuery(strQuery)

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

    Public Sub UpdateData()
        Try
            Using Conn1 As New SqlClient.SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        strQuery = " UPDATE  dbo.TravelCreditCard " & vbCrLf &
                                    " SET     CreditCardNumber =  " & QVal(CreditCardNumber) & " , " & vbCrLf &
                                    "         AccountName =  " & QVal(AccountName) & " , " & vbCrLf &
                                    "         BankName =  " & QVal(BankName) & " , " & vbCrLf &
                                    "         Provider =  " & QVal(Provider) & " , " & vbCrLf &
                                    "         ExpDate =  " & QVal(ExpDate) & " , " & vbCrLf &
                                    "         Type =  " & QVal(Type) & " , " & vbCrLf &
                                    "         CCNumberMaster =  " & QVal(CCNumberMaster) & " , " & vbCrLf &
                                    "         UpdatedBy = " & QVal(gh_Common.Username) & " , " & vbCrLf &
                                    "         UpdatedDate = GETDATE() " & vbCrLf &
                                    " WHERE   CreditCardID = " & QVal(CreditCardID) & " "
                        ExecQuery(strQuery)

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

    Public Function GetCreditCardMaster(ByVal _CCNumber As String) As DataTable
        Try
            strQuery = "SELECT  CreditCardID ,
                                CreditCardNumber ,
                                AccountName ,
                                BankName
                        FROM    dbo.TravelCreditCard
                        WHERE   [Type] = 'M'
                                AND CreditCardNumber <> '" & _CCNumber & "'"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable(strQuery)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function CheckCCNumber(ByVal _CCNumber As String) As Boolean
        Try
            Dim result As Boolean = False
            strQuery = "SELECT  CreditCardNumber
                        FROM    dbo.TravelCreditCard
                        WHERE   CreditCardNumber = '" & _CCNumber & "'"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTable(strQuery)
            If dtTable.Rows.Count > 0 Then
                result = True
            End If
            Return result
        Catch ex As Exception
            Throw
        End Try
    End Function

End Class
