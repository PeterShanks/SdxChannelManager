using System.Windows;
using SdxChannelSorter.ViewModels;

namespace SdxChannelSorter
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
