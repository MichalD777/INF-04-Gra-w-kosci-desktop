using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Gra_w_kości_2026_desktop.ViewModels;
using System.Text;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Gra_w_kości_2026_desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Podpięcie ViewModelu do kontekstu danych okna
            DataContext = new KoscViewModel();
        }

        private void kosc_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Image? image = sender as Image;
            if (image is null)
                return;

            // Przełączenie dostępności klikniętej kości i zmiana jej przezroczystości
            int index = int.Parse(image.Tag.ToString()!);
            KoscViewModel viewModel = (DataContext as KoscViewModel)!;
            viewModel.kosci[index].CzyDostepna = !viewModel.kosci[index].CzyDostepna;

            image.Opacity = image.Opacity == 1d ? 0.5d : 1d;
        }
    }
}