using System;
using BMIApp.Data;
using BMIApp.Models;
using Xamarin.Forms;

namespace BMIApp.Views
{
    public partial class UserItemPage : ContentPage
    {
        public UserItemPage()
        {
            InitializeComponent();
        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            var UserItem = (UserItem)BindingContext;
            UserItemDatabase database = await UserItemDatabase.Instance;
            await database.SaveItemAsync(UserItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteClicked(object sender, EventArgs e)
        {
            var UserItem = (UserItem)BindingContext;
            UserItemDatabase database = await UserItemDatabase.Instance;
            await database.DeleteItemAsync(UserItem);
            await Navigation.PopAsync();
        }

        async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        async void OnSelectClicked(object sender, EventArgs e)
        {
            var UserItem = (UserItem)BindingContext;
            await Navigation.PopAsync();
        }
    }
}
