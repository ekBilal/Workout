﻿using System.Collections.ObjectModel;
using System.Windows.Input;
using Workout.Models;
using Xamarin.Forms;

namespace Workout.ViewModels
{
    public class EntrainementsViewModel : BaseViewModel
    {

        private Entrainement _selectedEntrainement;
        private readonly IPageService _pageService;
        private ObservableCollection<Entrainement> _entrainements = new ObservableCollection<Entrainement>();


        public ObservableCollection<Entrainement> Entrainements
        {
            get { return _entrainements; }
            private set { SetValue(ref _entrainements, value); }
        }

        public Entrainement SelectedEntrainement
        {
            get { return _selectedEntrainement; }
            set { SetValue(ref _selectedEntrainement, value); }
        }

        public ICommand SelectedEntrainementCommand { get; private set; }

        public EntrainementsViewModel(IPageService pageService)
        {
            _pageService = pageService;
            SelectedEntrainementCommand = new Command<Entrainement>(e => SelectedEntrainament(e));
            Init();
        }

        private void Init()
        {
            Entrainement e = new Entrainement { Nom = "FullBody" };
            for(int i = 0; i<10; i++)
            {
                _entrainements.Add(new Entrainement { Nom = "Entainment " + i });
            }
        }

        private void SelectedEntrainament(Entrainement entrainement)
        {
            if (_selectedEntrainement == null) return;
            _selectedEntrainement = null;
            //Todo chager entraiment.Nom par entainement.ToString();
            _pageService.DisplayAlert("yolo", entrainement.Nom,"ok");
        }
    }
}
