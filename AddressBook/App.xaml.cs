using AddressBook.View;
using AddressBook.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AddressBook
{
    /// <summary>
    /// App.xaml の相互作用ロジック
    /// </summary>
    public partial class App : Application
    {
        private Dictionary<Type,Type> ViewModels { get; set; }

        public App()
            :base()
        {
            ViewModels = new Dictionary<Type, Type>();
            ViewModels.Add(typeof(AddressEditViewModel), typeof(AddressEditWindow));
        }

        public Window CreateView<T>(T viewModel)
        {
            if(ViewModels.ContainsKey(viewModel.GetType()))
            {
                Type viewType = ViewModels[viewModel.GetType()];
                Window wnd = Activator.CreateInstance(viewType) as Window;
                if (wnd != null)
                    wnd.DataContext = viewModel;
                return wnd;
            }
            else
            {
                return null;
            }
        }

        public bool ShowModalView<T>(T viewModel)
        {
            Window view = CreateView(viewModel);
            if (view != null)
            {
                return (view.ShowDialog() == true);
            }
            else
            {
                return false;
            }
        }

        // ViewModeからモードレスでViewを表示する
        public void ShowView<T>(T viewModel)
        {
            Window view = CreateView(viewModel);
            if (view != null)
            {
                view.Show();
            }
        }

        public void CloseView<T>(T viewModel)
        {
            Window view = CreateView(viewModel);
            //if (view != null)
            //{
            //    view.Close();
            //}

            foreach (Window item in App.Current.Windows)
            {
                if(item.GetType() == view.GetType())
                {

                    item.Close();
                }

              
            }
        }
    }
}
