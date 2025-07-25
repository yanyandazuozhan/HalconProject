using System;
using System.Collections.Generic;
using System.IO;
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
        private string imgpath;
        public DelegateCommand initCommand { get; set; }
        public DelegateCommand RgbToGrayCommand {  get; set; }
        public DelegateCommand ThreSholdCommand {  get; set; }
        private string _yuzhileft;
        public string yuzhileft
        {
            get
            {
                return _yuzhileft;
            }
            set
            {
                _yuzhileft=value;
                OnPropertyChanged("yuzhileft");
            }
        }

        private string _yuzhiright;
        public string yuzhiright
        {
            get
            {
                return _yuzhiright;
            }
            set
            {
                _yuzhiright = value;
                OnPropertyChanged("yuzhiright");
            }
        }
        public MainViewModel()
        {
            imgpath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img", "零件图片.png");
            yuzhileft =4.ToString();
            yuzhiright=110.ToString();  
            initCommand = new DelegateCommand(initMethod);
            RgbToGrayCommand = new DelegateCommand(RgbToGrayMethod);
            ThreSholdCommand = new DelegateCommand(ThreSholdMethod);
        }

        private void initMethod()
        {
            HOperatorSet.ReadImage(out ho_Heisi, imgpath);
            HOperatorSet.GetImageSize(ho_Heisi, out var width, out var height);
            halconControl.HalconWindow.SetPart(0, 0, height.D, width.D);
            halconControl.HalconWindow.DispObj(ho_Heisi);
        }
        private void RgbToGrayMethod()
        {
            HOperatorSet.Rgb1ToGray(ho_Heisi, out ho_grayimg);
            halconControl.HalconWindow.DispObj(ho_grayimg);
        }
        private void ThreSholdMethod()
        {
            if (!string.IsNullOrEmpty(yuzhileft) && !string.IsNullOrEmpty(yuzhiright))
            {
                try
                {
                    int left = int.Parse(yuzhileft);
                    int right = int.Parse(yuzhiright);
                    HOperatorSet.ReadImage(out ho_Heisi, imgpath);
                    HOperatorSet.GetImageSize(ho_Heisi, out var width, out var height);
                    halconControl.HalconWindow.SetPart(0, 0, height.D, width.D);
                    halconControl.HalconWindow.DispObj(ho_Heisi);

                    HOperatorSet.Rgb1ToGray(ho_Heisi, out ho_grayimg);
                    halconControl.HalconWindow.DispObj(ho_grayimg);

                    HOperatorSet.Threshold(ho_grayimg, out ho_Regions, left, right);
                    halconControl.HalconWindow.DispObj(ho_Regions);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("阈值不能为空");
            }
           
        }
    }
}
