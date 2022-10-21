using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO; //Para procesar los datos de entrada del cliente (html)
using Newtonsoft.Json; //Para procesar las estructuras tipo json de entrada y/o de salida
using AlmacenRopa.Modelos;//Para tener acceso a la clase de cliente
using AlmacenRopa.Clases;//Para manipular la base de datos

namespace AlmacenRopa.Controladores
{
    /// <summary>
    /// Descripción breve de ControladorHabilitacion
    /// </summary>
    public class ControladorProveedor : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string DatosProveedor;
            StreamReader reader = new StreamReader(context.Request.InputStream);
            //Pasa los datos a la variable de DatosCliente
            DatosProveedor = reader.ReadToEnd();
            //Convierte los datos tipo json, en formato texto, a un objeto de tipo cliente
            Proveedor _proveedor = JsonConvert.DeserializeObject<Proveedor>(DatosProveedor);

            //Procesa el comando que se quiere enviar a la base de datos
            context.Response.Write(ProcesarComando(_proveedor));
        }
        private string ProcesarComando(Proveedor _proveedor)
        {
            clsProveedor oProveedor = new clsProveedor();
            oProveedor._proveedor = _proveedor;

            switch (_proveedor.Mensaje.ToUpper())
            {
                case "INSERTAR":
                    oProveedor.Insertar();
                    break;
                case "ACTUALIZAR":
                    oProveedor.Actualizar();
                    break;
                case "ELIMINAR":
                    oProveedor.Eliminar();
                    break;
                case "CONSULTAR":
                    oProveedor.Consultar();
                    break;
            }
            return JsonConvert.SerializeObject(oProveedor._proveedor);
        }
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}