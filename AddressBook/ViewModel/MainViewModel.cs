using AddressBook.Common;
using AddressBook.Model;
using AddressBook.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AddressBook.ViewModel
{
    public class MainViewModel:ViewModelBase
    {
        public MainViewModel()
        {
            AddressBookModel a = new AddressBookModel();
            a.AddressList = new List<AddressBookModel.Address>();
            AddressBookModel.Address address = new AddressBookModel.Address();

            address.Name = "島袋雄介";
            address.NameKana = "しまぶくろゆうすけ";
            address.StreetAddress = "沖縄県沖縄市美原";
            address.FaxNo = "090978144390";
            address.TellNo = "09097812222";

            a.AddressList.Add(address);

            AddressBook = a.AddressList;
        }

        private void InitOnPage()
        {

        }

        #region プロパティ
        private List<AddressBookModel.Address> _addressBook;
        public List<AddressBookModel.Address> AddressBook
        {
            set
            {
                _addressBook = value;
                RaisePropertyChanged("AddressBook");
            }
            get
            {
                return _addressBook;
            }
        }

        #endregion プロパティ


        #region イベント
        private void Delete()
        {

        }

        ICommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                return _deleteCommand ?? (_deleteCommand = new DelegateCommand(Delete));
            }
        }

        private void Edit()
        {

        }

        ICommand _editCommand;
        public ICommand EditCommand
        {
            get
            {
                return _editCommand ?? (_editCommand = new DelegateCommand(Edit));
            }
        }

        private void AddAdress()
        {
            //AddressEditWindow a = new AddressEditWindow();
            //a.ShowDialog();

            App app = App.Current as App;
            app.ShowModalView(new AddressEditViewModel());
        }

        ICommand _addressCommand;
        public ICommand AddAddressCommand
        {
            get
            {
                return _addressCommand ?? (_addressCommand = new DelegateCommand(AddAdress));
            }
        }
        #endregion イベント
    }
}
