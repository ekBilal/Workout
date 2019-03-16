using Workout.Models;
using Workout.ViewModels;
using Xamarin.Forms;

namespace Workout.Views
{
    public partial class SeancesPage : ContentPage
    {
        private PageService _pageService;
        public SeancesViewModel ViewModel
        {
            get { return BindingContext as SeancesViewModel; }
            set { BindingContext = value; }
        }

        public SeancesPage()
        {
            _pageService = new PageService();
            ViewModel = new SeancesViewModel(_pageService);
            InitializeComponent();
        }
    }
}
