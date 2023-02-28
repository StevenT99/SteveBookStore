using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SteveBookStore.Models
{
    public interface IBookStoreRepository
    {
        IQueryable<Books> Books { get; }
    }
}
