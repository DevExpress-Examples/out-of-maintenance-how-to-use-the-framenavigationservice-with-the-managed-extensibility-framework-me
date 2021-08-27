<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128642500/16.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4745)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [ExportViewAttribute.cs](./CS/MeffedNavigationService.Infrastructure/Contract/ExportViewAttribute.cs) (VB: [ExportViewAttribute.vb](./VB/MeffedNavigationService.Infrastructure/Contract/ExportViewAttribute.vb))
* [IModule.cs](./CS/MeffedNavigationService.Infrastructure/Contract/IModule.cs) (VB: [IModuleMetadata.vb](./VB/MeffedNavigationService.Infrastructure/Contract/IModuleMetadata.vb))
* [IModuleListing.cs](./CS/MeffedNavigationService.Infrastructure/Contract/IModuleListing.cs) (VB: [IModuleListing.vb](./VB/MeffedNavigationService.Infrastructure/Contract/IModuleListing.vb))
* [IModuleMetadata.cs](./CS/MeffedNavigationService.Infrastructure/Contract/IModuleMetadata.cs) (VB: [IModuleMetadata.vb](./VB/MeffedNavigationService.Infrastructure/Contract/IModuleMetadata.vb))
* [MenuDataItem.cs](./CS/MeffedNavigationService.Infrastructure/DataModel/MenuDataItem.cs) (VB: [MenuDataItem.vb](./VB/MeffedNavigationService.Infrastructure/DataModel/MenuDataItem.vb))
* [ViewTypes.cs](./CS/MeffedNavigationService.Infrastructure/Enums/ViewTypes.cs) (VB: [ViewTypes.vb](./VB/MeffedNavigationService.Infrastructure/Enums/ViewTypes.vb))
* [GroupsModule.cs](./CS/MeffedNavigationService.ModuleA/GroupsModule.cs) (VB: [GroupsModule.vb](./VB/MeffedNavigationService.ModuleA/GroupsModule.vb))
* [ActivitiesView.xaml](./CS/MeffedNavigationService.ModuleA/View/ActivitiesView.xaml) (VB: [ActivitiesView.xaml](./VB/MeffedNavigationService.ModuleA/View/ActivitiesView.xaml))
* [LeadsView.xaml](./CS/MeffedNavigationService.ModuleA/View/LeadsView.xaml) (VB: [LeadsView.xaml](./VB/MeffedNavigationService.ModuleA/View/LeadsView.xaml))
* [OpportunitiesView.xaml](./CS/MeffedNavigationService.ModuleA/View/OpportunitiesView.xaml) (VB: [OpportunitiesView.xaml](./VB/MeffedNavigationService.ModuleA/View/OpportunitiesView.xaml))
* [GroupsModule.cs](./CS/MeffedNavigationService.ModuleB/GroupsModule.cs) (VB: [GroupsModule.vb](./VB/MeffedNavigationService.ModuleB/GroupsModule.vb))
* [InvoicesView.xaml](./CS/MeffedNavigationService.ModuleB/View/InvoicesView.xaml) (VB: [InvoicesView.xaml](./VB/MeffedNavigationService.ModuleB/View/InvoicesView.xaml))
* [OrdersView.xaml](./CS/MeffedNavigationService.ModuleB/View/OrdersView.xaml) (VB: [OrdersView.xaml](./VB/MeffedNavigationService.ModuleB/View/OrdersView.xaml))
* [ProductsView.xaml](./CS/MeffedNavigationService.ModuleB/View/ProductsView.xaml) (VB: [ProductsView.xaml](./VB/MeffedNavigationService.ModuleB/View/ProductsView.xaml))
* [QuotesView.xaml](./CS/MeffedNavigationService.ModuleB/View/QuotesView.xaml) (VB: [QuotesView.xaml](./VB/MeffedNavigationService.ModuleB/View/QuotesView.xaml))
* [MainWindow.xaml](./CS/MeffedNavigationService/MainWindow.xaml) (VB: [MainWindow.xaml](./VB/MeffedNavigationService/MainWindow.xaml))
* [MeffedViewLocator.cs](./CS/MeffedNavigationService/MEF/MeffedViewLocator.cs) (VB: [MeffedViewLocator.vb](./VB/MeffedNavigationService/MEF/MeffedViewLocator.vb))
* [MefLoader.cs](./CS/MeffedNavigationService/MEF/MefLoader.cs) (VB: [MefLoader.vb](./VB/MeffedNavigationService/MEF/MefLoader.vb))
* [FrontDeskView.xaml](./CS/MeffedNavigationService/View/FrontDeskView.xaml) (VB: [FrontDeskView.xaml](./VB/MeffedNavigationService/View/FrontDeskView.xaml))
* [ManagementView.xaml](./CS/MeffedNavigationService/View/ManagementView.xaml) (VB: [ManagementView.xaml](./VB/MeffedNavigationService/View/ManagementView.xaml))
* [MenuPage.xaml](./CS/MeffedNavigationService/View/MenuPage.xaml) (VB: [MenuPage.xaml](./VB/MeffedNavigationService/View/MenuPage.xaml))
* [WaitWindow.xaml](./CS/MeffedNavigationService/View/WaitWindow.xaml) (VB: [WaitWindow.xaml](./VB/MeffedNavigationService/View/WaitWindow.xaml))
* [MainViewModel.cs](./CS/MeffedNavigationService/ViewModel/MainViewModel.cs) (VB: [MainViewModel.vb](./VB/MeffedNavigationService/ViewModel/MainViewModel.vb))
* [MenuViewModel.cs](./CS/MeffedNavigationService/ViewModel/MenuViewModel.cs) (VB: [MenuViewModel.vb](./VB/MeffedNavigationService/ViewModel/MenuViewModel.vb))
* [ViewModel.cs](./CS/MeffedNavigationService/ViewModel/ViewModel.cs) (VB: [ViewModel.vb](./VB/MeffedNavigationService/ViewModel/ViewModel.vb))
<!-- default file list end -->
# How to use the FrameNavigationService with the Managed Extensibility Framework (MEF)


<p>The FrameNavigationService allows navigating between Views within a NavigationFrame. This example shows how this service can be used along with the <a href="https://msdn.microsoft.com/en-us/library/dd460648(v=vs.110).aspx">Managed Extensibility Framework (MEF)</a>.</p>
<br>
<p>In this example, we've defined a custom ViewLocator for the FrameNavigationService. This ViewLocator uses MEF and can load views dynamically from the external libraries. The MainWindow contains a NavigationFrame, which shows a MenuPage view at startup. The MenuPage contains tiles, which invoke a command to navigate to child views when clicked. Each child view contains the Back button for backward navigation.</p>

<br/>


