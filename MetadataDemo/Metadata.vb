Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.IO
Imports Atalasoft.Imaging
Imports Atalasoft.Imaging.Metadata
Imports Atalasoft.Imaging.Codec
Imports Atalasoft.Imaging.Codec.Tiff
Imports WinDemoHelperMethods.WinDemoHelperMethods

Namespace MetadataDemo
    ''' <summary>
    ''' Summary description for Form1.
    ''' </summary>
    Public Class Form1
        Inherits System.Windows.Forms.Form
        Private _lastFileName As String = ""
        ' Here are the tag collections which will hold all of the information.
        Private _tiffTags As TiffTagExtendedCollection = Nothing
        Private _iptcTags As IptcCollection = Nothing
        Private _comTags As ComTextCollection = Nothing
        Private _exifTags As ExifTagExtendedCollection = Nothing

        Private mainMenu1 As System.Windows.Forms.MainMenu
        Private menuItem4 As System.Windows.Forms.MenuItem
        Private menuFile As System.Windows.Forms.MenuItem
        Private WithEvents menuOpen As System.Windows.Forms.MenuItem
        Private WithEvents menuSave As System.Windows.Forms.MenuItem
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.Container = Nothing
        Private tabControl1 As System.Windows.Forms.TabControl
        Private tabExif As System.Windows.Forms.TabPage
        Private tabIptc As System.Windows.Forms.TabPage
        Private tabCom As System.Windows.Forms.TabPage
        Private menuItem1 As System.Windows.Forms.MenuItem
        Private menuIptc As System.Windows.Forms.MenuItem
        Private WithEvents menuIptcAdd As System.Windows.Forms.MenuItem
        Private menuCom As System.Windows.Forms.MenuItem
        Private WithEvents menuComClear As System.Windows.Forms.MenuItem
        Private menuItem12 As System.Windows.Forms.MenuItem
        Private WithEvents menuComAdd As System.Windows.Forms.MenuItem
        Private WithEvents menuComRemove As System.Windows.Forms.MenuItem
        Private tabTiff As System.Windows.Forms.TabPage
        Private panelImageBorder As System.Windows.Forms.Panel
        Private lblImageInfo As System.Windows.Forms.Label
        Private WithEvents mnuIptcRemove As System.Windows.Forms.MenuItem
        Private WithEvents menuIptcClear As System.Windows.Forms.MenuItem
        Private menuItem3 As System.Windows.Forms.MenuItem
        Private thumbnailView As Atalasoft.Imaging.WinControls.ImageViewer
        Private dataGridTableStyle4 As System.Windows.Forms.DataGridTableStyle
        Private dataGridTextBoxColumn13 As System.Windows.Forms.DataGridTextBoxColumn
        Private dataGridTextBoxColumn14 As System.Windows.Forms.DataGridTextBoxColumn
        Private menuItem6 As System.Windows.Forms.MenuItem
        Private menuItem13 As System.Windows.Forms.MenuItem
        Private menuTiff As System.Windows.Forms.MenuItem
        Private WithEvents menuTiffClear As System.Windows.Forms.MenuItem
        Private WithEvents menuTiffRemove As System.Windows.Forms.MenuItem
        Private menuTiffNothing As System.Windows.Forms.MenuItem
        Private WithEvents menuTiffAdd As System.Windows.Forms.MenuItem
        Private menuExif As System.Windows.Forms.MenuItem
        Private menuItem9 As System.Windows.Forms.MenuItem
        Private dataGrid As System.Windows.Forms.DataGrid
        Private label1 As System.Windows.Forms.Label
        Private dataGridIptc As System.Windows.Forms.DataGrid
        Private dataGridTableStyle1 As System.Windows.Forms.DataGridTableStyle
        Private dataGridTextBoxColumn1 As System.Windows.Forms.DataGridTextBoxColumn
        Private dataGridTextBoxColumn2 As System.Windows.Forms.DataGridTextBoxColumn
        Private dataGridTextBoxColumn3 As System.Windows.Forms.DataGridTextBoxColumn
        Private dataGridTextBoxColumn4 As System.Windows.Forms.DataGridTextBoxColumn
        Private dataGridTableStyle2 As System.Windows.Forms.DataGridTableStyle
        Private dataGridTextBoxColumn6 As System.Windows.Forms.DataGridTextBoxColumn
        Private dataGridTextBoxColumn7 As System.Windows.Forms.DataGridTextBoxColumn
        Private dataGridTextBoxColumn8 As System.Windows.Forms.DataGridTextBoxColumn
        Private dataGridCom As System.Windows.Forms.DataGrid
        Private WithEvents menuExifClear As System.Windows.Forms.MenuItem
        Private WithEvents menuExifAdd As System.Windows.Forms.MenuItem
        Private WithEvents menuExifRemove As System.Windows.Forms.MenuItem
        Private WithEvents menuTiffViewBinary As System.Windows.Forms.MenuItem
        Private WithEvents menuAddTagAscii As System.Windows.Forms.MenuItem
        Private WithEvents menuAbout As System.Windows.Forms.MenuItem
        Private WithEvents menuExit As System.Windows.Forms.MenuItem
        Private dataGridTableStyle3 As System.Windows.Forms.DataGridTableStyle
        Private dataGridTextBoxColumn5 As System.Windows.Forms.DataGridTextBoxColumn
        Private dataGridTextBoxColumn9 As System.Windows.Forms.DataGridTextBoxColumn
        Private dataGridTextBoxColumn10 As System.Windows.Forms.DataGridTextBoxColumn
        Private dataGridTextBoxColumn11 As System.Windows.Forms.DataGridTextBoxColumn
        Private dataGridTextBoxColumn12 As System.Windows.Forms.DataGridTextBoxColumn
        Private tabXmp As System.Windows.Forms.TabPage
        Private textXmp As System.Windows.Forms.TextBox
        Private menuItem2 As System.Windows.Forms.MenuItem
        Private WithEvents menuAddThumb As System.Windows.Forms.MenuItem
        Private dataGridTiff As System.Windows.Forms.DataGrid

        Shared Sub New()
            HelperMethods.PopulateDecoders(RegisteredDecoders.Decoders)
        End Sub

        Public Sub New()
            '
            ' Required for Windows Form Designer support
            '
            InitializeComponent()

            Me.tabControl1.TabPages.Remove(tabExif)
            Me.tabControl1.TabPages.Remove(tabIptc)
            Me.tabControl1.TabPages.Remove(tabCom)
            Me.tabControl1.TabPages.Remove(tabTiff)
            Me.tabControl1.TabPages.Remove(tabXmp)
        End Sub

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not components Is Nothing Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.mainMenu1 = New System.Windows.Forms.MainMenu()
            Me.menuFile = New System.Windows.Forms.MenuItem()
            Me.menuOpen = New System.Windows.Forms.MenuItem()
            Me.menuSave = New System.Windows.Forms.MenuItem()
            Me.menuItem4 = New System.Windows.Forms.MenuItem()
            Me.menuExit = New System.Windows.Forms.MenuItem()
            Me.menuItem1 = New System.Windows.Forms.MenuItem()
            Me.menuCom = New System.Windows.Forms.MenuItem()
            Me.menuComClear = New System.Windows.Forms.MenuItem()
            Me.menuItem12 = New System.Windows.Forms.MenuItem()
            Me.menuComAdd = New System.Windows.Forms.MenuItem()
            Me.menuComRemove = New System.Windows.Forms.MenuItem()
            Me.menuIptc = New System.Windows.Forms.MenuItem()
            Me.menuIptcClear = New System.Windows.Forms.MenuItem()
            Me.menuItem3 = New System.Windows.Forms.MenuItem()
            Me.menuIptcAdd = New System.Windows.Forms.MenuItem()
            Me.mnuIptcRemove = New System.Windows.Forms.MenuItem()
            Me.menuTiff = New System.Windows.Forms.MenuItem()
            Me.menuTiffClear = New System.Windows.Forms.MenuItem()
            Me.menuItem13 = New System.Windows.Forms.MenuItem()
            Me.menuTiffNothing = New System.Windows.Forms.MenuItem()
            Me.menuTiffAdd = New System.Windows.Forms.MenuItem()
            Me.menuAddTagAscii = New System.Windows.Forms.MenuItem()
            Me.menuTiffRemove = New System.Windows.Forms.MenuItem()
            Me.menuTiffViewBinary = New System.Windows.Forms.MenuItem()
            Me.menuExif = New System.Windows.Forms.MenuItem()
            Me.menuExifClear = New System.Windows.Forms.MenuItem()
            Me.menuItem9 = New System.Windows.Forms.MenuItem()
            Me.menuExifAdd = New System.Windows.Forms.MenuItem()
            Me.menuExifRemove = New System.Windows.Forms.MenuItem()
            Me.menuItem6 = New System.Windows.Forms.MenuItem()
            Me.menuAbout = New System.Windows.Forms.MenuItem()
            Me.tabControl1 = New System.Windows.Forms.TabControl()
            Me.tabExif = New System.Windows.Forms.TabPage()
            Me.dataGrid = New System.Windows.Forms.DataGrid()
            Me.dataGridTableStyle3 = New System.Windows.Forms.DataGridTableStyle()
            Me.dataGridTextBoxColumn5 = New System.Windows.Forms.DataGridTextBoxColumn()
            Me.dataGridTextBoxColumn9 = New System.Windows.Forms.DataGridTextBoxColumn()
            Me.dataGridTextBoxColumn11 = New System.Windows.Forms.DataGridTextBoxColumn()
            Me.dataGridTextBoxColumn12 = New System.Windows.Forms.DataGridTextBoxColumn()
            Me.dataGridTextBoxColumn10 = New System.Windows.Forms.DataGridTextBoxColumn()
            Me.tabCom = New System.Windows.Forms.TabPage()
            Me.dataGridCom = New System.Windows.Forms.DataGrid()
            Me.dataGridTableStyle4 = New System.Windows.Forms.DataGridTableStyle()
            Me.dataGridTextBoxColumn13 = New System.Windows.Forms.DataGridTextBoxColumn()
            Me.dataGridTextBoxColumn14 = New System.Windows.Forms.DataGridTextBoxColumn()
            Me.tabIptc = New System.Windows.Forms.TabPage()
            Me.dataGridIptc = New System.Windows.Forms.DataGrid()
            Me.dataGridTableStyle1 = New System.Windows.Forms.DataGridTableStyle()
            Me.dataGridTextBoxColumn1 = New System.Windows.Forms.DataGridTextBoxColumn()
            Me.dataGridTextBoxColumn2 = New System.Windows.Forms.DataGridTextBoxColumn()
            Me.dataGridTextBoxColumn3 = New System.Windows.Forms.DataGridTextBoxColumn()
            Me.dataGridTextBoxColumn4 = New System.Windows.Forms.DataGridTextBoxColumn()
            Me.tabTiff = New System.Windows.Forms.TabPage()
            Me.dataGridTiff = New System.Windows.Forms.DataGrid()
            Me.dataGridTableStyle2 = New System.Windows.Forms.DataGridTableStyle()
            Me.dataGridTextBoxColumn6 = New System.Windows.Forms.DataGridTextBoxColumn()
            Me.dataGridTextBoxColumn7 = New System.Windows.Forms.DataGridTextBoxColumn()
            Me.dataGridTextBoxColumn8 = New System.Windows.Forms.DataGridTextBoxColumn()
            Me.tabXmp = New System.Windows.Forms.TabPage()
            Me.textXmp = New System.Windows.Forms.TextBox()
            Me.panelImageBorder = New System.Windows.Forms.Panel()
            Me.thumbnailView = New Atalasoft.Imaging.WinControls.ImageViewer()
            Me.lblImageInfo = New System.Windows.Forms.Label()
            Me.label1 = New System.Windows.Forms.Label()
            Me.menuItem2 = New System.Windows.Forms.MenuItem()
            Me.menuAddThumb = New System.Windows.Forms.MenuItem()
            Me.tabControl1.SuspendLayout()
            Me.tabExif.SuspendLayout()
            CType(Me.dataGrid, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tabCom.SuspendLayout()
            CType(Me.dataGridCom, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tabIptc.SuspendLayout()
            CType(Me.dataGridIptc, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tabTiff.SuspendLayout()
            CType(Me.dataGridTiff, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.tabXmp.SuspendLayout()
            Me.panelImageBorder.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' mainMenu1
            ' 
            Me.mainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuFile, Me.menuItem1, Me.menuItem6})
            ' 
            ' menuFile
            ' 
            Me.menuFile.Index = 0
            Me.menuFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuOpen, Me.menuSave, Me.menuItem4, Me.menuExit})
            Me.menuFile.Text = "&File"
            ' 
            ' menuOpen
            ' 
            Me.menuOpen.Index = 0
            Me.menuOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO
            Me.menuOpen.Text = "&Open"
            '			Me.menuOpen.Click += New System.EventHandler(Me.menuOpen_Click);
            ' 
            ' menuSave
            ' 
            Me.menuSave.Index = 1
            Me.menuSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS
            Me.menuSave.Text = "&Save As"
            '			Me.menuSave.Click += New System.EventHandler(Me.menuSave_Click);
            ' 
            ' menuItem4
            ' 
            Me.menuItem4.Index = 2
            Me.menuItem4.Text = "-"
            ' 
            ' menuExit
            ' 
            Me.menuExit.Index = 3
            Me.menuExit.Text = "E&xit"
            '			Me.menuExit.Click += New System.EventHandler(Me.menuExit_Click);
            ' 
            ' menuItem1
            ' 
            Me.menuItem1.Index = 1
            Me.menuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuCom, Me.menuIptc, Me.menuTiff, Me.menuExif})
            Me.menuItem1.Text = "&Modify"
            ' 
            ' menuCom
            ' 
            Me.menuCom.Index = 0
            Me.menuCom.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuComClear, Me.menuItem12, Me.menuComAdd, Me.menuComRemove})
            Me.menuCom.Text = "COM"
            ' 
            ' menuComClear
            ' 
            Me.menuComClear.Index = 0
            Me.menuComClear.Text = "Clear"
            '			Me.menuComClear.Click += New System.EventHandler(Me.menuComClear_Click);
            ' 
            ' menuItem12
            ' 
            Me.menuItem12.Index = 1
            Me.menuItem12.Text = "-"
            ' 
            ' menuComAdd
            ' 
            Me.menuComAdd.Index = 2
            Me.menuComAdd.Text = "Add"
            '			Me.menuComAdd.Click += New System.EventHandler(Me.menuComAdd_Click);
            ' 
            ' menuComRemove
            ' 
            Me.menuComRemove.Index = 3
            Me.menuComRemove.Text = "Remove Selected"
            '			Me.menuComRemove.Click += New System.EventHandler(Me.menuComRemove_Click);
            ' 
            ' menuIptc
            ' 
            Me.menuIptc.Index = 1
            Me.menuIptc.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuIptcClear, Me.menuItem3, Me.menuIptcAdd, Me.mnuIptcRemove})
            Me.menuIptc.Text = "&IPTC"
            ' 
            ' menuIptcClear
            ' 
            Me.menuIptcClear.Index = 0
            Me.menuIptcClear.Text = "Clear"
            '			Me.menuIptcClear.Click += New System.EventHandler(Me.menuIptcClear_Click);
            ' 
            ' menuItem3
            ' 
            Me.menuItem3.Index = 1
            Me.menuItem3.Text = "-"
            ' 
            ' menuIptcAdd
            ' 
            Me.menuIptcAdd.Index = 2
            Me.menuIptcAdd.Text = "Add"
            '			Me.menuIptcAdd.Click += New System.EventHandler(Me.menuIptcAdd_Click);
            ' 
            ' mnuIptcRemove
            ' 
            Me.mnuIptcRemove.Index = 3
            Me.mnuIptcRemove.Text = "Remove  Selected"
            '			Me.mnuIptcRemove.Click += New System.EventHandler(Me.mnuIptcRemove_Click);
            ' 
            ' menuTiff
            ' 
            Me.menuTiff.Index = 2
            Me.menuTiff.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuTiffClear, Me.menuItem13, Me.menuTiffNothing, Me.menuTiffRemove, Me.menuTiffViewBinary})
            Me.menuTiff.Text = "&TIFF"
            ' 
            ' menuTiffClear
            ' 
            Me.menuTiffClear.Index = 0
            Me.menuTiffClear.Text = "Clear"
            '			Me.menuTiffClear.Click += New System.EventHandler(Me.menuTiffClear_Click);
            ' 
            ' menuItem13
            ' 
            Me.menuItem13.Index = 1
            Me.menuItem13.Text = "-"
            ' 
            ' menuTiffNothing
            ' 
            Me.menuTiffNothing.Index = 2
            Me.menuTiffNothing.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuTiffAdd, Me.menuAddTagAscii})
            Me.menuTiffNothing.Text = "Add"
            ' 
            ' menuTiffAdd
            ' 
            Me.menuTiffAdd.Index = 0
            Me.menuTiffAdd.Text = "Image (Binary)"
            '			Me.menuTiffAdd.Click += New System.EventHandler(Me.menuTiffAdd_Click);
            ' 
            ' menuAddTagAscii
            ' 
            Me.menuAddTagAscii.Index = 1
            Me.menuAddTagAscii.Text = "ASCII"
            '			Me.menuAddTagAscii.Click += New System.EventHandler(Me.menuTiffAdd_Click);
            ' 
            ' menuTiffRemove
            ' 
            Me.menuTiffRemove.Index = 3
            Me.menuTiffRemove.Text = "Remove Selected"
            '			Me.menuTiffRemove.Click += New System.EventHandler(Me.menuTiffRemove_Click);
            ' 
            ' menuTiffViewBinary
            ' 
            Me.menuTiffViewBinary.Index = 4
            Me.menuTiffViewBinary.Text = "View Binary Image Tag"
            '			Me.menuTiffViewBinary.Click += New System.EventHandler(Me.menuTiffViewBinary_Click);
            ' 
            ' menuExif
            ' 
            Me.menuExif.Index = 3
            Me.menuExif.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuExifClear, Me.menuItem9, Me.menuExifAdd, Me.menuExifRemove, Me.menuItem2, Me.menuAddThumb})
            Me.menuExif.Text = "&EXIF"
            ' 
            ' menuExifClear
            ' 
            Me.menuExifClear.Index = 0
            Me.menuExifClear.Text = "Clear"
            '			Me.menuExifClear.Click += New System.EventHandler(Me.menuExifClear_Click);
            ' 
            ' menuItem9
            ' 
            Me.menuItem9.Index = 1
            Me.menuItem9.Text = "-"
            ' 
            ' menuExifAdd
            ' 
            Me.menuExifAdd.Index = 2
            Me.menuExifAdd.Text = "Add"
            '			Me.menuExifAdd.Click += New System.EventHandler(Me.menuExifAdd_Click);
            ' 
            ' menuExifRemove
            ' 
            Me.menuExifRemove.Index = 3
            Me.menuExifRemove.Text = "Remove Selected"
            '			Me.menuExifRemove.Click += New System.EventHandler(Me.menuExifRemove_Click);
            ' 
            ' menuItem6
            ' 
            Me.menuItem6.Index = 2
            Me.menuItem6.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuAbout})
            Me.menuItem6.Text = "&Help"
            ' 
            ' menuAbout
            ' 
            Me.menuAbout.Index = 0
            Me.menuAbout.Text = "About ..."
            '			Me.menuAbout.Click += New System.EventHandler(Me.menuAbout_Click);
            ' 
            ' tabControl1
            ' 
            Me.tabControl1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
            Me.tabControl1.Controls.Add(Me.tabExif)
            Me.tabControl1.Controls.Add(Me.tabCom)
            Me.tabControl1.Controls.Add(Me.tabIptc)
            Me.tabControl1.Controls.Add(Me.tabTiff)
            Me.tabControl1.Controls.Add(Me.tabXmp)
            Me.tabControl1.Location = New System.Drawing.Point(0, 0)
            Me.tabControl1.Name = "tabControl1"
            Me.tabControl1.SelectedIndex = 0
            Me.tabControl1.Size = New System.Drawing.Size(520, 385)
            Me.tabControl1.TabIndex = 0
            ' 
            ' tabExif
            ' 
            Me.tabExif.Controls.Add(Me.dataGrid)
            Me.tabExif.Location = New System.Drawing.Point(4, 22)
            Me.tabExif.Name = "tabExif"
            Me.tabExif.Size = New System.Drawing.Size(512, 359)
            Me.tabExif.TabIndex = 0
            Me.tabExif.Text = "EXIF"
            ' 
            ' dataGrid
            ' 
            Me.dataGrid.AlternatingBackColor = System.Drawing.Color.Gainsboro
            Me.dataGrid.BackColor = System.Drawing.Color.Silver
            Me.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dataGrid.CaptionBackColor = System.Drawing.Color.DarkSlateBlue
            Me.dataGrid.CaptionFont = New System.Drawing.Font("Tahoma", 8.0F)
            Me.dataGrid.CaptionForeColor = System.Drawing.Color.White
            Me.dataGrid.DataMember = ""
            Me.dataGrid.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dataGrid.FlatMode = True
            Me.dataGrid.ForeColor = System.Drawing.Color.Black
            Me.dataGrid.GridLineColor = System.Drawing.Color.White
            Me.dataGrid.HeaderBackColor = System.Drawing.Color.DarkGray
            Me.dataGrid.HeaderForeColor = System.Drawing.Color.Black
            Me.dataGrid.LinkColor = System.Drawing.Color.DarkSlateBlue
            Me.dataGrid.Location = New System.Drawing.Point(0, 0)
            Me.dataGrid.Name = "dataGrid"
            Me.dataGrid.ParentRowsBackColor = System.Drawing.Color.Black
            Me.dataGrid.ParentRowsForeColor = System.Drawing.Color.White
            Me.dataGrid.SelectionBackColor = System.Drawing.Color.DarkSlateBlue
            Me.dataGrid.SelectionForeColor = System.Drawing.Color.White
            Me.dataGrid.Size = New System.Drawing.Size(512, 359)
            Me.dataGrid.TabIndex = 1
            Me.dataGrid.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.dataGridTableStyle3})
            ' 
            ' dataGridTableStyle3
            ' 
            Me.dataGridTableStyle3.DataGrid = Me.dataGrid
            Me.dataGridTableStyle3.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.dataGridTextBoxColumn5, Me.dataGridTextBoxColumn9, Me.dataGridTextBoxColumn11, Me.dataGridTextBoxColumn12, Me.dataGridTextBoxColumn10})
            Me.dataGridTableStyle3.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.dataGridTableStyle3.MappingName = "ExifTagExtendedCollection"
            ' 
            ' dataGridTextBoxColumn5
            ' 
            Me.dataGridTextBoxColumn5.Format = ""
            Me.dataGridTextBoxColumn5.FormatInfo = Nothing
            Me.dataGridTextBoxColumn5.HeaderText = "ID"
            Me.dataGridTextBoxColumn5.MappingName = "ID"
            Me.dataGridTextBoxColumn5.ReadOnly = True
            Me.dataGridTextBoxColumn5.Width = 50
            ' 
            ' dataGridTextBoxColumn9
            ' 
            Me.dataGridTextBoxColumn9.Format = ""
            Me.dataGridTextBoxColumn9.FormatInfo = Nothing
            Me.dataGridTextBoxColumn9.HeaderText = "Description"
            Me.dataGridTextBoxColumn9.MappingName = "Description"
            Me.dataGridTextBoxColumn9.ReadOnly = True
            Me.dataGridTextBoxColumn9.Width = 125
            ' 
            ' dataGridTextBoxColumn11
            ' 
            Me.dataGridTextBoxColumn11.Format = ""
            Me.dataGridTextBoxColumn11.FormatInfo = Nothing
            Me.dataGridTextBoxColumn11.HeaderText = "IFD"
            Me.dataGridTextBoxColumn11.MappingName = "Ifd"
            Me.dataGridTextBoxColumn11.ReadOnly = True
            Me.dataGridTextBoxColumn11.Width = 70
            ' 
            ' dataGridTextBoxColumn12
            ' 
            Me.dataGridTextBoxColumn12.Format = ""
            Me.dataGridTextBoxColumn12.FormatInfo = Nothing
            Me.dataGridTextBoxColumn12.HeaderText = "Type"
            Me.dataGridTextBoxColumn12.MappingName = "Type"
            Me.dataGridTextBoxColumn12.ReadOnly = True
            Me.dataGridTextBoxColumn12.Width = 75
            ' 
            ' dataGridTextBoxColumn10
            ' 
            Me.dataGridTextBoxColumn10.Format = ""
            Me.dataGridTextBoxColumn10.FormatInfo = Nothing
            Me.dataGridTextBoxColumn10.HeaderText = "Data"
            Me.dataGridTextBoxColumn10.MappingName = "DataString"
            Me.dataGridTextBoxColumn10.Width = 250
            ' 
            ' tabCom
            ' 
            Me.tabCom.Controls.Add(Me.dataGridCom)
            Me.tabCom.Location = New System.Drawing.Point(4, 22)
            Me.tabCom.Name = "tabCom"
            Me.tabCom.Size = New System.Drawing.Size(512, 359)
            Me.tabCom.TabIndex = 2
            Me.tabCom.Text = "COM"
            ' 
            ' dataGridCom
            ' 
            Me.dataGridCom.AlternatingBackColor = System.Drawing.Color.Gainsboro
            Me.dataGridCom.BackColor = System.Drawing.Color.Silver
            Me.dataGridCom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dataGridCom.CaptionBackColor = System.Drawing.Color.DarkSlateBlue
            Me.dataGridCom.CaptionFont = New System.Drawing.Font("Tahoma", 8.0F)
            Me.dataGridCom.CaptionForeColor = System.Drawing.Color.White
            Me.dataGridCom.DataMember = ""
            Me.dataGridCom.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dataGridCom.FlatMode = True
            Me.dataGridCom.ForeColor = System.Drawing.Color.Black
            Me.dataGridCom.GridLineColor = System.Drawing.Color.White
            Me.dataGridCom.HeaderBackColor = System.Drawing.Color.DarkGray
            Me.dataGridCom.HeaderForeColor = System.Drawing.Color.Black
            Me.dataGridCom.LinkColor = System.Drawing.Color.DarkSlateBlue
            Me.dataGridCom.Location = New System.Drawing.Point(0, 0)
            Me.dataGridCom.Name = "dataGridCom"
            Me.dataGridCom.ParentRowsBackColor = System.Drawing.Color.Black
            Me.dataGridCom.ParentRowsForeColor = System.Drawing.Color.White
            Me.dataGridCom.SelectionBackColor = System.Drawing.Color.DarkSlateBlue
            Me.dataGridCom.SelectionForeColor = System.Drawing.Color.White
            Me.dataGridCom.Size = New System.Drawing.Size(512, 359)
            Me.dataGridCom.TabIndex = 2
            Me.dataGridCom.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.dataGridTableStyle4})
            ' 
            ' dataGridTableStyle4
            ' 
            Me.dataGridTableStyle4.DataGrid = Me.dataGridCom
            Me.dataGridTableStyle4.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.dataGridTextBoxColumn13, Me.dataGridTextBoxColumn14})
            Me.dataGridTableStyle4.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.dataGridTableStyle4.MappingName = "ComTextCollection"
            ' 
            ' dataGridTextBoxColumn13
            ' 
            Me.dataGridTextBoxColumn13.Format = ""
            Me.dataGridTextBoxColumn13.FormatInfo = Nothing
            Me.dataGridTextBoxColumn13.HeaderText = "Key (PNG Only)"
            Me.dataGridTextBoxColumn13.MappingName = "Key"
            Me.dataGridTextBoxColumn13.Width = 75
            ' 
            ' dataGridTextBoxColumn14
            ' 
            Me.dataGridTextBoxColumn14.Format = ""
            Me.dataGridTextBoxColumn14.FormatInfo = Nothing
            Me.dataGridTextBoxColumn14.HeaderText = "Text"
            Me.dataGridTextBoxColumn14.MappingName = "Text"
            Me.dataGridTextBoxColumn14.Width = 300
            ' 
            ' tabIptc
            ' 
            Me.tabIptc.Controls.Add(Me.dataGridIptc)
            Me.tabIptc.Location = New System.Drawing.Point(4, 22)
            Me.tabIptc.Name = "tabIptc"
            Me.tabIptc.Size = New System.Drawing.Size(512, 359)
            Me.tabIptc.TabIndex = 1
            Me.tabIptc.Text = "IPTC"
            ' 
            ' dataGridIptc
            ' 
            Me.dataGridIptc.AlternatingBackColor = System.Drawing.Color.Gainsboro
            Me.dataGridIptc.BackColor = System.Drawing.Color.Silver
            Me.dataGridIptc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dataGridIptc.CaptionBackColor = System.Drawing.Color.DarkSlateBlue
            Me.dataGridIptc.CaptionFont = New System.Drawing.Font("Tahoma", 8.0F)
            Me.dataGridIptc.CaptionForeColor = System.Drawing.Color.White
            Me.dataGridIptc.DataMember = ""
            Me.dataGridIptc.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dataGridIptc.FlatMode = True
            Me.dataGridIptc.ForeColor = System.Drawing.Color.Black
            Me.dataGridIptc.GridLineColor = System.Drawing.Color.White
            Me.dataGridIptc.HeaderBackColor = System.Drawing.Color.DarkGray
            Me.dataGridIptc.HeaderForeColor = System.Drawing.Color.Black
            Me.dataGridIptc.LinkColor = System.Drawing.Color.DarkSlateBlue
            Me.dataGridIptc.Location = New System.Drawing.Point(0, 0)
            Me.dataGridIptc.Name = "dataGridIptc"
            Me.dataGridIptc.ParentRowsBackColor = System.Drawing.Color.Black
            Me.dataGridIptc.ParentRowsForeColor = System.Drawing.Color.White
            Me.dataGridIptc.SelectionBackColor = System.Drawing.Color.DarkSlateBlue
            Me.dataGridIptc.SelectionForeColor = System.Drawing.Color.White
            Me.dataGridIptc.Size = New System.Drawing.Size(512, 359)
            Me.dataGridIptc.TabIndex = 3
            Me.dataGridIptc.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.dataGridTableStyle1})
            ' 
            ' dataGridTableStyle1
            ' 
            Me.dataGridTableStyle1.DataGrid = Me.dataGridIptc
            Me.dataGridTableStyle1.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.dataGridTextBoxColumn1, Me.dataGridTextBoxColumn2, Me.dataGridTextBoxColumn3, Me.dataGridTextBoxColumn4})
            Me.dataGridTableStyle1.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.dataGridTableStyle1.MappingName = "IptcCollection"
            ' 
            ' dataGridTextBoxColumn1
            ' 
            Me.dataGridTextBoxColumn1.Format = ""
            Me.dataGridTextBoxColumn1.FormatInfo = Nothing
            Me.dataGridTextBoxColumn1.HeaderText = "ID"
            Me.dataGridTextBoxColumn1.MappingName = "ID"
            Me.dataGridTextBoxColumn1.ReadOnly = True
            Me.dataGridTextBoxColumn1.Width = 75
            ' 
            ' dataGridTextBoxColumn2
            ' 
            Me.dataGridTextBoxColumn2.Format = ""
            Me.dataGridTextBoxColumn2.FormatInfo = Nothing
            Me.dataGridTextBoxColumn2.HeaderText = "Section"
            Me.dataGridTextBoxColumn2.MappingName = "Section"
            Me.dataGridTextBoxColumn2.ReadOnly = True
            Me.dataGridTextBoxColumn2.Width = 75
            ' 
            ' dataGridTextBoxColumn3
            ' 
            Me.dataGridTextBoxColumn3.Format = ""
            Me.dataGridTextBoxColumn3.FormatInfo = Nothing
            Me.dataGridTextBoxColumn3.HeaderText = "Index"
            Me.dataGridTextBoxColumn3.MappingName = "Index"
            Me.dataGridTextBoxColumn3.ReadOnly = True
            Me.dataGridTextBoxColumn3.Width = 75
            ' 
            ' dataGridTextBoxColumn4
            ' 
            Me.dataGridTextBoxColumn4.Format = ""
            Me.dataGridTextBoxColumn4.FormatInfo = Nothing
            Me.dataGridTextBoxColumn4.HeaderText = "Data"
            Me.dataGridTextBoxColumn4.MappingName = "Data"
            Me.dataGridTextBoxColumn4.Width = 250
            ' 
            ' tabTiff
            ' 
            Me.tabTiff.Controls.Add(Me.dataGridTiff)
            Me.tabTiff.Location = New System.Drawing.Point(4, 22)
            Me.tabTiff.Name = "tabTiff"
            Me.tabTiff.Size = New System.Drawing.Size(512, 359)
            Me.tabTiff.TabIndex = 3
            Me.tabTiff.Text = "TIFF"
            ' 
            ' dataGridTiff
            ' 
            Me.dataGridTiff.AlternatingBackColor = System.Drawing.Color.Gainsboro
            Me.dataGridTiff.BackColor = System.Drawing.Color.Silver
            Me.dataGridTiff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.dataGridTiff.CaptionBackColor = System.Drawing.Color.DarkSlateBlue
            Me.dataGridTiff.CaptionFont = New System.Drawing.Font("Tahoma", 8.0F)
            Me.dataGridTiff.CaptionForeColor = System.Drawing.Color.White
            Me.dataGridTiff.DataMember = ""
            Me.dataGridTiff.Dock = System.Windows.Forms.DockStyle.Fill
            Me.dataGridTiff.FlatMode = True
            Me.dataGridTiff.ForeColor = System.Drawing.Color.Black
            Me.dataGridTiff.GridLineColor = System.Drawing.Color.White
            Me.dataGridTiff.HeaderBackColor = System.Drawing.Color.DarkGray
            Me.dataGridTiff.HeaderForeColor = System.Drawing.Color.Black
            Me.dataGridTiff.LinkColor = System.Drawing.Color.DarkSlateBlue
            Me.dataGridTiff.Location = New System.Drawing.Point(0, 0)
            Me.dataGridTiff.Name = "dataGridTiff"
            Me.dataGridTiff.ParentRowsBackColor = System.Drawing.Color.Black
            Me.dataGridTiff.ParentRowsForeColor = System.Drawing.Color.White
            Me.dataGridTiff.SelectionBackColor = System.Drawing.Color.DarkSlateBlue
            Me.dataGridTiff.SelectionForeColor = System.Drawing.Color.White
            Me.dataGridTiff.Size = New System.Drawing.Size(512, 359)
            Me.dataGridTiff.TabIndex = 2
            Me.dataGridTiff.TableStyles.AddRange(New System.Windows.Forms.DataGridTableStyle() {Me.dataGridTableStyle2})
            ' 
            ' dataGridTableStyle2
            ' 
            Me.dataGridTableStyle2.DataGrid = Me.dataGridTiff
            Me.dataGridTableStyle2.GridColumnStyles.AddRange(New System.Windows.Forms.DataGridColumnStyle() {Me.dataGridTextBoxColumn6, Me.dataGridTextBoxColumn7, Me.dataGridTextBoxColumn8})
            Me.dataGridTableStyle2.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.dataGridTableStyle2.MappingName = "TiffTagExtendedCollection"
            ' 
            ' dataGridTextBoxColumn6
            ' 
            Me.dataGridTextBoxColumn6.Format = ""
            Me.dataGridTextBoxColumn6.FormatInfo = Nothing
            Me.dataGridTextBoxColumn6.HeaderText = "ID"
            Me.dataGridTextBoxColumn6.MappingName = "TagDescription"
            Me.dataGridTextBoxColumn6.ReadOnly = True
            Me.dataGridTextBoxColumn6.Width = 75
            ' 
            ' dataGridTextBoxColumn7
            ' 
            Me.dataGridTextBoxColumn7.Format = ""
            Me.dataGridTextBoxColumn7.FormatInfo = Nothing
            Me.dataGridTextBoxColumn7.HeaderText = "Type"
            Me.dataGridTextBoxColumn7.MappingName = "Type"
            Me.dataGridTextBoxColumn7.ReadOnly = True
            Me.dataGridTextBoxColumn7.Width = 75
            ' 
            ' dataGridTextBoxColumn8
            ' 
            Me.dataGridTextBoxColumn8.Format = ""
            Me.dataGridTextBoxColumn8.FormatInfo = Nothing
            Me.dataGridTextBoxColumn8.HeaderText = "Data"
            Me.dataGridTextBoxColumn8.MappingName = "DataString"
            Me.dataGridTextBoxColumn8.Width = 250
            ' 
            ' tabXmp
            ' 
            Me.tabXmp.Controls.Add(Me.textXmp)
            Me.tabXmp.Location = New System.Drawing.Point(4, 22)
            Me.tabXmp.Name = "tabXmp"
            Me.tabXmp.Size = New System.Drawing.Size(512, 359)
            Me.tabXmp.TabIndex = 4
            Me.tabXmp.Text = "XMP"
            ' 
            ' textXmp
            ' 
            Me.textXmp.Dock = System.Windows.Forms.DockStyle.Fill
            Me.textXmp.Location = New System.Drawing.Point(0, 0)
            Me.textXmp.Multiline = True
            Me.textXmp.Name = "textXmp"
            Me.textXmp.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.textXmp.Size = New System.Drawing.Size(512, 359)
            Me.textXmp.TabIndex = 0
            Me.textXmp.Text = ""
            ' 
            ' panelImageBorder
            ' 
            Me.panelImageBorder.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
            Me.panelImageBorder.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.panelImageBorder.Controls.Add(Me.thumbnailView)
            Me.panelImageBorder.Location = New System.Drawing.Point(528, 24)
            Me.panelImageBorder.Name = "panelImageBorder"
            Me.panelImageBorder.Size = New System.Drawing.Size(200, 224)
            Me.panelImageBorder.TabIndex = 1
            ' 
            ' thumbnailView
            ' 
            Me.thumbnailView.AntialiasDisplay = Atalasoft.Imaging.WinControls.AntialiasDisplayMode.ReductionOnly
            Me.thumbnailView.BackColor = System.Drawing.Color.White
            Me.thumbnailView.Centered = True
            Me.thumbnailView.DisplayProfile = Nothing
            Me.thumbnailView.Dock = System.Windows.Forms.DockStyle.Fill
            Me.thumbnailView.Location = New System.Drawing.Point(0, 0)
            Me.thumbnailView.Magnifier.BackColor = System.Drawing.Color.White
            Me.thumbnailView.Magnifier.BorderColor = System.Drawing.Color.Black
            Me.thumbnailView.Magnifier.Size = New System.Drawing.Size(100, 100)
            Me.thumbnailView.Name = "thumbnailView"
            Me.thumbnailView.OutputProfile = Nothing
            Me.thumbnailView.Selection = Nothing
            Me.thumbnailView.Size = New System.Drawing.Size(198, 222)
            Me.thumbnailView.TabIndex = 4
            ' 
            ' lblImageInfo
            ' 
            Me.lblImageInfo.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
            Me.lblImageInfo.Location = New System.Drawing.Point(536, 264)
            Me.lblImageInfo.Name = "lblImageInfo"
            Me.lblImageInfo.Size = New System.Drawing.Size(184, 112)
            Me.lblImageInfo.TabIndex = 2
            ' 
            ' label1
            ' 
            Me.label1.Anchor = (CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
            Me.label1.AutoSize = True
            Me.label1.Location = New System.Drawing.Point(528, 8)
            Me.label1.Name = "label1"
            Me.label1.Size = New System.Drawing.Size(115, 16)
            Me.label1.TabIndex = 3
            Me.label1.Text = "Embedded Thumbnail"
            ' 
            ' menuItem2
            ' 
            Me.menuItem2.Index = 4
            Me.menuItem2.Text = "-"
            ' 
            ' menuAddThumb
            ' 
            Me.menuAddThumb.Index = 5
            Me.menuAddThumb.Text = "Add Thumbnail"
            '			Me.menuAddThumb.Click += New System.EventHandler(Me.menuAddThumb_Click);
            ' 
            ' Form1
            ' 
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(736, 385)
            Me.Controls.Add(Me.label1)
            Me.Controls.Add(Me.lblImageInfo)
            Me.Controls.Add(Me.tabControl1)
            Me.Controls.Add(Me.panelImageBorder)
            Me.Menu = Me.mainMenu1
            Me.Name = "Form1"
            Me.Text = "Atalasoft dotImage Metadata Demo"
            Me.tabControl1.ResumeLayout(False)
            Me.tabExif.ResumeLayout(False)
            CType(Me.dataGrid, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tabCom.ResumeLayout(False)
            CType(Me.dataGridCom, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tabIptc.ResumeLayout(False)
            CType(Me.dataGridIptc, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tabTiff.ResumeLayout(False)
            CType(Me.dataGridTiff, System.ComponentModel.ISupportInitialize).EndInit()
            Me.tabXmp.ResumeLayout(False)
            Me.panelImageBorder.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
#End Region

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread>
        Shared Sub Main()
            Application.Run(New Form1())
        End Sub

        Private Sub menuOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuOpen.Click
            Dim openFile As OpenFileDialog = New OpenFileDialog()
            openFile.Filter = HelperMethods.CreateDialogFilter(True)

            ' try to locate images folder
            Dim imagesFolder As String = Application.ExecutablePath
            ' we assume we are running under the DotImage install folder
            Dim pos As Integer = imagesFolder.IndexOf("DotImage ")
            If pos <> -1 Then
                imagesFolder = imagesFolder.Substring(0, imagesFolder.IndexOf("\", pos)) & "\Images"
            End If

            'use this folder as starting point			
            openFile.InitialDirectory = imagesFolder

            ' Load the image metadata information from the file.
            If openFile.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                'set the last filename field
                Me._lastFileName = openFile.FileName

                'get image information without loading the image
                RegisteredDecoders.Decoders.Insert(0, New RawDecoder)
                Dim info As ImageInfo = RegisteredDecoders.GetImageInfo(openFile.FileName)

                'display the image information
                Me.lblImageInfo.Text = System.IO.Path.GetFileName(openFile.FileName) + Constants.vbLf + info.Size.Width.ToString() & " x " & info.Size.Height.ToString() & " pixels" & Constants.vbLf + info.ColorDepth.ToString() & " bpp"

                'clear the image
                Me.thumbnailView.Image = Nothing

                ' Load the data.
                LoadControls(openFile.FileName)

            End If

            openFile.Dispose()

        End Sub

        Private Sub menuSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuSave.Click
            ' Make sure there is something to save.
            If _tiffTags Is Nothing AndAlso _comTags Is Nothing AndAlso _iptcTags Is Nothing AndAlso _exifTags Is Nothing Then
                MessageBox.Show("There is no metadata to save.")
                Return
            End If

            Dim saveFile As SaveFileDialog = New SaveFileDialog()
            saveFile.Filter = "JPEG Image|*.jpg|PNG Image|*.png|TIFF Image|*.tif"
            saveFile.AddExtension = True

            If saveFile.ShowDialog() = System.Windows.Forms.DialogResult.OK Then

                'if the source image is a JPEG, then get all the JPEG APP Markers
                Dim markers As JpegMarkerCollection = Nothing
                If System.IO.Path.GetExtension(_lastFileName) = ".jpg" Then
                    markers = New JpegMarkerCollection(_lastFileName)
                End If

                Select Case saveFile.FilterIndex
                    Case 1
                        ' JPG
                        Dim jpg As JpegEncoder = New JpegEncoder()
                        'Add IPTC Data
                        jpg.IptcTags = _iptcTags
                        'Add COM Text Blocks
                        jpg.ComText = _comTags
                        'Add EXIF Data
                        If Not markers Is Nothing Then
                            'if the original image has an APP1 JPEG Marker, then remove it (we don't need 2 copies of the EXIF data)
                            For Each mark As JpegMarker In markers
                                If mark.Type = JpegMarkerTypes.MarkerApp1 Then
                                    markers.Remove(mark)
                                    Exit For
                                End If
                            Next mark
                        End If
                        'save all the original metadata in the jpeg (with the exception of EXIF we just removed)
                        jpg.AppMarkers = markers
                        'EXIF is almost always stored in the APP1 JPEG Marker
                        If Not _exifTags Is Nothing Then
                            If jpg.AppMarkers Is Nothing Then
                                jpg.AppMarkers = New JpegMarkerCollection()
                            End If
                            jpg.AppMarkers.Add(New JpegMarker(JpegMarkerTypes.MarkerApp1, _exifTags.ToExifCollection().ToByteArray()))
                        End If
                        If textXmp.Text.Length > 0 Then
                            jpg.Xmp = System.Text.Encoding.ASCII.GetBytes(textXmp.Text)
                        End If

                        If Not markers Is Nothing Then
                            'save metadata with original compressed JPEG image to prevent introducing lossy artifacts!!
                            jpg.CopyJpegWithNewMarkers(_lastFileName, saveFile.FileName)
                        Else
                            'original image was not a JPEG, we need to decode the image file
                            Dim jpegImage As AtalaImage = New AtalaImage(_lastFileName)
                            jpegImage.Save(saveFile.FileName, jpg, Nothing)
                            jpegImage.Dispose()
                        End If

                    Case 2
                        ' PNG ( only COM text can be saved to PNG )
                        'load the image
                        Dim pngImage As AtalaImage = New AtalaImage(_lastFileName)
                        Dim png As PngEncoder = New PngEncoder()
                        png.ComText = _comTags
                        pngImage.Save(saveFile.FileName, New PngEncoder(), Nothing)
                        pngImage.Dispose()

                    Case 3
                        'TIFF
                        If _lastFileName = saveFile.FileName Then
                            MessageBox.Show("Cannot overwrite existing TIFF file in this demo")
                        End If

                        'Save new TiffTags
                        Dim fs As FileStream = New FileStream(Me._lastFileName, FileMode.Open, FileAccess.Read, FileShare.Read)
                        Dim ofs As FileStream = New FileStream(saveFile.FileName, FileMode.Create, FileAccess.Write, FileShare.Write)

                        Dim theFile As TiffFile
                        If System.IO.Path.GetExtension(_lastFileName) = ".tif" Then
                            theFile = New TiffFile()
                            theFile.Read(fs)
                        Else
                            theFile = New TiffFile()
                            theFile.Images.Add(New TiffDirectory(New AtalaImage(_lastFileName), TiffCompression.Lzw))
                        End If
                        Dim theImg As TiffDirectory = theFile.Images(0)
                        If Not _exifTags Is Nothing Then
                            theImg.ExifTags = _exifTags.ToExifCollection()
                        End If
                        'save IPTC Tags to the RichTextIPTC tag
                        If Not _iptcTags Is Nothing AndAlso _iptcTags.Count > 0 Then
                            'save IPTC to the RichTIFFIPTC TIFF Tag, 33723
                            If _tiffTags Is Nothing Then
                                _tiffTags = New TiffTagExtendedCollection(New TiffTagCollection())
                            End If
                            _tiffTags.Add(New TiffTagExtended(New TiffTag(33723, _iptcTags.CreateIptcDataBlock(), TiffTagDataType.Byte)))
                            'remove any photoshop resources, as it can cause confusion for IPTC readers.  
                            For Each tag As TiffTagExtended In _tiffTags
                                If tag.ID = CInt(Fix(TiffTagID.Photoshop)) Then
                                    _tiffTags.Remove(tag)
                                    Exit For
                                End If
                            Next tag
                        End If
                        'save XMP data to the 
                        If Me.textXmp.Text.Length > 0 Then
                            _tiffTags.Add(New TiffTagExtended(New TiffTag(700, System.Text.Encoding.ASCII.GetBytes(textXmp.Text), TiffTagDataType.Byte)))
                        End If
                        'add the TIFF Tags back into the collection in case any changes have been made
                        If Not _tiffTags Is Nothing Then
                            theFile.Images(0).Tags.Clear()
                            For Each tt As TiffTag In _tiffTags
                                theFile.Images(0).Tags.Add(CType(tt, TiffTag))
                            Next tt
                        End If
                        theFile.Save(ofs)
                        fs.Close()
                        ofs.Close()
                End Select
            End If
            saveFile.Dispose()
        End Sub

        ''' <summary>
        ''' Clear all data from the form controls.
        ''' </summary>
        Private Sub LoadControls(ByVal fileName As String)
            Me.tabControl1.TabPages.Remove(tabExif)
            Me.tabControl1.TabPages.Remove(tabIptc)
            Me.tabControl1.TabPages.Remove(tabTiff)
            Me.tabControl1.TabPages.Remove(tabCom)
            Me.tabControl1.TabPages.Remove(tabXmp)

            If Not _exifTags Is Nothing Then
                _exifTags.Clear()
            End If
            If Not _iptcTags Is Nothing Then
                _iptcTags.Clear()
            End If
            If Not _comTags Is Nothing Then
                _comTags.Clear()
            End If
            If Not _tiffTags Is Nothing Then
                _tiffTags.Clear()
            End If

            Dim st As FileStream = New FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read)
            Dim dec As ImageDecoder = RegisteredDecoders.GetDecoder(st)


            Dim tp As Type = dec.GetType()

            Dim exifParse As ExifParser = New ExifParser()
            Dim tempTags As ExifCollection = exifParse.ParseFromImage(fileName)
            If Not tempTags Is Nothing AndAlso tempTags.Count > 0 Then
                If Not tempTags.ThumbnailStream Is Nothing Then
                    Me.thumbnailView.Image = New AtalaImage(tempTags.ThumbnailStream, Nothing)
                    tempTags.ThumbnailStream.Seek(0, SeekOrigin.Begin)
                End If
                Me.tabControl1.TabPages.Add(tabExif)
                'loop through each tag and replace the data with the string representation if it's an array (for display purposes)
                _exifTags = New ExifTagExtendedCollection(tempTags)
                dataGrid.DataSource = _exifTags
            End If


            Dim iptcParse As IptcParser = New IptcParser()
            _iptcTags = iptcParse.ParseFromImage(fileName)
            If Not _iptcTags Is Nothing AndAlso _iptcTags.Count > 0 Then
                Me.tabControl1.TabPages.Add(tabIptc)
                dataGridIptc.DataSource = _iptcTags
            End If

            If tp Is GetType(TiffDecoder) Then
                Me.tabControl1.TabPages.Add(tabTiff)
                Dim tifffile As TiffFile = New TiffFile()
                AddHandler tifffile.CodecError, AddressOf tifffile_CodecError
                'INSTANT VB NOTE: The following 'using' block is replaced by its pre-VB.NET 2005 equivalent:
                '				using (FileStream fs = New FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                Dim fs As FileStream = New FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read)
                Try
                    tifffile.Read(fs)

                    Dim tiffImg As TiffDirectory = tifffile.Images(0)
                    _tiffTags = New TiffTagExtendedCollection(tiffImg.Tags)

                    dataGridTiff.DataSource = _tiffTags
                Finally
                    CType(fs, IDisposable).Dispose()
                End Try
                'INSTANT VB NOTE: End of the original C# 'using' block
            End If

            Dim ComParse As ComTextParser = New ComTextParser()
            _comTags = ComParse.ParseFromImage(fileName)
            If Not _comTags Is Nothing AndAlso _comTags.Count > 0 Then
                Me.tabControl1.TabPages.Add(tabCom)
                dataGridCom.DataSource = _comTags
            End If

            Dim xmpParse As XmpParser = New XmpParser()
            Dim xml As System.Xml.XmlDocument = CType(xmpParse.ParseFromImage(fileName), System.Xml.XmlDocument)
            If Not xml Is Nothing Then
                Me.tabControl1.TabPages.Add(tabXmp)
                Dim sw As StringWriter = New StringWriter()
                Dim xmlWrite As System.Xml.XmlTextWriter = New System.Xml.XmlTextWriter(sw)
                xmlWrite.Formatting = System.Xml.Formatting.Indented
                xml.WriteContentTo(xmlWrite)
                Me.textXmp.Text = sw.ToString()
            Else
                Me.textXmp.Text = ""
            End If

        End Sub

        Private Sub menuAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAbout.Click
            Dim aboutBox As AtalaDemos.AboutBox.About = New AtalaDemos.AboutBox.About("About Atalasoft DotImage Metadata Demo", "DotImage Metadata Demo")
            aboutBox.Description = "Demonstrates how to view, edit, and save metadata in image JPEG, TIFF, RAW, and PNG image files.  It includes code that preserves as much metadata as possible when re-saving an image as a TIFF or JPEG.  The TiffFile class gives the ability to view and edit tiff image metadata without the need to open the image into memory and demonstrates working with arbitrary TIFF tags by embedding an image into the tiff tag.  Also demonstrates lossless JPEG features to edit metadata within a JPEG without adding lossy compression artifacts.  These features requires a license of DotImage Photo Pro."
            aboutBox.ShowDialog()
        End Sub

        Private Sub menuExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuExit.Click
            ' Exit
            Me.Close()
        End Sub


#Region "Com code"

        Private Sub menuComClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuComClear.Click
            Me.tabControl1.TabPages.Remove(tabCom)
            If _comTags Is Nothing Then
                Return
            End If
            _comTags.Clear()
            dataGridCom.DataSource = Nothing
            dataGridCom.DataSource = _comTags
        End Sub

        Private Sub menuComAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuComAdd.Click
            ' Also make sure the ComTextCollection has been created.
            If _comTags Is Nothing OrElse _comTags.Count = 0 Then
                _comTags = New ComTextCollection()
                Me.tabControl1.TabPages.Add(tabCom)
            End If

            Dim tag As ComTextTag = New ComTextTag()
            Dim edit As MetadataEdit = New MetadataEdit()
            edit.LoadObject(tag)

            If edit.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                ' Add the tag to the collection and listview.
                _comTags.Add(tag)
            End If

            edit.Dispose()

            dataGridCom.DataSource = Nothing
            dataGridCom.DataSource = _comTags
        End Sub

        Private Sub menuComRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuComRemove.Click
            If _comTags Is Nothing Then
                Return
            End If
            If dataGridCom.CurrentRowIndex = -1 Then
                Return
            End If

            ' Remove it from the collection.
            _comTags.RemoveAt(dataGridCom.CurrentRowIndex)
            dataGridCom.DataSource = Nothing
            dataGridCom.DataSource = _comTags
        End Sub

#End Region

#Region "Iptc Code"

        Private Sub menuIptcAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuIptcAdd.Click

            ' Also make sure the IptcCollection has been created.
            If _iptcTags Is Nothing OrElse _iptcTags.Count = 0 Then
                _iptcTags = New IptcCollection()
                Me.tabControl1.TabPages.Add(tabIptc)
            End If

            Dim tag As IptcTag = New IptcTag(2, 0, 0, "")
            Dim edit As MetadataEdit = New MetadataEdit()
            edit.LoadObject(tag)

            If edit.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                ' Add the tag to the collection and listview.
                _iptcTags.Add(tag)
            End If

            edit.Dispose()

            dataGridIptc.DataSource = Nothing
            dataGridIptc.DataSource = _iptcTags
        End Sub
        Private Sub mnuIptcRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles mnuIptcRemove.Click
            If dataGridIptc.CurrentRowIndex > -1 Then
                _iptcTags.RemoveAt(dataGridIptc.CurrentRowIndex)
                dataGridIptc.DataSource = Nothing
                dataGridIptc.DataSource = _iptcTags
            End If


        End Sub

        Private Sub menuIptcClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuIptcClear.Click
            Me.tabControl1.TabPages.Remove(tabIptc)
            _iptcTags.Clear()
            dataGridIptc.DataSource = Nothing
            dataGridIptc.DataSource = _iptcTags
        End Sub

#End Region

#Region "TIFF Code"

        Private Sub menuTiffClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuTiffClear.Click
            Me.tabControl1.TabPages.Remove(tabTiff)
            If Not _tiffTags Is Nothing Then
                _tiffTags.Clear()
            End If
            dataGridTiff.DataSource = Nothing
            dataGridTiff.DataSource = _tiffTags
        End Sub


        Private Sub menuTiffRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuTiffRemove.Click
            If _tiffTags Is Nothing OrElse dataGridTiff.CurrentRowIndex = -1 Then
                Return
            End If

            ' Remove from the listview
            _tiffTags.RemoveAt(dataGridTiff.CurrentRowIndex)
            dataGridTiff.DataSource = Nothing
            dataGridTiff.DataSource = _tiffTags

        End Sub


        Private Sub menuTiffAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuTiffAdd.Click, menuAddTagAscii.Click
            If _tiffTags Is Nothing Then
                _tiffTags = New TiffTagExtendedCollection(New TiffTagCollection())
                Me.tabControl1.TabPages.Add(tabTiff)
            End If

            ' Display custom tag dialog
            Dim ct As CustomTag = New CustomTag()
            Dim mnu As MenuItem = CType(sender, MenuItem)

            If mnu.Text = "Image (Binary)" Then
                ct.Label = "Browse for Image"
                ct.BrowseVisible = True
            Else
                ct.Label = "Tag Data"
                ct.BrowseVisible = False
            End If

            Dim tag As TiffTag
            If ct.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim tagID As Integer = Integer.Parse(ct.ID.Text)

                If mnu.Text = "Image (Binary)" Then
                    ' encode image data to be temporarily stored in list view.
                    tag = New TiffTag(tagID, New AtalaImage(ct.Data.Text).ToByteArray(New BmpEncoder()), TiffTagDataType.Byte)
                    'add to tiff tag collection
                Else
                    tag = New TiffTag(tagID, ct.Data.Text, TiffTagDataType.Ascii)
                End If
                _tiffTags.Add(New TiffTagExtended(tag))
            End If
            ct.Dispose()

            dataGridTiff.DataSource = Nothing
            dataGridTiff.DataSource = _tiffTags

        End Sub

        Private Sub menuTiffViewBinary_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuTiffViewBinary.Click
            ' If the TiffTag is image data encoded as 64bitString, then display it.
            Try
                Dim img As AtalaImage = AtalaImage.FromByteArray(CType(_tiffTags(dataGridTiff.CurrentRowIndex).Data, Byte()), Nothing)

                'display the image in a new window
                Dim pv As PicView = New PicView(img)
                pv.ShowDialog()
                pv.Dispose()
            Catch e1 As Exception
                MessageBox.Show("Error reading binary image")
            End Try
        End Sub


        Private Sub tifffile_CodecError(ByVal sender As Object, ByVal e As CodecErrorEventArgs)
            MessageBox.Show(Me, e.Description, "TIFF File Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Sub

#End Region

#Region "EXIF Code"

        Private Sub menuExifClear_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuExifClear.Click
            Me.tabControl1.TabPages.Remove(tabExif)
            _exifTags = Nothing
            dataGrid.DataSource = Nothing
            dataGrid.DataSource = _exifTags
        End Sub

        Private Sub menuExifRemove_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuExifRemove.Click
            If _exifTags Is Nothing OrElse dataGrid.CurrentRowIndex = -1 Then
                Return
            End If

            ' Remove from the listview
            _exifTags.RemoveAt(dataGrid.CurrentRowIndex)
            dataGridTiff.DataSource = Nothing
            dataGridTiff.DataSource = _exifTags
        End Sub

        Private Sub menuExifAdd_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuExifAdd.Click
            If _exifTags Is Nothing Then
                _exifTags = New ExifTagExtendedCollection(New ExifCollection())
                Me.tabControl1.TabPages.Add(tabExif)
            End If

            ' Display custom tag dialog
            Dim ct As CustomTag = New CustomTag()
            ct.cmbIFD.Visible = True
            ct.lblIFD.Visible = True
            Dim tag As ExifTag
            If ct.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                Dim tagID As Integer = Integer.Parse(ct.ID.Text)
                tag = New ExifTag(tagID, CType(System.Enum.Parse(GetType(ExifTagIfd), ct.cmbIFD.Text), ExifTagIfd), ct.Data.Text, TiffTagDataType.Ascii)
                _exifTags.Add(New ExifTagExtended(tag))
            End If
            ct.Dispose()

            dataGrid.DataSource = Nothing
            dataGrid.DataSource = _exifTags
        End Sub

        Private Sub menuAddThumb_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuAddThumb.Click
            Dim fd As OpenFileDialog = New OpenFileDialog()
            If fd.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                If _exifTags Is Nothing Then
                    _exifTags = New ExifTagExtendedCollection()
                End If
                Dim thumb As Atalasoft.Imaging.ImageProcessing.Thumbnail = New Atalasoft.Imaging.ImageProcessing.Thumbnail(New Size(96, 96))
                Dim img As AtalaImage = thumb.Create(fd.FileName, 0)
                Dim ms As MemoryStream = New MemoryStream(img.ToByteArray(New JpegEncoder(), Nothing))
                _exifTags.ThumbnailStream = ms
                Me.thumbnailView.Image = img
            End If

        End Sub

#End Region

#Region "Helper Classes"
        'These helper classes let us display Array data.  Otherwise, the output is just System.Byte[], System.UInt32[], etc..
        Public Class ExifTagExtended
            Inherits ExifTag
            Public Sub New(ByVal tag As ExifTag)
                MyBase.New(tag.ID, tag.Ifd, tag.Data, tag.Type)

            End Sub

            Public Property DataString() As String
                Get
                    Dim data As String = ""
                    If MyBase.Data.GetType().IsArray Then
                        Dim ar As System.Array = CType(MyBase.Data, System.Array)
                        Dim maxlen As Integer = Convert.ToInt32(Math.Min(ar.Length, 8))
                        For i As Integer = 0 To maxlen - 1
                            data &= ar.GetValue(i).ToString()
                            If i <> maxlen - 1 Then
                                data &= ", "
                            End If
                        Next i
                        If ar.Length > 8 Then
                            data &= "..."
                        End If
                    Else
                        Dim dt As String = MyBase.ToString()
                        data = dt.Substring(dt.IndexOf(":", 0) + 2)
                    End If
                    Return data
                End Get
                Set
                    If MyBase.Data.GetType().IsArray Then
                        Throw New NotImplementedException("This demo does not implement editing of array tag items.")
                    Else
                        MyBase.Data = Value
                    End If
                End Set
            End Property
        End Class


        Public Class ExifTagExtendedCollection
            Inherits CollectionBase
            Public Sub New()
                _exifCol = New ExifCollection()
            End Sub
            Private _exifCol As ExifCollection = Nothing
            Public Sub New(ByVal exifCol As ExifCollection)
                _exifCol = exifCol
                For Each tag As ExifTag In exifCol
                    MyBase.InnerList.Add(New ExifTagExtended(tag))
                Next tag
            End Sub
            Default Public ReadOnly Property Item(ByVal index As Integer) As ExifTagExtended
                Get
                    Return CType(MyBase.InnerList(index), ExifTagExtended)
                End Get
            End Property

            Public Sub CopyTo(ByVal tags As ExifTagExtended(), ByVal index As Integer)
                For i As Integer = index To Me.Count - 1
                    tags(i) = CType(MyBase.InnerList(i + index), ExifTagExtended)
                Next i
            End Sub

            Public Sub Add(ByVal tag As ExifTagExtended)
                MyBase.InnerList.Add(tag)
            End Sub

            Public Sub Remove(ByVal tag As ExifTagExtended)
                MyBase.InnerList.Remove(tag)
            End Sub

            Public Function IndexOf(ByVal tag As ExifTagExtended) As Integer
                Return MyBase.InnerList.IndexOf(tag)
            End Function

            Public Sub Insert(ByVal index As Integer, ByVal source As ExifTagExtended)
                MyBase.InnerList.Insert(index, source)
            End Sub

            Public Function Contains(ByVal source As ExifTagExtended) As Boolean
                Return MyBase.InnerList.Contains(source)
            End Function

            Public Property ThumbnailStream() As Stream
                Get
                    Return _exifCol.ThumbnailStream
                End Get
                Set
                    _exifCol.ThumbnailStream = Value
                End Set
            End Property

            Public Function ToExifCollection() As ExifCollection
                Dim exif As ExifCollection = New ExifCollection()
                For Each tag As ExifTagExtended In Me
                    exif.Add(tag)
                Next tag
                exif.MakernoteHeader = _exifCol.MakernoteHeader
                exif.ThumbnailStream = _exifCol.ThumbnailStream
                Return exif
            End Function
        End Class

        Public Class TiffTagExtended
            Inherits TiffTag
            Public Sub New(ByVal tag As TiffTag)
                MyBase.New(tag.ID, tag.Data, tag.Type)

            End Sub

            Public ReadOnly Property TagDescription() As String
                Get
                    'find english string from ID
                    If System.Enum.IsDefined(GetType(TiffTagID), MyBase.ID) Then
                        Return (CType(MyBase.ID, TiffTagID)).ToString()
                    Else
                        Return MyBase.ID.ToString(System.Globalization.CultureInfo.InvariantCulture)
                    End If
                End Get
            End Property

            Public Property DataString() As String
                Get
                    Dim data As String = ""
                    If MyBase.Data.GetType().IsArray Then
                        Dim ar As System.Array = CType(MyBase.Data, System.Array)
                        Dim maxlen As Integer = Convert.ToInt32(Math.Min(ar.Length, 8))
                        For i As Integer = 0 To maxlen - 1
                            data &= ar.GetValue(i).ToString()
                            If i <> maxlen - 1 Then
                                data &= ", "
                            End If
                        Next i
                        If ar.Length > 8 Then
                            data &= "..."
                        End If
                    Else
                        data = MyBase.Data.ToString()
                    End If

                    Return data
                End Get
                Set
                    If MyBase.Data.GetType().IsArray Then
                        Throw New NotImplementedException("This demo does not implement editing of array tag items.")
                    Else
                        MyBase.Data = Value
                    End If
                End Set
            End Property
        End Class


        Public Class TiffTagExtendedCollection
            Inherits CollectionBase
            Public Sub New()
            End Sub
            Public Sub New(ByVal tags As TiffTagCollection)
                For Each tag As TiffTag In tags
                    MyBase.InnerList.Add(New TiffTagExtended(tag))
                Next tag
            End Sub

            Default Public ReadOnly Property Item(ByVal index As Integer) As TiffTagExtended
                Get
                    Return CType(MyBase.InnerList(index), TiffTagExtended)
                End Get
            End Property

            Public Sub CopyTo(ByVal tags As TiffTagExtended(), ByVal index As Integer)
                For i As Integer = index To Me.Count - 1
                    tags(i) = CType(MyBase.InnerList(i + index), TiffTagExtended)
                Next i
            End Sub

            Public Sub Add(ByVal tag As TiffTagExtended)
                MyBase.InnerList.Add(tag)
            End Sub

            Public Sub Remove(ByVal tag As TiffTagExtended)
                MyBase.InnerList.Remove(tag)
            End Sub

            Public Function IndexOf(ByVal tag As TiffTagExtended) As Integer
                Return MyBase.InnerList.IndexOf(tag)
            End Function

            Public Sub Insert(ByVal index As Integer, ByVal source As TiffTagExtended)
                MyBase.InnerList.Insert(index, source)
            End Sub

            Public Function Contains(ByVal source As TiffTagExtended) As Boolean
                Return MyBase.InnerList.Contains(source)
            End Function
        End Class
#End Region

    End Class
End Namespace
