using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;


namespace Projeto_ONE.Data.Entidade
{
    public class Usuario
    {
       
            public virtual int IdUsuario { get; set; }
            public virtual string Nome { get; set; }
            public virtual string Login { get; set; }
            public virtual string Senha { get; set; }
            public virtual DateTime DataCadastro { get; set; }

            public virtual ICollection<Tarefa> Tarefas { get; set; }
        
    }
}