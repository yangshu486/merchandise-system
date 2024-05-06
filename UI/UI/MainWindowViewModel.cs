using MaterialDesignThemes.Wpf;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using UI.Views;

namespace UI
{
    public class MainWindowViewModel : BindableBase
    {
        /// <summary>
        /// 关闭事件
        /// </summary>
        public DelegateCommand<Window> CloseCommand { get; set; }
        /// <summary>
        /// 最小化事件
        /// </summary>
        public DelegateCommand<Window> MinimizedCommand { get; set; }
        /// <summary>
        /// 菜单
        /// </summary>
        public DelegateCommand<string> ClickCommand { get; set; }
       
        private UserControl _UserControl;
        /// <summary>
        /// 用户
        /// </summary>
        public UserControl UserControl
        {
            get { return _UserControl; }
            set { SetProperty(ref _UserControl, value); }
        }
        private readonly IRegionManager _regionManager;

        public MainWindowViewModel(IRegionManager regionManager)
        {
            CloseCommand = new DelegateCommand<Window>(CloseEven);
            MinimizedCommand = new DelegateCommand<Window>(MinimizedEven);
            ClickCommand = new DelegateCommand<string>(ClickEven);
            _regionManager = regionManager;
        }
        public void ClickEven(string index)
        {
            switch (index)
            {
                case "Home":
                    UserControl = new CashRegisterUserControl();
                    break;
                case "Commodity":
                    UserControl = new CommodityUserControl();
                    break;
            }
        }

        /// <summary>
        /// 最小化
        /// </summary>
        /// <param name="obj"></param>
        private void MinimizedEven(Window window)
        {
            window.WindowState = WindowState.Minimized;
        }
        /// <summary>
        ///关闭
        /// </summary>
        /// <param name="obj"></param>
        private void CloseEven(Window window)
        {
            if (window != null)
            {
                if (MessageBox.Show("确定是否关闭程序", "提示", MessageBoxButton.OKCancel, MessageBoxImage.Information) == MessageBoxResult.OK)
                {
                    Thread.Sleep(300);
                    Window.GetWindow(window).Close();
                }

            }
        }
    }
}

