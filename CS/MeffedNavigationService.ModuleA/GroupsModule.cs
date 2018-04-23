using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MeffedNavigationService.Infrastructure.Contract;
using MeffedNavigationService.Infrastructure.DataModel;
using MeffedNavigationService.Infrastructure.Enums;

namespace MeffedNavigationService.ModuleA {
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
            MenuItems.Add(new MenuDataItem("Activities", ModuleTypes.ViewActivities, "General", true));
            MenuItems.Add(new MenuDataItem("Opportunities", ModuleTypes.ViewOpportunities));
        }
        #region IModuleListing Members
        IEnumerable<MenuDataItem> IModuleListing.MenuItems {
            get { return this.MenuItems; }
        }
        #endregion
    }
}
