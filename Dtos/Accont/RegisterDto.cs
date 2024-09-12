using System.ComponentModel.DataAnnotations;

namespace FinanceProject.Dtos.Accont
{
    public class RegisterDto
    {
        [Required]
        public string? Username { get; set; }

        [Required] 
        public string? Password { get; set; }

        [Required]
        [EmailAddress]
         public string? Email { get; set; }

   
    }
}
