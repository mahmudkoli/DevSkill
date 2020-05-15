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
    public interface IExpenseUnitOfWork : IUnitOfWork
    {
        IExpenseRepository ExpenseRepository { get; set; }
    }
}
