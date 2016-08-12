using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;


namespace SPA_AngularJs.Models
{
    public class bookDBContext:DbContext  

    {
        public bookDBContext()
            : base("bookDBContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
        }

        public static  bookDBContext Create()
        {
            return new bookDBContext();
        }
        public DbSet<book> books { get; set; }
        public DbSet<registerDetails> userDetails { get; set; }

    }
}