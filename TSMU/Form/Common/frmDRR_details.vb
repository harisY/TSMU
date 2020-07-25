Imports System.IO
Imports DevExpress.XtraBars.Ribbon
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraGrid.Views.Base
Imports DevExpress.XtraGrid.Views.Grid

Public Class frmDRR_details
    Public IsClosed As Boolean = False
    Public isCancel As Boolean = False
    Public rs_ReturnCode As String = ""
    Dim isUpdate As Boolean = False
    Dim ls_Error As String = ""
    Dim GridDtl As GridControl
    Dim dtGrid As New DataTable
    Dim id As Globalization.CultureInfo
    Dim _Tag As TagModel
    Dim _service As DRRService
    Dim ObjHeader As DRRModel
    Dim ObjDetail As DRRDetail
    Private dragDropHelper As DragDropHelper
    Dim IsTrue As Boolean

    Dim CmbLevel As RepositoryItemComboBox = New RepositoryItemComboBox()
    Dim LookPartName As RepositoryItemLookUpEdit = New RepositoryItemLookUpEdit()
    Dim CmnProses As RepositoryItemComboBox = New RepositoryItemComboBox()
    Dim TxtQty As RepositoryItemSpinEdit = New RepositoryItemSpinEdit()
    Dim TxtCavity As RepositoryItemTextEdit = New RepositoryItemTextEdit()
    Dim TxtTonase As RepositoryItemSpinEdit = New RepositoryItemSpinEdit()
    Dim _path As String = "\\10.10.1.12\e$\BoM\DRR Sketch\"
    Dim images As New List(Of String)
    Private Initializing As Boolean = False
    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub
    Public Sub New(ByVal strCode As String,
                   ByVal strCode2 As String,
                   ByRef lf_FormParent As Form,
                   ByVal li_GridRow As Integer,
                   ByRef _Grid As GridControl)
        ' this call is required by the windows form designer
        Me.New()
        If strCode <> "" Then
            fs_Code = strCode
            fs_Code2 = strCode2
            bi_GridParentRow = li_GridRow
        End If
        GridDtl = _Grid
        FrmParent = lf_FormParent
        _Tag = New TagModel
        _Tag.PageIndex = lf_FormParent.Tag.PageIndex
        Tag = _Tag
        dragDropHelper = New DragDropHelper(GalleryControl1)
        dragDropHelper.EnableDragDrop()
        IsTrue = True
        Initializing = True
    End Sub

    Private Sub frmDRR_details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call Proc_EnableButtons(False, True, False, True, False, False, False, False, False, False, False)
        Call InitialSetForm()
    End Sub

    Public Overrides Sub InitialSetForm()
        Try
            If fs_Code <> "0" Then
                _service = New DRRService
                ObjHeader = New DRRModel
                ObjHeader = _service.GetById(Convert.ToInt32(fs_Code))
                images = Nothing
                'LoadDetail(True)
                If ls_Error <> "" Then
                    Call ShowMessage(ls_Error, MessageTypeEnum.ErrorMessage)
                    isCancel = True
                    Hide()
                    Exit Sub
                Else
                    isUpdate = True
                End If
            End If
            Text = "DRR DETAIL"
            'PopulateCustomer()
            PopulateNPP()
            LoadTxtBox()
            LoadDetail()
            SetEditColumnGrid()
            'End If
            InputBeginState(Me)
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

                With ObjHeader
                    TxtNoNpp.Text = .No_NPP
                    TxtCustomer.Text = .Customer
                    TxtProject.Text = .Project
                    TxtMaspro.EditValue = .DueDateMaspro
                    TxtDate.EditValue = .Tanggal
                    TxtTime.EditValue = .Time
                    TxtPlace.Text = .Place
                    TxtNoDokumen.Text = .NoDokumen
                    TxtForecast.Text = .ForecastOrder
                    images = New List(Of String)({ .Gambar1, .Gambar2, .Gambar3, .Gambar4, .Gambar5})

                    GenerateImageGallery()
                    TxtNoNpp.Properties.ReadOnly = True
                End With
            Else
                TxtNoNpp.Text = ""
                TxtCustomer.Text = ""
                TxtProject.Text = ""
                TxtNoDokumen.Text = ""
                TxtMaspro.EditValue = Date.Today
                TxtDate.EditValue = Date.Today
                TxtTime.EditValue = Date.Now
                TxtPlace.Text = ""
                TxtForecast.Text = ""
            End If

        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub GenerateImageGallery()

        For Each gambar In images
            Dim pathParts = gambar.Split("_"c)
            Dim fileName = pathParts(pathParts.Count() - 1).Split("."c)
            Dim _index = pathParts(pathParts.Count() - 1).Split(","c)
            If fileName(0).ToString = "" Then
                Exit For
            End If
            If Directory.Exists(_path) Then
                Dim thumbnail As Image = Image.FromFile(Path.Combine(_path, pathParts(0) & "_" & _index(0)))
                GalleryControl1.Gallery.Groups(0).Items.Add(New GalleryItem(thumbnail, thumbnail, _index(0), "", CInt(_index(1)), CInt(_index(1)), Nothing, ""))
            End If
        Next
    End Sub
    Private Sub LoadDetail()
        Try
            Dim dt As New DataTable
            _service = New DRRService
            Grid.DataSource = Nothing
            dt = _service.DetailGetById(CInt(fs_Code))

            Grid.DataSource = dt
            With GridView1
                .Columns(0).Visible = False
                .Columns(1).Visible = False
                .BestFitColumns()
                For Each col As GridColumn In .Columns
                    If col.Name.ToLower = "colpartno" OrElse col.Name.ToLower = "colseq" Then
                        col.OptionsColumn.AllowEdit = False
                    Else
                        col.OptionsColumn.AllowEdit = True
                    End If
                Next
            End With

            If IsTrue Then
                GridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom
            End If
            GridView1.OptionsView.ColumnAutoWidth = True
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Private Sub PopulateNPP()
        Dim dtNpp As New DataTable
        _service = New DRRService
        dtNpp = _service.GetNPP
        TxtNoNpp.Properties.DataSource = Nothing
        TxtNoNpp.Properties.DataSource = dtNpp
        TxtNoNpp.Properties.ValueMember = "No_NPP"
        TxtNoNpp.Properties.DisplayMember = "No_NPP"
        TxtNoNpp.Properties.PopulateColumns()
    End Sub

    Private Sub SetEditColumnGrid()
        Try

            AddHandler CmbLevel.EditValueChanged, AddressOf OnEditValueChanged
            AddHandler LookPartName.EditValueChanged, AddressOf OnEditValueChanged
            AddHandler CmnProses.EditValueChanged, AddressOf OnEditValueChanged
            'AddHandler TxtQty.EditValueChanged, AddressOf OnEditValueChanged
            'AddHandler TxtCavity.EditValueChanged, AddressOf OnEditValueChanged
            'AddHandler TxtTonase.EditValueChanged, AddressOf OnEditValueChanged

            _service = New DRRService

            Dim dtPart As New DataTable
            dtPart = _service.GetPartName(TxtNoNpp.EditValue)
            LookPartName.NullText = "Pilih Part"
            LookPartName.PopupWidth = 500
            LookPartName.DataSource = Nothing
            LookPartName.DataSource = dtPart
            LookPartName.ValueMember = "PartName"
            LookPartName.DisplayMember = "PartName"
            LookPartName.PopulateColumns()


            CmbLevel.Items.Clear()
            CmbLevel.Items.AddRange(New String() {"1", "2", "3", "4"})
            CmnProses.Items.Clear()
            CmnProses.Items.AddRange(New String() {"INJ", "PNT"})


            With GridView1
                .Columns("Level").ColumnEdit = CmbLevel
                .Columns("PartName").ColumnEdit = LookPartName
                '.Columns("Qty").ColumnEdit = TxtQty
                '.Columns("Tonage").ColumnEdit = TxtTonase
                .Columns("Proses").ColumnEdit = CmnProses
                '.Columns("Cavity").ColumnEdit = TxtCavity
            End With
            With Grid.RepositoryItems
                .Add(CmbLevel)
                .Add(LookPartName)
                '.Add(TxtQty)
                '.Add(TxtTonase)
                .Add(CmnProses)
                '.Add(TxtCavity)
            End With

            'AddHandler GridView1.CustomColumnDisplayText, AddressOf GridView1_CustomColumnDisplayText
            'AddHandler GridView1.ShowingEditor, AddressOf GridView1_ShowingEditor
            'AddHandler GridView1.RowCellStyle, AddressOf GridView1_RowCellStyle
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Private Sub SetGridValue(ByVal sender As Object)
        Try
            If GridView1.FocusedColumn.Name = "colPartName" Then
                Dim lookUpEdit As LookUpEdit = CType(sender, LookUpEdit)
                Dim Seq As String = lookUpEdit.GetColumnValue("Seq").ToString
                Dim PartNo As String = lookUpEdit.GetColumnValue("PartNo").ToString
                With GridView1
                    .SetFocusedRowCellValue("Seq", Seq)
                    .SetFocusedRowCellValue("PartNo", PartNo)
                    .SetFocusedRowCellValue("Proses", "INJ")
                    .SetFocusedRowCellValue("Qty", 0)
                    .SetFocusedRowCellValue("Cavity", "")
                    .SetFocusedRowCellValue("Tonage", "0")
                    .SetFocusedRowCellValue("Material", "")
                    .SetFocusedRowCellValue("Part", 0)
                    .SetFocusedRowCellValue("Runner", 0)
                    .SetFocusedRowCellValue("Long", 0)
                    .SetFocusedRowCellValue("Width", 0)
                    .SetFocusedRowCellValue("Height", 0)
                    .SetFocusedRowCellValue("SurfaceTreatment", "")
                    .SetFocusedRowCellValue("C/T", 0)
                    .SetFocusedRowCellValue("Thickn", 0)
                    .SetFocusedRowCellValue("Reference", "")
                    .SetFocusedRowCellValue("Remark", "")
                End With
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub OnEditValueChanged(ByVal sender As Object, ByVal e As EventArgs)
        Try
            If GridView1.FocusedRowHandle = GridControl.NewItemRowHandle Then
                GridView1.CloseEditor()
                GridView1.UpdateCurrentRow()
                GridView1.ShowEditor()
                Dim edit As TextEdit = TryCast(sender, TextEdit)
                If edit Is Nothing Then Return
                edit.SelectionStart = 1
                edit.SelectionLength = 0

                SetGridValue(sender)
            Else
                GridView1.PostEditor()
                GridView1.UpdateCurrentRow()
                'GridView1.ShowEditor()
                SetGridValue(sender)

            End If
            GridCellFormat(GridView1)
        Catch ex As Exception
            Throw ex
        End Try

    End Sub

    Private Sub ComboBox_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs)

        Try

            'GridView1.PostEditor()
            'GridView1.UpdateCurrentRow()
        Catch ex As Exception
            'MsgBox(ex.Message)
        End Try

    End Sub
    Public Overrides Sub Proc_Refresh()
        Initializing = True
        GalleryControl1.Gallery.Groups(0).Items.Clear()
        Call LoadTxtBox()
        LoadDetail()
        Initializing = False
    End Sub
    Public Overrides Function ValidateSave() As Boolean
        Dim lb_Validated As Boolean = False
        Try
            If DxValidationProvider1.Validate Then
                lb_Validated = True
            Else
                Err.Raise(ErrNumber, , "Data yang anda input tidak valid, silahkan cek inputan anda !")
            End If

            If lb_Validated Then
                ObjHeader = New DRRModel With {
                    .IdDRR = CInt(fs_Code),
                    .No_NPP = TxtNoNpp.EditValue,
                    .Customer = TxtCustomer.Text,
                    .Project = TxtProject.Text,
                    .ForecastOrder = TxtForecast.Text,
                    .DueDateMaspro = TxtMaspro.EditValue,
                    .Tanggal = TxtDate.EditValue,
                    .Time = TimeSpan.Parse(TxtTime.Text),
                    .Place = TxtPlace.Text,
                    .NoDokumen = TxtNoDokumen.Text
                    }
                Dim _File As String = String.Empty
                Dim _Index As Integer = -1
                'For i As Integer = -1 To GalleryControl1.Gallery.Groups(0).Items.Count - 1

                'Next
                For Each item As GalleryItem In GalleryControl1.Gallery.Groups(0).Items
                    _File = Replace(TxtNoNpp.Text, "/", " ") & "_" & Replace(item.Caption, ".png", "") & ".png"
                    With ObjHeader
                        If _Index = -1 Then
                            .Gambar1 = _File & "," & CStr(_Index)
                        ElseIf _Index = 0 Then
                            .Gambar2 = _File & "," & CStr(_Index)
                        ElseIf _Index = 1 Then
                            .Gambar3 = _File & "," & CStr(_Index)
                        ElseIf _Index = 2 Then
                            .Gambar4 = _File & "," & CStr(_Index)
                        ElseIf _Index = 3 Then
                            .Gambar5 = _File & "," & CStr(_Index)
                        End If
                    End With
                    _Index += 1
                Next item
            End If
        Catch ex As Exception
            lb_Validated = False
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
        Return lb_Validated
    End Function

    Public Overrides Sub Proc_SaveData()
        Try
            _service = New DRRService
            _service.DetailModel.Clear()
            For i As Integer = 0 To GridView1.RowCount - 2
                If Not String.IsNullOrEmpty(GridView1.GetRowCellValue(i, "Seq").ToString()) Then
                    Dim ObjDetails As New DRRDetail
                    With ObjDetails
                        .Npp_Seq = Integer.Parse(GridView1.GetRowCellValue(i, "Seq").ToString())
                        .Level = Integer.Parse(GridView1.GetRowCellValue(i, "Level").ToString().TrimEnd)
                        .Part_Name = GridView1.GetRowCellValue(i, "PartName").ToString()
                        .Part_No = GridView1.GetRowCellValue(i, "PartNo").ToString()
                        .Proses = GridView1.GetRowCellValue(i, "Proses").ToString()
                        .Qty = Integer.Parse(GridView1.GetRowCellValue(i, "Qty").ToString())
                        .Cavity = GridView1.GetRowCellValue(i, "Cavity").ToString()
                        .Tonage = GridView1.GetRowCellValue(i, "Tonage").ToString()
                        .Material = GridView1.GetRowCellValue(i, "Material").ToString().TrimEnd
                        .Part = Double.Parse(GridView1.GetRowCellValue(i, "Part").ToString())
                        .Runner = Double.Parse(GridView1.GetRowCellValue(i, "Runner").ToString())
                        .Loong = Double.Parse(GridView1.GetRowCellValue(i, "Long").ToString())
                        .Width = Double.Parse(GridView1.GetRowCellValue(i, "Width").ToString())
                        .Height = Double.Parse(GridView1.GetRowCellValue(i, "Height").ToString())
                        .SurfaceTreatment = GridView1.GetRowCellValue(i, "SurfaceTreatment").ToString().TrimEnd
                        .CT = Double.Parse(GridView1.GetRowCellValue(i, "C/T").ToString())
                        .Thickn = Double.Parse(GridView1.GetRowCellValue(i, "Thickn").ToString())
                        .Reference = GridView1.GetRowCellValue(i, "Reference").ToString().TrimEnd
                        .Remark = GridView1.GetRowCellValue(i, "Remark").ToString().TrimEnd
                    End With
                    _service.DetailModel.Add(ObjDetails)
                End If
            Next
            If GalleryControl1.Gallery.Groups(0).Items.Count = 0 Then
                Throw New Exception("Belum ada Sketch DRR !")
            End If
            If _service.DetailModel.Count = 0 Then
                Throw New Exception("Silahkan isi detail DRR !")
            End If

            If Not isUpdate Then
                _service.Insert(ObjHeader)
                SaveDeleteImage()
                GridDtl.DataSource = _service.GetAll()

                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                Me.Hide()
            Else
                _service.Update(ObjHeader)
                SaveDeleteImage()

                GridDtl.DataSource = _service.GetAll()

                IsClosed = True
                Call ShowMessage(GetMessage(MessageEnum.SimpanBerhasil), MessageTypeEnum.NormalMessage)
                Me.Hide()
            End If
        Catch ex As Exception
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
            ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
        End Try
    End Sub

    Private Sub SaveDeleteImage()
        Try
            Dim files As String()
            Dim _File As String = String.Empty
            If Not Directory.Exists(_path) Then
                Directory.CreateDirectory(_path)
            End If
            files = Directory.GetFiles(_path, "*.png")
            For Each item As GalleryItem In GalleryControl1.Gallery.Groups(0).Items
                _File = Path.Combine(_path, Replace(TxtNoNpp.Text, "/", " ") & "_" & Replace(item.Caption, ".png", "") & ".png")
                If Not File.Exists(_File) Then
                    item.Image.Save(_File, Imaging.ImageFormat.Png)
                    'File.Delete(_File)
                End If
            Next item
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub TxtNoNpp_EditValueChanged(sender As Object, e As EventArgs) Handles TxtNoNpp.EditValueChanged
        If Initializing Then
            Exit Sub
        End If
        TxtCustomer.EditValue = TxtNoNpp.GetColumnValue("Customer").ToString
        TxtProject.Text = TxtNoNpp.GetColumnValue("Model_Name").ToString
        LoadDetail()
        SetEditColumnGrid()
        Initializing = False
    End Sub

    Private Sub GalleryControl1_DragEnter(sender As Object, e As DragEventArgs) Handles GalleryControl1.DragEnter
        Try
            If (e.Data.GetDataPresent(DataFormats.FileDrop)) Then
                e.Effect = DragDropEffects.Copy
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    'Private Sub GalleryControl1_Gallery_ItemRightClick(sender As Object, e As DevExpress.XtraBars.Ribbon.GalleryItemClickEventArgs) Handles GalleryControl1.Gallery.ItemRightClick

    '    Try
    '        Dim _file = Path.Combine(_path, Replace(TxtNoNpp.Text, "/", "_") & "_" & e.Item.Caption & ".png")
    '        If File.Exists(_file) Then
    '            File.Delete(_file)
    '        End If
    '        e.Item.Image.Save(_file, Imaging.ImageFormat.Png)
    '        MsgBox("Image Saved")
    '    Catch ex As Exception
    '        MsgBox(ex.Message)
    '    End Try

    'End Sub

    Private Sub frmDRR_details_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try

            If e.KeyCode = Keys.F1 Then

            Else
                If e.KeyCode = Keys.Delete Then
                    Dim item As GalleryItem = GalleryControl1.Gallery.GetCheckedItem()
                    If item IsNot Nothing Then GalleryControl1.Gallery.Groups(0).Items.Remove(item)
                End If
            End If
        Catch ex As Exception
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub
    Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
        Dim ignoreCancel As Boolean = False
        TxtNoNpp.DoValidate()
        TxtDate.DoValidate()
        TxtTime.DoValidate()
        TxtMaspro.DoValidate()
        TxtPlace.DoValidate()

        If DxValidationProvider1.GetInvalidControls().Contains(TxtNoNpp) _
            OrElse DxValidationProvider1.GetInvalidControls().Contains(TxtDate) _
            OrElse DxValidationProvider1.GetInvalidControls().Contains(TxtMaspro) _
            OrElse DxValidationProvider1.GetInvalidControls().Contains(TxtPlace) _
            OrElse DxValidationProvider1.GetInvalidControls().Contains(TxtTime) Then
            ignoreCancel = True
        Else
            ignoreCancel = True
        End If

        RemoveHandler CmbLevel.EditValueChanged, AddressOf OnEditValueChanged
        RemoveHandler LookPartName.EditValueChanged, AddressOf OnEditValueChanged
        RemoveHandler CmnProses.EditValueChanged, AddressOf OnEditValueChanged
        'RemoveHandler TxtQty.EditValueChanged, AddressOf OnEditValueChanged
        'RemoveHandler TxtCavity.EditValueChanged, AddressOf OnEditValueChanged
        'RemoveHandler TxtTonase.EditValueChanged, AddressOf OnEditValueChanged
        MyBase.OnFormClosing(e)
        e.Cancel = Not ignoreCancel

        dragDropHelper.DisableDragDrop()
        'GridDtl.DataSource = _service.GetAll()
    End Sub

    Private Sub frmDRR_details_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Initializing = False
    End Sub
End Class
