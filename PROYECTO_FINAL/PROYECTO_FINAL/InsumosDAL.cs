using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace PROYECTO_FINAL
{
    class InsumosDAL
    {
        public static int AgregarInsumos(insumo pInsumo)
        {

            int retorno = 0;

            MySqlCommand comando = new MySqlCommand(string.Format("Insert into insumo (CodInsumo, NombreInsumo, TipoInsumo, CantidadInsumo) values ('{0}','{1}','{2}', '{3}')",
              pInsumo.CodInsumo, pInsumo.NombreInsumo, pInsumo.TipoInsumo, pInsumo.CantidadInsumo), BDcomun.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            return retorno;

        }

        public static List<insumo> Buscar(string pNombreInsumo)
        {
            List<insumo> _lista = new List<insumo>();

            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT CodInsumo, NombreInsumo, TipoInsumo, CantidadInsumo FROM insumo where NombreInsumo ='{0}'", pNombreInsumo), BDcomun.ObtenerConexion());
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                insumo pInsumo = new insumo();
                pInsumo.CodInsumo = _reader.GetString(0);
                pInsumo.NombreInsumo = _reader.GetString(1);
                pInsumo.TipoInsumo = _reader.GetString(2);
                pInsumo.CantidadInsumo = _reader.GetString(3);

                _lista.Add(pInsumo);
            }

            return _lista;

        }

        public static insumo ObtenerInsumo(int pCodInsumo)
        {
            insumo pInsumo = new insumo();
            MySqlConnection conexion = BDcomun.ObtenerConexion();

            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT  CodInsumo, NombreInsumo, TipoInsumo, CantidadInsumo FROM insumo where CodInsumo ='{0}'", pCodInsumo), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                pInsumo.CodInsumo = _reader.GetString(0);
                pInsumo.NombreInsumo = _reader.GetString(1);
                pInsumo.TipoInsumo = _reader.GetString(2);
                pInsumo.CantidadInsumo = _reader.GetString(3);
            }

            conexion.Close();
            return pInsumo;

        }


        public static int Actualizar(insumo pInsumo)
        {
            int retorno = 0;
            MySqlConnection conexion = BDcomun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update insumo set NombreInsumo='{0}', TipoInsumo='{1}', CantidadInsumo ='{2}' where CodInsumo={3}",
                pInsumo.NombreInsumo, pInsumo.TipoInsumo, pInsumo.CantidadInsumo, pInsumo.CodInsumo), conexion);

            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;


        }



        public static int Eliminar(string pCodInsumo)

        {

            int retorno = 0;

            MySqlConnection conexion = BDcomun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format(" DELETE insumo FROM insumo where CodInsumo = {0} ", pCodInsumo), conexion);

            retorno = comando.ExecuteNonQuery();

            conexion.Close();

            return retorno;

        }
    }
}
