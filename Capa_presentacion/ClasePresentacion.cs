using Capa_Datos;
using Capa_Logica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_presentacion
{
    public class ClasePresentacion
    {
        ClaseDatos objd = new ClaseDatos();

        public DataTable N_listar_libros()
        {
            return objd.D_listar_productos();

        }
        public DataTable N_buscar_producto(ClaseLogica obje)
        {
            return objd.D_buscar_producto(obje);

        }
        public String N_CUD(ClaseLogica obje)
        {
            return objd.D_CUD(obje);

        }
    }
}
