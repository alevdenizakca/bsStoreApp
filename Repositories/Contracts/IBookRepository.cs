using Entities.Models;
using Entities.RequestFeatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IBookRepository : IRepositoryBase<Book>
    {
        Task<PagedList<Book>> GetAllBooksAsync(BookParameters bookParameters,bool trackChanges);
        Task<Book> GetABookByIdAsync(int id,bool trackChanges);
        void CreateABook(Book book);
        void UpdateABook(Book book);
        void DeleteABook(Book book);
    }
}
