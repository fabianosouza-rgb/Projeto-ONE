using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Projeto_ONE.Data.Util;
using Projeto_ONE.Data.Entidade;
using NHibernate;
using Projeto_ONE.Data.Generics;     
using NHibernate.Linq;




namespace Projeto_ONE.Data.Persistence
{
    public class UsuarioData : GenericsData<Usuario>
    {
        public bool HasLogin(string Login)
        {

            using (var s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                var query = from u in s.Query<Usuario>()
                            where u.Login.Equals(Login)
                            select u;
                //retornar a quantidade obtida...
                return query.Count() > 0;

            }
        }

        public Usuario Authenticate(string Login, string Senha)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                // SQL -> Select * from Usuario where Login=? and Senha=?
                var query = from u in s.Query<Usuario>()
                            where u.Login.Equals(Login)
                                && u.Senha.Equals(Senha)
                            select u;

                // retronar o primeiro registro encontrado
                return query.FirstOrDefault();
            }
        }
        public void Insert(UsuarioData u)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                ITransaction t = s.BeginTransaction();
                s.Save(u);
                t.Commit();
            }
        }

        public void Delete(Usuario u)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                ITransaction t = s.BeginTransaction();
                s.Delete(u);
                t.Commit();
            }
        }

        public void Update(Usuario u)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                ITransaction t = s.BeginTransaction();
                s.Update(u);
                t.Commit();
            }
        }

        public Usuario Find(int IdUsuario)
        {
            using(ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                return (Usuario)s.Get(typeof(Usuario), IdUsuario);
            }
        }

        public ICollection<Usuario> FindAll()
        {
            using(ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {                
                var query = from u in s.Query<Usuario>()
                            select u;          
                // retornar os dados
                return query.ToList();
            }
        }

        
        //autenticar os métodos para verificar o login e autenticar usuario
        
    
    }

   

}