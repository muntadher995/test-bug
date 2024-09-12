using BugProject.Interfaces;
using BugProject.Models;
using FinanceProject.Data;
using Microsoft.EntityFrameworkCore;

namespace BugProject.Repositry
{
    public class BugAtch : IBugAtch
    {


        private readonly AppDBContext _appDBContext;

        public BugAtch(AppDBContext appDBContext)
        {

            _appDBContext = appDBContext;
        }

        public async Task<List<Bug_Atachment>> GetAllAsync()
        {



            return await _appDBContext.bug_Atachments.ToListAsync();

        }


        public async Task<Bug_Atachment> CreateAsync(Bug_Atachment bugsmodel)
        {
            await _appDBContext.bug_Atachments.AddAsync(bugsmodel);

            await _appDBContext.SaveChangesAsync();

            return bugsmodel;
        }

      
    }
}
