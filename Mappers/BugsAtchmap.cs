using BugProject.Dtos.Bugs;
using BugProject.Dtos.Bugs.BugsAtachDto;
using BugProject.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugProject.Mappers
{
    public static class BugsAtchmap
    {


        public static BugsAtachDto TobgAtDto(this Bug_Atachment bugsmodel)
        {
            return new BugsAtachDto


            {
                Id = bugsmodel.Bugsid,

                Bugsid = bugsmodel.Bugsid,

               // ImageName=bugsmodel.ImageName,

                //ImagePaths =bugsmodel.ImagePaths,
            }; 



       }


        public static Bug_Atachment ToBgAttchfromDto(this BugsAtachDto bugsAtachDto)

        {
            return new Bug_Atachment

            {

                Bugsid = bugsAtachDto.Bugsid,

                //ImageName = bugsAtachDto.ImageName,

                //ImagePaths = bugsAtachDto.ImagePaths,


            };



        }






    }


}




