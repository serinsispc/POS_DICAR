using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunApi
{
    public class RespuestaApi
    {
        public bool estado { get; set; }
        public string mensaje { get; set; }
        public dynamic data { get; set; }
    }
}
