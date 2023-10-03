using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenes2
{
     class DetalleOrden
    {
        
        public Material Material { get; set; }
        public int Cantidad { get; set; }

        public DetalleOrden(Material material, int cantidad)
        {
            Material = material;
            Cantidad = cantidad;
        }
     
         //algun metodo CalcularSubtotal si tenemos precio en la clase material
         //seria public double CalcularSubtotal(){return Material.Precio * Cantidad}
    }
}
