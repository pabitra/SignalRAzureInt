using System;
using System.Collections.Generic;
using Microsoft.AspNet.SignalR;
using Microsoft.Azure;
using Microsoft.ServiceBus.Messaging;

namespace MessageAPI.Hubs
{
    public class AzureServieBusHub : Hub
    {
       
        public void Subscribe(string clientId)
        {
            Groups.Add(Context.ConnectionId, clientId);
        }

        public void Unsubscribe(string clientId)
        {
            Groups.Remove(Context.ConnectionId, clientId);
        }
        

        public void Publish(string clientId)
        {

            var connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");

            SubscriptionClient subscriptionClient = SubscriptionClient.CreateFromConnectionString(connectionString, "TestTopic", "AllMessages");

            // Configure the callback options.
            OnMessageOptions options = new OnMessageOptions();

            options.AutoComplete = false;

            options.AutoRenewTimeout = TimeSpan.FromSeconds(10);
            
            subscriptionClient.OnMessage((message) =>
            {
                try
                {
                    // Process message from subscription.
                    Clients.Group(clientId).onReceiveMessage(message);

                    // Remove message from subscription.
                    message.Complete();
                }
                catch (Exception ex)
                {
                    // Indicates a problem, unlock message in subscription.
                    message.Abandon();

                    Clients.Group(clientId).onErrorMessage("Internal Server Error...");
                }
            }, options);


           
        }
    }
}