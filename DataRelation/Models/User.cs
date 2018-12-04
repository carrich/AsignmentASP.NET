using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataRelation.Models
{
    public class User
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<Image> Images { get; set; }
    }
}