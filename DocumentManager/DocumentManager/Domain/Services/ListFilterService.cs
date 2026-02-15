using DocumentManager.Application.Interfaces;
using DocumentManager.Models;

namespace DocumentManager.Domain.Services
{
    public class ListFilterService : IFilterService
    {
        private readonly int _listId;

        public ListFilterService(int listId)
        {
            _listId = listId;
        }

        public List<DocumentItem> Filter(IEnumerable<DocumentItem> documents)
        {
            return [..documents.Where(d => d.DocumentListId == _listId)];
        }
    }
}
