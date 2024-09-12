
using BugProject.Dtos.Bugs;
using BugProject.Interfaces;
using BugProject.Models;
using FinanceProject.Data;
using FinanceProject.Models;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BugProject.Controllers
{
    [Route("api/Bugscontroller")]
    [ApiController]
    public class Bugscontroller : ControllerBase
    {
        private readonly UserManager<Users> _usermanager;
        private readonly IBugs _bugsRepo;
        private readonly AppDBContext _context;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public Bugscontroller(AppDBContext context, IBugs bugsRepo, IWebHostEnvironment hostingEnvironment, UserManager<Users> usermanager)
        {
            _usermanager= usermanager;
            _bugsRepo = bugsRepo;
            _context = context;
            _hostingEnvironment = hostingEnvironment;
        }



      

       /*

        [HttpGet("Get All")]

        public async Task<IActionResult> getBugsAsync()



        {


            var bg = _context.bugs.Include(b => b.Bug_Atachment).Where(b => b.Id == bug_id);

            //var user = _usermanager.Users.FirstOrDefault(u => u.UserName == logindto.Username.ToString());

            


            var bg =  _context.bugs.Include(b => b.Bug_Atachment).ToList();

            return Ok(bg);
        }*/


        [HttpGet("Get_Image")]
        public async Task<IActionResult> GetBug(int bugsid)
        {
            var bg = await _context.bug_Atachments.FindAsync(bugsid);

            if (bg == null)
            {
                return NotFound();
            }

            // Assuming ImagePaths is a comma-separated string or a list of strings
            var imagePaths = bg.ImagePaths.Split(',').ToList(); // Modify this based on your actual data structure
            var baseUrl = $"https://localhost:7179/images/";
            var imageUrls = new List<string>();

            foreach (var path in imagePaths)
            {
                var imagePath = Path.Combine(_hostingEnvironment.WebRootPath,"images", path.Trim());
                Console.WriteLine(imagePath); // Debugging: print the image path to check if it’s correct

                if (System.IO.File.Exists(imagePath))
                {
                    imageUrls.Add($"{baseUrl}{path.Trim()}");
                }
            }

            if (imageUrls.Count == 0)
            {
                return NotFound("No images found");
            }

            return Ok(imageUrls);
        }





      

        [HttpPost("Add Bug With Image")]

        public async Task<ActionResult<Bugs>> CreateBugsWithImage([FromForm] NewBugsDto newbugDto)
        {
            if (newbugDto.FilePaths == null || !newbugDto.FilePaths.Any())
            {
                return BadRequest("At least one image file is required.");
            }

            // var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
            var filePaths = new List<string>();

            foreach (var imageFile in newbugDto.FilePaths)
            {


                //var fileName = Path.GetFileName(imageFile.FileName);
                 var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
               // var filePath = Path.Combine(_hostingEnvironment.WebRootPath,"images",fileName);

                //var fileName = Path.GetFileName(imageFile.FileName);
                // var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", fileName);







                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }

    

                // Add the relative path to the filePaths list
               // filePaths.Add(Path.Combine("images", fileName));

                // filePaths.Add("/uploads/" + fileName);
                filePaths.Add(fileName);


            }
           


            var userAgent = Request.Headers["User-Agent"].ToString();

            //var user = _usermanager.Users.FirstOrDefault(u => u.UserName == logindto.Username.ToString());



            // Combine all paths into a single string, separated by a delimiter (e.g., ";")
            var combinedFilePaths = string.Join(",", filePaths);

            // Create the Employee and EmployeeImage models
            var bugsmdl = new Bugs
            {


                Title = newbugDto.Title,

                Description = newbugDto.Description,




                SystemName = newbugDto.SystemName,



               //UserName = user,

              //  UserName = user,


                 UserName = newbugDto.UserName,



                UserAgaint = userAgent,

                CreateAt = newbugDto.CreateAt,

                UpdateAt = newbugDto.UpdateAt,
                ActiveState = newbugDto.ActiveState,
                Status = newbugDto.Status,

                Bug_Atachment = new Bug_Atachment
                {

                   ImagePaths = combinedFilePaths,

                   

                }

            };

            // Add and save the employee and their image paths to the database
            _context.bugs.Add(bugsmdl);
            await _context.SaveChangesAsync();
            return Ok(bugsmdl);


        }



 










        [HttpGet("Get by Id")]
        public async Task<IActionResult> GetBugs(int id)
        {


            var bg = _context.bugs.Include(b => b.Bug_Atachment).FirstOrDefault(b => b.Id == id);
           

            //var bug = await _context.bugs.FindAsync(id);

            if (bg == null)
            {
                return NotFound();
            }



            return Ok(bg);
        }



        

         


        // PUT api/<Bugscontroller>/5
        [HttpPut("Update")]


        public async Task<ActionResult<Bugs>> BugUpdate(int id, [FromForm] NewBugsDto newbugDto)
        {


            var bg = _context.bugs.Include(b => b.Bug_Atachment).FirstOrDefault(b => b.Id == id);


            //var bug = await _context.bugs.FindAsync(id);

            if (bg == null)
            {
                return NotFound();
            }


            if (newbugDto.FilePaths == null || !newbugDto.FilePaths.Any())
            {
                return BadRequest("At least one image file is required.");
            }

            // var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
            var filePaths = new List<string>();

            foreach (var imageFile in newbugDto.FilePaths)
            {

                var fileName = Path.GetFileName(imageFile.FileName);
                // var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                var filePath = Path.Combine(_hostingEnvironment.WebRootPath, "images", fileName);






                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await imageFile.CopyToAsync(fileStream);
                }

                // filePaths.Add("/uploads/" + fileName);
                filePaths.Add(fileName);


            }



            var userAgent = Request.Headers["User-Agent"].ToString();


           

            //var user = _usermanager.Users.FirstOrDefault(u => u.UserName == logindto.Username.ToString());




            // Combine all paths into a single string, separated by a delimiter (e.g., ";")
            var combinedFilePaths = string.Join(",", filePaths);







            bg.Title = newbugDto.Title;

            bg.Description = newbugDto.Description;




           bg. SystemName = newbugDto.SystemName;



           

            bg.UserName = newbugDto.UserName;

            //  UserName = user,

            bg.UserName = newbugDto.UserName;




            bg.UserAgaint = userAgent;

           bg. CreateAt = newbugDto.CreateAt;

            bg.UpdateAt = newbugDto.UpdateAt;
            bg.ActiveState = newbugDto.ActiveState;
            bg.Status = newbugDto.Status;

            bg.Bug_Atachment.ImagePaths = combinedFilePaths;
        

            
            /*
            Bug_Atachment = new Bug_Atachment
                {
                    ImagePaths = combinedFilePaths,
                }
            */


            await _context.SaveChangesAsync( );
     
            

            return Ok(bg);



           // return Ok(bg);
        }

        // DELETE api/<Bugscontroller>/5
        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteBug(int id)
        {


            var bg = _context.bugs.FirstOrDefault(b => b.Id == id);


            //var bug = await _context.bugs.FindAsync(id);

            if (bg == null)
            {
                return NotFound();
            }
            _context.bugs.Remove(bg); 

            await _context.SaveChangesAsync();

            return Ok("item is removed");
        }





        

    }
}
