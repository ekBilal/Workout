using Workout.Models;
using Workout.ViewModels;
using Xamarin.Forms;

namespace Workout.Views
{
    public partial class SeancesPage : ContentPage
    {
        public SeancesViewModel ViewModel
        {
            get { return BindingContext as SeancesViewModel; }
            set { BindingContext = value; }
        }

        public SeancesPage()
        {
            ViewModel = new SeancesViewModel();
            InitializeComponent();
        }
    }
}
