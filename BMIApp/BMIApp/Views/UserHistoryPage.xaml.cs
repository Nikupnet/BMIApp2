using BMIApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace BMIApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new UserHistoryViewModel();
        }
    }
}