using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Projeto_ONE.Data.Entidade
{
    public class Tarefa
    {

        public virtual int IdTarefa { get; set;}
        public virtual string Titulo { get; set; }
        public virtual string Descricao { get; set; }
        public virtual DateTime DataHoraInicio { get; set; }
        public virtual DateTime DataHoraFim { get; set; }

        // relacionamentos 
        public virtual Categoria Categoria { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}