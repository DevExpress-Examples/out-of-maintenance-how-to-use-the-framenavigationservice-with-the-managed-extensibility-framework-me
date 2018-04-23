using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Composition;

namespace MeffedNavigationService.Infrastructure.Contract {
    [InheritedExport(typeof(IModule))]
    public interface IModule {
    }
}
