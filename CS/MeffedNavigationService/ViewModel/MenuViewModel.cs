using DevExpress.Xpf.Mvvm;
using DevExpress.Xpf.Mvvm.UI;
using DevExpress.Xpf.WindowsUI.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MeffedNavigationService.Infrastructure.DataModel;
using MeffedNavigationService.Infrastructure.Contract;

namespace MeffedNavigationService.ViewModel {
    public class MenuViewModel : ViewModel {
        IEnumerable<MenuDataItem> _items;
        [ImportMany]
        private IEnumerable<Lazy<IModule, IModuleMetadata>> _views;
        public MenuViewModel() {
            Items = null;
            this.InitializeCommands();
        }
        [ImportMany(typeof(IModuleListing))]
        private IEnumerable<Lazy<IModuleListing>> AddOnModuleListing { get; set; }
        public IEnumerable<MenuDataItem> Items {
            get { return _items; }
            private set { this.SetProperty<IEnumerable<MenuDataItem>>(ref this._items, value, "Items"); }
        }
        public IEnumerable<Lazy<IModule, IModuleMetadata>> Views {
            get { return this._views; }
        }
        public ICommand NavigationCommand { get; private set; }
        public void LoadState(object navigationParameter) {
            Items = new ObservableCollection<MenuDataItem>(SampleMenuDataSource.Instance.Items);
            // Load Module Listings.
            MeffedNavigationService.MEF.CompositionContainerHelper.ComposeParts(this, new DirectoryCatalog("."));
            foreach(Lazy<IModuleListing> addOnModule in AddOnModuleListing) {
                foreach(MenuDataItem menuItem in addOnModule.Value.MenuItems) {
                    ((ObservableCollection<MenuDataItem>)Items).Add(menuItem);
                }
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e) {
            LoadState(e.Parameter);
        }
        private void InitializeCommands() {
            this.NavigationCommand = new DelegateCommand<MenuDataItem>(DoNavigation);
        }
        private void DoNavigation(MenuDataItem module) {
            NavigationService.Navigate(module.ModuleType.ToString());
        }
    }
}