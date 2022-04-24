using CattleFarmManagement.Data.Repositories.Abstract.AbstractBase;
using CattleFarmManagement.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CattleFarmManagement.Data.Repositories.Abstract
{
    public interface ICowRepository:IRepository<Cow>
    {
        int Count();
        List<Cow> GetAll();

    }
}
