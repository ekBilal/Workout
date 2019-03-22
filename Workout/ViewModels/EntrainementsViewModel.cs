using System.Collections.ObjectModel;
using System.Windows.Input;
using Workout.Models;
using Xamarin.Forms;

namespace Workout.ViewModels
{
    public class EntrainementsViewModel : BaseViewModel
    {

        private ObservableCollection<Entrainement> _entrainements = new ObservableCollection<Entrainement>();
        public ObservableCollection<Entrainement> Entrainements
        {
            get { return _entrainements; }
            private set { SetValue(ref _entrainements, value); }
        }

        private Entrainement _selectedEntrainement;
        public Entrainement SelectedEntrainement
        {
            get { return _selectedEntrainement; }
            set { SetValue(ref _selectedEntrainement, value); }
        }

        public ICommand SelectedEntrainementCommand { get; private set; }

        public EntrainementsViewModel()
        {
            SelectedEntrainementCommand = new Command<Entrainement>(e => SelectedEntrainament(e));
            Init();
        }

        private void Init()
        {
            Entrainement e = new Entrainement { Nom = "FullBody" };
            for(int i = 0; i<10; i++)
            {
                _entrainements.Add(new Entrainement { Nom = "Entainment " + i });
            }
        }

        private async void SelectedEntrainament(Entrainement entrainement)
        {
            if (_selectedEntrainement == null) return;
            _selectedEntrainement = null;
            //Todo chager entraiment.Nom par entainement.ToString();
            await PageService.Instance.DisplayAlert("yolo", entrainement.Nom, "ok");
        }
    }
}
