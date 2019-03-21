using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Workout.Models;
using Xamarin.Forms;
using Workout.Servives;
using Workout.Views;

namespace Workout.ViewModels
{
    public class StartViewMode:BaseViewModel
    {
        private readonly IPageService _pageService;

        private ObservableCollection<Exercice.Type> _type;
        public ObservableCollection<Exercice.Type> Type
        {
            get { return _type; }
            private set { SetValue(ref _type, value); }
        }

        private ObservableCollection<Muscle> _muscle;
        public ObservableCollection<Muscle> Muscle
        {
            get { return _muscle; }
            private set { SetValue(ref _muscle, value); }
        }

        private Exercice.Type _selectedType;
        public Exercice.Type SelectedType
        {
            get { return _selectedType; }
            set { SetValue(ref _selectedType, value); }
        }

        private string _selectedGroupe;
        public string SelectedGroupe
        {
            get { return _selectedGroupe; }
            set { SetValue(ref _selectedGroupe, value); }
        }

        private string _selectedGoal;
        public string SelectedGoal
        {
            get { return _selectedGoal; }
            set { SetValue(ref _selectedGoal, value); }
        }

        private ObservableCollection<Exercice> mesExercices=new ObservableCollection<Exercice>();

        public ICommand StartCommand { get; private set; }

        public StartViewMode() : this(new PageService()) { }
        public StartViewMode(IPageService pageService)
        {
            _pageService = pageService;
            var type = Enum.GetValues(typeof(Exercice.Type));
            var muscle = JsonStatam.getMuscles();
            _type = new ObservableCollection<Exercice.Type>((IEnumerable<Exercice.Type>)type);
            StartCommand = new Command(Start);
        }

        private void Start()
        {
            Groupe groupe;
            switch (_selectedGroupe)
            {
                case "bas du corps":
                    groupe = Groupe.bas_du_corps;
                    break;
                case "haut du corps":
                    groupe = Groupe.haut_du_corps;
                    break;
                default:
                    groupe = Groupe.non_def;
                    break;
            }

            var exercices = JsonStatam.getExercice().Where(ex => ex.Types == SelectedType);
            var muscles = JsonStatam.getMuscles().Where(m=> true);
            if (groupe != Groupe.non_def)
                muscles = muscles.Where(m=>m.Groupe==groupe);

            foreach (Muscle muscle in muscles)
            {
                GetExercice(muscle, exercices);
            }

            CreerUneSeance();

        }

        private void GetExercice(Muscle muscle, IEnumerable<Exercice> e)
        {
            var exercices = e.Where(ex => ex.Cibles.Contains(muscle)).ToArray();
            if (exercices.Count() <= 0) return;
            var rnd = new Random(DateTime.Now.Millisecond);

            int ticks = rnd.Next(exercices.Count());

            if (!mesExercices.Contains(exercices[ticks]))
            {
                mesExercices.Add(exercices[ticks]);
                return;
            }

            for (int i = ticks+1; i < exercices.Count(); i++)
            {
                if (!mesExercices.Contains(exercices[i]))
                {
                    mesExercices.Add(exercices[i]);
                    return;
                }
            }
            for(int i = ticks-1; i >=0; i--)
            {
                if (!mesExercices.Contains(exercices[i]))
                {
                    mesExercices.Add(exercices[i]);
                    return;
                }
            }
        }

        private void CreerUneSeance()
        {
            Seance seance = new Seance { Series = new ObservableCollection<Serie>() };
            var repos = 90;
            var nbRep = 10;
            switch (SelectedGoal)
            {
                case "endurance":
                    nbRep = 12;
                    repos = 60;
                    break;
                case "force":
                    nbRep = 6;
                    repos = 180;
                    break;
                case "masse":
                    repos = 90;
                    nbRep = 10;
                    break;
                case "tonicité":
                    repos = 60;
                    nbRep = 12;
                    break;
            }

            foreach(Exercice exercice in mesExercices)
            {
                for(int i = 0; i<3; i++)
                    seance.Series.Add(new Serie { Exercice = exercice, NbReps = nbRep, Repos=repos });
            }

            JsonStatam.Save(seance);
            _pageService.ChangeMainPage(new ExercicesPage(new ExercicesSeanceViewModel(mesExercices,seance)));
            mesExercices = new ObservableCollection<Exercice>();
        }
    }
}
