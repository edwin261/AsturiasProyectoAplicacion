using DocumentManager.Models;

namespace DocumentManager.Application.Interfaces
{
    public interface IFilterService
    {
        List<DocumentItem> Filter(IEnumerable<DocumentItem> documents);
    }
}
