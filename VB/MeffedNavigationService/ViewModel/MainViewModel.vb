Imports System
Imports DevExpress.Mvvm

Namespace MeffedNavigationService.ViewModel
    Public Class MainViewModel
        Inherits ViewModel

        Protected Overrides Sub OnViewLoaded()
            MyBase.OnViewLoaded()
            Navigate("MenuPage")
        End Sub
    End Class
End Namespace