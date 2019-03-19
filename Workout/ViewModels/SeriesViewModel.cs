using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Workout.Models;
using Xamarin.Forms;

namespace Workout.ViewModels
{
    public class SeriesViewModel : BaseViewModel
    {
        private readonly IPageService _pageService;

        private ObservableCollection<Serie> _series;
        public ObservableCollection<Serie> Series
        {
            get { return _series; }
            private set { SetValue(ref _series, value); }
        }

        public Serie _serie;
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

        public ICommand ChangeExerciceCommand { get; private set; }

        public SeriesViewModel(IList<Serie> series, IPageService pageService)
        {
            Series = new ObservableCollection<Serie>(series);
            Serie = Series[0];
            ChangeExerciceCommand = new Command(ChangeExercice);
            _pageService = pageService;

        }

        private void ChangeExercice()
        {
            if (Series.Count <= 1)
            {
                _pageService.PopAsync();
                return;
            }
            Series.Remove(Serie);
            Serie = Series[0];
        }
    }
}
