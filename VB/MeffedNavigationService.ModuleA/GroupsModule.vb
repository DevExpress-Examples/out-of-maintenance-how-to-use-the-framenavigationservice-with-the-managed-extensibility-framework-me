Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports MeffedNavigationService.Infrastructure.Contract
Imports MeffedNavigationService.Infrastructure.DataModel
Imports MeffedNavigationService.Infrastructure.Enums

Namespace MeffedNavigationService.ModuleA
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
			MenuItems.Add(New MenuDataItem("Activities", ModuleTypes.ViewActivities, "General", True))
			MenuItems.Add(New MenuDataItem("Opportunities", ModuleTypes.ViewOpportunities))
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
