using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppXiamrinStore
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            // Inicializar los botones
            this.btnInicio.Clicked += OnBtnInicio;
        }

        private async void OnBtnInicio(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.ListarBoutique());
        }
    }
}
