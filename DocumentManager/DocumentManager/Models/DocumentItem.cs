namespace DocumentManager.Models
{
    public class DocumentItem
    {
        public int Id { get; set; }
        public string FileName { get; set; } = string.Empty;
        public string TagColor { get; set; } = string.Empty;
        public bool IsPrivate { get; set; }

        public int DocumentListId { get; set; }
        public DocumentList DocumentList { get; set; } = new();
    }
}