using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public List<Message> GetListInbox()
        {
            return _messageDal.List(x => x.ReceiverMail == "admin@gmail.com");
        }

        public List<Message> GetListSentBox()
        {
            return _messageDal.List(x => x.SenderMail == "admin@gmail.com");
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
