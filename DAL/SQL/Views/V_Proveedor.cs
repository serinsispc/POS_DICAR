using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SQL.Views
{
    public class V_Proveedor
    {
        public int id { get; set; }
        public string documentoProveedor { get; set; }
        public string nombreProveedor { get; set; }
        public string direccionProveedor { get; set; }
        public string telefonoProveedor { get; set; }
        public string emailProveedor { get; set; }
        public int idEstado { get; set; }
    }
}
