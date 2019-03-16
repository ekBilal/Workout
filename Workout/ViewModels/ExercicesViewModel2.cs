using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Workout.Models;
using Workout.Servives;
using Workout.Views;
using Xamarin.Forms;

namespace Workout.ViewModels
{
    public class ExercicesViewModels2 : BaseViewModel
    {
        private readonly IPageService _pageService;
        private ObservableCollection<MuscleColor> _muscles;
        public ObservableCollection<MuscleColor> Muscles
        {
            get { return _muscles; }
            private set { SetValue(ref _muscles, value); }
        }

        private Muscle _selectedMuscle;
        public Muscle SelectedMuscle
        {
            get { return _selectedMuscle; }
            set { SetValue(ref _selectedMuscle, value); }
        }


        private string _muscle;
        public string Muscle
        {
            get { return _muscle; }
            set { SetValue(ref _muscle, value); }
        }

        public ICommand SelectMuscleCommand { get; private set; }
        public ICommand SaveCommand { get; private set; }
        public ICommand SaveMuscleCommand { get; private set; }
        public ICommand AddMuscleCommand { get; private set; }
        private Stack<Exercice> _done =  new Stack<Exercice>();
        private Stack<Exercice> _todo = JsonStatam.getExercice();
        private Exercice _exercice;
        public Exercice Exercice
        {
            get { return _exercice; }
            set { SetValue(ref _exercice, value); }
        }

        public ExercicesViewModels2(IPageService pageService)
        {
            _pageService = pageService;
            Muscles = JsonStatam.getMusclesColor();
            Exercice = _todo.Pop();
            SelectMuscleCommand = new Command<MuscleColor>(SelectMuscle);
            SaveCommand = new Command(Save);
            SaveMuscleCommand = new Command(SaveMuscle);
            AddMuscleCommand = new Command(AddMuscle);
        }

        private void Save()
        {
            foreach(MuscleColor mc in Exercice.Cibles)
            {
                mc.color = Color.Black;
            }

            _done.Push(Exercice);
            JsonStatam.Save(_done);
            if (_todo.Count > 0)
                Exercice = _todo.Pop();
        }

        private void SaveMuscle()
        {
            if (string.IsNullOrEmpty(Muscle))
            {
                _pageService.DisplayAlert("Attention", "Aucun nom entré", "ok");
                return;
            }
            var id = _muscles.Max(m => m.IdMuscle);
            var muscle = new MuscleColor { Nom = Muscle, IdMuscle = id++ };
            Muscles.Add(muscle);

            JsonStatam.Save(new ObservableCollection<Muscle>(_muscles));
            _pageService.PopModalAsync();
        }

        private void SelectMuscle(MuscleColor muscle)
        {
            if (muscle == null) return;
            SelectedMuscle = null;
            if (!Exercice.Cibles.Contains(muscle))
            {
                Exercice.Cibles.Add(muscle);
                muscle.color = Color.Green;
            }
            else
            {
                Exercice.Cibles.Remove(muscle);
                muscle.color = Color.Black;
            }
        }

        private void AddMuscle()
        {
            _pageService.PushModalAsync(new AddMusclePage(this));
        }

    }
}
