using JEANKEFP6_23_2_APP.ViewModels;
using JEANKEFP6_23_2_APP.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace JEANKEFP6_23_2_APP
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
