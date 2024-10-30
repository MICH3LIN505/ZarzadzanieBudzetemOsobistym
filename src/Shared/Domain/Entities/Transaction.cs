using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }

        public Transaction(decimal amount, DateTime date, string description, string category, string title, string type)
        {
            Amount = amount;
            Date = date;
            Description = description;
            Category = category;
            Title = title;
            Type = type;
        }
    }
}
