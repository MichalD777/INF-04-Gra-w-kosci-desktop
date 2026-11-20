using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Gra_w_kości_2026_desktop.ViewModels
{
    class RelayCommand(Action execute) : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            execute.Invoke();
        }
    }

    class KoscViewModel : ViewModelBase
    {
        public readonly Kosc[] kosci = [new(), new(), new(), new(), new()];
        public ImageSource[] Kosci { get { return kosciField; } set { kosciField = value; OnProprtyChanged(); } }
        private ImageSource[] kosciField;
        private int suma;
        public int Suma { get { return suma; } set { suma = value; OnProprtyChanged(); } }
        public RelayCommand ThrowCommand { get; set; }

        public KoscViewModel()
        {
            Kosci = new ImageSource[5];

            for (int i = 0; i < Kosci.Length; i++)
                Kosci[i] = new BitmapImage(new Uri("Images/kosc0.png", UriKind.Relative));

            ThrowCommand = new(() =>
            {
                for (int i = 0; i < kosci.Length; i++)
                {
                    kosci[i].RzucKostka();

                    Kosci[i] = new BitmapImage(new Uri("Images/" + kosci[i].ZdjecieKosci[kosci[i].ZdjecieId], UriKind.Relative));
                }
                    OnProprtyChanged("Kosci");
                    Suma = CalculateSum();
            });
        }


        private int CalculateSum()
        {
            int sum = 0;

            foreach (var kosc in kosci)
            {
                sum += kosc.LiczbaOczek;
            }

            return sum;
        }
    }
}
