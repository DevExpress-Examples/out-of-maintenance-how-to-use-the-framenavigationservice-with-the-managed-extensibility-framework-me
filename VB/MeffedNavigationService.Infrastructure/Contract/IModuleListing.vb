Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.ComponentModel.Composition
Imports MeffedNavigationService.Infrastructure.DataModel

Namespace MeffedNavigationService.Infrastructure.Contract
    <InheritedExport(GetType(IModuleListing))> _
    Public Interface IModuleListing
        ReadOnly Property MenuItems() As IEnumerable(Of MenuDataItem)
    End Interface
End Namespace
