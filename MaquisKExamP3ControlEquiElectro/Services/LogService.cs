using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquisKExamP3ControlEquiElectro.Services
{
    public static class LogService
    {
        private static string apellido = "Maquis";

        public static async Task AppendLogAsync(string dispositivo, string accion)
        {
            string filename = $"Logs_{apellido}.txt";
            string logPath = Path.Combine(FileSystem.AppDataDirectory, filename);
            string logEntry = $"Se {accion} el registro [{dispositivo}] el {DateTime.Now:dd/MM/yyyy HH:mm}\n";
            await File.AppendAllTextAsync(logPath, logEntry);
        }

        public static async Task<List<string>> LeerLogsAsync()
        {
            string filename = $"Logs_{apellido}.txt";
            string logPath = Path.Combine(FileSystem.AppDataDirectory, filename);
            if (!File.Exists(logPath))
                return new List<string>();

            var lines = await File.ReadAllLinesAsync(logPath);
            return lines.ToList();
        }
    }
}
