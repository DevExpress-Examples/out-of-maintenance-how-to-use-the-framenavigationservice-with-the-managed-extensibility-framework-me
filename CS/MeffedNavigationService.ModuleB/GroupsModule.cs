using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MeffedNavigationService.Infrastructure.Contract;
using MeffedNavigationService.Infrastructure.DataModel;
using MeffedNavigationService.Infrastructure.Enums;

namespace MeffedNavigationService.ModuleB {
    public class GroupsModule : IModuleListing {
        List<MenuDataItem> _menuItems;
        /// <summary>
        /// Initializes a new instance of the GroupsModule class.
        /// </summary>
        /// <param name="menuItems"></param>
        public GroupsModule() {
            _menuItems = new List<MenuDataItem>();
            this.InitializeGroupsModule();
        }
        public List<MenuDataItem> MenuItems {
            get { return this._menuItems; }
        }
        private void InitializeGroupsModule() {
            MenuItems.Add(new MenuDataItem("Products", ModuleTypes.ViewProducts, "Opportunities", true));
            MenuItems.Add(new MenuDataItem("Orders", ModuleTypes.ViewOrders));
            MenuItems.Add(new MenuDataItem("Quotes", ModuleTypes.ViewQuotes));
            MenuItems.Add(new MenuDataItem("Invoices", ModuleTypes.ViewInvoices));
        }
        #region IModuleListing Members
        IEnumerable<MenuDataItem> IModuleListing.MenuItems {
            get { return this.MenuItems; }
        }
        #endregion
    }
}
