using Workout.ViewModels;
using Xamarin.Forms;

namespace Workout.Views
{
    public partial class AddExercicesPage : ContentPage
    {
        public ExercicesViewModels2 ViewModel
        {
            get { return BindingContext as ExercicesViewModels2; }
            set { BindingContext = value; }
        }

        public AddExercicesPage()
        {
            ViewModel = new ExercicesViewModels2(new PageService());
            InitializeComponent();
        }

        public AddExercicesPage(ExercicesViewModels2 exercicesView)
        {
            ViewModel = exercicesView;
            InitializeComponent();
        }

        void OnMuscleSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ViewModel.SelectMuscleCommand.Execute(e.SelectedItem);
        }
    }
}