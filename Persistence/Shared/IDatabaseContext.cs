using System;
using System.Collections.Generic;
using System.Text;
using Domain.Category;
using Domain.Common;
using Domain.ShopItem;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Shared
{
    internal interface IDatabaseContext
    {
        DbSet<ShopItem> ShopItems { get; set; }

        DbSet<Category> Categories { get; set; }

        DbSet<T> Set<T>() where T : class, IEntity;

        void Save();
    }
}
