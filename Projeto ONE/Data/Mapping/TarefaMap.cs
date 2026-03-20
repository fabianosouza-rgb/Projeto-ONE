using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using Projeto_ONE.Data.Entidade;
using System.Threading.Tasks;

namespace Projeto_ONE.Data.Mapping
{
    public class TarefaMap : ClassMap<Tarefa>
    {
        public TarefaMap()
        {
            Table("Tarefa"); //nome da tabela...
                             //chave primaria...
            Id(t => t.IdTarefa, "IdTarefa").GeneratedBy.Identity();
            //demais propriedades..
            Map(t => t.Titulo, "Titulo").Length(50).Not.Nullable();
            Map(t => t.Descricao, "Descricao").Not.Nullable();
            Map(t => t.DataHoraInicio, "DataHoraInicio").Not.Nullable();
            Map(t => t.DataHoraFim, "DataHoraFim").Not.Nullable();
            //chaves estrangeiras...
            References(f => f.Categoria).Column("IdCategoria"); //foreign key
            References(f => f.Usuario).Column("IdUsuario"); //foreign key
        }
    }
}