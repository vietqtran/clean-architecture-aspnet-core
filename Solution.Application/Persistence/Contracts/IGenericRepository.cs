﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Application.Persistence.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync (int id);
        Task<IReadOnlyList<T>> GetAll ( );
        Task<T> Add (T entity);
        Task<T> Update (T entity);
        Task<T> Delete (int id);
    }
}