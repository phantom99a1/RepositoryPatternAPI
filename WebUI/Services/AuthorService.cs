using AutoMapper;
using WebUI.Domain.Entities;
using WebUI.Repositories;

namespace WebUI.Services
{
    public interface IAuthorService
    {

    }
    public class AuthorService(IBaseRepository<Author> authorRepository, IMapper mapper) : IAuthorService
    {
        public async Task<List<Author>>
    }
}
