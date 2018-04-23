Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports MeffedNavigationService.Infrastructure.Contract
Imports MeffedNavigationService.Infrastructure.DataModel
Imports MeffedNavigationService.Infrastructure.Enums

Namespace MeffedNavigationService.ModuleB
	Public Class GroupsModule
		Implements IModuleListing
		Private _menuItems As List(Of MenuDataItem)
		''' <summary>
		''' Initializes a new instance of the GroupsModule class.
		''' </summary>
		''' <param name="menuItems"></param>
		Public Sub New()
			_menuItems = New List(Of MenuDataItem)()
			Me.InitializeGroupsModule()
		End Sub
		Public ReadOnly Property MenuItems() As List(Of MenuDataItem)
			Get
				Return Me._menuItems
			End Get
		End Property
		Private Sub InitializeGroupsModule()
			MenuItems.Add(New MenuDataItem("Products", ModuleTypes.ViewProducts, "Opportunities", True))
			MenuItems.Add(New MenuDataItem("Orders", ModuleTypes.ViewOrders))
			MenuItems.Add(New MenuDataItem("Quotes", ModuleTypes.ViewQuotes))
			MenuItems.Add(New MenuDataItem("Invoices", ModuleTypes.ViewInvoices))
		End Sub
		#Region "IModuleListing Members"
		Private ReadOnly Property IModuleListing_MenuItems() As IEnumerable(Of MenuDataItem) Implements IModuleListing.MenuItems
			Get
				Return Me.MenuItems
			End Get
		End Property
		#End Region
	End Class
End Namespace
