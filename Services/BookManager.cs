using AutoMapper;
using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Repositories.Contracts;
using Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class BookManager : IBookService
    {
        private readonly IRepositoryManager _manager;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        public BookManager(IRepositoryManager manager, ILoggerService logger, IMapper mapper)
        {
            _manager = manager;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<BookDto> CreateABookAsync(BookDtoForInsertion bookDto)
        {
            var entity =_mapper.Map<Book>(bookDto);
            _manager.Book.CreateABook(entity);
            await _manager.SaveAsync();
            return _mapper.Map<BookDto>(entity);
        }

        public async Task DeleteABookAsync(int id, bool trackChanges)
        {
            var book = await GetABookByIdAndCheckExists(id, trackChanges);
            _manager.Book.DeleteABook(book);
            await _manager.SaveAsync();
        }

        public async Task<BookDto> GetABookByIdAsync(int id, bool trackChanges)
        {
            var book = await GetABookByIdAndCheckExists(id, trackChanges);
            return _mapper.Map<BookDto>(book);
        }

        public async Task<IEnumerable<BookDto>> GetAllBooksAsync(bool trackChanges)
        {
            var books = await _manager.Book.GetAllBooksAsync(trackChanges);
            return _mapper.Map<IEnumerable<BookDto>>(books);
        }

        public async Task<(BookDtoForUpdate bookDtoForUpdate, Book book)> GetABookForPatchAsync(int id, bool trackChanges)
        {
            var book = await GetABookByIdAndCheckExists(id,trackChanges); 
            var bookDtoForUpdate= _mapper.Map<BookDtoForUpdate>(book);
            return (bookDtoForUpdate, book);
        }

        public async Task UpdateABookAsync(int id, BookDtoForUpdate bookDto, bool trackChanges)
        {
            var bookToUpdate = await GetABookByIdAndCheckExists(id,trackChanges);
            
            if (bookDto == null)
                throw new ArgumentNullException(nameof(bookDto));

            //Mapping
            bookToUpdate = _mapper.Map<Book>(bookDto);

            _manager.Book.UpdateABook(bookToUpdate);
            await _manager.SaveAsync();
        }

        public async Task SaveChangesForPatchAsync(BookDtoForUpdate bookDto, Book book)
        {
            _mapper.Map(bookDto, book);
            await _manager.SaveAsync();
        }

        private async Task<Book> GetABookByIdAndCheckExists(int id, bool trackChanges)
        {
            var entity = await _manager.Book.GetABookByIdAsync(id, trackChanges);

            if(entity == null)
                throw new BookNotFoundException(id);

            return entity;
        }
    }
}
