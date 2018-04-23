Imports System
Imports System.Collections.Generic
Imports System.ComponentModel.Composition
Imports System.ComponentModel.Composition.Hosting
Imports System.Linq
Imports System.Reflection
Imports MeffedNavigationService.Infrastructure.Contract

Namespace MeffedNavigationService.MEF
    Public NotInheritable Class MEFLoader
        Private importers As New Dictionary(Of String, List(Of Object))()
        Public Function LoadByMetadata(Of T)(ByVal path As String, ByVal tag As String) As IEnumerable(Of T)
            Dim importer = GetImporter(Of T)(path)
            Return importer.LoadByMEF(tag)
        End Function
        Public Function LoadByMetadata(Of T)(ByVal path As String) As IEnumerable(Of T)
            Return LoadByMetadata(Of T)(path, String.Empty)
        End Function
         Private Function GetImporter(Of T)(ByVal path As String) As MEFImporter(Of T)
            Dim importerList = GetImporterList(path)
            Dim importer = importerList.OfType(Of MEFImporter(Of T))().FirstOrDefault()
            If importer Is Nothing Then
                importer = New MEFImporter(Of T)(path)
                importerList.Add(importer)
            End If
            Return importer
         End Function
        Private Function GetImporterList(ByVal path As String) As List(Of Object)
            If Not importers.ContainsKey(path) Then
                importers.Add(path, New List(Of Object)())
            End If
            Return importers(path)
        End Function
    End Class
    Public NotInheritable Class MEFImporter(Of T)
        <ImportMany(AllowRecomposition := True)> _
        Public Property Imported() As IEnumerable(Of Lazy(Of T, IModuleMetadata))
        Private directoryCatalog As DirectoryCatalog = Nothing
        Private AggregateCatalog As AggregateCatalog
        Private Sub New()
            AggregateCatalog = New AggregateCatalog()
            AggregateCatalog.Catalogs.Add(New AssemblyCatalog(System.Reflection.Assembly.GetExecutingAssembly()))
        End Sub
        Public Sub New(ByVal path As String)
            Me.New()
            directoryCatalog = New DirectoryCatalog(path, "*.*")
            AggregateCatalog.Catalogs.Add(directoryCatalog)
            ComposeParts()
        End Sub
        Private Sub ComposeParts()
            CompositionContainerHelper.ComposeParts(Me, AggregateCatalog)
        End Sub
        Public Function LoadByMEF(ByVal name As String) As IEnumerable(Of T)
            Dim res = New List(Of T)()
            For Each [module] As Lazy(Of T, IModuleMetadata) In Imported
                If [module].Metadata.ModuleType.ToString() = name AndAlso (Not String.IsNullOrEmpty(name)) Then
                    res.Add([module].Value)
                End If
            Next [module]
            Return res
        End Function
    End Class
    Public Class CompositionContainerHelper
        Public Shared Sub ComposeParts(ByVal attributedPart As Object, ByVal catalog As System.ComponentModel.Composition.Primitives.ComposablePartCatalog)
            Dim container As New CompositionContainer(catalog)
            container.ComposeParts(attributedPart)
        End Sub
    End Class
End Namespace
