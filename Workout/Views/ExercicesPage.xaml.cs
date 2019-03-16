﻿using System;
using System.Collections.Generic;
using Workout.ViewModels;
using Xamarin.Forms;

namespace Workout.Views
{
    public partial class ExercicesPage : ContentPage
    {
        public ExercicesSeanceViewModel ViewModel
        {
            get { return BindingContext as ExercicesSeanceViewModel; }
            set { BindingContext = value; }
        }

        public ExercicesPage(ExercicesSeanceViewModel vm)
        {
            ViewModel =vm;
            InitializeComponent();
        }

        void OnExerciceSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectExerciceCommand.Execute(e.SelectedItem);
        }
    }
}