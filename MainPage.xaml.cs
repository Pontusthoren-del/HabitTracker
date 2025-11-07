using HabitTracker.Models;
using Microsoft.Maui.Controls;
namespace HabitTracker
{
    public partial class MainPage : ContentPage
    {
        List<Vana> vanor = new();
        public MainPage()
        {
            InitializeComponent();
        }
        private async void OnTraningClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new KategoriPage("Träning"));
        }

        private async void OnPluggClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new KategoriPage("Plugg"));
        }
    }
}
