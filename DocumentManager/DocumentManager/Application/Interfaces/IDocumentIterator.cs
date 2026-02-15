using DocumentManager.Models;

namespace DocumentManager.Application.Interfaces
{
    public interface IDocumentIterator
    {
        bool HasNext();
        DocumentItem Next();
    }
}
