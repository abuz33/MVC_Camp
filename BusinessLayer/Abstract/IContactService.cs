using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetList();
        List<Contact> GetUnread();
        Contact GetById(int id);
        void ContactAddBl(Contact contact);
        void ContactDelete(Contact contact);
        void ContactUpdate(Contact contact);
    }
}
