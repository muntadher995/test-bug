using BugProject.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugProject.Models
{

    [Table("Bug_Atachment")]
    public class Bug_Atachment
    {
        [Key]
        [ForeignKey("Bugs")]
        public int Bugsid { get; set; }
        public Bugs Bugs { get; set; }

         //public List<string> ImagePaths { get; set; }
        public string ImagePaths { get; set; } // This property will store the paths as a single string
    }

}