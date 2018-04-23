Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports MeffedNavigationService.Infrastructure.Enums

Namespace MeffedNavigationService.Infrastructure.Contract
	Public Interface IModuleMetadata
		ReadOnly Property ModuleType() As ModuleTypes
	End Interface
End Namespace
