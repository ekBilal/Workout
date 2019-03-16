using Workout.Models;

namespace Workout.ViewModels
{
    public class ExerciceViewModel : BaseViewModel
    {
        private Exercice _exercice;
        public Exercice Exercice
        {
            get { return _exercice; }
            set { SetValue(ref _exercice, value); }
        }

        public string Cibles
        {
            get
            {
                var cible = "Cible :\n";
                foreach(Muscle muscle in Exercice.Cibles)
                {
                    cible += muscle + "\n";
                }
                return cible;
            }
        }
    }
}
