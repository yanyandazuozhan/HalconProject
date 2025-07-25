using HalconDotNet;


namespace 高版本halocn_mvvm
{
    public  class MainWindowViewModel:Prism.Mvvm.BindableBase
    {
        public  HWindowControlWPF halconControl { get; set; }
        HObject ho_Heisi = new HObject();
        HObject ho_grayimg = new HObject();
        HObject ho_Regions = new HObject();

        private DelegateCommand _initCommand;
        private DelegateCommand _RgbToGrayCommand;
        private DelegateCommand _ThreSholdCommand;

        public DelegateCommand initCommand => _initCommand ??= new DelegateCommand(initMethod);
        public DelegateCommand RgbToGrayCommand => _RgbToGrayCommand ??= new DelegateCommand(RgbToGrayMethod);
        public DelegateCommand ThreSholdCommand => _ThreSholdCommand ??= new DelegateCommand(ThreSholdMethod);
        public MainWindowViewModel()
        {
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
