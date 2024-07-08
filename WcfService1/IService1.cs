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

    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        string HelloWorld();

        [OperationContract]
        DataSet GetCategorias();

        [OperationContract]
        DataSet GetProductos();

        [OperationContract]
        string AddProducto(string nombre, string descripcion, int idCategoria, decimal precio, decimal precioOferta, int cantidad, string imagen);

        [OperationContract]
        string UpdateProducto(int idProducto, string nombre, string descripcion, int idCategoria, decimal precio, decimal precioOferta, int cantidad, string imagen);
        
        [OperationContract]
        void DeleteProducto(int idProducto);

        [OperationContract]
        DataSet GetUsuarios();

        [OperationContract]
        void AddUsuario(string nombreCompleto, string correo, string clave, string rol);

        [OperationContract]
        void UpdateUsuario(int idUsuario, string nombreCompleto, string correo, string clave, string rol);

        [OperationContract]
        void DeleteUsuario(int idUsuario);

        [OperationContract]
        DataSet GetVentas();

        [OperationContract]
        void AddVenta(int idUsuario, decimal total);

        [OperationContract]
        void UpdateVenta(int idVenta, int idUsuario, decimal total);

        [OperationContract]
        void DeleteVenta(int idVenta);

        [OperationContract]
        DataSet GetDetalleVentas();

        [OperationContract]
        void AddDetalleVenta(int idVenta, int idProducto, int cantidad, decimal total);

        [OperationContract]
        void UpdateDetalleVenta(int idDetalleVenta, int idVenta, int idProducto, int cantidad, decimal total);

        [OperationContract]
        void DeleteDetalleVenta(int idDetalleVenta);

        [OperationContract]
        string CreateCategoria(string nombre, DateTime fechaCreacion);

        [OperationContract]
        string UpdateCategoria(int idCategoria, string nombre);

        [OperationContract]
        void DeleteCategoria(int idCategoria);
    }
}
