
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;

using Workout.Models;
using Workout.Servives;

using Xamarin.Forms;

namespace Workout.ViewModels
{
    public class MusclesViewModel : BaseViewModel
    {
        private readonly IPageService _pageService;
        public Muscle _selectedMuscle;
        private ObservableCollection<Muscle> _muscles = new ObservableCollection<Muscle>();

        public ObservableCollection<Muscle> Muscles
        {
            get { return _muscles; }
            private set { SetValue(ref _muscles, value); }
        }

        public Muscle SelectedMuscle
        {
            get { return _selectedMuscle; }
            set { SetValue(ref _selectedMuscle, value); }
        }

        public ICommand SelectMuscleCommand { get; private set; }

        public MusclesViewModel(IPageService pageService)
        {
            _pageService = pageService;
            Muscles = JsonStatam.getMuscles();
            SelectMuscleCommand = new Command<Muscle>(async m => await DetailMuscle(m));
        }


        private async Task DetailMuscle(Muscle muscle)
        {
            if (muscle == null) return;
            SelectedMuscle = null;
            await _pageService.DisplayAlert(muscle.Nom, muscle.Groupe.ToString(), "Ok");
        }
    }
}
