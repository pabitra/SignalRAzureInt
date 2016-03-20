using System;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using MessageAPI.Hubs;
using MessageAPI.Models;
using Microsoft.Azure;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace MessageAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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

                    CreateIfNotExists(message.TopicId, message.SubscriptionName);

                    var tpClient = TopicClient.CreateFromConnectionString(_connectionString, message.TopicId);

                    var topicMessage = new BrokeredMessage(message.Message);

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

        [HttpPost]
        public async Task<IHttpActionResult> SendRoomTemperature(RoomTemperatureMessage message)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    CreateIfNotExists(message.TopicId, message.SubscriptionName);
                    
                    var tpClient = TopicClient.CreateFromConnectionString(_connectionString, message.TopicId);

                    var topicMessage = new BrokeredMessage(message.Message);

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
            if (subscriptionName.Equals("TestSubscription", StringComparison.CurrentCultureIgnoreCase))
            {

                var subscriptionClient = SubscriptionClient.CreateFromConnectionString(_connectionString, topicId,
                    subscriptionName);

                // Configure the callback options.
                OnMessageOptions options = new OnMessageOptions
                {
                    AutoComplete = false,
                    AutoRenewTimeout = TimeSpan.FromSeconds(10)
                };

                subscriptionClient.OnMessage((message) =>
                {
                    try
                    {

                        var responsemessage = new Message()
                        {
                            SubscriptionName = subscriptionName,
                            Message = message.GetBody<string>()
                        };

                        // Process message from subscription.
                        Hub.Clients.Group(clientId).onReceiveMessage(responsemessage);

                        // Remove message from subscription.
                        message.Complete();
                    }
                    catch (Exception ex)
                    {
                        // Indicates a problem, unlock message in subscription.
                        message.Abandon();
                        var errormessage = new {message = "Server Error, Please contact your system adminstrator"};

                        Hub.Clients.Group(clientId).onErrorMessage(errormessage);
                    }
                }, options);
            }
        }

        [HttpGet]
        public void SubscribeToRoomTemperature(string topicId, string subscriptionName, string clientId)
        {

            var subscriptionClient = SubscriptionClient.CreateFromConnectionString(_connectionString, topicId, subscriptionName);

            // Configure the callback options.
            OnMessageOptions options = new OnMessageOptions
            {
                AutoComplete = false,
                AutoRenewTimeout = TimeSpan.FromSeconds(10)
            };

            subscriptionClient.OnMessage((message) =>
            {
                try
                {

                    var responsemessage = new RoomTemperatureMessage() { SubscriptionName = subscriptionName, Message = message.GetBody<RoomTemperature>() };

                    // Process message from subscription.
                    Hub.Clients.Group(clientId).onReceiveMessage(responsemessage);

                    // Remove message from subscription.
                    message.Complete();
                }
                catch (Exception ex)
                {
                    // Indicates a problem, unlock message in subscription.
                    message.Abandon();
                    var errormessage = new { message = "Server Error, Please contact your system adminstrator" };

                    Hub.Clients.Group(clientId).onErrorMessage(errormessage);
                }
            }, options);
        }

        private void CreateIfNotExists(string topicId, string subscriptionName)
        {
            var namespaceManager = NamespaceManager.CreateFromConnectionString(_connectionString);

            //TopicCreation
            if (!namespaceManager.TopicExists(topicId))
            {
                TopicDescription td = new TopicDescription(topicId)
                {
                    MaxSizeInMegabytes = 5120,
                    DefaultMessageTimeToLive = new TimeSpan(0, 0, 60)
                };
                namespaceManager.CreateTopic(topicId);
            }

            //Subscription Creation;
            if (!namespaceManager.SubscriptionExists(topicId, subscriptionName))
            {
                namespaceManager.CreateSubscription(topicId, subscriptionName);
            }

        }

    }
}
