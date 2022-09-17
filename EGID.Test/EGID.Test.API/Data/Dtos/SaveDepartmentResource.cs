namespace EGID.Test.API.Data.Dtos
{

    public class SaveOrderResource
    {
        public int StockID { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Commission { get; set; }
        public int? BrokerId { get; set; }
        public int? PersonID { get; set; }
    }
}
