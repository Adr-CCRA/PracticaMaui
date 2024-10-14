using PlatosComida.Pages;
namespace PlatosComida
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(GestionPlatosPage),typeof(GestionPlatosPage));
        }
    }
}
