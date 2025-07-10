using MaquisKExamP3ControlEquiElectro.Data;
using MaquisKExamP3ControlEquiElectro.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquisKExamP3ControlEquiElectro.ViewModels
{
    public class ListaViewModel : BaseViewModel
    {
        private ObservableCollection<Equipo> equipos;
        public ObservableCollection<Equipo> Equipos
        {
            get => equipos;
            set { equipos = value; OnPropertyChanged(); }
        }

        private AppDatabase _database;

        public ListaViewModel(AppDatabase db)
        {
            _database = db;
            _ = CargarEquiposAsync();
        }

        public async Task CargarEquiposAsync()
        {
            var lista = await _database.GetEquiposAsync();
            Equipos = new ObservableCollection<Equipo>(lista);
        }
    }
}
