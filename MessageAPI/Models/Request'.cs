
using System.ComponentModel.DataAnnotations;

namespace MessageAPI.Models
{
    public class BaseMessage<T> where T: class
    {
        public string ClientId { get; set; }
        
        [Required]
        public T Message { get; set; }
        [Required]
        public string TopicId { get; set; }

        [Required]
        public string SubscriptionName { get; set; }
    }

    public class Message : BaseMessage<string>
    {
      
    }

    public class RoomTemperature
    {
        public string RecordDateTime { get; set; }
        public string RoomCode { get; set; }
        public double Temperature { get; set; }
    }

    public class RoomTemperatureMessage : BaseMessage<RoomTemperature>
    {
        
    }
    
}