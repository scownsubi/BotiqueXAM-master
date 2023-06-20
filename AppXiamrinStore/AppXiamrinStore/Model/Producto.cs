using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace AppXiamrinStore.Model
{
    public class Producto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Precio { get; set;}
        public string Proveedor { get; set; }

        public string Ruta { get; set; }

    }
}
