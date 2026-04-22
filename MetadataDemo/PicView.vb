Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Namespace MetadataDemo
	''' <summary>
	''' Summary description for PicView.
	''' </summary>
	Public Class PicView
		Inherits System.Windows.Forms.Form
		Public workspaceViewer1 As Atalasoft.Imaging.WinControls.WorkspaceViewer
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.Container = Nothing

		Public Sub New(ByVal image As Atalasoft.Imaging.AtalaImage)
			'
			' Required for Windows Form Designer support
			'
			InitializeComponent()

			'
			' TODO: Add any constructor code after InitializeComponent call
			'
			Me.workspaceViewer1.Image = image
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
			Me.workspaceViewer1 = New Atalasoft.Imaging.WinControls.WorkspaceViewer()
			Me.SuspendLayout()
			' 
			' workspaceViewer1
			' 
			Me.workspaceViewer1.DisplayProfile = Nothing
			Me.workspaceViewer1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.workspaceViewer1.Location = New System.Drawing.Point(0, 0)
			Me.workspaceViewer1.Magnifier.BackColor = System.Drawing.Color.White
			Me.workspaceViewer1.Magnifier.BorderColor = System.Drawing.Color.Black
			Me.workspaceViewer1.Magnifier.Size = New System.Drawing.Size(100, 100)
			Me.workspaceViewer1.Name = "workspaceViewer1"
			Me.workspaceViewer1.OutputProfile = Nothing
			Me.workspaceViewer1.Selection = Nothing
			Me.workspaceViewer1.Size = New System.Drawing.Size(292, 266)
			Me.workspaceViewer1.TabIndex = 0
			Me.workspaceViewer1.Text = "workspaceViewer1"
			' 
			' PicView
			' 
			Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
			Me.ClientSize = New System.Drawing.Size(292, 266)
			Me.Controls.Add(Me.workspaceViewer1)
			Me.Name = "PicView"
			Me.Text = "PicView"
			Me.ResumeLayout(False)

		End Sub
		#End Region
	End Class
End Namespace
