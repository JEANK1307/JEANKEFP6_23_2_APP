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
    public partial class PreguntaPage : ContentPage
    {

        AskViewModel viewModel;

        public PreguntaPage()
        {
            InitializeComponent();
            BindingContext = viewModel = new AskViewModel();
        }

        private async void BtnAdd_Clicked(object sender, EventArgs e)
        {
            bool R = await viewModel.AddAskAsync(TxtAsk.Text.Trim(),
                                                  TxtImageUrl.Text.Trim(),
                                                  TxtDetail.Text.Trim()
                                                  );

            if (R)
            {
                await DisplayAlert(":)", "Pregunta creada!", "OK");
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(":)", "Algo salió mal...", "OK");
            }
        }

        private async void BtnCancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }


}