using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Reflection;
using MeffedNavigationService.Infrastructure.Contract;

namespace MeffedNavigationService.MEF {
    public sealed class MEFLoader {
        Dictionary<string, List<object>> importers = new Dictionary<string, List<object>>();
        public IEnumerable<T> LoadByMetadata<T>(string path, string tag) {
            var importer = GetImporter<T>(path);
            return importer.LoadByMEF(tag);
        }
        public IEnumerable<T> LoadByMetadata<T>(string path) {
            return LoadByMetadata<T>(path, String.Empty);
        }
         MEFImporter<T> GetImporter<T>(string path) {
            var importerList = GetImporterList(path);
            var importer = importerList.OfType<MEFImporter<T>>().FirstOrDefault();
            if(importer == null) {
                importer = new MEFImporter<T>(path);
                importerList.Add(importer);
            }
            return importer;
        }
        List<object> GetImporterList(string path) {
            if(!importers.ContainsKey(path))
                importers.Add(path, new List<object>());
            return importers[path];
        }
    }
    public sealed class MEFImporter<T> {
        [ImportMany(AllowRecomposition = true)]
        public IEnumerable<Lazy<T, IModuleMetadata>> Imported { get; set; }
        DirectoryCatalog directoryCatalog = null;
        AggregateCatalog AggregateCatalog;
        MEFImporter() {
            AggregateCatalog = new AggregateCatalog();
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetExecutingAssembly()));
        }
        public MEFImporter(string path)
            : this() {
            directoryCatalog = new DirectoryCatalog(path, "*.*");
            AggregateCatalog.Catalogs.Add(directoryCatalog);
            ComposeParts();
        }
        void ComposeParts() {
            CompositionContainerHelper.ComposeParts(this, AggregateCatalog);
        }
        public IEnumerable<T> LoadByMEF(string name) {
            var res = new List<T>();
            foreach(Lazy<T, IModuleMetadata> module in Imported) {
                if(module.Metadata.ModuleType.ToString() == name && !string.IsNullOrEmpty(name)) {
                    res.Add(module.Value);
                }
            }
            return res;
        }
    }
    public class CompositionContainerHelper {
        public static void ComposeParts(object attributedPart, System.ComponentModel.Composition.Primitives.ComposablePartCatalog catalog) {
            CompositionContainer container = new CompositionContainer(catalog);
            container.ComposeParts(attributedPart);
        }
    }
}
