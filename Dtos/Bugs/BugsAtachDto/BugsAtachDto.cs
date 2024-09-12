using System.ComponentModel.DataAnnotations.Schema;

namespace BugProject.Dtos.Bugs.BugsAtachDto
{
    public class BugsAtachDto
    {

        public int Id { get; set; }

        public int Bugsid { get; set; }

        //public string ImageName { get; set; }
        public string ImagePaths { get; set; }


    }
}
