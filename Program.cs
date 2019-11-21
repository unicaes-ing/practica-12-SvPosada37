using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace Guia12
{
 //Jose Humberto Posada Castro   
    class Program
    {
        [Serializable]
        public struct Mascota
        {
            public string NombreMascota;
            public string EspecieMascota;
            public string RazaMascota;
            public string SexoMascota;
            public int EdadMascota;
        }



    
    static void Main(string[] args)
        {
            const string Documento = "Mascotas.bin";
            FileStream fileStream = new FileStream(Documento, FileMode.Create, FileAccess.Write);
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            Mascota MascotaTemporal = new Mascota();

            try
            {

                Console.WriteLine("¿Cuántas mascotas tiene?");
                int Cantidad = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine("Ingrese el nombre de su mascota: ");
                    MascotaTemporal.NombreMascota = Console.ReadLine();
                    Console.WriteLine("\nIngrese la especie de {0}: ", MascotaTemporal.NombreMascota);
                    MascotaTemporal.EspecieMascota = Console.ReadLine();
                    Console.WriteLine("\nIngrese la raza de {0}: ", MascotaTemporal.NombreMascota);
                    MascotaTemporal.RazaMascota = Console.ReadLine();
                    Console.WriteLine("\nIngrese el sexo de {0}: ", MascotaTemporal.NombreMascota);
                    MascotaTemporal.SexoMascota = Console.ReadLine();
                    Console.WriteLine("\nIngrese la edad de {0}: (ingrese la edad en meses)", MascotaTemporal.NombreMascota);
                    MascotaTemporal.EdadMascota = Convert.ToInt32(Console.ReadLine());
                binaryFormatter.Serialize(fileStream, MascotaTemporal);
                fileStream.Close();
                
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            Console.WriteLine("Los datos de su o sus mascotas han sido guardados.");
            Console.ReadKey();
        }
    }
}
