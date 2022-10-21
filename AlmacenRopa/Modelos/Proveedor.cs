using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlmacenRopa.Modelos
{
    public class Proveedor
    {
        public string Nit { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string CorreoElectronico { get; set; }
        public string Productos { get; set; }
        public string SitioWeb { get; set; }
        public string Mensaje { get; set; }
        public string Error { get; set; }
    }
}