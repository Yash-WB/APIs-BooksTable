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
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(MyDBContext dbContext) : base(dbContext)
        {
        }
    }
}
