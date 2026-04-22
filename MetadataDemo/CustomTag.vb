Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Namespace MetadataDemo
	''' <summary>
	''' Summary description for CustomTag.
	''' </summary>
	Public Class CustomTag
		Inherits System.Windows.Forms.Form
		Public WithEvents ID As System.Windows.Forms.TextBox
		Public Data As System.Windows.Forms.TextBox
		Private label1 As System.Windows.Forms.Label
		Private OKbutton As System.Windows.Forms.Button
		Private openFileDialog1 As System.Windows.Forms.OpenFileDialog
		Private CancelBtn As System.Windows.Forms.Button
		Private lblData As System.Windows.Forms.Label
		Private WithEvents btnLoadImage As System.Windows.Forms.Button
		Public cmbIFD As System.Windows.Forms.ComboBox
		Public lblIFD As System.Windows.Forms.Label
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()


			Me.cmbIFD.DataSource = System.Enum.GetValues(GetType(Atalasoft.Imaging.Metadata.ExifTagIfd))

			'
			' TODO: Add any constructor code after InitializeComponent call
			'
		End Sub

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		Protected Overrides Overloads Sub Dispose(ByVal disposing As Boolean)
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
			Me.ID = New System.Windows.Forms.TextBox()
			Me.Data = New System.Windows.Forms.TextBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.lblData = New System.Windows.Forms.Label()
			Me.btnLoadImage = New System.Windows.Forms.Button()
			Me.OKbutton = New System.Windows.Forms.Button()
			Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
			Me.CancelBtn = New System.Windows.Forms.Button()
			Me.cmbIFD = New System.Windows.Forms.ComboBox()
			Me.lblIFD = New System.Windows.Forms.Label()
			Me.SuspendLayout()
			' 
			' ID
			' 
			Me.ID.Location = New System.Drawing.Point(88, 24)
			Me.ID.Name = "ID"
			Me.ID.Size = New System.Drawing.Size(184, 20)
			Me.ID.TabIndex = 0
			Me.ID.Text = ""
'			Me.ID.Validating += New System.ComponentModel.CancelEventHandler(Me.ID_Validating);
			' 
			' Data
			' 
			Me.Data.Location = New System.Drawing.Point(88, 64)
			Me.Data.Name = "Data"
			Me.Data.Size = New System.Drawing.Size(320, 20)
			Me.Data.TabIndex = 1
			Me.Data.Text = ""
			' 
			' label1
			' 
			Me.label1.Location = New System.Drawing.Point(16, 24)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(48, 23)
			Me.label1.TabIndex = 2
			Me.label1.Text = "Tag ID:"
			' 
			' lblData
			' 
			Me.lblData.AutoSize = True
			Me.lblData.Location = New System.Drawing.Point(16, 64)
			Me.lblData.Name = "lblData"
			Me.lblData.Size = New System.Drawing.Size(31, 16)
			Me.lblData.TabIndex = 3
			Me.lblData.Text = "Data:"
			' 
			' btnLoadImage
			' 
			Me.btnLoadImage.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnLoadImage.Location = New System.Drawing.Point(424, 64)
			Me.btnLoadImage.Name = "btnLoadImage"
			Me.btnLoadImage.TabIndex = 4
			Me.btnLoadImage.Text = "Browse ..."
			Me.btnLoadImage.Visible = False
'			Me.btnLoadImage.Click += New System.EventHandler(Me.button1_Click);
			' 
			' OKbutton
			' 
			Me.OKbutton.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.OKbutton.Location = New System.Drawing.Point(128, 96)
			Me.OKbutton.Name = "OKbutton"
			Me.OKbutton.TabIndex = 5
			Me.OKbutton.Text = "OK"
			' 
			' CancelBtn
			' 
			Me.CancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.CancelBtn.Location = New System.Drawing.Point(248, 96)
			Me.CancelBtn.Name = "CancelBtn"
			Me.CancelBtn.TabIndex = 6
			Me.CancelBtn.Text = "Cancel"
			' 
			' cmbIFD
			' 
			Me.cmbIFD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
			Me.cmbIFD.Location = New System.Drawing.Point(336, 24)
			Me.cmbIFD.Name = "cmbIFD"
			Me.cmbIFD.Size = New System.Drawing.Size(121, 21)
			Me.cmbIFD.TabIndex = 7
			Me.cmbIFD.Visible = False
			' 
			' lblIFD
			' 
			Me.lblIFD.AutoSize = True
			Me.lblIFD.Location = New System.Drawing.Point(304, 24)
			Me.lblIFD.Name = "lblIFD"
			Me.lblIFD.Size = New System.Drawing.Size(22, 16)
			Me.lblIFD.TabIndex = 8
			Me.lblIFD.Text = "IFD"
			Me.lblIFD.Visible = False
			' 
			' CustomTag
			' 
			Me.AcceptButton = Me.OKbutton
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.CancelButton = Me.CancelBtn
			Me.ClientSize = New System.Drawing.Size(512, 134)
			Me.Controls.Add(Me.lblIFD)
			Me.Controls.Add(Me.cmbIFD)
			Me.Controls.Add(Me.CancelBtn)
			Me.Controls.Add(Me.OKbutton)
			Me.Controls.Add(Me.btnLoadImage)
			Me.Controls.Add(Me.lblData)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.Data)
			Me.Controls.Add(Me.ID)
			Me.MaximizeBox = False
			Me.MinimizeBox = False
			Me.Name = "CustomTag"
			Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Create Custom Tag"
'			Me.Closing += New System.ComponentModel.CancelEventHandler(Me.CustomTag_Closing);
			Me.ResumeLayout(False)

		End Sub
		#End Region

		Private Sub button1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnLoadImage.Click
			If Me.openFileDialog1.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				Me.Data.Text = Me.openFileDialog1.FileName
				Me.DialogResult = System.Windows.Forms.DialogResult.OK
			End If
		End Sub

		Private Sub CustomTag_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
			If (Me.Data.Text = "" OrElse Me.ID.Text = "") AndAlso Me.DialogResult = System.Windows.Forms.DialogResult.OK Then
				e.Cancel = True
			End If
		End Sub

		Private Sub ID_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ID.Validating

		End Sub

		Public Property Label() As String
			Get
				Return Me.lblData.Text
			End Get
			Set
				Me.lblData.Text = Value
			End Set
		End Property

		Public Property BrowseVisible() As Boolean
			Get
				Return Me.btnLoadImage.Visible
			End Get
			Set
				Me.btnLoadImage.Visible = Value
			End Set
		End Property

	End Class
End Namespace
