using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Projeto_ONE.Data.Persistence;
using Projeto_ONE.Models;
using Projeto_ONE.Data.Entidade;
using Projeto_ONE.Valedators;
using Projeto_ONE.Data.Dto;
using System.Web.Mvc;


namespace Projeto_ONE.Controllers
{
    [Authorize] //requer autorização de acesso /agenda/
    public class AgendaController : Controller
    {
       
        // GET: Agenda /index
        public ActionResult Index()
        {
           
            return View();
        }

        public ActionResult Cadastro()
        {
            return View(new AgendaModelCadastro());
        }

        // GET: /Agenda/Consulta
        public ActionResult Consulta()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastro(AgendaModelCadastro model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Tarefa t = new Tarefa()
                    {
                        Titulo = model.Titulo,
                        Descricao = model.Descricao,
                        DataHoraInicio = model.DataHoraInicio,
                        DataHoraFim = model.DataHoraFim,
                        Categoria = new CategoriaData().
                                    Find(model.IdCategoria),
                        Usuario = (Usuario)Session["usuariologado"]
                    };

                    TarefaData d = new TarefaData();
                    d.Insert(t);
                    ViewBag.Mensagem = "Tarefa " + t.Titulo + ", cadastrado com sucesso.";
                    ModelState.Clear();

                }
                catch(Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
            }

            return View("Cadastro", new AgendaModelCadastro());
        }

        [HttpPost]
        public ActionResult Consulta(AgendaModelConsulta model)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    TarefaData d = new TarefaData(); // persistencia...

                    Usuario u = (Usuario) Session["usuariologado"];
                    model.ListagemTarefas = d.FindAll
                        (model.DataIni, model.DataFim, u.IdUsuario);
                }
                catch(Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }
            }
            return View("Consulta", model);
        }

        [HttpGet]
        public ActionResult ExcluirTarefa(int id)
        {
            try
            {
                TarefaData d = new TarefaData();
                Tarefa t = d.Find(id); //buscando 1 tarefa pelo id..
                d.Delete(t); //excluindo a tarefa...
                ViewBag.Mensagem = "Tarefa excluida com sucesso.";
            }
            catch (Exception e)
            {
                ViewBag.Mensagem = e.Message;
            }
            return View("Consulta");
        }


    }
}