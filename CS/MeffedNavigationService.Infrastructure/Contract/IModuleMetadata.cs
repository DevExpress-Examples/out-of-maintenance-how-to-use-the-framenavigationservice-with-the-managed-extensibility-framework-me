using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MeffedNavigationService.Infrastructure.Enums;

namespace MeffedNavigationService.Infrastructure.Contract {
    public interface IModuleMetadata {
        ModuleTypes ModuleType { get; }
    }
}
