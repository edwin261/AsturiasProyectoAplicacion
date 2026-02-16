using DocumentManager.Data;
using DocumentManager.Domain.Observers;
using DocumentManager.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace DocumentManager.Controllers
{
    [ApiController]
    [Route("api/documents")]
    public class DocumentController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public DocumentController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        [HttpPost("upload")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Upload(
             IFormFile file,
             int listId,
             string tagColor,
             bool isPrivate)
        {
            if (file == null)
                return BadRequest("Documento a cargar es requerido, favor verificar.");

            var manager = new Domain.Services.DocumentManager();
            var document = manager.Create(file.FileName, tagColor, isPrivate, listId);

            var folder = Path.Combine(_env.WebRootPath, "storage", listId.ToString());
            Directory.CreateDirectory(folder);

            var path = Path.Combine(folder, file.FileName);

            using var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);

            _context.Documents.Add(document);
            _context.SaveChanges();

            var subject = new DocumentService();
            subject.Attach(new LoggingObserver());
            subject.Notify($"Cargado via API: {file.FileName}");

            return Ok(document);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var doc = _context.Documents.Find(id);
            if (doc == null) return NotFound();

            var folder = Path.Combine(_env.WebRootPath, "storage", doc.DocumentListId.ToString());
            var path = Path.Combine(folder, doc.FileName);

            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);

            _context.Documents.Remove(doc);
            _context.SaveChanges();

            if (Directory.Exists(folder) &&
                !Directory.EnumerateFileSystemEntries(folder).Any())
                Directory.Delete(folder);

            return Ok("Eliminado");
        }
    }
}
