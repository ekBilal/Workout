using Workout.ViewModels;
using Xamarin.Forms;

namespace Workout.Views
{
    public partial class AddMusclePage : ContentPage
    {
        public ExercicesViewModels2 ViewModel
        {
            get { return BindingContext as ExercicesViewModels2; }
            set { BindingContext = value; }
        }


        public AddMusclePage (): this(new ExercicesViewModels2(new PageService()))
        {

        }

        public AddMusclePage( ExercicesViewModels2 vm)
        {
            ViewModel = vm;
            InitializeComponent();
        }
    }
}
