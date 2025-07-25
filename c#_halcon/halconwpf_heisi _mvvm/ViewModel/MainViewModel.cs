using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using HalconDotNet;
using Prism.Commands;

namespace halconwpf01.ViewModel
{
    public  class MainViewModel:Prism.Mvvm.BindableBase
    {
       public HWindowControlWPF halconControl { get; set; }
        HObject ho_Heisi = new HObject();
        HObject ho_grayimg = new HObject();
        HObject ho_Regions = new HObject();
        public DelegateCommand initCommand { get; set; }
        public DelegateCommand RgbToGrayCommand {  get; set; }
        public DelegateCommand ThreSholdCommand {  get; set; }
        public MainViewModel()
        {
            initCommand = new DelegateCommand(initMethod);
            RgbToGrayCommand = new DelegateCommand(RgbToGrayMethod);
            ThreSholdCommand = new DelegateCommand(ThreSholdMethod);
        }

        private void initMethod()
        {
            HOperatorSet.ReadImage(out ho_Heisi, "D:/Desktop/文档记录/heisi.png");
            HOperatorSet.GetImageSize(ho_Heisi, out var width, out var height);
            halconControl.HalconWindow.SetPart(0, 0, height.D, width.D);//:“HALCON error #2453: HALCON handle is NULL in operator set_part”
            halconControl.HalconWindow.DispObj(ho_Heisi);
        }
        private void RgbToGrayMethod()
        {
            HOperatorSet.Rgb1ToGray(ho_Heisi, out ho_grayimg);
            halconControl.HalconWindow.DispObj(ho_grayimg);
        }
        private void ThreSholdMethod()
        {
            HOperatorSet.Threshold(ho_grayimg, out ho_Regions, 4, 110);
            halconControl.HalconWindow.DispObj(ho_Regions);
        }
    }
}
