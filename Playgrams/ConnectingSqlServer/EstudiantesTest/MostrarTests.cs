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
    public class MostrarTests
    {       
        private Mock<IOutput> _output;

        private Mostrar _target;

        [TestInitialize]
        public void TestInitialize()
        {
            _output = new Mock<IOutput>(MockBehavior.Strict);

            _target = new Mostrar(_output.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _output.VerifyAll();
        }

        [TestMethod]
        public void EstudianteSimplificado_test()
        {
            var estudiante = new Estudiante { Name = Guid.NewGuid().ToString(), Dni = Guid.NewGuid().ToString() };
            _output.Setup(o => o.Line($"Nombre: {estudiante.Name}, Dni: {estudiante.Dni}"));

            _target.EstudianteSimplificado(estudiante);
        }
        [TestMethod]
        public void EstudianteCompleto_SinTelefono_test()
        {
            var estudiante = new Estudiante { Id = 1, Name = Guid.NewGuid().ToString(), Dni = Guid.NewGuid().ToString() };
            _output.Setup(o => o.Line($"ID: {estudiante.Id}, Nombre: {estudiante.Name}, Dni: {estudiante.Dni}, Telefono: No declarado"));

            _target.EstudianteCompleto(estudiante);
        }
        [TestMethod]
        public void EstudianteCompleto_ConTelefono_test()
        {
            var estudiante = new Estudiante { Id = 1, Name = Guid.NewGuid().ToString(), Dni = Guid.NewGuid().ToString(), Telefono = Guid.NewGuid().ToString() };
            _output.Setup(o => o.Line($"ID: {estudiante.Id}, Nombre: {estudiante.Name}, Dni: {estudiante.Dni}, Telefono: {estudiante.Telefono}"));

            _target.EstudianteCompleto(estudiante);
        }
        [TestMethod]
        public void EstudianteYRelaciones_ConEscuela_test()
        {
            var curso = new Curso { Name = "ingles"};
            var estudianteCursos = new List<EstudianteCurso> { new EstudianteCurso { FechaInscripcion = new DateTime(2020, 1, 15, 10, 20, 15), Curso = curso },
                                                               new EstudianteCurso { Curso = curso} };

            var estudiante = new Estudiante { Id = 1, Name = "pepe", Dni = "42318749", Telefono = "2612594592", Escuela = new Escuela { Name = "isma" },
                                              EstudiantesCursos = estudianteCursos
                                            };
            _output.Setup(o => o.Line($"ID: 1, Nombre: pepe, Dni: 42318749, Telefono: 2612594592, Escuela: isma"));
            _output.Setup(o => o.Line($"Curso: ingles, Fecha de inscripcion: 2020-01-15 10:20:15"));
            _output.Setup(o => o.Line($"Curso: ingles, Fecha de inscripcion: No declarada"));
            _output.Setup(o => o.Line(null));

            _target.EstudianteYRelaciones(estudiante);
        }
        [TestMethod]
        public void EstudianteYRelaciones_SinEscuela_test()
        {
            var estudiante = new Estudiante
            {
                Id = 1,
                Name = "pepe",
                Dni = "42318749",
                Telefono = "2612594592",
                EstudiantesCursos = new List<EstudianteCurso>()
            };
            _output.Setup(o => o.Line($"ID: 1, Nombre: pepe, Dni: 42318749, Telefono: 2612594592, Escuela: "));
            _output.Setup(o => o.Line(null));

            _target.EstudianteYRelaciones(estudiante);
        }
        [TestMethod]
        public void Escuela_test()
        {
            var escuela = new Escuela { Name = "isma" };
            
            _output.Setup(o => o.Line($"Nombre: isma"));

            _target.Escuela(escuela);
        }
        [TestMethod]
        public void CursosEstudiante_ConCurso_test()
        {
            _output.Setup(o => o.Line("Cursos inscriptos del estudiante:"));

            var curso = new Curso { Name = "ingles" };
            var estudianteCursos = new List<EstudianteCurso> { new EstudianteCurso { Curso = curso} };
            _output.Setup(o => o.Line("ingles"));

            _output.Setup(o => o.Line(null));

            _target.CursosEstudiante(estudianteCursos);

        }
        [TestMethod]
        public void CursosEstudiante_SinCurso_test()
        {
            _output.Setup(o => o.Line("Cursos inscriptos del estudiante:"));

            var estudianteCursos = new List<EstudianteCurso> { };
            
            _output.Setup(o => o.Line(null));

            _target.CursosEstudiante(estudianteCursos);

        }





    }
}
