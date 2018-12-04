using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataRelation.Models
{
    public class Image
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public int UserID { get; set; }
        public DateTime DatePosted { get; set; }
        public virtual User User { get; set; }
    }
}