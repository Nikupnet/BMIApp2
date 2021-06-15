using BMIApp.Models;
using BMIApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BMIApp.Views
{
    public partial class NewItemPage : ContentPage
    {
        public User Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewUserViewModel();
        }
    }
}