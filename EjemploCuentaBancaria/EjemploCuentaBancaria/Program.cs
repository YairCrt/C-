using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploCuentaBancaria
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double montoAr, saldoInicial;
            int opcion;
            string nombre, apellido, direccion, rfc;

            Console.WriteLine("\t¡¡¡Bienvenido!!!\nVamos a crear su cuenta Bancaria.");
            Console.Write("Su nombre: ");
            nombre = Console.ReadLine();
            Console.Write("Su apellido: ");
            apellido = Console.ReadLine();
            Console.Write("Su direccion: ");
            direccion = Console.ReadLine();
            Console.Write("Su RFC: ");
            rfc = Console.ReadLine();

            do
            {
                Console.Write("Monto Inicial: $");
                saldoInicial = Convert.ToDouble(Console.ReadLine());
                if (saldoInicial > 0)
                {
                    Console.WriteLine("\t¡FELICIDADES! \nSu cuenta ha sido creada con exito.\nPresione cualquier tecla para continuar...");
                    Console.ReadKey();
                }
                else
                {
                    Console.WriteLine("No es posible crear su cuenta con el monto indicado. Intentelo de nuevo");
                }
            }while(saldoInicial <= 0);

            CuentaBancaria cuenta = new CuentaBancaria(nombre, apellido, saldoInicial, direccion, rfc);

            Console.WriteLine();

            do
            {
                Console.WriteLine("\n1. Deposito");
                Console.WriteLine("2. Retiro");
                Console.WriteLine("3. Consultar Saldo");
                Console.WriteLine("4. Informacion de  la cuenta");
                Console.WriteLine("5. Salir");
                Console.Write("Opcion: ");
                opcion = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        Console.WriteLine("Monto a depositar: $");
                        montoAr = Convert.ToDouble(Console.ReadLine());
                        cuenta.deposito(montoAr);
                        break;
                    case 2:
                        Console.WriteLine("Monto a retirar: $");
                        montoAr = Convert.ToDouble(Console.ReadLine());
                        cuenta.retiro(montoAr);
                        break;
                    case 3:
                        cuenta.consultaSaldo();
                        break;
                    case 4:
                        Console.WriteLine(cuenta.ToString());
                        break;
                
                }
            } while(opcion >=1 && opcion <= 4);
        }
    }

    public class CuentaBancaria
    {
        double saldo;
        private string nombre, apellido, direccion, rfc;

        //Constructor
        public CuentaBancaria(string nombrePa, string apellidoPa, double saldoPa,string direccionPa, string rfcPa) 
        {
            this.nombre = nombrePa;
            this.apellido = apellidoPa;
            this.saldo = saldoPa;
            this.direccion = direccionPa;
            this.rfc = rfcPa;
        }

        public double deposito(double montoPa)
        {
            saldo += montoPa;

            return saldo;
        }

        public double retiro(double montoPa)
        {
            if( saldo >= montoPa )
            {
                saldo -= montoPa;
            }
            else
            {
                Console.WriteLine("Saldo Insuficiente");
            }
            return saldo;
        }

        public void consultaSaldo()
        {
            Console.WriteLine("Saldo disponible: ${0}",saldo);
        }

        public override string ToString()
        {
            string mensaje;
            mensaje = "Titular: " + nombre + " " + apellido + "\nRFC: " + rfc + "\nDireccion: " + direccion + "\nSaldo: $" + saldo;
            return mensaje;
        }

    }
}
