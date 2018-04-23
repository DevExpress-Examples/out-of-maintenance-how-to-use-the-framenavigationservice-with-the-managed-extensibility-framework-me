Imports Microsoft.VisualBasic
Imports System
Imports DevExpress.Xpf.Mvvm

Namespace MeffedNavigationService.ViewModel
	Public Class MainViewModel
		Inherits ViewModel
		Protected Overrides Sub OnViewLoaded()
			MyBase.OnViewLoaded()
			Navigate("MenuPage")
		End Sub
	End Class
End Namespace