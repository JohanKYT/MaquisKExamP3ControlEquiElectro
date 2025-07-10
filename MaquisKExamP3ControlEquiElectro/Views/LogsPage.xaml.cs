using MaquisKExamP3ControlEquiElectro.ViewModels;

namespace MaquisKExamP3ControlEquiElectro.Views;

public partial class LogsPage : ContentPage
{
    LogsViewModel _vm;

    public LogsPage()
    {
        InitializeComponent();
        _vm = new LogsViewModel();
        BindingContext = _vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.CargarLogsAsync();
    }
    private async void OnAbrirCarpetaClicked(object sender, EventArgs e)
    {
        try
        {
            string carpeta = FileSystem.AppDataDirectory;
            // Esto es la carpeta donde están tus archivos de logs y con el laucher la abrimos cuando damos click al boton que creamos
            await Launcher.OpenAsync(new Uri(carpeta));
        }
        catch (Exception ex)
        {
            await DisplayAlert("Error", "No se pudo abrir la carpeta: " + ex.Message, "OK");
        }
    }
}