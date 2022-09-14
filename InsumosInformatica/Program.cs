using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsumosInformatica
{
    internal class Program
    {
        static List<Insumos> InsumosINformaticos = new List<Insumos> { new Insumos("tn285",10,180000), new Insumos("tn230", 8, 200000), new Insumos("tn1060", 14, 380000) };
        static void Main(string[] args)
        {
            ConsoleKeyInfo teclaElegida;
            do
            {
                MenuNav();
                teclaElegida =Console.ReadKey();
                if (teclaElegida.Key == ConsoleKey.D1)
                {
                    ListarInsumos();
                }
                else if(teclaElegida.Key == ConsoleKey.D2)
                {
                    AgregarInsumos();
                }
                else if (teclaElegida.Key == ConsoleKey.D3)
                {
                    EntregarInsumos();
                }
                else if (teclaElegida.Key == ConsoleKey.D4)
                {
                    EliminarInsumos();
                }else
                {
                    Console.WriteLine("Opcion incorrecta:");
                }

            } while ( teclaElegida.Key != ConsoleKey.Escape);
            
            
        }

        static void MenuNav()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t###Sistema de Insumos Informatico###\n");
            Console.WriteLine("Seleccione la opcion que desea realizar");
            Console.WriteLine("1 - Listar Insumos\n\n2 - Agregar Insumos\n\n3 - Entregar Insumos\n\n4 - Eliminar insumos\n\n");
            Console.WriteLine("Para salir presiona 'ESC'");
        }

        static void ListarInsumos()
        {
            Console.Clear();
            Console.WriteLine("Listando Insumos");
            foreach (Insumos item in InsumosINformaticos)
            {
                Console.WriteLine(item.ToString());
            }

            Console.ReadKey();
        }
        static void AgregarInsumos()
        {
            Console.Clear();
            Console.WriteLine("Agregado Insumos");
            Console.ReadKey();
            
        }

        static void EntregarInsumos()
        {
            Console.Clear();
            Console.WriteLine("Entregado Insumos");
            Console.ReadKey();
            
        }

        static void EliminarInsumos()
        {
            Console.Clear();
            Console.WriteLine("Eliminando Insumos");
            Console.ReadKey();
        }
    }
}
