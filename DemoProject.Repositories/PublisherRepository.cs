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
    public class PublisherRepository : Repository<Publisher>, IPublisherRepository
    {
        public PublisherRepository(MyDBContext dbContext) : base(dbContext)
        {
        }
    }
}
