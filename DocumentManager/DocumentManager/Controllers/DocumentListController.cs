using DocumentManager.Data;
using DocumentManager.Models;
using Microsoft.AspNetCore.Mvc;

namespace DocumentManager.Controllers
{
    [ApiController]
    [Route("api/documentlists")]
    public class DocumentListController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DocumentListController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_context.DocumentLists.ToList());
        }

        [HttpPost]
        public IActionResult Create([FromBody] DocumentList model)
        {
            _context.DocumentLists.Add(model);
            _context.SaveChanges();
            return Ok(model);
        }
    }
}
