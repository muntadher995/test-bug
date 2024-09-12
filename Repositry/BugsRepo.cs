using BugProject.Interfaces;
using BugProject.Models;
using FinanceProject.Data;
using FinanceProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BugProject.Repositry
{


    public class BugsRepo : IBugs

    {

        private readonly AppDBContext _appDBContext;

        public BugsRepo(AppDBContext appDBContext)
        {

            _appDBContext = appDBContext;
        }



        public async Task<List<Bugs>> GetAllAsync()
        {



            return await _appDBContext.bugs.ToListAsync();

        }



        public async Task<Bugs> CreateAsync(Bugs bugsmodel)
        {
            await _appDBContext.bugs.AddAsync(bugsmodel);

            await _appDBContext.SaveChangesAsync();

            return bugsmodel;
        }

    }
}
