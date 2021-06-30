using System;
using BMIApp.Data;
using BMIApp.Models;
using Xamarin.Forms;

namespace BMIApp.Views
{
    public partial class UserListPage : ContentPage
    {
        public UserListPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            UserItemDatabase database = await UserItemDatabase.Instance;
            listView.ItemsSource = await database.GetItemsAsync();
        }

        async void OnItemAdded(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserItemPage
            {
                BindingContext = new UserItem()
            });
        }

        async void OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new UserItemPage
                {
                    BindingContext = e.SelectedItem as UserItem
                });
            }
        }
    }
}
