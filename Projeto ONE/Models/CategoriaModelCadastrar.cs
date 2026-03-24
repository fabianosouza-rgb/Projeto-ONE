using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using FluentNHibernate;
using Projeto_ONE.Data.Persistence;
using Projeto_ONE.Valedators;
using Projeto_ONE.Data.Dto;
using System.ComponentModel.DataAnnotations;
using Projeto_ONE.Data.Entidade;

namespace Projeto_ONE.Models
{
    public class CategoriaModelCadastrar
    {

        [Required(ErrorMessage = "Por favor, informe o nome de uma categoria valida.")]
        [Display(Name = "Infome o nome de sua nova categoria:")]
        public string Nome { get; set; }


        public virtual int IdCategoria { get; set; }
        public List<TarefaDto> ListagemCategorias { get; set; }


        
   
    }
}