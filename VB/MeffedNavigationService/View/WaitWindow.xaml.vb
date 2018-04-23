Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows
Imports System.Windows.Controls
Imports System.Windows.Data
Imports System.Windows.Documents
Imports System.Windows.Input
Imports System.Windows.Media
Imports System.Windows.Media.Imaging
Imports System.Windows.Shapes
Imports DevExpress.Xpf.Core

Namespace MeffedNavigationService.View
    ''' <summary>
    ''' Interaction logic for WaitWindow.xaml
    ''' </summary>
    Partial Public Class WaitWindow
        Inherits Window
        Implements ISplashScreen

        Public Sub New()
            InitializeComponent()
        End Sub
        #Region "ISplashScreen Members"
        Private Sub ISplashScreen_CloseSplashScreen() Implements ISplashScreen.CloseSplashScreen
            Close()
        End Sub
        Private Sub ISplashScreen_Progress(ByVal value As Double) Implements ISplashScreen.Progress
        End Sub
        Private Sub ISplashScreen_SetProgressState(ByVal isIndeterminate As Boolean) Implements ISplashScreen.SetProgressState
        End Sub
        #End Region
    End Class
End Namespace