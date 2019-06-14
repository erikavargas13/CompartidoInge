using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace PROYECTO_FINAL
{
    class BDconsultas
    {
        public static int AgregarSucursal(sucursal psucursal)
        {

            int retorno = 0;
            MySqlConnection conexion = BDcomun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Insert into sucursal (CodSucursal, NombreSucursal, DireccionSucursal, Latitud, Longitud, Telefonosucursal) values ('{0}','{1}','{2}','{3}','{4}','{5}')",
              psucursal.CodSucursal, psucursal.NombreSucursal, psucursal.DireccionSucural, psucursal.Latitud, psucursal.Longitud, psucursal.TelefonoSucursal), BDcomun.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;

        }
        public static int AgregarAsignacion(asig_rol pasig)
        {

            int retorno = 0;
            MySqlConnection conexion = BDcomun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Insert into asig_rol (CodPersona, CodRol) values ('{0}','{1}')",
              pasig.CodPersona, pasig.CodRol), BDcomun.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;

        }
        public static int AgregarPersona(persona ppersona)
        {

            int retorno = 0;
            MySqlConnection conexion = BDcomun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Insert into persona (CodigoPersona, NombrePersona, ApellidoPersona, TelefonoPersona, PassPersona) values ('{0}','{1}','{2}','{3}','{4}')",
              ppersona.CodigoPersona, ppersona.NombrePersona, ppersona.ApellidoPersona, ppersona.TelefonoPersona, ppersona.PassPersona), BDcomun.ObtenerConexion());
            retorno = comando.ExecuteNonQuery();
            conexion.Close();
            return retorno;

        }
        public static roles ObtenerCodigo(string codpersona)
        {
            roles proles = new roles();
            MySqlConnection conexion = BDcomun.ObtenerConexion();

            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT CodRol FROM asig_rol where CodPersona = {0} ", codpersona), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                proles.CodRoles = _reader.GetString(0);
              
            }

            conexion.Close();
            return proles;

        }
        public static int ActualizarSucursal(sucursal pactusuc)
        {

            int retorno = 0;
            MySqlConnection conexion = BDcomun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update sucursal set  NombreSucursal='{0}', DireccionSucursal='{1}', Latitud='{2}', Longitud='{3}', TelefonoSucursal='{4}' where CodSucursal={5}",
                pactusuc.NombreSucursal, pactusuc.DireccionSucural, pactusuc.Latitud, pactusuc.Longitud, pactusuc.TelefonoSucursal, pactusuc.CodSucursal), conexion);

            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;

        }
        public static int ActualizarAignaciones(asig_rol pasig)
        {

            int retorno = 0;
            MySqlConnection conexion = BDcomun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update asig_rol set  CodPersona='{0}', CodRol='{1}' where CodPersona={2}",
                pasig.CodPersona, pasig.CodRol, pasig.CodPersona), conexion);

            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;

        }
        public static int ActualizarPersona(persona ppersona)
        {

            int retorno = 0;
            MySqlConnection conexion = BDcomun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format("Update persona set  NombrePersona='{0}', ApellidoPersona='{1}', TelefonoPersona='{2}', PassPersona='{3}' where CodigoPersona={4}",
             ppersona.NombrePersona, ppersona.ApellidoPersona, ppersona.TelefonoPersona, ppersona.PassPersona, ppersona.CodigoPersona), conexion);

            retorno = comando.ExecuteNonQuery();
            conexion.Close();

            return retorno;

        }
        public static int EliminarSucursal(string pcodigosucur)

        {

            int retorno = 0;

            MySqlConnection conexion = BDcomun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format(" DELETE  FROM sucursal where CodSucursal = {0} ", pcodigosucur), conexion);

            retorno = comando.ExecuteNonQuery();

            conexion.Close();

            return retorno;

        }
        public static int EliminarAsignacion(string pasig)

        {

            int retorno = 0;

            MySqlConnection conexion = BDcomun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format(" DELETE  FROM asig_rol where CodRol = {0} ", pasig), conexion);

            retorno = comando.ExecuteNonQuery();

            conexion.Close();

            return retorno;

        }
        public static int EliminarPersona(string ppersona)

        {

            int retorno = 0;

            MySqlConnection conexion = BDcomun.ObtenerConexion();

            MySqlCommand comando = new MySqlCommand(string.Format(" DELETE  FROM persona where CodigoPersona = {0} ", ppersona), conexion);

            retorno = comando.ExecuteNonQuery();

            conexion.Close();

            return retorno;

        }
        public static List<sucursal> BuscarSucursal(string cod)
        {
            List<sucursal> _lista = new List<sucursal>();
            MySqlConnection conexion = BDcomun.ObtenerConexion();


            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT * FROM sucursal where CodSucursal = " + cod), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                sucursal psucursal = new sucursal();
                psucursal.CodSucursal= _reader.GetString(0);
                psucursal.NombreSucursal = _reader.GetString(1);
                psucursal.DireccionSucural = _reader.GetString(2);
                psucursal.Latitud = _reader.GetDouble(3);
                psucursal.Longitud = _reader.GetDouble(4);
                psucursal.TelefonoSucursal = _reader.GetInt32(5);


                _lista.Add(psucursal);
            }

            conexion.Close();
            return _lista;
        }
        public static List<sucursal> BuscarSucursales()
        {
            List<sucursal> _lista = new List<sucursal>();
            MySqlConnection conexion = BDcomun.ObtenerConexion();


            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT * FROM sucursal "), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                sucursal psucursal = new sucursal();
                psucursal.CodSucursal = _reader.GetString(0);
                psucursal.NombreSucursal = _reader.GetString(1);
                psucursal.DireccionSucural = _reader.GetString(2);
                psucursal.Latitud = _reader.GetDouble(3);
                psucursal.Longitud = _reader.GetDouble(4);
                psucursal.TelefonoSucursal = _reader.GetInt32(5);


                _lista.Add(psucursal);
            }

            conexion.Close();
            return _lista;
        }
        public static List<asig_rol> BuscarAsignaciones()
        {
            List<asig_rol> _lista = new List<asig_rol>();
            MySqlConnection conexion = BDcomun.ObtenerConexion();


            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT * FROM asig_rol "), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                asig_rol pasig = new asig_rol();
                pasig.CodPersona = _reader.GetString(0);
                pasig.CodRol = _reader.GetString(1);
               


                _lista.Add(pasig);
            }

            conexion.Close();
            return _lista;
        }
        public static List<persona> BuscarPersonas()
        {
            List<persona> _lista = new List<persona>();
            MySqlConnection conexion = BDcomun.ObtenerConexion();


            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT * FROM persona "), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                persona ppersona = new persona();
                ppersona.CodigoPersona = _reader.GetString(0);
                ppersona.NombrePersona = _reader.GetString(1);
                ppersona.ApellidoPersona = _reader.GetString(2);
                ppersona.TelefonoPersona = _reader.GetString(3);
                ppersona.PassPersona = _reader.GetString(4);




                _lista.Add(ppersona);
            }

            conexion.Close();
            return _lista;
        }
        public static bool LogInAdmi(string nombreusuario, string claveadmi) // Consultamos la clave del administrador para hacer el login
        {
            bool verificar = false; // creación de la variable para identificar si la clave es correcta
            MySqlConnection conexion = BDcomun.ObtenerConexion();


            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT PassPersona FROM persona where  CodigoPersona = '{0}'", nombreusuario), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                if (_reader.GetString(0) == claveadmi)
                {
                    verificar = true;
                }
            }

            conexion.Close();
            return verificar; // envia el estado de la variable "verificar" => true or false
        }
        public static sucursal ObtenerSucursal(string pCodigoSucursal)
        {
            sucursal psucursal = new sucursal();
            MySqlConnection conexion = BDcomun.ObtenerConexion();

            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT * FROM sucursal where CodSucursal = {0} ", pCodigoSucursal), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {
                
                psucursal.CodSucursal = _reader.GetString(0);
                psucursal.NombreSucursal = _reader.GetString(1);
                psucursal.DireccionSucural = _reader.GetString(2);
                psucursal.Latitud = _reader.GetDouble(3);
                psucursal.Longitud = _reader.GetDouble(4);
                psucursal.TelefonoSucursal = _reader.GetInt32(5);
            }

            conexion.Close();
            return psucursal;

        }
        public static asig_rol ObtenerAsignacion(string pcodasig)
        {
            asig_rol pasig = new asig_rol();
            MySqlConnection conexion = BDcomun.ObtenerConexion();

            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT * FROM asig_rol where CodRol = {0} ", pcodasig), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {

                pasig.CodPersona = _reader.GetString(0);
                pasig.CodRol = _reader.GetString(1);
                
            }

            conexion.Close();
            return pasig;

        }
        public static persona ObtenerPersona(string ppersona)
        {
            persona pperson = new persona();
            MySqlConnection conexion = BDcomun.ObtenerConexion();

            MySqlCommand _comando = new MySqlCommand(String.Format("SELECT * FROM persona where CodigoPersona = {0} ", ppersona), conexion);
            MySqlDataReader _reader = _comando.ExecuteReader();
            while (_reader.Read())
            {

                pperson.CodigoPersona = _reader.GetString(0);
                pperson.NombrePersona = _reader.GetString(1);
                pperson.ApellidoPersona = _reader.GetString(2);
                pperson.TelefonoPersona = _reader.GetString(3);
                pperson.PassPersona = _reader.GetString(4);

            }

            conexion.Close();
            return pperson;

        }
        public static List<Mermas> ListarMermas()
        {
            List<Mermas> listMermas = new List<Mermas>();
            MySqlCommand _comando = new MySqlCommand(
             "SELECT CodSucursal,CodProducto,CantidadMerma,FechaInicio,FechaFin FROM merma", BDcomun.ObtenerConexion());
            MySqlDataReader reader = _comando.ExecuteReader();
            while (reader.Read())
            {
                Mermas mermas = new Mermas();
                mermas.CodSucursal1 = reader.GetString(0);
                mermas.CodProducto1 = reader.GetString(1);
                mermas.CantidadMerma1 = reader.GetInt16(2);
                mermas.FechaInicio1 = reader.GetDateTime(3);
                mermas.FechaFin1 = reader.GetDateTime(4);

                listMermas.Add(mermas);
            }
            BDcomun.ObtenerConexion().Close();
            return listMermas;
        }
        public static List<Mermas> ListarMermasporFecha(MySqlParameter param, MySqlParameter param2)
        {

            List<Mermas> ListMermasFecha = new List<Mermas>();
            MySqlCommand cmd = new MySqlCommand(
            "SELECT CodSucursal,CodProducto,CantidadMerma,FechaInicio,FechaFin FROM merma where FechaInicio BETWEEN @p1 AND @p2 ", BDcomun.ObtenerConexion());
            cmd.Parameters.Add(param);
            cmd.Parameters.Add(param2);
            MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Mermas mermas = new Mermas();
                mermas.CodSucursal1 = reader.GetString(0);
                mermas.CodProducto1 = reader.GetString(1);
                mermas.CantidadMerma1 = reader.GetInt16(2);
                mermas.FechaInicio1 = reader.GetDateTime(3);
                mermas.FechaFin1 = reader.GetDateTime(4);

                ListMermasFecha.Add(mermas);
            }
            BDcomun.ObtenerConexion().Close();
            return ListMermasFecha;

        }


    }
}
