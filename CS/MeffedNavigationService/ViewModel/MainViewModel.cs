using System;
using DevExpress.Mvvm;

namespace MeffedNavigationService.ViewModel {
    public class MainViewModel : ViewModel {
        protected override void OnViewLoaded() {
            base.OnViewLoaded();
            Navigate("MenuPage");
        }
    }
}