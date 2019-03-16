using System;
using System.Collections.Generic;
using Workout.ViewModels;
using Xamarin.Forms;

namespace Workout.Views
{
    public partial class EntrainementsPage : ContentPage
    {
        private PageService _pageService;
        public EntrainementsViewModel ViewModel
        {
            get { return BindingContext as EntrainementsViewModel; }
            set { BindingContext = value; }
        }

        public EntrainementsPage()
        {
            _pageService = new PageService();
            ViewModel = new EntrainementsViewModel(_pageService);
            InitializeComponent();
        }

        void OnEntrainementSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectedEntrainementCommand.Execute(e.SelectedItem);
        }
    }
}
