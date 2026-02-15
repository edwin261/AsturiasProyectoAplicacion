using DocumentManager.Application.Interfaces;
using DocumentManager.Models;

namespace DocumentManager.Domain.Services
{
    public class TagFilterService : IFilterService
    {
        private readonly string _tag;

        public TagFilterService(string tag)
        {
            _tag = tag;
        }

        public List<DocumentItem> Filter(IEnumerable<DocumentItem> documents)
        {
            return [.. documents.Where(d => d.TagColor == _tag)];
        }
    }
}
