using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> GetListInbox(string email)
        {
            return _messageDal.List(x => x.ReceiverMail == email);
        }

        public List<Message> GetListSentBox(string email)
        {
            return _messageDal.List(x => x.SenderMail == email);
        }

        public List<Message> GetUnreadListInbox(string email)
        {
            return _messageDal.List(x => x.ReceiverMail == email && x.IsRead == false);
        }

        public List<Message> GetUnreadListSentBox(string email)
        {
            return _messageDal.List(x => x.SenderMail == email && x.IsRead == false);
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.Id == id);
        }

        public void MessageAddBl(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message) => _messageDal.Delete(message);

        public void MessageUpdate(Message message)
        {
            if (message != null) _messageDal.Update(message);
        }
    }
}
