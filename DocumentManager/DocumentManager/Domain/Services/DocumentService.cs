using DocumentManager.Application.Interfaces;

namespace DocumentManager.Domain.Services
{
    public class DocumentService
    {
        private readonly List<IDocumentService> _observers = new();

        public void Attach(IDocumentService observer)
        {
            _observers.Add(observer);
        }

        public void Notify(string message)
        {
            foreach (var observer in _observers)
                observer.Update(message);
        }
    }
}