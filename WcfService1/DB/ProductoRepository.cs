using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Aplicación_SD_Web_Server.DB
{
    public class ProductoRepository
    {
        private readonly DatabaseManager _databaseManager;

        public ProductoRepository(DatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
        }

        public DataSet GetProductos()
        {
            using (var command = new SqlCommand("SELECT * FROM Producto", _databaseManager.Connection))
            {
                using (var adapter = new SqlDataAdapter(command))
                {
                    var dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    return dataSet;
                }
            }
        }

        public void AddProducto(string nombre, string descripcion, int idCategoria, decimal precio, decimal precioOferta, int cantidad, string imagen)
        {
            using (var command = new SqlCommand("INSERT INTO Producto (Nombre, Descripcion, IdCategoria, Precio, PrecioOferta, Cantidad, Imagen, FechaCreacion) VALUES (@Nombre, @Descripcion, @IdCategoria, @Precio, @PrecioOferta, @Cantidad, @Imagen, @FechaCreacion)", _databaseManager.Connection))
            {
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Descripcion", descripcion);
                command.Parameters.AddWithValue("@IdCategoria", idCategoria);
                command.Parameters.AddWithValue("@Precio", precio);
                command.Parameters.AddWithValue("@PrecioOferta", precioOferta);
                command.Parameters.AddWithValue("@Cantidad", cantidad);
                command.Parameters.AddWithValue("@Imagen", imagen);
                command.Parameters.AddWithValue("@FechaCreacion", DateTime.Now);

                _databaseManager.Connection.Open();
                command.ExecuteNonQuery();
                _databaseManager.Connection.Close();
            }
        }

        public void UpdateProducto(int idProducto, string nombre, string descripcion, int idCategoria, decimal precio, decimal precioOferta, int cantidad, string imagen)
        {
            using (var command = new SqlCommand("UPDATE Producto SET Nombre = @Nombre, Descripcion = @Descripcion, IdCategoria = @IdCategoria, Precio = @Precio, PrecioOferta = @PrecioOferta, Cantidad = @Cantidad, Imagen = @Imagen WHERE IdProducto = @IdProducto", _databaseManager.Connection))
            {
                command.Parameters.AddWithValue("@IdProducto", idProducto);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Descripcion", descripcion);
                command.Parameters.AddWithValue("@IdCategoria", idCategoria);
                command.Parameters.AddWithValue("@Precio", precio);
                command.Parameters.AddWithValue("@PrecioOferta", precioOferta);
                command.Parameters.AddWithValue("@Cantidad", cantidad);
                command.Parameters.AddWithValue("@Imagen", imagen);

                _databaseManager.Connection.Open();
                command.ExecuteNonQuery();
                _databaseManager.Connection.Close();
            }
        }

        public void DeleteProducto(int idProducto)
        {
            using (var command = new SqlCommand("DELETE FROM Producto WHERE IdProducto = @IdProducto", _databaseManager.Connection))
            {
                command.Parameters.AddWithValue("@IdProducto", idProducto);

                _databaseManager.Connection.Open();
                command.ExecuteNonQuery();
                _databaseManager.Connection.Close();
            }
        }
    }
}