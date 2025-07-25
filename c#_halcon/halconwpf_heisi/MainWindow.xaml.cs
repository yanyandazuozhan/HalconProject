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
        public MainViewModel mvm=new MainViewModel();
        public MainWindow()
        {
            InitializeComponent();
            //this.DataContext = mvm;
            //Hwin = mvm.h1;

        }


        HObject ho_Heisi = new HObject();
        HObject ho_grayimg = new HObject();
        HObject ho_Regions = new HObject();
        private void Button_Click(object sender, RoutedEventArgs e)
        {


            HOperatorSet.ReadImage(out ho_Heisi, "D:/Desktop/文档记录/heisi.png");
            HOperatorSet.GetImageSize(ho_Heisi, out var width, out var height);
            Hwin.HalconWindow.SetPart(0, 0, height.D, width.D);

            Hwin.HalconWindow.DispObj(ho_Heisi);
        }

        private void rgb_gray_Click(object sender, RoutedEventArgs e)
        {
            HOperatorSet.Rgb1ToGray(ho_Heisi, out ho_grayimg);
            Hwin.HalconWindow.DispObj(ho_grayimg);
        }

        private void threshold_Click(object sender, RoutedEventArgs e)
        {
            HOperatorSet.Threshold(ho_grayimg, out ho_Regions, 4, 110);
            Hwin.HalconWindow.DispObj(ho_Regions);
        }




    }
}
