using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media.Media3D;
using HalconDotNet;
using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Media;
using System.Collections.ObjectModel;

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
        public DelegateCommand TypeChanged {  get; set; }

        ObservableCollection<string> _imgSources = new ObservableCollection<string>();
        private string _selectPath;
        public string selectPath
        {
            get
            {
                return _selectPath;
            }
            set
            {
                _selectPath = value;
                RaisePropertyChanged("selectPath");
            }
        }
        public ObservableCollection<string> imgSources
        {
            get
            {
                return _imgSources;
            }
            set
            {
                _imgSources = value;
                RaisePropertyChanged("imgSources");
            }
        }

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
                RaisePropertyChanged("yuzhileft");
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
                RaisePropertyChanged("yuzhiright");
            }
        }
        public MainViewModel()
        {

            imginit();
            yuzhileft =4.ToString();
            yuzhiright=110.ToString();  
            initCommand = new DelegateCommand(initMethod);
            RgbToGrayCommand = new DelegateCommand(RgbToGrayMethod);
            ThreSholdCommand = new DelegateCommand(ThreSholdMethod);
            TypeChanged = new DelegateCommand(a);
        }
        /// <summary>
        /// 读取img文件夹下所有图片
        /// </summary>
        public void imginit()
        {
            // 定义图片文件夹路径（根据实际路径调整）
            string imgFolderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img");

            // 检查文件夹是否存在
            if (Directory.Exists(imgFolderPath))
            {
                // 筛选扩展名为.png和.jpg的文件（不区分大小写）
                string[] imageFiles = Directory.GetFiles(imgFolderPath, "*.*")
                    .Where(file =>
                        string.Equals(Path.GetExtension(file), ".png", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(Path.GetExtension(file), ".jpg", StringComparison.OrdinalIgnoreCase)
                    ).ToArray();

                // 清空原有数据（可选，根据需求决定是否保留）
                imgSources.Clear();

                // 遍历文件，提取文件名并添加到集合
                foreach (string file in imageFiles)
                {
                    string fileName = Path.GetFileName(file); // 只获取文件名（含扩展名）
                    imgSources.Add(fileName);
                }
            }
            else
            {
                // 文件夹不存在时的处理（可选）
                MessageBox.Show($"图片文件夹不存在：{imgFolderPath}");
            }
        }
        private void a()
        {
          
        }

        private void initMethod()
        {
            if (!string.IsNullOrEmpty(selectPath))
            {
                imgpath= System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img", selectPath); 
                HOperatorSet.ReadImage(out ho_Heisi, imgpath);
                HOperatorSet.GetImageSize(ho_Heisi, out var width, out var height);
                halconControl.HalconWindow.SetPart(0, 0, height.D, width.D);
                halconControl.HalconWindow.DispObj(ho_Heisi);
            }
            else 
            {
                MessageBox.Show("请选择图片");
            }
         
        }
        private void RgbToGrayMethod()
        {
            if (!string.IsNullOrEmpty(selectPath))
            {
                imgpath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img", selectPath);
                HOperatorSet.ReadImage(out ho_Heisi, imgpath);
                HOperatorSet.GetImageSize(ho_Heisi, out var width, out var height);
                halconControl.HalconWindow.SetPart(0, 0, height.D, width.D);
                HOperatorSet.Rgb1ToGray(ho_Heisi, out ho_grayimg);
                halconControl.HalconWindow.DispObj(ho_grayimg);
            }
            else
            {
                MessageBox.Show("请选择图片");
            }


        }
        private void ThreSholdMethod()
        {
            if (!string.IsNullOrEmpty(yuzhileft) && !string.IsNullOrEmpty(yuzhiright))
            {
                try
                {
                    if (!string.IsNullOrEmpty(selectPath))
                    {
                        imgpath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "img", selectPath);
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
                    else
                    {
                        MessageBox.Show("请选择图片");
                    }

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
