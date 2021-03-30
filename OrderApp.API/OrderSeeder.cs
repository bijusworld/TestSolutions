using OrderApp.Domain;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using OrderApp.Data;


namespace OrderApp.API
{
    class OrderSeeder
    {
        private readonly OrderContext _ctx;
        private readonly IWebHostEnvironment _hosting;

        public OrderSeeder(OrderContext ctx, IWebHostEnvironment hosting)
        {
            _ctx = ctx;
            _hosting = hosting;
        }

        public void Seed()
        {
            _ctx.Database.EnsureCreated();

            if (!_ctx.Products.Any())
            {
                // Need to create the Sample Data
                var file = Path.Combine(_hosting.ContentRootPath, "art.json");
                var json = File.ReadAllText(file);
                var products = JsonSerializer.Deserialize<IEnumerable<Product>>(json);
                _ctx.Products.AddRange(products);

                //var order = _ctx.Orders.Where(o => o.Id == 1).FirstOrDefault();
                //if (order != null)
                //{
                //    order.Items = new List<OrderItem>()
                //    {
                //        new OrderItem()
                //        {
                //            Product = products.First(),
                //            Quantity = 5,
                //            UnitPrice = products.First().Price
                //        }
                //    };
                //}
                var order = new Order()
                {
                    OrderDate = DateTime.Now,
                    OrderNumber = "10000",
                    Items = new List<OrderItem>()
                    {
                        new OrderItem
                        {
                            Product = products.First(),
                            Quantity = 5,
                            UnitPrice = products.First().Price
                        }
                    }
                };
                _ctx.Orders.Add(order);
                _ctx.SaveChanges();
            }
        }
    }
}
