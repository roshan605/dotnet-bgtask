using Jubilant.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jubilant.API.Services
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();

        Task<Book> GetBookAsync(Guid id);
    }
}
