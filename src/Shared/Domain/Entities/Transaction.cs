using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    internal class Transaction
    {
        // Napisz klasę transaction, która będzie miała następujące właściwości:
        // - Id typu int które będzie zapisane w formacie data + numer od 0 do 9999
        // - Amount typu decimal
        // - Date typu DateTime
        // - tytuł transakcji i opis
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
            Id = DateTime.Now.Year * 100000000 + DateTime.Now.Month * 1000000 + DateTime.Now.Day * DateTime.Now.Hour;
            Amount = amount;
            Date = date;
            Description = description;
            Category = category;
            Title = title;
            Type = type;
        }
    }
}
