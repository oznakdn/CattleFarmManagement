using CattleFarmManagement.Data.Context;
using CattleFarmManagement.Data.Repositories.Abstract;
using CattleFarmManagement.Data.Repositories.Abstract.AbstractBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Data.Repositories.Concrete.ConcreteBase
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }


        private readonly CowRepository cowRepository;
        private readonly BullRepository bullRepository;
        private readonly MilkRecordRepository milkRecordRepository;
        private readonly LactationRepository lactationRepository;
        private readonly SeminationRepository seminationRepository;
        private readonly CalvingRepository calvingRepository;
        private readonly EmployeeRepository employeeRepository;
        private readonly EmployeeContactRepository employeeContactRepository;


        public ICowRepository Cow => cowRepository ?? new CowRepository(_context);

        public IBullRepository Bull => bullRepository ?? new BullRepository(_context);

        public IMilkRecordRepository MilkRecord => milkRecordRepository ?? new MilkRecordRepository(_context);

        public ILactationRepository Lactation => lactationRepository ?? new LactationRepository(_context);

        public ISeminationRepository Semination => seminationRepository ?? new SeminationRepository(_context);

        public ICalvingRepository Calving => calvingRepository ?? new CalvingRepository(_context);

        public IEmployeeRepository Employee => employeeRepository ?? new EmployeeRepository(_context);

        public IEmployeeContactRepository EmployeeContact => employeeContactRepository ?? new EmployeeContactRepository(_context);

        public async ValueTask DisposeAsync()
        {
            await _context.DisposeAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
