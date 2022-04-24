using CattleFarmManagement.Data.Repositories.Abstract;
using CattleFarmManagement.Data.Repositories.Concrete.ConcreteBase;
using CattleFarmManagement.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Data.Repositories.Concrete
{
    public class CowRepository:EfRepositoryBase<Cow>,ICowRepository
    {
        private readonly DbContext _context;
        public CowRepository(DbContext context):base(context)
        {
            _context = context;
        }

        public int Count()
        {
            return _context.Set<Cow>().Count();
        }

        public List<Cow>GetAll()
        {
            return _context.Set<Cow>().Where(x => x.IsActive).Include(x => x.CowPictures).ToList();

        }
    }
}
