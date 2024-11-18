namespace Domain.Entities;
using System;

public class Transaction
{
    public decimal Amount { get; set; }
    public string? Note { get; set; }
    public DateTime Date { get; set; }
}
