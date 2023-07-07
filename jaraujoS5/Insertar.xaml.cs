using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace jaraujoS5
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Insertar : ContentPage
    {
        private string URL = "http://192.168.10.18/ws_uisrael/post.php";
        public Insertar()
        {
            InitializeComponent();
        }

        private void btnInsertar_Clicked(object sender, EventArgs e)
        {
            try
            {
                WebClient cliente = new WebClient();
                var datos = new System.Collections.Specialized.NameValueCollection();
                datos.Add("codigo", txtCodigo.Text);
                datos.Add("nombre", txtNombre.Text);
                datos.Add("apellido", txtApellido.Text);
                datos.Add("edad", txtEdad.Text);

                cliente.UploadValues(URL, "POST", datos);

                var mensaje = "Dato Ingreasdo con exito";
                DependencyService.Get<Mensaje>().longAlert(mensaje);

                Navigation.PushAsync(new MainPage());

            }
            catch (Exception ex)
            {

                DependencyService.Get<Mensaje>().longAlert(ex.Message);
            }
        }
    }
}