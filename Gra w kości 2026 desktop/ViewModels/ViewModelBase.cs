using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Gra_w_kości_2026_desktop.ViewModels
{
    class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnProprtyChanged([CallerMemberName] string name = null!)
        {
            PropertyChanged?.Invoke(this, new(name));
        }
    }
}
