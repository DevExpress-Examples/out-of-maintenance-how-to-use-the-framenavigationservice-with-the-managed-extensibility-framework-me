Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.ObjectModel
Imports System.Linq
Imports DevExpress.Xpf.Mvvm

Namespace MeffedNavigationService.Infrastructure.DataModel
	Public Class MenuDataItem
		Inherits ViewModelBase
		Private _uniqueID As Integer
		Private _groupHeader As String
		Private _title As String
		Private _isFlowBreak As Boolean
		Private _moduleType As MeffedNavigationService.Infrastructure.Enums.ModuleTypes
		Private Shared idCount As Integer = 0
		''' <summary>
		''' Initializes a new instance of the MenuDataItem class.
		''' </summary>
		''' <param name="uniqueId">The unique id.</param>
		''' <param name="title">The title.</param>
		''' <param name="groupHeader">The group header.</param>
		Public Sub New(ByVal title As String, ByVal moduleType As MeffedNavigationService.Infrastructure.Enums.ModuleTypes, ByVal groupHeader As String, ByVal isFlowBreak As Boolean)
			Me.ModuleType = moduleType
			Me.IsFlowBreak = isFlowBreak
			UniqueID = idCount
			idCount += 1
			Me.GroupHeader = groupHeader
			Me.Title = title
		End Sub
		''' <summary>
		''' Initializes a new instance of the MenuDataItem class.
		''' </summary>
		''' <param name="uniqueId">The unique id.</param>
		''' <param name="title">The title.</param>
		Public Sub New(ByVal title As String, ByVal moduleType As MeffedNavigationService.Infrastructure.Enums.ModuleTypes)
			Me.New(title, moduleType, String.Empty, False)
		End Sub
		Public Property UniqueID() As Integer
			Get
				Return _uniqueID
			End Get
			Private Set(ByVal value As Integer)
				Me.SetProperty(Me._uniqueID, value, "UniqueID")
			End Set
		End Property
		Public Property ModuleType() As MeffedNavigationService.Infrastructure.Enums.ModuleTypes
			Get
				Return _moduleType
			End Get
			Set(ByVal value As MeffedNavigationService.Infrastructure.Enums.ModuleTypes)
				Me.SetProperty(Me._moduleType, value, "ModuleType")
			End Set
		End Property
		Public Property IsFlowBreak() As Boolean
			Get
				Return _isFlowBreak
			End Get
			Set(ByVal value As Boolean)
				Me.SetProperty(Me._isFlowBreak, value, "IsFlowBreak")
			End Set
		End Property
		Public Property GroupHeader() As String
			Get
				Return _groupHeader
			End Get
			Set(ByVal value As String)
				Me.SetProperty(Me._groupHeader, value, "GroupHeader")
			End Set
		End Property
		Public Property Title() As String
			Get
				Return _title
			End Get
			Set(ByVal value As String)
				Me.SetProperty(Me._title, value, "Title")
			End Set
		End Property
		Public Overrides Function ToString() As String
			Return Me.Title
		End Function
	End Class
	Public NotInheritable Class SampleMenuDataSource
		Public Shared ReadOnly Property Instance() As SampleMenuDataSource
			Get
				Return _sampleMenuDataSource
			End Get
		End Property
		Private Shared ReadOnly _sampleMenuDataSource As New SampleMenuDataSource()
		Private _items As ObservableCollection(Of MenuDataItem)
		Public ReadOnly Property Items() As ObservableCollection(Of MenuDataItem)
			Get
				Return Instance._items
			End Get
		End Property
		Public Shared Function GetItem(ByVal uniqueId As Integer) As MenuDataItem
			Dim matches = SampleMenuDataSource.Instance.Items.Where(Function(item) item.UniqueID.Equals(uniqueId))
			If matches.Count() = 1 Then
				Return matches.First()
			End If
			Return Nothing
		End Function
		''' <summary>
		''' Initializes a new instance of the SampleMenuDataSource class.
		''' </summary>
		Public Sub New()
			_items = New ObservableCollection(Of MenuDataItem)()
			_items.Add(New MenuDataItem("Front Desk", MeffedNavigationService.Infrastructure.Enums.ModuleTypes.ViewFrontDesk, "Guest Services", True))
			_items.Add(New MenuDataItem("Management", MeffedNavigationService.Infrastructure.Enums.ModuleTypes.ViewManagement))
		End Sub
	End Class
End Namespace