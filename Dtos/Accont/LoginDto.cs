using System.ComponentModel.DataAnnotations;

namespace FinanceProject.Dtos.Accont
{


    public class LoginDto
    {
        [Required]
        public string Username { get; set; }

        [Required] 
        public string Password { get;set; }



    }
}
