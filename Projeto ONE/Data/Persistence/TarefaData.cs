using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_ONE.Data.Generics;
using Projeto_ONE.Data.Entidade;
using Projeto_ONE.Data.Dto;
using NHibernate.Linq;
using NHibernate;
using Projeto_ONE.Data.Util;

namespace Projeto_ONE.Data.Persistence
{
    public class TarefaData : GenericsData<Tarefa>
    {
        public List<TarefaDto> FindAll(DateTime DataIni, DateTime DataFim, 
                                                int IdUsuario)
        {
            using(ISession s = HibernateUtil.GetSessionFactory().OpenSession())
            {
                var query = from t in s.Query<Tarefa>()
                            where t.DataHoraInicio >= DataIni &&
                                  t.DataHoraInicio <= DataFim &&
                                  t.Usuario.IdUsuario == IdUsuario
                            orderby t.DataHoraInicio ascending
                            select t;

                List<TarefaDto> lista = new List<TarefaDto>();

                foreach(var t in query.ToList())
                {
                    lista.Add(
                        new TarefaDto()
                        {
                            Codigo = t.IdTarefa,
                            Titulo = t.Titulo,
                            Descricao = t.Descricao,
                            DataHoraInicio = t.DataHoraInicio,
                            DataHoraFim = t.DataHoraFim,
                            Categoria = t.Categoria.Nome,
                            Usuario = t.Usuario.Nome
                        }
                    );
                }
                return lista;
            }
        }
    }
}