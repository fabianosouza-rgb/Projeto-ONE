using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Mapping;
using Projeto_ONE.Data.Entidade;

namespace Projeto_ONE.Data.Mapping
{
    public class UsuarioMap : ClassMap<Usuario>
    {
        public UsuarioMap()
            {

                Table("Usuario");
                //chave primaria
                Id(u => u.IdUsuario, "IdUsuario").GeneratedBy.Identity();
                // de mais atributos
                Map(u => u.Nome, "Nome").Length(50).Not.Nullable();
                Map(u => u.Login, "Login").Length(20).Not.Nullable();
                Map(u => u.Senha, "Senha").Length(40).Not.Nullable();
                Map(u => u.DataCadastro, "DataCadastro").Not.Nullable();

            HasMany(u => u.Tarefas).KeyColumn("IdUsuario").Inverse();
        }


    }

}