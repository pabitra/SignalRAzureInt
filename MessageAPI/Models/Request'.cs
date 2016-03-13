
using System.ComponentModel.DataAnnotations;

namespace MessageAPI.Models
{
    public class BaseMessage<T> where T: class
    {
        public string ClientId { get; set; }
        
        [Required]
        public T Message { get; set; }
    }

    public class Message : BaseMessage<string>
    {
        [Required]
        public string TopicId { get; set; }

        [Required]
        public string SubscriptionName { get; set; }
    }

    
}