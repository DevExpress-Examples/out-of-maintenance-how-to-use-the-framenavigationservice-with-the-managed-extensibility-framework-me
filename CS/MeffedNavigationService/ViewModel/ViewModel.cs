using System;
using DevExpress.Mvvm;
using System.Windows.Input;
using DevExpress.Xpf.WindowsUI.Navigation;

namespace MeffedNavigationService.ViewModel {
    public class ViewModel : ViewModelBase, INavigationAware {
        ICommand onViewLoadedCommand;
        ICommand navigateCommand;

        public ICommand OnViewLoadedCommand {
            get {
                if(onViewLoadedCommand == null)
                    onViewLoadedCommand = new DelegateCommand(OnViewLoaded);
                return onViewLoadedCommand;
            }
        }
        public ICommand NavigateCommand {
            get {
                if(navigateCommand == null)
                    navigateCommand = new DelegateCommand<string>(Navigate);
                return navigateCommand;
            }
        }
        public void Navigate(string target) {
            NavigationService.Navigate(target, null, this);
        }
        protected INavigationService NavigationService { get { return GetService<INavigationService>(); } }
        protected virtual void OnViewLoaded() { }
        protected virtual void OnNavigatedFrom(NavigationEventArgs e) { }
        protected virtual void OnNavigatedTo(NavigationEventArgs e) { }
        protected virtual void OnNavigatingFrom(NavigatingEventArgs e) { }
        #region INavigationAware Members

        void INavigationAware.NavigatedFrom(NavigationEventArgs e) {
            OnNavigatedFrom(e);
        }
        void INavigationAware.NavigatedTo(NavigationEventArgs e) {
            OnNavigatedTo(e);
        }
        void INavigationAware.NavigatingFrom(NavigatingEventArgs e) {
            OnNavigatingFrom(e);
        }
        #endregion
    }
}