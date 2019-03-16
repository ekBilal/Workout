using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Workout.Models;
using Workout.Servives;
using Workout.Views;
using Xamarin.Forms;

namespace Workout.ViewModels
{
    public class ExercicesViewModel : BaseViewModel
    {
        protected readonly IPageService _pageService;

        private ObservableCollection<Exercice> _exercices = new ObservableCollection<Exercice>();
        public ObservableCollection<Exercice> Exercices
        {
            get { return _exercices; }
            private set { SetValue(ref _exercices, value); }
        }

        private ExerciceViewModel _selectedExercice;
        public ExerciceViewModel SelectedExercice
        {
            get { return _selectedExercice; }
            set { SetValue(ref _selectedExercice, value); }
        }

        public ICommand SelectExerciceCommand { get; private set; }

        public ExercicesViewModel() : this(new PageService(), new ObservableCollection<Exercice>(JsonStatam.getExercice())) { }
        public ExercicesViewModel(IPageService pageService) : this(pageService, new ObservableCollection<Exercice>(JsonStatam.getExercice())) { }
        public ExercicesViewModel(ObservableCollection<Exercice> exercices) : this(new PageService(), exercices) { }

        public ExercicesViewModel(IPageService pageService, ObservableCollection<Exercice> exercices)
        {
            _pageService = pageService;
            Exercices = exercices;
            SelectExerciceCommand = new Command<Exercice>(async e => await SelectExercice(e));
        }

        protected async Task SelectExercice(Exercice exercice)
        {
            if (exercice == null) return;
            SelectedExercice = null;
            var vm = new ExerciceViewModel { Exercice = exercice };
            await _pageService.PushAsync(new ExerciceDetailPage(vm));
        }
    }
}
