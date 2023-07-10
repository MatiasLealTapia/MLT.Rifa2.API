using System.ComponentModel.DataAnnotations;

namespace MLT.Rifa2.API.Models
{
    public class FlowPayment
    {
        public int FlowPaymentId { get; set; }
        [Required]
        public string CommerceOrder { get; set; }
        [Required]
        public string Subject { get; set; }
        public string Currency { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        public int? PaymentMethod { get; set; }
        public string Optional { get; set; }
        public int? Timeout { get; set; }
        public string MerchantId { get; set; }
        public string PaymentCurrency { get; set; }
    }
}