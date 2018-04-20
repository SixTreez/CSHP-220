using System.ComponentModel.DataAnnotations;

namespace CardMaker.Models
{
    public class CardBusiness
    {
        [Required(ErrorMessage = "Please enter your name")]
        public string Sender { get; set; }
        [Required(ErrorMessage = "Please enter a recipient")]
        public string Recipient { get; set; }
        [Required(ErrorMessage = "Please enter a message")]
        public string Message { get; set; }
    }

}