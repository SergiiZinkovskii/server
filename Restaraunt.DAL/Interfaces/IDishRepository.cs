﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Domain.Entity;

namespace Restaurant.DAL.Interfaces
{
    public interface IDishRepository : IBaseRepository<Dish>
    {
        Task<Dish?> Find(long id, CancellationToken cancellationToken);
    }
}
