using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploMatrices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
             Se requiere conocer el numero de salones de una escuela con sus alumnos. Obtener calificaciones de los alumnos, obtener la calificacion minima, maxima y el promedio por salon y en general.
             */

            byte i, j, numAlumnos, salones;
            double sumCalif = 0, sumaCalifSalon, totalAlumnos = 0, califMin = 10, califMax = 0, promedio;

            //Numero de salones
            Console.Write("Numero de salones: ");
            salones = Convert.ToByte(Console.ReadLine());

            //Creamos la matriz
            double[][] calificaciones = new double[salones][];

            //Espacio
            Console.WriteLine();

            //Numero de alumnos por salon
            for (i = 0; i < salones; i++)
            {
                Console.Write("Numero de alumnos para el salon {0}: ", i);
                numAlumnos = Convert.ToByte(Console.ReadLine());

                //Acumulamos el numero de alumnos totales, para el promedio de toda la escuela
                totalAlumnos += numAlumnos;

                //Instanciamos las matrices internas(alumnos en cada salon)
                calificaciones[i] = new double[numAlumnos];
            }

            //Espacio
            Console.WriteLine();

            //Se declara matrices unidimensional para almacenar datos por salon
            double[] califMinSalon = new double[salones];
            double[] califMaxSalon = new double[salones];
            double[] promedioSalon = new double[salones];

            //Pedir calificaciones de los alumnos de cada salon
            for (i = 0; i < salones; i++)
            {
                /* Los valores de califMax, califMin y sumaCalifSalon se deben reiniciar a un valor de cero en cada vuelta del ciclo para que sean comparados en cada salon */
                sumaCalifSalon = 0;
                califMax = 0;
                califMin = 10;

                Console.WriteLine("Salon {0}", i);
                for (j = 0; j < calificaciones[i].Length; j++)
                {
                    Console.Write("Ingresa la calificacion del alumno {0}: ", j);
                    calificaciones[i][j] = Convert.ToDouble(Console.ReadLine());

                    //Se acumula las calificaciones de toda la escuela
                    sumCalif += calificaciones[i][j];

                    //Se acumula las calificaciones por salon
                    sumaCalifSalon += calificaciones[i][j];

                    //Calificacion Minima en cada salon
                    if (calificaciones[i][j] < califMin)
                    {
                        califMin = calificaciones[i][j];
                    }
                    califMinSalon[i] = califMin;

                    //Calificacion Maxima en cada salon
                    if (calificaciones[i][j] > califMax)
                    {
                        califMax = calificaciones[i][j];
                    }
                    califMaxSalon[i] = califMax;
                }

                //Calcular promedio de cada salon
                promedioSalon[i] = sumaCalifSalon / calificaciones[i].Length;
            }

            //Promedio de toda la escuela
            promedio = sumCalif / totalAlumnos;

            //Para calcular la califi min y max de toda la escuela se vuelve a hacer usando otras instrucciones de iteracion, ya que el reinicio de estas cusaría conflicto


            //Califmin y max de toda la escuela 
            for (i = 0; i < salones; i++)
            {
                for (j = 0; j < calificaciones[i].Length; j++)
                {
                    if (calificaciones[i][j] < califMin)
                    {
                        califMin = calificaciones[i][j];
                    }
                    if (calificaciones[i][j] > califMax)
                    {
                        califMax = calificaciones[i][j];
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Datos de la Escuela");

            Console.WriteLine();

            //Mostrar las calif de todos los alumnos de la escuela
            for (i = 0; i < salones; i++)
            {
                Console.WriteLine("Salon {0}", i);
                for (j = 0; j < calificaciones[i].Length; j++)
                {
                    Console.WriteLine("El alumno {0} tiene {1} de calificacion", j, calificaciones[i][j]);
                }
            }

            Console.WriteLine();

            //Mostrar por cada salon
            for (i = 0; i < salones; i++)
            {
                Console.WriteLine("Informacion del salon {0}", i);
                Console.WriteLine("Calificacion Maxima: {0}, calificacion minima: {1}", califMaxSalon[i], califMinSalon[i]);
                Console.WriteLine("Promedio: {0}", promedioSalon[i]);
            }

            Console.WriteLine();

            //Resultados de toda la escuela
            Console.WriteLine("Promedio de la escuela : " + promedio);
            Console.WriteLine("Calificacion minima de la escuela: " + califMin);
            Console.WriteLine("Calificacion maxima de la escuela: " + califMax);


        }
    }
}
