using Workout.ViewModels;
using Xamarin.Forms;

namespace Workout.Views
{
    public partial class StartPage : ContentPage
    {
        public StartViewMode ViewModel
        {
            get { return BindingContext as StartViewMode; }
            set { BindingContext = value; }
        }
        public StartPage()
        {
            ViewModel = new StartViewMode();
            InitializeComponent();

        }
    }
}
