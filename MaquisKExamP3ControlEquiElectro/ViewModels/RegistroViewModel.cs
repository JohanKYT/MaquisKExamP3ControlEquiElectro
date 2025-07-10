using MaquisKExamP3ControlEquiElectro.Data;
using MaquisKExamP3ControlEquiElectro.Models;
using MaquisKExamP3ControlEquiElectro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MaquisKExamP3ControlEquiElectro.ViewModels
{
    public class RegistroViewModel : BaseViewModel
    {
        private int id;
        private string dispositivo;
        public string Dispositivo
        {
            get => dispositivo;
            set { dispositivo = value; OnPropertyChanged(); }
        }

        private string marca;
        public string Marca
        {
            get => marca;
            set { marca = value; OnPropertyChanged(); }
        }

        private bool garantiaActiva;
        public bool GarantiaActiva
        {
            get => garantiaActiva;
            set { garantiaActiva = value; OnPropertyChanged(); }
        }

        private int vidaUtilMeses;
        public int VidaUtilMeses
        {
            get => vidaUtilMeses;
            set { vidaUtilMeses = value; OnPropertyChanged(); }
        }

        public ICommand GuardarCommand { get; }
        public ICommand CargarCommand { get; }

        private AppDatabase _database;

        public RegistroViewModel(AppDatabase db)
        {
            _database = db;
            GuardarCommand = new Command(async () => await Guardar());
            CargarCommand = new Command<int>(async (id) => await Cargar(id));
        }

        public async Task Cargar(int equipoId)
        {
            var equipo = await _database.GetEquipoByIdAsync(equipoId);
            if (equipo != null)
            {
                id = equipo.Id;
                Dispositivo = equipo.Dispositivo;
                Marca = equipo.Marca;
                GarantiaActiva = equipo.GarantiaActiva;
                VidaUtilMeses = equipo.VidaUtilMeses;
            }
        }

        private async Task Guardar()
        {
            if (string.IsNullOrWhiteSpace(Dispositivo) || string.IsNullOrWhiteSpace(Marca))
            {
                await App.Current.MainPage.DisplayAlert("Error", "Debe completar todos los campos", "OK");
                return;
            }

            if (GarantiaActiva && VidaUtilMeses < 12)
            {
                await App.Current.MainPage.DisplayAlert("Error", "Si la garantía está activa, la vida útil debe ser al menos 12 meses.", "OK");
                return;
            }

            var equipo = new Equipo
            {
                Id = id,
                Dispositivo = Dispositivo,
                Marca = Marca,
                GarantiaActiva = GarantiaActiva,
                VidaUtilMeses = VidaUtilMeses
            };

            if (id == 0)
            {
                await _database.InsertEquipoAsync(equipo);
                await LogService.AppendLogAsync(Dispositivo, "incluyó");
                await App.Current.MainPage.DisplayAlert("Éxito", "Equipo registrado", "OK");
            }
            else
            {
                await _database.UpdateEquipoAsync(equipo);
                await LogService.AppendLogAsync(Dispositivo, "actualizó");
                await App.Current.MainPage.DisplayAlert("Éxito", "Equipo actualizado", "OK");
            }

            
            id = 0;
            Dispositivo = string.Empty;
            Marca = string.Empty;
            GarantiaActiva = false;
            VidaUtilMeses = 0;
        }
    }
}
