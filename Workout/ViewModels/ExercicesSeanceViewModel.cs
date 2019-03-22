using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Workout.Models;
using Workout.Views;
using Xamarin.Forms;

namespace Workout.ViewModels
{
    public class ExercicesSeanceViewModel: ExercicesViewModel
    {
        private Seance _seance;
        public Seance Seance
        {
            get { return _seance; }
            private set { SetValue(ref _seance, value); }
        }

        private Exercice _selectedExercice;
        public new Exercice SelectedExercice
        {
            get { return _selectedExercice; }
            set
            {
                SetValue(ref _selectedExercice, value);
            }
        }

        public new ICommand SelectExerciceCommand { get; private set; }

        public ExercicesSeanceViewModel(ObservableCollection<Exercice> exercices, Seance seance):base(exercices)
        {
            Seance = seance;
            SelectExerciceCommand = new Command<Exercice>(async e => await SelectExercice(e));
        }

        private async Task SelectExercice(Exercice exercice)
        {
            if (exercice == null) return;
            SelectedExercice = null;
            var series = Seance.Series.Where(e => e.Exercice == exercice);
            var ls = series.ToList();
            await PageService.Instance.PushModalAsync(new SeriePage(new SeriesViewModel(ls)));
            Exercices.Remove(exercice);
        }

#pragma warning disable CS1998 // Cette méthode async n'a pas d'opérateur 'await' et elle s'exécutera de façon synchrone
        public async Task Fin()
#pragma warning restore CS1998 // Cette méthode async n'a pas d'opérateur 'await' et elle s'exécutera de façon synchrone
        {
            PageService.Instance.ChangeMainPage(new MainPage());
        }
    }
}