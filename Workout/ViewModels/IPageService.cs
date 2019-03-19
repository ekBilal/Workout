using System.Threading.Tasks;
using Workout.Views;
using Xamarin.Forms;

namespace Workout.ViewModels
{
    public interface IPageService
    {
        Task<bool> DisplayAlert(string title, string message, string ok, string cancel);
        Task DisplayAlert(string title, string message, string ok);
        void ChangeMainPage(Page page);
        Task PushAsync(Page page);
        Task PushModalAsync(Page Page);
        Task PopModalAsync();
        Task PopAsync();
        Task PopToRootAsync();
    }
}
