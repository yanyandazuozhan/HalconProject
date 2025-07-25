using System.Windows;


namespace 高版本halocn_mvvm
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindowView : Window
    {
        public MainWindowView()
        {
            InitializeComponent();

            if (DataContext is MainWindowViewModel mvm)
                mvm.halconControl = HWin;
        }
    }
}