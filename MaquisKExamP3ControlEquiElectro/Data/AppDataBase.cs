using MaquisKExamP3ControlEquiElectro.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaquisKExamP3ControlEquiElectro.Data
{
    public class AppDatabase
    {
        private readonly SQLiteAsyncConnection _database;

        public AppDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Equipo>().Wait();
        }

        public Task<int> InsertEquipoAsync(Equipo equipo) =>
            _database.InsertAsync(equipo);

        public Task<int> UpdateEquipoAsync(Equipo equipo) =>
            _database.UpdateAsync(equipo);

        public Task<int> DeleteEquipoAsync(Equipo equipo) =>
            _database.DeleteAsync(equipo);

        public Task<List<Equipo>> GetEquiposAsync() =>
            _database.Table<Equipo>().ToListAsync();

        public Task<Equipo> GetEquipoByIdAsync(int id) =>
            _database.Table<Equipo>().Where(e => e.Id == id).FirstOrDefaultAsync();
    }
}
