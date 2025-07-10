using MaquisKExamP3ControlEquiElectro.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquisKExamP3ControlEquiElectro.ViewModels
{
    public class LogsViewModel : BaseViewModel
    {
        private ObservableCollection<string> logs;
        public ObservableCollection<string> Logs
        {
            get => logs;
            set { logs = value; OnPropertyChanged(); }
        }

        public LogsViewModel()
        {
            _ = CargarLogsAsync();
        }

        public async Task CargarLogsAsync()
        {
            var registros = await LogService.LeerLogsAsync();
            Logs = new ObservableCollection<string>(registros);
        }
    }
}
