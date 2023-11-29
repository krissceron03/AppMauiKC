using AppMauiP.Models;
using System.Collections.ObjectModel;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using System.Threading.Tasks;
using AppMauiP.Service;

namespace AppMauiP;

public partial class ProductoPage : ContentPage
{
    private readonly APIService _APIService;
    public ProductoPage(APIService apiservice)
    {
        InitializeComponent();
        _APIService = apiservice;
        //ListaProductos.ItemsSource = new ObservableCollection<Producto>(Utils.Utils.ListaProductos);

    }
    //metodo de actualización
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        List<Producto> ListaProducto = await _APIService.GetProductos();
        var productos = new ObservableCollection<Producto>(ListaProducto);
        ListaProductos.ItemsSource = productos;
    } 

    private async void OnClicNuevoProducto(object sender, EventArgs e)
    {
        //Le dirige a la página de NuevoProductoPage (formulario)
        await Navigation.PushModalAsync(new NuevoProductoPage(_APIService));
        //var toast = Toast.Make("On Click Boton Nuevo Producto", ToastDuration.Short, 14);
        //await toast.Show();
    }

    private async void OnClickShowDetails(object sender, SelectedItemChangedEventArgs e)
    {
        var toast = CommunityToolkit.Maui.Alerts.Toast.Make("Click en ver producto", ToastDuration.Short, 14);

        await toast.Show();
        Producto producto = e.SelectedItem as Producto;
        await Navigation.PushModalAsync(new DetalleProductoPage(_APIService)
        {
            BindingContext = producto,
        });
    }
    
}