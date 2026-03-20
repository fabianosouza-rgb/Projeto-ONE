using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Projeto_ONE.Data.Persistence;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Projeto_ONE.Valedators
{
    public class LoginDisponivel : ValidationAttribute
    {
        //implementar o método IsValid
        //retornar true se a validação está ok...
        //retornar false se ocorreu um erro de validação
        public override bool IsValid(object value)
        {
            string Login = (string) value;
            UsuarioData d = new UsuarioData();
            return ! d.HasLogin(Login);
        }
    }
}