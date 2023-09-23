using APIIO.Business.Interfaces.Repositories;
using APIIO.Business.Models;
using APIIO.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIIO.Data.Repositories
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(DbApiContext context) : base(context) 
        {
            
        }
    }
}
