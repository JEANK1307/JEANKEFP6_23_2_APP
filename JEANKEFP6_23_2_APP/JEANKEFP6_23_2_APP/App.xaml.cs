using JEANKEFP6_23_2_APP.Services;
using JEANKEFP6_23_2_APP.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JEANKEFP6_23_2_APP
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            MainPage = new NavigationPage(new BienvenidaPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
