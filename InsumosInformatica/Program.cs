﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Remoting.Contexts;

namespace InsumosInformatica
{
    internal class Program
    {
        static List<Insumos> InsumosINformaticos = new List<Insumos> {  };
        static void Main(string[] args)
        {

            CargarDeArchivoALista();

            ConsoleKeyInfo teclaElegida;
            do
            {
                MenuNav();
                teclaElegida = Console.ReadKey();
                if (teclaElegida.Key == ConsoleKey.D1)
                {
                    ListarInsumos();
                }
                else if (teclaElegida.Key == ConsoleKey.D2)
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
                }
                else
                {
                    Console.WriteLine("Opcion incorrecta:");
                }

            } while (teclaElegida.Key != ConsoleKey.Escape);

            GuardarArticulosEnTxt();

        }

        static void GuardarArticulosEnTxt()
        {
            string InsumosPorLinea;
            foreach (Insumos insumo in InsumosINformaticos)
            {

                InsumosPorLinea = $"{insumo.IdInsumo}#{insumo.NombreInsumo}#" +
                                    $"{insumo.CantidadInsumo}#{insumo.CostoInsumo}";
                if (!VerificarExistenciaLinea(InsumosPorLinea))
                {

                    using (StreamWriter archivo = new StreamWriter(@"C:\ESD\database.txt", true))
                    {
                        archivo.WriteLine(InsumosPorLinea);
                    }
                }
                else
                {
                    continue;
                }
            }
        }
        //verifica si existe el insumo en una de las lineas del archivo txt, para no repetir la escritura del insumo
        static bool VerificarExistenciaLinea(string insumo)
        {
            string lineas;

            try
            {
                lineas = File.ReadAllText(@"C:\ESD\database.txt");


            }
            catch (FileNotFoundException)
            {
                return false;
            }

            return lineas.Contains(insumo);

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


            //variables temporales para agregar a la lista
            string nombre;
            int cantidad;
            int precio;

            Console.WriteLine("Nombre del insumo:");
            nombre = VerificarEntrada(Console.ReadLine());

            Console.WriteLine("Cantidad");
            cantidad = VerificarEntradaNumero(Console.ReadLine());

            Console.WriteLine("Precio:");
            precio = VerificarEntradaNumero(Console.ReadLine());

            //agregando a la lista
            InsumosINformaticos.Add(new Insumos(nombre, cantidad, precio));
            Console.WriteLine("Insumos agregados correctamente");
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
            //Variables
            bool volverElegir=true;
            do
            {
                Console.Clear();
                Console.WriteLine("Eliminando Insumos");
                ListarInsumos();
                int idEliminar;
                Console.WriteLine("Seleccione el insumo a eliminar por el ID");
                idEliminar = VerificarEntradaNumero(Console.ReadLine());
                //pregunta si esta seguro que desea eliminar
                Console.Clear();
                Console.WriteLine("\nEstas seguro que desea eliminar: 'S' si 'N' seleccionar otro y 'ESC' para salir \n");
                InsumosINformaticos.ToString();
                if (Console.ReadKey().Key == ConsoleKey.S)
                {
                    //recorrido de eliminacion
                    foreach (Insumos insumo in InsumosINformaticos)
                    {
                        if (insumo.IdInsumo == idEliminar)
                        {
                            InsumosINformaticos.RemoveAt(idEliminar-1);
                            break;
                        }
                    }

                    Console.WriteLine("\nInsumos eliminado correctamente");
                    Console.ReadKey();
                    volverElegir = false;
                }
                else if (Console.ReadKey().Key == ConsoleKey.N)
                {
                    volverElegir = true;
                }else if (Console.ReadKey().Key == ConsoleKey.Escape)
                {
                    volverElegir = false;
                    Console.WriteLine("Volviendo al menu");
                    Console.ReadKey();
                }

            } while (volverElegir);
                        
        }

        //Verifica la entrada del nombre del insumo
        static string VerificarEntrada(string entrada)
        {
            bool verificado = false;

            do
            {
                foreach (Insumos item in InsumosINformaticos)
                {
                    if (item.NombreInsumo.ToLower() == entrada.ToLower())
                    {
                        verificado = false;
                        Console.WriteLine("Nombre insumo ya Existente, ingrese otro");
                        entrada = Console.ReadLine();
                        break;

                    }
                    else if (entrada == "")
                    {
                        verificado = false;
                        Console.WriteLine("No puede dejar vacio");
                        entrada = Console.ReadLine();
                        break;
                    }
                    else
                    {
                        verificado = true;
                    }
                }
            } while (!verificado);

            return entrada;
        }
        static int VerificarEntradaNumero(string numero)
        {
            bool ingresoCorrecto;
            int numeroCorrecto = 0; ;
            do
            {
                try
                {
                    numeroCorrecto = Convert.ToInt32(numero);
                    ingresoCorrecto = true;
                    if (numero == "" || numero == "0")
                    {
                        Console.WriteLine("No puede dejar vacio o en 0");
                        ingresoCorrecto = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Ingrese un valor numerico");
                    numero = Console.ReadLine();
                    ingresoCorrecto = false;
                }


            } while (!ingresoCorrecto);

            return numeroCorrecto;
        }

        static void CargarDeArchivoALista()
        {
            string[] lineas = File.ReadAllLines(@"C:\ESD\database.txt");
            string[] lineasSeparadas;
            Insumos auxiliar;

            foreach (string linea in lineas)//falta agregar a los archivos con substream
            {
              lineasSeparadas=  linea.Trim().Split('#');
                auxiliar= new Insumos(lineasSeparadas[1], Convert.ToInt32(lineasSeparadas[2]), Convert.ToInt32(lineasSeparadas[3]) );
                InsumosINformaticos.Add(auxiliar);
            }
        }

    }
}
