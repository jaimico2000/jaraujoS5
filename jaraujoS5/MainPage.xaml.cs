using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace jaraujoS5
{
    public partial class MainPage : ContentPage
    {
        private string URL = "http://192.168.10.18/ws_uisrael/post.php";
        private readonly HttpClient cliente = new HttpClient();
        private ObservableCollection<estudiante> post;

        public MainPage()
        {
            InitializeComponent();
            Obtener();
        }

        public async void Obtener()
        {
            var contenido = await cliente.GetStringAsync(URL);
            List<estudiante> datosPost = JsonConvert.DeserializeObject<List<estudiante>>(contenido);
            post = new ObservableCollection<estudiante>(datosPost);
            listaEstudiantes.ItemsSource = post;
        }

        private async void btnConsultar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Insertar());
        }

        private void listaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var objetoEstudiante = (estudiante)e.SelectedItem;
            Navigation.PushAsync(new ActEliminar(objetoEstudiante));
        }
    }
}
