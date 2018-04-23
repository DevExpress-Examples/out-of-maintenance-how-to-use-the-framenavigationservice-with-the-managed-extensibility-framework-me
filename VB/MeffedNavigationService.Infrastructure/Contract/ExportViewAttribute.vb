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
        Public Property ModuleType() As MeffedNavigationService.Infrastructure.Enums.ModuleTypes
    End Class
End Namespace