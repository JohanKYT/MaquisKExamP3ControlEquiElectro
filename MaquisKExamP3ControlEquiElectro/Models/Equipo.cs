using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquisKExamP3ControlEquiElectro.Models
{
    public class Equipo
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Dispositivo { get; set; }
        [MaxLength(100)]
        public string Marca { get; set; }
        public bool GarantiaActiva { get; set; }
        public int VidaUtilMeses { get; set; }
    }
}
