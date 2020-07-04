﻿using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;
using Domain.Orders;
using Microsoft.EntityFrameworkCore;
using Persistence.Shared;

namespace Persistence.Orders
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public OrderRepository(IDatabaseContext databaseContext) : base(databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IList<Order> GetByUserId(string userId)
        {
            var orders = _databaseContext.Orders
                .Include(o => o.Customer)
                .Where(c => c.Customer.Email == userId)
                .ToList();
            return orders;
        }
    }
}