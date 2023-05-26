namespace MLT.Rifa2.API.Models
{
    public class NumberPurchased
    {
        public int NumberPurchasedId { get; set; }
        public int NumberId { get; set; }
        public Number Number { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
