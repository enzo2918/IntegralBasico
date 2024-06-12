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
    public class ObtenerTests
    {
        private Mock<IPedir> _pedir;
        private Mock<IMostrar> _mostrar;
        private Mock<IEstudianteRepositorio> _repoEstudiantes;
        private Mock<IEscuelaRepositorio> _repoEscuela;
        private Mock<ICursoRepositorio> _repoCurso;

        private Obtener _target;


        [TestInitialize]
        public void TestInitialize()
        {
            _pedir = new Mock<IPedir>(MockBehavior.Strict);
            _mostrar = new Mock<IMostrar>(MockBehavior.Strict);
            _repoEstudiantes = new Mock<IEstudianteRepositorio>(MockBehavior.Strict);
            _repoEscuela = new Mock<IEscuelaRepositorio>(MockBehavior.Strict);
            _repoCurso = new Mock<ICursoRepositorio>(MockBehavior.Strict);

            _target = new Obtener(_pedir.Object, _mostrar.Object, _repoEstudiantes.Object, _repoEscuela.Object, _repoCurso.Object);
        }
        [TestCleanup]
        public void TestCleanup()
        {
            _pedir.VerifyAll();
            _mostrar.VerifyAll();
            _repoEstudiantes.VerifyAll();
            _repoEscuela.VerifyAll();
            _repoCurso.VerifyAll();
        }

        [TestMethod]
        public void EstudiantesYMostrarTodos_Test()
        {
            var estudiante1 = new Estudiante();
            var estudiante2 = new Estudiante();

            var estudiantes = new List<Estudiante> { estudiante1, estudiante2 };

            _repoEstudiantes.Setup(r => r.ObtenerEstudiantes()).Returns(estudiantes);

            _mostrar.Setup(m => m.EstudianteSimplificado(estudiante1));
            _mostrar.Setup(m => m.EstudianteSimplificado(estudiante2));

            var result = _target.EstudiantesYMostrarTodos();

            Assert.AreEqual(estudiantes, result);
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains(estudiante1));
            Assert.IsTrue(result.Contains(estudiante2));
        }
        [TestMethod]
        public void EstudianteDesdeElUsuario_PorNombre_Test()
        {
            var estudiante1 = new Estudiante { Name = "Pepe", Dni = "42321654" };
            var estudiante2 = new Estudiante { Name = "Pipo", Dni = "42654321" };

            var estudiantes = new List<Estudiante> { estudiante1, estudiante2 };

            _repoEstudiantes.Setup(r => r.ObtenerEstudiantes()).Returns(estudiantes);

            _mostrar.Setup(m => m.EstudianteSimplificado(estudiante1));
            _mostrar.Setup(m => m.EstudianteSimplificado(estudiante2));

            _pedir.Setup(p => p.Cadena("Que estudiante deseas inscribir? Escribe el nombre o el dni")).Returns("pepe");

            var result = _target.EstudianteDesdeElUsuario();

            Assert.AreEqual(estudiante1, result);
        }
        [TestMethod]
        public void EstudianteDesdeElUsuario_PorDni_Test()
        {
            var estudiante1 = new Estudiante { Name = "Pepe", Dni = "42321654" };
            var estudiante2 = new Estudiante { Name = "Pipo", Dni = "42654321" };

            var estudiantes = new List<Estudiante> { estudiante1, estudiante2 };

            _repoEstudiantes.Setup(r => r.ObtenerEstudiantes()).Returns(estudiantes);

            _mostrar.Setup(m => m.EstudianteSimplificado(estudiante1));
            _mostrar.Setup(m => m.EstudianteSimplificado(estudiante2));

            _pedir.Setup(p => p.Cadena("Que estudiante deseas inscribir? Escribe el nombre o el dni")).Returns("42654321");

            var result = _target.EstudianteDesdeElUsuario();

            Assert.AreEqual(estudiante2, result);

        }
        [TestMethod]
        public void EstudianteDesdeElUsuario_MalIngresado_Test()
        {
            var estudiante1 = new Estudiante { Name = "Pepe", Dni = "42321654" };
            var estudiante2 = new Estudiante { Name = "Pipo", Dni = "42654321" };

            var estudiantes = new List<Estudiante> { estudiante1, estudiante2 };

            _repoEstudiantes.Setup(r => r.ObtenerEstudiantes()).Returns(estudiantes);

            _mostrar.Setup(m => m.EstudianteSimplificado(estudiante1));
            _mostrar.Setup(m => m.EstudianteSimplificado(estudiante2));

            _pedir.Setup(p => p.Cadena("Que estudiante deseas inscribir? Escribe el nombre o el dni")).Returns("papi");

            try
            {
                _target.EstudianteDesdeElUsuario();
                Assert.Fail();
            }
            catch (EstudianteInexistenteException ex)
            {
                Assert.AreEqual(ex.Message, "Este estudiante no existe");
            }
        }
        [TestMethod]
        public void EscuelasYMostrar_Test()
        {
            var escuela1 = new Escuela();
            var escuela2 = new Escuela();

            var escuelas = new List<Escuela> { escuela1, escuela2 };

            _repoEscuela.Setup(r => r.ObtenerEscuelas()).Returns(escuelas);

            _mostrar.Setup(m => m.Escuela(escuela1));
            _mostrar.Setup(m => m.Escuela(escuela2));

            var result = _target.EscuelasYMostrar();

            Assert.AreEqual(escuelas, result);
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains(escuela1));
            Assert.IsTrue(result.Contains(escuela2));
        }
        [TestMethod]
        public void CursosPorEscuelaYMostrar_EstudianteSinEscuela_Test()
        {
            var estudiante = new Estudiante();

            var result = _target.CursosPorEscuelaYMostrar(estudiante);

            Assert.AreEqual(null, result);
        }
        [TestMethod]
        public void CursosPorEscuelaYMostrar_Test()
        {
            var estudiante = new Estudiante { IdEscuela = 5, };

            var curso1 = new Curso { IdEscuela = 5};
            var curso2 = new Curso { IdEscuela = 5};

            var cursos = new List<Curso> { curso1, curso2};

            _repoCurso.Setup(r => r.ObtenerCursosPorEscuela(estudiante.IdEscuela.Value)).Returns(cursos);

            var result = _target.CursosPorEscuelaYMostrar(estudiante);

            Assert.AreEqual(cursos, result);
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains(curso1));
            Assert.IsTrue(result.Contains(curso2));
        }
    }
}
