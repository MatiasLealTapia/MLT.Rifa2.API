namespace MLT.Rifa2.API.Models
{
    public partial class Reward
    {
        public int RewardId { get; set; }
        public string RewardName { get; set; }
        public string RewardDescription { get; set; }
        public string RewardImgUrl { get; set; }
        public int RaffleId { get; set; }
        public Raffle Raffle { get; set; }
        public bool IsDeleted { get; set; }
    }
}
