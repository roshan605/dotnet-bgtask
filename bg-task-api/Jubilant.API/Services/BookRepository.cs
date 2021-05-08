﻿using Jubilant.API.Contexts;
using Jubilant.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Jubilant.API.Services
{
    public class BookRepository : IBookRepository,IDisposable
    {
        private BookContext _context;

        public BookRepository(BookContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }



        public async Task<Book> GetBookAsync(Guid id)
        {
            return await _context.Books.Include(b => b.Author).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _context.Books.Include(b=>b.Author).ToListAsync();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if(_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
