using System.Collections.ObjectModel;
using System.Windows.Input;
using Workout.Models;
using Workout.Servives;
using Xamarin.Forms;

namespace Workout.ViewModels
{
    public class SeancesViewModel:BaseViewModel
    {
        private ObservableCollection<Seance> _seances = new ObservableCollection<Seance>();
        public ObservableCollection<Seance> Seances
        {
            get { return _seances; }
            private set { SetValue(ref _seances, value); }
        }

        public ICommand SelectedSeanceCommand { get; private set; }

    }
}
