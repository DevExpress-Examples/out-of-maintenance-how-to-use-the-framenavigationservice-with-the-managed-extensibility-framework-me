using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;
using MeffedNavigationService.Infrastructure.DataModel;

namespace MeffedNavigationService.Infrastructure.Contract {
    [InheritedExport(typeof(IModuleListing))]
    public interface IModuleListing {
        IEnumerable<MenuDataItem> MenuItems { get; }
    }
}
