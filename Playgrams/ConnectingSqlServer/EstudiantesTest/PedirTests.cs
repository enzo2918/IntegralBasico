using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ProgramaEstudiantes;
using ProgramaEstudiantes.Exceptions;
using ProgramaEstudiantes.Repositorios;
using ProgramaEstudiantes.Repositorios.ConsultasCrudas;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EstudiantesTest
{
    [TestClass]
    public class PedirTests
    {
        private Mock<IInput> _input;

        private Pedir _target;


        [TestInitialize]
        public void TestInitialize()
        {
            _input = new Mock<IInput>(MockBehavior.Strict);

            _target = new Pedir(_input.Object);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            _input.VerifyAll();            
        }

        [TestMethod]
        public void Entero_DatoMalIngresado_Tests()
        {
            var mensaje = Guid.NewGuid().ToString();
            var rango = (1, 5);
            var datoIngresado = "Pepe";

           _input.Setup(i => i.Line()).Returns(datoIngresado);

            try
            {
                _target.Entero(mensaje, rango);
                Assert.Fail();
            }
            catch (InputInvalidaException ex)
            {
                Assert.AreEqual(ex.Message, "El dato ingresado debe ser un numero");
            }
        }
        [TestMethod]
        public void Entero_DatoFueraDeRango_Tests()
        {
            var mensaje = Guid.NewGuid().ToString();
            var rango = (1, 5);
            var datoIngresado = "6";
            
            _input.Setup(i => i.Line()).Returns(datoIngresado);

            try
            {
                _target.Entero(mensaje, rango);
                Assert.Fail();
            }
            catch (FueraDeRangoException ex)
            {
                Assert.AreEqual(ex.Message, "El dato ingresado no se encuentra entre las opciones");
            }
        }
        [TestMethod]
        public void Entero_Tests()
        {
            var mensaje = Guid.NewGuid().ToString();
            var rango = (1, 5);
            var datoIngresado = "5";

            _input.Setup(i => i.Line()).Returns(datoIngresado);

            var result = _target.Entero(mensaje, rango);

            Assert.AreEqual(5, result);            
        }
        [TestMethod]
        public void Cadena_Tests()
        {
            var mensaje = Guid.NewGuid().ToString();
            var datoIngresado = "Pepe";

            _input.Setup(i => i.Line()).Returns(datoIngresado);

            var result = _target.Cadena(mensaje);

            Assert.AreEqual("Pepe", result);
        }



    }
}
