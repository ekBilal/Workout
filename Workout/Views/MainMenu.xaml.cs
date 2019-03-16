using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using Xamarin.Forms;

namespace Workout.Views
{
    public partial class MainMenu : MasterDetailPage
    {
        public ObservableCollection<MainMenuItem> MainMenuItems { get; set; }

        public MainMenu()
        {
            // Set the binding context to this code behind.
            BindingContext = this;

            // Build the Menu
            MainMenuItems = new ObservableCollection<MainMenuItem>()
            {
                new MainMenuItem() { Title = "Page One", TargetType = typeof(ExercicesPage) },
                new MainMenuItem() { Title = "Page Two", TargetType = typeof(MainPage) }
            };

            // Set the default page, this is the "home" page.
            Detail = new NavigationPage(new SeancesPage());
            InitializeComponent();
        }

        // When a MenuItem is selected.
        public void MainMenuItem_Selected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MainMenuItem;
            if (item != null)
            {
                Detail = new NavigationPage(item.Page);

                MenuListView.SelectedItem = null;
                IsPresented = false;
            }
        }
    }

    public class MainMenuItem
    {
        public string Title { get; set; }
        public Type TargetType { get; set; }

        private Page _page;
        public Page Page
        {
            get
            {
                if (_page == null)
                    Page = Activator.CreateInstance(TargetType) as Page;
                return _page;
            }
            set
            {
                _page = value;
            }
        }

    }

}
