using System; 


namespace BaseDatos
{
    public class ClassBaseDatos
    {
        // se crea la estructura de datos que define las propiedades de la clase
        // DECLARACION DE CLASE 
        public int Id  { get; set; }
        public DateTime FechaDeVenta { get; set; } 
        public decimal ValorProducto { get; set; }
        public int CantidadDeProductos { get; set; }
        public string Vendedor { get; set; }
        public string Comprador { get; set; }
        public int TiempoGarantia { get; set; }
        public decimal PrecioTotal { get; set; }


        // creamos el constructor por defecto
        public ClassBaseDatos()
        {
            Id = 0;
            FechaDeVenta = DateTime.Now;
            ValorProducto = 0;
            CantidadDeProductos = 0; 
            Vendedor = "";
            Comprador = "";
            TiempoGarantia = 0; 
            PrecioTotal = 0;
        }

        // creamos el constructor de parametros
        public ClassBaseDatos(
            int id, 
            DateTime fechaDeVenta,
            decimal valorProducto,
            int cantidadDeProductos, 
            string vendedor, 
            string comprador, 
            int tiempoGarantia
        )
        {
            Id = id;
            FechaDeVenta = fechaDeVenta;
            ValorProducto = valorProducto;
            CantidadDeProductos = cantidadDeProductos;
            Vendedor = vendedor;
            Comprador = comprador;
            TiempoGarantia = tiempoGarantia;
            PrecioTotal = valorProducto * cantidadDeProductos;
        }

    }
}
