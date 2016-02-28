
using System;
using System.Net;
using System.Web;
using System.Web.Http;
using MessageAPI.Hubs;
using MessageAPI.Models;
using Microsoft.Azure;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace MessageAPI.Controllers
{
    public class MessagesController : ApiController
    {

        //Client will Send the message (Client could be mobile or windows , console)
        public IHttpActionResult SendMessage(TopicMessage message)
        {
            try
            {

                var connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");

                TopicClient tpClient = TopicClient.CreateFromConnectionString(connectionString, "TestTopic");

                BrokeredMessage topicMessage = new BrokeredMessage(message.Message);

                // Set additional custom app-specific property.
                topicMessage.Properties["MessageNumber"] = message.TopicId;

                tpClient.Send(topicMessage);


                return StatusCode(HttpStatusCode.NoContent);
            }
            catch (Exception ex)
            {

                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }


    }
}
