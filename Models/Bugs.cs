using BugProject.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugProject.Models
{


    [Table("Bugs")]

    public class Bugs
    {


        [Required]

        [Key]

        public int Id { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

      
        public string? SystemName { get; set; }

        public string? UserName { get; set; }

        [StringLength(500)]
        public string? UserAgaint { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }
        public  string? ActiveState { get; set; }

        public string? Status { get; set; }

        //public ICollection<Bug_Atachment> Bug_Atachment { get; set; }

        //public List<Bug_Atachment> Bug_Atachmentes { get; set; }
        public Bug_Atachment Bug_Atachment{ get; set; }




    }
}
