using System;
using System.ComponentModel;
using Workout.ViewModels;
using Xamarin.Forms;

namespace Workout.Models
{
    public class MuscleColor : Muscle, INotifyPropertyChanged
    {
        public Color _color = Color.Black;
        public Color color
        {
            get
            {
                return _color;
            }
            set
            {
                _color = value;
                OnPropertyChanged("color");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

}
