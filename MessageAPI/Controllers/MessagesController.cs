using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using MessageAPI.Hubs;
using MessageAPI.Models;
using Microsoft.Azure;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace MessageAPI.Controllers
{
    public class MessagesController : SignalRHubController<AzureServieBusHub>
    {
        private readonly string _connectionString; 
        public MessagesController()
        {
            _connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");    
        }

        [HttpPost]
        public async Task<IHttpActionResult> SendMessage(Message message)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var namespaceManager = NamespaceManager.CreateFromConnectionString(_connectionString);

                    //TopicCreation
                    if (!namespaceManager.TopicExists(message.TopicId))
                    {
                        TopicDescription td = new TopicDescription(message.TopicId);
                        td.MaxSizeInMegabytes = 5120;
                        td.DefaultMessageTimeToLive = new TimeSpan(0, 0, 60);
                        namespaceManager.CreateTopic(message.TopicId);
                    }

                    //Subscription Creation;
                    if (!namespaceManager.SubscriptionExists(message.TopicId, message.SubscriptionName))
                    {
                        namespaceManager.CreateSubscription(message.TopicId, message.SubscriptionName);
                    }


                    TopicClient tpClient = TopicClient.CreateFromConnectionString(_connectionString, message.TopicId);

                    BrokeredMessage topicMessage = new BrokeredMessage(message.Message);

                    // Set additional custom app-specific property.
                    topicMessage.Properties["MessageNumber"] = message.TopicId;

                   await tpClient.SendAsync(topicMessage).ConfigureAwait(false);
                }
                
                return StatusCode(HttpStatusCode.NoContent);

            }
            catch (Exception ex)
            {

                return StatusCode(HttpStatusCode.InternalServerError);
            }
        }


        [HttpGet]
        public void SubscribeToTopic(string topicId, string subscriptionName, string clientId)
        {
            

            SubscriptionClient subscriptionClient = SubscriptionClient.CreateFromConnectionString(_connectionString, topicId, subscriptionName);

            // Configure the callback options.
            OnMessageOptions options = new OnMessageOptions();

            options.AutoComplete = false;

            options.AutoRenewTimeout = TimeSpan.FromSeconds(10);

            subscriptionClient.OnMessage((message) =>
            {
                try
                {

                    var responsemessage = new Message() { SubscriptionName =subscriptionName, Message = message.GetBody<string>()};
                    
                    // Process message from subscription.
                    Hub.Clients.Group(clientId).onReceiveMessage(responsemessage);

                    // Remove message from subscription.
                    message.Complete();
                }
                catch (Exception ex)
                {
                    // Indicates a problem, unlock message in subscription.
                    message.Abandon();

                    Hub.Clients.Group(clientId).onErrorMessage("Error While getting the message from the respective subscription");
                }
            }, options);
        }

    }
}
