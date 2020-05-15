using DevSkill.Data;
using DevSkill.Framework.Context;
using DevSkill.Framework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Framework.UnitOfWork
{
    public class ExpenseUnitOfWork : DevSkill.Data.UnitOfWork, IExpenseUnitOfWork
    {
        public IExpenseRepository ExpenseRepository { get; set; }

        public ExpenseUnitOfWork(FrameworkContext dbContext,
            IExpenseRepository expenseRepository) : base(dbContext)
        {
            ExpenseRepository = expenseRepository;
        }
    }
}
