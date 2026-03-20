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
    [AllowAnonymous]
    public class HomeController : Controller
    {
        
        
       
        // GET: /Usuario/Login
        public ActionResult Login() 
        {
            return View(); //page_load
        }

        //post usuario atenticacao
        [HttpPost]
        public ActionResult AutenticarUsuario(HomeModelLogin model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    UsuarioData d = new UsuarioData(); //persistencia
                    Usuario u = d.Authenticate(model.Login, 
                        Cryptography.GetMD5Hash(model.Senha));

                    if (u != null)
                    {
                        //gerar um ticket de acesso para o usuário
                        FormsAuthentication.SetAuthCookie(u.Login, false);

                        Session.Add("usuariologado", u);

                        //redirecionar para a Agenda
                        return RedirectToAction("Index", "Agenda");
                    }
                    else // usuário encontrado
                    {
                        ViewBag.Mensagem = "Acesso Negado.";
                    }
                }

                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }

            }

            return View("Login");
        }


        // GET: /Usuario/Cadastro
        public ActionResult Cadastro(HomeModelCadastro model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Usuario u = new Usuario()
                    {
                        Nome = model.Nome,
                        Login = model.Login,
                        Senha = Cryptography.GetMD5Hash(model.Senha),
                        DataCadastro = DateTime.Now
                    };

                    UsuarioData d = new UsuarioData();
                    d.Insert(u);

                    ViewBag.Mensagem = "Usuario " + u.Nome + ", cadastro com sucesso.";

                    ModelState.Clear();

                }
                catch (Exception e)
                {
                    ViewBag.Mensagem = e.Message;
                }

            }

            return View("Cadastro");
        }

            [Authorize]
            public ActionResult Logout()
            {
            FormsAuthentication.SignOut();

            Session.Remove("usuariologado");
            Session.Abandon();

            return View("Login");
            }
        }




}



