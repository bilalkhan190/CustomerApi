using System.ComponentModel.DataAnnotations;

namespace CustomerApi.Models
{
    public class CustomerModel
    {
        [Key]
        public int CustomerId { get; set; }
        public string Customer { get; set; }
        public string Address { get; set; }
        public string Contact{ get; set; }
        public string Email { get; set; }
    }
}
