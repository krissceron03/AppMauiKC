using System.Threading.Tasks;
using AppMauiP.Models;
using AppMauiP.Service;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppMauiP;

public partial class NuevoProductoPage : ContentPage
{
    private Producto _producto;
    private readonly APIService _APIService;
    public NuevoProductoPage(APIService apiservice)
    {
        InitializeComponent();
        _APIService = apiservice;
    }
       
	
    protected override void OnAppearing()
    {
        base.OnAppearing();
        _producto = BindingContext as Producto;
        if (_producto != null)
        {
            nombre.Text = _producto.nombre;
            cantidad.Text = _producto.cantidad.ToString();
            descripcion.Text = _producto.descripcion;
        }
    }
    private async void OnClickGuardarProducto(object sender, EventArgs e)
    {
        if (_producto != null)
        {
            _producto.nombre = nombre.Text;
            _producto.cantidad = Int32.Parse(cantidad.Text);
            _producto.descripcion = descripcion.Text;
            await _APIService.PutProducto(_producto.idProducto, _producto);
        }
        else
        {

            Producto producto = new Producto
            {
                idProducto = 0,
                nombre = nombre.Text,
                descripcion = descripcion.Text,
                cantidad = Int32.Parse(cantidad.Text)
            };

            await _APIService.PostProducto(producto);

        }
        await Navigation.PopModalAsync();

    }
}