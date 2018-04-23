Imports Microsoft.VisualBasic
Imports DevExpress.Xpf.Mvvm
Imports DevExpress.Xpf.Mvvm.UI
Imports DevExpress.Xpf.WindowsUI.Navigation
Imports System
Imports System.Collections.Generic
Imports System.Collections.ObjectModel
Imports System.ComponentModel.Composition
Imports System.ComponentModel.Composition.Hosting
Imports System.Linq
Imports System.Reflection
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Input
Imports MeffedNavigationService.Infrastructure.DataModel
Imports MeffedNavigationService.Infrastructure.Contract

Namespace MeffedNavigationService.ViewModel
	Public Class MenuViewModel
		Inherits ViewModel
		Private _items As IEnumerable(Of MenuDataItem)
		<ImportMany> _
		Private _views As IEnumerable(Of Lazy(Of IModule, IModuleMetadata))
		Public Sub New()
			Items = Nothing
			Me.InitializeCommands()
		End Sub
		Private privateAddOnModuleListing As IEnumerable(Of Lazy(Of IModuleListing))
		<ImportMany(GetType(IModuleListing))> _
		Private Property AddOnModuleListing() As IEnumerable(Of Lazy(Of IModuleListing))
			Get
				Return privateAddOnModuleListing
			End Get
			Set(ByVal value As IEnumerable(Of Lazy(Of IModuleListing)))
				privateAddOnModuleListing = value
			End Set
		End Property
		Public Property Items() As IEnumerable(Of MenuDataItem)
			Get
				Return _items
			End Get
			Private Set(ByVal value As IEnumerable(Of MenuDataItem))
				Me.SetProperty(Of IEnumerable(Of MenuDataItem))(Me._items, value, "Items")
			End Set
		End Property
		Public ReadOnly Property Views() As IEnumerable(Of Lazy(Of IModule, IModuleMetadata))
			Get
				Return Me._views
			End Get
		End Property
		Private privateNavigationCommand As ICommand
		Public Property NavigationCommand() As ICommand
			Get
				Return privateNavigationCommand
			End Get
			Private Set(ByVal value As ICommand)
				privateNavigationCommand = value
			End Set
		End Property
		Public Sub LoadState(ByVal navigationParameter As Object)
			Items = New ObservableCollection(Of MenuDataItem)(SampleMenuDataSource.Instance.Items)
			' Load Module Listings.
			MeffedNavigationService.MEF.CompositionContainerHelper.ComposeParts(Me, New DirectoryCatalog("."))
			For Each addOnModule As Lazy(Of IModuleListing) In AddOnModuleListing
				For Each menuItem As MenuDataItem In addOnModule.Value.MenuItems
					CType(Items, ObservableCollection(Of MenuDataItem)).Add(menuItem)
				Next menuItem
			Next addOnModule
		End Sub
		Protected Overrides Sub OnNavigatedTo(ByVal e As NavigationEventArgs)
			LoadState(e.Parameter)
		End Sub
		Private Sub InitializeCommands()
			Me.NavigationCommand = New DelegateCommand(Of MenuDataItem)(AddressOf DoNavigation)
		End Sub
		Private Sub DoNavigation(ByVal [module] As MenuDataItem)
			NavigationService.Navigate([module].ModuleType.ToString())
		End Sub
	End Class
End Namespace