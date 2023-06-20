using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using static Xamarin.Essentials.AppleSignInAuthenticator;
using System.Threading.Tasks;
using Xamarin.Essentials;
using AppXiamrinStore.Model;

namespace AppXiamrinStore.Data
{
    public class Database
    {

            private readonly SQLiteAsyncConnection _database;

            public Database(string dbPath)
            {
                _database = new SQLiteAsyncConnection(dbPath);
                _database.CreateTableAsync<Producto>(); // Se crea la tabla producto
            }

            public Task<List<Producto>> ObtenerRegistrosAsync() // obtenerRegistros
            {
                return _database.Table<Producto>().ToListAsync(); // Método propio de SQLite
        }

            public Task<int> CrearRegistroAsync(Producto producto) // CrearRegistro
            {
                return _database.InsertAsync(producto); // Método propio de SQLite
            }

            public Task<int> ActualizarRegistroAsync(Producto producto)
            {
                return _database.UpdateAsync(producto);
            }

            public Task<int> EliminarRegistroAsync(Producto producto)
            {
                return _database.DeleteAsync(producto);
            }
    }
}
