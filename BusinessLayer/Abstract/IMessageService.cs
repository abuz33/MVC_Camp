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
        List<Message> GetListInbox();
        List<Message> GetListSentBox();
        Message GetById(int id);
        void MessageAddBl(Message message);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
    }
}
