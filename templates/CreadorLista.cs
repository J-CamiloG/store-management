using System;
using System.Data;
using BaseDatos;

namespace CreadorLista
{
    public class ClassCreadorLista
    {
        // Definimos la lista como un campo de la clase para que sea accesible desde otros métodos
        private List<ClassBaseDatos> listaVentas;

        // Constructor para inicializar la lista
        public ClassCreadorLista()
        {
            listaVentas = new List<ClassBaseDatos>();
        }
        public void crearLista()
        {
            ClassBaseDatos venta1 = new ClassBaseDatos(
                1,
                DateTime.Parse("07-11-2024"),
                299.99m,
                2,
                "Juan Pérez",
                "María López",
                12

            );
            ClassBaseDatos venta2 = new ClassBaseDatos(
                2,
                DateTime.Parse("07-11-2024"),
                299.99m,
                2,
                "Juan camilo",
                "carmelo",
                12
            );
            
            //ingresamos las variables que definimosa con lso datos 
            listaVentas.Add(venta1);
            listaVentas.Add(venta2);

        }
        public void printList()
        {
            // Iteramos y imprimimos cada elemento en la lista
            foreach (var item in listaVentas)
            {
                Console.WriteLine($"==============Factura No: {item.Id}==============");
                Console.WriteLine($"ID:                {item.Id}");
                Console.WriteLine($"Fecha de Venta:    {item.FechaDeVenta}");
                Console.WriteLine($"Vendedor:          {item.Vendedor}");
                Console.WriteLine($"Comprador:         {item.Comprador}");
                Console.WriteLine($"Valor del Producto:{item.ValorProducto:C}"); // :C formatea como moneda
                Console.WriteLine($"Cantidad:          {item.CantidadDeProductos}");
                Console.WriteLine($"Tiempo de Garantía:{item.TiempoGarantia} meses");
                Console.WriteLine($"Total Facturado:{item.PrecioTotal} COP");
                Console.WriteLine("===========================================\n");
            }
        }
        public void nuevoFactura()
        {
            Console.WriteLine(@"
            ===================================
                    Registrando factura... 
            ===================================
            ");

            Console.WriteLine("Valor del producto : ");
            decimal valorProductoIngresadoIngresada = Decimal.Parse(Console.ReadLine()); 
            Console.WriteLine("Ingresa la cantidad : ");
            int cantidadDeProductosIngresada = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Nombre del vendedor : ");
            string vendedorIngresada = Console.ReadLine();
            Console.WriteLine("Nombre del comprador : ");
            string compradorIngresada = Console.ReadLine();
            Console.WriteLine("Timepo de garantia : ");
            int tiempoGarantiaIngresada = Int32.Parse(Console.ReadLine());

            ClassBaseDatos envioDatos = new ClassBaseDatos(
                1,
                DateTime.Parse("07-11-2024"),
                valorProductoIngresadoIngresada,
                cantidadDeProductosIngresada,
                vendedorIngresada,
                compradorIngresada,
                tiempoGarantiaIngresada
            );

            listaVentas.Add(envioDatos);
            Console.WriteLine("Se ingreso de manera correcta");
        }
        public void promedioVentas()
        {
            Console.WriteLine("Ingresa la fecha ( dd-mm-yyyy ) :");
            DateTime fechaFiltrar = DateTime.Parse(Console.ReadLine());
            var ventasFiltradas = listaVentas.Where(v => v.FechaDeVenta.Date == fechaFiltrar.Date).ToList();

            decimal totalVentas = ventasFiltradas.Sum(v => v.PrecioTotal);
            int numeroVentas = ventasFiltradas.Count;
            decimal promedioVentas = numeroVentas > 0 ? totalVentas / numeroVentas : 0;

            Console.WriteLine($"Total de ventas encontradas: {numeroVentas}");
            Console.WriteLine($"Promedio de ventas diarias: {promedioVentas} COP");
        }
        public void mostrarVendedorMes()
        {
            var mesActual = DateTime.Now.Month;
            var empleadoMes = listaVentas.Where(venta => venta.FechaDeVenta.Month == mesActual)
            .GroupBy(venta => venta.Vendedor) 
            .OrderByDescending(venta => venta.Sum(venta => venta.CantidadDeProductos * venta.ValorProducto)) // sumamos las ventas que hizo
            .FirstOrDefault();
            Console.WriteLine(empleadoMes.Key);
        }
    }
}