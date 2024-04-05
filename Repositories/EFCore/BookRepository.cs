﻿using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class BookRepository : RepositoryBase<Book>,IBookRepository
    {
        public BookRepository(RepositoryContext context) : base(context)
        {
        }

        public void CreateABook(Book book) => Create(book);

        public void DeleteABook(Book book) => Delete(book);

        public async Task<Book> GetABookByIdAsync(int id, bool trackChanges) => await FindByCondition(b => b.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public async Task<IEnumerable<Book>> GetAllBooksAsync(bool trackChanges) => await FindAll(trackChanges).OrderBy(b => b.Id).ToListAsync();

        public void UpdateABook(Book book) => Update(book);
    }
}