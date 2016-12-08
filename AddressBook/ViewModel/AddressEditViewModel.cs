using AddressBook.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AddressBook.ViewModel
{
    public class AddressEditViewModel : ViewModelBase
    {

        private void Cancel()
        {
            App app = App.Current as App;
            app.CloseView(this);
        }

        ICommand _cancelCommand;
        public ICommand CancelCommand
        {
            get
            {
                return _cancelCommand ?? (_cancelCommand = new DelegateCommand(Cancel));
            }
        }
    }
}
