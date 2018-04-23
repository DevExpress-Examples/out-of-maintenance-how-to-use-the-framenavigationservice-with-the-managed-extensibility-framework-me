Imports System
Imports DevExpress.Mvvm
Imports System.Windows.Input
Imports DevExpress.Xpf.WindowsUI.Navigation

Namespace MeffedNavigationService.ViewModel
    Public Class ViewModel
        Inherits ViewModelBase
        Implements INavigationAware


        Private onViewLoadedCommand_Renamed As ICommand

        Private navigateCommand_Renamed As ICommand

        Public ReadOnly Property OnViewLoadedCommand() As ICommand
            Get
                If onViewLoadedCommand_Renamed Is Nothing Then
                    onViewLoadedCommand_Renamed = New DelegateCommand(AddressOf OnViewLoaded)
                End If
                Return onViewLoadedCommand_Renamed
            End Get
        End Property
        Public ReadOnly Property NavigateCommand() As ICommand
            Get
                If navigateCommand_Renamed Is Nothing Then
                    navigateCommand_Renamed = New DelegateCommand(Of String)(AddressOf Navigate)
                End If
                Return navigateCommand_Renamed
            End Get
        End Property
        Public Sub Navigate(ByVal target As String)
            NavigationService.Navigate(target, Nothing, Me)
        End Sub
        Protected ReadOnly Property NavigationService() As INavigationService
            Get
                Return GetService(Of INavigationService)()
            End Get
        End Property
        Protected Overridable Sub OnViewLoaded()
        End Sub
        Protected Overridable Sub OnNavigatedFrom(ByVal e As NavigationEventArgs)
        End Sub
        Protected Overridable Sub OnNavigatedTo(ByVal e As NavigationEventArgs)
        End Sub
        Protected Overridable Sub OnNavigatingFrom(ByVal e As NavigatingEventArgs)
        End Sub
        #Region "INavigationAware Members"

        Private Sub INavigationAware_NavigatedFrom(ByVal e As NavigationEventArgs) Implements INavigationAware.NavigatedFrom
            OnNavigatedFrom(e)
        End Sub
        Private Sub INavigationAware_NavigatedTo(ByVal e As NavigationEventArgs) Implements INavigationAware.NavigatedTo
            OnNavigatedTo(e)
        End Sub
        Private Sub INavigationAware_NavigatingFrom(ByVal e As NavigatingEventArgs) Implements INavigationAware.NavigatingFrom
            OnNavigatingFrom(e)
        End Sub
        #End Region
    End Class
End Namespace