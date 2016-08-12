using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SPA_AngularJs.Models
{
    public class loginDetails
    {
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }

    public class registerDetails
    {
        [Key]
        public int id { get; set; }
         public string firstName { get; set; }
        public string lastName { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public string confirmPass { get; set; }
        public DateTime creat_dt { get; set; }

    }
}