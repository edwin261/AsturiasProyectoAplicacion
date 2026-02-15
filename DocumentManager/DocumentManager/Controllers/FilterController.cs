using DocumentManager.Application.Interfaces;
using DocumentManager.Data;
using DocumentManager.DesignPatterns.Singleton;
using DocumentManager.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace DocumentManager.Controllers
{
    [ApiController]
    [Route("api/filter")]
    public class FilterController : Controller
    {
        private readonly AppDbContext _context;

        public FilterController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Filter(string? tag, int? listId, string? password)
        {
            var documents = _context.Documents.ToList();

            if (!PasswordManager.Instance.Validate(password!))
                documents = [.. documents.Where(d => !d.IsPrivate)];

            IFilterService? strategy = null;

            if (!string.IsNullOrEmpty(tag))
                strategy = new TagFilterService(tag);
            else if (listId.HasValue)
                strategy = new ListFilterService(listId.Value);

            if (strategy != null)
                documents = [.. strategy.Filter(documents)];

            return Ok(documents);
        }
    }
}
