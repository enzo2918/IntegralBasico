using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class CInicio
    {
        public void Inicio ()
        {
            Prueba clibro = new Prueba("putoc", "", "");
            CIngreso ingreso = new CIngreso();
            CPedir pedir = new CPedir();
            CAgregarLibro agrega = new CAgregarLibro();
            CEliminarLibro elimina = new CEliminarLibro();
            string eleccionp = "";
            do
            {

                Console.WriteLine("Bienvenido a la biblioteca");
                Console.WriteLine("Estas registrado? 1. Si  2. No 3. Salir");
                eleccionp = pedir.pedircadena();

                if (eleccionp == "1" || eleccionp == "si" || eleccionp == "Si")
                {
                    
                    var condicion = false;
                    var eleccion = 0;
                    condicion = ingreso.UsuarioRegistrado();
                    if (condicion)
                    {
                        do
                        {
                            Console.WriteLine("1. Agregar nuevo libro\n2. Eliminar libro\n3. Editar libro\n4. Salir");
                            eleccion = pedir.pedirentero();
                            switch (eleccion)
                            {
                                case 1:
                                    agrega.AgregarLibro();
                                    clibro.muestra();
                                    break;
                                case 2:
                                    clibro.muestra();
                                    elimina.EliminarLibro();
                                    break;


                            }
                        } while (eleccion != 4);


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
