namespace Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public required string OrderStatus { get; set; }
    }
}
