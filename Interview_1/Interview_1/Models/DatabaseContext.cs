using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Interview_1.Models
{
    public class DatabaseContext
    {


        //public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        //{

        //}

        public List<User> Users { get; set; }
        public List<Transaction> Transactions { get; set; }
    }
}
