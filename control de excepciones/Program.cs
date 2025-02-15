using System;
using System.IO;

namespace ControlExcepcionesArchivos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Ejemplo de Control de Excepciones con Archivos ===");

            try
            {
                // Solicitar al usuario el nombre del archivo
                Console.Write("Ingrese el nombre del archivo (incluya la extensión): ");
                string nombreArchivo = Console.ReadLine();
                // Nota: Hay tres archivos para combrobar el funcionamiento de la excepcion,
                // ejemplo.txt, prueba2.txt, vacio.txt. Al momento de ejecutar el codigo,
                // ingrese uno de esos archivos para hacer la comprobacion.

                // Leer el contenido del archivo
                string contenido = LeerArchivo(nombreArchivo);

                // Mostrar el contenido del archivo
                Console.WriteLine("\nContenido del archivo:");
                Console.WriteLine(contenido);
            }
            catch (FileNotFoundException)//este es una excepcion
            {
                // Capturar errores si el archivo no existe
                Console.WriteLine("Error: El archivo no fue encontrado.");
            }
            catch (IOException)//este es una excepcion
            {
                // Capturar errores relacionados con la lectura del archivo
                Console.WriteLine("Error: Ocurrió un problema al leer el archivo.");
            }
            catch (Exception ex)//este es una excepcion
            {
                // Capturar cualquier otra excepcion no manejada
                Console.WriteLine($"Ocurrio un error inesperado: {ex.Message}");
            }
            finally
            {
                // Este bloque siempre se ejecuta
                Console.WriteLine("\nEl programa ha terminado. Presione cualquier tecla para salir.");
            }

            Console.ReadKey();
        }

        // Metodo que lee el contenido de un archivo
        static string LeerArchivo(string nombreArchivo)
        {
            if (string.IsNullOrWhiteSpace(nombreArchivo))
            {
                throw new ArgumentException("El nombre del archivo no puede estar vacio.");
            }

            // Verificar si el archivo existe
            if (!File.Exists(nombreArchivo))
            {
                throw new FileNotFoundException("El archivo especificado no existe.", nombreArchivo);
            }

            // Leer el contenido del archivo
            string contenido = File.ReadAllText(nombreArchivo);

            // Si el archivo esta vacio, lanzar una excepcion personalizada
            if (string.IsNullOrWhiteSpace(contenido))
            {
                throw new InvalidOperationException("El archivo esta vacio.");
            }

            return contenido;
        }
    }
}