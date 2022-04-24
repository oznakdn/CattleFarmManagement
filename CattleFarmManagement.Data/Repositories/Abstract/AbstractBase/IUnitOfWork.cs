using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Data.Repositories.Abstract.AbstractBase
{
    public interface IUnitOfWork:IAsyncDisposable
    {
        ICowRepository Cow { get; }
        IBullRepository Bull { get; }
        IMilkRecordRepository MilkRecord { get;}
        ILactationRepository Lactation { get; }
        ISeminationRepository Semination { get; }
        ICalvingRepository Calving { get; }
        IEmployeeRepository Employee { get; }
        IEmployeeContactRepository EmployeeContact { get; }






        Task<int> SaveChangesAsync();


    }
}
