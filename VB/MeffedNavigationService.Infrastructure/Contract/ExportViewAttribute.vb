Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.ComponentModel
Imports System.ComponentModel.Composition

Namespace MeffedNavigationService.Infrastructure.Contract
	<MetadataAttribute, AttributeUsage(AttributeTargets.Class, AllowMultiple := False)> _
	Public Class ExportViewAttribute
		Inherits ExportAttribute
		''' <summary>
		''' Initializes a new instance of the ExportViewAttribute class.
		''' </summary>
		Public Sub New()
			MyBase.New(GetType(IModule))
		End Sub
		Private privateModuleType As MeffedNavigationService.Infrastructure.Enums.ModuleTypes
		Public Property ModuleType() As MeffedNavigationService.Infrastructure.Enums.ModuleTypes
			Get
				Return privateModuleType
			End Get
			Set(ByVal value As MeffedNavigationService.Infrastructure.Enums.ModuleTypes)
				privateModuleType = value
			End Set
		End Property
	End Class
End Namespace