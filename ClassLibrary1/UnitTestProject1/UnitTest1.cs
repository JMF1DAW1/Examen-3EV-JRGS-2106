using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Examen3EV_NS;
using System;

// Examen realizado por Javier Marco Francisco 1º DAW Y 2021
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ListaVacia()
        {
            List<int> notas = new List<int>();
            JMF2021EstadisticasNotas prueba = new JMF2021EstadisticasNotas();

            // Acción a probar
            prueba.CalcularEstadisticas(notas);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NotaMenorque0()
        {
            List<int> notas = new List<int>();


            notas.Add(-1);
            JMF2021EstadisticasNotas prueba = new JMF2021EstadisticasNotas();
            // Acción a probar
            prueba.CalcularEstadisticas(notas);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void NotaMayorQue10()
        {
            List<int> notas = new List<int>();

            notas.Add(11);

            JMF2021EstadisticasNotas prueba = new JMF2021EstadisticasNotas();

            // Acción a probar
            prueba.CalcularEstadisticas(notas);
        }

        [TestMethod]
        public void ContadorSuspensos()
        {
            List<int> notas = new List<int>();
            JMF2021EstadisticasNotas prueba = new JMF2021EstadisticasNotas();
            notas.Add(0);
            notas.Add(5);
            notas.Add(9);
            notas.Add(3);
            notas.Add(7);
            notas.Add(4);
            notas.Add(8);

            int ContadorSuspensos = 3;

            // Acción a probar
            prueba.CalcularEstadisticas(notas);

            // actual
            int actual = prueba.Suspensos;

            Assert.AreEqual(actual, ContadorSuspensos, 0.001, "No da el resultado esperado");
        }

        [TestMethod]
        public void ContadorAprobados()
        {
            List<int> notas = new List<int>();
            JMF2021EstadisticasNotas prueba = new JMF2021EstadisticasNotas();
            notas.Add(5);
            notas.Add(6);
            notas.Add(7);

            int ContadorAprobados = 2;

            // Acción a probar
            prueba.CalcularEstadisticas(notas);

            // Actual
            int actual = prueba.Aprobados;

            Assert.AreEqual(actual, ContadorAprobados, 0.001, "No da el resultado esperado");
        }
        [TestMethod]
        public void ContadorAprobadosPorDefecto()
        {
            List<int> notas = new List<int>();
            JMF2021EstadisticasNotas prueba = new JMF2021EstadisticasNotas();
            notas.Add(0);
            notas.Add(5);
            notas.Add(9);
            notas.Add(3);
            notas.Add(7);
            notas.Add(4);
            notas.Add(8);

            int ContadorAprobados = 1;

            // Acción a probar
            prueba.CalcularEstadisticas(notas);

            // Actual
            int actual = prueba.Aprobados;

            Assert.AreEqual(actual, ContadorAprobados, 0.001, "No da el resultado esperado");
        }

        [TestMethod]
        public void ContadorNotables()
        {
            List<int> notas = new List<int>();
            JMF2021EstadisticasNotas prueba = new JMF2021EstadisticasNotas();
            notas.Add(7);
            notas.Add(8);
            notas.Add(9);

            int ContadorNotables = 2;

            // Acción a probar
            prueba.CalcularEstadisticas(notas);

            // Actual
            int actual = prueba.Notables;

            Assert.AreEqual(actual, ContadorNotables, 0.001, "No da el resultado esperado");
        }

        [TestMethod]
        public void ContadorSobresalientes()
        {
            List<int> notas = new List<int>();
            JMF2021EstadisticasNotas prueba = new JMF2021EstadisticasNotas();
            notas.Add(8);
            notas.Add(9);
            notas.Add(10);

            int ContadorSobresalientes = 2;

            // Acción a probar
            prueba.CalcularEstadisticas(notas);

            // Actual
            int actual = prueba.Sobresalientes;

            Assert.AreEqual(actual, ContadorSobresalientes, 0.001, "No da el resultado esperado.");
        }


        [TestMethod]
        public void MediaEsperada()
        {
            List<int> notas = new List<int>();
            JMF2021EstadisticasNotas prueba = new JMF2021EstadisticasNotas();
            notas.Add(0);
            notas.Add(5);
            notas.Add(9);
            notas.Add(3);
            notas.Add(7);
            notas.Add(4);
            notas.Add(8);

            double mediaEsperada = 5.143;

            // Acción a probar
            prueba.CalcularEstadisticas(notas);

            // Actual
            double actual = prueba.media;

            Assert.AreEqual(mediaEsperada, actual, 0.001, "No da la misma media");
        }

        [TestMethod]
        public void NotaMayorQue10Mejorado()
        {
            try
            {
                List<int> notas = new List<int>();

                notas.Add(11);

                JMF2021EstadisticasNotas prueba = new JMF2021EstadisticasNotas();

                // Acción a probar
                prueba.CalcularEstadisticas(notas);
            }
            catch (ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, JMF2021EstadisticasNotas.NotaPorEncimade10, "Error");
                return;
            }
            Assert.Fail("Error");        
        }

        [TestMethod]
        public void TestConstructorMedia()
        {
            List<int> notas = new List<int>();

            notas.Add(0);
            notas.Add(5);
            notas.Add(9);
            notas.Add(3);
            notas.Add(7);
            notas.Add(4);
            notas.Add(8);

            double mediaEsperada = 5.143;

            // Acción a probar
            JMF2021EstadisticasNotas prueba = new JMF2021EstadisticasNotas(notas);

            // Actual
            double actual = prueba.media;

            Assert.AreEqual(mediaEsperada, actual, 0.001, "No da la misma media");
        }
    }
}
