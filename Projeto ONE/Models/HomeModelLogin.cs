using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //mapeamento
using Projeto_ONE.Valedators;

namespace Projeto_ONE.Models
{
    public class HomeModelLogin

    {
        [Required(ErrorMessage = "Por favor, informe o login de acesso.")]
        [Display(Name = "Informe seu Login:")]
        public string Login { get; set; }
        
        [Required(ErrorMessage = "Por favor, informe a senha de acesso.")]
        [Display(Name = "Informe sua Senha:")]
        public string Senha { get; set; }
    }

    public class HomeModelCadastro
    {
        [Required(ErrorMessage = "Por favor, informe o nome do usuario.")]
        [RegularExpression("^[A-Za-zÀ-Üà-ü\\s]{6,50}$",
            ErrorMessage = "Informe seu Nome:")]
        [Display(Name ="Informe seu Nome:")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe o login do usuario.")]
        [RegularExpression("^[a-z0-9]{6,20}$",
            ErrorMessage = "Erro. Login inválido.")]
       
        [LoginDisponivel(ErrorMessage = "Erro. Este login encontra-se indisponível. Tente outro")]
        [Display(Name = "Login de Acesso:")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Por favor, informe a senha do usuario.")]
        [RegularExpression("^[A-Za-z0-9@]{6,20}$",
            ErrorMessage = "Erro. Senha inválida.")] 
        [Display(Name = "Senha de Acesso:")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Por favor, confirme a senha do usuario.")]
        [Compare("Senha", ErrorMessage = "Erro. Confirme sua senha corretamente.")]
        [Display(Name = "Confirme sua senha:")]
        public string SenhaConfirm { get; set; }

    }
} 