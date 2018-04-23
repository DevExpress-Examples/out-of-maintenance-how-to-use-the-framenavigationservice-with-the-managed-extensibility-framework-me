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

Namespace MeffedNavigationService.ModuleB.View
	''' <summary>
	''' Interaction logic for ViewA1.xaml
	''' </summary>
	<ExportView(ModuleType := ModuleTypes.ViewOrders)> _
	Partial Public Class OrdersView
		Inherits UserControl
		Implements IModule
		Public Sub New()
			InitializeComponent()
		End Sub
	End Class
End Namespace
