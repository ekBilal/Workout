using System;
using System.Collections.Generic;
using Workout.ViewModels;
using Xamarin.Forms;

namespace Workout.Views
{
    public partial class EntrainementsPage : ContentPage
    {
        public EntrainementsViewModel ViewModel
        {
            get { return BindingContext as EntrainementsViewModel; }
            set { BindingContext = value; }
        }

        public EntrainementsPage()
        {
            ViewModel = new EntrainementsViewModel();
            InitializeComponent();
        }

        void OnEntrainementSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectedEntrainementCommand.Execute(e.SelectedItem);
        }
    }
}
