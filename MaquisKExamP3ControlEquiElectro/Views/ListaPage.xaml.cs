using MaquisKExamP3ControlEquiElectro.Data;
using MaquisKExamP3ControlEquiElectro.Models;
using MaquisKExamP3ControlEquiElectro.Services;
using MaquisKExamP3ControlEquiElectro.ViewModels;

namespace MaquisKExamP3ControlEquiElectro.Views;

public partial class ListaPage : ContentPage
{
    ListaViewModel _vm;
    AppDatabase _db;
    RegistroViewModel _registroVM;

    public ListaPage(AppDatabase db)
    {
        InitializeComponent();
        _db = db;
        _vm = new ListaViewModel(_db);
        _registroVM = new RegistroViewModel(_db);
        BindingContext = _vm;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _vm.CargarEquiposAsync();
    }

    private async void Editar_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var equipo = (Equipo)button.BindingContext;

        // Cargar equipo en RegistroViewModel para editar
        await _registroVM.Cargar(equipo.Id);

        // Navegar a RegistroPage con el contexto cargado para edición
        await Navigation.PushAsync(new RegistroPage(_db)
        {
            BindingContext = _registroVM
        });
    }

    private async void Eliminar_Clicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var equipo = (Equipo)button.BindingContext;

        bool confirm = await DisplayAlert("Confirmar", $"¿Eliminar equipo {equipo.Dispositivo}?", "Sí", "No");
        if (!confirm) return;

        await _db.DeleteEquipoAsync(equipo);
        await LogService.AppendLogAsync(equipo.Dispositivo, "eliminó");

        await DisplayAlert("Éxito", "Equipo eliminado", "OK");

        await _vm.CargarEquiposAsync();
    }
}
