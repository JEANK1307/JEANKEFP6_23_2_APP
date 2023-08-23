using JEANKEFP6_23_2_APP.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace JEANKEFP6_23_2_APP.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}