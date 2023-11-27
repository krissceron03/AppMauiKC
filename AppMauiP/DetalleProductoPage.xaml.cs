using AppMauiP.Models;
using CommunityToolkit.Maui.Core;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppMauiP;

public partial class DetalleProductoPage : ContentPage
{
	private Producto _producto;

	public DetalleProductoPage()
	{
		InitializeComponent();
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
        Utils.Utils.ListaProductos.Remove(_producto);
        await Navigation.PopAsync();
    }

    private async void OnClickEditar(object sender, EventArgs e)
    {
        var toast = CommunityToolkit.Maui.Alerts.Toast.Make(_producto.nombre, ToastDuration.Short, 14);

        await toast.Show();
        await Navigation.PushAsync(new NuevoProductoPage()
        {
            BindingContext = _producto,
        });
    }
}