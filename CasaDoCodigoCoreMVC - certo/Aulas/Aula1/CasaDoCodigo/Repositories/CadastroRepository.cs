using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public interface ICadastroRepository
    {
        Cadastro Update(int id, Cadastro cadastro);
    }
    public class CadastroRepository : BaseRepository<Cadastro>, ICadastroRepository
    {
        public CadastroRepository(ApplicationContext context) : base(context)
        {
        }

        public Cadastro Update(int id, Cadastro cadastro)
        {
            var cadastroDB = dbSet.Where(c => c.Id == id).SingleOrDefault();

            if(cadastroDB == null)
            {
                throw new ArgumentNullException("Cadastro nao encontrado");
            }

            cadastroDB.Update(cadastro);
            context.SaveChanges();
            return cadastroDB;
        }
    }
}
