using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace pueba
{
    public class ParametroSQL
    {
        public string nombreParametro { get; set; }
        public SqlDbType tipo { get; set; }
        public string valor { get; set; }
        //public ParameterDirection direccion {get; set; }
    }
}