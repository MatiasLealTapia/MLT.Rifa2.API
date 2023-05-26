﻿using MLT.Rifa2.API.Models;
using System.ComponentModel.DataAnnotations;

namespace MLT.Rifa2.API.DTOs
{
    public class RaffleDTO
    {
        public int RaffleId { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required.")]
        public string RaffleName { get; set; }
        public string RaffleDescription { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required.")]
        public int RaffleNumberPrice { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required.")]
        public int RaffleNumbersAmount { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required.")]
        public DateTime RaffleBeginDate { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required.")]
        public DateTime RaffleEndDate { get; set; }
        public IEnumerable<Reward> Rewards { get; set; }
        public IEnumerable<Number> Numbers { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "The field {0} is required.")]
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public DateTime RaffleCreationDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
