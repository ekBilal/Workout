using System.Collections.Generic;
using System.Collections.ObjectModel;

using Workout.Models;
namespace Workout.ViewModels
{
    public class SeriesViewModel : BaseViewModel
    {
        private ObservableCollection<Serie> _series;
        public ObservableCollection<Serie> Series
        {
            get {return _series;}
            private set {SetValue(ref _series, value);}
        }

        public Serie Serie
        {
            get { return Series[1]; }
        }

        public string Cibles
        {
            get
            {
                string txt = "Cible";
                if (Serie.Exercice.Cibles.Count > 1)
                    txt += "s";
                foreach(Muscle m in Serie.Exercice.Cibles)
                {
                    txt += m.Nom+" ";
                }
                return txt;
            }
        }

        public SeriesViewModel(IList<Serie> series)
        {

            Series = new ObservableCollection<Serie>(series);
        }
    }
}

