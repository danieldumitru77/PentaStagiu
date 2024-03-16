using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID.DependencyInversionPrinciple
{
    public class DIGoodV
    {
    }

    public interface IMessenger
    {
        void SendMessage();
    }

    public class EmaiTest : IMessenger
    {
        public void SendMessage() {
        //code to send email
        }
    }
    public class SMS : IMessenger
    {
        public void SendMessage()
        {
            //code to send SMS
        }
    }
    public class NotificationV
    {
        private IMessenger _iMessenger;
        public NotificationV(IMessenger pMessenger)
        {
            _iMessenger = pMessenger;
        }
        
        public void DoNotify()
        {
            //some logic
            _iMessenger.SendMessage();

        }
    }

    class Program
    {
        public void Startup()
        {
            new NotificationV(MessengerFactory.Create(MessengerType.Email)).DoNotify();
            //new NotificationV(new SMS()).DoNotify();
            new NotificationV(MessengerFactory.Create(MessengerType.SMS)).DoNotify();
        }
    }

    enum MessengerType
    {
        Email,
        SMS
    }


    class MessengerFactory
    {
        public static IMessenger Create(MessengerType messengerType) { 
        
        switch (messengerType)
            {
                case MessengerType.Email:
                    return new EmaiTest();
                   
                case MessengerType.SMS:
                    return new SMS();
                   
                default:
                    return null;
                    
            }
        }
    }
}
