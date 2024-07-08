using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eccomerce.Models
{
    public static class DataSetExtensions
    {
        public static List<Producto> ToProductoList(this DataSet dataSet)
        {
            var productos = new List<Producto>();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                productos.Add(new Producto
                {
                    IdProducto = Convert.ToInt32(row["IdProducto"]),
                    Nombre = row["Nombre"].ToString(),
                    Descripcion = row["Descripcion"].ToString(),
                    IdCategoria = Convert.ToInt32(row["IdCategoria"]),
                    Precio = Convert.ToDecimal(row["Precio"]),
                    PrecioOferta = Convert.ToDecimal(row["PrecioOferta"]),
                    Cantidad = Convert.ToInt32(row["Cantidad"]),
                    Imagen = row["Imagen"].ToString()
                });
            }

            return productos;
        }

        public static List<Categoria> ToCategoriaList(this DataSet dataSet)
        {
            var categorias = new List<Categoria>();

            foreach (DataRow row in dataSet.Tables[0].Rows)
            {
                categorias.Add(new Categoria
                {
                    IdCategoria = Convert.ToInt32(row["IdCategoria"]),
                    Nombre = row["Nombre"].ToString(),
                    FechaCreacion = Convert.ToDateTime(row["FechaCreacion"])
                });
            }

            return categorias;
        }
    }
}