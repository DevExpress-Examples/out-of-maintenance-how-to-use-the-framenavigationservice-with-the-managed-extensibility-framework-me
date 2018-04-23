using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MeffedNavigationService.Infrastructure.Contract;
using MeffedNavigationService.Infrastructure.Enums;

namespace MeffedNavigationService.View {
    /// <summary>
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    [ExportView(ModuleType = ModuleTypes.MenuPage)]
    public partial class MenuPage : UserControl, IModule {
        public MenuPage() {
            InitializeComponent();
        }

        #region IModule Members

        public string ModuleURI {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
