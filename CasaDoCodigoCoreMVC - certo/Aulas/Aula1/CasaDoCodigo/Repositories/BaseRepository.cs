using CasaDoCodigo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CasaDoCodigo.Repositories
{
    public class BaseRepository<T> where T : BaseModel
    { 
        protected readonly ApplicationContext context;
        protected readonly Microsoft.EntityFrameworkCore.DbSet<T> dbSet;

        public BaseRepository(ApplicationContext context)
        {
            this.context = context;
            this.dbSet = context.Set<T> ();
        }
    }
}
