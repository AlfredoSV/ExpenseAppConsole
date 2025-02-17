using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpensesApp.Data
{
    public class Expense
    {
        [Key]
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public double Amount { get; set; }

        public Expense(string? name, string? description, double amount)
        {
            Id = Guid.NewGuid();
            Name = name;
            Description = description;
            Amount = amount;
        }
    }
}