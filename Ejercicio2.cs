using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace Guia12
{
    class Ejercicio2
    {
        
        static void Main(string[] args)
        {
            
            Program.Mascota MascotaTemporal;
            const string Documento = "Mascotas.bin";
            FileStream fileStream = new FileStream(Documento, FileMode.Open, FileAccess.Read);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            if (File.Exists(Documento)) 
            {
                try
                {
                    MascotaTemporal = (Program.Mascota)binaryFormatter.Deserialize(fileStream);                 
                    Console.WriteLine("El nombre de su mascota es: {0}", MascotaTemporal.NombreMascota);
                    Console.WriteLine("La especie de {0} es: {1}", MascotaTemporal.NombreMascota, MascotaTemporal.EspecieMascota);
                    Console.WriteLine("La raza de {0} es: {1}", MascotaTemporal.NombreMascota, MascotaTemporal.RazaMascota);
                    Console.WriteLine("El sexo de {0} es: {1}", MascotaTemporal.NombreMascota, MascotaTemporal.SexoMascota);
                    Console.WriteLine("{0} tiene {1} meses de edad", MascotaTemporal.NombreMascota, MascotaTemporal.EdadMascota);
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }

            }
            Console.WriteLine("Presione <ENTER> para salir.");
            
        }
    }
}
