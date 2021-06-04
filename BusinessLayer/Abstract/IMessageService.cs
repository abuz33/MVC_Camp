using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
   public interface IMessageService
    {
        List<Message> GetListInbox(string email);
        List<Message> GetListSentBox(string email);
        List<Message> GetUnreadListInbox(string email);
        List<Message> GetUnreadListSentBox(string email);
        Message GetById(int id);
        void MessageAddBl(Message message);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
    }
}
