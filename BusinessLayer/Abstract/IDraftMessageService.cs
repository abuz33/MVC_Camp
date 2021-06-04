using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IDraftMessageService
    {
        List<DraftMessage> GetList(string mail);
        DraftMessage GetById(int id);
        void DraftMessageAddBl(DraftMessage draftMessage);
        void DraftMessageDelete(DraftMessage draftMessage);
        void DraftMessageUpdate(DraftMessage draftMessage);
    }
}
