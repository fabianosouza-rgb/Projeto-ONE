using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Projeto_ONE.Data.Generics;
using Projeto_ONE.Data.Entidade;
using Projeto_ONE.Data.Dto;
using FluentNHibernate;
using NHibernate;
using Projeto_ONE.Data.Util;


namespace Projeto_ONE.Data.Persistence
{
    public class CategoriaData : GenericsData<Categoria>
    {
        public List<Categoria> FindAll()
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                return s.Query<Categoria>().OrderBy(c => c.Nome).ToList();
            }
        }

        public void Insert(CategoriaData c)
        {
            using (ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                ITransaction t = s.BeginTransaction();
                s.Save(c);
                t.Commit();
            }
        }
    }
}
