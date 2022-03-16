﻿using Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Query
{
    public interface IQuery<TEntity> where TEntity : class, IEntity, new()
    {
        Task<List<TEntity>> GetSetAsync();

    }
}
