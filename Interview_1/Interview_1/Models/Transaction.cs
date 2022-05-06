using System;

namespace Interview_1.Models
{
    public class Transaction
    {
        public string Id { get; set; }
        public string UserId { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal AmountBilled { get; set; }
        public DateTime? DatePaid { get; set; }
    }
}
