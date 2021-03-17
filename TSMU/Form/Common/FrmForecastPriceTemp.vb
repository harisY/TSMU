Imports DevExpress.XtraGrid

Public Class FrmForecastPriceTemp
    Dim Service As New TForecastPrice_TempService
    Dim Model As New TForecastPrice_TempModel
    Dim _Tag As TagModel
    Dim GridDtl As GridControl
    Dim ls_Error As String = ""
    Public isCancel As Boolean = False
    Dim isUpdate As Boolean = False
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal Code As Integer,
                   ByVal strCode2 As String,
                   ByRef lf_FormParent As Form,
                   ByVal li_GridRow As Integer,
                   ByRef _Grid As GridControl)
        ' this call is required by the windows form designer
        Me.New()

        fs_Code = Code.ToString
        fs_Code2 = strCode2
        bi_GridParentRow = li_GridRow

        GridDtl = _Grid
        FrmParent = lf_FormParent
        _Tag = New TagModel
        _Tag.PageIndex = lf_FormParent.Tag.PageIndex
        Tag = _Tag
    End Sub
    Private Sub FrmForecastPriceTemp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Proc_EnableButtons(False, True, False, False, False, False, False, False, False, False, False, False)
        InitialSetForm()
    End Sub
    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "0" Then
                Model = Service.GetDataById(fs_Code.AsInt)
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Close()
                    Exit Sub
                Else
                    isUpdate = True
                End If
                Text = "HARGA MANUAL"
            Else
                Text = "HARGA MANUAL"
            End If
            Call LoadTxtBox()
            FillComboBulan()
            'End If
            Call InputBeginState(Me)
            bb_IsUpdate = isUpdate
            bs_MainFormName = FrmParent.Name
        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub LoadTxtBox()
        Try
            If fs_Code <> "0" Then
                With Model
                    TxtTahun.Text = .Tahun
                    TxtBulan.EditValue = .Bulan
                    TxtCustomer.Text = .CustID
                    TxtPartNo.Text = .PartNo
                    TxtPartName.Text = .PartName
                    TxtSite.Text = .Site
                    TxtHarga.Text = .Harga
                    TxtInventory.Text = .InvtID
                End With
            Else
                TxtTahun.Text = Date.Today.Year
                TxtBulan.EditValue = ""
                TxtCustomer.Text = ""
                TxtPartNo.Text = ""
                TxtPartName.Text = ""
                TxtSite.Text = "TNG-U"
                TxtHarga.Text = "0"
                TxtInventory.Text = ""
                TxtTahun.Focus()
            End If
        Catch ex As Exception
            Throw ex
        End Try
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
                .Id = fs_Code.AsInt
                .Tahun = TxtTahun.Text.AsString
                .Bulan = TxtBulan.EditValue
                .CustID = TxtCustomer.Text.AsString
                .InvtID = TxtInventory.Text.AsString
                .PartNo = TxtPartNo.Text.AsString
                .PartName = TxtPartName.Text.AsString
                .Site = TxtSite.Text.AsString
                .Harga = TxtHarga.Text.AsFloat
            End With
            If fs_Code = 0 Then

                Service.InsertData(Model)
                ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
            Else
                Service.UpdatetData(Model)
                ShowMessage(GetMessage(MessageEnum.UpdateBerhasil), MessageTypeEnum.NormalMessage)

            End If
            GridDtl.DataSource = Service.GetDataGrid()
            Close()

        Catch ex As Exception
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

End Class
