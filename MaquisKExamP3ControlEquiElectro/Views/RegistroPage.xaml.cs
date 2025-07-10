using MaquisKExamP3ControlEquiElectro.Data;
using MaquisKExamP3ControlEquiElectro.ViewModels;

namespace MaquisKExamP3ControlEquiElectro.Views;

public partial class RegistroPage : ContentPage
{
    RegistroViewModel _vm;

    public RegistroPage(AppDatabase db)
    {
        InitializeComponent();
        _vm = new RegistroViewModel(db);
        BindingContext = _vm;
    }

    private void OnLimpiarClicked(object sender, EventArgs e)
    {
        _vm.Dispositivo = string.Empty;
        _vm.Marca = string.Empty;
        _vm.GarantiaActiva = false;
        _vm.VidaUtilMeses = 0;
    }
}