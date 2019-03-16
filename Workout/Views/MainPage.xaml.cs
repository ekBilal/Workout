using Workout.ViewModels;
using Xamarin.Forms;

namespace Workout.Views
{
    public partial class MainPage : ContentPage
    {
        public StartViewMode ViewModel
        {
            get { return BindingContext as StartViewMode; }
            set { BindingContext = value; }
        }
        public MainPage()
        {
            ViewModel = new StartViewMode(new PageService());
            InitializeComponent();

        }
    }
}
