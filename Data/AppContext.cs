using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesApp.Data
{
    internal class AppExContext : DbContext
    {
        public AppExContext() : base()
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=Alfredo;Database=ExpenseApp;Trusted_Connection=True;Trust Server Certificate=true");
        }


        public DbSet<Expense> Expenses { get; set; }
    }
}
