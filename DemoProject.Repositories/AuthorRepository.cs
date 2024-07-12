using DemoProject.Data;
using DemoProject.IRepositories;
using DemoProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoProject.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(MyDBContext dbContext) : base(dbContext)
        {
        }
    }
}
