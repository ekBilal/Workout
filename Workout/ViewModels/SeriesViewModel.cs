using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Workout.Models;
using Workout.Servives;
using Xamarin.Forms;

namespace Workout.ViewModels
{
    public class SeriesViewModel : BaseViewModel
    {
        private readonly IPageService _pageService;
        private readonly Service _service;

        private ObservableCollection<Serie> _series;
        public ObservableCollection<Serie> Series
        {
            get { return _series; }
            private set { SetValue(ref _series, value); }
        }

        private Serie _serie;
        public Serie Serie
        {
            get { return _serie; }
            private set { SetValue(ref _serie, value); }
        }

        public string Cibles
        {
            get
            {
                string txt = "Cible";
                if (Serie.Exercice.Cibles.Count > 1)
                    txt += "s";
                foreach (Muscle m in Serie.Exercice.Cibles)
                {
                    txt += m.Nom + " ";
                }
                return txt;
            }
        }

        private int _charge;
        public int Charge
        {
            get { return _charge; }
            set { SetValue(ref _charge, value); }
        }

        private int _reps;
        public int Reps
        {
            get { return _reps; }
            set { SetValue(ref _reps, value); }
        }



        public ICommand ChangeExerciceCommand { get; private set; }
        public ICommand SavePerfCommand { get; private set; }

        public SeriesViewModel(IList<Serie> series, IPageService pageService)
        {
            Series = new ObservableCollection<Serie>(series);
            Serie = Series[0];
            ChangeExerciceCommand = new Command(ChangeExercice);
            SavePerfCommand = new Command(SavePerf);
            _pageService = pageService;
            _service = Service.Instance;

        }

        private void SavePerf()
        {
            var historique = new Historique { Date = DateTime.Today, Charge=Charge, Exercice=Serie.Exercice, Reps=Reps};
            Reps = Charge = 0;
            _service.SaveHistorique(historique);
        }

        private void ChangeExercice()
        {
            if (Series.Count <= 1)
            {
                _pageService.PopAsync();
                return;
            }
            SavePerf();
            Series.Remove(Serie);
            Serie = Series[0];
        }
    }
}
