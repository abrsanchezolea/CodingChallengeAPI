using CodingChallengeAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace CodingChallengeAPI
{
    public class ApiContext : DbContext
    {
        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options)
        {
        }

        public DbSet<Operation> Operations { get; set; }

        public void SaveOperation(string typeOperation, double value)
        {
            var Operation = new Operation() { TypeOperation = typeOperation,  Value = value };
            Operations.Add(Operation);
        }
    }
}
