using System;
using System.Collections.ObjectModel;
using System.Linq;
using DevExpress.Xpf.Mvvm;

namespace MeffedNavigationService.Infrastructure.DataModel {
    public class MenuDataItem : ViewModelBase {
        private int _uniqueID;
        private string _groupHeader;
        private string _title;
        private bool _isFlowBreak;
        private MeffedNavigationService.Infrastructure.Enums.ModuleTypes _moduleType;
        static int idCount = 0;
        /// <summary>
        /// Initializes a new instance of the MenuDataItem class.
        /// </summary>
        /// <param name="uniqueId">The unique id.</param>
        /// <param name="title">The title.</param>
        /// <param name="groupHeader">The group header.</param>
        public MenuDataItem(string title, MeffedNavigationService.Infrastructure.Enums.ModuleTypes moduleType, string groupHeader, bool isFlowBreak) {
            ModuleType = moduleType;
            IsFlowBreak = isFlowBreak;
            UniqueID = idCount++;
            GroupHeader = groupHeader;
            Title = title;
        }
        /// <summary>
        /// Initializes a new instance of the MenuDataItem class.
        /// </summary>
        /// <param name="uniqueId">The unique id.</param>
        /// <param name="title">The title.</param>
        public MenuDataItem(string title, MeffedNavigationService.Infrastructure.Enums.ModuleTypes moduleType)
            : this(title, moduleType, String.Empty, false) {
        }
        public int UniqueID {
            get { return _uniqueID; }
            private set { this.SetProperty(ref this._uniqueID, value, "UniqueID"); }
        }
        public MeffedNavigationService.Infrastructure.Enums.ModuleTypes ModuleType {
            get { return _moduleType; }
            set { this.SetProperty(ref this._moduleType, value, "ModuleType"); }
        }
        public bool IsFlowBreak {
            get { return _isFlowBreak; }
            set { this.SetProperty(ref this._isFlowBreak, value, "IsFlowBreak"); }
        }
        public string GroupHeader {
            get { return _groupHeader; }
            set { this.SetProperty(ref this._groupHeader, value, "GroupHeader"); }
        }
        public string Title {
            get { return _title; }
            set { this.SetProperty(ref this._title, value, "Title"); }
        }
        public override string ToString() {
            return this.Title;
        }
    }
    public sealed class SampleMenuDataSource {
        public static SampleMenuDataSource Instance {
            get { return _sampleMenuDataSource; }
        }
        private static readonly SampleMenuDataSource _sampleMenuDataSource = new SampleMenuDataSource();
        private ObservableCollection<MenuDataItem> _items;
        public ObservableCollection<MenuDataItem> Items {
            get { return Instance._items; }
        }
        public static MenuDataItem GetItem(int uniqueId) {
            var matches = SampleMenuDataSource.Instance.Items.Where((item) => item.UniqueID.Equals(uniqueId));
            if(matches.Count() == 1) return matches.First();
            return null;
        }
        /// <summary>
        /// Initializes a new instance of the SampleMenuDataSource class.
        /// </summary>
        public SampleMenuDataSource() {
            _items = new ObservableCollection<MenuDataItem>();
            _items.Add(new MenuDataItem("Front Desk", MeffedNavigationService.Infrastructure.Enums.ModuleTypes.ViewFrontDesk, "Guest Services", true));
            _items.Add(new MenuDataItem("Management", MeffedNavigationService.Infrastructure.Enums.ModuleTypes.ViewManagement));
        }
    }
}