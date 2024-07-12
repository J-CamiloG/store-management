using System;
using BaseDatos;
using CreadorLista;


namespace MiApp
{
    class Program
    {
        static void Main(string[] args)
        {
            ClassCreadorLista lista = new ClassCreadorLista();
            lista.crearLista();

            // Menu de nuestra aplicacion
            bool continuar = true;
            while (continuar)
            {
                // Console.Clear();
                Console.WriteLine("===========================================");
                Console.WriteLine("          Menú de Gestión de Ventas         ");
                Console.WriteLine("===========================================");
                Console.WriteLine("1 Ingresar factura");
                Console.WriteLine("2 Ver promedio ventas");
                Console.WriteLine("3 Imprimir todas las facturas");
                Console.WriteLine("4 Cerra");
                Console.WriteLine("===========================================");
                Console.Write("Selecciona una opción: ");

                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        lista.nuevoFactura();
                        break;
                    case "2":
                        lista.promedioVentas();
                        break;
                    case "3":
                        lista.printList();
                        break;
                    case "4":
                        Console.WriteLine("Hasta luego, vuelva pronto");
                        continuar = false;
                        break;
                    default:
                        
                        break;
                }
            }
        }

    }
}


