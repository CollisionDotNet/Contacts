using Contacts.Domain.Exceptions;
using System.Text;
using System.Text.RegularExpressions;

namespace Contacts.Domain.ValueObjects
{
    public class Image : ValueObject
    {        
        public Uri Uri { get; }
        public Image(Uri uri)
        {
            StringBuilder validationErrors = new StringBuilder();
            if (uri == null)
                validationErrors.Append($"{nameof(Uri)} can't be null");

            if (validationErrors.Length > 0)
                throw new ValidationException(validationErrors.ToString());

            Uri = uri!;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Uri;
        }
    }
}
