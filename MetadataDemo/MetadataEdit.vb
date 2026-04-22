Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Namespace MetadataDemo
	''' <summary>
	''' Summary description for MetadataEdit.
	''' </summary>
	Public Class MetadataEdit
		Inherits System.Windows.Forms.Form
		Private propertyGrid1 As System.Windows.Forms.PropertyGrid
		Private btnOK As System.Windows.Forms.Button
		Private btnCancel As System.Windows.Forms.Button
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New()
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()

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
			Me.propertyGrid1 = New System.Windows.Forms.PropertyGrid()
			Me.btnOK = New System.Windows.Forms.Button()
			Me.btnCancel = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' propertyGrid1
			' 
			Me.propertyGrid1.CommandsVisibleIfAvailable = True
			Me.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Top
			Me.propertyGrid1.HelpVisible = False
			Me.propertyGrid1.LargeButtons = False
			Me.propertyGrid1.LineColor = System.Drawing.SystemColors.ScrollBar
			Me.propertyGrid1.Name = "propertyGrid1"
			Me.propertyGrid1.PropertySort = System.Windows.Forms.PropertySort.Alphabetical
			Me.propertyGrid1.Size = New System.Drawing.Size(334, 112)
			Me.propertyGrid1.TabIndex = 0
			Me.propertyGrid1.Text = "propertyGrid1"
			Me.propertyGrid1.ToolbarVisible = False
			Me.propertyGrid1.ViewBackColor = System.Drawing.SystemColors.Window
			Me.propertyGrid1.ViewForeColor = System.Drawing.SystemColors.WindowText
			' 
			' btnOK
			' 
			Me.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK
			Me.btnOK.Location = New System.Drawing.Point(31, 133)
			Me.btnOK.Name = "btnOK"
			Me.btnOK.Size = New System.Drawing.Size(108, 29)
			Me.btnOK.TabIndex = 1
			Me.btnOK.Text = "&OK"
			' 
			' btnCancel
			' 
			Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.btnCancel.Location = New System.Drawing.Point(196, 133)
			Me.btnCancel.Name = "btnCancel"
			Me.btnCancel.Size = New System.Drawing.Size(108, 29)
			Me.btnCancel.TabIndex = 2
			Me.btnCancel.Text = "&Cancel"
			' 
			' MetadataEdit
			' 
			Me.AcceptButton = Me.btnOK
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.CancelButton = Me.btnCancel
			Me.ClientSize = New System.Drawing.Size(334, 178)
			Me.Controls.AddRange(New System.Windows.Forms.Control() { Me.btnCancel, Me.btnOK, Me.propertyGrid1})
			Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
			Me.Name = "MetadataEdit"
			Me.ShowInTaskbar = False
			Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
			Me.Text = "Metadata Editor"
			Me.ResumeLayout(False)

		End Sub
		#End Region


		Public Sub LoadObject(ByVal metadataTag As Object)
			Me.propertyGrid1.SelectedObject = metadataTag
		End Sub

	End Class
End Namespace
