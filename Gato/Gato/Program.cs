using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gato
{
    internal class Program
    {
        //Se crea un arreglo bidimensional para el tablero del juego(3 filas y 3 columnas)
        static int[,] tablero = new int[3, 3];
        //Se crea un arreglo para los simbolos del tablero
        static char[] simbolo = { ' ', 'O', 'X' }; //Jugador1:O Jugador2:X
        static void Main(string[] args)
        {
            bool terminado = false;
            
            //Dibujando el tablero
            dibujarTablero();
            Console.WriteLine("Jugador 1 = O\nJugador 2 = X");
            do
            {
                //Turno del jugador 1
                preguntarPosicion(1);

                //dibujar la casilla del jugador 1
                dibujarTablero();

                //Comprobar si ha ganado el jugador 1
                terminado = comprobarGanador();

                if(terminado == true)
                {
                    Console.WriteLine("¡El jugador 1 ha ganado!");
                }
                else //Si no ha ganado se comprueba si hubo empate
                {
                    terminado = comprobarEmpate();
                    if(terminado == true)
                    {
                        Console.WriteLine("¡Esto es un empate!");
                    }
                    //Si no gano el jugador 1 y no hay empate, es turno del jugador 2
                    else
                    {
                        preguntarPosicion(2);
                        //dibujar la casilla del jugador 2
                        dibujarTablero();
                        //Comprobar si ha ganado el jugador 2
                        terminado = comprobarGanador();
                        if(terminado == true)
                        {
                            Console.WriteLine("¡El jugador 2 ha ganado!");
                        }


                    }
                }


            } while (terminado == false); //Se repetirá hasta tres en linea o empate


        }

        static void dibujarTablero()
        {
            //Variables de conteo del ciclo
            int fila = 0;
            int columna = 0;

            Console.WriteLine();
            Console.WriteLine("-------------");

            for(fila = 0; fila < 3; fila++)
            {
                Console.Write("|");
                for(columna = 0; columna < 3; columna++)
                {
                    //Asigna un Espacio, O, X
                    Console.Write(" {0} |", simbolo[tablero[fila, columna]]);
                }
                Console.WriteLine();
                Console.WriteLine("-------------");
            }
        }

        //Se pregunta en donde se va a dibujar en el tablero
        static void preguntarPosicion(int jugador)
        {
            int fila, columna;
            do
            {
                Console.WriteLine();
                Console.WriteLine("Turno del jugador: {0}", jugador);
                //Se pide el num de fila
                do
                {
                    Console.Write("Selecciona la fila(1 a 3):");
                    fila = Convert.ToInt32(Console.ReadLine());

                } while ((fila<1) || (fila>3));
                //Se pide el num de columna
                do
                {
                    Console.WriteLine("Selecciona la columna(1 a 3): ");
                    columna = Convert.ToInt32(Console.ReadLine());

                } while ((columna < 1) || (columna > 3));

                if (tablero[fila -1, columna -1] != 0)
                {
                    Console.WriteLine("Casilla Ocupada");
                }

            } while (tablero[fila - 1, columna - 1] != 0);

            //Si lo anterior es correcto, se le asigna al jugador correspondiente
            tablero[fila - 1, columna - 1] = jugador;

        }

        //Devuelve true si hay tres en linea
        static bool comprobarGanador()
        {
            int fila = 0;
            int columna = 0;
            bool tresEnLinea = false;

            //Si en alguna fila todas las casillas son iguales y no estan vacias
            for(fila = 0; fila < 3; fila++)
            {
                if ((tablero[fila, 0] == tablero[fila, 1]) && (tablero[fila, 0] == tablero[fila, 2]) && (tablero[fila,0] != 0))
                {
                    tresEnLinea = true;
                }
            }

            //Si en alguna columna todas las casillas son iguales y no estan vacias
            for(columna = 0; columna < 3; columna++)
            {
                if ((tablero[0, columna] == tablero[1, columna]) && (tablero[0, columna] == tablero[1, columna]) && (tablero[0, columna] != 0))
                {
                    tresEnLinea = true;
                }
            }

            //Comprobar si en alguna diagonal todas las casillas son iguales y no estan vacias
            if ((tablero[0,0] == tablero[1,1]) && (tablero[0,0] == tablero[2,2]) && (tablero[0,0] != 0 ))
            {
                tresEnLinea = true;
            }
            if ((tablero[0, 2] == tablero[1, 1]) && (tablero[0, 2] == tablero[2, 0]) && (tablero[0, 2] != 0))
            {
                tresEnLinea = true;
            }

            return tresEnLinea;
        }

        //Devuelve true si hay empate
        static bool comprobarEmpate()
        {
            bool hayEspacio = false;
            int fila = 0;
            int columna = 0;

            for(fila = 0; fila < 3; fila++)
            {
                for(columna = 0; columna < 3; columna++)
                {
                    if (tablero[fila,columna] == 0) //Si detecta una casilla vacia al recorrer todavia se puede jugar
                    {
                        hayEspacio = true;
                    }
                }
            }

            return !hayEspacio;//Si hayEspacio es true, se tiene que regresar una negacion de true para que la condicion de empate no se cumpla en la funcion Main 

        }

    }
}
