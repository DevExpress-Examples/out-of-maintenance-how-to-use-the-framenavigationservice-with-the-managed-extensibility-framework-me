using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.Composition;

namespace MeffedNavigationService.Infrastructure.Contract {
    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ExportViewAttribute : ExportAttribute {
        /// <summary>
        /// Initializes a new instance of the ExportViewAttribute class.
        /// </summary>
        public ExportViewAttribute()
            : base(typeof(IModule)) {
        }
        public MeffedNavigationService.Infrastructure.Enums.ModuleTypes ModuleType { get; set; }
    }
}