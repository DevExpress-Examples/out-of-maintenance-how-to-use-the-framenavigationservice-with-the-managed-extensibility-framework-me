using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Mvvm.UI;
using MeffedNavigationService.Infrastructure.Contract;
using MeffedNavigationService.MEF;

namespace MeffedNavigationService.MEF {
    public class MeffedViewLocator : IViewLocator {
        MEFLoader mefLoader;
        public MeffedViewLocator() {
            mefLoader = new MEFLoader();
        }
        string GetPathByName(string name) {
            return AppDomain.CurrentDomain.BaseDirectory;
        }
        object ResolveByName<T>(string name) {
            return mefLoader.LoadByMetadata<T>(GetPathByName(name), name).FirstOrDefault();
        }
        object CreateFallbackView(string documentType) {
            var cp = new ContentPresenter()
            {
                Content = new TextBlock()
                {
                    Text = string.Format("\"{0}\" type not found.", documentType),
                    FontSize = 25,
                    Foreground = new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                }
            };
            return new DevExpress.Xpf.WindowsUI.PageAdornerControl() { Content = cp };
        }
        #region IViewLocator Members
        public object ResolveView(string name) {
            return ResolveByName<IModule>(name) ?? CreateFallbackView(name);
        }
        object IViewLocator.ResolveView(string name) {
            return ResolveView(name);
        }
        #endregion
    }
}
