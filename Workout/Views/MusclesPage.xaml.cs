using Workout.ViewModels;
using Xamarin.Forms;

namespace Workout.Views
{
    public partial class MusclesPage : ContentPage
    {
        public MusclesViewModel ViewModel
        {
            get { return BindingContext as MusclesViewModel; }
            set { BindingContext = value; }
        }

        public MusclesPage()
        {
            ViewModel = new MusclesViewModel();
            InitializeComponent();
        }

        void OnMuscleSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectMuscleCommand.Execute(e.SelectedItem);
        }
    }
}
