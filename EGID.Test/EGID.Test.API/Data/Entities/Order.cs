using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EGID.Test.API.Data.Entities
{
    /*
     StockID(int), Price(double), Quantity , 
    commission( The order has StockId,
    Price per unit, the quantity of the stock, and company commission عمولة الشركة .)
     */
    public class Order
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Stock")]
        public int StockID { get; set; }
        public Stock Stock { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Commission { get; set; }
        [ForeignKey("Broker")]
        public int? BrokerId { get; set; }
        public Broker Broker { get; set; }
        [ForeignKey("Person")]
        public int? PersonID { get; set; }
        public Person Person { get; set; }
    }
}
