using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EGID.Test.API.Data.Entities
{
    /*
     * Name(string), ID(int), List<Order>, List<Person> (A broker has a name, an ID, 
     * a list of orders he made personally, and a list of Clients i.e person)
     وسيط
     */
    public class Broker
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
        public List<Person> Clients { get; set; }
    }
}
