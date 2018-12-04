using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataRelation.Models
{
    public class Item
    {
        public int Id { get; set; }
        public int MaterialId { get; set; }
        public int SizeId { get; set; }
        public string PathImage { get; set; }
        public int Quantity { get; set; }
        public Material Material1;
        public Size Size1;
        
        public virtual Material Material { get; set; }
        public virtual Size Size { get; set; }
        public Item()
        {

        }
        public Item(int Id,string PathImage, int Quantity, Material Material, Size Size )
        {
            this.Id = Id;
            this.PathImage = PathImage;
            this.Material1 = Material;
            this.Size1 = Size;
            this.Quantity = Quantity;
            
        }
    }
}