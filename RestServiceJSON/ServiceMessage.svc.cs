using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace RestServiceJSON
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ServiceMessage" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ServiceMessage.svc or ServiceMessage.svc.cs at the Solution Explorer and start debugging.
    public class ServiceMessage : IServiceMessage
    {
        List<Message> IServiceMessage.findAll()
        {
            using (MessageDBEntities msg = new MessageDBEntities())
            {
                return msg.MessageEntities.Select(me => new Message {
                    Id = me.id,
                    message = me.message
                }).ToList();
            }
        }

        Message IServiceMessage.find(string id)
        {
            int nid = Convert.ToInt32(id);
            using (MessageDBEntities msg = new MessageDBEntities())
            {
                return msg.MessageEntities.Where(me => me.id == nid).Select(me => new Message
                {
                    Id = me.id,
                    message = me.message
                }).First();
            }
        }

        bool IServiceMessage.create(Message message)
        {
            using (MessageDBEntities msg = new MessageDBEntities())
            {
                try
                {
                    MessageEntity me = new MessageEntity();
                    me.message = message.message;
                    msg.MessageEntities.Add(me);
                    msg.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        bool IServiceMessage.edit(Message message)
        {
            using (MessageDBEntities msg = new MessageDBEntities())
            {
                try
                {
                    MessageEntity me = msg.MessageEntities.Single(p => p.id == message.Id);
                    me.message = message.message;
                    msg.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        bool IServiceMessage.delete(Message message)
        {
            using (MessageDBEntities msg = new MessageDBEntities())
            {
                try
                {
                    MessageEntity me = msg.MessageEntities.Single(p => p.id == message.Id);
                    msg.MessageEntities.Remove(me);
                    msg.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

    }
}
