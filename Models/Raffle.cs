namespace MLT.Rifa2.API.Models
{
    public partial class Raffle
    {
        public int RaffleId { get; set; }
        public string RaffleName { get; set; }
        public string RaffleDescription { get; set; }
        public string RaffleNumberPrice { get; set; }
        public int RaffleNumbersAmount { get; set; }
        public DateTime RaffleBeginDate { get; set; }
        public DateTime RaffleEndDate { get; set; }
        public IEnumerable<Reward> Rewards { get; set; }
        public IEnumerable<Number> Numbers { get; set; }
        public int OrganizationId { get; set; }
        public Organization Organization { get; set; }
        public DateTime RaffleCreationDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
