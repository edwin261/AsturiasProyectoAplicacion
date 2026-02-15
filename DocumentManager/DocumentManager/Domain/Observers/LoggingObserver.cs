using DocumentManager.Application.Interfaces;
using System.Diagnostics;

namespace DocumentManager.Domain.Observers
{
    public class LoggingObserver : IDocumentService
    {
        public void Update(string message)
        {
            Debug.WriteLine($"Se inicio una notificación: {message}");
        }
    }
}