
namespace Domain.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string Date { get; set; }
        public int Status { get; set; }
        public string Note { get; set; }
        public string Category { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }

        public Transaction(string title, decimal amount, string note)
        {
            Date = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            Id = DateTime.Now.Year * 100000000 + DateTime.Now.Month * 1000000 + DateTime.Now.Day * DateTime.Now.Hour;
            Title = title;
            Amount = amount;
            Note = note;
        }
    }
}
