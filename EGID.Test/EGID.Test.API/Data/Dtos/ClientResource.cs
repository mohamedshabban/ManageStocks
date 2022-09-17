using EGID.Test.API.Data.Entities;
using System.Collections.Generic;

namespace EGID.Test.API.Data.Dtos
{
    public class ClientResource
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<Order> Orders { get; set; }
        public int BrokerId { get; set; }
        public Broker Broker { get; set; }
    }
}
