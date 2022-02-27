using STVMatrimony.Models;
using STVMatrimony.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace STVMatrimony.Views
{
    public partial class NewItemPage : ContentPage
    {
        public VwCustomerBasicInfo Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}