using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System

using Aplicación_SD_Web_Server.DB;

namespace Aplicación_SD_Web_Server
{
    /// <summary>
    /// Descripción breve de WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    
    public class WebService1 : System.Web.Services.WebService
    {

        private CategoriaRepository categoriaRepository;
        private ProductoRepository productoRepository;
        private UsuarioRepository usuarioRepository;
        private VentaRepository ventaRepository;
        private DetalleVentaRepository detalleVentaRepository;

        public WebService1()
        {
            string connectionString = "server=.; database=DBEcommerce; trusted_connection=true; MultipleActiveResultSets=true; TrustServerCertificate=true;";
            var databaseManager = new DatabaseManager(connectionString);

            categoriaRepository = new CategoriaRepository(databaseManager);
            productoRepository = new ProductoRepository(databaseManager);
            usuarioRepository = new UsuarioRepository(databaseManager);
            ventaRepository = new VentaRepository(databaseManager);
            detalleVentaRepository = new DetalleVentaRepository(databaseManager);
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public DataSet GetCategorias()
        {
            return categoriaRepository.GetCategorias();
        }

        [WebMethod]
        public DataSet GetProductos()
        {
            return productoRepository.GetProductos();
        }

        [WebMethod]
        public void AddProducto(string nombre, string descripcion, int idCategoria, decimal precio, decimal precioOferta, int cantidad, string imagen)
        {
            productoRepository.AddProducto(nombre, descripcion, idCategoria, precio, precioOferta, cantidad, imagen);
        }

        [WebMethod]
        public void UpdateProducto(int idProducto, string nombre, string descripcion, int idCategoria, decimal precio, decimal precioOferta, int cantidad, string imagen)
        {
            productoRepository.UpdateProducto(idProducto, nombre, descripcion, idCategoria, precio, precioOferta, cantidad, imagen);
        }

        [WebMethod]
        public void DeleteProducto(int idProducto)
        {
            productoRepository.DeleteProducto(idProducto);
        }

        [WebMethod]
        public DataSet GetUsuarios()
        {
            return usuarioRepository.GetUsuarios();
        }

        [WebMethod]
        public void AddUsuario(string nombreCompleto, string correo, string clave, string rol)
        {
            usuarioRepository.AddUsuario(nombreCompleto, correo, clave, rol);
        }

        [WebMethod]
        public void UpdateUsuario(int idUsuario, string nombreCompleto, string correo, string clave, string rol)
        {
            usuarioRepository.UpdateUsuario(idUsuario, nombreCompleto, correo, clave, rol);
        }

        [WebMethod]
        public void DeleteUsuario(int idUsuario)
        {
            usuarioRepository.DeleteUsuario(idUsuario);
        }

        [WebMethod]
        public DataSet GetVentas()
        {
            return ventaRepository.GetVentas();
        }

        [WebMethod]
        public void AddVenta(int idUsuario, decimal total)
        {
            ventaRepository.AddVenta(idUsuario, total);
        }

        [WebMethod]
        public void UpdateVenta(int idVenta, int idUsuario, decimal total)
        {
            ventaRepository.UpdateVenta(idVenta, idUsuario, total);
        }

        [WebMethod]
        public void DeleteVenta(int idVenta)
        {
            ventaRepository.DeleteVenta(idVenta);
        }

        [WebMethod]
        public DataSet GetDetalleVentas()
        {
            return detalleVentaRepository.GetDetalleVentas();
        }

        [WebMethod]
        public void AddDetalleVenta(int idVenta, int idProducto, int cantidad, decimal total)
        {
            detalleVentaRepository.AddDetalleVenta(idVenta, idProducto, cantidad, total);
        }

        [WebMethod]
        public void UpdateDetalleVenta(int idDetalleVenta, int idVenta, int idProducto, int cantidad, decimal total)
        {
            detalleVentaRepository.UpdateDetalleVenta(idDetalleVenta, idVenta, idProducto, cantidad, total);
        }

        [WebMethod]
        public void DeleteDetalleVenta(int idDetalleVenta)
        {
            detalleVentaRepository.DeleteDetalleVenta(idDetalleVenta);
        }

        [WebMethod]
        public void CreateCategoria(string nombre, DateTime fechaCreacion)
        {
            categoriaRepository.AddCategoria(nombre, fechaCreacion);
        }


        [WebMethod]
        public void UpdateCategoria(int idCategoria, string nombre)
        {
            categoriaRepository.UpdateCategoria(idCategoria, nombre);
        }

        [WebMethod]
        public void DeleteCategoria(int idCategoria)
        {
            categoriaRepository.DeleteCategoria(idCategoria);
        }

    }
}
