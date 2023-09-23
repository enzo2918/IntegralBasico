using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class CInicio
    {

        public CLibro[] libro = new CLibro[10];
        public void Inicio ()
        {
            CIngreso ingreso = new CIngreso();
            CPedir pedir = new CPedir();
            CAgregarLibro agrega = new CAgregarLibro();
            CEliminarLibro elimina = new CEliminarLibro();
            CEditarLibro edita = new CEditarLibro();
            string eleccionp = "";
            do
            {

                Console.WriteLine("Bienvenido a la biblioteca");
                Console.WriteLine("Estas registrado? 1. Si  2. No 3. Salir");
                eleccionp = pedir.pedircadena();

                if (eleccionp == "1" || eleccionp == "si" || eleccionp == "Si")
                {
                    
                    var condicion = "";
                    var eleccion = 0;
                    condicion = ingreso.UsuarioRegistrado();
                    if (condicion == "administrador")
                    {
                        do
                        {
                            Console.WriteLine("1. Agregar nuevo libro\n2. Eliminar libro\n3. Editar libro\n4. Salir");
                            eleccion = pedir.pedirentero();
                            switch (eleccion)
                            {
                                case 1:
                                    agrega.AgregarLibro(libro);
                                    break;
                                case 2:
                                    elimina.EliminarLibro(libro);
                                    break;
                                case 3:
                                    edita.EditarLibro(libro);
                                    break;
                            }
                        } while (eleccion != 4);
                    }
                    if (condicion == "cliente")
                    {
                        do
                        {
                            Console.WriteLine("1. Pedir libro\n2. Devolver libro\n3. Salir");
                            eleccion = pedir.pedirentero();
                            switch (eleccion)
                            {
                                case 1:

                                    break;
                            
                            }
                        } while (eleccion != 3);


                    }

                }
                if (eleccionp == "2" || eleccionp == "no" || eleccionp == "No")
                {

                    ingreso.UsuarioNoRegistrado();

                }

            } while (eleccionp != "3");
        }
    }
}
