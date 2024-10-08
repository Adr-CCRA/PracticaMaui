using PlatosComida.ConexionDatos;
using PlatosComida.Models;

namespace PlatosComida.Pages;

[QueryProperty(nameof(plato), "Plato")]
public partial class GestionPlatosPage : ContentPage
{
    private readonly IRestConexionDatos restConexionDatos;
    private Platos _plato;
    private bool _esNuevo;

    public Platos plato
    {
        get => _plato;
        set
        {
            _esNuevo = esNuevo(value);
            _plato = value;
            OnPropertyChanged();
        }
    }

    public GestionPlatosPage(IRestConexionDatos restConexionDatos)
    {
        InitializeComponent();
        this.restConexionDatos = restConexionDatos;
        BindingContext = this;
    }

    bool esNuevo(Platos plato)
    {
        return plato.Id == 0;
    }

    async void OnCancelClic(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    async void OnGuardarClic(object sender, EventArgs e)
    {
        // Validación de los campos
        if (string.IsNullOrWhiteSpace(plato.Nombre) || plato.Costo <= 0 || string.IsNullOrWhiteSpace(plato.Ingredientes))
        {
            await DisplayAlert("Error", "Todos los campos son obligatorios y el costo debe ser mayor que 0.", "OK");
            return;
        }

        if (_esNuevo)
        {
            await restConexionDatos.AddPlatoAsync(plato);
        }
        else
        {
            await restConexionDatos.UpdatePlatoAsync(plato);
        }

        await Shell.Current.GoToAsync("..");
    }

    async void OnEliminarClic(object sender, EventArgs e)
    {
        var respuesta = await DisplayAlert("Confirmar", "¿Está seguro de eliminar este plato?", "Sí", "No");
        if (respuesta)
        {
            await restConexionDatos.DeletePlatoAsync(plato.Id);
            await Shell.Current.GoToAsync("..");
        }
    }
}
