using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PROYECTO_FINAL
{
    class ProductosDAL
    {
        public static int AgregarProductos(producto pProducto)
        {

            int retorno = 0;

            MySqlCommand comando = new MySqlCommand(string.Format("Insert into producto (CodProducto, NombreProducto, TipoProducto, Cantidad) values ('{0}','{1}','{2}', '{3}')",
              pProducto.CodProducto, pProducto.NombreProducto, pProducto.TipoProducto, pProducto.Cantidad), BDcomun.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;

        }

        public static int AgregarDetalleStock(producto pProducto)
        {

            int retorno = 0;
            MySqlCommand comando = new MySqlCommand(string.Format("Insert into detallestock (CodSucursal, CodProducto, CantidadDetalle, NombreProducto ) values ('{0}','{1}','{2}', '{3}' )",
           pProducto.CodSucursal = "1", pProducto.CodProducto, pProducto.Cantidad, pProducto.NombreProducto), BDcomun.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;
        }

        public static List<producto> Buscar(string pNombreProducto)
        {
            List<producto> _lista = new List<producto>();

            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT  CodProducto, NombreProducto, TipoProducto, Cantidad FROM producto where NombreProducto ='{0}'", pNombreProducto), BDcomun.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                producto pProducto = new producto();
                pProducto.CodProducto = _reader.GetString(0);
                pProducto.NombreProducto = _reader.GetString(1);
                pProducto.TipoProducto = _reader.GetString(2);
                pProducto.Cantidad = _reader.GetString(3);

                _lista.Add(pProducto);
            }

            return _lista;

        }

        public static producto Obtenerproducto(int pCodProducto)
        {
            producto pProducto = new producto();
            MySqlConnection conexion = BDcomun.ObtenerConexion();

            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT  CodProducto, NombreProducto, TipoProducto, Cantidad FROM producto where CodProducto ='{0}'", pCodProducto), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
           while (_reader.Read())
            {
                pProducto.CodProducto = _reader.GetString(0);
                pProducto.NombreProducto = _reader.GetString(1);
                pProducto.TipoProducto = _reader.GetString(2);
                pProducto.Cantidad = _reader.GetString(3);
            }

            conexion.Close();
            return pProducto;

        }

        public static int Actualizar(producto pProducto)
        {
            int retorno = 0;
            MySqlConnection conexion = BDcomun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update producto set NombreProducto='{0}', TipoProducto='{1}', Cantidad ='{2}' where CodProducto={3}",
                pProducto.NombreProducto, pProducto.TipoProducto, pProducto.Cantidad, pProducto.CodProducto), conexion);

            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;


        }



        public static int Eliminar(string pCodProducto)

        {

            int retorno = 0;

            MySqlConnection conexion = BDcomun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format(" DELETE producto FROM producto where CodProducto = {0} ", pCodProducto), conexion);

            retorno = comando.ExecuteNonQuery();

            conexion.Close();

            return retorno;

        }
    }
}
