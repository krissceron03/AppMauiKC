using AppMauiP.Models;
using AppMauiP.Service;
using CommunityToolkit.Maui.Core;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppMauiP;

public partial class DetalleProductoPage : ContentPage
{
	private Producto _producto;
    private readonly APIService _APIService;

    public DetalleProductoPage(APIService apiservice)
	{
		InitializeComponent();
        _APIService = apiservice;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _producto = BindingContext as Producto;
      
            nombre.Text = _producto.nombre;
            cantidad.Text = _producto.cantidad.ToString();
            descripcion.Text = _producto.descripcion;
        
        
    }

    private async void OnClickBorrar(object sender, EventArgs e)
    {

        await _APIService.DeleteProducto(_producto.idProducto);
        await Navigation.PopModalAsync();
    }

    private async void OnClickEditar(object sender, EventArgs e)
    {
        var toast = CommunityToolkit.Maui.Alerts.Toast.Make(_producto.nombre, ToastDuration.Short, 14);

        await toast.Show();
        await Navigation.PushModalAsync(new NuevoProductoPage(_APIService)
        {
            BindingContext = _producto,
        });
    }
}