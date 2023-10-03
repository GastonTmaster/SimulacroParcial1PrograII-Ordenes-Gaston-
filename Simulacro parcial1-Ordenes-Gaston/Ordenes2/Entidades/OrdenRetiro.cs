using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordenes2
{
     class OrdenRetiro
    {
        public int Nro { get; set; }
        public DateTime Fecha { get; set; }
        public string Responsable { get; set; }
 
        public List<DetalleOrden> Detalles { get; set; }

    
        public OrdenRetiro()
        {
            Detalles = new List<DetalleOrden>();
        }

        public void AgregarDetalle(DetalleOrden detalle)
        {
            Detalles.Add(detalle);
        }

        public void QuitarDetalle(int indice) // indice de la lista
        {
            Detalles.RemoveAt(indice);  
        }

    }

}
