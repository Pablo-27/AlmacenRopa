using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//Permite conectarse a la base de datos y ejecutar sentencias SQL
using libComunes.CapaDatos;
//Permite utilizar el modelo de Habilitacion
using AlmacenRopa.Modelos;

namespace AlmacenRopa.Clases
{
    public class clsProveedor
    {
        public Proveedor _proveedor { get; set; }
        public string Error { get; set; }
        public bool Consultar()
        {
            //Define la instrucción SQL - Ejecutar un sp de la base de datos
            string SQL = "Proveedores_Consultar";
            //Defino la clase de conexión y los parámetros del sp
            clsConexion oConexion = new clsConexion();
            oConexion.AgregarParametro("@prNit", System.Data.SqlDbType.VarChar, 50, _proveedor.Nit);

            oConexion.SQL = SQL;
            oConexion.StoredProcedure = true;
            //Se ejecuta la consulta
            if (oConexion.Consultar())
            {
                //Valida si hay datos
                if (oConexion.Reader.HasRows)
                {
                    oConexion.Reader.Read();
                    _proveedor.Nombre = oConexion.Reader.GetString(0);
                    _proveedor.Telefono = oConexion.Reader.GetString(1);
                    _proveedor.CorreoElectronico = oConexion.Reader.GetString(2);
                    _proveedor.Productos = oConexion.Reader.GetString(3);
                    _proveedor.SitioWeb = oConexion.Reader.GetString(4);



                    _proveedor.Mensaje = "SI";
                    _proveedor.Error = "El Proveedor se consultó de forma exitosa";
                    return true;
                }
                else
                {
                    //No hay datos, es un error para el usuario final
                    _proveedor.Mensaje = "NO";
                    _proveedor.Error = "El Proveedor no existe en la base de datos";
                    return true;
                }
            }
            else
            {
                _proveedor.Mensaje = "NO";
                _proveedor.Error = oConexion.Error;
                return false;
            }
        }


        public bool Insertar()
        {

            //Define la instrucción SQL - Ejecutar un sp de la base de datos
            string SQL = "Proveedores_Insertar";
            //Defino la clase de conexión y los parámetros del sp
            clsConexion oConexion = new clsConexion();
            oConexion.AgregarParametro("@prNit", System.Data.SqlDbType.VarChar, 50, _proveedor.Nit);
            oConexion.AgregarParametro("@prNombre", System.Data.SqlDbType.VarChar, 50, _proveedor.Nombre);
            oConexion.AgregarParametro("@prTelefono", System.Data.SqlDbType.VarChar, 50, _proveedor.Telefono);
            oConexion.AgregarParametro("@prCorreoElectronico", System.Data.SqlDbType.VarChar, 50, _proveedor.CorreoElectronico);
            oConexion.AgregarParametro("@prProductos", System.Data.SqlDbType.VarChar, 50, _proveedor.Productos);
            oConexion.AgregarParametro("@prSitioWeb", System.Data.SqlDbType.VarChar, 50, _proveedor.SitioWeb);



            oConexion.SQL = SQL;
            oConexion.StoredProcedure = true;
            //Se ejecuta la instrucción
            if (oConexion.EjecutarSentencia())
            {
                _proveedor.Mensaje = "SI";
                _proveedor.Error = "El Proveedor se ingresó exitosamente en la base de datos";
                return true;
            }
            else
            {
                _proveedor.Mensaje = "NO";
                _proveedor.Error = oConexion.Error;
                
                return false;
            }
        }
        public bool Actualizar()
        {

            //Define la instrucción SQL - Ejecutar un sp de la base de datos
            string SQL = "Proveedores_Actualizar";
            //Defino la clase de conexión y los parámetros del sp
            clsConexion oConexion = new clsConexion();
            oConexion.AgregarParametro("@prNit", System.Data.SqlDbType.VarChar, 50, _proveedor.Nit);
            oConexion.AgregarParametro("@prNombre", System.Data.SqlDbType.VarChar, 50, _proveedor.Nombre);
            oConexion.AgregarParametro("@prTelefono", System.Data.SqlDbType.VarChar, 50, _proveedor.Telefono);
            oConexion.AgregarParametro("@prCorreoElectronico", System.Data.SqlDbType.VarChar, 50, _proveedor.CorreoElectronico);
            oConexion.AgregarParametro("@prProductos", System.Data.SqlDbType.VarChar, 50, _proveedor.Productos);
            oConexion.AgregarParametro("@prSitioWeb", System.Data.SqlDbType.VarChar, 50, _proveedor.SitioWeb);


            oConexion.SQL = SQL;
            oConexion.StoredProcedure = true;
            //Se ejecuta la instrucción
            if (oConexion.EjecutarSentencia())
            {
                _proveedor.Mensaje = "SI";
                _proveedor.Error = "El Proveedor se actualizó exitosamente en la base de datos";
                return true;
            }
            else
            {
                _proveedor.Mensaje = "NO";
                _proveedor.Error = oConexion.Error;
                return false;
            }
        }
        public bool Eliminar()
        {
            //Define la instrucción SQL - Ejecutar un sp de la base de datos
            string SQL = "Proveedores_Eliminar";
            //Defino la clase de conexión y los parámetros del sp
            clsConexion oConexion = new clsConexion();
            oConexion.AgregarParametro("@prNit", System.Data.SqlDbType.VarChar, 50, _proveedor.Nit);

            oConexion.SQL = SQL;
            oConexion.StoredProcedure = true;
            //Se ejecuta la instrucción
            if (oConexion.EjecutarSentencia())
            {
                _proveedor.Mensaje = "SI";
                _proveedor.Error = "El Proveedores se eliminó de forma correcta en la base de datos";
                return true;
            }
            else
            {
                _proveedor.Mensaje = "NO";
                _proveedor.Error = oConexion.Error;
                return false;
            }
        }
    }
}
