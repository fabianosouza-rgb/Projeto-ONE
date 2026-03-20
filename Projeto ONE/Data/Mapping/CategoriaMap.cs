using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using FluentNHibernate.Mapping;
using Projeto_ONE.Data.Entidade;

namespace Projeto_ONE.Data.Mapping
{
    public class CategoriaMap : ClassMap<Categoria>
    {
        // GET: CategoriaMap
        public CategoriaMap ()
        {
            Table("Categoria");

            Id(c => c.IdCategoria, "IdCategoria").GeneratedBy.Identity();
            Map(c => c.Nome, "Nome").Length(50).Not.Nullable();

            HasMany(c => c.Tarefas).KeyColumn("IdCategoria").Inverse();
        }
    }
}