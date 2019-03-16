using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Workout.Models;
using Workout.Servives;
using Workout.Views;
using Xamarin.Forms;

namespace Workout.ViewModels
{
    public class ExercicesViewModelsCP : BaseViewModel
    {
        private Service _service;
        private ExerciceViewModel _selectedExercice;
        private readonly IPageService _pageService;
        private ObservableCollection<ExerciceViewModel> _exercices = new ObservableCollection<ExerciceViewModel>();

        public ObservableCollection<ExerciceViewModel> Exercices
        {
            get { return _exercices; }
            private set { SetValue(ref _exercices, value); }
        }

        public ExerciceViewModel SelectedExercice
        {
            get { return _selectedExercice; }
            set { SetValue(ref _selectedExercice, value); }
        }

        public ICommand AddExerciceCommand { get; private set; }
        public ICommand SelectExerciceCommand { get; private set; }


        public ExercicesViewModelsCP(IPageService pageService)
        {
            _service = new Service();
            _pageService = pageService;

            Init();

            AddExerciceCommand = new Command(AddExercice);
            SelectExerciceCommand = new Command<ExerciceViewModel>(async vm => await SelectExercice(vm));
        }

        private void Init()
        {

        }

        private async void AddExercice()
        {
            var nom = "Exercice " + (Exercices.Count + 1);
            var newExercice = new Exercice { Nom = nom, Difficulte = 3 };
            await _service.AddExercice(newExercice);
            Exercices.Add(new ExerciceViewModel() { Exercice = newExercice });
        }

        //Todo modifier ce bazar
#pragma warning disable CS1998 // Cette méthode async n'a pas d'opérateur 'await' et elle s'exécutera de façon synchrone
        private async Task SelectExercice(ExerciceViewModel exercice)
#pragma warning restore CS1998 // Cette méthode async n'a pas d'opérateur 'await' et elle s'exécutera de façon synchrone
        {
            if (exercice == null) return;
            SelectedExercice = null;
            //await _pageService.PushAsync(new ExerciceDetailPage(exercice));
        }
    }
}
