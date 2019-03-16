using System;
using System.Collections.Generic;
using Workout.ViewModels;
using Xamarin.Forms;

namespace Workout.Views
{
    public partial class SeriePage : ContentPage
    {
        public SeriesViewModel ViewModel
        {
            get { return BindingContext as SeriesViewModel; }
            set { BindingContext = value; }
        }

        //public SeriePage():this(new SeriesViewModel()) { }
        public SeriePage(SeriesViewModel vm)
        {
            ViewModel = vm;
            InitializeComponent();
        }

        //todo afficher la difficulté réele

        void Handle_Clicked(object sender, EventArgs e)
        {
            info.IsVisible = !info.IsVisible;
            feedback.IsVisible = !feedback.IsVisible;
            timer.IsVisible = !timer.IsVisible;
        }
    }
}
