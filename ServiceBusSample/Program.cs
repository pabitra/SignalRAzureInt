﻿
using System;
using Microsoft.Azure;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;

namespace ServiceBusSample
{
    class Program
    {
       
        static void Main(string[] args)
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
            if (!namespaceManager.SubscriptionExists("TestTopic", "TestSubscription"))
            {
                namespaceManager.CreateSubscription("TestTopic", "TestSubscription");
            }

          

            for (var i = 0; i <= 100; i++)
            {
                TopicClient tpClient = TopicClient.CreateFromConnectionString(connectionString, "TestTopic");

                BrokeredMessage topicMessage = new BrokeredMessage("Test message " + i);

                // Set additional custom app-specific property.
                topicMessage.Properties["MessageNumber"] = 100;

                tpClient.Send(topicMessage);

                tpClient.Close();
            }

            Console.WriteLine("100 message were sent succcessfully");    

            Console.ReadKey();
            SubscriptionClient subscriptionClient = SubscriptionClient.CreateFromConnectionString(connectionString, "TestTopic", "TestSubscription");

            // Configure the callback options.
            OnMessageOptions options = new OnMessageOptions();
            options.AutoComplete = false;
            options.AutoRenewTimeout = TimeSpan.FromMinutes(1);

            subscriptionClient.OnMessage((message) =>
            {
                try
                {
                    // Process message from subscription.
                    Console.WriteLine("\n**High Messages**");
                    Console.WriteLine("Body: " + message.GetBody<string>());
                    Console.WriteLine("MessageID: " + message.MessageId);
                    Console.WriteLine("Message Number: " +
                        message.Properties["MessageNumber"]);

                    // Remove message from subscription.
                    message.Complete();
                }
                catch (Exception)
                {
                    // Indicates a problem, unlock message in subscription.
                    message.Abandon();
                }
            }, options);

            Console.ReadKey();
        }
    }
}
