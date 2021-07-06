using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class WriterManager:IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public List<Writer> GetList()
        {
            return _writerDal.List();
        }

        public void AddWriter(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public void DeleteWriter(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public void UpdateWriter(Writer writer)
        {
            _writerDal.Update(writer);
        }

        public int GetWriterId(string mail)
        {
            return _writerDal.Get(x => x.WriterMail == mail).WriterId;
        }
        
        public Writer GetById(int id)
        {
            return _writerDal.Get(x => x.WriterId == id);
        }

        public Writer GetByMail(string mail)
        {
            return _writerDal.Get(x => x.WriterMail == mail);
        }
    }
}
