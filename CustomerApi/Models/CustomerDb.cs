using CustomerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerApi.Modls
{
    public class CustomerDb:DbContext
    {
        public CustomerDb(DbContextOptions<CustomerDb> options) : base(options)
        {

        }

        public DbSet<CustomerModel> Customers { get; set; }

    }
}
