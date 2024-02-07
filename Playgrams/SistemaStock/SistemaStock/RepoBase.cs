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
                    Name = "Villa Nueva"
                },

                new Base
                {
                    Id = 2,
                    Name = "Ciudad",
                    Articulo =
                    {
                        new Articulo { Name = "Fideos", Code = "fid" },
                        new Articulo { Name = "Lentejas", Code = "len" },
                        new Articulo { Name = "Porotos", Code = "por" }
                    }
                },

                new Base
                {
                    Id = 3,
                    Name = "Maipu",
                    Articulo =
                    {
                        new Articulo { Name = "Fernet", Code = "fer", Stock = 12 },
                        new Articulo { Name = "Gancia", Code = "gan", Stock = 4 },
                        new Articulo { Name = "Vodka", Code = "vod", Stock = 8 }
                    }
                },

                new Base
                {
                    Id = 4,
                    Name = "Godoy Cruz",
                    Articulo =
                    {
                        new Articulo { Name = "Fernet", Code = "fer", Stock = 8 },
                        new Articulo { Name = "Gancia", Code = "gan", Stock = 6 },
                        new Articulo { Name = "Vodka", Code = "vod", Stock = 16 },
                        new Articulo { Name = "Coca", Code = "coc", Stock = 48 },
                        new Articulo { Name = "Sprite", Code = "spr", Stock = 22 },
                        new Articulo { Name = "Cepita", Code = "cep", Stock = 0 }
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
