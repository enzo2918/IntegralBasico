using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class CEditarLibro
    {
        CInventario inventario = new CInventario();
        CPedir pedir = new CPedir();
        public void EditarLibro(CLibro[] plibro) 
        {
            var eleccion = "";
            Console.WriteLine("Que libro deseas editar?");
            inventario.MuestraInventario(plibro);
            eleccion = pedir.pedircadena();
            Editar(eleccion.ToLower(),plibro);
        }
        private void Editar(string peleccion, CLibro[] plibro)
        {
            var eleccion = "";
            var dato = "";
            for (int n = 0; n < plibro.Length; n++)
            {
                if (plibro[n] != null)
                {
                    if (peleccion == plibro[n].ATitulo)
                    {
                        Console.WriteLine("Que deseas modificar:\n1. Titulo: {0}\n2. Autor: {1}\n3. Genero: {2}", plibro[n].ATitulo, plibro[n].AAutor, plibro[n].AGenero);
                        eleccion = pedir.pedircadena();
                        if (eleccion == "1" || eleccion.ToLower() == "titulo")
                        {
                            Console.WriteLine("Cual es el nuevo Titulo?");
                            dato = pedir.pedircadena();
                            plibro[n].ATitulo = dato;
                            break;
                        }
                        if (eleccion == "2" || eleccion.ToLower() == "autor")
                        {
                            Console.WriteLine("Cual es el nuevo Autor?");
                            dato = pedir.pedircadena();
                            plibro[n].AAutor = dato;
                            break;
                        }
                        if (eleccion == "3" || eleccion.ToLower() == "genero")
                        {
                            Console.WriteLine("Cual es el nuevo Genero?");
                            dato = pedir.pedircadena();
                            plibro[n].AGenero = dato;
                            break;
                        }
                    }
                }
                
            }
        }
        
    }
}
