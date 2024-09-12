using BugProject.Models;
using BugProject.Repositry;

namespace BugProject.Interfaces
{
    public interface IBugAtch



    {

        public Task<List<Bug_Atachment>> GetAllAsync();
        public Task<Bug_Atachment> CreateAsync(Bug_Atachment bugsmodel);

    }
}
