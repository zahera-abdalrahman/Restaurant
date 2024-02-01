using Microsoft.AspNetCore.Http;
using Resturant.Models;

namespace Resturant.ViewModels
{
    public class CustomerModel:BaseEntity
    {
        public int CustomerId { get; set; }

        public string CustomerDesc { get; set; }

        public string CustomerName { get; set; }

        public string CustomerPosition { get; set; }
        public string CustomerImage { get; set; }
        public IFormFile File { get; set; }
    }
}
