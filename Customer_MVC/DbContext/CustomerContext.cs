using Customer_MVC.Models;
using Microsoft.EntityFrameworkCore;

namespace Customer_MVC 
{
    public class CustomerContext: DbContext 
    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options) { }
        public DbSet<Customer> Customers { get; set; }
    }
}
