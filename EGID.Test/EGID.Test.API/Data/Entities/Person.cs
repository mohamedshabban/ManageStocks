using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EGID.Test.API.Data.Entities
{
    /*
     Name(string), ID(int), List<Order> ( A person has a name ID and a List of Order he made)
     */
    public class Person
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
        [ForeignKey("Broker")]
        public int BrokerId { get; set; }
        public Broker Broker { get; set; }

    }
}
