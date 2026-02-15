using DocumentManager.Application.Interfaces;
using DocumentManager.Models;

namespace DocumentManager.Domain.Services
{
    public class DocumentCollectionService
    {
        private readonly List<DocumentItem> _documents;

        public DocumentCollectionService(List<DocumentItem> documents)
        {
            _documents = documents;
        }

        public IDocumentIterator CreateIterator()
        {
            return new DocumentIterator(_documents);
        }
    }

    public class DocumentIterator : IDocumentIterator
    {
        private readonly List<DocumentItem> _documents;
        private int _position = 0;

        public DocumentIterator(List<DocumentItem> documents)
        {
            _documents = documents;
        }

        public bool HasNext()
        {
            return _position < _documents.Count;
        }

        public DocumentItem Next()
        {
            return _documents[_position++];
        }
    }
}
