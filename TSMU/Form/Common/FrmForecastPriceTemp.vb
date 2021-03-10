Public Class FrmForecastPriceTemp
    Dim Service As New TForecastPrice_TempService
    Dim Model As TForecastPrice_TempModel
    Private Sub FrmForecastPriceTemp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Proc_EnableButtons(False, True, False, False, False, False, False, False, False, False, False, False)
        FillComboBulan()
    End Sub
    Private Sub FillComboBulan()
        Dim items =
        {
            New With {Key .Text = "", Key .Value = 0},
            New With {Key .Text = "Januari", Key .Value = 1},
            New With {Key .Text = "Februari", Key .Value = 2},
            New With {Key .Text = "Maret", Key .Value = 3},
            New With {Key .Text = "April", Key .Value = 4},
            New With {Key .Text = "Mei", Key .Value = 5},
            New With {Key .Text = "Juni", Key .Value = 6},
            New With {Key .Text = "Juli", Key .Value = 7},
            New With {Key .Text = "Agustus", Key .Value = 8},
            New With {Key .Text = "September", Key .Value = 9},
            New With {Key .Text = "Oktober", Key .Value = 10},
            New With {Key .Text = "November", Key .Value = 11},
            New With {Key .Text = "Desember", Key .Value = 12}
        }
        TxtBulan.Properties.DataSource = Nothing
        TxtBulan.Properties.DataSource = items
        TxtBulan.Properties.DisplayMember = "Text"
        TxtBulan.Properties.ValueMember = "Value"
    End Sub

    Public Overrides Sub Proc_SaveData()
        Try
            If TxtTahun.Text = "" Then
                TxtTahun.Focus()
                Throw New Exception("Input Tahun")
            End If
            If TxtBulan.EditValue = 0 Then
                TxtBulan.Focus()
                Throw New Exception("Pilih Bulan")
            End If
            If TxtCustomer.Text = "" Then
                TxtCustomer.Focus()
                Throw New Exception("Input Customer ID")
            End If
            If TxtInventory.Text = "" Then
                TxtInventory.Focus()
                Throw New Exception("Input Inventory ID")
            End If
            If TxtPartNo.Text = "" Then
                TxtPartNo.Focus()
                Throw New Exception("Input Part No")
            End If
            If TxtPartName.Text = "" Then
                TxtPartName.Focus()
                Throw New Exception("Input Part Name")
            End If
            If TxtSite.Text = "" Then
                TxtSite.Focus()
                Throw New Exception("Pilih Site")
            End If
            If TxtHarga.Text = "" Then
                TxtHarga.Focus()
                Throw New Exception("Input Harga")
            End If

            Model = New TForecastPrice_TempModel
            With Model
                .Tahun = TxtTahun.Text.AsString
                .Bulan = TxtBulan.EditValue
                .CustID = TxtCustomer.Text.AsString
                .InvtID = TxtInventory.Text.AsString
                .PartNo = TxtPartNo.Text.AsString
                .PartName = TxtPartName.Text.AsString
                .Site = TxtSite.Text.AsString
                .Harga = TxtHarga.Text.AsFloat
            End With

            Service.InsertTemptData(Model)
            ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Close()

        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub TxtHarga_EditValueChanged(sender As Object, e As EventArgs) Handles TxtHarga.EditValueChanged
        'TxtHarga.Text = Format(TxtHarga.Text, gs_FormatDecimal)
    End Sub
End Class
