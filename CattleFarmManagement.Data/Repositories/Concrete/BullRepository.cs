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
    public class BullRepository:EfRepositoryBase<Bull>, IBullRepository
    {
        private readonly DbContext _context;
        public BullRepository(DbContext context):base(context)
        {
            _context = context;

        }

        public int Count()
        {
            return _context.Set<Bull>().Count();
        }
    }
}
