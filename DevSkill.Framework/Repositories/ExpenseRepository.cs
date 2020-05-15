﻿using DevSkill.Data;
using DevSkill.Framework.Context;
using DevSkill.Framework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Framework.Repositories
{
    public class ExpenseRepository : Repository<Entities.Expense, int, FrameworkContext>, IExpenseRepository
    {
        public ExpenseRepository(FrameworkContext dbContext)
            : base(dbContext)
        {

        }
    }
}
