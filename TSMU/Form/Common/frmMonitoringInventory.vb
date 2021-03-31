﻿Imports DevExpress.XtraSplashScreen

Public Class frmMonitoringInventory
    Dim dtGrid As DataTable
    Dim Service As New SolomonService

    Private Sub frmMonitoringInventory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bb_SetDisplayChangeConfirmation = False
        Call Proc_EnableButtons(False, False, False, True, True, False, False, False, False, False, False, True)
    End Sub

    Private Sub LoadGrid(FromDate As Date, ToDate As Date)
        Try
            SplashScreenManager.ShowForm(GetType(FrmWait))
            dtGrid = New DataTable
            dtGrid = Service.GetDataInventory(FromDate, ToDate)
            Grid.DataSource = dtGrid

            With GridView1
                .BestFitColumns()
            End With
            If GridView1.RowCount > 0 Then
                GridCellFormat(GridView1)
            End If
            SplashScreenManager.CloseForm()
        Catch ex As Exception
            SplashScreenManager.CloseForm()
            Call ShowMessage(ex.Message, MessageTypeEnum.ErrorMessage)
            WriteToErrorLog(ex.Message, gh_Common.Username, ex.StackTrace)
        End Try
    End Sub

    Public Overrides Sub Proc_Refresh()
        LoadGrid(Date.Today, Date.Today)
    End Sub

    Public Overrides Sub Proc_Excel()
        If GridView1.RowCount > 0 Then
            Dim save As New SaveFileDialog With {
                .Filter = "Excel File|*.xlsx",
                .Title = "Save an Excel File"
            }
            If save.ShowDialog = DialogResult.OK Then
                _Grid.ExportToXlsx(save.FileName)
            End If
        Else
            ShowMessage("Data Kosong !", MessageTypeEnum.ErrorMessage)
        End If
    End Sub

    Private Sub frmMonitoringInventory_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        LoadGrid(Date.Today, Date.Today)
    End Sub

    Public Overrides Sub Proc_Search()
        Dim Frm As New frmSearch
        Frm.StartPosition = FormStartPosition.CenterScreen
        Frm.ShowDialog()
        LoadGrid(Frm.TglDari, Frm.TglSampai)
    End Sub

End Class