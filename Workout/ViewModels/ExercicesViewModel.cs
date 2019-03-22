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
        private ObservableCollection<Exercice> _exercices = new ObservableCollection<Exercice>();
        public ObservableCollection<Exercice> Exercices
        {
            get { return _exercices; }
            private set { SetValue(ref _exercices, value); }
        }

        private Exercice _selectedExercice;
        public Exercice SelectedExercice
        {
            get { return _selectedExercice; }
            set
            {
                SetValue(ref _selectedExercice, value);
            }
        }

        public ICommand SelectExerciceCommand { get; private set; }

        public ExercicesViewModel() : this(Service.Instance.getAllExercices()) { }
        public ExercicesViewModel(ObservableCollection<Exercice> exercices)
        {
            Exercices = exercices;
            SelectExerciceCommand = new Command<Exercice>(async e => await SelectExercice(e));
        }



        private async Task SelectExercice(Exercice exercice)
        {
            if (exercice == null) return;
            SelectedExercice = null;
            var vm = new ExerciceViewModel { Exercice = exercice };
            await PageService.Instance.DisplayAlert("baka", "ok", "ok");
            //await PageService.Instance.PushAsync(new ExercicePage(vm));
        }
    }
}
