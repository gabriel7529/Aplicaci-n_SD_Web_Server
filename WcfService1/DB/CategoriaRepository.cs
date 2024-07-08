using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Aplicación_SD_Web_Server.DB
{
    public class CategoriaRepository
    {
        private readonly DatabaseManager _databaseManager;

        public CategoriaRepository(DatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
        }

        public DataSet GetCategorias()
        {
            using (var command = new SqlCommand("SELECT * FROM Categoria", _databaseManager.Connection))
            {
                using (var adapter = new SqlDataAdapter(command))
                {
                    var dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    return dataSet;
                }
            }
        }

        public void AddCategoria(string nombre, DateTime fechaCreacion)
        {
            using (var command = new SqlCommand("INSERT INTO Categoria (Nombre, FechaCreacion) VALUES (@Nombre, @FechaCreacion)", _databaseManager.Connection))
            {
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@FechaCreacion", fechaCreacion);
                _databaseManager.OpenConnection();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateCategoria(int id, string nombre)
        {
            using (var command = new SqlCommand("UPDATE Categoria SET Nombre = @Nombre WHERE IdCategoria = @IdCategoria", _databaseManager.Connection))
            {
                command.Parameters.AddWithValue("@IdCategoria", id);
                command.Parameters.AddWithValue("@Nombre", nombre);
              
                _databaseManager.OpenConnection();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteCategoria(int id)
        {
            using (var command = new SqlCommand("DELETE FROM Categoria WHERE IdCategoria = @IdCategoria", _databaseManager.Connection))
            {
                command.Parameters.AddWithValue("@IdCategoria", id);
                _databaseManager.OpenConnection();
                command.ExecuteNonQuery();
            }
        }
    }
}