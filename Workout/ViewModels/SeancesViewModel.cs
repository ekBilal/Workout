using System.Collections.ObjectModel;
using System.Windows.Input;
using Workout.Models;
using Workout.Servives;
using Xamarin.Forms;

namespace Workout.ViewModels
{
    public class SeancesViewModel:BaseViewModel
    {
        private Service _service;
        private readonly IPageService _pageService;
        private ObservableCollection<Seance> _seances = new ObservableCollection<Seance>();

        public ObservableCollection<Seance> Seances
        {
            get { return _seances; }
            private set { SetValue(ref _seances, value); }
        }

        public ICommand SelectedSeanceCommand { get; private set; }

        public SeancesViewModel(IPageService pageService)
        {
            _service = new Service();
            _pageService = pageService;
            InitMock();
        }

        private void InitMock()
        {
            var seance = new Seance { Series = new ObservableCollection<Serie>(), Nom="FullBody" };
            var serie = new Serie { NbReps = 10, Exercice = new Exercice { Nom = "Exercice 1" } };
            seance.Series.Add(serie);
            _seances.Add(seance);
        }

        private void Init()
        {
            //var seance = new Seance();
            //seance.Nom = "une seance";
            //seance.Exercices = new ObservableCollection<Exercice>();
            //var exercices = await _service.GetExercices();
            ////Exercices = new ObservableCollection<ExerciceViewModel>();
            //for (var i = 0; i < 5; i++)
            //{
            //    seance.Exercices.Add(exercices[i]);
            //}

            //Seances.Add(seance);
            //Seances.Add(seance);

        }
    }
}
