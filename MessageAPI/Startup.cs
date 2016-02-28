using System;
using Microsoft.Azure;
using Microsoft.Owin;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Owin;

[assembly: OwinStartup(typeof(MessageAPI.Startup))]

namespace MessageAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");

            var namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);

            //TopicCreation
            if (!namespaceManager.TopicExists("TestTopic"))
            {
                TopicDescription td = new TopicDescription("TestTopic");
                td.MaxSizeInMegabytes = 5120;
                td.DefaultMessageTimeToLive = new TimeSpan(0, 1, 0);
                namespaceManager.CreateTopic("TestTopic");
            }

            //Subscription Creation;
            if (!namespaceManager.SubscriptionExists("TestTopic", "AllMessages"))
            {
                namespaceManager.CreateSubscription("TestTopic", "AllMessages");
            }
        }
    }
}
