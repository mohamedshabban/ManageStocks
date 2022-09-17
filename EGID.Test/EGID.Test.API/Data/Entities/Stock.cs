using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EGID.Test.API.Data.Entities
{
    /*
     Name(string), ID(int), Price
     */
    public class Stock
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public List<Order> orders { get; set; }
    }
}
