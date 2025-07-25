using Prism.Common;
using System.Windows;

namespace 高版本halocn_mvvm
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        IContainerExtension _containerExtension;

        protected override Window CreateShell() => null!;

        protected override void Initialize()
        {
            base.Initialize();
            DisPlayShellView();
        }

        private void DisPlayShellView()
        {
            _containerExtension = ContainerLocator.Current;
            var shell = Container.Resolve<MainWindowView>();
            if (shell != null)
            {
                MvvmHelpers.AutowireViewModel(shell);
                RegionManager.SetRegionManager(shell, _containerExtension.Resolve<IRegionManager>());
                RegionManager.UpdateRegions();
                InitializeShell(shell);
            }
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void ConfigureViewModelLocator()
        {
            base.ConfigureViewModelLocator();
            ViewModelLocationProvider.Register<MainWindowView, MainWindowViewModel>();
        }
    }
}
