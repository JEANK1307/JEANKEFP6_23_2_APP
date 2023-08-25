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
    public partial class PreguntasListPage : ContentPage
    {
        AskViewModel viewModel;

        public PreguntasListPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AskViewModel();
            LoadAskList();
        }

        private async void LoadAskList()
        {
            LvList.ItemsSource = await viewModel.GetAskAsync(GlobalObjects.MyLocalUser.IDUsuario);
        }
    }
}