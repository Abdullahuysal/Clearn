using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Clearn.Models.Managers
{
    public class DatabaseContext:DbContext
    {
        public DbSet<UserData>Users { get; set; }
        public DbSet<BeginnerWords> Begginner { get; set; }

        public DbSet<IntermediateWords> Intermediate { get; set; }
     
        public DbSet<AdvancedWords> Advanced { get; set;}
    }




}