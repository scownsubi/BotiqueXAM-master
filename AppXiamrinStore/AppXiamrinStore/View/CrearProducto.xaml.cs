using AppXiamrinStore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppXiamrinStore.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CrearProducto : ContentPage
	{
		public CrearProducto ()
		{
			InitializeComponent ();
            //this.btnSiguiente.Clicked += OnBtnSiguiente;
            this.btnCrear.Clicked += OnBtnCrear;
        }
        /*private async void OnBtnSiguiente(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.ListarBoutique());
        }*/

        private async void OnBtnCrear(object sender, EventArgs e)
        {
            Console.WriteLine("Creando el registro");

            // Crear el registro en la base datos SQLite

            await App.Database.CrearRegistroAsync(new Producto
            {
                Nombre = nombreEntry.Text,
                Categoria = categoriaEntry.Text,
                Precio = precioEntry.Text,
                Proveedor = proveedorEntry.Text,
                Ruta = rutaEntry.Text,
            });

            // Setear los campos en blanco en la vista
            nombreEntry.Text = string.Empty;
            categoriaEntry.Text = string.Empty;
            precioEntry.Text = string.Empty;
            proveedorEntry.Text = string.Empty;
            rutaEntry.Text = string.Empty;

            await Navigation.PushAsync(new View.ListarBoutique());

            // Mostrar el registro en un CollectionView
            //collectionView.ItemsSource = await App.Database.ObtenerRegistrosAsync();
        }
    }
}