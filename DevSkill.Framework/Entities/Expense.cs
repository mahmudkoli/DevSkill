using MKZeroDev.Data;
using DevSkill.Framework.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevSkill.Framework.Entities
{
    public class Expense : IEntity<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public ExpenseType ExpenseType { get; set; }
        public DateTime ExpenseDate { get; set; }
    }
}
