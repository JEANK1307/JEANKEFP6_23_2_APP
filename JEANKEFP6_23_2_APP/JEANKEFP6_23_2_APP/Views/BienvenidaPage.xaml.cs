using JEANKEFP6_23_2_APP.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace JEANKEFP6_23_2_APP.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BienvenidaPage : ContentPage
    {
        //Se realiza el anclaje entre esta vista y el VM que le da la 
        //funcionalidad
        UserViewModel viewModel;

        public BienvenidaPage()
        {
            InitializeComponent();
            //Esto vincula la V con el VM y además crea la instancia del obj
            this.BindingContext = viewModel = new UserViewModel();
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            GlobalObjects.MyLocalUser = await viewModel.GetUserDataAsync();      
            await Navigation.PushAsync(new PreguntaPage());
        }

        private void BtnAsks_Clicked(object sender, EventArgs e)
        {

        }
    }
}