namespace MLT.Rifa2.API.Models
{
    public partial class Winner
    {
        public int WinnerId { get; set; }
        public int? RewardId { get; set; }
        public Reward Reward { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public int? NumberId { get; set; }
        public Number Number { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
