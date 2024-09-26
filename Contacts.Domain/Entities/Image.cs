namespace Contacts.Domain.Entities
{
    public class Image
    {
        public int Id { get; }
        public Uri Uri { get; }
        public Image(int id, Uri uri)
        {
            Id = id;
            Uri = uri;
        }
    }
}
