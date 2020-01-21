Public Class MizuhoModels
    Dim query As String = String.Empty
    Public Property ref_no_sup As String
    Public Property takagi_acct As String
    Public Property rek_pt As String
    Public Property payment_method As String
    Public Property curyid As String
    Public Property sp_amount As String
    Public Property trans_amount As String
    Public Property value_date As String
    Public Property bankname As String
    Public Property branch As String
    Public Property address As String
    Public Property address2 As String
    Public Property norek_supplier As String
    Public Property pt As String
    Public Property pt2 As String
    Public Property address_pt As String
    Public Property address_pt2 As String
    Public Property space_kosong As String
    Public Property bank_charges As String
    Public Property applicant_acct As String
    Public Property space_kosong2 As String
    Public Property other As String
    Public Property other1 As String
    Public Property other2 As String
    Public Property other3 As String
    Public Property field As String


    '' Public Property ObjMizuhoDetails() As New Collection(Of MizuhoModels)


    Public Sub InsertData()
        Try
            Using Conn1 As New SqlClient.SqlConnection(MainModul.GetConnStringSolomon)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    MainModul.gh_Trans = New InstanceVariables.TransactionHelper
                    MainModul.gh_Trans.Command.Connection = Conn1
                    MainModul.gh_Trans.Command.Transaction = Trans1
                    Try
                        ''DeleteMizuho()
                        InsertMizuho()

                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw
                    Finally
                        MainModul.gh_Trans = Nothing
                    End Try
                End Using

        End Using
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub InsertMizuho()

        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "INSERT INTO uploadmizuho_Compare (ref_no_sup,field,takagi_acct,rek_pt,payment_method,curyid,sp_amount,trans_amount,value_date,bankname,branch,address,address2,norek_supplier,pt,pt2,address_pt,address_pt2,space_kosong,bank_charges,applicant_acct,space_kosong2,other,other1,other2,other3) " & vbCrLf &
                                    "Values(" & QVal(Me.ref_no_sup) & ", " & vbCrLf &
                                    "       " & QVal(Me.field) & ", " & vbCrLf &
                                    "       " & QVal(Me.takagi_acct) & ", " & vbCrLf &
                                    "       " & QVal(Me.rek_pt) & ", " & vbCrLf &
                                    "       " & QVal(Me.payment_method) & ", " & vbCrLf &
                                    "       " & QVal(Me.curyid) & ", " & vbCrLf &
                                    "       " & QVal(Me.sp_amount) & ", " & vbCrLf &
                                    "       " & QVal(Me.trans_amount) & ", " & vbCrLf &
                                    "       " & QVal(Me.value_date) & ", " & vbCrLf &
                                    "       " & QVal(Me.bankname) & ", " & vbCrLf &
                                    "       " & QVal(Me.branch) & ", " & vbCrLf &
                                    "       " & QVal(Me.address) & ", " & vbCrLf &
                                    "       " & QVal(Me.address2) & ", " & vbCrLf &
                                    "       " & QVal(Me.norek_supplier) & ", " & vbCrLf &
                                    "       " & QVal(Me.pt) & ", " & vbCrLf &
                                    "       " & QVal(Me.pt2) & ", " & vbCrLf &
                                    "       " & QVal(Me.address_pt) & ", " & vbCrLf &
                                    "       " & QVal(Me.address_pt2) & ", " & vbCrLf &
                                    "       " & QVal(Me.space_kosong) & ", " & vbCrLf &
                                    "       " & QVal(Me.bank_charges) & ", " & vbCrLf &
                                    "       " & QVal(Me.applicant_acct) & ", " & vbCrLf &
                                    "       " & QVal(Me.space_kosong2) & ", " & vbCrLf &
                                    "       " & QVal(Me.other) & ", " & vbCrLf &
                                    "       " & QVal(Me.other1) & ", " & vbCrLf &
                                    "       " & QVal(Me.other2) & ", " & vbCrLf &
                                    "       " & QVal(Me.other3) & ")"
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub DeleteMizuho()
        Try
            Dim ls_SP As String = "delete from uploadmizuho_Compare"
            MainModul.ExecQuery_Solomon(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub


    Public Function GetDataGridNew() As DataTable

        Try
            query = ""

            Dim dt As DataTable = New DataTable
            dt = MainModul.GetDataTable_Solomon(query)
            Return dt
        Catch ex As Exception
            Throw

        End Try
    End Function


End Class
