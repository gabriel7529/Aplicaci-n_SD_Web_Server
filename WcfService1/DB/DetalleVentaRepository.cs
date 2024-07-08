using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Aplicación_SD_Web_Server.DB
{
    public class DetalleVentaRepository
    {
        private readonly DatabaseManager _databaseManager;

        public DetalleVentaRepository(DatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
        }

        public DataSet GetDetalleVentas()
        {
            using (var command = new SqlCommand("SELECT * FROM DetalleVenta", _databaseManager.Connection))
            {
                using (var adapter = new SqlDataAdapter(command))
                {
                    var dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    return dataSet;
                }
            }
        }

        public void AddDetalleVenta(int idVenta, int idProducto, int cantidad, decimal total)
        {
            using (var command = new SqlCommand("INSERT INTO DetalleVenta (IdVenta, IdProducto, Cantidad, Total) VALUES (@IdVenta, @IdProducto, @Cantidad, @Total)", _databaseManager.Connection))
            {
                command.Parameters.AddWithValue("@IdVenta", idVenta);
                command.Parameters.AddWithValue("@IdProducto", idProducto);
                command.Parameters.AddWithValue("@Cantidad", cantidad);
                command.Parameters.AddWithValue("@Total", total);

                _databaseManager.Connection.Open();
                command.ExecuteNonQuery();
                _databaseManager.Connection.Close();
            }
        }

        public void UpdateDetalleVenta(int idDetalleVenta, int idVenta, int idProducto, int cantidad, decimal total)
        {
            using (var command = new SqlCommand("UPDATE DetalleVenta SET IdVenta = @IdVenta, IdProducto = @IdProducto, Cantidad = @Cantidad, Total = @Total WHERE IdDetalleVenta = @IdDetalleVenta", _databaseManager.Connection))
            {
                command.Parameters.AddWithValue("@IdDetalleVenta", idDetalleVenta);
                command.Parameters.AddWithValue("@IdVenta", idVenta);
                command.Parameters.AddWithValue("@IdProducto", idProducto);
                command.Parameters.AddWithValue("@Cantidad", cantidad);
                command.Parameters.AddWithValue("@Total", total);

                _databaseManager.Connection.Open();
                command.ExecuteNonQuery();
                _databaseManager.Connection.Close();
            }
        }

        public void DeleteDetalleVenta(int idDetalleVenta)
        {
            using (var command = new SqlCommand("DELETE FROM DetalleVenta WHERE IdDetalleVenta = @IdDetalleVenta", _databaseManager.Connection))
            {
                command.Parameters.AddWithValue("@IdDetalleVenta", idDetalleVenta);

                _databaseManager.Connection.Open();
                command.ExecuteNonQuery();
                _databaseManager.Connection.Close();
            }
        }
    }
}