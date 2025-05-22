using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
 public class Log
    {
        private static string logDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log"); // Ruta dentro del directorio del API

        public static void Write(string eventType, string message)
        {
            try
            {
                // Asegurar que la carpeta existe
                if (!Directory.Exists(logDirectory))
                {
                    Directory.CreateDirectory(logDirectory);
                }

                // Nombre del archivo con fecha del día
                string logFileName = Path.Combine(logDirectory, $"log_{DateTime.Now:yyyy-MM-dd}.txt");

                // Formato del log
                string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] [{eventType}] {message}{Environment.NewLine}";

                // Escribir en el archivo
                File.AppendAllText(logFileName, logEntry);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al escribir en el log: {ex.Message}");
            }
        }
    }
}

