
Imports System.Globalization
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid
Public Class Frm_GetPRDetail

    Dim IsNew As Boolean
    Dim ID As String
    Dim Grid1 As GridControl
    Dim DtTabale As DataTable
    Dim DtGridBarang As DataTable
    Dim fc_Class As New Cls_PO
    Dim dt As DataTable
    Dim dtcekharga As DataTable
    Dim harga As Double

    Private Sub Frm_GetPRDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Call CreateTableBarang()
        Call LoadGrid(ID)

    End Sub

    Private Sub LoadGrid(PRNo As String)

        Try

            Cursor.Current = Cursors.WaitCursor

            'Dim DtGridNPWO As New DataTable
            dt = fc_Class.Get_PRDetail(PRNo)



            Grid.DataSource = dt
            Cursor.Current = Cursors.Default
            Call List_GridPurchaseFor()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try

    End Sub

    Public Sub New(ByVal _ID As String,
                 ByRef _dt As DataTable,
                 ByRef _grid As GridControl,
                 ByVal _IsNew As Boolean)

        ' This call is required by the designer.
        InitializeComponent()

        ID = _ID
        Grid1 = _grid
        DtTabale = _dt
        IsNew = _IsNew


    End Sub

    Private Sub CreateTableBarang()

        DtGridBarang = New DataTable
        DtGridBarang.Columns.AddRange(New DataColumn(26) {New DataColumn("PR No", GetType(String)),
                                                            New DataColumn("Check", GetType(Boolean)),
                                                            New DataColumn("PR Line No", GetType(String)),
                                                            New DataColumn("Alternate ID", GetType(String)),
                                                            New DataColumn("No", GetType(Double)),
                                                            New DataColumn("XSeq", GetType(Double)),
                                                            New DataColumn("Inventory ID", GetType(String)),
                                                            New DataColumn("Description", GetType(String)),
                                                            New DataColumn("Quantity", GetType(Double)),
                                                            New DataColumn("OUM", GetType(String)),
                                                            New DataColumn("Unit Cost", GetType(Double)),
                                                            New DataColumn("Extended Cost", GetType(Double)),
                                                            New DataColumn("Status Price", GetType(String)),
                                                            New DataColumn("Unit Weight", GetType(Double)),
                                                            New DataColumn("Site ID", GetType(String)),
                                                            New DataColumn("Extended Weight", GetType(Double)),
                                                            New DataColumn("Purchase For", GetType(String)),
                                                            New DataColumn("Unit Volume", GetType(Double)),
                                                            New DataColumn("Extended Volume", GetType(String)),
                                                            New DataColumn("Required", GetType(Date)),
                                                            New DataColumn("Promised", GetType(Date)),
                                                            New DataColumn("Account", GetType(String)),
                                                            New DataColumn("SubAccount", GetType(String)),
                                                            New DataColumn("Balance", GetType(Double)),
                                                            New DataColumn("PoQty", GetType(Double)),
                                                            New DataColumn("PRQty", GetType(Double)),
                                                            New DataColumn("Lead Time", GetType(Boolean))})
        Grid.DataSource = DtGridBarang
        GridView1.OptionsView.ShowAutoFilterRow = False
    End Sub


    Private Sub List_GridPurchaseFor()

        Dim cList As New ContactList()
        cList.Add(New Contact("DL", "Description Line"))
        cList.Add(New Contact("FR", "Freight Charges"))
        cList.Add(New Contact("GI", "Goods for Inventory"))
        cList.Add(New Contact("GS", "Goods for Sales Order"))
        cList.Add(New Contact("MI", "Misc Charges"))
        cList.Add(New Contact("GN", "Non-Inventory Goods"))
        cList.Add(New Contact("SE", "Services for Expense"))



        RepoPurchaseFor.DataSource = cList
        RepoPurchaseFor.DisplayMember = "Name"
        RepoPurchaseFor.ValueMember = "Id"
        ' Add columns.
        ' The ID column is populated 
        ' via the GetNotInListValue event (not listed in the example).
        RepoPurchaseFor.Columns.Add(New LookUpColumnInfo("Id", "ID", 20))
        RepoPurchaseFor.Columns.Add(New LookUpColumnInfo("Name", "Name", 80))
        'enable text editing
        RepoPurchaseFor.TextEditStyle = TextEditStyles.Standard
    End Sub

    Public Class Contact
        'INSTANT VB NOTE: The variable name was renamed since Visual Basic does not allow variables and other class members to have the same name:
        Private name_Renamed As String
        'INSTANT VB NOTE: The variable id was renamed since Visual Basic does not allow variables and other class members to have the same name:
        Private id_Renamed As String

        Public Sub New(ByVal _id As String, ByVal _name As String)
            id_Renamed = _id
            name_Renamed = _name
        End Sub

        Public Property Name() As String
            Get
                Return name_Renamed
            End Get
            Set(ByVal value As String)
                name_Renamed = value
            End Set
        End Property

        Public Property Id() As String
            Get
                Return id_Renamed
            End Get
            Set(ByVal value As String)
                id_Renamed = value
            End Set
        End Property
    End Class

    Public Class ContactList
        Inherits System.Collections.CollectionBase

        Default Public Property Item(ByVal index As Integer) As Contact
            Get
                Return DirectCast(List(index), Contact)
            End Get
            Set(ByVal value As Contact)
                List(index) = value
            End Set
        End Property

        Public Function Add(ByVal value As Contact) As Integer
            Return List.Add(value)
        End Function
        '...
    End Class

    Private Sub BAdd_Click(sender As Object, e As EventArgs) Handles BAdd.Click

        Dim SisaStok As Integer = 0
        Dim GV_PRNo As String = ""
        Dim GV_PRLine As String = ""
        Dim GV_PRInvtID As String = ""
        Dim GV_PRQty As Integer = 0
        Dim GV_POQty As Integer = 0

        Dim DT_PRNo As String = ""
        Dim DT_PRLine As String = ""
        Dim DT_PRInvtID As String = ""
        Dim DT_QtyPO As Integer = 0



        DtTabale.AcceptChanges()
        Dim chkSelect As Boolean
        Dim MyNewRow As DataRow
        MyNewRow = DtTabale.NewRow
        Dim a As Integer
        Dim b As Integer

        For i As Integer = 0 To GridView1.RowCount - 1

            chkSelect = Convert.ToBoolean(GridView1.GetRowCellValue(i, GridView1.Columns("Check")))

            If chkSelect = True Then

                dtcekharga = New DataTable
                dtcekharga = fc_Class.Get_CekHarga(GridView1.GetRowCellValue(i, GridView1.Columns("Inventory ID")), 1)

                If dtcekharga.Rows(0).Item("Tipe") = "F" Then

                    If dtcekharga.Rows(0).Item("LastCost") > 0 Then
                        harga = dtcekharga.Rows(0).Item("LastCost")
                    Else
                        harga = GridView1.GetRowCellValue(i, GridView1.Columns("Unit Cost"))
                    End If
                Else
                    dtcekharga = New DataTable
                    dtcekharga = fc_Class.Get_CekHarga(GridView1.GetRowCellValue(i, GridView1.Columns("Inventory ID")), 2)

                    If dtcekharga.Rows.Count > 0 Then
                        If dtcekharga.Rows(0).Item("UnitCost") > 0 Then
                            harga = dtcekharga.Rows(0).Item("UnitCost")
                        Else
                            harga = GridView1.GetRowCellValue(i, GridView1.Columns("Unit Cost"))
                        End If
                    Else
                        harga = GridView1.GetRowCellValue(i, GridView1.Columns("Unit Cost"))
                    End If
                End If


                b = 1
                Dim currentValue As Integer, maxValue As Integer
                maxValue = 0
                If DtTabale.Rows.Count > 0 Then

                    For c As Integer = 0 To DtTabale.Rows.Count - 1
                        currentValue = IIf(DtTabale.Rows(c).Item("XSeq") Is DBNull.Value, 0, DtTabale.Rows(c).Item("XSeq"))
                        If currentValue > maxValue Then maxValue = currentValue
                    Next

                End If
                b = b + maxValue

                GV_PRQty = GridView1.GetRowCellValue(i, GridView1.Columns("PRQty"))
                GV_POQty = GridView1.GetRowCellValue(i, GridView1.Columns("PoQty"))

                GV_PRNo = GridView1.GetRowCellValue(i, GridView1.Columns("PR No"))
                GV_PRLine = GridView1.GetRowCellValue(i, GridView1.Columns("PR Line No"))
                GV_PRInvtID = GridView1.GetRowCellValue(i, GridView1.Columns("Inventory ID"))


                If DtTabale.Rows.Count <= 0 Then
                    MyNewRow = DtTabale.NewRow
                    With MyNewRow
                        .Item("PR No") = GridView1.GetRowCellValue(i, GridView1.Columns("PR No")).ToString
                        .Item("PR Line No") = GridView1.GetRowCellValue(i, GridView1.Columns("PR Line No")).ToString
                        '.Item("Alternate ID") = GridView1.GetRowCellValue(i, GridView1.Columns("Alternate ID")).ToString
                        '.Item("No") = GridView1.GetRowCellValue(i, GridView1.Columns("PR No")).ToString
                        .Item("XSeq") = b
                        .Item("Inventory ID") = GridView1.GetRowCellValue(i, GridView1.Columns("Inventory ID")).ToString
                        .Item("Description") = GridView1.GetRowCellValue(i, GridView1.Columns("Description")).ToString
                        .Item("Quantity") = GridView1.GetRowCellValue(i, GridView1.Columns("Quantity")).ToString
                        .Item("OUM") = GridView1.GetRowCellValue(i, GridView1.Columns("OUM")).ToString
                        .Item("Unit Cost") = harga
                        .Item("Extended Cost") = GridView1.GetRowCellValue(i, GridView1.Columns("Quantity")) * harga
                        '.Item("Status Price") = GridView1.GetRowCellValue(i, GridView1.Columns("PR No")).ToString
                        '.Item("Unit Weight") = GridView1.GetRowCellValue(i, GridView1.Columns("PR No")).ToString
                        .Item("Site ID") = ""
                        '.Item("Extended Weight") = GridView1.GetRowCellValue(i, GridView1.Columns("PR No")).ToString
                        .Item("Purchase For") = GridView1.GetRowCellValue(i, GridView1.Columns("Purchase For")).ToString
                        '.Item("Unit Volume") = GridView1.GetRowCellValue(i, GridView1.Columns("PR No")).ToString
                        '.Item("Extended Volume") = GridView1.GetRowCellValue(i, GridView1.Columns("PR No")).ToString
                        .Item("Required") = GridView1.GetRowCellValue(i, GridView1.Columns("Required")).ToString
                        .Item("Promised") = GridView1.GetRowCellValue(i, GridView1.Columns("Promised")).ToString
                        .Item("Account") = GridView1.GetRowCellValue(i, GridView1.Columns("Account")).ToString
                        .Item("SubAccount") = GridView1.GetRowCellValue(i, GridView1.Columns("SubAccount")).ToString
                        .Item("Rcpt Qty Min%") = 0
                        .Item("Rcpt Qty Max%") = 100
                        .Item("Receipt Action") = "E"
                        .Item("Balance") = GridView1.GetRowCellValue(i, GridView1.Columns("Balance")).ToString
                        .Item("PoQty") = GridView1.GetRowCellValue(i, GridView1.Columns("PoQty")).ToString
                        .Item("PRQty") = GridView1.GetRowCellValue(i, GridView1.Columns("PRQty")).ToString
                        .Item("Receipt Status") = "N"
                        .Item("Voucher Status") = "N"
                        .Item("Lead Time") = 0
                    End With
                    DtTabale.Rows.Add(MyNewRow)
                    DtTabale.AcceptChanges()

                Else
                    SisaStok = 0
                    DT_QtyPO = 0

                    For j As Integer = 0 To DtTabale.Rows.Count - 1
                        DT_PRNo = DtTabale.Rows(j).Item("PR No")
                        DT_PRLine = DtTabale.Rows(j).Item("PR Line No")
                        DT_PRInvtID = DtTabale.Rows(j).Item("Inventory ID")

                        If DT_PRNo = GV_PRNo And DT_PRLine = GV_PRLine And DT_PRInvtID = GV_PRInvtID Then
                            DT_QtyPO = DT_QtyPO + DtTabale.Rows(j).Item("Quantity")
                        End If
                    Next

                    SisaStok = GV_PRQty - (GV_POQty + DT_QtyPO)


                    If SisaStok > 0 Then
                        MyNewRow = DtTabale.NewRow
                        With MyNewRow
                            .Item("PR No") = GridView1.GetRowCellValue(i, GridView1.Columns("PR No")).ToString
                            .Item("PR Line No") = GridView1.GetRowCellValue(i, GridView1.Columns("PR Line No")).ToString
                            '.Item("Alternate ID") = GridView1.GetRowCellValue(i, GridView1.Columns("Alternate ID")).ToString
                            '.Item("No") = GridView1.GetRowCellValue(i, GridView1.Columns("PR No")).ToString
                            .Item("XSeq") = b
                            .Item("Inventory ID") = GridView1.GetRowCellValue(i, GridView1.Columns("Inventory ID")).ToString
                            .Item("Description") = GridView1.GetRowCellValue(i, GridView1.Columns("Description")).ToString
                            .Item("Quantity") = GridView1.GetRowCellValue(i, GridView1.Columns("Quantity")) - DT_QtyPO
                            .Item("OUM") = GridView1.GetRowCellValue(i, GridView1.Columns("OUM")).ToString
                            .Item("Unit Cost") = harga
                            .Item("Extended Cost") = GridView1.GetRowCellValue(i, GridView1.Columns("Quantity")) * harga
                            '.Item("Status Price") = GridView1.GetRowCellValue(i, GridView1.Columns("PR No")).ToString
                            '.Item("Unit Weight") = GridView1.GetRowCellValue(i, GridView1.Columns("PR No")).ToString
                            .Item("Site ID") = ""
                            '.Item("Extended Weight") = GridView1.GetRowCellValue(i, GridView1.Columns("PR No")).ToString
                            .Item("Purchase For") = GridView1.GetRowCellValue(i, GridView1.Columns("Purchase For")).ToString
                            '.Item("Unit Volume") = GridView1.GetRowCellValue(i, GridView1.Columns("PR No")).ToString
                            '.Item("Extended Volume") = GridView1.GetRowCellValue(i, GridView1.Columns("PR No")).ToString
                            .Item("Required") = GridView1.GetRowCellValue(i, GridView1.Columns("Required")).ToString
                            .Item("Promised") = GridView1.GetRowCellValue(i, GridView1.Columns("Promised")).ToString
                            .Item("Account") = GridView1.GetRowCellValue(i, GridView1.Columns("Account")).ToString
                            .Item("SubAccount") = GridView1.GetRowCellValue(i, GridView1.Columns("SubAccount")).ToString
                            .Item("Rcpt Qty Min%") = 0
                            .Item("Rcpt Qty Max%") = 100
                            .Item("Receipt Action") = "E"
                            .Item("Balance") = GridView1.GetRowCellValue(i, GridView1.Columns("Balance")).ToString
                            .Item("PoQty") = GridView1.GetRowCellValue(i, GridView1.Columns("PoQty")).ToString
                            .Item("PRQty") = GridView1.GetRowCellValue(i, GridView1.Columns("PRQty")).ToString
                            .Item("Receipt Status") = "N"
                            .Item("Voucher Status") = "N"
                            .Item("Lead Time") = 0

                        End With
                        DtTabale.Rows.Add(MyNewRow)
                        DtTabale.AcceptChanges()
                    End If

                End If




            End If
        Next
        Me.Close()
    End Sub
End Class