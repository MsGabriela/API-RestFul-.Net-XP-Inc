using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIIO.Business.Models
{
    public abstract class Entity
    {
        public Guid Id { get; set; }

        public DateTime DataCadastro { get; set; }
        public bool Ativo { get; set; }
        public Entity()
        {
            Id = Guid.NewGuid();
            DataCadastro = DateTime.Now;
            Ativo = true;
        }
        
    }
}
