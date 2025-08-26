using Gridify;
using GridifyInDotNet.Models;
using Microsoft.AspNetCore.Mvc;

namespace Gridify_In_DotNet.Controllers;

[ApiController]
[Route("[controller]")]
public class GridifyController : ControllerBase
{
    private readonly BookContext _context;

    public GridifyController(BookContext context)
    {
        _context = context;
    }

    [HttpGet("books")]
    public IActionResult GetBooks([FromQuery] GridifyQuery model)
    {
        if (!_context.Books.Any())
        {
            var books = Enumerable.Range(1, 100).Select(index => new Book
            {
                Title = $"Book {index}",
                Date = DateTime.Now.AddDays(-index)
            }).ToList();

            _context.Books.AddRange(books);
            _context.SaveChanges();
        }

        var result = _context.Books.GridifyQueryable(model);

        return Ok(result);
    }
}
