namespace MLT.Rifa2.API.Models
{
    public partial class Number
    {
        public int NumberId { get; set; }
        public int NumberPosition { get; set; }
        public int RaffleId { get; set; }
        public Raffle Raffle { get; set; }
        public bool IsBuyed { get; set; }
        public bool IsDeleted { get; set; }
    }
}
