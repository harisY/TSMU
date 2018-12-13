Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraGrid.Views.Base

Public Class frm_lookup_pph
    Dim _FP As String
    Dim _Voucher As String
    Dim _invcNbr As String
    Dim _DPP As String
    Dim ObjFP As Cls_FP = New Cls_FP()
    Dim tes As Boolean = True
    Dim total_dpp As Double = 0
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(FP As String, Voucher As String, invcNbr As String, DPP As String)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        _FP = FP
        _Voucher = Voucher
        _invcNbr = invcNbr
        _DPP = DPP
    End Sub
    Private Sub frm_lookup_pph_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Initial()
    End Sub

    Private Sub loadGrid()
        Try

            Dim dtgrid As DataTable = New DataTable
            dtgrid = ObjFP.getalldataap_det()
            Grid.DataSource = dtgrid

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub loadGrid1()
        Try

            Dim dtgrid As DataTable = New DataTable
            dtgrid = ObjFP.getalldataap_det2()
            Grid.DataSource = dtgrid

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub Initial()
        Try
            ObjFP.Fp = _FP
            ObjFP.invcnbr = _invcNbr
            _TxtFP.Text = _FP
            _TxtVoucher.Text = _Voucher
            _TxtInvcNbr.Text = _invcNbr
            _TxtDPP.Text = _DPP
            _TxtCekInv.Text = ObjFP.cekinv
            _TxtCekFaktur.Text = ObjFP.cekfaktur
            _TxtTahun.Text = DateTime.Now.Year.ToString
            _TxtBulan.Text = DateTime.Now.Month.ToString
            If _TxtInvcNbr.Text = _TxtCekInv.Text Then
                loadGrid1()
            Else
                loadGrid()
            End If
            LoadPPh()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub LoadPPh()
        Try
            Dim dtgrid As DataTable = New DataTable
            dtgrid = ObjFP.pasal()
            _TxtPPh.Properties.DataSource = dtgrid
            _TxtPPh.Properties.ValueMember = "pasal"
            _TxtPPh.Properties.DisplayMember = "pasal"

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub LoadKetPPh()
        Try
            Dim dtgrid As DataTable = New DataTable
            ObjFP.pph = _TxtPPh.EditValue
            dtgrid = ObjFP.ketpasal()
            _TxtKetPPh.Properties.DataSource = dtgrid
            _TxtKetPPh.Properties.ValueMember = "ket_pph"
            _TxtKetPPh.Properties.DisplayMember = "tarif"
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub _TxtPPh_Validated(sender As Object, e As EventArgs) Handles _TxtPPh.Validated
        LoadKetPPh()
    End Sub

    Private Sub _TxtKetPPh_Validated(sender As Object, e As EventArgs) Handles _TxtKetPPh.Validated
        _TxtTarif.Text = _TxtKetPPh.Text
        If _TxtTarif.Text <> "" AndAlso _TxtDPP.Text <> "" Then
            _TxtNilaiPPh.Text = Format(Val(_TxtDPP.Text * _TxtTarif.Text / 100), "#,#.##")
        End If
    End Sub

    Private Sub RepositoryItemCheckEdit1_EditValueChanged(sender As Object, e As EventArgs) Handles RepositoryItemCheckEdit1.EditValueChanged
        Grid.FocusedView.PostEditor()
    End Sub

    Private Sub _TxtLokasi_Validated(sender As Object, e As EventArgs) Handles _TxtLokasi.Validated
        Try
            With ObjFP
                .tarif = _TxtTarif.Text
                .lokasi = _TxtLokasi.Text
                .voucno = _TxtVoucher.Text
                _TxtNoBuktiPot.Text = .autonoFP
                '_TxtNilaiPPh.Text = Format(Val(_TxtDPP.Text * _TxtTarif.Text / 100), "#,#.##")
            End With
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub GridView1_CellValueChanged(sender As Object, e As CellValueChangedEventArgs) Handles GridView1.CellValueChanged
        Try
            If e.Column.FieldName = "cek" Then
                If GridView1.GetRowCellValue(e.RowHandle, "cek") = True Then
                    total_dpp = total_dpp + CDbl(GridView1.GetRowCellValue(e.RowHandle, "Amount"))
                Else
                    total_dpp = total_dpp - CDbl(GridView1.GetRowCellValue(e.RowHandle, "Amount"))
                End If

                If total_dpp = 0 Then
                    _TxtDPP.Text = "0"
                    _TxtNilaiPPh.Text = "0"
                Else
                    _TxtDPP.Text = Format(total_dpp, "#,#.##")
                    _TxtNilaiPPh.Text = Format(Val(_TxtDPP.Text * _TxtTarif.Text / 100), "#,#.##")
                End If
                '_TxtDPP.Text = Format(Val(IIf(total_dpp = "", "0", total_dpp)), "#,#.##")

                'If _TxtNilaiPPh.Text = "" Or _TxtDPP.Text = "" Then
                '    _TxtNilaiPPh.Text = "0"
                'Else
                '    _TxtNilaiPPh.Text = Format(Val(_TxtDPP.Text * _TxtTarif.Text / 100), "#,#.##")
                'End If
            End If
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub

    ReadOnly Property PPHDetails As Double
        Get
            Return Convert.ToDouble(_TxtNilaiPPh.Text)
        End Get
    End Property
    ReadOnly Property NoBuktiPotong As String
        Get
            Return _TxtNoBuktiPot.Text
        End Get
    End Property
    Private Sub _TsbOk_Click(sender As Object, e As EventArgs) Handles _TsbOk.Click
        Try
            Me.Close()
        Catch ex As Exception
            XtraMessageBox.Show(ex.Message)
        End Try
    End Sub
End Class