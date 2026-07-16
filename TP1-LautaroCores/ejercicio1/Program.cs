using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/*Realizar un programa que represente una simulación de copos de nieve cayendo en la consola, utilizando el símbolo "*" para cada copo.

El programa debe cumplir con las siguientes condiciones:
Definir una clase Configuracion que almacene parámetros de la simulación, como la cantidad de filas, columnas y la velocidad de caída de los copos.
Definir una clase Copo que modele el comportamiento de un copo de nieve. Cada copo debe tener una posición en la consola y un método para mostrarse y desplazarse hacia abajo.
Usar una lista para administrar todos los copos activos durante la simulación.
Implementar una lógica que controle la caída de los copos de nieve, evitando que se superpongan en la misma posición.
Al completarse una fila con copos en todas las columnas, esta debe eliminarse para permitir que continúe la simulación.
El programa debe ejecutarse en un ciclo continuo, simulando de manera animada la caída de los copos.
Adicionalmente, se les llamará individualmente para que expliquen brevemente el funcionamiento del código y realicen alguna modificación al mismo dictada en el momento por el docente. Para dicho cambio en el código tendrán 7 minutos cada alumno. En caso de no poder realizarlo, deberán recuperar el trabajo.

La defensa de este trabajo se realiza de manera PRESENCIAL.

Para realizar este trabajo es requisito obligatorio tenes las actividades 21 y 22 hechas.

Detalles a tener en cuenta al momento de entregar:
El enlace de github con el trabajo debe estar subido ANTES de que comience la clase. De no entregarse en fecha y horario correspondiente se toma por desaprobado.
La actividad debe estar subida a un repositorio de Github. Esta debe estar subida como una carpeta con su nombre correspondiente y sus proyectos por separado. Debe ser un nuevo repositorio y no el mismo de la cursada.
La carpeta de esta actividad debe de el siguiente nombre nombre: "TP1-[NombreApellido]"
La consigna debe estar redactada en el código como un comentario.
Esta actividad es de realización individual.

Cualquier código similar al de otro compañero será considerado en la nota final del trabajo.
Para la aprobación del trabajo es requisito obligatorio contar con todos los items en el mismo (programa y entrega). En el caso de no tenerlo, se tomará el trabajo por desaprobado.

FECHA DE ENTREGA: 16/07 - 7:45*/

namespace ejercicio1 { 

    class Configuracion
    {
        private int filas;
        private int columnas;
        private int velocidad;
       
        
        public int Filas {
        get { return filas; }
            set { filas = value; }
        }
        public int Columnas {
            get { return columnas; }
            set { columnas = value; }
        }
        public int Velocidad {
            get { return velocidad; }
            set { velocidad = value; }
        }
    }

    internal class Copo
    {
        private int Fila;
        private int Columna;


        public Copo(int Fila, int Columna)
        {
            this.Fila = Fila;
            this.Columna = Columna;
        }

        public void Mostrar()
        {
            Console.SetCursorPosition(Columna, Fila);
            Console.Write("*");
        }
        public void Borrar()
        {
            Console.SetCursorPosition(Columna, Fila);
            Console.Write(" ");
        }
        public void Desplazar()
        {
            Borrar();
            Fila++;
        }

        static void Main(string[] args)
        {
            Configuracion config = new Configuracion()
            {
                Filas = 20,
                Columnas = 20,
                Velocidad = 100
            };

            List<Copo> copos = new List<Copo>();
            Random random = new Random();
            Console.CursorVisible = false;

            while (true) 
            {
                int columna = random.Next(config.Columnas);
                Copo copo = new Copo(0, columna);
                copos.Add(copo);

                foreach (var c in copos)
                {
                    int FilaSiguiente = c.Fila + 1;
                    bool HayCopoEnFilaSiguiente = copos.Any(cop => cop.Fila == FilaSiguiente && cop.Columna == c.Columna);

                    if (!HayCopoEnFilaSiguiente)
                     {
                        if (c.Fila < config.Filas - 1)
                        {
                          
                            c.Desplazar();
                        }
                     }
                }
               
                for (int fila = 0; fila < config.Filas; fila++)
                {
                    int cantidadEnFila = copos.Count(c => c.Fila == fila);

                    if (cantidadEnFila == config.Columnas)
                    {
                        foreach (var c in copos)
                        {
                            c.Borrar();
                        }
                        copos.RemoveAll(d => d.Fila == fila);
                    }
                }

                foreach (var c in copos)
                {
                    c.Mostrar();
                }

                Thread.Sleep(config.Velocidad);
            }
            
        }
    }
}
