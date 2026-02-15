using DocumentManager.Models;

namespace DocumentManager.Domain.Services
{
    public class DocumentManager
    {
        public virtual DocumentItem Create(string fileName, string tagColor, bool isPrivate, int listId)
        {
            return new DocumentItem
            {
                FileName = fileName,
                TagColor = tagColor,
                IsPrivate = isPrivate,
                DocumentListId = listId
            };
        }
    }
}
