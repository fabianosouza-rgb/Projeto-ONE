using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Projeto_ONE.Data.Util;
using Projeto_ONE.Data.Entidade;
using Projeto_ONE.Data.Persistence;
using Projeto_ONE.Models;


namespace Projeto_ONE.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult CategoriaCadastro()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult Consulta(AgendaModelConsulta model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            TarefaData d = new TarefaData(); // persistencia...

        //            Usuario u = (Usuario)Session["usuariologado"];
        //            model.ListagemTarefas = d.FindAll
        //                (model.DataIni, model.DataFim, u.IdUsuario);
        //        }
        //        catch (Exception e)
        //        {
        //            ViewBag.Mensagem = e.Message;
        //        }
        //    }
        //    return View("Consulta", model);
        //}

    }
}
