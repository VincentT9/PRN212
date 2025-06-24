using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessObjects;

namespace DataAccessLayer
{
    public class CustomerDAO
    {
        static List<Customer> customers = new List<Customer>();

        public void GenerateSampleDataset()
        {
            customers.Add(new Customer() { Id = 1, Name = "John Doe", Phone = "0912309103", Email = "johndoe@gmail.com" });
            customers.Add(new Customer() { Id = 2, Name = "Kim", Phone = "0912305433", Email = "kim@gmail.com" });
            customers.Add(new Customer() { Id = 3, Name = "Dong", Phone = "09123012303", Email = "dong@gmail.com" });
            customers.Add(new Customer() { Id = 4, Name = "Mahe", Phone = "0912302313", Email = "mahe@gmail.com" });
            customers.Add(new Customer() { Id = 5, Name = "Kobe", Phone = "0912345663", Email = "kobe@gmail.com" });
        }

        public List<Customer> GetCustomers()
        {
            return customers;
        }
    }
}
