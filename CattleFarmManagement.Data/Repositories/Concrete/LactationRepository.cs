﻿using CattleFarmManagement.Data.Repositories.Abstract;
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
    public class LactationRepository:EfRepositoryBase<Lactation>,ILactationRepository
    {
        public LactationRepository(DbContext context):base(context)
        {

        }
    }
}
