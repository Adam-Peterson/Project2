using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project2.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public int userID { get; set; }
        public string userEmail { get; set; }
        public string userPassword { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
    }
}

