using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HalconDotNet;
using halconwpf01.ViewModel;

namespace halconwpf01
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
       MainViewModel mvm=new MainViewModel();  
        public MainWindow()
        {
            InitializeComponent();
           this.DataContext = mvm;
            mvm.halconControl = Hwin;

        }



    }
}
