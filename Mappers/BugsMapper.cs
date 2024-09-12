using BugProject.Dtos.Bugs;
using BugProject.Dtos.Bugs.BugsAtachDto;
using BugProject.Models;
using FinanceProject.Models;
using System.Collections.Generic;

namespace BugProject.Mappers
{

 // static  string userAgent = HttpContext.Request.Headers["User-Agent"];

    public static class BugsMapper


    {

    
        public static BugsDto TobugsDto(this Bugs bugsmodel)
        {
              
            return new BugsDto
            {
                Id = bugsmodel.Id,
                Title = bugsmodel.Title,
                Description = bugsmodel.Description,
                SystemName = bugsmodel.SystemName,
               UserAgaint =bugsmodel.UserAgaint,
               // UserAgaint = HttpContext.Request.Headers["User-Agent"],
                UserName = bugsmodel.UserName,
                CreateAt = bugsmodel.CreateAt,
                UpdateAt = bugsmodel.UpdateAt,
                ActiveState = bugsmodel.ActiveState,
                Status = bugsmodel.Status,

              //  bug_Atachments = bugsmodel.bug_Atachments.Select(c => c.TobgAtDto()).ToList()

              // List <BugsAtachDto> bug_Atachments = bugsmodel.bug_Atachments.Select(c => c.TobgAtDto()).ToList()


            };
        }

        public static Bugs ToBugsFromDto(this CreateBugsdto crtBugsDto)

        {
            return new Bugs

            {

                Title = crtBugsDto.Title,
                Description = crtBugsDto.Description,
                SystemName = crtBugsDto.SystemName,
               // UserAgaint = "userAgent",  //crtBugsDto.UserAgaint,
                UserName = crtBugsDto.UserName,
                CreateAt = crtBugsDto.CreateAt,
                UpdateAt = crtBugsDto.UpdateAt,
                ActiveState = crtBugsDto.ActiveState,
                Status = crtBugsDto.Status,



            };




        }




    }
}
