using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuktionsOpgave.Models
{
    public class Item
    {
        public Type Type { get; set; }
        public double Price { get; set;}
        public virtual Person Seller { get; set; }
        public virtual Person Buyer { get; set; }
        public int Amount { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Expire { get; set; }
        [Key]
        public int Id { get; set; }

       
    }
    public enum Type
    {
        Gold,
        Silver,
        Platinum,
        Palladium,
        Titanium
    }
}