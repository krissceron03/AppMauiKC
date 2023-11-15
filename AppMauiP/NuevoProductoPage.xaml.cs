using System.Threading.Tasks;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;
namespace AppMauiP;

public partial class NuevoProductoPage : ContentPage
{
	public NuevoProductoPage()
	{
		InitializeComponent();
	}
    private async void OnClickGuardarProducto(object sender, EventArgs e)
    {
        try
        {
            Utils.Utils.ListaProductos.Add(new Models.Producto
            {
                idProducto = 0,
                nombre = nombre.Text,
                descripcion = descripcion.Text,
                cantidad = Int32.Parse(cantidad.Text),
            }
        );
            //Al dar clic en guardar producto me redirige a la página principal (ProductoPage)
            await Navigation.PopModalAsync();
        }
        catch (Exception ex)
        {
            var toast = Toast.Make("Llene los campos", ToastDuration.Short, 14);
            await toast.Show();
        }

    }
}