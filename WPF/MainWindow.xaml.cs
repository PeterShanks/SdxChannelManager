using System.Windows;
using SdxChannelManager.ViewModels;

namespace SdxChannelManager
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
