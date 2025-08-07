using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;

namespace creacionDeArchivos
{
    internal class Program
    {
        
            static void Main(string[] args)
            {
                try
                {
                    while (true)
                    {
                        Console.Clear();
                        Opciones();
                    }
                }
                catch (Exception ex)
                {
                    
                    Console.WriteLine("Ocurrió un error: \n" + ex.Message);
                    Console.WriteLine("Presione cualquier tecla para continuar");
                    Console.ReadKey();
                    Console.Clear();

                    Opciones();
                }
            }

            static void Opciones()
            {
                try
                {
                    while (true)
                    {
                    Console.Clear();
                    Console.WriteLine("Qué deseas hacer? \n");
                    Console.WriteLine("1. Guardar archivo \n");
                    Console.WriteLine("2. leer archivo \n");
                    Console.WriteLine("3. Eliminar archivo \n");
                    Console.WriteLine("4. Cerrar aplicacion \n");
                    int opcion = Convert.ToInt32(Console.ReadLine());



                        switch (opcion)
                        {
                            case 1:
                                Console.WriteLine("Opción 1 seleccionada: \n");
                                Console.WriteLine(" Guardar archivo \n");
                                guardarArchivo();
                                break;

                            case 2:
                                Console.WriteLine("Opción 2 seleccionada: \n");
                                Console.WriteLine(" Leyendo archivo \n");
                                leerArchivo();
                                break;

                        case 3:
                            Console.WriteLine("Opción 3 seleccionada: \n");
                            Console.WriteLine("Eliminar archivo \n");
                            eliminarArchivo();
                            break;

                        case 4:
                                Console.WriteLine("Opción 4 seleccionada: \n");
                                Console.WriteLine("4. Cerrar aplicacion \n");

                                if (ConfirmExitWindow())
                                {
                                    Environment.Exit(0);
                                }
                                break;

                            default:
                                Console.WriteLine("Opción no válida \n");
                                Console.ReadKey();
                                Console.Clear();
                                break;
                        }
                    }
                }
                catch (Exception ex)
                {

                    Console.WriteLine("Ocurrió un error: \n" + ex.Message);
                    Console.WriteLine("Presione cualquier tecla para continuar \n");
                    Console.ReadKey();
                    Console.Clear();

                    Opciones();
                }
            }

            static void guardarArchivo()
            {
                Console.WriteLine("Ingrese un mensaje \n");
                TextWriter archivo1;
                archivo1 = new StreamWriter("informacion.txt");
                string mensaje1 = Console.ReadLine();
                archivo1.WriteLine(mensaje1);
                archivo1.Close();
                Console.Clear();
                Console.WriteLine("Archivo guardado correctamente \n");

                Console.ReadKey();
            }

            static void leerArchivo()
            {

                TextReader LeerArchivo;
                LeerArchivo = new StreamReader("informacion.txt");
                Console.WriteLine(LeerArchivo.ReadToEnd());
                LeerArchivo.Close();


                Console.ReadKey();
                Console.Clear();
            }

        static void eliminarArchivo()
        {
            string path = "informacion.txt";

            if (!File.Exists(path))
            {
                Console.WriteLine("El archivo no existe. \n");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            // Confirmación antes de eliminar
            if (ConfirmDeleteWindow())
            {
                File.Delete(path);
                Console.WriteLine("Archivo eliminado correctamente. \n");
            }
            else
            {
                Console.WriteLine("Operación cancelada. \n");
            }

            Console.ReadKey();
            Console.Clear();
        }

        static bool ConfirmDeleteWindow()
        {
            Console.Clear();

            string line1 = "¿Seguro que deseas eliminar el archivo? \n";
            string line2 = "s = Sí    n = No \n";
            int boxWidth = Math.Max(line1.Length, line2.Length) + 6;
            int boxHeight = 5;

            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;

            int startX = Math.Max(0, (windowWidth - boxWidth) / 2);
            int startY = Math.Max(0, (windowHeight - boxHeight) / 2);

            for (int y = 0; y < boxHeight; y++)
            {
                Console.SetCursorPosition(startX, startY + y);
                for (int x = 0; x < boxWidth; x++)
                {
                    if (y == 0)
                    {
                        if (x == 0) Console.Write('╔');
                        else if (x == boxWidth - 1) Console.Write('╗');
                        else Console.Write('═');
                    }
                    else if (y == boxHeight - 1)
                    {
                        if (x == 0) Console.Write('╚');
                        else if (x == boxWidth - 1) Console.Write('╝');
                        else Console.Write('═');
                    }
                    else
                    {
                        if (x == 0 || x == boxWidth - 1) Console.Write('║');
                        else Console.Write(' ');
                    }
                }
            }

            Console.SetCursorPosition(startX + (boxWidth - line1.Length) / 2, startY + 1);
            Console.Write(line1);

            Console.SetCursorPosition(startX + (boxWidth - line2.Length) / 2, startY + 2);
            Console.Write(line2);

            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.S) return true;
                if (key == ConsoleKey.N)
                {
                    Console.Clear();
                    return false;
                }
                if (key == ConsoleKey.Escape) Environment.Exit(0);
            }
        }


        static bool ConfirmExitWindow()
            {
                Console.Clear();

                string line1 = "¿Seguro que quieres salir? \n";
                string line2 = "s = Sí    n = No \n";
                int boxWidth = Math.Max(line1.Length, line2.Length) + 6;
                int boxHeight = 5;

                int windowWidth = Console.WindowWidth;
                int windowHeight = Console.WindowHeight;

                int startX = Math.Max(0, (windowWidth - boxWidth) / 2);
                int startY = Math.Max(0, (windowHeight - boxHeight) / 2);

                for (int y = 0; y < boxHeight; y++)
                {
                    Console.SetCursorPosition(startX, startY + y);
                    for (int x = 0; x < boxWidth; x++)
                    {
                        if (y == 0)
                        {
                            if (x == 0) Console.Write('╔');
                            else if (x == boxWidth - 1) Console.Write('╗');
                            else Console.Write('═');
                        }
                        else if (y == boxHeight - 1)
                        {
                            if (x == 0) Console.Write('╚');
                            else if (x == boxWidth - 1) Console.Write('╝');
                            else Console.Write('═');
                        }
                        else
                        {
                            if (x == 0 || x == boxWidth - 1) Console.Write('║');
                            else Console.Write(' ');
                        }
                    }
                }

                // Escribir texto centrado
                Console.SetCursorPosition(startX + (boxWidth - line1.Length) / 2, startY + 1);
                Console.Write(line1);

                Console.SetCursorPosition(startX + (boxWidth - line2.Length) / 2, startY + 2);
                Console.Write(line2);

                // Esperar respuesta del usuario
                while (true)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.S) return true;
                    if (key == ConsoleKey.N) 
                    {
                        Console.Clear();
                        return false;
                    }
                    if (key == ConsoleKey.Escape) Environment.Exit(0);
                }
            }
    }
}