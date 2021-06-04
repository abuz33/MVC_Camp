using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
   public class DraftMessageManager:IDraftMessageService
   {
       IDraftMessageDal _draftMessageDal;

       public DraftMessageManager(IDraftMessageDal draftMessageDal)
       {
           _draftMessageDal = draftMessageDal;
       }


       public List<DraftMessage> GetList(string mail)
       {
           return _draftMessageDal.List(x => x.SenderMail == mail);
       }
        
        public DraftMessage GetById(int id)
       {
           return _draftMessageDal.Get(x => x.Id == id);
       }

       public void DraftMessageAddBl(DraftMessage draftMessage)
       {
           _draftMessageDal.Insert(draftMessage);
       }

       public void DraftMessageDelete(DraftMessage draftMessage)
       {
           _draftMessageDal.Delete(draftMessage);
       }

       public void DraftMessageUpdate(DraftMessage draftMessage)
       {
           _draftMessageDal.Update(draftMessage);
       }
   }
}
