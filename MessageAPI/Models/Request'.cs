
namespace MessageAPI.Models
{
    public class Request<T> where T: class
    {
        public string clientId { get; set; }
        public T Message { get; set; }
    }

    public class TopicMessage : Request<string>
    {
        public string TopicId { get; set; }
    }
}