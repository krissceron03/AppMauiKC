using System.Threading.Tasks;
using AppMauiP.Models;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AppMauiP;

public partial class NuevoProductoPage : ContentPage
{
    private Producto _producto;
    public NuevoProductoPage()
	{
		InitializeComponent();
       
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

            Utils.Utils.ListaProductos.Add(producto);
           
        }
        await Navigation.PopModalAsync();

    }
}