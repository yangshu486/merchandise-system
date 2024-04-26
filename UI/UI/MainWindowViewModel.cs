using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using UI.Views;

namespace UI
{
    public class MainWindowViewModel : BindableBase
    {
        public DelegateCommand<string> MenuCommand;
        public MainWindowViewModel()
       {
            MenuCommand = new DelegateCommand<string>(MenuEven);
        }
        private UserControl _UserControl;
        /// <summary>
        /// 用户
        /// </summary>
        public UserControl UserControl
        {
            get { return _UserControl; }
            set { SetProperty(ref _UserControl, value); }
        }

        public void MenuEven(string index)
        {
            switch (index)
            {
                case "1":
                    UserControl = new CashRegisterUserControl();
                    break;
                case "2":
                    UserControl = new CommodityUserControl();
                    break;
            }
        }
    }
}

