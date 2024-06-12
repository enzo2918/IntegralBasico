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
    public class InicioTests
    {
        private Mock<IEstudianteRepositorio> _repoEstudiantes;
        private Mock<ICursoRepositorio> _repoCursos;
        private Mock<IEscuelaRepositorio> _repoEscuelas;
        private Mock<IErrorCRRepositorio> _repoError;
        private Mock<IPedir> _pedir;
        private Mock<IMostrar> _mostrar;
        private Mock<IObtener> _obtener;

        private Inicio _target;

        [TestInitialize]
        public void TestInitialize()
        {
            _repoEstudiantes = new Mock<IEstudianteRepositorio>(MockBehavior.Strict);
            _repoCursos = new Mock<ICursoRepositorio>(MockBehavior.Strict);
            _repoEscuelas = new Mock<IEscuelaRepositorio>(MockBehavior.Strict);
            _repoError = new Mock<IErrorCRRepositorio>(MockBehavior.Strict);
            _pedir = new Mock<IPedir>(MockBehavior.Strict);
            _mostrar = new Mock<IMostrar>(MockBehavior.Strict);
            _obtener = new Mock<IObtener>(MockBehavior.Strict);

            _target = new Inicio(_repoEstudiantes.Object, _repoCursos.Object, _repoEscuelas.Object, _repoError.Object, _pedir.Object, _mostrar.Object, _obtener.Object);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            _repoEstudiantes.VerifyAll();
            _repoCursos.VerifyAll();
            _repoEscuelas.VerifyAll();
            _repoError.VerifyAll();
            _pedir.VerifyAll();
            _mostrar.VerifyAll();
            _obtener.VerifyAll();
        }


        [TestMethod]
        public void IniciarPrograma_Accion1_Test()
        {
            var rango = (1, 11);

            _pedir.SetupSequence(p => p.Entero(It.IsAny<string>(), rango))
                  .Returns(1)
                  .Returns(11);

            _obtener.Setup(o => o.EstudiantesYMostrarTodos()).Returns(new List<Estudiante> { });

            //var estudiante = new Estudiante { Id = 5 };
            //_repoEstudiantes.Setup(r => r.ObtenerEstudiantes()).Returns(new List<Estudiante> { estudiante });
            //_mostrar.Setup(m => m.EstudianteSimplificado(estudiante) );

            _target.IniciarPrograma();
        }
        [TestMethod]
        public void IniciarPrograma_Accion2EstudianteEncontrado_Test()
        {
            var rango = (1, 11);

            _pedir.SetupSequence(p => p.Entero(It.IsAny<string>(), rango))
                  .Returns(2)
                  .Returns(11);

            _obtener.Setup(o => o.EstudiantesYMostrarTodos()).Returns(new List<Estudiante> { });
            //var estudiante = new Estudiante { Id = 5 };
            //_repoEstudiantes.Setup(r => r.ObtenerEstudiantes()).Returns(new List<Estudiante> { estudiante });
            //_mostrar.Setup(m => m.EstudianteSimplificado(estudiante));

            var nombreEstudiante = Guid.NewGuid().ToString();

            _pedir.Setup(p => p.Cadena("Que estudiante deseas ver en detalle? Escribe el nombre o el dni"))
                  .Returns(nombreEstudiante);

            var estudianteSeleccionado = new Estudiante { Id = 5 };

            _repoEstudiantes.Setup(r => r.ObtenerEstudianteConRelaciones(nombreEstudiante))
                            .Returns(estudianteSeleccionado);

            _mostrar.Setup(m => m.EstudianteYRelaciones(estudianteSeleccionado));

            _target.IniciarPrograma();
        }
        [TestMethod]
        public void IniciarPrograma_Accion2EstudianteNull_Test()
        {
            var rango = (1, 11);

            _pedir.SetupSequence(p => p.Entero(It.IsAny<string>(), rango))
                  .Returns(2)
                  .Returns(11);

            _obtener.Setup(o => o.EstudiantesYMostrarTodos()).Returns(new List<Estudiante> { });

            //var estudiante = new Estudiante { Id = 5 };
            //_repoEstudiantes.Setup(r => r.ObtenerEstudiantes()).Returns(new List<Estudiante> { estudiante });
            //_mostrar.Setup(m => m.EstudianteSimplificado(estudiante));

            var nombreEstudiante = Guid.NewGuid().ToString();

            _pedir.Setup(p => p.Cadena("Que estudiante deseas ver en detalle? Escribe el nombre o el dni"))
                  .Returns(nombreEstudiante);

            Estudiante estudianteSeleccionado = null;

            _repoEstudiantes.Setup(r => r.ObtenerEstudianteConRelaciones(nombreEstudiante))
                            .Returns(estudianteSeleccionado);

            try
            {
                _target.IniciarPrograma();
                Assert.Fail();
            }
            catch (EstudianteInexistenteException ex)
            {
                Assert.AreEqual(ex.Message, "Este estudiante no existe");
            }
        }        
        [TestMethod]
        public void IniciarPrograma_Accion3_Test()
        {
            var rango = (1, 11);

            _pedir.SetupSequence(p => p.Entero(It.IsAny<string>(), rango))
                  .Returns(3)
                  .Returns(11);

            var nombre = Guid.NewGuid().ToString();
            var dni = Guid.NewGuid().ToString();
            var telefono = Guid.NewGuid().ToString();

            _pedir.Setup(p => p.Cadena("Cual es el nombre del estudiante?"))
                  .Returns(nombre);
            _pedir.Setup(p => p.Cadena("Cual es su numero de DNI?"))
                  .Returns(dni);
            _pedir.Setup(p => p.Cadena("Cual es su numero de telefono?"))
                  .Returns(telefono);

            var estudiante = new Estudiante { Id = 5 };

            _repoEstudiantes.Setup(r => r.InsertarEstudiante(nombre, dni, telefono) );

            _target.IniciarPrograma();
        }
        [TestMethod]
        public void IniciarPrograma_Accion4Name_Test()
        {
            var rango = (1, 11);

            _pedir.SetupSequence(p => p.Entero(It.IsAny<string>(), rango))
                  .Returns(4)
                  .Returns(11);

            var nameViejo = Guid.NewGuid().ToString();
            var telefonoViejo = Guid.NewGuid().ToString();
            var dniViejo = Guid.NewGuid().ToString();
            var estudiante = new Estudiante { Id = 5, Name = nameViejo, Dni = dniViejo, Telefono = telefonoViejo };

            _obtener.Setup(o => o.EstudianteDesdeElUsuario()).Returns(estudiante);

            _mostrar.Setup(m => m.EstudianteCompleto(estudiante));

            var rangoCategoria = (1, 3);
            _pedir.Setup(p => p.Entero("Que categoria desea modificar:\n1. Nombre\n2. DNI\n3. Telefono", rangoCategoria))
                  .Returns(1);

            var nameNuevo = Guid.NewGuid().ToString();
            _pedir.Setup(p => p.Cadena("Cual es el nuevo valor?"))
                  .Returns(nameNuevo);

            _repoEstudiantes.Setup(r => r.ActualizarEstudiante(It.Is<Estudiante>(e => e.Name == nameNuevo
                                                                                      && e.Telefono == telefonoViejo
                                                                                      && e.Dni == dniViejo)));            

            _target.IniciarPrograma();
        }
        [TestMethod]
        public void IniciarPrograma_Accion4Dni_Test()
        {
            var rango = (1, 11);

            _pedir.SetupSequence(p => p.Entero(It.IsAny<string>(), rango))
                  .Returns(4)
                  .Returns(11);

            var nameViejo = Guid.NewGuid().ToString();
            var telefonoViejo = Guid.NewGuid().ToString();
            var dniViejo = Guid.NewGuid().ToString();
            var estudiante = new Estudiante { Id = 5, Name = nameViejo, Dni = dniViejo, Telefono = telefonoViejo  };

            _obtener.Setup(o => o.EstudianteDesdeElUsuario()).Returns(estudiante);

            _mostrar.Setup(m => m.EstudianteCompleto(estudiante));

            var rangoCategoria = (1, 3);
            _pedir.Setup(p => p.Entero("Que categoria desea modificar:\n1. Nombre\n2. DNI\n3. Telefono", rangoCategoria))
                  .Returns(2);

            var nuevoDni = Guid.NewGuid().ToString();
            _pedir.Setup(p => p.Cadena("Cual es el nuevo valor?"))
                  .Returns(nuevoDni);

            _repoEstudiantes.Setup(r => r.ActualizarEstudiante(It.Is<Estudiante>(e => e.Dni == nuevoDni
                                                                                      && e.Telefono == telefonoViejo
                                                                                      && e.Name == nameViejo )));

            _target.IniciarPrograma();
        }
        [TestMethod]
        public void IniciarPrograma_Accion4Telefono_Test()
        {
            var rango = (1, 11);

            _pedir.SetupSequence(p => p.Entero(It.IsAny<string>(), rango))
                  .Returns(4)
                  .Returns(11);

            var nameViejo = Guid.NewGuid().ToString();
            var telefonoViejo = Guid.NewGuid().ToString();
            var dniViejo = Guid.NewGuid().ToString();
            var estudiante = new Estudiante { Id = 5, Name = nameViejo, Dni = dniViejo, Telefono = telefonoViejo };

            _obtener.Setup(o => o.EstudianteDesdeElUsuario()).Returns(estudiante);

            _mostrar.Setup(m => m.EstudianteCompleto(estudiante));

            var rangoCategoria = (1, 3);
            _pedir.Setup(p => p.Entero("Que categoria desea modificar:\n1. Nombre\n2. DNI\n3. Telefono", rangoCategoria))
                  .Returns(3);

            var telefonoNuevo = Guid.NewGuid().ToString();
            _pedir.Setup(p => p.Cadena("Cual es el nuevo valor?"))
                  .Returns(telefonoNuevo);

            _repoEstudiantes.Setup(r => r.ActualizarEstudiante(It.Is<Estudiante>(e => e.Telefono == telefonoNuevo
                                                                                      && e.Dni == dniViejo
                                                                                      && e.Name == nameViejo )));

            _target.IniciarPrograma();
        }
        [TestMethod]
        public void IniciarPrograma_Accion5_Test()
        {
            var rango = (1, 11);

            _pedir.SetupSequence(p => p.Entero(It.IsAny<string>(), rango))
                  .Returns(5)
                  .Returns(11);

            var estudiante = new Estudiante { Id = 5 };

            _obtener.Setup(o => o.EstudianteDesdeElUsuario()).Returns(estudiante);

            _mostrar.Setup(m => m.EstudianteCompleto(estudiante));

            _repoEstudiantes.Setup(r => r.DesvincularAlumnoDeTodosLosCursos(estudiante.Id) );

            _repoEstudiantes.Setup(r => r.EliminarEstudiante(estudiante.Id) );
            
            _target.IniciarPrograma();
        }
        [TestMethod]
        public void IniciarPrograma_Accion6_NoInscripto_EscuelaMalSeleccionada_Test()
        {
            var rango = (1, 11);

            _pedir.SetupSequence(p => p.Entero(It.IsAny<string>(), rango))
                  .Returns(6)
                  .Returns(11);

            var estudiante = new Estudiante { Id = 5 };

            _obtener.Setup(o => o.EstudianteDesdeElUsuario()).Returns(estudiante);

            var nombreEscuela1 = Guid.NewGuid().ToString();
            var nombreEscuela2 = Guid.NewGuid().ToString();

            var escuelas = new List<Escuela> { new Escuela { Id = 1, Name = nombreEscuela1 }, 
                                               new Escuela { Id = 2, Name = nombreEscuela2 } 
                                             };

            _obtener.Setup(o => o.EscuelasYMostrar()).Returns(escuelas);
            //_repoEscuelas.Setup(r => r.ObtenerEscuelas()).Returns(escuelas);
            //_mostrar.Setup(m => m.Escuela(escuelas[0]) );
            //_mostrar.Setup(m => m.Escuela(escuelas[1]) );

            var nombreEscuelaInexistente = Guid.NewGuid().ToString();

            _pedir.Setup(p => p.Cadena("A que escuela lo quieres vincular?")).Returns(nombreEscuelaInexistente);

            _target.IniciarPrograma();
        }
        [TestMethod]
        public void IniciarPrograma_Accion6_NoInscripto_EscuelaBienSeleccionada_Test()
        {
            var rango = (1, 11);

            _pedir.SetupSequence(p => p.Entero(It.IsAny<string>(), rango))
                  .Returns(6)
                  .Returns(11);

            var estudiante = new Estudiante { Id = 5 };

            _obtener.Setup(o => o.EstudianteDesdeElUsuario()).Returns(estudiante);

            var nombreEscuela1 = "Pepe";
            var nombreEscuela2 = Guid.NewGuid().ToString();
            var escuela1 = new Escuela
            {
                Id = 1,
                Name = nombreEscuela1
            };

            var escuelas = new List<Escuela> { escuela1 ,
                                               new Escuela { Id = 2, Name = nombreEscuela2 }
                                             };

            _obtener.Setup(o => o.EscuelasYMostrar()).Returns(escuelas);
            //_repoEscuelas.Setup(r => r.ObtenerEscuelas()).Returns(escuelas);
            //_mostrar.Setup(m => m.Escuela(escuelas[0]) );
            //_mostrar.Setup(m => m.Escuela(escuelas[1]) );

            _pedir.Setup(p => p.Cadena("A que escuela lo quieres vincular?")).Returns(nombreEscuela1.ToLower());

            _repoEstudiantes.Setup(p => p.VincularAlumnoEscuela(escuela1.Id, estudiante.Id));

            _target.IniciarPrograma();
        }
        [TestMethod]
        public void IniciarPrograma_Accion6_YaInscripto_Test()
        {
            var rango = (1, 11);

            _pedir.SetupSequence(p => p.Entero(It.IsAny<string>(), rango))
                  .Returns(6)
                  .Returns(11);

            var estudiante = new Estudiante { Id = 5, IdEscuela = 1 };

            _obtener.Setup(o => o.EstudianteDesdeElUsuario()).Returns(estudiante);            

            _target.IniciarPrograma();
        }
        [TestMethod]
        public void IniciarPrograma_Accion7_EstudianteSinEscuela_Test()
        {
            var rango = (1, 11);

            _pedir.SetupSequence(p => p.Entero(It.IsAny<string>(), rango))
                  .Returns(7)
                  .Returns(11);

            var estudiante = new Estudiante { Id = 5 };

            _obtener.Setup(o => o.EstudianteDesdeElUsuario()).Returns(estudiante);

            List<Curso> cursos = null;

            _obtener.Setup(o => o.CursosPorEscuelaYMostrar(estudiante)).Returns(cursos);

            _target.IniciarPrograma();
        }
        [TestMethod]
        public void IniciarPrograma_Accion7_CursoMalSeleccionado_Test()
        {
            var rango = (1, 11);

            _pedir.SetupSequence(p => p.Entero(It.IsAny<string>(), rango))
                  .Returns(7)
                  .Returns(11);

            var estudiante = new Estudiante { Id = 5 };

            _obtener.Setup(o => o.EstudianteDesdeElUsuario()).Returns(estudiante);

            var nombreCurso = Guid.NewGuid().ToString();

            var cursos = new List<Curso> { new Curso { Id = 1, Name = nombreCurso } };

            _obtener.Setup(o => o.CursosPorEscuelaYMostrar(estudiante)).Returns(cursos);

            var cursosEstudiante = new List<EstudianteCurso> { new EstudianteCurso {  Id = 1 } };

            _repoCursos.Setup(r => r.ObtenerCursosEstudiante(estudiante.Id)).Returns(cursosEstudiante);

            _mostrar.Setup(m => m.CursosEstudiante(cursosEstudiante));

            var nombreCursoInexistente = Guid.NewGuid().ToString();

            _pedir.Setup(p => p.Cadena("En qué curso deseas inscribir al estudiante?")).Returns(nombreCursoInexistente);

            _target.IniciarPrograma();
        }
        [TestMethod]
        public void IniciarPrograma_Accion7_EstudianteYaInscriptoEnCurso_Test()
        {
            var rango = (1, 11);

            _pedir.SetupSequence(p => p.Entero(It.IsAny<string>(), rango))
                  .Returns(7)
                  .Returns(11);

            var estudiante = new Estudiante { Id = 5 };

            _obtener.Setup(o => o.EstudianteDesdeElUsuario()).Returns(estudiante);

            var nombreCurso = "Pepe";
            var cursoEstudianteYaInscripto = new Curso { Id = 1, Name = nombreCurso };
            var cursos = new List<Curso> { cursoEstudianteYaInscripto };

            _obtener.Setup(o => o.CursosPorEscuelaYMostrar(estudiante)).Returns(cursos);

            var cursosEstudiante = new List<EstudianteCurso> { new EstudianteCurso { Id = 1, Curso = cursoEstudianteYaInscripto } };

            _repoCursos.Setup(r => r.ObtenerCursosEstudiante(estudiante.Id)).Returns(cursosEstudiante);

            _mostrar.Setup(m => m.CursosEstudiante(cursosEstudiante));

            _pedir.Setup(p => p.Cadena("En qué curso deseas inscribir al estudiante?")).Returns(nombreCurso.ToLower());

            _target.IniciarPrograma();
        }
        [TestMethod]
        public void IniciarPrograma_Accion7_Test()
        {
            var rango = (1, 11);

            _pedir.SetupSequence(p => p.Entero(It.IsAny<string>(), rango))
                  .Returns(7)
                  .Returns(11);

            var estudiante = new Estudiante { Id = 5 };

            _obtener.Setup(o => o.EstudianteDesdeElUsuario()).Returns(estudiante);

            var nombreCurso = "Pepe";
            var curso = new Curso { Id = 1, Name = nombreCurso };
            var cursos = new List<Curso> { curso };

            _obtener.Setup(o => o.CursosPorEscuelaYMostrar(estudiante)).Returns(cursos);

            var cursosEstudiante = new List<EstudianteCurso> { new EstudianteCurso { Id = 1, Curso = new Curso { Id = 1, Name = "pipo" } } };

            _repoCursos.Setup(r => r.ObtenerCursosEstudiante(estudiante.Id)).Returns(cursosEstudiante);

            _mostrar.Setup(m => m.CursosEstudiante(cursosEstudiante));

            _pedir.Setup(p => p.Cadena("En qué curso deseas inscribir al estudiante?")).Returns(nombreCurso.ToLower());

            _repoEstudiantes.Setup(r => r.VincularAlumnoCursos(estudiante.Id, curso.Id));

            _target.IniciarPrograma();
        }
        [TestMethod]
        public void IniciarPrograma_Accion8_EstudianteSinEscuela_Test()
        {
            var rango = (1, 11);

            _pedir.SetupSequence(p => p.Entero(It.IsAny<string>(), rango))
                  .Returns(8)
                  .Returns(11);

            var estudiante = new Estudiante { Id = 5 };

            _obtener.Setup(o => o.EstudianteDesdeElUsuario()).Returns(estudiante);

            _target.IniciarPrograma();
        }
        [TestMethod]
        public void IniciarPrograma_Accion8_Test()
        {
            var rango = (1, 11);

            _pedir.SetupSequence(p => p.Entero(It.IsAny<string>(), rango))
                  .Returns(8)
                  .Returns(11);

            var estudiante = new Estudiante { Id = 5, IdEscuela = 1 };

            _obtener.Setup(o => o.EstudianteDesdeElUsuario()).Returns(estudiante);

            _repoEstudiantes.Setup(r => r.DesvincularAlumnoDeTodosLosCursos(estudiante.Id));
            _repoEstudiantes.Setup(r => r.DesvincularAlumnoEscuela(estudiante.Id));

            _target.IniciarPrograma();
        }
        [TestMethod]
        public void IniciarPrograma_Accion9_EstudianteSinEscuela_Test()
        {
            var rango = (1, 11);

            _pedir.SetupSequence(p => p.Entero(It.IsAny<string>(), rango))
                  .Returns(9)
                  .Returns(11);

            var estudiante = new Estudiante { Id = 5 };

            _obtener.Setup(o => o.EstudianteDesdeElUsuario()).Returns(estudiante);

            _target.IniciarPrograma();
        }
        [TestMethod]
        public void IniciarPrograma_Accion9_EstudianteSinCursos_Test()
        {
            var rango = (1, 11);

            _pedir.SetupSequence(p => p.Entero(It.IsAny<string>(), rango))
                  .Returns(9)
                  .Returns(11);

            var estudiante = new Estudiante { Id = 5, IdEscuela = 1};

            _obtener.Setup(o => o.EstudianteDesdeElUsuario()).Returns(estudiante);

            var estudianteCursos = new List<EstudianteCurso>();

            _repoCursos.Setup(r => r.ObtenerCursosEstudiante(estudiante.Id)).Returns(estudianteCursos);

            _target.IniciarPrograma();
        }
        [TestMethod]
        public void IniciarPrograma_Accion9_CursosMalSeleccionado_Test()
        {
            var rango = (1, 11);

            _pedir.SetupSequence(p => p.Entero(It.IsAny<string>(), rango))
                  .Returns(9)
                  .Returns(11);

            var estudiante = new Estudiante { Id = 5, IdEscuela = 1 };

            _obtener.Setup(o => o.EstudianteDesdeElUsuario()).Returns(estudiante);

            var nombreCurso = "Pepe";
            var curso = new Curso { Id = 1, Name = nombreCurso };
            var cursosEstudiante = new List<EstudianteCurso> { new EstudianteCurso { Id = 1, Curso = curso } };

            _repoCursos.Setup(r => r.ObtenerCursosEstudiante(estudiante.Id)).Returns(cursosEstudiante);

            _mostrar.Setup(m => m.CursosEstudiante(cursosEstudiante));

            var nombreCursoInexsistente = Guid.NewGuid().ToString();
            _pedir.Setup(p => p.Cadena("De qué curso deseas desinscribir al alumno?")).Returns(nombreCursoInexsistente);

            _target.IniciarPrograma();
        }
        [TestMethod]
        public void IniciarPrograma_Accion9_Test()
        {
            var rango = (1, 11);

            _pedir.SetupSequence(p => p.Entero(It.IsAny<string>(), rango))
                  .Returns(9)
                  .Returns(11);

            var estudiante = new Estudiante { Id = 5, IdEscuela = 1 };

            _obtener.Setup(o => o.EstudianteDesdeElUsuario()).Returns(estudiante);

            var nombreCurso = "Pepe";
            var curso = new Curso { Id = 1, Name = nombreCurso };
            var cursoEstudiante = new EstudianteCurso { Id = 1, IdCurso = curso.Id, Curso = curso };
            var cursosEstudiante = new List<EstudianteCurso> { cursoEstudiante };

            _repoCursos.Setup(r => r.ObtenerCursosEstudiante(estudiante.Id)).Returns(cursosEstudiante);

            _mostrar.Setup(m => m.CursosEstudiante(cursosEstudiante));

            _pedir.Setup(p => p.Cadena("De qué curso deseas desinscribir al alumno?")).Returns(nombreCurso);

            _repoEstudiantes.Setup(r => r.DesvincularAlumnoCurso(estudiante.Id, cursoEstudiante.IdCurso));

            _target.IniciarPrograma();
        }
        [TestMethod]
        public void IniciarPrograma_Accion10_Test()
        {
            var rango = (1, 11);

            _pedir.SetupSequence(p => p.Entero(It.IsAny<string>(), rango))
                  .Returns(10);


            var exception = new Exception("test");


            _repoError.Setup(r => r.Error()).Throws(exception);

            try
            {
                _target.IniciarPrograma();
                Assert.Fail();
            }
            catch (Exception ex)
            {
                Assert.AreEqual(exception, ex);
            }
        }


        

    }
}
