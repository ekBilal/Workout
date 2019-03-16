using Workout.Models;

namespace Workout.ViewModels
{
    public class SeanceViewModel : BaseViewModel
    {
        private Seance _seance;
        public Seance Seance
        {
            get { return _seance; }
            set { SetValue(ref _seance, value); }
        }
    }
}