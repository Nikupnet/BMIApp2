using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BMIApp.Data;
using BMIApp.Models;

namespace BMIApp.Views
{
    public partial class BMICalc : ContentPage
    {
        public BMICalc()
        {
            InitializeComponent();

        }

        async void OnSaveClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Hello");

            var BmiItem = (BmiItem)BindingContext;
            Console.WriteLine("gfdgfdgf");

            BMIItemDatabase database = await BMIItemDatabase.Instance;
            await database.SaveItemAsync(BmiItem);
            await Navigation.PopAsync();
        }
    }


}