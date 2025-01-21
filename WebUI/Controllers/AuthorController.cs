using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebUI.Domain.Contracts;
using WebUI.Services;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController(IAuthorService authorService, IMapper mapper) : ControllerBase
    {
        [HttpGet]
        [Route("GetAllAuthor")]
        public async Task<IActionResult> GetAllAuthorAsync()
        {
            var authors = await authorService.GetAllAuthorAsync();
            var authorDTO = mapper.Map<List<GetAuthorDTO>>(authors);
            return Ok(authorDTO);
        }

        [HttpGet]
        [Route("GetAuthorById/{id}")]
        public async Task<IActionResult> GetAuthorByIdAsync(Guid id)
        {
            var author = await authorService.GetAuthorByIdAsync(id);
            if (author == null)
            {
                return NotFound();
            }

            var authorDTO = mapper.Map<GetAuthorDTO>(author);
            return Ok(authorDTO);
        }

        [HttpPost]
        [Route("CreateNewAuthor")]
        public async Task<IActionResult> CreateNewAuthorAsync([FromBody] CreateAuthor createAuthor)
        {
            try
            {
                var (status, error) = await authorService.CreateNewAuthorAsync(createAuthor);
                return status ? Ok(new { status, errorMessage = "" }) : Ok(new { errorMessage = error });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("UpdateAuthor/{id}")]
        public async Task<IActionResult> UpdateAuthorAsync(Guid id, [FromBody] UpdateAuthor updateAuthor)
        {
            try
            {
                var Author = await authorService.GetAuthorByIdAsync(id);
                if (Author == null)
                {
                    return NotFound();
                }
                var (status, error) = await authorService.UpdateAuthorAsync(updateAuthor);
                return status ? Ok(new { status, errorMessage = "" }) : Ok(new { errorMessage = error });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("DeleteAuthor/{id}")]
        public async Task<IActionResult> DeleteAuthorAsync(Guid id)
        {
            try
            {
                var Author = await authorService.GetAuthorByIdAsync(id);
                if (Author == null)
                {
                    return NotFound();
                }
                var (status, error) = await authorService.DeleteAuthorAsync(Author);
                return status ? Ok(new { status, errorMessage = "" }) : Ok(new { errorMessage = error });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
