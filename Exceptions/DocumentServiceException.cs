using System.Runtime.Serialization;

namespace CloudDoc.Exceptions
{
    public class DocumentServiceException : Exception
    {
        public DocumentServiceException(string message):base(message) { }
        public DocumentServiceException(string message,Exception innerException):base(message,innerException){ }
    }
}
