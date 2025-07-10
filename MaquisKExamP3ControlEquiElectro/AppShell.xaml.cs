using MaquisKExamP3ControlEquiElectro.Views;
using Microsoft.Maui.Controls;

namespace MaquisKExamP3ControlEquiElectro
{
    public partial class AppShell : Shell
    {
        public AppShell(RegistroPage registroPage, ListaPage listaPage, LogsPage logsPage)
        {
            InitializeComponent();

            Items.Clear();

            Items.Add(new TabBar
            {
                Items =
                {
                    new ShellContent
                    {
                        Title = "Registrar",
                        Content = registroPage
                    },
                    new ShellContent
                    {
                        Title = "Lista de Dispositivos",
                        Content = listaPage
                    },
                    new ShellContent
                    {
                        Title = "Ver Logs",
                        Content = logsPage
                    }
                }
            });
        }
    }
}
