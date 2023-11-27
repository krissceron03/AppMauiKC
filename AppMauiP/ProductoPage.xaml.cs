using AppMauiP.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Threading.Tasks;

namespace AppMauiP;

public partial class ProductoPage : ContentPage
{
    public ProductoPage()
    {
        InitializeComponent();
        //ListaProductos.ItemsSource = Utils.Utils.ListaProductos;
        ListaProductos.ItemsSource = new ObservableCollection<Producto>(Utils.Utils.ListaProductos);

    }
    private async void OnClicNuevoProducto(object sender, EventArgs e)
    {
        //Le dirige a la página de NuevoProductoPage (formulario)
        await Navigation.PushModalAsync(new NuevoProductoPage());
        var toast = Toast.Make("On Click Boton Nuevo Producto", ToastDuration.Short, 14);
        await toast.Show();
    }
    private async void OnClickShowDetails(object sender, SelectedItemChangedEventArgs e)
    {
        var toast = CommunityToolkit.Maui.Alerts.Toast.Make("Click en ver producto", ToastDuration.Short, 14);

        await toast.Show();
        Producto producto = e.SelectedItem as Producto;
        await Navigation.PushAsync(new DetalleProductoPage()
        {
            BindingContext = producto,
        });
    }
    //metodo de actualización
    protected override void OnAppearing()
    {
        base.OnAppearing();
        //listaProductos.ItemsSource = Utils.Utils.ListaProductos;
        ListaProductos.ItemsSource = new ObservableCollection<Producto>(Utils.Utils.ListaProductos);
    }
}