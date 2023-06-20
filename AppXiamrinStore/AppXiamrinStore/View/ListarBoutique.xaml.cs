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
    public partial class ListarBoutique : ContentPage
    {
        public ListarBoutique()
        {
            InitializeComponent();

            //this.btnEliminar.Clicked += OnBtnEliminar;
            this.btnRegresar.Clicked += OnBtnRegresar;
            this.btnAgregar.Clicked += OnBtnAgregar;
            this.btnActualizarDB.Clicked += OnBtnActualizarDB;
            this.listarRegistro();

            //this.btnEliminar.Clicked += OnBtnActualizar;
        }

        private async void listarRegistro()
        {
            collectionView.ItemsSource = await App.Database.ObtenerRegistrosAsync();
        }

        private async void OnBtnRegresar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MainPage());


        }

        private async void OnBtnAgregar(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new View.CrearProducto());


        }

        Producto lastSelection;
        void collectionView_SelectionChanged(System.Object sender, Xamarin.Forms.SelectionChangedEventArgs e)
        {
            lastSelection = e.CurrentSelection[0] as Producto;
        }

        private void OnBtnActualizar(System.Object sender, System.EventArgs e)
        {
          
            if (lastSelection != null)
            {
                //await App.Database.ActualizarRegistroAsync(lastSelection);

                //collectionView.ItemsSource = await App.Database.ObtenerRegistrosAsync();

                nombreEntry.Text = lastSelection.Nombre;
                categoriaEntry.Text = lastSelection.Categoria;
                precioEntry.Text = lastSelection.Precio;
                proveedorEntry.Text = lastSelection.Proveedor;

                this.formularioActualizar.IsVisible = true;

               // await App.Database.ActualizarRegistroAsync(lastSelection);

            }

        }

        private async void OnBtnActualizarDB(object sender, EventArgs e)
        {
            if (lastSelection != null)
            {

               
                lastSelection.Nombre = nombreEntry.Text;
                lastSelection.Precio= precioEntry.Text;
                lastSelection.Proveedor =proveedorEntry.Text;
                lastSelection.Categoria = categoriaEntry.Text;
                await App.Database.ActualizarRegistroAsync(lastSelection);
                collectionView.ItemsSource = await App.Database.ObtenerRegistrosAsync();
                this.formularioActualizar.IsVisible = false;

            }
        }


        // Delete
        async void OnBtnEliminar(System.Object sender, System.EventArgs e)
        {

            if (lastSelection != null)
            {
                if (await DisplayAlert("", "¿Está seguro de eliminar este registro?", "Si", "No"))
                {
                    await App.Database.EliminarRegistroAsync(lastSelection);
                    collectionView.ItemsSource = await App.Database.ObtenerRegistrosAsync();
                }

            }
        }
    }


    
}