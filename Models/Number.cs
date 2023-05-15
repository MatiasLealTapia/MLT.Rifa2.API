namespace MLT.Rifa2.API.Models
{
    public partial class Number
    {
        public Guid NumberId { get; set; }
        public int NumberPosition { get; set; }
        public int NumberPrice { get; set; }
        public int UserId { get; set; }
        public int RaffleId { get; set; }
        public Raffle Raffle { get; set; }
        public DateTime PurchaseDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
