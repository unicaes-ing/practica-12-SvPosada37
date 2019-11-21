using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

using System.Threading.Tasks;

namespace Practica_12
{
    class Ejercicio3
    {
        class Program
        {
            [Serializable]

            public struct DatosAlumno
            {
                //carnet nombre carrera cum
                public string Carnet;
                public string nombre;
                public string carrera;
                private decimal cum;
                public void serCum(decimal cum)
                {
                    if (cum > 0)
                    {
                        this.cum = cum;
                    }
                }
                public decimal getCum()
                {
                    return cum;
                }
            }

            private static Dictionary<string, DatosAlumno> DiccionarioAlumnos = new Dictionary<string, DatosAlumno>();
            private static BinaryFormatter formatter = new BinaryFormatter();
            private const string Documento = "DatosAlumno.bin";

            public static bool GuardarDiccionario(Dictionary<string, DatosAlumno> Alumnos)
            {
                try
                {
                    FileStream fs = new FileStream(Documento, FileMode.Create, FileAccess.Write);
                    formatter.Serialize(fs, Alumnos);
                    fs.Close();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }


            public static bool leerDiccionario()
            {
                try
                {
                    FileStream fs = new FileStream(Documento, FileMode.Open, FileAccess.Read);
                    DiccionarioAlumnos = (Dictionary<string, DatosAlumno>)formatter.Deserialize(fs);
                    fs.Close();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

            public void ejer3()
            {
                if (File.Exists(Documento))
                {
                    leerDiccionario();
                }
                else
                {
                    GuardarDiccionario(DiccionarioAlumnos);
                }
            }


            static void Main(string[] args)
            {

                int Opcion;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Menu opción");
                    Console.WriteLine("\n1)Agregar alumno.");
                    Console.WriteLine("\n2)Mostrar alumnos.");
                    Console.WriteLine("\n3)Buscar alumno.");
                    Console.WriteLine("\n4)Editar alumno");
                    Console.WriteLine("\n5)Eliminar alumno");
                    Console.WriteLine("\n6)Salir\n");


                    Opcion = Convert.ToInt32(Console.ReadLine());

                    switch (Opcion)
                    {
                        case 1:
                            //Agregar

                            Console.Clear();
                            Console.WriteLine("Ingrese los datos del alumno que quiera agregar:");
                            DatosAlumno AlumnoTemporal = new DatosAlumno();
                            do
                            {
                                Console.WriteLine("Carnet: ");
                                AlumnoTemporal.Carnet = Console.ReadLine();
                                if (DiccionarioAlumnos.ContainsKey(AlumnoTemporal.Carnet))
                                {
                                    Console.WriteLine("\nEl carnet: {0} ya existe...", AlumnoTemporal.Carnet);
                                }
                            } while (DiccionarioAlumnos.ContainsKey(AlumnoTemporal.Carnet));
                            Console.WriteLine("\nNombre: ");
                            AlumnoTemporal.nombre = Console.ReadLine();
                            Console.WriteLine("\nCarrera: ");
                            AlumnoTemporal.carrera = Console.ReadLine();
                            Console.WriteLine("\nCUM: ");
                            AlumnoTemporal.serCum(Convert.ToDecimal(Console.ReadLine()));
                            DiccionarioAlumnos.Add(AlumnoTemporal.Carnet, AlumnoTemporal);
                            GuardarDiccionario(DiccionarioAlumnos);
                            Console.WriteLine("\nLos datos se almacenaron correctamente");
                            Console.WriteLine("Presione <ENTER> para continuar.");
                            Console.ReadKey();

                            break;

                        case 2:
                            //Mostrar

                            Console.Clear();
                            try
                            {

                                Console.WriteLine("Datos de los alumnos.");
                                Console.WriteLine();
                                Console.ResetColor();
                                Console.WriteLine("{0,-10}    {1,-10}   {2,5}    {3,8}", "Carnet", "Nombre", "Carrera", "CUM");
                                Console.WriteLine("==========================================================================");
                                leerDiccionario();
                                foreach (KeyValuePair<string, DatosAlumno> Imprimir in DiccionarioAlumnos)
                                {
                                    DatosAlumno AlumnMostrar = Imprimir.Value;
                                    Console.WriteLine("{0,-10}    {1,-10}    {2,5}    {3,8}",
                                    AlumnMostrar.Carnet, AlumnMostrar.nombre, AlumnMostrar.carrera, AlumnMostrar.getCum());
                                }
                                Console.WriteLine("=========================================================================");
                                Console.WriteLine(" Presione <ENTER> para continuar.");
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                                throw;
                            }
                            Console.ReadKey();

                            break;

                        case 3:
                            //Buscar

                            Console.Clear();
                            string Buscar;
                            Console.WriteLine("Ingrese el carnet del alumno que desea buscar:");
                            Buscar = Console.ReadLine();
                            if (DiccionarioAlumnos.ContainsKey(Buscar))
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.WriteLine(" ALUMNO ENCONTRADO");
                                Console.ResetColor();
                                Console.WriteLine("{0,3}    {1,-10}   {2,5}    {3,8}", "Carnet", "Nombre", "Carrera", "CUM");
                                Console.WriteLine("=========================================================================");
                                leerDiccionario();
                                Console.WriteLine("{0,3}    {1,-10}    {2,5}    {3,8}",
                                    DiccionarioAlumnos[Buscar].Carnet, DiccionarioAlumnos[Buscar].nombre, DiccionarioAlumnos[Buscar].carrera, DiccionarioAlumnos[Buscar].getCum());
                            }
                            else
                            {
                                Console.WriteLine("El carnet: " + Buscar + " no esta registrado.");
                            }
                            Console.WriteLine(" Presione <ENTER> para continuar.");
                            Console.ReadKey();

                            break;

                        case 4:
                            //Modificar

                            Console.Clear();
                            string ModificarCarnet;
                            Console.WriteLine("Ingrese el carnet del alumno que desea modificar:");
                            ModificarCarnet = Console.ReadLine();
                            if (DiccionarioAlumnos.ContainsKey(ModificarCarnet))
                            {

                                DiccionarioAlumnos.Remove(ModificarCarnet);
                                DatosAlumno AlumnoModificar = new DatosAlumno();
                                do
                                {
                                    Console.WriteLine("Carnet: ");
                                    AlumnoModificar.Carnet = Console.ReadLine();
                                    if (DiccionarioAlumnos.ContainsKey(AlumnoModificar.Carnet))
                                    {
                                        Console.WriteLine("El carnet: {0} ya existe...", AlumnoModificar.Carnet);
                                    }
                                } while (DiccionarioAlumnos.ContainsKey(AlumnoModificar.Carnet));
                                Console.WriteLine("Nombre: ");
                                AlumnoModificar.nombre = Console.ReadLine();
                                Console.WriteLine("Carrera: ");
                                AlumnoModificar.carrera = Console.ReadLine();
                                Console.WriteLine("CUM: ");
                                AlumnoModificar.serCum(Convert.ToDecimal(Console.ReadLine()));
                                DiccionarioAlumnos.Add(AlumnoModificar.Carnet, AlumnoModificar);
                                GuardarDiccionario(DiccionarioAlumnos);
                                Console.WriteLine(" Datos almacenados Correctamente");
                                Console.WriteLine(" Presione <ENTER> para continuar.");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("El carnet: " + ModificarCarnet + " no esta registrado.");
                            }

                            break;
                        case 5:
                            //Eliminar

                            Console.Clear();
                            string EliminarCarnet;
                            Console.WriteLine("Ingrese el carnet del alumno que desea eliminar: ");
                            EliminarCarnet = Console.ReadLine();
                            if (DiccionarioAlumnos.ContainsKey(EliminarCarnet))
                            {
                                DiccionarioAlumnos.Remove(EliminarCarnet);
                            }
                            GuardarDiccionario(DiccionarioAlumnos);

                            break;
                    }
                } while (Opcion != 6);

            }

        }
    }
}