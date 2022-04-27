using System.ComponentModel;
using System.Runtime.CompilerServices;
using Datalayer.EFClasses.BaseClasses;
using MVCHWpf.Annotations;

namespace MVCHWpf.ViewModels.ItemViewModels
{
    public class ItemViewModel : INotifyPropertyChanged
    {
        #region Fields
        private string _itemId;
        private string _name;
        private decimal _unitCost;
        private string _description;

        #endregion
        #region Properties

        public string ItemId
        {
            get { return _itemId; }
            set
            {
                _itemId = value;
                OnPropertyChanged(nameof(ItemId));
            }
        }

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public decimal UnitCost
        {
            get { return _unitCost; }
            set
            {
                _unitCost = value;
                OnPropertyChanged(nameof(UnitCost));
            }
        }

        public string Description
        {
            get { return _description; }
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        #endregion
        #region PropertyHandler
        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        public ItemViewModel(Item item)
        {
            ItemId = item.ItemId;
            Name = item.Name;
            Description = item.Description;
            UnitCost = item.UnitCost;
        }

       

        public ItemViewModel()
        {

        }

    }
}
