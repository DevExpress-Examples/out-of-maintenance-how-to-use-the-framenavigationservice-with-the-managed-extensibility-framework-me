Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows
Imports System.Windows.Controls
Imports DevExpress.Mvvm.UI
Imports MeffedNavigationService.Infrastructure.Contract
Imports MeffedNavigationService.MEF

Namespace MeffedNavigationService.MEF
    Public Class MeffedViewLocator
        Implements IViewLocator

        Private mefLoader As MEFLoader
        Public Sub New()
            mefLoader = New MEFLoader()
        End Sub
        Private Function GetPathByName(ByVal name As String) As String
            Return AppDomain.CurrentDomain.BaseDirectory
        End Function
        Private Function ResolveByName(Of T)(ByVal name As String) As Object
            Return mefLoader.LoadByMetadata(Of T)(GetPathByName(name), name).FirstOrDefault()
        End Function
        Private Function CreateFallbackView(ByVal documentType As String) As Object
            Dim cp = New ContentPresenter() With { _
                .Content = New TextBlock() With {.Text = String.Format("""{0}"" type not found.", documentType), .FontSize = 25, .Foreground = New System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red), .HorizontalAlignment = HorizontalAlignment.Center, .VerticalAlignment = VerticalAlignment.Center} _
            }
            Return New DevExpress.Xpf.WindowsUI.PageAdornerControl() With {.Content = cp}
        End Function
        #Region "IViewLocator Members"
        Public Function ResolveView(ByVal name As String) As Object
            Return If(ResolveByName(Of IModule)(name), CreateFallbackView(name))
        End Function
        Private Function IViewLocator_ResolveView(ByVal name As String) As Object Implements IViewLocator.ResolveView
            Return ResolveView(name)
        End Function
        Private Function IViewLocator_ResolveViewType(ByVal name As String) As Type Implements IViewLocator.ResolveViewType
            Return ResolveView(name).GetType()
        End Function
        #End Region
    End Class
End Namespace
