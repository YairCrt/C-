using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploOpLogicos
{
    internal class Program
    {
        /*Una aeronave sólo puede despegar si su bateria se encuentra en un 75% o mayor 
            y si sus dos propulsores funcionan; O si alguno de sus dos propulsores funcionan Y
            tiene el 100% de bateria
         */
        static void Main(string[] args)
        {
            float bateria;
            bool propulsorIzq, propulsorDer;

            Console.WriteLine("Ingrese el porcentaje de bateria: ");
            bateria = Convert.ToSingle(Console.ReadLine());

            Console.WriteLine("Propulsor Izquierdo funciona(true/false)? ");
            propulsorIzq = Convert.ToBoolean(Console.ReadLine());
            Console.WriteLine("Propulsor Derecho funciona(true/false)? ");
            propulsorDer = Convert.ToBoolean(Console.ReadLine());

            if (((propulsorIzq == true) && (propulsorDer == true)) && bateria >= 75) {
                Console.WriteLine("Despegando...");
            }
            else if(bateria == 100 && (propulsorIzq == true || propulsorDer == true)) {
                Console.WriteLine("Despegando...");
            }
            else
            {
                Console.WriteLine("Aeronave no puede despegar...");
            }
        }
    }
}
