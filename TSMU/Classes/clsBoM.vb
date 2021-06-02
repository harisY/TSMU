﻿Imports System.Collections.ObjectModel
Imports System.Data.SqlClient
Imports System.Globalization
Public Class clsBoM

    Private _bomid As String
    Public Property BoMID() As String
        Get
            Return _bomid
        End Get
        Set(ByVal value As String)
            _bomid = value
        End Set
    End Property
    Private _tgl As Date
    Public Property Tgl() As Date
        Get
            Return _tgl
        End Get
        Set(ByVal value As Date)
            _tgl = value
        End Set
    End Property

    Private _invtid As String
    Public Property InvtID() As String
        Get
            Return _invtid
        End Get
        Set(ByVal value As String)
            _invtid = value
        End Set
    End Property

    Private _desc As String
    Public Property Desc() As String
        Get
            Return _desc
        End Get
        Set(ByVal value As String)
            _desc = value
        End Set
    End Property

    Private _siteid As String
    Public Property SiteID() As String
        Get
            Return _siteid
        End Get
        Set(ByVal value As String)
            _siteid = value
        End Set
    End Property

    Private _runner As String
    Public Property Runner() As String
        Get
            Return _runner
        End Get
        Set(ByVal value As String)
            _runner = value
        End Set
    End Property

    Private _ct As String
    Public Property CycleTime() As String
        Get
            Return _ct
        End Get
        Set(ByVal value As String)
            _ct = value
        End Set
    End Property
    Private _mc As String
    Public Property MC() As String
        Get
            Return _mc
        End Get
        Set(ByVal value As String)
            _mc = value
        End Set
    End Property

    Public Property cavity() As String
    Public Property WC() As String
    Private _allowance As Integer
    Public Property Allowance() As Integer
        Get
            Return _allowance
        End Get
        Set(ByVal value As Integer)
            _allowance = value
        End Set
    End Property

    Private _mp As String
    Public Property MP() As String
        Get
            Return _mp
        End Get
        Set(ByVal value As String)
            _mp = value
        End Set
    End Property
    Private _status As String
    Public Property Status() As String
        Get
            Return _status
        End Get
        Set(ByVal value As String)
            _status = value
        End Set
    End Property
    Private _active As Integer
    Public Property Active() As Integer
        Get
            Return _active
        End Get
        Set(ByVal value As Integer)
            _active = value
        End Set
    End Property
    Public Property RefType() As String
    Public Property RefNo() As String
    Public Property Converted() As Boolean
    Public Property BoMHeaderCollection As New Collection(Of clsBoM)
    Public Property BoMTempCollection As New Collection(Of BoM_Temp)

    Public Function GetAllDataTable(ByVal ls_Filter As String) As DataTable
        Try
            Dim ls_SP As String =
                "SELECT [bomid] [BOM ID]
                    ,[tgl]  [TGL]
                    ,Status Jenis
                    ,[invtid] [Inventory ID]
                    ,[descr] [Description]
                    ,[siteid] [Site]
                    ,[runner] [Runner]
                    ,[ct] [CT]
                    ,[mc] [MC/Ton]
                    ,[cavity] [Cavity]
                    ,[wc] [WC]
                    ,[allowance] [Allow]
                    ,[mp] [MP]
                    ,Case Active
                        When 0 then 'Subcon'
                        When 1 then 'InHouse'
                        Else 'Discontinue'
                    END as [Status]
                    ,[updated_by] [Updated By]
                    ,[updated_date] [Updated Date]
                FROM [bomh]"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function GetAllData() As DataTable
        Try
            Dim ls_SP As String = "select bomid as [BoM ID],invtid as [Inventory ID], descr as Description, siteid as Site " &
                "from bomh order by bomid"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(ls_SP)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Sub getDataByID(ByVal ID As String)
        Try
            Dim query As String = "select * from bomh where bomid = '" & ID & "'"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me._bomid = Trim(.Item("bomid") & "")
                    Me._tgl = Trim(.Item("tgl") & "")
                    Me._invtid = Trim(.Item("invtid") & "")
                    Me._desc = Trim(.Item("descr") & "")
                    Me._siteid = Trim(.Item("siteid") & "")
                    Me._runner = Trim(.Item("runner") & "")
                    Me._ct = Trim(.Item("ct") & "")
                    Me._mc = Trim(.Item("mc") & "")
                    Me.cavity = Trim(.Item("cavity") & "")
                    Me.WC = Trim(.Item("wc") & "")
                    Me._allowance = Trim(.Item("allowance") & "")
                    Me._mp = Trim(.Item("mp") & "")
                    Me._status = Trim(.Item("status") & "")
                    Me._active = Trim(.Item("active") & "")
                    Me.RefType = Trim(.Item("RefTipe") & "")
                    Me.RefNo = Trim(.Item("RefNo") & "")
                End With
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Dim _rev As Integer = 0
    Public Function getRevisi(ByVal bomid As String) As Integer
        Try
            Dim query As String = "" & vbCrLf &
                                  "SELECT isnull(max(revisi),0) revisi " & vbCrLf &
                                  "FROM bom_header_history where bomid=" & QVal(bomid) & ""
            Dim dt As New DataTable
            dt = MainModul.GetDataTable(query)
            If dt.Rows.Count > 0 Then
                _rev = Convert.ToInt32(dt.Rows(0)(0))
            End If
        Catch ex As Exception
            Throw
        End Try
        Return _rev
    End Function
    Public Function getRoutingBoM(ByVal invtId As String, Optional BomId As String = "")
        Try
            Dim query As String = "select * from fn_GetMultiLevelBOM('" & invtId & "', " & QVal(BomId) & " ) " &
                "union " &
                "select '' as FinishedGood,'' as parentid,b.invtid,'1' as qty, '0' as Extendedqty, b.descr, b.stkunit, a.bomid from bomh a inner join Inventory b on a.invtid=b.InvtID where b.invtid = '" & invtId & "'"

            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function GetBomId(InvtId As String, Status As String) As String
        Dim Hasil As String = String.Empty
        Try
            Dim Query = "Select BomId From Bomh Where InvtId = @InvtId And Status = @Status"
            Dim Params As List(Of SqlParameter) = New List(Of SqlParameter) From {
                 New SqlParameter() With {.ParameterName = "InvtId", .Value = InvtId},
                 New SqlParameter() With {.ParameterName = "Status", .Value = Status}
                }
            Dim dt As New DataTable
            dt = GetDataTableByParam(Query, CommandType.Text, Params, GetConnString)
            If dt.Rows.Count > 0 Then
                Hasil = dt.Rows(0)(0).ToString
            End If
            Return Hasil
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Function getDetailBoM(ByVal BoMID As String) As DataTable
        Try
            'Dim query As String = "SELECT ltrim(rtrim(bom.invtid)) as [Inventory ID],bom.descr Description,CAST(bom.qty AS decimal(11,4)) as Qty,bom.unit Unit FROM bomh inner join bom on bomh.bomid=bom.bomid where bom.bomid = '" & BoMID & "'"
            'Dim query As String = "SELECT ltrim(rtrim(bom.invtid)) as [Inventory ID],bom.descr Description,bom.qty as Qty,bom.unit Unit FROM bomh inner join bom on bomh.bomid=bom.bomid where bom.bomid = '" & BoMID & "'"
            Dim query As String = "SELECT 
                                        ltrim(rtrim(bom.invtid)) as [Inventory ID],
                                        i.Descr Description,bom.qty as Qty,bom.unit Unit
                                    FROM bomh inner join 
                                        bom on bomh.bomid=bom.bomid inner join 
                                        TSC16Application.dbo.Inventory i on bom.invtid = i.InvtID 
                                    where bom.bomid = '" & BoMID & "'"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function getDetailBoMByinvtId(ByVal invtId As String) As DataTable
        Try


            'Dim query As String = "SELECT ltrim(rtrim(bom.invtid)) as [Inventory ID],bom.descr Description,CAST(bom.qty AS decimal(11,4)) as Qty,bom.unit Unit FROM bomh inner join bom on bomh.bomid=bom.bomid where bom.bomid = '" & BoMID & "'"
            Dim query As String = "SELECT ltrim(rtrim(bom.invtid)) as [Inventory ID],bom.descr Description,bom.qty as Qty,bom.unit Unit FROM bomh inner join bom on bomh.bomid=bom.bomid where bom.parentid = '" & invtId & "'"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Sub getDataByInvt(ByVal ID As String)
        Try
            Dim query As String = "select * from bomh where invtID = '" & ID & "'"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            If dtTable IsNot Nothing AndAlso dtTable.Rows.Count > 0 Then
                With dtTable.Rows(0)
                    Me._bomid = Trim(.Item("bomid") & "")
                    Me._tgl = Trim(.Item("tgl") & "")
                    Me._invtid = Trim(.Item("invtid") & "")
                    Me._desc = Trim(.Item("descr") & "")
                    Me._siteid = Trim(.Item("siteid") & "")
                    Me._runner = Trim(.Item("runner") & "")
                    Me._ct = Trim(.Item("ct") & "")
                    Me._mc = Trim(.Item("mc") & "")
                End With
            Else
                _bomid = ""
                _tgl = ""
                _invtid = ""
                _desc = ""
                _siteid = ""
                _runner = ""
                _ct = ""
                _mc = ""
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Function getDetailBoM_Part(ByVal invtid As String) As DataTable
        Try
            'Dim query As String = "SELECT ltrim(rtrim(bom.invtid)) as [Inventory ID],bom.descr Description,CAST(bom.qty AS decimal(11,2)) as Qty,bom.unit Unit FROM bomh inner join bom on bomh.bomid=bom.bomid where bom.parentid = '" & BoMID & "'"
            Dim query As String = "SELECT descr, qty, unit from bom where invtid = '" & invtid & "'"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function getDetailBoM_Part_n(ByVal invtid As String) As DataTable
        Try
            'Dim query As String = "SELECT ltrim(rtrim(bom.invtid)) as [Inventory ID],bom.descr Description,CAST(bom.qty AS decimal(11,2)) as Qty,bom.unit Unit FROM bomh inner join bom on bomh.bomid=bom.bomid where bom.parentid = '" & BoMID & "'"
            Dim query As String = "SELECT Invtid as [Invetory ID],descr as Description, qty Qty, unit Unit from bom where parentid = '" & invtid & "'"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function AutoNoBoMID() As DataTable
        Try
            Dim query As String = "select MAX(SUBSTRING(bomid,1,7))+1 AS bomid from bomh"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

    Public Function ProjectAutoNo() As String

        Try
            Dim query As String

            query = "declare  @seq varchar(6)
            set @seq= (select right('00000'+cast(right(rtrim(max(bomid)),6)+1 as varchar),6)
            from bomh
            where left(bomid,1) = 'P')
            print @seq
            select 'P' + '-' + coalesce(@seq, '000001') No"

            Dim dt As DataTable = New DataTable
            dt = GetDataTable(query)
            Return dt.Rows(0).Item(0).ToString

        Catch ex As Exception
            Throw

        End Try
    End Function
    Public Function RegularAutoNo() As String

        Try
            Dim query As String

            query = "declare  @seq varchar(7)
            set @seq= (select right('000000'+cast(right(rtrim(max(bomid)),7)+1 as varchar),7)
            from bomh
            where left(bomid,1) <> 'P')
            print @seq
            select coalesce(@seq, '0000001') No   "

            Dim dt As DataTable = New DataTable
            dt = GetDataTable(query)
            Return dt.Rows(0).Item(0).ToString

        Catch ex As Exception
            Throw

        End Try
    End Function

    Public Function getInvtItem() As DataTable
        Try
            Dim query As String =
            "select InvtID as [Invetory ID], Descr as Description, StkUnit as Unit from Inventory where TranStatusCode='AC'  order by Descr"
            Dim dtTable As New DataTable
            dtTable = GetDataTable_Solomon(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function getInvtItem_project() As DataTable
        Try
            Dim query As String = "select InvtID as [Invetory ID], Descr as Description, StkUnit as Unit from Inventory_lc where TranStatusCode='AC'  order by Descr"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function getIdMesin(ByVal site As String) As DataTable
        Try
            Dim query As String =
                "   select '' [ID Mesin],'' Deskripsi  from m_mesin
                    UNION 
                    select [ID Mesin],Deskripsi from m_mesin where [Id Lokasi] = " & QVal(site) & ""
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function getSite() As DataTable
        Try
            Dim query As String =
                "   select '' [ID Lokasi],'' Deskripsi  from m_lokasi 
                    UNION 
                    select [ID Lokasi], Deskripsi from m_lokasi"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function
    Public Function getWC() As DataTable
        Try
            Dim query As String =
                "   select '' [Value],'' Text  from m_work_center
                    UNION 
                    select [ID] [Value], Description Text from m_work_center"
            Dim dtTable As New DataTable
            dtTable = MainModul.GetDataTableByCommand(query)
            Return dtTable
        Catch ex As Exception
            Throw
        End Try
    End Function

#Region "CRUD"
    Public Sub InsertHeader(Status As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "Insert into bomh(bomid,tgl,invtid,descr,siteid,runner,ct,mc,cavity,wc,allowance, mp, [status],active,converted,created_by,created_date) " & vbCrLf &
                                    "       OUTPUT  Inserted.bomid, " & vbCrLf &
                                    "               Inserted.tgl, " & vbCrLf &
                                    "               Inserted.invtid, " & vbCrLf &
                                    "               Inserted.descr, " & vbCrLf &
                                    "               Inserted.siteid, " & vbCrLf &
                                    "               Inserted.runner, " & vbCrLf &
                                    "               Inserted.ct, " & vbCrLf &
                                    "               Inserted.mc, " & vbCrLf &
                                    "               Inserted.cavity, " & vbCrLf &
                                    "               Inserted.wc, " & vbCrLf &
                                    "               Inserted.allowance, " & vbCrLf &
                                    "               Inserted.mp, " & vbCrLf &
                                    "               NULL, " & vbCrLf &
                                    "               NULL, " & vbCrLf &
                                    "               Inserted.[status], " & vbCrLf &
                                    "               Inserted.[active], " & vbCrLf &
                                    "               0, " & vbCrLf &
                                    "               Inserted.created_by, " & vbCrLf &
                                    "               Inserted.created_date, " & vbCrLf &
                                    "               NULL, " & vbCrLf &
                                    "               NULL " & vbCrLf &
                                    "       Into bom_header_history " & vbCrLf &
                                    "Values(" & QVal(Me._bomid) & ", " & vbCrLf &
                                    "       " & QVal(Me._tgl) & ", " & vbCrLf &
                                    "       " & QVal(Me._invtid) & ", " & vbCrLf &
                                    "       " & QVal(Me._desc) & ", " & vbCrLf &
                                    "       " & QVal(Me._siteid) & ", " & vbCrLf &
                                    "       " & QVal(Me._runner) & ", " & vbCrLf &
                                    "       " & QVal(Me._ct) & ", " & vbCrLf &
                                    "       " & QVal(Me._mc) & ", " & vbCrLf &
                                    "       " & QVal(Me.cavity) & ", " & vbCrLf &
                                    "       " & QVal(Me.WC) & ", " & vbCrLf &
                                    "       " & QVal(Me._allowance) & ", " & vbCrLf &
                                    "       " & QVal(Me._mp) & ", " & vbCrLf &
                                    "       " & QVal(Status) & ", " & vbCrLf &
                                    "       " & QVal(Me._active) & ", " & vbCrLf &
                                    "       " & QVal(Me.Converted) & ", " & vbCrLf &
                                    "       " & QVal(gh_Common.Username) & ", " & vbCrLf &
                                    "       getdate())"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub InsertHeaderExcel(i As Integer)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "Insert into bomh(bomid,tgl,invtid,descr,siteid,runner,ct,mc,cavity,wc,allowance, mp, [status],active,converted,created_by,created_date) " & vbCrLf &
                                    "       OUTPUT  Inserted.bomid, " & vbCrLf &
                                    "               Inserted.tgl, " & vbCrLf &
                                    "               Inserted.invtid, " & vbCrLf &
                                    "               Inserted.descr, " & vbCrLf &
                                    "               Inserted.siteid, " & vbCrLf &
                                    "               Inserted.runner, " & vbCrLf &
                                    "               Inserted.ct, " & vbCrLf &
                                    "               Inserted.mc, " & vbCrLf &
                                    "               Inserted.cavity, " & vbCrLf &
                                    "               Inserted.wc, " & vbCrLf &
                                    "               Inserted.allowance, " & vbCrLf &
                                    "               Inserted.mp, " & vbCrLf &
                                    "               NULL, " & vbCrLf &
                                    "               NULL, " & vbCrLf &
                                    "               Inserted.[status], " & vbCrLf &
                                    "               Inserted.[active], " & vbCrLf &
                                    "               0, " & vbCrLf &
                                    "               Inserted.created_by, " & vbCrLf &
                                    "               Inserted.created_date, " & vbCrLf &
                                    "               NULL, " & vbCrLf &
                                    "               NULL " & vbCrLf &
                                    "       Into bom_header_history " & vbCrLf &
                                    "Values(" & QVal(BoMHeaderCollection(i)._bomid) & ", " & vbCrLf &
                                    "       " & QVal(BoMHeaderCollection(i)._tgl) & ", " & vbCrLf &
                                    "       " & QVal(BoMHeaderCollection(i)._invtid) & ", " & vbCrLf &
                                    "       " & QVal(BoMHeaderCollection(i)._desc) & ", " & vbCrLf &
                                    "       " & QVal(BoMHeaderCollection(i)._siteid) & ", " & vbCrLf &
                                    "       " & QVal(BoMHeaderCollection(i)._runner) & ", " & vbCrLf &
                                    "       " & QVal(BoMHeaderCollection(i)._ct) & ", " & vbCrLf &
                                    "       " & QVal(BoMHeaderCollection(i)._mc) & ", " & vbCrLf &
                                    "       " & QVal(BoMHeaderCollection(i).cavity) & ", " & vbCrLf &
                                    "       " & QVal(BoMHeaderCollection(i).WC) & ", " & vbCrLf &
                                    "       " & QVal(BoMHeaderCollection(i)._allowance) & ", " & vbCrLf &
                                    "       " & QVal(BoMHeaderCollection(i)._mp) & ", " & vbCrLf &
                                    "       " & QVal(BoMHeaderCollection(i)._status) & ", " & vbCrLf &
                                    "       " & QVal(BoMHeaderCollection(i)._active) & ", " & vbCrLf &
                                    "       " & QVal(BoMHeaderCollection(i).Converted) & ", " & vbCrLf &
                                    "       " & QVal(gh_Common.Username) & ", " & vbCrLf &
                                    "       getdate())"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub UpdateHeader(ByVal rev As Integer)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "Update bomh " & vbCrLf &
                                    "SET    tgl = " & QVal(Me._tgl) & ", " & vbCrLf &
                                    "       invtid = " & QVal(Me._invtid) & ", " & vbCrLf &
                                    "       descr = " & QVal(Me._desc) & ", " & vbCrLf &
                                    "       siteid = " & QVal(Me._siteid) & ", " & vbCrLf &
                                    "       runner = " & QVal(Me._runner) & ", " & vbCrLf &
                                    "       ct = " & QVal(Me._ct) & ", " & vbCrLf &
                                    "       mc = " & QVal(Me._mc) & ", " & vbCrLf &
                                    "       cavity = " & QVal(Me.cavity) & ", " & vbCrLf &
                                    "       wc = " & QVal(Me.WC) & ", " & vbCrLf &
                                    "       allowance = " & QVal(Me._allowance) & ", " & vbCrLf &
                                    "       mp = " & QVal(Me._mp) & ", " & vbCrLf &
                                    "       [status] = " & QVal(Me._status) & ", " & vbCrLf &
                                    "       RefTipe = " & QVal(Me.RefType) & ", " & vbCrLf &
                                    "       RefNo = " & QVal(Me.RefNo) & ", " & vbCrLf &
                                    "       [active] = " & QVal(Me._active) & ", " & vbCrLf &
                                    "       [updated_by] = " & QVal(gh_Common.Username) & ", " & vbCrLf &
                                    "       updated_date = getdate() " & vbCrLf &
                                    "       OUTPUT  '" & Me._bomid & "', " & vbCrLf &
                                    "               Inserted.tgl, " & vbCrLf &
                                    "               Inserted.invtid, " & vbCrLf &
                                    "               Inserted.descr, " & vbCrLf &
                                    "               Inserted.siteid, " & vbCrLf &
                                    "               Inserted.runner, " & vbCrLf &
                                    "               Inserted.ct, " & vbCrLf &
                                    "               Inserted.mc, " & vbCrLf &
                                    "               Inserted.cavity, " & vbCrLf &
                                    "               Inserted.wc, " & vbCrLf &
                                    "               Inserted.allowance, " & vbCrLf &
                                    "               Inserted.mp, " & vbCrLf &
                                    "               Inserted.[status], " & vbCrLf &
                                    "               Inserted.RefTipe, " & vbCrLf &
                                    "               Inserted.RefNo, " & vbCrLf &
                                    "               Inserted.[active], " & vbCrLf &
                                    "               " & QVal(rev) & " + 1, " & vbCrLf &
                                    "               NULL, " & vbCrLf &
                                    "               NULL, " & vbCrLf &
                                    "               Inserted.updated_by, " & vbCrLf &
                                    "               Inserted.updated_date " & vbCrLf &
                                    "       Into bom_header_history " & vbCrLf &
                                    "       where bomid = '" & _bomid & "'"
            ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub UpdateHeaderExcel(ByVal rev As Integer, i As Integer)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "Update bomh " & vbCrLf &
                                    "SET    tgl = " & QVal(Date.Today) & ", " & vbCrLf &
                                    "       invtid = " & QVal(BoMHeaderCollection(i)._invtid) & ", " & vbCrLf &
                                    "       descr = " & QVal(BoMHeaderCollection(i)._desc) & ", " & vbCrLf &
                                    "       siteid = " & QVal(BoMHeaderCollection(i)._siteid) & ", " & vbCrLf &
                                    "       runner = " & QVal(BoMHeaderCollection(i)._runner) & ", " & vbCrLf &
                                    "       ct = " & QVal(BoMHeaderCollection(i)._ct) & ", " & vbCrLf &
                                    "       mc = " & QVal(BoMHeaderCollection(i)._mc) & ", " & vbCrLf &
                                    "       cavity = " & QVal(BoMHeaderCollection(i).cavity) & ", " & vbCrLf &
                                    "       wc = " & QVal(BoMHeaderCollection(i).WC) & ", " & vbCrLf &
                                    "       allowance = " & QVal(BoMHeaderCollection(i)._allowance) & ", " & vbCrLf &
                                    "       mp = " & QVal(BoMHeaderCollection(i)._mp) & ", " & vbCrLf &
                                    "       [status] = " & QVal(BoMHeaderCollection(i)._status) & ", " & vbCrLf &
                                    "       RefTipe = " & QVal(BoMHeaderCollection(i).RefType) & ", " & vbCrLf &
                                    "       RefNo = " & QVal(BoMHeaderCollection(i).RefNo) & ", " & vbCrLf &
                                    "       [active] = " & QVal(BoMHeaderCollection(i)._active) & ", " & vbCrLf &
                                    "       [updated_by] = " & QVal(gh_Common.Username) & ", " & vbCrLf &
                                    "       updated_date = getdate() " & vbCrLf &
                                    "       OUTPUT  '" & _bomid & "', " & vbCrLf &
                                    "               Inserted.tgl, " & vbCrLf &
                                    "               Inserted.invtid, " & vbCrLf &
                                    "               Inserted.descr, " & vbCrLf &
                                    "               Inserted.siteid, " & vbCrLf &
                                    "               Inserted.runner, " & vbCrLf &
                                    "               Inserted.ct, " & vbCrLf &
                                    "               Inserted.mc, " & vbCrLf &
                                    "               Inserted.cavity, " & vbCrLf &
                                    "               Inserted.wc, " & vbCrLf &
                                    "               Inserted.allowance, " & vbCrLf &
                                    "               Inserted.mp, " & vbCrLf &
                                    "               Inserted.[status], " & vbCrLf &
                                    "               Inserted.RefTipe, " & vbCrLf &
                                    "               Inserted.RefNo, " & vbCrLf &
                                    "               Inserted.[active], " & vbCrLf &
                                    "               " & QVal(rev) & " + 1, " & vbCrLf &
                                    "               NULL, " & vbCrLf &
                                    "               NULL, " & vbCrLf &
                                    "               Inserted.updated_by, " & vbCrLf &
                                    "               Inserted.updated_date " & vbCrLf &
                                    "       Into bom_header_history " & vbCrLf &
                                    "       where bomid = '" & BoMHeaderCollection(i)._bomid & "'"
            ExecQuery(ls_SP)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Public Function GetLasRevisi(i As Integer) As Integer
        Dim _result As Integer = 0
        Try
            Dim Sql As String = "select isnull(max(revisi),0) rev from bom_header_history where bomid =" & QVal(BoMHeaderCollection(i)._bomid) & ""
            Dim dt As New DataTable

            dt = GetDataTable(Sql)
            If dt.Rows.Count > 0 Then
                _result = Convert.ToInt32(dt.Rows(0)(0))
            End If
            Return _result
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub DeleteHeader(ByVal bomid As String)
        Try
            Dim ls_SP As String = "Delete from bomh where bomid =" & QVal(bomid) & ""
            ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub DeleteHeaderByInvtID(ByVal bomid As String)
        Try
            Dim ls_SP As String = "BoMDeleteByInvtId_SiteID"
            Dim param() As SqlParameter = New SqlParameter(0) {}
            param(0) = New SqlParameter("@invtid", SqlDbType.VarChar)
            param(0).Value = bomid
            ExecQueryByCommand_SP(ls_SP, param)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub UpdateHeaderManual(InvtID As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "Update bomh " & vbCrLf &
                                    "SET    mc = " & QVal(Me._mc) & " " & vbCrLf &
                                    "       where RTRIM(InvtId) = '" & InvtID.Trim & "'"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub

    Public Sub UpdateHeaderManualCT(InvtID As String)
        Try
            Dim ls_SP As String = " " & vbCrLf &
                                    "Update bomh " & vbCrLf &
                                    "SET    ct = " & QVal(Me._ct) & " " & vbCrLf &
                                    "       where RTRIM(InvtId) = '" & InvtID.Trim & "'"
            MainModul.ExecQuery(ls_SP)
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub ValidateInsert()
        If Me._invtid = "" Then
            Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
        End If
        Try
            Dim Query As String =
                "   
                    SELECT bomid 
                    FROM bomh 
                    WHERE invtid = " & QVal(Me._invtid) & "
                "
            Dim dt As DataTable = MainModul.GetDataTable(Query)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.DataTelahDigunakan) &
                          "[" & Me._invtid & "] Pada BoM [" & dt.Rows(0)(0).ToString() & "]")
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub ValidateInsert1()
        If Me._invtid = "" Then
            Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
        End If
        Try
            Dim Query As String =
                "   
                    SELECT bomid 
                    FROM bomh 
                    WHERE invtid = " & QVal(Me._invtid) & " AND Status = 'REGULAR'
                "
            Dim dt As DataTable = MainModul.GetDataTable(Query)
            If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.DataTelahDigunakan) &
                          "[" & Me._invtid & "] Pada BoM [" & dt.Rows(0)(0).ToString() & "]")
            End If

        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub ValidateDelete()
        Try
            If Me._bomid = "" Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
            End If
            Dim Query As String =
                "   
                    SELECT * 
                    FROM bomh 
                    WHERE bomid = " & QVal(Me._bomid) & "
                "
            Dim dt As DataTable = MainModul.GetDataTable(Query)
            If dt IsNot Nothing AndAlso dt.Rows.Count = 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.DataTidakKetemu) &
                "[" & Me._bomid & "]")
            End If


        Catch ex As Exception

        End Try
    End Sub
    Public Sub ValidateUpdate()
        If Me._bomid = "" Then
            Err.Raise(ErrNumber, , GetMessage(MessageEnum.PropertyKosong))
        End If
        Try
            Dim Query As String =
                "   
                    SELECT * 
                    FROM bomh 
                    WHERE bomid = " & QVal(Me._bomid) & "
                "
            Dim dt As DataTable = MainModul.GetDataTable(Query)
            If dt IsNot Nothing AndAlso dt.Rows.Count = 0 Then
                Err.Raise(ErrNumber, , GetMessage(MessageEnum.DataTidakKetemu) &
                "[" & Me._bomid & "]")
            End If
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Function ValidateUpdateHeader(i As Integer) As Boolean
        Dim _result As Boolean = False
        Try
            Dim Query As String =
                "   
                    SELECT BomId 
                    FROM bomh 
                    WHERE bomid = " & QVal(BoMHeaderCollection(i)._bomid) & "
                "
            Dim dt As DataTable = GetDataTable(Query)
            If dt.Rows.Count > 0 Then
                _result = True
            End If
            Return _result
        Catch ex As Exception
            Throw ex
        End Try
    End Function
    Public Sub InsertBoMHeader()
        Try
            Using Conn1 As New SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        For i As Integer = 0 To BoMHeaderCollection.Count - 1
                            InsertHeaderExcel(i)
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

    Public Sub UpdateBoMHeader()
        Try
            Using Conn1 As New SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlClient.SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try

                        Dim IsBomIdExist As Boolean
                        Dim Rev As Integer

                        For i As Integer = 0 To BoMHeaderCollection.Count - 1
                            IsBomIdExist = ValidateUpdateHeader(i)
                            Rev = GetLasRevisi(i)
                            If IsBomIdExist Then
                                UpdateHeaderExcel(Rev, i)
                            End If
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

    Public Sub DeleteBoMOnUpload()
        Try
            Using Conn1 As New SqlConnection(GetConnString)
                Conn1.Open()
                Using Trans1 As SqlTransaction = Conn1.BeginTransaction
                    gh_Trans = New InstanceVariables.TransactionHelper
                    gh_Trans.Command.Connection = Conn1
                    gh_Trans.Command.Transaction = Trans1

                    Try
                        For i As Integer = 0 To BoMTempCollection.Count - 1
                            With BoMTempCollection(i)
                                .DeleteByExcel()
                            End With
                        Next
                        Trans1.Commit()
                    Catch ex As Exception
                        Trans1.Rollback()
                        Throw ex
                    Finally
                        gh_Trans = Nothing
                    End Try
                End Using
            End Using
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
#End Region
End Class

Public Class BoM_Temp
    Public Property InvtID() As String

    Public Sub DeleteByExcel()
        Try
            Dim BomID As String = String.Empty
            Dim Sql As String = "BoMH_DeleteByInvtId"
            Dim pParam() As SqlParameter = New SqlParameter(0) {}
            pParam(0) = New SqlParameter("@InvtID", SqlDbType.VarChar)
            pParam(0).Value = InvtID
            Dim dt As New DataTable
            dt = GetDataTableByCommand_SP(Sql, pParam)
            If dt.Rows.Count > 0 Then
                BomID = dt.Rows(0)(0).ToString()
                Dim Sql1 As String = "BoM_DeleteByBomIDOnUploadExcel"
                Dim pParam1() As SqlParameter = New SqlParameter(0) {}
                pParam1(0) = New SqlParameter("@bomid", SqlDbType.VarChar)
                pParam1(0).Value = BomID
                ExecQueryByCommand_SP(Sql1, pParam1)
            End If
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class

