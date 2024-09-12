using BugProject.Models;
using FinanceProject.Models;

namespace BugProject.Interfaces
{
    public interface IBugs


    {

        public Task<List<Bugs>> GetAllAsync();
        public Task<Bugs>CreateAsync(Bugs bugsmodel);


    }
}
