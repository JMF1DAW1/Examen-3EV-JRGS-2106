using System;
using System.Collections.Generic;

// Examen realizado por Javier Marco Francisco 1º DAW Y 2021
namespace Examen3EV_NS
{
    // esta clase nos calcula las estadísticas de un conjunto de notas 
    public class JMF2021EstadisticasNotas 
    {
        private int suspensos;
        private int aprobados;
        private int notables;
        private int sobresalientes;

        public double media;

        public int Suspensos 
        { 
            get => suspensos; 
            set => suspensos = value; 
        }
        public int Aprobados 
        { 
            get => aprobados; 
            set => aprobados = value; 
        }
        public int Notables 
        {
            get => notables; 
            set => notables = value; 
        }
        public int Sobresalientes 
        { 
            get => sobresalientes;
            set => sobresalientes = value; 
        }

        // Constructor vacío
        public JMF2021EstadisticasNotas()
        {
            Suspensos = 0;
            Aprobados = 0;
            Notables = 0;
            Sobresalientes = 0; 
            media = 0.0;
        }

        // Constructor a partir de un array, calcula las estadísticas al crear el objeto
        public JMF2021EstadisticasNotas(List<int> listaNotas)
        {
            Suspensos = 0;
            Aprobados = 0;
            notables = 0;
            Sobresalientes = 0;
            media = 0.0;

            CalcularEstadisticas(listaNotas);
        }


        // Para un conjunto de listaNotas, calculamos las estadísticas
        // calcula la media y el número de suspensos/aprobados/notables/sobresalientes

        // Agregamos estas constantes para hacer una prueba más especifica. 
        public const string NotaPorDebajoDe0 = "Nota que está por debajo de 0";
        public const string NotaPorEncimade10 = "Nota que está por encima de 10";

        /// <summary>
        /// Método que calcula las estadísticas
        /// </summary>
        /// <param name="listaNotas"> Listado que le pasará el usuario con las lista de notas. </param>
        /// <returns> Devuelve el calculo de la media</returns>
        /// <remarks> En esta función se devolverán diferentes errores en caso de fallar. </remarks>
        public double CalcularEstadisticas(List<int> listaNotas)
        {                                 
            media = 0.0;

            // Si la lista no contiene elementos, devolvemos un error
            if (listaNotas.Count <= 0)
            {        
                throw new Exception("La lista no contiene elementos.");
            }

            for (int i = 0; i < listaNotas.Count; i++)
            {
                // Si es menor que 0, da error. 
                if (listaNotas[i] < 0)
                {
                    throw new ArgumentOutOfRangeException("nota", listaNotas[i], NotaPorDebajoDe0);
                }
                // Si es mayor que 0, da error. 
                if (listaNotas[i] > 10)
                {
                    throw new ArgumentOutOfRangeException("nota", listaNotas[i], NotaPorEncimade10);
                }
            }
          
            for (int i = 0; i < listaNotas.Count; i++)
            {
                // Por debajo de 5 suspensos
                if (listaNotas[i] < 5)
                {
                    Suspensos++;
                }
                // Nota para aprobar: 5          
                else if (listaNotas[i] >= 5 && listaNotas[i] < 7)
                {
                    Aprobados++;
                }
                // Nota para notables: 7  
                else if (listaNotas[i] >= 7 && listaNotas[i] < 9)
                {
                    Notables++;
                }
                // Nota para sobresalientes: 9
                else if (listaNotas[i] >= 9)
                {
                    Sobresalientes++;
                }                     

                media = media + listaNotas[i];
            }

            media = media / listaNotas.Count;

            return media;
        }
    }
}
