using System;
using System.Collections.Generic;
using Workout.ViewModels;
using Xamarin.Forms;

namespace Workout.Views
{
    public partial class ExerciceDetailPage : ContentPage
    {
        public ExerciceViewModel ViewModel
        {
            get { return BindingContext as ExerciceViewModel; }
            set { BindingContext = value; }
        }

        public ExerciceDetailPage() :this(new ExerciceViewModel()) { }
        public ExerciceDetailPage(ExerciceViewModel exercice)
        {
            ViewModel = exercice;
            InitializeComponent();
        }
    }
}