using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaStock
{
    internal class RepoBase
    {

        List<Base> bases = new List<Base>();
        public RepoBase()
        {
            bases.AddRange(new List<Base> 
            {
                new Base
                {
                    Id = 1,
                    Name = "General VN2"
                },
                
                new Base
                {
                    Id = 2,
                    Name = "Alimentos VN1",
                    Articulos =
                    {
                        new Articulo { Name = "Fideos", Code = "fid" },
                        new Articulo { Name = "Lentejas", Code = "len" },
                        new Articulo { Name = "Porotos", Code = "por" },
                        new Articulo { Name = "Cepita", Code = "cep" }
                    }
                },

                new Base
                {
                    Id = 3,
                    Name = "Bebidas VN1",
                    Articulos =
                    {
                        new Articulo { Name = "Fernet", Code = "fer" },
                        new Articulo { Name = "Gancia", Code = "gan" },
                        new Articulo { Name = "Vodka", Code = "vod" }
                    }
                },

                new Base
                {
                    Id = 4,
                    Name = "General CBA",
                    Articulos =
                    {
                        new Articulo { Name = "Fernet", Code = "fer" },
                        new Articulo { Name = "Gancia", Code = "gan" },
                        new Articulo { Name = "Vodka", Code = "vod" },
                        new Articulo { Name = "Coca", Code = "coc" },
                        new Articulo { Name = "Sprite", Code = "spr" },
                        new Articulo { Name = "Cepita", Code = "cep" }
                    }
                },

                new Base
                {
                    Id= 5,
                    Name = "General GC",
                    Articulos =
                    {
                        new Articulo { Name = "Fideos", Code = "fid" },
                        new Articulo { Name = "Lentejas", Code = "len" },
                        new Articulo { Name = "Porotos", Code = "por" },
                        new Articulo { Name = "Cepita", Code = "cep" },
                        new Articulo { Name = "Fernet", Code = "fer" },
                        new Articulo { Name = "Gancia", Code = "gan" },
                        new Articulo { Name = "Vodka", Code = "vod" }

                    }
                }
            }
            );
        }

        public List<Base> TraerLista()
        {
            return bases;
        }



    }
}
