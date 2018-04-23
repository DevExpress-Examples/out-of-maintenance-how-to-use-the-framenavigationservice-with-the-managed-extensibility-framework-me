Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Navigation
Imports System.Windows.Shapes
Imports MeffedNavigationService.Infrastructure.Contract
Imports MeffedNavigationService.Infrastructure.Enums

Namespace MeffedNavigationService.View
	''' <summary>
	''' Interaction logic for MenuPage.xaml
	''' </summary>
	<ExportView(ModuleType := ModuleTypes.MenuPage)> _
	Partial Public Class MenuPage
		Inherits UserControl
		Implements IModule
		Public Sub New()
			InitializeComponent()
		End Sub

		#Region "IModule Members"

		Public ReadOnly Property ModuleURI() As String
			Get
				Throw New NotImplementedException()
			End Get
		End Property

		#End Region
	End Class
End Namespace
