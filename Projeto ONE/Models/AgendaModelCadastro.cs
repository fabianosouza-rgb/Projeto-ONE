using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projeto_ONE.Data.Persistence;
using Projeto_ONE.Data.Dto;
using System.ComponentModel.DataAnnotations;
using Projeto_ONE.Data.Entidade;


namespace Projeto_ONE.Models
{
    public class AgendaModelCadastro
    {
        [Required(ErrorMessage="Por favor, informe o titulo da tarefa.")]
        [Display(Name = "Titulo da Tarefa:")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Por favor, informe o titulo da tarefa.")]
        [Display(Name = "Descrição:")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data/hora " +
                                  "de inicio da tarefa.")]
        [Display(Name = "Data/Hora de Inicio:")]
        public DateTime DataHoraInicio { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data/hora de termino da tarefa")]
        [Display(Name = "Data/Hora de Término:")]
        public DateTime DataHoraFim { get; set; }

        #region Campo de seleção de categorias
        
        [Required(ErrorMessage = " Por favor, selecione a categoria da tarefa.")]
        [Display(Name = "Selecione a Categoria:")]
        public int IdCategoria { get; set; }

        public List<SelectListItem> ListagemCategorias
        {
         get
            {
                List<SelectListItem> lista = new List<SelectListItem> ();
                CategoriaData d = new CategoriaData();
                foreach(Categoria c in d.FindAll())
                {
                    SelectListItem item = new SelectListItem();
                    item.Value = c.IdCategoria.ToString();
                    item.Text = c.Nome;
                    lista.Add(item);
                }
                return lista;
            }
        }
        #endregion
    }
    public class AgendaModelConsulta
    {
        [Required(ErrorMessage = "Por favor, informe a data de inicio.")]
        [Display(Name = "Data de Inicio")]
        public DateTime DataIni { get; set; }

        [Required(ErrorMessage = "Por favor, informe a data de termino.")]
        [Display(Name = "Data de Termino")]
        public DateTime DataFim { get; set; }
        //propriedade para exibir o resultado da pesquisa...
        public List<TarefaDto> ListagemTarefas { get; set; } //saida..

    }
}