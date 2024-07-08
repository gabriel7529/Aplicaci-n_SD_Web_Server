using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace Aplicación_SD_Web_Server.DB
{
    public class UsuarioRepository
    {
        private readonly DatabaseManager _databaseManager;

        public UsuarioRepository(DatabaseManager databaseManager)
        {
            _databaseManager = databaseManager;
        }

        public DataSet GetUsuarios()
        {
            using (var command = new SqlCommand("SELECT * FROM Usuario", _databaseManager.Connection))
            {
                using (var adapter = new SqlDataAdapter(command))
                {
                    var dataSet = new DataSet();
                    adapter.Fill(dataSet);
                    return dataSet;
                }
            }
        }

        public void AddUsuario(string nombreCompleto, string correo, string clave, string rol)
        {
            using (var command = new SqlCommand("INSERT INTO Usuario (NombreCompleto, Correo, Clave, Rol, FechaCreacion) VALUES (@NombreCompleto, @Correo, @Clave, @Rol, @FechaCreacion)", _databaseManager.Connection))
            {
                command.Parameters.AddWithValue("@NombreCompleto", nombreCompleto);
                command.Parameters.AddWithValue("@Correo", correo);
                command.Parameters.AddWithValue("@Clave", clave);
                command.Parameters.AddWithValue("@Rol", rol);
                command.Parameters.AddWithValue("@FechaCreacion", DateTime.Now);

                _databaseManager.Connection.Open();
                command.ExecuteNonQuery();
                _databaseManager.Connection.Close();
            }
        }

        public void UpdateUsuario(int idUsuario, string nombreCompleto, string correo, string clave, string rol)
        {
            using (var command = new SqlCommand("UPDATE Usuario SET NombreCompleto = @NombreCompleto, Correo = @Correo, Clave = @Clave, Rol = @Rol WHERE IdUsuario = @IdUsuario", _databaseManager.Connection))
            {
                command.Parameters.AddWithValue("@IdUsuario", idUsuario);
                command.Parameters.AddWithValue("@NombreCompleto", nombreCompleto);
                command.Parameters.AddWithValue("@Correo", correo);
                command.Parameters.AddWithValue("@Clave", clave);
                command.Parameters.AddWithValue("@Rol", rol);

                _databaseManager.Connection.Open();
                command.ExecuteNonQuery();
                _databaseManager.Connection.Close();
            }
        }

        public void DeleteUsuario(int idUsuario)
        {
            using (var command = new SqlCommand("DELETE FROM Usuario WHERE IdUsuario = @IdUsuario", _databaseManager.Connection))
            {
                command.Parameters.AddWithValue("@IdUsuario", idUsuario);

                _databaseManager.Connection.Open();
                command.ExecuteNonQuery();
                _databaseManager.Connection.Close();
            }
        }
    }
}