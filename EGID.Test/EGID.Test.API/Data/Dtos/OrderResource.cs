using EGID.Test.API.Data.Entities;
using System;

namespace EGID.Test.API.Data.Dtos
{
    public class OrderResource
    {
        public int ID { get; set; }
        public int StockID { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Commission { get; set; }
        public int? BrokerId { get; set; }
        public int? PersonID { get; set; }
    }
}
