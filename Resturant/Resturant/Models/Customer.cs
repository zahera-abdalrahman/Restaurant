namespace Resturant.Models
{
    public class Customer : BaseEntity
    {
        public int CustomerId { get; set; }

        public string CustomerDesc { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPosition { get; set; }

        public string CustomerImage { get; set; }
    }
}
