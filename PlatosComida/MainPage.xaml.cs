using PlatosComida.ConexionDatos;
using PlatosComida.Models;
using PlatosComida.Pages;
using System.Diagnostics;
using System.Linq;

namespace PlatosComida
{
    public partial class MainPage : ContentPage
    {
        private readonly IRestConexionDatos conexionDatos;

        public MainPage(IRestConexionDatos conexionDatos)
        {
            InitializeComponent();
            this.conexionDatos = conexionDatos;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            // Obtener los platos del servidor
            var platos = await conexionDatos.GetPlatosAsync();
            // Ordenar aleatoriamente la lista
            coleccionPlatosView.ItemsSource = platos.OrderBy(p => Guid.NewGuid()).ToList();
        }

        // Evento Add
        async void OnAddPlatoClic(object sender, EventArgs e)
        {
            Debug.WriteLine("[EVENTO] Botón AddPlato clickeado");
            var param = new Dictionary<string, object> {
                { nameof(Platos), new Platos() }
            };
            await Shell.Current.GoToAsync(nameof(GestionPlatosPage), param);
        }

        // Evento clic en un plato de la lista
        async void OnelementoCambiado(object sender, SelectionChangedEventArgs e)
        {
            Debug.WriteLine("[EVENTO] Elemento cambiado");
            var param = new Dictionary<string, object> {
                { nameof(Platos), e.CurrentSelection.FirstOrDefault() as Platos }
            };
            await Shell.Current.GoToAsync(nameof(GestionPlatosPage), param);
        }
    }
}
