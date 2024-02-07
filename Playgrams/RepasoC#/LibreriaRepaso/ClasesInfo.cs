using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaRepaso
{
    internal class ClasesInfo
    {
        public ClasesInfo()
        {
            
        }

        public void Main(IVehiculo vehiculo)
        {
            vehiculo.Arrancar();
        }



        public interface IVehiculo
        {
            void Arrancar();
        }

        public class Coche : IVehiculo
        {
            private void LimpiarVidrio()
            {

            }
            public void Arrancar()
            {
                LimpiarVidrio();
                Console.WriteLine("Arrancando el coche...");
            }
        }

        public class Motocicleta : IVehiculo
        {
            public void Arrancar()
            {
                Console.WriteLine("Arrancando la motocicleta...");
            }
        }




        public class UsadorArticulos
        {
            public void Main()
            {
                var articulo = new Articulo();

                var articuloStock = new ArticuloConStock();

            }

            public void ModificarArticulo(ArticuloConStock art)
            {

            }
        }



        public class Articulo
        {
            public int Id { get; set; }
            public string Codigo { get; set; }
            public double Precio { get; set; }

            public virtual void SetearPrecio()
            {

            }
        }

        public class ArticuloConStock : Articulo
        {
            public int Stock { get; set; }

            public override void SetearPrecio()
            {
                base.SetearPrecio();
            }
        }

    }
}
