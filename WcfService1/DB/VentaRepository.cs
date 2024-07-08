using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Aplicación_SD_Web_Server.DB
{
    public class VentaRepository
    {
        private readonly DatabaseManager _databaseManager;

        public VentaRepository(DatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
        }

        public DataSet GetVentas()
        {
            using (var command = new SqlCommand("SELECT * FROM Venta", _databaseManager.Connection))
            {
                using (var adapter = new SqlDataAdapter(command))
                {
                    var dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    return dataSet;
                }
            }
        }

        public void AddVenta(int idUsuario, decimal total)
        {
            using (var command = new SqlCommand("INSERT INTO Venta (IdUsuario, Total, FechaCreacion) VALUES (@IdUsuario, @Total, @FechaCreacion)", _databaseManager.Connection))
            {
                command.Parameters.AddWithValue("@IdUsuario", idUsuario);
                command.Parameters.AddWithValue("@Total", total);
                command.Parameters.AddWithValue("@FechaCreacion", DateTime.Now);

                _databaseManager.Connection.Open();
                command.ExecuteNonQuery();
                _databaseManager.Connection.Close();
            }
        }

        public void UpdateVenta(int idVenta, int idUsuario, decimal total)
        {
            using (var command = new SqlCommand("UPDATE Venta SET IdUsuario = @IdUsuario, Total = @Total WHERE IdVenta = @IdVenta", _databaseManager.Connection))
            {
                command.Parameters.AddWithValue("@IdVenta", idVenta);
                command.Parameters.AddWithValue("@IdUsuario", idUsuario);
                command.Parameters.AddWithValue("@Total", total);

                _databaseManager.Connection.Open();
                command.ExecuteNonQuery();
                _databaseManager.Connection.Close();
            }
        }

        public void DeleteVenta(int idVenta)
        {
            using (var command = new SqlCommand("DELETE FROM Venta WHERE IdVenta = @IdVenta", _databaseManager.Connection))
            {
                command.Parameters.AddWithValue("@IdVenta", idVenta);

                _databaseManager.Connection.Open();
                command.ExecuteNonQuery();
                _databaseManager.Connection.Close();
            }
        }
    }
}