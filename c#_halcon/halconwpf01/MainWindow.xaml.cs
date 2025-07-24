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

namespace halconwpf01
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var image = new HImage();
            image.ReadImage("C:/Users/Administrator/Desktop/文档管理/haikang02.png");
            image.GetImageSize(out int width, out var height);
            Hwin.HalconWindow.SetPart(0, 0, height, width);
            image.DispImage(Hwin.HalconWindow);
        }
    }
}
