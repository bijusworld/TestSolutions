using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OrderApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderApp.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly OrderContext _ctx;
        private readonly ILogger<OrderRepository> _logger;

        public OrderRepository(OrderContext ctx, ILogger<OrderRepository> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            if (includeItems)
            {
                return _ctx.Orders
                  .Include(o => o.Items)
                  .ThenInclude(i => i.Product)
                  .ToList();
            }
            else
            {
                return _ctx.Orders
                  .ToList();
            }
        }

        public Order GetOrderById(int id)
        {
            return _ctx.Orders
              .Include(o => o.Items)
              .ThenInclude(i => i.Product)
              .Where(o => o.Id == id)
              .FirstOrDefault();
        }

        public bool SaveAll()
        {
            return _ctx.SaveChanges() > 0;
        }

        public void AddEntity(object entity)
        {
            _ctx.Add(entity);
        }
    }
}
