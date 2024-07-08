using Aplicación_SD_Web_Server.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service1" en el código, en svc y en el archivo de configuración.
    // NOTE: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Service1.svc o Service1.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Service1 : IService1
    {
        private CategoriaRepository categoriaRepository;
        private ProductoRepository productoRepository;
        private UsuarioRepository usuarioRepository;
        private VentaRepository ventaRepository;
        private DetalleVentaRepository detalleVentaRepository;

        public Service1()
        {
            string connectionString = "server=.; database=DBEcommerce; trusted_connection=true; MultipleActiveResultSets=true; TrustServerCertificate=true;";
            var databaseManager = new DatabaseManager(connectionString);

            categoriaRepository = new CategoriaRepository(databaseManager);
            productoRepository = new ProductoRepository(databaseManager);
            usuarioRepository = new UsuarioRepository(databaseManager);
            ventaRepository = new VentaRepository(databaseManager);
            detalleVentaRepository = new DetalleVentaRepository(databaseManager);
        }

        public string HelloWorld()
        {
            return "Hola a todos";
        }

        public DataSet GetCategorias()
        {
            return categoriaRepository.GetCategorias();
        }

        public DataSet GetProductos()
        {
            return productoRepository.GetProductos();
        }

        public string AddProducto(string nombre, string descripcion, int idCategoria, decimal precio, decimal precioOferta, int cantidad, string imagen)
        {
            productoRepository.AddProducto(nombre, descripcion, idCategoria, precio, precioOferta, cantidad, imagen);
            return "Producto agregado exitosamente";
        }

        public string UpdateProducto(int idProducto, string nombre, string descripcion, int idCategoria, decimal precio, decimal precioOferta, int cantidad, string imagen)
        {
            productoRepository.UpdateProducto(idProducto, nombre, descripcion, idCategoria, precio, precioOferta, cantidad, imagen);
            return "Producto actualizado exitosamente";
        }

        public void DeleteProducto(int idProducto)
        {
            productoRepository.DeleteProducto(idProducto);
        }

        public DataSet GetUsuarios()
        {
            return usuarioRepository.GetUsuarios();
        }

        public void AddUsuario(string nombreCompleto, string correo, string clave, string rol)
        {
            usuarioRepository.AddUsuario(nombreCompleto, correo, clave, rol);
        }

        public void UpdateUsuario(int idUsuario, string nombreCompleto, string correo, string clave, string rol)
        {
            usuarioRepository.UpdateUsuario(idUsuario, nombreCompleto, correo, clave, rol);
        }

        public void DeleteUsuario(int idUsuario)
        {
            usuarioRepository.DeleteUsuario(idUsuario);
        }

        public DataSet GetVentas()
        {
            return ventaRepository.GetVentas();
        }

        public void AddVenta(int idUsuario, decimal total)
        {
            ventaRepository.AddVenta(idUsuario, total);
        }

        public void UpdateVenta(int idVenta, int idUsuario, decimal total)
        {
            ventaRepository.UpdateVenta(idVenta, idUsuario, total);
        }

        public void DeleteVenta(int idVenta)
        {
            ventaRepository.DeleteVenta(idVenta);
        }

        public DataSet GetDetalleVentas()
        {
            return detalleVentaRepository.GetDetalleVentas();
        }

        public void AddDetalleVenta(int idVenta, int idProducto, int cantidad, decimal total)
        {
            detalleVentaRepository.AddDetalleVenta(idVenta, idProducto, cantidad, total);
        }

        public void UpdateDetalleVenta(int idDetalleVenta, int idVenta, int idProducto, int cantidad, decimal total)
        {
            detalleVentaRepository.UpdateDetalleVenta(idDetalleVenta, idVenta, idProducto, cantidad, total);
        }

        public void DeleteDetalleVenta(int idDetalleVenta)
        {
            detalleVentaRepository.DeleteDetalleVenta(idDetalleVenta);
        }

        public string CreateCategoria(string nombre, DateTime fechaCreacion)
        {
            categoriaRepository.AddCategoria(nombre, fechaCreacion);
            return "Categoria creada";
        }

        public string UpdateCategoria(int idCategoria, string nombre)
        {
            categoriaRepository.UpdateCategoria(idCategoria, nombre);
            return "Categoria " + nombre + "actualizado exitosamente";
        }

        public void DeleteCategoria(int idCategoria)
        {
            categoriaRepository.DeleteCategoria(idCategoria);
        }
    }
}
