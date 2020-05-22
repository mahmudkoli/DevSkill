using MKZeroDev.Data;
using DevSkill.Framework.Context;
using DevSkill.Framework.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Framework.Repositories
{
    public interface IExpenseRepository : IRepository<Entities.Expense, int, FrameworkContext>
    {
        
    }
}
