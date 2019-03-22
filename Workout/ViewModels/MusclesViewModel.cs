
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
        private ObservableCollection<Muscle> _muscles = new ObservableCollection<Muscle>();

        public ObservableCollection<Muscle> Muscles
        {
            get { return _muscles; }
            private set { SetValue(ref _muscles, value); }
        }

        public Muscle _selectedMuscle;
        public Muscle SelectedMuscle
        {
            get { return _selectedMuscle; }
            set { SetValue(ref _selectedMuscle, value); }
        }

        public ICommand SelectMuscleCommand { get; private set; }

        public MusclesViewModel()
        {
            Muscles = JsonStatam.getAllMuscles();
            SelectMuscleCommand = new Command<Muscle>(async m => await DetailMuscle(m));
        }


        private async Task DetailMuscle(Muscle muscle)
        {
            if (muscle == null) return;
            SelectedMuscle = null;
            await PageService.Instance.DisplayAlert(muscle.Nom, muscle.Groupe.ToString(), "Ok");
        }
    }
}
