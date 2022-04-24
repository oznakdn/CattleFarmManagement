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
    public class MilkRecordRepository:EfRepositoryBase<MilkRecord>,IMilkRecordRepository
    {
        private readonly DbContext _context;
        public MilkRecordRepository(DbContext context):base(context)
        {
            _context = context;
        }

       
        public double Average(int Id)
        {
            var averege = _context.Set<MilkRecord>().Where(x => x.CowId == Id).Average(x => x.Quantity);
            return averege;
        }

        public async Task<MilkRecord> Find(int Id)
        {
            return await _context.Set<MilkRecord>().FindAsync(Id);
          
        }
    }
}
